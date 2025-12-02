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

namespace Pedidos
{
    public partial class FormProduccion : Form
    {
        ToolStripButton btnPedidos;
        ToolStripButton btnInventario;
        ToolStripButton btnRecetas;
        ToolStripButton btnProduccion;
        ToolStripButton btnProductos;

        private int? idProductoSeleccionado = null;
        private int stockActualProducto = 0;
        private decimal precioVentaProducto = 0m;

        private class IngredienteReceta
        {
            public int IdIngrediente { get; set; }
            public string NombreIngrediente { get; set; }
            public decimal CantidadRequerida { get; set; }
            public decimal CantidadActual { get; set; }
            public string UnidadMedida { get; set; }
        }

        private readonly List<IngredienteReceta> ingredientesRecetaActual = new List<IngredienteReceta>();

        public FormProduccion()
        {
            InitializeComponent();
            ConfigurarMenu();
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

            btnPedidos.Click += (s, e) => AbrirFormulario(new FormPedido(), btnPedidos);
            btnInventario.Click += (s, e) => AbrirFormulario(new FormInventario(), btnInventario);
            btnRecetas.Click += (s, e) => AbrirFormulario(new FormReceta(), btnRecetas);
            btnProduccion.Click += (s, e) => AbrirFormulario(new FormProduccion(), btnProduccion);
            btnProductos.Click += (s, e) => AbrirFormulario(new FormProducto(), btnProductos);

            MarcarBotonActivo(btnProduccion);
        }

        private void FormProduccion_Load(object sender, EventArgs e)
        {
            plInfoLote.Visible = false;
            plIngreStock.Visible = false;
            dtgIngreNecDisp.Visible = false;

            nudCantProd.Minimum = 0;
            nudCantProd.DecimalPlaces = 0;

            if (!dtgIngreNecDisp.Columns.Contains("Column4"))
            {
                var colUnidad = new DataGridViewTextBoxColumn
                {
                    Name = "Column4",
                    HeaderText = "Unidad",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                };
                dtgIngreNecDisp.Columns.Add(colUnidad);
            }

            dtgIngreNecDisp.AllowUserToAddRows = false;
            nudCantProd.ValueChanged += nudCantProd_ValueChanged;

            CargarProductos();
        }

