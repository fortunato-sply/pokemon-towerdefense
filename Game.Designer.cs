namespace pokemon_towerdefense
{
    partial class Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.PbScreen = new System.Windows.Forms.PictureBox();
            this.inventoryPanel = new pokemon_towerdefense.CustomizedControls.RoundedPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.roundedPanel7 = new pokemon_towerdefense.CustomizedControls.RoundedPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.speedPanel1 = new pokemon_towerdefense.CustomizedControls.RoundedPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.speedPanel2 = new pokemon_towerdefense.CustomizedControls.RoundedPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.speedPanel4 = new pokemon_towerdefense.CustomizedControls.RoundedPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.speedPanel6 = new pokemon_towerdefense.CustomizedControls.RoundedPanel();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbScreen)).BeginInit();
            this.inventoryPanel.SuspendLayout();
            this.roundedPanel7.SuspendLayout();
            this.speedPanel1.SuspendLayout();
            this.speedPanel2.SuspendLayout();
            this.speedPanel4.SuspendLayout();
            this.speedPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // PbScreen
            // 
            this.PbScreen.BackColor = System.Drawing.Color.Transparent;
            this.PbScreen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PbScreen.BackgroundImage")));
            this.PbScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PbScreen.Location = new System.Drawing.Point(-5, 0);
            this.PbScreen.Name = "PbScreen";
            this.PbScreen.Size = new System.Drawing.Size(1928, 1097);
            this.PbScreen.TabIndex = 6;
            this.PbScreen.TabStop = false;
            // 
            // inventoryPanel
            // 
            this.inventoryPanel.BackColor = System.Drawing.Color.Red;
            this.inventoryPanel.Controls.Add(this.label6);
            this.inventoryPanel.Location = new System.Drawing.Point(1540, 977);
            this.inventoryPanel.Name = "inventoryPanel";
            this.inventoryPanel.Radius = 10;
            this.inventoryPanel.Size = new System.Drawing.Size(179, 60);
            this.inventoryPanel.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 37);
            this.label6.TabIndex = 1;
            this.label6.Text = "Inventory";
            // 
            // roundedPanel7
            // 
            this.roundedPanel7.BackColor = System.Drawing.Color.Black;
            this.roundedPanel7.Controls.Add(this.label1);
            this.roundedPanel7.Location = new System.Drawing.Point(12, 986);
            this.roundedPanel7.Name = "roundedPanel7";
            this.roundedPanel7.Radius = 10;
            this.roundedPanel7.Size = new System.Drawing.Size(527, 63);
            this.roundedPanel7.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(33, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Speed";
            // 
            // speedPanel1
            // 
            this.speedPanel1.BackColor = System.Drawing.Color.Red;
            this.speedPanel1.Controls.Add(this.label2);
            this.speedPanel1.Location = new System.Drawing.Point(207, 989);
            this.speedPanel1.Name = "speedPanel1";
            this.speedPanel1.Radius = 10;
            this.speedPanel1.Size = new System.Drawing.Size(69, 57);
            this.speedPanel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "1X";
            // 
            // speedPanel2
            // 
            this.speedPanel2.BackColor = System.Drawing.Color.DarkRed;
            this.speedPanel2.Controls.Add(this.label3);
            this.speedPanel2.Location = new System.Drawing.Point(292, 989);
            this.speedPanel2.Name = "speedPanel2";
            this.speedPanel2.Radius = 10;
            this.speedPanel2.Size = new System.Drawing.Size(69, 57);
            this.speedPanel2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 37);
            this.label3.TabIndex = 2;
            this.label3.Text = "2X";
            // 
            // speedPanel4
            // 
            this.speedPanel4.BackColor = System.Drawing.Color.DarkRed;
            this.speedPanel4.Controls.Add(this.label4);
            this.speedPanel4.Location = new System.Drawing.Point(380, 989);
            this.speedPanel4.Name = "speedPanel4";
            this.speedPanel4.Radius = 10;
            this.speedPanel4.Size = new System.Drawing.Size(69, 57);
            this.speedPanel4.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 37);
            this.label4.TabIndex = 3;
            this.label4.Text = "4X";
            // 
            // speedPanel6
            // 
            this.speedPanel6.BackColor = System.Drawing.Color.DarkRed;
            this.speedPanel6.Controls.Add(this.label5);
            this.speedPanel6.Location = new System.Drawing.Point(468, 989);
            this.speedPanel6.Name = "speedPanel6";
            this.speedPanel6.Radius = 10;
            this.speedPanel6.Size = new System.Drawing.Size(69, 57);
            this.speedPanel6.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 37);
            this.label5.TabIndex = 4;
            this.label5.Text = "6X";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.speedPanel6);
            this.Controls.Add(this.speedPanel4);
            this.Controls.Add(this.speedPanel2);
            this.Controls.Add(this.speedPanel1);
            this.Controls.Add(this.roundedPanel7);
            this.Controls.Add(this.inventoryPanel);
            this.Controls.Add(this.PbScreen);
            this.Name = "Game";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbScreen)).EndInit();
            this.inventoryPanel.ResumeLayout(false);
            this.inventoryPanel.PerformLayout();
            this.roundedPanel7.ResumeLayout(false);
            this.roundedPanel7.PerformLayout();
            this.speedPanel1.ResumeLayout(false);
            this.speedPanel1.PerformLayout();
            this.speedPanel2.ResumeLayout(false);
            this.speedPanel2.PerformLayout();
            this.speedPanel4.ResumeLayout(false);
            this.speedPanel4.PerformLayout();
            this.speedPanel6.ResumeLayout(false);
            this.speedPanel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private CustomizedControls.RoundedPanel inventoryPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox PbScreen;
        private CustomizedControls.RoundedPanel roundedPanel7;
        private System.Windows.Forms.Label label1;
        private CustomizedControls.RoundedPanel speedPanel1;
        private System.Windows.Forms.Label label2;
        private CustomizedControls.RoundedPanel speedPanel2;
        private System.Windows.Forms.Label label3;
        private CustomizedControls.RoundedPanel speedPanel4;
        private System.Windows.Forms.Label label4;
        private CustomizedControls.RoundedPanel speedPanel6;
        private System.Windows.Forms.Label label5;
    }
}