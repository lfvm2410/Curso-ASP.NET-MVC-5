using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public static List<Alumno> Listar()
        {
            var alumnos = new List<Alumno>();

            for (var i = 0; i <= 10; i++)
            {
                alumnos.Add(new Alumno()
                {
                    Id = i,
                    Nombre = "Alumno " + i
                });
            }

            return alumnos;

        }

        public static Alumno Obtener()
        {
            return new Alumno
            {
                Id = 1,
                Nombre = "Alumno 1"
            };
        }

    }
}
