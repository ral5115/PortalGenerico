using System;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.CRUD
{
    public class BDPropiedades
    {
        public void Sp_AlmacenarPropiedades(string Nombre, string Valor)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_AlmacenarPropiedades";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("Nombre", Nombre);
            sqlComando.Parameters.AddWithValue("Valor", Valor);

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

        public void Sp_ActualizarPropiedades(int RowId, string Nombre, string Valor)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ActualizarPropiedades";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("RowId", RowId);
            sqlComando.Parameters.AddWithValue("Nombre", Nombre);
            sqlComando.Parameters.AddWithValue("Valor", Valor);

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

        public void Sp_EliminarPropiedades(int RowId)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_EliminarPropiedades";
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

        public DataSet Sp_BuscarPropiedades(int RowId)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_BuscarPropiedades";
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

        public DataSet Sp_ValidarPropiedad(string Nombre)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ValidarPropiedad";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("Nombre", Nombre);

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
