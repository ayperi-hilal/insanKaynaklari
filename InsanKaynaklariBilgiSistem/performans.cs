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
using System.Windows.Forms.DataVisualization.Charting;

namespace InsanKaynaklariBilgiSistem
{
    public partial class performans : Form
    {
        public performans()
        {
            InitializeComponent();
        }

        sqlBaglantisi baglantim = new sqlBaglantisi();

        private void performans_Load(object sender, EventArgs e)
        {
            //listeletumu();
            txt_harf_tecrübe.Enabled = false;

            DateTime zaman = DateTime.Now;
            int yil = int.Parse(zaman.ToString("yyyy"));
            int ay = int.Parse(zaman.ToString("MM"));
            int gun = int.Parse(zaman.ToString("dd"));

            for (int i = 2020; i <= yil; i++)
            {
                cb_yil_tecrübe.Items.Add(i);
                cb_yil_sec.Items.Add(i);
                cb_yil_il.Items.Add(i);
            }

            mtxt_tc_no.Mask = "00000000000";//kullnıcı 11 haneli tc numarası girebilecek.

            for (int i = 1; i <= 12; i++)
            {
                cb_donem_tecrübe.Items.Add(i);
            }

            cb_yil_sec.Text = "";
            cb_yil_tecrübe.Text = "";
            cb_donem_tecrübe.Text = "";
            cb_yil_il.Text = "";


        }
        DataTable dtpi = new DataTable();
        public void listeletumu()
        {
            SqlCommand selectsorgui = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + "31801721856" + "'", baglantim.baglanti());
            //selectsorgui.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dai = new SqlDataAdapter(selectsorgui);
            selectsorgui.Parameters.AddWithValue("@kisi_tc", "31801721856");

            //selectsorgui.Parameters.AddWithValue("@yil", cb_yil_sec.Text);


            dai.Fill(dtpi);
            gridControl2.DataSource = dtpi;
            //dataGridView1.DataSource = dtp;

        }
        private void txt_ilk_TextChanged(object sender, EventArgs e)
        {
            if (txt_ilk.Text.Length > 0)
            {

                int sayi1 = Convert.ToInt32(txt_ilk.Text);
                if (0 <= sayi1 && sayi1 < 13)
                {
                    lbl_harf_ilk.Text = "E";
                    lbl_ilk_aciklama.Text = "BAŞARISIZ";
                }
                else if (13 <= sayi1 && sayi1 < 22)
                {
                    lbl_harf_ilk.Text = "D";
                    lbl_ilk_aciklama.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                }
                else if (22 <= sayi1 && sayi1 < 29)
                {
                    lbl_harf_ilk.Text = "C";
                    lbl_ilk_aciklama.Text = "NORMAL";
                }
                else if (29 <= sayi1 && sayi1 < 33)
                {
                    lbl_harf_ilk.Text = "B";
                    lbl_ilk_aciklama.Text = "İYİ";
                }

                else if (33 <= sayi1 && sayi1 <= 35)
                {
                    lbl_harf_ilk.Text = "A";
                    lbl_ilk_aciklama.Text = "ÇOK İYİ";
                }
                else if (sayi1 < 0 || sayi1 > 35)
                {
                    lbl_harf_ilk.Text = "";
                    lbl_ilk_aciklama.Text = "";
                    txt_ilk.ForeColor = Color.Red;

                }
            }
            else
            {
                lbl_harf_ilk.Text = "";
                lbl_ilk_aciklama.Text = "";
            }

        }

        private void txt_sayi_tecrübe_TextChanged(object sender, EventArgs e)
        {
            if (txt_sayi_tecrübe.Text.Length > 0)
            {


                int sayi1 = Convert.ToInt32(txt_sayi_tecrübe.Text);
                if (0 <= sayi1 && sayi1 < 36)
                {
                    txt_harf_tecrübe.Text = "E";
                    lbl_aciklama_tecrübe.Text = "BAŞARISIZ";
                }
                else if (36 <= sayi1 && sayi1 < 60)
                {
                    txt_harf_tecrübe.Text = "D";
                    lbl_aciklama_tecrübe.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                }
                else if (60 <= sayi1 && sayi1 < 80)
                {
                    txt_harf_tecrübe.Text = "C";
                    lbl_aciklama_tecrübe.Text = "NORMAL";
                }
                else if (80 <= sayi1 && sayi1 < 90)
                {
                    txt_harf_tecrübe.Text = "B";
                    lbl_aciklama_tecrübe.Text = "İYİ";
                }

                else if (90 <= sayi1 && sayi1 <= 100)
                {
                    txt_harf_tecrübe.Text = "A";
                    lbl_aciklama_tecrübe.Text = "ÇOK İYİ";
                }
                else if (sayi1 < 0 || sayi1 > 100)
                {
                    txt_harf_tecrübe.Text = "";
                    lbl_aciklama_tecrübe.Text = "";
                    txt_sayi_tecrübe.ForeColor = Color.Red;
                    lbl_puan.ForeColor = Color.Red;


                }

            }
            else
            {
                txt_harf_tecrübe.Text = "";
                txt_sayi_tecrübe.Text = "";

            }
        }

