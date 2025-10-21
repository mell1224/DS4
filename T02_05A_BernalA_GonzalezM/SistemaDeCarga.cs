using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T02_05A_BernalA_GonzalezM
{

    public partial class SistemaDeCarga : Form
    {
        int cargaActual = 0;
        int capacidad = 0;
        int sacos = 0;
        int camionActual = 1;
        int totalCamiones = 0;

        public SistemaDeCarga()
        {
            InitializeComponent();
            pbCarga.Maximum = 20;
            btnReg.Visible = false;
            button1.Visible = false; // Oculta el botón al iniciar
            gbDatosCamion.Visible = false; // Oculta el GroupBox al iniciar
            gbInf.Visible = false;
            btnCarsaco.Visible = false;

        }
        private void ActualizarCarga()
        {
            lblCargaInfo.Text = $"{cargaActual:N0} / {capacidad:N0} kg ({sacos} sacos)";
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblEActual_Click(object sender, EventArgs e)
        {
            
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (nudCantidad.Value < 10)
            {
                lblEActual.Text = "El sistema no está listo.";
                lblEActual.ForeColor = Color.White;
                lblEActual.BackColor = Color.DarkRed;

                button1.Visible = false; // Oculta el botón si el valor vuelve a ser inválido
            }
            else
            {
                lblEActual.Text = "Sistema listo para iniciar.";
                lblEActual.ForeColor = Color.DarkGreen;
                lblEActual.BackColor = Color.FromArgb(204, 255, 204);
                button1.Visible = true; // Muestra el botón solo si el sistema está listo
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            if(nudCantidad.Value < 10)
            {
                MessageBox.Show("El sistema no se puede iniciar.", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Iniciando Jornada"); 
                btnReg.Visible = true;
                gbDatosCamion.Visible = true;
            }
          

        }

        private void nudSacos_ValueChanged(object sender, EventArgs e)
        {
            //pbCarga.Value = (int)nudSacos.Value;
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            gbDatosCamion.Visible = true;
            gbInf.Visible = true;
            btnReg.Visible = false;
            btnCarsaco.Visible = true;
            lstRegistro.Items.Add($"[{DateTime.Now:t}] 🚀 Jornada iniciada con {totalCamiones} camiones disponibles");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pbCarga_Click(object sender, EventArgs e)
        {

        }

        private void lblCapCam_Click(object sender, EventArgs e)
        {

        }

        private void txtTransportista_TextChanged(object sender, EventArgs e)
        {

        }

        private void lstRegistro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
