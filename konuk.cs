using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdiguzelTatilKoyu
{
    public partial class konuk : Form
    {
        public konuk()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form eglencemerkezi = new EglenceMerkezi();
            eglencemerkezi.Show();
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form kapat = new Form1();
            kapat.Show();
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form musteritemsilcisi = new musteritemsilcisi();
            musteritemsilcisi.Show();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
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
    }
}
