using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP01_BarrionuevoAnaly
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Calculadora";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            this.lblResultado.Text = "";
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            String textNumero1 = this.txtNumero1.Text;
            String opera = this.cmbOperacion.Text;
            String textNumero2 = this.txtNumero2.Text;

            string operadorValidado;

            Calculadora calculadora = new Calculadora();

            Numero num1 = new Numero(textNumero1);
            Numero num2 = new Numero(textNumero2);

            operadorValidado = calculadora.validarOperador(opera);

            double resultado;

            resultado = calculadora.operar(num1, num2, operadorValidado);

            this.lblResultado.Text = resultado.ToString();
        }
    }
}
