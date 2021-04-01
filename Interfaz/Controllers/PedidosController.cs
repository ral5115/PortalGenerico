using Dominio.FormulariosPublicos;
using System.Web.Mvc;

namespace Interfaz.Controllers
{
    public class PedidosController : Controller
    {
        private readonly Pedidos _Pedidos = new Pedidos();

        public ActionResult Index()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(_Pedidos.Consultar());
        }
    }
}