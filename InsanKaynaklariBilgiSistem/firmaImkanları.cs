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

namespace InsanKaynaklariBilgiSistem
{
    public partial class firmaImkanları : Form
    {
        public firmaImkanları()
        {
            InitializeComponent();
        }
        sqlBaglantisi baglantim = new sqlBaglantisi();

        private void firmaImkanları_Load(object sender, EventArgs e)
        {
            mtxt_tc_no.Mask = "00000000000";//kullnıcı 11 haneli tc numarası girebilecek.

        }

        private void mtxt_tc_no_TextChanged(object sender, EventArgs e)
        {
            //tc kimlik no giriş kısmı için kısıtlamalar yazılacaktır.
            //yukarıda 11 den fazla giremeyeceğini belirtmştirk. bu ksımda da 11d den az giremeyeceğini belirttik.
            if (mtxt_tc_no.Text.Length < 11)
                dxErrorProvider1.SetError(mtxt_tc_no, "TC KİMLİK NO 11 KARAKTER OLMALIDIR.");
            else
                dxErrorProvider1.ClearErrors();
            if (mtxt_tc_no.Text.Length == 11)
            {
                SqlCommand selectsorgu = new SqlCommand("kisi_arama", baglantim.baglanti());
                selectsorgu.CommandType = CommandType.StoredProcedure;

                selectsorgu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                selectsorgu.Parameters.AddWithValue("@pdks", txt_pdks.Text);

                SqlDataReader kayitokuma = selectsorgu.ExecuteReader();

                //kayıtokumanın içerisne attığımız değişkenin while döngüsü ile tüm veri tabanında arayalım.
                while (kayitokuma.Read())
                {   //kayıt var ise buradan true dönecek.
                    if (mtxt_tc_no.Text != "")
                        txt_pdks.Text = kayitokuma.GetValue(19).ToString();
                    else if (txt_pdks.Text != "")
                        mtxt_tc_no.Text = kayitokuma.GetValue(1).ToString();
                    else if (mtxt_tc_no.Text != "" && txt_pdks.Text != "")
                    {
                        SqlCommand selectsorguiki = new SqlCommand("select *from Kisi where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());
                        SqlDataReader kayitokumaiki = selectsorgu.ExecuteReader();

                        while (kayitokumaiki.Read())
                        {

                            string gelen;
                            gelen = kayitokumaiki.GetValue(19).ToString();
                            if (gelen != txt_pdks.Text)
                            {
                                txt_pdks.Text = kayitokumaiki.GetValue(19).ToString();
                            }

                        }
                    }


                    label3.Text = kayitokuma.GetValue(2).ToString();//ilgili tck ait değerin veritabanındaki tck getirilecek. veri tabanı 0,1,2,.. diye gider.
                    label5.Text = kayitokuma.GetValue(3).ToString();//ad




                    break;
                }

                SqlCommand selectsorgu2 = new SqlCommand("select *from Kisi_iletisim_Bilgileri where tc_bilgisi='" + mtxt_tc_no.Text + "'", baglantim.baglanti());
                SqlDataReader kayitokuma2 = selectsorgu2.ExecuteReader();

                while (kayitokuma2.Read())
                {
                    txt_adres.Text = kayitokuma2.GetValue(14).ToString();

                    break;
                }

                SqlCommand selectsorgu5 = new SqlCommand("select *from Kisi_maddi_durum_Bilgileri where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());
                SqlDataReader kayitokuma5 = selectsorgu5.ExecuteReader();

                while (kayitokuma5.Read())
                {
                    
                    if (kayitokuma5.GetValue(3).ToString() == "Yol")
                    {
                        txt_destek_yol.Visible = true;
                        label7.Visible = true;
                        txt_destek_yol.Text = kayitokuma5.GetValue(4).ToString();
                    }
                    else
                    {
                        txt_destek_yol.Visible = false;
                        label7.Visible = false;
                    }

                    if (kayitokuma5.GetValue(3).ToString() == "Gıda")
                    {
                        txt_destek_gıda.Visible = true;
                        label7.Visible = true;
                        txt_destek_yol.Text = kayitokuma5.GetValue(4).ToString();
                    }
                    else
                    {
                        txt_destek_gıda.Visible = false;
                        label7.Visible = false;
                    }


                    break;
                }







            }
        }
    }
}
