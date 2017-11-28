namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Alumno")]
    public partial class Alumno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alumno()
        {
            Adjunto = new HashSet<Adjunto>();
            AlumnoCurso = new HashSet<AlumnoCurso>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adjunto> Adjunto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlumnoCurso> AlumnoCurso { get; set; }

        public List<Alumno> Listar()
        {
            var alumnos = new List<Alumno>();

            try
            {
                using (var ctx = new TestContext())
                {
                    alumnos = ctx.Alumno.ToList();
                }
            }catch (Exception)
            {
                throw;
            }

            return alumnos;
        }

        public Alumno Obtener(int id)
        {
            var alumno = new Alumno();

            try
            {
                using (var ctx = new TestContext())
                {
                    /*
                     * Cancelar lazy load
                     * Lazy load puede acceder a propiedades y automaticamente se ejecutar 
                     * una consulta que traiga lo relacionado a la propiedad
                     * ctx.Configuration.LazyLoadingEnabled = false;
                     * */

                    /*El include permite incluir en la consulta la relación 
                    de la tabla
                    
                    AlumnoCurso: Trae la relación
                    AlumnoCurso.Curso: Trae la relación del AlumnoCurso con el Curso
                     */
                    alumno = ctx.Alumno.Include("AlumnoCurso")
                                       .Include("AlumnoCurso.Curso")
                                       .Where(x => x.id == id)
                                       .SingleOrDefault();
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
