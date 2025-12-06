
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

        // >>> NUEVO: Filtro activado por las tarjetas/panel grande
        private string _filtroVista = string.Empty;

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
            dtgProductos.CellClick += dtgProductos_CellClick; // << habilita clic en celda de imagen

            txtBuscarProd.TextChanged += txtBuscarProd_TextChanged;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            btnNuevoProducto.Click += btnNuevoProducto_Click;
            btnCanceProd.Click += btnCanceProd_Click;
            btnCanceEditProd.Click += btnCanceEditProd_Click;
            btnCrearProd.Click += btnCrearProd_Click;
            btnGuardCamb.Click += btnGuardCamb_Click;

            ConfigurarGrillaProductos(); // configura columnas, incl. imagen

            // >>> NUEVO: Click en las tarjetas (plVistaInfoProd) y panel grande (plProSinStock)
            plTotalProd.Click += (s, e) => { _filtroVista = ""; AplicarFiltrosYMostrar(); };
            plStockTotal.Click += (s, e) => { _filtroVista = ""; AplicarFiltrosYMostrar(); }; // KPI informativo
            plStockBajo.Click += (s, e) => { _filtroVista = $"Stock <= {UMBRAL_STOCK_BAJO}"; AplicarFiltrosYMostrar(); };
            plSinStock.Click += (s, e) => { _filtroVista = "Stock = 0"; AplicarFiltrosYMostrar(); };

            // Panel grande: también filtra por Sin Stock
            plProSinStock.Click += (s, e) => { _filtroVista = "Stock = 0"; AplicarFiltrosYMostrar(); };

            // >>> NUEVO: Hover visual para los paneles clicables
            WireHover(plTotalProd);
            WireHover(plStockTotal);
            WireHover(plStockBajo);
            WireHover(plSinStock);
            WireHover(plProSinStock);
        }

        private void ConfigurarMenu()
        {
            // Crear botones
            btnPedidos = new ToolStripButton("Pedidos");
            btnInventario = new ToolStripButton("Inventario");
            btnRecetas = new ToolStripButton("Recetas");
            btnProduccion = new ToolStripButton("Producción");
            btnProductos = new ToolStripButton("Productos");

            // Abrir formularios
            btnPedidos.Click += (s, e) => AbrirFormulario(new FormPedido(), btnPedidos);
            btnInventario.Click += (s, e) => AbrirFormulario(new FormInventario(), btnInventario);
            btnRecetas.Click += (s, e) => AbrirFormulario(new FormReceta(), btnRecetas);
            btnProduccion.Click += (s, e) => AbrirFormulario(new FormProduccion(), btnProduccion);
            btnProductos.Click += (s, e) => AbrirFormulario(new FormProducto(), btnProductos);

            tsP.Items.AddRange(new ToolStripItem[] { btnPedidos, btnInventario, btnRecetas, btnProduccion, btnProductos });
            MarcarBotonActivo(btnProductos);
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

        private void FormProducto_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarProductos();
        }

        private void ConfigurarGrillaProductos()
        {
            // Asegurar columna IdProducto oculta (necesaria para actualizar la imagen)
            if (!dtgProductos.Columns.Contains("IdProducto"))
            {
                var colId = new DataGridViewTextBoxColumn();
                colId.Name = "IdProducto";
                colId.HeaderText = "IdProducto";
                colId.Visible = false;
                dtgProductos.Columns.Insert(0, colId);
            }

            // Configurar la columna de imagen
            if (dtgProductos.Columns["Column1"] is DataGridViewImageColumn imgCol)
            {
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom; // imagen proporcionada
                imgCol.Width = 120; // ancho confortable
            }

            // Altura de filas para visualizar bien las imágenes
            dtgProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtgProductos.RowTemplate.Height = 100;

            // Botones
            Column6.Text = "Editar";
            Column6.UseColumnTextForButtonValue = true;

            // Comportamiento
            dtgProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgProductos.MultiSelect = false;
            dtgProductos.ReadOnly = false; // permite editar la celda de imagen mediante clic
            dtgProductos.AllowUserToAddRows = false;
        }

        // >>> CARGA DE CATEGORÍAS (SP)
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

                        // Filtro "Todas"
                        DataTable dtFiltro = dt.Copy();
                        DataRow filaTodas = dtFiltro.NewRow();
                        filaTodas["IdCategoria"] = DBNull.Value;
                        filaTodas["Nombre"] = "Todas";
                        dtFiltro.Rows.InsertAt(filaTodas, 0);

                        comboBox1.DataSource = dtFiltro;
                        comboBox1.DisplayMember = "Nombre";
                        comboBox1.ValueMember = "IdCategoria";

                        // Combos de alta/edición
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
                MessageBox.Show("Error al cargar las categorías: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // >>> CARGA DE PRODUCTOS (SP)
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

                    // >>> NUEVO: Actualiza paneles con KPIs y lista de sin stock
                    ActualizarPanelesInfo();

                    this.Text = $"Productos cargados: {_productos?.Rows.Count ?? 0}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // >>> NUEVO: filtro activado por las tarjetas/panel grande
            if (!string.IsNullOrWhiteSpace(_filtroVista))
            {
                filtros.Add(_filtroVista);
            }

            string filtroFinal = string.Join(" AND ", filtros);
            DataView dv = new DataView(_productos);
            dv.RowFilter = filtroFinal;

            MostrarEnGrid(dv);
        }

        // >>> Muestra datos en el grid, incluyendo la imagen desde ImagenURL
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

                // Cargar imagen desde ruta (ImagenURL)
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

        // >>> NUEVO: Actualiza contadores y listas en paneles KPI y panel grande
        private void ActualizarPanelesInfo()
        {
            try
            {
                if (_productos == null || _productos.Rows.Count == 0)
                {
                    lblCantProd.Text = "0";
                    lblUnidTotal.Text = "0 Unidades";
                    lblCantStockBajo.Text = "0";
                    lblCantProdSinStock.Text = "0";
                    lblCantSinStock.Text = "0";
                    lblProductosSinStock.Text = "";

                    plVistaInfoProd.Visible = true;
                    plProSinStock.Visible = true;
                    plVistaInfoProd.BringToFront();
                    plProSinStock.BringToFront();
                    return;
                }

                // Total productos
                int totalProductos = _productos.Rows.Count;

                // Total unidades (suma de Stock)
                int totalUnidades = _productos.AsEnumerable()
                    .Sum(r => Convert.ToInt32(r["Stock"]));

                // Sin stock
                var sinStockQuery = _productos.AsEnumerable()
                    .Where(r => Convert.ToInt32(r["Stock"]) == 0)
                    .Select(r => r["Nombre"].ToString())
                    .ToList();
                int cantSinStock = sinStockQuery.Count;

                // Stock bajo
                int cantStockBajo = _productos.AsEnumerable()
                    .Count(r => Convert.ToInt32(r["Stock"]) <= UMBRAL_STOCK_BAJO);

                // Actualiza tarjetas
                lblCantProd.Text = totalProductos.ToString();
                lblUnidTotal.Text = $"{totalUnidades} Unidades";
                lblCantStockBajo.Text = cantStockBajo.ToString();
                lblCantProdSinStock.Text = cantSinStock.ToString();

                // Panel grande (sin stock)
                lblCantSinStock.Text = cantSinStock.ToString();
                string lista = string.Join(", ", sinStockQuery.Take(10));
                lblProductosSinStock.Text = string.IsNullOrWhiteSpace(lista) ? "—" : lista;

                plVistaInfoProd.Visible = true;
                plProSinStock.Visible = true;
                plVistaInfoProd.BringToFront();
                plProSinStock.BringToFront();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar paneles: " + ex.Message);
            }
        }

        // >>> NUEVO: feedback visual (hover) para paneles clicables
        private void WireHover(Panel p)
        {
            p.MouseEnter += (s, e) =>
            {
                p.BackColor = Color.FromArgb(245, 245, 245);
                p.Cursor = Cursors.Hand;
            };
            p.MouseLeave += (s, e) =>
            {
                p.BackColor = Color.White;
                p.Cursor = Cursors.Default;
            };
        }

        // >>> Clic en celda de imagen: elegir archivo y actualizar BD
        private void dtgProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Solo cuando se hace clic en la columna de imagen
            if (dtgProductos.Columns[e.ColumnIndex].Name == "Column1")
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp;*.ico";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string ruta = ofd.FileName;
                    // Mostrar en la celda
                    dtgProductos.Rows[e.RowIndex].Cells["Column1"].Value = Image.FromFile(ruta);
                    // Actualizar BD
                    int id = Convert.ToInt32(dtgProductos.Rows[e.RowIndex].Cells["IdProducto"].Value);
                    GuardarImagenBD(id, ruta);
                }
            }
        }

        // >>> Guarda la ruta de la imagen en la BD (SP_ActualizarImagenProducto)
        // FormProducto.cs
        private void GuardarImagenBD(int idProducto, string ruta)
        {
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("dbo.SP_ActualizarImagenProducto", cn)) // <-- usa esquema dbo
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    cmd.Parameters.AddWithValue("@ImagenURL", ruta);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al actualizar la imagen: " + ex.Message +
                    "\n\nVerifica:\n- Que el SP 'dbo.SP_ActualizarImagenProducto' exista en PanaderiaDB.\n" +
                    "- Que la cadena de conexión apunte a PanaderiaDB.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la imagen: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            // Editar
            if (dtgProductos.Columns[e.ColumnIndex].Name == "Column6")
            {
                MostrarPanelEditarProducto(e.RowIndex);
                return;
            }
            // Eliminar
            if (dtgProductos.Columns[e.ColumnIndex].Name == "Column7")
            {
                EliminarProducto(e.RowIndex);
                return;
            }
        }

        private void MostrarPanelEditarProducto(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dtgProductos.Rows.Count) return;
            DataGridViewRow fila = dtgProductos.Rows[rowIndex];
            if (fila.Cells["IdProducto"].Value == null) return;

            _idProductoEnEdicion = Convert.ToInt32(fila.Cells["IdProducto"].Value);
            txtEditProd.Text = fila.Cells["Column2"].Value?.ToString() ?? "";
            txtDescrEdit.Text = ""; // (Completar si la descripción está en el grid)
            nudPrecEdit.Value = fila.Cells["Column4"].Value != null ? Convert.ToDecimal(fila.Cells["Column4"].Value) : 0;
            nudIniEdit.Value = fila.Cells["Column5"].Value != null ? Convert.ToDecimal(fila.Cells["Column5"].Value) : 0;
            cmbCategEdit.SelectedIndex = cmbCategEdit.FindStringExact(fila.Cells["Categoria"].Value?.ToString() ?? "");

            plEditProd.Visible = true;
            plNuevoProd.Visible = false;
        }

        private void txtBuscarProd_TextChanged(object sender, EventArgs e) => AplicarFiltrosYMostrar();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) => AplicarFiltrosYMostrar();

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

        private void btnCanceProd_Click(object sender, EventArgs e) => plNuevoProd.Visible = false;
        private void btnCanceEditProd_Click(object sender, EventArgs e) => plEditProd.Visible = false;

        private bool ValidarNuevoProducto()
        {
            if (string.IsNullOrWhiteSpace(txtNombProd.Text))
            {
                MessageBox.Show("Ingrese el nombre del producto.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbCategNuev.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una categoría.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidarProductoEdicion()
        {
            if (string.IsNullOrWhiteSpace(txtEditProd.Text))
            {
                MessageBox.Show("Ingrese el nombre del producto.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbCategEdit.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una categoría.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnCrearProd_Click(object sender, EventArgs e)
        {
            if (!ValidarNuevoProducto()) return;
            string nombre = txtNombProd.Text.Trim();
            string descripcion = txtDescrN.Text.Trim();
            decimal precio = nudPreNuev.Value;
            int stock = (int)nudIniNuev.Value;
            int idCategoria = Convert.ToInt32(cmbCategNuev.SelectedValue);
            string imagenUrl = null; // se puede asignar al crear si ya tienes una
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

        private void btnGuardCamb_Click(object sender, EventArgs e)
        {
            if (!ValidarProductoEdicion()) return;
            int idProducto = _idProductoEnEdicion.Value;
            string nombre = txtEditProd.Text.Trim();
            string descripcion = txtDescrEdit.Text.Trim();
            decimal precio = nudPrecEdit.Value;
            int stock = (int)nudIniEdit.Value;
            int idCategoria = Convert.ToInt32(cmbCategEdit.SelectedValue);
            string imagenUrl = null; // mantener o actualizar si editas fuera del grid
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_ActualizarProducto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                    cmd.Parameters.AddWithValue("@PrecioVenta", precio);
                    cmd.Parameters.AddWithValue("@Stock", stock);
                    cmd.Parameters.AddWithValue("@ImagenURL",
                        string.IsNullOrEmpty(imagenUrl) ? (object)DBNull.Value : imagenUrl);
                    cmd.Parameters.AddWithValue("@Activo", 1); // si tu SP lo requiere
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
