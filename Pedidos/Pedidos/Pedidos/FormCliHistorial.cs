
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pedidos
{
    public partial class FormCliHistorial : Form
    {
        private int idUsuarioActual;

        public FormCliHistorial(int idUsuario)
        {
            InitializeComponent();
            idUsuarioActual = idUsuario;
        }

        private void FormCliHistorial_Load(object sender, EventArgs e)
        {
            CargarHistorial(); // ✅ Se ejecuta al abrir el formulario
        }


        private void CargarHistorial()
        {
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_ListarPedidos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuarioActual);
                    cmd.Parameters.AddWithValue("@EstadoFiltro", "Todos");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dtgHistorial.Columns.Clear();
                    dtgHistorial.DataSource = dt;

                    // Ajustar encabezados
                    dtgHistorial.Columns["IdPedido"].HeaderText = "ID Pedido";
                    dtgHistorial.Columns["FechaPedido"].HeaderText = "Fecha";
                    dtgHistorial.Columns["Total"].HeaderText = "Total";
                    dtgHistorial.Columns["Estado"].HeaderText = "Estado";

                    // Agregar columna de botón
                    DataGridViewButtonColumn btnAccion = new DataGridViewButtonColumn
                    {
                        HeaderText = "Acción",
                        Text = "Ver Estado",
                        UseColumnTextForButtonValue = true,
                        Name = "Acción"
                    };
                    dtgHistorial.Columns.Add(btnAccion);

                    // ✅ Ajustar todas las columnas al ancho del DataGridView
                    dtgHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dtgHistorial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dtgHistorial.Columns["Acción"].Index)
            {
                string estado = dtgHistorial.Rows[e.RowIndex].Cells["Estado"].Value.ToString();
                MessageBox.Show("Estado del pedido: " + estado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAtrasH_Click(object sender, EventArgs e)
        {
            FormCliente formCliente = new FormCliente(idUsuarioActual);
            formCliente.Show();
            this.Hide();
        }

        private void FormCliHistorial_Load_1(object sender, EventArgs e)
        {
            CargarHistorial();
        }
    }
}
