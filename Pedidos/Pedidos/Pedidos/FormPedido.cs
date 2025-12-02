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

        public FormPedido()
        {
            InitializeComponent();

            plVerPedido.Visible = false;

            // Configurar menú superior
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
            ConfigurarColumnas();
            CargarPedidos();
        }

        private void ConfigurarColumnas()
        {
            dataGridView1.AutoGenerateColumns = false;

            idPedido.DataPropertyName = "IdPedido";
            fecha.DataPropertyName = "FechaPedido";
            nomCli.DataPropertyName = "NombreCompleto";
            total.DataPropertyName = "Total";
            dirEntrega.DataPropertyName = "DireccionEntrega";
            obser.DataPropertyName = "Observaciones";
            metodoPago.DataPropertyName = "MetodoPago";
            estado.DataPropertyName = "Estado";
        }

        // ======================================================
        //  CARGAR LISTA DE PEDIDOS (SP_ListarPedidos)
        // ======================================================
        private void CargarPedidos()
        {
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_ListarPedidos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    tablaPedidos = new DataTable();
                    da.Fill(tablaPedidos);

                    dataGridView1.DataSource = tablaPedidos;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los pedidos: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        // ======================================================
        //  APLICAR FILTRO LOCAL DE ESTADO
        // ======================================================
        private void AplicarFiltroEstado(string estado)
        {
            if (tablaPedidos == null) return;

            DataView vista = tablaPedidos.DefaultView;
            vista.RowFilter = string.IsNullOrEmpty(estado)
                ? string.Empty
                : $"Estado = '{estado.Replace("'", "''")}'";

            dataGridView1.DataSource = vista;
        }

        // ======================================================
        //  ACTUALIZAR ESTADO DEL PEDIDO (SP_ActualizarEstadoPedido)
        // ======================================================
        private bool ActualizarEstadoPedidoEnBD(int idPedido, string nuevoEstado)
        {
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_ActualizarEstadoPedido", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPedido", idPedido);
                    cmd.Parameters.AddWithValue("@Estado", nuevoEstado);

                    cn.Open();
                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el estado del pedido: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }
        }

        // ======================================================
        //  CARGAR DETALLE DEL PEDIDO (SP_ObtenerDetallePedido)
        // ======================================================
        private void CargarDetallePedido(int idPedido)
        {
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_ObtenerDetallePedido", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPedido", idPedido);

                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            lblNProduct.Text = dr["Nombre"].ToString();

                            int cantidad = Convert.ToInt32(dr["Cantidad"]);
                            lblCantidadProd.Text = "Cantidad: " + cantidad;

                            decimal precioUnitario = Convert.ToDecimal(dr["PrecioUnitario"]);
                            lblPrecioProd.Text = "$ " + precioUnitario.ToString("0.00");

                            decimal totalLinea = cantidad * precioUnitario;
                            lblPrecioTot.Text = "$ " + totalLinea.ToString("0.00");

                            string rutaImagen = dr["ImagenURL"] as string;

                            if (!string.IsNullOrWhiteSpace(rutaImagen) && File.Exists(rutaImagen))
                            {
                                if (pbProducto.Image != null)
                                {
                                    pbProducto.Image.Dispose();
                                    pbProducto.Image = null;
                                }

                                pbProducto.Image = Image.FromFile(rutaImagen);
                                pbProducto.SizeMode = PictureBoxSizeMode.Zoom;
                            }
                            else
                            {
                                pbProducto.Image = null;
                            }
                        }
                        else
                        {
                            lblNProduct.Text = "Nombre Producto";
                            lblCantidadProd.Text = "Cantidad: 0";
                            lblPrecioProd.Text = "$ 0.00";
                            pbProducto.Image = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos del pedido: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
            if (fila.Cells["idPedido"].Value == null) return;

            int idPedido = Convert.ToInt32(fila.Cells["idPedido"].Value);
            string columna = dataGridView1.Columns[e.ColumnIndex].Name;

            if (columna == "accion")
            {
                string estadoActual = (fila.Cells["estado"].Value ?? "").ToString().Trim();
                string nuevoEstado = ObtenerSiguienteEstado(estadoActual);

                if (nuevoEstado != estadoActual && ActualizarEstadoPedidoEnBD(idPedido, nuevoEstado))
                {
                    fila.Cells["estado"].Value = nuevoEstado;
                    if (plVerPedido.Visible && lblNumeP.Text == $"#{idPedido}")
                        lblResulEstado.Text = nuevoEstado;
                }

                return;
            }

            lblNumeP.Text = $"#{idPedido}";
            lblNameClient.Text = (fila.Cells["nomCli"].Value ?? "-----").ToString();

            decimal totalPedido = 0m;
            if (fila.Cells["total"].Value != null && fila.Cells["total"].Value != DBNull.Value)
                totalPedido = Convert.ToDecimal(fila.Cells["total"].Value);

            lblTotal.Text = "$ " + totalPedido.ToString("0.00");
            lblPago.Text = (fila.Cells["metodoPago"].Value ?? "-----").ToString();
            lblResulEstado.Text = (fila.Cells["estado"].Value ?? "-----").ToString();

            CargarDetallePedido(idPedido);
            plVerPedido.Visible = true;
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
    }
}
