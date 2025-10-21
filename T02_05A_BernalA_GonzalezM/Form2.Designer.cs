namespace Camiones
{
    partial class Form2
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
            this.lstResu = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstResu
            // 
            this.lstResu.FormattingEnabled = true;
            this.lstResu.Location = new System.Drawing.Point(29, 22);
            this.lstResu.Name = "lstResu";
            this.lstResu.Size = new System.Drawing.Size(916, 589);
            this.lstResu.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(239)))), ((int)(((byte)(216)))));
            this.ClientSize = new System.Drawing.Size(976, 643);
            this.Controls.Add(this.lstResu);
            this.Name = "Form2";
            this.Text = "Registro de Carga";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox lstResu;
    }
}