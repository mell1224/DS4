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
using System.Globalization;

namespace Pedidos
{
    public partial class FormReceta : Form
    {
        ToolStripButton btnPedidos;
        ToolStripButton btnInventario;
        ToolStripButton btnRecetas;
        ToolStripButton btnProduccion;
        ToolStripButton btnProductos;

        private DataTable dtIngredientes;
        private int? idRecetaActual = null;

        public FormReceta()
        {
            InitializeComponent();
            ConfigurarMenu();
        }

        // Agrega estos métodos dentro de la clase FormReceta:

        private void AbrirFormulario(Form formulario, ToolStripButton botonActivo)
        {
            // Cierra el formulario actual y abre el nuevo
            this.Hide();
            formulario.Show();
            MarcarBotonActivo(botonActivo);
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
            botonActivo.BackColor = Color.LightBlue;
            botonActivo.ForeColor = Color.Black;
        }
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

            MarcarBotonActivo(btnRecetas);
        }

        private void FormReceta_Load(object sender, EventArgs e)
        {
            plIngredienteReceta.Visible = false;

            ConfigurarGrillaReceta();

            CargarProductos();
            CargarIngredientes();

            cmbSeleccionProd.SelectedIndexChanged += cmbSeleccionProd_SelectedIndexChanged;
            btnAñadirReceta.Click += btnAñadirReceta_Click;
            btnGuardarReceta.Click += btnGuardarReceta_Click;
            dtgInfoReceta.CellContentClick += dtgInfoReceta_CellContentClick;
        }

        private void ConfigurarGrillaReceta()
        {
            dtgInfoReceta.AutoGenerateColumns = false;
            dtgInfoReceta.AllowUserToAddRows = false;

            if (!dtgInfoReceta.Columns.Contains("IdDetalleReceta"))
            {
                var colDet = new DataGridViewTextBoxColumn();
                colDet.Name = "IdDetalleReceta";
                colDet.HeaderText = "IdDetalleReceta";
                colDet.Visible = false;
                dtgInfoReceta.Columns.Insert(0, colDet);
            }

            if (!dtgInfoReceta.Columns.Contains("IdIngrediente"))
            {
                var colIng = new DataGridViewTextBoxColumn();
                colIng.Name = "IdIngrediente";
                colIng.HeaderText = "IdIngrediente";
                colIng.Visible = false;
                dtgInfoReceta.Columns.Insert(1, colIng);
            }

            if (!dtgInfoReceta.Columns.Contains("Column4"))
            {
                var colEliminar = new DataGridViewButtonColumn();
                colEliminar.Name = "Column4";
                colEliminar.HeaderText = "Eliminar";
                colEliminar.Text = "Eliminar";
                colEliminar.UseColumnTextForButtonValue = true;
                colEliminar.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgInfoReceta.Columns.Add(colEliminar);
            }
        }

        private void CargarProductos()
        {
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_ListarProductos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cmbSeleccionProd.DataSource = dt;
                        cmbSeleccionProd.DisplayMember = "Nombre";
                        cmbSeleccionProd.ValueMember = "IdProducto";
                        cmbSeleccionProd.SelectedIndex = -1;
                        cmbSeleccionProd.Text = "--Seleccionar--";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarIngredientes()
        {
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_ListarIngredientes", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        dtIngredientes = new DataTable();
                        da.Fill(dtIngredientes);

                        cmbIngrediente.DataSource = dtIngredientes;
                        cmbIngrediente.DisplayMember = "Nombre";
                        cmbIngrediente.ValueMember = "IdIngrediente";
                        cmbIngrediente.SelectedIndex = -1;
                        cmbIngrediente.Text = "--Seleccionar--";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los ingredientes: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSeleccionProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSeleccionProd.SelectedIndex < 0 || cmbSeleccionProd.SelectedValue == null)
            {
                plIngredienteReceta.Visible = false;
                dtgInfoReceta.Rows.Clear();
                idRecetaActual = null;
                return;
            }

            int idProducto;
            if (!int.TryParse(cmbSeleccionProd.SelectedValue.ToString(), out idProducto))
                return;

            lblProductReceta.Text = cmbSeleccionProd.Text;

            plIngredienteReceta.Visible = true;

            CargarRecetaDeProducto(idProducto);
        }

