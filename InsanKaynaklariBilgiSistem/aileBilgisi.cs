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
//system.text.regularExpression(regex) kütüphanesinin tanımlanması
using System.Text.RegularExpressions;//görevi güvenli paralo oluşturma için bu kütüphaneden yararlanılacak
//giriş çıkış işlemlerine ilişkşin kütüphanenin tanımlanması
using System.IO;//klasör oluşturma var olan klsörü sorguama için kullanılacak


namespace InsanKaynaklariBilgiSistem
{
    public partial class aileBilgisi : Form
    {
        public aileBilgisi()
        {
            InitializeComponent();
        }
        //veri tabanı doaya yoluve provider nesnesinin belirlenmesi
        sqlBaglantisi baglantim = new sqlBaglantisi();

        
        string cinsiyet = "";
        string yasamBilgisi = "YAŞIYOR.";
       
        string saglik_durumu, engel_durumu, calisma_durumu, mezuniyet_durumu, okul;
        string saglik_durumu_bakım = "", engel_durumu_bakim = "";
        public void listele_yakin_bilgileri()
        {
            SqlCommand sorgu = new SqlCommand("Listele_Yakin_Bilgileri", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sorgu);
            sorgu.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl3.DataSource = dt;
            gridView3.Columns["id"].Visible = false;

            gridView3.Columns["kisi_tc"].Caption = "TC NO";
            gridView3.Columns["yakinlik_derecesi"].Caption = "YAKINLIK DERECESİ";
            gridView3.Columns["yakin_adi_soyadi"].Caption = "ADI SOYADI";
            gridView3.Columns["yakin_cinsiyeti"].Caption = "CİNSİYETİ";
            gridView3.Columns["yakin_dogum_yeri"].Caption = "DOĞUM YERİ";
            gridView3.Columns["yakin_dogum_tarihi"].Caption = "DOĞUM TARİHİ";
            gridView3.Columns["yakin_yasam_bilgisi"].Caption = "SAĞ/ÖLÜ";
            gridView3.Columns["yakin_olum_tarihi"].Caption = "ÖLÜM TARİHİ";
            gridView3.Columns["yakin_olum_aciklamasi"].Caption = "ÖLÜM NEDENİ";
            gridView3.Columns["yakin_medeni_hali"].Caption = "MEDENİ HALİ";
            gridView3.Columns["yakin_kan_grubu"].Caption = "KAN GRUBU";
            gridView3.Columns["yakin_tel_no"].Caption = "TEEFON NUMARASI";
            gridView3.Columns["yakin_saglik_sorunu"].Caption = "SAĞLIK SORUNU";
            gridView3.Columns["yakin_saglik_aciklama"].Caption = "SAĞLIK SORUNU AÇIKLAMASI";
            gridView3.Columns["yakin_engel_durumu"].Caption = "ENGEL DURUMU";
            gridView3.Columns["yakin_engel_aciklama"].Caption = "ENGEL DURUMU AÇIKLAMASI";
            gridView3.Columns["yakin_çalisma_durumu"].Caption = "ÇALIŞMA DURUMU";
            gridView3.Columns["yakin_meslegi"].Caption = "MESLEĞİ";
            gridView3.Columns["yakin_geliri"].Caption = "GERLİRİ";
            gridView3.Columns["yakin_calistigi_yer"].Caption = "ÇALIŞTIĞI YER";
            gridView3.Columns["yakin_okul"].Caption = "OKUL BİLGİSİ";
            gridView3.Columns["yakin_okul_adi"].Caption = "OKULUN ADI";
            gridView3.Columns["yakin_ogrenim_duzeyi"].Caption = "ÖĞRENİM DÜZEYİ";
            gridView3.Columns["yakin_okul_bolumu"].Caption = "BÖLÜM";
            gridView3.Columns["yakin_okul_sinif"].Caption = "SINIF";
            gridView3.Columns["yakin_okul_sehir"].Caption = "ŞEHİR";
            gridView3.Columns["yakin_okul_giris_tarihi"].Caption = "GİRİŞ TARİHİ";
            gridView3.Columns["yakin_okul_durumu"].Caption = "DURUM";
            gridView3.Columns["yakin_okul_mezuniyet_tarihi"].Caption = "MEZUNİYET TARİHİ";
            gridView3.Columns["yakin_mezuniyet_derecesi"].Caption = "DERECE";
            gridView3.Columns["yakin_merasim_turu"].Caption = "MERASİM TÜRÜ";
            gridView3.Columns["yakin_merasim_tarihi"].Caption = "MERASM TARİHİ";
            gridView3.Columns["yakin_hobileri"].Caption = "HOBİLERİ";
        }
        public void listele_bakim()
        {
            SqlCommand sorgu2 = new SqlCommand("Listele_Bakim_Bilgileri", baglantim.baglanti());
            sorgu2.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da2 = new SqlDataAdapter(sorgu2);
            sorgu2.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
            gridView2.Columns["id"].Visible = false;
            gridView2.Columns["pdks"].Visible = false;

            gridView2.Columns["kisi_tc"].Caption = "TC NO";
            gridView2.Columns["adi_soyadi"].Caption = "ADI SOYADI";
            gridView2.Columns["dogum_yeri"].Caption = "DOĞUM YERİ";
            gridView2.Columns["dogum_tarihi"].Caption = "DOĞUM TARİHİ";
            gridView2.Columns["tel_no"].Caption = "TELEFON NUMARASI";
            gridView2.Columns["saglik_sorunu"].Caption = "SAĞLIK SORUNU DURUMU";
            gridView2.Columns["saglik_sorunu_aciklama"].Caption = "SAĞLIK SORUNU AÇIKLAMASI";
            gridView2.Columns["engel_durumu"].Caption = "ENGEL DURUMU";
            gridView2.Columns["engel_aciklama"].Caption = "ENGEL DURUMU AÇIKLAMASI";
            gridView2.Columns["geliri"].Caption = "GELİRİ";
            gridView2.Columns["bakim_yakini"].Caption = "YAKINLIK DERECESİ";
            gridView2.Columns["bakim_hobi"].Caption = "HOBİLERİ";

        }


