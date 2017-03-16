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

namespace Case_1
{
    public partial class FormAcoesPrat : System.Windows.Forms.Form
    {


        public List<Prateleira>Prateleiras;


        public FormAcoesPrat(List<Prateleira> Prateleiras)
        {
            InitializeComponent();
            this.Prateleiras = Prateleiras;
            dataGridView1.DataSource = Prateleiras;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Prateleiras;

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            FormAddPrateleira f = new FormAddPrateleira(Prateleiras);
            f.Show();

        }
        private void FormAcoesPrat_Activated(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Prateleiras;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = (dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).ToString();
            txtSetor.Text = (dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString());
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "" && txtSetor.Text != "")
            {
                foreach (Prateleira p in Prateleiras)
                {
                    if (int.Parse(txtId.Text) == p.ID)
                    {
                        p.Setor = txtSetor.Text;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = Prateleiras;
                        txtId.Text = "";
                        txtSetor.Text = "";
                        MessageBox.Show("Ateração concluida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
            }
            else {
                MessageBox.Show("Ateração não pode ser concluida!","Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "" && txtSetor.Text != "")
            {
                foreach (Prateleira p in Prateleiras)
                {
                    if (int.Parse(txtId.Text) == p.ID)
                    {
                        Prateleiras.Remove(p);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = Prateleiras;
                        txtId.Text = "";
                        txtSetor.Text = "";
                        MessageBox.Show("Exclusão concluida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
            }
            else {
                MessageBox.Show("Exclusão não pode ser concluida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            List<Prateleira> filtro = new List<Prateleira>(); 
            string t = txtPesquisar.Text;
            foreach (Prateleira p in Prateleiras) {
                if (p.Setor.Contains(t)) {
                    filtro.Add(p);
                }
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = filtro;


        }

        public static bool Contains(String str, String substring,
                              StringComparison comp)
        {
            if (substring == null)
                throw new ArgumentNullException("substring",
                                                "substring cannot be null.");
            else if (!Enum.IsDefined(typeof(StringComparison), comp))
                throw new ArgumentException("comp is not a member of StringComparison",
                                            "comp");

            return str.IndexOf(substring, comp) >= 0;
        }
    }



}
