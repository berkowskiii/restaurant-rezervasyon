using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restaurant_rezarvasyon
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public static int gondskor;
        int sayac = 0;
        void randombaslangic()
        {
            Random rnd = new Random();
            int randx = rnd.Next(12, 856);
            Point bas = new Point();
            bas.X = randx;
            bas.Y = 12;
            pictureBox2.Location = bas;
        }
        void baslangic()
        {
            Point basla = new Point();
            basla.X = 393;
            basla.Y = 50;
            pictureBox2.Location = basla;
        }
        void sepet()
        {
            Point sepet = new Point();
            sepet.X = 350;
            sepet.Y = 450;
            pictureBox1.Location = sepet;
        }
        void seviye()
        {
            label2.Visible = true;
            label2.Text = "Seviyeniz Yükseldi..";
        }
        void seviyedur()
        {
            label2.Text = "";
        }
        void skor()
        {
            label1.Text = (Convert.ToInt32(label1.Text) + 1).ToString();
        }
        void skorsifirla()
        {
            label1.Text = "Puanınız : " + 0.ToString();
        }
        void skorgoster()
        {
            MessageBox.Show("" + ((label1.Text).ToString())).ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)//hamburgerin kontrolü
        {
            var rect1 = new Rectangle(new Point(pictureBox2.Location.X, pictureBox2.Location.Y), pictureBox2.Size);//picturebox2'nin x ve y noktalarını picturebox2'nin boyutuna eşitlenir
            var rect2 = new Rectangle(new Point(pictureBox1.Location.X, pictureBox1.Location.Y), pictureBox1.Size);//picturebox1'in x ve y noktalarını picturebox1'in boyutuna eşitlenir
            pictureBox2.Top += 7;//nesnenin top noktasına girilen değer kadar ekler ve ona göre düşme hızı ayarlanır
            if (rect1.IntersectsWith(rect2)/*button1.Top >= button2.Top && button1.Left >= button2.Left && button1.Right <= button2.Right*/)
            {
                Form1 frm1 = new Form1();
                randombaslangic();
                sayac += 1;
                label1.Text = "Puanınız : " + sayac.ToString();
                gondskor = sayac;
            }
            if (sayac >= 10)
            {
                if (sayac == 10)
                {
                    seviye();
                }
                if (sayac == 12)
                {
                    seviyedur();
                }
                pictureBox2.Top += 7;
            }
            if (sayac >= 20)
            {
                if (sayac == 20)
                {
                    seviye();
                }
                if (sayac == 22)
                {
                    seviyedur();
                }
                pictureBox2.Top += 10;
            }
            if (sayac >= 30)
            {
                if (sayac == 30)
                {
                    seviye();
                }
                if (sayac == 32)
                {
                    seviyedur();
                }
                pictureBox2.Top += 15;
            }
            if (pictureBox2.Top > pictureBox1.Bottom)
            {
                baslangic();
                sepet();
                timer1.Stop();
                timer2.Stop();
                Cursor.Show();
                MessageBox.Show("Yandınız !");
                seviyedur();
                skorgoster();
                button1.Visible = true;
                label3.Text = "Oyuna Başlamak İçin Sepete Tıklayınız ! ";
                skorsifirla();
                sayac = 0;

            }
        }

        private void timer2_Tick(object sender, EventArgs e)//sepetin kontrolü
        {

            var rect2 = new Rectangle(new Point(pictureBox1.Location.X, pictureBox1.Location.Y), pictureBox1.Size);////picturebox1'nin x ve y noktalarını picturebox1'nin boyutuna eşitlenir
            var rect4 = new Rectangle(new Point(pictureBox2.Location.X, pictureBox2.Location.Y), pictureBox2.Size);//picturebox2'nin x ve y noktalarını picturebox2'nin boyutuna eşitlenir
            if (rect2.IntersectsWith(rect4))
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X - 10, 440);
            }
            else
            {
                pictureBox1.Location = new Point(Cursor.Position.X, 440);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            randombaslangic();
            label3.Text = "";
            skorsifirla();
            timer1.Start();
            timer2.Start();
            Cursor.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Close();
            frm1.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

    }
}
