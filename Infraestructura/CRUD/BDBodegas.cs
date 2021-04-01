using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.CRUD
{
    public class BDBodegas
    {
        public void Sp_AlmacenarBodegas(int Orden, string IdBodega, string Descripcion, string CentroOperacion, string Correo)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_AlmacenarBodegas";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("Orden", Orden);
            sqlComando.Parameters.AddWithValue("IdBodega", IdBodega);
            sqlComando.Parameters.AddWithValue("Descripcion", Descripcion);
            sqlComando.Parameters.AddWithValue("CentroOperacion", CentroOperacion);
            sqlComando.Parameters.AddWithValue("Correo", Correo);

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

        public void Sp_ActualizarBodegas(int RowId, int Orden, string IdBodega, string Descripcion, string CentroOperacion, string Correo, bool Activo)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ActualizarBodegas";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("RowId", RowId);
            sqlComando.Parameters.AddWithValue("Orden", Orden);
            sqlComando.Parameters.AddWithValue("IdBodega", IdBodega);
            sqlComando.Parameters.AddWithValue("Descripcion", Descripcion);
            sqlComando.Parameters.AddWithValue("CentroOperacion", CentroOperacion);
            sqlComando.Parameters.AddWithValue("Correo", Correo);
            sqlComando.Parameters.AddWithValue("Activo", Activo);

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

        public void Sp_EliminarBodegas(int RowId)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_EliminarBodegas";
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

        public DataSet Sp_BuscarBodegas(int RowId)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_BuscarBodegas";
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

        public DataSet Sp_BuscarBodegasOrden(int OrdenActual, int OrdenNuevo, string Opcion)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_BuscarBodegasOrden";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("OrdenActual", OrdenActual);
            sqlComando.Parameters.AddWithValue("OrdenNuevo", OrdenNuevo);
            sqlComando.Parameters.AddWithValue("Opcion", Opcion);

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

        public DataSet Sp_ValidarBodega(string IdBodega)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ValidarBodega";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("IdBodega", IdBodega);

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

        public DataSet Sp_ListadoBodegas_ERP_Filtrado(string IdBodega)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ListadoBodegas_ERP_Filtrado";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("IdBodega", IdBodega);

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

        public DataSet Sp_ListadoBodegasPriorizacionExclusion(string IdBodega)
        {
            SqlConnection sqlConexion = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            sqlComando.Connection = sqlConexion;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ListadoBodegasPriorizacionExclusion";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("IdBodega", IdBodega);

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
