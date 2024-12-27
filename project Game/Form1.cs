using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool right, left, space;
        int score;


        void game_result()
        {
            foreach (Control j in this.Controls)
            {
                foreach (Control i in this.Controls) 
                { 

                    if (j is PictureBox && j.Tag=="bullete")
                {
                    if (i is PictureBox && i.Tag=="enemy")
                        {
                            if (j.Bounds.IntersectsWith(i.Bounds))
                            {
                                i.Top = -100;
                                score ++;
                                label1.Text = score.ToString();
                                this.Controls.Remove(j);

                            }
                        }

                }

                }

            }

            if (player.Bounds.IntersectsWith(enemy1.Bounds)|| player.Bounds.IntersectsWith(enemy2.Bounds)
                || player.Bounds.IntersectsWith(enemy3.Bounds) || player.Bounds.IntersectsWith(enemy4.Bounds))
            {
                timer1.Stop();
                label2.Visible = true;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void stars_move()
        {
          foreach (Control n in this.Controls)
            {
                if (n is PictureBox && n.Tag=="stars")
                {
                    n.Top += 10;
                    if(n.Top>400)
                    {
                        n.Top = 0;

                    }

                }
            }
        }


        void add_bulle()
        {
            PictureBox bullet = new PictureBox();
            bullet.SizeMode = PictureBoxSizeMode.StretchImage;
            bullet.Size = new Size(15, 15);
            bullet.Image = Properties.Resources.bullet;
            bullet.BackColor = Color.Transparent;
            bullet.Tag = "bullete";
            bullet.Left = player.Left + 15;
            bullet.Top = player.Top - 30;
            this.Controls.Add(bullet);
            bullet.BringToFront();
        }


        void bullet_move()
        {
            foreach (Control f in this.Controls)
            {
                if (f is PictureBox && f.Tag =="bullete")
                {
                    f.Top -= 10;
                    if (f.Top < 100)
                    {
                        this.Controls.Remove(f);
                    }
                }
            }
        }

        void enemymove()
        {
            Random r = new Random();
            int x, y, z, c;
            if (enemy1.Top>=500)
            {
                x = r.Next(0, 300);
                enemy1.Location = new Point(x, 0);

            }
            if (enemy2.Top >= 500)
            {
                y = r.Next(0, 300);
                enemy2.Location = new Point(y, 0);

            }
            if (enemy3.Top >= 500)
            {
                z = r.Next(0, 300);
                enemy3.Location = new Point(z, 0);

            }
            if (enemy4.Top >= 500)
            {
                c = r.Next(0, 300);
                enemy4.Location = new Point(c, 0);

            }
            enemy1.Top += 15;
            enemy2.Top += 5;
            enemy3 .Top+= 10;
            enemy4 .Top+=6;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            stars_move();
            player_move();
            bullet_move();
            enemymove();
            game_result();
        }
        void player_move()
        {
            if ( right == true )
            {
                if (player.Left<425)
                {
                    player.Left += 20;
                }

            }

            if (left == true)
            {
                if (player.Left > 10)
                {
                    player.Left -= 20;
                }

            }



        }


        private void pictureBox22_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox25_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }
            if(e.KeyCode == Keys.Space)
            {
                space = true;
                add_bulle();

            } 

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right)
            {
                right = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
        }
    }
}
