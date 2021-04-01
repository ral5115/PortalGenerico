using System;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.CRUD
{
    public class BDConsultar
    {
        public DataSet Query(string NombreProcedimiento)
        {

            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = NombreProcedimiento;
            sqlComando.CommandTimeout = 999999999;
            objDA.SelectCommand = sqlComando;

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
                objDA.Fill(Ds);
                return Ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlComando.Connection.Close();
            }
        }

        public DataSet QueryExterno(string NombreProcedimiento)
        {

            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = NombreProcedimiento;
            sqlComando.CommandTimeout = 999999999;
            objDA.SelectCommand = sqlComando;

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
                objDA.Fill(Ds);
                return Ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlComando.Connection.Close();
            }
        }

        public DataSet Correo(string Bodega)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();
            sqlComando.Connection = SqlConnection;
            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ObtenerCorreo";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("Bodega", Bodega);
            objDA.SelectCommand = sqlComando;

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
                objDA.Fill(Ds);
                return Ds;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                sqlComando.Connection.Close();
            }
        }
    }
}
