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
    public partial class Log : Form
    {
        private const string Usuario = "Dezzx";
        private const string Contraseña = "12345";
        private bool mostrarContraseña = false;
        public Log()
        {
            InitializeComponent();
        }
 
    
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string usuarioIngresado = textBox1.Text;
            string contraseñaIngresada = maskedTextBox1.Text;

            if (usuarioIngresado == Usuario && contraseñaIngresada == Contraseña)
            {
                Home inicio = new Home();
                inicio.Show();
                this.Hide();
            }
            else
            {
                label3.Text = "Usuario o contraseña incorrectos. \nUsuario: Dezzx \nContraseña: 12345";
                label3.Visible = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            mostrarContraseña = !mostrarContraseña;

            if (mostrarContraseña)
            {
                maskedTextBox1.PasswordChar = '\0';
                button2.Text = "Ocultar";
            }
            else
            {
                maskedTextBox1.PasswordChar = '*';
                button2.Text = "Mostrar";
            }
        }

        private void Log_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
            maskedTextBox1.PasswordChar = '*';
        }
    
    }
}
