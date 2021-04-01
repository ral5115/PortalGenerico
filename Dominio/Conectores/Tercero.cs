using Infraestructura.CRUD;
using Infraestructura;
using System;
using System.Data;
using Dominio.Recursos;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;

namespace Dominio.Conectores
{
    public class Tercero
    {
        private readonly Infraestructura.Ws_GT_Real.wsGenerarPlano _Importar = new Infraestructura.Ws_GT_Real.wsGenerarPlano();
        private readonly BDPedidos _BDPedidos = new BDPedidos();
        private readonly Deserializar _Deserializar = new Deserializar();

        public string Importar(string OrderId)
        {
            return RecorrerInformacion(_BDPedidos.Sp_ConsultarClientesPorOrderId(OrderId), OrderId);
        }

        private string RecorrerInformacion(DataSet DsTerceros, string OrderId)
        {
            var Respuesta = string.Empty;

            try
            {
                if (DsTerceros.Tables[1].Rows.Count > 0)
                {
                    var Ruta = Configuraciones.RutaPlanosReal;

                    Respuesta = "Tercero: " + _Importar.ImportarDatosDS(92313, "Cliente_Crm_Ecommerce", 2, "1", "gt", "gt", DsTerceros, ref Ruta);

                    if (Respuesta != "Tercero: Importacion exitosa")
                    {
                        Respuesta = "Tercero: " + _Deserializar.XML(Respuesta);
                    }
                    else
                    {
                        _BDPedidos.Sp_ActualizarEstados(OrderId, "8");
                        Respuesta += ImportarClienteCRM(OrderId);
                    }
                }
                else
                {
                    Respuesta = "Tercero: No se encontraron datos por procesar";
                }
            }
            catch (Exception Ex)
            {
                Respuesta = "Tercero: " + Ex.Message.ToString();
            }

            return Respuesta; 
        }

        public string ImportarClienteCRM(string OrderId)
        {
            DataSet DsCliente = _BDPedidos.Sp_ConsultarClienteCRM(OrderId);

            RestClient client = new RestClient("http://crm.frutafrescavirtual.com:9052");
            RestRequest request = new RestRequest("/WSVTEX/v1/rest.php", Method.POST);

            var authenticator = new HttpBasicAuthenticator("app.vtex0v", "FrutAFr3sc4,Vt3XoV");
            authenticator.Authenticate(client, request);
            var Respuesta = string.Empty;

            string json = "{" +
                          "\"parameters\": {" +
                          "\"numero_documento\": \"" + DsCliente.Tables[0].Rows[0]["Documento"].ToString() + "\"," +
                          "\"primer_nombre\": \"" + DsCliente.Tables[0].Rows[0]["Nombre1"].ToString() + "\"," +
                          "\"segundo_nombre\": \"" + DsCliente.Tables[0].Rows[0]["Nombre2"].ToString() + "\"," +
                          "\"primer_apellido\": \"" + DsCliente.Tables[0].Rows[0]["Apellido1"].ToString() + "\"," +
                          "\"segundo_apellido\": \"" + DsCliente.Tables[0].Rows[0]["Apellido2"].ToString() + "\"," +
                          "\"direccion\": \"" + DsCliente.Tables[0].Rows[0]["Direccion"].ToString() + "\"," +
                          "\"departamento\": \"" + DsCliente.Tables[0].Rows[0]["Departamento"].ToString() + "\"," +
                          "\"ciudad\": \"" + DsCliente.Tables[0].Rows[0]["Ciudad"].ToString() + "\"," +
                          "\"celular\": \"" + DsCliente.Tables[0].Rows[0]["Celular"].ToString() + "\"," +
                          "\"correo\": \"" + DsCliente.Tables[0].Rows[0]["Correo"].ToString() + "\"" +
                          "}," +
                          "\"module\": \"Cliente\"," +
                          "\"action\": \"crearActualizarCliente\"" +
                          "}";

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            try
            {
                if (client.Execute(request).StatusCode == HttpStatusCode.OK)
                {
                    return Environment.NewLine + "Tercero CRM: Importacion exitosa";
                }
                else
                {
                    return Respuesta = Environment.NewLine + "Tercero CRM: " + client.Execute(request).Content.ToString();
                }
            }
            catch (Exception Ex)
            {
                return Respuesta = Environment.NewLine + "Tercero CRM: " + Ex.Message.ToString();
            }
        }
    }
}
