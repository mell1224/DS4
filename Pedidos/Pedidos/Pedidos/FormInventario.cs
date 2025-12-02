using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection.Emit;

namespace Pedidos
{
    public partial class FormInventario : Form
    {
        ToolStripButton btnPedidos;
        ToolStripButton btnInventario;
        ToolStripButton btnRecetas;
        ToolStripButton btnProduccion;
        ToolStripButton btnProductos;

        public FormInventario()
        {
            InitializeComponent();
            ConfigurarMenu();
            this.Load += FormInventario_Load;

            if (!dtgInventario.Columns.Contains("IdIngrediente"))
            {
                var colId = new DataGridViewTextBoxColumn();
                colId.Name = "IdIngrediente";
                colId.HeaderText = "IdIngrediente";
                colId.Visible = false;
                dtgInventario.Columns.Insert(0, colId);
            }

            plNuevoIngre.Visible = false;
            plEditarIngrediente.Visible = false;

            Column4.Text = "Editar";
            Column4.UseColumnTextForButtonValue = true;
            Column5.Text = "Eliminar";
            Column5.UseColumnTextForButtonValue = true;
        }

        private void FormInventario_Load(object sender, EventArgs e)
        {
            CargarInventario();
            btnCancelarIngre.Click += (s, ev) => plNuevoIngre.Visible = false;
            btnEditCancI.Click += (s, ev) => plEditarIngrediente.Visible = false;
        }

