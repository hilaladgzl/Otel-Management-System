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
    public partial class esyalar : Form
    {
        public esyalar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void verilerigoster(string veriler)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select daireID Blok, esyaAdi,  odaismi, adet From Esyalar ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void esyalar_Load(object sender, EventArgs e)
        {
            verilerigoster("select* from Esyalar");
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
