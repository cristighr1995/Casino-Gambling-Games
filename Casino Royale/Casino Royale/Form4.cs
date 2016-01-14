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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        Label[,] matrice = new Label[6, 6];
        List<int> numere = new List<int>();
        Random rand = new Random();
        int credit;
            
        private void Form4_Load(object sender, EventArgs e)
        {
            int i, j;
            credit = 1000;
            //adauga matricea corespunzatoare numerelor
            for (i = 0; i < 6; i++)
                for (j = 0; j < 6; j++)
                {
                    matrice[i, j] = new Label();
                    matrice[i, j].AutoSize = false;
                    matrice[i, j].Height = 65;
                    matrice[i, j].Width = 65;
                    matrice[i, j].Left = 50 + j * 66;
                    matrice[i, j].Top = 210 + i * 66;
                    matrice[i, j].Text = "X";
                    matrice[i, j].BackColor = Color.White;
                    matrice[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    matrice[i, j].Font = new Font("Calibri", 20);
                    matrice[i, j].BorderStyle = BorderStyle.FixedSingle;
                    this.Controls.Add(matrice[i, j]);
                }
            
            numere.Add(rand.Next(1, 49));
            int count = 0;
            int attemp;
            //adauga numere in lista numerelor posibile
            do
            {
                attemp = rand.Next(1,49);
                if (!numere.Contains(attemp))
                {
                    numere.Add(attemp);
                    count++;
                }
            } 
            while (count <= 34);

            button2.Enabled = false;
            label9.BackColor = Color.Transparent;
            label10.BackColor = Color.Transparent;
            label11.BackColor = Color.Transparent;
            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
            button3.Cursor = Cursors.Hand;
            //
            label1.Width = 60;
            label1.Height = 60;
            label1.Location = new Point(50,9);
            //
            label2.Width = 60;
            label2.Height = 60;
            label2.Location = new Point(116, 9);
            //
            label3.Width = 60;
            label3.Height = 60;
            label3.Location = new Point(182, 9);
            //
            label4.Width = 60;
            label4.Height = 60;
            label4.Location = new Point(248, 9);
            //
            label5.Width = 60;
            label5.Height = 60;
            label5.Location = new Point(314, 9);
            //
            label6.Width = 60;
            label6.Height = 60;
            label6.Location = new Point(512, 9);
            //
            label7.Width = 60;
            label7.Height = 60;
            label7.Location = new Point(578, 9);
            //
            label8.Width = 60;
            label8.Height = 60;
            label8.Location = new Point(644, 9);
            //
            label9.Font = new Font("Microsoft Sans Serif", 13);
            label9.TextAlign = ContentAlignment.TopLeft;
            label9.Location = new Point(45, 98);
            //
            label10.Location = new Point(495, 169);
            label10.TextAlign = ContentAlignment.TopLeft;
            label10.Font = new Font("Microsoft Sans Serif", 11);
            //
            label11.Location = new Point(45,169);
            label11.TextAlign = ContentAlignment.TopLeft;
            label11.Font = new Font("Microsoft Sans Serif", 13);
            //
            label12.Width = 169;
            label12.Height = 38;
            label12.Location = new Point(274, 159);
            label12.Font = new Font("Microsoft Sans Serif", 22);
            //
            textBox1.Size = new Size(60,20);
            textBox1.Location = new Point(50, 126);
            //
            textBox2.Size = new Size(60, 20);
            textBox2.Location = new Point(117, 126);
            //
            textBox3.Size = new Size(60, 20);
            textBox3.Location = new Point(183, 126);
            //
            textBox4.Size = new Size(60, 20);
            textBox4.Location = new Point(248, 126);
            //
            textBox5.Size = new Size(60, 20);
            textBox5.Location = new Point(314, 126);
            //
            textBox6.Size = new Size(192, 20);
            textBox6.Location = new Point(512, 197);
            //
            textBox7.Size = new Size(63, 20);
            textBox7.Location = new Point(380, 126);
            //
            button1.Size = new Size(263, 51);
            button1.Location = new Point(484, 256);
            //
            button2.Size = new Size(263, 51);
            button2.Location = new Point(484, 313);
            //
            button3.Size = new Size(263, 51);
            button3.Location = new Point(484, 370);
            //
            this.Size = new Size(765, 648);
        }

        //INCEARCA-TI NOROCUL
        private void button1_Click(object sender, EventArgs e)
        {
            int k = 0;
            int contor = 0;

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                if (Convert.ToInt32(textBox1.Text) < 49 && Convert.ToInt32(textBox2.Text) < 49 && Convert.ToInt32(textBox3.Text) < 49 && Convert.ToInt32(textBox4.Text) < 49 && Convert.ToInt32(textBox5.Text) < 49 && Convert.ToInt32(textBox7.Text) < 49)
                {
                    if (credit - Convert.ToInt32(textBox6.Text) >= 0)
                    {
                        credit = credit - Convert.ToInt32(textBox6.Text);
                        label12.Text = credit.ToString();
                        //de fiecare data primul numar este ales la intamplare
                        for (int i = 0; i < 36; i++)
                        {
                            numere[i] = rand.Next(1, 49);
                        }
                        //lista se updateaza cu numere la intamplare
                        //verifica daca un numar se repeta, daca nu il adauga in lista in locul 
                        //primului gasit diferit
                        do
                        {
                            int attemp = rand.Next(1, 49);
                            if (!numere.Contains(attemp))
                            {
                                numere[k] = attemp;
                                k++;
                            }
                        }
                        while (k <= 35);
                        //completeaza matricea cu numere din lista
                        for (int i = 0; i < 6; i++)
                            for (int j = 0; j < 6; j++)
                            {
                                matrice[i, j].Text = numere[contor].ToString();
                                contor++;
                            }
                        for (int i = 0; i < 6; i++)
                            for (int j = 0; j < 6; j++)
                            {
                                if (Convert.ToInt32(matrice[i, j].Text) < 10)
                                {
                                    matrice[i, j].BackColor = Color.Green;
                                }
                                if (Convert.ToInt32(matrice[i, j].Text) >= 10 && Convert.ToInt32(matrice[i, j].Text) <20)
                                {
                                    matrice[i, j].BackColor = Color.SteelBlue;
                                }
                                if (Convert.ToInt32(matrice[i, j].Text) >= 20 && Convert.ToInt32(matrice[i, j].Text) < 30)
                                {
                                    matrice[i, j].BackColor = Color.Gold;
                                }
                                if (Convert.ToInt32(matrice[i, j].Text) >= 30 && Convert.ToInt32(matrice[i, j].Text) < 40)
                                {
                                    matrice[i, j].BackColor = Color.Purple;
                                }
                                if (Convert.ToInt32(matrice[i, j].Text) >= 40)
                                {
                                    matrice[i, j].BackColor = Color.Red;
                                }
                            }
                        button2.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Insufficient credit!");
                    }
                }
                else
                {
                    MessageBox.Show("Number out of bounds! You should pick numbers less than 49!");
                }
            }
            else
            {
                MessageBox.Show("Missing numbers!");
            }
        }

        //VERIFICA
        private void button2_Click(object sender, EventArgs e)
        {
            int i, j;
            int scor = 0;
            //verifica cate numere din textboxuri se potrivesc cu cele din extragere
            for (i = 0; i < 6; i++)
                for (j = 0; j < 6; j++)
                {
                    if (textBox1.Text == matrice[i, j].Text) scor++;
                    if (textBox2.Text == matrice[i, j].Text) scor++;
                    if (textBox3.Text == matrice[i, j].Text) scor++;
                    if (textBox4.Text == matrice[i, j].Text) scor++;
                    if (textBox5.Text == matrice[i, j].Text) scor++;
                    if (textBox7.Text == matrice[i, j].Text) scor++;
                }
            if (scor == 0) MessageBox.Show("None");
            if (scor == 1) MessageBox.Show("1 correct number! Maybe next time!");
            if (scor == 2) MessageBox.Show("2 correct numbers! Maybe next time!");
            if (scor == 3) MessageBox.Show("3 correct numbers! Maybe next time!");
            if (scor == 4) MessageBox.Show("4 correct numbers! Maybe next time!");
            if (scor == 5) MessageBox.Show("5 correct numbers! Maybe next time!");
            if (scor == 6)
            {
                MessageBox.Show("Congratulations!!! 6 correct numbers! You have won " + (Convert.ToInt32(textBox6.Text) * 50).ToString() + "!");
                credit = credit + Convert.ToInt32(textBox6.Text) * 50;
                label12.Text = credit.ToString();
            }
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form2 formDoi = new Form2();
            formDoi.ShowDialog();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
