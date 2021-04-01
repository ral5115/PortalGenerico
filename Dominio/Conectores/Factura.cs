using Dominio.Recursos;
using Infraestructura;
using Infraestructura.CRUD;
using System;
using System.Data;

namespace Dominio.Conectores
{
    public class Factura
    {
        private readonly Infraestructura.Ws_GT_Real.wsGenerarPlano _Importar = new Infraestructura.Ws_GT_Real.wsGenerarPlano();
        private readonly BDPedidos _BDPedidos = new BDPedidos();
        private readonly Deserializar _Deserializar = new Deserializar();

        public string Importar(string OrderId, int RowIdEmpaques, string CodigoAlterno, string RespuestaTercero)
        {
            if (RespuestaTercero.Contains("Tercero: Importacion exitosa"))
            {
                return RecorrerInformacion(_BDPedidos.Sp_ConsultarFacturasPorOrderId(OrderId), OrderId, RowIdEmpaques, CodigoAlterno);
            }
            return "Factura: Sin Procesar";
        }

        private string RecorrerInformacion(DataSet DsFacturas, string OrderId, int RowIdEmpaques, string CodigoAlterno)
        {
            var Respuesta = string.Empty;

            try
            {
                if (DsFacturas.Tables[1].Rows.Count > 0)
                {
                    var Ruta = Configuraciones.RutaPlanosReal;

                    Respuesta = "Factura: " + _Importar.ImportarDatosDS(100414, "Ecommerce_Factura_PrecioUnitario", 2, "1", "gt", "gt", DsFacturas, ref Ruta);

                    if (Respuesta == "Factura: Importacion exitosa")
                    {
                        var Factura = _BDPedidos.Sp_ConsultarCampoLlaveFactura(OrderId).Tables[0].Rows[0]["Factura"].ToString();
                        _BDPedidos.Sp_ActualizarEstados(OrderId, "9");
                        _BDPedidos.Sp_ActualizarFacturaEmpaqueYMedida(OrderId, Factura, RowIdEmpaques, CodigoAlterno);
                        return Respuesta;
                    }
                    else
                    {
                        Respuesta = "Factura: " + _Deserializar.XML(Respuesta);
                    }
                }
                else
                {
                    Respuesta = "Factura: No se encontraron datos por procesar";
                }
            }
            catch (Exception Ex)
            {
                Respuesta = "Factura: " + Ex.Message.ToString();
            }

            return Respuesta;
        }

        public void ActualizarDatosPedido(string OrderId, int RowIdEmpaques, string CodigoAlterno, string FacturaAlterna)
        {
            _BDPedidos.Sp_ActualizarFacturaEmpaqueYMedida(OrderId, FacturaAlterna, RowIdEmpaques, CodigoAlterno);
        }
    }
}
