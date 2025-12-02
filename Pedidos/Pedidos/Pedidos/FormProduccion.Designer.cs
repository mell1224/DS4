namespace Pedidos
{
    partial class FormProduccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProduccion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tsP = new System.Windows.Forms.ToolStrip();
            this.lblPLAdmin = new System.Windows.Forms.Label();
            this.plProduccionTit = new System.Windows.Forms.Panel();
            this.lblIntroProduccion = new System.Windows.Forms.Label();
            this.lblTitProduccion = new System.Windows.Forms.Label();
            this.pbProducc = new System.Windows.Forms.PictureBox();
            this.plLote = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.plInfoLote = new System.Windows.Forms.Panel();
            this.lblUniDProd = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.plIngreStock = new System.Windows.Forms.Panel();
            this.lblIngreNec = new System.Windows.Forms.Label();
            this.dtgIngreNecDisp = new System.Windows.Forms.DataGridView();
            this.lblTitSDespProd = new System.Windows.Forms.Label();
            this.btnRegProd = new System.Windows.Forms.Button();
            this.txtObserv = new System.Windows.Forms.TextBox();
            this.lblObserv = new System.Windows.Forms.Label();
            this.nudCantProd = new System.Windows.Forms.NumericUpDown();
            this.lblCantAProducir = new System.Windows.Forms.Label();
            this.plStockActual = new System.Windows.Forms.Panel();
            this.lblPrecUni = new System.Windows.Forms.Label();
            this.lblCostUni = new System.Windows.Forms.Label();
            this.pbStock = new System.Windows.Forms.PictureBox();
            this.lblUnidStock = new System.Windows.Forms.Label();
            this.lblTitStock = new System.Windows.Forms.Label();
            this.cmbSelecProd = new System.Windows.Forms.ComboBox();
            this.lblProdProducir = new System.Windows.Forms.Label();
            this.lblLoteProd = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.plProduccionTit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProducc)).BeginInit();
            this.plLote.SuspendLayout();
            this.plInfoLote.SuspendLayout();
            this.plIngreStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIngreNecDisp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantProd)).BeginInit();
            this.plStockActual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStock)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.tsP);
            this.panel1.Controls.Add(this.lblPLAdmin);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1604, 116);
            this.panel1.TabIndex = 9;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(1523, 26);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.tsP.Size = new System.Drawing.Size(137, 31);
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
            // plProduccionTit
            // 
            this.plProduccionTit.BackColor = System.Drawing.Color.White;
            this.plProduccionTit.Controls.Add(this.lblIntroProduccion);
            this.plProduccionTit.Controls.Add(this.lblTitProduccion);
            this.plProduccionTit.Controls.Add(this.pbProducc);
            this.plProduccionTit.Location = new System.Drawing.Point(1, 113);
            this.plProduccionTit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.plProduccionTit.Name = "plProduccionTit";
            this.plProduccionTit.Size = new System.Drawing.Size(1600, 96);
            this.plProduccionTit.TabIndex = 10;
            // 
            // lblIntroProduccion
            // 
            this.lblIntroProduccion.AutoSize = true;
            this.lblIntroProduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntroProduccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(121)))));
            this.lblIntroProduccion.Location = new System.Drawing.Point(116, 50);
            this.lblIntroProduccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIntroProduccion.Name = "lblIntroProduccion";
            this.lblIntroProduccion.Size = new System.Drawing.Size(347, 18);
            this.lblIntroProduccion.TabIndex = 2;
            this.lblIntroProduccion.Text = "Registrar lotes de producción y actualizar inventario";
            // 
            // lblTitProduccion
            // 
            this.lblTitProduccion.AutoSize = true;
            this.lblTitProduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitProduccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(124)))), ((int)(((byte)(14)))));
            this.lblTitProduccion.Location = new System.Drawing.Point(115, 21);
            this.lblTitProduccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitProduccion.Name = "lblTitProduccion";
            this.lblTitProduccion.Size = new System.Drawing.Size(213, 25);
            this.lblTitProduccion.TabIndex = 1;
            this.lblTitProduccion.Text = "Registro de Producción";
            // 
            // pbProducc
            // 
            this.pbProducc.Location = new System.Drawing.Point(61, 21);
            this.pbProducc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbProducc.Name = "pbProducc";
            this.pbProducc.Size = new System.Drawing.Size(45, 37);
            this.pbProducc.TabIndex = 0;
            this.pbProducc.TabStop = false;
            // 
            // plLote
            // 
            this.plLote.BackColor = System.Drawing.Color.White;
            this.plLote.Controls.Add(this.label1);
            this.plLote.Controls.Add(this.plInfoLote);
            this.plLote.Controls.Add(this.cmbSelecProd);
            this.plLote.Controls.Add(this.lblProdProducir);
            this.plLote.Controls.Add(this.lblLoteProd);
            this.plLote.Location = new System.Drawing.Point(332, 234);
            this.plLote.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.plLote.Name = "plLote";
            this.plLote.Size = new System.Drawing.Size(948, 673);
            this.plLote.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(175, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "*";
            // 
            // plInfoLote
            // 
            this.plInfoLote.Controls.Add(this.lblUniDProd);
            this.plInfoLote.Controls.Add(this.label2);
            this.plInfoLote.Controls.Add(this.plIngreStock);
            this.plInfoLote.Controls.Add(this.lblTitSDespProd);
            this.plInfoLote.Controls.Add(this.btnRegProd);
            this.plInfoLote.Controls.Add(this.txtObserv);
            this.plInfoLote.Controls.Add(this.lblObserv);
            this.plInfoLote.Controls.Add(this.nudCantProd);
            this.plInfoLote.Controls.Add(this.lblCantAProducir);
            this.plInfoLote.Controls.Add(this.plStockActual);
            this.plInfoLote.Location = new System.Drawing.Point(35, 181);
            this.plInfoLote.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.plInfoLote.Name = "plInfoLote";
            this.plInfoLote.Size = new System.Drawing.Size(861, 474);
            this.plInfoLote.TabIndex = 3;
            // 
            // lblUniDProd
            // 
            this.lblUniDProd.AutoSize = true;
            this.lblUniDProd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(125)))), ((int)(((byte)(4)))));
            this.lblUniDProd.Location = new System.Drawing.Point(237, 186);
            this.lblUniDProd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUniDProd.Name = "lblUniDProd";
            this.lblUniDProd.Size = new System.Drawing.Size(73, 16);
            this.lblUniDProd.TabIndex = 9;
            this.lblUniDProd.Text = "0 unidades";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(157, 138);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "*";
            // 
            // plIngreStock
            // 
            this.plIngreStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(253)))), ((int)(((byte)(244)))));
            this.plIngreStock.Controls.Add(this.lblIngreNec);
            this.plIngreStock.Controls.Add(this.dtgIngreNecDisp);
            this.plIngreStock.Location = new System.Drawing.Point(31, 213);
            this.plIngreStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.plIngreStock.Name = "plIngreStock";
            this.plIngreStock.Size = new System.Drawing.Size(801, 123);
            this.plIngreStock.TabIndex = 8;
            // 
            // lblIngreNec
            // 
            this.lblIngreNec.AutoSize = true;
            this.lblIngreNec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(84)))), ((int)(((byte)(114)))));
            this.lblIngreNec.Location = new System.Drawing.Point(23, 11);
            this.lblIngreNec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIngreNec.Name = "lblIngreNec";
            this.lblIngreNec.Size = new System.Drawing.Size(154, 16);
            this.lblIngreNec.TabIndex = 1;
            this.lblIngreNec.Text = "Ingredientes Necesarios";
            // 
            // dtgIngreNecDisp
            // 
            this.dtgIngreNecDisp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIngreNecDisp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dtgIngreNecDisp.Location = new System.Drawing.Point(27, 31);
            this.dtgIngreNecDisp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgIngreNecDisp.Name = "dtgIngreNecDisp";
            this.dtgIngreNecDisp.RowHeadersWidth = 51;
            this.dtgIngreNecDisp.Size = new System.Drawing.Size(751, 76);
            this.dtgIngreNecDisp.TabIndex = 0;
            // 
            // lblTitSDespProd
            // 
            this.lblTitSDespProd.AutoSize = true;
            this.lblTitSDespProd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(101)))));
            this.lblTitSDespProd.Location = new System.Drawing.Point(27, 186);
            this.lblTitSDespProd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitSDespProd.Name = "lblTitSDespProd";
            this.lblTitSDespProd.Size = new System.Drawing.Size(189, 16);
            this.lblTitSDespProd.TabIndex = 7;
            this.lblTitSDespProd.Text = "Stock después de producción:";
            // 
            // btnRegProd
            // 
            this.btnRegProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(103)))), ((int)(((byte)(4)))));
            this.btnRegProd.ForeColor = System.Drawing.Color.White;
            this.btnRegProd.Location = new System.Drawing.Point(509, 417);
            this.btnRegProd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRegProd.Name = "btnRegProd";
            this.btnRegProd.Size = new System.Drawing.Size(323, 41);
            this.btnRegProd.TabIndex = 6;
            this.btnRegProd.Text = "📝 Registrar Producción ";
            this.btnRegProd.UseVisualStyleBackColor = false;
            this.btnRegProd.Click += new System.EventHandler(this.btnRegProd_Click);
            // 
            // txtObserv
            // 
            this.txtObserv.Location = new System.Drawing.Point(31, 366);
            this.txtObserv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtObserv.Multiline = true;
            this.txtObserv.Name = "txtObserv";
            this.txtObserv.Size = new System.Drawing.Size(800, 47);
            this.txtObserv.TabIndex = 5;
            // 
            // lblObserv
            // 
            this.lblObserv.AutoSize = true;
            this.lblObserv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblObserv.Location = new System.Drawing.Point(27, 346);
            this.lblObserv.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblObserv.Name = "lblObserv";
            this.lblObserv.Size = new System.Drawing.Size(164, 16);
            this.lblObserv.TabIndex = 4;
            this.lblObserv.Text = "Observaciones (Opcional)";
            // 
            // nudCantProd
            // 
            this.nudCantProd.Location = new System.Drawing.Point(31, 158);
            this.nudCantProd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudCantProd.Name = "nudCantProd";
            this.nudCantProd.Size = new System.Drawing.Size(801, 22);
            this.nudCantProd.TabIndex = 3;
            // 
            // lblCantAProducir
            // 
            this.lblCantAProducir.AutoSize = true;
            this.lblCantAProducir.Location = new System.Drawing.Point(27, 138);
            this.lblCantAProducir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantAProducir.Name = "lblCantAProducir";
            this.lblCantAProducir.Size = new System.Drawing.Size(128, 16);
            this.lblCantAProducir.TabIndex = 2;
            this.lblCantAProducir.Text = "Cantidad a Producir ";
            // 
            // plStockActual
            // 
            this.plStockActual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.plStockActual.Controls.Add(this.lblPrecUni);
            this.plStockActual.Controls.Add(this.lblCostUni);
            this.plStockActual.Controls.Add(this.pbStock);
            this.plStockActual.Controls.Add(this.lblUnidStock);
            this.plStockActual.Controls.Add(this.lblTitStock);
            this.plStockActual.Location = new System.Drawing.Point(31, 22);
            this.plStockActual.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.plStockActual.Name = "plStockActual";
            this.plStockActual.Size = new System.Drawing.Size(801, 96);
            this.plStockActual.TabIndex = 1;
            // 
            // lblPrecUni
            // 
            this.lblPrecUni.AutoSize = true;
            this.lblPrecUni.Location = new System.Drawing.Point(731, 54);
            this.lblPrecUni.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrecUni.Name = "lblPrecUni";
            this.lblPrecUni.Size = new System.Drawing.Size(38, 16);
            this.lblPrecUni.TabIndex = 4;
            this.lblPrecUni.Text = "$0.00";
            // 
            // lblCostUni
            // 
            this.lblCostUni.AutoSize = true;
            this.lblCostUni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(101)))));
            this.lblCostUni.Location = new System.Drawing.Point(619, 15);
            this.lblCostUni.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCostUni.Name = "lblCostUni";
            this.lblCostUni.Size = new System.Drawing.Size(151, 16);
            this.lblCostUni.TabIndex = 3;
            this.lblCostUni.Text = "Costo Unitario Estimado";
            // 
            // pbStock
            // 
            this.pbStock.BackColor = System.Drawing.Color.Gainsboro;
            this.pbStock.Image = ((System.Drawing.Image)(resources.GetObject("pbStock.Image")));
            this.pbStock.Location = new System.Drawing.Point(27, 50);
            this.pbStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbStock.Name = "pbStock";
            this.pbStock.Size = new System.Drawing.Size(28, 20);
            this.pbStock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStock.TabIndex = 2;
            this.pbStock.TabStop = false;
            // 
            // lblUnidStock
            // 
            this.lblUnidStock.AutoSize = true;
            this.lblUnidStock.Location = new System.Drawing.Point(63, 54);
            this.lblUnidStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUnidStock.Name = "lblUnidStock";
            this.lblUnidStock.Size = new System.Drawing.Size(73, 16);
            this.lblUnidStock.TabIndex = 1;
            this.lblUnidStock.Text = "0 unidades";
            // 
            // lblTitStock
            // 
            this.lblTitStock.AutoSize = true;
            this.lblTitStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(101)))));
            this.lblTitStock.Location = new System.Drawing.Point(23, 15);
            this.lblTitStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitStock.Name = "lblTitStock";
            this.lblTitStock.Size = new System.Drawing.Size(81, 16);
            this.lblTitStock.TabIndex = 0;
            this.lblTitStock.Text = "Stock Actual";
            // 
            // cmbSelecProd
            // 
            this.cmbSelecProd.FormattingEnabled = true;
            this.cmbSelecProd.Location = new System.Drawing.Point(49, 116);
            this.cmbSelecProd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbSelecProd.Name = "cmbSelecProd";
            this.cmbSelecProd.Size = new System.Drawing.Size(833, 24);
            this.cmbSelecProd.TabIndex = 2;
            this.cmbSelecProd.Text = "-- Seleccionar Producto--";
            this.cmbSelecProd.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblProdProducir
            // 
            this.lblProdProducir.AutoSize = true;
            this.lblProdProducir.Location = new System.Drawing.Point(41, 75);
            this.lblProdProducir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProdProducir.Name = "lblProdProducir";
            this.lblProdProducir.Size = new System.Drawing.Size(128, 16);
            this.lblProdProducir.TabIndex = 1;
            this.lblProdProducir.Text = "Producto a Producir ";
            // 
            // lblLoteProd
            // 
            this.lblLoteProd.AutoSize = true;
            this.lblLoteProd.Location = new System.Drawing.Point(41, 28);
            this.lblLoteProd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoteProd.Name = "lblLoteProd";
            this.lblLoteProd.Size = new System.Drawing.Size(166, 16);
            this.lblLoteProd.TabIndex = 0;
            this.lblLoteProd.Text = "Nuevo Lote de Producción";
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Necesario";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Disponible";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Unidad ";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // FormProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 922);
            this.Controls.Add(this.plLote);
            this.Controls.Add(this.plProduccionTit);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormProduccion";
            this.Text = "FormProduccion";
            this.Load += new System.EventHandler(this.FormProduccion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.plProduccionTit.ResumeLayout(false);
            this.plProduccionTit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProducc)).EndInit();
            this.plLote.ResumeLayout(false);
            this.plLote.PerformLayout();
            this.plInfoLote.ResumeLayout(false);
            this.plInfoLote.PerformLayout();
            this.plIngreStock.ResumeLayout(false);
            this.plIngreStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIngreNecDisp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantProd)).EndInit();
            this.plStockActual.ResumeLayout(false);
            this.plStockActual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStrip tsP;
        private System.Windows.Forms.Label lblPLAdmin;
        private System.Windows.Forms.Panel plProduccionTit;
        private System.Windows.Forms.Label lblIntroProduccion;
        private System.Windows.Forms.Label lblTitProduccion;
        private System.Windows.Forms.PictureBox pbProducc;
        private System.Windows.Forms.Panel plLote;
        private System.Windows.Forms.ComboBox cmbSelecProd;
        private System.Windows.Forms.Label lblProdProducir;
        private System.Windows.Forms.Label lblLoteProd;
        private System.Windows.Forms.Panel plInfoLote;
        private System.Windows.Forms.Label lblTitStock;
        private System.Windows.Forms.Panel plStockActual;
        private System.Windows.Forms.TextBox txtObserv;
        private System.Windows.Forms.Label lblObserv;
        private System.Windows.Forms.NumericUpDown nudCantProd;
        private System.Windows.Forms.Label lblCantAProducir;
        private System.Windows.Forms.Label lblPrecUni;
        private System.Windows.Forms.Label lblCostUni;
        private System.Windows.Forms.PictureBox pbStock;
        private System.Windows.Forms.Label lblUnidStock;
        private System.Windows.Forms.Button btnRegProd;
        private System.Windows.Forms.Label lblTitSDespProd;
        private System.Windows.Forms.Panel plIngreStock;
        private System.Windows.Forms.DataGridView dtgIngreNecDisp;
        private System.Windows.Forms.Label lblIngreNec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUniDProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}