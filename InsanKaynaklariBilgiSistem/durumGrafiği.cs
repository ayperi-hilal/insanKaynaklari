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
            SqlCommand komut=new SqlCommand("SELECT cinsiyet,COUNT(*) as 'sayi' FROM Kisi GROUP BY cinsiyet", baglantim.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {

                tablo_cinsiyet.Series["Cinsiyet"].Points.AddPoint(Convert.ToString( dr[0]),int.Parse(dr[1].ToString()));
                
            }
        }
    }
}
