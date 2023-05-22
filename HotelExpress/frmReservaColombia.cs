using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelExpress
{
    public partial class frmReservaColombia : Form
    {
        public frmReservaColombia()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear una instancia de la clase clsRegistro para registrar el pago.
                clsRegistro registrarPago = new clsRegistro();

                // Obtener los valores seleccionados en los ComboBox para la cantidad de personas, camas, comidas y días.
                double cantidadPersonas = Convert.ToDouble(cboCantidadPersonas.Text);
                double cantidadCamas = Convert.ToDouble(cboCantidadCamas.Text);
                double cantidadComidas = Convert.ToDouble(cboCantidadComidas.Text);
                double cantidadDias = Convert.ToDouble(cboCantidadDias.Text);

                // Calcular el pago total utilizando el método estático CalcularPago de la clase clsRegistro.
                double pagoTotal = clsRegistro.CalcularPago(cantidadComidas, cantidadCamas, cantidadDias, cantidadPersonas);

                // Mostrar el pago total al cliente en un mensaje de MessageBox.
                MessageBox.Show("El cliente debe de Pagar " + pagoTotal);

                // Ocultar el formulario actual.
                this.Hide();

                // Abrir el formulario frmPagar y pasar el pago total como argumento.
                frmPagar pagar = new frmPagar(pagoTotal);
                

                // Abrir el formulario frmRegistro y pasar el pago total como argumento.
                frmRegistro registro = new frmRegistro(pagoTotal);
                registro.Show();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            // Maximizar el formulario al hacer clic en el botón "Maximizar"
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            // Restaurar el tamaño normal del formulario al hacer clic en el botón "Restaurar"
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            // Minimizar el formulario al hacer clic en el botón "Minimizar"
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario al hacer clic en el botón "Cerrar"
            this.Close();
        }
    }
}
