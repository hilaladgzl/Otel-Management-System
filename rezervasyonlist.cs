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
    public partial class rezervasyonlist : Form
    {
        public rezervasyonlist()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void verilerigoster(string veriler)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *From Rezervasyonlar ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void rezervasyonlist_Load(object sender, EventArgs e)
        {
            verilerigoster("select from Rezervasyonlar");
        }


        private void sil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from Rezervasyonlar where KonukTCKNO=@a1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@a1", txt.Text);
            cmd.ExecuteNonQuery();

            verilerigoster("select from Rezervasyonlar");

            bgl.baglanti().Close();
            MessageBox.Show("Rezervasyon Silinmiştir", "Tatilköyü");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string KonukTCKNO = dataGridView1.Rows[secilialan].Cells[0].Value.ToString();

            txt.Text = KonukTCKNO;
            Txttc.Text= dataGridView1.Rows[secilialan].Cells[0].Value.ToString();
            txtisim.Text= dataGridView1.Rows[secilialan].Cells[1].Value.ToString();
            txtsoyisim.Text= dataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            txtemail.Text= dataGridView1.Rows[secilialan].Cells[3].Value.ToString();
            mskedtel.Text= dataGridView1.Rows[secilialan].Cells[4].Value.ToString();
            cmbx1.Text= dataGridView1.Rows[secilialan].Cells[5].Value.ToString();
            cmbxdaireturu.Text= dataGridView1.Rows[secilialan].Cells[6].Value.ToString();
            cmbdaire.Text= dataGridView1.Rows[secilialan].Cells[7].Value.ToString();
            dateTimePicker1.Text= dataGridView1.Rows[secilialan].Cells[8].Value.ToString();
            dateTimePicker2.Text= dataGridView1.Rows[secilialan].Cells[9].Value.ToString();
            lblucret.Text= dataGridView1.Rows[secilialan].Cells[10].Value.ToString();


        }
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

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            ucrethesapla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            SqlCommand komut = new SqlCommand("update Rezervasyonlar set giristarihi= '"+dateTimePicker1.Value.ToString("yyyy-MM-dd")+"', cikistarihi='"+dateTimePicker2.Value.ToString("yyyy-MM-dd") +"', ucret='"+lblucret.Text+"' where KonukTCKNO="+txt.Text+"",bgl.baglanti());
            komut.ExecuteNonQuery();
            verilerigoster("select from Rezervasyonlar");
            bgl.baglanti().Close();
            MessageBox.Show("Başarıyla Güncellenmiştir", "Tatilköyü");



            //rezervasyon guncellendikten sonra verileri temizle
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
            rezervasyonlist_Load(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            tablo.Clear();
            SqlCommand adap = new SqlCommand("select * from Rezervasyonlar where KonukTCKNO like '%" + txt.Text + "%'", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(adap);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bgl.baglanti().Close();
        }

    }
}
