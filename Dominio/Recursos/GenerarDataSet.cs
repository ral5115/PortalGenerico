using System.Data;
using System.IO;
using System.Xml;

namespace Dominio.Recursos
{
    public class GenerarDataSet
    {
        public DataSet Obtener(string Xml)
        {
            DataSet dataSet = new DataSet();
            TextReader textReader = new StringReader(Xml);
            XmlReader xmlReader = new XmlTextReader(textReader);
            dataSet.ReadXml(xmlReader);

            return dataSet;
        }
    }
}
