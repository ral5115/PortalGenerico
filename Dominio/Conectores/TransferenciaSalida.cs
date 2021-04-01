using Dominio.Recursos;
using Infraestructura;
using Infraestructura.CRUD;
using System;
using System.Data;

namespace Dominio.Conectores
{
    public class TransferenciaSalida
    {
        private readonly BDPedidos _BDPedidos = new BDPedidos();
        private readonly Deserializar _Deserializar = new Deserializar();
        private readonly Infraestructura.Ws_GT_Real.wsGenerarPlano _Importar = new Infraestructura.Ws_GT_Real.wsGenerarPlano();

        public string Importar(string Requisicion)
        {
            return RecorrerInformacion(_BDPedidos.Sp_TransferenciasPorRequisicion(Requisicion), Requisicion);
        }

        private string RecorrerInformacion(DataSet DsTransferencia, string Requisicion)
        {
            var Respuesta = string.Empty;

            if (DsTransferencia.Tables[1].Rows.Count > 0)
            {
                try
                {
                    var Ruta = Configuraciones.RutaPlanosReal;

                    Respuesta = _Importar.ImportarDatosDS(91934, "Ecommerce_Transf_Sal_Req_Interna", 2, "1", "gt", "gt", DsTransferencia, ref Ruta);

                    var CampoLlave = (DsTransferencia.Tables[1].Rows[0]["f350_notas"].ToString());
                    var CampoLlaveSplit = CampoLlave.Split('-');
                    var OrderId = CampoLlaveSplit[0] + '-' + CampoLlaveSplit[1];

                    if (Respuesta == "Importacion exitosa")
                    {
                        DataSet DsTranferencia = _BDPedidos.Sp_ConsultarCampoLlave(DsTransferencia.Tables[1].Rows[0]["f350_id_co"].ToString(), CampoLlave);
                        _BDPedidos.Sp_ActualizarTransferencia(CampoLlave, DsTranferencia.Tables[0].Rows[0]["CampoLlave"].ToString());
                        return DsTranferencia.Tables[0].Rows[0]["CampoLlave"].ToString() + " - " + Respuesta;
                    }
                }
                catch (Exception Ex)
                {
                    return Ex.Message.ToString();
                }
            }
            else
            {
                return Requisicion;
            }
            return _Deserializar.XML(Requisicion); ;
        }
    }
}
