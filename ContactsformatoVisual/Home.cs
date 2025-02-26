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
    public partial class Home : Form
    {
        // Donde se guardaran los datos
        static string[] nombres = new string[100];
        static string[] telefonos = new string[100];
        static int indiceActual = 0;
        public Home()
        {
            InitializeComponent();
        }
        public static void ActualizarContactos(string[] nuevosNombres, string[] nuevosTelefonos, int nuevoIndice)
        {
            Array.Copy(nuevosNombres, nombres, nuevoIndice);
            Array.Copy(nuevosTelefonos, telefonos, nuevoIndice);
            indiceActual = nuevoIndice;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AgregarContacto agregarContacto = new AgregarContacto(nombres, telefonos, ref indiceActual);
            this.Hide();
            agregarContacto.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListarContactos listarContactos = new ListarContactos(nombres, telefonos, ref indiceActual);
            this.Hide();
            listarContactos.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ActualizarContactos actualizarContactos = new ActualizarContactos(nombres, telefonos, ref indiceActual);
            this.Hide();
            actualizarContactos.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BorrarContacto borrarContacto = new BorrarContacto(nombres, telefonos, ref indiceActual);
            this.Hide();
            borrarContacto.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
