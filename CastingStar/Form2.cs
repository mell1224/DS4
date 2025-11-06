using System;
using System.Windows.Forms;

namespace CastingStar
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dtgRegistrados.Rows.Add(1, "María González", 28, "Femenino", "Ciudad de Panamá", "Teatro universitario, 3 comerciales de TV");
            dtgRegistrados.Rows.Add(2, "Carlos Rodríguez", 35, "Masculino", "Colón", "5 años en teatro profesional, 2 películas independientes");
            dtgRegistrados.Rows.Add(3, "Ana Martínez", 22, "Femenino", "David", "Estudiante de actuación, participación en obras escolares");

            dtgRegistrados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgRegistrados.ReadOnly = true;
            dtgRegistrados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgRegistrados.AllowUserToAddRows = false;
            dtgRegistrados.RowHeadersVisible = false;
            dtgRegistrados.BorderStyle = BorderStyle.FixedSingle;

            dtgRegistrados.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            dtgRegistrados.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
