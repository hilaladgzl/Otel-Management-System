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
    public partial class musteritemsilcisi : Form
    {
        public musteritemsilcisi()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void verilerigoster(string veriler)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Tadi, Tsoyadi, numara From MusteriTemsilcisi ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void musteritemsilcisi_Load(object sender, EventArgs e)
        {
            verilerigoster("select *from MusteriTemsilcisi");
        }
    }
}
