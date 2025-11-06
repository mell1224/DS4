namespace CastingStar
{
    partial class Form1
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
            this.lblCasting = new System.Windows.Forms.Label();
            this.lblSisreg = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.lblListo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCasting
            // 
            this.lblCasting.AutoSize = true;
            this.lblCasting.Font = new System.Drawing.Font("Mongolian Baiti", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCasting.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCasting.Location = new System.Drawing.Point(439, 302);
            this.lblCasting.Name = "lblCasting";
            this.lblCasting.Size = new System.Drawing.Size(183, 37);
            this.lblCasting.TabIndex = 1;
            this.lblCasting.Text = "CastingStar";
            // 
            // lblSisreg
            // 
            this.lblSisreg.AutoSize = true;
            this.lblSisreg.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSisreg.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSisreg.Location = new System.Drawing.Point(426, 353);
            this.lblSisreg.Name = "lblSisreg";
            this.lblSisreg.Size = new System.Drawing.Size(201, 16);
            this.lblSisreg.TabIndex = 2;
            this.lblSisreg.Text = "Sistema de Registro de Actores";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnIniciar.Location = new System.Drawing.Point(455, 387);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(137, 37);
            this.btnIniciar.TabIndex = 4;
            this.btnIniciar.Text = "Iniciar Sistema";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // lblListo
            // 
            this.lblListo.AutoSize = true;
            this.lblListo.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListo.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblListo.Location = new System.Drawing.Point(419, 439);
            this.lblListo.Name = "lblListo";
            this.lblListo.Size = new System.Drawing.Size(216, 16);
            this.lblListo.TabIndex = 5;
            this.lblListo.Text = "\"Listo para el próximo casting...\"";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CastingStar.Properties.Resources.pctEstrella;
            this.pictureBox1.Location = new System.Drawing.Point(497, 225);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1080, 633);
            this.Controls.Add(this.lblListo);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.lblSisreg);
            this.Controls.Add(this.lblCasting);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCasting;
        private System.Windows.Forms.Label lblSisreg;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label lblListo;
    }
}

