using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsformatoVisual
{
   
    public partial class AgregarContacto : Form
    {
        string[] nombres;
        string[] telefonos;
        int indiceActual;
        public AgregarContacto(string[] nombres, string[] telefonos, ref int indiceActual)
        {
            InitializeComponent();
            this.nombres = nombres;
            this.telefonos = telefonos;
            this.indiceActual = indiceActual;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 9)
            {
                textBox2.Text = textBox2.Text.Substring(0, 9); 
                textBox2.SelectionStart = textBox2.Text.Length; 
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            string nombre = textBox1.Text;
            string telefono = textBox2.Text;
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(telefono))
            {
                MessageBox.Show("Por favor, ingrese tanto el nombre como el teléfono.");
                return;
            }
            if (indiceActual < 100) 
            {
                nombres[indiceActual] = nombre; 
                telefonos[indiceActual] = telefono;
                indiceActual++;

                MessageBox.Show("Contacto agregado exitosamente.");
                Home inicio = new Home();
                Home.ActualizarContactos(nombres, telefonos, indiceActual);
                inicio.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("No se pueden agregar más contactos, límite alcanzado.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home inicio1 = new Home();
            inicio1.Show();
            this.Hide();
        }
    }
}
