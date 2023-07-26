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
using System.Text.RegularExpressions;

namespace restaurant_rezarvasyon
{
    public partial class Form1 : Form
    {
        OleDbCommand komut = new OleDbCommand();
        public Form1()
        {
            InitializeComponent();
            baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=rezervasyon.mdb");
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
        //YÖNETİCİ ŞİFRE = admin
        //yönetici şifresini girdikten sonra rezervasynoları görüntüle dedikten sonra tc kimlik numarasına tıklayarak kaydı silebilirsiniz
        //------------------------------------------------------------------------------------------------------------------------------------------------
        int click = 0;
        public OleDbConnection baglanti;
        void verilerigoster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * From Rezervasyon");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["TC_No"].ToString();
                ekle.SubItems.Add(oku["Ad"].ToString());
                ekle.SubItems.Add(oku["Soyad"].ToString());
                ekle.SubItems.Add(oku["Telefon_No"].ToString());
                ekle.SubItems.Add(oku["Masa_No"].ToString());
                ekle.SubItems.Add(oku["Indirim"].ToString());
                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Lütfen Bilgileri Doldurunuz !!");
            }
            if (textBox4.Text.Length < 11)
            {
                errorProvider1.SetError(textBox4, "Eksik Karakter Girdiniz !!");
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
                Form2 frm2 = new Form2();
                frm2.kayitbilgi1 = textBox1.Text;
                frm2.kayitbilgi2 = textBox2.Text;
                frm2.kayitbilgi3 = textBox3.Text;
                frm2.kayitbilgi4 = textBox4.Text;
                frm2.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            click++;
            if (click % 2 == 1)
            {
                listView1.Visible = true;
            }
            else
            {
                listView1.Visible = false;
            }

            verilerigoster();
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            checkBox1.Enabled = true;
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            if (Form3.gondskor == 0)
            {
                checkBox1.Enabled = false;
            }
            textBox1.MaxLength = 11;
            textBox4.MaxLength = 11;
            ToolTip aciklama = new ToolTip();
            aciklama.ToolTipTitle = "Bilgilendirme!";
            aciklama.SetToolTip(button3, "Basit bir oyun oynayarak indirim kazanabilirsiniz");
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 11)
            {
                errorProvider1.SetError(textBox1, "Eksik Karakter Girdiniz !!");
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
        }
        public static int skor = 0;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                skor = Form3.gondskor;
            }
            else
            {
                skor = 0;
            }
            label5.Text = "";
            checkBox1.Text = Form3.gondskor + " TL İndirim Kazandınız";
            if (checkBox1.Checked == false)
            {
                checkBox1.Text = "";
                label5.Text = "İndirimi Kullanmak İçin Tıklayınız";
            }
        }
        string items;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                items = listView1.SelectedItems[0].Text.ToString();
                DialogResult dialogResult = MessageBox.Show(items + " TC Nolu Rezervasyonu Silmek İstiyor Musunuz ?", "Sil", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (textBox5.Text == "admin")
                    {
                        baglanti.Open();
                        komut.CommandText = ("delete from Rezervasyon where TC_No = '" + items + "'");
                        komut.ExecuteReader();
                        baglanti.Close();
                        verilerigoster();
                        textBox5.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Yönetici Şifresi Giriniz !!!");
                    }
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)//tc kimlik no textbox(kullanıcı sadece rakam girebilir harf giremez)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)//ad textbox(kullanıcı sadece harf girebilir rakam giremez)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

    }

}
    
