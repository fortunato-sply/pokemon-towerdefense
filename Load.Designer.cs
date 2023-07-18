namespace pokemon_towerdefense
{
    partial class Load
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.exitButton = new pokemon_towerdefense.CustomizedControls.RoundedButton();
            this.playButton = new pokemon_towerdefense.CustomizedControls.RoundedButton();
            this.arcanine = new System.Windows.Forms.PictureBox();
            this.logo = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arcanine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.exitButton);
            this.panel1.Controls.Add(this.playButton);
            this.panel1.ForeColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(399, 237);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 175);
            this.panel1.TabIndex = 1;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Red;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Location = new System.Drawing.Point(84, 94);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(205, 64);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Sair";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.roundedButton2_Click);
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.Red;
            this.playButton.FlatAppearance.BorderSize = 0;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.playButton.ForeColor = System.Drawing.Color.White;
            this.playButton.Location = new System.Drawing.Point(84, 24);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(205, 64);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "Jogar";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.roundedButton1_Click);
            // 
            // arcanine
            // 
            this.arcanine.BackgroundImage = global::pokemon_towerdefense.Properties.Resources.arcaninelogo;
            this.arcanine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.arcanine.Location = new System.Drawing.Point(763, 394);
            this.arcanine.Name = "arcanine";
            this.arcanine.Size = new System.Drawing.Size(570, 437);
            this.arcanine.TabIndex = 2;
            this.arcanine.TabStop = false;
            this.arcanine.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // logo
            // 
            this.logo.BackColor = System.Drawing.Color.Transparent;
            this.logo.BackgroundImage = global::pokemon_towerdefense.Properties.Resources.logo;
            this.logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logo.Location = new System.Drawing.Point(351, -28);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(571, 322);
            this.logo.TabIndex = 3;
            this.logo.TabStop = false;
            this.logo.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1181, 647);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.arcanine);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.arcanine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomizedControls.RoundedButton playButton;
        private System.Windows.Forms.Panel panel1;
        private CustomizedControls.RoundedButton exitButton;
        private System.Windows.Forms.PictureBox arcanine;
        private System.Windows.Forms.PictureBox logo;
    }
}

