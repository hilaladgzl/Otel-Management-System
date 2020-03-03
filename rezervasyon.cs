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
    public partial class rezervasyon : Form
    {
        public rezervasyon()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        
        sqlbaglantisi bgl = new sqlbaglantisi(); 

        private void rezervasyon_Load(object sender, EventArgs e)
        {
            //databasedeki durum 0 olanları seç 
            SqlCommand komutt = new SqlCommand("Select * from Daire where RezervasyonDurum='False'", bgl.baglanti());
            SqlDataReader okuyucu = komutt.ExecuteReader();
            while (okuyucu.Read())
            {
                cmbdaire.Items.Add(okuyucu["RezervasyonDurum"].ToString());
            }
            bgl.baglanti().Close();








            SqlCommand komut = new SqlCommand("Select daireID From Daire ", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbdaire.Items.Add(dr[0]);
            }

            //daire turlerini comboboxa aktarma
            SqlCommand komut1 = new SqlCommand("Select distinct turAdi From Daire ", bgl.baglanti());
            SqlDataReader drr = komut1.ExecuteReader();
            while (drr.Read())
            {
                cmbxdaireturu.Items.Add(drr[0]);
            }
            bgl.baglanti().Close();
        }


        //Seçilenin durumunu değiştirmek istediğim fonksiyonu yazdım, tekrar seçilmesini engelleyecek burası fonksiyon tablo isimlerini kontrol et ama


        bool durum;

        void secilen()
        {

            SqlCommand deneme = new SqlCommand("select * From Rezervasyonlar Where daireID=@p3", bgl.baglanti());
            deneme.Parameters.AddWithValue("@p3", cmbdaire.SelectedItem.ToString());

            SqlDataReader oku = deneme.ExecuteReader();

            if (oku.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }

            bgl.baglanti().Close();

        }



        private void button1_Click(object sender, EventArgs e)
        {

            //Rezervasyon bilgilerini kaydet
            SqlCommand komut = new SqlCommand("insert into Rezervasyonlar (KonukTCKNO,isim,soyisim,email,telefon,kisiSayisi,daireturu,daireID,giristarihi,cikistarihi,ucret) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Txttc.Text);
            komut.Parameters.AddWithValue("@p2", txtisim.Text);
            komut.Parameters.AddWithValue("@p3", txtsoyisim.Text);
            komut.Parameters.AddWithValue("@p4", txtemail.Text);
            komut.Parameters.AddWithValue("@p5", mskedtel.Text);
            komut.Parameters.AddWithValue("@p6", cmbx1.Text);
            komut.Parameters.AddWithValue("@p7", cmbxdaireturu.Text);
            komut.Parameters.AddWithValue("@p8", cmbdaire.Text);
            komut.Parameters.AddWithValue("@p9", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            komut.Parameters.AddWithValue("@p10", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            komut.Parameters.AddWithValue("@p11", lblucret.Text);
            komut.ExecuteNonQuery();

            //Rezervasyon bilgilerini Konuk tablosuna da kaydet
            SqlCommand komut1 = new SqlCommand("insert into Konuk (KonukTCKNO,daireID,adi,soyadi,KisiSayisi,email,telefon) values(@a1,@a2,@a3,@a4,@a5,@a6,@a7)", bgl.baglanti());
            komut1.Parameters.AddWithValue("@a1", Txttc.Text);
            komut1.Parameters.AddWithValue("@a2", cmbdaire.Text);
            komut1.Parameters.AddWithValue("@a3", txtisim.Text);
            komut1.Parameters.AddWithValue("@a4", txtsoyisim.Text);
            komut1.Parameters.AddWithValue("@a5", cmbx1.Text);
            komut1.Parameters.AddWithValue("@a6", txtemail.Text);
            komut1.Parameters.AddWithValue("@a7", mskedtel.Text);
            komut1.ExecuteNonQuery();



            SqlCommand komut2 = new SqlCommand("update Daire set Daire.RezervasyonDurum='True' where daireID=@d1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@d1", cmbdaire.SelectedIndex.ToString());
            komut2.ExecuteNonQuery();
         

            //SqlCommand deneme = new SqlCommand("Update Daire SET RezervasyonDurum='0'  WHERE daireID = @p2", bgl.baglanti());
            ////bu kargoid ye ait kargotakip noyu çıkartabilirim hepsini yaptıktan sonra
            //deneme.Parameters.AddWithValue("@p2", cmbdaire.SelectedItem.ToString());


            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız Gerçekleşmiştir.");

            //rezervasyon yapıldıktan sonra verileri temizle
            Txttc.Text = "";
            txtisim.Text = "";
            txtsoyisim.Text = "";
            txtemail.Text = "";
            mskedtel.Text = "";
            cmbx1.Text = "";
            cmbxdaireturu.Text = "";
            cmbdaire.Items.Clear();
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            lblucret.Text = "";
            rezervasyon_Load(sender, e);

        }
        //Tablo isimlerinde yanlışlık olabilir. Yapmak istediğim durum diye bir bool tanımladım. ve oda durumlarında aratmak istedim bunu . yani comboboxtan
        //seçeceği odanın durumuna baksın diye. eğer seçiliyse seçili diycek. 



        //daire türüne göre daire numarası seçme
        private void cmbxdaireturu_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdaire.Items.Clear();
            SqlCommand komut = new SqlCommand("Select daireID From Daire where turadi=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbxdaireturu.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbdaire.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();

        }

       
        //ücret hesaplama
        public void ucrethesapla()
        {
            int Ucret;
            DateTime kucukTarih = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime buyukTarih = Convert.ToDateTime(dateTimePicker2.Text);

            TimeSpan sonuc = buyukTarih - kucukTarih;

            label11.Text = sonuc.TotalDays.ToString();
            //daire türüne göre ücret hesaplama
            if (cmbxdaireturu.Text == "1+1")
            {
                Ucret = Convert.ToInt32(label11.Text) * 100;
                lblucret.Text = "Ücret:" + Ucret.ToString();
            }
            if (cmbxdaireturu.Text == "2+1")
            {
                Ucret = Convert.ToInt32(label11.Text) * 120;
                lblucret.Text = "Ücret:" + Ucret.ToString();
            }
            if (cmbxdaireturu.Text == "3+1")
            {
                Ucret = Convert.ToInt32(label11.Text) * 150;
                lblucret.Text = "Ücret:" + Ucret.ToString();
            }
        }

        //çıkış tarihi girildiğinde fiyatı hesaplayack.
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            ucrethesapla();
        }

        
    }
}





