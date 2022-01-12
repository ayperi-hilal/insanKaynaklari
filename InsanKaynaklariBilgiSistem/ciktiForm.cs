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
    public partial class ciktiForm : Form
    {
        public ciktiForm()
        {
            InitializeComponent();
        }

        sqlBaglantisi baglantim = new sqlBaglantisi();

        private void ciktiForm_Load(object sender, EventArgs e)
        {
            mtxt_tc_no.Mask = "00000000000";//kullnıcı 11 haneli tc numarası girebilecek.
            lbl_cocuk.Text = "0";
        }

        public void resim_goruntule()
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT resim FROM Kisi WHERE TC = '" + mtxt_tc_no.Text + "'", baglantim.baglanti()));

                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count == 1)
                {
                    Byte[] data = new Byte[0];
                    data = (Byte[])(dataSet.Tables[0].Rows[0]["resim"]);        // tablodaki coloum ismi
                    MemoryStream mem = new MemoryStream(data);
                    picb_resim.Image = Image.FromStream(mem);

                    MessageBox.Show("Okuma Başarılı");
                }
                else
                {
                    picb_resim.Image = null;
                    MessageBox.Show("Resim Yok!");
                }

            }
            catch (Exception se)
            {

                MessageBox.Show(se.Message);
            }
            finally
            {

            }
        }

        string hobiler = "";

        public void listele_yabanci_dil()//1
        {
            SqlCommand sorgu = new SqlCommand("Listele_Yabanci_Dil", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sorgu);
            sorgu.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["pdks"].Visible = false;

            gridView1.Columns["kisi_tc"].Visible = false;

            gridView1.Columns["yabanci_dil"].Caption = "YABANCI DİL";
            gridView1.Columns["duzeyi"].Caption = "DÜZEY";


        }

        public void listele_bilgisayar_bilgisi()//3
        {
            SqlCommand sorgu2 = new SqlCommand("Listele_Bilgisayar_Bilgisi", baglantim.baglanti());
            sorgu2.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da2 = new SqlDataAdapter(sorgu2);
            sorgu2.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            gridControl3.DataSource = dt2;
            gridView3.Columns["id"].Visible = false;
            gridView3.Columns["pdks"].Visible = false;

            //gridView3.Columns["kisi_tc"].Visible = false;
            gridView3.Columns["kisi_tc"].Visible = false;
            gridView3.Columns["program_ad"].Caption = "PROGRAM ADI";
            gridView3.Columns["duzey"].Caption = "DÜZEY";


        }

        public void listele_sertifika()//4
        {
            SqlCommand sorgu3 = new SqlCommand("Listele_Sertifika", baglantim.baglanti());
            sorgu3.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da3 = new SqlDataAdapter(sorgu3);
            sorgu3.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            gridControl4.DataSource = dt3;
            gridView4.Columns["id"].Visible = false;
            gridView4.Columns["pdks"].Visible = false;

            gridView4.Columns["kisi_tc"].Visible = false;

            gridView4.Columns["sertifika_adi"].Caption = "SERTİFİKA ADI";
            gridView4.Columns["aldigi_kurum"].Caption = "SERTİFİKANIN ALINDIĞI KURUM";
            gridView4.Columns["konu"].Caption = "SERTİFİKA KONUSU";
            gridView4.Columns["tarih"].Caption = "TARİH";
        }
       
        public void listele_sertifika_agir_is() //5
        {
            SqlCommand sorgu5 = new SqlCommand("Listele_Kisi_Sertifika_Agir_is", baglantim.baglanti());
            sorgu5.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da5 = new SqlDataAdapter(sorgu5);
            sorgu5.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);
            gridControl6.DataSource = dt5;
            gridView6.Columns["id"].Visible = false;
            gridView6.Columns["pdks"].Visible = false;

            gridView6.Columns["kisi_tc"].Visible = false;
            gridView6.Columns["agir_is_sertifika_adi"].Caption = "SERTİFİKA ADI";
            gridView6.Columns["alinis_tarihi"].Caption = "TARİH";
        }

        public void listele_yakin_bilgileri()
        {
            SqlCommand sorguy = new SqlCommand("Listele_Yakin_Bilgileri", baglantim.baglanti());
            sorguy.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter day = new SqlDataAdapter(sorguy);
            sorguy.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            DataTable dty = new DataTable();
            day.Fill(dty);
            gridControl7.DataSource = dty;
            gridView7.Columns["id"].Visible = false;
            gridView7.Columns["kisi_tc"].Visible = false;
            gridView7.Columns["pdks"].Visible = false;

            gridView7.Columns["yakinlik_derecesi"].Caption = "YAKINLIK DERECESİ";
            gridView7.Columns["yakin_adi_soyadi"].Caption = "ADI SOYADI";
            gridView7.Columns["yakin_cinsiyeti"].Caption = "CİNSİYETİ";
            gridView7.Columns["yakin_dogum_yeri"].Caption = "DOĞUM YERİ";
            gridView7.Columns["yakin_dogum_tarihi"].Caption = "DOĞUM TARİHİ";
            gridView7.Columns["yakin_yasam_bilgisi"].Caption = "SAĞ/ÖLÜ";
            gridView7.Columns["yakin_olum_tarihi"].Caption = "ÖLÜM TARİHİ";
            gridView7.Columns["yakin_olum_aciklamasi"].Caption = "ÖLÜM NEDENİ";
            gridView7.Columns["yakin_medeni_hali"].Caption = "MEDENİ HALİ";
            gridView7.Columns["yakin_kan_grubu"].Caption = "KAN GRUBU";
            gridView7.Columns["yakin_tel_no"].Caption = "TEEFON NUMARASI";
            gridView7.Columns["yakin_saglik_sorunu"].Caption = "SAĞLIK SORUNU";
            gridView7.Columns["yakin_saglik_aciklama"].Caption = "SAĞLIK SORUNU AÇIKLAMASI";
            gridView7.Columns["yakin_engel_durumu"].Caption = "ENGEL DURUMU";
            gridView7.Columns["yakin_engel_aciklama"].Caption = "ENGEL DURUMU AÇIKLAMASI";
            gridView7.Columns["yakin_çalisma_durumu"].Caption = "ÇALIŞMA DURUMU";
            gridView7.Columns["yakin_meslegi"].Caption = "MESLEĞİ";
            gridView7.Columns["yakin_geliri"].Caption = "GERLİRİ";
            gridView7.Columns["yakin_calistigi_yer"].Caption = "ÇALIŞTIĞI YER";
            gridView7.Columns["yakin_okul"].Caption = "OKUL BİLGİSİ";
            gridView7.Columns["yakin_okul_adi"].Caption = "OKULUN ADI";
            gridView7.Columns["yakin_ogrenim_duzeyi"].Caption = "ÖĞRENİM DÜZEYİ";
            gridView7.Columns["yakin_okul_bolumu"].Caption = "BÖLÜM";
            gridView7.Columns["yakin_okul_sinif"].Caption = "SINIF";
            gridView7.Columns["yakin_okul_sehir"].Caption = "ŞEHİR";
            gridView7.Columns["yakin_okul_giris_tarihi"].Caption = "GİRİŞ TARİHİ";
            gridView7.Columns["yakin_okul_durumu"].Caption = "DURUM";
            gridView7.Columns["yakin_okul_mezuniyet_tarihi"].Caption = "MEZUNİYET TARİHİ";
            gridView7.Columns["yakin_mezuniyet_derecesi"].Caption = "DERECE";
            gridView7.Columns["yakin_merasim_turu"].Caption = "MERASİM TÜRÜ";
            gridView7.Columns["yakin_merasim_tarihi"].Caption = "MERASM TARİHİ";
            gridView7.Columns["yakin_hobileri"].Caption = "HOBİLERİ";
        }

        public void listele_bakim()
        {
            SqlCommand sorgub = new SqlCommand("Listele_Bakim_Bilgileri", baglantim.baglanti());
            sorgub.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dab = new SqlDataAdapter(sorgub);
            sorgub.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            DataTable dtb = new DataTable();
            dab.Fill(dtb);
            gridControl5.DataSource = dtb;
            gridView5.Columns["id"].Visible = false;
            gridView5.Columns["pdks"].Visible = false;
            gridView5.Columns["kisi_tc"].Visible = false;

            gridView5.Columns["adi_soyadi"].Caption = "ADI SOYADI";
            gridView5.Columns["dogum_yeri"].Caption = "DOĞUM YERİ";
            gridView5.Columns["dogum_tarihi"].Caption = "DOĞUM TARİHİ";
            gridView5.Columns["tel_no"].Caption = "TELEFON NUMARASI";
            gridView5.Columns["saglik_sorunu"].Caption = "SAĞLIK SORUNU DURUMU";
            gridView5.Columns["saglik_sorunu_aciklama"].Caption = "SAĞLIK SORUNU AÇIKLAMASI";
            gridView5.Columns["engel_durumu"].Caption = "ENGEL DURUMU";
            gridView5.Columns["engel_aciklama"].Caption = "ENGEL DURUMU AÇIKLAMASI";
            gridView5.Columns["geliri"].Caption = "GELİRİ";
            gridView5.Columns["bakim_yakini"].Caption = "YAKINLIK DERECESİ";
            gridView5.Columns["bakim_hobi"].Caption = "HOBİLERİ";

        }

        public void listele_egitim()
        {
            SqlCommand sorgu = new SqlCommand("Listele_Egitim_Bilgisi", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dae = new SqlDataAdapter(sorgu);
            sorgu.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            DataTable dte = new DataTable();
            dae.Fill(dte);
            gridControl2.DataSource = dte;
            gridView2.Columns["id"].Visible = false;
            gridView2.Columns["kisi_tc"].Visible = false;

            gridView2.Columns["okul_adi"].Caption = "OKULUN ADI";
            gridView2.Columns["ogrenim_düzeyi"].Caption = "ÖĞRENİM DÜZEYİ";
            gridView2.Columns["bolum"].Caption = "BÖLÜM";
            gridView2.Columns["sinif"].Caption = "SINIF";
            gridView2.Columns["sehir_id"].Caption = "ŞEHİR";
            gridView2.Columns["giris_tarihi"].Caption = "GİRİŞ TARİHİ";
            gridView2.Columns["durum_bilgisi"].Caption = "EĞİTİM DURUMU";
            gridView2.Columns["mezuniyet_tarihi"].Caption = "MEZUNİYET TARİHİ";
            gridView2.Columns["derece"].Caption = "MEZUNİYET DERECESİ";


        }

        public void listele_ozgecmis()
        {
            SqlCommand sorgu = new SqlCommand("Listele_Ozgecmis_isyeri", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter dao = new SqlDataAdapter(sorgu);
            sorgu.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);

            DataTable dto = new DataTable();
            dao.Fill(dto);
            gridControl9.DataSource = dto;
            gridView9.Columns["id"].Visible = false;
            gridView9.Columns["kisi_tc"].Visible = false;

            gridView9.Columns["isyeri_adi"].Caption = "ÇALIŞILAN İŞ YERİ";
            gridView9.Columns["tel"].Caption = "TELEFON NO";
            gridView9.Columns["gorev"].Caption = "GÖREV";
            gridView9.Columns["maaş"].Caption = "MAAŞ";
            gridView9.Columns["yon_adi"].Caption = "YÖNETİCİ ADI SOYADI";
            gridView9.Columns["giris_tarihi"].Caption = "GİRİŞ TARİHİ";
            gridView9.Columns["cikis_tarihi"].Caption = "ÇIKIŞ TARİHİ";
            gridView9.Columns["sebep"].Caption = "İŞTEN AYRILMA SEBEBİ";




        }

        public void listele_kkd()
        {
            SqlCommand sorgu = new SqlCommand("Listele_kkd", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sorgu);
            sorgu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gridControl8.DataSource = dt;

            gridView8.Columns["id"].Visible = false;
            gridView8.Columns["pdks"].Visible = false;
            gridView8.Columns["TC"].Visible = false;

            gridView8.Columns["kkd_turu"].Caption = "KKD TÜRÜ";
            gridView8.Columns["beden"].Caption = "BEDEN";
            gridView8.Columns["kkd_teslim_tarihi"].Caption = "TESLİM TARİHİ";
            gridView8.Columns["aksiyon_tutu"].Caption = "AKSİYON";
            gridView8.Columns["aksiyon_tarihi"].Caption = "AKSİYON TARİHİ";

        }

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
                        SqlDataReader kayitokumaiki = selectsorguiki.ExecuteReader();

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

        private void btn_formu_temizle_Click(object sender, EventArgs e)
        {
            ekrani_temizle();
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

                    picb_resim.Height = 90;
                    picb_resim.Width = 90;
                    picb_resim.SizeMode = PictureBoxSizeMode.StretchImage;

                    if (mtxt_tc_no.Text != "")
                    {
                        txt_pdks.Text = kayitokuma.GetValue(19).ToString();
                        MessageBox.Show("Test", kayitokuma.GetValue(19).ToString());
                    }

                    else if (txt_pdks.Text != "")
                    {
                        mtxt_tc_no.Text = kayitokuma.GetValue(1).ToString();
                        MessageBox.Show("Test2", kayitokuma.GetValue(1).ToString());

                    }

                   else if (mtxt_tc_no.Text != "" && txt_pdks.Text != "")
                    {
                        MessageBox.Show("Test");
                        SqlCommand selectsorguiki = new SqlCommand("select *from Kisi where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());
                        SqlDataReader kayitokumaiki = selectsorguiki.ExecuteReader();

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

                    txt_pdks.Text = kayitokuma.GetValue(19).ToString();
                    lbl_ad.Text = kayitokuma.GetValue(2).ToString();
                    lbl_soyad.Text = kayitokuma.GetValue(3).ToString();
                    lbl_uyruk.Text = kayitokuma.GetValue(4).ToString();
                    lbl_cinsiyet.Text = kayitokuma.GetValue(5).ToString();
                    lbl_medeni_hal.Text = kayitokuma.GetValue(6).ToString();
                    lbl_dogum_yeri.Text = kayitokuma.GetValue(8).ToString();
                    lbl_ana_adi.Text = kayitokuma.GetValue(10).ToString();
                    lbl_baba_adi.Text = kayitokuma.GetValue(11).ToString();
                    lbl_meslek_kodu.Text = kayitokuma.GetValue(12).ToString();
                    lbl_görevi.Text = kayitokuma.GetValue(13).ToString();
                    lbl_gorev_yeri.Text = kayitokuma.GetValue(14).ToString();
                    lbl_durum.Text = kayitokuma.GetValue(16).ToString();
                    if (kayitokuma.GetValue(16).ToString() == " Çalışıyor.")
                        date_isten_cikis.Visible = false;
                    else
                    {
                        date_isten_cikis.Text = kayitokuma.GetValue(18).ToString();
                    }
                    date_ise_giris.Text = kayitokuma.GetValue(15).ToString();
                    date_doğum_tarihi.Text = kayitokuma.GetValue(7).ToString();

                    break;
                }
                if(kayit_arama_durumu==true)
                {
                    resim_goruntule();
                }



                SqlCommand selectsorgu2 = new SqlCommand("select *from Kisi_iletisim_Bilgileri where tc_bilgisi='" + mtxt_tc_no.Text + "'", baglantim.baglanti());
                SqlDataReader kayitokuma2 = selectsorgu2.ExecuteReader();

                while (kayitokuma2.Read())
                {
                    lbl_tel_no.Text = kayitokuma2.GetValue(2).ToString();
                    lbl_cep_no.Text = kayitokuma2.GetValue(3).ToString();
                    lbl_email.Text = kayitokuma2.GetValue(4).ToString();
                    lbl_yakin.Text = kayitokuma2.GetValue(5).ToString();
                    lbl_yakin_tel.Text = kayitokuma2.GetValue(6).ToString();
                    lbl_adres.Text = kayitokuma2.GetValue(14).ToString();

                    break;
                }

                listele_bilgisayar_bilgisi();

                listele_sertifika();

                listele_sertifika_agir_is();

                listele_yabanci_dil();

                SqlCommand selectsorgu3 = new SqlCommand("select *from Kisi_Hobi where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());
                SqlDataReader kayitokuma3 = selectsorgu3.ExecuteReader();

                while (kayitokuma3.Read())
                {
                    lbl_hobileri.Text = kayitokuma3.GetValue(2).ToString();
                    

                    break;
                }

                listele_egitim();

                SqlCommand selectsorgu4 = new SqlCommand("select *from Kisi_Saglik_Bilgisi where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());
                SqlDataReader kayitokuma4 = selectsorgu4.ExecuteReader();

                while (kayitokuma4.Read())
                {
                    lbl_kan.Text = kayitokuma4.GetValue(2).ToString();
                    lbl_boy.Text = kayitokuma4.GetValue(5).ToString();
                    lbl_kilo.Text = kayitokuma4.GetValue(6).ToString();
                    txt_saglik.Text = kayitokuma4.GetValue(4).ToString();
                    txt_engel.Text = kayitokuma4.GetValue(8).ToString();
                    txt_ameliyat.Text = kayitokuma4.GetValue(10).ToString();

                    lbl_sigara.Text = kayitokuma4.GetValue(12).ToString();
                    lbl_z_sigara.Text = kayitokuma4.GetValue(13).ToString();
                    lbl_alkol.Text = kayitokuma4.GetValue(15).ToString();
                    lbl_z_alkol.Text = kayitokuma4.GetValue(16).ToString();
                    
                    break;
                }

                SqlCommand selectsorgu5 = new SqlCommand("select *from Kisi_maddi_durum_Bilgileri where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());
                SqlDataReader kayitokuma5 = selectsorgu5.ExecuteReader();

                while (kayitokuma5.Read())
                {
                    lbl_maas.Text = kayitokuma5.GetValue(2).ToString();
                    if (kayitokuma5.GetValue(3).ToString()=="")
                    { 
                        lbl_destek_mikari.Visible = false;
                        label38.Visible = false;
                        lbl_destek_mikari.Visible = false;
                    }
                    lbl_destek_mikari.Text = kayitokuma5.GetValue(4).ToString();
                    lbl_destek.Text=kayitokuma5.GetValue(3).ToString();

                    lbl_ev.Text = kayitokuma5.GetValue(6).ToString();
                    lbl_kira.Text = kayitokuma5.GetValue(7).ToString();//kişinin ödediği kira miktarı
                    lbl_isinma.Text = kayitokuma5.GetValue(8).ToString();

                    lbl_arac.Text = kayitokuma5.GetValue(11).ToString();
                    lbl_arac_amac.Text = kayitokuma5.GetValue(12).ToString();

                    lbl_arazi.Text = kayitokuma5.GetValue(13).ToString();
                    lbl_arazi_amac.Text = kayitokuma5.GetValue(14).ToString();

                    lbl_gelir_ev.Text = kayitokuma5.GetValue(9).ToString();//durmu
                    lbl_gelir_ev_tutar.Text = kayitokuma5.GetValue(10).ToString();
                   
                    
                    lbl_iban.Text = kayitokuma5.GetValue(5).ToString();
                    lbl_icra.Text = kayitokuma5.GetValue(15).ToString();
                    if (kayitokuma5.GetValue(15).ToString() == "İcrası yok.")
                    {
                        lbl_icra_konu.Visible = false;
                        lbl_borc_miktari.Visible = false;
                        lbl_borc_hesap_no.Visible = false;
                        date_borc_tarihi.Visible = false;
                        label29.Visible = false;
                        label49.Visible = false;
                        label52.Visible = false;
                        label35.Visible = false;
                    }
                    else
                    {
                        lbl_icra_konu.Text = kayitokuma5.GetValue(16).ToString();
                        lbl_borc_miktari.Text = kayitokuma5.GetValue(17).ToString();
                        lbl_borc_hesap_no.Text = kayitokuma5.GetValue(18).ToString();
                        date_borc_tarihi.Text = kayitokuma5.GetValue(19).ToString();
                    }
                    break;
                }

                listele_ozgecmis();

                listele_kkd();

                listele_bakim();

                listele_yakin_bilgileri();

                SqlCommand selectsorgu7 = new SqlCommand("aile_yakin", baglantim.baglanti());
                selectsorgu7.CommandType = CommandType.StoredProcedure;
                
                selectsorgu7.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                selectsorgu7.Parameters.AddWithValue("@pdks", txt_pdks.Text);

                SqlDataReader kayitokuma7 = selectsorgu7.ExecuteReader();

                while (kayitokuma7.Read())
                {
                    lbl_cocuk.Text = kayitokuma7.GetValue(0).ToString();

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
