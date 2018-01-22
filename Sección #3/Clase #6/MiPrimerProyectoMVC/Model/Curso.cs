namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    [Table("Curso")]
    public partial class Curso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Curso()
        {
            AlumnoCurso = new HashSet<AlumnoCurso>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlumnoCurso> AlumnoCurso { get; set; }

        public List<Curso> Todos(int Alumno_id = 0)
        {//Se debe crear inner join para ignorar los cursos del alumno en cuestion
            var cursos = new List<Curso>();

            try
            {

                using(var ctx = new TestContext())
                {
                    if (Alumno_id > 0)
                    {
                        //Forma más sencilla
                        /*cursos = ctx.Database.SqlQuery<Curso>("SELECT C.* FROM Curso C WHERE C.id NOT IN (SELECT Curso_id FROM AlumnoCurso A WHERE A.Curso_id = C.id AND A.Alumno_id = @Alumno_id)", new SqlParameter("Alumno_id", Alumno_id))
                                     .ToList();*/

                        var cursosTomados = ctx.AlumnoCurso.Where(x => x.Alumno_id == Alumno_id)
                                                                           .Select(x => x.Curso_id)
                                                                           .ToList();

                        // Cursos donde no esta el alumno (Curso no tomados, apartir de los tomados)
                        cursos = ctx.Curso.Where(x => !cursosTomados.Contains(x.id)).ToList();
                    }
                    else
                    {
                        cursos = ctx.Curso.ToList();
                    }

                }

            }catch (Exception)
            {
                throw;
            }

            return cursos;
        }
    }
}
