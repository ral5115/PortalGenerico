using Dominio.FormulariosAdministracion;
using Dominio.Modelos;
using Dominio.Recursos;
using Infraestructura.CRUD;
using System;
using System.Web.Mvc;

namespace Interfaz.Controllers
{
    public class BodegasController : Controller
    {
        private readonly BDConsultar _BDConsultar = new BDConsultar();
        private readonly BDBodegas _BDBodegas = new BDBodegas();
        private readonly Bodegas _Bodegas = new Bodegas();
        private readonly Combos _Combos = new Combos();


        public ActionResult Index()
        {
            if (Session["Perfil"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if ((int)Session["Perfil"] == 2)
            {
                return View(_Bodegas.Consultar());
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
                ViewBag.ListadoBodegas = _Combos.ObtenerBodegas("Sp_ListadoBodegas_ERP");
                return View("Create");
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Create(ModeloBodega Modelo)
        {
            var Bodega = Modelo.IdBodega.Split('-');

            if (_Bodegas.ValidarBodega(Bodega[0]) == "EXISTE")
            {
                ViewBag.ListadoBodegas = _Combos.ObtenerBodegas("Sp_ListadoBodegas_ERP", Bodega[0]);
                ViewData["Error"] = "EL ID DE LA BODEGA YA EXISTE...";
                return View(Modelo);
            }

            _Bodegas.Insertar(Modelo);
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
                LlenarCombos(RowId);
                return View(_Bodegas.EnviarModelo(RowId));
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Edit(ModeloBodega Modelo)
        {
            _Bodegas.Actualizar(Modelo);
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
                LlenarCombos(RowId);
                return View(_Bodegas.EnviarModelo(RowId));
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Delete(string RowId)
        {
            _Bodegas.Eliminar(Convert.ToInt32(RowId));
            return Json("La bodega ha sido eliminada.", JsonRequestBehavior.AllowGet);
        }

        public void LlenarCombos(int RowId)
        {
            ViewBag.ListadoOrden = _Combos.ObtenerOrden("Sp_ListadoBodegas", RowId.ToString());
        }
    }
}