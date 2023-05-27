using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace YurtOtoSistemi
{
    public class SqlBaglantim
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-00FTS1Q\\SQLEXPRESS;Initial Catalog=YurtOtomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
// bölümlerde ve kayıtt bağlantıyı değiştirmedim ders 15