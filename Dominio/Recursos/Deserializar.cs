using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Recursos
{
    public class Deserializar
    {
        public string XML(string RespuestaERP)
        {
            DataSet DsErrores = new DataSet();
            StringBuilder ErrorSiesaDescompuesto = new StringBuilder();

            if (RespuestaERP.Contains("<NewDataSet>"))
            {
                ErrorSiesaDescompuesto.Append("Mensaje ERP Siesa Enterprise: ");
                RespuestaERP = RespuestaERP.Substring(RespuestaERP.ToString().IndexOf("<NewDataSet>"), 13 + RespuestaERP.ToString().IndexOf("</NewDataSet>") - RespuestaERP.ToString().IndexOf("<NewDataSet>"));
                System.IO.StringReader xmlSR = new System.IO.StringReader(RespuestaERP);
                DsErrores.ReadXml(xmlSR, XmlReadMode.Auto);

                foreach (System.Data.DataRow FilaError in DsErrores.Tables[0].Rows)
                {
                    ErrorSiesaDescompuesto.AppendLine("Linea:" + FilaError[0].ToString() + " Tipo de Registro:" + FilaError[1].ToString() + " SubTipo de resgistro:" + FilaError[2].ToString() + " Version:" + FilaError[3].ToString() + " Nivel" + FilaError[4].ToString() + " Error" + FilaError[5].ToString() + " Detalle:" + FilaError[6].ToString() + "\r\n");
                }
            }

            return ErrorSiesaDescompuesto.ToString();
        }
    }
}
