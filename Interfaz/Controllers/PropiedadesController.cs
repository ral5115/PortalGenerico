using Dominio.FormulariosAdministracion;
using Dominio.Modelos;
using System;
using System.Web.Mvc;

namespace Interfaz.Controllers
{
    public class PropiedadesController : Controller
    {
        private readonly Propiedades _Propiedades = new Propiedades();

        public ActionResult Index()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if ((int)Session["Perfil"] == 2)
            {
                return View(_Propiedades.Consultar());
            }

            return RedirectToAction("Index", "Login");
        }

        public ActionResult Create()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if ((int)Session["Perfil"] == 2)
            {
                return View("Create");
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Create(ModeloPropiedad Modelo)
        {
            if (_Propiedades.Insertar(Modelo) == "EXISTE")
            {
                ViewData["Error"] = "EL NOMBRE DE LA PROPIEDAD YA EXISTE...";
                return View(Modelo);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int RowId)
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if ((int)Session["Perfil"] == 2)
            {
                return View(_Propiedades.EnviarModelo(RowId));
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Edit(ModeloPropiedad Modelo)
        {
            _Propiedades.Actualizar(Modelo);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int RowId)
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if ((int)Session["Perfil"] == 2)
            {
                return View(_Propiedades.EnviarModelo(RowId));
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Delete(string RowId)
        {
            _Propiedades.Eliminar(Convert.ToInt32(RowId));
            return Json("La propiedad ha sido eliminada.", JsonRequestBehavior.AllowGet);
        }
    }
}