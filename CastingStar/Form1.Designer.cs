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
            this.components = new System.ComponentModel.Container();
            this.timerEstrella = new System.Windows.Forms.Timer(this.components);
            this.timerTexto = new System.Windows.Forms.Timer(this.components);
            this.lblListo = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.lblSisreg = new System.Windows.Forms.Label();
            this.lblCasting = new System.Windows.Forms.Label();
            this.pictureEstrellaAmarilla = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEstrellaAmarilla)).BeginInit();
            this.SuspendLayout();
            // 
            // timerEstrella
            // 
            this.timerEstrella.Interval = 30;
            this.timerEstrella.Tick += new System.EventHandler(this.timerEstrella_Tick);
            // 
            // timerTexto
            // 
            this.timerTexto.Tick += new System.EventHandler(this.timerTexto_Tick);
            // 
            // lblListo
            // 
            this.lblListo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblListo.AutoSize = true;
            this.lblListo.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListo.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblListo.Location = new System.Drawing.Point(432, 411);
            this.lblListo.Name = "lblListo";
            this.lblListo.Size = new System.Drawing.Size(216, 16);
            this.lblListo.TabIndex = 10;
            this.lblListo.Text = "\"Listo para el próximo casting...\"";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIniciar.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnIniciar.Location = new System.Drawing.Point(468, 359);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(137, 37);
            this.btnIniciar.TabIndex = 9;
            this.btnIniciar.Text = "Iniciar Sistema";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // lblSisreg
            // 
            this.lblSisreg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSisreg.AutoSize = true;
            this.lblSisreg.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSisreg.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSisreg.Location = new System.Drawing.Point(439, 325);
            this.lblSisreg.Name = "lblSisreg";
            this.lblSisreg.Size = new System.Drawing.Size(201, 16);
            this.lblSisreg.TabIndex = 8;
            this.lblSisreg.Text = "Sistema de Registro de Actores";
            // 
            // lblCasting
            // 
            this.lblCasting.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCasting.AutoSize = true;
            this.lblCasting.Font = new System.Drawing.Font("Mongolian Baiti", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCasting.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCasting.Location = new System.Drawing.Point(452, 274);
            this.lblCasting.Name = "lblCasting";
            this.lblCasting.Size = new System.Drawing.Size(183, 37);
            this.lblCasting.TabIndex = 7;
            this.lblCasting.Text = "CastingStar";
            // 
            // pictureEstrellaAmarilla
            // 
            this.pictureEstrellaAmarilla.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureEstrellaAmarilla.Image = global::CastingStar.Properties.Resources.pctEstrella;
            this.pictureEstrellaAmarilla.Location = new System.Drawing.Point(509, 206);
            this.pictureEstrellaAmarilla.Name = "pictureEstrellaAmarilla";
            this.pictureEstrellaAmarilla.Size = new System.Drawing.Size(63, 65);
            this.pictureEstrellaAmarilla.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureEstrellaAmarilla.TabIndex = 6;
            this.pictureEstrellaAmarilla.TabStop = false;
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
            this.Controls.Add(this.pictureEstrellaAmarilla);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEstrellaAmarilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerEstrella;
        private System.Windows.Forms.Timer timerTexto;
        private System.Windows.Forms.Label lblListo;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label lblSisreg;
        private System.Windows.Forms.Label lblCasting;
        private System.Windows.Forms.PictureBox pictureEstrellaAmarilla;
    }
}

