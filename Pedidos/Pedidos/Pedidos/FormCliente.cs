using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pedidos
{
    public partial class FormCliente : Form
    {
        public FormCliente()
        {
            InitializeComponent();
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            pbCarrito.Visible = false;
        }

        private void btnPostres_Click(object sender, EventArgs e)
        {
            plCroiss.Visible = false;
            plPF.Visible = false;
            plB.Visible = false;
            plPI.Visible = false;
        }

        private void btnSalados_Click(object sender, EventArgs e)
        {
            plCroiss.Visible = false;
            plPF.Visible = false;
            plB.Visible = false;
            plPI.Visible = false;
        }

        private void btnBebidas_Click(object sender, EventArgs e)
        {
            plCroiss.Visible = false;
            plPF.Visible = false;
            plB.Visible = false;
            plPI.Visible = false;
        }

        private void btnPanes_Click(object sender, EventArgs e)
        {
            plCroiss.Visible = true;
            plPF.Visible = true;
            plB.Visible = true;
            plPI.Visible = true;
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            plCroiss.Visible = true;
            plPF.Visible = true;
            plB.Visible = true;
            plPI.Visible = true;
        }

        private void btnAgPF_Click(object sender, EventArgs e)
        {
            pbCarrito.Visible = true;
        }

        private void btnAgCroiss_Click(object sender, EventArgs e)
        {
            pbCarrito.Visible = true;
        }

        private void btnAgPI_Click(object sender, EventArgs e)
        {
            pbCarrito.Visible = true;
        }

        private void btnAgBag_Click(object sender, EventArgs e)
        {
            pbCarrito.Visible = true;
        }
    }
}
