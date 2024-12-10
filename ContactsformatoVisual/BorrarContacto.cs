using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsformatoVisual
{
    public partial class BorrarContacto : Form
    {
        string[] nombres;
        string[] telefonos;
        int indiceActual;

        public BorrarContacto(string[] nombres, string[] telefonos, ref int indiceActual)
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
                int seleccion = listBox1.SelectedIndex;
                label3.Text = nombres[seleccion];
                label4.Text = telefonos[seleccion];
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un contacto para borrar.");
                return;
            }
            int seleccion = listBox1.SelectedIndex;
            for (int i = seleccion; i < indiceActual - 1; i++)
            {
                nombres[i] = nombres[i + 1];
                telefonos[i] = telefonos[i + 1];
            }
            nombres[indiceActual - 1] = null;
            telefonos[indiceActual - 1] = null;
            indiceActual--;
            listBox1.Items.Clear();
            for (int i = 0; i < indiceActual; i++)
            {
                string contacto = $"{nombres[i]} - {telefonos[i]}";
                listBox1.Items.Add(contacto);
            }
            if (listBox1.SelectedIndex == -1)
            {
                label3.Text = "";
                label4.Text = "";
            }

            MessageBox.Show("Contacto eliminado exitosamente.");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Home inicio = new Home();
            Home.ActualizarContactos(nombres, telefonos, indiceActual);
            inicio.Show();
            this.Hide();
        }
    }
}
