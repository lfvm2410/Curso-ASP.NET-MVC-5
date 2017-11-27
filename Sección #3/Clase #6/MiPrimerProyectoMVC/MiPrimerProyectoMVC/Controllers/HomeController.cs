using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiPrimerProyectoMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //Action Result permite retornar vistas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Alumno()
        {
            return View();
        }
    }
}