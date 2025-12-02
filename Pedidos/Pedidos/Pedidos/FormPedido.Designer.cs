namespace Pedidos
{
    partial class FormPedido
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dirEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metodoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.accion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tsP = new System.Windows.Forms.ToolStrip();
            this.lblPLAdmin = new System.Windows.Forms.Label();
            this.lblPAdm = new System.Windows.Forms.Label();
            this.plEstadoP = new System.Windows.Forms.Panel();
            this.btnPreparado = new System.Windows.Forms.Button();
            this.btnPendiente = new System.Windows.Forms.Button();
            this.btnCompletado = new System.Windows.Forms.Button();
            this.btnTodosAd = new System.Windows.Forms.Button();
            this.lblTitGestionP = new System.Windows.Forms.Label();
            this.plVerPedido = new System.Windows.Forms.Panel();
            this.btnCerrarDetalle = new System.Windows.Forms.Button();
            this.lblNumeP = new System.Windows.Forms.Label();
            this.lblPrecioTot = new System.Windows.Forms.Label();
            this.lblTotSelProd = new System.Windows.Forms.Label();
            this.plProductoDetalle = new System.Windows.Forms.Panel();
            this.pbProducto = new System.Windows.Forms.PictureBox();
            this.lblPrecioProd = new System.Windows.Forms.Label();
            this.lblCantidadProd = new System.Windows.Forms.Label();
            this.lblNProduct = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.plMetodoP = new System.Windows.Forms.Panel();
            this.lblPago = new System.Windows.Forms.Label();
            this.lblTitPago = new System.Windows.Forms.Label();
            this.plEstado = new System.Windows.Forms.Panel();
            this.lblResulEstado = new System.Windows.Forms.Label();
            this.lblTitEstado = new System.Windows.Forms.Label();
            this.plTotal = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTitTotal = new System.Windows.Forms.Label();
            this.plClient = new System.Windows.Forms.Panel();
            this.lblNameClient = new System.Windows.Forms.Label();
            this.lblTitClien = new System.Windows.Forms.Label();
            this.lblDetalleP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.plEstadoP.SuspendLayout();
            this.plVerPedido.SuspendLayout();
            this.plProductoDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProducto)).BeginInit();
            this.plMetodoP.SuspendLayout();
            this.plEstado.SuspendLayout();
            this.plTotal.SuspendLayout();
            this.plClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPedido,
            this.fecha,
            this.nomCli,
            this.total,
            this.dirEntrega,
            this.obser,
            this.metodoPago,
            this.estado,
            this.detalle,
            this.accion});
            this.dataGridView1.Location = new System.Drawing.Point(-5, 193);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1604, 670);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // idPedido
            // 
            this.idPedido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idPedido.HeaderText = "ID Pedido";
            this.idPedido.MinimumWidth = 6;
            this.idPedido.Name = "idPedido";
            // 
            // fecha
            // 
            this.fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fecha.HeaderText = "Fecha Pedido";
            this.fecha.MinimumWidth = 6;
            this.fecha.Name = "fecha";
            // 
            // nomCli
            // 
            this.nomCli.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomCli.HeaderText = "Nombre Cliente";
            this.nomCli.MinimumWidth = 6;
            this.nomCli.Name = "nomCli";
            // 
            // total
            // 
            this.total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.total.HeaderText = "Total";
            this.total.MinimumWidth = 6;
            this.total.Name = "total";
            // 
            // dirEntrega
            // 
            this.dirEntrega.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dirEntrega.HeaderText = "Dirección Entrega";
            this.dirEntrega.MinimumWidth = 6;
            this.dirEntrega.Name = "dirEntrega";
            // 
            // obser
            // 
            this.obser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.obser.HeaderText = "Observaciones";
            this.obser.MinimumWidth = 6;
            this.obser.Name = "obser";
            // 
            // metodoPago
            // 
            this.metodoPago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.metodoPago.HeaderText = "Método Pago";
            this.metodoPago.MinimumWidth = 6;
            this.metodoPago.Name = "metodoPago";
            // 
            // estado
            // 
            this.estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.estado.HeaderText = "Estado";
            this.estado.MinimumWidth = 6;
            this.estado.Name = "estado";
            // 
            // detalle
            // 
            this.detalle.HeaderText = "Detalle del Pedido";
            this.detalle.MinimumWidth = 6;
            this.detalle.Name = "detalle";
            this.detalle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.detalle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.detalle.Width = 125;
            // 
            // accion
            // 
            this.accion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.accion.HeaderText = "Acción";
            this.accion.MinimumWidth = 6;
            this.accion.Name = "accion";
            this.accion.UseColumnTextForButtonValue = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.tsP);
            this.panel1.Controls.Add(this.lblPLAdmin);
            this.panel1.Location = new System.Drawing.Point(-5, -2);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1604, 116);
            this.panel1.TabIndex = 7;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(1523, 26);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(49, 46);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "➡️";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tsP
            // 
            this.tsP.Dock = System.Windows.Forms.DockStyle.None;
            this.tsP.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsP.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsP.Location = new System.Drawing.Point(120, 66);
            this.tsP.Name = "tsP";
            this.tsP.Size = new System.Drawing.Size(112, 25);
            this.tsP.TabIndex = 5;
            this.tsP.Text = "toolStrip1";
            // 
            // lblPLAdmin
            // 
            this.lblPLAdmin.AutoSize = true;
            this.lblPLAdmin.Font = new System.Drawing.Font("Constantia", 14.25F);
            this.lblPLAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(143)))), ((int)(((byte)(14)))));
            this.lblPLAdmin.Location = new System.Drawing.Point(115, 26);
            this.lblPLAdmin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPLAdmin.Name = "lblPLAdmin";
            this.lblPLAdmin.Size = new System.Drawing.Size(399, 29);
            this.lblPLAdmin.TabIndex = 4;
            this.lblPLAdmin.Text = "Panel Administrador - Family Bakery";
            // 
            // lblPAdm
            // 
            this.lblPAdm.AutoSize = true;
            this.lblPAdm.Font = new System.Drawing.Font("Constantia", 14.25F);
            this.lblPAdm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(103)))), ((int)(((byte)(4)))));
            this.lblPAdm.Location = new System.Drawing.Point(86, 21);
            this.lblPAdm.Name = "lblPAdm";
            this.lblPAdm.Size = new System.Drawing.Size(309, 23);
            this.lblPAdm.TabIndex = 4;
            this.lblPAdm.Text = "Panel Administrador - Family Bakery";
            // 
            // plEstadoP
            // 
            this.plEstadoP.BackColor = System.Drawing.Color.White;
            this.plEstadoP.Controls.Add(this.btnPreparado);
            this.plEstadoP.Controls.Add(this.btnPendiente);
            this.plEstadoP.Controls.Add(this.btnCompletado);
            this.plEstadoP.Controls.Add(this.btnTodosAd);
            this.plEstadoP.Location = new System.Drawing.Point(929, 121);
            this.plEstadoP.Margin = new System.Windows.Forms.Padding(4);
            this.plEstadoP.Name = "plEstadoP";
            this.plEstadoP.Size = new System.Drawing.Size(648, 49);
            this.plEstadoP.TabIndex = 9;
            // 
            // btnPreparado
            // 
            this.btnPreparado.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreparado.Location = new System.Drawing.Point(327, 7);
            this.btnPreparado.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreparado.Name = "btnPreparado";
            this.btnPreparado.Size = new System.Drawing.Size(153, 38);
            this.btnPreparado.TabIndex = 3;
            this.btnPreparado.Text = "Preparado";
            this.btnPreparado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreparado.UseVisualStyleBackColor = true;
            this.btnPreparado.Click += new System.EventHandler(this.btnPreparado_Click);
            // 
            // btnPendiente
            // 
            this.btnPendiente.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPendiente.Location = new System.Drawing.Point(165, 7);
            this.btnPendiente.Margin = new System.Windows.Forms.Padding(4);
            this.btnPendiente.Name = "btnPendiente";
            this.btnPendiente.Size = new System.Drawing.Size(153, 38);
            this.btnPendiente.TabIndex = 2;
            this.btnPendiente.Text = "Pendiente";
            this.btnPendiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPendiente.UseVisualStyleBackColor = true;
            this.btnPendiente.Click += new System.EventHandler(this.btnPendiente_Click);
            // 
            // btnCompletado
            // 
            this.btnCompletado.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompletado.Location = new System.Drawing.Point(488, 7);
            this.btnCompletado.Margin = new System.Windows.Forms.Padding(4);
            this.btnCompletado.Name = "btnCompletado";
            this.btnCompletado.Size = new System.Drawing.Size(153, 38);
            this.btnCompletado.TabIndex = 1;
            this.btnCompletado.Text = "Completado";
            this.btnCompletado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompletado.UseVisualStyleBackColor = true;
            this.btnCompletado.Click += new System.EventHandler(this.btnCompletado_Click);
            // 
            // btnTodosAd
            // 
            this.btnTodosAd.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTodosAd.Location = new System.Drawing.Point(4, 7);
            this.btnTodosAd.Margin = new System.Windows.Forms.Padding(4);
            this.btnTodosAd.Name = "btnTodosAd";
            this.btnTodosAd.Size = new System.Drawing.Size(153, 38);
            this.btnTodosAd.TabIndex = 0;
            this.btnTodosAd.Text = "Todos";
            this.btnTodosAd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTodosAd.UseVisualStyleBackColor = true;
            this.btnTodosAd.Click += new System.EventHandler(this.btnTodosAd_Click);
            // 
            // lblTitGestionP
            // 
            this.lblTitGestionP.AutoSize = true;
            this.lblTitGestionP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitGestionP.Location = new System.Drawing.Point(4, 121);
            this.lblTitGestionP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitGestionP.Name = "lblTitGestionP";
            this.lblTitGestionP.Size = new System.Drawing.Size(226, 29);
            this.lblTitGestionP.TabIndex = 10;
            this.lblTitGestionP.Text = "Gestión de Pedidos";
            // 
            // plVerPedido
            // 
            this.plVerPedido.BackColor = System.Drawing.Color.White;
            this.plVerPedido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plVerPedido.Controls.Add(this.btnCerrarDetalle);
            this.plVerPedido.Controls.Add(this.lblNumeP);
            this.plVerPedido.Controls.Add(this.lblPrecioTot);
            this.plVerPedido.Controls.Add(this.lblTotSelProd);
            this.plVerPedido.Controls.Add(this.plProductoDetalle);
            this.plVerPedido.Controls.Add(this.lblProduct);
            this.plVerPedido.Controls.Add(this.plMetodoP);
            this.plVerPedido.Controls.Add(this.plEstado);
            this.plVerPedido.Controls.Add(this.plTotal);
            this.plVerPedido.Controls.Add(this.plClient);
            this.plVerPedido.Controls.Add(this.lblDetalleP);
            this.plVerPedido.Location = new System.Drawing.Point(372, 125);
            this.plVerPedido.Margin = new System.Windows.Forms.Padding(4);
            this.plVerPedido.Name = "plVerPedido";
            this.plVerPedido.Size = new System.Drawing.Size(729, 613);
            this.plVerPedido.TabIndex = 11;
            // 
            // btnCerrarDetalle
            // 
            this.btnCerrarDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarDetalle.Location = new System.Drawing.Point(676, 14);
            this.btnCerrarDetalle.Name = "btnCerrarDetalle";
            this.btnCerrarDetalle.Size = new System.Drawing.Size(37, 31);
            this.btnCerrarDetalle.TabIndex = 10;
            this.btnCerrarDetalle.Text = "X";
            this.btnCerrarDetalle.UseVisualStyleBackColor = true;
            this.btnCerrarDetalle.Click += new System.EventHandler(this.btnCerrarDetalle_Click);
            // 
            // lblNumeP
            // 
            this.lblNumeP.AutoSize = true;
            this.lblNumeP.Location = new System.Drawing.Point(164, 28);
            this.lblNumeP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumeP.Name = "lblNumeP";
            this.lblNumeP.Size = new System.Drawing.Size(42, 16);
            this.lblNumeP.TabIndex = 2;
            this.lblNumeP.Text = "#0000";
            // 
            // lblPrecioTot
            // 
            this.lblPrecioTot.AutoSize = true;
            this.lblPrecioTot.Location = new System.Drawing.Point(607, 571);
            this.lblPrecioTot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrecioTot.Name = "lblPrecioTot";
            this.lblPrecioTot.Size = new System.Drawing.Size(48, 16);
            this.lblPrecioTot.TabIndex = 8;
            this.lblPrecioTot.Text = "$ 00.00";
            // 
            // lblTotSelProd
            // 
            this.lblTotSelProd.AutoSize = true;
            this.lblTotSelProd.Location = new System.Drawing.Point(32, 571);
            this.lblTotSelProd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotSelProd.Name = "lblTotSelProd";
            this.lblTotSelProd.Size = new System.Drawing.Size(38, 16);
            this.lblTotSelProd.TabIndex = 7;
            this.lblTotSelProd.Text = "Total";
            // 
            // plProductoDetalle
            // 
            this.plProductoDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.plProductoDetalle.Controls.Add(this.pbProducto);
            this.plProductoDetalle.Controls.Add(this.lblPrecioProd);
            this.plProductoDetalle.Controls.Add(this.lblCantidadProd);
            this.plProductoDetalle.Controls.Add(this.lblNProduct);
            this.plProductoDetalle.Location = new System.Drawing.Point(28, 369);
            this.plProductoDetalle.Margin = new System.Windows.Forms.Padding(4);
            this.plProductoDetalle.Name = "plProductoDetalle";
            this.plProductoDetalle.Size = new System.Drawing.Size(656, 86);
            this.plProductoDetalle.TabIndex = 5;
            // 
            // pbProducto
            // 
            this.pbProducto.Location = new System.Drawing.Point(16, 18);
            this.pbProducto.Margin = new System.Windows.Forms.Padding(4);
            this.pbProducto.Name = "pbProducto";
            this.pbProducto.Size = new System.Drawing.Size(73, 50);
            this.pbProducto.TabIndex = 3;
            this.pbProducto.TabStop = false;
            // 
            // lblPrecioProd
            // 
            this.lblPrecioProd.AutoSize = true;
            this.lblPrecioProd.Location = new System.Drawing.Point(575, 53);
            this.lblPrecioProd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrecioProd.Name = "lblPrecioProd";
            this.lblPrecioProd.Size = new System.Drawing.Size(41, 16);
            this.lblPrecioProd.TabIndex = 2;
            this.lblPrecioProd.Text = "$ 0.00";
            // 
            // lblCantidadProd
            // 
            this.lblCantidadProd.AutoSize = true;
            this.lblCantidadProd.Location = new System.Drawing.Point(123, 53);
            this.lblCantidadProd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantidadProd.Name = "lblCantidadProd";
            this.lblCantidadProd.Size = new System.Drawing.Size(74, 16);
            this.lblCantidadProd.TabIndex = 1;
            this.lblCantidadProd.Text = "Cantidad: 0";
            // 
            // lblNProduct
            // 
            this.lblNProduct.AutoSize = true;
            this.lblNProduct.Location = new System.Drawing.Point(123, 18);
            this.lblNProduct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNProduct.Name = "lblNProduct";
            this.lblNProduct.Size = new System.Drawing.Size(113, 16);
            this.lblNProduct.TabIndex = 0;
            this.lblNProduct.Text = "Nombre Producto";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(31, 336);
            this.lblProduct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(68, 16);
            this.lblProduct.TabIndex = 4;
            this.lblProduct.Text = "Productos";
            // 
            // plMetodoP
            // 
            this.plMetodoP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.plMetodoP.Controls.Add(this.lblPago);
            this.plMetodoP.Controls.Add(this.lblTitPago);
            this.plMetodoP.Location = new System.Drawing.Point(373, 186);
            this.plMetodoP.Margin = new System.Windows.Forms.Padding(4);
            this.plMetodoP.Name = "plMetodoP";
            this.plMetodoP.Size = new System.Drawing.Size(297, 100);
            this.plMetodoP.TabIndex = 3;
            // 
            // lblPago
            // 
            this.lblPago.AutoSize = true;
            this.lblPago.Location = new System.Drawing.Point(12, 62);
            this.lblPago.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPago.Name = "lblPago";
            this.lblPago.Size = new System.Drawing.Size(39, 16);
            this.lblPago.TabIndex = 1;
            this.lblPago.Text = "--------";
            // 
            // lblTitPago
            // 
            this.lblTitPago.AutoSize = true;
            this.lblTitPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(101)))));
            this.lblTitPago.Location = new System.Drawing.Point(12, 26);
            this.lblTitPago.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitPago.Name = "lblTitPago";
            this.lblTitPago.Size = new System.Drawing.Size(108, 16);
            this.lblTitPago.TabIndex = 0;
            this.lblTitPago.Text = "Método de Pago";
            // 
            // plEstado
            // 
            this.plEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.plEstado.Controls.Add(this.lblResulEstado);
            this.plEstado.Controls.Add(this.lblTitEstado);
            this.plEstado.Location = new System.Drawing.Point(28, 186);
            this.plEstado.Margin = new System.Windows.Forms.Padding(4);
            this.plEstado.Name = "plEstado";
            this.plEstado.Size = new System.Drawing.Size(297, 100);
            this.plEstado.TabIndex = 2;
            // 
            // lblResulEstado
            // 
            this.lblResulEstado.AutoSize = true;
            this.lblResulEstado.Location = new System.Drawing.Point(12, 62);
            this.lblResulEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResulEstado.Name = "lblResulEstado";
            this.lblResulEstado.Size = new System.Drawing.Size(43, 16);
            this.lblResulEstado.TabIndex = 1;
            this.lblResulEstado.Text = "---------";
            // 
            // lblTitEstado
            // 
            this.lblTitEstado.AutoSize = true;
            this.lblTitEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(101)))));
            this.lblTitEstado.Location = new System.Drawing.Point(12, 26);
            this.lblTitEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitEstado.Name = "lblTitEstado";
            this.lblTitEstado.Size = new System.Drawing.Size(50, 16);
            this.lblTitEstado.TabIndex = 0;
            this.lblTitEstado.Text = "Estado";
            // 
            // plTotal
            // 
            this.plTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.plTotal.Controls.Add(this.lblTotal);
            this.plTotal.Controls.Add(this.lblTitTotal);
            this.plTotal.Location = new System.Drawing.Point(373, 64);
            this.plTotal.Margin = new System.Windows.Forms.Padding(4);
            this.plTotal.Name = "plTotal";
            this.plTotal.Size = new System.Drawing.Size(297, 100);
            this.plTotal.TabIndex = 2;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(12, 62);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(48, 16);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "$ 00.00";
            // 
            // lblTitTotal
            // 
            this.lblTitTotal.AutoSize = true;
            this.lblTitTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(101)))));
            this.lblTitTotal.Location = new System.Drawing.Point(12, 26);
            this.lblTitTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitTotal.Name = "lblTitTotal";
            this.lblTitTotal.Size = new System.Drawing.Size(38, 16);
            this.lblTitTotal.TabIndex = 0;
            this.lblTitTotal.Text = "Total";
            // 
            // plClient
            // 
            this.plClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.plClient.Controls.Add(this.lblNameClient);
            this.plClient.Controls.Add(this.lblTitClien);
            this.plClient.Location = new System.Drawing.Point(28, 64);
            this.plClient.Margin = new System.Windows.Forms.Padding(4);
            this.plClient.Name = "plClient";
            this.plClient.Size = new System.Drawing.Size(297, 100);
            this.plClient.TabIndex = 1;
            // 
            // lblNameClient
            // 
            this.lblNameClient.AutoSize = true;
            this.lblNameClient.Location = new System.Drawing.Point(12, 62);
            this.lblNameClient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNameClient.Name = "lblNameClient";
            this.lblNameClient.Size = new System.Drawing.Size(56, 16);
            this.lblNameClient.TabIndex = 1;
            this.lblNameClient.Text = "Nombre";
            // 
            // lblTitClien
            // 
            this.lblTitClien.AutoSize = true;
            this.lblTitClien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(101)))));
            this.lblTitClien.Location = new System.Drawing.Point(12, 26);
            this.lblTitClien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitClien.Name = "lblTitClien";
            this.lblTitClien.Size = new System.Drawing.Size(48, 16);
            this.lblTitClien.TabIndex = 0;
            this.lblTitClien.Text = "Cliente";
            // 
            // lblDetalleP
            // 
            this.lblDetalleP.AutoSize = true;
            this.lblDetalleP.Location = new System.Drawing.Point(32, 27);
            this.lblDetalleP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetalleP.Name = "lblDetalleP";
            this.lblDetalleP.Size = new System.Drawing.Size(119, 16);
            this.lblDetalleP.TabIndex = 0;
            this.lblDetalleP.Text = "Detalle del Pedido";
            // 
            // FormPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1665, 849);
            this.Controls.Add(this.plVerPedido);
            this.Controls.Add(this.lblTitGestionP);
            this.Controls.Add(this.plEstadoP);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormPedido";
            this.Text = "FormPedido";
            this.Load += new System.EventHandler(this.FormPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.plEstadoP.ResumeLayout(false);
            this.plVerPedido.ResumeLayout(false);
            this.plVerPedido.PerformLayout();
            this.plProductoDetalle.ResumeLayout(false);
            this.plProductoDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProducto)).EndInit();
            this.plMetodoP.ResumeLayout(false);
            this.plMetodoP.PerformLayout();
            this.plEstado.ResumeLayout(false);
            this.plEstado.PerformLayout();
            this.plTotal.ResumeLayout(false);
            this.plTotal.PerformLayout();
            this.plClient.ResumeLayout(false);
            this.plClient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPLAdmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn dirEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn obser;
        private System.Windows.Forms.DataGridViewTextBoxColumn metodoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewButtonColumn detalle;
        private System.Windows.Forms.DataGridViewButtonColumn accion;
        private System.Windows.Forms.Label lblPAdm;
        private System.Windows.Forms.ToolStrip tsP;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel plEstadoP;
        private System.Windows.Forms.Button btnPreparado;
        private System.Windows.Forms.Button btnPendiente;
        private System.Windows.Forms.Button btnCompletado;
        private System.Windows.Forms.Button btnTodosAd;
        private System.Windows.Forms.Label lblTitGestionP;
        private System.Windows.Forms.Panel plVerPedido;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Panel plMetodoP;
        private System.Windows.Forms.Label lblPago;
        private System.Windows.Forms.Label lblTitPago;
        private System.Windows.Forms.Panel plEstado;
        private System.Windows.Forms.Label lblResulEstado;
        private System.Windows.Forms.Label lblTitEstado;
        private System.Windows.Forms.Panel plTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTitTotal;
        private System.Windows.Forms.Panel plClient;
        private System.Windows.Forms.Label lblNameClient;
        private System.Windows.Forms.Label lblTitClien;
        private System.Windows.Forms.Label lblDetalleP;
        private System.Windows.Forms.Label lblPrecioTot;
        private System.Windows.Forms.Label lblTotSelProd;
        private System.Windows.Forms.Panel plProductoDetalle;
        private System.Windows.Forms.PictureBox pbProducto;
        private System.Windows.Forms.Label lblPrecioProd;
        private System.Windows.Forms.Label lblCantidadProd;
        private System.Windows.Forms.Label lblNProduct;
        private System.Windows.Forms.Label lblNumeP;
        private System.Windows.Forms.Button btnCerrarDetalle;
    }
}
