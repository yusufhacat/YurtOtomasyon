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
using System.Data.Sql;

namespace YurtOtoSistemi
{
    public partial class FrmOgrKayit : Form
    {
        public FrmOgrKayit()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-00FTS1Q\\SQLEXPRESS;Initial Catalog=YurtOtomasyon;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            // bölümleri listeler
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select BolumAd From Bolumler", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                CmbBolum.Items.Add(oku[0].ToString());
            }
            baglanti.Close();

            // boş odaları listleerr
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Odano From Odalar", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())

            {
                cmbOdaNo.Items.Add(oku2[0].ToString());
            }
            baglanti.Close();
            
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {


            baglanti.Open();
            SqlCommand komutkaydet = new SqlCommand("insert into Ogrenci(OgrAd,OgrSoyad,OgrTc,OgrTelefon,OgrDogum,OgrMail,OgrOdaNo,OgrBolum) values ( @p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", baglanti);
            komutkaydet.Parameters.AddWithValue("@p1", TxtOgrAd.Text);
            komutkaydet.Parameters.AddWithValue("@p2", TxtOgrSoyad.Text);
            komutkaydet.Parameters.AddWithValue("@p3", mskTc.Text);
            komutkaydet.Parameters.AddWithValue("@p4", MskTelefon.Text);
            komutkaydet.Parameters.AddWithValue("@p5", mskDogum.Text);
            komutkaydet.Parameters.AddWithValue("@p6", TxtMail.Text);
            komutkaydet.Parameters.AddWithValue("@p7", cmbOdaNo.Text);
            komutkaydet.Parameters.AddWithValue("@p8", CmbBolum.Text);
            komutkaydet.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt İşlemi Gerçekleştirildi");
            

        }
    }
}
