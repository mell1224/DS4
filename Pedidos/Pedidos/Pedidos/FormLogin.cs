
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Pedidos
{
    public partial class FormLogin : Form
    {
        public FormLogin() { InitializeComponent(); }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigurarPlaceholder(txtCorreo, "Ingresa tu correo", false);
            ConfigurarPlaceholder(txtPass, "Ingresa tu contraseña", true);
        }

        private void ConfigurarPlaceholder(TextBox txt, string placeholder, bool esPassword)
        {
            txt.Text = placeholder;
            txt.ForeColor = Color.Gray;
            txt.UseSystemPasswordChar = false;
            txt.Enter += (s, ev) =>
            {
                if (txt.Text == placeholder)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                    if (esPassword) txt.UseSystemPasswordChar = true;
                }
            };
            txt.Leave += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                    if (esPassword) txt.UseSystemPasswordChar = false;
                }
            };
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            string pass = txtPass.Text.Trim();

            if (string.IsNullOrWhiteSpace(correo) || correo == "Ingresa tu correo" ||
                string.IsNullOrWhiteSpace(pass) || pass == "Ingresa tu contraseña")
            {
                MessageBox.Show("Por favor ingresa tu correo y contraseña.", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var usuario = GestorDeUsuarios.IniciarSesion(correo, pass);

                if (usuario == null)
                {
                    MessageBox.Show("Correo o contraseña incorrectos.", "Login",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var (idUsuario, rol) = usuario.Value; // ✅ Desestructuramos el tuple
                    MessageBox.Show($"Bienvenido {correo}", "Login",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
                        new FormPedido().Show();
                    else
                        new FormCliente(idUsuario).Show(); // ✅ Pasamos el ID del usuario

                    this.Hide();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblLog_Click(object sender, EventArgs e)
        {
            FormRegistro f2 = new FormRegistro();
            f2.Show();
            this.Hide();
        }

        private void lblLog_Click_1(object sender, EventArgs e)
        {
            FormRegistro f2 = new FormRegistro();
            f2.Show();
            this.Hide();
        }

        private void btnInfoC_Click(object sender, EventArgs e)
        {
            FormInfoCurso fc = new FormInfoCurso();
            this.Hide();
            fc.Show();
        }

        private void btnInfoP_Click(object sender, EventArgs e)
        {
            FormInfoProy fp = new FormInfoProy();
            this.Hide();
            fp.Show();
        }
    }

    public static class GestorDeUsuarios
    {
        public static (int IdUsuario, string Rol)? IniciarSesion(string email, string password)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_ValidarLogin", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Correo", email);
                    cmd.Parameters.AddWithValue("@Contrasena", PasswordHelper.HashPassword(password));

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return (Convert.ToInt32(dr["IdUsuario"]), dr["Rol"].ToString());
                        }
                        else
                            return null;
                    }
                }
            }
        }
    }

    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            // ✅ Simulación simple para proyecto universitario
            return $"hashed_{password}";
        }
    }
}
