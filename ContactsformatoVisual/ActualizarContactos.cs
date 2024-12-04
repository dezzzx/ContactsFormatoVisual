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
    public partial class ActualizarContactos : Form
    {
        string[] nombres;
        string[] telefonos;
        int indiceActual;
        int seleccionado;
        public ActualizarContactos(string[] nombres, string[] telefonos, ref int indiceActual)
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int Seleccion = listBox1.SelectedIndex;
                label4.Text = nombres[Seleccion];
                label5.Text = telefonos[Seleccion];
                seleccionado = Seleccion;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 9)
            {
                textBox1.Text = textBox1.Text.Substring(0, 9);
                textBox1.SelectionStart = textBox1.Text.Length;
            }
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un contacto para actualizar.");
                return;
            }

            string nuevoTelefono = textBox1.Text;
            if (string.IsNullOrWhiteSpace(nuevoTelefono))
            {
                MessageBox.Show("Por favor, ingrese un número de teléfono válido.");
                return;
            }

            telefonos[seleccionado] = nuevoTelefono;
            MessageBox.Show("Número de teléfono actualizado correctamente.");
            listBox1.Items[seleccionado] = $"{nombres[seleccionado]} - {telefonos[seleccionado]}";
            nombres[seleccionado] = label4.Text;
            telefonos[seleccionado]=label5.Text ;
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio();
            Inicio.ActualizarContactos(nombres, telefonos, indiceActual);
            inicio.Show();
            this.Hide();
        }
    }
}
