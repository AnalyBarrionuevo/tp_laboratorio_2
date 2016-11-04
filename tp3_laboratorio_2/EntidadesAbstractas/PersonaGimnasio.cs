using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class PersonaGimnasio : Persona
    {
        private int _identificador;

        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._identificador = id;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PersonaGimnasio)) return false;
            PersonaGimnasio personaGimnasio = (PersonaGimnasio)obj;
            return this == personaGimnasio;
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("CARNET NUMERO: {0}\n", this._identificador);
            
            return sb.ToString();
        }

        public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return pg1.Nacionalidad == pg2.Nacionalidad && (pg1._identificador == pg2._identificador || pg1.DNI == pg2.DNI);
        }

        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }

        protected abstract string ParticiparEnClase();

    }
}
