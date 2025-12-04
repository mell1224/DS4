namespace Pedidos
{
    partial class FormInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInventario));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tsP = new System.Windows.Forms.ToolStrip();
            this.lblPLAdmin = new System.Windows.Forms.Label();
            this.plGesInventario = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.plProximoV = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblProxV = new System.Windows.Forms.Label();
            this.btnNuevoIng = new System.Windows.Forms.Button();
            this.plStockB = new System.Windows.Forms.Panel();
            this.pbWarning1 = new System.Windows.Forms.PictureBox();
            this.lblIngrediente = new System.Windows.Forms.Label();
            this.lblStockb = new System.Windows.Forms.Label();
            this.lblGestion = new System.Windows.Forms.Label();
            this.dtgInventario = new System.Windows.Forms.DataGridView();
            this.idProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.plGesInventario.SuspendLayout();
            this.plProximoV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.plStockB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarning1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.tsP);
            this.panel1.Controls.Add(this.lblPLAdmin);
            this.panel1.Location = new System.Drawing.Point(2, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1203, 94);
            this.panel1.TabIndex = 8;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(1142, 21);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(37, 37);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "➡️";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // tsP
            // 
            this.tsP.Dock = System.Windows.Forms.DockStyle.None;
            this.tsP.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsP.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsP.Location = new System.Drawing.Point(90, 54);
            this.tsP.Name = "tsP";
            this.tsP.Size = new System.Drawing.Size(111, 25);
            this.tsP.TabIndex = 5;
            this.tsP.Text = "toolStrip1";
            // 
            // lblPLAdmin
            // 
            this.lblPLAdmin.AutoSize = true;
            this.lblPLAdmin.Font = new System.Drawing.Font("Constantia", 14.25F);
            this.lblPLAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(143)))), ((int)(((byte)(14)))));
            this.lblPLAdmin.Location = new System.Drawing.Point(86, 21);
            this.lblPLAdmin.Name = "lblPLAdmin";
            this.lblPLAdmin.Size = new System.Drawing.Size(309, 23);
            this.lblPLAdmin.TabIndex = 4;
            this.lblPLAdmin.Text = "Panel Administrador - Family Bakery";
            // 
            // plGesInventario
            // 
            this.plGesInventario.Controls.Add(this.btnGuardar);
            this.plGesInventario.Controls.Add(this.plProximoV);
            this.plGesInventario.Controls.Add(this.btnNuevoIng);
            this.plGesInventario.Controls.Add(this.plStockB);
            this.plGesInventario.Controls.Add(this.lblGestion);
            this.plGesInventario.Location = new System.Drawing.Point(2, 112);
            this.plGesInventario.Name = "plGesInventario";
            this.plGesInventario.Size = new System.Drawing.Size(1186, 159);
            this.plGesInventario.TabIndex = 9;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(103)))), ((int)(((byte)(4)))));
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(992, 16);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(169, 32);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "💾 Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // plProximoV
            // 
            this.plProximoV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.plProximoV.Controls.Add(this.pictureBox1);
            this.plProximoV.Controls.Add(this.label4);
            this.plProximoV.Controls.Add(this.lblProxV);
            this.plProximoV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(24)))), ((int)(((byte)(61)))));
            this.plProximoV.Location = new System.Drawing.Point(604, 61);
            this.plProximoV.Name = "plProximoV";
            this.plProximoV.Size = new System.Drawing.Size(556, 83);
            this.plProximoV.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(18, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(0)))), ((int)(((byte)(7)))));
            this.label4.Location = new System.Drawing.Point(67, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "0 Ingredientes";
            // 
            // lblProxV
            // 
            this.lblProxV.AutoSize = true;
            this.lblProxV.Location = new System.Drawing.Point(66, 20);
            this.lblProxV.Name = "lblProxV";
            this.lblProxV.Size = new System.Drawing.Size(90, 13);
            this.lblProxV.TabIndex = 0;
            this.lblProxV.Text = "Próximo a Vencer";
            // 
            // btnNuevoIng
            // 
            this.btnNuevoIng.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(103)))), ((int)(((byte)(4)))));
            this.btnNuevoIng.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoIng.ForeColor = System.Drawing.Color.White;
            this.btnNuevoIng.Location = new System.Drawing.Point(817, 16);
            this.btnNuevoIng.Name = "btnNuevoIng";
            this.btnNuevoIng.Size = new System.Drawing.Size(169, 32);
            this.btnNuevoIng.TabIndex = 3;
            this.btnNuevoIng.Text = "+   Nuevo Ingrediente";
            this.btnNuevoIng.UseVisualStyleBackColor = false;
            this.btnNuevoIng.Click += new System.EventHandler(this.btnNuevoIng_Click);
            // 
            // plStockB
            // 
            this.plStockB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.plStockB.Controls.Add(this.pbWarning1);
            this.plStockB.Controls.Add(this.lblIngrediente);
            this.plStockB.Controls.Add(this.lblStockb);
            this.plStockB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(24)))), ((int)(((byte)(61)))));
            this.plStockB.Location = new System.Drawing.Point(14, 61);
            this.plStockB.Name = "plStockB";
            this.plStockB.Size = new System.Drawing.Size(556, 83);
            this.plStockB.TabIndex = 1;
            // 
            // pbWarning1
            // 
            this.pbWarning1.Image = ((System.Drawing.Image)(resources.GetObject("pbWarning1.Image")));
            this.pbWarning1.Location = new System.Drawing.Point(18, 20);
            this.pbWarning1.Name = "pbWarning1";
            this.pbWarning1.Size = new System.Drawing.Size(43, 43);
            this.pbWarning1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbWarning1.TabIndex = 2;
            this.pbWarning1.TabStop = false;
            // 
            // lblIngrediente
            // 
            this.lblIngrediente.AutoSize = true;
            this.lblIngrediente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblIngrediente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngrediente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(0)))), ((int)(((byte)(7)))));
            this.lblIngrediente.Location = new System.Drawing.Point(67, 50);
            this.lblIngrediente.Name = "lblIngrediente";
            this.lblIngrediente.Size = new System.Drawing.Size(85, 15);
            this.lblIngrediente.TabIndex = 1;
            this.lblIngrediente.Text = "0 Ingredientes";
            // 
            // lblStockb
            // 
            this.lblStockb.AutoSize = true;
            this.lblStockb.Location = new System.Drawing.Point(67, 14);
            this.lblStockb.Name = "lblStockb";
            this.lblStockb.Size = new System.Drawing.Size(59, 13);
            this.lblStockb.TabIndex = 0;
            this.lblStockb.Text = "Stock Bajo";
            // 
            // lblGestion
            // 
            this.lblGestion.AutoSize = true;
            this.lblGestion.Location = new System.Drawing.Point(11, 0);
            this.lblGestion.Name = "lblGestion";
            this.lblGestion.Size = new System.Drawing.Size(108, 13);
            this.lblGestion.TabIndex = 0;
            this.lblGestion.Text = "Gestión de Inventario";
            // 
            // dtgInventario
            // 
            this.dtgInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProd,
            this.Nombre,
            this.Cantidad,
            this.Column1,
            this.costU,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dtgInventario.Location = new System.Drawing.Point(2, 277);
            this.dtgInventario.Name = "dtgInventario";
            this.dtgInventario.RowHeadersWidth = 51;
            this.dtgInventario.Size = new System.Drawing.Size(1186, 543);
            this.dtgInventario.TabIndex = 10;
            this.dtgInventario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgInventario_CellContentClick);
            // 
            // idProd
            // 
            this.idProd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idProd.HeaderText = "IdProducto";
            this.idProd.Name = "idProd";
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Unidad";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // costU
            // 
            this.costU.HeaderText = "Costo Unitario";
            this.costU.Name = "costU";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Fecha de Vencimiento";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Editar";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "Eliminar";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // FormInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1200, 749);
            this.Controls.Add(this.dtgInventario);
            this.Controls.Add(this.plGesInventario);
            this.Controls.Add(this.panel1);
            this.Name = "FormInventario";
            this.Text = "FormInventario";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.plGesInventario.ResumeLayout(false);
            this.plGesInventario.PerformLayout();
            this.plProximoV.ResumeLayout(false);
            this.plProximoV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.plStockB.ResumeLayout(false);
            this.plStockB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarning1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInventario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStrip tsP;
        private System.Windows.Forms.Label lblPLAdmin;
        private System.Windows.Forms.Panel plGesInventario;
        private System.Windows.Forms.Label lblGestion;
        private System.Windows.Forms.Panel plStockB;
        private System.Windows.Forms.Label lblIngrediente;
        private System.Windows.Forms.Label lblStockb;
        private System.Windows.Forms.DataGridView dtgInventario;
        private System.Windows.Forms.PictureBox pbWarning1;
        private System.Windows.Forms.Button btnNuevoIng;
        private System.Windows.Forms.Panel plProximoV;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblProxV;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn costU;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
        private System.Windows.Forms.DataGridViewButtonColumn Column5;
    }
}