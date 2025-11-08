using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CastingStar
{
    public partial class Form2 : Form
    {
        string connectionString = "Server=ADMN-PC\\SQLEXPRESS;Database=CastingStarDB;User Id=castingstar;Password=skizpkzi;";


        public Form2()
        {
            InitializeComponent();
            CargarActores();
        }

        private void CargarActores()
        {
            dtgRegistrados.Rows.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("BuscarActor", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdActor", DBNull.Value);
                cmd.Parameters.AddWithValue("@Nombre", DBNull.Value);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dtgRegistrados.Rows.Add(
                        reader["IdActor"],
                        reader["Nombre"],
                        reader["Edad"],
                        reader["Género"],
                        reader["Ciudad"],
                        reader["Experiencia"]
                    );
                }

                conn.Close();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertarActor", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Edad", int.Parse(txtEdad.Text));
                cmd.Parameters.AddWithValue("@Genero", cmbGenero.Text);
                cmd.Parameters.AddWithValue("@Ciudad", txtCiudad.Text);
                cmd.Parameters.AddWithValue("@Experiencia", txtExperiencia.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            txtNombre.Text = "";
            txtEdad.Text = "";
            cmbGenero.Text = "Seleccione género";
            txtCiudad.Text = "";
            txtExperiencia.Text = "";

            CargarActores();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgRegistrados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una fila para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow filaSeleccionada = dtgRegistrados.SelectedRows[0];
            int idActor = Convert.ToInt32(filaSeleccionada.Cells["IdActor"].Value);
            string genero = filaSeleccionada.Cells["Genero"].Value.ToString();

            DialogResult confirmar = MessageBox.Show(
                $"¿Está seguro de eliminar al {(genero == "Masculino" ? "actor" : "actriz")} seleccionado?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmar == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("EliminarActor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdActor", idActor);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                CargarActores();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtgRegistrados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una fila para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dtgRegistrados.ReadOnly = false;
            dtgRegistrados.AllowUserToAddRows = false;

            MessageBox.Show("Puede editar directamente los datos en la tabla.\nHaga clic en 'Guardar' cuando termine.",
                "Modo edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in dtgRegistrados.Rows)
            {
                if (fila.IsNewRow) continue;

                int idActor = Convert.ToInt32(fila.Cells["IdActor"].Value);
                string nombre = fila.Cells["Nombre"].Value.ToString();
                int edad = Convert.ToInt32(fila.Cells["Edad"].Value);
                string genero = fila.Cells["Genero"].Value.ToString();
                string ciudad = fila.Cells["Ciudad"].Value.ToString();
                string experiencia = fila.Cells["Experiencia"].Value.ToString();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("ModificarActor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdActor", idActor);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Edad", edad);
                    cmd.Parameters.AddWithValue("@Genero", genero);
                    cmd.Parameters.AddWithValue("@Ciudad", ciudad);
                    cmd.Parameters.AddWithValue("@Experiencia", experiencia);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            dtgRegistrados.ReadOnly = true;
            dtgRegistrados.AllowUserToAddRows = false;

            MessageBox.Show("Cambios guardados correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarActores();
        }

        private void btnConexion_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    MessageBox.Show("✅ Conexión a la base de datos establecida correctamente.", "Estado de conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al conectar con la base de datos: \n{ex.Message}", "Estado de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}