using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace EntidadesInstanciables
{
    public class Gimnasio
    {

        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornada;

        public enum EClases
        {
            CrossFit = 0,
            Natacion = 1,
            Pilates = 2,
            Yoga = 3
        }

        public Gimnasio() {
            _alumnos = new List<Alumno>();
            _instructores = new List<Instructor>();
            _jornada = new List<Jornada>();
        }

        public Jornada this[int i]
        {
            get
            {
                return _jornada[i];
            }
        }

        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }

        private static string MostrarDatos(Gimnasio gim)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADAS:");
            foreach (Jornada jornada in gim._jornada)
            {
                sb.Append(jornada.ToString());
                sb.AppendLine("<----------------------------------------------->");
            }

            return sb.ToString();

        }

        public static bool operator ==(Gimnasio g, Alumno a)
        {
            return g._alumnos.IndexOf(a) >= 0;
        }

        public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g==a);
        }

        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            if (g != a)
            {
                g._alumnos.Add(a);
                return g;
            }

            throw new AlumnoRepetidoException();
        }

        public static bool operator ==(Gimnasio g, Instructor i)
        {
            return g._instructores.IndexOf(i) >= 0;
        }

        public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g == i);
        }

        public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            if (g != i) g._instructores.Add(i);
            return g;
        }
        
        public static Instructor operator ==(Gimnasio g, EClases clase)
        {
            int i = g._instructores.FindIndex(instructor => instructor == clase);
            if (i < 0) throw new SinInstructorException();
            return g._instructores[i];
        }

        public static Instructor operator !=(Gimnasio g, EClases clase)
        {
            Instructor instructorDeClase = g._instructores.Find(instructor => instructor != clase);
            if (instructorDeClase == null) throw new SinInstructorException();
            return instructorDeClase;
        }

        public static Gimnasio operator +(Gimnasio g, EClases clase)
        {
            Jornada jornada = new Jornada(clase, g==clase);
            
            foreach(Alumno alumno in g._alumnos) {
                if (alumno == clase) jornada += alumno;
            }

            g._jornada.Add(jornada);

            return g;
        }

        public static bool Guardar(Gimnasio gim)
        {
            Xml<Gimnasio> xmlWritter = new Xml<Gimnasio>();
            return xmlWritter.guardar("Gimnasio.xml", gim);
        }

        public static Gimnasio Leer()
        {
            Gimnasio gim;
            Xml<Gimnasio> xmlReader = new Xml<Gimnasio>();
            xmlReader.leer("Gimnasio.xml", out gim);

            return gim;
        }

    }
}
