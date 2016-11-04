using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInstanciables
{
    public sealed class Alumno : PersonaGimnasio
    {

        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        public enum EEstadoCuenta
        {
            Deudor,
            AlDia,
            MesPrueba
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendFormat("ESTADO DE CUENTA: {0}\n", _estadoCuenta);
            sb.AppendLine(this.ParticiparEnClase());

            sb.AppendLine("");

            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return string.Concat("TOMA CLASES DE ", this._claseQueToma.ToString());
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            return a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor;
        }

        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            return a._claseQueToma != clase;
        }


    }

}
