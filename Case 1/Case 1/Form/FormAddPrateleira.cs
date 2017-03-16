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

        List<Prateleira> Prateleiras;

        public FormAddPrateleira(List<Prateleira>Prateleiras)
        {
            InitializeComponent();
            this.Prateleiras = Prateleiras;
        }

        private void btnCadSetor_Click(object sender, EventArgs e)
        {
            Prateleira p = new Prateleira();

            p.ID = Prateleiras.Count+1;
            p.Setor = txtSetor.Text;                   
            Prateleiras.Add(p);     

            
        }   
    }
}
