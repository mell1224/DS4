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
using System.IO;

namespace Pedidos
{
    public partial class FormProducto : Form
    {
        ToolStripButton btnPedidos;
        ToolStripButton btnInventario;
        ToolStripButton btnRecetas;
        ToolStripButton btnProduccion;
        ToolStripButton btnProductos;

        private DataTable _productos;
        private DataTable _categorias;
        private int? _idProductoEnEdicion;
        private const int UMBRAL_STOCK_BAJO = 10;

        public FormProducto()
        {
            InitializeComponent();
            ConfigurarMenu();
            InicializarFormulario();
        }

        private void InicializarFormulario()
        {
            plNuevoProd.Visible = false;
            plEditProd.Visible = false;

            this.Load += FormProducto_Load;

            dtgProductos.AutoGenerateColumns = false;
            dtgProductos.CellContentClick += dtgProductos_CellContentClick;

            txtBuscarProd.TextChanged += txtBuscarProd_TextChanged;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            btnNuevoProducto.Click += btnNuevoProducto_Click;
            btnCanceProd.Click += btnCanceProd_Click;
            btnCanceEditProd.Click += btnCanceEditProd_Click;
            btnCrearProd.Click += btnCrearProd_Click;
            btnGuardCamb.Click += btnGuardCamb_Click;

            ConfigurarGrillaProductos();
        }

        // 1. Método ConfigurarMenu

        private void ConfigurarMenu()
        {
            // Crear botones
            btnPedidos = new ToolStripButton("Pedidos");
            btnInventario = new ToolStripButton("Inventario");
            btnRecetas = new ToolStripButton("Recetas");
            btnProduccion = new ToolStripButton("Producción");
            btnProductos = new ToolStripButton("Productos");

            // Asignar eventos para abrir formularios
            btnPedidos.Click += (s, e) => AbrirFormulario(new FormPedido(), btnPedidos);
            btnInventario.Click += (s, e) => AbrirFormulario(new FormInventario(), btnInventario);
            btnRecetas.Click += (s, e) => AbrirFormulario(new FormReceta(), btnRecetas);
            btnProduccion.Click += (s, e) => AbrirFormulario(new FormProduccion(), btnProduccion);
            btnProductos.Click += (s, e) => AbrirFormulario(new FormProducto(), btnProductos);

            // Agregar botones al ToolStrip
            tsP.Items.AddRange(new ToolStripItem[]
            {
        btnPedidos, btnInventario, btnRecetas, btnProduccion, btnProductos
            });

            // Marcar el botón activo (Productos)
            MarcarBotonActivo(btnProductos);
        }

        // Método para abrir formularios y ocultar el actual
        private void AbrirFormulario(Form destino, ToolStripButton botonActivo)
        {
            MarcarBotonActivo(botonActivo);
            destino.Show();
            this.Hide();
        }

        // Método para resaltar el botón activo
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


        // 2. Evento dtgProductos_CellContentClick
        private void dtgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Editar
            if (dtgProductos.Columns[e.ColumnIndex].Name == "Column6")
            {
                MostrarPanelEditarProducto(e.RowIndex);
            }
            // Eliminar
            else if (dtgProductos.Columns[e.ColumnIndex].Name == "Column7")
            {
                EliminarProducto(e.RowIndex);
            }
        }

