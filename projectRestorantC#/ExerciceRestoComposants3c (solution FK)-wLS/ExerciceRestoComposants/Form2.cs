using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ExerciceRestoComposants
{
    public partial class Form2 : Form
    {
        internal class ModeControl
        {
            private int mode ;
            internal ModeControl() { this.mode = -1; }

            //private  ModeControl() { this.mode = -1; }
            //static private ModeControl singleton = new ModeControl();
            //static internal ModeControl getINTANCE() { return singleton; }

            internal void setInsertMode() { this.mode = 1; }
            internal void setUpdateMode() { this.mode = 2; }
            internal Boolean IsInsertMode { get => this.mode == 1; }
            internal Boolean IsUpdateMode { get => this.mode == 2; }
        }

        internal readonly ModeControl Mode = new ModeControl();
        //internal readonly ModeControl Mode = ModeControl.getINTANCE();

        internal TextBox TextBox1 { get => textBox1; }
        internal ComboBox ComboBox1 { get => comboBox1; }
        internal ComboBox ComboBox2 { get => comboBox2; }
        internal Button Button1 { get => button1; }

        private int n;

        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out n)&&(n>0))
            {                             
                comboBox1.DisplayMember = "Type_de_Composant";
                comboBox1.ValueMember = "Type_de_Composant";
                comboBox1.DataSource = 
                    BusinessLayer.Commandes.TypeDeComposantDisponiblePourUnClient(n);

                ComboBox1.SelectedIndex = 0;
                if (comboBox1.Items.Count > 1) { comboBox1.Enabled = true; }
                else { comboBox1.Enabled = false; }
            }
            else
            {
                if (textBox1.Text != "")
                {
                    MessageBox.Show("Numéro de commande doit être un nombre entier");
                    textBox1.Text = "";
                }
                comboBox1.SelectedIndex = -1;
                comboBox1.Enabled = false;
                comboBox2.SelectedIndex = -1;
                comboBox2.Enabled = false;
                Button1.Enabled = false;
            }
        }

        internal void fillDropListComboBox2(String typeDeComposant)
        {
           
            comboBox2.DisplayMember = "Composant";
            comboBox2.ValueMember = "Num_du_Composant";
            comboBox2.DataSource = Data.Commandes.ComposantsDunTypeDeComposant(typeDeComposant);
        }


        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0)
            {
                fillDropListComboBox2(comboBox1.SelectedValue.ToString());
                comboBox2.SelectedIndex = 0;
                comboBox2.Enabled = true;               
            }
            else
            {
                comboBox2.DataSource = null;
                comboBox2.Enabled = false;
            }
            button1.Enabled = false;
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex > 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool updated = false;
            if (Mode.IsInsertMode)
            {
                updated = Data.Commandes.insererLignes(textBox1.Text,
                    comboBox1.SelectedValue.ToString(),
                    comboBox2.SelectedValue.ToString());          
            }
            if (Mode.IsUpdateMode)
            {
                updated = Data.Commandes.modifierLignes(textBox1.Text,
                    comboBox1.SelectedItem.ToString(),
                    comboBox2.SelectedValue.ToString());
            }
            
            if (updated)
            {
                Program.MainForm.showCommands();
            }
            else
            {
                MessageBox.Show("Addition / Update rejected");
            } 
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
