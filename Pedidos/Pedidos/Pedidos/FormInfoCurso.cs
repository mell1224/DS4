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
    public partial class FormInfoCurso : Form
    {
        public FormInfoCurso()
        {
            InitializeComponent();
        }

        private void btnVolverFInfo_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            this.Hide();
            formLogin.Show();
        }
    }
}
