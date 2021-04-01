using Infraestructura;
using Infraestructura.CRUD;
using RestSharp;
using System;
using System.Data;
using System.Text;

namespace Dominio.FormulariosPublicos
{
    public class Estados
    {
        BDPedidos _BDPedidos = new BDPedidos();
        public string StartHandling(string OrderId, string RespuestaCoordinadora)
        {
            if (RespuestaCoordinadora.Contains("Factura: Importacion exitosa") || RespuestaCoordinadora.Contains("Coordinadora: Importacion exitosa"))
            {
                var Respuesta = string.Empty;

                try
                {
                    var DsStarHandling = _BDPedidos.Sp_EstadoStartHandlingPorOrderId(OrderId);

                    if (DsStarHandling.Tables[0].Rows.Count > 0)
                    {
                        RestClient Client = new RestClient("Https://" + Configuraciones.UsuarioVTEX + "." + Configuraciones.EntornoVTEX + ".com.br");

                        string RequestRoute = "/api/oms/pvt/orders/" + OrderId + "/start-handling";
                        RestRequest Request = new RestRequest(RequestRoute, Method.POST);
                        Request.AddHeader("X-VTEX-API-AppKey", Configuraciones.AppKey);
                        Request.AddHeader("X-VTEX-API-AppToken", Configuraciones.AppToken);
                        Request.AddHeader("Content-Type", "application/json;charset=utf8");
                        Request.AddHeader("Accept", "application/json");

                        Respuesta = Client.Execute(Request).Content.ToString();

                        if (Respuesta != "[]")
                        {
                            _BDPedidos.Sp_ActualizarEstados(OrderId, "11");
                            Respuesta = "StartHandling: Importacion exitosa";
                        }
                    }
                    else
                    {
                        Respuesta = "StartHandling: No se encontraron datos por procesar";
                    }
                    return Respuesta;
                }
                catch (Exception Ex)
                {
                    return "StartHandling: " + Ex.Message.ToString();
                }
            }
            else
            {
                return "StartHandling: Sin Procesar";
            }
        }

        public string Invoicing(string OrderId, string RespuestaStartHandling)
        {
            if (RespuestaStartHandling.Contains("StartHandling: Importacion exitosa"))
            {
                try
                {
                    var DsInvoiced = _BDPedidos.Sp_EstadoInvoicedPorOrderId(OrderId);
                    var Respuesta = string.Empty;

                    if (DsInvoiced.Tables[0].Rows.Count > 0)
                    {
                        var TotalAPagar = Convert.ToInt32(DsInvoiced.Tables[0].Rows[0]["TotalAPagar"].ToString());

                        RestClient Client = new RestClient("Https://" + Configuraciones.UsuarioVTEX + "." + Configuraciones.EntornoVTEX + ".com.br");
                        RestRequest request = new RestRequest("/api/oms/pvt/orders/" + OrderId + "/invoice", Method.POST);

                        StringBuilder Body = new StringBuilder();

                        Body.Append("{");
                        Body.Append("\"type\":\"Output\",");
                        Body.Append("\"issuanceDate\":\"" + DsInvoiced.Tables[0].Rows[0]["Fecha"].ToString() + "\",");
                        Body.Append("\"invoiceNumber\":\"" + DsInvoiced.Tables[0].Rows[0]["Factura"].ToString() + "\",");
                        Body.Append("\"invoiceValue\":\"" + TotalAPagar + "\",");
                        Body.Append("\"courier\": \"\",");
                        Body.Append("\"trackingNumber\": \"\",");
                        Body.Append("\"trackingUrl\":\"\",");
                        Body.Append("\"items\": [");

                        DataSet DsInvoicedDetalle = _BDPedidos.Sp_EstadoInvoicedDetallePorOrderId(OrderId);

                        if (DsInvoicedDetalle.Tables.Count > 0)
                        {
                            int Contador = DsInvoicedDetalle.Tables[0].Rows.Count;
                            int Iteracion = 0;

                            foreach (DataRow ItemDetalle in DsInvoicedDetalle.Tables[0].Rows)
                            {
                                Iteracion++;

                                Body.Append("{");
                                Body.Append("\"id\":\"" + ItemDetalle["VtexIdSku"].ToString() + "\",");
                                Body.Append("\"price\":" + ItemDetalle["PrecioDeVenta"].ToString() + ",");
                                Body.Append("\"quantity\":" + ItemDetalle["Cantidad"].ToString());
                                if (Iteracion == Contador)
                                {
                                    Body.Append("}");
                                }
                                else
                                {
                                    Body.Append("},");
                                }
                            }

                            Body.Append("]");
                            Body.Append("}");

                            request.AddHeader("X-VTEX-API-AppKey", Configuraciones.AppKey);
                            request.AddHeader("X-VTEX-API-AppToken", Configuraciones.AppToken);
                            request.AddHeader("Content-Type", "application/json; charset=utf-8");
                            request.AddParameter("application/json", Body.ToString(), ParameterType.RequestBody);

                            if (Client.Execute(request).StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                _BDPedidos.Sp_ActualizarEstados(OrderId, "12");
                                Respuesta = "Invoicing: Importacion exitosa";
                            }
                        }
                    }
                    else
                    {
                        Respuesta = "Invoicing: No se encontraron datos por procesar";
                    }

                    return Respuesta;
                }
                catch (Exception Ex)
                {
                    return "Invoicing: " + Ex.Message.ToString();
                }
            }
            else
            {
                return "Invoicing: Sin Procesar";
            }
        }

