using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Poker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //lista de imagini cu pozele cartilor
        Bitmap[] imagini = new Bitmap[53];
        Random rand = new Random();
        //lista in care se vor salva numere la intamplare, reprezentand indicii cartilor
        List<int> numbers = new List<int>();
        //lista in care se vor salva valorile cartilor penru a putea fi comparate de la 3 carti incolo
        List<int> check = new List<int>();
        List<int> check2 = new List<int>();
        //retine cate casute sunt bifate
        int verif = 0;
        //retine ce valoare are o carte, de exemplu daca contor=5 => contor / 4 = 1 => jucatorul are un 3
        //adica valoarea cartii pe care o are in mana este contor + 2
        int contor1, contor2, contor3, contor4, contor5;
        int contor6, contor7, contor8, contor9, contor10;
        //variabile pentru a verifica cea mai mare carte ( high )
        string s, s2;
        //lista va salva valoarea cartilor atunci cand sunt doar perechi si nu altceva
        //adica o pereche sau 2 si apoi compara valorile pentru a vedea care jucator a castigat mana
        List<int> oPereche = new List<int>();
        //salveaza doar atunci cand sunt 3 carti identice, celelalte 2 neaflandu-se in nicio combinatie
        //compara care are mana mai mare
        List<int> treiBucati = new List<int>();
        //este un contor care creste atunci cand 2 carti sunt la fel
        //daca k = 1 , inseamna ca jucatorul / calculatorul are o pereche
        //daca k = 2, inseamna ca jucatorul / calculatorul are 2 perechi
        int k = 0;
        int k2 = 0;
        //retine cate maini a castigat fiecare
        int scor1 = 0, scor2 = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            imagini[0] = new Bitmap(Application.StartupPath + "\\deck\\2_of_clubs.png");
            imagini[1] = new Bitmap(Application.StartupPath + "\\deck\\2_of_diamonds.png");
            imagini[2] = new Bitmap(Application.StartupPath + "\\deck\\2_of_hearts.png");
            imagini[3] = new Bitmap(Application.StartupPath + "\\deck\\2_of_spades.png");

            imagini[4] = new Bitmap(Application.StartupPath + "\\deck\\3_of_clubs.png");
            imagini[5] = new Bitmap(Application.StartupPath + "\\deck\\3_of_diamonds.png");
            imagini[6] = new Bitmap(Application.StartupPath + "\\deck\\3_of_hearts.png");
            imagini[7] = new Bitmap(Application.StartupPath + "\\deck\\3_of_spades.png");

            imagini[8] = new Bitmap(Application.StartupPath + "\\deck\\4_of_clubs.png");
            imagini[9] = new Bitmap(Application.StartupPath + "\\deck\\4_of_diamonds.png");
            imagini[10] = new Bitmap(Application.StartupPath + "\\deck\\4_of_hearts.png");
            imagini[11] = new Bitmap(Application.StartupPath + "\\deck\\4_of_spades.png");

            imagini[12] = new Bitmap(Application.StartupPath + "\\deck\\5_of_clubs.png");
            imagini[13] = new Bitmap(Application.StartupPath + "\\deck\\5_of_diamonds.png");
            imagini[14] = new Bitmap(Application.StartupPath + "\\deck\\5_of_hearts.png");
            imagini[15] = new Bitmap(Application.StartupPath + "\\deck\\5_of_spades.png");

            imagini[16] = new Bitmap(Application.StartupPath + "\\deck\\6_of_clubs.png");
            imagini[17] = new Bitmap(Application.StartupPath + "\\deck\\6_of_diamonds.png");
            imagini[18] = new Bitmap(Application.StartupPath + "\\deck\\6_of_hearts.png");
            imagini[19] = new Bitmap(Application.StartupPath + "\\deck\\6_of_spades.png");

            imagini[20] = new Bitmap(Application.StartupPath + "\\deck\\7_of_clubs.png");
            imagini[21] = new Bitmap(Application.StartupPath + "\\deck\\7_of_diamonds.png");
            imagini[22] = new Bitmap(Application.StartupPath + "\\deck\\7_of_hearts.png");
            imagini[23] = new Bitmap(Application.StartupPath + "\\deck\\7_of_spades.png");

            imagini[24] = new Bitmap(Application.StartupPath + "\\deck\\8_of_clubs.png");
            imagini[25] = new Bitmap(Application.StartupPath + "\\deck\\8_of_diamonds.png");
            imagini[26] = new Bitmap(Application.StartupPath + "\\deck\\8_of_hearts.png");
            imagini[27] = new Bitmap(Application.StartupPath + "\\deck\\8_of_spades.png");

            imagini[28] = new Bitmap(Application.StartupPath + "\\deck\\9_of_clubs.png");
            imagini[29] = new Bitmap(Application.StartupPath + "\\deck\\9_of_diamonds.png");
            imagini[30] = new Bitmap(Application.StartupPath + "\\deck\\9_of_hearts.png");
            imagini[31] = new Bitmap(Application.StartupPath + "\\deck\\9_of_spades.png");

            imagini[32] = new Bitmap(Application.StartupPath + "\\deck\\10_of_clubs.png");
            imagini[33] = new Bitmap(Application.StartupPath + "\\deck\\10_of_diamonds.png");
            imagini[34] = new Bitmap(Application.StartupPath + "\\deck\\10_of_hearts.png");
            imagini[35] = new Bitmap(Application.StartupPath + "\\deck\\10_of_spades.png");

            imagini[36] = new Bitmap(Application.StartupPath + "\\deck\\ace_of_clubs.png");
            imagini[37] = new Bitmap(Application.StartupPath + "\\deck\\ace_of_diamonds.png");
            imagini[38] = new Bitmap(Application.StartupPath + "\\deck\\ace_of_hearts.png");
            imagini[39] = new Bitmap(Application.StartupPath + "\\deck\\ace_of_spades.png");

            imagini[40] = new Bitmap(Application.StartupPath + "\\deck\\jack_of_clubs.png");
            imagini[41] = new Bitmap(Application.StartupPath + "\\deck\\jack_of_diamonds.png");
            imagini[42] = new Bitmap(Application.StartupPath + "\\deck\\jack_of_hearts.png");
            imagini[43] = new Bitmap(Application.StartupPath + "\\deck\\jack_of_spades.png");

            imagini[44] = new Bitmap(Application.StartupPath + "\\deck\\queen_of_clubs.png");
            imagini[45] = new Bitmap(Application.StartupPath + "\\deck\\queen_of_diamonds.png");
            imagini[46] = new Bitmap(Application.StartupPath + "\\deck\\queen_of_hearts.png");
            imagini[47] = new Bitmap(Application.StartupPath + "\\deck\\queen_of_spades.png");

            imagini[48] = new Bitmap(Application.StartupPath + "\\deck\\king_of_clubs.png");
            imagini[49] = new Bitmap(Application.StartupPath + "\\deck\\king_of_diamonds.png");
            imagini[50] = new Bitmap(Application.StartupPath + "\\deck\\king_of_hearts.png");
            imagini[51] = new Bitmap(Application.StartupPath + "\\deck\\king_of_spades.png");

            imagini[52] = new Bitmap(Application.StartupPath + "\\deck\\back.jpg");


            pictureBox1.BackgroundImage = imagini[52];
            pictureBox2.BackgroundImage = imagini[52];
            pictureBox3.BackgroundImage = imagini[52];
            pictureBox4.BackgroundImage = imagini[52];
            pictureBox5.BackgroundImage = imagini[52];
            pictureBox6.BackgroundImage = imagini[52];
            pictureBox7.BackgroundImage = imagini[52];
            pictureBox8.BackgroundImage = imagini[52];
            pictureBox9.BackgroundImage = imagini[52];
            pictureBox10.BackgroundImage = imagini[52];
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox8.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox9.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox10.BackgroundImageLayout = ImageLayout.Stretch;

            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
            button3.Cursor = Cursors.Hand;
            button4.Cursor = Cursors.Hand;

            check.Add(0);
            check.Add(0);
            check.Add(0);
            check.Add(0);
            check.Add(0);
            check2.Add(0);
            check2.Add(0);
            check2.Add(0);
            check2.Add(0);
            check2.Add(0);

            int count = 0;
            int attemp;

            numbers.Add(rand.Next(0, 52));
            while (count < 51)
            {
                attemp = rand.Next(0, 52);
                if (!numbers.Contains(attemp))
                {
                    numbers.Add(attemp);
                    count++;
                }
            }

            button1.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;

            checkBox1.BackColor = Color.Transparent;
            checkBox2.BackColor = Color.Transparent;
            checkBox3.BackColor = Color.Transparent;
            checkBox4.BackColor = Color.Transparent;
            checkBox5.BackColor = Color.Transparent;
            //
            checkBox1.ForeColor = Color.White;
            checkBox2.ForeColor = Color.White;
            checkBox3.ForeColor = Color.White;
            checkBox4.ForeColor = Color.White;
            checkBox5.ForeColor = Color.White;
            //
            checkBox1.Text = "Schimba cartea";
            checkBox2.Text = "Schimba cartea";
            checkBox3.Text = "Schimba cartea";
            checkBox4.Text = "Schimba cartea";
            checkBox5.Text = "Schimba cartea";
            //
            checkBox1.Font = new Font("Calibri", 12);
            checkBox2.Font = new Font("Calibri", 12);
            checkBox3.Font = new Font("Calibri", 12);
            checkBox4.Font = new Font("Calibri", 12);
            checkBox5.Font = new Font("Calibri", 12);
            //
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
        }

        //SCHIMBA CARTILE
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                verif++;
            }
            if (checkBox2.Checked == true)
            {
                verif++;
            }
            if (checkBox3.Checked == true)
            {
                verif++;
            }
            if (checkBox4.Checked == true)
            {
                verif++;
            }
            if (checkBox5.Checked == true)
            {
                verif++;
            }
            if (verif >= 4)
            {
                MessageBox.Show("Nu puteti schimba decat maxim 3 carti !");
                verif = 0;
            }
            else
            {
                if (verif == 0)
                {
                    MessageBox.Show("Nu ati ales nicio schimbare ! Ori schimbati vreo carte, ori apasati butonul NU SCHIMB");
                }
                else
                {
                    verif = 0;
                    button1.Enabled = false;
                    button2.Enabled = true;
                    button4.Enabled = false;
                    //alege urmatoarele 3 carti care trebuiesc schimbate
                    if (checkBox1.Checked == true)
                    {
                        pictureBox1.BackgroundImage = imagini[numbers[5]];
                    }
                    if (checkBox2.Checked == true)
                    {
                        pictureBox2.BackgroundImage = imagini[numbers[6]];
                    }
                    if (checkBox3.Checked == true)
                    {
                        pictureBox3.BackgroundImage = imagini[numbers[7]];
                    }
                    if (checkBox4.Checked == true)
                    {
                        pictureBox4.BackgroundImage = imagini[numbers[8]];
                    }
                    if (checkBox5.Checked == true)
                    {
                        pictureBox5.BackgroundImage = imagini[numbers[9]];
                    }
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    checkBox5.Checked = false;
                }
            }



        }

        //IMPARTE CARTILE
        private void button3_Click(object sender, EventArgs e)
        {
            int k = 0;
            int x;
            x = rand.Next(0, 52);
            for (int i = 0; i < 52; i++)
            {
                numbers[i] = x;
            }
            //adauga numere la intamplare intr-o lista
            do
            {
                int attemp = rand.Next(0, 52);
                if (!numbers.Contains(attemp))
                {
                    numbers[k] = attemp;
                    k++;
                }
            } while (k <= 50);
            //imparte primele 5 carti ca fiind primele elemente din lista (care sunt la intamplare)
            pictureBox1.BackgroundImage = imagini[numbers[0]];
            pictureBox2.BackgroundImage = imagini[numbers[1]];
            pictureBox3.BackgroundImage = imagini[numbers[2]];
            pictureBox4.BackgroundImage = imagini[numbers[3]];
            pictureBox5.BackgroundImage = imagini[numbers[4]];
            pictureBox6.BackgroundImage = imagini[52];
            pictureBox7.BackgroundImage = imagini[52];
            pictureBox8.BackgroundImage = imagini[52];
            pictureBox9.BackgroundImage = imagini[52];
            pictureBox10.BackgroundImage = imagini[52];
            button3.Enabled = false;
            button1.Enabled = true;
            button4.Enabled = true;
            label1.Text = "Mana Jucator";
            label2.Text = "Mana Calculator";
        }

        //VERIFICA
        private void button2_Click(object sender, EventArgs e)
        {
            //arata cartile calculatorului
            pictureBox6.BackgroundImage = imagini[numbers[10]];
            pictureBox7.BackgroundImage = imagini[numbers[11]];
            pictureBox8.BackgroundImage = imagini[numbers[12]];
            pictureBox9.BackgroundImage = imagini[numbers[13]];
            pictureBox10.BackgroundImage = imagini[numbers[14]];

            //retine "pozitia" fiecarei carti 
            // doiarii sunt intre 0 si 4 si asa mai departe
            for (int i = 0; i < 52; i++)
            {
                if (pictureBox1.BackgroundImage == imagini[numbers[i]])
                {
                    contor1 = numbers[i];
                }
            }
            for (int i = 0; i < 52; i++)
            {
                if (pictureBox2.BackgroundImage == imagini[numbers[i]])
                {
                    contor2 = numbers[i];
                }
            }
            for (int i = 0; i < 52; i++)
            {
                if (pictureBox3.BackgroundImage == imagini[numbers[i]])
                {
                    contor3 = numbers[i];
                }
            }
            for (int i = 0; i < 52; i++)
            {
                if (pictureBox4.BackgroundImage == imagini[numbers[i]])
                {
                    contor4 = numbers[i];
                }
            }
            for (int i = 0; i < 52; i++)
            {
                if (pictureBox5.BackgroundImage == imagini[numbers[i]])
                {
                    contor5 = numbers[i];
                }
            }
            for (int i = 0; i < 52; i++)
            {
                if (pictureBox6.BackgroundImage == imagini[numbers[i]])
                {
                    contor6 = numbers[i];
                }
            }
            for (int i = 0; i < 52; i++)
            {
                if (pictureBox7.BackgroundImage == imagini[numbers[i]])
                {
                    contor7 = numbers[i];
                }
            }
            for (int i = 0; i < 52; i++)
            {
                if (pictureBox8.BackgroundImage == imagini[numbers[i]])
                {
                    contor8 = numbers[i];
                }
            }
            for (int i = 0; i < 52; i++)
            {
                if (pictureBox9.BackgroundImage == imagini[numbers[i]])
                {
                    contor9 = numbers[i];
                }
            }
            for (int i = 0; i < 52; i++)
            {
                if (pictureBox10.BackgroundImage == imagini[numbers[i]])
                {
                    contor10 = numbers[i];
                }
            }
            //
            // Jucator 1
            //
            if (contor1 / 4 == contor2 / 4 ||
                contor1 / 4 == contor3 / 4 ||
                contor1 / 4 == contor4 / 4 ||
                contor1 / 4 == contor5 / 4 ||
                contor2 / 4 == contor3 / 4 ||
                contor2 / 4 == contor4 / 4 ||
                contor2 / 4 == contor5 / 4 ||
                contor3 / 4 == contor4 / 4 ||
                contor3 / 4 == contor5 / 4 ||   //daca cel putin 2 carti sunt din aceeasi pereche
                contor4 / 4 == contor5 / 4)
            {
                //daca cel putin 3 sunt din aceeasi pereche
                if (contor1 / 4 == contor2 / 4 && contor1 / 4 == contor3 / 4 && contor2 / 4 == contor3 / 4 ||
                    contor1 / 4 == contor2 / 4 && contor1 / 4 == contor4 / 4 && contor2 / 4 == contor4 / 4 ||
                    contor1 / 4 == contor2 / 4 && contor1 / 4 == contor5 / 4 && contor2 / 4 == contor5 / 4 ||
                    contor1 / 4 == contor3 / 4 && contor1 / 4 == contor4 / 4 && contor3 / 4 == contor4 / 4 ||
                    contor1 / 4 == contor3 / 4 && contor1 / 4 == contor5 / 4 && contor3 / 4 == contor5 / 4 ||
                    contor1 / 4 == contor4 / 4 && contor1 / 4 == contor5 / 4 && contor4 / 4 == contor5 / 4 ||
                    contor2 / 4 == contor3 / 4 && contor2 / 4 == contor4 / 4 && contor3 / 4 == contor4 / 4 ||
                    contor2 / 4 == contor3 / 4 && contor2 / 4 == contor5 / 4 && contor3 / 4 == contor5 / 4 ||
                    contor2 / 4 == contor4 / 4 && contor2 / 4 == contor5 / 4 && contor4 / 4 == contor5 / 4 ||
                    contor3 / 4 == contor4 / 4 && contor3 / 4 == contor5 / 4 && contor4 / 4 == contor5 / 4)
                {
                    //daca 3 sunt din aceeasi pereche si 2 identice
                    if (contor1 / 4 == contor2 / 4 && contor1 / 4 == contor3 / 4 && contor2 / 4 == contor3 / 4 && contor4 / 4 == contor5 / 4 ||
                    contor1 / 4 == contor2 / 4 && contor1 / 4 == contor4 / 4 && contor2 / 4 == contor4 / 4 && contor3 / 4 == contor5 / 4 ||
                    contor1 / 4 == contor2 / 4 && contor1 / 4 == contor5 / 4 && contor2 / 4 == contor5 / 4 && contor3 / 4 == contor4 / 4 ||
                    contor1 / 4 == contor3 / 4 && contor1 / 4 == contor4 / 4 && contor3 / 4 == contor4 / 4 && contor2 / 4 == contor5 / 4 ||
                    contor1 / 4 == contor3 / 4 && contor1 / 4 == contor5 / 4 && contor3 / 4 == contor5 / 4 && contor2 / 4 == contor4 / 4 ||
                    contor1 / 4 == contor4 / 4 && contor1 / 4 == contor5 / 4 && contor4 / 4 == contor5 / 4 && contor2 / 4 == contor3 / 4 ||
                    contor2 / 4 == contor3 / 4 && contor2 / 4 == contor4 / 4 && contor3 / 4 == contor4 / 4 && contor1 / 4 == contor5 / 4 ||
                    contor2 / 4 == contor3 / 4 && contor2 / 4 == contor5 / 4 && contor3 / 4 == contor5 / 4 && contor1 / 4 == contor4 / 4 ||
                    contor2 / 4 == contor4 / 4 && contor2 / 4 == contor5 / 4 && contor4 / 4 == contor5 / 4 && contor1 / 4 == contor3 / 4 ||
                    contor3 / 4 == contor4 / 4 && contor3 / 4 == contor5 / 4 && contor4 / 4 == contor5 / 4 && contor1 / 4 == contor2 / 4)
                    {
                        //daca patru dintre ele sunt identice
                        if (contor1 / 4 == contor2 / 4 && contor1 / 4 == contor3 / 4 && contor1 / 4 == contor4 / 4 && contor2 / 4 == contor3 / 4 && contor2 / 4 == contor4 / 4 && contor3 / 4 == contor4 / 4 ||
                            contor1 / 4 == contor2 / 4 && contor1 / 4 == contor3 / 4 && contor1 / 4 == contor5 / 4 && contor2 / 4 == contor3 / 4 && contor2 / 4 == contor5 / 4 && contor3 / 4 == contor5 / 4 ||
                            contor1 / 4 == contor3 / 4 && contor1 / 4 == contor4 / 4 && contor1 / 4 == contor5 / 4 && contor3 / 4 == contor4 / 4 && contor3 / 4 == contor5 / 4 && contor4 / 4 == contor5 / 4 ||
                            contor2 / 4 == contor3 / 4 && contor2 / 4 == contor4 / 4 && contor2 / 4 == contor5 / 4 && contor3 / 4 == contor4 / 4 && contor3 / 4 == contor5 / 4 && contor4 / 4 == contor5 / 4)
                        {
                            label1.Text = "4 Bucati";
                            //retine in vectorul check ce carti are jucatorul 
                            //daca contor1 = 0 => contor1 / 4 = 0 => jucatorul are un 2
                            //daca contor1 = 2 => contor1 / 4 = 0 => jucatorul are tot un 2
                            check[0] = contor1 / 4;
                            check[1] = contor2 / 4;
                            check[2] = contor3 / 4;
                            check[3] = contor4 / 4;
                            check[4] = contor5 / 4;
                            check.Sort(); //sorteaza vectorul crescator
                        }
                        else
                        {
                            label1.Text = "Full";
                            check[0] = contor1 / 4;
                            check[1] = contor2 / 4;
                            check[2] = contor3 / 4;
                            check[3] = contor4 / 4;
                            check[4] = contor5 / 4;
                            check.Sort();
                        }
                    }
                    else
                    {
                        label1.Text = "3 Bucati";
                        check[0] = contor1 / 4;
                        check[1] = contor2 / 4;
                        check[2] = contor3 / 4;
                        check[3] = contor4 / 4;
                        check[4] = contor5 / 4;
                        for (int i = 0; i < 5; i++)
                            for (int j = 0; j < 5; j++)
                            {
                                //verifica ce carti sunt identice ( cate 3) si le salveaza valoarea
                                //in lista treiBucati (acest lucru este pentru compararea cu cartile
                                //calculatorului in cazul in care si acesta are tot 3 bucati
                                //adica 3 carti identice
                                if (check[i] == check[j] && i < j)
                                {
                                    treiBucati.Add(check[i]);
                                }
                            }
                    }
                }
                else
                {
                    //daca a ajuns aici inseamna ca minim 2 sunt egale, dar nu exista 3 la fel
                    if (contor1 / 4 == contor2 / 4) { k++; oPereche.Add(contor1 / 4); }
                    if (contor1 / 4 == contor3 / 4) { k++; oPereche.Add(contor1 / 4); }
                    if (contor1 / 4 == contor4 / 4) { k++; oPereche.Add(contor1 / 4); }
                    if (contor1 / 4 == contor5 / 4) { k++; oPereche.Add(contor1 / 4); }
                    if (contor2 / 4 == contor3 / 4) { k++; oPereche.Add(contor2 / 4); }
                    if (contor2 / 4 == contor4 / 4) { k++; oPereche.Add(contor2 / 4); }
                    if (contor2 / 4 == contor5 / 4) { k++; oPereche.Add(contor2 / 4); }
                    if (contor3 / 4 == contor4 / 4) { k++; oPereche.Add(contor3 / 4); }
                    if (contor3 / 4 == contor5 / 4) { k++; oPereche.Add(contor3 / 4); }
                    if (contor4 / 4 == contor5 / 4) { k++; oPereche.Add(contor4 / 4); }
                    if (k == 1) label1.Text = "1 Pereche";
                    if (k == 2) label1.Text = "2 Perechi";
                    k = 0;
                }
            }
            else
            {
                int x;
                //daca impart contor la 4 aflu ce carte am 
                //daca vreau restul la 4 aflu ce culoare am 
                x = contor1 % 4;
                if (contor2 % 4 == x && contor3 % 4 == x && contor4 % 4 == x && contor5 % 4 == x)
                {
                    label1.Text = "Culoare";
                }
                else
                {
                    //daca nu am nicio pereche ordonez toate cartile in ordine crescatoare
                    check[0] = contor1 / 4;
                    check[1] = contor2 / 4;
                    check[2] = contor3 / 4;
                    check[3] = contor4 / 4;
                    check[4] = contor5 / 4;
                    check.Sort();
                    //daca ele sunt consecutive am kinta !!!
                    if (check[0] == check[1] - 1 && check[1] == check[2] - 1 && check[2] == check[3] - 1 && check[3] == check[4] - 1)
                        label1.Text = "Kinta";
                    else
                    {
                        s = (check[4] + 2).ToString();
                        label1.Text = "High " + s;
                    }
                }
            }
            //
            // Calculator
            //
            // Acelasi procedeu il folosesc si pentru a determina mana calculatorului
            //
            if (contor6 / 4 == contor7 / 4 ||
                contor6 / 4 == contor8 / 4 ||
                contor6 / 4 == contor9 / 4 ||
                contor6 / 4 == contor10 / 4 ||
                contor7 / 4 == contor8 / 4 ||
                contor7 / 4 == contor9 / 4 ||
                contor7 / 4 == contor10 / 4 ||
                contor8 / 4 == contor9 / 4 ||
                contor8 / 4 == contor10 / 4 ||
                contor9 / 4 == contor10 / 4)
            {
                if (contor6 / 4 == contor7 / 4 && contor6 / 4 == contor8 / 4 && contor7 / 4 == contor8 / 4 ||
                    contor6 / 4 == contor7 / 4 && contor6 / 4 == contor9 / 4 && contor7 / 4 == contor9 / 4 ||
                    contor6 / 4 == contor7 / 4 && contor6 / 4 == contor10 / 4 && contor7 / 4 == contor10 / 4 ||
                    contor6 / 4 == contor8 / 4 && contor6 / 4 == contor9 / 4 && contor8 / 4 == contor9 / 4 ||
                    contor6 / 4 == contor8 / 4 && contor6 / 4 == contor10 / 4 && contor8 / 4 == contor10 / 4 ||
                    contor6 / 4 == contor9 / 4 && contor6 / 4 == contor10 / 4 && contor9 / 4 == contor10 / 4 ||
                    contor7 / 4 == contor8 / 4 && contor7 / 4 == contor9 / 4 && contor8 / 4 == contor9 / 4 ||
                    contor7 / 4 == contor8 / 4 && contor7 / 4 == contor10 / 4 && contor8 / 4 == contor10 / 4 ||
                    contor7 / 4 == contor9 / 4 && contor7 / 4 == contor10 / 4 && contor9 / 4 == contor10 / 4 ||
                    contor8 / 4 == contor9 / 4 && contor8 / 4 == contor10 / 4 && contor9 / 4 == contor10 / 4)
                {
                    if (contor6 / 4 == contor7 / 4 && contor6 / 4 == contor8 / 4 && contor7 / 4 == contor8 / 4 && contor9 / 4 == contor10 / 4 ||
                    contor6 / 4 == contor7 / 4 && contor6 / 4 == contor9 / 4 && contor7 / 4 == contor9 / 4 && contor8 / 4 == contor10 / 4 ||
                    contor6 / 4 == contor7 / 4 && contor6 / 4 == contor10 / 4 && contor7 / 4 == contor10 / 4 && contor8 / 4 == contor9 / 4 ||
                    contor6 / 4 == contor8 / 4 && contor6 / 4 == contor9 / 4 && contor8 / 4 == contor9 / 4 && contor7 / 4 == contor10 / 4 ||
                    contor6 / 4 == contor8 / 4 && contor6 / 4 == contor10 / 4 && contor8 / 4 == contor10 / 4 && contor7 / 4 == contor9 / 4 ||
                    contor6 / 4 == contor9 / 4 && contor6 / 4 == contor10 / 4 && contor9 / 4 == contor10 / 4 && contor7 / 4 == contor8 / 4 ||
                    contor7 / 4 == contor8 / 4 && contor7 / 4 == contor9 / 4 && contor8 / 4 == contor9 / 4 && contor6 / 4 == contor10 / 4 ||
                    contor7 / 4 == contor8 / 4 && contor7 / 4 == contor10 / 4 && contor8 / 4 == contor10 / 4 && contor6 / 4 == contor9 / 4 ||
                    contor7 / 4 == contor9 / 4 && contor7 / 4 == contor10 / 4 && contor9 / 4 == contor10 / 4 && contor6 / 4 == contor8 / 4 ||
                    contor8 / 4 == contor9 / 4 && contor8 / 4 == contor10 / 4 && contor9 / 4 == contor10 / 4 && contor6 / 4 == contor7 / 4)
                    {
                        if (contor6 / 4 == contor7 / 4 && contor6 / 4 == contor8 / 4 && contor6 / 4 == contor9 / 4 && contor7 / 4 == contor8 / 4 && contor7 / 4 == contor9 / 4 && contor8 / 4 == contor9 / 4 ||
                            contor6 / 4 == contor7 / 4 && contor6 / 4 == contor8 / 4 && contor6 / 4 == contor10 / 4 && contor7 / 4 == contor8 / 4 && contor7 / 4 == contor10 / 4 && contor8 / 4 == contor10 / 4 ||
                            contor6 / 4 == contor8 / 4 && contor6 / 4 == contor9 / 4 && contor6 / 4 == contor10 / 4 && contor8 / 4 == contor9 / 4 && contor8 / 4 == contor10 / 4 && contor9 / 4 == contor10 / 4 ||
                            contor7 / 4 == contor8 / 4 && contor7 / 4 == contor9 / 4 && contor7 / 4 == contor10 / 4 && contor8 / 4 == contor9 / 4 && contor8 / 4 == contor10 / 4 && contor9 / 4 == contor10 / 4)
                        {
                            label2.Text = "4 Bucati";
                            check2[0] = contor6 / 4;
                            check2[1] = contor7 / 4;
                            check2[2] = contor8 / 4;
                            check2[3] = contor9 / 4;
                            check2[4] = contor10 / 4;
                        }
                        else
                        {
                            label2.Text = "Full";
                            check2[0] = contor6 / 4;
                            check2[1] = contor7 / 4;
                            check2[2] = contor8 / 4;
                            check2[3] = contor9 / 4;
                            check2[4] = contor10 / 4;
                            check2.Sort();
                        }
                    }
                    else
                    {
                        label2.Text = "3 Bucati";
                        check2[0] = contor6 / 4;
                        check2[1] = contor7 / 4;
                        check2[2] = contor8 / 4;
                        check2[3] = contor9 / 4;
                        check2[4] = contor10 / 4;
                        for (int i = 0; i < 5; i++)
                            for (int j = 0; j < 5; j++)
                            {
                                if (check2[i] == check2[j] && i < j)
                                {
                                    treiBucati.Add(check2[i]);
                                }
                            }
                    }
                }
                else
                {
                    if (contor6 / 4 == contor7 / 4) { k2++; oPereche.Add(contor6 / 4); }
                    if (contor6 / 4 == contor8 / 4) { k2++; oPereche.Add(contor6 / 4); }
                    if (contor6 / 4 == contor9 / 4) { k2++; oPereche.Add(contor6 / 4); }
                    if (contor6 / 4 == contor10 / 4) { k2++; oPereche.Add(contor6 / 4); }
                    if (contor7 / 4 == contor8 / 4) { k2++; oPereche.Add(contor7 / 4); }
                    if (contor7 / 4 == contor9 / 4) { k2++; oPereche.Add(contor7 / 4); }
                    if (contor7 / 4 == contor10 / 4) { k2++; oPereche.Add(contor7 / 4); }
                    if (contor8 / 4 == contor9 / 4) { k2++; oPereche.Add(contor8 / 4); }
                    if (contor8 / 4 == contor10 / 4) { k2++; oPereche.Add(contor8 / 4); }
                    if (contor9 / 4 == contor10 / 4) { k2++; oPereche.Add(contor9 / 4); }
                    if (k2 == 1) label2.Text = "1 Pereche";
                    if (k2 == 2) label2.Text = "2 Perechi";
                    k2 = 0;
                }
            }
            else
            {
                int x;
                x = contor6 % 4;
                if (contor7 % 4 == x && contor8 % 4 == x && contor9 % 4 == x && contor10 % 4 == x)
                {
                    label2.Text = "Culoare";
                }
                else
                {
                    check2[0] = contor6 / 4;
                    check2[1] = contor7 / 4;
                    check2[2] = contor8 / 4;
                    check2[3] = contor9 / 4;
                    check2[4] = contor10 / 4;
                    check2.Sort();

                    if (check2[0] == check2[1] - 1 && check2[1] == check2[2] - 1 && check2[2] == check2[3] - 1 && check2[3] == check2[4] - 1)
                        label2.Text = "Kinta";
                    else
                    {
                        s2 = (check2[4] + 2).ToString();
                        label2.Text = "High " + s2;
                    }
                }
            }
            //
            //De aici incepe verificarea propriu-zisa a mainilor fiecaruia
            //
            if (label1.Text != "1 Pereche" && label1.Text != "2 Perechi" && label1.Text != "Full" && label1.Text != "3 Bucati" && label1.Text != "4 Bucati" && label1.Text != "Culoare" && label1.Text != "Kinta" &&
                label2.Text != "1 Pereche" && label2.Text != "2 Perechi" && label2.Text != "Full" && label2.Text != "3 Bucati" && label2.Text != "4 Bucati" && label2.Text != "Culoare" && label2.Text != "Kinta")
            {
                //inseamna ca nu am nimic, iar castigatorul se decide dupa cartea cea mai mare
                //trebuie retinut ca asul reprezinta valoarea 11 si nu este cea mai mare carte
                //cea mai mare fiind popa ( K)
                if (Convert.ToInt32(s) > Convert.ToInt32(s2)) { MessageBox.Show("Castigator Jucator 1"); scor1++; label5.Text = scor1.ToString(); }
                if (Convert.ToInt32(s) < Convert.ToInt32(s2)) { MessageBox.Show("Castigator Calculator"); scor2++; label6.Text = scor2.ToString(); }
                if (s == s2) MessageBox.Show("Remiza");
            }
            //
            //
            if (label1.Text != "1 Pereche" && label1.Text != "2 Perechi" && label1.Text != "Full" && label1.Text != "3 Bucati" && label1.Text != "4 Bucati" && label1.Text != "Culoare" && label1.Text != "Kinta" &&
                (label2.Text == "1 Pereche" || label2.Text == "2 Perechi" || label2.Text == "Full" || label2.Text == "3 Bucati" || label2.Text == "4 Bucati" || label2.Text == "Culoare" || label2.Text == "Kinta"))
            {
                //daca primul jucator nu are nimic, iar calculatorul are orice altceva
                // => castigator calculator
                MessageBox.Show("Castigator Calculator");
                scor2++;
                label6.Text = scor2.ToString();
            }
            if (label2.Text != "1 Pereche" && label2.Text != "2 Perechi" && label2.Text != "Full" && label2.Text != "3 Bucati" && label2.Text != "4 Bucati" && label2.Text != "Culoare" && label2.Text != "Kinta" &&
                (label1.Text == "1 Pereche" || label1.Text == "2 Perechi" || label1.Text == "Full" || label1.Text == "3 Bucati" || label1.Text == "4 Bucati" || label1.Text == "Culoare" || label1.Text == "Kinta"))
            {
                // acelasi lucru, numai ca pentru jucator
                MessageBox.Show("Castigator Jucator 1");
                scor1++;
                label5.Text = scor1.ToString();
            }
            //
            //
            if (label1.Text == "1 Pereche" && label2.Text == "1 Pereche")
            {
                //daca ambii jucatori au 1 pereche, inseamna ca in lista voi verifica
                //ultimele 2 valori consecutive
                if (oPereche[oPereche.Count - 2] > oPereche[oPereche.Count - 1])
                    //daca prima valoare este mai mare decat cea de-a doua , castiga jucator
                { MessageBox.Show("Castigator Jucator 1"); scor1++; label5.Text = scor1.ToString(); }
                if (oPereche[oPereche.Count - 2] < oPereche[oPereche.Count - 1])
                { MessageBox.Show("Castigator Calculator"); scor2++; label6.Text = scor2.ToString(); }
                if (oPereche[oPereche.Count - 2] == oPereche[oPereche.Count - 1])
                    MessageBox.Show("Remiza");
            }
            //
            //
            if (label1.Text == "2 Perechi" && label2.Text == "2 Perechi")
            {
                //daca cei doi au 2 perechi, lista oPereche se va completa cu cate 4 valori 
                //2 pentru jucator si 2 pentru calculator, primele fiind pentru jucator
                //este suficient ca o singura pereche sa fie mai mare decat celelalte 2 ale oponentului
                if (oPereche[oPereche.Count - 4] > oPereche[oPereche.Count - 2] ||
                    oPereche[oPereche.Count - 4] > oPereche[oPereche.Count - 1] ||
                    oPereche[oPereche.Count - 3] > oPereche[oPereche.Count - 2] ||
                    oPereche[oPereche.Count - 3] > oPereche[oPereche.Count - 1])
                {
                    MessageBox.Show("Castigator Jucator 1");
                    scor1++;
                    label5.Text = scor1.ToString();
                }
                if (oPereche[oPereche.Count - 4] < oPereche[oPereche.Count - 2] ||
                    oPereche[oPereche.Count - 4] < oPereche[oPereche.Count - 1] ||
                    oPereche[oPereche.Count - 3] < oPereche[oPereche.Count - 2] ||
                    oPereche[oPereche.Count - 3] < oPereche[oPereche.Count - 1])
                {
                    MessageBox.Show("Castigator Calculator");
                    scor2++;
                    label6.Text = scor2.ToString();
                }
                if (oPereche[oPereche.Count - 4] == oPereche[oPereche.Count - 2] &&
                    oPereche[oPereche.Count - 4] == oPereche[oPereche.Count - 1] &&
                    oPereche[oPereche.Count - 3] == oPereche[oPereche.Count - 2] &&
                    oPereche[oPereche.Count - 3] == oPereche[oPereche.Count - 1])
                {
                    MessageBox.Show("Remiza");
                }
            }
            //
            //
            if (label1.Text == "1 Pereche" && label2.Text == "2 Perechi")
            {
                MessageBox.Show("Castigator Calculator");
                scor2++;
                label6.Text = scor2.ToString();
            }
            if (label1.Text == "2 Perechi" && label2.Text == "1 Pereche")
            {
                MessageBox.Show("Castigator Jucator 1");
                scor1++;
                label5.Text = scor1.ToString();
            }
            //
            //
            if (label1.Text == "3 Bucati" && label2.Text == "1 Pereche" || label1.Text == "3 Bucati" && label2.Text == "2 Perechi")
            {
                MessageBox.Show("Castigator Jucator 1");
                scor1++;
                label5.Text = scor1.ToString();
            }
            if (label2.Text == "3 Bucati" && label1.Text == "1 Pereche" || label2.Text == "3 Bucati" && label1.Text == "2 Perechi")
            {
                MessageBox.Show("Castigator Calculator");
                scor2++;
                label6.Text = scor2.ToString();
            }
            if (label1.Text == "3 Bucati" && label2.Text == "3 Bucati")
            {
                if (treiBucati[treiBucati.Count - 2] > treiBucati[treiBucati.Count - 1])
                {
                    MessageBox.Show("Castigator Jucator 1");
                    scor1++;
                    label5.Text = scor1.ToString();
                }
                if (treiBucati[treiBucati.Count - 2] < treiBucati[treiBucati.Count - 1])
                {
                    MessageBox.Show("Castigator Calculator");
                    scor2++;
                    label6.Text = scor2.ToString();
                }
                if (treiBucati[treiBucati.Count - 2] == treiBucati[treiBucati.Count - 1])
                {
                    MessageBox.Show("Remiza");
                }
            }
            //
            //
            if (label1.Text == "Full" && (label2.Text == "1 Pereche" || label2.Text == "2 Perechi" || label2.Text == "3 Bucati"))
            {
                MessageBox.Show("Castigator Jucator 1");
                scor1++;
                label5.Text = scor1.ToString();
            }
            if (label2.Text == "Full" && (label1.Text == "1 Pereche" || label1.Text == "2 Perechi" || label1.Text == "3 Bucati"))
            {
                MessageBox.Show("Castigator Calculator");
                scor2++;
                label6.Text = scor2.ToString();
            }
            if (label1.Text == "Full" && label2.Text == "Full")
            {
                if (check[0] == check[1] && check[0] == check[2] && check[1] == check[2] && check2[0] == check2[1] && check2[0] == check2[2] && check2[1] == check2[2])
                {
                    if (check[0] > check2[0]) { MessageBox.Show("Castigator Jucator 1"); scor1++; label5.Text = scor1.ToString(); }
                    if (check[0] < check2[0]) { MessageBox.Show("Castigator Calculator"); scor2++; label6.Text = scor2.ToString(); }
                }
                if (check[0] == check[1] && check[0] == check[2] && check[1] == check[2] && check2[0] == check2[1] && check2[0] != check2[2] && check2[1] != check2[2])
                {
                    if (check[3] > check2[3]) { MessageBox.Show("Castigator Jucator 1"); scor1++; label5.Text = scor1.ToString(); }
                    if (check[3] < check2[3]) { MessageBox.Show("Castigator Calculator"); scor2++; label6.Text = scor2.ToString(); }
                }
            }
            //
            //
            if (label1.Text == "4 Bucati" && (label2.Text == "1 Pereche" || label2.Text == "2 Perechi" || label2.Text == "3 Bucati" || label2.Text == "Full"))
            {
                MessageBox.Show("Castigator Jucator 1");
                scor1++;
                label5.Text = scor1.ToString();
            }
            if (label2.Text == "4 Bucati" && (label1.Text == "1 Pereche" || label1.Text == "2 Perechi" || label1.Text == "3 Bucati" || label1.Text == "Full"))
            {
                MessageBox.Show("Castigator Calculator");
                scor2++;
                label6.Text = scor2.ToString();
            }
            if (label1.Text == "4 Bucati" && label2.Text == "4 Bucati")
            {
                if (check[1] > check2[1]) { MessageBox.Show("Castigator Jucator 1"); scor1++; label5.Text = scor1.ToString(); }
                if (check[1] < check2[1]) { MessageBox.Show("Castigator Calculator"); scor2++; label6.Text = scor2.ToString(); }
            }
            //
            //
            if (label1.Text == "Kinta" && (label2.Text == "1 Pereche" || label2.Text == "2 Perechi" || label2.Text == "3 Bucati" || label2.Text == "Full" || label2.Text == "4 Bucati"))
            {
                MessageBox.Show("Castigator Jucator 1");
                scor1++;
                label5.Text = scor1.ToString();
            }
            if (label2.Text == "Kinta" && (label1.Text == "1 Pereche" || label1.Text == "2 Perechi" || label1.Text == "3 Bucati" || label1.Text == "Full" || label1.Text == "4 Bucati"))
            {
                MessageBox.Show("Castigator Calculator");
                scor2++;
                label6.Text = scor2.ToString();
            }
            if (label1.Text == "Kinta" && label2.Text == "Kinta")
            {
                if (check[0] > check2[0])
                {
                    MessageBox.Show("Castigator Jucator 1");
                    scor1++;
                    label5.Text = scor1.ToString();
                }
                if (check[0] < check2[0])
                {
                    MessageBox.Show("Castigator Calculator");
                    scor2++;
                    label6.Text = scor2.ToString();
                }
                if (check[0] == check2[0]) MessageBox.Show("Remiza");
            }
            //
            //
            if (label1.Text == "Culoare" && (label2.Text == "1 Pereche" || label2.Text == "2 Perechi" || label2.Text == "3 Bucati" || label2.Text == "Full" || label2.Text == "4 Bucati" || label2.Text == "Kinta"))
            {
                MessageBox.Show("Castigator Jucator 1");
                scor1++;
                label5.Text = scor1.ToString();
            }
            if (label2.Text == "Culoare" && (label1.Text == "1 Pereche" || label1.Text == "2 Perechi" || label1.Text == "3 Bucati" || label1.Text == "Full" || label1.Text == "4 Bucati" || label1.Text == "Kinta"))
            {
                MessageBox.Show("Castigator Calculator");
                scor2++;
                label6.Text = scor2.ToString();
            }
            if (label1.Text == "Culoare" && label2.Text == "Culoare")
            {
                MessageBox.Show("Remiza");
            }
            //
            //
            //
            //
            button3.Enabled = true;
            button2.Enabled = false;
        }

        //NU SCHIMB
        private void button4_Click(object sender, EventArgs e)
        {
            //daca nu vreau sa schimb,dar totusi este o casuta bifata
            if (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true || checkBox4.Checked == true || checkBox5.Checked == true)
            {
                MessageBox.Show("Ati ales deja sa schimbati cartile ! Va rugam sa apasati pe butonul SCHIMBA");
            }
            else
            {
                button1.Enabled = false;
                button4.Enabled = false;
                button2.Enabled = true;
            }
        }

    }
}