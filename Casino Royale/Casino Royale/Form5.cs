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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        PictureBox[] zar = new PictureBox[2];
        Bitmap[] imagini = new Bitmap[6];
        Random rand = new Random();
        int credit;
        int attemp;
        int attemp2;

        private void Form5_Load(object sender, EventArgs e)
        {
            int i;
            credit = 1000;
            for (i = 0; i < 2; i++)
            {
                zar[i] = new PictureBox();
                zar[i].Height = 100;
                zar[i].Width = 100;
                zar[i].Top = 140;
                zar[i].Left = 40 + i * 110;
                zar[i].BackColor = Color.White;
                zar[i].BorderStyle = BorderStyle.FixedSingle;
                zar[i].BackgroundImage = Image.FromFile(Application.StartupPath + "\\dice_back.jpg");
                zar[i].BackgroundImageLayout = ImageLayout.Stretch;
                this.Controls.Add(zar[i]);
            }
            imagini[0] = new Bitmap(Application.StartupPath + "\\dice1.jpg");
            imagini[1] = new Bitmap(Application.StartupPath + "\\dice2.jpg");
            imagini[2] = new Bitmap(Application.StartupPath + "\\dice3.jpg");
            imagini[3] = new Bitmap(Application.StartupPath + "\\dice4.jpg");
            imagini[4] = new Bitmap(Application.StartupPath + "\\dice5.jpg");
            imagini[5] = new Bitmap(Application.StartupPath + "\\dice6.jpg");

            button2.Enabled = false;
            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
            button3.Cursor = Cursors.Hand;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            //
            label1.Size = new Size(60, 60);
            label1.Location = new Point(75, 9);
            //
            label2.Size = new Size(60, 60);
            label2.Location = new Point(141, 39);
            //
            label3.Size = new Size(60, 60);
            label3.Location = new Point(207, 9);
            //
            label4.Size = new Size(60, 60);
            label4.Location = new Point(273, 39);
            //
            label5.Size = new Size(60, 60);
            label5.Location = new Point(344, 9);
            //
            label6.Size = new Size(60, 60);
            label6.Location = new Point(410, 39);
            //
            label7.AutoSize = false;
            label7.Size = new Size(300, 30);
            label7.Font = new Font("Microsoft Sans Serif", 11);
            label7.TextAlign = ContentAlignment.TopLeft;
            label7.Location = new Point(36, 258);
            //
            label8.AutoSize = false;
            label8.Size = new Size(250, 30);
            label8.Font = new Font("Microsoft Sans Serif", 11);
            label8.TextAlign = ContentAlignment.TopLeft;
            label8.Location = new Point(288, 155);
            //
            label9.AutoSize = false;
            label9.Size = new Size(188, 30);
            label9.Font = new Font("Microsoft Sans Serif", 13);
            label9.TextAlign = ContentAlignment.MiddleCenter;
            label9.Location = new Point(292, 178);
            //
            textBox1.Size = new Size(242,20);
            textBox1.Location = new Point(40, 284);
            //
            comboBox1.Size = new Size(200, 21);
            comboBox1.Location = new Point(288, 284);
            comboBox1.Font = new Font("Microsoft Sans Serif", 8);
            //
            button1.Size = new Size(117, 38);
            button1.Location = new Point(40, 309);
            button1.Font = new Font("Microsoft Sans Serif", 12);
            //
            button2.Size = new Size(117, 38);
            button2.Location = new Point(163, 309);
            button2.Font = new Font("Microsoft Sans Serif", 12);
            //
            button3.Size = new Size(119, 38);
            button3.Location = new Point(424, 309);
            button3.Font = new Font("Microsoft Sans Serif", 12);
            //
            this.Size = new Size(561, 388);
        }

        //START
        private void button1_Click(object sender, EventArgs e)
        {
            attemp = 0;
            attemp2 = 0;
            if (textBox1.Text != "" && comboBox1.SelectedIndex != -1)
            {
                if (credit - Convert.ToInt32(textBox1.Text) >= 0)
                {
                    attemp = rand.Next(0, 6);
                    attemp2 = rand.Next(0, 6);
                    //valoarea reala a zarului este attemp sau attemp2 + 1
                    zar[0].BackgroundImage = imagini[attemp];
                    zar[1].BackgroundImage = imagini[attemp2];
                    credit = credit - Convert.ToInt32(textBox1.Text);
                    label9.Text = credit.ToString();
                    button2.Enabled = true;
                    comboBox1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Insufficient credit!");
                }
            }
            else
            {
                if (textBox1.Text == "" && comboBox1.SelectedIndex != -1) MessageBox.Show("Please choose a bet sum!");
                if(comboBox1.SelectedIndex == -1 && textBox1.Text != "") MessageBox.Show("Please choose a bet!");
                if (textBox1.Text == "" && comboBox1.SelectedIndex == -1) MessageBox.Show("Bet sum and bet are empty!");
            }
        }

        //VERIFICA
        private void button2_Click(object sender, EventArgs e)
        {
            int scor;
            scor = credit;
            if (comboBox1.SelectedIndex == 0)
            {
                //suma numar par
                int verif = attemp + attemp2 + 2;
                if (verif % 2 == 0)
                {
                    credit = credit + Convert.ToInt32(textBox1.Text) * 2;
                    label9.Text = credit.ToString();
                    MessageBox.Show("Congratulations! You have won " + (Convert.ToInt32(textBox1.Text) * 2).ToString() + " !");
                }
            }
            if (comboBox1.SelectedIndex == 1)
            {
                //suma numar impar
                int verif = attemp + attemp2 + 2;
                if (verif % 2 == 1)
                {
                    credit = credit + Convert.ToInt32(textBox1.Text) * 2;
                    label9.Text = credit.ToString();
                    MessageBox.Show("Congratulations! You have won " + (Convert.ToInt32(textBox1.Text) * 2).ToString() + " !");
                }
            }
            if (comboBox1.SelectedIndex == 2)
            {
                //dubla
                if (attemp == attemp2)
                {
                    credit = credit + Convert.ToInt32(textBox1.Text) * 6;
                    label9.Text = credit.ToString();
                    MessageBox.Show("Congratulations! You have won " + (Convert.ToInt32(textBox1.Text) * 6).ToString() + " !");
                }
            }
            if (comboBox1.SelectedIndex == 3)
            {
                //mai mare decat 7
                if ((attemp + attemp2 + 2) >= 7)
                {
                    credit = credit + Convert.ToInt32(textBox1.Text) * 2;
                    MessageBox.Show("Congratulations! You have won " + (Convert.ToInt32(textBox1.Text) * 2).ToString() + " !");
                    label9.Text = credit.ToString();
                }
            }
            if (comboBox1.SelectedIndex == 4)
            {
                //mai mica decat 7
                if ((attemp + attemp2 + 2) < 7)
                {
                    credit = credit + Convert.ToInt32(textBox1.Text) * 3;
                    label9.Text = credit.ToString();
                    MessageBox.Show("Congratulations! You have won " + (Convert.ToInt32(textBox1.Text) * 3).ToString() + " !");
                }
            }
            if (comboBox1.SelectedIndex == 5)
            {
                // dubla 1-1
                if (attemp == 0 && attemp2 == 0)
                {
                    credit = credit + Convert.ToInt32(textBox1.Text) * 36;
                    label9.Text = credit.ToString();
                    MessageBox.Show("Congratulations! You have won " + (Convert.ToInt32(textBox1.Text) * 36).ToString() + " !");
                }
            }
            if (comboBox1.SelectedIndex == 6)
            {
                //dubla 2-2
                if (attemp == 1 && attemp2 == 1)
                {
                    credit = credit + Convert.ToInt32(textBox1.Text) * 36;
                    label9.Text = credit.ToString();
                    MessageBox.Show("Congratulations! You have won " + (Convert.ToInt32(textBox1.Text) * 36).ToString() + " !");
                }
            }
            if (comboBox1.SelectedIndex == 7)
            {
                //dubla 3-3
                if (attemp == 2 && attemp2 == 2)
                {
                    credit = credit + Convert.ToInt32(textBox1.Text) * 36;
                    label9.Text = credit.ToString();
                    MessageBox.Show("Congratulations! You have won " + (Convert.ToInt32(textBox1.Text) * 36).ToString() + " !");
                }
            }
            if (comboBox1.SelectedIndex == 8)
            {
                //dubla 4-4
                if (attemp == 3 && attemp2 == 3)
                {
                    credit = credit + Convert.ToInt32(textBox1.Text) * 36;
                    label9.Text = credit.ToString();
                    MessageBox.Show("Congratulations! You have won " + (Convert.ToInt32(textBox1.Text) * 36).ToString() + " !");
                }
            }
            if (comboBox1.SelectedIndex == 9)
            {
                //dubla 5-5
                if (attemp == 4 && attemp2 == 4)
                {
                    credit = credit + Convert.ToInt32(textBox1.Text) * 36;
                    label9.Text = credit.ToString();
                    MessageBox.Show("Congratulations! You have won " + (Convert.ToInt32(textBox1.Text) * 36).ToString() + " !");
                }
            }
            if (comboBox1.SelectedIndex == 10)
            {
                //dubla 6-6
                if (attemp == 5 && attemp2 == 5)
                {
                    credit = credit + Convert.ToInt32(textBox1.Text) * 36;
                    label9.Text = credit.ToString();
                    MessageBox.Show("Congratulations! You have won " + (Convert.ToInt32(textBox1.Text) * 36).ToString() + " !");
                }
            }
            //in cazul in care creditul a ramas neschimbat inseamna ca niciun pariu nu e bun
            if (scor == credit)
            {
                MessageBox.Show("Sorry! Maybe next time!");
            }
            button2.Enabled = false;
            comboBox1.Enabled = true;
            zar[0].BackgroundImage = Image.FromFile(Application.StartupPath + "\\dice_back.jpg");
            zar[1].BackgroundImage = Image.FromFile(Application.StartupPath + "\\dice_back.jpg");
        }

        //IESIRE
        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form2 formDoi = new Form2();
            formDoi.ShowDialog();
        }

    }
}
