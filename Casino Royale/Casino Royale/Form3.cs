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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        Random rand = new Random();
        Bitmap[] imagine = new Bitmap[2];
        int credit = 0;
        int k = 0;

        //START
        private void label2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (credit - Convert.ToInt32(textBox1.Text) >= 0)
                {
                    timer1.Start();
                    pictureBox1.Text = "";
                    credit = credit - Convert.ToInt32(textBox1.Text);
                    label6.Text = credit.ToString();
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button1.Text = "RED";
                    button2.Text = "BLACK";
                    button1.Font = new Font("Calibri", 18);
                    button2.Font = new Font("Calibri", 18);
                    button1.ForeColor = Color.White;
                    button2.ForeColor = Color.White;
                    pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\back1.jpg");
                    pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    MessageBox.Show("Insufficient credit!");
                } 
            }
            else
            {
                MessageBox.Show("You need to place a bet sum!"); 
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            imagine[0] = new Bitmap(Application.StartupPath + "\\ace_of_hearts.png");
            imagine[1] = new Bitmap(Application.StartupPath + "\\ace_of_spades.png");
            credit = 1000;
            label6.Text = credit.ToString();
            button1.Enabled = false;
            button2.Enabled = false;
            label5.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label1.Cursor = Cursors.Hand;
            label2.Cursor = Cursors.Hand;
            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
            pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\back.jpg");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            k++;
        }

        //ROSIE
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (k % 2 == 0)
            {
                pictureBox1.BackgroundImage = imagine[0];
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                credit = credit + Convert.ToInt32(textBox1.Text) * 2;
                MessageBox.Show("Well done! You have won " + (Convert.ToInt32(textBox1.Text) * 2).ToString() + "!");
                label6.Text = credit.ToString();
            }
            else
            {
                pictureBox1.BackgroundImage = imagine[1];
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                MessageBox.Show("Try again! Maybe next time!");
            }
            textBox1.Text = "";
            button1.Enabled = false;
            button2.Enabled = false;
            button1.Text = "";
            button2.Text = "";
            if (button1.Enabled == false)
            {
                pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\back.jpg");
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        //NEAGRA
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (k % 2 == 0)
            {
                pictureBox1.BackgroundImage = imagine[0];
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                MessageBox.Show("Try again! Maybe next time!");
            }
            else
            {
                pictureBox1.BackgroundImage = imagine[1];
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                MessageBox.Show("Well done! You have won " + (Convert.ToInt32(textBox1.Text) * 2).ToString() + " !");
                credit = credit + Convert.ToInt32(textBox1.Text) * 2;
                label6.Text = credit.ToString();
            }
            textBox1.Text = "";
            button2.Enabled = false;
            button1.Enabled = false;
            button1.Text = "";
            button2.Text = "";
            if (button2.Enabled == false)
            {
                pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\back.jpg");
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form2 formDoi = new Form2();
            formDoi.ShowDialog();
        }
    }
}
