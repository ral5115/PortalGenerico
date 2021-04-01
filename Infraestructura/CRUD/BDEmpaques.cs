using System;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.CRUD
{
    public class BDEmpaques
    {
        public void Sp_AlmacenarEmpaques(string NombreEmpaque, string Largo, string Peso, string Alto,
            string Ancho, string Unidades, string Ubl)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_AlmacenarEmpaques";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("NombreEmpaque", NombreEmpaque);
            sqlComando.Parameters.AddWithValue("Largo", Largo);
            sqlComando.Parameters.AddWithValue("Peso", Peso);
            sqlComando.Parameters.AddWithValue("Alto", Alto);
            sqlComando.Parameters.AddWithValue("Ancho", Ancho);
            sqlComando.Parameters.AddWithValue("Unidades", Unidades);
            sqlComando.Parameters.AddWithValue("Ubl", Ubl);

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Sp_ActualizarEmpaques(int RowId, string NombreEmpaque, string Largo, string Peso, string Alto,
            string Ancho, string Unidades, string Ubl)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ActualizarEmpaques";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("RowId", RowId);
            sqlComando.Parameters.AddWithValue("NombreEmpaque", NombreEmpaque);
            sqlComando.Parameters.AddWithValue("Largo", Largo);
            sqlComando.Parameters.AddWithValue("Peso", Peso);
            sqlComando.Parameters.AddWithValue("Alto", Alto);
            sqlComando.Parameters.AddWithValue("Ancho", Ancho);
            sqlComando.Parameters.AddWithValue("Unidades", Unidades);
            sqlComando.Parameters.AddWithValue("Ubl", Ubl);

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Sp_EliminarEmpaques(int RowId)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_EliminarEmpaques";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("RowId", RowId);


            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public DataSet Sp_BuscarEmpaques(int RowId)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_BuscarEmpaques";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("RowId", RowId);

            try
            {
                sqlAdaptador.SelectCommand = sqlComando;
                sqlAdaptador.Fill(ds);
                return ds;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                sqlComando.Parameters.Clear();
                sqlComando.Connection.Close();
            }
        }

        public DataSet Sp_ValidarEmpaque(string NombreEmpaque)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ValidarEmpaque";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("NombreEmpaque", NombreEmpaque);

            try
            {
                sqlAdaptador.SelectCommand = sqlComando;
                sqlAdaptador.Fill(ds);
                return ds;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                sqlComando.Parameters.Clear();
                sqlComando.Connection.Close();
            }
        }
    }
}
