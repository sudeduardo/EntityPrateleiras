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
        public List<Prateleira> Prateleiras = new List<Prateleira>();
        public Form1()
        {
            InitializeComponent();
         
            for (int i = 0; i < 5; i++)
            {
                Prateleira a = new Prateleira();
                a.ID = i; 
                a.Setor = RandomString(3);
                Prateleiras.Add(a);

                for (int j = 0; j < 3; j++)
                {
                    Produto p = new Produto();
                    p.ID = j;
                    p.Nome = RandomString(3);
                    p.Quantidade = random.Next();
                    Prateleiras[i].Produtos.Add(p);
                }
            }

        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void prateleiraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAcoesPrat frmAcoesPrat = new FormAcoesPrat(Prateleiras);
            frmAcoesPrat.Show();
           
           
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAcoesProd frmAcoesProd = new FormAcoesProd(Prateleiras);            
            frmAcoesProd.Show();
        }

        private void adcionarPlateleiraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddPrateleira p = new FormAddPrateleira(Prateleiras);
            p.Show();
        }



      
    }
}
