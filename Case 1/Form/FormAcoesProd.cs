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
        public Model1 DB = new Model1();
        public FormAcoesProd()
        {

            InitializeComponent();

            listPrateleiras.DataSource = DB.Prateleiras.ToList();
            listPrateleiras.DisplayMember = "Setor";

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            if (!(listPrateleiras.SelectedIndex == -1))
            {
                Produto a = new Produto();
                a.Nome = txtNome.Text;
                try
                {
                    a.Quantidade = Convert.ToInt32(txtQtd.Text);
                }
                catch
                {
                    a.Quantidade = 1;
                }
                Prateleira prat = (Prateleira)listPrateleiras.SelectedItem;
                var x = DB.Prateleiras.Find(prat.ID);
                    x.Produtos.Add(a);
                DB.SaveChanges();

                UpdateDGVListaProdutos(prat.ID);
                MessageBox.Show("Produto savo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Selecione uma prateleria!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void listPrateleiras_SelectedIndexChanged(object sender, EventArgs e)
        {
            Prateleira prat = (Prateleira)listPrateleiras.SelectedItem;
            UpdateDGVListaProdutos(prat.ID);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0 && !(listPrateleiras.SelectedIndex == -1))
            {
                Prateleira prat = (Prateleira)listPrateleiras.SelectedItem;
                UpdateDGVListaProdutos(prat.ID);
            }
            else
            {
                DgvListaProduto.DataSource = null;
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (DgvListaProduto.CurrentCell != null && !(listPrateleiras.SelectedIndex == -1))
            {
                int id = Convert.ToInt32(DgvListaProduto[0, DgvListaProduto.CurrentCell.RowIndex].Value);
                Produto a = DB.Produtos.Find(id);
                DB.Entry(a).State = System.Data.Entity.EntityState.Deleted;
                DB.SaveChanges();
                Prateleira prat = (Prateleira)listPrateleiras.SelectedItem;
                UpdateDGVListaProdutos(prat.ID);
                MessageBox.Show("Produto excluido com sucesso!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Exclusão não pode ser concluida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvListaProduto_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 1:
                    UpdateNomeProduto(int.Parse(DgvListaProduto[0, e.RowIndex].Value.ToString()), DgvListaProduto[e.ColumnIndex, e.RowIndex].Value.ToString());
                    break;
                case 2:
                    UpdateQtdProduto(int.Parse(DgvListaProduto[0, e.RowIndex].Value.ToString()), int.Parse(DgvListaProduto[e.ColumnIndex, e.RowIndex].Value.ToString()));
                    break;
                default:
                    break;


            }
        }
        private void UpdateDGVListaProdutos(int id)
        {
            DgvListaProduto.DataSource = null;
            DgvListaProduto.DataSource = DB.Prateleiras.Find(id).Produtos.ToList();
            DgvListaProduto.Columns[0].ReadOnly = true;
        }

        private void UpdateQtdProduto(int id, int qtd) {
            DB.Produtos.Find(id).Quantidade = qtd;
            DB.SaveChanges();
            Prateleira prat = (Prateleira)listPrateleiras.SelectedItem;
            UpdateDGVListaProdutos(prat.ID);
        }

        private void UpdateNomeProduto(int id, string nome)
        {
            DB.Produtos.Find(id).Nome = nome;
            DB.SaveChanges();
            Prateleira prat = (Prateleira)listPrateleiras.SelectedItem;
            UpdateDGVListaProdutos(prat.ID);
        }

    }
}

