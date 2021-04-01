using Dominio.Conectores;
using Infraestructura.CRUD;
using System.Data;

namespace Dominio.FormulariosPublicos
{
    public class Pedidos
    {
        private readonly BDConsultar _BDConsultar = new BDConsultar();
        private readonly BDPedidos _BDPedidos = new BDPedidos();
        private readonly Requisicion _Requisicion = new Requisicion();
        private readonly TransferenciaSalida _TransferenciaSalida = new TransferenciaSalida();

        public DataSet Consultar()
        {
            return _BDConsultar.Query("Sp_Pedidos");
        }

        public DataSet ConsultarUltimo()
        {
            return _BDConsultar.Query("Sp_PedidosDetalle");
        }

        public DataSet ConsultarPorRowId(int RowId)
        {
            return _BDPedidos.Sp_ConsultarOrdenesRowId(RowId);
        }

        public DataSet ConsultarPorOrderId(string OrderId)
        {
            return _BDPedidos.Sp_ConsultarOrdenesOrderId(OrderId);
        }

        public void ActualizarDetalle(string OrderId, string Requisicion, string Transferencia, bool Entrada)
        {
            _BDPedidos.Sp_ActualizarEntrada(OrderId, Requisicion, Transferencia, Entrada);
        }

        public DataSet ConsultarEntradasPorOrderId(string OrderId)
        {
            return _BDPedidos.Sp_ConsultarEntradasPorOrderId(OrderId);
        }

        public string ResincronizacionSalida(string Transferencia)
        {
            return _TransferenciaSalida.Importar(_Requisicion.Importar(Transferencia));
        }

        public string Anular(string OrderId)
        {
             _BDPedidos.Sp_ActualizarEstados(OrderId, "14");
            return "Anulación exitosa";
        }
    }
}
