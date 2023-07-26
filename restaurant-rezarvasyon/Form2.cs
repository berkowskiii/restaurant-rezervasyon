using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace restaurant_rezarvasyon
{
    public partial class Form2 : Form
    {
        OleDbDataReader rd;
        OleDbCommand komut = new OleDbCommand();
        public Form2()
        {
            InitializeComponent();
            baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=rezervasyon.mdb");
            bosmasa();
            masakontrol();
            boyama();
        }

        int[] no = new int[8];
        void boyama()
        {
            for (int i = 0; i < no.Length; i++)
            {
                switch (no[i])
                {
                    case 1:
                        {
                            pictureBox1.BackColor = Color.Red;
                            break;
                        }
                    case 2:
                        {
                            pictureBox2.BackColor = Color.Red;
                            break;
                        }
                    case 3:
                        {
                            pictureBox3.BackColor = Color.Red;
                            break;
                        }
                    case 4:
                        {
                            pictureBox4.BackColor = Color.Red;
                            break;
                        }
                    case 5:
                        {
                            pictureBox5.BackColor = Color.Red;
                            break;
                        }
                    case 6:
                        {
                            pictureBox6.BackColor = Color.Red;
                            break;
                        }
                    case 7:
                        {
                            pictureBox7.BackColor = Color.Red;
                            break;
                        }
                    case 8:
                        {
                            pictureBox8.BackColor = Color.Red;
                            break;
                        }
                    case 9:
                        {
                            pictureBox9.BackColor = Color.Red;
                            break;
                        }
                        
                }
            }
        }
        void dolumasa()
        {
            if (pictureBox1.BackColor == Color.Red)
            {
                pictureBox1.Enabled = false;
            }
            if (pictureBox2.BackColor == Color.Red)
            {
                pictureBox2.Enabled = false;
            }
            if (pictureBox3.BackColor == Color.Red)
            {
                pictureBox3.Enabled = false;
            }
            if (pictureBox4.BackColor == Color.Red)
            {
                pictureBox4.Enabled = false;
            }
            if (pictureBox5.BackColor == Color.Red)
            {
                pictureBox5.Enabled = false;
            }
            if (pictureBox6.BackColor == Color.Red)
            {
                pictureBox6.Enabled = false;
            }
            if (pictureBox7.BackColor == Color.Red)
            {
                pictureBox7.Enabled = false;
            }
            if (pictureBox8.BackColor == Color.Red)
            {
                pictureBox8.Enabled = false;
            }
            if (pictureBox9.BackColor == Color.Red)
            {
                pictureBox9.Enabled = false;
            }
        }
        void masakontrol()
        {
            int i=0;          
            baglanti.Open();
            komut.CommandText = ("Select * From Rezervasyon");
            komut.Connection = baglanti;
            rd = komut.ExecuteReader();

            while (rd.Read())
            {              
                no[i] = Convert.ToInt32(rd["Masa_No"]);
                i++;
            }
            baglanti.Close();
        }
        void bosmasa()
        {
            pictureBox1.BackColor = Color.Gray;
            pictureBox2.BackColor = Color.Gray;
            pictureBox3.BackColor = Color.Gray;
            pictureBox4.BackColor = Color.Gray;
            pictureBox5.BackColor = Color.Gray;
            pictureBox6.BackColor = Color.Gray;
            pictureBox7.BackColor = Color.Gray;
            pictureBox8.BackColor = Color.Gray;
            pictureBox9.BackColor = Color.Gray;
        }
        public string kayitbilgi1="";
        public string kayitbilgi2 = "";
        public string kayitbilgi3 = "";
        public string kayitbilgi4 = "";

        public OleDbConnection baglanti;
        int click1 = 0;
        int click2 = 0;
        int click3 = 0;
        int click4 = 0;
        int click5 = 0;
        int click6 = 0;
        int click7 = 0;
        int click8 = 0;
        int click9 = 0;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            click1++;
            if (click1 % 2 == 0) pictureBox1.BackColor = Color.Gray;
            else pictureBox1.BackColor = Color.Yellow;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            click2++;
            if (click2 % 2 == 0) pictureBox2.BackColor = Color.Gray;
            else pictureBox2.BackColor = Color.Yellow;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            click3++;
            if (click3 % 2 == 0) pictureBox3.BackColor = Color.Gray;
            else pictureBox3.BackColor = Color.Yellow;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            click4++;
            if (click4 % 2 == 0) pictureBox6.BackColor = Color.Gray;
            else pictureBox6.BackColor = Color.Yellow;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            click5++;
            if (click5 % 2 == 0) pictureBox5.BackColor = Color.Gray;
            else pictureBox5.BackColor = Color.Yellow;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            click6++;
            if (click6 % 2 == 0) pictureBox4.BackColor = Color.Gray;
            else pictureBox4.BackColor = Color.Yellow;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            click7++;
            if (click7 % 2 == 0) pictureBox9.BackColor = Color.Gray;
            else pictureBox9.BackColor = Color.Yellow;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            click8++;
            if (click8 % 2 == 0) pictureBox8.BackColor = Color.Gray;
            else pictureBox8.BackColor = Color.Yellow;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            click9++;
            if (click9 % 2 == 0) pictureBox7.BackColor = Color.Gray;
            else pictureBox7.BackColor = Color.Yellow;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            dolumasa();
            button1.BackColor = Color.Gray;
            button2.BackColor = Color.Yellow;
            button3.BackColor = Color.Red;

        }

        public void kaydet()
        {

            int Masa_no=0;
            if (pictureBox1.BackColor == Color.Yellow)
            {
                Masa_no = 1;
                MessageBox.Show("Rezervasyonunuz Oluşturuldu Afiyet Olsun :)");
                pictureBox1.BackColor = Color.Red;

            }
            if (pictureBox2.BackColor == Color.Yellow)
            {
                Masa_no = 2;
                MessageBox.Show("Rezervasyonunuz Oluşturuldu Afiyet Olsun :)");
                pictureBox2.BackColor = Color.Red;
            }
            if (pictureBox3.BackColor == Color.Yellow)
            {
                Masa_no = 3;
                MessageBox.Show("Rezervasyonunuz Oluşturuldu Afiyet Olsun :)");
                pictureBox3.BackColor = Color.Red;
            }
            if (pictureBox4.BackColor == Color.Yellow)
            {
                Masa_no = 4;
                MessageBox.Show("Rezervasyonunuz Oluşturuldu Afiyet Olsun :)");
                pictureBox4.BackColor = Color.Red;
            }
            if (pictureBox5.BackColor == Color.Yellow)
            {
                Masa_no = 5;
                MessageBox.Show("Rezervasyonunuz Oluşturuldu Afiyet Olsun :)");
                pictureBox5.BackColor = Color.Red;
            }
            if (pictureBox6.BackColor == Color.Yellow)
            {
                Masa_no = 6;
                MessageBox.Show("Rezervasyonunuz Oluşturuldu Afiyet Olsun :)");
                pictureBox6.BackColor = Color.Red;
            }
            if (pictureBox7.BackColor == Color.Yellow)
            {
                Masa_no = 7;
                MessageBox.Show("Rezervasyonunuz Oluşturuldu Afiyet Olsun :)");
                pictureBox7.BackColor = Color.Red;
            }
            if (pictureBox8.BackColor == Color.Yellow)
            {
                Masa_no = 8;
                MessageBox.Show("Rezervasyonunuz Oluşturuldu Afiyet Olsun :)");
                pictureBox8.BackColor = Color.Red;
            }
            if (pictureBox9.BackColor == Color.Yellow)
            {
                Masa_no = 9;
                MessageBox.Show("Rezervasyonunuz Oluşturuldu Afiyet Olsun :)");
                pictureBox9.BackColor = Color.Red;
            }
            baglanti.Open();
            komut.CommandText = ("insert into Rezervasyon (TC_No,Ad,Soyad,Telefon_No,Masa_No,Indirim) values ('" + kayitbilgi1 + "','" + kayitbilgi2 + "','" + kayitbilgi3 + "','" + kayitbilgi4 + "'," + Masa_no + "," + Form1.skor + ")");
            
            komut.ExecuteReader();
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!(pictureBox1.BackColor == Color.Yellow || pictureBox2.BackColor == Color.Yellow || pictureBox3.BackColor == Color.Yellow || pictureBox4.BackColor == Color.Yellow || pictureBox5.BackColor == Color.Yellow || pictureBox6.BackColor == Color.Yellow || pictureBox7.BackColor == Color.Yellow || pictureBox8.BackColor == Color.Yellow || pictureBox9.BackColor == Color.Yellow))
            {
                MessageBox.Show("Lütfen Masa Seçiniz !");
            }
            else
            {
                kaydet();
                Form1 frm1 = new Form1();
                frm1.Show();
                this.Hide();
            }
            
        }
    }
}
