using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.CRUD
{
    public class BDPedidos
    {
        public DataSet Sp_ConsultarOrdenesRowId(int RowId)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();
            sqlComando.Connection = SqlConnection;
            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ConsultarOrdenesRowId";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("RowId", RowId);
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

        public DataSet Sp_ConsultarOrdenesOrderId(string OrderId)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();
            sqlComando.Connection = SqlConnection;
            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ConsultarOrdenesOrderId";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("OrderId", OrderId);
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

        public DataSet Sp_ActualizarEntrada(string OrderId, string Requisicion, string Transferencia, bool Entrada)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();
            sqlComando.Connection = SqlConnection;
            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ActualizarEntrada";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("OrderId", OrderId);
            sqlComando.Parameters.AddWithValue("Requisicion", Requisicion);
            sqlComando.Parameters.AddWithValue("Transferencia", Transferencia);
            sqlComando.Parameters.AddWithValue("Entrada", Entrada);
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

        public DataSet Sp_ConsultarEntradas(string Transferencia)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();
            sqlComando.Connection = SqlConnection;
            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ConsultarEntradas";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("Transferencia", Transferencia);
            objDA.SelectCommand = sqlComando;

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
                objDA.Fill(Ds);

                Ds.Tables[0].TableName = "Inicial";
                Ds.Tables[1].TableName = "Documentos";
                Ds.Tables[2].TableName = "Movimientos";
                Ds.Tables[3].TableName = "Final";

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

        public DataSet Sp_ConsultarCampoLlave(string CentroOperacion, string CampoLlave)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ConsultarCampoLlave";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("CentroOperacion", CentroOperacion);
            sqlComando.Parameters.AddWithValue("CampoLlave", CampoLlave);

            objDA.SelectCommand = sqlComando;

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
                objDA.Fill(Ds);
                return Ds;
            }
            catch (Exception)
            {
                return new DataSet();
            }
            finally
            {
                sqlComando.Connection.Close();
            }
        }

        public void Sp_ActualizarEntrada(string CampoLlave, string Entrada)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();
            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ActualizarEntrada";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("CampoLlave", CampoLlave);
            sqlComando.Parameters.AddWithValue("Entrada", Entrada);

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
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

        public void Sp_ActualizarEstados(string OrderId, string IndicadorEstado)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();
            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ActualizarEstados";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("OrderId", OrderId);
            sqlComando.Parameters.AddWithValue("IndicadorEstado", IndicadorEstado);

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
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

        public DataSet Sp_ConsultarEntradasPorOrderId(string OrderId)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ConsultarEntradasPorOrderId";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("OrderId", OrderId);

            objDA.SelectCommand = sqlComando;

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
                objDA.Fill(Ds);
                return Ds;
            }
            catch (Exception)
            {
                return new DataSet();
            }
            finally
            {
                sqlComando.Connection.Close();
            }
        }

        public DataSet Sp_ConsultarClientesPorOrderId(string OrderId)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ConsultarClientesPorOrderId";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("OrderId", OrderId);

            objDA.SelectCommand = sqlComando;

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
                objDA.Fill(Ds);

                Ds.Tables[0].TableName = "Inicial";
                Ds.Tables[1].TableName = "Terceros";
                Ds.Tables[2].TableName = "Clientes";
                Ds.Tables[3].TableName = "ImpYRet"; 
                Ds.Tables[4].TableName = "Final";

                return Ds;
            }
            catch (Exception)
            {
                return new DataSet();
            }
            finally
            {
                sqlComando.Connection.Close();
            }
        }

        public DataSet Sp_ConsultarFacturasPorOrderId(string OrderId)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ConsultarFacturasPorOrderId";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("OrderId", OrderId);

            objDA.SelectCommand = sqlComando;

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
                objDA.Fill(Ds);

                Ds.Tables[0].TableName = "Inicial";
                Ds.Tables[1].TableName = "Documentos";
                Ds.Tables[2].TableName = "Movimientos";
                Ds.Tables[3].TableName = "Caja";
                Ds.Tables[4].TableName = "Descuentos";
                Ds.Tables[5].TableName = "Final";

                return Ds;
            }
            catch (Exception)
            {
                return new DataSet();
            }
            finally
            {
                sqlComando.Connection.Close();
            }
        }

        public DataSet Sp_ConsultarClienteCRM(string OrderId)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ConsultarClienteCRM";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("OrderId", OrderId);

            objDA.SelectCommand = sqlComando;

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
                objDA.Fill(Ds);

                return Ds;
            }
            catch (Exception)
            {
                return new DataSet();
            }
            finally
            {
                sqlComando.Connection.Close();
            }
        }

        public DataSet Sp_RequisicionPorTransferencia(string Transferencia)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_RequisicionPorTransferencia";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("Transferencia", Transferencia);

            objDA.SelectCommand = sqlComando;

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
                objDA.Fill(Ds);

                Ds.Tables[0].TableName = "Inicial";
                Ds.Tables[1].TableName = "Documentos";
                Ds.Tables[2].TableName = "Movimientos";
                Ds.Tables[3].TableName = "Final";

                return Ds;
            }
            catch (Exception)
            {
                return new DataSet();
            }
            finally
            {
                sqlComando.Connection.Close();
            }
        }

        public void Sp_ActualizarTransferencia(string CampoLlave, string Transferencia)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();
            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ActualizarTransferencia";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("CampoLlave", CampoLlave);
            sqlComando.Parameters.AddWithValue("Transferencia", Transferencia);

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
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

        public DataSet Sp_ValidarInventario(string Bodega, string Barra, int Cantidad)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ValidarInventario";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("Bodega", Bodega);
            sqlComando.Parameters.AddWithValue("Barra", Barra);
            sqlComando.Parameters.AddWithValue("Cantidad", Cantidad);

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

        public DataSet Sp_ConsultarCampoLlaveRequisicion(string Referencia)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ConsultarCampoLlaveRequisicion";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("Referencia", Referencia);

            objDA.SelectCommand = sqlComando;

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
                objDA.Fill(Ds);
                return Ds;
            }
            catch (Exception)
            {
                return new DataSet();
            }
            finally
            {
                sqlComando.Connection.Close();
            }
        }

        public DataSet Sp_ConsultarCampoLlaveFactura(string OrderId)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ConsultarCampoLlaveFactura";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("OrderId", OrderId);

            objDA.SelectCommand = sqlComando;

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
                objDA.Fill(Ds);
                return Ds;
            }
            catch (Exception)
            {
                return new DataSet();
            }
            finally
            {
                sqlComando.Connection.Close();
            }
        }

        public void Sp_ActualizarRequisicion(string CampoLlave, string Bodega, string Requisicion)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();
            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ActualizarRequisicion";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("CampoLlave", CampoLlave);
            sqlComando.Parameters.AddWithValue("Bodega", Bodega);
            sqlComando.Parameters.AddWithValue("Requisicion", Requisicion);

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
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

        public void Sp_ActualizarCompromiso(string CampoLlave)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();
            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ActualizarCompromiso";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("CampoLlave", CampoLlave);

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
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

        public DataSet Sp_TransferenciasPorRequisicion(string Requisicion)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_TransferenciasPorRequisicion";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("Requisicion", Requisicion);

            objDA.SelectCommand = sqlComando;

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
                objDA.Fill(Ds);

                Ds.Tables[0].TableName = "Inicial";
                Ds.Tables[1].TableName = "Documentos";
                Ds.Tables[2].TableName = "Final";

                return Ds;
            }
            catch (Exception)
            {
                return new DataSet();
            }
            finally
            {
                sqlComando.Connection.Close();
            }
        }

        public void Sp_ActualizarFacturaEmpaqueYMedida(string OrderId,string Factura, int RowIdEmpaques, string CodigoAlterno)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();
            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ActualizarFacturaEmpaqueYMedida";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("OrderId", OrderId);
            sqlComando.Parameters.AddWithValue("Factura", Factura);
            sqlComando.Parameters.AddWithValue("RowIdEmpaques", RowIdEmpaques);
            sqlComando.Parameters.AddWithValue("CodigoAlterno", CodigoAlterno);

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
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

        public DataSet Sp_ConsultarCoordinadoraPorOrderId(string OrderId)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ConsultarCoordinadoraPorOrderId";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("OrderId", OrderId);

            objDA.SelectCommand = sqlComando;

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
                objDA.Fill(Ds);

                return Ds;
            }
            catch (Exception)
            {
                return new DataSet();
            }
            finally
            {
                sqlComando.Connection.Close();
            }
        }

        public void Sp_AlmacenarGuias(string OrderId, string Remision, string PDFGuia, string PDFRotulo)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            SqlCommand sqlComando = new SqlCommand();
            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_AlmacenarGuias";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("OrderId", OrderId);
            sqlComando.Parameters.AddWithValue("Remision", Remision);
            sqlComando.Parameters.AddWithValue("PDFGuia", PDFGuia);
            sqlComando.Parameters.AddWithValue("PDFRotulo", PDFRotulo);

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
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
        public DataSet Sp_ConsultarGuiaYRotuloPorOrderId(string OrderId)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_ConsultarGuiaYRotuloPorOrderId";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("OrderId", OrderId);

            objDA.SelectCommand = sqlComando;

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
                objDA.Fill(Ds);

                return Ds;
            }
            catch (Exception)
            {
                return new DataSet();
            }
            finally
            {
                sqlComando.Connection.Close();
            }
        }

        public DataSet Sp_EstadoStartHandlingPorOrderId(string OrderId)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_EstadoStartHandlingPorOrderId";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("OrderId", OrderId);

            objDA.SelectCommand = sqlComando;

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
                objDA.Fill(Ds);

                return Ds;
            }
            catch (Exception)
            {
                return new DataSet();
            }
            finally
            {
                sqlComando.Connection.Close();
            }
        }

        public DataSet Sp_EstadoInvoicedPorOrderId(string OrderId)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_EstadoInvoicedPorOrderId";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("OrderId", OrderId);

            objDA.SelectCommand = sqlComando;

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
                objDA.Fill(Ds);

                return Ds;
            }
            catch (Exception)
            {
                return new DataSet();
            }
            finally
            {
                sqlComando.Connection.Close();
            }
        }

        public DataSet Sp_EstadoInvoicedDetallePorOrderId(string OrderId)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_EstadoInvoicedDetallePorOrderId";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("OrderId", OrderId);

            objDA.SelectCommand = sqlComando;

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
                objDA.Fill(Ds);

                return Ds;
            }
            catch (Exception)
            {
                return new DataSet();
            }
            finally
            {
                sqlComando.Connection.Close();
            }
        }

        public DataSet Sp_EstadoTranckingPorOrderId(string OrderId)
        {
            SqlConnection SqlConnection = new SqlConnection(Configuraciones.Conexion);
            DataSet Ds = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();
            SqlCommand sqlComando = new SqlCommand();

            sqlComando.Connection = SqlConnection;
            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = "Sp_EstadoTranckingPorOrderId";
            sqlComando.CommandTimeout = 999999999;

            sqlComando.Parameters.AddWithValue("OrderId", OrderId);

            objDA.SelectCommand = sqlComando;

            try
            {
                sqlComando.Connection.Open();
                sqlComando.ExecuteNonQuery();
                objDA.Fill(Ds);

                return Ds;
            }
            catch (Exception)
            {
                return new DataSet();
            }
            finally
            {
                sqlComando.Connection.Close();
            }
        }
    }
}
