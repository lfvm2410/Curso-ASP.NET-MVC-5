namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("AlumnoCurso")]
    public partial class AlumnoCurso
    {
        public int id { get; set; }

        public int Alumno_id { get; set; }

        public int Curso_id { get; set; }

        [Required(ErrorMessage="Debe ingresar una nota para el alumno.")]
        [Range(0, 20, ErrorMessage = "Debe ingresar una nota entre 0 a 20.")]
        public decimal Nota { get; set; }

        public virtual Alumno Alumno { get; set; }

        public virtual Curso Curso { get; set; }

        //Guardar los cursos de un alumno en edición. En la tabla de relacion n:m
        public ResponseModel Guardar()
        {
            //Por defecto se setea como respuesta con errores. Cuando llega a exito, se cambia a respuesta debida
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new TestContext())
                {

                    if (this.id > 0)
                    {
                        ctx.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        ctx.Entry(this).State = EntityState.Added;
                    }
                    
                    rm.SetResponse(true);
                    ctx.SaveChanges();
                }
            }
            catch (Exception E)
            {
                throw;
            }

            return rm;
        }


        //Se trae los cursos relacionados a un alumno
        public List<AlumnoCurso> Listar(int Alumno_id)
        {
            var alumnoCursos = new List<AlumnoCurso>();

            try
            {
                using (var ctx = new TestContext())
                {
                    alumnoCursos = ctx.AlumnoCurso.Include("Curso")
                                                  .Where(x => x.Alumno_id == Alumno_id)
                                                  .ToList();
                }
            }
            catch (Exception E)
            {
                throw;
            }

            return alumnoCursos;
        }

        //Eliminar alumno de curso
        public ResponseModel Eliminar()
        {
            //Por defecto se setea como respuesta con errores. Cuando llega a exito, se cambia a respuesta debida
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new TestContext())
                {

                    ctx.Entry(this).State = EntityState.Deleted;
          
                    //Hasta este punto no hay errores. Por lo tanto se cambia el objeto a true para no responder con error
                    rm.SetResponse(true);
                    ctx.SaveChanges();
                }
            }
            catch (Exception E)
            {
                throw;
            }

            return rm;
        }
    }
}
