using Dominio.Conectores;
using Dominio.FormulariosAdministracion;
using Dominio.FormulariosPublicos;
using Dominio.Recursos;
using System;
using System.Data;
using System.Web.Mvc;

namespace Interfaz.Controllers
{
    public class PedidosDetalleController : Controller
    {

        private readonly Pedidos _Pedidos = new Pedidos();
        private readonly TransferenciaEntrada _TransferenciaEntrada = new TransferenciaEntrada();
        private readonly Tercero _Tercero = new Tercero();
        private readonly Factura _Factura = new Factura();
        private readonly Empaques _Empaques = new Empaques();
        private readonly Combos _Combos = new Combos();
        private readonly Coordinadora _Coordinadora = new Coordinadora();
        private readonly Guias _Guias = new Guias();
        private readonly Rotulos _Rotulos = new Rotulos();
        private readonly Estados _Estados = new Estados();

        public ActionResult Index()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewData["Error"] = string.Empty;

            DataSet DsPedido = _Pedidos.ConsultarUltimo();

            ViewBag.ListadoEmpaques = _Combos.Obtener("Sp_ListadoEmpaques", DsPedido.Tables[0].Rows[0]["RowIdEmpaques"].ToString());

            return View(DsPedido);
        }

        public ActionResult Regresar(int RowId)
        {
            DataSet DsPedido = _Pedidos.ConsultarPorRowId(RowId - 1);

            if (DsPedido.Tables[0].Rows.Count > 0)
            {
                ViewData["Error"] = string.Empty;

                ViewBag.ListadoEmpaques = _Combos.Obtener("Sp_ListadoEmpaques", DsPedido.Tables[0].Rows[0]["RowIdEmpaques"].ToString());

                return View("Index", DsPedido);
            }
            else
            {
                DataSet DsPedidoFiltrado = _Pedidos.ConsultarPorRowId(RowId);
                ViewData["Error"] = string.Empty;

                ViewBag.ListadoEmpaques = _Combos.Obtener("Sp_ListadoEmpaques", DsPedidoFiltrado.Tables[0].Rows[0]["RowIdEmpaques"].ToString());

                return View("Index", DsPedidoFiltrado);
            }
        }

        public ActionResult Siguiente(int RowId)
        {
            DataSet DsPedido = _Pedidos.ConsultarPorRowId(RowId + 1);

            if (DsPedido.Tables[0].Rows.Count > 0)
            {
                ViewData["Error"] = string.Empty;

                ViewBag.ListadoEmpaques = _Combos.Obtener("Sp_ListadoEmpaques", DsPedido.Tables[0].Rows[0]["RowIdEmpaques"].ToString());

                return View("Index", DsPedido);
            }
            else
            {
                DataSet DsPedidoFiltrado = _Pedidos.ConsultarPorRowId(RowId);
                ViewData["Error"] = string.Empty;

                ViewBag.ListadoEmpaques = _Combos.Obtener("Sp_ListadoEmpaques", DsPedidoFiltrado.Tables[0].Rows[0]["RowIdEmpaques"].ToString());

                return View("Index", DsPedidoFiltrado);
            }
        }

        public ActionResult Buscar(string OrderId)
        {
            DataSet DsPedido = _Pedidos.ConsultarPorOrderId(OrderId);

            if (DsPedido.Tables[0].Rows.Count > 0)
            {
                ViewData["Error"] = string.Empty;

                ViewBag.ListadoEmpaques = _Combos.Obtener("Sp_ListadoEmpaques", DsPedido.Tables[0].Rows[0]["RowIdEmpaques"].ToString());

                return View("Index", DsPedido);
            }
            else
            {
                DataSet DsPedidoFiltrado = _Pedidos.ConsultarUltimo();
                ViewData["Error"] = "No se encontraron datos, se deja por defecto el último pedido.";

                ViewBag.ListadoEmpaques = _Combos.Obtener("Sp_ListadoEmpaques", DsPedidoFiltrado.Tables[0].Rows[0]["RowIdEmpaques"].ToString());

                return View("Index", DsPedidoFiltrado);
            }
        }

        public ActionResult BuscarDetalle(int RowId)
        {
            DataSet DsPedido = _Pedidos.ConsultarPorRowId(RowId);

            if (DsPedido.Tables[0].Rows.Count > 0)
            {
                ViewBag.ListadoEmpaques = _Combos.Obtener("Sp_ListadoEmpaques", DsPedido.Tables[0].Rows[0]["RowIdEmpaques"].ToString());
            }
            else
            {
                ViewBag.ListadoEmpaques = _Combos.Obtener("Sp_ListadoEmpaques");
            }

            return View("Index", DsPedido);
        }

