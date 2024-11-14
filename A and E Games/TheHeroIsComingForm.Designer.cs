namespace A_and_E_Games
{
    partial class TheHeroIsComingForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TheHeroIsComingForm));
            this.scoreText = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.Superhero = new System.Windows.Forms.PictureBox();
            this.ObstacleBottom = new System.Windows.Forms.PictureBox();
            this.ObstacleTop = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Superhero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObstacleBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObstacleTop)).BeginInit();
            this.SuspendLayout();
            // 
            // scoreText
            // 
            this.scoreText.AutoSize = true;
            this.scoreText.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreText.Location = new System.Drawing.Point(12, 9);
            this.scoreText.Name = "scoreText";
            this.scoreText.Size = new System.Drawing.Size(109, 31);
            this.scoreText.TabIndex = 3;
            this.scoreText.Text = "Score: 0";
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimerEvent);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Press E to Exit the game.";
            // 
            // Superhero
            // 
            this.Superhero.Image = global::A_and_E_Games.Properties.Resources.The_hero_is_coming_CHARACTER;
            this.Superhero.Location = new System.Drawing.Point(59, 354);
            this.Superhero.Name = "Superhero";
            this.Superhero.Size = new System.Drawing.Size(86, 92);
            this.Superhero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Superhero.TabIndex = 0;
            this.Superhero.TabStop = false;
            // 
            // ObstacleBottom
            // 
            this.ObstacleBottom.Image = global::A_and_E_Games.Properties.Resources.The_hero_is_coming_OBSTACLE;
            this.ObstacleBottom.Location = new System.Drawing.Point(531, 0);
            this.ObstacleBottom.Name = "ObstacleBottom";
            this.ObstacleBottom.Size = new System.Drawing.Size(62, 239);
            this.ObstacleBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ObstacleBottom.TabIndex = 2;
            this.ObstacleBottom.TabStop = false;
            this.ObstacleBottom.Tag = "obstacle";
            // 
            // ObstacleTop
            // 
            this.ObstacleTop.Image = ((System.Drawing.Image)(resources.GetObject("ObstacleTop.Image")));
            this.ObstacleTop.Location = new System.Drawing.Point(394, 468);
            this.ObstacleTop.Name = "ObstacleTop";
            this.ObstacleTop.Size = new System.Drawing.Size(62, 239);
            this.ObstacleTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ObstacleTop.TabIndex = 1;
            this.ObstacleTop.TabStop = false;
            this.ObstacleTop.Tag = "obstacle";
            // 
            // TheHeroIsComingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(622, 707);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Superhero);
            this.Controls.Add(this.scoreText);
            this.Controls.Add(this.ObstacleBottom);
            this.Controls.Add(this.ObstacleTop);
            this.Name = "TheHeroIsComingForm";
            this.Text = "The hero is coming";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gamekeyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gamekeyisup);
            ((System.ComponentModel.ISupportInitialize)(this.Superhero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObstacleBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObstacleTop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Superhero;
        private System.Windows.Forms.PictureBox ObstacleTop;
        private System.Windows.Forms.PictureBox ObstacleBottom;
        private System.Windows.Forms.Label scoreText;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label label1;
    }
}