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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form yoneticigirisi = new yoneticigirisi();
            yoneticigirisi.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form konuk = new konuk();
            konuk.Show();
            this.Hide();
        }
    }
}
