
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
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
        }

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

        private void MostrarProductosEnPaneles(DataTable productos)
        {
            flpProductos.Controls.Clear();
            foreach (DataRow row in productos.Rows)
            {
                Panel panel = new Panel
                {
                    Width = 200,
                    Height = 250,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10)
                };

                Label lblNombre = new Label
                {
                    Text = row["Nombre"].ToString(),
                    Dock = DockStyle.Top,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Height = 30
                };

                Label lblPrecio = new Label
                {
                    Text = "$ " + Convert.ToDecimal(row["PrecioVenta"]).ToString("0.00"),
                    Dock = DockStyle.Top,
                    Height = 25
                };

                PictureBox pb = new PictureBox
                {
                    Height = 120,
                    Dock = DockStyle.Top,
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                string imgPath = row["ImagenURL"].ToString();
                if (!string.IsNullOrWhiteSpace(imgPath) && File.Exists(imgPath))
                    pb.Image = Image.FromFile(imgPath);

                Button btnAgregar = new Button
                {
                    Text = "Agregar al carrito",
                    Dock = DockStyle.Bottom,
                    Tag = row
                };
                btnAgregar.Click += BtnAgregar_Click;

                panel.Controls.Add(btnAgregar);
                panel.Controls.Add(lblPrecio);
                panel.Controls.Add(lblNombre);
                panel.Controls.Add(pb);
                flpProductos.Controls.Add(panel);
            }
        }

        private void FiltrarPorCategoria(string categoria)
        {
            if (_productos == null) return;
            DataView dv = new DataView(_productos);
            dv.RowFilter = $"Categoria LIKE '%{categoria}%'";
            MostrarProductosEnPaneles(dv.ToTable());
        }


        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            DataRow producto = btn.Tag as DataRow;
            if (producto != null)
            {
                int idProducto = Convert.ToInt32(producto["IdProducto"]);
                decimal precioBase = Convert.ToDecimal(producto["PrecioVenta"]);
                int stockDisponible = Convert.ToInt32(producto["Stock"]); // ✅ Stock desde la BD

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
                    Text = "$ " + precioBase.ToString("0.00"),
                    Location = new Point(10, 40),
                    Width = 80
                };

                Label lblAcumulado = new Label
                {
                    Text = "$ " + precioBase.ToString("0.00"),
                    Location = new Point(100, 40),
                    Width = 80,
                    ForeColor = ColorTranslator.FromHtml("#fef9c2"),
                    BackColor = Color.Transparent,
                    Font = new Font("Constantia", 12)
                };

                NumericUpDown nudCantidad = new NumericUpDown
                {
                    Minimum = 1,
                    Maximum = stockDisponible, // ✅ Limita al stock disponible
                    Value = 1,
                    Location = new Point(200, 35),
                    Width = 50
                };
                nudCantidad.ValueChanged += (s, ev) =>
                {
                    decimal total = precioBase * nudCantidad.Value;
                    lblAcumulado.Text = "$ " + total.ToString("0.00");
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
        }


        private void ActualizarTotales()
        {
            decimal subtotal = 0;

            foreach (Panel panel in flpPC.Controls)
            {
                var lblAcumulado = panel.Controls.OfType<Label>()
                    .FirstOrDefault(l => l.Location == new Point(100, 40));

                if (lblAcumulado != null)
                {
                    string texto = lblAcumulado.Text.Replace("$", "").Trim();
                    if (decimal.TryParse(texto, out decimal valor))
                    {
                        subtotal += valor;
                    }
                }
            }

            lblVSubtotal.Text = "$ " + subtotal.ToString("0.00");
            decimal itbms = subtotal * 0.07m;
            lblVItbms.Text = "$ " + itbms.ToString("0.00");
            lblVTotal.Text = "$ " + (subtotal + itbms).ToString("0.00");
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


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
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

                    decimal total = decimal.Parse(lblVTotal.Text.Replace("$", "").Trim());
                    cmd.Parameters.AddWithValue("@Total", total);

                    string detalleXML = "<Productos>";
                    foreach (Panel panel in flpPC.Controls)
                    {
                        int idProducto = (int)panel.Tag;
                        var lblPrecio = panel.Controls.OfType<Label>().FirstOrDefault(l => l.Location == new Point(10, 40));
                        var nudCantidad = panel.Controls.OfType<NumericUpDown>().FirstOrDefault();

                        if (lblPrecio != null && nudCantidad != null)
                        {
                            decimal precioUnitario = decimal.Parse(lblPrecio.Text.Replace("$", "").Trim());
                            int cantidad = (int)nudCantidad.Value;

                            detalleXML += $"<Producto><IdProducto>{idProducto}</IdProducto><Cantidad>{cantidad}</Cantidad><PrecioUnitario>{precioUnitario}</PrecioUnitario></Producto>";
                        }
                    }
                    detalleXML += "</Productos>";

                    cmd.Parameters.AddWithValue("@DetalleProductosXML", detalleXML);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pedido registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el pedido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnHistorial_Click(object sender, EventArgs e)
        {
            FormCliHistorial f4 = new FormCliHistorial(idUsuarioActual); // ✅ Pasamos el ID
            f4.Show();
            this.Hide();
        }

    }
}
