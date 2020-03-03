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
    public partial class yonetici : Form
    {
        public yonetici()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string kullaniciadi;
        private void yonetici_Load(object sender, EventArgs e)
        {
            lblkullanici.Text = " Hoşgeldiniz  " + kullaniciadi;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form rezervasyon = new rezervasyon();
            rezervasyon.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form eglencemerkezi = new EglenceMerkezi();
            eglencemerkezi.Show();
            
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form kapat = new yoneticigirisi();
            kapat.Show();
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select* From yonetici ", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            Form konuklistele = new konuklist();
            konuklistele.Show();
            
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            
            Form rezervasyonlistele = new rezervasyonlist();
            rezervasyonlistele.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form musteritemsilcisi = new musteritemsilcisi ();
            musteritemsilcisi.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form daireler = new daireler();
            daireler.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form odalar = new odalar();
            odalar.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form esyalar = new esyalar();
            esyalar.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form daireler = new daireler();
            daireler.Show();
        }

        
    }
}
