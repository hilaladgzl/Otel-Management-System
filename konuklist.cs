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
    public partial class konuklist : Form
    {
        public konuklist()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void verilerigoster(string veriler)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *From Konuk ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void konuklist_Load(object sender, EventArgs e)
        {
            verilerigoster("select *from Konuk");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string KonukTCKNO = dataGridView1.Rows[secilialan].Cells[0].Value.ToString();

            textBox1.Text = KonukTCKNO;

        }

        private void sil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from Konuk where KonukTCKNO=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.ExecuteNonQuery();

            verilerigoster("select *from Konuk");

            bgl.baglanti().Close();



        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