        private void CargarRecetaDeProducto(int idProducto)
        {
            dtgInfoReceta.Rows.Clear();
            idRecetaActual = null;

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_ObtenerDetalleRecetaPorProducto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (!idRecetaActual.HasValue)
                                idRecetaActual = Convert.ToInt32(dr["IdReceta"]);

                            int idDet = Convert.ToInt32(dr["IdDetalleReceta"]);
                            int idIng = Convert.ToInt32(dr["IdIngrediente"]);
                            string nombreIng = Convert.ToString(dr["NombreIngrediente"]);
                            decimal cantidadReq = Convert.ToDecimal(dr["CantidadRequerida"]);
                            string unidad = Convert.ToString(dr["UnidadMedida"]);

                            int fila = dtgInfoReceta.Rows.Add();
                            DataGridViewRow row = dtgInfoReceta.Rows[fila];
                            row.Cells["IdDetalleReceta"].Value = idDet;
                            row.Cells["IdIngrediente"].Value = idIng;
                            row.Cells["Column1"].Value = nombreIng;
                            row.Cells["Column2"].Value = cantidadReq;
                            row.Cells["Column3"].Value = unidad;
                        }
                    }
                }
                ActualizarPanelAnuncio();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la receta: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAñadirReceta_Click(object sender, EventArgs e)
        {
            if (cmbSeleccionProd.SelectedIndex < 0 || cmbSeleccionProd.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un producto.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cmbIngrediente.SelectedIndex < 0 || cmbIngrediente.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un ingrediente.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (nudCantUni.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor que 0.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idIngrediente = Convert.ToInt32(cmbIngrediente.SelectedValue);
            decimal cantidadReq = nudCantUni.Value;
            string unidad = "";

            if (dtIngredientes != null)
            {
                DataRow[] filas = dtIngredientes.Select("IdIngrediente = " + idIngrediente);
                if (filas.Length > 0)
                    unidad = Convert.ToString(filas[0]["UnidadMedida"]);
            }

            // ✅ Si ya hay receta guardada en BD, usamos SP_InsertarDetalleReceta
            if (idRecetaActual.HasValue)
            {
                try
                {
                    using (SqlConnection cn = Conexion.ObtenerConexion())
                    using (SqlCommand cmd = new SqlCommand("SP_InsertarDetalleReceta", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdReceta", idRecetaActual.Value);
                        cmd.Parameters.AddWithValue("@IdIngrediente", idIngrediente);
                        cmd.Parameters.AddWithValue("@CantidadRequerida", cantidadReq);

                        cn.Open();
                        cmd.ExecuteNonQuery();
                    }

                    CargarRecetaDeProducto(Convert.ToInt32(cmbSeleccionProd.SelectedValue));

                    nudCantUni.Value = 0;
                    cmbIngrediente.SelectedIndex = -1;
                    cmbIngrediente.Text = "--Seleccionar--";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al añadir ingrediente: " + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }

            // Si la receta no existe aún (en memoria)
            int rowIndex = dtgInfoReceta.Rows.Add();
            DataGridViewRow rowNew = dtgInfoReceta.Rows[rowIndex];
            rowNew.Cells["IdIngrediente"].Value = idIngrediente;
            rowNew.Cells["Column1"].Value = cmbIngrediente.Text;
            rowNew.Cells["Column2"].Value = cantidadReq;
            rowNew.Cells["Column3"].Value = unidad;

            nudCantUni.Value = 0;
            cmbIngrediente.SelectedIndex = -1;
            cmbIngrediente.Text = "--Seleccionar--";

            ActualizarPanelAnuncio();
        }

        private void EliminarDetalleFila(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dtgInfoReceta.Rows.Count) return;

            DataGridViewRow fila = dtgInfoReceta.Rows[rowIndex];

            if (fila.Cells["IdDetalleReceta"].Value == null)
            {
                dtgInfoReceta.Rows.RemoveAt(rowIndex);
                return;
            }

            int idDetalle = Convert.ToInt32(fila.Cells["IdDetalleReceta"].Value);
            string nombreIng = Convert.ToString(fila.Cells["Column1"].Value);

            DialogResult result = MessageBox.Show(
                $"¿Desea eliminar el ingrediente \"{nombreIng}\" de la receta?",
                "Eliminar ingrediente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_EliminarDetalleReceta", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdDetalleReceta", idDetalle);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Ingrediente eliminado correctamente.",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (cmbSeleccionProd.SelectedValue != null)
                {
                    int idProducto = Convert.ToInt32(cmbSeleccionProd.SelectedValue);
                    CargarRecetaDeProducto(idProducto);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar ingrediente: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgInfoReceta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dtgInfoReceta.Columns[e.ColumnIndex].Name == "Column4")
            {
                EliminarDetalleFila(e.RowIndex);
            }
        }

        private void ActualizarPanelAnuncio()
        {
            plAnuncioIngre.Visible = (dtgInfoReceta.Rows.Count == 0);
        }


        private void btnGuardarReceta_Click(object sender, EventArgs e)
        {
            if (cmbSeleccionProd.SelectedIndex < 0 || cmbSeleccionProd.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un producto para la receta.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dtgInfoReceta.Rows.Count == 0)
            {
                MessageBox.Show("Agregue al menos un ingrediente a la receta.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idProducto = Convert.ToInt32(cmbSeleccionProd.SelectedValue);

            // ✅ Construir XML con los detalles
            StringBuilder xmlBuilder = new StringBuilder();
            xmlBuilder.Append("<Detalles>");
            foreach (DataGridViewRow fila in dtgInfoReceta.Rows)
            {
                if (fila.IsNewRow) continue;

                int idIngrediente = Convert.ToInt32(fila.Cells["IdIngrediente"].Value);
                decimal cantidadReq = Convert.ToDecimal(fila.Cells["Column2"].Value);

                xmlBuilder.Append("<Detalle>");
                xmlBuilder.AppendFormat("<IdIngrediente>{0}</IdIngrediente>", idIngrediente);
                xmlBuilder.AppendFormat("<CantidadRequerida>{0}</CantidadRequerida>", cantidadReq);
                xmlBuilder.Append("</Detalle>");
            }
            xmlBuilder.Append("</Detalles>");

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_InsertarRecetaCompleta", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    cmd.Parameters.AddWithValue("@DetalleRecetasXML", xmlBuilder.ToString());

                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int resultado = Convert.ToInt32(reader["Resultado"]);
                            string mensaje = reader["Mensaje"].ToString();

                            MessageBox.Show(mensaje,
                                resultado == 1 ? "Éxito" : "Error",
                                MessageBoxButtons.OK,
                                resultado == 1 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                        }
                    }
                }

                // ✅ Recargar receta para mostrar datos actualizados
                CargarRecetaDeProducto(idProducto);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la receta: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
