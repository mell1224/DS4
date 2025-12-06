
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace Pedidos
{
    public partial class FormCliHistorial : Form
    {
        private int idUsuarioActual;

        // ====== NOMBRES DE SP ======
        // Encabezado: cámbialo si ya tienes el SP creado con otro nombre
        private const string SP_PEDIDO_ENC = "dbo.SP_ObtenerEncabezadoPedido"; // <-- CAMBIAR si aplica
        // Detalle: coincide con lo que nos pasaste
        private const string SP_PEDIDO_DET = "dbo.SP_ObtenerDetallePedido";
        // ============================

        public FormCliHistorial(int idUsuario)
        {
            InitializeComponent();
            idUsuarioActual = idUsuario;
        }

        private void FormCliHistorial_Load_1(object sender, EventArgs e)
        {
            plVerPedidoCli.Visible = false;

            // Conectar eventos por seguridad
            dtgHistorial.CellClick += dtgHistorial_CellClick;
            btnCerrarDetalle.Click += btnCerrarDetalle_Click;

            CargarHistorial();
        }

        private void CargarHistorial()
        {
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SP_ListarPedidos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuarioActual);
                    cmd.Parameters.AddWithValue("@EstadoFiltro", "Todos");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Mantener columnas del diseñador
                    dtgHistorial.AutoGenerateColumns = false;

                    // Mapea columnas del diseñador a los nombres reales del DataTable
                    idPedido.DataPropertyName = "IdPedido";       // Debe existir en el SP_ListarPedidos
                    fecha.DataPropertyName = "FechaPedido";    // "
                    total.DataPropertyName = "Total";          // "
                    estado.DataPropertyName = "Estado";         // "

                    dtgHistorial.DataSource = dt;
                    dtgHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgHistorial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var colAccion = dtgHistorial.Columns["accion"]; // nombre de la columna botón en el diseñador
                if (colAccion != null && e.ColumnIndex == colAccion.Index)
                {
                    // Obtener IdPedido desde la columna mapeada
                    object valId = dtgHistorial.Rows[e.RowIndex].Cells[idPedido.Name].Value;
                    if (valId == null || valId == DBNull.Value)
                    {
                        MessageBox.Show("No se pudo obtener el ID del pedido.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    int idPed = Convert.ToInt32(valId);

                    // Mostrar panel y asegurarlo visible
                    plVerPedidoCli.Visible = true;
                    plVerPedidoCli.BringToFront();

                    if (plVerPedidoCli.Width < 300 || plVerPedidoCli.Height < 200)
                        plVerPedidoCli.Size = new Size(548, 544);
                    if (plVerPedidoCli.Left < 0 || plVerPedidoCli.Top < 0)
                        plVerPedidoCli.Location = new Point(256, 81);

                    // Cargar detalle (y encabezado)
                    CargarDetallePedido(idPed, dtgHistorial.Rows[e.RowIndex]);
                }
            }
        }

        /// <summary>
        /// Carga encabezado y detalle del pedido. Si el SP de encabezado no existe,
        /// rellena desde la fila de la grilla como fallback.
        /// </summary>
        private void CargarDetallePedido(int idPedido, DataGridViewRow filaOrigen)
        {
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                {
                    cn.Open();

                    bool encabezadoOk = false;

                    // ===== Encabezado (intenta SP; si falla, usa fallback) =====
                    try
                    {
                        using (SqlCommand cmdEnc = new SqlCommand(SP_PEDIDO_ENC, cn))
                        {
                            cmdEnc.CommandType = CommandType.StoredProcedure;
                            cmdEnc.Parameters.AddWithValue("@IdPedido", idPedido);

                            using (SqlDataReader rd = cmdEnc.ExecuteReader())
                            {
                                if (rd.Read())
                                {
                                    // Ajusta los nombres de campo a tu SP real
                                    // Ejemplos típicos: NumeroPedido, ClienteNombre, Total, Estado, MetodoPago
                                    lblNumeP.Text = rd.GetOrdinal("NumeroPedido") >= 0 ? rd["NumeroPedido"].ToString() : idPedido.ToString();
                                    lblNameClient.Text = rd.GetOrdinal("ClienteNombre") >= 0 ? rd["ClienteNombre"].ToString() : "--";
                                    lblTotal.Text = rd.GetOrdinal("Total") >= 0 ? Convert.ToDecimal(rd["Total"]).ToString("$ 0.00") : GetCellDecimal(filaOrigen, total.Name).ToString("$ 0.00");
                                    lblResulEstado.Text = rd.GetOrdinal("Estado") >= 0 ? rd["Estado"].ToString() : GetCellString(filaOrigen, estado.Name);
                                    lblPago.Text = rd.GetOrdinal("MetodoPago") >= 0 ? rd["MetodoPago"].ToString() : "--";
                                    encabezadoOk = true;
                                }
                            }
                        }
                    }
                    catch (SqlException sqlEx) when (sqlEx.Number == 2812 /*SP no encontrado*/)
                    {
                        // Ignoramos y usamos fallback abajo
                        encabezadoOk = false;
                    }
                    catch
                    {
                        encabezadoOk = false;
                    }

                    // ===== Fallback del encabezado (desde la fila de la grilla) =====
                    if (!encabezadoOk)
                    {
                        lblNumeP.Text = idPedido.ToString();
                        lblNameClient.Text = "--"; // si quieres, carga el nombre desde otra tabla/variable
                        lblTotal.Text = GetCellDecimal(filaOrigen, total.Name).ToString("$ 0.00");
                        lblResulEstado.Text = GetCellString(filaOrigen, estado.Name);
                        lblPago.Text = "--";
                    }

                    // ===== Detalle de productos (usa tu SP modificado) =====
                    plProductoDetalle.Controls.Clear();

                    using (SqlCommand cmdDet = new SqlCommand(SP_PEDIDO_DET, cn))
                    {
                        cmdDet.CommandType = CommandType.StoredProcedure;
                        cmdDet.Parameters.AddWithValue("@IdPedido", idPedido);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmdDet))
                        {
                            DataTable dtProd = new DataTable();
                            da.Fill(dtProd);

                            int y = 10;
                            decimal sumTotal = 0m;

                            foreach (DataRow row in dtProd.Rows)
                            {
                                string nombre = Convert.ToString(row["Nombre"]);
                                int cantidad = Convert.ToInt32(row["Cantidad"]);
                                decimal precioUnit = Convert.ToDecimal(row["PrecioUnitario"]);
                                string imagenUrl = row.Table.Columns.Contains("ImagenURL")
                                                   ? Convert.ToString(row["ImagenURL"])
                                                   : null;

                                decimal precioTotal = cantidad * precioUnit;
                                sumTotal += precioTotal;

                                // Renderizado de item
                                var pb = new PictureBox
                                {
                                    Location = new System.Drawing.Point(12, y),
                                    Size = new System.Drawing.Size(55, 41),
                                    SizeMode = PictureBoxSizeMode.Zoom
                                };
                               
                                // pero maneja excepciones por si no hay red/archivo.
                                if (!string.IsNullOrWhiteSpace(imagenUrl))
                                {
                                    try
                                    {
                                        pb.Load(imagenUrl);
                                    }
                                    catch
                                    {
                                        // Si falla, no rompemos la UI
                                        pb.Image = null;
                                    }
                                }

                                var lblNombre = new Label
                                {
                                    Location = new System.Drawing.Point(92, y),
                                    AutoSize = true,
                                    Text = nombre
                                };

                                var lblCant = new Label
                                {
                                    Location = new System.Drawing.Point(92, y + 22),
                                    AutoSize = true,
                                    Text = "Cantidad: " + cantidad
                                };

                                var lblPrecio = new Label
                                {
                                    Location = new System.Drawing.Point(431, y + 22),
                                    AutoSize = true,
                                    Text = precioTotal.ToString("$ 0.00")
                                };

                                plProductoDetalle.Controls.Add(pb);
                                plProductoDetalle.Controls.Add(lblNombre);
                                plProductoDetalle.Controls.Add(lblCant);
                                plProductoDetalle.Controls.Add(lblPrecio);

                                y += 60;
                            }

                            // Totales
                            lblPrecioTot.Text = sumTotal.ToString("$ 0.00");
                            lblTotSelProd.Text = "Total";
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 2812) // Could not find stored procedure
                {
                    MessageBox.Show(
                        "No se encontró uno de los procedimientos almacenados.\n\n" +
                        $"Encabezado: {SP_PEDIDO_ENC}\nDetalle: {SP_PEDIDO_DET}\n\n" +
                        " Verifica el nombre del SP de encabezado o usa el fallback desde la grilla (ya aplicado).",
                        "Procedimiento inexistente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                else
                {
                    MessageBox.Show("Error al cargar detalle: " + sqlEx.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                plVerPedidoCli.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalle: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                plVerPedidoCli.Visible = false;
            }
        }

        private string GetCellString(DataGridViewRow row, string colName)
        {
            var val = row.Cells[colName]?.Value;
            return (val == null || val == DBNull.Value) ? "--" : val.ToString();
        }

        private decimal GetCellDecimal(DataGridViewRow row, string colName)
        {
            var val = row.Cells[colName]?.Value;
            if (val == null || val == DBNull.Value) return 0m;
            decimal d;
            return decimal.TryParse(val.ToString(), out d) ? d : 0m;
        }

        private void btnCerrarDetalle_Click(object sender, EventArgs e)
        {
            plVerPedidoCli.Visible = false;
        }

        private void btnAtrasH_Click(object sender, EventArgs e)
        {
            FormCliente formCliente = new FormCliente(idUsuarioActual);
            formCliente.Show();
            this.Hide();
        }
    }
}