        // ====================================================
        // Cargar lista de productos (usa SP_ListarProductos)
        // ====================================================
        private void CargarProductos()
        {
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_ListarProductos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbSelecProd.DataSource = dt;
                    cmbSelecProd.DisplayMember = "Nombre";
                    cmbSelecProd.ValueMember = "IdProducto";
                    cmbSelecProd.SelectedIndex = -1;
                    cmbSelecProd.Text = "-- Seleccionar Producto --";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====================================================
        // Cargar ingredientes de la receta (usa SP_ObtenerIngredientesReceta)
        // ====================================================
        private void CargarIngredientesReceta(int idProducto)
        {
            ingredientesRecetaActual.Clear();

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_ObtenerIngredientesReceta", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ingredientesRecetaActual.Add(new IngredienteReceta
                            {
                                IdIngrediente = Convert.ToInt32(dr["IdIngrediente"]),
                                NombreIngrediente = dr["NombreIngrediente"].ToString(),
                                CantidadRequerida = Convert.ToDecimal(dr["CantidadRequerida"]),
                                CantidadActual = Convert.ToDecimal(dr["CantidadActual"]),
                                UnidadMedida = dr["UnidadMedida"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los ingredientes de la receta: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====================================================
        // Evento cambio cantidad
        // ====================================================
        private void nudCantProd_ValueChanged(object sender, EventArgs e)
        {
            if (!idProductoSeleccionado.HasValue)
            {
                dtgIngreNecDisp.Rows.Clear();
                plIngreStock.Visible = false;
                dtgIngreNecDisp.Visible = false;
                lblUniDProd.Text = $"{stockActualProducto} unidades";
                return;
            }

            decimal cantidadProducir = nudCantProd.Value;
            if (cantidadProducir <= 0)
            {
                dtgIngreNecDisp.Rows.Clear();
                plIngreStock.Visible = false;
                dtgIngreNecDisp.Visible = false;
                lblUniDProd.Text = $"{stockActualProducto} unidades";
                return;
            }

            plIngreStock.Visible = true;
            dtgIngreNecDisp.Visible = true;
            dtgIngreNecDisp.Rows.Clear();

            foreach (var ing in ingredientesRecetaActual)
            {
                decimal necesario = ing.CantidadRequerida * cantidadProducir;
                int fila = dtgIngreNecDisp.Rows.Add();
                DataGridViewRow row = dtgIngreNecDisp.Rows[fila];
                row.Cells["Column1"].Value = ing.NombreIngrediente;
                row.Cells["Column2"].Value = necesario;
                row.Cells["Column3"].Value = ing.CantidadActual;
                row.Cells["Column4"].Value = ing.UnidadMedida;
            }

            ActualizarStockDespuesProduccion();
        }

        private void ActualizarStockDespuesProduccion()
        {
            int total = stockActualProducto + Convert.ToInt32(nudCantProd.Value);
            lblUniDProd.Text = total + " unidades";
        }

        // ====================================================
        // Selección de producto (usa SP_ObtenerDatosProducto)
        // ====================================================
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelecProd.SelectedIndex < 0 || cmbSelecProd.SelectedValue == null)
            {
                idProductoSeleccionado = null;
                stockActualProducto = 0;
                precioVentaProducto = 0m;

                lblUnidStock.Text = "0 unidades";
                lblPrecUni.Text = "$0.00";
                lblUniDProd.Text = "0 unidades";

                plInfoLote.Visible = false;
                plIngreStock.Visible = false;
                dtgIngreNecDisp.Rows.Clear();
                dtgIngreNecDisp.Visible = false;
                return;
            }

            int idProducto = Convert.ToInt32(cmbSelecProd.SelectedValue);
            idProductoSeleccionado = idProducto;

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_ObtenerDatosProducto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            stockActualProducto = Convert.ToInt32(dr["Stock"]);
                            precioVentaProducto = Convert.ToDecimal(dr["PrecioVenta"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos del producto: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblUnidStock.Text = $"{stockActualProducto} unidades";
            lblPrecUni.Text = precioVentaProducto.ToString("C2");
            lblProdProducir.Text = "Producto a Producir: " + cmbSelecProd.Text;
            lblLoteProd.Text = "Lote de Producción - " + cmbSelecProd.Text;
            lblUniDProd.Text = $"{stockActualProducto} unidades";
            nudCantProd.Value = 0;

            CargarIngredientesReceta(idProducto);
            plInfoLote.Visible = true;
        }

        // ====================================================
        // Registrar producción (usa SP_RegistrarProduccion)
        // ====================================================
        private void btnRegProd_Click(object sender, EventArgs e)
        {
            if (!idProductoSeleccionado.HasValue)
            {
                MessageBox.Show("Debe seleccionar un producto.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (nudCantProd.Value <= 0)
            {
                MessageBox.Show("Debe indicar la cantidad a producir.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_RegistrarProduccion", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", idProductoSeleccionado.Value);
                    cmd.Parameters.AddWithValue("@CantidadProducida", Convert.ToInt32(nudCantProd.Value));
                    cmd.Parameters.AddWithValue("@Observaciones",
                        string.IsNullOrWhiteSpace(txtObserv.Text) ? (object)DBNull.Value : txtObserv.Text);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                stockActualProducto += Convert.ToInt32(nudCantProd.Value);
                lblUnidStock.Text = $"{stockActualProducto} unidades";
                lblUniDProd.Text = $"{stockActualProducto} unidades";

                MessageBox.Show("Producción registrada correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                nudCantProd.Value = 0;
                txtObserv.Clear();
                dtgIngreNecDisp.Rows.Clear();
                plIngreStock.Visible = false;
                dtgIngreNecDisp.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la producción: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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



        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Desea cerrar sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // ✅ Buscar si FormLogin está abierto, si no, crear uno nuevo
                FormLogin frmLogin = Application.OpenForms
                    .OfType<FormLogin>()
                    .FirstOrDefault() ?? new FormLogin();

                frmLogin.Show();
                this.Close();
            }
        }




        private void lblLog_Click(object sender, EventArgs e)
        {
            FormRegistro f2 = new FormRegistro();
            f2.Show();
            this.Hide();

        }
    }

}
