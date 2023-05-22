using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelExpress
{
    public partial class frmRegistro : Form
    {
        public frmRegistro(double pagoTotal)
        {
            InitializeComponent();
            this.pagoTotal = pagoTotal;
        }

        private double pagoTotal;

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

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection coneccion = new SqlConnection("server=SEBASZZ ; database = dboHotelExpress; INTEGRATED SECURITY = true");
                // Establecer la conexión a la base de datos.
                coneccion.Open();

                // Crear una instancia de la clase clsRegistro y pasar los valores ingresados en los TextBox y ComboBox.
                clsRegistro cliente = new clsRegistro(Convert.ToInt32(txtIntDocumento.Text), txtStrNombre.Text, txtStrApellido.Text, cboStrTipoDocumento.Text);

                // Insertar el dato en la base de datos.
                cliente.insertarDato();

                MessageBox.Show("Dato ingresado correctamente");

                this.Hide();
                frmPagar pagar = new frmPagar(pagoTotal);
                pagar.Show();

                coneccion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar el dato: " + ex.Message);
            }
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            // Evento de carga del formulario "Registro"
        }
    }
}
