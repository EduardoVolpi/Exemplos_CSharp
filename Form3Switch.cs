using System;
using System.Windows.Forms;

namespace Exemplos {
    public partial class Form3Switch : Form {
        // string publica
        private string estilo;

        public Form3Switch() {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Form3Switch_Load(object sender, EventArgs e) {
            lblResultado.Text = "";
        }

        private void radioBtnWingChun_CheckedChanged(object sender, EventArgs e) {
            estilo = "Wing Chun";
        }

        private void button1_Click(object sender, EventArgs e) {
            switch (estilo) {
                case "Wing Chun":
                    lblResultado.Text = "Esse é o melhor Estilo!";
                    break;

                case "Hung Gar":
                    lblResultado.Text = "Esse é o Estilo do Tigre. É bom!";
                    break;

                case "Choy Li Fut":
                    lblResultado.Text = "Esse é bom para lutar contra vários adversários.";
                    break;

                case "Mantis":
                    lblResultado.Text = "Esse é um estilo muito bom e completo.";
                    break;

                default:
                    break;
            }
        }

        private void radioBtnHungGar_CheckedChanged(object sender, EventArgs e) {
            estilo = "Hung Gar";
        }

        private void radioBtnMantis_CheckedChanged(object sender, EventArgs e) {
            estilo = "Mantis";
        }

        private void radioBtnCLF_CheckedChanged(object sender, EventArgs e) {
            estilo = "Choy Li Fut";
        }
    }
}