        // ======================================================
        // CARGAR INVENTARIO (usa SP_ListarIngredientes)
        // ======================================================
        private void CargarInventario()
        {
            int cantStockBajo = 0;
            int cantProximosVencer = 0;
            DateTime hoy = DateTime.Today;
            int diasAviso = 7;
            DateTime limite = hoy.AddDays(diasAviso);

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_ListarIngredientes", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dtgInventario.Rows.Clear();

                            while (dr.Read())
                            {
                                int fila = dtgInventario.Rows.Add();

                                int idIngrediente = Convert.ToInt32(dr["IdIngrediente"]);
                                string nombre = dr["Nombre"].ToString();

                                decimal cantidad = dr["Cantidad"] != DBNull.Value ? Convert.ToDecimal(dr["Cantidad"]) : 0;
                                string unidad = dr["UnidadMedida"].ToString();
                                decimal stockMinimo = dr["StockMinimo"] != DBNull.Value ? Convert.ToDecimal(dr["StockMinimo"]) : 0;

                                DateTime? fechaVenc = dr["FechaVencimiento"] != DBNull.Value
                                    ? Convert.ToDateTime(dr["FechaVencimiento"])
                                    : (DateTime?)null;

                                DataGridViewRow filaGrid = dtgInventario.Rows[fila];
                                filaGrid.Cells["IdIngrediente"].Value = idIngrediente;
                                filaGrid.Cells["Nombre"].Value = nombre;
                                filaGrid.Cells["Cantidad"].Value = cantidad;
                                filaGrid.Cells["Column1"].Value = unidad;
                                filaGrid.Cells["Column2"].Value = stockMinimo;
                                filaGrid.Cells["Column3"].Value = fechaVenc.HasValue ? fechaVenc.Value.ToString("dd/MM/yyyy") : "";

                                bool esStockBajo = cantidad < stockMinimo;
                                bool esProximoVencer = fechaVenc.HasValue && fechaVenc.Value.Date >= hoy && fechaVenc.Value.Date <= limite;

                                if (esStockBajo)
                                {
                                    filaGrid.DefaultCellStyle.BackColor = plStockB.BackColor;
                                    cantStockBajo++;
                                }
                                else if (esProximoVencer)
                                {
                                    filaGrid.DefaultCellStyle.BackColor = plProximoV.BackColor;
                                    cantProximosVencer++;
                                }
                            }
                        }
                    }
                }

                lblIngrediente.Text = $"{cantStockBajo} {(cantStockBajo == 1 ? "Ingrediente" : "Ingredientes")}";
                label4.Text = $"{cantProximosVencer} {(cantProximosVencer == 1 ? "Ingrediente" : "Ingredientes")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el inventario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================================================
        // INSERTAR NUEVO INGREDIENTE (usa SP_InsertarIngrediente)
        // ======================================================
        private void btnGuardarIngre_Click(object sender, EventArgs e)
        {
            if (!ValidarNuevoIngrediente()) return;

            string nombre = txtNombreIngre.Text.Trim();
            string unidad = txtUniIngre.Text.Trim();
            decimal cantidad = nudCantiIngre.Value;
            decimal stockMinimo = nudStockIngre.Value;
            DateTime fechaVenc = mcalFechaIngre.SelectionStart.Date;

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_InsertarIngrediente", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                        cmd.Parameters.AddWithValue("@UnidadMedida", unidad);
                        cmd.Parameters.AddWithValue("@StockMinimo", stockMinimo);
                        cmd.Parameters.AddWithValue("@FechaVencimiento", fechaVenc);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Ingrediente registrado correctamente.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarInventario();
                plNuevoIngre.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el ingrediente: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================================================
        // ACTUALIZAR INGREDIENTE (usa SP_ActualizarIngrediente)
        // ======================================================
        private void btnEditGuarI_Click(object sender, EventArgs e)
        {
            if (!ValidarEdicionIngrediente()) return;

            if (plEditarIngrediente.Tag == null)
            {
                MessageBox.Show("No se encontró el Id del ingrediente a editar.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idIngrediente = Convert.ToInt32(plEditarIngrediente.Tag);
            string nombre = txtEditNomI.Text.Trim();
            string unidad = txtEditUniI.Text.Trim();
            decimal cantidad = nudEditCantI.Value;
            decimal stockMinimo = nudEditStockI.Value;
            DateTime fechaVenc = mcalEditI.SelectionStart.Date;

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_ActualizarIngrediente", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdIngrediente", idIngrediente);
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                        cmd.Parameters.AddWithValue("@UnidadMedida", unidad);
                        cmd.Parameters.AddWithValue("@StockMinimo", stockMinimo);
                        cmd.Parameters.AddWithValue("@FechaVencimiento", fechaVenc);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Ingrediente actualizado correctamente.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarInventario();
                plEditarIngrediente.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el ingrediente: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================================================
        // ELIMINAR INGREDIENTE (usa SP_EliminarIngrediente)
        // ======================================================
        private void EliminarFila(int rowIndex)
        {
            DataGridViewRow fila = dtgInventario.Rows[rowIndex];

            if (fila.Cells["IdIngrediente"].Value == null)
            {
                MessageBox.Show("No se encontró el Id del ingrediente.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idIngrediente = Convert.ToInt32(fila.Cells["IdIngrediente"].Value);
            string nombre = Convert.ToString(fila.Cells["Nombre"].Value);

            if (MessageBox.Show($"¿Desea eliminar el ingrediente \"{nombre}\"?",
                "Eliminar ingrediente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_EliminarIngrediente", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdIngrediente", idIngrediente);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Ingrediente eliminado correctamente.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el ingrediente: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================================================
        // FUNCIONES DE VALIDACIÓN Y MENÚ
        // ======================================================

        private bool ValidarNuevoIngrediente()
        {
            if (string.IsNullOrWhiteSpace(txtNombreIngre.Text))
            {
                MessageBox.Show("Ingrese el nombre del ingrediente.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreIngre.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtUniIngre.Text))
            {
                MessageBox.Show("Ingrese la unidad de medida.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUniIngre.Focus();
                return false;
            }
            return true;
        }

        private bool ValidarEdicionIngrediente()
        {
            if (string.IsNullOrWhiteSpace(txtEditNomI.Text))
            {
                MessageBox.Show("Ingrese el nombre del ingrediente.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEditNomI.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEditUniI.Text))
            {
                MessageBox.Show("Ingrese la unidad de medida.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEditUniI.Focus();
                return false;
            }
            return true;
        }

        private void MostrarPanelEditar(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dtgInventario.Rows.Count)
                return;

            DataGridViewRow fila = dtgInventario.Rows[rowIndex];

            if (fila.Cells["IdIngrediente"].Value == null)
            {
                MessageBox.Show("No se encontró el Id del ingrediente.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idIngrediente = Convert.ToInt32(fila.Cells["IdIngrediente"].Value);
            string nombre = Convert.ToString(fila.Cells["Nombre"].Value);
            string unidad = Convert.ToString(fila.Cells["Column1"].Value);
            decimal cantidad = fila.Cells["Cantidad"].Value != null ? Convert.ToDecimal(fila.Cells["Cantidad"].Value) : 0;
            decimal stockMinimo = fila.Cells["Column2"].Value != null ? Convert.ToDecimal(fila.Cells["Column2"].Value) : 0;
            DateTime fechaVenc = DateTime.Today;
            if (fila.Cells["Column3"].Value != null && !string.IsNullOrWhiteSpace(fila.Cells["Column3"].Value.ToString()))
            {
                DateTime.TryParse(fila.Cells["Column3"].Value.ToString(), out fechaVenc);
            }

            plEditarIngrediente.Visible = true;
            plEditarIngrediente.Tag = idIngrediente;

            txtEditNomI.Text = nombre;
            txtEditUniI.Text = unidad;
            nudEditCantI.Value = cantidad;
            nudEditStockI.Value = stockMinimo;
            mcalEditI.SetDate(fechaVenc);
            plNuevoIngre.Visible = false;
        }

        private void dtgInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = dtgInventario.Columns[e.ColumnIndex].Name;

            if (col == "Column4") MostrarPanelEditar(e.RowIndex);
            else if (col == "Column5") EliminarFila(e.RowIndex);
        }

        private void btnNuevoIng_Click(object sender, EventArgs e)
        {
            plNuevoIngre.Visible = true;
            plEditarIngrediente.Visible = false;

            txtNombreIngre.Clear();
            txtUniIngre.Clear();
            nudCantiIngre.Value = 0;
            nudStockIngre.Value = 0;
            mcalFechaIngre.SetDate(DateTime.Today);
        }

        // Resto de funciones de menú y navegación sin cambios
        private void ConfigurarMenu()
        {
            btnPedidos = new ToolStripButton("Pedidos");
            btnInventario = new ToolStripButton("Inventario");
            btnRecetas = new ToolStripButton("Recetas");
            btnProduccion = new ToolStripButton("Producción");
            btnProductos = new ToolStripButton("Productos");

            tsP.Items.Clear();
            tsP.Items.AddRange(new ToolStripItem[]
            {
                btnPedidos, btnInventario, btnRecetas, btnProduccion, btnProductos
            });

            foreach (ToolStripItem item in tsP.Items)
            {
                if (item is ToolStripButton btn)
                {
                    btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
                    btn.BackColor = Color.White;
                    btn.ForeColor = SystemColors.ControlText;
                }
            }

            btnPedidos.Click += (s, e) => AbrirFormulario(new FormPedido(), btnPedidos);
            btnInventario.Click += (s, e) => AbrirFormulario(new FormInventario(), btnInventario);
            btnRecetas.Click += (s, e) => AbrirFormulario(new FormReceta(), btnRecetas);
            btnProduccion.Click += (s, e) => AbrirFormulario(new FormProduccion(), btnProduccion);
            btnProductos.Click += (s, e) => AbrirFormulario(new FormProducto(), btnProductos);

            MarcarBotonActivo(btnInventario);
        }

        private void AbrirFormulario(Form destino, ToolStripButton botonActivo)
        {
            MarcarBotonActivo(botonActivo);
            destino.Show();
            this.Hide();
        }

        private void MarcarBotonActivo(ToolStripButton botonActivo)
        {
            foreach (ToolStripItem item in tsP.Items)
            {
                if (item is ToolStripButton btn)
                {
                    btn.BackColor = Color.White;
                    btn.ForeColor = SystemColors.ControlText;
                }
            }

            botonActivo.BackColor = ColorTranslator.FromHtml("#d96704");
            botonActivo.ForeColor = Color.White;
        }
    }
}
