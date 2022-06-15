using System;
using System.Windows.Forms;

namespace Exemplos
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            // poderia ser this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblResultado.Text = "";
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            /*
			* O Objetivo neste código é mostrar os Operadores Lógicos
			* do C# como: ! (Not), && (And), || (Or)
			*/
            if (!string.IsNullOrWhiteSpace(txtAnoNascimento.Text))
            {
                int anoNasc = Convert.ToInt32(txtAnoNascimento.Text);
                int anoAtual = DateTime.Now.Year;
                int idade = anoAtual - anoNasc;

                if (idade < 16)
                {
                    lblResultado.Text = "Voce tem " + idade + " anos. Voce Não Vota.";
                }
                else if ((idade >= 16 && idade < 18) || (idade > 70))
                {
                    lblResultado.Text = "Voce tem " + idade + " anos. O Voto é Opcional.";
                }
                else
                {
                    lblResultado.Text = "Voce tem " + idade + " anos. O Voto é Obrigatório.";
                }
            }
        }

        private void txtAnoNascimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se é numero e tecla backspace (char)8 da Tabela ASCII, ambos permitidos O
            // resto não é permitido ser digitado no campo
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}