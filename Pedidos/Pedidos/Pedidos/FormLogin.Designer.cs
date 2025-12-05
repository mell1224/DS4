namespace Pedidos
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.btnInfoP = new System.Windows.Forms.Button();
            this.btnInfoC = new System.Windows.Forms.Button();
            this.lblLog = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDummy = new System.Windows.Forms.Label();
            this.gbLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbLogin
            // 
            this.gbLogin.BackColor = System.Drawing.Color.White;
            this.gbLogin.Controls.Add(this.btnInfoP);
            this.gbLogin.Controls.Add(this.btnInfoC);
            this.gbLogin.Controls.Add(this.lblLog);
            this.gbLogin.Controls.Add(this.btnLogin);
            this.gbLogin.Controls.Add(this.txtPass);
            this.gbLogin.Controls.Add(this.lblPass);
            this.gbLogin.Controls.Add(this.txtCorreo);
            this.gbLogin.Controls.Add(this.lblCorreo);
            this.gbLogin.Controls.Add(this.lblLogin);
            this.gbLogin.Controls.Add(this.pictureBox1);
            this.gbLogin.Location = new System.Drawing.Point(375, 102);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(420, 520);
            this.gbLogin.TabIndex = 0;
            this.gbLogin.TabStop = false;
            // 
            // btnInfoP
            // 
            this.btnInfoP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfoP.Location = new System.Drawing.Point(371, 491);
            this.btnInfoP.Name = "btnInfoP";
            this.btnInfoP.Size = new System.Drawing.Size(43, 23);
            this.btnInfoP.TabIndex = 9;
            this.btnInfoP.Text = "i";
            this.btnInfoP.UseVisualStyleBackColor = true;
            this.btnInfoP.Click += new System.EventHandler(this.btnInfoP_Click);
            // 
            // btnInfoC
            // 
            this.btnInfoC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfoC.Location = new System.Drawing.Point(7, 491);
            this.btnInfoC.Name = "btnInfoC";
            this.btnInfoC.Size = new System.Drawing.Size(43, 23);
            this.btnInfoC.TabIndex = 8;
            this.btnInfoC.Text = "i";
            this.btnInfoC.UseVisualStyleBackColor = true;
            this.btnInfoC.Click += new System.EventHandler(this.btnInfoC_Click);
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(95)))), ((int)(((byte)(0)))));
            this.lblLog.Location = new System.Drawing.Point(136, 455);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(153, 13);
            this.lblLog.TabIndex = 7;
            this.lblLog.Text = "¿No tienes cuenta? Regístrate";
            this.lblLog.Click += new System.EventHandler(this.lblLog_Click_1);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(103)))), ((int)(((byte)(4)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(28, 402);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(371, 36);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Ingresar";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(28, 333);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(371, 20);
            this.txtPass.TabIndex = 5;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(95)))), ((int)(((byte)(0)))));
            this.lblPass.Location = new System.Drawing.Point(24, 309);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(92, 21);
            this.lblPass.TabIndex = 4;
            this.lblPass.Text = "Contraseña";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(28, 252);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(371, 20);
            this.txtCorreo.TabIndex = 3;
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(95)))), ((int)(((byte)(0)))));
            this.lblCorreo.Location = new System.Drawing.Point(24, 228);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(146, 21);
            this.lblCorreo.TabIndex = 2;
            this.lblCorreo.Text = "Correo Electrónico";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(95)))), ((int)(((byte)(0)))));
            this.lblLogin.Location = new System.Drawing.Point(132, 161);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(160, 21);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "Ingresa a tu cuenta";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(157, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblDummy
            // 
            this.lblDummy.AutoSize = true;
            this.lblDummy.Location = new System.Drawing.Point(106, 84);
            this.lblDummy.Name = "lblDummy";
            this.lblDummy.Size = new System.Drawing.Size(0, 13);
            this.lblDummy.TabIndex = 1;
            this.lblDummy.Visible = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(1154, 685);
            this.Controls.Add(this.lblDummy);
            this.Controls.Add(this.gbLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLogin";
            this.Text = "Family Bakery";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Label lblDummy;
        private System.Windows.Forms.Button btnInfoP;
        private System.Windows.Forms.Button btnInfoC;
    }
}

