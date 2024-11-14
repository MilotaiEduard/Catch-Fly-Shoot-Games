using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_and_E_Games
{
    public partial class EasterBunnyAndTheEggs : Form
    {

        bool goLeft, goRight;

        int speed = 8;
        int score = 0;
        int missed = 0;

        Random randX= new Random();
        Random randY= new Random();

        PictureBox splash = new PictureBox();





        public EasterBunnyAndTheEggs()
        {
            InitializeComponent();
            RestartGame();
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            textScore.Text = "Saved: " + score;
            textMissed.Text = "Missed: " + missed;

            if(goLeft == true && bunny.Left > 0)
            {
                bunny.Left -= 12;
                bunny.Image = Properties.Resources.BunnyLeft;
            }

            if(goRight == true  && bunny.Left + bunny.Width < this.ClientSize.Width)
            {
                bunny.Left += 12;
                bunny.Image = Properties.Resources.BunnyRight;
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "eggs")
                {
                    x.Top += speed;


                    if(x.Top + x.Height > this.ClientSize.Height)
                    {

                        splash.Image = Properties.Resources.SplashedEgg;
                        splash.Location = x.Location;
                        splash.Height = 80;
                        splash.Width = 80;
                       
                        splash.BackColor = Color.Transparent;

                        this.Controls.Add(splash);  

                        x.Top = randY.Next(80, 300) * -1;
                        x.Left = randX.Next(5,this.ClientSize.Width - x.Width);
                        missed += 1;
                    }

                    if(bunny.Bounds.IntersectsWith(x.Bounds))
                    {
                        x.Top = randY.Next(80, 300) * -1;
                        x.Left = randX.Next(5, this.ClientSize.Width - x.Width);
                        score += 1;
                    }
                }

            }

            if(score > 10)
            {
                speed = 12;
            }

            if(missed > 5)
            {
                GameTimer.Stop();
                MessageBox.Show("Game Over!" + Environment.NewLine + "Press OK to try again.");
                RestartGame();
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }

            if(e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }

            if(e.KeyCode == Keys.E)
            {
                new MainForm().Show();
                this.Close();
            }
        }

        private void RestartGame()
        {
            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "eggs")
                {
                    x.Top = randY.Next(80,300) * - 1;
                    x.Left = randX.Next(5,this.ClientSize.Width - x.Width);
                }

            }

            bunny.Left = this.ClientSize.Width / 2;
            bunny.Image = Properties.Resources.BunnyLeft;

            score = 0;
            missed = 0;
            speed = 8;

            goLeft = false;
            goRight = false;

            GameTimer.Start();



        }
    }
}
