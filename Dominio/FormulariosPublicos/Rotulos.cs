using Infraestructura.CRUD;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace Dominio.FormulariosPublicos
{
    public class Rotulos
    {
        BDPedidos _BDPedidos = new BDPedidos();

        public string Descargar(string OrderId)
        {
            try
            {
                DataSet DsCoordinadora = _BDPedidos.Sp_ConsultarGuiaYRotuloPorOrderId(OrderId);

                if (DsCoordinadora.Tables[0].Rows.Count > 0)
                {
                    byte[] Byte = Convert.FromBase64String(DsCoordinadora.Tables[0].Rows[0]["PDFRotulo"].ToString());
                    FileStream Guia = File.Create(DsCoordinadora.Tables[0].Rows[0]["Ruta"].ToString() + "Rotulo" + OrderId + ".pdf");
                    Guia.Write(Byte, 0, Byte.Length);
                    Guia.Flush();
                    Guia.Close();
                }

                return DsCoordinadora.Tables[0].Rows[0]["Ruta"].ToString() + "Rotulo" + OrderId + ".pdf";
            }
            catch (Exception Ex)
            {
                return Ex.Message.ToString();
            }
        }
    }
}
