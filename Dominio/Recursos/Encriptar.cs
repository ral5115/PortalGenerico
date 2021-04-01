using System.Security.Cryptography;
using System.Text;

namespace Dominio.Recursos
{
    public class Encriptar
    {
        public string Clave(string Clave)
        {
            SHA256 Sha256 = SHA256Managed.Create();
            ASCIIEncoding Encoding = new ASCIIEncoding();
            byte[] Stream = null;
            StringBuilder Builder = new StringBuilder();
            Stream = Sha256.ComputeHash(Encoding.GetBytes(Clave));
            for (int i = 0; i < Stream.Length; i++) Builder.AppendFormat("{0:x2}", Stream[i]);
            return Builder.ToString();
        }
    }
}
