using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Case_1.Model;

namespace Case_1.Form
{
    public partial class FormAcoesProd : System.Windows.Forms.Form
    {
        public List<Prateleira> Prateleira;
        public FormAcoesProd(List<Prateleira> Prateleira)
        {
            InitializeComponent();
            this.Prateleira = Prateleira;
            foreach (Prateleira p in Prateleira)
            {
                listPrateleiras.Items.Add(p.Setor);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            if (!(listPrateleiras.SelectedIndex == -1))
            {
                string setor = listPrateleiras.SelectedItem.ToString();
                foreach (Prateleira p in Prateleira) {
                    if (p.Setor == setor) {
                        Produto prod = new Produto();
                        prod.ID = p.Produtos.Count + 1;
                        prod.Nome = txtNome.Text;
                        try {
                            prod.Quantidade = Convert.ToInt32(txtQtd.Text);
                        } catch {
                            prod.Quantidade = 1;
                        }
                        p.Produtos.Add(prod);
                        MessageBox.Show("Produto savo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma prateleria!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void listPrateleiras_SelectedIndexChanged(object sender, EventArgs e)
        {
            string setor = listPrateleiras.SelectedItem.ToString();
            foreach (Prateleira p in Prateleira)
            {
                if (p.Setor == setor)
                {
                    DgvListaProduto.DataSource = p.Produtos;
                    break;
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0 && !(listPrateleiras.SelectedIndex == -1)) {
                string setor = listPrateleiras.SelectedItem.ToString();
                foreach (Prateleira p in Prateleira)
                {
                    if (p.Setor == setor)
                    {
                        DgvListaProduto.DataSource = null;
                        DgvListaProduto.DataSource = p.Produtos;
                        break;
                    }
                }
            }
        }
        private void DgvExcluir() {
            if(DgvListaProduto.CurrentCell != null && !(listPrateleiras.SelectedIndex == -1))
            {
                try {
                 int id = Convert.ToInt32(DgvListaProduto[0, DgvListaProduto.CurrentCell.RowIndex].Value);
                    string setor = listPrateleiras.SelectedItem.ToString();
                    foreach (Prateleira p in Prateleira) {
                        if (p.Setor == setor)
                        {
                            foreach (Produto prod in p.Produtos) {
                                if (prod.ID == id) {
                                    p.Produtos.Remove(prod);
                                    DgvListaProduto.DataSource = null;
                                    DgvListaProduto.DataSource = p.Produtos;
                                    MessageBox.Show("Produto excluido com sucesso");
                                    break;
                                }
                            }
                            break;
                        }

                        }
                } catch {
                    return;
                }
            }
           
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DgvExcluir();
        }
    }
}

