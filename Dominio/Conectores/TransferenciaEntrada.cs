using Dominio.Recursos;
using Infraestructura;
using Infraestructura.CRUD;
using System;
using System.Data;

namespace Dominio.Conectores
{
    public class TransferenciaEntrada
    {
        private readonly Infraestructura.Ws_GT_Real.wsGenerarPlano _Importar = new Infraestructura.Ws_GT_Real.wsGenerarPlano();
        private BDPedidos _BDPedidos = new BDPedidos();
        private readonly Deserializar _Deserializar = new Deserializar();

        public string Importar(string Transferencia)
        {
            return RecorrerInformacion(_BDPedidos.Sp_ConsultarEntradas(Transferencia));
        }

        private string RecorrerInformacion(DataSet DsEntrada)
        {
            var Respuesta = string.Empty;

            if (DsEntrada.Tables[1].Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow Registro in DsEntrada.Tables[1].Rows)
                    {
                        var Ruta = Configuraciones.RutaPlanosReal;

                        DataTable DtInicial = DsEntrada.Tables[0].Copy();
                        DataTable DtDocumento = DsEntrada.Tables[1].Copy();
                        DataTable DtFinal = DsEntrada.Tables[2].Copy();

                        DataSet DsTransferencia = new DataSet();
                        DsTransferencia.Tables.Add(DtInicial);
                        DsTransferencia.Tables.Add(DtDocumento);
                        DsTransferencia.Tables.Add(DtFinal);

                        Respuesta = _Importar.ImportarDatosDS(91936, "Ecommerce_Transf_Trans_Ent_Desde_Sal", 2, "1", "gt", "gt", DsEntrada, ref Ruta);

                        var CampoLlave = Registro["f350_notas"].ToString();
                        var CampoLlaveSplit = CampoLlave.Split('-');
                        var OrderId = CampoLlaveSplit[0] + '-' + CampoLlaveSplit[1];

                        if (Respuesta == "Importacion exitosa")
                        {
                            DataSet DsEntradas = _BDPedidos.Sp_ConsultarCampoLlave(Registro["f350_id_co"].ToString(), CampoLlave);
                            _BDPedidos.Sp_ActualizarEntrada(CampoLlave, DsEntradas.Tables[0].Rows[0]["CampoLlave"].ToString());
                            _BDPedidos.Sp_ActualizarEstados(OrderId, "7");
                        }
                        else
                        { 
                            if (Respuesta.Contains("El estado del documento de salida en tránsito no permite su modificación."))
                            {
                                Respuesta = "Entrada: La transferencia en transito de salida debe estar en estado aprobado.";
                            }
                            else
                            {
                                Respuesta = "Entrada: " + _Deserializar.XML(Respuesta);
                            }
                        }
                    }
                }
                catch (Exception Ex)
                {
                    return Ex.Message.ToString();
                }
            }
            return Respuesta;
        }
    }
}
