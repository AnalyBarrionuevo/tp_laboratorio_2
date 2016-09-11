using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01_BarrionuevoAnaly
{
    class Numero
    {
        double numero;

        public double getNumero()
        {
            return this.numero;
        }
       
        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string numero)
        {
            this.numero = validarNumero(numero);
        }

        private void setNumero(string numero)
        {
            this.numero = validarNumero(numero);
        }

        private double validarNumero(string numeroString)
        {
            double number;

            if (Double.TryParse(numeroString, out number))
                return number;

            else
                return 0;     
        }
    }
}
