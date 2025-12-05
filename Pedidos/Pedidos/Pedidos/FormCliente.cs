
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pedidos
{
    public partial class FormCliente : Form
    {
        private DataTable _productos;
        private int idUsuarioActual;

        public FormCliente(int idUsuario)
        {
            InitializeComponent();
            idUsuarioActual = idUsuario;

            SetPlaceholder();
            txtBuscar.Enter += RemovePlaceholder;
            txtBuscar.Leave += SetPlaceholder;

            plTotal.Visible = false;
            pbCarrito.Visible = false;
            plPConfir.Visible = false;

            // Configurar cursores
            btnPostres.Cursor = Cursors.Hand;
            btnSalados.Cursor = Cursors.Hand;
            btnBebidas.Cursor = Cursors.Hand;
            btnPanes.Cursor = Cursors.Hand;
            btnTodos.Cursor = Cursors.Hand;
            btnSalirCarrito.Cursor = Cursors.Hand;
            btnSalir.Cursor = Cursors.Hand;
            btnConfirmar.Cursor = Cursors.Hand;
            btnHistorial.Cursor = Cursors.Hand;
            pbCarrito.Cursor = Cursors.Hand;
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            CargarProductos();

            // FLP: comportamiento agradable
            flpProductos.AutoScroll = true;
            flpProductos.WrapContents = true;
            flpProductos.FlowDirection = FlowDirection.LeftToRight;
        }

        // Placeholder del buscador
        private void SetPlaceholder(object sender = null, EventArgs e = null)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = "Buscar productos...";
                txtBuscar.ForeColor = Color.Gray;
            }
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar productos...")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;
            }
        }

        private void ResetButtonStyles()
        {
            btnPostres.BackColor = Color.White;
            btnPostres.ForeColor = SystemColors.ControlText;

            btnSalados.BackColor = Color.White;
            btnSalados.ForeColor = SystemColors.ControlText;

            btnBebidas.BackColor = Color.White;
            btnBebidas.ForeColor = SystemColors.ControlText;

            btnPanes.BackColor = Color.White;
            btnPanes.ForeColor = SystemColors.ControlText;

            btnTodos.BackColor = Color.White;
            btnTodos.ForeColor = SystemColors.ControlText;
        }

        private void btnPostres_Click(object sender, EventArgs e)
        {
            ResetButtonStyles();
            btnPostres.BackColor = ColorTranslator.FromHtml("#d96704");
            btnPostres.ForeColor = Color.White;
            FiltrarPorCategoria("Postres");
        }

        private void btnSalados_Click(object sender, EventArgs e)
        {
            ResetButtonStyles();
            btnSalados.BackColor = ColorTranslator.FromHtml("#d96704");
            btnSalados.ForeColor = Color.White;
            FiltrarPorCategoria("Salados");
        }

        private void btnBebidas_Click(object sender, EventArgs e)
        {
            ResetButtonStyles();
            btnBebidas.BackColor = ColorTranslator.FromHtml("#d96704");
            btnBebidas.ForeColor = Color.White;
            FiltrarPorCategoria("Bebidas");
        }

        private void btnPanes_Click(object sender, EventArgs e)
        {
            ResetButtonStyles();
            btnPanes.BackColor = ColorTranslator.FromHtml("#d96704");
            btnPanes.ForeColor = Color.White;
            FiltrarPorCategoria("Panes");
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            ResetButtonStyles();
            btnTodos.BackColor = ColorTranslator.FromHtml("#d96704");
            btnTodos.ForeColor = Color.White;
            MostrarProductosEnPaneles(_productos);
        }

        // Cargar productos desde SP
        private void CargarProductos()
        {
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_ListarProductos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    _productos = new DataTable();
                    da.Fill(_productos);
                }

                MostrarProductosEnPaneles(_productos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Muestra solo productos con Stock > 0 y oculta el FLP si no hay ninguno disponible.
        /// </summary>
        private void MostrarProductosEnPaneles(DataTable productos)
        {
            // Filtrar productos con stock
            DataRow[] rowsConStock = productos.Select("Stock > 0");

            // Si no hay productos, ocultar FLP y salir
            if (rowsConStock.Length == 0)
            {
                flpProductos.Visible = false;
                flpProductos.Controls.Clear();
                return;
            }

            // Hay productos con stock: mostrar FLP
            flpProductos.Visible = true;

            // Mejora visual y rendimiento al agregar muchos controles
            flpProductos.SuspendLayout();
            flpProductos.Controls.Clear();

            foreach (DataRow row in rowsConStock)
            {
                // --- Card contenedora ---
                Panel panel = new Panel
                {
                    Width = 200,
                    Height = 260,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10),
                    BackColor = Color.White
                };

                // --- PictureBox (imagen del producto) ---
                PictureBox pb = new PictureBox
                {
                    Height = 120,
                    Dock = DockStyle.Top,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.White,
                    WaitOnLoad = false
                };

                string imgPath = row["ImagenURL"]?.ToString();

                // Usa ImageLocation para rutas/URLs; placeholder si no existe
                if (!string.IsNullOrWhiteSpace(imgPath))
                {
                    if (File.Exists(imgPath) || Uri.IsWellFormedUriString(imgPath, UriKind.Absolute))
                        pb.ImageLocation = imgPath;
                    else
                        pb.Image = GetPlaceholderImage();
                }
                else
                {
                    pb.Image = GetPlaceholderImage();
                }

                // --- Nombre ---
                Label lblNombre = new Label
                {
                    Text = row["Nombre"].ToString(),
                    Dock = DockStyle.Top,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Height = 30
                };

                // --- Precio ---
                Label lblPrecio = new Label
                {
                    Name = "lblPrecio",
                    Text = "$ " + Convert.ToDecimal(row["PrecioVenta"]).ToString("0.00", CultureInfo.InvariantCulture),
                    Dock = DockStyle.Top,
                    Height = 25
                };

                // --- Botón Agregar (habilitado solo si hay stock) ---
                int stockDisponible = Convert.ToInt32(row["Stock"]);
                Button btnAgregar = new Button
                {
                    Text = "Agregar al carrito",
                    Dock = DockStyle.Bottom,
                    Tag = row,
                    Enabled = stockDisponible > 0
                };
                btnAgregar.Click += BtnAgregar_Click;

                // Orden de agregado (primero imagen, luego textos, al final botón)
                panel.Controls.Add(btnAgregar);
                panel.Controls.Add(lblPrecio);
                panel.Controls.Add(lblNombre);
                panel.Controls.Add(pb);

                // Añadir al FlowLayoutPanel
                flpProductos.Controls.Add(panel);
            }

            flpProductos.ResumeLayout();
        }

        // Placeholder simple para imagen cuando no existe la ruta
        private Image GetPlaceholderImage()
        {
            // Genera un rectángulo gris con el texto "Sin imagen"
            Bitmap bmp = new Bitmap(120, 120);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.LightGray);
                using (var brush = new SolidBrush(Color.DimGray))
                using (var font = new Font("Arial", 10, FontStyle.Bold))
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

        /// <summary>
        /// Filtro por categoría respetando Stock > 0 y ocultando FLP si no hay productos.
        /// </summary>
        private void FiltrarPorCategoria(string categoria)
        {
            if (_productos == null) return;

            DataView dv = new DataView(_productos);
            dv.RowFilter = $"Categoria LIKE '%{categoria}%' AND Stock > 0";

            if (dv.Count == 0)
            {
                flpProductos.Visible = false;
                flpProductos.Controls.Clear();
                return;
            }

            MostrarProductosEnPaneles(dv.ToTable());
        }

        // Handler para Agregar al Carrito
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            DataRow producto = btn.Tag as DataRow;
            if (producto == null) return;

            int idProducto = Convert.ToInt32(producto["IdProducto"]);
            decimal precioBase = Convert.ToDecimal(producto["PrecioVenta"]);
            int stockDisponible = Convert.ToInt32(producto["Stock"]); // desde la BD

            // Si no hay stock, evitar agregar
            if (stockDisponible <= 0)
            {
                MessageBox.Show("Este producto no tiene stock disponible.", "Sin stock",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // --- Panel del ítem en el carrito ---
            Panel panelCarrito = new Panel
            {
                Width = 328,
                Height = 115,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5),
                Tag = idProducto
            };

            Label lblProd = new Label
            {
                Text = producto["Nombre"].ToString(),
                Location = new Point(10, 10),
                Width = 150,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Label lblPrecio = new Label
            {
                Name = "lblPrecioCarrito",
                Text = "$ " + precioBase.ToString("0.00", CultureInfo.InvariantCulture),
                Location = new Point(10, 40),
                Width = 80
            };

            Label lblAcumulado = new Label
            {
                Name = "lblAcumulado",
                Text = "$ " + precioBase.ToString("0.00", CultureInfo.InvariantCulture),
                Location = new Point(100, 40),
                Width = 80,
                ForeColor = ColorTranslator.FromHtml("#fef9c2"),
                BackColor = Color.Transparent,
                Font = new Font("Constantia", 12)
            };

            // NumericUpDown seguro con límite de stock
            NumericUpDown nudCantidad = new NumericUpDown
            {
                Location = new Point(200, 35),
                Width = 50
            };

            // Con stock: rango 1..stockDisponible y valor inicial 1
            nudCantidad.Minimum = 1;
            nudCantidad.Maximum = stockDisponible;
            nudCantidad.Value = 1;
            nudCantidad.Enabled = true;

            nudCantidad.ValueChanged += (s, ev) =>
            {
                // Asegurar que Value esté dentro del rango luego de cambios de stock
                if (nudCantidad.Value > nudCantidad.Maximum)
                    nudCantidad.Value = nudCantidad.Maximum;
                if (nudCantidad.Value < nudCantidad.Minimum)
                    nudCantidad.Value = nudCantidad.Minimum;

                decimal total = precioBase * nudCantidad.Value;
                lblAcumulado.Text = "$ " + total.ToString("0.00", CultureInfo.InvariantCulture);
                ActualizarTotales();
            };

            Label lblStockInfo = new Label
            {
                Text = $"Stock: {stockDisponible}",
                Location = new Point(10, 70),
                Width = 150,
                ForeColor = Color.Gray
            };

            Button btnEliminar = new Button
            {
                Text = "Eliminar",
                Location = new Point(200, 70),
                Width = 80
            };
            btnEliminar.Click += (s, ev) =>
            {
                flpPC.Controls.Remove(panelCarrito);
                ActualizarTotales();
                if (flpPC.Controls.Count == 0)
                {
                    plTotal.Visible = false;
                    pbCarrito.Visible = false;
                }
            };

            panelCarrito.Controls.Add(lblProd);
            panelCarrito.Controls.Add(lblPrecio);
            panelCarrito.Controls.Add(lblAcumulado);
            panelCarrito.Controls.Add(nudCantidad);
            panelCarrito.Controls.Add(lblStockInfo);
            panelCarrito.Controls.Add(btnEliminar);

            flpPC.Controls.Add(panelCarrito);
            pbCarrito.Visible = true;
            ActualizarTotales();
        }

        // Totales del carrito
        private void ActualizarTotales()
        {
            decimal subtotal = 0;

            foreach (Panel panel in flpPC.Controls)
            {
                var lblAcumulado = panel.Controls.OfType<Label>()
                    .FirstOrDefault(l => l.Name == "lblAcumulado");

                if (lblAcumulado != null)
                {
                    string texto = lblAcumulado.Text.Replace("$", "").Trim();
                    if (decimal.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
                    {
                        subtotal += valor;
                    }
                }
            }

            lblVSubtotal.Text = "$ " + subtotal.ToString("0.00", CultureInfo.InvariantCulture);
            decimal itbms = subtotal * 0.07m;
            lblVItbms.Text = "$ " + itbms.ToString("0.00", CultureInfo.InvariantCulture);
            lblVTotal.Text = "$ " + (subtotal + itbms).ToString("0.00", CultureInfo.InvariantCulture);
        }

        private void pbCarrito_Click(object sender, EventArgs e)
        {
            plTotal.Visible = true;
            plTotal.Focus();
        }

        private void btnSalirCarrito_Click(object sender, EventArgs e)
        {
            plTotal.Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin f1 = new FormLogin();
            f1.Show();
        }

        // Confirmar pedido: construcción robusta del XML y ejecución del SP
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Ocultar vista para confirmación
            flpPC.Visible = false;
            lblDir.Visible = false;
            txtDir.Visible = false;
            lblObser.Visible = false;
            txtObservaciones.Visible = false;
            plMetodo.Visible = false;
            plPedidoTotal.Visible = false;
            plPConfir.Visible = true;

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_CrearPedido", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuarioActual);
                    cmd.Parameters.AddWithValue("@DireccionEntrega", txtDir.Text.Trim());
                    cmd.Parameters.AddWithValue("@Observaciones", txtObservaciones.Text.Trim());
                    cmd.Parameters.AddWithValue("@MetodoPago", rbEfectivo.Checked ? "Efectivo" : "Tarjeta");

                    // Parseo seguro del total
                    decimal total;
                    string totalText = lblVTotal.Text?.Replace("$", "").Trim();
                    if (!decimal.TryParse(totalText, NumberStyles.Any, CultureInfo.InvariantCulture, out total))
                    {
                        MessageBox.Show("No se pudo leer el total del pedido. Verifica los importes.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    cmd.Parameters.AddWithValue("@Total", total);

                    // Si no hay items en el carrito, avisar
                    if (flpPC.Controls.Count == 0)
                    {
                        MessageBox.Show("No hay productos en el carrito para confirmar.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Construir XML de detalle de forma segura
                    var sb = new StringBuilder();
                    sb.Append("<Productos>");

                    foreach (Control ctrl in flpPC.Controls)
                    {
                        if (ctrl is Panel panel)
                        {
                            // ID de producto desde Tag
                            int idProducto;
                            if (panel.Tag == null || !int.TryParse(panel.Tag.ToString(), out idProducto))
                            {
                                // si el panel no tiene ID válido, se ignora
                                continue;
                            }

                            // Obtener label precio y NumericUpDown cantidad
                            var lblPrecio = panel.Controls.OfType<Label>()
                                .FirstOrDefault(l => l.Name == "lblPrecioCarrito");
                            var nudCantidad = panel.Controls.OfType<NumericUpDown>().FirstOrDefault();

                            if (lblPrecio == null || nudCantidad == null)
                                continue;

                            // Precio unitario robusto
                            decimal precioUnitario;
                            string puText = lblPrecio.Text?.Replace("$", "").Trim();
                            if (!decimal.TryParse(puText, NumberStyles.Any, CultureInfo.InvariantCulture, out precioUnitario))
                            {
                                MessageBox.Show($"Precio inválido en el producto ID {idProducto}.", "Validación",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            int cantidad = (int)nudCantidad.Value;
                            if (cantidad <= 0)
                            {
                                MessageBox.Show($"Cantidad inválida en el producto ID {idProducto}.", "Validación",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            sb.Append($"<Producto><IdProducto>{idProducto}</IdProducto><Cantidad>{cantidad}</Cantidad><PrecioUnitario>{precioUnitario.ToString(CultureInfo.InvariantCulture)}</PrecioUnitario></Producto>");
                        }
                    }

                    sb.Append("</Productos>");
                    string detalleXML = sb.ToString();

                    cmd.Parameters.AddWithValue("@DetalleProductosXML", detalleXML);

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Pedido registrado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el pedido: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            FormCliHistorial f4 = new FormCliHistorial(idUsuarioActual); // Pasamos el ID
            f4.Show();
            this.Hide();
        }
    }
}
