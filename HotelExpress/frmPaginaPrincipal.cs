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

namespace HotelExpress
{
    public partial class frmPaginaPrincipal : Form
    {
        public frmPaginaPrincipal()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // Cerrar la aplicación al hacer clic en el botón "Cerrar"
            Application.Exit();
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

        // Importar funciones externas para permitir mover el formulario sin bordes
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            // Permitir mover el formulario al hacer clic y arrastrar en la barra de título
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            // Cerrar la aplicación al hacer clic en el botón "Salir"
            Application.Exit();
        }

        private void Abrirformhijo(object formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void btnUbicacion_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de Ubicación al hacer clic en el botón "Ubicación"
            Abrirformhijo(new frmUbicacion());
        }

        private void btnMetodoDePago_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de Formas de Pago al hacer clic en el botón "Método de Pago"
            Abrirformhijo(new frmFormasDePago());
        }

        private void btnDatosCliente_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de Datos del Cliente al hacer clic en el botón "Datos del Cliente"
            Abrirformhijo(new frmDatosCliente());
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de Empleados Nuevos al hacer clic en el botón "Empleados"
            Abrirformhijo(new frmEmpleadosNuevos());
        }
    }
}
