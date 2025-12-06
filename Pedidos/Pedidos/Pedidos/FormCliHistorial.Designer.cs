namespace Pedidos
{
    partial class FormCliHistorial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCliHistorial));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAtrasH = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.dtgHistorial = new System.Windows.Forms.DataGridView();
            this.idPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.plVerPedidoCli = new System.Windows.Forms.Panel();
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
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistorial)).BeginInit();
            this.plVerPedidoCli.SuspendLayout();
            this.plProductoDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProducto)).BeginInit();
            this.plMetodoP.SuspendLayout();
            this.plEstado.SuspendLayout();
            this.plTotal.SuspendLayout();
            this.plClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnAtrasH);
            this.panel1.Controls.Add(this.lblCliente);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1203, 61);
            this.panel1.TabIndex = 1;
            // 
            // btnAtrasH
            // 
            this.btnAtrasH.BackColor = System.Drawing.Color.Transparent;
            this.btnAtrasH.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnAtrasH.FlatAppearance.BorderSize = 0;
            this.btnAtrasH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtrasH.Font = new System.Drawing.Font("Constantia", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtrasH.Location = new System.Drawing.Point(45, 8);
            this.btnAtrasH.Name = "btnAtrasH";
            this.btnAtrasH.Size = new System.Drawing.Size(44, 41);
            this.btnAtrasH.TabIndex = 3;
            this.btnAtrasH.Text = "⬅️";
            this.btnAtrasH.UseVisualStyleBackColor = false;
            this.btnAtrasH.Click += new System.EventHandler(this.btnAtrasH_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(86, 21);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(202, 23);
            this.lblCliente.TabIndex = 4;
            this.lblCliente.Text = "Mi Historial de Pedidos";
            // 
            // dtgHistorial
            // 
            this.dtgHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPedido,
            this.fecha,
            this.total,
            this.estado,
            this.accion});
            this.dtgHistorial.Location = new System.Drawing.Point(-1, 54);
            this.dtgHistorial.Name = "dtgHistorial";
            this.dtgHistorial.ReadOnly = true;
            this.dtgHistorial.Size = new System.Drawing.Size(1177, 301);
            this.dtgHistorial.TabIndex = 6;
            // 
            // idPedido
            // 
            this.idPedido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idPedido.HeaderText = "ID Pedido";
            this.idPedido.Name = "idPedido";
            this.idPedido.ReadOnly = true;
            // 
            // fecha
            // 
            this.fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // total
            // 
            this.total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // estado
            // 
            this.estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            // 
            // accion
            // 
            this.accion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.accion.HeaderText = "Acción";
            this.accion.Name = "accion";
            this.accion.ReadOnly = true;
            this.accion.Text = "👁️ Ver Detalle";
            this.accion.UseColumnTextForButtonValue = true;
            // 
            // plVerPedidoCli
            // 
            this.plVerPedidoCli.AutoScroll = true;
            this.plVerPedidoCli.AutoSize = true;
            this.plVerPedidoCli.BackColor = System.Drawing.Color.White;
            this.plVerPedidoCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plVerPedidoCli.Controls.Add(this.btnCerrarDetalle);
            this.plVerPedidoCli.Controls.Add(this.lblNumeP);
            this.plVerPedidoCli.Controls.Add(this.lblPrecioTot);
            this.plVerPedidoCli.Controls.Add(this.lblTotSelProd);
            this.plVerPedidoCli.Controls.Add(this.plProductoDetalle);
            this.plVerPedidoCli.Controls.Add(this.lblProduct);
            this.plVerPedidoCli.Controls.Add(this.plMetodoP);
            this.plVerPedidoCli.Controls.Add(this.plEstado);
            this.plVerPedidoCli.Controls.Add(this.plTotal);
            this.plVerPedidoCli.Controls.Add(this.plClient);
            this.plVerPedidoCli.Controls.Add(this.lblDetalleP);
            this.plVerPedidoCli.Location = new System.Drawing.Point(256, 81);
            this.plVerPedidoCli.Name = "plVerPedidoCli";
            this.plVerPedidoCli.Size = new System.Drawing.Size(548, 544);
            this.plVerPedidoCli.TabIndex = 12;
            // 
            // btnCerrarDetalle
            // 
            this.btnCerrarDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarDetalle.Location = new System.Drawing.Point(507, 11);
            this.btnCerrarDetalle.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrarDetalle.Name = "btnCerrarDetalle";
            this.btnCerrarDetalle.Size = new System.Drawing.Size(28, 25);
            this.btnCerrarDetalle.TabIndex = 10;
            this.btnCerrarDetalle.Text = "X";
            this.btnCerrarDetalle.UseVisualStyleBackColor = true;
            // 
            // lblNumeP
            // 
            this.lblNumeP.AutoSize = true;
            this.lblNumeP.Location = new System.Drawing.Point(123, 23);
            this.lblNumeP.Name = "lblNumeP";
            this.lblNumeP.Size = new System.Drawing.Size(38, 13);
            this.lblNumeP.TabIndex = 2;
            this.lblNumeP.Text = "#0000";
            // 
            // lblPrecioTot
            // 
            this.lblPrecioTot.AutoSize = true;
            this.lblPrecioTot.Location = new System.Drawing.Point(455, 464);
            this.lblPrecioTot.Name = "lblPrecioTot";
            this.lblPrecioTot.Size = new System.Drawing.Size(43, 13);
            this.lblPrecioTot.TabIndex = 8;
            this.lblPrecioTot.Text = "$ 00.00";
            // 
            // lblTotSelProd
            // 
            this.lblTotSelProd.AutoSize = true;
            this.lblTotSelProd.Location = new System.Drawing.Point(24, 464);
            this.lblTotSelProd.Name = "lblTotSelProd";
            this.lblTotSelProd.Size = new System.Drawing.Size(31, 13);
            this.lblTotSelProd.TabIndex = 7;
            this.lblTotSelProd.Text = "Total";
            // 
            // plProductoDetalle
            // 
            this.plProductoDetalle.AutoScroll = true;
            this.plProductoDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.plProductoDetalle.Controls.Add(this.pbProducto);
            this.plProductoDetalle.Controls.Add(this.lblPrecioProd);
            this.plProductoDetalle.Controls.Add(this.lblCantidadProd);
            this.plProductoDetalle.Controls.Add(this.lblNProduct);
            this.plProductoDetalle.Location = new System.Drawing.Point(21, 300);
            this.plProductoDetalle.Name = "plProductoDetalle";
            this.plProductoDetalle.Size = new System.Drawing.Size(492, 69);
            this.plProductoDetalle.TabIndex = 5;
            // 
            // pbProducto
            // 
            this.pbProducto.Location = new System.Drawing.Point(12, 15);
            this.pbProducto.Name = "pbProducto";
            this.pbProducto.Size = new System.Drawing.Size(55, 41);
            this.pbProducto.TabIndex = 3;
            this.pbProducto.TabStop = false;
            // 
            // lblPrecioProd
            // 
            this.lblPrecioProd.AutoSize = true;
            this.lblPrecioProd.Location = new System.Drawing.Point(431, 43);
            this.lblPrecioProd.Name = "lblPrecioProd";
            this.lblPrecioProd.Size = new System.Drawing.Size(37, 13);
            this.lblPrecioProd.TabIndex = 2;
            this.lblPrecioProd.Text = "$ 0.00";
            // 
            // lblCantidadProd
            // 
            this.lblCantidadProd.AutoSize = true;
            this.lblCantidadProd.Location = new System.Drawing.Point(92, 43);
            this.lblCantidadProd.Name = "lblCantidadProd";
            this.lblCantidadProd.Size = new System.Drawing.Size(61, 13);
            this.lblCantidadProd.TabIndex = 1;
            this.lblCantidadProd.Text = "Cantidad: 0";
            // 
            // lblNProduct
            // 
            this.lblNProduct.AutoSize = true;
            this.lblNProduct.Location = new System.Drawing.Point(92, 15);
            this.lblNProduct.Name = "lblNProduct";
            this.lblNProduct.Size = new System.Drawing.Size(90, 13);
            this.lblNProduct.TabIndex = 0;
            this.lblNProduct.Text = "Nombre Producto";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(23, 273);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(55, 13);
            this.lblProduct.TabIndex = 4;
            this.lblProduct.Text = "Productos";
            // 
            // plMetodoP
            // 
            this.plMetodoP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.plMetodoP.Controls.Add(this.lblPago);
            this.plMetodoP.Controls.Add(this.lblTitPago);
            this.plMetodoP.Location = new System.Drawing.Point(280, 151);
            this.plMetodoP.Name = "plMetodoP";
            this.plMetodoP.Size = new System.Drawing.Size(223, 81);
            this.plMetodoP.TabIndex = 3;
            // 
            // lblPago
            // 
            this.lblPago.AutoSize = true;
            this.lblPago.Location = new System.Drawing.Point(9, 50);
            this.lblPago.Name = "lblPago";
            this.lblPago.Size = new System.Drawing.Size(31, 13);
            this.lblPago.TabIndex = 1;
            this.lblPago.Text = "--------";
            // 
            // lblTitPago
            // 
            this.lblTitPago.AutoSize = true;
            this.lblTitPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(101)))));
            this.lblTitPago.Location = new System.Drawing.Point(9, 21);
            this.lblTitPago.Name = "lblTitPago";
            this.lblTitPago.Size = new System.Drawing.Size(86, 13);
            this.lblTitPago.TabIndex = 0;
            this.lblTitPago.Text = "Método de Pago";
            // 
            // plEstado
            // 
            this.plEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.plEstado.Controls.Add(this.lblResulEstado);
            this.plEstado.Controls.Add(this.lblTitEstado);
            this.plEstado.Location = new System.Drawing.Point(21, 151);
            this.plEstado.Name = "plEstado";
            this.plEstado.Size = new System.Drawing.Size(223, 81);
            this.plEstado.TabIndex = 2;
            // 
            // lblResulEstado
            // 
            this.lblResulEstado.AutoSize = true;
            this.lblResulEstado.Location = new System.Drawing.Point(9, 50);
            this.lblResulEstado.Name = "lblResulEstado";
            this.lblResulEstado.Size = new System.Drawing.Size(34, 13);
            this.lblResulEstado.TabIndex = 1;
            this.lblResulEstado.Text = "---------";
            // 
            // lblTitEstado
            // 
            this.lblTitEstado.AutoSize = true;
            this.lblTitEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(101)))));
            this.lblTitEstado.Location = new System.Drawing.Point(9, 21);
            this.lblTitEstado.Name = "lblTitEstado";
            this.lblTitEstado.Size = new System.Drawing.Size(40, 13);
            this.lblTitEstado.TabIndex = 0;
            this.lblTitEstado.Text = "Estado";
            // 
            // plTotal
            // 
            this.plTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.plTotal.Controls.Add(this.lblTotal);
            this.plTotal.Controls.Add(this.lblTitTotal);
            this.plTotal.Location = new System.Drawing.Point(280, 52);
            this.plTotal.Name = "plTotal";
            this.plTotal.Size = new System.Drawing.Size(223, 81);
            this.plTotal.TabIndex = 2;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(9, 50);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(43, 13);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "$ 00.00";
            // 
            // lblTitTotal
            // 
            this.lblTitTotal.AutoSize = true;
            this.lblTitTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(101)))));
            this.lblTitTotal.Location = new System.Drawing.Point(9, 21);
            this.lblTitTotal.Name = "lblTitTotal";
            this.lblTitTotal.Size = new System.Drawing.Size(31, 13);
            this.lblTitTotal.TabIndex = 0;
            this.lblTitTotal.Text = "Total";
            // 
            // plClient
            // 
            this.plClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.plClient.Controls.Add(this.lblNameClient);
            this.plClient.Controls.Add(this.lblTitClien);
            this.plClient.Location = new System.Drawing.Point(21, 52);
            this.plClient.Name = "plClient";
            this.plClient.Size = new System.Drawing.Size(223, 81);
            this.plClient.TabIndex = 1;
            // 
            // lblNameClient
            // 
            this.lblNameClient.AutoSize = true;
            this.lblNameClient.Location = new System.Drawing.Point(9, 50);
            this.lblNameClient.Name = "lblNameClient";
            this.lblNameClient.Size = new System.Drawing.Size(44, 13);
            this.lblNameClient.TabIndex = 1;
            this.lblNameClient.Text = "Nombre";
            // 
            // lblTitClien
            // 
            this.lblTitClien.AutoSize = true;
            this.lblTitClien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(101)))));
            this.lblTitClien.Location = new System.Drawing.Point(9, 21);
            this.lblTitClien.Name = "lblTitClien";
            this.lblTitClien.Size = new System.Drawing.Size(39, 13);
            this.lblTitClien.TabIndex = 0;
            this.lblTitClien.Text = "Cliente";
            // 
            // lblDetalleP
            // 
            this.lblDetalleP.AutoSize = true;
            this.lblDetalleP.Location = new System.Drawing.Point(24, 22);
            this.lblDetalleP.Name = "lblDetalleP";
            this.lblDetalleP.Size = new System.Drawing.Size(93, 13);
            this.lblDetalleP.TabIndex = 0;
            this.lblDetalleP.Text = "Detalle del Pedido";
            // 
            // FormCliHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1197, 692);
            this.Controls.Add(this.plVerPedidoCli);
            this.Controls.Add(this.dtgHistorial);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCliHistorial";
            this.Text = "FormCliHistorial";
            this.Load += new System.EventHandler(this.FormCliHistorial_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistorial)).EndInit();
            this.plVerPedidoCli.ResumeLayout(false);
            this.plVerPedidoCli.PerformLayout();
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

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAtrasH;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.DataGridView dtgHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewButtonColumn accion;
        private System.Windows.Forms.Panel plVerPedidoCli;
        private System.Windows.Forms.Button btnCerrarDetalle;
        private System.Windows.Forms.Label lblNumeP;
        private System.Windows.Forms.Label lblPrecioTot;
        private System.Windows.Forms.Label lblTotSelProd;
        private System.Windows.Forms.Panel plProductoDetalle;
        private System.Windows.Forms.PictureBox pbProducto;
        private System.Windows.Forms.Label lblPrecioProd;
        private System.Windows.Forms.Label lblCantidadProd;
        private System.Windows.Forms.Label lblNProduct;
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
    }
}