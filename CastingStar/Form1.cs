using System;
using System.Drawing;
using System.Windows.Forms;

namespace CastingStar
{
    public partial class Form1 : Form
    {
        Form2 f2 = new Form2();
        // Estrella pulsante
        private double pulsoAngulo = 0;
        private int baseSize = 60;
        private int centroX;
        private int centroY;

        // Texto máquina de escribir
        private string textoCompleto = "\"Listo para el próximo casting...\"";
        private int letraActual = 0;


        public Form1()
        {
            InitializeComponent();
            this.Opacity = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            centroX = this.ClientSize.Width / 2;
            centroY = this.ClientSize.Height / 3;

            pictureEstrellaAmarilla.Left = centroX - pictureEstrellaAmarilla.Width / 2;
            pictureEstrellaAmarilla.Top = centroY - pictureEstrellaAmarilla.Height / 2;

            timerEstrella.Start();
            timerTexto.Start();
        }

        private void timerEstrella_Tick(object sender, EventArgs e)
        {
            pulsoAngulo += 0.11;
            double escala = 1 + Math.Sin(pulsoAngulo) * 0.15;

            int nuevoAncho = (int)(baseSize * escala);
            int nuevoAlto = (int)(baseSize * escala);

            pictureEstrellaAmarilla.Size = new Size(nuevoAncho, nuevoAlto);

            // Recalcular centro en cada tick
            int centroX = this.ClientSize.Width / 2;
            int centroY = this.ClientSize.Height / 3;

            pictureEstrellaAmarilla.Location = new Point(
                centroX - pictureEstrellaAmarilla.Width / 2,
                centroY - pictureEstrellaAmarilla.Height / 2
            );
        }



        private void timerTexto_Tick(object sender, EventArgs e)
        {
            if (letraActual <= textoCompleto.Length)
            {
                lblListo.Text = textoCompleto.Substring(0, letraActual);
                letraActual++;
            }
            else
            {
                letraActual = 0;
                lblListo.Text = ""; // Limpia antes de repetir
            }
        }


        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Opacity = 0; // Empieza invisible

            // Posición inicial: esquina superior izquierda
            f2.StartPosition = FormStartPosition.Manual;
            f2.Location = new Point(0, 0);
            f2.Show();
            this.Hide();

            // Timer para movimiento diagonal controlado
            Timer diagonalTimer = new Timer { Interval = 10 };
            diagonalTimer.Tick += (s, args) =>
            {
                int maxLeft = (Screen.PrimaryScreen.WorkingArea.Width - f2.Width) / 2;
                int maxTop = (Screen.PrimaryScreen.WorkingArea.Height - f2.Height) / 2;

                if (f2.Left < maxLeft) f2.Left += 10;
                if (f2.Top < maxTop) f2.Top += 10;

                if (f2.Left >= maxLeft && f2.Top >= maxTop)
                {
                    f2.Left = maxLeft;
                    f2.Top = maxTop;
                    diagonalTimer.Stop();
                }
            };
            diagonalTimer.Start();

            // Timer para fade-in
            Timer fadeTimer = new Timer { Interval = 50 };
            fadeTimer.Tick += (s, args) =>
            {
                if (f2.Opacity < 1)
                {
                    f2.Opacity += 0.05;
                }
                else
                {
                    f2.Opacity = 1;
                    fadeTimer.Stop();
                }
            };
            fadeTimer.Start();
        }



    }
}
