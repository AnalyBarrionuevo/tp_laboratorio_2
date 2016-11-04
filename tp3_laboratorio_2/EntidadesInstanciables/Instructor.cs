using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInstanciables
{
    public sealed class Instructor : PersonaGimnasio
    {

        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;

        static Instructor()
        {
            Instructor._random = new Random();
        }

        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            _clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClases();

        }

        private void _randomClases() 
        {
            int cantClases = Enum.GetNames(typeof(Gimnasio.EClases)).Length;

            for (int i = 0; i < 2; i++)
            {
                Gimnasio.EClases clase = (Gimnasio.EClases)_random.Next(0, cantClases);
                _clasesDelDia.Enqueue(clase);
            }

        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder("CLASES DEL DIA: ");

            foreach (Gimnasio.EClases clase in _clasesDelDia)
                sb.AppendFormat("{0} ", clase.ToString());

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Instructor i, Gimnasio.EClases clase)
        {
            return i._clasesDelDia.Contains(clase);
        }

        public static bool operator !=(Instructor i, Gimnasio.EClases clase)
        {
            return !(i == clase);
        }

    }
}