        [HttpGet]
        public JsonResult Asignar(bool Check, string OrderId, string Requisicion, string Transferencia)
        {
            _Pedidos.ActualizarDetalle(OrderId, Requisicion, Transferencia, Check);
            return Json(JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Entrada(string Transferencia)
        {
            var Respuesta = Transferencia + " - " + _TransferenciaEntrada.Importar(Transferencia);

            if (Respuesta.Contains("Importacion exitosa"))
            {
                return Json("success" + "|" + Respuesta, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error" + "|" + Respuesta, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ResincronizarSalida(string Transferencia)
        {
            var Respuesta = _Pedidos.ResincronizacionSalida(Transferencia);

            if (Respuesta.Contains("Importacion exitosa"))
            {
                return Json("success" + "|" + Respuesta, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error" + "|" + Respuesta, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult TodasEntradas(string OrderId)
        {
            DataSet DsEntradas = _Pedidos.ConsultarEntradasPorOrderId(OrderId);
            string Respuesta = string.Empty;

            if (DsEntradas.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Registro in DsEntradas.Tables[0].Rows)
                {
                    Respuesta += Registro["Transferencia"].ToString() + " - " + _TransferenciaEntrada.Importar(Registro["Transferencia"].ToString()) + Environment.NewLine;
                }
            }

            if (Respuesta.Contains("Entrada"))
            {
                return Json("error" + "|" + Respuesta, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("success" + "|" + Respuesta, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult FacturarConGuia(string OrderId, int RowIdEmpaques, string CodigoAlterno)
        {
            var Respuesta = _Tercero.Importar(OrderId);
            Respuesta += Environment.NewLine + _Factura.Importar(OrderId, RowIdEmpaques, CodigoAlterno, Respuesta);
            Respuesta += Environment.NewLine + _Coordinadora.GenerarGuia(OrderId, CodigoAlterno, Respuesta);
            Respuesta += Environment.NewLine + _Estados.StartHandling(OrderId, Respuesta);
            Respuesta += Environment.NewLine + _Estados.Invoicing(OrderId, Respuesta);
            Respuesta += Environment.NewLine + _Estados.Tracking(OrderId, Respuesta);

            if (Respuesta.Contains("Tercero: Importacion exitosa")
                && Respuesta.Contains("Factura: Importacion exitosa")
                && Respuesta.Contains("Coordinadora: Importacion exitosa")
                && Respuesta.Contains("StartHandling: Importacion exitosa")
                && Respuesta.Contains("Invoicing: Importacion exitosa")
                && Respuesta.Contains("Tracking: Importacion exitosa"))
            {
                return Json("success" + "|" + Respuesta, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error" + "|" + Respuesta, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult FacturarSinGuia(string OrderId, int RowIdEmpaques, string CodigoAlterno)
        {
            var Respuesta = _Tercero.Importar(OrderId);
            Respuesta += Environment.NewLine + _Factura.Importar(OrderId, RowIdEmpaques, CodigoAlterno, Respuesta);
            Respuesta += Environment.NewLine + _Estados.StartHandling(OrderId, Respuesta);
            Respuesta += Environment.NewLine + _Estados.Invoicing(OrderId, Respuesta);

            if (Respuesta.Contains("Tercero: Importacion exitosa")
                && Respuesta.Contains("Factura: Importacion exitosa")
                && Respuesta.Contains("StartHandling: Importacion exitosa")
                && Respuesta.Contains("Invoicing: Importacion exitosa"))
            {
                return Json("success" + "|" + Respuesta, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error" + "|" + Respuesta, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult FacturarConCodigo(string OrderId, int RowIdEmpaques, string CodigoAlterno, string FacturaAlterna)
        {
            _Factura.ActualizarDatosPedido(OrderId, RowIdEmpaques, CodigoAlterno, FacturaAlterna);

            var Respuesta = Environment.NewLine + _Coordinadora.GenerarGuia(OrderId, CodigoAlterno, "Factura: Importacion exitosa");
            Respuesta += Environment.NewLine + _Estados.StartHandling(OrderId, Respuesta);
            Respuesta += Environment.NewLine + _Estados.Invoicing(OrderId, Respuesta);
            Respuesta += Environment.NewLine + _Estados.Tracking(OrderId, Respuesta);

            if (Respuesta.Contains("Coordinadora: Importacion exitosa")
                && Respuesta.Contains("StartHandling: Importacion exitosa")
                && Respuesta.Contains("Invoicing: Importacion exitosa")
                && Respuesta.Contains("Tracking: Importacion exitosa"))
            {
                return Json("success" + "|" + Respuesta, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error" + "|" + Respuesta, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Coordinadora(string OrderId, string CodigoAlterno)
        {
            var Respuesta = _Coordinadora.GenerarGuia(OrderId, CodigoAlterno, "Factura: Importacion exitosa");
            Respuesta += Environment.NewLine + _Estados.StartHandling(OrderId, Respuesta);
            Respuesta += Environment.NewLine + _Estados.Invoicing(OrderId, Respuesta);
            Respuesta += Environment.NewLine + _Estados.Tracking(OrderId, Respuesta);

            if (Respuesta.Contains("Coordinadora: Importacion exitosa")
                && Respuesta.Contains("StartHandling: Importacion exitosa")
                && Respuesta.Contains("Invoicing: Importacion exitosa")
                && Respuesta.Contains("Tracking: Importacion exitosa"))
            {
                return Json("success" + "|" + Respuesta, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error" + "|" + Respuesta, JsonRequestBehavior.AllowGet);
            }
        }

        public FileResult Guia(string OrderId)
        {
            var Respuesta = _Guias.Descargar(OrderId);

            return File(Respuesta, "pdf", "Guia" + OrderId + ".pdf");
        }

        public ActionResult Rotulo(string OrderId)
        {
            var Respuesta = _Rotulos.Descargar(OrderId);

            return File(Respuesta, "pdf", "Rotulo" + OrderId + ".pdf");
        }

        [HttpPost]
        public ActionResult Anular(string OrderId)
        {
            return Json("success" + "|" + _Pedidos.Anular(OrderId), JsonRequestBehavior.AllowGet);
        }
    }
}