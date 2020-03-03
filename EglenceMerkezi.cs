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
    public partial class EglenceMerkezi : Form
    {
        public EglenceMerkezi()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void verilerigoster(string veriler)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select  Gunler, saat, ucret From Gun join havuzSeanslari On Gun.gunID=havuzSeanslari.gunID    ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            DataTable dtt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter("Select  Gunler, saat, ucret From Gun join sporSeanslari On Gun.gunID=sporSeanslari.gunID   ", bgl.baglanti());
            ds.Fill(dtt);
            dataGridView2.DataSource = dtt;
        }

        private void EglenceMerkezi_Load(object sender, EventArgs e)
        {
            verilerigoster("Select *From  havuzSeanslari");
            verilerigoster("Select *from sporSeanslari");

           

        }
    }
}
