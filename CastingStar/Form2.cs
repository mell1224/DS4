using System;
using System.Windows.Forms;

namespace CastingStar
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            int id = dtgRegistrados.Rows.Count + 1;
            dtgRegistrados.Rows.Add(id, txtNombre.Text, txtEdad.Text, cmbGenero.Text, txtCiudad.Text, txtExperiencia.Text);

            txtCiudad.Text = "";
            txtExperiencia.Text = "";
            txtNombre.Text = "";
            txtEdad.Text = "";
            cmbGenero.Text = "Seleccione género";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgRegistrados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una fila para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow filaSeleccionada = dtgRegistrados.SelectedRows[0];
            string genero = filaSeleccionada.Cells["Genero"].Value.ToString();

            DialogResult confirmar;

            if (genero == "Masculino")
            {
                confirmar = MessageBox.Show(
                    "¿Está seguro de eliminar al actor seleccionado?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
            }
            else
            {
                confirmar = MessageBox.Show(
                    "¿Está seguro de eliminar a la actriz seleccionada?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
            }

            if (confirmar == DialogResult.Yes)
            {
                for (int i = dtgRegistrados.SelectedRows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow fila = dtgRegistrados.SelectedRows[i];
                    if (!fila.IsNewRow)
                    {
                        dtgRegistrados.Rows.Remove(fila);
                    }
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtgRegistrados.Rows.Count == 0)
            {
                MessageBox.Show("No hay filas para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dtgRegistrados.ReadOnly = false;
            dtgRegistrados.AllowUserToAddRows = false;

            MessageBox.Show("Puede editar directamente los datos en la tabla.\nHaga clic en 'Guardar' cuando termine.",
                "Modo edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtgRegistrados.EndEdit();
            dtgRegistrados.ReadOnly = true;
            dtgRegistrados.AllowUserToAddRows = false;

            MessageBox.Show("Cambios guardados correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
