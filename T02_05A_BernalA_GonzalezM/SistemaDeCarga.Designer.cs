namespace T02_05A_BernalA_GonzalezM
{
    partial class SistemaDeCarga
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnReg = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblEActual = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblEst = new System.Windows.Forms.Label();
            this.lblCJ = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.gbDatosCamion = new System.Windows.Forms.Panel();
            this.lblSacos = new System.Windows.Forms.Label();
            this.lblTam = new System.Windows.Forms.Label();
            this.lblCargaInfo = new System.Windows.Forms.Label();
            this.lblCarga = new System.Windows.Forms.Label();
            this.pbCarga = new System.Windows.Forms.ProgressBar();
            this.cmbCap = new System.Windows.Forms.ComboBox();
            this.lblCap = new System.Windows.Forms.Label();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.lblPlaca = new System.Windows.Forms.Label();
            this.lblDCA = new System.Windows.Forms.Label();
            this.txtTransportista = new System.Windows.Forms.TextBox();
            this.lblTransportista = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstRegistro = new System.Windows.Forms.ListBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.gbDatosCamion.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnReg);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.lblEActual);
            this.panel2.Controls.Add(this.nudCantidad);
            this.panel2.Controls.Add(this.lblEst);
            this.panel2.Controls.Add(this.lblCJ);
            this.panel2.Controls.Add(this.lblCantidad);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(678, 157);
            this.panel2.TabIndex = 9;
            // 
            // btnReg
            // 
            this.btnReg.ForeColor = System.Drawing.Color.Black;
            this.btnReg.Location = new System.Drawing.Point(200, 107);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(162, 38);
            this.btnReg.TabIndex = 8;
            this.btnReg.Text = "✅Registrar camión #1";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGreen;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(21, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 38);
            this.button1.TabIndex = 7;
            this.button1.Text = "🚀 Iniciar Jornada";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblEActual
            // 
            this.lblEActual.AutoSize = true;
            this.lblEActual.BackColor = System.Drawing.Color.Maroon;
            this.lblEActual.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEActual.ForeColor = System.Drawing.Color.White;
            this.lblEActual.Location = new System.Drawing.Point(345, 73);
            this.lblEActual.Name = "lblEActual";
            this.lblEActual.Size = new System.Drawing.Size(179, 21);
            this.lblEActual.TabIndex = 6;
            this.lblEActual.Text = "El sistema no está listo.";
            this.lblEActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEActual.Click += new System.EventHandler(this.lblEActual_Click);
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(21, 72);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(289, 25);
            this.nudCantidad.TabIndex = 5;
            this.nudCantidad.ValueChanged += new System.EventHandler(this.nudCantidad_ValueChanged);
            // 
            // lblEst
            // 
            this.lblEst.AutoSize = true;
            this.lblEst.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEst.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblEst.Location = new System.Drawing.Point(345, 48);
            this.lblEst.Name = "lblEst";
            this.lblEst.Size = new System.Drawing.Size(58, 21);
            this.lblEst.TabIndex = 3;
            this.lblEst.Text = "Estado";
            // 
            // lblCJ
            // 
            this.lblCJ.AutoSize = true;
            this.lblCJ.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCJ.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblCJ.Location = new System.Drawing.Point(3, 0);
            this.lblCJ.Name = "lblCJ";
            this.lblCJ.Size = new System.Drawing.Size(238, 21);
            this.lblCJ.TabIndex = 2;
            this.lblCJ.Text = "⚙ Configuración de la Jornada";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblCantidad.Location = new System.Drawing.Point(17, 48);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(259, 21);
            this.lblCantidad.TabIndex = 0;
            this.lblCantidad.Text = "Cantidad de camiones (mínimo 10)";
            // 
            // gbDatosCamion
            // 
            this.gbDatosCamion.AutoScroll = true;
            this.gbDatosCamion.BackColor = System.Drawing.Color.White;
            this.gbDatosCamion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gbDatosCamion.Controls.Add(this.lblSacos);
            this.gbDatosCamion.Controls.Add(this.lblTam);
            this.gbDatosCamion.Controls.Add(this.lblCargaInfo);
            this.gbDatosCamion.Controls.Add(this.lblCarga);
            this.gbDatosCamion.Controls.Add(this.pbCarga);
            this.gbDatosCamion.Controls.Add(this.cmbCap);
            this.gbDatosCamion.Controls.Add(this.lblCap);
            this.gbDatosCamion.Controls.Add(this.txtPlaca);
            this.gbDatosCamion.Controls.Add(this.lblPlaca);
            this.gbDatosCamion.Controls.Add(this.lblDCA);
            this.gbDatosCamion.Controls.Add(this.txtTransportista);
            this.gbDatosCamion.Controls.Add(this.lblTransportista);
            this.gbDatosCamion.Location = new System.Drawing.Point(12, 198);
            this.gbDatosCamion.Name = "gbDatosCamion";
            this.gbDatosCamion.Size = new System.Drawing.Size(678, 203);
            this.gbDatosCamion.TabIndex = 10;
            // 
            // lblSacos
            // 
            this.lblSacos.AutoSize = true;
            this.lblSacos.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblSacos.Location = new System.Drawing.Point(600, 116);
            this.lblSacos.Name = "lblSacos";
            this.lblSacos.Size = new System.Drawing.Size(0, 17);
            this.lblSacos.TabIndex = 11;
            // 
            // lblTam
            // 
            this.lblTam.AutoSize = true;
            this.lblTam.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblTam.Location = new System.Drawing.Point(556, 117);
            this.lblTam.Name = "lblTam";
            this.lblTam.Size = new System.Drawing.Size(0, 17);
            this.lblTam.TabIndex = 10;
            // 
            // lblCargaInfo
            // 
            this.lblCargaInfo.AutoSize = true;
            this.lblCargaInfo.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblCargaInfo.Location = new System.Drawing.Point(547, 116);
            this.lblCargaInfo.Name = "lblCargaInfo";
            this.lblCargaInfo.Size = new System.Drawing.Size(109, 17);
            this.lblCargaInfo.TabIndex = 9;
            this.lblCargaInfo.Text = "0 / 0 kg (0 sacos)";
            this.lblCargaInfo.Click += new System.EventHandler(this.lblCapCam_Click);
            // 
            // lblCarga
            // 
            this.lblCarga.AutoSize = true;
            this.lblCarga.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarga.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblCarga.Location = new System.Drawing.Point(17, 117);
            this.lblCarga.Name = "lblCarga";
            this.lblCarga.Size = new System.Drawing.Size(104, 21);
            this.lblCarga.TabIndex = 8;
            this.lblCarga.Text = "Carga Actual";
            // 
            // pbCarga
            // 
            this.pbCarga.BackColor = System.Drawing.Color.White;
            this.pbCarga.Location = new System.Drawing.Point(21, 141);
            this.pbCarga.Name = "pbCarga";
            this.pbCarga.Size = new System.Drawing.Size(635, 23);
            this.pbCarga.TabIndex = 7;
            this.pbCarga.Click += new System.EventHandler(this.pbCarga_Click);
            // 
            // cmbCap
            // 
            this.cmbCap.FormattingEnabled = true;
            this.cmbCap.Items.AddRange(new object[] {
            "18000",
            "28000"});
            this.cmbCap.Location = new System.Drawing.Point(453, 72);
            this.cmbCap.Name = "cmbCap";
            this.cmbCap.Size = new System.Drawing.Size(167, 25);
            this.cmbCap.TabIndex = 6;
            // 
            // lblCap
            // 
            this.lblCap.AutoSize = true;
            this.lblCap.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCap.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblCap.Location = new System.Drawing.Point(449, 48);
            this.lblCap.Name = "lblCap";
            this.lblCap.Size = new System.Drawing.Size(86, 21);
            this.lblCap.TabIndex = 5;
            this.lblCap.Text = "Capacidad";
            // 
            // txtPlaca
            // 
            this.txtPlaca.Location = new System.Drawing.Point(223, 72);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(172, 25);
            this.txtPlaca.TabIndex = 4;
            // 
            // lblPlaca
            // 
            this.lblPlaca.AutoSize = true;
            this.lblPlaca.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaca.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblPlaca.Location = new System.Drawing.Point(219, 48);
            this.lblPlaca.Name = "lblPlaca";
            this.lblPlaca.Size = new System.Drawing.Size(133, 21);
            this.lblPlaca.TabIndex = 3;
            this.lblPlaca.Text = "Número de Placa";
            // 
            // lblDCA
            // 
            this.lblDCA.AutoSize = true;
            this.lblDCA.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDCA.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblDCA.Location = new System.Drawing.Point(3, 0);
            this.lblDCA.Name = "lblDCA";
            this.lblDCA.Size = new System.Drawing.Size(307, 21);
            this.lblDCA.TabIndex = 2;
            this.lblDCA.Text = "🚚 Datos del Camión Actual (Camión #1)";
            // 
            // txtTransportista
            // 
            this.txtTransportista.Location = new System.Drawing.Point(21, 72);
            this.txtTransportista.Name = "txtTransportista";
            this.txtTransportista.Size = new System.Drawing.Size(155, 25);
            this.txtTransportista.TabIndex = 1;
            this.txtTransportista.TextChanged += new System.EventHandler(this.txtTransportista_TextChanged);
            // 
            // lblTransportista
            // 
            this.lblTransportista.AutoSize = true;
            this.lblTransportista.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransportista.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTransportista.Location = new System.Drawing.Point(17, 48);
            this.lblTransportista.Name = "lblTransportista";
            this.lblTransportista.Size = new System.Drawing.Size(107, 21);
            this.lblTransportista.TabIndex = 0;
            this.lblTransportista.Text = "Transportista";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstRegistro);
            this.groupBox1.Location = new System.Drawing.Point(12, 428);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(678, 164);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // lstRegistro
            // 
            this.lstRegistro.FormattingEnabled = true;
            this.lstRegistro.ItemHeight = 17;
            this.lstRegistro.Location = new System.Drawing.Point(44, 52);
            this.lstRegistro.Name = "lstRegistro";
            this.lstRegistro.Size = new System.Drawing.Size(577, 106);
            this.lstRegistro.TabIndex = 0;
            this.lstRegistro.SelectedIndexChanged += new System.EventHandler(this.lstRegistro_SelectedIndexChanged);
            // 
            // SistemaDeCarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(239)))), ((int)(((byte)(216)))));
            this.ClientSize = new System.Drawing.Size(704, 604);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbDatosCamion);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Yellow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SistemaDeCarga";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador de Carga de Camiones";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.gbDatosCamion.ResumeLayout(false);
            this.gbDatosCamion.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblEst;
        private System.Windows.Forms.Label lblCJ;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label lblEActual;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Panel gbDatosCamion;
        private System.Windows.Forms.Label lblSacos;
        private System.Windows.Forms.Label lblTam;
        private System.Windows.Forms.Label lblCargaInfo;
        private System.Windows.Forms.Label lblCarga;
        private System.Windows.Forms.ProgressBar pbCarga;
        private System.Windows.Forms.ComboBox cmbCap;
        private System.Windows.Forms.Label lblCap;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Label lblPlaca;
        private System.Windows.Forms.Label lblDCA;
        private System.Windows.Forms.TextBox txtTransportista;
        private System.Windows.Forms.Label lblTransportista;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstRegistro;
    }
}

