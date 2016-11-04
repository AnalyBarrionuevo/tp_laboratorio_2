using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        public enum ENacionalidad
        {
            Extranjero, Argentino
        }
        
        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = ValidarNombreApellido(value);
            }
        }

        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = ValidarNombreApellido(value);
            }
        }

        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = this.ValidarDni(this._nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }

        public string StringToDNI
        {
            set
            {
                this._dni = this.ValidarDni(this._nacionalidad, value);
            }
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            try
            {
                this.DNI = dni;
            }
            catch (DniInvalidoException)
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI.");
            }
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            try
            {
                this.StringToDNI = dni;
            }
            catch (DniInvalidoException)
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI.");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);
            sb.AppendFormat("DNI: {0}\n", this.DNI);

            return sb.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && dato >= 90000000 || nacionalidad == ENacionalidad.Extranjero && dato < 90000000) throw new DniInvalidoException();
            return dato;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return this.ValidarDni(nacionalidad, Int32.Parse(dato));
        }

        private string ValidarNombreApellido(string dato)
        {
            return dato.All(Char.IsLetter) ? dato : null;
        }
    }

}
