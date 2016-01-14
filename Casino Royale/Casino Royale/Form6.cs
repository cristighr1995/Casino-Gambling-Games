using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Casino_Royale
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        Bitmap[] fruit = new Bitmap[6];
        PictureBox[,] matrice = new PictureBox[3, 3];
        Random rand = new Random();
        int credit;
        int k = 0;

        private void Form6_Load(object sender, EventArgs e)
        {
            int i, j;
            credit = 1000;

            fruit[0] = new Bitmap(Application.StartupPath + "\\slot\\cherry.jpg");
            fruit[1] = new Bitmap(Application.StartupPath + "\\slot\\grapes.jpg");
            fruit[2] = new Bitmap(Application.StartupPath + "\\slot\\lemon.jpg");
            fruit[3] = new Bitmap(Application.StartupPath + "\\slot\\melon.jpg");
            fruit[4] = new Bitmap(Application.StartupPath + "\\slot\\orange.jpg");
            fruit[5] = new Bitmap(Application.StartupPath + "\\slot\\plum.jpg");

            for (i = 0; i < 3; i++)
                for (j = 0; j < 3; j++)
                {
                    matrice[i, j] = new PictureBox();
                    matrice[i, j].Height = 130;
                    matrice[i, j].Width = 130;
                    matrice[i, j].Left = 20 + j * 130;
                    matrice[i, j].Top = 80 + i * 130;
                    matrice[i, j].BorderStyle = BorderStyle.FixedSingle;
                    matrice[i, j].BackgroundImage = fruit[rand.Next(0, 6)];
                    matrice[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    this.Controls.Add(matrice[i, j]);
                }

            button2.Enabled = false;
            label2.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
            button3.Cursor = Cursors.Hand;
            //
            label1.Size = new Size(50, 50);
            label1.Location = new Point(13, 9);
            //
            label6.Size = new Size(50, 50);
            label6.Location = new Point(69, 9);
            //
            label7.Size = new Size(50, 50);
            label7.Location = new Point(125, 9);
            //
            label8.Size = new Size(50, 50);
            label8.Location = new Point(181, 9);
            //
            label9.Size = new Size(50, 50);
            label9.Location = new Point(237, 9);
            //
            label10.Size = new Size(50, 50);
            label10.Location = new Point(293, 9);
            //
            label11.Size = new Size(50, 50);
            label11.Location = new Point(349, 9);
            //
            label12.Size = new Size(50, 50);
            label12.Location = new Point(405, 9);
            //
            label4.Location = new Point(457, 39);
            label4.TextAlign = ContentAlignment.TopLeft;
            label4.Font = new Font("Microsoft Sans Serif", 10);
            //
            label5.Location = new Point(623, 32);
            label5.Size = new Size(125, 31);
            label5.Font = new Font("Microsoft Sans Serif", 14);
            //
            label2.Location = new Point(453, 80);
            label2.TextAlign = ContentAlignment.TopLeft;
            label2.Font = new Font("Microsoft Sans Serif", 10);
            //
            textBox1.Size = new Size(291, 20);
            textBox1.Location = new Point(457, 103);
            //
            panel1.Size = new Size(254, 100);
            panel1.Location = new Point(477, 129);
            //
            label3.Location = new Point(4, 4);
            label3.TextAlign = ContentAlignment.TopLeft;
            label3.Font = new Font("Microsoft Sans Serif", 9);
            //
            radioButton1.Location = new Point(4, 26);
            radioButton1.Size = new Size(33, 20);
            radioButton1.Font = new Font("Microsoft Sans Serif", 10);
            //
            radioButton2.Location = new Point(4, 49);
            radioButton2.Size = new Size(33, 20);
            radioButton2.Font = new Font("Microsoft Sans Serif", 10);
            //
            radioButton3.Location = new Point(4, 73);
            radioButton3.Size = new Size(33, 20);
            radioButton3.Font = new Font("Microsoft Sans Serif", 10);
            //
            button1.Location = new Point(457, 247);
            button1.Size = new Size(291, 46);
            button1.Font = new Font("Microsoft Sans Serif", 14);
            //
            button2.Location = new Point(457, 299);
            button2.Size = new Size(291, 46);
            button2.Font = new Font("Microsoft Sans Serif", 14);
            //
            button3.Location = new Point(457, 351);
            button3.Size = new Size(291, 46);
            button3.Font = new Font("Microsoft Sans Serif", 14);
            //
            this.Size = new Size(775, 525);
        }

        //START
        private void button1_Click(object sender, EventArgs e)
        {
           if (textBox1.Text != "")
            {
                if (credit - Convert.ToInt32(textBox1.Text) >= 0)
                {
                    if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true)
                    {
                        if (radioButton1.Checked == true)
                        {
                            if (Convert.ToInt32(textBox1.Text) > 4)
                            {
                                for (int i = 0; i < 3; i++)
                                    for (int j = 0; j < 3; j++)
                                    {
                                        matrice[i, j].BackgroundImage = fruit[rand.Next(0, 6)];
                                        matrice[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                                    }
                                credit = credit - Convert.ToInt32(textBox1.Text);
                                label5.Text = credit.ToString();
                                timer1.Start();
                                button1.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("Please place a bet higher than 5!");
                            }
                        }
                        if (radioButton2.Checked == true)
                        {
                            if (Convert.ToInt32(textBox1.Text) > 19)
                            {
                                for (int i = 0; i < 3; i++)
                                    for (int j = 0; j < 3; j++)
                                    {
                                        matrice[i, j].BackgroundImage = fruit[rand.Next(0, 6)];
                                        matrice[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                                    }
                                credit = credit - Convert.ToInt32(textBox1.Text);
                                label5.Text = credit.ToString();
                                timer1.Start();
                                button1.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("Please place a bet higher than 20!");
                            }
                        }
                        if (radioButton3.Checked == true)
                        {
                            if (Convert.ToInt32(textBox1.Text) > 49)
                            {
                                for (int i = 0; i < 3; i++)
                                    for (int j = 0; j < 3; j++)
                                    {
                                        matrice[i, j].BackgroundImage = fruit[rand.Next(0, 6)];
                                        matrice[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                                    }
                                credit = credit - Convert.ToInt32(textBox1.Text);
                                label5.Text = credit.ToString();
                                timer1.Start();
                                button1.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("Please place a bet higher than 50!");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Choose line numbers!");
                    }
                }
                else
                {
                    MessageBox.Show("Insufficient credit");
                }
            }
            else
            {
                MessageBox.Show("Please place a bet sum!");
            }
        }

        //VERIFICA
        private void button2_Click(object sender, EventArgs e)
        {
            int verif;
            int verif2;
            button2.Enabled = false;
            if (radioButton1.Checked == true)
            {
                if (matrice[1, 0].BackgroundImage == matrice[1, 1].BackgroundImage && matrice[1, 0].BackgroundImage == matrice[1, 2].BackgroundImage && matrice[1, 1].BackgroundImage == matrice[1, 2].BackgroundImage)
                {
                    credit = credit + Convert.ToInt32(textBox1.Text) * 10;
                    label5.Text = credit.ToString();
                    MessageBox.Show("Congratulation! You have won " + (Convert.ToInt32(textBox1.Text) * 10).ToString() + " !");
                }
                else
                {
                    if (matrice[1, 0].BackgroundImage == matrice[1, 1].BackgroundImage)
                    {
                        credit = credit + Convert.ToInt32(textBox1.Text) * 2;
                        label5.Text = credit.ToString();
                        MessageBox.Show("Congratulation! You have won " + (Convert.ToInt32(textBox1.Text) * 2).ToString() + " !");
                    }
                    else
                        MessageBox.Show("Sorry! Maybe next time!");
                }
            }
            if (radioButton2.Checked == true)
            {
                verif = credit;
                if (matrice[0, 0].BackgroundImage == matrice[0, 1].BackgroundImage && matrice[0, 0].BackgroundImage == matrice[0, 2].BackgroundImage && matrice[0, 1].BackgroundImage == matrice[0, 2].BackgroundImage)
                {
                    credit = credit + Convert.ToInt32(textBox1.Text) * 8;
                }
                if (matrice[1, 0].BackgroundImage == matrice[1, 1].BackgroundImage && matrice[1, 0].BackgroundImage == matrice[1, 2].BackgroundImage && matrice[1, 1].BackgroundImage == matrice[1, 2].BackgroundImage)
                {
                    credit = credit + Convert.ToInt32(textBox1.Text) * 8;
                }
                if (matrice[2, 0].BackgroundImage == matrice[2, 1].BackgroundImage && matrice[2, 0].BackgroundImage == matrice[2, 2].BackgroundImage && matrice[2, 1].BackgroundImage == matrice[2, 2].BackgroundImage)
                {
                    credit = credit + Convert.ToInt32(textBox1.Text) * 8;
                }
                if (verif == credit)
                {
                    if(matrice[0,0].BackgroundImage == matrice[0,1].BackgroundImage)
                        credit = credit + Convert.ToInt32(textBox1.Text) * 2;
                    if (matrice[1, 0].BackgroundImage == matrice[1, 1].BackgroundImage)
                        credit = credit + Convert.ToInt32(textBox1.Text) * 2;
                    if (matrice[2, 0].BackgroundImage == matrice[2, 1].BackgroundImage)
                        credit = credit + Convert.ToInt32(textBox1.Text) * 2;
                    //daca tot nu s-a schimbat
                    if(verif == credit)
                        MessageBox.Show("Sorry! Maybe next time!");
                    else
                        MessageBox.Show("Congratulation! You have won " + (credit - verif).ToString() + " !");
                }
                else
                {
                    MessageBox.Show("Felicitari, ai castigat " + (credit - verif).ToString() + " !");
                }
                label5.Text = credit.ToString();
            }
            if (radioButton3.Checked == true)
            {
                verif2 = credit;
                if (matrice[0, 0].BackgroundImage == matrice[0, 1].BackgroundImage && matrice[0, 0].BackgroundImage == matrice[0, 2].BackgroundImage && matrice[0, 1].BackgroundImage == matrice[0, 2].BackgroundImage)
                {
                    credit = credit + Convert.ToInt32(textBox1.Text) * 5;
                }
                if (matrice[1, 0].BackgroundImage == matrice[1, 1].BackgroundImage && matrice[1, 0].BackgroundImage == matrice[1, 2].BackgroundImage && matrice[1, 1].BackgroundImage == matrice[1, 2].BackgroundImage)
                {
                    credit = credit + Convert.ToInt32(textBox1.Text) * 5;
                }
                if (matrice[2, 0].BackgroundImage == matrice[2, 1].BackgroundImage && matrice[2, 0].BackgroundImage == matrice[2, 2].BackgroundImage && matrice[2, 1].BackgroundImage == matrice[2, 2].BackgroundImage)
                {
                    credit = credit + Convert.ToInt32(textBox1.Text) * 5;
                }
                if (matrice[0, 0].BackgroundImage == matrice[1, 1].BackgroundImage && matrice[0, 0].BackgroundImage == matrice[2, 2].BackgroundImage && matrice[1, 1].BackgroundImage == matrice[2, 2].BackgroundImage)
                {
                    credit = credit + Convert.ToInt32(textBox1.Text) * 15;
                }
                if (matrice[0, 2].BackgroundImage == matrice[1, 1].BackgroundImage && matrice[0, 2].BackgroundImage == matrice[2, 0].BackgroundImage && matrice[1, 1].BackgroundImage == matrice[2, 0].BackgroundImage)
                {
                    credit = credit + Convert.ToInt32(textBox1.Text) * 15;
                }
                if (verif2 == credit)
                {
                    if (matrice[0, 0].BackgroundImage == matrice[0, 1].BackgroundImage)
                        credit = credit + Convert.ToInt32(textBox1.Text) * 2;
                    if (matrice[1, 0].BackgroundImage == matrice[1, 1].BackgroundImage)
                        credit = credit + Convert.ToInt32(textBox1.Text) * 2;
                    if (matrice[2, 0].BackgroundImage == matrice[2, 1].BackgroundImage)
                        credit = credit + Convert.ToInt32(textBox1.Text) * 2;
                    //daca tot nu s-a schimbat
                    if (verif2 == credit)
                        MessageBox.Show("Sorry! Maybe next time!");
                    else
                        MessageBox.Show("Congratulation! You have won " + (credit - verif2).ToString() + " !");
                }
                else
                {
                    MessageBox.Show("Congratulation! You have won " + (credit - verif2).ToString() + " !");
                }
                label5.Text = credit.ToString();
            }
            button1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            k++;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    {
                        matrice[i, j].BackgroundImage = fruit[rand.Next(0, 6)];
                        matrice[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    }
            if (k == 120)
            {
                timer1.Stop();
                button2.Enabled = true;
                k = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form2 formDoi = new Form2();
            formDoi.ShowDialog();
        }
    }
}
