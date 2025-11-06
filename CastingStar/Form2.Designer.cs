namespace CastingStar
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTitF2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.gbDatosActor = new System.Windows.Forms.GroupBox();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.txtExperiencia = new System.Windows.Forms.TextBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblExperiencia = new System.Windows.Forms.Label();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.lblGenero = new System.Windows.Forms.Label();
            this.lblEdad = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitgb = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.gbTabla = new System.Windows.Forms.GroupBox();
            this.dtgRegistrados = new System.Windows.Forms.DataGridView();
            this.IdActor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Genero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ciudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Experiencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.gbDatosActor.SuspendLayout();
            this.gbTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRegistrados)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblTitF2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-4, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1176, 79);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(3, 78);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1173, 66);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(5, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1170, 60);
            this.panel2.TabIndex = 0;
            // 
            // lblTitF2
            // 
            this.lblTitF2.AutoSize = true;
            this.lblTitF2.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitF2.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitF2.Location = new System.Drawing.Point(816, 30);
            this.lblTitF2.Name = "lblTitF2";
            this.lblTitF2.Size = new System.Drawing.Size(346, 19);
            this.lblTitF2.TabIndex = 1;
            this.lblTitF2.Text = "CastingStar - Sistema de Registro de Actores";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CastingStar.Properties.Resources.pctEstrella;
            this.pictureBox1.Location = new System.Drawing.Point(16, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CastingStar.Properties.Resources.cst;
            this.pictureBox2.Location = new System.Drawing.Point(608, 121);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(533, 379);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // gbDatosActor
            // 
            this.gbDatosActor.BackColor = System.Drawing.Color.White;
            this.gbDatosActor.Controls.Add(this.cmbGenero);
            this.gbDatosActor.Controls.Add(this.txtExperiencia);
            this.gbDatosActor.Controls.Add(this.txtCiudad);
            this.gbDatosActor.Controls.Add(this.txtEdad);
            this.gbDatosActor.Controls.Add(this.txtNombre);
            this.gbDatosActor.Controls.Add(this.txtId);
            this.gbDatosActor.Controls.Add(this.lblExperiencia);
            this.gbDatosActor.Controls.Add(this.lblCiudad);
            this.gbDatosActor.Controls.Add(this.lblGenero);
            this.gbDatosActor.Controls.Add(this.lblEdad);
            this.gbDatosActor.Controls.Add(this.lblNombre);
            this.gbDatosActor.Controls.Add(this.lblID);
            this.gbDatosActor.Controls.Add(this.label1);
            this.gbDatosActor.Controls.Add(this.lblTitgb);
            this.gbDatosActor.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatosActor.Location = new System.Drawing.Point(24, 121);
            this.gbDatosActor.Name = "gbDatosActor";
            this.gbDatosActor.Size = new System.Drawing.Size(554, 379);
            this.gbDatosActor.TabIndex = 2;
            this.gbDatosActor.TabStop = false;
            // 
            // cmbGenero
            // 
            this.cmbGenero.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Items.AddRange(new object[] {
            "Masculino",
            "Femenino"});
            this.cmbGenero.Location = new System.Drawing.Point(166, 226);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(379, 27);
            this.cmbGenero.TabIndex = 15;
            this.cmbGenero.Text = "Seleccione género";
            // 
            // txtExperiencia
            // 
            this.txtExperiencia.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtExperiencia.Location = new System.Drawing.Point(166, 310);
            this.txtExperiencia.Name = "txtExperiencia";
            this.txtExperiencia.Size = new System.Drawing.Size(379, 26);
            this.txtExperiencia.TabIndex = 14;
            this.txtExperiencia.Text = "Describa la experiencia del actor";
            // 
            // txtCiudad
            // 
            this.txtCiudad.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtCiudad.Location = new System.Drawing.Point(166, 269);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(379, 26);
            this.txtCiudad.TabIndex = 13;
            this.txtCiudad.Text = "Ingrese ciudad";
            // 
            // txtEdad
            // 
            this.txtEdad.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtEdad.Location = new System.Drawing.Point(166, 182);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(379, 26);
            this.txtEdad.TabIndex = 11;
            this.txtEdad.Text = "Ingrese edad";
            // 
            // txtNombre
            // 
            this.txtNombre.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtNombre.Location = new System.Drawing.Point(166, 139);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(379, 26);
            this.txtNombre.TabIndex = 10;
            this.txtNombre.Text = "Ingrese nombre completo";
            // 
            // txtId
            // 
            this.txtId.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtId.Location = new System.Drawing.Point(166, 96);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(379, 26);
            this.txtId.TabIndex = 9;
            this.txtId.Text = "Auto";
            // 
            // lblExperiencia
            // 
            this.lblExperiencia.AutoSize = true;
            this.lblExperiencia.Location = new System.Drawing.Point(13, 313);
            this.lblExperiencia.Name = "lblExperiencia";
            this.lblExperiencia.Size = new System.Drawing.Size(99, 19);
            this.lblExperiencia.TabIndex = 8;
            this.lblExperiencia.Text = "Experiencia:";
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Location = new System.Drawing.Point(13, 272);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(71, 19);
            this.lblCiudad.TabIndex = 7;
            this.lblCiudad.Text = "Ciudad: ";
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Location = new System.Drawing.Point(13, 229);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(71, 19);
            this.lblGenero.TabIndex = 6;
            this.lblGenero.Text = "Género:";
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(13, 185);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(52, 19);
            this.lblEdad.TabIndex = 5;
            this.lblEdad.Text = "Edad:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(13, 142);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(76, 19);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(13, 99);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(70, 19);
            this.lblID.TabIndex = 3;
            this.lblID.Text = "IdActor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(527, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "--------------------------------------------------------------------------";
            // 
            // lblTitgb
            // 
            this.lblTitgb.AutoSize = true;
            this.lblTitgb.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitgb.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTitgb.Location = new System.Drawing.Point(11, 24);
            this.lblTitgb.Name = "lblTitgb";
            this.lblTitgb.Size = new System.Drawing.Size(151, 20);
            this.lblTitgb.TabIndex = 1;
            this.lblTitgb.Text = "Datos del Actor";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(12, 80);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(139, 34);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "📤 Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(189, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "💾 Guardar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(368, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 34);
            this.button2.TabIndex = 5;
            this.button2.Text = "✏️ Modificar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(549, 80);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 34);
            this.button3.TabIndex = 6;
            this.button3.Text = "🗑️ Eliminar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(729, 80);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(139, 34);
            this.button4.TabIndex = 7;
            this.button4.Text = "🔍 Buscar";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // gbTabla
            // 
            this.gbTabla.Controls.Add(this.dtgRegistrados);
            this.gbTabla.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTabla.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gbTabla.Location = new System.Drawing.Point(24, 508);
            this.gbTabla.Name = "gbTabla";
            this.gbTabla.Size = new System.Drawing.Size(1116, 179);
            this.gbTabla.TabIndex = 8;
            this.gbTabla.TabStop = false;
            this.gbTabla.Text = "Actores Registrados";
            // 
            // dtgRegistrados
            // 
            this.dtgRegistrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgRegistrados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdActor,
            this.Nombre,
            this.Edad,
            this.Genero,
            this.Ciudad,
            this.Experiencia});
            this.dtgRegistrados.Location = new System.Drawing.Point(0, 26);
            this.dtgRegistrados.Name = "dtgRegistrados";
            this.dtgRegistrados.Size = new System.Drawing.Size(1115, 152);
            this.dtgRegistrados.TabIndex = 0;
            // 
            // IdActor
            // 
            this.IdActor.HeaderText = "IdActor";
            this.IdActor.Name = "IdActor";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Edad
            // 
            this.Edad.HeaderText = "Edad";
            this.Edad.Name = "Edad";
            // 
            // Genero
            // 
            this.Genero.HeaderText = "Género";
            this.Genero.Name = "Genero";
            // 
            // Ciudad
            // 
            this.Ciudad.HeaderText = "Ciudad";
            this.Ciudad.Name = "Ciudad";
            // 
            // Experiencia
            // 
            this.Experiencia.HeaderText = "Experiencia";
            this.Experiencia.Name = "Experiencia";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 696);
            this.Controls.Add(this.gbTabla);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.gbDatosActor);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.gbDatosActor.ResumeLayout(false);
            this.gbDatosActor.PerformLayout();
            this.gbTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgRegistrados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitF2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox gbDatosActor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitgb;
        private System.Windows.Forms.Label lblExperiencia;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtExperiencia;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox gbTabla;
        private System.Windows.Forms.DataGridView dtgRegistrados;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdActor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Edad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Genero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ciudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Experiencia;
    }
}