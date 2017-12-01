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

        private Alumno alumno = new Alumno();
        
        // GET: Home
        //Action Result permite retornar vistas
        public ActionResult Index()
        {
            //Viewbag se utiliza para setear datos que se pueden recoger en la vista
            ViewBag.Algo = "Soy algo";
            ViewBag.Alumnos = alumno.Listar();
            //ViewBag.Alumno = alumno.Obtener();

            //Se le pasa modelo a la vista para listar los alumnos
            //Mediante el view se especifica el modelo principal de la vista
            //Con ViewBag se pasan las demas cosas
            return View(alumno.Listar());
        }

        public ActionResult VerAlumnos()
        {
            return View(alumno.Listar());
        }

        //home/ver/1
        public ActionResult VerAlumno(int id = 0)
        { 
            return View(alumno.Obtener(id));
        }

        public ActionResult Ver(int id = 0)
        {
            ViewBag.id = id;

            return View(alumno.Obtener(id));
        }

        public ActionResult Guardar(Alumno alumno, int algo, int[] pruebaArray)
        {
            //Redireccionar a otro metodo del controlador
            return Redirect("~/Home/Index");
        }


        /*
         * Accion para actualizar o insertar un registro
         * Si el id viene vacio entonces se crea un nuevo alumno
         * Si el id viene con informacion, se modifica el alumno existente
         */
        public ActionResult Crud(int id = 0)
        {
            return View(
                id == 0 ? new Alumno()
                        : alumno.Obtener(id)
            );
        }

        //Como la vista esta ligada al modelo, entonces solo se llama al metodo guardar para utilizar su mismo contexto
        public ActionResult GuardarAlumno(Alumno model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                //Redirige a index automaticamente por ser accion por defecto
                return Redirect("~/home/VerAlumnos");
            }
            else
            {
                //Se le pasa el modelo a la vista para que lo tenga asignado al llamarla
                //Tambien se le pasa el modelo para que la vista muestre los campos de validacion
                return View("~/views/home/crud.cshtml", model);
            }
            
        }

        //Como la vista esta ligada al modelo, entonces solo se llama al metodo eliminar para utilizar su mismo contexto
        public ActionResult EliminarAlumno(int id)
        {
            alumno.id = id;
            alumno.Eliminar();
            //Redirige a index automaticamente por ser accion por defecto
            return Redirect("~/home/VerAlumnos");
        }
    }
}