        private void aileBilgisi_Load(object sender, EventArgs e)
        {

            txt_ad_soyad_yakin.CharacterCasing = CharacterCasing.Upper; //yakınının adı ve soyad
            txt_dogum_yeri.CharacterCasing = CharacterCasing.Upper; ;
            txt_olum_nedeni.CharacterCasing = CharacterCasing.Upper; ;//ölüm bilgisi
            txt_saglik_aciklama_yakin.CharacterCasing = CharacterCasing.Upper; ;
            txt_yakin_engel_aciklama.CharacterCasing = CharacterCasing.Upper; ;
            txt_yakin_meslek.CharacterCasing = CharacterCasing.Upper; ;

            txt_gelir_yakin.MaxLength = 8;
            txt_calistiği_yer.CharacterCasing = CharacterCasing.Upper; ;

            txt_okul_adi.CharacterCasing = CharacterCasing.Upper;
            txt_bolum.CharacterCasing = CharacterCasing.Upper;
            txt_sehir.CharacterCasing = CharacterCasing.Upper;
            txt_yakin_okul_derece.CharacterCasing = CharacterCasing.Upper;//düzeyi yani not durumu


            txt_bakim_yakin.CharacterCasing = CharacterCasing.Upper;

            txt_bakim_adsoyad.CharacterCasing = CharacterCasing.Upper;

            txt_bakim_dogum_yeri.CharacterCasing = CharacterCasing.Upper;

            txt_bakim_saglik_aciklama.CharacterCasing = CharacterCasing.Upper;

            txt_bakim_engel_aciklama.CharacterCasing = CharacterCasing.Upper;

            
            txt_bakim_maas.MaxLength = 8;


            mtxt_tc_no.Mask = "00000000000";//kullnıcı 11 haneli tc numarası girebilecek.
            mtxt_tel_no_yakin.Mask = "0000000000";//cep no
            mtxt_bakim_tel_no.Mask = "0000000000";//cep no

            

            //yakınlık bbilgileri
            cb_yakin.Items.Add("EŞi");
            cb_yakin.Items.Add("KIZI");
            cb_yakin.Items.Add("OĞLU");
            cb_yakin.Items.Add("ANNESİ");
            cb_yakin.Items.Add("BABASI");
            cb_yakin.Items.Add("KIZ KARDEŞİ");
            cb_yakin.Items.Add("ERKEK KARDEŞİ");

            //medeni hal
            cb_medinhal.Items.Add("Bekar");
            cb_medinhal.Items.Add("Evli");
            cb_medinhal.Items.Add("Boşanmış");
            //kan grubu
            cb_kangrubu.Items.Add("0(+)");
            cb_kangrubu.Items.Add("0(-)");
            cb_kangrubu.Items.Add("A(+)");
            cb_kangrubu.Items.Add("A(-)");
            cb_kangrubu.Items.Add("B(+)");
            cb_kangrubu.Items.Add("B(-)");
            cb_kangrubu.Items.Add("AB(+)");
            cb_kangrubu.Items.Add("AB(-)");
            cb_kangrubu.Items.Add("Bilinmiyor");

            //öğrenim düzeyi
            cb_duzey.Items.Add("Ana Okulu");
            cb_duzey.Items.Add("İlkokul");
            cb_duzey.Items.Add("Ortaokul");
            cb_duzey.Items.Add("Lise");
            cb_duzey.Items.Add("Üniversite");
            cb_duzey.Items.Add("YÜksek Lisans");
            cb_duzey.Items.Add("Doktora");


            //sınıf bilgisi
            cb_sinif.Items.Add("Hazırlık");
            cb_sinif.Items.Add("1");
            cb_sinif.Items.Add("2");
            cb_sinif.Items.Add("3");
            cb_sinif.Items.Add("4");
            cb_sinif.Items.Add("5");
            cb_sinif.Items.Add("6");
            cb_sinif.Items.Add("Mezun");
           
            //merasim türü
            cb_merasim.Items.Add("Düğün");
            cb_merasim.Items.Add("Asker");
            cb_merasim.Items.Add("Nişan");
            cb_merasim.Items.Add("Mezuniyet");


            DateTime zaman = DateTime.Now;
            int yil = int.Parse(zaman.ToString("yyyy"));
            int ay = int.Parse(zaman.ToString("MM"));
            int gun = int.Parse(zaman.ToString("dd"));

            //yakının doğum tarihi
            date_dogum_tarihi.MinDate = new DateTime(1900, 1, 1);
            date_dogum_tarihi.MaxDate = new DateTime(yil, ay, gun+1);



            //yakının ÖLÜM tarihi
            date_olum_tarihi.MinDate = new DateTime(1900, 1, 1);
            date_olum_tarihi.MaxDate = new DateTime(yil, ay, gun+1);

            //okulagiriş tarihi
            date_giris_tarihi.MinDate = new DateTime(1900, 1, 1);
            date_giris_tarihi.MaxDate = new DateTime(yil, ay, gun+1);


            //mezuniyet tarihi
            date_mezuniyet.MinDate = new DateTime(1900, 1, 1);
            date_mezuniyet.MaxDate = new DateTime(yil, ay, gun+1);

            //merasim tarihi
            date_merasim.MinDate = new DateTime(1900, 1, 1);
            date_merasim.MaxDate = new DateTime(yil + 20, 12, 31);


            //bakmakla yükümlü olduğu yakının doğum tarihi
            date_bakim_dogum.MinDate = new DateTime(1900, 1, 1);
            date_bakim_dogum.MaxDate = new DateTime(yil, ay, gun+1);


            lbl_olum_tarihi.Visible = false;
            date_olum_tarihi.Visible = false;
            lbl_olum_nedeni.Visible = false;
            txt_olum_nedeni.Visible = false;



            date_merasim.Visible = false;

           
            txt_yakin_meslek.Visible = false;
            txt_gelir_yakin.Visible = false;
            txt_calistiği_yer.Visible = false;
    

      


            //gridLookUpEdit1View.NewItemRowText =;
            panel1.Visible = false;
            



        }
        string hobiler = "";
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.CheckOnClick = true;
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                lbl_yakin_hobi.Text = "";
                hobiler = "";
                foreach (string title in checkedListBox1.CheckedItems)
                {
                    lbl_yakin_hobi.Text += " " + title + ", ";
                    hobiler += " " + title + ", ";



                }

            }
            else
            {
                hobiler = "";
            }
        }

        string bakımHobi = "";

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox2.CheckOnClick = true;
            if (checkedListBox2.CheckedItems.Count > 0)
            {
                lbl_bakim_hobi.Text = "";
                bakımHobi = "";
                foreach (string title in checkedListBox2.CheckedItems)
                {
                    lbl_bakim_hobi.Text += " " + title + ", ";
                    bakımHobi += " " + title + ", ";



                }
            }
            else
            {
                bakımHobi = "";
            }

        }
        
        
        private void ekrani_temizle()
        {
           
            txt_bakim_id.Text = string.Empty;
            txt_yakin_id.Text = string.Empty;
            mtxt_tc_no.Clear();
            txt_pdks.Text = string.Empty;
            txt_dogum_yeri.Clear();
            txt_ad_soyad_yakin.Clear();
            txt_olum_nedeni.Clear();
            txt_saglik_aciklama_yakin.Clear();
            txt_yakin_engel_aciklama.Clear();
            txt_yakin_meslek.Clear();
            txt_gelir_yakin.Clear();
            txt_calistiği_yer.Clear();
            txt_gelir_yakin.Clear();
            txt_calistiği_yer.Clear();
            txt_okul_adi.Clear();
            txt_bolum.Clear();
            txt_sehir.Clear();
            txt_yakin_okul_derece.Clear();
            txt_bakim_yakin.Clear();
            txt_bakim_adsoyad.Clear();
            txt_bakim_dogum_yeri.Clear();
            txt_bakim_saglik_aciklama.Clear();
            txt_bakim_engel_aciklama.Clear();
            txt_bakim_maas.Clear();
            mtxt_tc_no.Clear();
            mtxt_tel_no_yakin.Clear();
            mtxt_bakim_tel_no.Clear();
            cb_yakin.Text = string.Empty;
            cb_medinhal.Text = string.Empty;
            cb_kangrubu.Text = string.Empty;
            cb_duzey.Text = string.Empty;
            cb_sinif.Text = string.Empty;
            cb_merasim.Text = string.Empty;
            cb_yakin.Text = "";

            date_dogum_tarihi.ResetText();
            date_olum_tarihi.ResetText();
            date_giris_tarihi.ResetText();
            date_mezuniyet.ResetText();
            date_merasim.ResetText();
            date_bakim_dogum.ResetText();

            label3.Text = string.Empty;
            label5.Text = string.Empty;
            label22.Text = string.Empty;



            toggleSwitch_okul_durum.Reset();
            toggleSwitch_saglik_yakin.Reset();
            toggleSwitch_yakin_engel.Reset();
            toggleSwitch_yakin_calisma.Reset();
            toggleSwitch_bakim_engel.Reset();
            toggleSwitch_bakim_saglik.Reset();
            toggleSwitch_sag_olu.Reset();

            checkedListBox1.ClearSelected();
            checkedListBox2.ClearSelected();

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }

            lbl_yakin_hobi.Text = "";

            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, false);
            }

            lbl_bakim_hobi.Text = "";


        }

        public void yasam_bilgisi_togled(Boolean deger)
        {
            // kişi ölü ise bu bölümleri gözükmesin
            
            label23.Visible = deger;
            lbl_yakin_okul_giris_tarihi.Visible = deger;
            lbl_yakin_mezuniyet_tarihi.Visible = deger;
            lbl_yakin_medeni_hal.Visible = deger;

            cb_medinhal.Visible = deger;
            cb_kangrubu.Visible = deger;
            mtxt_tel_no_yakin.Visible = deger;
            toggleSwitch_saglik_yakin.Visible = deger;
            txt_saglik_aciklama_yakin.Visible = deger;
            toggleSwitch_yakin_engel.Visible = deger;
            txt_yakin_engel_aciklama.Visible = deger;
            toggleSwitch_yakin_calisma.Visible = deger;
            txt_yakin_meslek.Visible = deger;
            txt_gelir_yakin.Visible = deger;
            txt_calistiği_yer.Visible = deger;
            txt_okul_adi.Visible = deger;
            cb_duzey.Visible = deger;
            cb_sinif.Visible = deger;
            txt_bolum.Visible = deger;
            txt_sehir.Visible = deger;
            date_giris_tarihi.Visible = deger;
            toggleSwitch_okul_durum.Visible = deger;
            date_mezuniyet.Visible = deger;
            txt_yakin_okul_derece.Visible = deger;
            cb_merasim.Visible = deger;
            date_merasim.Visible = deger;
            checkedListBox1.Visible = deger;

            //şimdi de labelleri gizleyelim.

            //lbl_medeni_hal.Visible = false; //??//

            lbl_yakin_kan_grubu.Visible = lbl_yakin_tel_no.Visible = lbl_saglik_sorunu_durumu_yakin.Visible = deger;
            lbl_yakin_saglik_aciklama.Visible = lbl_engel_durum_yakin.Visible = lbl_engel_yakin_aciklama.Visible = deger;
            lbl_calisma_durumu_yakin.Visible = lbl_meslek_yakin.Visible = lbl_geliri_yakin.Visible = lbl_yakin_calistigi_yer.Visible = deger;
            lbl_yakin_okul_adi.Visible = lbl_yakin_okul_duzey.Visible = lbl_yakin_sinif.Visible = lbl_yakin_bolum.Visible = deger;
            lbl_yakin_sehir.Visible = date_giris_tarihi.Visible = lbl_yakin_okul_durum.Visible = date_mezuniyet.Visible = deger;
            lbl_yakin_okul_derece.Visible = lbl_yakin_merasim_turu.Visible = lbl_yakin_merasim_tarihi.Visible = lbl_yakin_hobi_secim.Visible = lbl_yakin_hobi.Visible = deger;


        }

      /*  public void bos()
        {
            cb_medinhal.Text = "";
            cb_kangrubu.Text = "";
            mtxt_tel_no_yakin.Text = "";
            toggleSwitch_saglik_yakin.Reset();
            txt_saglik_aciklama_yakin.Text = "";
            toggleSwitch_yakin_engel.Reset();
            txt_yakin_engel_aciklama.Text = "";
            toggleSwitch_yakin_calisma.Reset();
            txt_yakin_meslek.Text = "";
            txt_gelir_yakin.Text = "";
            txt_calistiği_yer.Text = "";
            txt_okul_adi.Text="";
            cb_duzey.Text="";
            cb_sinif.Text="";
            txt_bolum.Text="";
            txt_sehir.Text="";
            date_giris_tarihi.Text=null;
            toggleSwitch_okul_durum.Reset();
            date_mezuniyet.Text = null;
            txt_yakin_okul_derece.Text="";
            cb_merasim.Text="";
            date_merasim.Text=null;
            checkedListBox1.Text="";

            

            
        }*/

        //tc karakter kontrolü
        private void mtxt_tc_no_TextChanged(object sender, EventArgs e)
        {//tc kimlik no giriş kısmı için kısıtlamalar yazılacaktır.
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
                    label3.Text = kayitokuma.GetValue(2).ToString();//ad
                    label5.Text = kayitokuma.GetValue(3).ToString();//soyad
                    label22.Text = kayitokuma.GetValue(6).ToString();//medeni hali

                    break;

                }


            }
        }
              
        private void toggleSwitch_sag_olu_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch_sag_olu.IsOn != true)
            {
                lbl_olum_tarihi.Visible = false;
                date_olum_tarihi.Visible = false;
                lbl_olum_nedeni.Visible = false;
                txt_olum_nedeni.Visible = false;

                yasam_bilgisi_togled(true);
                yasamBilgisi = "YAŞIYOR.";
            }
            else
            {
                //pasif();
                lbl_olum_tarihi.Visible = true;
                date_olum_tarihi.Visible = true;
                lbl_olum_nedeni.Visible = true;
                txt_olum_nedeni.Visible = true;

                yasam_bilgisi_togled(false);
             //   bos();
                yasamBilgisi = "ÖLDÜ.";
            }

        }

        private void txt_gelir_yakin_KeyPress(object sender, KeyPressEventArgs e)
        {//sadece sayı girişiyapılabilsin
            e.Handled =! char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
     
        }
        private void txt_pdks_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        //ekranda kayıtların görünmesi-yakın bilgileri
        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            txt_yakin_id.Text = gridView3.GetFocusedRowCellValue("id").ToString();
            mtxt_tc_no.Text = gridView3.GetFocusedRowCellValue("kisi_tc").ToString();
            cb_yakin.Text = gridView3.GetFocusedRowCellValue("yakinlik_derecesi").ToString();
            txt_ad_soyad_yakin.Text = gridView3.GetFocusedRowCellValue("yakin_adi_soyadi").ToString();
            cinsiyet = gridView3.GetFocusedRowCellValue("yakin_cinsiyeti").ToString();
            txt_dogum_yeri.Text = gridView3.GetFocusedRowCellValue("yakin_dogum_yeri").ToString();
            date_dogum_tarihi.Text = gridView3.GetFocusedRowCellValue("yakin_dogum_tarihi").ToString();


            if (gridView3.GetFocusedRowCellValue("yakin_yasam_bilgisi").ToString() == "YAŞIYOR.")
            {
                toggleSwitch_sag_olu.IsOn = false;
            }
            else
                toggleSwitch_sag_olu.IsOn = true;

            date_olum_tarihi.Text = gridView3.GetFocusedRowCellValue("yakin_olum_tarihi").ToString();

            txt_olum_nedeni.Text = gridView3.GetFocusedRowCellValue("yakin_olum_aciklamasi").ToString();
            cb_medinhal.Text = gridView3.GetFocusedRowCellValue("yakin_medeni_hali").ToString();
            cb_kangrubu.Text = gridView3.GetFocusedRowCellValue("yakin_kan_grubu").ToString();
            mtxt_tel_no_yakin.Text = gridView3.GetFocusedRowCellValue("yakin_tel_no").ToString();

            if (gridView3.GetFocusedRowCellValue("yakin_saglik_sorunu").ToString() == "Bir sağlık sorunu vardır.")
            {
                toggleSwitch_saglik_yakin.IsOn = true;
            }
            else
                toggleSwitch_saglik_yakin.IsOn = false;


            txt_saglik_aciklama_yakin.Text = gridView3.GetFocusedRowCellValue("yakin_saglik_aciklama").ToString();

            if (gridView3.GetFocusedRowCellValue("yakin_engel_durumu").ToString() == "Bir engeli vardır.")
                toggleSwitch_yakin_engel.IsOn = true;
            else
                toggleSwitch_yakin_engel.IsOn = false;

            txt_yakin_engel_aciklama.Text = gridView3.GetFocusedRowCellValue("yakin_engel_aciklama").ToString();

            if (gridView3.GetFocusedRowCellValue("yakin_çalisma_durumu").ToString() == "Çalışıyor")
                toggleSwitch_yakin_calisma.IsOn = true;
            else
                toggleSwitch_yakin_calisma.IsOn = false;

            txt_yakin_meslek.Text = gridView3.GetFocusedRowCellValue("yakin_meslegi").ToString();
            txt_gelir_yakin.Text = gridView3.GetFocusedRowCellValue("yakin_geliri").ToString();
            txt_calistiği_yer.Text = gridView3.GetFocusedRowCellValue("yakin_calistigi_yer").ToString();
            txt_okul_adi.Text = gridView3.GetFocusedRowCellValue("yakin_okul_adi").ToString();
            cb_duzey.Text = gridView3.GetFocusedRowCellValue("yakin_ogrenim_duzeyi").ToString();
            txt_bolum.Text = gridView3.GetFocusedRowCellValue("yakin_okul_bolumu").ToString();
            cb_sinif.Text = gridView3.GetFocusedRowCellValue("yakin_okul_sinif").ToString();
            txt_sehir.Text = gridView3.GetFocusedRowCellValue("yakin_okul_sehir").ToString();
            date_giris_tarihi.Text = gridView3.GetFocusedRowCellValue("yakin_okul_giris_tarihi").ToString();

            if (gridView3.GetFocusedRowCellValue("yakin_okul_durumu").ToString() == "Mezun")
                toggleSwitch_okul_durum.IsOn = true;
            else
                toggleSwitch_okul_durum.IsOn = false;

            date_mezuniyet.Text = gridView3.GetFocusedRowCellValue("yakin_okul_mezuniyet_tarihi").ToString();
            txt_yakin_okul_derece.Text = gridView3.GetFocusedRowCellValue("yakin_mezuniyet_derecesi").ToString();
            cb_merasim.Text = gridView3.GetFocusedRowCellValue("yakin_merasim_turu").ToString();
            date_merasim.Text = gridView3.GetFocusedRowCellValue("yakin_merasim_tarihi").ToString();
            string hobilerr = gridView3.GetFocusedRowCellValue("yakin_hobileri").ToString();
            lbl_yakin_hobi.Text = hobilerr;
            for (int count = 0; count < checkedListBox1.Items.Count; count++)
            {
                if (hobilerr.Contains(checkedListBox1.Items[count].ToString()))
                {
                    checkedListBox1.SetItemChecked(count, true);
                }
                else
                {
                    checkedListBox1.SetItemChecked(count, false);
                }
            }

            btn_guncelle.Enabled = true;
            simpleButton1.Enabled = true;
            btn_sil.Enabled = true;
        }


        //ekranda kayıtların görünmesi-bakım bilgileri
        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            
            txt_bakim_yakin.Text = gridView2.GetFocusedRowCellValue("bakim_yakini").ToString();
            mtxt_tc_no.Text = gridView2.GetFocusedRowCellValue("kisi_tc").ToString();
            txt_bakim_adsoyad.Text = gridView2.GetFocusedRowCellValue("adi_soyadi").ToString();
            txt_bakim_dogum_yeri.Text = gridView2.GetFocusedRowCellValue("dogum_yeri").ToString();
            date_bakim_dogum.Text = gridView2.GetFocusedRowCellValue("dogum_tarihi").ToString();
            mtxt_bakim_tel_no.Text = gridView2.GetFocusedRowCellValue("tel_no").ToString();

            if (gridView2.GetFocusedRowCellValue("saglik_sorunu").ToString() == "Bir sağlık problemi vardır.")
                toggleSwitch_bakim_saglik.IsOn = true;
            else
                toggleSwitch_bakim_saglik.IsOn = false;

            txt_bakim_saglik_aciklama.Text = gridView2.GetFocusedRowCellValue("saglik_sorunu_aciklama").ToString();

            if (gridView2.GetFocusedRowCellValue("engel_durumu").ToString() == "Bir engel durumu söz konusudur.")
                toggleSwitch_bakim_engel.IsOn = true;
            else
                toggleSwitch_bakim_engel.IsOn = false;

            txt_bakim_engel_aciklama.Text = gridView2.GetFocusedRowCellValue("engel_aciklama").ToString();
            txt_bakim_maas.Text = gridView2.GetFocusedRowCellValue("geliri").ToString();

            string bakim_hobilers = gridView2.GetFocusedRowCellValue("bakim_hobi").ToString();
            lbl_bakim_hobi.Text = bakim_hobilers;
            for (int count = 0; count < checkedListBox2.Items.Count; count++)
            {
                if (bakim_hobilers.Contains(checkedListBox2.Items[count].ToString()))
                {
                    checkedListBox2.SetItemChecked(count, true);
                }
                else
                {
                    checkedListBox2.SetItemChecked(count, false);
                }
            }

            txt_bakim_id.Text = gridView2.GetFocusedRowCellValue("id").ToString();

            btn_guncelle.Enabled = true;
            simpleButton1.Enabled = true;
            btn_sil.Enabled = true;

        }

        
        //simpleButton5 =ara butonu
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            //tck yazılarak veri tablosundaki veri araştırılır
            bool kayit_arama_durumu = false;//kayıdın olup olmadığını değerlendirecektir.
            if (mtxt_tc_no.Text.Length == 11||txt_pdks.Text!="")
            {  //tck 11 hane olarak yazıldı ise arama yapılabilecek aksi taktirde arama yapmaya gerek yok zaten.
                
                SqlCommand selectsorgu = new SqlCommand("kisi_arama", baglantim.baglanti());
                selectsorgu.CommandType = CommandType.StoredProcedure;

                selectsorgu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                selectsorgu.Parameters.AddWithValue("@pdks",txt_pdks.Text);


                SqlDataReader kayitokuma = selectsorgu.ExecuteReader();

                //kayıtokumanın içerisne attığımız değişkenin while döngüsü ile tüm veri tabanında arayalım.
                while (kayitokuma.Read())
                {   //kayıt var ise buradan true dönecek.
                    kayit_arama_durumu = true;

                    if (mtxt_tc_no.Text != "")
                        txt_pdks.Text = kayitokuma.GetValue(19).ToString();
                    else if (txt_pdks.Text != "")
                        mtxt_tc_no.Text = kayitokuma.GetValue(1).ToString();
                    else if(mtxt_tc_no.Text!="" && txt_pdks.Text!="")
                    {
                        SqlCommand selectsorguiki = new SqlCommand("select *from Kisi where TC='" + mtxt_tc_no.Text  + "'", baglantim.baglanti());
                        SqlDataReader kayitokumaiki = selectsorgu.ExecuteReader();
                        
                        while (kayitokumaiki.Read())
                        {
                           
                            string gelen;
                            gelen = kayitokumaiki.GetValue(19).ToString();
                            if(gelen!=txt_pdks.Text)
                            {
                                txt_pdks.Text = kayitokumaiki.GetValue(19).ToString();
                            }

                        }
                    }


                    label3.Text = kayitokuma.GetValue(2).ToString();//ilgili tck ait değerin veritabanındaki tck getirilecek. veri tabanı 0,1,2,.. diye gider.
                    label5.Text = kayitokuma.GetValue(3).ToString();//ad
                    label22.Text = kayitokuma.GetValue(6).ToString();//soyad
                  
                    
                    btn_guncelle.Enabled = true;
                    simpleButton1.Enabled = true;
                    btn_sil.Enabled = true;


                    break;


                }
               
                //eğer kayıt okuma durumu gerçekleşmemiş ise kayıt bulunamadı ise
                if (kayit_arama_durumu == false)
                {
                    MessageBox.Show("Arama kayıtı bulunamadı", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btn_guncelle.Enabled = false;
                    simpleButton1.Enabled = false;
                    btn_sil.Enabled = false;
                }
                
            }
            else
            {
                //girilen tc no 11karakter değilse
                MessageBox.Show("Lütfen 11 haneli TC veya geçerli bir pdks giriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ekrani_temizle();
            }
            listele_bakim();
            listele_yakin_bilgileri();
        }

        private void toggleSwitch_saglik_yakin_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch_saglik_yakin.IsOn == true)
            {
                txt_saglik_aciklama_yakin.Visible = true;
                txt_saglik_aciklama_yakin.Enabled = true;
            }
            else
            {
                txt_saglik_aciklama_yakin.Enabled = false;
            }
        }

        private void txt_okul_adi_TextChanged(object sender, EventArgs e)
        {
            cb_duzey.Visible = true;
            cb_sinif.Visible = true;
            txt_bolum.Visible = true;
            txt_sehir.Visible = true;
            date_giris_tarihi.Visible = true;
            toggleSwitch_okul_durum.Visible = true;

            cb_duzey.Enabled = true;
            cb_sinif.Enabled = true;
            txt_bolum.Enabled = true;
            txt_sehir.Enabled = true;
            date_giris_tarihi.Enabled = true;
            toggleSwitch_okul_durum.Enabled = true;
        }

        private void toggleSwitch_yakin_engel_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch_yakin_engel.IsOn == true)
            {
                txt_yakin_engel_aciklama.Enabled = true;
                txt_yakin_engel_aciklama.Visible = true;
            }
            else
            {
                txt_yakin_engel_aciklama.Enabled = false;
            }
        }

        private void toggleSwitch_yakin_calisma_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch_yakin_calisma.IsOn == true)
            {
                txt_yakin_meslek.Visible = true;
                txt_calistiği_yer.Visible = true;
                txt_gelir_yakin.Visible = true;

                txt_yakin_meslek.Enabled = true;
                txt_calistiği_yer.Enabled = true;
                txt_gelir_yakin.Enabled = true;
            }
            else
            {
                txt_yakin_meslek.Enabled = false;
                txt_calistiği_yer.Enabled = false;
                txt_gelir_yakin.Enabled = false;
            }
        }

        private void cb_merasim_TextChanged(object sender, EventArgs e)
        {
            if (cb_merasim.Text == "")
            {
                date_merasim.Visible = false;
            }
            else
            {
                date_merasim.Visible = true;
                date_merasim.Enabled = true;
            }
        }

        private void toggleSwitch_bakim_saglik_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch_bakim_saglik.IsOn == true)
            {
                txt_bakim_saglik_aciklama.Visible = true;
                txt_bakim_saglik_aciklama.Enabled = true;
            }
            else
            {
                txt_bakim_saglik_aciklama.Enabled = false;
            }
        }

        private void toggleSwitch_bakim_engel_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch_bakim_engel.IsOn == true)
            {
                txt_bakim_engel_aciklama.Visible = true;
                txt_bakim_engel_aciklama.Enabled = true;
            }
            else
            {
                txt_bakim_engel_aciklama.Enabled = false;
            }
        }

        //formu temizle butonu
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            ekrani_temizle();
        }

        private void txt_bakim_yakin_TextChanged(object sender, EventArgs e)
        {
            txt_bakim_adsoyad.Enabled = true;
            txt_bakim_dogum_yeri.Enabled = true;
            date_bakim_dogum.Enabled = true;
            mtxt_bakim_tel_no.Enabled = true;
            toggleSwitch_bakim_saglik.Enabled = true;
            //txt_bakim_saglik_aciklama.Enabled = true;
            toggleSwitch_bakim_engel.Enabled = true;
            //txt_bakim_engel_aciklama.Enabled = true;
            txt_bakim_maas.Enabled = true;
            checkedListBox2.Enabled = true;
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11)

            {
                bool kayit_arama_yakin = false;
                bool yakin_sorgula_bool = false;

                if (txt_yakin_id.Text != "")
                {
                    SqlCommand YakinsecmeSorgusu = new SqlCommand("Select *from Kisi_Yakini_Bilgileri where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokumayakin = YakinsecmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokumayakin.Read())
                    {

                        //kayıt okuma gerçekleşti ise
                        kayit_arama_yakin = true;
                        SqlCommand YakinSilsorgusu = new SqlCommand("delete from Kisi_Yakini_Bilgileri where kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_yakin_id.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        SqlCommand Yakinsorgula = new SqlCommand("select * from Kisi_Yakini_Bilgileri where kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_yakin_id.Text + "'", baglantim.baglanti());
                        SqlDataReader yakin_sorgula = Yakinsorgula.ExecuteReader();
                        while (yakin_sorgula.Read())
                        {
                            
                            yakin_sorgula_bool = true;

                            YakinSilsorgusu.ExecuteNonQuery();
                            MessageBox.Show("Kullanıcının igili yakınının kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        yakin_sorgula.Close();

                        //  ekrani_temizle();
                      
                        break;
                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_yakin == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Lütfen 11 haneli TC veya geçerli bir pdks giriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                listele_yakin_bilgileri();
               // ekrani_temizle();
                if (txt_bakim_id.Text!= "")
                {
                    bool kayit_arama_bakim = false;
                    bool bakim_sorgula_bool = false;
                    SqlCommand secmeSorgusuBakim = new SqlCommand("Select *from Kisi_Bakmakla_Yukumlu where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokumabakim = secmeSorgusuBakim.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokumabakim.Read())
                    {
                        //kayıt okuma gerçekleşti ise
                        kayit_arama_bakim = true;

                        SqlCommand BakimSilsorgusu = new SqlCommand("delete from Kisi_Bakmakla_Yukumlu where kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_bakim_id.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 


                        SqlCommand Bakimsorgula = new SqlCommand("select * from Kisi_Bakmakla_Yukumlu where kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_bakim_id.Text + "'", baglantim.baglanti());
                        SqlDataReader bakim_sorgula = Bakimsorgula.ExecuteReader();
                        while (bakim_sorgula.Read())
                        {
                          

                            bakim_sorgula_bool = true;

                            BakimSilsorgusu.ExecuteNonQuery();
                            MessageBox.Show("Kullanıcının igili yakınının kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        bakim_sorgula.Close();

                        // ekrani_temizle();
                       
                        break;
                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_bakim == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Yakını ile ilgili böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                ekrani_temizle();

            }
            else
            {
                MessageBox.Show("Lütfen 11 haneli TC veya geçerli bir pdks giriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ekrani_temizle();
            listele_bakim();
            

        }

        private void toggleSwitch_okul_durum_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch_okul_durum.IsOn != true) //on = mezun
            {
                panel1.Visible = false; //load da da false olmalı..
            }
            else
            {
                panel1.Visible = true;

                date_mezuniyet.Enabled = true;
                lbl_yakin_mezuniyet_tarihi.Enabled = true;
                lbl_yakin_okul_derece.Enabled = true;
                txt_yakin_okul_derece.Enabled = true;
            }
        }
                
        //forma ekle
        private void simpleButton7_Click(object sender, EventArgs e)
        {//bu kısım için veri tabanında ad soyad için bir arama yapılması gerektedir.

            bool kayitkontrol = false;//bir kayıt yaparken daha önceden böyle bir kullanıcı var mı diye kontrolü yapılacak
                                      //////baglantim.baglanti().Open();
            SqlCommand selectsorgu = new SqlCommand("select * from Kisi_Yakini_Bilgileri where kisi_tc='" + mtxt_tc_no.Text + "' and yakin_adi_soyadi='" + txt_ad_soyad_yakin.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.
                                                                   //ilgili tc no ya ait vb de kayıt vamı diye kontrol edelim.

            while (kayitokuma.Read())
            {
                kayitkontrol = true;//ilgili tc noya ait bir kullanıcı var demektir.
                break;

            }
            //baglantim.baglanti().Close();

                if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                    lbl_tc_no.ForeColor = Color.Red;
                else
                    lbl_tc_no.ForeColor = Color.Black;

                //yakını bilgisi
                if (cb_yakin.Text != "")//herhangi bir yakını seçildi ise
                {
                    //adı soyadı
                    if (txt_ad_soyad_yakin.Text == "" || txt_ad_soyad_yakin.Text.Length < 2)

                        lbl_yakin_ad_soyad.ForeColor = Color.Red;
                    else
                        lbl_yakin_ad_soyad.ForeColor = Color.Black;

                    if (radioButton_bay.Checked == true)
                        cinsiyet = "BAY";
                    else if (radioButton_bayan.Checked == true)
                        cinsiyet = "BAYAN";

                    //doğum yeri
                    if (txt_dogum_yeri.Text == "" || txt_dogum_yeri.Text.Length < 2)
                        lbl_yakin_dogum_yeri.ForeColor = Color.Red;
                    else
                        lbl_yakin_dogum_yeri.ForeColor = Color.Black;
                    

                    if(toggleSwitch_sag_olu.IsOn!=true)//yaşıyor ise

                    {
                        yasamBilgisi = "YAŞIYOR.";
                        //medeni hali
                        if (cb_medinhal.Text == "")
                            lbl_yakin_medeni_hal.ForeColor = Color.Red;
                        else
                            lbl_yakin_medeni_hal.ForeColor = Color.Black;

                        //kangrubu
                        if (cb_kangrubu.Text == "")
                            lbl_yakin_kan_grubu.ForeColor = Color.Red;
                        else
                            lbl_yakin_kan_grubu.ForeColor = Color.Black;

                        //telefonnumarası
                        if (mtxt_tel_no_yakin.Text == "")
                            lbl_yakin_tel_no.ForeColor = Color.Red;
                        else
                            lbl_yakin_tel_no.ForeColor = Color.Black;

                        //sağlık açıklaması yazılmalıdır.
                        if (toggleSwitch_saglik_yakin.IsOn == true)
                        {
                            saglik_durumu = "Bir sağlık sorunu vardır.";
                           
                            txt_saglik_aciklama_yakin.Visible = true;
                            txt_saglik_aciklama_yakin.Enabled = true;

                            if (txt_saglik_aciklama_yakin.Text == "")

                            { lbl_yakin_saglik_aciklama.ForeColor = Color.Red; }
                                                    
                        }

                        else
                        {
                            
                            lbl_yakin_saglik_aciklama.ForeColor = Color.Black;
                            txt_saglik_aciklama_yakin.Enabled = false;
                            saglik_durumu = "Bir sağlık sorunu yoktur.";

                        }

                        //engeli var ise  açıklaması yazılmalıdır.
                        if (toggleSwitch_yakin_engel.IsOn == true)
                        {
                            if (txt_yakin_engel_aciklama.Text == "")
                                lbl_engel_yakin_aciklama.ForeColor = Color.Red;
                            txt_yakin_engel_aciklama.Enabled = true;
                            engel_durumu = "Bir engeli vardır.";
                        }

                        else
                        {
                            lbl_engel_yakin_aciklama.ForeColor = Color.Black;
                            txt_yakin_engel_aciklama.Enabled = false;
                            engel_durumu = "Bir engeli yoktur.";
                        }

                        //çalışma durumu var ise  açıklaması yazılmalıdır.
                        if (toggleSwitch_yakin_calisma.IsOn == true)
                        {
                            calisma_durumu = "Çalışıyor.";
                            //mesleği
                            if (txt_yakin_meslek.Text == "")
                                lbl_meslek_yakin.ForeColor = Color.Red;
                            else
                                lbl_meslek_yakin.ForeColor = Color.Black;

                            //geliri
                            if (txt_gelir_yakin.Text == "")
                                lbl_geliri_yakin.ForeColor = Color.Red;
                            else
                                lbl_geliri_yakin.ForeColor = Color.Black;

                            //çalıştığı yer
                            if (txt_calistiği_yer.Text == "" && txt_calistiği_yer.Text.Length < 2)
                            {
                                lbl_yakin_calistigi_yer.ForeColor = Color.Red;
                               
                            }
                            else
                                lbl_yakin_calistigi_yer.ForeColor = Color.Black;
                        }
                        else
                        {
                            calisma_durumu = "Çalışmıyor.";
                            txt_yakin_meslek.Enabled = false;
                            txt_gelir_yakin.Enabled = false;
                            txt_calistiği_yer.Enabled = false;
                        }



                        //okul bilgisi
                        if (txt_okul_adi.Text != "" && txt_okul_adi.Text.Length > 2)
                        {//okul adı kısmına herhangi birşey yazılır ise
                            okul = "VAR";
                            //öğrenim düzeyiseçilmeli
                            if (cb_duzey.Text == "")

                                lbl_yakin_okul_duzey.ForeColor = Color.Red;
                            else
                                lbl_yakin_okul_duzey.ForeColor = Color.Black;

                            //sınıf seçmeli
                            if (cb_sinif.Text == "")
                                lbl_yakin_sinif.ForeColor = Color.Red;
                            else
                                lbl_yakin_sinif.ForeColor = Color.Black;


                            //eğer üniversite veya lise düzeyi ise bölüm bilgisi seçilsin
                            if (cb_duzey.Text == "Lise" || cb_duzey.Text == "Üniversite" || cb_duzey.Text == "Yüksek Lisans" || cb_duzey.Text == "Doktora")
                            {
                                if (txt_bolum.Text == "")
                                    lbl_yakin_bolum.ForeColor = Color.Red;
                                else
                                    lbl_yakin_bolum.ForeColor = Color.Black;
                            }
                            else
                                txt_bolum.Enabled = false;

                            //okuduğu şehir seçilmeli
                            if (txt_sehir.Text == "")
                                lbl_yakin_sehir.ForeColor = Color.Red;
                            else
                                lbl_yakin_sehir.ForeColor = Color.Black;

                            //mezun mu eğer mezun ise mezuniyet tarihi girilmeli değil ise girememeli
                            if (toggleSwitch_okul_durum.IsOn == true)
                            {
                                mezuniyet_durumu = "Mezun";
                                date_mezuniyet.Enabled = true;
                                if (txt_yakin_okul_derece.Text == "")
                                    lbl_yakin_okul_derece.ForeColor = Color.Red;
                                else
                                    lbl_yakin_okul_derece.ForeColor = Color.Black;
                            }
                            else
                            {
                                mezuniyet_durumu = "Okuyor";
                                date_mezuniyet.Enabled = false;
                                lbl_yakin_okul_derece.Enabled = false;
                            }
                        }
                        else
                        {
                        okul = "YOK";
                        cb_duzey.Enabled = false;
                        cb_sinif.Enabled = false;
                        txt_bolum.Enabled = false;
                        txt_sehir.Enabled = false;
                        date_giris_tarihi.Enabled = false;
                        toggleSwitch_okul_durum.Enabled = false;
                        date_mezuniyet.Enabled = false;
                        txt_yakin_okul_derece.Enabled = false;
                        mezuniyet_durumu = "YOK";

                    }

                        //kişi için planlanan herhangi bir mearsim etkinlik var mıdır. varsa tarihi
                        if (cb_merasim.Text != "")
                        {
                            date_merasim.Enabled = true;
                        }
                        else
                            date_merasim.Enabled = false;

                    }
                    else
                    {
                        yasamBilgisi = "ÖLDÜ.";
                        lbl_olum_tarihi.Visible = true;
                        date_olum_tarihi.Visible = true;
                        lbl_olum_nedeni.Visible = true;
                        txt_olum_nedeni.Visible = true;

                        yasam_bilgisi_togled(false);
                    }
                }
                

                //herhangi bir bakım bilgisi girecek ise bu kısım çalışacakktır.
                if (txt_bakim_yakin.Text != "")
                {
                //baktığı kişinin adı soyadı olmalı
                if (txt_bakim_adsoyad.Text == "")
                    lbl_bakim_adsoyad.ForeColor = Color.Red;
                else
                    lbl_bakim_adsoyad.ForeColor = Color.Black;

                //baktığı kişinin doğum yeri olmalı
                if (txt_bakim_dogum_yeri.Text == "")
                    lbl_bakim_dogum_yeri.ForeColor = Color.Red;
                else
                    lbl_bakim_dogum_yeri.ForeColor = Color.Black;

                if (toggleSwitch_bakim_saglik.IsOn == true)
                    {

                    saglik_durumu_bakım = "Bir sağlık problemi vardır.";
                    //herhangi bir şağlık sorunu var ise açıklama yazsın yoksa yazmasın
                    if (txt_bakim_saglik_aciklama.Text == "")
                    {
                        lbl_bakim_saglik_aciklama.ForeColor = Color.Red;
                    }
                    else
                    {
                        lbl_bakim_saglik_aciklama.ForeColor = Color.Black;

                    }

                }
                    else
                    {
                        saglik_durumu_bakım = "Bir sağlık problemi yoktur.";
                        lbl_bakim_saglik_aciklama.ForeColor = Color.Black;
                        txt_bakim_saglik_aciklama.Enabled = false;
                    }

                    //engel durmunu sorgulayalım.
                    if (toggleSwitch_bakim_engel.IsOn == true)
                    {
                    engel_durumu_bakim = "Bir engel durumu söz konusudur.";
                    //herhangi bir engeli var ise açıklama yazsın yoksa yazmasın
                    if (txt_bakim_engel_aciklama.Text == "")
                    {
                        lbl_bakim_engel_aciklama.ForeColor = Color.Red;
                    }
                    else
                    {
                        lbl_bakim_engel_aciklama.ForeColor = Color.Black;

                    }

                }
                    else
                    {
                        engel_durumu_bakim = "Bir engel durumu yoktur.";
                        lbl_bakim_engel_aciklama.ForeColor = Color.Black;
                        txt_bakim_engel_aciklama.Enabled = false;
                    }


                }

                else
                {
                txt_bakim_adsoyad.Enabled = false;
                txt_bakim_dogum_yeri.Enabled = false;
                date_bakim_dogum.Enabled = false;
                mtxt_bakim_tel_no.Enabled = false;
                toggleSwitch_bakim_saglik.Enabled = false;
                txt_bakim_saglik_aciklama.Enabled = false;
                toggleSwitch_bakim_engel.Enabled = false;
                txt_bakim_engel_aciklama.Enabled = false;
                txt_bakim_maas.Enabled = false;
                checkedListBox2.Enabled = false;

            }

                //şimdiye kadar alanların zorunlulukları belirlendi sıra geldi forma ekleme işlemine

                if (mtxt_tc_no.Text.Length == 11)
                {
                    if (cb_yakin.Text != ""&&txt_ad_soyad_yakin.Text!="")//herhangi bir yakını eklenir ise
                    {
                                               
                            try
                            {

                        SqlCommand eklekomutuyakin = new SqlCommand("Kaydet_Yakini_Bilgisi", baglantim.baglanti());
                        eklekomutuyakin.CommandType = CommandType.StoredProcedure;

                        eklekomutuyakin.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                        eklekomutuyakin.Parameters.AddWithValue("@yakinlik_derecesi", cb_yakin.Text);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_adi_soyadi", txt_ad_soyad_yakin.Text);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_cinsiyeti", cinsiyet);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_dogum_yeri", txt_dogum_yeri.Text);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_dogum_tarihi", date_dogum_tarihi.Value);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_yasam_bilgisi", yasamBilgisi);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_olum_tarihi", date_olum_tarihi.Value);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_olum_aciklamasi", txt_olum_nedeni.Text);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_medeni_hali", cb_medinhal.Text);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_kan_grubu", cb_kangrubu.Text);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_tel_no", mtxt_tel_no_yakin.Text);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_saglik_sorunu", saglik_durumu);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_saglik_aciklama", txt_saglik_aciklama_yakin.Text);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_engel_durumu", engel_durumu);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_engel_aciklama", txt_yakin_engel_aciklama.Text);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_çalisma_durumu", calisma_durumu);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_meslegi", txt_yakin_meslek.Text);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_geliri", txt_gelir_yakin.Text);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_calistigi_yer", txt_calistiği_yer.Text);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_okul", okul);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_okul_adi", txt_okul_adi.Text);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_ogrenim_duzeyi", cb_duzey.Text);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_okul_bolumu", txt_bolum.Text);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_okul_sinif", cb_sinif.Text);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_okul_sehir", txt_sehir.Text);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_okul_giris_tarihi", date_giris_tarihi.Value);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_okul_durumu", mezuniyet_durumu);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_okul_mezuniyet_tarihi", date_mezuniyet.Value);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_mezuniyet_derecesi", txt_yakin_okul_derece.Text);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_merasim_turu", cb_merasim.Text);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_merasim_tarihi", date_merasim.Value);
                        eklekomutuyakin.Parameters.AddWithValue("@yakin_hobileri", hobiler);






                        eklekomutuyakin.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                         MessageBox.Show("Kişinin yakınları ile ilgili bilgiler başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                        listele_yakin_bilgileri();
                        ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                            }
                            catch (Exception hatamjs)
                            {
                               //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                               MessageBox.Show(hatamjs.Message);
                            }
                                          
                    }
                   /* else
                    { MessageBox.Show("Yakın bilgisi giriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                   */
                    if(txt_bakim_yakin.Text!="")//herhangi bir bakım kişisi eklenİr ise
                    {
                    try
                    {
                        SqlCommand eklekomutubakim = new SqlCommand("Kaydet_Bakim_Yükümlü_Bilgisi", baglantim.baglanti());
                        eklekomutubakim.CommandType = CommandType.StoredProcedure;

                        eklekomutubakim.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                        eklekomutubakim.Parameters.AddWithValue("@bakim_yakini", txt_bakim_yakin.Text);
                        eklekomutubakim.Parameters.AddWithValue("@adi_soyadi", txt_bakim_adsoyad.Text);
                        eklekomutubakim.Parameters.AddWithValue("@dogum_yeri", txt_bakim_dogum_yeri.Text);
                        eklekomutubakim.Parameters.AddWithValue("@dogum_tarihi", date_bakim_dogum.Value);
                        eklekomutubakim.Parameters.AddWithValue("@tel_no", mtxt_bakim_tel_no.Text);
                        eklekomutubakim.Parameters.AddWithValue("@saglik_sorunu", saglik_durumu_bakım);
                        eklekomutubakim.Parameters.AddWithValue("@saglik_sorunu_aciklama", txt_bakim_saglik_aciklama.Text);
                        eklekomutubakim.Parameters.AddWithValue("@engel_durumu", engel_durumu_bakim);
                        eklekomutubakim.Parameters.AddWithValue("@engel_aciklama", txt_bakim_engel_aciklama.Text);
                        eklekomutubakim.Parameters.AddWithValue("@geliri", txt_bakim_maas.Text);
                        eklekomutubakim.Parameters.AddWithValue("@bakim_hobi", bakımHobi);

                        eklekomutubakim.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir
                                                          //baglantim.baglanti().Close();
                                                          //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                        listele_bakim();
                        MessageBox.Show("Kişinin bakımı ile yükümlü olduğu bilgiler başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi
                    }

                    catch (Exception hataamsj)
                    {

                        MessageBox.Show(hataamsj.Message);
                    }

                }


            }

            else//herhangi bir hata ile karşılaşılır ise 
            {
                MessageBox.Show("yazı rengi kırmızı olan alanları yeniden gözden geçirniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }




        }
    
        //güncelle
        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            //bu kısım için veri tabanında ad soyad için bir arama yapılması gerektedir.

            bool kayitkontrol = false;//bir kayıt yaparken daha önceden böyle bir kullanıcı var mı diye kontrolü yapılacak
                                      //////baglantim.baglanti().Open();
            SqlCommand selectsorgu = new SqlCommand("select * from Kisi_Yakini_Bilgileri where kisi_tc='" + mtxt_tc_no.Text + "' and yakin_adi_soyadi='" + txt_ad_soyad_yakin.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.
                                                                   //ilgili tc no ya ait vb de kayıt vamı diye kontrol edelim.

            while (kayitokuma.Read())
            {
                kayitkontrol = true;//ilgili tc noya ait bir kullanıcı var demektir.
                break;

            }
              //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

                if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                    lbl_tc_no.ForeColor = Color.Red;
                else
                    lbl_tc_no.ForeColor = Color.Black;

                //yakını bilgisi
                if (cb_yakin.Text != "")//herhangi bir yakını seçildi ise
                {
                //adı soyadı
                if (txt_ad_soyad_yakin.Text == "" || txt_ad_soyad_yakin.Text.Length < 2)

                    lbl_yakin_ad_soyad.ForeColor = Color.Red;
                else
                    lbl_yakin_ad_soyad.ForeColor = Color.Black;

                if (radioButton_bay.Checked == true)
                    cinsiyet = "BAY";
                else if (radioButton_bayan.Checked == true)
                    cinsiyet = "BAYAN";

                //doğum yeri
                if (txt_dogum_yeri.Text == "" || txt_dogum_yeri.Text.Length < 2)
                    lbl_yakin_dogum_yeri.ForeColor = Color.Red;
                else
                    lbl_yakin_dogum_yeri.ForeColor = Color.Black;

                    if (toggleSwitch_sag_olu.IsOn != true)//yaşıyor ise
                    {   //medeni hali
                    if (cb_medinhal.Text == "")
                        lbl_yakin_medeni_hal.ForeColor = Color.Red;
                    else
                        lbl_yakin_medeni_hal.ForeColor = Color.Black;

                    //kangrubu
                    if (cb_kangrubu.Text == "")
                        lbl_yakin_kan_grubu.ForeColor = Color.Red;
                    else
                        lbl_yakin_kan_grubu.ForeColor = Color.Black;

                    //telefonnumarası
                    if (mtxt_tel_no_yakin.Text == "")
                        lbl_yakin_tel_no.ForeColor = Color.Red;
                    else
                        lbl_yakin_tel_no.ForeColor = Color.Black;

                    //sağlık açıklaması yazılmalıdır.
                    if (toggleSwitch_saglik_yakin.IsOn == true)
                    {
                        if (txt_saglik_aciklama_yakin.Text == "")
                            lbl_yakin_saglik_aciklama.ForeColor = Color.Red;
                        saglik_durumu = "Bir sağlık sorunu vardır.";

                    }

                    else
                        {
                            lbl_yakin_saglik_aciklama.ForeColor = Color.Black;
                            txt_saglik_aciklama_yakin.Enabled = false;
                            saglik_durumu = "Bir sağlık sorunu yoktur.";
                        }

                    //engeli var ise  açıklaması yazılmalıdır.
                    if (toggleSwitch_yakin_engel.IsOn == true)
                    {
                        if (txt_yakin_engel_aciklama.Text == "")
                            lbl_engel_yakin_aciklama.ForeColor = Color.Red;
                        engel_durumu = "Bir engeli vardır.";
                    }

                    else
                    {
                        lbl_engel_yakin_aciklama.ForeColor = Color.Black;
                        txt_yakin_engel_aciklama.Enabled = false;
                        engel_durumu = "Bir engeli yoktur.";
                    }


                    //çalışma durumu var ise  açıklaması yazılmalıdır.
                    if (toggleSwitch_yakin_calisma.IsOn == true)
                        {
                        calisma_durumu = "Çalışıyor";
                        //mesleği
                        if (txt_yakin_meslek.Text == "")
                            lbl_meslek_yakin.ForeColor = Color.Red;
                        else
                            lbl_meslek_yakin.ForeColor = Color.Black;

                        //geliri
                        if (txt_gelir_yakin.Text == "")
                            lbl_geliri_yakin.ForeColor = Color.Red;
                        else
                            lbl_geliri_yakin.ForeColor = Color.Black;

                        //çalıştığı yer
                        if (txt_calistiği_yer.Text == "" && txt_calistiği_yer.Text.Length < 2)
                        {
                            lbl_yakin_calistigi_yer.ForeColor = Color.Red;

                        }
                        else
                            lbl_yakin_calistigi_yer.ForeColor = Color.Black;
                    }
                    else
                    {
                        calisma_durumu = "Çalışmıyor.";
                        txt_yakin_meslek.Enabled = false;
                        txt_gelir_yakin.Enabled = false;
                        txt_calistiği_yer.Enabled = false;
                    }



                        //okul bilgisi
                        if (txt_okul_adi.Text != "" && txt_okul_adi.Text.Length > 2)
                        {//okul adı kısmına herhangi birşey yazılır ise

                        //öğrenim düzeyiseçilmeli
                        if (cb_duzey.Text == "")

                            lbl_yakin_okul_duzey.ForeColor = Color.Red;
                        else
                            lbl_yakin_okul_duzey.ForeColor = Color.Black;

                        //sınıf seçmeli
                        if (cb_sinif.Text == "")
                            lbl_yakin_sinif.ForeColor = Color.Red;
                        else
                            lbl_yakin_sinif.ForeColor = Color.Black;


                        //eğer üniversite veya lise düzeyi ise bölüm bilgisi seçilsin
                        if (cb_duzey.Text == "Lise" || cb_duzey.Text == "Üniversite" || cb_duzey.Text == "Yüksek Lisans" || cb_duzey.Text == "Doktora")
                        {
                            if (txt_bolum.Text == "")
                                lbl_yakin_bolum.ForeColor = Color.Red;
                            else
                                lbl_yakin_bolum.ForeColor = Color.Black;
                        }
                        else
                             txt_bolum.Enabled = false;

                            //okuduğu şehir seçilmeli
                            if (txt_sehir.Text == "")
                                lbl_yakin_sehir.ForeColor = Color.Red;
                            else
                                lbl_yakin_sehir.ForeColor = Color.Black;

                            //mezun mu eğer mezun ise mezuniyet tarihi girilmeli değil ise girememeli
                            if (toggleSwitch_okul_durum.IsOn == true)
                            {
                            mezuniyet_durumu = "Mezun";
                            date_mezuniyet.Enabled = true;
                            lbl_yakin_okul_derece.Enabled = true;
                            if (txt_yakin_okul_derece.Text == "")
                                    lbl_yakin_okul_derece.ForeColor = Color.Red;
                                else
                                    lbl_yakin_okul_derece.ForeColor = Color.Black;
                            }
                            else
                            {
                                mezuniyet_durumu = "Okuyor";
                                date_mezuniyet.Enabled = false;
                                lbl_yakin_okul_derece.Enabled = false;
                            }
                        }
                        else
                        {
                        cb_duzey.Enabled = false;
                        cb_sinif.Enabled = false;
                        txt_bolum.Enabled = false;
                        txt_sehir.Enabled = false;
                        date_giris_tarihi.Enabled = false;
                        toggleSwitch_okul_durum.Enabled = false;
                        date_mezuniyet.Enabled = false;
                        txt_yakin_okul_derece.Enabled = false;

                    }

                        //kişi için planlanan herhangi bir mearsim etkinlik var mıdır. varsa tarihi
                        if (cb_merasim.Text != "")
                        {
                            date_merasim.Enabled = true;
                        }
                        else
                            date_merasim.Enabled = false;

                    }
                    else
                    {
                        lbl_olum_tarihi.Visible = true;
                        date_olum_tarihi.Visible = true;
                        lbl_olum_nedeni.Visible = true;
                        txt_olum_nedeni.Visible = true;

                        yasam_bilgisi_togled(false);
                    }
                }


            //okul bilgisi
            if (txt_okul_adi.Text != "" && txt_okul_adi.Text.Length > 2)
            {//okul adı kısmına herhangi birşey yazılır ise
                okul = "VAR";
                //öğrenim düzeyiseçilmeli
                if (cb_duzey.Text == "")

                    lbl_yakin_okul_duzey.ForeColor = Color.Red;
                else
                    lbl_yakin_okul_duzey.ForeColor = Color.Black;

                //sınıf seçmeli
                if (cb_sinif.Text == "")
                    lbl_yakin_sinif.ForeColor = Color.Red;
                else
                    lbl_yakin_sinif.ForeColor = Color.Black;


                //eğer üniversite veya lise düzeyi ise bölüm bilgisi seçilsin
                if (cb_duzey.Text == "Lise" || cb_duzey.Text == "Üniversite" || cb_duzey.Text == "Yüksek Lisans" || cb_duzey.Text == "Doktora")
                {
                    if (txt_bolum.Text == "")
                        lbl_yakin_bolum.ForeColor = Color.Red;
                    else
                        lbl_yakin_bolum.ForeColor = Color.Black;
                }
                else
                    txt_bolum.Enabled = false;

                //okuduğu şehir seçilmeli
                if (txt_sehir.Text == "")
                    lbl_yakin_sehir.ForeColor = Color.Red;
                else
                    lbl_yakin_sehir.ForeColor = Color.Black;

                //mezun mu eğer mezun ise mezuniyet tarihi girilmeli değil ise girememeli
                if (toggleSwitch_okul_durum.IsOn == true)
                {
                    mezuniyet_durumu = "Mezun";
                    date_mezuniyet.Enabled = true;
                    if (txt_yakin_okul_derece.Text == "")
                        lbl_yakin_okul_derece.ForeColor = Color.Red;
                    else
                        lbl_yakin_okul_derece.ForeColor = Color.Black;
                }
                else
                {
                    mezuniyet_durumu = "Okuyor";
                    date_mezuniyet.Enabled = false;
                    lbl_yakin_okul_derece.Enabled = false;
                }
            }
            else
            {
                okul = "YOK";
                cb_duzey.Enabled = false;
                cb_sinif.Enabled = false;
                txt_bolum.Enabled = false;
                txt_sehir.Enabled = false;
                date_giris_tarihi.Enabled = false;
                toggleSwitch_okul_durum.Enabled = false;
                date_mezuniyet.Enabled = false;
                txt_yakin_okul_derece.Enabled = false;
                mezuniyet_durumu = "YOK";

            }


            //herhangi bir bakım bilgisi girecek ise bu kısım çalışacakktır.
            if (txt_bakim_yakin.Text != "")
                {
                //baktığı kişinin adı soyadı olmalı
                if (txt_bakim_adsoyad.Text == "")
                    lbl_bakim_adsoyad.ForeColor = Color.Red;
                else
                    lbl_bakim_adsoyad.ForeColor = Color.Black;

                //baktığı kişinin doğum yeri olmalı
                if (txt_bakim_dogum_yeri.Text == "")
                    lbl_bakim_dogum_yeri.ForeColor = Color.Red;
                else
                    lbl_bakim_dogum_yeri.ForeColor = Color.Black;

                if (toggleSwitch_bakim_saglik.IsOn == true)
                {
                    saglik_durumu = "Bir sağlık problemi vardır.";
                    //herhangi bir şağlık sorunu var ise açıklama yazsın yoksa yazmasın
                    if (txt_bakim_saglik_aciklama.Text == "")
                    {
                        lbl_bakim_saglik_aciklama.ForeColor = Color.Red;
                    }
                    else
                    {
                        lbl_bakim_saglik_aciklama.ForeColor = Color.Black;

                    }

                

                }
                    else
                    {
                        saglik_durumu = "Bir sağlık problemi yoktur.";
                        lbl_bakim_saglik_aciklama.ForeColor = Color.Black;
                        txt_bakim_saglik_aciklama.Enabled = false;
                    }

                //engel durmunu sorgulayalım.

                if (toggleSwitch_bakim_engel.IsOn == true)
                {
                    engel_durumu = "Bir engel durumu söz konusudur.";
                    //herhangi bir engeli var ise açıklama yazsın yoksa yazmasın
                    if (txt_bakim_engel_aciklama.Text == "")
                    {
                        lbl_bakim_engel_aciklama.ForeColor = Color.Red;
                    }
                    else
                    {
                        lbl_bakim_engel_aciklama.ForeColor = Color.Black;

                    }

                }
                else
                {
                    engel_durumu = "Bir engel durumu yoktur.";
                    lbl_bakim_engel_aciklama.ForeColor = Color.Black;
                    txt_bakim_engel_aciklama.Enabled = false;
                }


            }

                else
                {
                txt_bakim_adsoyad.Enabled = false;
                txt_bakim_dogum_yeri.Enabled = false;
                date_bakim_dogum.Enabled = false;
                mtxt_bakim_tel_no.Enabled = false;
                toggleSwitch_bakim_saglik.Enabled = false;
                txt_bakim_saglik_aciklama.Enabled = false;
                toggleSwitch_bakim_engel.Enabled = false;
                txt_bakim_engel_aciklama.Enabled = false;
                txt_bakim_maas.Enabled = false;
                checkedListBox2.Enabled = false;



                }

                //şimdiye kadar alanların zorunlulukları belirlendi sıra geldi forma ekleme işlemine

                if (mtxt_tc_no.Text.Length == 11)
                {
                if (cb_yakin.Text != "" && txt_ad_soyad_yakin.Text!="")//herhangi bir yakını eklenir ise
                {

                    try
                    {
                        SqlCommand guncellekomutuyakin = new SqlCommand("Guncelle_Yakini_Bilgisi", baglantim.baglanti());
                        guncellekomutuyakin.CommandType = CommandType.StoredProcedure;

                        guncellekomutuyakin.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakinlik_derecesi", cb_yakin.Text);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_adi_soyadi", txt_ad_soyad_yakin.Text);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_cinsiyeti", cinsiyet);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_dogum_yeri", txt_dogum_yeri.Text);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_dogum_tarihi", date_dogum_tarihi.Value);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_yasam_bilgisi", yasamBilgisi);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_olum_tarihi", date_olum_tarihi.Value);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_olum_aciklamasi", txt_olum_nedeni.Text);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_medeni_hali", cb_medinhal.Text);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_kan_grubu", cb_kangrubu.Text);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_tel_no", mtxt_tel_no_yakin.Text);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_saglik_sorunu", saglik_durumu);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_saglik_aciklama", txt_saglik_aciklama_yakin.Text);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_engel_durumu", engel_durumu);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_engel_aciklama", txt_yakin_engel_aciklama.Text);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_çalisma_durumu", calisma_durumu);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_meslegi", txt_yakin_meslek.Text);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_geliri", txt_gelir_yakin.Text);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_calistigi_yer", txt_calistiği_yer.Text);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_okul", okul);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_okul_adi", txt_okul_adi.Text);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_ogrenim_duzeyi", cb_duzey.Text);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_okul_bolumu", txt_bolum.Text);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_okul_sinif", cb_sinif.Text);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_okul_sehir", txt_sehir.Text);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_okul_giris_tarihi", date_giris_tarihi.Value);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_okul_durumu", mezuniyet_durumu);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_okul_mezuniyet_tarihi", date_mezuniyet.Value);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_mezuniyet_derecesi", txt_yakin_okul_derece.Text);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_merasim_turu", cb_merasim.Text);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_merasim_tarihi", date_merasim.Value);
                        guncellekomutuyakin.Parameters.AddWithValue("@yakin_hobileri", hobiler);
                        guncellekomutuyakin.Parameters.AddWithValue("@id", txt_yakin_id.Text);

                        guncellekomutuyakin.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        MessageBox.Show("Kişinin yakınları ile ilgili bilgiler başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                        listele_yakin_bilgileri();
                    }
                    catch (Exception hatamjs)
                    {
                        MessageBox.Show(hatamjs.Message);
                    }
                }
                /*
                else
                 { MessageBox.Show("Yakın bilgisi giriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                */
                 
               if (txt_bakim_yakin.Text != "")//herhangi bir bakım kişisi eklenşr ise
                {
                    try
                    {
                        SqlCommand guncellekomutubakim = new SqlCommand("Guncelle_Bakim_Yükümlü_Bilgisi", baglantim.baglanti());
                        guncellekomutubakim.CommandType = CommandType.StoredProcedure;

                        guncellekomutubakim.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                        guncellekomutubakim.Parameters.AddWithValue("@bakim_yakini", txt_bakim_yakin.Text);
                        guncellekomutubakim.Parameters.AddWithValue("@adi_soyadi", txt_bakim_adsoyad.Text);
                        guncellekomutubakim.Parameters.AddWithValue("@dogum_yeri", txt_bakim_dogum_yeri.Text);
                        guncellekomutubakim.Parameters.AddWithValue("@dogum_tarihi", date_bakim_dogum.Value);
                        guncellekomutubakim.Parameters.AddWithValue("@tel_no", mtxt_bakim_tel_no.Text);
                        guncellekomutubakim.Parameters.AddWithValue("@saglik_sorunu", saglik_durumu_bakım);
                        guncellekomutubakim.Parameters.AddWithValue("@saglik_sorunu_aciklama", txt_bakim_saglik_aciklama.Text);
                        guncellekomutubakim.Parameters.AddWithValue("@engel_durumu", engel_durumu_bakim);
                        guncellekomutubakim.Parameters.AddWithValue("@engel_aciklama", txt_bakim_engel_aciklama.Text);
                        guncellekomutubakim.Parameters.AddWithValue("@bakim_hobi", bakımHobi);
                        guncellekomutubakim.Parameters.AddWithValue("@geliri", txt_bakim_maas.Text);
                        guncellekomutubakim.Parameters.AddWithValue("@id", txt_bakim_id.Text);



                        guncellekomutubakim.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir
                                                              //baglantim.baglanti().Close();
                                                              //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                        listele_bakim();
                        MessageBox.Show("Kişinin bakımı ile yükümlü olduğu bilgiler başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi





                    }
                    catch (Exception hataamsj)
                    {

                        MessageBox.Show(hataamsj.Message);
                    }

                }


                }

                else//herhangi bir hata ile karşılaşılır ise 
                {
                    MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçirniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

         }


     }


      
    

    }

