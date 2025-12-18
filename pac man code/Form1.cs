using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pac_man_code
{
    public partial class Form1 : Form
    {
        bool goup, godown, goleft, goright, isGameOver;

        int score, playerSpeed, redGhostSpeed, yellowGhostSpeed, pinkGhostX, pinkGhostY;

        private void pictureBox51_Click(object sender, EventArgs e)
        {

        }

        private void pinkghost_Click(object sender, EventArgs e)
        {

        }

        private void yellowghost_Click(object sender, EventArgs e)
        {

        }

        private void redghost_Click(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
            resetGame();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.Up)
            {
                goup = true;
            }

            if(e.KeyCode == Keys.Down)
            {
                godown = true;
            }

            if(e.KeyCode == Keys.Left)
            {
                goleft = true;
            }

            if(e.KeyCode == Keys.Right)
            {
                goright = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }

            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if(e.KeyCode == Keys.Enter && isGameOver == true)
            {
                resetGame();
            }
        }

        private void mainGameTimer(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;

            if (goleft == true)
            {
                pacman.Left -= playerSpeed;
                pacman.Image = Properties.Resources.left;
            }

            if (goright == true)
            {
                pacman.Left += playerSpeed;
                pacman.Image = Properties.Resources.right;
            }

            if (godown == true)
            {
                pacman.Top += playerSpeed;
                pacman.Image = Properties.Resources.down;
            }

            if (goup == true)
            {
                pacman.Top -= playerSpeed;
                pacman.Image = Properties.Resources.Up;
            }

            if (pacman.Left <= -10)
            {
                pacman.Left = 680;
            }

            if (pacman.Left > 680)
            {
                pacman.Left = -10;
            }

            if (pacman.Top < -10)
            {
                pacman.Top = 550;
            }
            if (pacman.Top > 550)
            {
                pacman.Top = 0;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "coin" && x.Visible == true)
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            score += 1;
                            x.Visible = false;
                        }

                    }

                    if((string)x.Tag == "wall" )
                    {
                        if(pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameOver("Drake heard you!");
                        }

                        if(pinkghost.Bounds.IntersectsWith(x.Bounds))
                        {
                            pinkGhostX = -pinkGhostX;
                        }
                    }
                    if((string)x.Tag == "ghost")
                    {
                        if(pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameOver("Drake got you!");
                        }
                    }
                }
            }
            //da se dvijat duhchetata
            redghost.Left += redGhostSpeed;
            if(redghost.Bounds.IntersectsWith(pictureBox1.Bounds) || redghost.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                redGhostSpeed = -redGhostSpeed;
            }

            yellowghost.Left -= yellowGhostSpeed;
            if (yellowghost.Bounds.IntersectsWith(pictureBox3.Bounds) || yellowghost.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                yellowGhostSpeed = -yellowGhostSpeed;
            }

            pinkghost.Left -= pinkGhostX;
            pinkghost.Top -= pinkGhostY;
            if(pinkghost.Top < 0 || pinkghost.Top > 520)
            {
                pinkGhostY = -pinkGhostY;
            }

            if (pinkghost.Left < 0 || pinkghost.Left > 620)
            {
                pinkGhostX = -pinkGhostX;
            }

            if (score == 62)
            {
                gameOver("You escaped Drakes basement!");
            }
        }

       

        private void resetGame()
        {

            txtScore.Text = "Score: 0";
            score = 0;

            redGhostSpeed = 5;
            yellowGhostSpeed = 5;
            pinkGhostX = 5;
            pinkGhostY = 5;
            playerSpeed = 8;

            isGameOver = false;

            pacman.Left = 31;
            pacman.Top = 46;

            redghost.Left = 233;
            redghost.Top = 40;

            yellowghost.Left = 315;
            yellowghost.Top = 433;

            pinkghost.Left = 487;
            pinkghost.Top = 187;

            foreach (Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    x.Visible = true;
                }
            }


            gameTimer.Start();
        }

        private void gameOver(string message)
        {
            isGameOver = true;
            gameTimer.Stop();
            txtScore.Text = "Score: " + score + Environment.NewLine + message;
        }

    }
}
