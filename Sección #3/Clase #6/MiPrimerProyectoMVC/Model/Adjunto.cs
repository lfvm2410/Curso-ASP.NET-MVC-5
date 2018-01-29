namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Adjunto")]
    public partial class Adjunto
    {
        public int id { get; set; }

        public int Alumno_id { get; set; }

        [Required]
        [StringLength(200)]
        public string Archivo { get; set; }

        public virtual Alumno Alumno { get; set; }

        public List<Adjunto> Listar(int Alumno_id)
        {
            var adjuntos = new List<Adjunto>();

            try
            {

                using (var ctx = new TestContext())
                {
                    adjuntos = ctx.Adjunto.Where(x => x.Alumno_id == Alumno_id)
                                          .ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }

            return adjuntos;
        }

        //Guardar los adjuntos de un alumno en edici�n
        public ResponseModel Guardar()
        {
            //Por defecto se setea como respuesta con errores. Cuando llega a exito, se cambia a respuesta debida
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new TestContext())
                {
                   
                    ctx.Entry(this).State = EntityState.Added;
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
