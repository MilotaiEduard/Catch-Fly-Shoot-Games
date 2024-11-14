using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace A_and_E_Games
{
    public partial class TheHeroIsComingForm : Form
    {

        int obstacleSpeed = 8;
        int gravity = 15;
        int score = 0;
        bool isGameOver = false;
   
        

        public TheHeroIsComingForm()
        {
            InitializeComponent();

            GameReset();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            Superhero.Top += gravity;
            ObstacleBottom.Left -= obstacleSpeed;
            ObstacleTop.Left -= obstacleSpeed;
            scoreText.Text = "Score: " + score;

            if(ObstacleBottom.Left < -150)
            {
                ObstacleBottom.Left = 800;
                score++;
            }

            if(ObstacleTop.Left < -180)
            {
                ObstacleTop.Left = 950;
                score++;
            }

            if(Superhero.Bounds.IntersectsWith(ObstacleBottom.Bounds) || Superhero.Bounds.IntersectsWith(ObstacleTop.Bounds) || Superhero.Top < -25)
            {
                endGame();
                isGameOver = true;
            }

            if(score > 5)
            {
                obstacleSpeed = 12;
            }

            if(score > 10)
            {
                obstacleSpeed = 15;
            }

            if(score > 15)
            {
                obstacleSpeed = 18;
            }

        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }


        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }

            if(e.KeyCode == Keys.R && isGameOver == true)
            {
                GameReset();
            }

            if(e.KeyCode == Keys.E)
            {
                new MainForm().Show();
                this.Close();
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game over! Press R to Restart the game.";
            isGameOver = true;
        }

        private void GameReset()
        {

            Superhero.Location = new Point(59, 354);
            ObstacleTop.Left = 800;
            ObstacleBottom.Left = 1200;

            obstacleSpeed = 8;
            gravity = 15;
            score = 0;
            scoreText.Text = "Score: " + score;
            isGameOver = false;
            



            gameTimer.Start();
        }
    }
}
