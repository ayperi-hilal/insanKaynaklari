using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsanKaynaklariBilgiSistem
{
    public partial class kkd : Form
    {
        public kkd()
        {
            InitializeComponent();
        }
        sqlBaglantisi baglantim = new sqlBaglantisi();

        string kkd_turu = "";
        private void kkd_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.Columns.Count; i++) gridView1.Columns[i].BestFit();
            mtxt_tc_no.Mask = "00000000000";//kullnıcı 11 haneli tc numarası girebilecek.

            //beden büyüklükleri
            txt_is_yelegi.CharacterCasing = CharacterCasing.Upper;
            txt_polar.CharacterCasing = CharacterCasing.Upper;
            txt_tulum.CharacterCasing = CharacterCasing.Upper;
            txt_pantolun.CharacterCasing = CharacterCasing.Upper;
            txt_thirt.CharacterCasing = CharacterCasing.Upper;
            txt_celik_ayakkabi.CharacterCasing = CharacterCasing.Upper;
            txt_is_eldiveni.CharacterCasing = CharacterCasing.Upper;
            txt_gozluk.CharacterCasing = CharacterCasing.Upper;
            txt_kulaklik.CharacterCasing = CharacterCasing.Upper;
            txt_maske.CharacterCasing = CharacterCasing.Upper;
            txt_kaynak_gozluk.CharacterCasing = CharacterCasing.Upper;
            txt_baret.CharacterCasing = CharacterCasing.Upper;
            txt_kaynak_eldiveni.CharacterCasing = CharacterCasing.Upper;


            DateTime zaman = DateTime.Now;
            int yil = int.Parse(zaman.ToString("yyyy"));
            int ay = int.Parse(zaman.ToString("MM"));
            int gun = int.Parse(zaman.ToString("dd"));


            //teslim tarihleri
            date_is_yelegi.MinDate = new DateTime(1900, 1, 1);
            date_is_yelegi.MaxDate = new DateTime(yil, ay, gun + 1);

            date_polar.MinDate = new DateTime(1900, 1, 1);
            date_polar.MaxDate = new DateTime(yil, ay, gun + 1);

            date_tulum.MinDate = new DateTime(1900, 1, 1);
            date_tulum.MaxDate = new DateTime(yil, ay, gun + 1);

            date_pantolon.MinDate = new DateTime(1900, 1, 1);
            date_pantolon.MaxDate = new DateTime(yil, ay, gun + 1);

            date_tshirt.MinDate = new DateTime(1900, 1, 1);
            date_tshirt.MaxDate = new DateTime(yil, ay, gun + 1);

            date_ayakkabi.MinDate = new DateTime(1900, 1, 1);
            date_ayakkabi.MaxDate = new DateTime(yil, ay, gun + 1);

            date_is_eldiveni.MinDate = new DateTime(1900, 1, 1);
            date_is_eldiveni.MaxDate = new DateTime(yil, ay, gun + 1);

            date_gozluk.MinDate = new DateTime(1900, 1, 1);
            date_gozluk.MaxDate = new DateTime(yil, ay, gun + 1);

            date_kulaklik.MinDate = new DateTime(1900, 1, 1);
            date_kulaklik.MaxDate = new DateTime(yil, ay, gun + 1);

            date_maske.MinDate = new DateTime(1900, 1, 1);
            date_maske.MaxDate = new DateTime(yil, ay, gun + 1);

            date_kaynak_gozluk.MinDate = new DateTime(1900, 1, 1);
            date_kaynak_gozluk.MaxDate = new DateTime(yil, ay, gun + 1);

            date_baret.MinDate = new DateTime(1900, 1, 1);
            date_baret.MaxDate = new DateTime(yil, ay, gun + 1);

            date_kaynak_eldiveni.MinDate = new DateTime(1900, 1, 1);
            date_kaynak_eldiveni.MaxDate = new DateTime(yil, ay, gun + 1);


            //aksiyon tarihleri
            date_is_yelek_aksiyon.MinDate = new DateTime(1900, 1, 1);
            date_is_yelek_aksiyon.MaxDate = new DateTime(yil, ay, gun + 1);

            date_polar_aksiyon.MinDate = new DateTime(1900, 1, 1);
            date_polar_aksiyon.MaxDate = new DateTime(yil, ay, gun + 1);

            date_tulum_aksiyon.MinDate = new DateTime(1900, 1, 1);
            date_tulum_aksiyon.MaxDate = new DateTime(yil, ay, gun + 1);

            date_pantolon_aksiyon.MinDate = new DateTime(1900, 1, 1);
            date_pantolon_aksiyon.MaxDate = new DateTime(yil, ay, gun + 1);

            date_tshirt_aksiyon.MinDate = new DateTime(1900, 1, 1);
            date_tshirt_aksiyon.MaxDate = new DateTime(yil, ay, gun + 1);

            date_ayakkabi_aksiyon.MinDate = new DateTime(1900, 1, 1);
            date_ayakkabi_aksiyon.MaxDate = new DateTime(yil, ay, gun + 1);

            date_is_eldiveni_aksiyon.MinDate = new DateTime(1900, 1, 1);
            date_is_eldiveni_aksiyon.MaxDate = new DateTime(yil, ay, gun + 1);

            date_gozluk_aksiyon.MinDate = new DateTime(1900, 1, 1);
            date_gozluk_aksiyon.MaxDate = new DateTime(yil, ay, gun + 1);

            date_kulaklik_aksiyon.MinDate = new DateTime(1900, 1, 1);
            date_kulaklik_aksiyon.MaxDate = new DateTime(yil, ay, gun + 1);

            date_maske_aksiyon.MinDate = new DateTime(1900, 1, 1);
            date_maske_aksiyon.MaxDate = new DateTime(yil, ay, gun + 1);

            date_kaynak_gozluk_aksiyon.MinDate = new DateTime(1900, 1, 1);
            date_kaynak_gozluk_aksiyon.MaxDate = new DateTime(yil, ay, gun + 1);

            date_baret_aksiyon.MinDate = new DateTime(1900, 1, 1);
            date_baret_aksiyon.MaxDate = new DateTime(yil, ay, gun + 1);

            date_kaynak_eldiveni_aksiyon.MinDate = new DateTime(1900, 1, 1);
            date_kaynak_eldiveni_aksiyon.MaxDate = new DateTime(yil, ay, gun + 1);

            //aksiyon tahilerinin görünmesi
            lbl_aksiyon_tarihi.Visible = false;
            date_is_yelek_aksiyon.Visible = false;
            date_polar_aksiyon.Visible = false;
            date_tulum_aksiyon.Visible = false;
            date_pantolon_aksiyon.Visible = false;
            date_tshirt_aksiyon.Visible = false;
            date_ayakkabi_aksiyon.Visible = false;
            date_is_eldiveni_aksiyon.Visible = false;
            date_gozluk_aksiyon.Visible = false;
            date_kulaklik_aksiyon.Visible = false;
            date_maske_aksiyon.Visible = false;
            date_kaynak_gozluk_aksiyon.Visible = false;
            date_baret_aksiyon.Visible = false;
            date_kaynak_eldiveni_aksiyon.Visible = false;

            //aksiyon türleri
            cb_is_yelek.Items.Add("Kullanımda");
            cb_is_yelek.Items.Add("İşten Ayrılma");
            cb_is_yelek.Items.Add("Değişim");
            cb_is_yelek.Items.Add("Kırılma");
            cb_is_yelek.Items.Add("Görevden Ayrılma");
            cb_is_yelek.Items.Add("Kaybolma");
            cb_is_yelek.Items.Add("Yenileme");
            cb_is_yelek.SelectedItem = "Kullanımda";


            cb_polar.Items.Add("Kullanımda");
            cb_polar.Items.Add("İşten Ayrılma");
            cb_polar.Items.Add("Değişim");
            cb_polar.Items.Add("Kırılma");
            cb_polar.Items.Add("Görevden Ayrılma");
            cb_polar.Items.Add("Kaybolma");
            cb_polar.Items.Add("Yenileme");
            cb_polar.SelectedItem = "Kullanımda";

            cb_tulum.Items.Add("Kullanımda");
            cb_tulum.Items.Add("İşten Ayrılma");
            cb_tulum.Items.Add("Değişim");
            cb_tulum.Items.Add("Kırılma");
            cb_tulum.Items.Add("Görevden Ayrılma");
            cb_tulum.Items.Add("Kaybolma");
            cb_tulum.Items.Add("Yenileme");
            cb_tulum.SelectedItem = "Kullanımda";

            cb_pantolon.Items.Add("Kullanımda");
            cb_pantolon.Items.Add("İşten Ayrılma");
            cb_pantolon.Items.Add("Değişim");
            cb_pantolon.Items.Add("Kırılma");
            cb_pantolon.Items.Add("Görevden Ayrılma");
            cb_pantolon.Items.Add("Kaybolma");
            cb_pantolon.Items.Add("Yenileme");
            cb_pantolon.SelectedItem = "Kullanımda";

            cb_tshirt.Items.Add("Kullanımda");
            cb_tshirt.Items.Add("İşten Ayrılma");
            cb_tshirt.Items.Add("Değişim");
            cb_tshirt.Items.Add("Kırılma");
            cb_tshirt.Items.Add("Görevden Ayrılma");
            cb_tshirt.Items.Add("Kaybolma");
            cb_tshirt.Items.Add("Yenileme");
            cb_tshirt.SelectedItem = "Kullanımda";

            cb_ayakkabi.Items.Add("Kullanımda");
            cb_ayakkabi.Items.Add("İşten Ayrılma");
            cb_ayakkabi.Items.Add("Değişim");
            cb_ayakkabi.Items.Add("Kırılma");
            cb_ayakkabi.Items.Add("Görevden Ayrılma");
            cb_ayakkabi.Items.Add("Kaybolma");
            cb_ayakkabi.Items.Add("Yenileme");
            cb_ayakkabi.SelectedItem = "Kullanımda";

            cb_is_eldiveni.Items.Add("Kullanımda");
            cb_is_eldiveni.Items.Add("İşten Ayrılma");
            cb_is_eldiveni.Items.Add("Değişim");
            cb_is_eldiveni.Items.Add("Kırılma");
            cb_is_eldiveni.Items.Add("Görevden Ayrılma");
            cb_is_eldiveni.Items.Add("Kaybolma");
            cb_is_eldiveni.Items.Add("Yenileme");
            cb_is_eldiveni.SelectedItem = "Kullanımda";

            cb_gozluk.Items.Add("Kullanımda");
            cb_gozluk.Items.Add("İşten Ayrılma");
            cb_gozluk.Items.Add("Değişim");
            cb_gozluk.Items.Add("Kırılma");
            cb_gozluk.Items.Add("Görevden Ayrılma");
            cb_gozluk.Items.Add("Kaybolma");
            cb_gozluk.Items.Add("Yenileme");
            cb_gozluk.SelectedItem = "Kullanımda";

            cb_kulaklık.Items.Add("Kullanımda");
            cb_kulaklık.Items.Add("İşten Ayrılma");
            cb_kulaklık.Items.Add("Değişim");
            cb_kulaklık.Items.Add("Kırılma");
            cb_kulaklık.Items.Add("Görevden Ayrılma");
            cb_kulaklık.Items.Add("Kaybolma");
            cb_kulaklık.Items.Add("Yenileme");
            cb_kulaklık.SelectedItem = "Kullanımda";

            cb_maske.Items.Add("Kullanımda");
            cb_maske.Items.Add("İşten Ayrılma");
            cb_maske.Items.Add("Değişim");
            cb_maske.Items.Add("Kırılma");
            cb_maske.Items.Add("Görevden Ayrılma");
            cb_maske.Items.Add("Kaybolma");
            cb_maske.Items.Add("Yenileme");
            cb_maske.SelectedItem = "Kullanımda";

            cb_kaynak_gozluk.Items.Add("Kullanımda");
            cb_kaynak_gozluk.Items.Add("İşten Ayrılma");
            cb_kaynak_gozluk.Items.Add("Değişim");
            cb_kaynak_gozluk.Items.Add("Kırılma");
            cb_kaynak_gozluk.Items.Add("Görevden Ayrılma");
            cb_kaynak_gozluk.Items.Add("Kaybolma");
            cb_kaynak_gozluk.Items.Add("Yenileme");
            cb_kaynak_gozluk.SelectedItem = "Kullanımda";

            cb_baret.Items.Add("Kullanımda");
            cb_baret.Items.Add("İşten Ayrılma");
            cb_baret.Items.Add("Değişim");
            cb_baret.Items.Add("Kırılma");
            cb_baret.Items.Add("Görevden Ayrılma");
            cb_baret.Items.Add("Kaybolma");
            cb_baret.Items.Add("Yenileme");
            cb_baret.SelectedItem = "Kullanımda";

            cb_kaynak_eldiven.Items.Add("Kullanımda");
            cb_kaynak_eldiven.Items.Add("İşten Ayrılma");
            cb_kaynak_eldiven.Items.Add("Değişim");
            cb_kaynak_eldiven.Items.Add("Kırılma");
            cb_kaynak_eldiven.Items.Add("Görevden Ayrılma");
            cb_kaynak_eldiven.Items.Add("Kaybolma");
            cb_kaynak_eldiven.Items.Add("Yenileme");
            cb_kaynak_eldiven.SelectedItem = "Kullanımda";


            btn_sil.Enabled = false;
            btn_guncelle.Enabled = false;
            btn_forma_ekle.Enabled = false;

        }
        private void ekrani_temizle()
        {
            mtxt_tc_no.Clear();
            txt_pdks.Text = string.Empty;
            lbl_add.Text = string.Empty;
            lbl_soyadd.Text = string.Empty;
            lbl_gorevyeri.Text = string.Empty;

            txt_id_ayakkabi.Text = string.Empty;
            txt_id_is_eldiveni.Text = string.Empty;
            txt_id_baret.Text = string.Empty;
            txt_id_gozluk.Text = string.Empty;
            txt_id_kaynak_eldiven.Text = string.Empty;
            txt_id_kaynak_gozluk.Text = string.Empty;
            txt_id_kulaklik.Text = string.Empty;
            txt_id_maske.Text = string.Empty;
            txt_id_pantolon.Text = string.Empty;
            txt_id_polar.Text = string.Empty;
            txt_id_tshirt.Text = string.Empty;
            txt_id_tulum.Text = string.Empty;
            txt_id_yelek.Text = string.Empty;

            txt_is_yelegi.Text = string.Empty;
            txt_polar.Text = string.Empty;
            txt_tulum.Text = string.Empty;
            txt_pantolun.Text = string.Empty;
            txt_thirt.Text = string.Empty;
            txt_celik_ayakkabi.Text = string.Empty;
            txt_is_eldiveni.Text = string.Empty;
            txt_gozluk.Text = string.Empty;
            txt_kulaklik.Text = string.Empty;
            txt_maske.Text = string.Empty;
            txt_kaynak_gozluk.Text = string.Empty;
            txt_baret.Text = string.Empty;
            txt_kaynak_eldiveni.Text = string.Empty;

            cb_is_yelek.Text = string.Empty;
            cb_polar.Text = string.Empty;
            cb_tulum.Text = string.Empty;
            cb_pantolon.Text = string.Empty;
            cb_tshirt.Text = string.Empty;
            cb_ayakkabi.Text = string.Empty;
            cb_is_eldiveni.Text = string.Empty;
            cb_gozluk.Text = string.Empty;
            cb_kulaklık.Text = string.Empty;
            cb_maske.Text = string.Empty;
            cb_kaynak_gozluk.Text = string.Empty;
            cb_baret.Text = string.Empty;
            cb_kaynak_eldiven.Text = string.Empty;


            date_is_yelegi.ResetText();
            date_polar.ResetText();
            date_tulum.ResetText();
            date_pantolon.ResetText();
            date_tshirt.ResetText();
            date_ayakkabi.ResetText();
            date_is_eldiveni.ResetText();
            date_gozluk.ResetText();
            date_kulaklik.ResetText();
            date_maske.ResetText();
            date_kaynak_gozluk.ResetText();
            date_baret.ResetText();
            date_kaynak_eldiveni.ResetText();

            date_is_yelek_aksiyon.ResetText();
            date_polar_aksiyon.ResetText();
            date_tulum_aksiyon.ResetText();
            date_pantolon_aksiyon.ResetText();
            date_tshirt_aksiyon.ResetText();
            date_ayakkabi_aksiyon.ResetText();
            date_is_eldiveni_aksiyon.ResetText();
            date_gozluk_aksiyon.ResetText();
            date_kulaklik_aksiyon.ResetText();
            date_maske_aksiyon.ResetText();
            date_kaynak_gozluk_aksiyon.ResetText();
            date_baret_aksiyon.ResetText();
            date_kaynak_eldiveni_aksiyon.ResetText();


            date_is_yelek_aksiyon.Visible = false;
            date_polar_aksiyon.Visible = false;
            date_tulum_aksiyon.Visible = false;
            date_pantolon_aksiyon.Visible = false;
            date_tshirt_aksiyon.Visible = false;
            date_ayakkabi_aksiyon.Visible = false;
            date_is_eldiveni_aksiyon.Visible = false;
            date_gozluk_aksiyon.Visible = false;
            date_kulaklik_aksiyon.Visible = false;
            date_maske_aksiyon.Visible = false;
            date_kaynak_gozluk_aksiyon.Visible = false;
            date_baret_aksiyon.Visible = false;
            date_kaynak_eldiveni_aksiyon.Visible = false;

            lbl_aksiyon_tarihi.Visible = false;
        }

        public void tum_kkd_bilgileri()
        {
            SqlCommand sorgu = new SqlCommand("tum_kkd_bilgileri", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sorgu);

            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl2.DataSource = dt;


            gridView2.OptionsBehavior.Editable = false;
            gridView2.OptionsView.ShowAutoFilterRow = true;
        }

        public void listele()
        {
            SqlCommand sorgu = new SqlCommand("Listele_kkd", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sorgu);
            sorgu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gridControl1.DataSource = dt;

            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["pdks"].Visible = false;

            gridView1.Columns["TC"].Caption = "TC NO";
            gridView1.Columns["kkd_turu"].Caption = "KKD TÜRÜ";
            gridView1.Columns["beden"].Caption = "BEDEN";
            gridView1.Columns["kkd_teslim_tarihi"].Caption = "TESLİM TARİHİ";
            gridView1.Columns["aksiyon_tutu"].Caption = "AKSİYON";
            gridView1.Columns["aksiyon_tarihi"].Caption = "AKSİYON TARİHİ";

        }

        private void cb_is_yelek_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_is_yelek.Text == "Kullanımda")
                date_is_yelek_aksiyon.Visible = false;
            else
            {
                date_is_yelek_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }
        }

        private void cb_polar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_polar.Text == "Kullanımda")
                date_polar_aksiyon.Visible = false;
            else
            {
                date_polar_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }

        }

        private void cb_tulum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_tulum.Text == "Kullanımda")
                date_tulum_aksiyon.Visible = false;
            else
            {
                date_tulum_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }
        }

        private void cb_pantolon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_pantolon.Text == "Kullanımda")
                date_pantolon_aksiyon.Visible = false;
            else
            {
                date_pantolon_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }
        }

        private void cb_tshirt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_tshirt.Text == "Kullanımda")
                date_tshirt_aksiyon.Visible = false;
            else
            {
                date_tshirt_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }
        }

        private void cb_ayakkabi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_ayakkabi.Text == "Kullanımda")
                date_ayakkabi_aksiyon.Visible = false;
            else
            {
                date_ayakkabi_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }
        }

        private void cb_is_eldiveni_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_is_eldiveni.Text == "Kullanımda")
                date_is_eldiveni_aksiyon.Visible = false;
            else
            {
                date_is_eldiveni_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }
        }

        private void cb_gozluk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_gozluk.Text == "Kullanımda")
                date_gozluk_aksiyon.Visible = false;
            else
            {
                date_gozluk_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }
        }

        private void cb_kulaklık_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_kulaklık.Text == "Kullanımda")
                date_kulaklik_aksiyon.Visible = false;
            else
            {
                date_kulaklik_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }

        }

        private void cb_maske_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_maske.Text == "Kullanımda")
                date_maske_aksiyon.Visible = false;
            else
            {
                date_maske_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }
        }

        private void cb_kaynak_gozluk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_kaynak_gozluk.Text == "Kullanımda")
                date_kaynak_gozluk_aksiyon.Visible = false;
            else
            {
                date_kaynak_gozluk_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }
        }

        private void cb_baret_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_baret.Text == "Kullanımda")
                date_baret_aksiyon.Visible = false;
            else
            {
                date_baret_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }
        }

        private void cb_kaynak_eldiven_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_kaynak_eldiven.Text == "Kullanımda")
                date_kaynak_eldiveni_aksiyon.Visible = false;
            else
            {
                date_kaynak_eldiveni_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }
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


                    lbl_add.Text = kayitokuma.GetValue(2).ToString();//ilgili tck ait değerin veritabanındaki tck getirilecek. veri tabanı 0,1,2,.. diye gider.
                    lbl_soyadd.Text = kayitokuma.GetValue(3).ToString();//soyad
                    lbl_gorevyeri.Text = kayitokuma.GetValue(14).ToString();//görev yeri



                    break;
                }
            }
        }


        //ara butonu
        private void btn_ara_Click(object sender, EventArgs e)
        {
            //tck yazılarak veri tablosundaki veri araştırılır
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
                            }

                        }
                    }

                    lbl_add.Text = kayitokuma.GetValue(2).ToString();//ilgili tck ait değerin veritabanındaki tck getirilecek. veri tabanı 0,1,2,.. diye gider.
                    lbl_soyadd.Text = kayitokuma.GetValue(3).ToString();
                    lbl_gorevyeri.Text = kayitokuma.GetValue(14).ToString();//görev yeri

                    btn_sil.Enabled = true;
                    btn_guncelle.Enabled = true;
                    btn_forma_ekle.Enabled = true;

                    break;
                }
                //eğer kayıt okuma durumu gerçekleşmemiş ise kayıt bulunamadı ise
                if (kayit_arama_durumu == false)
                {
                    MessageBox.Show("Kayıt bulunamadı", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btn_sil.Enabled = false;
                    btn_guncelle.Enabled = false;
                    btn_forma_ekle.Enabled = false;
                }

            }
            else
            {
                //girilen tc no 11karakter değilse
                MessageBox.Show("Lütfen 11 haneli TC NO giriniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ekrani_temizle();
            }
            listele();

        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            //öncelikle bedenleri çekelim.
            if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "İŞ YELEĞİ")
                txt_id_yelek.Text = gridView1.GetFocusedRowCellValue("id").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "POLAR")
                txt_id_polar.Text = gridView1.GetFocusedRowCellValue("id").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "TULUM")
                txt_id_tulum.Text = gridView1.GetFocusedRowCellValue("id").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "PANTOLON")
                txt_id_pantolon.Text = gridView1.GetFocusedRowCellValue("id").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "T-SHIRT")
                txt_id_tshirt.Text = gridView1.GetFocusedRowCellValue("id").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "ÇELİK AYAKKABI")
                txt_id_ayakkabi.Text = gridView1.GetFocusedRowCellValue("id").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "İŞ ELDİVENİ")
                txt_id_is_eldiveni.Text = gridView1.GetFocusedRowCellValue("id").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "GÖZLÜK")
                txt_id_gozluk.Text = gridView1.GetFocusedRowCellValue("id").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "KULAKLIK")
                txt_id_kulaklik.Text = gridView1.GetFocusedRowCellValue("id").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "MASKE")
                txt_id_maske.Text = gridView1.GetFocusedRowCellValue("id").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "KAYNAKÇI GÖZLÜĞÜ")
                txt_id_kaynak_gozluk.Text = gridView1.GetFocusedRowCellValue("id").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "BARET")
                txt_id_baret.Text = gridView1.GetFocusedRowCellValue("id").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "KAYNAKÇI ELDİVENİ")
                txt_id_kaynak_eldiven.Text = gridView1.GetFocusedRowCellValue("id").ToString();


            mtxt_tc_no.Text = gridView1.GetFocusedRowCellValue("TC").ToString();

            //öncelikle bedenleri çekelim.
            if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "İŞ YELEĞİ")
                txt_is_yelegi.Text = gridView1.GetFocusedRowCellValue("beden").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "POLAR")
                txt_polar.Text = gridView1.GetFocusedRowCellValue("beden").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "TULUM")
                txt_tulum.Text = gridView1.GetFocusedRowCellValue("beden").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "PANTOLON")
                txt_pantolun.Text = gridView1.GetFocusedRowCellValue("beden").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "T-SHIRT")
                txt_thirt.Text = gridView1.GetFocusedRowCellValue("beden").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "ÇELİK AYAKKABI")
                txt_celik_ayakkabi.Text = gridView1.GetFocusedRowCellValue("beden").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "İŞ ELDİVENİ")
                txt_is_eldiveni.Text = gridView1.GetFocusedRowCellValue("beden").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "GÖZLÜK")
                txt_gozluk.Text = gridView1.GetFocusedRowCellValue("beden").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "KULAKLIK")
                txt_kulaklik.Text = gridView1.GetFocusedRowCellValue("beden").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "MASKE")
                txt_maske.Text = gridView1.GetFocusedRowCellValue("beden").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "KAYNAKÇI GÖZLÜĞÜ")
                txt_kaynak_gozluk.Text = gridView1.GetFocusedRowCellValue("beden").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "BARET")
                txt_baret.Text = gridView1.GetFocusedRowCellValue("beden").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "KAYNAKÇI ELDİVENİ")
                txt_kaynak_eldiveni.Text = gridView1.GetFocusedRowCellValue("beden").ToString();

            //teslim tarihlerini çekelim
            if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "İŞ YELEĞİ")
                date_is_yelegi.Text = gridView1.GetFocusedRowCellValue("kkd_teslim_tarihi").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "POLAR")
                date_polar.Text = gridView1.GetFocusedRowCellValue("kkd_teslim_tarihi").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "TULUM")
                date_tulum.Text = gridView1.GetFocusedRowCellValue("kkd_teslim_tarihi").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "PANTOLON")
                date_pantolon.Text = gridView1.GetFocusedRowCellValue("kkd_teslim_tarihi").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "T-SHIRT")
                date_tshirt.Text = gridView1.GetFocusedRowCellValue("kkd_teslim_tarihi").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "ÇELİK AYAKKABI")
                date_ayakkabi.Text = gridView1.GetFocusedRowCellValue("kkd_teslim_tarihi").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "İŞ ELDİVENİ")
                date_is_eldiveni.Text = gridView1.GetFocusedRowCellValue("kkd_teslim_tarihi").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "GÖZLÜK")
                date_gozluk.Text = gridView1.GetFocusedRowCellValue("kkd_teslim_tarihi").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "KULAKLIK")
                date_kulaklik.Text = gridView1.GetFocusedRowCellValue("kkd_teslim_tarihi").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "MASKE")
                date_maske.Text = gridView1.GetFocusedRowCellValue("kkd_teslim_tarihi").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "KAYNAKÇI GÖZLÜĞÜ")
                date_kaynak_gozluk.Text = gridView1.GetFocusedRowCellValue("kkd_teslim_tarihi").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "BARET")
                date_baret.Text = gridView1.GetFocusedRowCellValue("kkd_teslim_tarihi").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "KAYNAKÇI ELDİVENİ")
                date_kaynak_eldiveni.Text = gridView1.GetFocusedRowCellValue("kkd_teslim_tarihi").ToString();

            //aksiyon türünü çekelim
            if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "İŞ YELEĞİ")
                cb_is_yelek.Text = gridView1.GetFocusedRowCellValue("aksiyon_tutu").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "POLAR")
                cb_polar.Text = gridView1.GetFocusedRowCellValue("aksiyon_tutu").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "TULUM")
                cb_tulum.Text = gridView1.GetFocusedRowCellValue("aksiyon_tutu").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "PANTOLON")
                cb_pantolon.Text = gridView1.GetFocusedRowCellValue("aksiyon_tutu").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "T-SHIRT")
                cb_tshirt.Text = gridView1.GetFocusedRowCellValue("aksiyon_tutu").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "ÇELİK AYAKKABI")
                cb_ayakkabi.Text = gridView1.GetFocusedRowCellValue("aksiyon_tutu").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "İŞ ELDİVENİ")
                cb_is_eldiveni.Text = gridView1.GetFocusedRowCellValue("aksiyon_tutu").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "GÖZLÜK")
                cb_gozluk.Text = gridView1.GetFocusedRowCellValue("aksiyon_tutu").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "KULAKLIK")
                cb_kulaklık.Text = gridView1.GetFocusedRowCellValue("aksiyon_tutu").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "MASKE")
                cb_maske.Text = gridView1.GetFocusedRowCellValue("aksiyon_tutu").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "KAYNAKÇI GÖZLÜĞÜ")
                cb_kaynak_gozluk.Text = gridView1.GetFocusedRowCellValue("aksiyon_tutu").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "BARET")
                cb_baret.Text = gridView1.GetFocusedRowCellValue("aksiyon_tutu").ToString();
            else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "KAYNAKÇI ELDİVENİ")
                cb_kaynak_eldiven.Text = gridView1.GetFocusedRowCellValue("aksiyon_tutu").ToString();


            //şimdi de skaiyon tarihini çekelim
            if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "İŞ YELEĞİ")
                if (cb_is_yelek.Text != "" && cb_is_yelek.Text != "Kullanımda")
                {
                    lbl_aksiyon_tarihi.Visible = true;
                    date_is_yelegi.Visible = true;
                    date_is_yelek_aksiyon.Text = gridView1.GetFocusedRowCellValue("aksiyon_tarihi").ToString();
                }
                else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "POLAR")
                    date_polar_aksiyon.Text = gridView1.GetFocusedRowCellValue("aksiyon_tarihi").ToString();
                else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "TULUM")
                    date_tulum_aksiyon.Text = gridView1.GetFocusedRowCellValue("aksiyon_tarihi").ToString();
                else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "PANTOLON")
                    date_pantolon_aksiyon.Text = gridView1.GetFocusedRowCellValue("aksiyon_tarihi").ToString();
                else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "T-SHIRT")
                    date_tshirt_aksiyon.Text = gridView1.GetFocusedRowCellValue("aksiyon_tarihi").ToString();
                else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "ÇELİK AYAKKABI")
                    date_ayakkabi_aksiyon.Text = gridView1.GetFocusedRowCellValue("aksiyon_tarihi").ToString();
                else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "İŞ ELDİVENİ")
                    date_is_eldiveni_aksiyon.Text = gridView1.GetFocusedRowCellValue("aksiyon_tarihi").ToString();
                else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "GÖZLÜK")
                    date_gozluk_aksiyon.Text = gridView1.GetFocusedRowCellValue("aksiyon_tarihi").ToString();
                else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "KULAKLIK")
                    date_kulaklik_aksiyon.Text = gridView1.GetFocusedRowCellValue("aksiyon_tarihi").ToString();
                else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "MASKE")
                    date_maske_aksiyon.Text = gridView1.GetFocusedRowCellValue("aksiyon_tarihi").ToString();
                else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "KAYNAKÇI GÖZLÜĞÜ")
                    date_kaynak_gozluk_aksiyon.Text = gridView1.GetFocusedRowCellValue("aksiyon_tarihi").ToString();
                else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "BARET")
                    date_baret_aksiyon.Text = gridView1.GetFocusedRowCellValue("aksiyon_tarihi").ToString();
                else if (gridView1.GetFocusedRowCellValue("kkd_turu").ToString() == "KAYNAKÇI ELDİVENİ")
                    date_kaynak_eldiveni_aksiyon.Text = gridView1.GetFocusedRowCellValue("aksiyon_tarihi").ToString();

            btn_guncelle.Enabled = true;
            btn_sil.Enabled = true;
            btn_forma_ekle.Enabled = true;
        }

        //forma ekleme
        private void btn_forma_ekle_Click(object sender, EventArgs e)
        {
            // baglantim.baglanti().Open();
            SqlCommand selectsorgu = new SqlCommand("select * from kkd where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                lbl_tc_no.ForeColor = Color.Red;
            else
                lbl_tc_no.ForeColor = Color.Black;

            //kkd türü 
            if (txt_is_yelegi.Text != "")
                kkd_turu = lbl_is_yelegi.Text;
            else if (txt_polar.Text != "")
                kkd_turu = lbl_polar.Text;
            else if (txt_tulum.Text != "")
                kkd_turu = lbl_tulum.Text;
            else if (txt_pantolun.Text != "")
                kkd_turu = lbl_pantolon.Text;
            else if (txt_thirt.Text != "")
                kkd_turu = lbl_tshirt.Text;
            else if (txt_celik_ayakkabi.Text != "")
                kkd_turu = lbl_celik_ayakkabi.Text;
            else if (txt_is_eldiveni.Text != "")
                kkd_turu = lbl_is_eldiveni.Text;
            else if (txt_gozluk.Text != "")
                kkd_turu = lbl_gozluk.Text;
            else if (txt_kulaklik.Text != "")
                kkd_turu = lbl_kulaklik.Text;
            else if (txt_maske.Text != "")
                kkd_turu = lbl_maske.Text;
            else if (txt_kaynak_gozluk.Text != "")
                kkd_turu = lbl_kaynak_gozluk.Text;
            else if (txt_baret.Text != "")
                kkd_turu = lbl_baret.Text;
            else if (txt_kaynak_eldiveni.Text != "")
                kkd_turu = lbl_kaynak_eldiveni.Text;


            //eğer aksiyon türüseçilir ise tarih zoruluolarak girilsin
            if (cb_is_yelek.Text != "Kullanımda" && cb_is_yelek.Text != "")
            {
                date_is_yelek_aksiyon.Enabled = true;
                date_is_yelek_aksiyon.Visible = true;
            }
            else
            {
                date_is_yelek_aksiyon.Enabled = false;
                date_is_yelek_aksiyon.Visible = false;
            }

            if (cb_polar.Text != "Kullanımda" && cb_polar.Text != "")
            {
                date_polar_aksiyon.Enabled = true;
                date_polar_aksiyon.Visible = true;
            }
            else
            {
                date_polar_aksiyon.Enabled = false;
                date_polar_aksiyon.Visible = false;
            }

            if (cb_tulum.Text != "Kullanımda" && cb_tulum.Text != "")
            {
                date_tulum_aksiyon.Enabled = true;
                date_tulum_aksiyon.Visible = true;
            }
            else
            {
                date_tulum_aksiyon.Enabled = false;
                date_tulum_aksiyon.Visible = false;
            }
            if (cb_pantolon.Text != "Kullanımda" && cb_pantolon.Text != "")
            {
                date_pantolon_aksiyon.Enabled = true;
                date_pantolon_aksiyon.Visible = true;
            }
            else
            {
                date_pantolon_aksiyon.Enabled = false;
                date_pantolon_aksiyon.Visible = false;
            }
            if (cb_tshirt.Text != "Kullanımda" && cb_tshirt.Text != "")
            {
                date_tshirt_aksiyon.Enabled = true;
                date_tshirt_aksiyon.Visible = true;
            }
            else
            {
                date_tshirt_aksiyon.Enabled = false;
                date_tshirt_aksiyon.Visible = false;
            }

            if (cb_ayakkabi.Text != "Kullanımda" && cb_ayakkabi.Text != "")
            {
                date_ayakkabi_aksiyon.Enabled = true;
                date_ayakkabi_aksiyon.Visible = true;
            }
            else
            {
                date_ayakkabi_aksiyon.Enabled = false;
                date_ayakkabi_aksiyon.Visible = false;
            }
            if (cb_is_eldiveni.Text != "Kullanımda" && cb_is_eldiveni.Text != "")
            {
                date_is_eldiveni_aksiyon.Enabled = true;
                date_is_eldiveni_aksiyon.Visible = true;
            }
            else
            {
                date_is_eldiveni_aksiyon.Enabled = false;
                date_is_eldiveni_aksiyon.Visible = false;
            }

            if (cb_gozluk.Text != "Kullanımda" && cb_gozluk.Text != "")
            {
                date_gozluk_aksiyon.Enabled = true;
                date_gozluk_aksiyon.Visible = true;
            }
            else
            {
                date_gozluk_aksiyon.Enabled = false;
                date_gozluk_aksiyon.Visible = false;
            }

            if (cb_kulaklık.Text != "Kullanımda" && cb_kulaklık.Text != "")
            {
                date_kulaklik_aksiyon.Enabled = true;
                date_kulaklik_aksiyon.Visible = true;
            }
            else
            {
                date_kulaklik_aksiyon.Enabled = false;
                date_kulaklik_aksiyon.Visible = false;
            }
            if (cb_maske.Text != "Kullanımda" && cb_maske.Text != "")
            {
                date_maske_aksiyon.Enabled = true;
                date_maske_aksiyon.Visible = true;
            }
            else
            {
                date_maske_aksiyon.Enabled = false;
                date_maske_aksiyon.Visible = false;
            }
            if (cb_kaynak_gozluk.Text != "Kullanımda" && cb_kaynak_gozluk.Text != "")
            {
                date_kaynak_gozluk_aksiyon.Enabled = true;
                date_kaynak_gozluk_aksiyon.Visible = true;
            }
            else
            {
                date_kaynak_gozluk_aksiyon.Enabled = false;
                date_kaynak_gozluk_aksiyon.Visible = false;
            }

            if (cb_baret.Text != "Kullanımda" && cb_baret.Text != "")
            {
                date_baret_aksiyon.Enabled = true;
                date_baret_aksiyon.Visible = true;
            }
            else
            {
                date_baret_aksiyon.Enabled = false;
                date_baret_aksiyon.Visible = false;

            }

            if (cb_kaynak_eldiven.Text != "Kullanımda" && cb_kaynak_eldiven.Text != "")
            {
                date_kaynak_eldiveni_aksiyon.Enabled = true;
                date_kaynak_eldiveni_aksiyon.Visible = true;
            }
            else
            {
                date_kaynak_eldiveni_aksiyon.Enabled = false;
                date_kaynak_eldiveni_aksiyon.Visible = false;
            }

            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_is_yelegi.Text != "" && cb_is_yelek.Text != "")
                {
                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_kkd", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_turu", "İŞ YELEĞİ");
                        eklekomutu.Parameters.AddWithValue("@beden", txt_is_yelegi.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_is_yelegi.Value);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_is_yelek.Text);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_is_yelek_aksiyon.Value);



                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        //  MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (txt_polar.Text != "" && cb_polar.Text != "")
                {
                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_kkd", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_turu", "POLAR");
                        eklekomutu.Parameters.AddWithValue("@beden", txt_polar.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_polar.Value);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_polar.Text);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_polar_aksiyon.Value);



                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        //  MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (txt_tulum.Text != "" && cb_tulum.Text != "")
                {
                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_kkd", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_turu", "TULUM");
                        eklekomutu.Parameters.AddWithValue("@beden", txt_tulum.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_tulum.Value);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_tulum.Text);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_tulum_aksiyon.Value);



                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        // MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (txt_pantolun.Text != "" && cb_pantolon.Text != "")
                {
                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_kkd", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_turu", "PANTOLON");
                        eklekomutu.Parameters.AddWithValue("@beden", txt_pantolun.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_pantolon.Value);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_pantolon.Text);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_pantolon_aksiyon.Value);



                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        // MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (txt_thirt.Text != "" && cb_tshirt.Text != "")
                {
                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_kkd", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_turu", "T-SHIRT");
                        eklekomutu.Parameters.AddWithValue("@beden", txt_thirt.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_tshirt.Value);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_tshirt.Text);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_tshirt_aksiyon.Value);



                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        //  MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (txt_celik_ayakkabi.Text != "" && cb_ayakkabi.Text != "")
                {
                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_kkd", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_turu", "ÇELİK AYAKKABI");
                        eklekomutu.Parameters.AddWithValue("@beden", txt_celik_ayakkabi.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_ayakkabi.Value);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_ayakkabi.Text);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_ayakkabi_aksiyon.Value);



                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        // MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (txt_is_eldiveni.Text != "" && cb_is_eldiveni.Text != "")
                {
                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_kkd", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_turu", "İŞ ELDİVENİ");
                        eklekomutu.Parameters.AddWithValue("@beden", txt_is_eldiveni.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_is_eldiveni.Value);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_is_eldiveni.Text);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_is_eldiveni_aksiyon.Value);



                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        // MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (txt_gozluk.Text != "" && cb_gozluk.Text != "")
                {
                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_kkd", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_turu", "GÖZLÜK");
                        eklekomutu.Parameters.AddWithValue("@beden", txt_gozluk.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_gozluk.Value);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_gozluk.Text);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_gozluk_aksiyon.Value);



                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        //  MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (txt_kulaklik.Text != "" && cb_kulaklık.Text != "")
                {
                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_kkd", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_turu", "KULAKLIK");
                        eklekomutu.Parameters.AddWithValue("@beden", txt_kulaklik.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_kulaklik.Value);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_kulaklık.Text);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_kulaklik_aksiyon.Value);



                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        //  MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (txt_maske.Text != "" && cb_maske.Text != "")
                {
                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_kkd", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_turu", "MASKE");
                        eklekomutu.Parameters.AddWithValue("@beden", txt_maske.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_maske.Value);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_maske.Text);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_maske_aksiyon.Value);



                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        // MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (txt_kaynak_gozluk.Text != "" && cb_kaynak_gozluk.Text != "")
                {
                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_kkd", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_turu", "KAYNAKÇI GÖZLÜĞÜ");
                        eklekomutu.Parameters.AddWithValue("@beden", txt_kaynak_gozluk.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_kaynak_gozluk.Value);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_kaynak_gozluk.Text);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_kaynak_gozluk_aksiyon.Value);



                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        //MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (txt_baret.Text != "" && cb_baret.Text != "")
                {
                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_kkd", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_turu", "BARET");
                        eklekomutu.Parameters.AddWithValue("@beden", txt_baret.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_baret.Value);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_baret.Text);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_baret_aksiyon.Value);



                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        // MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (txt_kaynak_eldiveni.Text != "" && cb_kaynak_eldiven.Text != "")
                {
                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_kkd", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_turu", "KAYNAKÇI ELDİVENİ");
                        eklekomutu.Parameters.AddWithValue("@beden", txt_kaynak_eldiveni.Text);
                        eklekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_kaynak_eldiveni.Value);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_kaynak_eldiven.Text);
                        eklekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_kaynak_eldiveni_aksiyon.Value);



                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        //  MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }

            }
            else
            {
                MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçirniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_formu_temizle_Click(object sender, EventArgs e)
        {
            ekrani_temizle();
        }

        //kayıtları güncelle
        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            bool guncelle = false;
            // baglantim.baglanti().Open();
            SqlCommand selectsorgu = new SqlCommand("select * from kkd where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                lbl_tc_no.ForeColor = Color.Red;
            else
                lbl_tc_no.ForeColor = Color.Black;

            //eğer aksiyon türüseçilir ise tarih zoruluolarak girilsin
            if (cb_is_yelek.Text != "Kullanımda" && cb_is_yelek.Text != "")
            {
                date_is_yelek_aksiyon.Enabled = true;
                date_is_yelek_aksiyon.Visible = true;
            }
            else
            {
                //  date_is_yelek_aksiyon.Enabled = false;
                date_is_yelek_aksiyon.Visible = false;
            }

            if (cb_polar.Text != "Kullanımda" && cb_polar.Text != "")
            {
                date_polar_aksiyon.Enabled = true;
                date_polar_aksiyon.Visible = true;
            }
            else
            {
                //   date_polar_aksiyon.Enabled = false;
                date_polar_aksiyon.Visible = false;
            }

            if (cb_tulum.Text != "Kullanımda" && cb_tulum.Text != "")
            {
                date_tulum_aksiyon.Enabled = true;
                date_tulum_aksiyon.Visible = true;
            }
            else
            {
                //   date_tulum_aksiyon.Enabled = false;
                date_tulum_aksiyon.Visible = false;
            }

            if (cb_pantolon.Text != "Kullanımda" && cb_pantolon.Text != "")
            {
                date_pantolon_aksiyon.Enabled = true;
                date_pantolon_aksiyon.Visible = true;
            }
            else
            {
                //    date_pantolon_aksiyon.Enabled = false;
                date_pantolon_aksiyon.Visible = false;
            }

            if (cb_tshirt.Text != "Kullanımda" && cb_tshirt.Text != "")
            {
                date_tshirt_aksiyon.Enabled = true;
                date_tshirt_aksiyon.Visible = true;
            }
            else
            {
                //   date_tshirt_aksiyon.Enabled = false;
                date_tshirt_aksiyon.Visible = false;
            }

            if (cb_ayakkabi.Text != "Kullanımda" && cb_ayakkabi.Text != "")
            {
                date_ayakkabi_aksiyon.Enabled = true;
                date_ayakkabi_aksiyon.Visible = true;
            }
            else
            {
                //   date_ayakkabi_aksiyon.Enabled = false;
                date_ayakkabi_aksiyon.Visible = false;
            }

            if (cb_is_eldiveni.Text != "Kullanımda" && cb_is_eldiveni.Text != "")
            {
                date_is_eldiveni_aksiyon.Enabled = true;
                date_is_eldiveni_aksiyon.Visible = true;
            }
            else
            {
                //   date_is_eldiveni_aksiyon.Enabled = false;
                date_is_eldiveni_aksiyon.Visible = false;
            }

            if (cb_gozluk.Text != "Kullanımda" && cb_gozluk.Text != "")
            {
                date_gozluk_aksiyon.Enabled = true;
                date_gozluk_aksiyon.Visible = true;
            }
            else
            {
                // date_gozluk_aksiyon.Enabled = false;
                date_gozluk_aksiyon.Visible = false;
            }

            if (cb_kulaklık.Text != "Kullanımda" && cb_kulaklık.Text != "")
            {
                date_kulaklik_aksiyon.Enabled = true;
                date_kulaklik_aksiyon.Visible = true;
            }
            else
            {
                //  date_kulaklik_aksiyon.Enabled = false;
                date_kulaklik_aksiyon.Visible = false;
            }

            if (cb_maske.Text != "Kullanımda" && cb_maske.Text != "")
            {
                date_maske_aksiyon.Enabled = true;
                date_maske_aksiyon.Visible = true;
            }
            else
            {
                // date_maske_aksiyon.Enabled = false;
                date_maske_aksiyon.Visible = false;
            }

            if (cb_kaynak_gozluk.Text != "Kullanımda" && cb_kaynak_gozluk.Text != "")
            {
                date_kaynak_gozluk_aksiyon.Enabled = true;
                date_kaynak_gozluk_aksiyon.Visible = true;
            }
            else
            {
                //   date_kaynak_gozluk_aksiyon.Enabled = false;
                date_kaynak_gozluk_aksiyon.Visible = false;
            }

            if (cb_baret.Text != "Kullanımda" && cb_baret.Text != "")
            {
                date_baret_aksiyon.Enabled = true;
                date_baret_aksiyon.Visible = true;
            }
            else
            {
                //  date_baret_aksiyon.Enabled = false;
                date_baret_aksiyon.Visible = false;

            }

            if (cb_kaynak_eldiven.Text != "Kullanımda" && cb_kaynak_eldiven.Text != "")
            {
                date_kaynak_eldiveni_aksiyon.Enabled = true;
                date_kaynak_eldiveni_aksiyon.Visible = true;
            }
            else
            {
                //  date_kaynak_eldiveni_aksiyon.Enabled = false;
                date_kaynak_eldiveni_aksiyon.Visible = false;
            }

            if (mtxt_tc_no.Text.Length == 11)
            {
                if (txt_is_yelegi.Text != "" && cb_is_yelek.Text != "")
                {
                    guncelle = true;
                    btn_guncelle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_kkd", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_turu", "İŞ YELEĞİ");
                        guncellekomutu.Parameters.AddWithValue("@beden", txt_is_yelegi.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_is_yelegi.Value);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_is_yelek.Text);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_is_yelek_aksiyon.Value);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_yelek.Text);


                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        //  MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (txt_polar.Text != "" && cb_polar.Text != "")
                {
                    guncelle = true;
                    btn_guncelle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_kkd", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_turu", "POLAR");
                        guncellekomutu.Parameters.AddWithValue("@beden", txt_polar.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_polar.Value);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_polar.Text);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_polar_aksiyon.Value);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_polar.Text);


                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        // MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde güncellenmiştir..", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (txt_tulum.Text != "" && cb_tulum.Text != "")
                {
                    guncelle = true;
                    btn_guncelle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_kkd", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_turu", "TULUM");
                        guncellekomutu.Parameters.AddWithValue("@beden", txt_tulum.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_tulum.Value);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_tulum.Text);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_tulum_aksiyon.Value);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_tulum.Text);


                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        // MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (txt_pantolun.Text != "" && cb_pantolon.Text != "")
                {
                    guncelle = true;
                    btn_guncelle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_kkd", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_turu", "PANTOLON");
                        guncellekomutu.Parameters.AddWithValue("@beden", txt_pantolun.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_pantolon.Value);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_pantolon.Text);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_pantolon_aksiyon.Value);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_pantolon.Text);


                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        // MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (txt_thirt.Text != "" && cb_tshirt.Text != "")
                {
                    guncelle = true;
                    btn_guncelle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_kkd", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_turu", "T-SHIRT");
                        guncellekomutu.Parameters.AddWithValue("@beden", txt_thirt.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_tshirt.Value);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_tshirt.Text);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_tshirt_aksiyon.Value);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_tshirt.Text);


                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        // MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (txt_celik_ayakkabi.Text != "" && cb_ayakkabi.Text != "")
                {
                    guncelle = true;
                    btn_guncelle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_kkd", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_turu", "ÇELİK AYAKKABI");
                        guncellekomutu.Parameters.AddWithValue("@beden", txt_celik_ayakkabi.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_ayakkabi.Value);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_ayakkabi.Text);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_ayakkabi_aksiyon.Value);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_ayakkabi.Text);


                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        //MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (txt_is_eldiveni.Text != "" && cb_is_eldiveni.Text != "")
                {
                    guncelle = true;
                    btn_guncelle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_kkd", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_turu", "İŞ ELDİVENİ");
                        guncellekomutu.Parameters.AddWithValue("@beden", txt_is_eldiveni.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_is_eldiveni.Value);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_is_eldiveni.Text);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_is_eldiveni_aksiyon.Value);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_is_eldiveni.Text);


                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        //  MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (txt_gozluk.Text != "" && cb_gozluk.Text != "")
                {
                    guncelle = true;
                    btn_guncelle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_kkd", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_turu", "GÖZLÜK");
                        guncellekomutu.Parameters.AddWithValue("@beden", txt_gozluk.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_gozluk.Value);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_gozluk.Text);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_gozluk_aksiyon.Value);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_gozluk.Text);


                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        // MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (txt_kulaklik.Text != "" && cb_kulaklık.Text != "")
                {
                    guncelle = true;
                    btn_guncelle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_kkd", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_turu", "KULAKLIK");
                        guncellekomutu.Parameters.AddWithValue("@beden", txt_kulaklik.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_kulaklik.Value);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_kulaklık.Text);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_kulaklik_aksiyon.Value);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_kulaklik.Text);


                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        // MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (txt_maske.Text != "" && cb_maske.Text != "")
                {
                    guncelle = true;
                    btn_guncelle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_kkd", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_turu", "MASKE");
                        guncellekomutu.Parameters.AddWithValue("@beden", txt_maske.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_maske.Value);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_maske.Text);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_maske_aksiyon.Value);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_maske.Text);


                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        // MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (txt_kaynak_gozluk.Text != "" && cb_kaynak_gozluk.Text != "")
                {
                    guncelle = true;
                    btn_guncelle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_kkd", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_turu", "KAYNAKÇI GÖZLÜĞÜ");
                        guncellekomutu.Parameters.AddWithValue("@beden", txt_kaynak_gozluk.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_kaynak_gozluk.Value);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_kaynak_gozluk.Text);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_kaynak_gozluk_aksiyon.Value);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_kaynak_gozluk.Text);


                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        /// MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (txt_baret.Text != "" && cb_baret.Text != "")
                {
                    guncelle = true;
                    btn_guncelle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_kkd", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_turu", "BARET");
                        guncellekomutu.Parameters.AddWithValue("@beden", txt_baret.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_baret.Value);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_baret.Text);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_baret_aksiyon.Value);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_baret.Text);


                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        //  MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (txt_kaynak_eldiveni.Text != "" && cb_kaynak_eldiven.Text != "")
                {
                    guncelle = true;
                    btn_guncelle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_kkd", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_turu", "KAYNAKÇI ELDİVENİ");
                        guncellekomutu.Parameters.AddWithValue("@beden", txt_kaynak_eldiveni.Text);
                        guncellekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_kaynak_eldiveni.Value);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_kaynak_eldiven.Text);
                        guncellekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_kaynak_eldiveni_aksiyon.Value);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_kaynak_eldiven.Text);


                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        listele();
                        /// MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }

                if (guncelle == true)
                {
                    MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }


            }
            else
            {
                MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçirniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //silme işlemi
        private void btn_sil_Click(object sender, EventArgs e)
        {

            if (mtxt_tc_no.Text.Length == 11)

            {
                bool sil = false;
                if (txt_is_yelegi.Text != "" && txt_id_yelek.Text != "")
                {
                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from kkd where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {



                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from kkd where TC='" + mtxt_tc_no.Text + "'and id='" + txt_id_yelek.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        //     MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        sil = true;
                        //ekrani_temizle();
                        listele();
                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if (txt_polar.Text != "" && txt_id_polar.Text != "")
                {

                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from kkd where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {


                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from kkd where TC='" + mtxt_tc_no.Text + "'and id='" + txt_id_polar.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        // MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        sil = true;
                        //ekrani_temizle();
                        listele();
                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if (txt_tulum.Text != "" && txt_id_tulum.Text != "")
                {
                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from kkd where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {


                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from kkd where TC='" + mtxt_tc_no.Text + "'and id='" + txt_id_tulum.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        // MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        sil = true;
                        //ekrani_temizle();
                        listele();
                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if (txt_pantolun.Text != "" && txt_id_pantolon.Text != "")
                {
                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from kkd where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {



                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from kkd where TC='" + mtxt_tc_no.Text + "'and id='" + txt_id_pantolon.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        //MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        sil = true;
                        //ekrani_temizle();
                        listele();
                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if (txt_thirt.Text != "" && txt_id_tshirt.Text != "")
                {

                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from kkd where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {



                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from kkd where TC='" + mtxt_tc_no.Text + "'and id='" + txt_id_tshirt.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        //MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        sil = true;

                        //ekrani_temizle();
                        listele();
                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if (txt_celik_ayakkabi.Text != "" && txt_id_ayakkabi.Text != "")
                {
                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from kkd where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {



                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from kkd where TC='" + mtxt_tc_no.Text + "'and id='" + txt_id_ayakkabi.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        //MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        sil = true;
                        //ekrani_temizle();
                        listele();
                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if (txt_is_eldiveni.Text != "" && txt_id_is_eldiveni.Text != "")
                {
                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from kkd where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {


                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from kkd where TC='" + mtxt_tc_no.Text + "'and id='" + txt_id_is_eldiveni.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        // MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        sil = true;
                        //ekrani_temizle();
                        listele();
                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if (txt_gozluk.Text != "" && txt_id_gozluk.Text != "")
                {
                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from kkd where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {


                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from kkd where TC='" + mtxt_tc_no.Text + "'and id='" + txt_id_gozluk.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        //MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        sil = true;

                        //ekrani_temizle();
                        listele();
                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if (txt_kulaklik.Text != "" && txt_id_kulaklik.Text != "")
                {
                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from kkd where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {


                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from kkd where TC='" + mtxt_tc_no.Text + "'and id='" + txt_id_kulaklik.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        // MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        sil = true;

                        //ekrani_temizle();
                        listele();
                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if (txt_maske.Text != "" && txt_id_maske.Text != "")
                {
                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from kkd where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {


                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from kkd where TC='" + mtxt_tc_no.Text + "'and id='" + txt_id_maske.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        //MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        sil = true;

                        //ekrani_temizle();
                        listele();
                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if (txt_kaynak_gozluk.Text != "" && txt_id_kaynak_gozluk.Text != "")
                {
                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from kkd where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {


                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from kkd where TC='" + mtxt_tc_no.Text + "'and id='" + txt_id_kaynak_gozluk.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        // MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        sil = true;

                        //ekrani_temizle();
                        listele();
                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if (txt_baret.Text != "" && txt_id_baret.Text != "")
                {
                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from kkd where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {


                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from kkd where TC='" + mtxt_tc_no.Text + "'and id='" + txt_id_baret.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        // MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        sil = true;
                        //ekrani_temizle();
                        listele();
                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if (txt_kaynak_eldiveni.Text != "" && txt_id_kaynak_eldiven.Text != "")
                {
                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from kkd where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {


                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from kkd where TC='" + mtxt_tc_no.Text + "'and id='" + txt_id_kaynak_eldiven.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        //MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        sil = true;

                        //ekrani_temizle();
                        listele();
                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

                if (sil == true)
                {
                    MessageBox.Show("Kullanıcının ilgili  kkd bilgisi başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                ekrani_temizle();


            }
            else
            {
                MessageBox.Show("TC kimlik no 11 haneli girilmelidir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }





        }

        private void cb_is_yelek_TextChanged(object sender, EventArgs e)
        {
            if (cb_is_yelek.Text == "Kullanımda")
                date_is_yelek_aksiyon.Visible = false;
            else
            {
                date_is_yelek_aksiyon.Enabled = true;
                date_is_yelek_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }
        }

        private void cb_polar_TextChanged(object sender, EventArgs e)
        {
            if (cb_polar.Text == "Kullanımda")
                date_polar_aksiyon.Visible = false;
            else
            {
                date_polar_aksiyon.Enabled = true;
                date_polar_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }
        }

        private void cb_tulum_TextChanged(object sender, EventArgs e)
        {
            if (cb_tulum.Text == "Kullanımda")
                date_tulum_aksiyon.Visible = false;
            else
            {
                date_tulum_aksiyon.Enabled = true;
                date_tulum_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }
        }

        private void cb_pantolon_TextChanged(object sender, EventArgs e)
        {
            if (cb_pantolon.Text == "Kullanımda")
                date_pantolon_aksiyon.Visible = false;
            else
            {
                date_pantolon_aksiyon.Enabled = true;
                date_pantolon_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }
        }

        private void cb_tshirt_TextChanged(object sender, EventArgs e)
        {
            if (cb_tshirt.Text == "Kullanımda")
                date_tshirt_aksiyon.Visible = false;
            else
            {
                date_tshirt_aksiyon.Enabled = true;
                date_tshirt_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }
        }

        private void cb_ayakkabi_TextChanged(object sender, EventArgs e)
        {
            if (cb_ayakkabi.Text == "Kullanımda")
                date_ayakkabi_aksiyon.Visible = false;
            else
            {
                date_ayakkabi_aksiyon.Enabled = true;
                date_ayakkabi_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }
        }

        private void cb_is_eldiveni_TextChanged(object sender, EventArgs e)
        {
            if (cb_is_eldiveni.Text == "Kullanımda")
                date_is_eldiveni_aksiyon.Visible = false;
            else
            {
                date_is_eldiveni_aksiyon.Enabled = true;
                date_is_eldiveni_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }
        }

        private void cb_gozluk_TextChanged(object sender, EventArgs e)
        {
            if (cb_gozluk.Text == "Kullanımda")
                date_gozluk_aksiyon.Visible = false;
            else
            {
                date_gozluk_aksiyon.Enabled = true;
                date_gozluk_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }
        }

        private void cb_kulaklık_TextChanged(object sender, EventArgs e)
        {
            if (cb_kulaklık.Text == "Kullanımda")
                date_kulaklik_aksiyon.Visible = false;
            else
            {
                date_kulaklik_aksiyon.Enabled = true;
                date_kulaklik_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }
        }

        private void cb_maske_TextChanged(object sender, EventArgs e)
        {
            if (cb_maske.Text == "Kullanımda")
                date_maske_aksiyon.Visible = false;
            else
            {
                date_maske_aksiyon.Enabled = true;
                date_maske_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }
        }

        private void cb_kaynak_gozluk_TextChanged(object sender, EventArgs e)
        {
            if (cb_kaynak_gozluk.Text == "Kullanımda")
                date_kaynak_gozluk_aksiyon.Visible = false;
            else
            {
                date_kaynak_gozluk_aksiyon.Enabled = true;
                date_kaynak_gozluk_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }
        }

        private void cb_baret_TextChanged(object sender, EventArgs e)
        {
            if (cb_baret.Text == "Kullanımda")
                date_baret_aksiyon.Visible = false;
            else
            {
                date_baret_aksiyon.Enabled = true;
                date_baret_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;
            }
        }

        private void cb_kaynak_eldiven_TextChanged(object sender, EventArgs e)
        {
            if (cb_kaynak_eldiven.Text == "Kullanımda")
                date_kaynak_eldiveni_aksiyon.Visible = false;
            else
            {
                date_kaynak_eldiveni_aksiyon.Enabled = true;
                date_kaynak_eldiveni_aksiyon.Visible = true;
                lbl_aksiyon_tarihi.Visible = true;

            }
        }

        private void btn_rapor_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xls":
                            gridControl2.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            gridControl2.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            gridControl2.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            gridControl2.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            gridControl2.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            gridControl2.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            //Try to open the file and let windows decide how to open it.
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "Dosya açılamadı." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "Dosya kaydedilemedi." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


    }
}
