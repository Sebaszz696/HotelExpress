using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace HotelExpress
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        #region Drag Form/ Mover Arrastrar Formulario
        // Importar funciones externas para permitir mover el formulario sin bordes
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // Permitir mover el formulario al hacer clic y arrastrar en cualquier parte del formulario
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            // Permitir mover el formulario al hacer clic y arrastrar en cualquier parte del panel
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Placeholder or WaterMark
        private void txtuser_Enter(object sender, EventArgs e)
        {
            // Placeholder para el campo de usuario
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            // Placeholder para el campo de usuario
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.Silver;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            // Placeholder para el campo de contraseña
            if (txtContrasena.Text == "Contraseña")
            {
                txtContrasena.Text = "";
                txtContrasena.ForeColor = Color.LightGray;
                txtContrasena.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            // Placeholder para el campo de contraseña
            if (txtContrasena.Text == "")
            {
                txtContrasena.Text = "Contraseña";
                txtContrasena.ForeColor = Color.Silver;
                txtContrasena.UseSystemPasswordChar = false;
            }
        }
        #endregion 

        private void btncerrar_Click(object sender, EventArgs e)
        {
            // Cerrar la aplicación al hacer clic en el botón "Cerrar"
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            // Minimizar el formulario al hacer clic en el botón "Minimizar"
            this.WindowState = FormWindowState.Minimized;
        }

        SqlConnection coneccion = new SqlConnection("server=SEBASZZ ; database = dboHotelExpress; INTEGRATED SECURITY = true");

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                coneccion.Open();

                SqlCommand comando = new SqlCommand("SELECT strUsuario, strContrasena FROM tblLogin WHERE strUsuario = @strUsuario AND strContrasena = @strContrasena", coneccion);
                comando.Parameters.AddWithValue("@strUsuario", txtUsuario.Text);
                comando.Parameters.AddWithValue("@strContrasena", txtContrasena.Text);

                SqlDataReader lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    coneccion.Close();

                    frmPaginaPrincipal paginaPrincipal = new frmPaginaPrincipal();
                    this.Hide(); // Oculta el formulario actual
                    paginaPrincipal.Show();
                }
                else
                {
                    // Validar que los campos de usuario y contraseña no estén vacíos antes de mostrar el mensaje de error
                    if (txtUsuario.Text != "Usuario") { }
                    else
                    {
                        MessageBox.Show("El Campo usuario no puede quedar vacio");
                    }

                    if (txtContrasena.Text != "Contraseña") { }
                    else
                    {
                        MessageBox.Show("El Campo Contraseña no puede quedar vacio");
                    }

                    MessageBox.Show("El usuario o contraseña es incorrecto");
                    coneccion.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Evento de carga del formulario
        }

        private void linkpass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Mostrar un mensaje con una pista para restablecer la contraseña o contactar al área de sistemas
            MessageBox.Show("Contacte con el área de sistemas de HotelExpress o aquí tienes una pista: el usuario es Admin");
        }
    }
}
