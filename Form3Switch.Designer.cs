namespace Exemplos {
    partial class Form3Switch {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3Switch));
            this.btnFechar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.radioBtnWingChun = new System.Windows.Forms.RadioButton();
            this.radioBtnHungGar = new System.Windows.Forms.RadioButton();
            this.radioBtnMantis = new System.Windows.Forms.RadioButton();
            this.radioBtnCLF = new System.Windows.Forms.RadioButton();
            this.lblResultado = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Location = new System.Drawing.Point(391, 204);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(88, 30);
            this.btnFechar.TabIndex = 0;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(26, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Qual o melhor estilo de Kung Fu?";
            // 
            // radioBtnWingChun
            // 
            this.radioBtnWingChun.AutoSize = true;
            this.radioBtnWingChun.Location = new System.Drawing.Point(30, 96);
            this.radioBtnWingChun.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioBtnWingChun.Name = "radioBtnWingChun";
            this.radioBtnWingChun.Size = new System.Drawing.Size(85, 19);
            this.radioBtnWingChun.TabIndex = 2;
            this.radioBtnWingChun.TabStop = true;
            this.radioBtnWingChun.Tag = "";
            this.radioBtnWingChun.Text = "Wing Chun";
            this.radioBtnWingChun.UseVisualStyleBackColor = true;
            this.radioBtnWingChun.CheckedChanged += new System.EventHandler(this.radioBtnWingChun_CheckedChanged);
            // 
            // radioBtnHungGar
            // 
            this.radioBtnHungGar.AutoSize = true;
            this.radioBtnHungGar.Location = new System.Drawing.Point(146, 96);
            this.radioBtnHungGar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioBtnHungGar.Name = "radioBtnHungGar";
            this.radioBtnHungGar.Size = new System.Drawing.Size(76, 19);
            this.radioBtnHungGar.TabIndex = 3;
            this.radioBtnHungGar.TabStop = true;
            this.radioBtnHungGar.Text = "Hung Gar";
            this.radioBtnHungGar.UseVisualStyleBackColor = true;
            this.radioBtnHungGar.CheckedChanged += new System.EventHandler(this.radioBtnHungGar_CheckedChanged);
            // 
            // radioBtnMantis
            // 
            this.radioBtnMantis.AutoSize = true;
            this.radioBtnMantis.Location = new System.Drawing.Point(252, 96);
            this.radioBtnMantis.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioBtnMantis.Name = "radioBtnMantis";
            this.radioBtnMantis.Size = new System.Drawing.Size(61, 19);
            this.radioBtnMantis.TabIndex = 4;
            this.radioBtnMantis.TabStop = true;
            this.radioBtnMantis.Text = "Mantis";
            this.radioBtnMantis.UseVisualStyleBackColor = true;
            this.radioBtnMantis.CheckedChanged += new System.EventHandler(this.radioBtnMantis_CheckedChanged);
            // 
            // radioBtnCLF
            // 
            this.radioBtnCLF.AutoSize = true;
            this.radioBtnCLF.Location = new System.Drawing.Point(348, 96);
            this.radioBtnCLF.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioBtnCLF.Name = "radioBtnCLF";
            this.radioBtnCLF.Size = new System.Drawing.Size(85, 19);
            this.radioBtnCLF.TabIndex = 5;
            this.radioBtnCLF.TabStop = true;
            this.radioBtnCLF.Text = "Choy Li Fut";
            this.radioBtnCLF.UseVisualStyleBackColor = true;
            this.radioBtnCLF.CheckedChanged += new System.EventHandler(this.radioBtnCLF_CheckedChanged);
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblResultado.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblResultado.Location = new System.Drawing.Point(26, 143);
            this.lblResultado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(84, 18);
            this.lblResultado.TabIndex = 6;
            this.lblResultado.Text = "Resultado";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(30, 204);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 30);
            this.button1.TabIndex = 7;
            this.button1.Text = "&Resultado";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3Switch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 250);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.radioBtnCLF);
            this.Controls.Add(this.radioBtnMantis);
            this.Controls.Add(this.radioBtnHungGar);
            this.Controls.Add(this.radioBtnWingChun);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3Switch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exemplos C# - Comando Switch";
            this.Load += new System.EventHandler(this.Form3Switch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioBtnWingChun;
        private System.Windows.Forms.RadioButton radioBtnHungGar;
        private System.Windows.Forms.RadioButton radioBtnMantis;
        private System.Windows.Forms.RadioButton radioBtnCLF;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Button button1;
    }
}