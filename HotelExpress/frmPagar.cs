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
    public partial class frmPagar : Form
    {
private double pagoTotal;

        public frmPagar(double pagoTotal)
        {
            InitializeComponent();

            
            this.pagoTotal = pagoTotal;
        }

        private void Pagar_Load(object sender, EventArgs e)
        {
            
           lblPagar.Text = pagoTotal.ToString();
        }

        private void btnFormasDePago_Click(object sender, EventArgs e)
        {
            //Va a formas de pago
            this.Hide();
            frmFormasDePago forma = new frmFormasDePago();
            forma.Show();
        }
    }
}
