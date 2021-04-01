using Dominio.Recursos;
using Infraestructura;
using Infraestructura.CRUD;
using System;
using System.Data;

namespace Dominio.Conectores
{
    public class Requisicion
    {
        private readonly BDConsultar _BDConsultar = new BDConsultar();
        private readonly BDPedidos _BDPedidos = new BDPedidos();
        private readonly Correo _Correo = new Correo();
        private readonly BDBodegas _BDBodegas = new BDBodegas();
        private readonly Compromiso _Compromiso = new Compromiso();
        private readonly Infraestructura.Ws_GT_Real.wsGenerarPlano _Importar = new Infraestructura.Ws_GT_Real.wsGenerarPlano();

        public string Importar(string Transferencia)
        {
            return RecorrerInformacion(_BDPedidos.Sp_RequisicionPorTransferencia(Transferencia));
        }

        private string RecorrerInformacion(DataSet DsRequisicion)
        {
            var Respuesta = string.Empty;

            if (DsRequisicion.Tables[1].Rows.Count > 0)
            {
                try
                {
                    var Ruta = Configuraciones.RutaPlanosReal;

                    var Bodega = ValidarInventario(DsRequisicion.Tables[2].Rows[0]["f441_codigo_barras"].ToString(),
                        DsRequisicion.Tables[2].Rows[0]["f441_id_bodega"].ToString());

                    if (Bodega != string.Empty)
                    {
                        DsRequisicion.Tables[1].Rows[0]["f440_id_bodega_salida"] = Bodega;
                        DsRequisicion.Tables[2].Rows[0]["f441_id_bodega"] = Bodega;
                    }
                    else
                    {
                        DsRequisicion.Tables[1].Rows[0]["f440_id_bodega_salida"] = "";
                        DsRequisicion.Tables[2].Rows[0]["f441_id_bodega"] = "";
                    }

                    Respuesta = _Importar.ImportarDatosDS(91930, "Ecommerce_Requisicion_Transito", 2, "1", "gt", "gt", DsRequisicion, ref Ruta);
                    DataSet Requisicion = new DataSet();
                    var CampoLlave = DsRequisicion.Tables[2].Rows[0]["f441_notas"].ToString();
                    var CampoLlaveSplit = CampoLlave.Split('-');
                    var OrderId = CampoLlaveSplit[0] + '-' + CampoLlaveSplit[1];

                    if (Respuesta == "Importacion exitosa")
                    {
                        Requisicion = _BDPedidos.Sp_ConsultarCampoLlaveRequisicion(DsRequisicion.Tables[2].Rows[0]["f441_notas"].ToString());
                        string Rq = Requisicion.Tables[0].Rows[0]["CampoLlave"].ToString();
                        string Orden = Requisicion.Tables[0].Rows[0]["OrderId"].ToString();
                        string Secuencia = Requisicion.Tables[0].Rows[0]["Secuencia"].ToString();

                        _BDPedidos.Sp_ActualizarRequisicion(DsRequisicion.Tables[2].Rows[0]["f441_notas"].ToString(), Bodega, Rq);

                        DataSet DsDatosCorreo = _BDConsultar.Correo(Bodega);

                        _Correo.Sencillo(DsDatosCorreo.Tables[0].Rows[0]["CorreoRemitente"].ToString(),
                            DsDatosCorreo.Tables[0].Rows[0]["ClaveMail"].ToString(),
                            DsDatosCorreo.Tables[0].Rows[0]["ServidorDeCorreo"].ToString(),
                            Convert.ToInt32(DsDatosCorreo.Tables[0].Rows[0]["Puerto"]),
                            Convert.ToBoolean(DsDatosCorreo.Tables[0].Rows[0]["SSL"]),
                            DsDatosCorreo.Tables[0].Rows[0]["Correo"].ToString(),
                        "Tienda Online - Solicitud de mercancia: " + Orden + "(" + Secuencia + ") - " + Rq,
                        "Se ha generado la siguiente requisición " + Rq + " Número de orden: " + Orden + "(" + Secuencia + ")" +
                        "<br>" + "EAN: " + DsRequisicion.Tables[2].Rows[0]["f441_codigo_barras"].ToString());

                        _Compromiso.Importar(OrderId, CampoLlave, Rq, DsRequisicion.Tables[2].Rows[0]["f441_codigo_barras"].ToString(), Bodega,
                             Requisicion.Tables[0].Rows[0]["RowId"].ToString());

                        return Rq;
                    }
                    else
                    {
                        return Respuesta;
                    }
                }
                catch (Exception Ex)
                {
                    return Ex.Message.ToString();
                }
            }
            else
            {
                return "No hay datos para procesar";
            }
        }

        public string ValidarInventario(string Barra, string IdBodega)
        {
            DataSet DsBodegas = _BDBodegas.Sp_ListadoBodegasPriorizacionExclusion(IdBodega);
            DataSet DsInventario = new DataSet();
            var Bodega = string.Empty;

            foreach (DataRow Registro in DsBodegas.Tables[0].Rows)
            {
                DsInventario = _BDPedidos.Sp_ValidarInventario(Registro["Bodega"].ToString().Substring(0, 5), Barra, 1);

                if (DsInventario.Tables[0].Rows.Count > 0)
                {
                    Bodega = Registro["Bodega"].ToString().Substring(0, 5);
                    return Bodega;
                }
            }
            return Bodega;
        }
    }
}
