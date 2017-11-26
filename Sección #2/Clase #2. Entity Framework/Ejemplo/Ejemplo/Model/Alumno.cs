namespace Ejemplo.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("Alumno")]
    public partial class Alumno
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        public int Sexo { get; set; }

        [Required]
        [StringLength(10)]
        public string FechaNacimiento { get; set; }

        public List<Alumno> Listar()
        {

            var alumnos = new List<Alumno>();

            try
            {

                using (var ctx = new TestContext())
                {
                    alumnos = ctx.Alumno.ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }

            return alumnos;

        }

        public void Guardar(Alumno alumno)
        {

            try
            {

                using (var ctx = new TestContext())
                {
                    /*Registro que ya existe*/
                    if(alumno.id > 0)
                    {
                        //Toma el alumno como entrada y determina que aplicar de acuerdo al estado
                        ctx.Entry(alumno).State = EntityState.Modified;
                    }
                    else /*Nuevo Registro*/
                    {
                        //Toma el alumno como entrada y determina que aplicar de acuerdo al estado
                        ctx.Entry(alumno).State = EntityState.Added;
                    }

                    ctx.SaveChanges(); //Guardar cambios
                        
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public void Eliminar(int id)
        {
            try
            {
                using (var ctx = new TestContext())
                {
                    //Elimina alumno por su id
                    ctx.Entry(new Alumno { id = id }).State = EntityState.Deleted;
                    ctx.SaveChanges();
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public Alumno Obtener(int id)
        {
            var alumno = new Alumno();

            try
            {
                using (var ctx = new TestContext())
                {
                    //Obtiene alumno por id
                    //Single = retorna un resultado
                    alumno = ctx.Alumno.Where(x => x.id == id).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return alumno;

        }

   }
}
