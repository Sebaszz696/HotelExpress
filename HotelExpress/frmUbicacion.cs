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
    public partial class frmUbicacion : Form
    {
        public frmUbicacion()
        {
            InitializeComponent();
        }
  
        //Estos botones e imagenes simplemente llevan a las diferentes reservas
        private void pictureBox3_Click(object sender, EventArgs e)
        {

            frmReservaEspaña reservaEspaña = new frmReservaEspaña();
            reservaEspaña.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmReservaColombia reservaColombia = new frmReservaColombia();
            reservaColombia.Show();
        }
       
        private void btnColombiaa_Click(object sender, EventArgs e)
        {
            
            frmReservaColombia reservaColombia = new frmReservaColombia();
            reservaColombia.Show();
        }

        private void btnFrancia_Click(object sender, EventArgs e)
        {
            frmReservaFrancia reservaFrancia = new frmReservaFrancia();

            reservaFrancia.Show();
        }

        private void btnEspaña_Click(object sender, EventArgs e)
        {
            frmReservaEspaña reservaEspaña = new frmReservaEspaña();
            reservaEspaña.Show(); 
        }

      

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmReservaJapon reservaOtrosPaises = new frmReservaJapon();

            reservaOtrosPaises.Show();
        }

        private void btnJapon_Click(object sender, EventArgs e)
        {
            frmReservaJapon reservaOtrosPaises = new frmReservaJapon();

            reservaOtrosPaises.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmReservaFrancia reservaFrancia = new frmReservaFrancia();

            reservaFrancia.Show();
        }
    }
}
