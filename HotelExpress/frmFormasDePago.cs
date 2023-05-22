using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelExpress
{
    public partial class frmFormasDePago : Form
    {
        public frmFormasDePago()
        {
            InitializeComponent();
        }

        private void btnVisa_Click(object sender, EventArgs e)
        {
            //LLeva a la pagina de visa
            Process.Start("https://www.visa.com.co");
        }

        private void btnMasterCard_Click(object sender, EventArgs e)
        {
            //LLeva a la pagina de MasterCard
            Process.Start("https://www.mastercard.com.co");
        }

        private void btnAmericanExpress_Click(object sender, EventArgs e)
        {
            //LLeva a la pagina de AmericanExpress
            Process.Start("https://www.americanexpress.com");
        }

        private void btnPse_Click(object sender, EventArgs e)
        {
            //LLeva a la pagina de Pse
            Process.Start("https://www.pse.com.co/persona");
        }

        private void btnNequi_Click(object sender, EventArgs e)
        {
            //LLeva a la pagina de recarga Nequi
            Process.Start("https://recarga.nequi.com.co");
        }

        private void btnBancolombia_Click(object sender, EventArgs e)
        {
            //LLeva a la pagina de Bancolombia
            Process.Start("https://www.bancolombia.com");
        }
    }
}
