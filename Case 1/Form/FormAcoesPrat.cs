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


        public Model1 DB = new Model1();        

        public FormAcoesPrat()
        {
            InitializeComponent();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DB.Prateleiras.ToList();

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            FormAddPrateleira f = new FormAddPrateleira();
            f.Show();

        }
        private void FormAcoesPrat_Activated(object sender, EventArgs e)
        {

            UpdateDGV();
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
                Prateleira a = DB.Prateleiras.Find(int.Parse(txtId.Text));
                a.Setor = txtSetor.Text;
                DB.Entry(a).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
                UpdateDGV();
                MessageBox.Show("Ateração concluida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ateração não pode ser concluida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "" && txtSetor.Text != "")
            {
                Prateleira a = DB.Prateleiras.Find(int.Parse(txtId.Text));
                DB.Entry(a).State = System.Data.Entity.EntityState.Deleted;
                DB.SaveChanges();
                UpdateDGV();
            }
            else
            {
                MessageBox.Show("Exclusão não pode ser concluida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            List<Prateleira> filtro = new List<Prateleira>();
            foreach (Prateleira p in DB.Prateleiras.ToList())
            {
                if (p.Setor.Contains(txtPesquisar.Text))
                {
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
        public void UpdateDGV()
        {
            txtId.Text = "";
            txtSetor.Text = "";
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DB.Prateleiras.ToList();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormAcoesPrat_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }


}
