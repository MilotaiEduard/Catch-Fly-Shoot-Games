using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_and_E_Games
{
    public partial class RiseOfTheZombies : Form
    {

        bool goLeft, goRight, goUp, goDown, gameOver;
        string facing = "up";
        int humanHealth = 100;
        int score;
        int speed = 10;
        int ammo = 10;
        int zombieSpeed = 3;
        Random randNum = new Random();

        List<PictureBox> zombiesList = new List<PictureBox>();






        public RiseOfTheZombies()
        {
            InitializeComponent();
            RestartGame();
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            if(humanHealth > 1)
            {
                healthBar.Value = humanHealth;
            }
            else
            {
                gameOver = true;
                human.Image = Properties.Resources.HumanDead;
                GameTimer.Stop();
            }

            ammoText.Text = "Ammo: " + ammo;
            textScore.Text = "Score: " + score;

            if(goLeft == true && human.Left > 0)
            {
                human.Left -= speed;
            }

            if(goRight == true && human.Left + human.Width < this.ClientSize.Width)
            {
                human.Left += speed;
            }

            if(goUp == true && human.Top > 55)
            {
                human.Top -= speed;
            }

            if(goDown == true && human.Top + human.Height < this.ClientSize.Height)
            {
                human.Top += speed;
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "ammo")
                {
                    if(human.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        ammo += 5;
                    }
                }

                if(x is PictureBox && (string) x.Tag == "zombie")
                {

                    if(human.Bounds.IntersectsWith(x.Bounds))
                    {
                        humanHealth -= 1;
                    }


                    if(x.Left > human.Left)
                    {
                        x.Left -= zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.ZombieLeft;
                    }

                    if(x.Left < human.Left)
                    {
                        x.Left += zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.ZombieRight;
                    }

                    if(x.Top > human.Top)
                    {
                        x.Top -= zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.ZombieUp;
                    }

                    if(x.Top < human.Top)
                    {
                        x.Top += zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.ZombieDown;
                    }
                }

                foreach(Control j in this.Controls)
                {
                    if (j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "zombie") 
                    {
                        if(x.Bounds.IntersectsWith(j.Bounds))
                        {
                            score++;

                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            this.Controls.Remove(x);
                            ((PictureBox)x).Dispose();
                            zombiesList.Remove(((PictureBox)x));
                            MakeZombies();
                        }
                    }
                }
            }

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(gameOver == true)
            {
                return;
            }

            if(e.KeyCode == Keys.Left)
            {
                goLeft = true;
                facing = "left";
                human.Image = Properties.Resources.HumanLeft;
            }

            if(e.KeyCode == Keys.Right)
            {
                goRight = true;
                facing = "right";
                human.Image= Properties.Resources.HumanRight;
            }

            if(e.KeyCode == Keys.Up)
            {
                goUp = true;
                facing = "up";
                human.Image= Properties.Resources.HumanUp;
            }

            if(e.KeyCode == Keys.Down)
            {
                goDown = true;
                facing = "down";
                human.Image = Properties.Resources.HumanDown;
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

            if (e.KeyCode == Keys.Up)
            {
                goUp = false;     
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = false;       
            }

            if(e.KeyCode == Keys.Space && ammo > 0 && gameOver == false)
            {
                ammo--;
                ShootBullet(facing);

                if(ammo < 1)
                {
                    DropAmmo();
                }
            }

            if(e.KeyCode == Keys.R)
            {
                RestartGame();
            }

            if(e.KeyCode == Keys.E) 
            {
                new MainForm().Show();
                this.Close();
            }

        }

        private void ShootBullet(string direction)
        {
            Bullet shootBullet = new Bullet();
            shootBullet.direction = direction;
            shootBullet.bulletLeft = human.Left + (human.Width / 2);
            shootBullet.BulletTop = human.Top + (human.Height / 2);
            shootBullet.MakeBullet(this);
        }

        private void MakeZombies()
        {
            PictureBox zombie = new PictureBox();
            zombie.Tag = "zombie";
            zombie.Image = Properties.Resources.ZombieDown;
            zombie.BackColor = Color.Transparent;
            zombie.Size = new Size(83, 104);
            zombie.Left = randNum.Next(0, 900);
            zombie.Top = randNum.Next(0, 800);
            zombie.SizeMode = PictureBoxSizeMode.StretchImage;
            zombiesList.Add(zombie);
            this.Controls.Add(zombie);
            human.BringToFront();
        }

        private void DropAmmo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo_Image;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = randNum.Next(10, this.ClientSize.Width - ammo.Width); 
            ammo.Top = randNum.Next(60,this.ClientSize.Height - ammo.Height);
            ammo.Tag = "ammo";
            this.Controls.Add(ammo);

            ammo.BringToFront();
            human.BringToFront();
        }

        private void RestartGame()
        {
            human.Image = Properties.Resources.HumanUp;

            foreach(PictureBox i in zombiesList)
            {
                this.Controls.Remove(i);
            }

            zombiesList.Clear();

            for(int i = 0; i < 3; i++) 
            {
                MakeZombies();
            }

            goUp = false;
            goDown = false;
            goLeft = false;
            goRight = false;
            gameOver = false;

            humanHealth = 100;
            score = 0;
            ammo = 10;

            GameTimer.Start();
        }
    }
}
