using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exemplos
{
    public partial class frmPassagemDados : Form
    {
        public frmPassagemDados(String nome)
        {
            InitializeComponent();
            txtNome.Text = nome;
            lblNome.Text = nome;
            btnNome.Text = nome;
        }

        private void frmPassagemDados_Load(object sender, EventArgs e)
        {

        }
    }
}
