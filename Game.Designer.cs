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
            ((System.ComponentModel.ISupportInitialize)(this.PbScreen)).BeginInit();
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
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.PbScreen);
            this.Name = "Game";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox PbScreen;
    }
}