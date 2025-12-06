
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
    public partial class FormPedido : Form
    {
        ToolStripButton btnPedidos;
        ToolStripButton btnInventario;
        ToolStripButton btnRecetas;
        ToolStripButton btnProduccion;
        ToolStripButton btnProductos;

        private DataTable tablaPedidos;

        // FlowLayoutPanel para listar los productos del pedido (debajo del label "Productos")
        private FlowLayoutPanel flpDetalle;

        public FormPedido()
        {
            InitializeComponent();
            plVerPedido.Visible = false;

            // ==== Menú superior ====
            btnPedidos = new ToolStripButton("Pedidos");
            btnInventario = new ToolStripButton("Inventario");
            btnRecetas = new ToolStripButton("Recetas");
            btnProduccion = new ToolStripButton("Producción");
            btnProductos = new ToolStripButton("Productos");

            btnPedidos.Click += (s, e) => AbrirFormulario(new FormPedido(), btnPedidos);
            btnInventario.Click += (s, e) => AbrirFormulario(new FormInventario(), btnInventario);
            btnRecetas.Click += (s, e) => AbrirFormulario(new FormReceta(), btnRecetas);
            btnProduccion.Click += (s, e) => AbrirFormulario(new FormProduccion(), btnProduccion);
            btnProductos.Click += (s, e) => AbrirFormulario(new FormProducto(), btnProductos);

            tsP.Items.AddRange(new ToolStripItem[]
            {
                btnPedidos, btnInventario, btnRecetas, btnProduccion, btnProductos
            });

            MarcarBotonActivo(btnPedidos);

            // ==== Crear y ubicar el FlowLayoutPanel debajo del label "Productos" en plVerPedido ====
            CrearFlowLayoutDetalleDebajoDelLabelProductos();
        }

        // Crea el FlowLayoutPanel y lo ubica debajo del label "Productos" dentro de plVerPedido
        private void CrearFlowLayoutDetalleDebajoDelLabelProductos()
        {
            if (flpDetalle != null) return;

            // Buscar el label por Name o por texto "Productos"
            Label lblProductos = plVerPedido.Controls
                .OfType<Label>()
                .FirstOrDefault(l =>
                    l.Name == "lblProductos" ||
                    (l.Text != null && l.Text.Trim().Equals("Productos", StringComparison.OrdinalIgnoreCase)));

            int topBase = (lblProductos != null) ? lblProductos.Bottom + 8 : 150;

            flpDetalle = new FlowLayoutPanel
            {
                Name = "flpDetalle",
                AutoScroll = true,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight,
                BackColor = Color.White,
                Padding = new Padding(8),
                Margin = new Padding(0),

                Dock = DockStyle.None,
                Location = new Point(16, topBase),
                Size = new Size(plVerPedido.Width - 32, plVerPedido.Height - topBase - 16),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom
            };

            plVerPedido.Controls.Add(flpDetalle);

            // Asegurar que quede por encima de otros controles
            flpDetalle.BringToFront();
            plVerPedido.Controls.SetChildIndex(flpDetalle, 0);
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

        private void FormPedido_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            ConfigurarColumnas();
            CargarPedidos();
        }

        private void ConfigurarColumnas()
        {
            dataGridView1.AutoGenerateColumns = false;

            // Mapea tus columnas del DataGridView a las del DataTable
            idPedido.DataPropertyName = "IdPedido";
            fecha.DataPropertyName = "FechaPedido";

            // IMPORTANTE: la grilla espera 'NombreCompleto'
            nomCli.DataPropertyName = "NombreCompleto";

            total.DataPropertyName = "Total";
            dirEntrega.DataPropertyName = "DireccionEntrega";
            obser.DataPropertyName = "Observaciones";
            metodoPago.DataPropertyName = "MetodoPago";
            estado.DataPropertyName = "Estado";
        }

        // =========== CARGAR LISTA DE PEDIDOS (SP_ListarPedidos) ===========
        private void CargarPedidos()
        {
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_ListarPedidos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = DBNull.Value; // Todos
                    cmd.Parameters.Add("@EstadoFiltro", SqlDbType.NVarChar, 50).Value = "Todos";

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    tablaPedidos = new DataTable();
                    da.Fill(tablaPedidos);

                    dataGridView1.DataSource = tablaPedidos;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los pedidos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========== FILTRO LOCAL POR ESTADO ===========
        private void AplicarFiltroEstado(string estado)
        {
            if (tablaPedidos == null) return;
            DataView vista = tablaPedidos.DefaultView;

            vista.RowFilter = string.IsNullOrEmpty(estado)
                ? string.Empty
                : $"ISNULL(Estado,'') = '{estado.Replace("'", "''")}'";

            dataGridView1.DataSource = vista;
        }

        // =========== ACTUALIZAR ESTADO EN BD (SP_ActualizarEstadoPedido) ===========
        private bool ActualizarEstadoPedidoEnBD(int idPedido, string nuevoEstado)
        {
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_ActualizarEstadoPedido", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = idPedido;
                    cmd.Parameters.Add("@NuevoEstado", SqlDbType.NVarChar, 20).Value = nuevoEstado ?? string.Empty;

                    cn.Open();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el estado del pedido: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // =========== CARGAR DETALLE (SP_ObtenerDetallePedido) ===========
        // Llena el FlowLayoutPanel con tarjetas de productos
        private void CargarDetallePedido(int idPedido)
        {
            try
            {
                if (flpDetalle == null) return;

                flpDetalle.SuspendLayout();
                flpDetalle.Controls.Clear();

                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_ObtenerDetallePedido", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = idPedido;

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        bool hayFilas = false;

                        while (dr.Read())
                        {
                            hayFilas = true;

                            // Coinciden con tu BD (Productos y DetallePedidos)
                            string nombreProd = SafeToString(dr["Nombre"], "Producto");
                            int cantidad = SafeToInt(dr["Cantidad"], 0);
                            decimal precioUnit = SafeToDecimal(dr["PrecioUnitario"], 0m);
                            decimal totalLinea = cantidad * precioUnit;
                            string rutaImagen = SafeToString(dr["ImagenURL"], "");

                            // Tarjeta del producto
                            var card = new Panel
                            {
                                Width = 420,
                                Height = 120,
                                BorderStyle = BorderStyle.FixedSingle,
                                BackColor = Color.White,
                                Margin = new Padding(6)
                            };

                            // Imagen (izquierda)
                            var pb = new PictureBox
                            {
                                Width = 110,
                                Dock = DockStyle.Left,
                                SizeMode = PictureBoxSizeMode.Zoom,
                                BackColor = Color.White
                            };

                            if (!string.IsNullOrWhiteSpace(rutaImagen) && File.Exists(rutaImagen))
                            {
                                if (pb.Image != null)
                                {
                                    pb.Image.Dispose();
                                    pb.Image = null;
                                }
                                pb.Image = Image.FromFile(rutaImagen);
                            }
                            else
                            {
                                pb.Image = GetPlaceholderImage(); // placeholder si no existe
                            }

                            // Textos (derecha)
                            var panelTextos = new Panel
                            {
                                Dock = DockStyle.Fill,
                                BackColor = Color.White,
                                Padding = new Padding(8)
                            };

                            var lblNombre = new Label
                            {
                                Text = nombreProd,
                                Font = new Font("Arial", 11, FontStyle.Bold),
                                AutoSize = false,
                                Height = 24,
                                Dock = DockStyle.Top
                            };

                            var lblCantidad = new Label
                            {
                                Text = $"Cantidad: {cantidad}",
                                AutoSize = false,
                                Height = 20,
                                Dock = DockStyle.Top
                            };

                            var lblPrecioU = new Label
                            {
                                Text = $"Precio: $ {precioUnit.ToString("0.00")}",
                                AutoSize = false,
                                Height = 20,
                                Dock = DockStyle.Top
                            };

                            var lblTotalLinea = new Label
                            {
                                Text = $"Total línea: $ {totalLinea.ToString("0.00")}",
                                AutoSize = false,
                                Height = 24,
                                Dock = DockStyle.Top,
                                ForeColor = ColorTranslator.FromHtml("#dd5807"),
                                Font = new Font("Constantia", 11, FontStyle.Bold)
                            };

                            panelTextos.Controls.Add(lblTotalLinea);
                            panelTextos.Controls.Add(lblPrecioU);
                            panelTextos.Controls.Add(lblCantidad);
                            panelTextos.Controls.Add(lblNombre);

                            card.Controls.Add(panelTextos);
                            card.Controls.Add(pb);

                            flpDetalle.Controls.Add(card);
                        }

                        if (!hayFilas)
                        {
                            flpDetalle.Controls.Add(new Label
                            {
                                Text = "Este pedido no tiene productos.",
                                AutoSize = true,
                                ForeColor = Color.Gray,
                                Padding = new Padding(4),
                                Margin = new Padding(8)
                            });
                        }
                    }
                }

                flpDetalle.ResumeLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos del pedido: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==== Helpers seguros ====
        private static string SafeToString(object value, string defaultValue = "")
        {
            return (value == null || value == DBNull.Value) ? defaultValue : value.ToString();
        }

        private static int SafeToInt(object value, int defaultValue = 0)
        {
            if (value == null || value == DBNull.Value) return defaultValue;
            try { return Convert.ToInt32(value); } catch { return defaultValue; }
        }

        private static decimal SafeToDecimal(object value, decimal defaultValue = 0m)
        {
            if (value == null || value == DBNull.Value) return defaultValue;
            try { return Convert.ToDecimal(value); } catch { return defaultValue; }
        }

        private string ObtenerSiguienteEstado(string estadoActual)
        {
            estadoActual = (estadoActual ?? "").Trim();
            if (estadoActual.Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
                return "En Preparacion";
            if (estadoActual.Equals("En Preparacion", StringComparison.OrdinalIgnoreCase))
                return "Completado";
            return estadoActual;
        }

        // =========== Click en celdas del grid ===========
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var fila = dataGridView1.Rows[e.RowIndex];
            var colClic = dataGridView1.Columns[e.ColumnIndex];

            var drv = fila.DataBoundItem as DataRowView;
            if (drv == null) return;

            bool esColVerDetalle = string.Equals(colClic.Name, "detalle", StringComparison.OrdinalIgnoreCase);
            bool esColAccionEstado = string.Equals(colClic.Name, "accion", StringComparison.OrdinalIgnoreCase);

            if (!esColVerDetalle && !esColAccionEstado)
                return;

            int idPedido = 0;
            if (drv.Row.Table.Columns.Contains("IdPedido") && drv["IdPedido"] != DBNull.Value)
                idPedido = SafeToInt(drv["IdPedido"], 0);
            if (idPedido <= 0) return;

            // Cambiar estado
            if (esColAccionEstado)
            {
                string estadoActual = drv.Row.Table.Columns.Contains("Estado") && drv["Estado"] != DBNull.Value
                    ? drv["Estado"].ToString().Trim()
                    : "";

                string nuevoEstado = ObtenerSiguienteEstado(estadoActual);
                if (nuevoEstado != estadoActual && ActualizarEstadoPedidoEnBD(idPedido, nuevoEstado))
                {
                    drv["Estado"] = nuevoEstado;

                    if (plVerPedido.Visible && lblNumeP.Text == $"#{idPedido}")
                        lblResulEstado.Text = nuevoEstado;
                }
                return;
            }

            // Ver detalle
            if (esColVerDetalle)
            {
                lblNumeP.Text = $"#{idPedido}";

                string nombreCli = "-----";
                if (drv.Row.Table.Columns.Contains("NombreCompleto") && drv["NombreCompleto"] != DBNull.Value)
                    nombreCli = drv["NombreCompleto"].ToString().Trim();
                lblNameClient.Text = string.IsNullOrWhiteSpace(nombreCli) ? "-----" : nombreCli;

                decimal totalPedido = 0m;
                if (drv.Row.Table.Columns.Contains("Total") && drv["Total"] != DBNull.Value)
                    totalPedido = SafeToDecimal(drv["Total"], 0m);
                lblTotal.Text = "$ " + totalPedido.ToString("0.00");

                string metodo = drv.Row.Table.Columns.Contains("MetodoPago") && drv["MetodoPago"] != DBNull.Value
                    ? drv["MetodoPago"].ToString()
                    : "-----";
                lblPago.Text = metodo;

                string estadoTxt = drv.Row.Table.Columns.Contains("Estado") && drv["Estado"] != DBNull.Value
                    ? drv["Estado"].ToString()
                    : "-----";
                lblResulEstado.Text = estadoTxt;

                // Llenar tarjetas en el FlowLayoutPanel
                CargarDetallePedido(idPedido);

                // Mostrar panel
                plVerPedido.Visible = true;
                plVerPedido.BringToFront();
            }
        }

        private void btnCerrarDetalle_Click(object sender, EventArgs e)
        {
            plVerPedido.Visible = false;
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
                FormLogin frmLogin = Application.OpenForms
                    .OfType<FormLogin>()
                    .FirstOrDefault() ?? new FormLogin();
                frmLogin.Show();
                this.Close();
            }
        }

        private void btnTodosAd_Click(object sender, EventArgs e) => AplicarFiltroEstado(null);
        private void btnPendiente_Click(object sender, EventArgs e) => AplicarFiltroEstado("Pendiente");
        private void btnPreparado_Click(object sender, EventArgs e) => AplicarFiltroEstado("En Preparacion");
        private void btnCompletado_Click(object sender, EventArgs e) => AplicarFiltroEstado("Completado");

        // Placeholder de imagen si no existe ruta
        private Image GetPlaceholderImage()
        {
            Bitmap bmp = new Bitmap(110, 110);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.LightGray);
                using (var brush = new SolidBrush(Color.DimGray))
                using (var font = new Font("Arial", 9, FontStyle.Bold))
                {
                    string text = "Sin imagen";
                    var size = g.MeasureString(text, font);
                    g.DrawString(text, font, brush,
                        (bmp.Width - size.Width) / 2f,
                        (bmp.Height - size.Height) / 2f);
                }
            }
            return bmp;
        }
    }
}
