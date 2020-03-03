using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AdiguzelTatilKoyu
{
    public partial class daireler : Form
    {
        public daireler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void daireler_Load(object sender, EventArgs e)
        {


            SqlCommand komut = new SqlCommand("Select * from Daire, Rezervasyonlar where Daire.daireID=Rezervasyonlar.daireID and RezervasyonDurum=0", bgl.baglanti());
            SqlDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                if (okuyucu["daireID"].ToString() == "A1")
                {
                    A1.BackColor = Color.Red;
                    lbla1.Text = okuyucu["isim"].ToString();
                    lbla1.BackColor = Color.Red;
                    label1.BackColor = Color.Red;
                }
                if (okuyucu["daireID"].ToString() == "A2")
                {
                    A2.BackColor = Color.Red;
                    lbla2.Text = okuyucu["isim"].ToString();
                    lbla2.BackColor = Color.Red;
                    label2.BackColor = Color.Red;
                }
                if (okuyucu["daireID"].ToString() == "A3")
                {
                    A3.BackColor = Color.Red;
                    lbla3.Text = okuyucu["isim"].ToString();
                    lbla3.BackColor = Color.Red;
                    label3.BackColor = Color.Red;

                }
                if (okuyucu["daireID"].ToString() == "A4")
                {
                    A4.BackColor = Color.Red;
                    lbl4.Text = okuyucu["isim"].ToString();
                    lbl4.BackColor = Color.Red;
                    label4.BackColor = Color.Red;
                }
                if (okuyucu["daireID"].ToString() == "A5")
                {
                    A5.BackColor = Color.Red;
                    lbl5.Text = okuyucu["isim"].ToString();
                    lbl5.BackColor = Color.Red;
                    label5.BackColor = Color.Red;
                }
                if (okuyucu["daireID"].ToString() == "A6")
                {
                    A6.BackColor = Color.Red;
                    lbla6.Text = okuyucu["isim"].ToString();
                    lbla6.BackColor = Color.Red;
                    label6.BackColor = Color.Red;
                }
                if (okuyucu["daireID"].ToString() == "B1")
                {
                    B1.BackColor = Color.Red;
                    lblb1.Text = okuyucu["isim"].ToString();
                    lblb1.BackColor = Color.Red;
                    label7.BackColor = Color.Red;
                }
                if (okuyucu["daireID"].ToString() == "B2")
                {
                    B2.BackColor = Color.Red;
                    lblb2.Text = okuyucu["isim"].ToString();
                    lblb2.BackColor = Color.Red;
                    label8.BackColor = Color.Red;
                }
                if (okuyucu["daireID"].ToString() == "B3")
                {
                    B3.BackColor = Color.Red;
                    lblb3.Text = okuyucu["isim"].ToString();
                    lblb3.BackColor = Color.Red;
                    label9.BackColor = Color.Red;

                }
                if (okuyucu["daireID"].ToString() == "A4")
                {
                    B4.BackColor = Color.Red;
                    lblb4.Text = okuyucu["isim"].ToString();
                    lblb4.BackColor = Color.Red;
                    label10.BackColor = Color.Red;
                }
                if (okuyucu["daireID"].ToString() == "B5")
                {
                    B5.BackColor = Color.Red;
                    lblb5.Text = okuyucu["isim"].ToString();
                    lblb5.BackColor = Color.Red;
                    label11.BackColor = Color.Red;
                }
                if (okuyucu["daireID"].ToString() == "B6")
                {
                    B6.BackColor = Color.Red;
                    lblb6.Text = okuyucu["isim"].ToString();
                    lblb6.BackColor = Color.Red;
                    label12.BackColor = Color.Red;
                }
                if (okuyucu["daireID"].ToString() == "C1")
                {
                    C1.BackColor = Color.Red;
                    lblc1.Text = okuyucu["isim"].ToString();
                    lblc1.BackColor = Color.Red;
                    label13.BackColor = Color.Red;
                }
                if (okuyucu["daireID"].ToString() == "C2")
                {
                    C2.BackColor = Color.Red;
                    lblc2.Text = okuyucu["isim"].ToString();
                    lblc2.BackColor = Color.Red;
                    label14.BackColor = Color.Red;
                }
                if (okuyucu["daireID"].ToString() == "C3")
                {
                    C3.BackColor = Color.Red;
                    lblc3.Text = okuyucu["isim"].ToString();
                    lblc3.BackColor = Color.Red;
                    label15.BackColor = Color.Red;

                }
                
            }

            bgl.baglanti().Close();
        }


    }
}

