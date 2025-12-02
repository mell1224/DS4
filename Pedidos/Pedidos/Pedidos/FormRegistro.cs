
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Pedidos
{
    public partial class FormRegistro : Form
    {
        public FormRegistro()
        {
            InitializeComponent();
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

        private void lblReg_Click(object sender, EventArgs e)
        {
            FormLogin f1 = new FormLogin();
            f1.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ConfigurarPlaceholder(txtNombre, "Ingresa tu nombre completo", false);
            ConfigurarPlaceholder(txtCorreoReg, "Ingresa tu correo", false);
            ConfigurarPlaceholder(txtPassReg, "Ingresa tu contraseña", true);

            lblDummy.Focus();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string correo = txtCorreoReg.Text.Trim();
            string pass = txtPassReg.Text.Trim();

            // Validaciones
            if (string.IsNullOrWhiteSpace(nombre) || nombre == "Ingresa tu nombre completo" ||
                string.IsNullOrWhiteSpace(correo) || correo == "Ingresa tu correo" ||
                string.IsNullOrWhiteSpace(pass) || pass == "Ingresa tu contraseña")
            {
                MessageBox.Show("Por favor completa todos los campos obligatorios.", "Registro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!correo.Contains("@") || !correo.Contains("."))
            {
                MessageBox.Show("Ingresa un correo válido.", "Registro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pass.Length < 4)
            {
                MessageBox.Show("La contraseña debe tener al menos 4 caracteres.", "Registro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_InsertarUsuario", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NombreCompleto", nombre);
                    cmd.Parameters.AddWithValue("@Correo", correo);
                    // ✅ Aplicamos el mismo hash que en el login
                    cmd.Parameters.AddWithValue("@Contrasena", PasswordHelper.HashPassword(pass));
                    cmd.Parameters.AddWithValue("@Rol", "Cliente"); // Valor por defecto

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            int resultado = Convert.ToInt32(dr["Resultado"]);
                            string mensaje = dr["Mensaje"].ToString();

                            if (resultado == 1)
                            {
                                MessageBox.Show(mensaje, "Registro",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                FormLogin f1 = new FormLogin();
                                f1.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show(mensaje, "Registro",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el usuario:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
