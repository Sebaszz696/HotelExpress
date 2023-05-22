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
    public partial class frmRegistroCrud : Form
    {
        public frmRegistroCrud()
        {
            InitializeComponent();
        }

        SqlConnection coneccion = new SqlConnection("server=SEBASZZ ; database = dboHotelExpress; INTEGRATED SECURITY = true");

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

        private void Registro_Load(object sender, EventArgs e)
        {
            // Evento de carga del formulario "Registro"
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                // Establecer la conexión a la base de datos.
                coneccion.Open();

                // Crear una instancia de la clase clsRegistro y pasar los valores ingresados en los TextBox y ComboBox.
                clsRegistro cliente = new clsRegistro(Convert.ToInt32(txtIntDocumento.Text), txtStrNombre.Text, txtStrApellido.Text, cboStrTipoDocumento.Text);

                // Insertar el dato en la base de datos.
                cliente.insertarDato();

                MessageBox.Show("Dato ingresado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar el dato: " + ex.Message);
            }
            finally
            {
                coneccion.Close();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Establecer la conexión a la base de datos.
                coneccion.Open();

                // Crear una instancia de la clase clsRegistro y pasar los valores ingresados en los TextBox y ComboBox.
                clsRegistro cliente = new clsRegistro(Convert.ToInt32(txtIntDocumento.Text), txtStrNombre.Text, txtStrApellido.Text, cboStrTipoDocumento.Text);

                // Modificar el dato correspondiente al número de documento ingresado.
                cliente.modificarDato();

                MessageBox.Show("Datos modificados correctamente");

                // Consultar los datos actualizados y mostrarlos en el DataGridView.
                dtgCliente.DataSource = cliente.consultarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el dato: " + ex.Message);
            }
            finally
            {
                coneccion.Close();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                // Establecer la conexión a la base de datos.
                coneccion.Open();

                // Crear una instancia de la clase clsRegistro.
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
                coneccion.Close();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Establecer la conexión a la base de datos.
                coneccion.Open();

                // Crear una instancia de la clase clsRegistro.
                clsRegistro cliente = new clsRegistro();

                // Asignar el número de documento ingresado a la instancia existente.
                cliente.intDocumento = Convert.ToInt32(txtCrud.Text);

                // Eliminar el dato correspondiente al número de documento ingresado.
                cliente.eliminarDatos();

                // Consultar los datos actualizados y mostrarlos en el DataGridView.
                dtgCliente.DataSource = cliente.consultarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se eliminó ningún dato: " + ex.Message);
            }
            finally
            {
                coneccion.Close();
            }
        }

        private void dtgCliente_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                // Mostrar los valores de la fila seleccionada en los TextBox y ComboBox correspondientes.
                txtIntDocumento.Text = dtgCliente.SelectedRows[0].Cells[0].Value.ToString();
                txtStrNombre.Text = dtgCliente.SelectedRows[0].Cells[1].Value.ToString();
                txtStrApellido.Text = dtgCliente.SelectedRows[0].Cells[2].Value.ToString();
                cboStrTipoDocumento.Text = dtgCliente.SelectedRows[0].Cells[3].Value.ToString();
                txtCrud.Text = dtgCliente.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
