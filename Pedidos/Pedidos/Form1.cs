using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pedidos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigurarPlaceholder(txtCorreo, "Ingresa tu correo", false);
            ConfigurarPlaceholder(txtPass, "Ingresa tu contraseña", true);
        }

        private void ConfigurarPlaceholder(TextBox txt, string placeholder, bool esPassword)
        {
            txt.Text = placeholder;
            txt.ForeColor = Color.Gray;
            txt.UseSystemPasswordChar = false; // Mostrar texto normal al inicio

            txt.Enter += (s, ev) =>
            {
                if (txt.Text == placeholder)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                    if (esPassword) txt.UseSystemPasswordChar = true; // Activar puntitos
                }
            };

            txt.Leave += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                    if (esPassword) txt.UseSystemPasswordChar = false; // Desactivar puntitos
                }
            };
        }

        private void lblLog_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
    }
}
