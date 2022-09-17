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
    public partial class cikti : Form
    {
        public cikti()
        {
            InitializeComponent();
        }
        sqlBaglantisi baglantim = new sqlBaglantisi();
        private void ekrani_temizle()
        {
            picb_resim.Image = null;

            mtxt_tc_no.Clear();

            txt_pdks.Text = string.Empty;

            lbl_ad.Text = string.Empty;
            lbl_soyad.Text = string.Empty;
            lbl_uyruk.Text = string.Empty;
            lbl_cinsiyet.Text = string.Empty;
            lbl_medeni_hal.Text = string.Empty;
            lbl_dogum_yeri.Text = string.Empty;
            lbl_ana_adi.Text = string.Empty;
            lbl_baba_adi.Text = string.Empty;
            lbl_meslek_kodu.Text = string.Empty;
            lbl_görevi.Text = string.Empty;
            lbl_gorev_yeri.Text = string.Empty;
            lbl_durum.Text = string.Empty;
            lbl_tel_no.Text = string.Empty;
            lbl_cep_no.Text = string.Empty;
            lbl_email.Text = string.Empty;
            lbl_yakin.Text = string.Empty;
            lbl_yakin_tel.Text = string.Empty;
            lbl_adres.Text = string.Empty;
            lbl_cocuk.Text = "0";
            lbl_maas.Text = string.Empty;
            lbl_destek.Text = string.Empty;
            lbl_ev.Text = string.Empty;
            lbl_kira.Text = string.Empty;
            lbl_isinma.Text = string.Empty;
            lbl_arac.Text = string.Empty;
            lbl_arazi.Text = string.Empty;
            lbl_icra.Text = string.Empty;
            lbl_iban.Text = string.Empty;

            date_isten_cikis.ResetText();
            date_ise_giris.ResetText();
            date_doğum_tarihi.ResetText();
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


                    break;
                }
            }
        }

        private void btn_ara_Click(object sender, EventArgs e)
        {
            bool kayit_arama_durumu = false;//kayıdın olup olmadığını değerlendirecektir.
            if (mtxt_tc_no.Text.Length == 11 || txt_pdks.Text != "")
            {  //tck 11 hane olarak yazıldı ise arama yapılabilecek aksi taktirde arama yapmaya gerek yok zaten.
                SqlCommand selectsorgu = new SqlCommand("kisi_arama", baglantim.baglanti());
                selectsorgu.CommandType = CommandType.StoredProcedure;

                selectsorgu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                selectsorgu.Parameters.AddWithValue("@pdks", txt_pdks.Text);

                SqlDataReader kayitokuma = selectsorgu.ExecuteReader();
                //kayıtokumanın içerisne attığımız değişkenin while döngüsü ile tüm veri tabanında arayalım.
                while (kayitokuma.Read())
                {   //kayıt var ise buradan true dönecek.
                    kayit_arama_durumu = true;

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
                                lbl_ad.Text = kayitokumaiki.GetValue(2).ToString();
                                lbl_soyad.Text = kayitokumaiki.GetValue(3).ToString();
                                lbl_uyruk.Text = kayitokumaiki.GetValue(4).ToString();
                                lbl_cinsiyet.Text = kayitokumaiki.GetValue(5).ToString();
                                lbl_medeni_hal.Text = kayitokumaiki.GetValue(6).ToString();
                                lbl_dogum_yeri.Text = kayitokumaiki.GetValue(8).ToString();
                                lbl_ana_adi.Text = kayitokumaiki.GetValue(10).ToString();
                                lbl_baba_adi.Text = kayitokumaiki.GetValue(11).ToString();
                                lbl_meslek_kodu.Text = kayitokumaiki.GetValue(12).ToString();
                                lbl_görevi.Text = kayitokumaiki.GetValue(13).ToString();
                                lbl_gorev_yeri.Text = kayitokumaiki.GetValue(14).ToString();
                                lbl_durum.Text = kayitokumaiki.GetValue(16).ToString();
                                date_isten_cikis.Text = kayitokumaiki.GetValue(18).ToString();
                                date_ise_giris.Text = kayitokumaiki.GetValue(15).ToString();
                                date_doğum_tarihi.Text = kayitokumaiki.GetValue(7).ToString();
                                                              

                            }

                        }
                    }

                   // label3.Text = kayitokuma.GetValue(2).ToString();//ilgili tck ait değerin veritabanındaki tck getirilecek. veri tabanı 0,1,2,.. diye gider.
                   // label5.Text = kayitokuma.GetValue(3).ToString();
                                      
                    btn_formu_temizle.Enabled = true;

                    break;
                }
                //eğer kayıt okuma durumu gerçekleşmemiş ise kayıt bulunamadı ise
                if (kayit_arama_durumu == false)
                {
                    MessageBox.Show("Kayıt bulunamadı", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                   
                    btn_formu_temizle.Enabled = false;
                }

            }
            else
            {
                //girilen tc no 11karakter değilse
                MessageBox.Show("Lütfen 11 haneli TC NO giriniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ekrani_temizle();
            }
           
        }
    }
}
