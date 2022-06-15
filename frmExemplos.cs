using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Exemplos
{
    public partial class frmExemplos : Form
    {
#if WINDOWS
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
#endif   

        // Inicializando var utilizada pelo eventos de Sons Wav e Mp3
        private int playing = 0;
        private bool playingMp3 = false;
        //Nova linha
        private string nl = System.Environment.NewLine;

        public frmExemplos()
        {
            InitializeComponent();
        }

        // Para o método abaixo, tem que incluir : "using System.Collections.Generic" e "using System.Linq"
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAll(ctrl, type)).Concat(controls).Where(c => c.GetType() == type);
        }

        private void btnAbrirQualquerArquivoExterno_Click(object sender, EventArgs e)
        {
            // Abrir um arquivo externo qualquer com seu programa padrão
            OpenFileDialog abrirArq = new OpenFileDialog();

            if (abrirArq.ShowDialog() == DialogResult.OK)
            {
                if (!String.IsNullOrWhiteSpace(abrirArq.FileName))
                {
                    // comando para abrir O @ só é necessario qdo o caminho completo utiliza "\"
                    try
                    {
                        // using System.Diagnostics;
                        System.Diagnostics.Process.Start(new ProcessStartInfo(abrirArq.FileName) { UseShellExecute = true });

                        // forma antiga utilizada no .net framework
                        //System.Diagnostics.Process.Start(abrirArq.FileName);
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message);
                    }

                    // ou seria System.Diagnostics.Process.Start(@"C:\Arquivo.Extensão")
                }
            }
        }

        private void btnArrays_Click(object sender, EventArgs e)
        {
            String[] meses = new String[12]
            { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
            for (int i = 0; i < meses.Length; i++)
            {
                MessageBox.Show(meses[i]);
            }
        }

        private void btnChamaOutroForm_Click(object sender, EventArgs e)
        {
            Form dudas = new Form2();
            dudas.ShowDialog();
        }

        private void btnColorDialog_Click(object sender, EventArgs e)
        {
            #region Mostrar ColorDialog
            // Posso colocar o componente sem criar o dialogo ou criar o componente como estou
            // criando abaixo
            ColorDialog colorDialog1 = new ColorDialog();

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
            #endregion
        }

        private void btnConcatenarString_Click(object sender, EventArgs e)
        {

            /*
             Formas de concatenar: As duas primeiras são de performance ruin para enormes
             processamentos neste caso é melhor usar a forma 3 e 4, sendo a 4 a melhor. Mas para
             pouca coisa qulquer uma.
             */

            string nome = "Eduardo";
            string sobrenome = "Volpi";
            string nomecompleto;

            //// 1 - Usando sinal de +
            //nomecompleto = nome + " " + sobrenome;

            //// 2 - Usando String.Concat
            //nomecompleto = string.Concat(nome, " ", sobrenome);

            //// 3 - Usando String Format
            //nomecompleto = string.Format("{0} {1}", nome, sobrenome);

            // 4 - Usando objeto StringBuilder
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0} {1}", nome, sobrenome);
            nomecompleto = Convert.ToString(sb);

            MessageBox.Show(nomecompleto + "\n\nVeja o código fonte.", Application.ProductName);
        }

        /// FIM MÉTODOS CRIADOS
        private void btnCopiarDiretorio_Click(object sender, EventArgs e)
        {
            string origem = @"";
            string destino = @"";

            // Procurei uma solução descente para isso em C# mas muitos concordaram que esta é a
            // melhor e mais elegante.

            try
            {
                Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(origem, destino, true);
                MessageBox.Show("Copiado!");
            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu um erro no programa:" + nl + erro.Message + nl
                    + "Se o erro persistir contate o desenvolvedor do programa.",
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            // Posso colocar o componente sem criar o dialogo ou criar o componente como estou
            // criando abaixo
            SaveFileDialog createDir = new SaveFileDialog();
            createDir.Title = "Escolha o local e o nome da pasta a ser criada";

            if (createDir.ShowDialog() == DialogResult.OK)
            {
                Directory.CreateDirectory(createDir.FileName);
                MessageBox.Show("A pasta " + createDir.FileName + " foi criada!",
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDataAtual_Click(object sender, EventArgs e)
        {
            string hora = "Data de hoje: " + Convert.ToString(DateTime.Now.ToShortDateString() + "\n" +
                "Hora atual: " + DateTime.Now.ToShortTimeString() + "hs");

            MessageBox.Show(hora, Application.ProductName);
        }

        private void btnDiferenca_Click(object sender, EventArgs e)
        {
            string dataInicial = dtpDataInicial.Text;
            string dataFinal = dtpDataFinal.Text;

            int totalDias = (DateTime.Parse(dataFinal).Subtract(DateTime.Parse(dataInicial))).Days;

            lblDiferenca.Text = Convert.ToString(totalDias) + " dias.";
        }

        private void btnDoWhile_Click(object sender, EventArgs e)
        {
            string val = Interaction.InputBox("Digite o número de vezes que deseja contar", Application.ProductName);

            if (val.Length > 1)
            {
                int total = Convert.ToInt32(val);
                int c = 1;
                do
                {
                    c++;
                    lblTitle.Text = Convert.ToString(c);
                    lblTitle.Refresh();
                    c++;
                } while (c < total);
                timer1.Enabled = true;
            }
        }

        private void btnEncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExcluirDiretorio_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowse = new FolderBrowserDialog();

            if (folderBrowse.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("Tem certeza que deseja excluir a pasta:\n" + folderBrowse.SelectedPath,
                    Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    // vou extrair somente o nome da pasta para mostrar no messageBox confirmando a exclusão
                    string pasta = Path.GetFileName(folderBrowse.SelectedPath);
                    // Vou excluir a pasta selecionada
                    Directory.Delete(folderBrowse.SelectedPath);
                    // Vou exibir a mesnagem de sucesso
                    MessageBox.Show("A Pasta \"" + pasta + "\" foi excluída com sucesso!",
                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnExtrairNomeDeArquivoOuPasta_Click(object sender, EventArgs e)
        {
            string arquivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\teste.rtf";
            // Extrai do caminho o nome do arquivo
            string nomeArquivo = Path.GetFileName(arquivo);
            MessageBox.Show(arquivo + "\n\nNome do Arquivo Extraído: " + nomeArquivo);
        }

        private void btnFolderBrowseDialog_Click(object sender, EventArgs e)
        {
            // Posso colocar o componente sem criar o dialogo ou criar o componente como estou
            // criando abaixo
            FolderBrowserDialog folderBrowse = new FolderBrowserDialog();

            if (folderBrowse.ShowDialog() == DialogResult.OK)
            {
                if (!String.IsNullOrWhiteSpace(folderBrowse.SelectedPath))
                {
                    MessageBox.Show(folderBrowse.SelectedPath, Application.ProductName);
                }
            }
        }

        private void btnFontDialog_Click(object sender, EventArgs e)
        {
            // Posso colocar o componente sem criar o dialogo ou criar o componente como estou
            // criando abaixo
            FontDialog fontDialog1 = new FontDialog();

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void btnFor_Click(object sender, EventArgs e)
        {
            string val = Interaction.InputBox("Digite o número de vezes que deseja contar", Application.ProductName);

            if (val.Length > 0)
            {
                int numVezes = Convert.ToInt32(val);
                for (int i = 1; i <= numVezes; i++)
                {
                    lblTitle.Text = Convert.ToString(i);
                    lblTitle.Refresh();
                }
                timer1.Enabled = true;
            }
        }

        private void btnForEach_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Vamos mudar o texto dos Botões no form\n para \"Olá Mundo!.\" Concorda?",
    Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                /*
                Esse código abaixo só muda a propriedade dos controles sobre o formulário. Os
                controles dentro de outro controle como o TabControl por exemplo, não eram
                modificados. Então, o código que altera "todos " os controles, independente de
                estarem ou não dentro de outros controle está abaixo deste comentado, e, depende
                do método "public IEnumerable<Control> GetAll(Control control, Type type)" mais abaixo

               foreach (Control control in this.Controls)
               {
                   if (control is Label)
                   {
                       control.Text = "Olá Mundo!!";
                   }
               }
               */

                foreach (var controle in GetAll(this, typeof(Button)))
                {
                    (controle as Button).Text = "Olá Mundo";
                }
                foreach (var controle in GetAll(this, typeof(Label)))
                {
                    (controle as Label).Text = "Olá Mundo";
                }
                foreach (var controle in GetAll(this, typeof(GroupBox)))
                {
                    (controle as GroupBox).Text = "Olá Mundo";
                }
            }
        }

        private void btnGetFiles_Click(object sender, EventArgs e)
        {
            string driveLetter = Convert.ToString(cboDriveLetter.SelectedItem);

            if (String.IsNullOrEmpty(driveLetter))
            {
                MessageBox.Show("Voce deve selecionar a letra de\n um drive na Caixa de Seleção.",
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cboDriveLetter.Focus();
                return;
            }

            //Limpa o ListBox
            listBox1.Items.Clear();

            // string[] arquivos = Directory.GetFiles(@"C:\");
            string[] arquivos = Directory.GetFiles(driveLetter);

            foreach (string conteudo in arquivos)
            {
                listBox1.Items.Add(conteudo);
            }
        }

        private void btnGlobalizacaoCulturaDoSistema_Click(object sender, EventArgs e)
        {
            string cultura = Convert.ToString(System.Globalization.CultureInfo.CurrentCulture);
            MessageBox.Show("Seu sitema está em " + cultura,
Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGravarArquivoEmDisco_Click(object sender, EventArgs e)
        {
            // System.IO
            try
            {
                string arquivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\teste.txt";
                StreamWriter gravar = new StreamWriter(arquivo);

                gravar.WriteLine("Oi Mundo nesta primeira linha");
                gravar.WriteLine("Continua a segunda linha do Olá Mundo!");
                gravar.WriteLine("e finalmente a última linha do mundão olado.");
                gravar.WriteLine();
                gravar.WriteLine("Gravado em " + DateTime.Now.ToShortDateString() + " às " + DateTime.Now.ToShortTimeString() + "hs");
                gravar.Close();
                MessageBox.Show("Arquivo Gravado!", Application.ProductName, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnIfElse_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voce é maior de Idade?", Application.ProductName,
MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Então voce tem 18 anos ou mais", Application.ProductName,
               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Então voce tem menos de dezoito anos",
                         Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnInputBox_Click(object sender, EventArgs e)
        {

            /* Para usar um inputbox como no VB, basta adicionar uma referencia
             * ao Microsoft.VisualBasic no projeto e depois declarar "using Microsoft.VisualBasic",
             * depois basta usar o método "Interaction.InputBox", como abaixo. */

            string nome = Interaction.InputBox("Informe o seu nome:", Application.ProductName);

            if (nome.Replace(" ", "").Length > 0)
            {
                MessageBox.Show("Bem-vindo " + nome, Application.ProductName);

            }
        }

        private void btnItalico_Click(object sender, EventArgs e)
        {
            // Isso é o básico. Tem que declarar no topo "Using System.Drawing"
            if (richTextBox1.SelectionFont.Italic)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Italic);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Italic);
            }
        }

        private void btnLerArquivoEmDisco_Click(object sender, EventArgs e)
        {
            //System.IO
            string arquivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\teste.txt";

            if (File.Exists(arquivo))
            {
                StreamReader ler = new StreamReader(arquivo);

                MessageBox.Show(ler.ReadToEnd());

                /*
                  Eu tambem poderia ler linha a linha e tambem procurar por algo especifico nesta
                  linha, como farei abaixo, nãi lendo as linhas que contem a data e a hora
                  (conforme gravei no exemplo gravar)

                  string linha = "";
                  string tudo = "";
                  int contador = 0;

                  while (!ler.EndOfStream)
                  {
                     linha = ler.ReadLine();
                     if (!linha.Contains("/") && !linha.Contains("hs")) // data e hora contem, ex 14/01/2016 e 18hs
                     {
                         tudo = tudo + linha + "\n";
                         //contador++; O uso do contador não é nescessário a nao ser que eu quisesse numerar as linhas por ex.
                     }
                  }
                  MessageBox.Show(tudo);
                */

                // Fecha Leitor
                ler.Close();
            }
            else
            {
                MessageBox.Show("Arquivo Inexistente!\nClique em Gravar (acima) para criar um",
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnMediaSons_Click(object sender, EventArgs e)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Criando e instanciando
                SoundPlayer tocar = new SoundPlayer();

                if (playing == 0)
                {
                    if (openWav.ShowDialog() == DialogResult.OK)
                    {
                        if (!String.IsNullOrWhiteSpace(openWav.FileName))
                        {
                            tocar.SoundLocation = openWav.FileName;
                            tocar.Play();
                            playing = 1;
                        }
                    }
                }
                else
                {
                    tocar.Stop();
                    playing = 0;
                }

            }


        }

        private void btnMetodoSimples_Click(object sender, EventArgs e)
        {
            meuMetodo();
        }

        private void btnMoveDir_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowse = new FolderBrowserDialog();

                folderBrowse.Description = "Escolha o Diretorio / Pasta que deseja mover e clique em \"Ok\"";

                if (folderBrowse.ShowDialog() == DialogResult.OK)
                {
                    // Bom, essa é a pasta que vou mover
                    string dirOrigem = folderBrowse.SelectedPath;
                    // Vou extrair somente o nome da pasta posi vou precisar qdo for move
                    string nomePasta = Path.GetFileName(folderBrowse.SelectedPath);

                    // Agora vou definir e move-la para a pasta "Meus Documentos" adiciona o nome da
                    // pasta (extraido acima ao detino
                    string localDestino =
                        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\" + nomePasta;

                    // Finalmente Movo o Diretorio
                    Directory.Move(dirOrigem, localDestino);

                    MessageBox.Show("A pasta escolhida foi movida para\n" + localDestino,
                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMp3_Click(object sender, EventArgs e)
        {
            /*
              Tem que adicionar uma referencia (como abaixo) no projeto (em COM) ao arquivo WMPLib.dll na pasta System32
              O objeto foi criado no topo para ficar como global para todo o form.
              Tambem pode ser criado como public em um novo mudulo

              --> WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
            */
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (playingMp3 == false)
                {
                    if (openMp3.ShowDialog() == DialogResult.OK)
                    {
                        if (!String.IsNullOrWhiteSpace(openMp3.FileName))
                        {
                            wplayer.URL = openMp3.FileName;
                            wplayer.controls.play();
                            playingMp3 = true;
                        }
                    }
                }
                else
                {
                    wplayer.controls.stop();
                    playingMp3 = false;
                }
            }

        }

        private void btnMsgBoxDialogResult_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clique em \"Sim\" ou \"Não\"", Application.ProductName,
                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                MessageBox.Show("Voce apertou o botão \"Sim\"");
            }
            else
            {
                MessageBox.Show("Voce apertou o botão \"Não\"");
            }
        }

        private void btnNegrito_Click(object sender, EventArgs e)
        {
            // Isso é o básico. Tem que declarar no topo "Using System.Drawing"
            if (richTextBox1.SelectionFont.Bold)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Bold);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Bold);
            }
        }

        private void btnNumeroRandomico_Click(object sender, EventArgs e)
        {
            //Vou gerar um numero randomico até 5
            Random r = new Random();
            // Poderia ser só um numero, 50 por exemplo, mas aqui estou dizendo que quero numeros
            // entre 1 e 5 (coloco 6 pois ele gera um a menos
            int num2 = r.Next(1, 6);
            MessageBox.Show("Numero Randômico de 1 à 5:  " + Convert.ToString(num2));
        }

        private void btnOpenFileDialog_Click(object sender, EventArgs e)
        {
            // Bom aqui voce deixar o componente invés de criar na hora pois fica mais fácil setar
            // as diversas prorpiedades OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!String.IsNullOrWhiteSpace(openFileDialog1.FileName))
                {
                    richTextBox1.LoadFile(openFileDialog1.FileName);
                }
            }
        }

        private void btnOperadoresLogicos_Click(object sender, EventArgs e)
        {
            // Exemplos de Operadores Lógicos no Form2
            Form a = new Form2();
            a.ShowDialog();
        }

        private void btnOutraClasse_Click(object sender, EventArgs e)
        {

            // CHAMA MÉTODO EM OUTRA CLASSE OU MÓDULO

            /*
             Clicando com o lado direito sobre o projeto "Exemplos", eu selecionei "Add" e
             adicionei a classe "ClasseExemploSimples.css", onde criei um método que vou chamar à
             partir do código deste botão.Coloquei a classe dentro de uma pasta "Classes que
             tambem criei com o botão o lado direito sobre o projeto "Exemplos", eu selecionei
             "Add" e adicionei a pasta

             Vou declarar/ instanciar a classe para usá-la Ou posso declarar no topo para não
             precisar declarar cada vez que for usar
            */
            ClasseExemploSimples minhaClasse = new ClasseExemploSimples();

            // Agora vou mostrar o conteúdo, que é uma string, dentro de um msgBox
            MessageBox.Show(minhaClasse.minhaMensagem(), "Exemplos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnProgressBars_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10000; i++)
            {
                progressBar1.Value = i;
            }
        }

        private void btnRedimensionarArray_Click(object sender, EventArgs e)
        {
            #region Array Inicial
            // Vou definir o Array Inicial com capacidade para dois nomes
            string[] nomes = new string[2];

            MessageBox.Show("Definido um Array de " + Convert.ToString(nomes.Length) + " nomes.\nExibindo os nomes:");

            nomes[0] = "Nome 1";
            nomes[1] = "Nome 2";

            for (int i = 0; i < nomes.Length; i++)
            {
                MessageBox.Show(nomes[i]);
            }
            #endregion

            #region Array Redimensionado
            MessageBox.Show("Agora vou Redimensionar, acrescentar espaço\npara mais dois nomes e exibir todos os nomes aqui");

            // Vou redimensionar o Array para incluir espaço para mais dois nomes
            Array.Resize(ref nomes, 4);

            nomes[2] = "Nome 3";
            nomes[3] = "Nome 4";

            MessageBox.Show("Array redimensionada para " + Convert.ToString(nomes.Length) + " nomes.\nExibindo os nomes:");

            for (int i = 0; i < nomes.Length; i++)
            {
                MessageBox.Show(nomes[i]);
            }
            #endregion
        }

        private void btnRefazTitle_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Application.ProductName;
        }

        private void btnSaveFileDialog_Click(object sender, EventArgs e)
        {
            // Bom aqui voce deixar o componente invés de criar na hora pois fica mais fácil setar
            // as diversas propriedades SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (String.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                MessageBox.Show("Não há texto para salvar.\nEscreva algo e depois\nclique em salvar",
                   Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!String.IsNullOrWhiteSpace(saveFileDialog1.FileName))
                {
                    richTextBox1.SaveFile(saveFileDialog1.FileName);
                }
            }
        }

        private void btnSomarDias_Click(object sender, EventArgs e)
        {
            string dataFinal = dtpDataFinal.Text;

            if (txtDias.Text.Replace(" ", "").Length > 0)
            {
                lblDiferenca.Text =
                    DateTime.Parse(dtpDataFinal.Text).AddDays(Convert.ToDouble(txtDias.Text)).ToString("dd/MM/yyyy");
            }
            else
            {
                MessageBox.Show("Informe quantos dias quer somar ou subtrair (-) da data final.",
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSonsSistema_Click(object sender, EventArgs e)
        {

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                System.Media.SystemSounds.Exclamation.Play();
            }


        }

        private void btnSpecialFolders_Click(object sender, EventArgs e)
        {
            string mensagem;

            #region SpecialFolders
            string tempPath = Path.GetTempPath();
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string music = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            string images = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            string program = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            string programx86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string videos = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);

            string execName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            string execName2 = System.AppDomain.CurrentDomain.FriendlyName;
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string appDir = Application.StartupPath;
            #endregion

            mensagem = ("TempDir: " + tempPath + nl + nl + "Desktop: " + desktop + nl + nl + "My Documents: " + documents +
      nl + nl + "My Music: " + music + nl + nl + "My Images: " + images + nl + nl + "My Videos: " + videos + nl +
      nl + "Program Files: " + program + nl + nl + "Program Files(x86): " + programx86 + nl +
      nl + "Application Data: " + appData + nl + nl + "Nome Executável: " + execName + nl + nl +
      "Nome Executável 2: " + execName2 + nl + nl + "Caminho completo do Executável: " + strExeFilePath +
      nl + nl + "Diretório do Executável: " + appDir);

            MessageBox.Show(mensagem, Application.ProductName, MessageBoxButtons.OK);
        }

        private void btnSublinhado_Click(object sender, EventArgs e)
        {
            // Isso é o básico. Tem que declarar no topo "Using System.Drawing"
            if (richTextBox1.SelectionFont.Underline)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Underline);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Underline);
            }
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            Form a = new Form3Switch();
            a.ShowDialog();
        }

        private void btnSystemIoDriveInfo_Click(object sender, EventArgs e)
        {
            string driveLetter = Convert.ToString(cboDriveLetter.SelectedItem);

            if (String.IsNullOrEmpty(driveLetter))
            {
                MessageBox.Show("Voce deve selecionar a letra de\n um drive na Caixa de Seleção.",
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDriveLetter.Focus();
                return;
            }

            try
            {
                // Crio e instancio um objeto (drive) do Tipo "System.IO.DriveInfo" para poder
                // acessar e utilizar suas propriedades e métodos.
                DriveInfo drive = new DriveInfo(driveLetter);
                //System.IO.DriveInfo drive = new System.IO.DriveInfo(@"C:\");

                // Espaço disponível no disco C:
                txtEspacoLivre.Text = Convert.ToString(drive.AvailableFreeSpace);
                // Tipo de Drive
                txtTipoDrive.Text = Convert.ToString(drive.DriveType);
                // Volume Label
                lblVolumeLabel.Text = drive.VolumeLabel;
                // IsReady
                txtEstaPronto.Text = Convert.ToString(drive.IsReady);
                txtFormatoDrive.Text = Convert.ToString(drive.DriveFormat);
                //Diretprio Raiz (root)
                txtRoot.Text = Convert.ToString(drive.RootDirectory);
                // Tamanho Total
                txtTamanhoTotal.Text = Convert.ToString(drive.TotalSize);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTrayCatch_Click(object sender, EventArgs e)
        {
            // Uma tentativa de divisão por zero para causar um erro que será interceptado e exibido
            // para o usuario utilizando-se tratamento de erro "Try...Catch"
            try
            {
                // Aqui meu código que vai gerar um erro
                int valor1 = 1;
                int valor2 = 0;
                string total;

                total = Convert.ToString(valor1 / valor2);
            }
            catch (Exception erro)
            {
                // Aqui eu exibo o erro na tela
                MessageBox.Show(erro.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (MessageBox.Show("Deseja ver outro exemplo?", Application.ProductName,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Tab Exemplos 3 - botão Copiar Diretorio
                tabControl1.SelectedIndex = 2;
                btnCopiarDiretorio.Focus();
            }
        }

        private void btnWhile_Click(object sender, EventArgs e)
        {
            string val = Interaction.InputBox("Digite o número de vezes que deseja contar", Application.ProductName);

            if (val.Length > 1)
            {
                int total = Convert.ToInt32(val);
                int c = 0;
                while (c < total + 1)
                {
                    lblTitle.Text = Convert.ToString(c);
                    lblTitle.Refresh();
                    c++;
                }
                timer1.Enabled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            lblDiferenca.Text = (dateTimePicker1.Value).ToString("dd/MM/yyyy");
        }

        private void frmExemplos_Load(object sender, EventArgs e)
        {

            //Texto onde são utilizados exemplos para laçços while e do while, etc..
            lblTitle.Text = "";

            // Data completa do Sistema
            StatusLabelData.Text = "Hoje é " + DateTime.Now.ToLongDateString();

            // Carrega os drives existentes para dentro do combobox do exemplo "System.IO.DriveInfo"
            // da aba "File System"

            // Crio o array "drives" para onde o metodo retornará todos os drives existentes.
            string[] drives = System.IO.Directory.GetLogicalDrives();

            // Jogo o conteudo do array para o combobox
            foreach (string conteudo in drives)
            {
                cboDriveLetter.Items.Add(conteudo);
            }

        }

        /// MÉTODOS CRIADOS

        private void listBox1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(listBox1.SelectedItem)))
            {
                System.Diagnostics.Process.Start(Convert.ToString(listBox1.SelectedItem));
            }
        }

        private void meuMetodo()
        {
            MessageBox.Show("Olá Mundo!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            lblDiferenca.Text = (calendar.SelectionStart).ToString("dd/MM/yyyy");
        }

        private void txtSomenteNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se é numero e tecla backspace (char)8 da Tabela ASCII, ambos permitidos O
            // resto não é permitido ser digitado no campo
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void btnCalcularIdade_Click(object sender, EventArgs e)
        {
            int idade = DateTime.Now.Year - dtpIdade.Value.Year;

            if (DateTime.Now.Month < dtpIdade.Value.Month)
            {
                idade = idade - 1;
            }
            else
            {
                if (DateTime.Now.Month == dtpIdade.Value.Month && DateTime.Now.Day < dtpIdade.Value.Day)
                {
                    idade = idade - 1;
                }
            }

            MessageBox.Show("Voce tem " + Convert.ToString(idade) + " anos!");
        }

        private void btnIndexOf_Click(object sender, EventArgs e)
        {
            // A função IndexOf verificar se um determinado caracter existe em uma string e retorna
            // o numero de sua posição. Se não existir afunção retorna o numero 0

            if (!string.IsNullOrWhiteSpace(txtExemplo.Text))
            {
                if (txtExemplo.Text.IndexOf("@") > 0)
                {
                    MessageBox.Show("Endereço de Email Válido!",
                       Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Endereço de Email Inválido!",
                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Digite um email no campo abaixo para verificação",
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtExemplo.Clear();
                txtExemplo.Focus();
            }
        }

        private void btnToUpper_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtExemplo.Text))
            {
                txtExemplo.Text = "Eduardo Volpi de Almeida";
            }
            txtExemplo.Text = txtExemplo.Text.ToUpper();
        }

        private void btnToLower_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtExemplo.Text))
            {
                txtExemplo.Text = "Eduardo Volpi de Almeida";
            }
            txtExemplo.Text = txtExemplo.Text.ToLower();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            lblTitle.Text = "";
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            btnBotaoComImagem.Enabled = checkBox1.Checked;
        }

        private void btnBotaoComImagem_Click(object sender, EventArgs e)
        {
            string mensagem;

            mensagem = ("Este botão utiliza alinhamento da imagem," +
                nl + "alinhamento de texto e padding para posicionar" +
                nl + "corretamente os elementos." + nl + nl +
                "O código também tem exemplo de como" + nl +
                "posicionar um texto em uma nova linha," + nl +
                "como feito nesta mensagem, sendo que a" + nl
                + "'string nl' está declarada na classe (no topo)");

            MessageBox.Show(mensagem, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOS_Click(object sender, EventArgs e)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                MessageBox.Show("Seu sistema operacional é Linux.", Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                MessageBox.Show("Seu sistema operacional é macOS.", Application.ProductName,
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                MessageBox.Show("Seu sistema operacional é Windows.", Application.ProductName,
                  MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void frmExemplos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja fechar a aplicação?", Application.ProductName,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            /*
             * Comando goto utilizado várias vezes neste código
             */

            // Variaveis que conterão os numeros
            string num1, num2, num3, num4, num5, num6;

            //Primeiro crio o objeto do tipo Random
            Random r = new Random();

            // Defino um array de 6 posições que guardarão 6 numeros aleatorios
            int[] numsMegaSena = new int[6];

// Label para usar o comando goto mais abaixo
Inicio:

// Preencho a array de 6 numeros
            for (int i = 0; i < numsMegaSena.Length; i++)
            {
                numsMegaSena[i] = r.Next(1, 61);
            }

            #region Controle para evitar numeros repetidos

            // Agora faço o controle para evitar numeros repetidos

            // Controle Numero Repetido para indice 0
            if (numsMegaSena[0] == numsMegaSena[1] || numsMegaSena[0] == numsMegaSena[2] || numsMegaSena[0] == numsMegaSena[3]
                || numsMegaSena[0] == numsMegaSena[4] || numsMegaSena[0] == numsMegaSena[5])
            {
                goto Inicio;
            }

            // Controle Numero Repetido para indice 1
            if (numsMegaSena[1] == numsMegaSena[0] || numsMegaSena[1] == numsMegaSena[2] || numsMegaSena[1] == numsMegaSena[3]
                || numsMegaSena[1] == numsMegaSena[4] || numsMegaSena[1] == numsMegaSena[5])
            {
                goto Inicio;
            }

            // Controle Numero Repetido para indice 2
            if (numsMegaSena[2] == numsMegaSena[0] || numsMegaSena[2] == numsMegaSena[1] || numsMegaSena[2] == numsMegaSena[3]
                || numsMegaSena[2] == numsMegaSena[4] || numsMegaSena[2] == numsMegaSena[5])
            {
                goto Inicio;
            }

            // Controle Numero Repetido para indice 3
            if (numsMegaSena[3] == numsMegaSena[0] || numsMegaSena[3] == numsMegaSena[1] || numsMegaSena[3] == numsMegaSena[2]
                || numsMegaSena[3] == numsMegaSena[4] || numsMegaSena[3] == numsMegaSena[5])
            {
                goto Inicio;
            }

            // Controle Numero Repetido para indice 4
            if (numsMegaSena[4] == numsMegaSena[0] || numsMegaSena[4] == numsMegaSena[1] || numsMegaSena[4] == numsMegaSena[2]
                || numsMegaSena[4] == numsMegaSena[3] || numsMegaSena[4] == numsMegaSena[5])
            {
                goto Inicio;
            }

            // Controle Numero Repetido para indice 5
            if (numsMegaSena[5] == numsMegaSena[0] || numsMegaSena[5] == numsMegaSena[1] || numsMegaSena[5] == numsMegaSena[2]
                || numsMegaSena[5] == numsMegaSena[3] || numsMegaSena[5] == numsMegaSena[4])
            {
                goto Inicio;
            }

            #endregion

            #region Ordeno os numeros do array

            // Ordenos os números do Array em ordem crescente
            Array.Sort(numsMegaSena);

            // Poderia ser em ordem decrescente, como abaixo
            //Array.Reverse(numsMegaSena);

            #endregion

            #region Já transformo em string e coloco 0 na frente de numeros de 1 a 9

            if (numsMegaSena[0] == 1 || numsMegaSena[0] == 2 || numsMegaSena[0] == 3
               || numsMegaSena[0] == 4 || numsMegaSena[0] == 5 || numsMegaSena[0] == 6
               || numsMegaSena[0] == 7 || numsMegaSena[0] == 8 || numsMegaSena[0] == 9)
            {
                num1 = numsMegaSena[0].ToString().PadLeft(2, '0');
            }
            else
            {
                num1 = numsMegaSena[0].ToString();
            }

            if (numsMegaSena[1] == 1 || numsMegaSena[1] == 2 || numsMegaSena[1] == 3
               || numsMegaSena[1] == 4 || numsMegaSena[1] == 5 || numsMegaSena[1] == 6
               || numsMegaSena[1] == 7 || numsMegaSena[1] == 8 || numsMegaSena[1] == 9)
            {
                num2 = numsMegaSena[1].ToString().PadLeft(2, '0');
            }
            else
            {
                num2 = numsMegaSena[1].ToString();
            }

            if (numsMegaSena[2] == 1 || numsMegaSena[2] == 2 || numsMegaSena[2] == 3
               || numsMegaSena[2] == 4 || numsMegaSena[2] == 5 || numsMegaSena[2] == 6
               || numsMegaSena[2] == 7 || numsMegaSena[2] == 8 || numsMegaSena[2] == 9)
            {
                num3 = numsMegaSena[2].ToString().PadLeft(2, '0');
            }
            else
            {
                num3 = numsMegaSena[2].ToString();
            }

            if (numsMegaSena[3] == 1 || numsMegaSena[3] == 2 || numsMegaSena[3] == 3
               || numsMegaSena[3] == 4 || numsMegaSena[3] == 5 || numsMegaSena[3] == 6
               || numsMegaSena[3] == 7 || numsMegaSena[3] == 8 || numsMegaSena[3] == 9)
            {
                num4 = numsMegaSena[3].ToString().PadLeft(2, '0');
            }
            else
            {
                num4 = numsMegaSena[3].ToString();
            }

            if (numsMegaSena[4] == 1 || numsMegaSena[4] == 2 || numsMegaSena[4] == 3
               || numsMegaSena[4] == 4 || numsMegaSena[4] == 5 || numsMegaSena[4] == 6
               || numsMegaSena[4] == 7 || numsMegaSena[4] == 8 || numsMegaSena[4] == 9)
            {
                num5 = numsMegaSena[4].ToString().PadLeft(2, '0');
            }
            else
            {
                num5 = numsMegaSena[4].ToString();
            }

            if (numsMegaSena[5] == 1 || numsMegaSena[5] == 2 || numsMegaSena[5] == 3
               || numsMegaSena[5] == 4 || numsMegaSena[5] == 5 || numsMegaSena[5] == 6
               || numsMegaSena[5] == 7 || numsMegaSena[5] == 8 || numsMegaSena[5] == 9)
            {
                num6 = numsMegaSena[5].ToString().PadLeft(2, '0');
            }
            else
            {
                num6 = numsMegaSena[5].ToString();
            }

            #endregion

            #region Exibo e Salvo os Números Sorteados

            // Agora vou exibir os numeros em um messagebox
            string mensagem;

            mensagem = "Números da MegaSena:" + nl + nl
                + num1 + " - " + num2 + " - " + num3 + " - " + num4 + " - " + num5 + " - " + num6;

            if (MessageBox.Show(mensagem + nl + nl + "Deseja salvar os números na Área de Trabalho (Desktop)?",
                Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {

                // Vou salvar em um arquivo de texto no Desktop
                string arquivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MegaSena.txt";
                // Extrai do caminho o nome do arquivo
                string nomeArquivo = Path.GetFileName(arquivo);

                // Verifico se o arquivo já existe
                if (File.Exists(arquivo))
                {
                    if (MessageBox.Show("O Arquivo " + nomeArquivo + " já existe na Área de Trabalho." + nl + "Deseja sobrescreve-lo?", Application.ProductName,
                         MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    {
                        return;
                    }
                    else goto gravaNumeros;
                }
                else goto gravaNumeros;
            }
            else return;
gravaNumeros:
            try
            {
                string arquivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MegaSena.txt";
                StreamWriter gravar = new StreamWriter(arquivo);
                gravar.WriteLine(mensagem);
                gravar.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu um Erro:" + nl + erro.Message, Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("Números salvos na Área de Trabalho", Application.ProductName,
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion
        }

        private void btnAbrirFormDados_Click(object sender, EventArgs e)
        {
            // Aqui, quando instancio o form que vou abrir eu passo
            // o texto do campo txtNome como parametro requerido
            // devido a requisição feita na inicialização do frmPassagemDados(veja lá o código para entender)

            Form f = new frmPassagemDados(txtNome.Text);
            f.ShowDialog();
        }
        private void mnuSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void btnVariaveisConstantes_Click(object sender, EventArgs e)
        {
            Form abrir = new frmVariavesiConstantes();
            abrir.ShowDialog();
        }

        private void btnTiposDados_Click(object sender, EventArgs e)
        {
            Form TiposDados = new frmTiposDados();
            TiposDados.ShowDialog();
        }
    }
}