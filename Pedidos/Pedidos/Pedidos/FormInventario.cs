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


            Column4.Text = "Editar";
            Column4.UseColumnTextForButtonValue = true;
            Column5.Text = "Eliminar";
            Column5.UseColumnTextForButtonValue = true;
        }

        private void FormInventario_Load(object sender, EventArgs e)
        {
            CargarInventario();
        }

        // ======================================================
        // CARGAR INVENTARIO (usa SP_ListarIngredientes)
        // ======================================================


        private void CargarInventario()
        {
            int cantMenorCinco = 0;
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
                                decimal costoUnitario = dr["CostoUnitario"] != DBNull.Value ? Convert.ToDecimal(dr["CostoUnitario"]) : 0;
                                DateTime? fechaVenc = dr["FechaVencimiento"] != DBNull.Value
                                    ? Convert.ToDateTime(dr["FechaVencimiento"])
                                    : (DateTime?)null;

                                DataGridViewRow filaGrid = dtgInventario.Rows[fila];
                                filaGrid.Cells["IdIngrediente"].Value = idIngrediente;
                                filaGrid.Cells["Nombre"].Value = nombre;
                                filaGrid.Cells["Cantidad"].Value = cantidad;
                                filaGrid.Cells["Column1"].Value = unidad;
                                filaGrid.Cells["costU"].Value = costoUnitario;
                                filaGrid.Cells["Column3"].Value = fechaVenc.HasValue ? fechaVenc.Value.ToString("dd/MM/yyyy") : "";

                                // Contar ingredientes con cantidad < 5
                                if (cantidad < 5)
                                {
                                    cantMenorCinco++;
                                }

                                bool esProximoVencer = fechaVenc.HasValue && fechaVenc.Value.Date >= hoy && fechaVenc.Value.Date <= limite;
                                if (esProximoVencer)
                                {
                                    filaGrid.DefaultCellStyle.BackColor = plProximoV.BackColor;
                                    cantProximosVencer++;
                                }
                            }
                        }
                    }
                }

                lblIngrediente.Text = $"{cantMenorCinco} {(cantMenorCinco == 1 ? "Ingrediente" : "Ingredientes")} con cantidad < 5";
                label4.Text = $"{cantProximosVencer} {(cantProximosVencer == 1 ? "Ingrediente" : "Ingredientes")} próximos a vencer";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el inventario: " + ex.Message,
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





        private bool ValidarNuevoIngrediente(DataGridViewRow fila)
        {
            if (fila.IsNewRow) return false;

            string nombre = fila.Cells["Nombre"].Value?.ToString().Trim() ?? "";
            string unidad = fila.Cells["Column1"].Value?.ToString().Trim() ?? "";
            string costoStr = fila.Cells["costU"].Value?.ToString().Trim() ?? "";

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Ingrese el nombre del ingrediente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(unidad))
            {
                MessageBox.Show("Ingrese la unidad de medida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!decimal.TryParse(costoStr, out decimal costo) || costo <= 0)
            {
                MessageBox.Show("Ingrese un costo unitario válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (fila.Cells["Column3"].Value == null ||
                !DateTime.TryParseExact(fila.Cells["Column3"].Value.ToString(),
                                         "dd/MM/yyyy",
                                         System.Globalization.CultureInfo.InvariantCulture,
                                         System.Globalization.DateTimeStyles.None,
                                         out _))
            {
                MessageBox.Show("Ingrese una fecha de vencimiento válida (dd/MM/yyyy).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ValidarEdicionIngrediente(DataGridViewRow fila)
        {
            if (fila.IsNewRow) return false;

            if (fila.Cells["IdIngrediente"].Value == null || string.IsNullOrWhiteSpace(fila.Cells["IdIngrediente"].Value.ToString()))
            {
                MessageBox.Show("No se encontró el ID del ingrediente para editar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return ValidarNuevoIngrediente(fila);
        }

        private void dtgInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string col = dtgInventario.Columns[e.ColumnIndex].Name;

            if (col == "Column4") // Editar
            {
                // Habilitar edición solo en la fila seleccionada
                foreach (DataGridViewColumn c in dtgInventario.Columns)
                {
                    c.ReadOnly = true; // Bloquear todo
                }

                dtgInventario.Rows[e.RowIndex].ReadOnly = false; // Desbloquear la fila completa
                dtgInventario.Columns["IdIngrediente"].ReadOnly = true; // Mantener ID bloqueado
                dtgInventario.Columns["Column4"].ReadOnly = true; // Botón Editar
                dtgInventario.Columns["Column5"].ReadOnly = true; // Botón Eliminar

                MessageBox.Show("Edición habilitada para este ingrediente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (col == "Column5") // Eliminar
            {
                var fila = dtgInventario.Rows[e.RowIndex];
                if (fila.Cells["IdIngrediente"].Value == null)
                {
                    MessageBox.Show("No se puede eliminar un ingrediente sin ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idIngrediente = Convert.ToInt32(fila.Cells["IdIngrediente"].Value);
                if (MessageBox.Show($"¿Desea eliminar el ingrediente \"{fila.Cells["Nombre"].Value}\"?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
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
                    MessageBox.Show("Ingrediente eliminado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarInventario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el ingrediente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            dtgInventario.ReadOnly = true;

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                {
                    cn.Open();

                    foreach (DataGridViewRow fila in dtgInventario.Rows)
                    {
                        if (fila.IsNewRow) continue;

                        int? idIngrediente = fila.Cells["IdIngrediente"].Value != null && fila.Cells["IdIngrediente"].Value.ToString() != ""
                            ? Convert.ToInt32(fila.Cells["IdIngrediente"].Value)
                            : (int?)null;

                        // Validación según si es nuevo o edición
                        if (!idIngrediente.HasValue)
                        {
                            if (!ValidarNuevoIngrediente(fila)) return;
                        }
                        else
                        {
                            if (!ValidarEdicionIngrediente(fila)) return;
                        }

                        string nombre = fila.Cells["Nombre"].Value?.ToString() ?? "";
                        string unidad = fila.Cells["Column1"].Value?.ToString() ?? "";
                        decimal cantidad = fila.Cells["Cantidad"].Value != null ? Convert.ToDecimal(fila.Cells["Cantidad"].Value) : 0;
                        decimal costoUnitario = fila.Cells["costU"].Value != null ? Convert.ToDecimal(fila.Cells["costU"].Value) : 0;

                        // ✅ Validar y convertir fecha con formato dd/MM/yyyy
                        DateTime fechaVenc;
                        if (!DateTime.TryParseExact(fila.Cells["Column3"].Value?.ToString(),
                                                     "dd/MM/yyyy",
                                                     System.Globalization.CultureInfo.InvariantCulture,
                                                     System.Globalization.DateTimeStyles.None,
                                                     out fechaVenc))
                        {
                            MessageBox.Show($"La fecha '{fila.Cells["Column3"].Value}' no tiene el formato correcto (dd/MM/yyyy).",
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        SqlCommand cmd;
                        if (idIngrediente.HasValue)
                        {
                            cmd = new SqlCommand("SP_ActualizarIngrediente", cn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@IdIngrediente", idIngrediente.Value);
                        }
                        else
                        {
                            cmd = new SqlCommand("SP_InsertarIngrediente", cn);
                            cmd.CommandType = CommandType.StoredProcedure;
                        }

                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                        cmd.Parameters.AddWithValue("@UnidadMedida", unidad);
                        cmd.Parameters.AddWithValue("@CostoUnitario", costoUnitario);
                        cmd.Parameters.AddWithValue("@FechaVencimiento", fechaVenc);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cambios guardados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los cambios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnNuevoIng_Click(object sender, EventArgs e)
        {
            // Permitir agregar nuevas filas, pero bloquear edición en filas existentes
            dtgInventario.ReadOnly = false;

            foreach (DataGridViewColumn col in dtgInventario.Columns)
            {
                col.ReadOnly = true; // Bloquear todas
            }

            // Desbloquear columnas editables para nuevas filas
            dtgInventario.AllowUserToAddRows = true;
            dtgInventario.Columns["Nombre"].ReadOnly = false;
            dtgInventario.Columns["Column1"].ReadOnly = false;
            dtgInventario.Columns["Cantidad"].ReadOnly = false;
            dtgInventario.Columns["Column3"].ReadOnly = false; 
            dtgInventario.Columns["costU"].ReadOnly = false;

            MessageBox.Show("Puede agregar un nuevo ingrediente en la última fila.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
