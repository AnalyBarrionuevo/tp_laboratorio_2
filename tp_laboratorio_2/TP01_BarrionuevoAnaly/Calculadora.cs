using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01_BarrionuevoAnaly
{
    class Calculadora
    {
        public double operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado;

            if (operador == "/")
            {
                if (numero2.getNumero() == 0)
                    return 0;
                else
                {
                    resultado = numero1.getNumero() / numero2.getNumero();
                    return resultado;
                }
            }
            else
            {
                if (operador == "*")
                {
                    resultado = numero1.getNumero() * numero2.getNumero();
                    return resultado;
                }
                else
                {
                    if (operador == "+")
                    {
                        resultado = numero1.getNumero() + numero2.getNumero();
                        return resultado;
                    }
                    else
                    {
                        resultado = numero1.getNumero() - numero2.getNumero();
                        return resultado;
                    }
                }
            }
        }

        public string validarOperador(string operador)
        {
            if (operador == "/" || operador == "*" || operador == "+" || operador == "-")
                return operador;
            else
                return "+";
        }
    }
}
