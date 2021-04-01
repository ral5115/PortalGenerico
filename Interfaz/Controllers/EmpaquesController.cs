using Dominio.FormulariosAdministracion;
using Dominio.Modelos;
using System;
using System.Web.Mvc;

namespace Interfaz.Controllers
{
    public class EmpaquesController : Controller
    {
        private readonly Empaques _Empaques = new Empaques();

        public ActionResult Index()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if ((int)Session["Perfil"] == 2)
            {
                return View(_Empaques.Consultar());
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
        public ActionResult Create(ModeloEmpaque Modelo)
        {
            if (_Empaques.Insertar(Modelo) == "EXISTE")
            {
                ViewData["Error"] = "EL NOMBRE DEL EMPAQUE YA EXISTE...";
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
                return View(_Empaques.EnviarModelo(RowId));
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Edit(ModeloEmpaque Modelo)
        {
            _Empaques.Actualizar(Modelo);
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
                return View(_Empaques.EnviarModelo(RowId));
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Delete(string RowId)
        {
            _Empaques.Eliminar(Convert.ToInt32(RowId));
            return Json("El empaque ha sido eliminado.", JsonRequestBehavior.AllowGet);
        }
    }
}