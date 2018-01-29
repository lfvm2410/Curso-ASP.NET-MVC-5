using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.IO;

namespace MiPrimerProyectoMVC.Controllers
{
    public class HomeController : Controller
    {

        private Alumno alumno = new Alumno();
        private AlumnoCurso alumnoCurso = new AlumnoCurso();
        private Curso curso = new Curso();
        private Adjunto adjunto = new Adjunto();

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

        //Retorno de vista parcial
        public ActionResult Cursos(AlumnoCurso alumnoCurso)
        {
            //Listamos los cursos de un alumno
            ViewBag.CursosElegidos = alumnoCurso.Listar(alumnoCurso.Alumno_id);

            //Listamos todos los cursos DISPONIBLES
            ViewBag.Cursos = curso.Todos(alumnoCurso);

            if (Request.IsAjaxRequest())
            {
                var rm = new ResponseModel();

                rm.SetResponse(true);
                rm.message = RenderPartialViewToString("Cursos", alumnoCurso);

                //Retorna la vista parcial en application/json
                return Json(rm);
            }
            else
            {
                //Retorna la vista parcial en text/html
                return PartialView(alumnoCurso);
            }

        }

        //Metodo que convierte a string una partialview
        protected string RenderPartialViewToString(string viewName, object model)
        {
            //Se le especifica el modelo a la vista parcial con ViewData para luego operar con el contexto
            ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                //Encontrar la vista parcial
                //ControllerContext: Contexto del controlador, entorno
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);

                /* ViewContext: Contexto de la vista
                 * ViewData: Son los datos de vista que se pasan a la vista
                 * TempData: Datos asociados a la solicitud actual, solo para ella
                 * Writer: Obtiene o establece el objeto para escribir la salida a HTML
                 */

                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);

                //Renderiza la vista al string writer asociado
                viewResult.View.Render(viewContext, sw);

                //Libera la vista usando el contexto del controlador
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);

                //Se retorna la vista en string
                return sw.GetStringBuilder().ToString();

            }
        }

        // Vista parcial de adjuntos
        // home/Adjuntos/?Alumno_id=1
        public PartialViewResult Adjuntos(int Alumno_id)
        {
            ViewBag.Adjuntos = adjunto.Listar(Alumno_id);

            return PartialView(adjunto);
        }

        //Se guardan los alumnos del alumno en modo de edición
        //HttpPostedFileBase name debe coincidir con el name de la etiqueta file en el form
        public JsonResult GuardarAdjunto(Adjunto model, HttpPostedFileBase Archivo)
        {
            var rm = new ResponseModel();

            // Validar si viene o no el archivo
            if (Archivo != null)
            {
                //Nombre archivo: Fecha exacta actual más extensión de archivo
                string archivo = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(Archivo.FileName);
                
                //Guardar archivo en la ruta con un nombre único
                //MapPath: Devuelve ruta de acceso especificada de acuerdo a la que necesita al servidor
                Archivo.SaveAs(Server.MapPath("~/uploads/" + archivo));

                //Se le indica el nombre del archivo al modelo
                model.Archivo = archivo;
                     
                rm = model.Guardar();

                if (rm.response)
                {
                    rm.function = "CargarAdjuntos();";
                }
            }
            else
            {
                rm.SetResponse(false, "Debe adjuntar un archivo");
            }

            //Serializar objeto
            return Json(rm);
        }

        //Se guardan los cursos del alumno en modo de edición
        public JsonResult GuardarCurso(AlumnoCurso model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                rm = model.Guardar();

                if (rm.response)
                {
                    rm.function = "CargarCursos();";
                }

            }

            //Serializar objeto
            return Json(rm);
        }

        //Eliminar alumno de curso
        public JsonResult EliminarAlumnoCurso(int id)
        {
            var rm = new ResponseModel();
            alumnoCurso.id = id;

            if (ModelState.IsValid)
            {
                rm = alumnoCurso.Eliminar();

                if (rm.response)
                {
                    rm.function = "CargarCursos();";
                    rm.message = "Se ha eliminado el curso correctamente";
                }

            }

            //Serializar objeto
            return Json(rm);
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
        /*public ActionResult GuardarAlumno(Alumno model)
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
            
        }*/

        //Se guarda el alumno pero se devuelve un objeto json
        public JsonResult GuardarAlumno(Alumno model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                rm = model.Guardar();

                if (rm.response)
                {
                    //rm.function = "SoyAlgo()";
                    rm.href = Url.Content("~/home/VerAlumnos");
                }

            }

            //Serializar objeto
            return Json(rm);
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