        // 3. Evento txtBuscarProd_TextChanged
        private void txtBuscarProd_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltrosYMostrar();
        }

        // 4. Evento comboBox1_SelectedIndexChanged
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltrosYMostrar();
        }

        // 5. Evento btnNuevoProducto_Click
        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            plNuevoProd.Visible = true;
            plEditProd.Visible = false;
            txtNombProd.Text = "";
            txtDescrN.Text = "";
            nudPreNuev.Value = 0;
            nudIniNuev.Value = 0;
            cmbCategNuev.SelectedIndex = -1;
        }

        // 6. Evento btnCanceProd_Click
        private void btnCanceProd_Click(object sender, EventArgs e)
        {
            plNuevoProd.Visible = false;
        }

        // 7. Evento btnCanceEditProd_Click
        private void btnCanceEditProd_Click(object sender, EventArgs e)
        {
            plEditProd.Visible = false;
        }
      

        // 9. Método ValidarNuevoProducto
        private bool ValidarNuevoProducto()
        {
            if (string.IsNullOrWhiteSpace(txtNombProd.Text))
            {
                MessageBox.Show("Ingrese el nombre del producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbCategNuev.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // 10. Método ValidarProductoEdicion
        private bool ValidarProductoEdicion()
        {
            if (string.IsNullOrWhiteSpace(txtEditProd.Text))
            {
                MessageBox.Show("Ingrese el nombre del producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbCategEdit.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Método auxiliar para editar producto
        private void MostrarPanelEditarProducto(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dtgProductos.Rows.Count) return;

            DataGridViewRow fila = dtgProductos.Rows[rowIndex];
            if (fila.Cells["IdProducto"].Value == null) return;

            _idProductoEnEdicion = Convert.ToInt32(fila.Cells["IdProducto"].Value);
            txtEditProd.Text = fila.Cells["Column2"].Value?.ToString() ?? "";
            txtDescrEdit.Text = ""; // Asigna la descripción si está disponible
            nudPrecEdit.Value = fila.Cells["Column4"].Value != null ? Convert.ToDecimal(fila.Cells["Column4"].Value) : 0;
            nudIniEdit.Value = fila.Cells["Column5"].Value != null ? Convert.ToDecimal(fila.Cells["Column5"].Value) : 0;
            cmbCategEdit.SelectedIndex = cmbCategEdit.FindStringExact(fila.Cells["Categoria"].Value?.ToString() ?? "");

            plEditProd.Visible = true;
            plNuevoProd.Visible = false;
        }

        private void FormProducto_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarProductos();
        }

        private void ConfigurarGrillaProductos()
        {
            if (!dtgProductos.Columns.Contains("IdProducto"))
            {
                var colId = new DataGridViewTextBoxColumn();
                colId.Name = "IdProducto";
                colId.HeaderText = "IdProducto";
                colId.Visible = false;
                dtgProductos.Columns.Insert(0, colId);
            }

            if (Column1 is DataGridViewImageColumn imgCol)
            {
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }

            Column6.Text = "Editar";
            Column6.UseColumnTextForButtonValue = true;

            Column7.Text = "Eliminar";
            Column7.UseColumnTextForButtonValue = true;

            dtgProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgProductos.MultiSelect = false;
            dtgProductos.ReadOnly = true;
            dtgProductos.AllowUserToAddRows = false;
        }

        // ✅ CARGAR CATEGORÍAS CON SP
        private void CargarCategorias()
        {
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_ListarCategorias", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        _categorias = dt;

                        DataTable dtFiltro = dt.Copy();
                        DataRow filaTodas = dtFiltro.NewRow();
                        filaTodas["IdCategoria"] = DBNull.Value;
                        filaTodas["Nombre"] = "Todas";
                        dtFiltro.Rows.InsertAt(filaTodas, 0);

                        comboBox1.DataSource = dtFiltro;
                        comboBox1.DisplayMember = "Nombre";
                        comboBox1.ValueMember = "IdCategoria";

                        DataTable dtNuev = dt.Copy();
                        DataTable dtEdit = dt.Copy();

                        cmbCategNuev.DataSource = dtNuev;
                        cmbCategNuev.DisplayMember = "Nombre";
                        cmbCategNuev.ValueMember = "IdCategoria";
                        cmbCategNuev.SelectedIndex = -1;

                        cmbCategEdit.DataSource = dtEdit;
                        cmbCategEdit.DisplayMember = "Nombre";
                        cmbCategEdit.ValueMember = "IdCategoria";
                        cmbCategEdit.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las categorías: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        
        // ✅ CARGAR PRODUCTOS CON SP

        private void CargarProductos()
        {
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_ListarProductos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        _productos = dt;
                    }

                    AplicarFiltrosYMostrar();

                    // Actualizar título del formulario
                    this.Text = $"Productos cargados: {_productos?.Rows.Count ?? 0}";

                    // ✅ Actualizar labels con estadísticas generales
                    if (_productos != null)
                    {
                        Font fuente = new Font("Constantia", 12, FontStyle.Bold);
                        Color colorGeneral = Color.FromArgb(228, 125, 4);
                        Color colorCantSinStock = Color.FromArgb(146, 24, 61);
                        Color colorProductosSinStock = Color.FromArgb(197, 0, 7);

                        // 1. Cantidad total de productos
                        lblCantProd.Text = _productos.Rows.Count.ToString();
                        lblCantProd.Font = fuente;
                        lblCantProd.ForeColor = colorGeneral;

                        // 2. Stock total
                        int stockTotal = _productos.AsEnumerable().Sum(row => row.Field<int>("Stock"));
                        lblUnidTotal.Text = $"{stockTotal} Unidades";
                        lblUnidTotal.Font = fuente;
                        lblUnidTotal.ForeColor = colorGeneral;

                        // 3. Productos con stock bajo (<10)
                        int stockBajo = _productos.AsEnumerable().Count(row => row.Field<int>("Stock") < UMBRAL_STOCK_BAJO);
                        lblCantStockBajo.Text = stockBajo.ToString();
                        lblCantStockBajo.Font = fuente;
                        lblCantStockBajo.ForeColor = colorGeneral;

                        // 4. Productos sin stock (==0) - Cantidad
                        int sinStock = _productos.AsEnumerable().Count(row => row.Field<int>("Stock") == 0);
                        lblCantSinStock.Text = sinStock.ToString();
                        lblCantSinStock.Font = fuente;
                        lblCantSinStock.ForeColor = colorCantSinStock;

                        // 5. Nombres de productos sin stock
                        var nombresSinStock = _productos.AsEnumerable()
                            .Where(row => row.Field<int>("Stock") == 0)
                            .Select(row => row.Field<string>("Nombre"))
                            .ToList();

                        lblProductosSinStock.Text = nombresSinStock.Count > 0 ? string.Join(", ", nombresSinStock) : "Ninguno";
                        lblProductosSinStock.Font = fuente;
                        lblProductosSinStock.ForeColor = colorProductosSinStock;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltrosYMostrar()
        {
            if (_productos == null) return;

            string texto = txtBuscarProd.Text.Trim().Replace("'", "''");
            List<string> filtros = new List<string>();

            if (!string.IsNullOrEmpty(texto))
            {
                filtros.Add($"(Nombre LIKE '%{texto}%' OR Categoria LIKE '%{texto}%')");
            }

            if (comboBox1.SelectedValue != null && comboBox1.SelectedValue != DBNull.Value)
            {
                int idCat = Convert.ToInt32(comboBox1.SelectedValue);
                filtros.Add($"IdCategoria = {idCat}");
            }

            string filtroFinal = string.Join(" AND ", filtros);
            DataView dv = new DataView(_productos);
            dv.RowFilter = filtroFinal;

            MostrarEnGrid(dv);

            // ✅ Actualizar labels con datos filtrados
            Font fuente = new Font("Constantia", 12, FontStyle.Bold);
            Color color = Color.FromArgb(228, 125, 4);

            int cantProd = dv.Count;
            int stockTotal = dv.Cast<DataRowView>().Sum(drv => Convert.ToInt32(drv["Stock"]));
            int stockBajo = dv.Cast<DataRowView>().Count(drv => Convert.ToInt32(drv["Stock"]) < UMBRAL_STOCK_BAJO);
            int sinStock = dv.Cast<DataRowView>().Count(drv => Convert.ToInt32(drv["Stock"]) == 0);

            lblCantProd.Text = cantProd.ToString();
            lblCantProd.Font = fuente;
            lblCantProd.ForeColor = color;

            lblUnidTotal.Text = $"{stockTotal} Unidades";
            lblUnidTotal.Font = fuente;
            lblUnidTotal.ForeColor = color;

            lblCantStockBajo.Text = stockBajo.ToString();
            lblCantStockBajo.Font = fuente;
            lblCantStockBajo.ForeColor = color;

            lblCantProdSinStock.Text = sinStock.ToString();
            lblCantProdSinStock.Font = fuente;
            lblCantProdSinStock.ForeColor = color;
        }


        private void MostrarEnGrid(DataView vista)
        {
            dtgProductos.Rows.Clear();

            foreach (DataRowView drv in vista)
            {
                DataRow row = drv.Row;

                int index = dtgProductos.Rows.Add();
                DataGridViewRow gr = dtgProductos.Rows[index];

                gr.Cells["IdProducto"].Value = row["IdProducto"];
                gr.Cells["Column2"].Value = row["Nombre"];
                gr.Cells["Categoria"].Value = row["Categoria"];
                gr.Cells["Column4"].Value = row["PrecioVenta"];
                gr.Cells["Column5"].Value = row["Stock"];

                Image img = null;
                object imgObj = row["ImagenURL"];
                if (imgObj != DBNull.Value && imgObj != null)
                {
                    string ruta = imgObj.ToString();
                    if (!string.IsNullOrWhiteSpace(ruta) && File.Exists(ruta))
                    {
                        try { img = Image.FromFile(ruta); } catch { img = null; }
                    }
                }

                gr.Cells["Column1"].Value = img;
            }
        }

        // ✅ CREAR PRODUCTO CON SP
        private void btnCrearProd_Click(object sender, EventArgs e)
        {
            if (!ValidarNuevoProducto()) return;

            string nombre = txtNombProd.Text.Trim();
            string descripcion = txtDescrN.Text.Trim();
            decimal precio = nudPreNuev.Value;
            int stock = (int)nudIniNuev.Value;
            int idCategoria = Convert.ToInt32(cmbCategNuev.SelectedValue);
            string imagenUrl = null;

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_InsertarProducto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                    cmd.Parameters.AddWithValue("@PrecioVenta", precio);
                    cmd.Parameters.AddWithValue("@Stock", stock);
                    cmd.Parameters.AddWithValue("@ImagenURL",
                        string.IsNullOrEmpty(imagenUrl) ? (object)DBNull.Value : imagenUrl);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Producto creado correctamente.",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                plNuevoProd.Visible = false;
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el producto: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ✅ EDITAR PRODUCTO CON SP
        private void btnGuardCamb_Click(object sender, EventArgs e)
        {
            if (!ValidarProductoEdicion()) return;

            int idProducto = _idProductoEnEdicion.Value;
            string nombre = txtEditProd.Text.Trim();
            string descripcion = txtDescrEdit.Text.Trim();
            decimal precio = nudPrecEdit.Value;
            int stock = (int)nudIniEdit.Value; // ✅ Stock leído correctamente
            int idCategoria = Convert.ToInt32(cmbCategEdit.SelectedValue);
            string imagenUrl = null;

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_ActualizarProducto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@PrecioVenta", precio);
                    cmd.Parameters.AddWithValue("@Stock", stock); // ✅ Agregado
                    cmd.Parameters.AddWithValue("@ImagenURL", string.IsNullOrEmpty(imagenUrl) ? (object)DBNull.Value : imagenUrl);
                    cmd.Parameters.AddWithValue("@Activo", 1);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Producto actualizado correctamente.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                plEditProd.Visible = false;
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el producto: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // ✅ ELIMINAR PRODUCTO CON SP
        private void EliminarProducto(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dtgProductos.Rows.Count) return;

            DataGridViewRow fila = dtgProductos.Rows[rowIndex];
            if (fila.Cells["IdProducto"].Value == null) return;

            int idProducto = Convert.ToInt32(fila.Cells["IdProducto"].Value);
            string nombre = fila.Cells["Column2"].Value?.ToString() ?? "";

            DialogResult dr = MessageBox.Show(
                $"¿Seguro que deseas eliminar el producto \"{nombre}\"?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes) return;

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_EliminarProducto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Producto eliminado correctamente.",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el producto. Verifique dependencias.\n\nDetalle: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin fl = new FormLogin();
            fl.Show();
        }
    }
}
