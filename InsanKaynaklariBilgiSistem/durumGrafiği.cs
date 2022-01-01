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

namespace InsanKaynaklariBilgiSistem
{
    public partial class durumGrafiği : Form
    {
        public durumGrafiği()
        {
            InitializeComponent();
        }
        sqlBaglantisi baglantim = new sqlBaglantisi();

        

        private void durumGrafiği_Load(object sender, EventArgs e)
        {
            SqlCommand cinsiyet=new SqlCommand("SELECT cinsiyet,COUNT(*) as 'sayi' FROM Kisi GROUP BY cinsiyet", baglantim.baglanti());
            SqlDataReader dr = cinsiyet.ExecuteReader();
            while(dr.Read())
            {

                tablo_cinsiyet.Series["Cinsiyet"].Points.AddPoint(Convert.ToString( dr[0]),int.Parse(dr[1].ToString()));
                
                
            }


            SqlCommand gorevYeri = new SqlCommand("SELECT gorev_Yeri,COUNT(*) as 'sayi' FROM Kisi GROUP BY gorev_Yeri", baglantim.baglanti());
            SqlDataReader gy = gorevYeri.ExecuteReader();
            while (dr.Read())
            {

                tablo_gorevYeri.Series["Görev Yeri"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));

            }







        }

        private void chartControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