        public string Tracking(string OrderId, string RespuestaInvoicing)
        {
            if (RespuestaInvoicing.Contains("Invoicing: Importacion exitosa"))
            {
                try
                {
                    var DsTracking = _BDPedidos.Sp_EstadoTranckingPorOrderId(OrderId);
                    var Respuesta = string.Empty;

                    if (DsTracking.Tables[0].Rows.Count > 0)
                    {

                        RestClient Client = new RestClient("https://" + Configuraciones.UsuarioVTEX + "." + Configuraciones.EntornoVTEX + ".com.br");
                        string RequestRoute = "/api/oms/pvt/orders/" + OrderId + "/invoice/"
                            + DsTracking.Tables[0].Rows[0]["Factura"].ToString();

                        StringBuilder Body = new StringBuilder();

                        Body.Append("{");
                        Body.Append("\"trackingNumber\":\"" + DsTracking.Tables[0].Rows[0]["Remision"].ToString() + "\",");
                        Body.Append("\"trackingUrl\":\" http://www.coordinadora.com/portafolio-de-servicios/servicios-en-linea/rastrear-guias/ \",");
                        Body.Append("\"courier\":\"" + DsTracking.Tables[0].Rows[0]["MetodoPago"].ToString() + "");
                        Body.Append("}");

                        RestRequest request = new RestRequest(RequestRoute, Method.PATCH);
                        request.AddHeader("X-VTEX-API-AppToken", Configuraciones.AppToken);
                        request.AddHeader("X-VTEX-API-AppKey", Configuraciones.AppKey);
                        request.AddHeader("Content-Type", "application/json");
                        request.AddHeader("Accept", "application/json");
                        request.AddParameter("application/json", Body.ToString(), ParameterType.RequestBody);

                        if (Client.Execute(request).StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            _BDPedidos.Sp_ActualizarEstados(OrderId, "13");
                            Respuesta = "Tracking: Importacion exitosa";
                        }
                    }
                    else
                    {
                        Respuesta = "Tracking: No se encontraron datos por procesar";
                    }
                    return Respuesta;
                }
                catch (Exception Ex)
                {
                    return "Tracking: " + Ex.Message.ToString();
                }
            }
            else
            {
                return "Tracking: Sin Procesar";
            }
        }
    }
}
