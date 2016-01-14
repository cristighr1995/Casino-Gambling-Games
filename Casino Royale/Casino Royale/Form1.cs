using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Configuration;

namespace Casino_Royale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\1.jpg");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
            label5.BackColor = Color.Transparent;
        }

        //verific daca login-ul este bun
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCeConnection conn = new SqlCeConnection(ConfigurationManager.ConnectionStrings["Casino_Royale.Properties.Settings.Database1ConnectionString"].ConnectionString);
                SqlCeCommand command = new SqlCeCommand("select * from LOGIN where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'  ;", conn);

                SqlCeDataReader dr;

                command.Connection = conn;
                conn.Open();

                dr = command.ExecuteReader();
                int count = 0;

                while (dr.Read())
                {
                    count++;
                }

                if (count == 1)
                {
                    MessageBox.Show("Bun venit, " + textBox1.Text + " !");
                    this.Hide();
                    Form2 formDoi = new Form2();
                    formDoi.ShowDialog();
                }
                else
                {
                    if (count > 1) MessageBox.Show("Cont duplicat ! Va rugam sa va creati alt cont !");
                    if (count == 0) MessageBox.Show("Ati introdus gresit username-ul sau parola sau contul este inexistent !");
                }
            }
            catch (SqlCeException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //adauga cont
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCeConnection conn = new SqlCeConnection(ConfigurationManager.ConnectionStrings["Casino_Royale.Properties.Settings.Database1ConnectionString"].ConnectionString);
                SqlCeCommand cmdInsert = new SqlCeCommand("insert into LOGIN (username,password) values ('" + textBox1.Text + "', '" + textBox2.Text + "') ;", conn);
                SqlCeDataReader dr;
                cmdInsert.Connection = conn;
                conn.Open();
                dr = cmdInsert.ExecuteReader();
                MessageBox.Show("Contul a fost adaugat cu succes");
                textBox1.Text = "";
                textBox2.Text = ""; 
            }
            catch (SqlCeException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
