using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdiguzelTatilKoyu
{
    public partial class yoneticigirisi : Form
    {
        public yoneticigirisi()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Lütfen Giriş Bilgilerini Doldurunuz", "Tatil Köyü");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Kullanıcı Adını Giriniz", "Tatil Köyü");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Lütfen Şifreyi Giriniz", "Tatil Köyü");
            }
            else { 

                SqlCommand komut = new SqlCommand("Select* From yonetici Where YKullaniciAdi=@p1 and Ysifre=@p2", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    yonetici yon = new yonetici();
                    yon.kullaniciadi = textBox1.Text;
                    yon.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı & Şifre", "Tatil Köyü");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                bgl.baglanti().Close();
        }   }

        private void button2_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            Form kapat = new Form1();
            kapat.Show();
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}