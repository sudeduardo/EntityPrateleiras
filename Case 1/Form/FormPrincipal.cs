using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Case_1.Form;
using Case_1.Model;

namespace Case_1
{
    public partial class Form1 : System.Windows.Forms.Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        private void prateleiraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAcoesPrat frmAcoesPrat = new FormAcoesPrat();
            frmAcoesPrat.Show();
           
           
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAcoesProd frmAcoesProd = new FormAcoesProd();            
            frmAcoesProd.Show();
        }

        private void adcionarPlateleiraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddPrateleira p = new FormAddPrateleira();
            p.Show();
        }



      
    }
}
