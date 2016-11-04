using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Gimnasio.EClases _clase;
        private Instructor _instructor;

        private Jornada() 
        { 
            _alumnos = new List<Alumno>();
        }

        public Jornada(Gimnasio.EClases clase, Instructor instructor) : this() {
            _clase = clase;
            _instructor = instructor;
        }

        public static bool Guardar(Jornada jornada)
        {
            Texto textoWritter = new Texto();
            return textoWritter.guardar("Jornada.txt", jornada.ToString());

        }

        public static string Leer(Jornada jornada)
        {
            string archivo;
            Texto textoReader = new Texto();
            textoReader.leer("Jornada.txt", out archivo);

            return archivo;
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            return j._alumnos.IndexOf(a) >= 0;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j._alumnos.Add(a);
                return j;
            }

            throw new AlumnoRepetidoException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DE {0} POR {1}\n", this._clase.ToString(), this._instructor.ToString());
            sb.AppendLine("ALUMNOS:");

            foreach (Alumno alumno in _alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }

            return sb.ToString();
        }

    }
}
