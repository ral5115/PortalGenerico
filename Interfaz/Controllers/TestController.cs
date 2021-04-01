using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interfaz.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public FileResult Download()
        {
            return File(@"C:\Users\Usuario\Documents\Codigo Fuente\Integracion Fruta Fresca Portal VTEX\Interfaz\Content\pdfs\Guia1068633005789-01.pdf", "pdf", "Guia1068633005789-01.pdf");
        }

        public FileResult DownloadParameter(string OrderId)
        {
            return File(@"C:\Users\Usuario\Documents\Codigo Fuente\Integracion Fruta Fresca Portal VTEX\Interfaz\Content\pdfs\Guia1068633005789-01.pdf", "application/pdf", "Guia1068633005789-01.pdf");
        }
    }
}