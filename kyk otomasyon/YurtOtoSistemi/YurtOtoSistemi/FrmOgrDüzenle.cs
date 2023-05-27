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
    public partial class FrmOgrDüzenle : Form
    {
        public FrmOgrDüzenle()
        {
            InitializeComponent();
        }
        public string ad, soyad, tc, telefon, dogum, id, bolum, odano, mail;

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komusil = new SqlCommand("delete from Ogrenci where Ogrid=@k1", bgl.baglanti());
            komusil.Parameters.AddWithValue("@k1", TxtOgrid.Text);
            komusil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Öğrenci Kaydı Silinmiştir.");        }

        SqlBaglantim bgl = new SqlBaglantim();



        private void FrmOgrDüzenle_Load(object sender, EventArgs e)
        {
            TxtOgrid.Text = id;
            TxtOgrAd.Text = ad;
            TxtOgrSoyad.Text = soyad;
            mskTc.Text = tc;
            MskTelefon.Text = telefon;
            mskDogum.Text = dogum;
            cmbOdaNo.Text = odano;
            CmbBolum.Text = bolum;
            TxtMail.Text = mail;
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
            {
                

                SqlCommand komut = new SqlCommand("update Ogrenci set OgrAd=@p1,OgrSoyad=@p2,OgrTc=@p3,OgrTelefon=@p4,OgrDogum=@p5,OgrBolum=@p7,OgrOdaNo=@p8,OgrMail=@p9 where Ogrid=@p6", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtOgrAd.Text);
                komut.Parameters.AddWithValue("@p2", TxtOgrSoyad.Text);
                komut.Parameters.AddWithValue("@p3", mskTc.Text);
                komut.Parameters.AddWithValue("@p4", MskTelefon.Text);
                komut.Parameters.AddWithValue("@p5", mskDogum.Text);
                komut.Parameters.AddWithValue("@p6", TxtOgrid.Text);
                komut.Parameters.AddWithValue("@p7", CmbBolum.Text);
                komut.Parameters.AddWithValue("@p8", cmbOdaNo.Text);
                komut.Parameters.AddWithValue("@p9", TxtMail.Text);

                
                komut.ExecuteNonQuery();

            MessageBox.Show("Kayıt Güncellenmiştir.");

                bgl.baglanti().Close();
         }



        } 
    }

