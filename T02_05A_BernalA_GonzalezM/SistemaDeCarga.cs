using Camiones;
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
        int cargaActual = 0, cAcum = 0;
        string capacidad;
        int sacos = 0;
        int camionActual = 1;
        decimal totalCamiones = 0;
        int saco = 0;

        Random rnd = new Random();

        public SistemaDeCarga()
        {
            InitializeComponent();
            pbCarga.Maximum = 20;
            btnReg.Visible = false;
            btnJor.Visible = false;
            gbDatosCamion.Visible = false;
            gbInf.Visible = false;
            btnCarsaco.Visible = false;
            btnDespacho.Visible = false;
            btnResu.Visible = false;
        }

        private void ActualizarCarga()
        {
            string capacidade = cmbCap.SelectedItem.ToString();
            lblCargaInfo.Text = cargaActual.ToString("N0") + " / " + capacidade + " kg (" + sacos + " sacos)";
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void lblEActual_Click(object sender, EventArgs e) { }
        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (nudCantidad.Value < 2)
            {
                lblEActual.Text = "El sistema no está listo.";
                lblEActual.ForeColor = Color.White;
                lblEActual.BackColor = Color.DarkRed;
                btnJor.Visible = false;
            }
            else
            {
                lblEActual.Text = "Sistema listo para iniciar.";
                lblEActual.ForeColor = Color.DarkGreen;
                lblEActual.BackColor = Color.FromArgb(204, 255, 204);
                btnJor.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nudCantidad.Value < 2)
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

        private void nudSacos_ValueChanged(object sender, EventArgs e) { }

        private void btnReg_Click(object sender, EventArgs e)
        {
            if (cmbCap.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una capacidad de camión.", "Error de Selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            gbDatosCamion.Visible = true;
            gbInf.Visible = true;
            btnReg.Visible = false;
            btnCarsaco.Visible = true;
            totalCamiones = nudCantidad.Value;

            if (camionActual == 1)
            {
                lstRegistro.Items.Add($"[{DateTime.Now:t}] 🚀 Jornada iniciada con {totalCamiones} camiones disponibles");
            }

            string capacidade = cmbCap.SelectedItem.ToString();
            lblCargaInfo.Text = cAcum.ToString("N0") + " / " + capacidade + " kg (" + sacos + " sacos)";
            lstRegistro.SelectedIndex = lstRegistro.Items.Count - 1;
        }

        private void Form1_Load(object sender, EventArgs e) { }
        private void pbCarga_Click(object sender, EventArgs e) { }
        private void lblCapCam_Click(object sender, EventArgs e) { }
        private void txtTransportista_TextChanged(object sender, EventArgs e) { }
        private void lstRegistro_SelectedIndexChanged(object sender, EventArgs e) { }

        private void btnCarsaco_Click(object sender, EventArgs e)
        {
            if (cmbCap.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una capacidad de camión para cargar.", "Error de Selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCarsaco.Visible = false;
                btnReg.Visible = true;
                return;
            }

            int capacidadMaxima = Convert.ToInt32(cmbCap.SelectedItem.ToString());
            pbCarga.Maximum = capacidadMaxima;

            int pesoMaximoSaco;

            if (capacidadMaxima == 18000) pesoMaximoSaco = 1500;
            else if (capacidadMaxima == 28000) pesoMaximoSaco = 2500;
            else pesoMaximoSaco = 500;

            if (saco == 0)
            {
                saco = rnd.Next(1, pesoMaximoSaco + 1);
            }

            if (cAcum + saco <= pbCarga.Maximum)
            {
                cAcum += saco;
                sacos++;
                pbCarga.Value = cAcum;

                string hora = DateTime.Now.ToString("t");
                lstRegistro.Items.Add($"[{hora}] 🎒 Saco agregado. Carga: {cAcum:N0} kg (+{saco:N0} kg)");
                lstRegistro.SelectedIndex = lstRegistro.Items.Count - 1;

                saco = 0;
            }
            else
            {
                MessageBox.Show($"¡Advertencia! El saco de {saco:N0} kg excede la capacidad del camión y se cargará en el próximo.", "Capacidad Excedida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnDespacho.Visible = true;
                btnCarsaco.Visible = false;
            }

            if (pbCarga.Value >= pbCarga.Maximum)
            {
                if (saco == 0) saco = rnd.Next(1, pesoMaximoSaco + 1);

                MessageBox.Show("¡Carga del Camión Completa!", "Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((Button)sender).Enabled = false;
                btnDespacho.Visible = true;
                btnCarsaco.Visible = false;
            }

            lblCargaInfo.Text = $"{cAcum:N0} / {capacidadMaxima:N0} kg ({sacos} sacos)";
        }

        private void btnResu_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            foreach (string item in lstRegistro.Items)
            {
                f2.lstResu.Items.Add(item);
            }

            f2.Show();
        }

        private void btnDespacho_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTransportista.Text) || string.IsNullOrWhiteSpace(txtPlaca.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del Transportista y el número de Placa antes de despachar el camión.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hora = DateTime.Now.ToString("t");
            string transportista = txtTransportista.Text;
            string placa = txtPlaca.Text;

            // MODIFICACIÓN: Se agrega el número de sacos al registro.
            lstRegistro.Items.Add($"[{hora}] 🚚 Camión despachado. Carga final: {cAcum:N0} kg. Sacos: {sacos}. Transportista: {transportista}. Placa: {placa}.");

            string mensajeDespacho = $"Camión despachado.\n" +
                                     $"Carga final: {cAcum:N0} kg ({sacos} sacos).\n" +
                                     $"Transportista: {transportista}\n" +
                                     $"Placa: {placa}";

            MessageBox.Show(mensajeDespacho, "Despacho Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (saco > 0)
            {
                cAcum = saco;
                sacos = 1;

                lstRegistro.Items.Add($"[{DateTime.Now:t}] ➡️ Saco excedente ({saco:N0} kg) cargado primero en el camión {camionActual + 1}.");
                lstRegistro.SelectedIndex = lstRegistro.Items.Count - 1;
            }
            else
            {
                cAcum = 0;
                sacos = 0;
            }

            camionActual++;

            if (camionActual > totalCamiones)
            {
                MessageBox.Show("Se ha alcanzado el límite de camiones para esta jornada.", "Jornada Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnReg.Visible = false;
                gbInf.Visible = false;

                btnResu.Visible = true;
            }
            else
            {
                btnReg.Text = $"✅Registrar camión {camionActual}";
                btnReg.Visible = true;
                gbInf.Visible = true;
                btnResu.Visible = false;
            }

            pbCarga.Value = cAcum;
            lblCargaInfo.Text = $"{cAcum:N0} / 0 kg ({sacos} sacos)";
            txtTransportista.Text = string.Empty;
            txtPlaca.Text = string.Empty;

            btnDespacho.Visible = false;
            btnCarsaco.Visible = false;
            btnCarsaco.Enabled = true;
            gbDatosCamion.Visible = true;
        }
    }
}