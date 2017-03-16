    using Case_1.Model;
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

namespace Case_1.Form
{
    public partial class FormAddPrateleira : System.Windows.Forms.Form
    {

        public Model1 DB = new Model1();
        public FormAddPrateleira()
        {
            InitializeComponent();

        }

        private void btnCadSetor_Click(object sender, EventArgs e)
        {
            Prateleira p = new Prateleira();

            p.Setor = txtSetor.Text;                   

            DB.Prateleiras.Add(p);
            DB.SaveChanges();
            MessageBox.Show("Tabela inserida com sucesso", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtSetor.Clear();
        }   
    }
}
