using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AdiguzelTatilKoyu
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source = LAPTOP-5CO28KVP; Initial Catalog = tatilkoyu; Integrated Security = True");
            baglan.Open();
            return baglan;
        }
    }
}
