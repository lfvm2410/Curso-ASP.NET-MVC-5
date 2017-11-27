using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MiPrimerProyectoMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //Action Result permite retornar vistas
        public ActionResult Index()
        {
            //Viewbag se utiliza para setear datos que se pueden recoger en la vista
            ViewBag.Algo = "Soy algo";
            ViewBag.Alumnos = Alumno.Listar();
            ViewBag.Alumno = Alumno.Obtener();

            //Se le pasa modelo a la vista para listar los alumnos
            //Mediante el view se especifica el modelo principal de la vista
            //Con ViewBag se pasan las demas cosas
            return View(Alumno.Listar());
        }

        public ActionResult Ver(int id = 0)
        {
            ViewBag.id = id;

            return View(Alumno.Obtener());
        }

        public ActionResult Guardar(Alumno alumno, int algo, int[] pruebaArray)
        {
            //Redireccionar a otro metodo del controlador
            return Redirect("~/Home/Index");
        }
    }
}