using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExerciceRestoComposants
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Dock = DockStyle.Fill;
        }

        private void componentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dataGridView1.MultiSelect = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bindingSource1.DataSource = Data.Composants.GetComposants();
            bindingSource1.Sort = "Type_de_Composant, Num_du_Composant";
            dataGridView1.DataSource = bindingSource1;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            Data.Composants.UpdateComposants();
        }

        internal void showCommands()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var c = Data.Commandes.GetCommandes().AsEnumerable()
                                          .Select(r => new {
                                              Commande = r.Field<int>("Commande"),
                                              Composant = r.Field<string>("Composant"),
                                              TypeDeComposant = r.Field<string>("TypeDeComposant")
                                          }).ToList();
            dataGridView1.DataSource = c;
        }

        private void showTheCommandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showCommands();
        }

        private void deleteALineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("No line is selected");
            }
            else
            {
                if (DialogResult.OK == MessageBox.Show(
                    dataGridView1.SelectedRows.Count + " line(s) will be deleted",
                    "Supprimer",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                    ))
                {
                    List<String[]> list = new List<String[]>();
                    foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                    {
                        list.Add(new string[2]
                            {
                            r.Cells["Commande"].Value.ToString(),
                            r.Cells["TypeDeComposant"].Value.ToString()
                            });
                    }


                    if (Data.Commandes.SupprimerLignes(list))
                    {
                        showCommands();
                    }
                    else
                    {
                        MessageBox.Show("Impossible to delete");
                    }
                }
            }

        }

        private void addALineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showCommands();

            Program.UpdateForm.Text = "Add a line to a command";
            Program.UpdateForm.Mode.setInsertMode();
            Program.UpdateForm.MaximizeBox = false;
            Program.UpdateForm.FormBorderStyle = FormBorderStyle.FixedSingle;

            Program.UpdateForm.TextBox1.Clear();
            Program.UpdateForm.TextBox1.Enabled = true;

            Program.UpdateForm.ComboBox1.DataSource = null;
            Program.UpdateForm.ComboBox1.Items.Clear();
            Program.UpdateForm.ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            Program.UpdateForm.ComboBox1.Enabled = false;

            Program.UpdateForm.ComboBox2.DataSource = null;
            Program.UpdateForm.ComboBox2.Items.Clear();
            Program.UpdateForm.ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            Program.UpdateForm.ComboBox2.Enabled = false;

            Program.UpdateForm.Button1.Enabled = false;

            Program.UpdateForm.ShowDialog();
        }

        private void updateALineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("One (and only one) line must be selected for update");
            }
            else
            {
                String numeroCommande = dataGridView1.SelectedRows[0].Cells["Commande"].Value.ToString();
                String typeDeComposant = dataGridView1.SelectedRows[0].Cells["TypeDeComposant"].Value.ToString();
                String composant = dataGridView1.SelectedRows[0].Cells["Composant"].Value.ToString();

                Program.UpdateForm.Text = "MOdifier une ligne de commande";
                Program.UpdateForm.Mode.setUpdateMode();
                Program.UpdateForm.MaximizeBox = false;
                Program.UpdateForm.FormBorderStyle = FormBorderStyle.FixedSingle;

                Program.UpdateForm.TextBox1.Text = numeroCommande;
                Program.UpdateForm.TextBox1.Enabled = false;

                Program.UpdateForm.ComboBox1.DataSource = null;
                Program.UpdateForm.ComboBox1.Items.Clear();
                Program.UpdateForm.ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                Program.UpdateForm.ComboBox1.Items.Add(typeDeComposant);
                Program.UpdateForm.ComboBox1.SelectedIndex = 0;
                Program.UpdateForm.ComboBox1.Enabled = false;

                Program.UpdateForm.ComboBox2.DataSource = null;
                Program.UpdateForm.ComboBox2.Items.Clear();
                Program.UpdateForm.ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                Program.UpdateForm.fillDropListComboBox2(typeDeComposant);
                Program.UpdateForm.ComboBox2.SelectedIndex = Program.UpdateForm.ComboBox2.FindStringExact(composant);
                Program.UpdateForm.ComboBox2.Enabled = true;

                Program.UpdateForm.Button1.Enabled = false;

                Program.UpdateForm.ShowDialog();
            }

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Addition / Update rejected");
        }

        private void tdcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dataGridView1.MultiSelect = true;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bindingSource2.DataSource = Data.Tdc.GetTdc();
            bindingSource2.Sort = "Type_de_Composant";
            dataGridView1.DataSource = bindingSource2;
        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {
            Data.Tdc.UpdateTdc();
        }
    }
}
