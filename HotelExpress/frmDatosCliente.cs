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
    public partial class frmDatosCliente : Form
    {
        public frmDatosCliente()
        {
            InitializeComponent();
        }
        //crera la conexion a la base de datos 
        SqlConnection coneccion = new SqlConnection("server=SEBASZZ ; database = dboHotelExpress; INTEGRATED SECURITY = true");


        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                
                // Establecer la conexión a la base de datos.
                coneccion.Open();

                // Crear una instancia de la clase clsCliente.
                clsRegistro cliente = new clsRegistro();

                // Consultar todos los datos y mostrarlos en el DataGridView.
               dtgCliente.DataSource = cliente.consultarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar los datos: " + ex.Message);
            }
            finally
            {
                coneccion.Close(); // Cierra la conexión en el bloque finally
            }
        }

     


        private void btnBuscar_Click(object sender, EventArgs e)
        {
          //LLeva al registro donde se puede modificar las cosas
            frmRegistroCrud registroCrud = new frmRegistroCrud();
            this.Hide();
            registroCrud.Show();
        }

      
        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void DatosCliente_Load(object sender, EventArgs e)
        {

        }

       
    }
}
