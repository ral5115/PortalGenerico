using System;
using System.Text;

namespace Dominio.Recursos
{
    public static class Seguridad
    {
        public static string Encriptar(this string Texto)
        {
            string Resultado = string.Empty;
            byte[] Encriptado = Encoding.Unicode.GetBytes(Texto);
            Resultado = Convert.ToBase64String(Encriptado);
            return Resultado;
        }

        public static string DesEncriptar(this string Texto)
        {
            string Resultado = string.Empty;
            byte[] Encriptado = Convert.FromBase64String(Texto);
            Resultado = Encoding.Unicode.GetString(Encriptado);
            return Resultado;
        }
    }
}