        private void txt_sayi_tecrübe_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txt_sayi_tecrübe.Text) < 0 || Convert.ToInt32(txt_sayi_tecrübe.Text) > 101)
                {
                    MessageBox.Show("Değer 0-100 arasında olmalı");
                    txt_sayi_tecrübe.Text = "";
                    txt_sayi_tecrübe.Focus();
                }

            }
            catch
            {
                MessageBox.Show("Sayısal bir değer girin");
                txt_sayi_tecrübe.Text = "";


            }
        }

        private void ekrani_temizle()
        {
            mtxt_tc_no.Clear();
            txt_pdks.Text = string.Empty;

            label3.Text = "...";
            label5.Text = "...";
            lbl_gorevyeri.Text = "...";
            lbl_gorevii.Text = "...";
            lbl_ortalama.Text = "...";
            lbl_aciklama_tecrübe.Text = "...";
            lbl_harf_ilk.Text = "...";
            lbl_ilk_aciklama.Text = "...";

            cb_yil_sec.Text = "";
            cb_yil_tecrübe.Text = "";
            cb_yil_il.Text = "";
            cb_donem_tecrübe.Text = "";

            txt_sayi_tecrübe.Text = string.Empty;
            txt_harf_tecrübe.Text = string.Empty;
            txt_id_ilk.Text = string.Empty;
            txt_ilk.Text = string.Empty;

            //  chartControl3.Series.Clear();

            // this.chartControl3.Series.BeginUpdate();



            //   gridView1.Columns.Clear();
            grid_temizle();
            chart_temizle();

        }
        private void grid_temizle()
        {
            /* for (int i = 1; i <= gridView1.RowCount; i++)
             {
                 gridView1.SelectAll();
                 gridView1.DeleteSelectedRows();
             }*/
            //while (gridView1.RowCount != 0)
            //{
            //    gridView1.SelectAll();
            //    gridView1.DeleteSelectedRows();
            //}
            //dataGridView1.DataSource = null;
        }

        private void chart_temizle()
        {

            //foreach (var series in chart1.Series)
            //{
            //    series.Points.Clear();
            //}
            //i = 0;
            //chartControl3.Series.Clear();
            //chartControl3.Series[i].Clear();

            //foreach (var series in chartControl3.Series)
            //{
            //    chartControl3.Series.Clear();
            //    //series. Points.Clear();
            //}
        }

        bool kayit_arama_durumu = false;

        string yeni = "YENİ PERSONEL";

        private void btn_ara_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11 || txt_pdks.Text != "")
            {
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
                            }

                        }
                    }

                    label3.Text = kayitokuma.GetValue(2).ToString();//ilgili tck ait değerin veritabanındaki tck getirilecek. veri tabanı 0,1,2,.. diye gider.
                    label5.Text = kayitokuma.GetValue(3).ToString();
                    lbl_gorevyeri.Text = kayitokuma.GetValue(14).ToString();
                    lbl_gorevii.Text = kayitokuma.GetValue(13).ToString();

                    btn_sil.Enabled = true;
                    btn_guncelle.Enabled = true;
                    btn_ekle.Enabled = true;
                    btn_listele.Enabled = true;

                    //listele();
                    break;
                }
                //eğer kayıt okuma durumu gerçekleşmemiş ise kayıt bulunamadı ise
                if (kayit_arama_durumu == false)
                {
                    MessageBox.Show("Kayıt bulunamadı", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btn_sil.Enabled = false;
                    btn_guncelle.Enabled = false;
                    btn_ekle.Enabled = false;
                    btn_listele.Enabled = false;
                }


                SqlCommand selectsorgu2 = new SqlCommand("select *from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'and calismaGrubu='" + yeni + "'", baglantim.baglanti());

                SqlDataReader kayitokuma2 = selectsorgu2.ExecuteReader();
                while (kayitokuma2.Read())
                {
                    txt_ilk.Text = kayitokuma2.GetValue(3).ToString();
                    lbl_harf_ilk.Text = kayitokuma2.GetValue(4).ToString();
                    lbl_ilk_aciklama.Text = kayitokuma2.GetValue(6).ToString();
                    txt_id_ilk.Text = kayitokuma2.GetValue(0).ToString();
                    cb_yil_il.Text = kayitokuma2.GetValue(5).ToString();
                }

            }
            else
            {
                //girilen tc no 11karakter değilse
                MessageBox.Show("Lütfen 11 haneli TC NO giriniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ekrani_temizle();
            }
        }

        private void txt_ilk_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_sayi_tecrübe_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void mtxt_tc_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void mtxt_tc_no_TextChanged(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length < 11)
                dxErrorProvider1.SetError(mtxt_tc_no, "TC KİMLİK NO 11 KARAKTER OLMALIDIR.");
            else
                dxErrorProvider1.ClearErrors();
        }

        private void btn_formu_temizle_Click(object sender, EventArgs e)
        {
            ekrani_temizle();
        }

        //string gelenyil,gelendonem;

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            //SqlCommand selectsorgu_varmı_yokmu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());


            //SqlDataReader kayitokumawww = selectsorguwww.ExecuteReader();//okuduğu sorguları tutuyoruz.

            SqlCommand selectsorguwww = new SqlCommand("select * from Kisi where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());


            SqlDataReader kayitokumawww = selectsorguwww.ExecuteReader();//okuduğu sorguları tutuyoruz.


            while (kayitokumawww.Read())
            //    if (kayit_arama_durumu == true)
            {
                kayit_arama_durumu = true;
                btn_ekle.Enabled = true;
                btn_guncelle.Enabled = true;
                btn_sil.Enabled = true;
                btn_listele.Enabled = true;
                //önce hangi bölümün kaydedileceğini tespit edelim
                //işe giriş mi tecrübe mi?


                if (txt_sayi_tecrübe.Text != "")
                {
                    //girilen yıla ve döneme ait veri var mı kontrol edilmelidir.
                    /*
                       string gelen;
                            gelen = kayitokumaiki.GetValue(19).ToString();
                            if (gelen != txt_pdks.Text)
                            {
                                txt_pdks.Text = kayitokumaiki.GetValue(19).ToString();
                            }
                     */
                    string gelenyil, gelendonem;

                    gelenyil = kayitokumawww.GetValue(5).ToString();

                    // MessageBox.Show(gelenyil);

                    gelendonem = kayitokumawww.GetValue(2).ToString();


                    if (cb_yil_tecrübe.Text == "Seçiniz" || cb_donem_tecrübe.Text == "Seçiniz" || txt_sayi_tecrübe.Text == "")
                    {
                        lbl_donem.ForeColor = Color.Red;
                        lbl_yıl.ForeColor = Color.Red;
                        lbl_puan.ForeColor = Color.Red;
                        lbl_aciklama.ForeColor = Color.Red;
                        lbl_not.ForeColor = Color.Red;

                    }
                    else
                    {
                        lbl_donem.ForeColor = Color.Black;
                        lbl_yıl.ForeColor = Color.Black;
                        lbl_puan.ForeColor = Color.Black;
                        lbl_aciklama.ForeColor = Color.Black;
                        lbl_not.ForeColor = Color.Black;
                    }

                }

                SqlCommand selectsorgu_varmı_yokmu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'and persormansDonemi='" + cb_donem_tecrübe.Text + "'and yil='" + cb_yil_tecrübe.Text + "'", baglantim.baglanti());

                //_tc='" + mtxt_tc_no.Text + "'and calismaGrubu='" + yeni + "'",
                SqlDataReader kayitokuma_varmı_yokmu = selectsorgu_varmı_yokmu.ExecuteReader();


                bool var = false, var2 = false;
                while (kayitokuma_varmı_yokmu.Read())
                {
                    var = true;
                    /* MessageBox.Show(kayitokuma_varmı_yokmu.GetValue(0).ToString() + "\n" +
                         kayitokuma_varmı_yokmu.GetValue(1).ToString() + "\n" +
                         kayitokuma_varmı_yokmu.GetValue(2).ToString() + "\n" +
                         kayitokuma_varmı_yokmu.GetValue(3).ToString() + "\n" +
                         kayitokuma_varmı_yokmu.GetValue(4).ToString() + "\n" +
                         kayitokuma_varmı_yokmu.GetValue(5).ToString() + "\n" +
                         kayitokuma_varmı_yokmu.GetValue(6).ToString() + "\n" +
                         kayitokuma_varmı_yokmu.GetValue(7).ToString() + "\n" );*/
                    //Birden çok kayıt okuyor anlamadımm
                    break;
                }
                //label9= cbdönemtecrübe  label7 = cbyıltecrübbe
                SqlCommand selectsorgu_varmı_yokmu2 = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'and persormansDonemi=0 and yil='" + cb_yil_il.Text + "'", baglantim.baglanti());
                SqlDataReader kayitokuma_varmı_yokmu2 = selectsorgu_varmı_yokmu2.ExecuteReader();
                while (kayitokuma_varmı_yokmu2.Read())
                {
                    var2 = true;
                    /* MessageBox.Show(kayitokuma_varmı_yokmu.GetValue(0).ToString() + "\n" +
                         kayitokuma_varmı_yokmu.GetValue(1).ToString() + "\n" +
                         kayitokuma_varmı_yokmu.GetValue(2).ToString() + "\n" +
                         kayitokuma_varmı_yokmu.GetValue(3).ToString() + "\n" +
                         kayitokuma_varmı_yokmu.GetValue(4).ToString() + "\n" +
                         kayitokuma_varmı_yokmu.GetValue(5).ToString() + "\n" +
                         kayitokuma_varmı_yokmu.GetValue(6).ToString() + "\n" +
                         kayitokuma_varmı_yokmu.GetValue(7).ToString() + "\n" );*/
                    //Birden çok kayıt okuyor anlamadımm
                    break;
                }



                bool ekletecrube = false;
                bool ekleilk = false;






                //  if (label9.Text == kayitokumawww.GetValue(2).ToString() && label7.Text == kayitokumawww.GetValue(5).ToString())
                if (var == true)
                {
                    MessageBox.Show("Dönem ve Yıla ait veri vardır.Lütfen kontrol ediniz");
                    //cb_donem_tecrübe.Text = "Seçiniz";
                    //cb_yil_tecrübe.Text= "Seçiniz";
                    //txt_sayi_tecrübe.Text = "";
                    //txt_harf_tecrübe.Text = "";
                    //lbl_aciklama_tecrübe.Text = "...";
                    //label7.Text = "";
                    //label9.Text="";



                }
                if (var2 == true)
                {
                    MessageBox.Show("Personele ait ilk değerlendirme zaten mevcuttur.Tekrar kayıt ekleyemezsiniz.Lütfen kontrol ediniz");
                    //cb_donem_tecrübe.Text = "Seçiniz";
                    //cb_yil_tecrübe.Text= "Seçiniz";
                    //txt_sayi_tecrübe.Text = "";
                    //txt_harf_tecrübe.Text = "";
                    //lbl_aciklama_tecrübe.Text = "...";
                    //label7.Text = "";
                    //label9.Text="";



                }

                if (var == false)
                {


                    //bool ekletecrube = false;
                    //bool ekleilk = false;

                    if (txt_sayi_tecrübe.Text != "" && cb_yil_tecrübe.Text != "Seçiniz" && cb_donem_tecrübe.Text != "Seçiniz")
                    {
                        ekletecrube = true;
                        btn_ekle.Enabled = true;
                        try
                        {
                            SqlCommand eklekomutu = new SqlCommand("Kaydet_KisiYillikPerformans", baglantim.baglanti());
                            eklekomutu.CommandType = CommandType.StoredProcedure;

                            eklekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                            eklekomutu.Parameters.AddWithValue("@persormansDonemi", cb_donem_tecrübe.Text);
                            eklekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi_tecrübe.Text);
                            eklekomutu.Parameters.AddWithValue("@harfNotu", txt_harf_tecrübe.Text);
                            eklekomutu.Parameters.AddWithValue("@yil", cb_yil_tecrübe.Text);
                            eklekomutu.Parameters.AddWithValue("@aciklama", lbl_aciklama_tecrübe.Text);
                            eklekomutu.Parameters.AddWithValue("@calismaGrubu", "TECRÜBELİ PERSONEL");

                            eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        }
                        catch (Exception hatamjs)
                        {
                            //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                            MessageBox.Show(hatamjs.Message);


                        }
                    }

                    /*  if (txt_ilk.Text != "")
                      {
                          ekleilk = true;
                          btn_ekle.Enabled = true;
                          try
                          {
                              SqlCommand eklekomutu = new SqlCommand("Kaydet_KisiYillikPerformans", baglantim.baglanti());
                              eklekomutu.CommandType = CommandType.StoredProcedure;

                              eklekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                              eklekomutu.Parameters.AddWithValue("@persormansDonemi", "0");
                              eklekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_ilk.Text);
                              eklekomutu.Parameters.AddWithValue("@harfNotu", lbl_harf_ilk.Text);
                              eklekomutu.Parameters.AddWithValue("@yil", cb_yil_il.Text);
                              eklekomutu.Parameters.AddWithValue("@aciklama", lbl_ilk_aciklama.Text);
                              eklekomutu.Parameters.AddWithValue("@calismaGrubu", "YENİ PERSONEL");

                              eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                          }
                          catch (Exception hatamjs)
                          {
                              //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                              MessageBox.Show(hatamjs.Message);


                          }






                      if (ekleilk == true || ekletecrube == true)
                      {
                          MessageBox.Show("Personelin değerlendirmesi kaydedilmiştir.");
                      } }*/
                }
                if (var2 == false)
                {


                    //bool ekletecrube = false;
                    //bool ekleilk = false;

                    /*   if (txt_sayi_tecrübe.Text != "" && cb_yil_tecrübe.Text != "Seçiniz" && cb_donem_tecrübe.Text != "Seçiniz")
                       {
                           ekletecrube = true;
                           btn_ekle.Enabled = true;
                           try
                           {
                               SqlCommand eklekomutu = new SqlCommand("Kaydet_KisiYillikPerformans", baglantim.baglanti());
                               eklekomutu.CommandType = CommandType.StoredProcedure;

                               eklekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                               eklekomutu.Parameters.AddWithValue("@persormansDonemi", cb_donem_tecrübe.Text);
                               eklekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi_tecrübe.Text);
                               eklekomutu.Parameters.AddWithValue("@harfNotu", txt_harf_tecrübe.Text);
                               eklekomutu.Parameters.AddWithValue("@yil", cb_yil_tecrübe.Text);
                               eklekomutu.Parameters.AddWithValue("@aciklama", lbl_aciklama_tecrübe.Text);
                               eklekomutu.Parameters.AddWithValue("@calismaGrubu", "TECRÜBELİ PERSONEL");

                               eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                           }
                           catch (Exception hatamjs)
                           {
                               //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                               MessageBox.Show(hatamjs.Message);


                           }
                       }
                    */
                    if (txt_ilk.Text != "")
                    {
                        ekleilk = true;
                        btn_ekle.Enabled = true;
                        try
                        {
                            SqlCommand eklekomutu = new SqlCommand("Kaydet_KisiYillikPerformans", baglantim.baglanti());
                            eklekomutu.CommandType = CommandType.StoredProcedure;

                            eklekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                            eklekomutu.Parameters.AddWithValue("@persormansDonemi", "0");
                            eklekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_ilk.Text);
                            eklekomutu.Parameters.AddWithValue("@harfNotu", lbl_harf_ilk.Text);
                            eklekomutu.Parameters.AddWithValue("@yil", cb_yil_il.Text);
                            eklekomutu.Parameters.AddWithValue("@aciklama", lbl_ilk_aciklama.Text);
                            eklekomutu.Parameters.AddWithValue("@calismaGrubu", "YENİ PERSONEL");

                            eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        }
                        catch (Exception hatamjs)
                        {
                            //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                            MessageBox.Show(hatamjs.Message);


                        }





                    }
                    /*   if (ekleilk == true || ekletecrube == true)
                       {
                           MessageBox.Show("Personelin değerlendirmesi kaydedilmiştir.");
                       }*/
                }
                if (ekleilk == true || ekletecrube == true)
                {
                    MessageBox.Show("Personelin değerlendirmesi kaydedilmiştir.");
                }
                break;
            }

            if (kayit_arama_durumu == false)
            {
                MessageBox.Show("Personel kaydı bulunamadığı için işlem yapamazsınız.");
                //else
                //{
                btn_ekle.Enabled = false;
                btn_guncelle.Enabled = false;
                btn_sil.Enabled = false;
                btn_listele.Enabled = false;

                //}
            }


        }

        public void listele()
        {
            SqlCommand den = new SqlCommand("performanss", baglantim.baglanti());
            den.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter eme = new SqlDataAdapter(den);
            den.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
            den.Parameters.AddWithValue("@yil", cb_yil_sec.Text);
            DataTable xaw = new DataTable();
            eme.Fill(xaw);
            gridControl1.DataSource = xaw;
            gridView1.Columns["id"].Visible = false;


            gridView1.Columns["Kisi_tc"].Caption = "TC NO";
            gridView1.Columns["calismaGrubu"].Caption = "ÇALIŞAN GRUBU";
            gridView1.Columns["yil"].Caption = "YIL";
            gridView1.Columns["persormansDonemi"].Caption = "DÖNEM";
            gridView1.Columns["sayisalKarsilik"].Caption = "SAYI";
            gridView1.Columns["harfNotu"].Caption = "HARF NOTU";
            gridView1.Columns["aciklama"].Caption = "AÇIKLAMA";
            

            SqlCommand selectsorgu2 = new SqlCommand("ORTALAMA", baglantim.baglanti());
            selectsorgu2.CommandType = CommandType.StoredProcedure;

            selectsorgu2.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
            selectsorgu2.Parameters.AddWithValue("@yil", cb_yil_sec.Text);

            SqlDataReader kayitokuma2 = selectsorgu2.ExecuteReader();

            while (kayitokuma2.Read())

            {
                // MessageBox.Show(kayitokuma2.GetValue(0).ToString() + "---" + kayitokuma2.GetValue(1).ToString());
                if (kayitokuma2.GetValue(0).ToString() == mtxt_tc_no.Text)
                {
                    lbl_ortalama.Text = kayitokuma2.GetValue(1).ToString();
                }
                else
                {
                    lbl_ortalama.Text = "";
                    //  MessageBox.Show("ORTALAMA GETİRİLEMEDİ");
                }

                break;
            }





        }

        //DataTable dtp = new DataTable();

        //public void listele()
        //{
        //    //dataGridView1.Rows.Clear();

        //    // gridControl1.DataSource = null;
        //    //gridView1.Columns.Clear();

        //    SqlCommand sorgu = new SqlCommand("tum_kisiYillikPerformans", baglantim.baglanti());
        //    sorgu.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter da = new SqlDataAdapter(sorgu);
        //    sorgu.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);

        //    sorgu.Parameters.AddWithValue("@yil", cb_yil_sec.Text);
        //    DataTable dtp = new DataTable();

        //    //DataTable dt = new DataTable();
        //    da.Fill(dtp);
        //    gridControl1.DataSource = dtp;
        //    dataGridView1.DataSource = dtp;
        //    chart1.DataSource = dtp;

        //    // gridView1.Columns["ID"].Visible = false;
        //    //gridView1.Columns["pdks"].Visible = false;


        //    SqlCommand selectsorgu2 = new SqlCommand("ORTALAMA", baglantim.baglanti());
        //    selectsorgu2.CommandType = CommandType.StoredProcedure;

        //    selectsorgu2.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
        //    selectsorgu2.Parameters.AddWithValue("@yil", cb_yil_sec.Text);

        //    SqlDataReader kayitokuma2 = selectsorgu2.ExecuteReader();

        //    while (kayitokuma2.Read())

        //    {
        //        // MessageBox.Show(kayitokuma2.GetValue(0).ToString() + "---" + kayitokuma2.GetValue(1).ToString());
        //        if (kayitokuma2.GetValue(0).ToString() == mtxt_tc_no.Text)
        //        {
        //            lbl_ortalama.Text = kayitokuma2.GetValue(1).ToString();
        //        }
        //        else
        //        {
        //            lbl_ortalama.Text = "";
        //            //  MessageBox.Show("ORTALAMA GETİRİLEMEDİ");
        //        }

        //        break;
        //    }


        //}

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("calismaGrubu").ToString() == yeni)
            {

                lbl_ilk_aciklama.Text = gridView1.GetFocusedRowCellValue("aciklama").ToString();
                txt_ilk.Text = gridView1.GetFocusedRowCellValue("sayisalKarsilik").ToString();
                txt_id_ilk.Text = gridView1.GetFocusedRowCellValue("id").ToString();
                lbl_harf_ilk.Text = gridView1.GetFocusedRowCellValue("harfNotu").ToString();
            }
            if (gridView1.GetFocusedRowCellValue("calismaGrubu").ToString() != yeni)
            {
                cb_donem_tecrübe.Text = gridView1.GetFocusedRowCellValue("persormansDonemi").ToString();
                txt_sayi_tecrübe.Text = gridView1.GetFocusedRowCellValue("sayisalKarsilik").ToString();
                txt_harf_tecrübe.Text = gridView1.GetFocusedRowCellValue("harfNotu").ToString();
                lbl_aciklama_tecrübe.Text = gridView1.GetFocusedRowCellValue("aciklama").ToString();
                txt_id_tecrübe.Text = gridView1.GetFocusedRowCellValue("id").ToString();
                cb_yil_tecrübe.Text = gridView1.GetFocusedRowCellValue("yil").ToString();
            }
        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            if (cb_yil_sec.Text != "" && cb_yil_sec.Text != "Seçiniz")
            {
                temizle_grafikleri();
                //gridView1.Columns.Clear();
                chart_temizle();
                grid_temizle();
                if (mtxt_tc_no.Text == "")
                {
                    MessageBox.Show("Lütfen önce arama işlemi yapınız.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    lbl_aciklama_tecrübe.Text = "...";
                    lbl_harf_ilk.Text = "...";
                    lbl_ilk_aciklama.Text = "...";



                    txt_sayi_tecrübe.Text = string.Empty;
                    txt_harf_tecrübe.Text = string.Empty;
                    txt_id_ilk.Text = string.Empty;
                    txt_ilk.Text = string.Empty;
                    cb_yil_il.Text = "";
                    //this.chartControl3.Series.BeginUpdate();

                    //chartControl1.DataSource = null;
                    //chartControl1.Series.Clear();


                    if (cb_yil_sec.Text == "")
                    {
                        MessageBox.Show("Sol taraftan yıl bilgisini seçiniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (mtxt_tc_no.Text != "" && txt_pdks.Text != "" && label3.Text != "" && label5.Text != "")
                    {
                        listele();
                        //try
                        //{
                        DataTable drrr = (DataTable)gridControl1.DataSource;

                        for (int i = 0; i < drrr.Rows.Count; i++)
                        {
                            //    //Series sutunlar = this.chart1.Series.Add(dtp.Rows[i].ItemArray.ToString());
                            //    //sutunlar.Points.Add(dtp.Columns[i].DataType.Name);
                            //    //this.chartControl1.Series["Series 2"].Points.AddPoint(dtp.Rows[i][7].ToString(), Convert.ToInt32(dtp.Rows[i][5]));
                            //    //this.chartControl1.DataSource = dtp;
                            //    //MessageBox.Show("Test2", dtp.Rows[i][8].ToString());//3//dönem
                            //    //MessageBox.Show("Test", dtp.Rows[i][6].ToString());//25//puan

                            //    //label7.Text = dtp.Rows[i][8].ToString();//dönem
                            //    //label9.Text = dtp.Rows[i][6].ToString();//sayı

                            //    //this.chartControl1.Series["Series 1"].Points.AddPoint(dtp.Rows[i][5].ToString(), Convert.ToInt32(dtp.Rows[i][6]));

                            //    //this.chartControl1.Series["Series 1"].Points.AddPoint(dtp.Rows[i][7].ToString(), Convert.ToInt32(dtp.Rows[i][5].ToString()));

                            //    //chartControl2.Series["Series 1"].Points.AddPoint(dtp.Rows[i][6].ToString(),Convert.ToDouble(dtp.Rows[i][8]));

                            //    //this.chartControl1.Series["Series 3"].Points.AddPoint(dtp.Rows[i][6].ToString(), Convert.ToInt32(dtp.Rows[i][0]));

                            //this.chartControl3.DataSource = gridControl1.DataSource;

                            //DataTable drrr = (DataTable)gridControl1.DataSource;
                            //gridControl1.DataSource.

                            this.chartControl3.Series["Series 1"].Points.AddPoint(drrr.Rows[i][2].ToString(), Convert.ToInt32(drrr.Rows[i][3]));

                            //    /* chart1.Series.Clear();
                            //   for (int s = 0; s < dataGridView1.Rows.Count-1; s++)
                            //    {
                            //        Series A = chart1.Series.Add(dataGridView1[0, s].Value.ToString());
                            //        A.ChartType = SeriesChartType.Column;
                            //        A.Color = Color.Black;
                            //    }
                            //    for (int t = 0; t < dataGridView1.Rows.Count; t++)
                            //    {
                            //        for (int h = 1; h < dataGridView1.Rows.Count; h++)
                            //        {
                            //            int p = chart1.Series[i].Points.AddXY(dataGridView1.Columns[h].HeaderText, dataGridView1[h, t].Value);
                            //        }
                            //    }
                            //    */
                            //    foreach (var series in chart1.Series)
                            //    {
                            //        series.Points.Clear();
                            //    }

                            //    //add series

                            chart1.Series["Series1"].Points.AddXY(drrr.Rows[i][2].ToString(), Convert.ToInt32(drrr.Rows[i][3]));


                        }

                        //}
                        //catch (Exception ex)
                        //{
                        //    MessageBox.Show("Hata:",ex.Message);
                        //    //throw;
                        //}
                    }
                    else
                    {
                        MessageBox.Show("Birşeyler ters  gitti.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Önce Listelemek İstediğiniz Yılı Seçiniz");
            }

        }
        bool guncellemetecrube;
        bool guncelleilk;
        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            if (txt_id_ilk.Text != "" || txt_id_tecrübe.Text != "")
            {
                SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

                SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

                //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

                guncelleilk = false;
                guncellemetecrube = false;
                while (kayitokuma.Read())
                {

                    btn_ekle.Enabled = true;
                    btn_guncelle.Enabled = true;
                    btn_sil.Enabled = true;
                    btn_listele.Enabled = true;
                    //önce hangi bölümün kaydedileceğini tespit edelim
                    //işe giriş mi tecrübe mi?

                    if (txt_sayi_tecrübe.Text != "")
                    {
                        if (cb_yil_tecrübe.Text == "Seçiniz" || cb_yil_tecrübe.Text ==""|| cb_donem_tecrübe.Text == "Seçiniz" || cb_donem_tecrübe.Text == "" || txt_sayi_tecrübe.Text == "")
                        {
                            lbl_donem.ForeColor = Color.Red;
                            lbl_yıl.ForeColor = Color.Red;
                            lbl_puan.ForeColor = Color.Red;
                            lbl_aciklama.ForeColor = Color.Red;
                            lbl_not.ForeColor = Color.Red;

                        }
                        else
                        {
                            guncellemetecrube = true;
                            lbl_donem.ForeColor = Color.Black;
                            lbl_yıl.ForeColor = Color.Black;
                            lbl_puan.ForeColor = Color.Black;
                            lbl_aciklama.ForeColor = Color.Black;
                            lbl_not.ForeColor = Color.Black;
                        }
                    }



                    if (txt_sayi_tecrübe.Text != "" && (cb_yil_tecrübe.Text != "Seçiniz"|| cb_yil_tecrübe.Text != "") &&( cb_donem_tecrübe.Text != "Seçiniz"|| cb_donem_tecrübe.Text != ""))
                    {

                        btn_guncelle.Enabled = true;
                        try
                        {
                            SqlCommand guncellekomutu = new SqlCommand("Guncelle_KisiYillikPerformans", baglantim.baglanti());
                            guncellekomutu.CommandType = CommandType.StoredProcedure;

                            guncellekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                            guncellekomutu.Parameters.AddWithValue("@persormansDonemi", cb_donem_tecrübe.Text);
                            guncellekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi_tecrübe.Text);
                            guncellekomutu.Parameters.AddWithValue("@harfNotu", txt_harf_tecrübe.Text);
                            guncellekomutu.Parameters.AddWithValue("@yil", cb_yil_tecrübe.Text);
                            guncellekomutu.Parameters.AddWithValue("@aciklama", lbl_aciklama_tecrübe.Text);
                            guncellekomutu.Parameters.AddWithValue("@calismaGrubu", "TECRÜBELİ PERSONEL");
                            guncellekomutu.Parameters.AddWithValue("@id", txt_id_tecrübe.Text);
                            guncellemetecrube = true;

                            guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        }
                        catch (Exception hatamjs)
                        {
                            //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                            MessageBox.Show(hatamjs.Message);

                        }
                    }

                    if (txt_ilk.Text != "")
                    {
                        btn_guncelle.Enabled = true;
                        try
                        {
                            SqlCommand guncelleilksorgu = new SqlCommand("Guncelle_KisiYillikPerformans", baglantim.baglanti());
                            guncelleilksorgu.CommandType = CommandType.StoredProcedure;

                            guncelleilksorgu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                            guncelleilksorgu.Parameters.AddWithValue("@persormansDonemi", "0");
                            guncelleilksorgu.Parameters.AddWithValue("@sayisalKarsilik", txt_ilk.Text);
                            guncelleilksorgu.Parameters.AddWithValue("@harfNotu", lbl_harf_ilk.Text);
                            guncelleilksorgu.Parameters.AddWithValue("@yil", cb_yil_il.Text);
                            guncelleilksorgu.Parameters.AddWithValue("@aciklama", lbl_ilk_aciklama.Text);
                            guncelleilksorgu.Parameters.AddWithValue("@calismaGrubu", "YENİ PERSONEL");
                            guncelleilksorgu.Parameters.AddWithValue("@id", txt_id_ilk.Text);
                            guncelleilk = true;

                            guncelleilksorgu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir



                        }
                        catch (Exception hatamjs)
                        {
                            //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                            MessageBox.Show(hatamjs.Message);

                        }

                        if (guncelleilk == true || guncellemetecrube == true)
                        {
                            MessageBox.Show("Personelin değerlendirmesi güncellenmiştir.");
                        }

                    }
                    break;
                }


                if (kayit_arama_durumu == false)
                {
                    btn_ekle.Enabled = false;
                    btn_guncelle.Enabled = false;
                    btn_sil.Enabled = false;
                    btn_listele.Enabled = false;
                    MessageBox.Show("Personel kaydı bulunamadığı için işlem yapamazsınız.");
                }

                if (guncellemetecrube == true)
                {
                    MessageBox.Show("Personelin değerlendirmesi güncellennmiştir.");
                }
            }
            else
            {
                MessageBox.Show("Seçili bir öğe yoktur");
            }
            listele();
            listeletumu();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            bool sil_ilk = false;
            bool sil_tecrube = false;

            if (kayit_arama_durumu == true)
            {

                if (txt_ilk.Text != "")
                {

                    bool kayitaramailk = false;
                    SqlCommand secmesorgusuilk = new SqlCommand("Select *from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

                    SqlDataReader kayitokumailk = secmesorgusuilk.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokumailk.Read())
                    {
                        kayitaramailk = true;
                        SqlCommand silsorgusuilk = new SqlCommand("delete from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_id_ilk.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusuilk.ExecuteNonQuery();
                        //     MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        sil_ilk = true;
                        //ekrani_temizle();

                        break;

                    }



                }

                if (cb_yil_tecrübe.Text != "Seçiniz"|| cb_yil_tecrübe.Text != "" || cb_donem_tecrübe.Text != "Seçiniz" || cb_donem_tecrübe.Text != "" || txt_sayi_tecrübe.Text != "")
                {

                    bool kayitaramatecrube = false;
                    SqlCommand secmesorgusutecrube = new SqlCommand("Select *from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

                    SqlDataReader kayitokumatecrube = secmesorgusutecrube.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokumatecrube.Read())
                    {
                        kayitaramatecrube = true;
                        SqlCommand silsorgusutecrube = new SqlCommand("delete from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_id_tecrübe.Text + "'and yil='" + cb_yil_tecrübe.Text + "'and persormansDonemi='" + cb_donem_tecrübe.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusutecrube.ExecuteNonQuery();
                        //     MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        sil_tecrube = true;
                        //ekrani_temizle();

                        break;

                    }



                }

            }

            if (sil_ilk == true || sil_tecrube == true)
            {
                MessageBox.Show("Silme işlemi başarılı bir şekilde gerçekleşmiştir.");
            }
            listele();
            listeletumu();
        }

        private void cb_yil_tecrübe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_yil_tecrübe.SelectedItem != null)
            {
                if (cb_yil_tecrübe.Text != "Seçiniz" || cb_yil_tecrübe.Text != " ")
                {
                    label7.Text = cb_yil_tecrübe.SelectedItem.ToString();
                }
            }
            //else
            //    MessageBox.Show("null döndü");



        }

        private void cb_donem_tecrübe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_donem_tecrübe.SelectedItem != null)
            {
                if (cb_donem_tecrübe.Text != "Seçiniz" || cb_donem_tecrübe.Text != "")
                {
                    label9.Text = cb_donem_tecrübe.SelectedItem.ToString();
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //chartControl3.DataSource = null;
            //chartControl3.Series.Clear();

            //chartControl3.Series[0].Points.Clear();
            gridControl1.DataSource = null;
            gridControl1.DataMember = null;
            gridView1.RefreshData();

            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    gridView1.Columns.Clear();
            //}

            //gridControl1.
            //gridView1.PrintDialog();

            //DataTable dataTable = new DataTable();
            //gridControl1.DataSource = dataTable;

            //chart1.Series.Clear();
            chart1.Series[0].Points.Clear();

            chartControl3.Series["Series 1"].Points.Clear();
            ////chart1.DataSource = null;

        }

        public void temizle_grafikleri()
        {
            gridControl1.DataSource = null;
            gridControl1.DataMember = null;
            gridView1.RefreshData();

            chart1.Series[0].Points.Clear();

            chartControl3.Series["Series 1"].Points.Clear();
        }

        private void btn_ilk_temizle_Click(object sender, EventArgs e)
        {
            txt_ilk.Text = "";
            cb_yil_il.Text = "Seçiniz";
            lbl_harf_ilk.Text = "...";
            lbl_ilk_aciklama.Text = "...";
            txt_id_ilk.Text = "";
        }

        private void cb_donem_tecrübe_TextChanged(object sender, EventArgs e)
        {
            label9.Text = cb_donem_tecrübe.Text;
        }

        private void label7_TextChanged(object sender, EventArgs e)
        {
            label7.Text = cb_yil_tecrübe.Text;
        }

        private void bnt_sil_tecrube_Click(object sender, EventArgs e)
        {
            cb_yil_tecrübe.Text = "";
            cb_donem_tecrübe.Text = "";
            txt_sayi_tecrübe.Text = "";
            txt_harf_tecrübe.Text = "";
            lbl_aciklama_tecrübe.Text = "...";
            label7.Text = "label7";
            label9.Text = "label9";


        }
    }
}
