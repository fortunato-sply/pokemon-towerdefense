namespace pokemon_towerdefense
{
    partial class Pause
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.container = new System.Windows.Forms.Panel();
            this.options = new System.Windows.Forms.Panel();
            this.exitButton = new pokemon_towerdefense.CustomizedControls.RoundedButton();
            this.playButton = new pokemon_towerdefense.CustomizedControls.RoundedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.container.SuspendLayout();
            this.options.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.container.Controls.Add(this.label1);
            this.container.Controls.Add(this.options);
            this.container.Location = new System.Drawing.Point(1, 2);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(787, 405);
            this.container.TabIndex = 0;
            // 
            // options
            // 
            this.options.BackColor = System.Drawing.Color.Transparent;
            this.options.Controls.Add(this.exitButton);
            this.options.Controls.Add(this.playButton);
            this.options.ForeColor = System.Drawing.Color.Transparent;
            this.options.Location = new System.Drawing.Point(222, 117);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(358, 175);
            this.options.TabIndex = 2;
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
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
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
            this.playButton.Text = "Voltar";
            this.playButton.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(328, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 55);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pause";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Pause
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.container);
            this.Name = "Pause";
            this.Text = "Pause";
            this.Load += new System.EventHandler(this.Pause_Load);
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.options.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.Panel options;
        private CustomizedControls.RoundedButton exitButton;
        private CustomizedControls.RoundedButton playButton;
        private System.Windows.Forms.Label label1;
    }
}