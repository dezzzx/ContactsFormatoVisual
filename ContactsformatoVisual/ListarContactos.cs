using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ContactsformatoVisual
{
    public partial class ListarContactos : Form
    {
        string[] nombres;
        string[] telefonos;
        int indiceActual;
        public ListarContactos(string[] nombres, string[] telefonos, ref int indiceActual)
        {
            InitializeComponent();
            this.nombres = nombres;
            this.telefonos = telefonos;
            this.indiceActual = indiceActual;
            this.Load += new EventHandler(ListarContactos_Load);
        }
        private void ListarContactos_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < indiceActual; i++)
            {
                string contacto = $"{nombres[i]} - {telefonos[i]}";
                listBox1.Items.Add(contacto);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                textBox1.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
                if (textBox1.Text.Length > 9)
                {
                    textBox1.Text = textBox1.Text.Substring(0, 9);
                    textBox1.SelectionStart = textBox1.Text.Length;
                }
                checkBox2.Checked = false;
            }
            else
            {
                textBox1.KeyPress -= new KeyPressEventHandler(textBox1_KeyPress);
            }
            
     
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text.Length >= 9 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                    textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string busqueda = textBox1.Text.ToLower();
            listBox1.Items.Clear();
            for (int i = 0; i < indiceActual; i++)
            {
                if (nombres[i].ToLower().Contains(busqueda) || telefonos[i].Contains(busqueda))
                {
                    string contacto = $"{nombres[i]} - {telefonos[i]}";
                    listBox1.Items.Add(contacto);
                }
            }
            if (listBox1.Items.Count == 0)
            {
                listBox1.Items.Add("No se encontraron resultados.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio();
            inicio.Show();
            this.Hide();
        }
    }
}
