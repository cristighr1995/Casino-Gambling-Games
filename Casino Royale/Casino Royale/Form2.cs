using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Casino_Royale
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\2.jpg");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.BackgroundImage = Image.FromFile(Application.StartupPath + "\\lucky.jpg");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.BackgroundImage = Image.FromFile(Application.StartupPath + "\\barbut.jpg");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.BackgroundImage = Image.FromFile(Application.StartupPath + "\\slots.jpg");
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox5.BackgroundImage = Image.FromFile(Application.StartupPath + "\\poker.jpg");
            pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            label1.BackColor = Color.Transparent;
            label2.Cursor = Cursors.Hand;
            label3.Cursor = Cursors.Hand;
            label4.Cursor = Cursors.Hand;
            label5.Cursor = Cursors.Hand;
            label6.Cursor = Cursors.Hand;
            button1.Cursor = Cursors.Hand;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form3 formTrei = new Form3();
            formTrei.Show();
            this.Dispose();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form4 formPatru = new Form4();
            formPatru.Show();
            this.Dispose();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form5 formCinci = new Form5();
            formCinci.Show();
            this.Dispose();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form6 formSase = new Form6();
            formSase.Show();
            this.Dispose();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            string query;
            query = "\\Poker\\Poker\\bin\\Debug\\Poker.exe";
            Process.Start(Application.StartupPath + query);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form1 formUnu = new Form1();
            formUnu.ShowDialog();
        }
    }
}
