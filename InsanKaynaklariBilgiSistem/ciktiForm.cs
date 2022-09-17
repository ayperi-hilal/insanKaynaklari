using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using iTextSharp.text;
using iTextSharp.text.pdf;



namespace InsanKaynaklariBilgiSistem
{
    public partial class ciktiForm : Form
    {
        public ciktiForm()
        {
            InitializeComponent();
        }

        sqlBaglantisi baglantim = new sqlBaglantisi();
        DataTable dte = new DataTable();
        DataTable dt = new DataTable();//yabancı dil
        DataTable dt2 = new DataTable();//bilgisayar
        DataTable dt3 = new DataTable();//sertifika
        DataTable dt5 = new DataTable();//ağır sertifika
        DataTable dtyt = new DataTable();
        DataTable dtys = new DataTable();
        DataTable dtye = new DataTable();//yakını eğitim
        DataTable dtyc = new DataTable();//yakını çalışma durumu
        DataTable dtyg = new DataTable();//yakını gyk
        DataTable dtb = new DataTable();//bakımı
        DataTable dto = new DataTable();//öz geçmiş
        DataTable dtk = new DataTable();//kkd
        DataTable dtm = new DataTable();//maddi durum
        DataTable dtmb = new DataTable();//borç durumu

        private void ciktiForm_Load(object sender, EventArgs e)
        {
            mtxt_tc_no.Mask = "00000000000";//kullnıcı 11 haneli tc numarası girebilecek.
            lbl_cocuk.Text = "0";
            this.AutoScroll = true;
            this.HorizontalScroll.Enabled = true;
            this.HorizontalScroll.Visible = true;
            this.VerticalScroll.Enabled = true;
            this.VerticalScroll.Visible = true;
            xtraTabPage1.AutoScroll = true;
            xtraTabPage2.AutoScroll = true;
            xtraTabPage3.AutoScroll = true;
            xtraTabPage4.AutoScroll = true;

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
                    picb_resim.Image = System.Drawing.Image.FromStream(mem);

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

        }

        string hobiler = "";

        public void listele_yabanci_dil()//1
        {
            SqlCommand sorgu = new SqlCommand("Listele_Yabanci_Dil", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sorgu);
            sorgu.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            // DataTable dt = new DataTable();
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
            // DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            gridControl3.DataSource = dt2;
            gridView3.Columns["id"].Visible = false;
            gridView3.Columns["pdks"].Visible = false;
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
            //  DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            gridControl4.DataSource = dt3;
            gridView4.Columns["id"].Visible = false;
            //gridView4.Columns["pdks"].Visible = false;
            gridView4.Columns["kisi_tc"].Visible = false;
            gridView4.Columns["sertifika_adi"].Caption = "SERTİFİKA ADI";
            gridView4.Columns["aldigi_kurum"].Caption = "SERTİFİKANIN ALINDIĞI KURUM";
            gridView4.Columns["konu"].Caption = "SERTİFİKA KONUSU";
            gridView4.Columns["tarih"].Caption = "TARİH";
            gridView4.Columns["bitis_tarihi"].Caption = "GEÇERLİLİK TARİHİ";
        }

        public void listele_sertifika_agir_is() //5
        {
            SqlCommand sorgu5 = new SqlCommand("Listele_Kisi_Sertifika_Agir_is", baglantim.baglanti());
            sorgu5.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da5 = new SqlDataAdapter(sorgu5);
            sorgu5.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            // DataTable dt5 = new DataTable();
            da5.Fill(dt5);
            gridControl6.DataSource = dt5;
            gridView6.Columns["id"].Visible = false;
            //gridView6.Columns["pdks"].Visible = false;
            gridView6.Columns["kisi_tc"].Visible = false;
            gridView6.Columns["agir_is_sertifika_adi"].Caption = "SERTİFİKA ADI";
            gridView6.Columns["alinis_tarihi"].Caption = "TARİH";
            gridView6.Columns["bitis_tarihi"].Caption = "GEÇERLİLİK TARİHİ";
        }

        public void listele_temel_yakin_bilgileri()
        {
            SqlCommand sorguyt = new SqlCommand("Listele_Yakin_Bilgileri", baglantim.baglanti());
            sorguyt.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dayt = new SqlDataAdapter(sorguyt);
            sorguyt.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            //   DataTable dtyt = new DataTable();
            dayt.Fill(dtyt);
            gridControl7.DataSource = dtyt;
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
            gridView7.Columns["yakin_kan_grubu"].Visible = false;
            gridView7.Columns["yakin_tel_no"].Caption = "TEEFON NUMARASI";
            gridView7.Columns["yakin_saglik_sorunu"].Visible = false;
            gridView7.Columns["yakin_saglik_aciklama"].Visible = false;
            gridView7.Columns["yakin_engel_durumu"].Visible = false;
            gridView7.Columns["yakin_engel_aciklama"].Visible = false;
            gridView7.Columns["yakin_çalisma_durumu"].Visible = false;
            gridView7.Columns["yakin_meslegi"].Visible = false;
            gridView7.Columns["yakin_geliri"].Visible = false;
            gridView7.Columns["yakin_calistigi_yer"].Visible = false;
            gridView7.Columns["yakin_okul"].Visible = false;
            gridView7.Columns["yakin_okul_adi"].Visible = false;
            gridView7.Columns["yakin_ogrenim_duzeyi"].Visible = false;
            gridView7.Columns["yakin_okul_bolumu"].Visible = false;
            gridView7.Columns["yakin_okul_sinif"].Visible = false;
            gridView7.Columns["yakin_okul_sehir"].Visible = false;
            gridView7.Columns["yakin_okul_giris_tarihi"].Visible = false;
            gridView7.Columns["yakin_okul_durumu"].Visible = false;
            gridView7.Columns["yakin_okul_mezuniyet_tarihi"].Visible = false;
            gridView7.Columns["yakin_mezuniyet_derecesi"].Visible = false;
            gridView7.Columns["yakin_merasim_turu"].Visible = false;
            gridView7.Columns["yakin_merasim_tarihi"].Visible = false;
            gridView7.Columns["yakin_hobileri"].Visible = false;
        }

        public void listele_saglik_yakin_bilgileri()
        {
            SqlCommand sorguys = new SqlCommand("Listele_Yakin_Bilgileri", baglantim.baglanti());
            sorguys.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter days = new SqlDataAdapter(sorguys);
            sorguys.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            //  DataTable dtys = new DataTable();
            days.Fill(dtys);
            gridControl10.DataSource = dtys;
            gridView10.Columns["id"].Visible = false;
            gridView10.Columns["kisi_tc"].Visible = false;
            gridView10.Columns["pdks"].Visible = false;

            gridView10.Columns["yakinlik_derecesi"].Visible = false;
            gridView10.Columns["yakin_adi_soyadi"].Caption = "ADI SOYADI";
            gridView10.Columns["yakin_cinsiyeti"].Visible = false;
            gridView10.Columns["yakin_dogum_yeri"].Visible = false;
            gridView10.Columns["yakin_dogum_tarihi"].Visible = false;
            gridView10.Columns["yakin_yasam_bilgisi"].Visible = false;
            gridView10.Columns["yakin_olum_tarihi"].Visible = false;
            gridView10.Columns["yakin_olum_aciklamasi"].Visible = false;
            gridView10.Columns["yakin_medeni_hali"].Visible = false;
            gridView10.Columns["yakin_kan_grubu"].Caption = "KAN GRUBU";
            gridView10.Columns["yakin_tel_no"].Visible = false;

            gridView10.Columns["yakin_saglik_sorunu"].Visible = false;
            gridView10.Columns["yakin_saglik_aciklama"].Caption = "SAĞLIK SORUNU AÇIKLAMASI";
            gridView10.Columns["yakin_engel_aciklama"].Caption = "ENGEL DURUMU AÇIKLAMASI";
            gridView10.Columns["yakin_engel_durumu"].Visible = false;

            gridView10.Columns["yakin_çalisma_durumu"].Visible = false;
            gridView10.Columns["yakin_meslegi"].Visible = false;
            gridView10.Columns["yakin_geliri"].Visible = false;
            gridView10.Columns["yakin_calistigi_yer"].Visible = false;
            gridView10.Columns["yakin_okul"].Visible = false;
            gridView10.Columns["yakin_okul_adi"].Visible = false;
            gridView10.Columns["yakin_ogrenim_duzeyi"].Visible = false;
            gridView10.Columns["yakin_okul_bolumu"].Visible = false;
            gridView10.Columns["yakin_okul_sinif"].Visible = false;
            gridView10.Columns["yakin_okul_sehir"].Visible = false;
            gridView10.Columns["yakin_okul_giris_tarihi"].Visible = false;
            gridView10.Columns["yakin_okul_durumu"].Visible = false;
            gridView10.Columns["yakin_okul_mezuniyet_tarihi"].Visible = false;
            gridView10.Columns["yakin_mezuniyet_derecesi"].Visible = false;
            gridView10.Columns["yakin_merasim_turu"].Visible = false;
            gridView10.Columns["yakin_merasim_tarihi"].Visible = false;
            gridView10.Columns["yakin_hobileri"].Visible = false;
        }

        public void listele_egitim_yakin_bilgileri()
        {
            SqlCommand sorguye = new SqlCommand("Listele_Yakin_Bilgileri", baglantim.baglanti());
            sorguye.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter daye = new SqlDataAdapter(sorguye);
            sorguye.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            //   DataTable dtye = new DataTable();
            daye.Fill(dtye);
            gridControl11.DataSource = dtye;
            gridView11.Columns["id"].Visible = false;
            gridView11.Columns["kisi_tc"].Visible = false;
            gridView11.Columns["pdks"].Visible = false;

            gridView11.Columns["yakinlik_derecesi"].Visible = false;
            gridView11.Columns["yakin_adi_soyadi"].Caption = "ADI SOYADI";
            gridView11.Columns["yakin_cinsiyeti"].Visible = false;
            gridView11.Columns["yakin_dogum_yeri"].Visible = false;
            gridView11.Columns["yakin_dogum_tarihi"].Visible = false;
            gridView11.Columns["yakin_yasam_bilgisi"].Visible = false;
            gridView11.Columns["yakin_olum_tarihi"].Visible = false;
            gridView11.Columns["yakin_olum_aciklamasi"].Visible = false;
            gridView11.Columns["yakin_medeni_hali"].Visible = false;
            gridView11.Columns["yakin_kan_grubu"].Visible = false;
            gridView11.Columns["yakin_tel_no"].Visible = false;
            gridView11.Columns["yakin_saglik_sorunu"].Visible = false;
            gridView11.Columns["yakin_saglik_aciklama"].Visible = false;
            gridView11.Columns["yakin_engel_durumu"].Visible = false;
            gridView11.Columns["yakin_engel_aciklama"].Visible = false;
            gridView11.Columns["yakin_çalisma_durumu"].Visible = false;
            gridView11.Columns["yakin_meslegi"].Visible = false;
            gridView11.Columns["yakin_geliri"].Visible = false;
            gridView11.Columns["yakin_calistigi_yer"].Visible = false;
            gridView11.Columns["yakin_okul"].Caption = "OKUL BİLGİSİ";
            gridView11.Columns["yakin_okul_adi"].Caption = "OKULUN ADI";
            gridView11.Columns["yakin_ogrenim_duzeyi"].Caption = "ÖĞRENİM DÜZEYİ";
            gridView11.Columns["yakin_okul_bolumu"].Caption = "BÖLÜM";
            gridView11.Columns["yakin_okul_sinif"].Caption = "SINIF";
            gridView11.Columns["yakin_okul_sehir"].Caption = "ŞEHİR";
            gridView11.Columns["yakin_okul_giris_tarihi"].Caption = "GİRİŞ TARİHİ";
            gridView11.Columns["yakin_okul_durumu"].Caption = "DURUM";
            gridView11.Columns["yakin_okul_mezuniyet_tarihi"].Caption = "MEZUNİYET TARİHİ";
            gridView11.Columns["yakin_mezuniyet_derecesi"].Caption = "DERECE";
            gridView11.Columns["yakin_merasim_turu"].Visible = false;
            gridView11.Columns["yakin_merasim_tarihi"].Visible = false;
            gridView11.Columns["yakin_hobileri"].Visible = false;
        }

        public void listele__calisma_yakin_bilgileri()
        {
            SqlCommand sorguyc = new SqlCommand("Listele_Yakin_Bilgileri", baglantim.baglanti());
            sorguyc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dayc = new SqlDataAdapter(sorguyc);
            sorguyc.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            //   DataTable dtyc = new DataTable();
            dayc.Fill(dtyc);
            gridControl12.DataSource = dtyc;
            gridView12.Columns["id"].Visible = false;
            gridView12.Columns["kisi_tc"].Visible = false;
            gridView12.Columns["pdks"].Visible = false;

            gridView12.Columns["yakinlik_derecesi"].Visible = false;
            gridView12.Columns["yakin_adi_soyadi"].Caption = "ADI SOYADI";
            gridView12.Columns["yakin_cinsiyeti"].Visible = false;
            gridView12.Columns["yakin_dogum_yeri"].Visible = false;
            gridView12.Columns["yakin_dogum_tarihi"].Visible = false;
            gridView12.Columns["yakin_yasam_bilgisi"].Visible = false;
            gridView12.Columns["yakin_olum_tarihi"].Visible = false;
            gridView12.Columns["yakin_olum_aciklamasi"].Visible = false;
            gridView12.Columns["yakin_medeni_hali"].Visible = false;
            gridView12.Columns["yakin_kan_grubu"].Visible = false;
            gridView12.Columns["yakin_tel_no"].Visible = false;
            gridView12.Columns["yakin_saglik_sorunu"].Visible = false;
            gridView12.Columns["yakin_saglik_aciklama"].Visible = false;
            gridView12.Columns["yakin_engel_durumu"].Visible = false;
            gridView12.Columns["yakin_engel_aciklama"].Visible = false;
            gridView12.Columns["yakin_çalisma_durumu"].Caption = "ÇALIŞMA DURUMU";
            gridView12.Columns["yakin_meslegi"].Caption = "MESLEĞİ";
            gridView12.Columns["yakin_geliri"].Caption = "GERLİRİ";
            gridView12.Columns["yakin_calistigi_yer"].Caption = "ÇALIŞTIĞI YER";
            gridView12.Columns["yakin_okul"].Visible = false;
            gridView12.Columns["yakin_okul_adi"].Visible = false;
            gridView12.Columns["yakin_ogrenim_duzeyi"].Visible = false;
            gridView12.Columns["yakin_okul_bolumu"].Visible = false;
            gridView12.Columns["yakin_okul_sinif"].Visible = false;
            gridView12.Columns["yakin_okul_sehir"].Visible = false;
            gridView12.Columns["yakin_okul_giris_tarihi"].Visible = false;
            gridView12.Columns["yakin_okul_durumu"].Visible = false;
            gridView12.Columns["yakin_okul_mezuniyet_tarihi"].Visible = false;
            gridView12.Columns["yakin_mezuniyet_derecesi"].Visible = false;
            gridView12.Columns["yakin_merasim_turu"].Visible = false;
            gridView12.Columns["yakin_merasim_tarihi"].Visible = false;
            gridView12.Columns["yakin_hobileri"].Visible = false;
        }

        public void listele__gk_yakin_bilgileri()
        {
            SqlCommand sorguyg = new SqlCommand("Listele_Yakin_Bilgileri", baglantim.baglanti());
            sorguyg.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dayg = new SqlDataAdapter(sorguyg);
            sorguyg.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            //  DataTable dtyg = new DataTable();
            dayg.Fill(dtyg);
            gridControl13.DataSource = dtyg;
            gridView13.Columns["id"].Visible = false;
            gridView13.Columns["kisi_tc"].Visible = false;
            gridView13.Columns["pdks"].Visible = false;

            gridView13.Columns["yakinlik_derecesi"].Visible = false;
            gridView13.Columns["yakin_adi_soyadi"].Caption = "ADI SOYADI";
            gridView13.Columns["yakin_cinsiyeti"].Visible = false;
            gridView13.Columns["yakin_dogum_yeri"].Visible = false;
            gridView13.Columns["yakin_dogum_tarihi"].Visible = false;
            gridView13.Columns["yakin_yasam_bilgisi"].Visible = false;
            gridView13.Columns["yakin_olum_tarihi"].Visible = false;
            gridView13.Columns["yakin_olum_aciklamasi"].Visible = false;
            gridView13.Columns["yakin_medeni_hali"].Visible = false;
            gridView13.Columns["yakin_kan_grubu"].Visible = false;
            gridView13.Columns["yakin_tel_no"].Visible = false;
            gridView13.Columns["yakin_saglik_sorunu"].Visible = false;
            gridView13.Columns["yakin_saglik_aciklama"].Visible = false;
            gridView13.Columns["yakin_engel_durumu"].Visible = false;
            gridView13.Columns["yakin_engel_aciklama"].Visible = false;
            gridView13.Columns["yakin_çalisma_durumu"].Visible = false;
            gridView13.Columns["yakin_meslegi"].Visible = false;
            gridView13.Columns["yakin_geliri"].Visible = false;
            gridView13.Columns["yakin_calistigi_yer"].Visible = false;
            gridView13.Columns["yakin_okul"].Visible = false;
            gridView13.Columns["yakin_okul_adi"].Visible = false;
            gridView13.Columns["yakin_ogrenim_duzeyi"].Visible = false;
            gridView13.Columns["yakin_okul_bolumu"].Visible = false;
            gridView13.Columns["yakin_okul_sinif"].Visible = false;
            gridView13.Columns["yakin_okul_sehir"].Visible = false;
            gridView13.Columns["yakin_okul_giris_tarihi"].Visible = false;
            gridView13.Columns["yakin_okul_durumu"].Visible = false;
            gridView13.Columns["yakin_okul_mezuniyet_tarihi"].Visible = false;
            gridView13.Columns["yakin_mezuniyet_derecesi"].Visible = false;
            gridView13.Columns["yakin_merasim_turu"].Caption = "MERASİM TÜRÜ";
            gridView13.Columns["yakin_merasim_tarihi"].Caption = "MERASM TARİHİ";
            gridView13.Columns["yakin_hobileri"].Caption = "HOBİLERİ";
        }

        public void listele_bakim()
        {
            SqlCommand sorgub = new SqlCommand("Listele_Bakim_Bilgileri", baglantim.baglanti());
            sorgub.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dab = new SqlDataAdapter(sorgub);
            sorgub.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            //  DataTable dtb = new DataTable();
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
            // DataTable dte = new DataTable();
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

            //  DataTable dto = new DataTable();
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
            SqlDataAdapter dak = new SqlDataAdapter(sorgu);
            sorgu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
            // DataTable dt = new DataTable();
            dak.Fill(dtk);

            gridControl8.DataSource = dtk;

            gridView8.Columns["id"].Visible = false;
            gridView8.Columns["pdks"].Visible = false;
            gridView8.Columns["TC"].Visible = false;

            gridView8.Columns["kkd_turu"].Caption = "KKD TÜRÜ";
            gridView8.Columns["beden"].Caption = "BEDEN";
            gridView8.Columns["kkd_teslim_tarihi"].Caption = "TESLİM TARİHİ";
            gridView8.Columns["aksiyon_tutu"].Caption = "AKSİYON";
            gridView8.Columns["aksiyon_tarihi"].Caption = "AKSİYON TARİHİ";

        }

        public void Listele_Maddi_Durum()
        {
            SqlCommand sorgu = new SqlCommand("Listele_Maddi_Durum", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dam = new SqlDataAdapter(sorgu);
            sorgu.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
            // DataTable dt = new DataTable();
            dam.Fill(dtm);

            gridControl15.DataSource = dtm;

            gridView15.Columns["id"].Visible = false;
            gridView15.Columns["kisi_tc"].Visible = false;

            gridView15.Columns["hesap_numarasi"].Caption = "HESAP NUMARASI";
            gridView15.Columns["tur"].Caption = "TUR";
            gridView15.Columns["durum"].Caption = "DURUM";
            gridView15.Columns["giderUcreti"].Caption = "GİDER ÜCRETİ";
            gridView15.Columns["ozellik"].Caption = "ÖZELLİK";
            gridView15.Columns["gelirUcreti"].Caption = "GELİR ÜCRETİ";
            gridView15.Columns["kullanimAmaci"].Caption = "KULLANIM AMACI";

        }

        public void Listele_Borc_Bilgisi()
        {
            SqlCommand sorgu = new SqlCommand("Listele_Borc_Bilgisi", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter damb = new SqlDataAdapter(sorgu);
            sorgu.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
            // DataTable dtmb = new DataTable();
            damb.Fill(dtmb);

            gridControl16.DataSource = dtmb;

            gridView16.Columns["id"].Visible = false;
            gridView16.Columns["kisi_tc"].Visible = false;

            gridView16.Columns["borcBaslangicTarihi"].Caption = "EDİNİM TARİHİ";
            gridView16.Columns["borcNedeni"].Caption = "NEDENİ";
            gridView16.Columns["borcKaynagi"].Caption = "NEREDEN ALINDIĞI";
            gridView16.Columns["borcMiktari"].Caption = "MİKTAR";
            gridView16.Columns["durum"].Caption = "DURUM";
            gridView16.Columns["borcOdemeTarihi"].Caption = "ÖDEME TARİHİ";
            gridView16.Columns["ödendigiTarih"].Caption = "ÖDENDİĞİ TARİH";

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
            lbl_tc.Text = string.Empty;
            lbl_pdkss.Text = string.Empty;

            lbl_ise_giris.Text = string.Empty;
            lbl_isten_cikis.Text = string.Empty;
            lbl_dogum_tarihi.Text = string.Empty;

            //gridView2.clear;
            //    gridview2.DataSource = null;
            //gridView2.DataSource = null;

            gridView1.Columns.Clear();
            gridView2.Columns.Clear();
            gridView3.Columns.Clear();
            gridView4.Columns.Clear();
            gridView5.Columns.Clear();
            gridView6.Columns.Clear();
            gridView7.Columns.Clear();
            gridView8.Columns.Clear();
            gridView9.Columns.Clear();
            gridView10.Columns.Clear();
            gridView11.Columns.Clear();
            gridView12.Columns.Clear();
            gridView13.Columns.Clear();


        }

        string e;

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
                    lbl_pdkss.Text = kayitokuma.GetValue(19).ToString();
                    lbl_tc.Text = kayitokuma.GetValue(1).ToString();
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
                    if (kayitokuma.GetValue(16).ToString() == "Çalışıyor.")
                    {
                        lbl_isten_cikis.Visible = false;
                        label12.Visible = false;
                    }
                    else
                    {
                        lbl_isten_cikis.Visible = true;
                        label12.Visible = true;
                        lbl_isten_cikis.Text = kayitokuma.GetValue(18).ToString().Substring(0, 10);
                    }

                    lbl_ise_giris.Text = kayitokuma.GetValue(15).ToString().Substring(0, 10);
                    lbl_dogum_tarihi.Text = kayitokuma.GetValue(7).ToString().Substring(0, 10);


                    break;
                }
                if (kayit_arama_durumu == true)
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
                Listele_Maddi_Durum();
                Listele_Borc_Bilgisi();

                //SqlCommand selectsorgu5 = new SqlCommand("select *from Kisi_maddi_durum_Bilgileri where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());
                //SqlDataReader kayitokuma5 = selectsorgu5.ExecuteReader();

                //while (kayitokuma5.Read())
                //{
                //    lbl_maas.Text = kayitokuma5.GetValue(2).ToString();
                //    if (kayitokuma5.GetValue(3).ToString()=="")
                //    { 
                //        lbl_destek_mikari.Visible = false;
                //        label38.Visible = false;
                //        lbl_destek_mikari.Visible = false;
                //    }
                //    lbl_destek_mikari.Text = kayitokuma5.GetValue(4).ToString();
                //    lbl_destek.Text=kayitokuma5.GetValue(3).ToString();

                //    lbl_ev.Text = kayitokuma5.GetValue(6).ToString();
                //    lbl_kira.Text = kayitokuma5.GetValue(7).ToString();//kişinin ödediği kira miktarı
                //    lbl_isinma.Text = kayitokuma5.GetValue(8).ToString();

                //    lbl_arac.Text = kayitokuma5.GetValue(11).ToString();
                //    lbl_arac_amac.Text = kayitokuma5.GetValue(12).ToString();

                //    lbl_arazi.Text = kayitokuma5.GetValue(13).ToString();
                //    lbl_arazi_amac.Text = kayitokuma5.GetValue(14).ToString();

                //    lbl_gelir_ev.Text = kayitokuma5.GetValue(9).ToString();//durmu
                //    lbl_gelir_ev_tutar.Text = kayitokuma5.GetValue(10).ToString();


                //    lbl_iban.Text = kayitokuma5.GetValue(5).ToString();
                //    lbl_icra.Text = kayitokuma5.GetValue(15).ToString();
                //    if (kayitokuma5.GetValue(15).ToString() == "İcrası yok.")
                //    {
                //        lbl_icra_konu.Visible = false;
                //        lbl_borc_miktari.Visible = false;
                //        lbl_borc_hesap_no.Visible = false;
                //        date_borc_tarihi.Visible = false;
                //        label29.Visible = false;
                //        label49.Visible = false;
                //        label52.Visible = false;
                //        label35.Visible = false;
                //    }
                //    else
                //    {
                //        lbl_icra_konu.Text = kayitokuma5.GetValue(16).ToString();
                //        lbl_borc_miktari.Text = kayitokuma5.GetValue(17).ToString();
                //        lbl_borc_hesap_no.Text = kayitokuma5.GetValue(18).ToString();
                //        date_borc_tarihi.Text = kayitokuma5.GetValue(19).ToString();
                //    }
                //    break;
                //}

                SqlCommand selectsorgu8 = new SqlCommand("select *from Kisi_firmaImkanlari where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());
                SqlDataReader kayitokuma8 = selectsorgu8.ExecuteReader();

                while (kayitokuma8.Read())
                {
                    lbl_gider.Text = kayitokuma8.GetValue(2).ToString();

                    lbl_sure.Text = kayitokuma8.GetValue(3).ToString();
                    lbl_v1.Text = kayitokuma8.GetValue(4).ToString();

                    lbl_v2.Text = kayitokuma8.GetValue(5).ToString();
                    lbl_3.Text = kayitokuma8.GetValue(6).ToString();//kişinin ödediği kira miktarı
                    lbl_4.Text = kayitokuma8.GetValue(7).ToString();

                    lbl_5.Text = kayitokuma8.GetValue(8).ToString();
                    lbl_v6.Text = kayitokuma8.GetValue(9).ToString();

                    txt_alerji.Text = kayitokuma8.GetValue(10).ToString();
                    lbl_yemek.Text = kayitokuma8.GetValue(11).ToString();

                    txt_neden.Text = kayitokuma8.GetValue(12).ToString();//durmu
                    txt_talep.Text = kayitokuma8.GetValue(13).ToString();

                    break;
                }


                listele_ozgecmis();

                listele_kkd();

                listele_bakim();

                listele_temel_yakin_bilgileri();
                listele_saglik_yakin_bilgileri();
                listele_egitim_yakin_bilgileri();
                listele__gk_yakin_bilgileri();
                listele__calisma_yakin_bilgileri();

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

        private void btn_onizleme_Click(object sender, EventArgs e)
        {

            //if (mtxt_tc_no.Text != "")
            //{
            //    printPreviewDialog1.Document = printDocument1;
            //    printPreviewDialog1.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("Lütfen önce Tc No giriniz");
            //}

        }
        //private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        //private PrintDocument printDocument1 = new PrintDocument();

        //// Declare a string to hold the entire document contents.
        //private string documentContents;

        //// Declare a variable to hold the portion of the document that
        //// is not printed.
        //private string stringToPrint;

        //private void btn_cikti_Click(object sender, EventArgs e)
        //{
        //    //DialogResult pdr = printDialog1.ShowDialog();

        //    //if (pdr == DialogResult.OK)

        //    //{
        //    //    printDocument1.Print();
        //    //}


        //    printDocument1.Print();

        //}

        //   PrintDocument YaziciCiktisi = new PrintDocument();

        int a = 1;

        // int yazdirilan_eleman_no = 0;
        // private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //GridView[] gvpdf = new GridView[] {gridView1, gridView2, gridView3, gridView4, gridView5, gridView6, gridView7, gridView8,
            //    gridView9,gridView10,gridView11,gridView12,gridView13,gridView14 };
            //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            //MemoryStream ms = new MemoryStream();
            //PdfWriter.GetInstance(pdfDoc, ms);
            //pdfDoc.Open();

            int x, y;
            int satir_yuksekligi, sayfa_yuksekligi;

            System.Drawing.Printing.PageSettings sayfa_ayari;
            sayfa_ayari = printDocument1.DefaultPageSettings;
            sayfa_yuksekligi = sayfa_ayari.PaperSize.Height - sayfa_ayari.Margins.Top - sayfa_ayari.Margins.Bottom;

            int sayfa_genisligi;

            sayfa_genisligi = sayfa_ayari.PaperSize.Width - sayfa_ayari.Margins.Left - sayfa_ayari.Margins.Right;

            x = sayfa_ayari.Margins.Left + 2;
            y = sayfa_ayari.Margins.Top;

            StringFormat ortala = new StringFormat();
            ortala.Alignment = StringAlignment.Center;

            /*  StringFormat saga_yasla = new StringFormat();
             saga_yasla.Alignment = StringAlignment.Far;*/



            //Yazı fontumu ve çizgi çizmek için fırçamı ve kalem nesnemi oluşturdum
            System.Drawing.Font myFont1 = new System.Drawing.Font("Calibri", 6);
            SolidBrush sbrush1 = new SolidBrush(Color.Black);
            Pen myPen1 = new Pen(Color.Black);



            System.Drawing.Font myFont = new System.Drawing.Font("Calibri", 28);
            SolidBrush sbrush = new SolidBrush(Color.Black);
            Pen myPen = new Pen(Color.Black);

            System.Drawing.Font cizgiFont = new System.Drawing.Font("Calibri", 28, FontStyle.Underline);
            SolidBrush cizgisbrush = new SolidBrush(Color.Black);
            Pen cizgiPen = new Pen(Color.Black);

            System.Drawing.Font ustFont = new System.Drawing.Font("Calibri", 8);
            SolidBrush sbbrush = new SolidBrush(Color.Black);
            Pen ustPen = new Pen(Color.Black);


            System.Drawing.Font tableFont = new System.Drawing.Font("Calibri", 5);
            SolidBrush tablerush = new SolidBrush(Color.Black);
            Pen tablePen = new Pen(Color.Black);

            System.Drawing.Font italikFont = new System.Drawing.Font("Calibri", 8, FontStyle.Underline);
            SolidBrush italiksbrush = new SolidBrush(Color.Black);
            Pen italikPen = new Pen(Color.Black);


            satir_yuksekligi = (int)e.Graphics.MeasureString("x", myFont).Height;

            StringFormat ustStringFormat = new StringFormat();
            ustStringFormat.Alignment = StringAlignment.Far;
            ustStringFormat.LineAlignment = StringAlignment.Center;

            cizgiFont = new System.Drawing.Font("Calibri", 8, FontStyle.Underline);
            SolidBrush sbcizgi = new SolidBrush(Color.Black);

            italikFont = new System.Drawing.Font("Calibri", 8, FontStyle.Italic);
            SolidBrush isbcizgi = new SolidBrush(Color.Black);

            myFont = new System.Drawing.Font("Calibri", 8, FontStyle.Bold);
            SolidBrush sb = new SolidBrush(Color.Black);

            myFont1 = new System.Drawing.Font("Calibri", 6, FontStyle.Regular);
            SolidBrush sb1 = new SolidBrush(Color.Black);

            switch (a)
            {
                //birinci sayfa

                case 1:
                    ////////////////////////Yeni Kod Başlangıç//////////////////////////
                    // string tc = "";
                    // string strPdfPath = @"C:\Dosyalar\ciktiForm.pdf";
                    //string strPdfPath = @"C:\\Dosyalar\\"+mtxt_tc_no.Text+"\\";
                    string dosya_yolu = "C:\\Dosyalar\\" + mtxt_tc_no.Text;
                    if (Directory.Exists(dosya_yolu))
                    {
                        // MessageBox.Show("Dosya bulundu", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        try
                        {
                            Directory.CreateDirectory(@"C://Dosyalar/" + mtxt_tc_no.Text + "/");
                            //  MessageBox.Show("Dosya başarılı bir şekilde oluşturulmuştur.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Exception)
                        {

                            // MessageBox.Show("Dosya oluşturulamadı", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    string strPdfPath = @"C://Dosyalar/" + mtxt_tc_no.Text + "/" + mtxt_tc_no.Text + "_" + "Tüm_Bilgiler.pdf";

                    //string yeniad = mtxt_tc_no.Text + "_" + "bilgiler.pdf"; //Benzersiz isim verme

                    //   "C:\\Dosyalar\\" + mtxt_tc_no.Text;

                    //string strPdfPath = @"C://Dosyalar/" + mtxt_tc_no.Text + "/" + mtxt_tc_no.Text + "_Tüm Bilgileri" + ".pdf";

                    System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
                    //Document document = new Document();

                    Document document = new Document(PageSize.A4, 10f, 10f, 10f, 10f);//???

                    document.SetPageSize(iTextSharp.text.PageSize.A4);

                    PdfWriter writer = PdfWriter.GetInstance(document, fs);//yazıyorrr 
                    document.Open();


                    Bitmap MemoryImage;

                    Panel pnl;
                    pnl = panel_genel_bilgiler;
                    MemoryImage = new Bitmap(pnl.Width, pnl.Height);
                    System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, pnl.Width, pnl.Height);
                    pnl.DrawToBitmap(MemoryImage, new System.Drawing.Rectangle(0, 0, pnl.Width, pnl.Height));

                    iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(MemoryImage, System.Drawing.Imaging.ImageFormat.Png);




                    Bitmap MemoryImage2;

                    Panel pnl2;
                    pnl2 = panel_saglik;
                    MemoryImage2 = new Bitmap(pnl2.Width, pnl2.Height);
                    System.Drawing.Rectangle rect2 = new System.Drawing.Rectangle(0, 0, pnl2.Width, pnl2.Height);
                    pnl2.DrawToBitmap(MemoryImage2, pnl2.ClientRectangle);
                    //pnl2.DrawToBitmap(MemoryImage2, new System.Drawing.Rectangle(0, 0, pnl2.Width, pnl2.Height));

                    iTextSharp.text.Image png2 = iTextSharp.text.Image.GetInstance(MemoryImage2, System.Drawing.Imaging.ImageFormat.Png);


                    Bitmap MemoryImage3;

                    Panel pnl3;
                    pnl3 = panel_iletisim;
                    MemoryImage3 = new Bitmap(pnl3.Width, pnl3.Height);
                    System.Drawing.Rectangle rect3 = new System.Drawing.Rectangle(0, 0, pnl3.Width, pnl3.Height);
                    pnl3.DrawToBitmap(MemoryImage3, new System.Drawing.Rectangle(0, 0, pnl3.Width, pnl3.Height));

                    iTextSharp.text.Image png3 = iTextSharp.text.Image.GetInstance(MemoryImage3, System.Drawing.Imaging.ImageFormat.Png);


                    Bitmap MemoryImage4;

                    Panel pnl4;
                    pnl4 = panel_ulasim;
                    MemoryImage4 = new Bitmap(pnl4.Width, pnl4.Height);
                    System.Drawing.Rectangle rect4 = new System.Drawing.Rectangle(0, 0, pnl4.Width, pnl4.Height);
                    pnl4.DrawToBitmap(MemoryImage4, new System.Drawing.Rectangle(0, 0, pnl4.Width, pnl4.Height));

                    iTextSharp.text.Image png4 = iTextSharp.text.Image.GetInstance(MemoryImage4, System.Drawing.Imaging.ImageFormat.Png);

                    //Bitmap MemoryImage6;

                    //MemoryImage6 = new Bitmap(picb_resim.Width, picb_resim.Height);
                    //System.Drawing.Rectangle rect6 = new System.Drawing.Rectangle(0, 0, picb_resim.Width, picb_resim.Height);
                    //picb_resim.Image.RawFormat(Stream, ImageFormatConverter);
                    //(MemoryImage, new System.Drawing.Rectangle(0, 0, picb_resim.Width, picb_resim.Height));

                    //iTextSharp.text.Image png6 = iTextSharp.text.Image.GetInstance(MemoryImage6, System.Drawing.Imaging.ImageFormat.Png);



                    //Bitmap MemoryImage5;

                    //Panel pnl5;
                    //pnl5 = panel_ulasim;
                    //MemoryImage5 = new Bitmap(pnl5.Width, pnl5.Height);
                    //System.Drawing.Rectangle rect5 = new System.Drawing.Rectangle(0, 0, pnl5.Width, pnl5.Height);
                    //pnl5.DrawToBitmap(MemoryImage5, new System.Drawing.Rectangle(0, 0, pnl5.Width, pnl5.Height));

                    //iTextSharp.text.Image png5 = iTextSharp.text.Image.GetInstance(MemoryImage5, System.Drawing.Imaging.ImageFormat.Png);

                    /*
                    iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(picb_resim.Image, System.Drawing.Imaging.ImageFormat.Jpeg);

                    png.ScaleAbsolute(90, 90);//pdf deki resmi boyutlandırma.*/


                    DataTable t1 = new DataTable();

                    DataTable t2 = new DataTable();

                    DataTable t3 = new DataTable();

                    DataTable t4 = new DataTable();

                    DataTable t5 = new DataTable();

                    DataTable t6 = new DataTable();

                    DataTable t7 = new DataTable();

                    DataTable t8 = new DataTable();

                    DataTable t9 = new DataTable();

                    DataTable t10 = new DataTable();

                    DataTable t11 = new DataTable();

                    DataTable t12 = new DataTable();

                    DataTable t13 = new DataTable();

                    DataTable t14 = new DataTable();

                    DataTable t15 = new DataTable();

                    DataTable t16 = new DataTable();

                    DataTable t17 = new DataTable();

                    //eğitim bilgisi girilmiş mi diye sorgulamak lazım


                    bool kayitkontrolegitim = false;//bir kayıt yaparken daha önceden böyle bir kullanıcı var mı diye kontrolü yapılacak
                                                    //baglantim.baglanti().Open();
                    SqlCommand selectsorgu = new SqlCommand("select * from Kisi_Egitim_Bilgisi where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

                    SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.
                                                                           //ilgili tc no ya ait vb de kayıt vamı diye kontrol edelim.

                    //while (kayitokuma.Read())
                    //{
                    kayitkontrolegitim = true;//ilgili tc noya ait bir kullanıcı var demektir.
                    SqlCommand sorgu1 = new SqlCommand("Listele_Egitim_Bilgisi_Cikti", baglantim.baglanti());
                    sorgu1.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae1 = new SqlDataAdapter(sorgu1);
                    sorgu1.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
                    dae1.Fill(t1);
                    //    break;

                    //}
                    //eğitim bilgisi girilmiş mi diye sorgulamak lazım


                    //bool kayitkontrolesaglik = false;//bir kayıt yaparken daha önceden böyle bir kullanıcı var mı diye kontrolü yapılacak
                    //                                //baglantim.baglanti().Open();
                    //SqlCommand selectsorgu2 = new SqlCommand("select * from Kisi_Saglik_Bilgisi where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

                    //SqlDataReader kayitokuma2 = selectsorgu2.ExecuteReader();//okuduğu sorguları tutuyoruz.
                    //                                                       //ilgili tc no ya ait vb de kayıt vamı diye kontrol edelim.

                    //while (kayitokuma2.Read())
                    //{
                    //kayitkontrolesaglik = true;
                    SqlCommand sorgu2 = new SqlCommand("Listele_Kisi_Saglik_Bilgisi_Cikti", baglantim.baglanti());
                    sorgu2.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae2 = new SqlDataAdapter(sorgu2);
                    sorgu2.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae2.Fill(t2);
                    //}

                    SqlCommand sorgu3 = new SqlCommand("Listeler_Ilestisim_Bilgisi_cikti", baglantim.baglanti());
                    sorgu3.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae3 = new SqlDataAdapter(sorgu3);

                    sorgu3.Parameters.AddWithValue("@tc_bilgisi", mtxt_tc_no.Text);
                    dae3.Fill(t3);

                    SqlCommand sorgu4 = new SqlCommand("Listele_Bilgisayar_Bilgisi_Cikti", baglantim.baglanti());
                    sorgu4.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae4 = new SqlDataAdapter(sorgu4);
                    sorgu4.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae4.Fill(t4);

                    SqlCommand sorgu5 = new SqlCommand("Listele_Yabanci_Dil_Cikti", baglantim.baglanti());
                    sorgu5.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae5 = new SqlDataAdapter(sorgu5);
                    sorgu5.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae5.Fill(t5);


                    SqlCommand sorgu6 = new SqlCommand("Kisi_Sertifika_Bilgileri_Cikti", baglantim.baglanti());
                    sorgu6.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae6 = new SqlDataAdapter(sorgu6);
                    sorgu6.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae6.Fill(t6);



                    SqlCommand sorgu7 = new SqlCommand("Kisi_Sertifika_Agir_is_Cikti", baglantim.baglanti());
                    sorgu7.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae7 = new SqlDataAdapter(sorgu7);
                    sorgu7.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae7.Fill(t7);


                    SqlCommand sorgu8 = new SqlCommand("Listele_Ozgecmis_isyeri_Cikti", baglantim.baglanti());
                    sorgu8.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae8 = new SqlDataAdapter(sorgu8);
                    sorgu8.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae8.Fill(t8);


                    SqlCommand sorgu9 = new SqlCommand("Listele_kkd_Cikti", baglantim.baglanti());
                    sorgu9.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae9 = new SqlDataAdapter(sorgu9);
                    sorgu9.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                    dae9.Fill(t9);


                    SqlCommand sorgu10 = new SqlCommand("Listele_Borc_Bilgisi_Cikti", baglantim.baglanti());
                    sorgu10.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae10 = new SqlDataAdapter(sorgu10);
                    sorgu10.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae10.Fill(t10);


                    SqlCommand sorgu11 = new SqlCommand("Listele_Maddi_Durum_Listele", baglantim.baglanti());
                    sorgu11.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae11 = new SqlDataAdapter(sorgu11);
                    sorgu11.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae11.Fill(t11);


                    SqlCommand sorgu12 = new SqlCommand("Listele_Bakim_Bilgileri_Cikti", baglantim.baglanti());
                    sorgu12.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae12 = new SqlDataAdapter(sorgu12);
                    sorgu12.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae12.Fill(t12);


                    SqlCommand sorgu13 = new SqlCommand("Listele_Yakin_Bilgileri_Cikti", baglantim.baglanti());
                    sorgu13.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae13 = new SqlDataAdapter(sorgu13);
                    sorgu13.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae13.Fill(t13);

                    SqlCommand sorgu14 = new SqlCommand("Listele_Yakin_Saglik_Bilgileri_Cikti", baglantim.baglanti());
                    sorgu14.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae14 = new SqlDataAdapter(sorgu14);
                    sorgu14.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae14.Fill(t14);


                    SqlCommand sorgu15 = new SqlCommand("Listele_Yakin_Egitim_Bilgileri_Cikti", baglantim.baglanti());
                    sorgu15.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae15 = new SqlDataAdapter(sorgu15);
                    sorgu15.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae15.Fill(t15);

                    SqlCommand sorgu16 = new SqlCommand("Listele_Yakin_Calisma_Bilgileri_Cikti", baglantim.baglanti());
                    sorgu16.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae16 = new SqlDataAdapter(sorgu16);
                    sorgu16.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae16.Fill(t16);


                    SqlCommand sorgu17 = new SqlCommand("Listele_Yakin_gyk_Bilgileri_Cikti", baglantim.baglanti());
                    sorgu17.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae17 = new SqlDataAdapter(sorgu11);
                    sorgu17.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae17.Fill(t17);

                    PdfPTable table1 = new PdfPTable(t1.Columns.Count);

                    PdfPTable table2 = new PdfPTable(t2.Columns.Count);

                    PdfPTable table3 = new PdfPTable(t3.Columns.Count);

                    PdfPTable table4 = new PdfPTable(t4.Columns.Count);

                    PdfPTable table5 = new PdfPTable(t5.Columns.Count);

                    PdfPTable table6 = new PdfPTable(t6.Columns.Count);

                    PdfPTable table7 = new PdfPTable(t7.Columns.Count);

                    PdfPTable table8 = new PdfPTable(t8.Columns.Count);

                    PdfPTable table9 = new PdfPTable(t9.Columns.Count);

                    PdfPTable table10 = new PdfPTable(t10.Columns.Count);

                    PdfPTable table11 = new PdfPTable(t11.Columns.Count);

                    PdfPTable table12 = new PdfPTable(t12.Columns.Count);

                    PdfPTable table13 = new PdfPTable(t13.Columns.Count);

                    PdfPTable table14 = new PdfPTable(t14.Columns.Count);

                    PdfPTable table15 = new PdfPTable(t15.Columns.Count);

                    PdfPTable table16 = new PdfPTable(t16.Columns.Count);

                    PdfPTable table17 = new PdfPTable(t17.Columns.Count);


                    //BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                    BaseFont btnColumnHeader = BaseFont.CreateFont(@"C:\Windows\Fonts\Calibri.ttf", "Identity-H", BaseFont.EMBEDDED);
                    //iTextSharp.text.Font fntColumnHeader = new Font(btnColumnHeader, 6, 0, Color.BLACK);
                    iTextSharp.text.Font fntColumnHeader = new iTextSharp.text.Font(btnColumnHeader, 6, 1, iTextSharp.text.BaseColor.BLACK);
                    if (t1.Rows.Count > 0)
                    {
                        //t1 için
                        for (int i = 0; i < t1.Columns.Count; i++)
                        {
                            PdfPCell cell_1 = new PdfPCell();
                            cell_1.AddElement(new Chunk(t1.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table1.AddCell(cell_1);
                        }

                        for (int i = 0; i < t1.Rows.Count; i++)
                        {
                            for (int j = 0; j < t1.Columns.Count; j++)
                            {
                                PdfPCell cell_1_1 = new PdfPCell();
                                cell_1_1.AddElement(new Chunk(t1.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table1.AddCell(cell_1_1);
                            }
                        }

                    }
                    if (t2.Rows.Count > 0)
                    {
                        //t2için
                        for (int i = 0; i < t2.Columns.Count; i++)
                        {
                            PdfPCell cell_2 = new PdfPCell();
                            cell_2.AddElement(new Chunk(t2.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table2.AddCell(cell_2);
                        }

                        for (int i = 0; i < t2.Rows.Count; i++)
                        {
                            for (int j = 0; j < t2.Columns.Count; j++)
                            {
                                PdfPCell cell_2_1 = new PdfPCell();
                                cell_2_1.AddElement(new Chunk(t2.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table2.AddCell(cell_2_1);
                            }
                        }
                    }
                    //t3için
                    if (t3.Rows.Count > 0)
                    {
                        for (int i = 0; i < t3.Columns.Count; i++)
                        {
                            PdfPCell cell_3 = new PdfPCell();
                            cell_3.AddElement(new Chunk(t3.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table3.AddCell(cell_3);
                        }

                        for (int i = 0; i < t3.Rows.Count; i++)
                        {
                            for (int j = 0; j < t3.Columns.Count; j++)
                            {
                                PdfPCell cell_3_1 = new PdfPCell();
                                cell_3_1.AddElement(new Chunk(t3.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table3.AddCell(cell_3_1);
                            }
                        }

                    }
                    if (t4.Rows.Count > 0)
                    {
                        //t4için
                        for (int i = 0; i < t4.Columns.Count; i++)
                        {
                            PdfPCell cell_4 = new PdfPCell();
                            cell_4.AddElement(new Chunk(t4.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table4.AddCell(cell_4);
                        }

                        for (int i = 0; i < t4.Rows.Count; i++)
                        {
                            for (int j = 0; j < t4.Columns.Count; j++)
                            {
                                PdfPCell cell_4_1 = new PdfPCell();
                                cell_4_1.AddElement(new Chunk(t4.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table4.AddCell(cell_4_1);
                            }
                        }
                    }
                    //t5için
                    if (t5.Rows.Count > 0)
                    {
                        for (int i = 0; i < t5.Columns.Count; i++)
                        {
                            PdfPCell cell_5 = new PdfPCell();
                            cell_5.AddElement(new Chunk(t5.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table5.AddCell(cell_5);
                        }

                        for (int i = 0; i < t5.Rows.Count; i++)
                        {
                            for (int j = 0; j < t5.Columns.Count; j++)
                            {
                                PdfPCell cell_5_1 = new PdfPCell();
                                cell_5_1.AddElement(new Chunk(t5.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table5.AddCell(cell_5_1);
                            }
                        }
                    }
                    if (t6.Rows.Count > 0)
                    {
                        //t6için
                        for (int i = 0; i < t6.Columns.Count; i++)
                        {
                            PdfPCell cell_6 = new PdfPCell();
                            cell_6.AddElement(new Chunk(t6.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table6.AddCell(cell_6);
                        }

                        for (int i = 0; i < t6.Rows.Count; i++)
                        {
                            for (int j = 0; j < t6.Columns.Count; j++)
                            {
                                PdfPCell cell_6_1 = new PdfPCell();
                                cell_6_1.AddElement(new Chunk(t6.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table6.AddCell(cell_6_1);
                            }
                        }
                    }
                    if (t7.Rows.Count > 0)
                    {

                        //t7için
                        for (int i = 0; i < t7.Columns.Count; i++)
                        {
                            PdfPCell cell_7 = new PdfPCell();
                            cell_7.AddElement(new Chunk(t7.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table7.AddCell(cell_7);
                        }

                        for (int i = 0; i < t7.Rows.Count; i++)
                        {
                            for (int j = 0; j < t7.Columns.Count; j++)
                            {
                                PdfPCell cell_7_1 = new PdfPCell();
                                cell_7_1.AddElement(new Chunk(t7.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table7.AddCell(cell_7_1);
                            }
                        }
                    }
                    if (t8.Rows.Count > 0)
                    {
                        //t8için
                        for (int i = 0; i < t8.Columns.Count; i++)
                        {
                            PdfPCell cell_8 = new PdfPCell();
                            cell_8.AddElement(new Chunk(t8.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table8.AddCell(cell_8);
                        }

                        for (int i = 0; i < t8.Rows.Count; i++)
                        {
                            for (int j = 0; j < t8.Columns.Count; j++)
                            {
                                PdfPCell cell_8_1 = new PdfPCell();
                                cell_8_1.AddElement(new Chunk(t8.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table8.AddCell(cell_8_1);
                            }
                        }
                    }
                    if (t9.Rows.Count > 0)
                    {
                        //t9 için
                        for (int i = 0; i < t9.Columns.Count; i++)
                        {
                            PdfPCell cell_9 = new PdfPCell();
                            cell_9.AddElement(new Chunk(t9.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table9.AddCell(cell_9);
                        }

                        for (int i = 0; i < t9.Rows.Count; i++)
                        {
                            for (int j = 0; j < t9.Columns.Count; j++)
                            {
                                PdfPCell cell_9_1 = new PdfPCell();
                                cell_9_1.AddElement(new Chunk(t9.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table9.AddCell(cell_9_1);
                            }
                        }
                    }
                    if (t10.Rows.Count > 0)
                    {

                        //t10için
                        for (int i = 0; i < t10.Columns.Count; i++)
                        {
                            PdfPCell cell_10 = new PdfPCell();
                            cell_10.AddElement(new Chunk(t10.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table10.AddCell(cell_10);
                        }

                        for (int i = 0; i < t10.Rows.Count; i++)
                        {
                            for (int j = 0; j < t10.Columns.Count; j++)
                            {
                                PdfPCell cell_10_1 = new PdfPCell();
                                cell_10_1.AddElement(new Chunk(t10.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table10.AddCell(cell_10_1);
                            }
                        }
                    }
                    if (t11.Rows.Count > 0)
                    {
                        //t11için
                        for (int i = 0; i < t11.Columns.Count; i++)
                        {
                            PdfPCell cell_11 = new PdfPCell();
                            cell_11.AddElement(new Chunk(t11.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table11.AddCell(cell_11);
                        }

                        for (int i = 0; i < t11.Rows.Count; i++)
                        {
                            for (int j = 0; j < t11.Columns.Count; j++)
                            {
                                PdfPCell cell_11_1 = new PdfPCell();
                                cell_11_1.AddElement(new Chunk(t11.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table11.AddCell(cell_11_1);
                            }
                        }
                    }
                    if (t12.Rows.Count > 0)
                    {
                        //t12için
                        for (int i = 0; i < t12.Columns.Count; i++)
                        {
                            PdfPCell cell_12 = new PdfPCell();
                            cell_12.AddElement(new Chunk(t12.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table12.AddCell(cell_12);
                        }

                        for (int i = 0; i < t12.Rows.Count; i++)
                        {
                            for (int j = 0; j < t12.Columns.Count; j++)
                            {
                                PdfPCell cell_12_1 = new PdfPCell();
                                cell_12_1.AddElement(new Chunk(t12.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table12.AddCell(cell_12_1);
                            }
                        }
                    }
                    if (t13.Rows.Count > 0)
                    {
                        //t13için
                        for (int i = 0; i < t13.Columns.Count; i++)
                        {
                            PdfPCell cell_13 = new PdfPCell();
                            cell_13.AddElement(new Chunk(t13.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table13.AddCell(cell_13);
                        }

                        for (int i = 0; i < t13.Rows.Count; i++)
                        {
                            for (int j = 0; j < t13.Columns.Count; j++)
                            {
                                PdfPCell cell_13_1 = new PdfPCell();
                                cell_13_1.AddElement(new Chunk(t13.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table13.AddCell(cell_13_1);
                            }
                        }
                    }
                    if (t14.Rows.Count > 0)
                    {
                        //t14için
                        for (int i = 0; i < t14.Columns.Count; i++)
                        {
                            PdfPCell cell_14 = new PdfPCell();
                            cell_14.AddElement(new Chunk(t14.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table14.AddCell(cell_14);
                        }

                        for (int i = 0; i < t14.Rows.Count; i++)
                        {
                            for (int j = 0; j < t14.Columns.Count; j++)
                            {
                                PdfPCell cell_14_1 = new PdfPCell();
                                cell_14_1.AddElement(new Chunk(t14.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table14.AddCell(cell_14_1);
                            }
                        }
                    }
                    if (t15.Rows.Count > 0)
                    {
                        //t15için
                        for (int i = 0; i < t15.Columns.Count; i++)
                        {
                            PdfPCell cell_15 = new PdfPCell();
                            cell_15.AddElement(new Chunk(t15.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table15.AddCell(cell_15);
                        }

                        for (int i = 0; i < t15.Rows.Count; i++)
                        {
                            for (int j = 0; j < t15.Columns.Count; j++)
                            {
                                PdfPCell cell_15_1 = new PdfPCell();
                                cell_15_1.AddElement(new Chunk(t15.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table15.AddCell(cell_15_1);
                            }
                        }
                    }
                    if (t16.Rows.Count > 0)
                    {
                        //t16için
                        for (int i = 0; i < t16.Columns.Count; i++)
                        {
                            PdfPCell cell_16 = new PdfPCell();
                            cell_16.AddElement(new Chunk(t16.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table16.AddCell(cell_16);
                        }

                        for (int i = 0; i < t16.Rows.Count; i++)
                        {
                            for (int j = 0; j < t16.Columns.Count; j++)
                            {
                                PdfPCell cell_16_1 = new PdfPCell();
                                cell_16_1.AddElement(new Chunk(t16.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table16.AddCell(cell_16_1);
                            }
                        }
                    }
                    if (t17.Rows.Count > 0)
                    {
                        //t17için
                        for (int i = 0; i < t17.Columns.Count; i++)
                        {
                            PdfPCell cell_17 = new PdfPCell();
                            cell_17.AddElement(new Chunk(t17.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table17.AddCell(cell_17);
                        }

                        for (int i = 0; i < t17.Rows.Count; i++)
                        {
                            for (int j = 0; j < t17.Columns.Count; j++)
                            {
                                PdfPCell cell_17_1 = new PdfPCell();
                                cell_17_1.AddElement(new Chunk(t17.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table17.AddCell(cell_17_1);
                            }
                        }
                    }
                    /*
                    //t18için
                    for (int i = 0; i < t18.Columns.Count; i++)
                    {
                        PdfPCell cell_18 = new PdfPCell();
                        cell_18.AddElement(new Chunk(t18.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                        table18.AddCell(cell_18);
                    }

                    for (int i = 0; i < t18.Rows.Count; i++)
                    {
                        for (int j = 0; j < t18.Columns.Count; j++)
                        {
                            PdfPCell cell_18_1 = new PdfPCell();
                            cell_18_1.AddElement(new Chunk(t18.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                            table18.AddCell(cell_18_1);
                        }
                    }
                    */



                    iTextSharp.text.pdf.BaseFont STF_Helvetica_Turkish = iTextSharp.text.pdf.BaseFont.CreateFont("Helvetica", "CP1254", iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, iTextSharp.text.Font.NORMAL);
                    Paragraph bosluk = new Paragraph();
                    //BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    BaseFont btnAuthor = BaseFont.CreateFont(@"C:\Windows\Fonts\Calibri.ttf", "Identity-H", BaseFont.EMBEDDED);
                    iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(STF_Helvetica_Turkish, 12, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    bosluk.Add(new Chunk(" \n                                                              " + "PERSONEL BİLGİ FORMU", fntAuthor));
                    bosluk.Add(new Chunk("\n", fntAuthor));

                    Paragraph prgAuthor1 = new Paragraph();
                    prgAuthor1.Add(new Chunk("Başlık 1 : " + label1.Text, fntAuthor));



                    Paragraph prgAuthor2 = new Paragraph();
                    prgAuthor2.Add(new Chunk("Başlık 2 : " + label6.Text, fntAuthor));



                    Paragraph prgAuthor3 = new Paragraph();
                    prgAuthor3.Add(new Chunk("Başlık 3 : " + label2.Text + "\n", fntAuthor));////iletişim bilgileri

                    Paragraph prgAuthor4 = new Paragraph();
                    prgAuthor4.Add(new Chunk("Başlık 4 : " + label10.Text + "\n", fntAuthor));//firma imkanları bilgisi

                    Paragraph prgAuthor5 = new Paragraph();
                    prgAuthor5.Add(new Chunk("Başlık 5 : " + label4.Text + "\n", fntAuthor));//eğitim bilgisi

                    //iTextSharp.text.pdf.BaseFont STF_Helvetica_Turkish = iTextSharp.text.pdf.BaseFont.CreateFont("Helvetica", "CP1254", iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);
                    //iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, iTextSharp.text.Font.NORMAL);
                    Paragraph egitim = new Paragraph();
                    BaseFont btnegitim = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntegitim = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    egitim.Add(new Chunk(" \n                                                              " + "Personele ait eğitim bilgilerini giriniz.", fntegitim));
                    egitim.Add(new Chunk("\n", fntegitim));

                    Paragraph prgAuthor6 = new Paragraph();
                    prgAuthor6.Add(new Chunk("Başlık 6 : " + label6.Text + "\n", fntAuthor));//sağlık bilgisi

                    Paragraph saglik = new Paragraph();
                    BaseFont btnsaglik = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntsaglik = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    saglik.Add(new Chunk(" \n                                                              " + "Personele ait saglik bilgilerini giriniz.", fntsaglik));
                    saglik.Add(new Chunk("\n", fntsaglik));

                    Paragraph prgAuthor7 = new Paragraph();
                    prgAuthor7.Add(new Chunk("Başlık 7 : " + label2.Text + "\n", fntAuthor));//iletişim bilgisi

                    Paragraph iletisim = new Paragraph();
                    BaseFont btniletisim = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntiletisim = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    iletisim.Add(new Chunk(" \n                                                              " + "Personele ait iletişim bilgilerini giriniz.", fntiletisim));
                    iletisim.Add(new Chunk("\n", fntiletisim));



                    Paragraph prgAuthor8 = new Paragraph();
                    prgAuthor8.Add(new Chunk("Başlık 6 : " + "Bilgisayar Bilgisi" + "\n", fntAuthor));

                    Paragraph bilgisayar = new Paragraph();
                    BaseFont btnbilgisayar = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntbilgisayar = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    bilgisayar.Add(new Chunk(" \n                                                              " + "Personele ait bilgisayar program bilgisi giriniz.", fntbilgisayar));
                    bilgisayar.Add(new Chunk("\n", fntbilgisayar));

                    Paragraph prgAuthor9 = new Paragraph();
                    prgAuthor9.Add(new Chunk("Başlık 7 : " + "Yabancı Dil Bilgisi" + "\n", fntAuthor));

                    Paragraph dil = new Paragraph();
                    BaseFont btndil = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntdil = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    dil.Add(new Chunk(" \n                                                              " + "Personele ait yabancı dil bilgisi giriniz.", fntdil));
                    dil.Add(new Chunk("\n", fntdil));

                    Paragraph prgAuthor10 = new Paragraph();
                    prgAuthor10.Add(new Chunk("Başlık 8 : " + "Sertifika Bilgisi" + "\n", fntAuthor));

                    Paragraph sertifika = new Paragraph();
                    BaseFont btnsertifika = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntsertifika = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    sertifika.Add(new Chunk(" \n                                                              " + "Personele ait sertifika bilgisi giriniz.", fntsertifika));
                    sertifika.Add(new Chunk("\n", fntsertifika));

                    Paragraph prgAuthor11 = new Paragraph();
                    prgAuthor11.Add(new Chunk("Başlık 9 : " + "Ağır İş Sertifikası" + "\n", fntAuthor));

                    Paragraph sertifikaa = new Paragraph();
                    BaseFont btnsertifikaa = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntsertifikaa = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    sertifikaa.Add(new Chunk(" \n                                                              " + "Personele ait varsa ağır iş sertifika bilgisi giriniz.", fntsertifikaa));
                    sertifikaa.Add(new Chunk("\n", fntsertifikaa));

                    Paragraph prgAuthor12 = new Paragraph();
                    prgAuthor12.Add(new Chunk("Başlık 11 : " + label7.Text + "\n", fntAuthor));

                    Paragraph cv = new Paragraph();
                    BaseFont btncv = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntcv = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    cv.Add(new Chunk(" \n                                                              " + "Personele ait varsa öz geçmiş bilgisi giriniz.", fntcv));
                    cv.Add(new Chunk("\n", fntcv));

                    Paragraph prgAuthor13 = new Paragraph();
                    prgAuthor13.Add(new Chunk("Başlık 12 : " + label9.Text + "\n", fntAuthor));

                    Paragraph kkd = new Paragraph();
                    BaseFont btnkkd = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntkkd = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    kkd.Add(new Chunk(" \n                                                              " + "Personele ait varsa iş sağlığı ve güvenliği malzeme bilgisi giriniz.", fntkkd));
                    kkd.Add(new Chunk("\n", fntkkd));

                    Paragraph prgAuthor14 = new Paragraph();
                    prgAuthor14.Add(new Chunk("Başlık 13 : " + label72.Text + "\n", fntAuthor));

                    Paragraph borc = new Paragraph();
                    BaseFont btnborc = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntborc = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    borc.Add(new Chunk(" \n                                                              " + "Personele ait herhangibir borç bilgisi yoktur.", fntborc));
                    borc.Add(new Chunk("\n", fntborc));


                    Paragraph prgAuthor15 = new Paragraph();
                    prgAuthor15.Add(new Chunk("Başlık 14 : " + label8.Text + "\n", fntAuthor));

                    Paragraph maddi = new Paragraph();
                    BaseFont btnmaddi = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntmaddi = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    maddi.Add(new Chunk(" \n                                                              " + "Personele ait maddi durum bilgisi giriniz.", fntmaddi));
                    maddi.Add(new Chunk("\n", fntmaddi));

                    Paragraph prgAuthor16 = new Paragraph();
                    prgAuthor16.Add(new Chunk("Başlık 15 : " + label55.Text + "\n", fntAuthor));


                    Paragraph bakim = new Paragraph();
                    BaseFont btnbakim = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntbakim = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    bakim.Add(new Chunk(" \n                                                              " + "Personelin bakımı ile ilgilendiği herhangi bir birey yoktur.", fntbakim));
                    bakim.Add(new Chunk("\n", fntbakim));

                    Paragraph prgAuthor17 = new Paragraph();
                    prgAuthor17.Add(new Chunk("Başlık 16 : " + "Çekirdek Aileye Ait Temel Bilgiler" + "\n", fntAuthor));

                    Paragraph yakın1 = new Paragraph();
                    BaseFont btnyakın1 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntyakın1 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    yakın1.Add(new Chunk(" \n                                                              " + "Personelin çekirdek ailesine ait personel bilgisi yoktur.", fntyakın1));
                    yakın1.Add(new Chunk("\n", fntyakın1));

                    Paragraph prgAuthor18 = new Paragraph();
                    prgAuthor18.Add(new Chunk("Başlık 17 : " + "Çekirdek Aileye Ait Sağlık Bilgileri" + "\n", fntAuthor));

                    Paragraph yakın2 = new Paragraph();
                    BaseFont btnyakın2 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntyakın2 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    yakın2.Add(new Chunk(" \n                                                              " + "Personelin çekirdek ailesine ait personel bilgisi yoktur.", fntyakın2));
                    yakın2.Add(new Chunk("\n", fntyakın2));

                    Paragraph prgAuthor19 = new Paragraph();
                    prgAuthor19.Add(new Chunk("Başlık 18 : " + "Çekirdek Aileye Ait Eğitim Bilgileri" + "\n", fntAuthor));

                    Paragraph yakın3 = new Paragraph();
                    BaseFont btnyakın3 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntyakın3 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    yakın3.Add(new Chunk(" \n                                                              " + "Personelin çekirdek ailesine ait personel bilgisi yoktur.", fntyakın3));
                    yakın3.Add(new Chunk("\n", fntyakın3));

                    Paragraph prgAuthor20 = new Paragraph();
                    prgAuthor20.Add(new Chunk("Başlık 19 : " + "Çekirdek Aileye Ait Çalışan Bilgisi" + "\n", fntAuthor));

                    Paragraph yakın4 = new Paragraph();
                    BaseFont btnyakın4 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntyakın4 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    yakın4.Add(new Chunk(" \n                                                              " + "Personelin çekirdek ailesine ait personel bilgisi yoktur.", fntyakın4));
                    yakın4.Add(new Chunk("\n", fntyakın4));

                    Paragraph prgAuthor21 = new Paragraph();
                    prgAuthor21.Add(new Chunk("Başlık 20 : " + "Çekirdek Aileye Ait Genel Kültür Bilgisi" + "\n", fntAuthor));

                    Paragraph yakın5 = new Paragraph();
                    BaseFont btnyakın5 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntyakın5 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    yakın5.Add(new Chunk(" \n                                                              " + "Personelin çekirdek ailesine ait personel bilgisi yoktur.", fntyakın5));
                    yakın5.Add(new Chunk("\n", fntyakın5));

                    Paragraph prgAuthor22 = new Paragraph();
                    prgAuthor22.Add(new Chunk("Başlık 10 : " + "Personelin hobileri" + "\n", fntAuthor));

                    Paragraph hobi = new Paragraph();
                    BaseFont btnhobi = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fnthobi = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    hobi.Add(new Chunk(" \n                                                              " + "Personelin kayıtlı bir hobisi yoktur.", fnthobi));
                    hobi.Add(new Chunk("\n", fnthobi));


                    Paragraph cocuk = new Paragraph();
                    BaseFont btncocuk = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntcocuk = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    cocuk.Add(new Chunk(" \n                Çocuk Sayısı=" + lbl_cocuk.Text, fntcocuk));
                    cocuk.Add(new Chunk("\n", fntcocuk));

                    Paragraph cocukyok = new Paragraph();
                    BaseFont btncocukyok = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntcocukyok = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    cocukyok.Add(new Chunk(" \n                  " + "Personelin kayıtlı cocuk bilgisi yoktur.", fntcocukyok));
                    cocukyok.Add(new Chunk("\n", fntcocukyok));


                    Paragraph hobii = new Paragraph();
                    BaseFont btnhobii = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fnthobii = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    hobii.Add(new Chunk(" \n                Hobileri=" + lbl_hobileri.Text, fnthobii));
                    hobii.Add(new Chunk("\n", fnthobii));

                    //////////////////////////////////////////////////////////////////////////////////////////////////////////
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                    /////////////////////////////////////////////////////////////////////////////////////////////////

                    Paragraph aylikGider = new Paragraph();
                    BaseFont btnaylikGider = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntaylikGider = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    aylikGider.Add(new Chunk(label56.Text + " : " + lbl_gider.Text, fntaylikGider));
                    //   aylikGider.Add(new Chunk("\n", fntaylikGider));

                    Paragraph sure = new Paragraph();
                    BaseFont btnsure = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntsure = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    sure.Add(new Chunk(label57.Text + " : " + lbl_sure.Text, fntsure));
                    //   sure.Add(new Chunk("\n", fntsure));

                    Paragraph vasita = new Paragraph();
                    BaseFont btnvasita = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntvasita = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    vasita.Add(new Chunk(label58.Text, fntvasita));
                    //   vasita.Add(new Chunk("\n", fntvasita));


                    Paragraph vasita1 = new Paragraph();
                    BaseFont btnvasita1 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntvasita1 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    vasita1.Add(new Chunk(label60.Text + " : " + lbl_v1.Text, fntvasita1));
                    //     vasita1.Add(new Chunk("\n", fntvasita1));

                    Paragraph vasita2 = new Paragraph();
                    BaseFont btnvasita2 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntvasita2 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    vasita2.Add(new Chunk(label61.Text + " : " + lbl_v2.Text, fntvasita2));
                    /// vasita2.Add(new Chunk("\n", fntvasita2));


                    Paragraph vasita3 = new Paragraph();
                    BaseFont btnvasita3 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntvasita3 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    vasita3.Add(new Chunk(label62.Text + " : " + lbl_3.Text, fntvasita3));
                    //vasita3.Add(new Chunk("\n", fntvasita3));

                    Paragraph vasita4 = new Paragraph();
                    BaseFont btnvasita4 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntvasita4 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    vasita4.Add(new Chunk(label63.Text + " : " + lbl_4.Text, fntvasita4));
                    //   vasita4.Add(new Chunk("\n", fntvasita4));

                    Paragraph vasita5 = new Paragraph();
                    BaseFont btnvasita5 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntvasita5 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    vasita5.Add(new Chunk(label64.Text + " : " + lbl_5.Text, fntvasita5));
                    //   vasita5.Add(new Chunk("\n", fntvasita5));

                    Paragraph vasita6 = new Paragraph();
                    BaseFont btnvasita6 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntvasita6 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    vasita6.Add(new Chunk(label65.Text + " : " + lbl_v6.Text, fntvasita6));
                    //     vasita6.Add(new Chunk("\n", fntvasita6));

                    Paragraph alarji = new Paragraph();
                    BaseFont btnalarji = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntalarji = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    alarji.Add(new Chunk(label68.Text + " : " + txt_alerji.Text, fntalarji));
                    //    alarji.Add(new Chunk("\n", fntalarji));




                    Paragraph yemek1 = new Paragraph();
                    BaseFont btnyemek1 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntyemek1 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    yemek1.Add(new Chunk(label69.Text + " " + lbl_yemek.Text, fntyemek1));
                    // yemek1.Add(new Chunk("\n", fntyemek1));


                    Paragraph yemek2 = new Paragraph();
                    BaseFont btnyemek2 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntyemek2 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    yemek2.Add(new Chunk(label71.Text + " : " + txt_neden.Text, fntyemek2));
                    //    yemek2.Add(new Chunk("\n", fntyemek2));


                    Paragraph talep = new Paragraph();
                    BaseFont btntalep = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fnttalep = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    talep.Add(new Chunk(label70.Text + " : " + txt_talep.Text, fnttalep));
                    //  talep.Add(new Chunk("\n", fnttalep));

                    //////////////////////////////////////////////////////////////////////////
                    ///////////////
                    ///
                    //////////////////////////////////////////////////////////////////////////

                    Paragraph tcbilgisi = new Paragraph();
                    BaseFont btntcbilgisi = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fnttcbilgisi = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    tcbilgisi.Add(new Chunk(label73.Text + " : " + lbl_tc.Text, fnttcbilgisi));

                    Paragraph adsoyad = new Paragraph();
                    BaseFont btnadsoyad = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntadsoyad = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    adsoyad.Add(new Chunk(label21.Text + " " + label22.Text + " : " + lbl_ad.Text + " " + lbl_soyad.Text, fntadsoyad));

                    Paragraph uyruk = new Paragraph();
                    BaseFont btnuyruk = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntuyruk = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    uyruk.Add(new Chunk(label23.Text + " : " + lbl_uyruk.Text, fntuyruk));

                    Paragraph cinsiyet = new Paragraph();
                    BaseFont btncinsiyet = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntcinsiyet = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    cinsiyet.Add(new Chunk(label24.Text + " : " + lbl_cinsiyet.Text, fntcinsiyet));

                    Paragraph medeni = new Paragraph();
                    BaseFont btnmedeni = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntmedeni = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    medeni.Add(new Chunk(label17.Text + " : " + lbl_medeni_hal.Text, fntmedeni));

                    Paragraph dogum = new Paragraph();
                    BaseFont btndogum = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntdogum = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    dogum.Add(new Chunk("DOĞUM YERİ/TARİHİ" + " : " + lbl_dogum_yeri.Text + " / " + lbl_dogum_tarihi.Text, fntdogum));

                    Paragraph baba = new Paragraph();
                    BaseFont btnbaba = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntbaba = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    baba.Add(new Chunk(label13.Text + " : " + lbl_baba_adi.Text, fntbaba));


                    Paragraph anne = new Paragraph();
                    BaseFont btnanne = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntanne = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    anne.Add(new Chunk(label20.Text + " : " + lbl_ana_adi.Text, fntanne));


                    Paragraph kod = new Paragraph();
                    BaseFont btnkod = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntkod = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    kod.Add(new Chunk(label14.Text + " : " + lbl_meslek_kodu.Text, fntkod));



                    Paragraph gorev = new Paragraph();
                    BaseFont btngorev = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntgorev = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    gorev.Add(new Chunk("GÖREV / YERİ" + " : " + lbl_görevi.Text + " / " + lbl_gorev_yeri.Text, fntgorev));

                    Paragraph durum = new Paragraph();
                    BaseFont btndurum = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntdurum = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    durum.Add(new Chunk("ÇALIŞMA SÜRESİ" + " : " + lbl_ise_giris.Text + " / " + lbl_isten_cikis.Text, fntdurum));

                    Paragraph dipnot = new Paragraph();
                    BaseFont btndipnot = BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntdipnot = new iTextSharp.text.Font(STF_Helvetica_Turkish, 6, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    dipnot.Add(new Chunk("~~Optimak İnsan Kaynakları Form Sonu" + "      /     " + DateTime.Now.ToString(), fntdipnot));


                    //MemoryStream ms = new MemoryStream();
                    //picb_resim.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //byte[] resim = ms.GetBuffer();



                    iTextSharp.text.Image resim = iTextSharp.text.Image.GetInstance(picb_resim.Image, System.Drawing.Imaging.ImageFormat.Jpeg);

                    resim.ScaleAbsolute(90, 90);//pdf deki resmi boyutlandırma.

                    ////////////////////////////////////////////////////////////////////
                    ///
                    ////////////////////////////////////////////////////////////////////


                    Paragraph ara = new Paragraph();
                    ara.Add(new Chunk("\n", fntAuthor));
                    {     /*



                    Paragraph prgAuthor = new Paragraph();
                    //BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    // iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(STF_Helvetica_Turkish, 12, 1, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    prgAuthor.Add(new Chunk("                                                               Başlık 1 : " + label1.Text, fntAuthor));
                    prgAuthor.Add(new Chunk("\n\n", fntAuthor));






                    //deneme
                    {
                        //prgAuthor.Add(new Chunk("\n\n\nTemel Kimlik Bilgileri\n", fntAuthor));
                        prgAuthor.Add(new Chunk(
                            textBox3.Text + textBox3.Text + lbl_tc_no.Text + " : " + mtxt_tc_no.Text + "\n" +
                            textBox3.Text + textBox3.Text + lbl_pdks.Text + " : " + txt_pdks.Text + "\n" +
                            textBox3.Text + textBox3.Text + "ADI SOYADI" + " : " + lbl_ad.Text + " " + lbl_soyad.Text + "\n" +
                            textBox3.Text + textBox3.Text + label23.Text + " : " + lbl_uyruk.Text + "\n" +
                            textBox3.Text + textBox3.Text + label24.Text + " : " + lbl_cinsiyet.Text + "\n" +
                            textBox3.Text + textBox3.Text + label17.Text + " : " + lbl_medeni_hal.Text + "\n" +
                            textBox3.Text + textBox3.Text + label18.Text + " : " + lbl_dogum_tarihi.Text + "\n" +
                            textBox3.Text + textBox3.Text + label19.Text + " : " + lbl_dogum_yeri.Text + "\n" +
                            textBox3.Text + textBox3.Text + label20.Text + " : " + lbl_ana_adi.Text + "\n" +
                            textBox3.Text + textBox3.Text + label13.Text + " : " + lbl_baba_adi.Text + "\n" +
                            textBox3.Text + textBox3.Text + label14.Text + " : " + lbl_meslek_kodu.Text + "\n" +
                            textBox3.Text + textBox3.Text + label15.Text + " : " + lbl_görevi.Text + "\n" +
                            textBox3.Text + textBox3.Text + label16.Text + " : " + lbl_gorev_yeri.Text + "\n" +
                            textBox3.Text + textBox3.Text + lbl_calisma_durumu.Text + " : " + lbl_durum.Text + "\n" +
                            textBox3.Text + textBox3.Text + label11.Text + " : " + lbl_ise_giris.Text + "\n" +
                            textBox3.Text + textBox3.Text + label12.Text + " : " + lbl_isten_cikis.Text + "\n" +
                            "\n\n"
                            , fntAuthor));

                        prgAuthor.Add(new Chunk("                                                               Başlık 2 : " + label10.Text, fntAuthor));
                        prgAuthor.Add(new Chunk("\n\n", fntAuthor));
                        prgAuthor.Add(new Chunk(
                             textBox3.Text + textBox3.Text + label56.Text + " : " + lbl_gider.Text + "\n" +
                             textBox3.Text + textBox3.Text + label57.Text + " : " + lbl_gider.Text + "\n" +
                             textBox3.Text + textBox3.Text + label58.Text + " ; " + "\n" +
                             textBox3.Text + textBox3.Text + label60.Text + " : " + lbl_v1.Text + "\n" +
                             textBox3.Text + textBox3.Text + label60.Text + " : " + lbl_v1.Text + textBox3.Text + textBox3.Text + textBox3.Text + textBox3.Text + label61.Text + " : " + lbl_v2.Text + "\n" +
                             textBox3.Text + textBox3.Text + label62.Text + " : " + lbl_3.Text + textBox3.Text + textBox3.Text + textBox3.Text + textBox3.Text + label61.Text + " : " + lbl_v2.Text + "\n" +
                             textBox3.Text + textBox3.Text + label64.Text + " : " + lbl_5.Text + textBox3.Text + textBox3.Text + textBox3.Text + textBox3.Text + label65.Text + " : " + lbl_v6.Text + "\n" +
                             textBox3.Text + textBox3.Text + label68.Text + " : " + txt_alerji.Text + "\n" +
                             textBox3.Text + textBox3.Text + label69.Text + " : " + lbl_yemek.Text + " ; " +
                             textBox3.Text + textBox3.Text + textBox3.Text + textBox3.Text + label71.Text + "  " + txt_neden.Text + "\n" +
                             textBox3.Text + textBox3.Text + label70.Text + " " + txt_talep.Text +
                                "\n\n"
                            , fntAuthor));



                        prgAuthor.Add(new Chunk("                                                               Başlık 3 : " + label3.Text, fntAuthor));
                        prgAuthor.Add(new Chunk("\n\n", fntAuthor));
                        prgAuthor.Add(new Chunk(
                             textBox3.Text + textBox3.Text + lbl_hobi.Text + " " + lbl_hobileri.Text +
                                "\n\n"
                            , fntAuthor));
                    }
                    e.Graphics.DrawString(label11.Text + " : " + lbl_ise_giris.Text, myFont1, sb1, 630, 100);

                    e.Graphics.DrawString(label23.Text + " : " + lbl_uyruk.Text, myFont1, sb1, 100, 125);
                    e.Graphics.DrawString(label19.Text + " : " + lbl_dogum_yeri.Text, myFont1, sb1, 255, 125);
                    e.Graphics.DrawString(label15.Text + " : " + lbl_görevi.Text, myFont1, sb1, 430, 125);
                    e.Graphics.DrawString(label12.Text + " : " + lbl_isten_cikis.Text, myFont1, sb1, 630, 125);
                    */
                    }
                    {
                        document.Add(resim);
                        document.Add(bosluk);

                        //document.Add(prgAuthor);
                        document.Add(prgAuthor1);//başlık 1

                        ///////////////////////////////////////////////////////
                        ///
                        /////////////////////////////////////////////////////////

                        // document.Add(png);

                        document.Add(tcbilgisi);
                        document.Add(adsoyad);
                        document.Add(uyruk);
                        document.Add(cinsiyet);
                        document.Add(medeni);
                        document.Add(dogum);
                        document.Add(baba);
                        document.Add(anne);
                        document.Add(kod);
                        document.Add(gorev);
                        document.Add(durum);



                        document.Add(ara);//araya boşluk tara


                        ///////////////////////////////////////////////////////
                        ///
                        /////////////////////////////////////////////////////////

                        document.Add(prgAuthor2);//başlık 2

                        //document.Add(png2);
                        document.Add(ara);//araya boşluk atar
                                          // document.Add(prgAuthor6);
                        if (t2.Rows.Count > 0)//sağlık kısmı için
                        {
                            document.Add(ara);
                            document.Add(table2);
                        }
                        else
                            document.Add(saglik);


                        document.Add(ara);//araya boşluk atar


                        document.Add(prgAuthor3);//başlık3

                        document.Add(ara);
                        //document.Add(prgAuthor7);
                        if (t3.Rows.Count > 0)//letişim tablosu
                        {
                            document.Add(ara);
                            document.Add(table3);
                        }
                        else
                            document.Add(iletisim);

                        document.Add(ara);

                        ///////////////////////////////////////////////////////
                        ///
                        /////////////////////////////////////////////////////////
                        document.Add(prgAuthor4);//başlık4
                                                 //document.Add(png4);//firma ikanları resmi


                        document.Add(ara);

                        if (lbl_gider.Text != "" && lbl_gider.Text != "...")
                        {
                            document.Add(aylikGider);
                        }
                        if (lbl_sure.Text != "" && lbl_sure.Text != "...")
                        {
                            document.Add(sure);
                        }
                        if (lbl_v1.Text != "" && lbl_v1.Text != "...")
                        {
                            document.Add(vasita);
                        }
                        if (lbl_v1.Text != "" && lbl_v1.Text != "...")
                        {
                            document.Add(vasita1);
                        }
                        if (lbl_v2.Text != "" && lbl_v2.Text != "...")
                        {
                            document.Add(vasita2);
                        }
                        if (lbl_3.Text != "" && lbl_3.Text != "...")
                        {
                            document.Add(vasita3);
                        }
                        if (lbl_4.Text != "" && lbl_4.Text != "...")
                        {
                            document.Add(vasita4);
                        }
                        if (lbl_5.Text != "" && lbl_5.Text != "...")
                        {
                            document.Add(vasita5);
                        }
                        if (lbl_v6.Text != "" && lbl_v6.Text != "...")
                        {
                            document.Add(vasita6);
                        }
                        if (txt_alerji.Text != "")
                        {
                            document.Add(alarji);
                        }
                        if (lbl_yemek.Text != "" && lbl_yemek.Text != "...")
                        {
                            document.Add(yemek1);
                        }
                        if (txt_neden.Text != "")
                        {
                            document.Add(yemek2);
                        }
                        if (txt_talep.Text != "")
                        {
                            document.Add(talep);
                        }

                        ///////////////////////////////////////////////////////
                        ///
                        /////////////////////////////////////////////////////////

                        document.Add(ara);//araya boşluk atar



                        document.Add(prgAuthor5);//başlık5

                        if (t1.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table1);//eğitim kısmı
                        }
                        else
                            document.Add(egitim);

                        document.Add(ara);




                        document.Add(prgAuthor8);//başlık6

                        if (t4.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table4);//bilgisayar becerisi
                        }
                        else
                            document.Add(bilgisayar);

                        document.Add(ara);


                        document.Add(prgAuthor9);//başlık7
                        if (t5.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table5);//yabancı dil
                        }
                        else
                            document.Add(dil);

                        document.Add(ara);



                        document.Add(prgAuthor10);//başlık8
                        if (t6.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table6);//sertifika 
                        }
                        else
                            document.Add(sertifika);
                        document.Add(ara);





                        document.Add(prgAuthor11);//başlık9
                        if (t7.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table7);//ağır iş sertifikası
                        }
                        else
                            document.Add(sertifikaa);

                        document.Add(ara);




                        document.Add(prgAuthor22);//başlık10
                        //document.Add(ara);

                        if (lbl_hobileri.Text == "...")
                            document.Add(hobi);
                        else
                            document.Add(hobii);

                        document.Add(ara);



                        document.Add(prgAuthor12);//başlık11
                        if (t8.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table8);//öz geçmiş
                        }
                        else
                            document.Add(cv);

                        document.Add(ara);

                        document.Add(prgAuthor13);//başlık12

                        if (t9.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table9);//isg-kkd
                        }
                        else
                            document.Add(kkd);

                        document.Add(ara);




                        document.Add(prgAuthor14);//başlık13
                        if (t10.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table10);//borç tablosu
                        }
                        else
                            document.Add(borc);
                        document.Add(ara);





                        document.Add(prgAuthor15);//başlık14
                        if (t11.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table11);//maddi durum tablosu
                        }
                        else
                            document.Add(maddi);
                        document.Add(ara);





                        document.Add(prgAuthor16);//başlık15
                        if (t12.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table12);//bakımı ile ilgili tablo
                        }
                        else
                            document.Add(bakim);
                        document.Add(ara);




                        document.Add(prgAuthor17);//başlık16

                        if (t13.Rows.Count > 0)
                        {
                            {
                                if (lbl_cocuk.Text == "0")
                                    document.Add(cocukyok);
                                else
                                    document.Add(cocuk);
                                document.Add(ara);
                            }
                            document.Add(table13);//aile temel bilgiler
                        }

                        else
                            document.Add(yakın1);

                        document.Add(ara);




                        document.Add(prgAuthor18);//başlık17
                        if (t14.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table14);
                        }
                        else
                            document.Add(yakın2);//aile sağlık bilgisi

                        document.Add(ara);



                        document.Add(prgAuthor19);//başlık18

                        if (t15.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table15);//aile eğitim bilgisi
                        }
                        else
                            document.Add(yakın3);
                        document.Add(ara);


                        document.Add(prgAuthor20);//başlık19
                        if (t16.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table16);//aile çalışma bilgisi
                        }
                        else
                            document.Add(yakın4);



                        document.Add(ara);
                        document.Add(prgAuthor21);//başlık20
                        if (t17.Rows.Count > 0)
                        {
                            document.Add(ara);

                            document.Add(table17);//aile genel kültür
                        }
                        else
                            document.Add(yakın5);
                        document.Add(ara);
                        document.Add(ara);
                        document.Add(ara);
                        document.Add(ara);
                        document.Add(ara);

                        document.Add(dipnot);

                        //document.Add(table18);

                        document.Close();
                        writer.Close();
                        fs.Close();
                    }

                    //   string strPdfPath = @"C://Dosyalar/" + mtxt_tc_no.Text + "/" + mtxt_tc_no.Text + "_" + "Tüm_Bilgiler.pdf";

                    System.Diagnostics.Process.Start(strPdfPath);

                    ////////////////////////Yeni Kod Sonu//////////////////////////
                    /*
                    //Bu kısımda sipariş formu yazısını ve çizgileri yazdırıyorum
                    e.Graphics.DrawLine(myPen, 100, 50, 750, 50);

                    e.Graphics.DrawString("PERSONEL BİLGİ FORMU", ustFont, sbbrush, (sayfa_genisligi / 2) + 70, 30);

                    e.Graphics.DrawLine(myPen, 100, 320, 750, 320);

                    ustFont = new System.Drawing.Font("Calibri", 12, FontStyle.Bold);

                    e.Graphics.DrawLine(myPen, 100, 348, 750, 348);

                    e.Graphics.DrawString("Temel Kimlik Bilgileri", cizgiFont, sbcizgi, 100, 55);

                    //e.Graphics.DrawString(".............................................", myFont, sb, 70, 170);
                    e.Graphics.DrawString(label21.Text + " : " + lbl_ad.Text, myFont1, sb1, 100, 75);
                    e.Graphics.DrawString(label17.Text + " : " + lbl_medeni_hal.Text, myFont1, sb1, 255, 75);
                    e.Graphics.DrawString(label13.Text + " : " + lbl_baba_adi.Text, myFont1, sb1, 430, 75);
                    e.Graphics.DrawString(lbl_calisma_durumu.Text + " : " + lbl_durum.Text, myFont1, sb1, 630, 75);

                    e.Graphics.DrawString(label22.Text + " : " + lbl_soyad.Text, myFont1, sb1, 100, 100);
                    e.Graphics.DrawString(label18.Text + " : " + lbl_dogum_tarihi.Text, myFont1, sb1, 255, 100);
                    e.Graphics.DrawString(label14.Text + " : " + lbl_meslek_kodu.Text, myFont1, sb1, 430, 100);
                    e.Graphics.DrawString(label11.Text + " : " + lbl_ise_giris.Text, myFont1, sb1, 630, 100);

                    e.Graphics.DrawString(label23.Text + " : " + lbl_uyruk.Text, myFont1, sb1, 100, 125);
                    e.Graphics.DrawString(label19.Text + " : " + lbl_dogum_yeri.Text, myFont1, sb1, 255, 125);
                    e.Graphics.DrawString(label15.Text + " : " + lbl_görevi.Text, myFont1, sb1, 430, 125);
                    e.Graphics.DrawString(label12.Text + " : " + lbl_isten_cikis.Text, myFont1, sb1, 630, 125);



                    e.Graphics.DrawString(label24.Text + " : " + lbl_cinsiyet.Text, myFont1, sb1, 100, 150);
                    e.Graphics.DrawString(label20.Text + " : " + lbl_ana_adi.Text, myFont1, sb1, 255, 150);
                    e.Graphics.DrawString(label16.Text + " : " + lbl_gorev_yeri.Text, myFont1, sb1, 430, 150);

                    e.Graphics.DrawLine(myPen, 100, 170, 750, 170);

                    //iletişim bilgileri
                    e.Graphics.DrawString(label2.Text, cizgiFont, sbcizgi, 100, 175);

                    e.Graphics.DrawString(label25.Text + " : " + lbl_tel_no.Text, myFont, sb, 100, 200);
                    e.Graphics.DrawString(label26.Text + " : " + lbl_cep_no.Text, myFont, sb, 300, 200);
                    e.Graphics.DrawString(label36.Text + " : " + lbl_email.Text, myFont, sb, 500, 200);

                    e.Graphics.DrawString(label30.Text + " : " + lbl_yakin.Text, myFont, sb, 100, 225);
                    e.Graphics.DrawString(label31.Text + " : " + lbl_yakin_tel.Text, myFont, sb, 300, 225);
                    e.Graphics.DrawString(label32.Text + " : " + lbl_adres.Text, myFont, sb, 500, 225);


                    e.Graphics.DrawLine(myPen, 100, 250, 750, 250);


                    //eğitim bilgisi

                    e.Graphics.DrawString(label4.Text, cizgiFont, sbcizgi, 100, 255);
                    e.Graphics.DrawString("EĞİTİM BİLGİLERİ ", cizgiFont, sbcizgi, 100, 280);

                    //for (int i = 0; i < dte.Rows.Count; i++)
                    //{

                    //    e.Graphics.DrawString(i+"-"+dte.Rows[i]["okul_adi"] +  ""+ dte.Rows[i]["ogrenim_düzeyi"] + "," + dte.Rows[i]["bolum"] + "," + dte.Rows[i]["sinif"] + "," + dte.Rows[i]["sehir_id"] + ",(" + dte.Rows[i]["giris_tarihi"] + "-"  + dte.Rows[i]["mezuniyet_tarihi"] + ") , " + dte.Rows[i]["derece"]+ ", "+ dte.Rows[i]["durum_bilgisi"]  , myFont, sb, 100, 305 + (i * 25));
                    //}
                    //e.Graphics.DrawLine(myPen, 100, 625, 750, 625);

                    //sağlık bilgileri
                    e.Graphics.DrawString(label6.Text, cizgiFont, sbcizgi, 100, 650);

                    e.Graphics.DrawString(label28.Text + " : " + lbl_kan.Text, myFont, sb, 100, 675);
                    e.Graphics.DrawString(label33.Text + " : " + lbl_boy.Text + " " + label50.Text, myFont, sb, 300, 675);
                    e.Graphics.DrawString(label34.Text + " : " + lbl_kilo.Text + " " + label54.Text, myFont, sb, 400, 675);
                    e.Graphics.DrawString(label46.Text + " : " + txt_saglik.Text, myFont, sb, 100, 700);


                    e.Graphics.DrawString(label53.Text + " : " + txt_engel.Text, myFont, sb, 100, 725);
                    e.Graphics.DrawString(label59.Text + " : " + txt_ameliyat.Text, myFont, sb, 100, 750);
                    e.Graphics.DrawString(label48.Text + " : " + lbl_sigara.Text + " " + lbl_z_sigara.Text, myFont, sb, 500, 675);
                    e.Graphics.DrawString(label51.Text + " : " + lbl_alkol.Text + " " + lbl_z_alkol.Text, myFont, sb, 600, 675);

                    e.Graphics.DrawLine(myPen, 100, 750, 750, 750);

                    //genel kültür kısmı
                    e.Graphics.DrawString("Hobileri", cizgiFont, sbcizgi, 100, 775);
                    e.Graphics.DrawString(lbl_hobi.Text + " : " + lbl_hobileri.Text, myFont, sb, 100, 800);

                    e.Graphics.DrawString("Yabancı Dil", cizgiFont, sbcizgi, 100, 825);
                    e.Graphics.DrawString("YABANCI DİL   YABANCI DİL DÜZEYİ", cizgiFont, sbcizgi, 100, 850);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        e.Graphics.DrawString(dt.Rows[i]["yabanci_dil"] + " " + dt.Rows[i]["duzeyi"], tableFont, tablerush, 100, 875 + (i * 25));
                    }

                    e.Graphics.DrawString("Bilgisayar Programları", cizgiFont, sbcizgi, 400, 825);
                    e.Graphics.DrawString("PROGRAM ADI   PROGRAM BİLGİ DÜZEYİ", cizgiFont, sbcizgi, 400, 850);

                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {

                        e.Graphics.DrawString(dt2.Rows[i]["program_ad"] + " " + dt2.Rows[i]["duzey"], tableFont, tablerush, 400, 875 + (i * 25));
                    }
                    e.Graphics.DrawString("Sertifikalar", cizgiFont, sbcizgi, 100, 1000);
                    e.Graphics.DrawString("SERTİFİKANIN ADI   SERTİFİKANIN ALINDIĞI KURULUŞ     SERTİFİKA KONUSU    ALIŞ TARİHİ", cizgiFont, sbcizgi, 100, 1025);
                    int h = 1050;
                    int s = 0;
                    for (s = 0; s < dt3.Rows.Count; s++)
                    {

                        e.Graphics.DrawString(dt3.Rows[s]["sertifika_adi"] + " " + dt3.Rows[s]["aldigi_kurum"] + "  " + dt3.Rows[s]["konu"] + " " + dt3.Rows[s]["tarih"], tableFont, tablerush, 100, h + (s * 25));
                    }

                    //resmi çekmek
                    e.Graphics.DrawImage(picb_resim.Image, 3, 3, 95, 95);

                    e.Graphics.DrawString("Sayfa 1/4", italikFont, isbcizgi, 100, 1095);*/
                    break;

                    //ikinci sayfa

                    /* case 2:



                         e.Graphics.DrawString("Ağır İş Sertifikası", cizgiFont, sbcizgi, 100, 125);
                         e.Graphics.DrawString("SERTİFİKANIN ADI    ALIŞ TARİHİ", cizgiFont, sbcizgi, 100, 150);

                         for (int i = 0; i < dt5.Rows.Count; i++)
                         {

                             e.Graphics.DrawString(dt5.Rows[i]["agir_is_sertifika_adi"] + " " + dt5.Rows[i]["alinis_tarihi"], tableFont, tablerush, 100, 175 + (i * 25));
                         }

                         e.Graphics.DrawString("Ağır İş Sertifikası", cizgiFont, sbcizgi, 100, 125);

                         //ulaşımın kısmı
                         e.Graphics.DrawLine(myPen, 100, 250, 750, 250);
                         e.Graphics.DrawString("FİRMA İMKANLARI", cizgiFont, sbcizgi, 100, 275);


                         e.Graphics.DrawString(label56.Text + " : " + lbl_gider.Text, myFont, sb, 100, 300);
                         e.Graphics.DrawString(label57.Text + " : " + lbl_sure.Text, myFont, sb, 100, 325);
                         e.Graphics.DrawString(label58.Text, myFont, sb, 100, 350);
                         e.Graphics.DrawString(label60.Text + " " + lbl_v1.Text, myFont, sb, 100, 375);
                         e.Graphics.DrawString(label61.Text + " " + lbl_v2.Text, myFont, sb, 100, 400);
                         e.Graphics.DrawString(label62.Text + " " + lbl_3.Text, myFont, sb, 100, 425);
                         e.Graphics.DrawString(label63.Text + " " + lbl_4.Text, myFont, sb, 100, 450);
                         e.Graphics.DrawString(label64.Text + " " + lbl_5.Text, myFont, sb, 100, 475);
                         e.Graphics.DrawString(label65.Text + " " + lbl_v6.Text, myFont, sb, 100, 500);

                         e.Graphics.DrawString(label68.Text + " ; ", myFont, sb, 400, 300);
                         e.Graphics.DrawString(txt_alerji.Text, myFont, sb, 400, 325);
                         e.Graphics.DrawString(label69.Text + "  " + lbl_yemek.Text, myFont, sb, 400, 400);
                         e.Graphics.DrawString(label71.Text, myFont, sb, 400, 425);
                         e.Graphics.DrawString(txt_neden.Text, myFont, sb, 400, 450);

                         e.Graphics.DrawString(label70.Text, myFont, sb, 400, 475);
                         e.Graphics.DrawString(txt_talep.Text, myFont, sb, 400, 500);



                         e.Graphics.DrawLine(myPen, 100, 550, 750, 550);

                         //MADDİ DURUM BİLGİLERİ
                         e.Graphics.DrawString("MADDİ DURUM BİLGİLERİ", cizgiFont, sbcizgi, 100, 575);

                         e.Graphics.DrawString(label37.Text + " : " + lbl_maas.Text, myFont, sb, 100, 600);
                         e.Graphics.DrawString(label38.Text + " : " + lbl_destek.Text + " " + lbl_destek_mikari.Text, myFont, sb, 100, 625);
                         e.Graphics.DrawString(label39.Text + " : " + lbl_ev.Text, myFont, sb, 100, 650);
                         e.Graphics.DrawString(label40.Text + " : " + lbl_kira.Text, myFont, sb, 100, 675);
                         e.Graphics.DrawString(label41.Text + " : " + lbl_isinma.Text, myFont, sb, 100, 700);
                         e.Graphics.DrawString(label43.Text + " : " + lbl_arac.Text + " , " + lbl_arac_amac.Text, myFont, sb, 100, 725);
                         e.Graphics.DrawString(label42.Text + " : " + lbl_arazi.Text, myFont, sb, 100, 750);
                         e.Graphics.DrawString(lbl_arazi_amac.Text, myFont, sb, 100, 775);
                         e.Graphics.DrawString(label27.Text + " : " + lbl_gelir_ev.Text + " ; " + lbl_gelir_ev_tutar.Text, myFont, sb, 500, 625);
                         e.Graphics.DrawString(label45.Text + " : " + lbl_iban.Text, myFont, sb, 500, 650);
                         e.Graphics.DrawString(label44.Text + " : " + lbl_icra.Text, myFont, sb, 500, 675);
                         e.Graphics.DrawString(label29.Text + " : " + lbl_icra_konu.Text, myFont, sb, 500, 700);
                         e.Graphics.DrawString(label49.Text + " : " + lbl_borc_miktari.Text, myFont, sb, 500, 725);
                         e.Graphics.DrawString(label52.Text + " : " + lbl_borc_hesap_no.Text, myFont, sb, 500, 750);
                         e.Graphics.DrawString(label35.Text + " : " + date_borc_tarihi.Value.ToShortDateString(), myFont, sb, 500, 775);

                         e.Graphics.DrawString("Sayfa 2/4", italikFont, isbcizgi, 100, 1095);
                         break;

                         */
                    /*case 3:

                        //özgeçmiş bilgilerinin çekilmesi
                        e.Graphics.DrawString("PERSONEL ÖZ GEÇMİŞ BİLGİLERİ", cizgiFont, sbcizgi, 100, 125);



                        e.Graphics.DrawString("İŞ YERİ ADI      TELEFON NUMARASI        GÖREVİ       MAAŞ        YÖNETİCİ ADI         İŞE GİRİŞ TARİHİ      İŞTEN AYRILIŞ TARİHİ        AYRILMA SEBEBİ", cizgiFont, sbcizgi, 100, 150);

                        for (int i = 0; i < dto.Rows.Count; i++)
                        {

                            e.Graphics.DrawString(dto.Rows[i]["isyeri_adi"] + " " + dto.Rows[i]["tel"] + " " + dto.Rows[i]["gorev"] + " " + dto.Rows[i]["maaş"] +
                                " " + dto.Rows[i]["yon_adi"] + " " + dto.Rows[i]["giris_tarihi"] + " " + dto.Rows[i]["cikis_tarihi"] + " " + dto.Rows[i]["sebep"], tableFont, tablerush, 100, 175 + (i * 25));

                        }

                        //kkd çekilmesi
                        e.Graphics.DrawString("PERSONEL KŞİSEL KORUYUCU DONANIM LİSTESİ", cizgiFont, sbcizgi, 100, 275);

                        e.Graphics.DrawString("KKD TÜRÜ         BEDEN       KKD TESLİM TARİHİ        AKSİYON TÜRÜ        AKSİYON TARİHİ", cizgiFont, sbcizgi, 100, 300);

                        for (int i = 0; i < dtk.Rows.Count; i++)
                        {

                            e.Graphics.DrawString(dtk.Rows[i]["kkd_turu"] + " " + dtk.Rows[i]["beden"] + " " + dtk.Rows[i]["kkd_teslim_tarihi"] +
                                " " + dtk.Rows[i]["aksiyon_tutu"] + " " + dtk.Rows[i]["aksiyon_tarihi"], tableFont, tablerush, 100, 350 + (i * 25));

                        }


                        ///aile ve bakım bilgisi
                        e.Graphics.DrawString("AİLE BİLGİLERİ", cizgiFont, sbcizgi, 100, 475);

                        //printDocument1.DefaultPageSettings.Landscape = false;

                        //çocuk sayıısnın çekilmesi
                        e.Graphics.DrawString(label47.Text + " : " + lbl_cocuk.Text, myFont, sb, 100, 500);



                        //aileye ait temel bilgiler
                        e.Graphics.DrawString("YAKINLIK DERECESİ    ADI SOYADI      CİNSİYETİ       DOĞUM YERİ      DOĞUM TARİHİ       YAŞAM BİLGİSİ        ÖLÜM TARİHİ         ÖLÜM SEBEBİ         MEDENİ HALİ         TELEFON NUMARASI", cizgiFont, sbcizgi, 100, 525);

                        for (int i = 0; i < dtyt.Rows.Count; i++)
                        {

                            e.Graphics.DrawString(dtyt.Rows[i]["yakinlik_derecesi"] + " " + dtyt.Rows[i]["yakin_adi_soyadi"] + " "
                                + dtyt.Rows[i]["yakin_cinsiyeti"] + " " + dtyt.Rows[i]["yakin_dogum_yeri"] + " " + dtyt.Rows[i]["yakin_dogum_tarihi"]
                                + " " + dtyt.Rows[i]["yakin_yasam_bilgisi"] + " " + dtyt.Rows[i]["yakin_olum_tarihi"] + " " + dtyt.Rows[i]["yakin_olum_aciklamasi"]
                                + " " + dtyt.Rows[i]["yakin_medeni_hali"] + " " + dtyt.Rows[i]["yakin_tel_no"], tableFont, tablerush, 100, 550 + (i * 25));

                        }


                        //aileye ait sağlık  bilgiler
                        e.Graphics.DrawString("ADI SOYADI         KAN GRUBU      SAĞLIK AÇIKLAMASI       ENGEL AÇIKLAMASI", cizgiFont, sbcizgi, 100, 700);

                        for (int i = 0; i < dtys.Rows.Count; i++)
                        {

                            e.Graphics.DrawString(dtys.Rows[i]["yakin_adi_soyadi"] + " " + dtys.Rows[i]["yakin_kan_grubu"] + " " + dtys.Rows[i]["yakin_saglik_aciklama"] + " " +
                                dtys.Rows[i]["yakin_engel_aciklama"] + " " + dtys.Rows[i]["yakin_çalisma_durumu"], tableFont, tablerush, 100, 725 + (i * 25));

                        }

                        //aileye ait eğitim bilgileri
                        e.Graphics.DrawString("ADI SOYADI      OKUL DURUMU       OKUL ADI        ÖĞRENİM DÜZEYİ      BÖLÜMÜ      SINIF       ŞEHİR      OKUL GİRİŞ TARİHİ      MEZUNİYET DURUMU         MEZUNİYET TARİHİ         MEZUNİYET DERECESİ", cizgiFont, sbcizgi, 100, 925);

                        for (int i = 0; i < dtye.Rows.Count; i++)
                        {

                            e.Graphics.DrawString(dtye.Rows[i]["yakin_adi_soyadi"] + " " + dtye.Rows[i]["yakin_okul"] + " " + dtye.Rows[i]["yakin_okul_adi"] + " " + dtye.Rows[i]["yakin_ogrenim_duzeyi"]
                                + " " + dtye.Rows[i]["yakin_okul_bolumu"] + " " + dtye.Rows[i]["yakin_okul_sinif"] + " " + dtye.Rows[i]["yakin_okul_sehir"]
                                + " " + dtye.Rows[i]["yakin_okul_giris_tarihi"] + " " + dtye.Rows[i]["yakin_okul_durumu"] + " " +
                                dtye.Rows[i]["yakin_okul_mezuniyet_tarihi"] + " " + dtye.Rows[i]["yakin_mezuniyet_derecesi"], tableFont, tablerush, 100, 950 + (i * 25));

                        }



                        e.Graphics.DrawString("Sayfa 3/4", italikFont, isbcizgi, 100, 1095);
                        break;
                    */
                    /* case 4:
                         //aileye ait çalışma bilgiler
                         e.Graphics.DrawString("ADI SOYADI         ÇALIŞMA DURUMU         MESLEK BİLGİSİ       AYLIK GELİR         ÇALIŞMA YERİ", cizgiFont, sbcizgi, 100, 125);

                         for (int i = 0; i < dtyc.Rows.Count; i++)
                         {

                             e.Graphics.DrawString(dtyc.Rows[i]["yakin_adi_soyadi"] + " " + dtyc.Rows[i]["yakin_çalisma_durumu"]
                                 + " " + dtyc.Rows[i]["yakin_meslegi"] + " " + dtyc.Rows[i]["yakin_geliri"] + " " + dtyc.Rows[i]["yakin_calistigi_yer"], tableFont, tablerush, 100, 150 + (i * 25));

                         }



                         //aileye ait genel kültür bilgileri
                         e.Graphics.DrawString("ADI SOYADI      MERASİM TÜRÜ       MERASİM TARİHİ       HOBİLERİ", cizgiFont, sbcizgi, 100, 225);

                         for (int i = 0; i < dtyg.Rows.Count; i++)
                         {

                             e.Graphics.DrawString(dtyg.Rows[i]["yakin_adi_soyadi"] + " " + dtyg.Rows[i]["yakin_merasim_turu"]
                                 + " " + dtyg.Rows[i]["yakin_merasim_tarihi"] + " " + dtyg.Rows[i]["yakin_hobileri"], tableFont, tablerush, 100, 250 + (i * 25));

                         }

                         e.Graphics.DrawString("ADI SOYADI       DOĞUM YERİ          DOĞUM TARİHİ           TELEFON NUMARASI          SAĞLIK AÇIKLAMASI      ENGEL AÇIKLAMASI        GELİRİ      YAKINLIK DERECESİ        HOBİLERİ", cizgiFont, sbcizgi, 100, 350);

                         for (int i = 0; i < dtb.Rows.Count; i++)
                         {

                             e.Graphics.DrawString(dtb.Rows[i]["adi_soyadi"] + " " + dtb.Rows[i]["dogum_yeri"] + "     " + dtb.Rows[i]["dogum_tarihi"] +
                                 " " + dtb.Rows[i]["tel_no"] + "     " + dtb.Rows[i]["saglik_sorunu_aciklama"] + " " + dtb.Rows[i]["engel_aciklama"] +
                                 "     " + dtb.Rows[i]["geliri"] + " " + dtb.Rows[i]["bakim_yakini"] + "     " + dtb.Rows[i]["bakim_hobi"], tableFont, tablerush, 100, 875 + (i * 25));

                         }


                         e.Graphics.DrawLine(myPen, 100, 450, 750, 450);


                        e.Graphics.DrawString("Sayfa 4/4", italikFont, isbcizgi, 100, 1095);
                    */
                    //  break;
                    //satırlar safaya sığmazsa bir sonraki sayfadan devam edilsin



                    //if ((y/satir_yuksekligi)>(sayfa_ayari.PaperSize.Height-sayfa_ayari.Margins.Bottom))
                    //{
                    //    e.HasMorePages = true;

                    //}

            }
            //if (a < 4)
            //{
            //    a++;
            //    e.HasMorePages = true;
            //}
            //else
            //    a = 1;

        }


        private void btn_cikti_Click(object sender, EventArgs e)
        {
            //DialogResult pdr = printDialog1.ShowDialog();

            //    //if (pdr == DialogResult.OK)

            //    //{
            //    //    printDocument1.Print();
            //    //}

            sade_print();


            if (mtxt_tc_no.Text == "")
            {
                MessageBox.Show("Lütfen önce Tc No giriniz");
            }
            else
            {



                //    PrintDocument pd = new PrintDocument();
                //    pd.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);

                //    PrintDialog printdlg = new PrintDialog();
                //    PrintPreviewDialog printprvdlg = new PrintPreviewDialog();

                //    printprvdlg.Document = pd;
                //    printprvdlg.ShowDialog();

                //    printprvdlg.Document = pd;
                //    if (printprvdlg.ShowDialog() == DialogResult.OK)
                //    {
                //        pd.Print();
                //    }

                //printDocument1.Print();
                //printDocument1.PrintPage += PrintDocument1_PrintPage;

                //printDocument1.PrintPage += PrintDocument1_PrintPage;


            }



        }
        public void sade_print()
        {
            //son1



            //pdfDoc.Open();

            int x, y;
            int satir_yuksekligi, sayfa_yuksekligi;

            System.Drawing.Printing.PageSettings sayfa_ayari;
            sayfa_ayari = printDocument1.DefaultPageSettings;
            sayfa_yuksekligi = sayfa_ayari.PaperSize.Height - sayfa_ayari.Margins.Top - sayfa_ayari.Margins.Bottom;

            int sayfa_genisligi;

            sayfa_genisligi = sayfa_ayari.PaperSize.Width - sayfa_ayari.Margins.Left - sayfa_ayari.Margins.Right;

            x = sayfa_ayari.Margins.Left + 2;
            y = sayfa_ayari.Margins.Top;

            StringFormat ortala = new StringFormat();
            ortala.Alignment = StringAlignment.Center;

            /*  StringFormat saga_yasla = new StringFormat();
             saga_yasla.Alignment = StringAlignment.Far;*/



            //Yazı fontumu ve çizgi çizmek için fırçamı ve kalem nesnemi oluşturdum
            System.Drawing.Font myFont1 = new System.Drawing.Font("Calibri", 6);
            SolidBrush sbrush1 = new SolidBrush(Color.Black);
            Pen myPen1 = new Pen(Color.Black);



            System.Drawing.Font myFont = new System.Drawing.Font("Calibri", 28);
            SolidBrush sbrush = new SolidBrush(Color.Black);
            Pen myPen = new Pen(Color.Black);

            System.Drawing.Font cizgiFont = new System.Drawing.Font("Calibri", 28, FontStyle.Underline);
            SolidBrush cizgisbrush = new SolidBrush(Color.Black);
            Pen cizgiPen = new Pen(Color.Black);

            System.Drawing.Font ustFont = new System.Drawing.Font("Calibri", 8);
            SolidBrush sbbrush = new SolidBrush(Color.Black);
            Pen ustPen = new Pen(Color.Black);


            System.Drawing.Font tableFont = new System.Drawing.Font("Calibri", 5);
            SolidBrush tablerush = new SolidBrush(Color.Black);
            Pen tablePen = new Pen(Color.Black);

            System.Drawing.Font italikFont = new System.Drawing.Font("Calibri", 8, FontStyle.Underline);
            SolidBrush italiksbrush = new SolidBrush(Color.Black);
            Pen italikPen = new Pen(Color.Black);


            //satir_yuksekligi = (int)e.Graphics.MeasureString("x", myFont).Height;

            StringFormat ustStringFormat = new StringFormat();
            ustStringFormat.Alignment = StringAlignment.Far;
            ustStringFormat.LineAlignment = StringAlignment.Center;

            cizgiFont = new System.Drawing.Font("Calibri", 8, FontStyle.Underline);
            SolidBrush sbcizgi = new SolidBrush(Color.Black);

            italikFont = new System.Drawing.Font("Calibri", 8, FontStyle.Italic);
            SolidBrush isbcizgi = new SolidBrush(Color.Black);

            myFont = new System.Drawing.Font("Calibri", 8, FontStyle.Bold);
            SolidBrush sb = new SolidBrush(Color.Black);

            myFont1 = new System.Drawing.Font("Calibri", 6, FontStyle.Regular);
            SolidBrush sb1 = new SolidBrush(Color.Black);

            //birinci sayfa


            ////////////////////////Yeni Kod Başlangıç//////////////////////////
            // string tc = "";
            // string strPdfPath = @"C:\Dosyalar\ciktiForm.pdf";
            //string strPdfPath = @"C:\\Dosyalar\\"+mtxt_tc_no.Text+"\\";
            string dosya_yolu = "C:\\Dosyalar\\" + mtxt_tc_no.Text;
            if (Directory.Exists(dosya_yolu))
            {
                // MessageBox.Show("Dosya bulundu", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                try
                {
                    Directory.CreateDirectory(@"C://Dosyalar/" + mtxt_tc_no.Text + "/");
                    //  MessageBox.Show("Dosya başarılı bir şekilde oluşturulmuştur.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception)
                {

                    // MessageBox.Show("Dosya oluşturulamadı", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            string strPdfPath = @"C://Dosyalar/" + mtxt_tc_no.Text + "/" + mtxt_tc_no.Text + "_" + "Tüm_Bilgiler.pdf";

            //string yeniad = mtxt_tc_no.Text + "_" + "bilgiler.pdf"; //Benzersiz isim verme

            //   "C:\\Dosyalar\\" + mtxt_tc_no.Text;

            //string strPdfPath = @"C://Dosyalar/" + mtxt_tc_no.Text + "/" + mtxt_tc_no.Text + "_Tüm Bilgileri" + ".pdf";

            System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            //Document document = new Document();

            Document document = new Document(PageSize.A4, 10f, 10f, 10f, 10f);//???

            document.SetPageSize(iTextSharp.text.PageSize.A4);

            PdfWriter writer = PdfWriter.GetInstance(document, fs);//yazıyorrr 
            document.Open();


            Bitmap MemoryImage;

            Panel pnl;
            pnl = panel_genel_bilgiler;
            MemoryImage = new Bitmap(pnl.Width, pnl.Height);
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, pnl.Width, pnl.Height);
            pnl.DrawToBitmap(MemoryImage, new System.Drawing.Rectangle(0, 0, pnl.Width, pnl.Height));

            iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(MemoryImage, System.Drawing.Imaging.ImageFormat.Png);




            Bitmap MemoryImage2;

            Panel pnl2;
            pnl2 = panel_saglik;
            MemoryImage2 = new Bitmap(pnl2.Width, pnl2.Height);
            System.Drawing.Rectangle rect2 = new System.Drawing.Rectangle(0, 0, pnl2.Width, pnl2.Height);
            pnl2.DrawToBitmap(MemoryImage2, pnl2.ClientRectangle);
            //pnl2.DrawToBitmap(MemoryImage2, new System.Drawing.Rectangle(0, 0, pnl2.Width, pnl2.Height));

            iTextSharp.text.Image png2 = iTextSharp.text.Image.GetInstance(MemoryImage2, System.Drawing.Imaging.ImageFormat.Png);


            Bitmap MemoryImage3;

            Panel pnl3;
            pnl3 = panel_iletisim;
            MemoryImage3 = new Bitmap(pnl3.Width, pnl3.Height);
            System.Drawing.Rectangle rect3 = new System.Drawing.Rectangle(0, 0, pnl3.Width, pnl3.Height);
            pnl3.DrawToBitmap(MemoryImage3, new System.Drawing.Rectangle(0, 0, pnl3.Width, pnl3.Height));

            iTextSharp.text.Image png3 = iTextSharp.text.Image.GetInstance(MemoryImage3, System.Drawing.Imaging.ImageFormat.Png);


            Bitmap MemoryImage4;

            Panel pnl4;
            pnl4 = panel_ulasim;
            MemoryImage4 = new Bitmap(pnl4.Width, pnl4.Height);
            System.Drawing.Rectangle rect4 = new System.Drawing.Rectangle(0, 0, pnl4.Width, pnl4.Height);
            pnl4.DrawToBitmap(MemoryImage4, new System.Drawing.Rectangle(0, 0, pnl4.Width, pnl4.Height));

            iTextSharp.text.Image png4 = iTextSharp.text.Image.GetInstance(MemoryImage4, System.Drawing.Imaging.ImageFormat.Png);

            //Bitmap MemoryImage6;

            //MemoryImage6 = new Bitmap(picb_resim.Width, picb_resim.Height);
            //System.Drawing.Rectangle rect6 = new System.Drawing.Rectangle(0, 0, picb_resim.Width, picb_resim.Height);
            //picb_resim.Image.RawFormat(Stream, ImageFormatConverter);
            //(MemoryImage, new System.Drawing.Rectangle(0, 0, picb_resim.Width, picb_resim.Height));

            //iTextSharp.text.Image png6 = iTextSharp.text.Image.GetInstance(MemoryImage6, System.Drawing.Imaging.ImageFormat.Png);



            //Bitmap MemoryImage5;

            //Panel pnl5;
            //pnl5 = panel_ulasim;
            //MemoryImage5 = new Bitmap(pnl5.Width, pnl5.Height);
            //System.Drawing.Rectangle rect5 = new System.Drawing.Rectangle(0, 0, pnl5.Width, pnl5.Height);
            //pnl5.DrawToBitmap(MemoryImage5, new System.Drawing.Rectangle(0, 0, pnl5.Width, pnl5.Height));

            //iTextSharp.text.Image png5 = iTextSharp.text.Image.GetInstance(MemoryImage5, System.Drawing.Imaging.ImageFormat.Png);

            /*
            iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(picb_resim.Image, System.Drawing.Imaging.ImageFormat.Jpeg);

            png.ScaleAbsolute(90, 90);//pdf deki resmi boyutlandırma.*/


            DataTable t1 = new DataTable();

            DataTable t2 = new DataTable();

            DataTable t3 = new DataTable();

            DataTable t4 = new DataTable();

            DataTable t5 = new DataTable();

            DataTable t6 = new DataTable();

            DataTable t7 = new DataTable();

            DataTable t8 = new DataTable();

            DataTable t9 = new DataTable();

            DataTable t10 = new DataTable();

            DataTable t11 = new DataTable();

            DataTable t12 = new DataTable();

            DataTable t13 = new DataTable();

            DataTable t14 = new DataTable();

            DataTable t15 = new DataTable();

            DataTable t16 = new DataTable();

            DataTable t17 = new DataTable();

            //eğitim bilgisi girilmiş mi diye sorgulamak lazım


            bool kayitkontrolegitim = false;//bir kayıt yaparken daha önceden böyle bir kullanıcı var mı diye kontrolü yapılacak
                                            //baglantim.baglanti().Open();
            SqlCommand selectsorgu = new SqlCommand("select * from Kisi_Egitim_Bilgisi where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.
                                                                   //ilgili tc no ya ait vb de kayıt vamı diye kontrol edelim.

            //while (kayitokuma.Read())
            //{
            kayitkontrolegitim = true;//ilgili tc noya ait bir kullanıcı var demektir.
            SqlCommand sorgu1 = new SqlCommand("Listele_Egitim_Bilgisi_Cikti", baglantim.baglanti());
            sorgu1.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dae1 = new SqlDataAdapter(sorgu1);
            sorgu1.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            dae1.Fill(t1);
            //    break;

            //}
            //eğitim bilgisi girilmiş mi diye sorgulamak lazım


            //bool kayitkontrolesaglik = false;//bir kayıt yaparken daha önceden böyle bir kullanıcı var mı diye kontrolü yapılacak
            //                                //baglantim.baglanti().Open();
            //SqlCommand selectsorgu2 = new SqlCommand("select * from Kisi_Saglik_Bilgisi where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            //SqlDataReader kayitokuma2 = selectsorgu2.ExecuteReader();//okuduğu sorguları tutuyoruz.
            //                                                       //ilgili tc no ya ait vb de kayıt vamı diye kontrol edelim.

            //while (kayitokuma2.Read())
            //{
            //kayitkontrolesaglik = true;
            SqlCommand sorgu2 = new SqlCommand("Listele_Kisi_Saglik_Bilgisi_Cikti", baglantim.baglanti());
            sorgu2.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dae2 = new SqlDataAdapter(sorgu2);
            sorgu2.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
            dae2.Fill(t2);
            //}

            SqlCommand sorgu3 = new SqlCommand("Listeler_Ilestisim_Bilgisi_cikti", baglantim.baglanti());
            sorgu3.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dae3 = new SqlDataAdapter(sorgu3);

            sorgu3.Parameters.AddWithValue("@tc_bilgisi", mtxt_tc_no.Text);
            dae3.Fill(t3);

            SqlCommand sorgu4 = new SqlCommand("Listele_Bilgisayar_Bilgisi_Cikti", baglantim.baglanti());
            sorgu4.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dae4 = new SqlDataAdapter(sorgu4);
            sorgu4.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
            dae4.Fill(t4);

            SqlCommand sorgu5 = new SqlCommand("Listele_Yabanci_Dil_Cikti", baglantim.baglanti());
            sorgu5.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dae5 = new SqlDataAdapter(sorgu5);
            sorgu5.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
            dae5.Fill(t5);


            SqlCommand sorgu6 = new SqlCommand("Kisi_Sertifika_Bilgileri_Cikti", baglantim.baglanti());
            sorgu6.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dae6 = new SqlDataAdapter(sorgu6);
            sorgu6.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
            dae6.Fill(t6);



            SqlCommand sorgu7 = new SqlCommand("Kisi_Sertifika_Agir_is_Cikti", baglantim.baglanti());
            sorgu7.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dae7 = new SqlDataAdapter(sorgu7);
            sorgu7.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
            dae7.Fill(t7);


            SqlCommand sorgu8 = new SqlCommand("Listele_Ozgecmis_isyeri_Cikti", baglantim.baglanti());
            sorgu8.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dae8 = new SqlDataAdapter(sorgu8);
            sorgu8.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
            dae8.Fill(t8);


            SqlCommand sorgu9 = new SqlCommand("Listele_kkd_Cikti", baglantim.baglanti());
            sorgu9.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dae9 = new SqlDataAdapter(sorgu9);
            sorgu9.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
            dae9.Fill(t9);


            SqlCommand sorgu10 = new SqlCommand("Listele_Borc_Bilgisi_Cikti", baglantim.baglanti());
            sorgu10.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dae10 = new SqlDataAdapter(sorgu10);
            sorgu10.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
            dae10.Fill(t10);


            SqlCommand sorgu11 = new SqlCommand("Listele_Maddi_Durum_Listele", baglantim.baglanti());
            sorgu11.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dae11 = new SqlDataAdapter(sorgu11);
            sorgu11.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
            dae11.Fill(t11);


            SqlCommand sorgu12 = new SqlCommand("Listele_Bakim_Bilgileri_Cikti", baglantim.baglanti());
            sorgu12.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dae12 = new SqlDataAdapter(sorgu12);
            sorgu12.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
            dae12.Fill(t12);


            SqlCommand sorgu13 = new SqlCommand("Listele_Yakin_Bilgileri_Cikti", baglantim.baglanti());
            sorgu13.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dae13 = new SqlDataAdapter(sorgu13);
            sorgu13.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
            dae13.Fill(t13);

            SqlCommand sorgu14 = new SqlCommand("Listele_Yakin_Saglik_Bilgileri_Cikti", baglantim.baglanti());
            sorgu14.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dae14 = new SqlDataAdapter(sorgu14);
            sorgu14.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
            dae14.Fill(t14);


            SqlCommand sorgu15 = new SqlCommand("Listele_Yakin_Egitim_Bilgileri_Cikti", baglantim.baglanti());
            sorgu15.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dae15 = new SqlDataAdapter(sorgu15);
            sorgu15.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
            dae15.Fill(t15);

            SqlCommand sorgu16 = new SqlCommand("Listele_Yakin_Calisma_Bilgileri_Cikti", baglantim.baglanti());
            sorgu16.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dae16 = new SqlDataAdapter(sorgu16);
            sorgu16.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
            dae16.Fill(t16);


            SqlCommand sorgu17 = new SqlCommand("Listele_Yakin_gyk_Bilgileri_Cikti", baglantim.baglanti());
            sorgu17.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dae17 = new SqlDataAdapter(sorgu11);
            sorgu17.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
            dae17.Fill(t17);

            PdfPTable table1 = new PdfPTable(t1.Columns.Count);

            PdfPTable table2 = new PdfPTable(t2.Columns.Count);

            PdfPTable table3 = new PdfPTable(t3.Columns.Count);

            PdfPTable table4 = new PdfPTable(t4.Columns.Count);

            PdfPTable table5 = new PdfPTable(t5.Columns.Count);

            PdfPTable table6 = new PdfPTable(t6.Columns.Count);

            PdfPTable table7 = new PdfPTable(t7.Columns.Count);

            PdfPTable table8 = new PdfPTable(t8.Columns.Count);

            PdfPTable table9 = new PdfPTable(t9.Columns.Count);

            PdfPTable table10 = new PdfPTable(t10.Columns.Count);

            PdfPTable table11 = new PdfPTable(t11.Columns.Count);

            PdfPTable table12 = new PdfPTable(t12.Columns.Count);

            PdfPTable table13 = new PdfPTable(t13.Columns.Count);

            PdfPTable table14 = new PdfPTable(t14.Columns.Count);

            PdfPTable table15 = new PdfPTable(t15.Columns.Count);

            PdfPTable table16 = new PdfPTable(t16.Columns.Count);

            PdfPTable table17 = new PdfPTable(t17.Columns.Count);


            //BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            BaseFont btnColumnHeader = BaseFont.CreateFont(@"C:\Windows\Fonts\Calibri.ttf", "Identity-H", BaseFont.EMBEDDED);
            //iTextSharp.text.Font fntColumnHeader = new Font(btnColumnHeader, 6, 0, Color.BLACK);
            iTextSharp.text.Font fntColumnHeader = new iTextSharp.text.Font(btnColumnHeader, 6, 1, iTextSharp.text.BaseColor.BLACK);
            if (t1.Rows.Count > 0)
            {
                //t1 için
                for (int i = 0; i < t1.Columns.Count; i++)
                {
                    PdfPCell cell_1 = new PdfPCell();
                    cell_1.AddElement(new Chunk(t1.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                    table1.AddCell(cell_1);
                }

                for (int i = 0; i < t1.Rows.Count; i++)
                {
                    for (int j = 0; j < t1.Columns.Count; j++)
                    {
                        PdfPCell cell_1_1 = new PdfPCell();
                        cell_1_1.AddElement(new Chunk(t1.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                        table1.AddCell(cell_1_1);
                    }
                }

            }
            if (t2.Rows.Count > 0)
            {
                //t2için
                for (int i = 0; i < t2.Columns.Count; i++)
                {
                    PdfPCell cell_2 = new PdfPCell();
                    cell_2.AddElement(new Chunk(t2.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                    table2.AddCell(cell_2);
                }

                for (int i = 0; i < t2.Rows.Count; i++)
                {
                    for (int j = 0; j < t2.Columns.Count; j++)
                    {
                        PdfPCell cell_2_1 = new PdfPCell();
                        cell_2_1.AddElement(new Chunk(t2.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                        table2.AddCell(cell_2_1);
                    }
                }
            }
            //t3için
            if (t3.Rows.Count > 0)
            {
                for (int i = 0; i < t3.Columns.Count; i++)
                {
                    PdfPCell cell_3 = new PdfPCell();
                    cell_3.AddElement(new Chunk(t3.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                    table3.AddCell(cell_3);
                }

                for (int i = 0; i < t3.Rows.Count; i++)
                {
                    for (int j = 0; j < t3.Columns.Count; j++)
                    {
                        PdfPCell cell_3_1 = new PdfPCell();
                        cell_3_1.AddElement(new Chunk(t3.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                        table3.AddCell(cell_3_1);
                    }
                }

            }
            if (t4.Rows.Count > 0)
            {
                //t4için
                for (int i = 0; i < t4.Columns.Count; i++)
                {
                    PdfPCell cell_4 = new PdfPCell();
                    cell_4.AddElement(new Chunk(t4.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                    table4.AddCell(cell_4);
                }

                for (int i = 0; i < t4.Rows.Count; i++)
                {
                    for (int j = 0; j < t4.Columns.Count; j++)
                    {
                        PdfPCell cell_4_1 = new PdfPCell();
                        cell_4_1.AddElement(new Chunk(t4.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                        table4.AddCell(cell_4_1);
                    }
                }
            }
            //t5için
            if (t5.Rows.Count > 0)
            {
                for (int i = 0; i < t5.Columns.Count; i++)
                {
                    PdfPCell cell_5 = new PdfPCell();
                    cell_5.AddElement(new Chunk(t5.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                    table5.AddCell(cell_5);
                }

                for (int i = 0; i < t5.Rows.Count; i++)
                {
                    for (int j = 0; j < t5.Columns.Count; j++)
                    {
                        PdfPCell cell_5_1 = new PdfPCell();
                        cell_5_1.AddElement(new Chunk(t5.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                        table5.AddCell(cell_5_1);
                    }
                }
            }
            if (t6.Rows.Count > 0)
            {
                //t6için
                for (int i = 0; i < t6.Columns.Count; i++)
                {
                    PdfPCell cell_6 = new PdfPCell();
                    cell_6.AddElement(new Chunk(t6.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                    table6.AddCell(cell_6);
                }

                for (int i = 0; i < t6.Rows.Count; i++)
                {
                    for (int j = 0; j < t6.Columns.Count; j++)
                    {
                        PdfPCell cell_6_1 = new PdfPCell();
                        cell_6_1.AddElement(new Chunk(t6.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                        table6.AddCell(cell_6_1);
                    }
                }
            }
            if (t7.Rows.Count > 0)
            {

                //t7için
                for (int i = 0; i < t7.Columns.Count; i++)
                {
                    PdfPCell cell_7 = new PdfPCell();
                    cell_7.AddElement(new Chunk(t7.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                    table7.AddCell(cell_7);
                }

                for (int i = 0; i < t7.Rows.Count; i++)
                {
                    for (int j = 0; j < t7.Columns.Count; j++)
                    {
                        PdfPCell cell_7_1 = new PdfPCell();
                        cell_7_1.AddElement(new Chunk(t7.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                        table7.AddCell(cell_7_1);
                    }
                }
            }
            if (t8.Rows.Count > 0)
            {
                //t8için
                for (int i = 0; i < t8.Columns.Count; i++)
                {
                    PdfPCell cell_8 = new PdfPCell();
                    cell_8.AddElement(new Chunk(t8.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                    table8.AddCell(cell_8);
                }

                for (int i = 0; i < t8.Rows.Count; i++)
                {
                    for (int j = 0; j < t8.Columns.Count; j++)
                    {
                        PdfPCell cell_8_1 = new PdfPCell();
                        cell_8_1.AddElement(new Chunk(t8.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                        table8.AddCell(cell_8_1);
                    }
                }
            }
            if (t9.Rows.Count > 0)
            {
                //t9 için
                for (int i = 0; i < t9.Columns.Count; i++)
                {
                    PdfPCell cell_9 = new PdfPCell();
                    cell_9.AddElement(new Chunk(t9.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                    table9.AddCell(cell_9);
                }

                for (int i = 0; i < t9.Rows.Count; i++)
                {
                    for (int j = 0; j < t9.Columns.Count; j++)
                    {
                        PdfPCell cell_9_1 = new PdfPCell();
                        cell_9_1.AddElement(new Chunk(t9.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                        table9.AddCell(cell_9_1);
                    }
                }
            }
            if (t10.Rows.Count > 0)
            {

                //t10için
                for (int i = 0; i < t10.Columns.Count; i++)
                {
                    PdfPCell cell_10 = new PdfPCell();
                    cell_10.AddElement(new Chunk(t10.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                    table10.AddCell(cell_10);
                }

                for (int i = 0; i < t10.Rows.Count; i++)
                {
                    for (int j = 0; j < t10.Columns.Count; j++)
                    {
                        PdfPCell cell_10_1 = new PdfPCell();
                        cell_10_1.AddElement(new Chunk(t10.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                        table10.AddCell(cell_10_1);
                    }
                }
            }
            if (t11.Rows.Count > 0)
            {
                //t11için
                for (int i = 0; i < t11.Columns.Count; i++)
                {
                    PdfPCell cell_11 = new PdfPCell();
                    cell_11.AddElement(new Chunk(t11.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                    table11.AddCell(cell_11);
                }

                for (int i = 0; i < t11.Rows.Count; i++)
                {
                    for (int j = 0; j < t11.Columns.Count; j++)
                    {
                        PdfPCell cell_11_1 = new PdfPCell();
                        cell_11_1.AddElement(new Chunk(t11.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                        table11.AddCell(cell_11_1);
                    }
                }
            }
            if (t12.Rows.Count > 0)
            {
                //t12için
                for (int i = 0; i < t12.Columns.Count; i++)
                {
                    PdfPCell cell_12 = new PdfPCell();
                    cell_12.AddElement(new Chunk(t12.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                    table12.AddCell(cell_12);
                }

                for (int i = 0; i < t12.Rows.Count; i++)
                {
                    for (int j = 0; j < t12.Columns.Count; j++)
                    {
                        PdfPCell cell_12_1 = new PdfPCell();
                        cell_12_1.AddElement(new Chunk(t12.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                        table12.AddCell(cell_12_1);
                    }
                }
            }
            if (t13.Rows.Count > 0)
            {
                //t13için
                for (int i = 0; i < t13.Columns.Count; i++)
                {
                    PdfPCell cell_13 = new PdfPCell();
                    cell_13.AddElement(new Chunk(t13.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                    table13.AddCell(cell_13);
                }

                for (int i = 0; i < t13.Rows.Count; i++)
                {
                    for (int j = 0; j < t13.Columns.Count; j++)
                    {
                        PdfPCell cell_13_1 = new PdfPCell();
                        cell_13_1.AddElement(new Chunk(t13.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                        table13.AddCell(cell_13_1);
                    }
                }
            }
            if (t14.Rows.Count > 0)
            {
                //t14için
                for (int i = 0; i < t14.Columns.Count; i++)
                {
                    PdfPCell cell_14 = new PdfPCell();
                    cell_14.AddElement(new Chunk(t14.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                    table14.AddCell(cell_14);
                }

                for (int i = 0; i < t14.Rows.Count; i++)
                {
                    for (int j = 0; j < t14.Columns.Count; j++)
                    {
                        PdfPCell cell_14_1 = new PdfPCell();
                        cell_14_1.AddElement(new Chunk(t14.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                        table14.AddCell(cell_14_1);
                    }
                }
            }
            if (t15.Rows.Count > 0)
            {
                //t15için
                for (int i = 0; i < t15.Columns.Count; i++)
                {
                    PdfPCell cell_15 = new PdfPCell();
                    cell_15.AddElement(new Chunk(t15.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                    table15.AddCell(cell_15);
                }

                for (int i = 0; i < t15.Rows.Count; i++)
                {
                    for (int j = 0; j < t15.Columns.Count; j++)
                    {
                        PdfPCell cell_15_1 = new PdfPCell();
                        cell_15_1.AddElement(new Chunk(t15.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                        table15.AddCell(cell_15_1);
                    }
                }
            }
            if (t16.Rows.Count > 0)
            {
                //t16için
                for (int i = 0; i < t16.Columns.Count; i++)
                {
                    PdfPCell cell_16 = new PdfPCell();
                    cell_16.AddElement(new Chunk(t16.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                    table16.AddCell(cell_16);
                }

                for (int i = 0; i < t16.Rows.Count; i++)
                {
                    for (int j = 0; j < t16.Columns.Count; j++)
                    {
                        PdfPCell cell_16_1 = new PdfPCell();
                        cell_16_1.AddElement(new Chunk(t16.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                        table16.AddCell(cell_16_1);
                    }
                }
            }
            if (t17.Rows.Count > 0)
            {
                //t17için
                for (int i = 0; i < t17.Columns.Count; i++)
                {
                    PdfPCell cell_17 = new PdfPCell();
                    cell_17.AddElement(new Chunk(t17.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                    table17.AddCell(cell_17);
                }

                for (int i = 0; i < t17.Rows.Count; i++)
                {
                    for (int j = 0; j < t17.Columns.Count; j++)
                    {
                        PdfPCell cell_17_1 = new PdfPCell();
                        cell_17_1.AddElement(new Chunk(t17.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                        table17.AddCell(cell_17_1);
                    }
                }
            }
            /*
            //t18için
            for (int i = 0; i < t18.Columns.Count; i++)
            {
                PdfPCell cell_18 = new PdfPCell();
                cell_18.AddElement(new Chunk(t18.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table18.AddCell(cell_18);
            }

            for (int i = 0; i < t18.Rows.Count; i++)
            {
                for (int j = 0; j < t18.Columns.Count; j++)
                {
                    PdfPCell cell_18_1 = new PdfPCell();
                    cell_18_1.AddElement(new Chunk(t18.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                    table18.AddCell(cell_18_1);
                }
            }
            */



            iTextSharp.text.pdf.BaseFont STF_Helvetica_Turkish = iTextSharp.text.pdf.BaseFont.CreateFont("Helvetica", "CP1254", iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, iTextSharp.text.Font.NORMAL);
            Paragraph bosluk = new Paragraph();
            //BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            BaseFont btnAuthor = BaseFont.CreateFont(@"C:\Windows\Fonts\Calibri.ttf", "Identity-H", BaseFont.EMBEDDED);
            iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(STF_Helvetica_Turkish, 12, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            bosluk.Add(new Chunk(" \n                                                              " + "PERSONEL BİLGİ FORMU", fntAuthor));
            bosluk.Add(new Chunk("\n", fntAuthor));

            Paragraph prgAuthor1 = new Paragraph();
            prgAuthor1.Add(new Chunk("Başlık 1 : " + label1.Text, fntAuthor));



            Paragraph prgAuthor2 = new Paragraph();
            prgAuthor2.Add(new Chunk("Başlık 2 : " + label6.Text, fntAuthor));



            Paragraph prgAuthor3 = new Paragraph();
            prgAuthor3.Add(new Chunk("Başlık 3 : " + label2.Text + "\n", fntAuthor));////iletişim bilgileri

            Paragraph prgAuthor4 = new Paragraph();
            prgAuthor4.Add(new Chunk("Başlık 4 : " + label10.Text + "\n", fntAuthor));//firma imkanları bilgisi

            Paragraph prgAuthor5 = new Paragraph();
            prgAuthor5.Add(new Chunk("Başlık 5 : " + label4.Text + "\n", fntAuthor));//eğitim bilgisi

            //iTextSharp.text.pdf.BaseFont STF_Helvetica_Turkish = iTextSharp.text.pdf.BaseFont.CreateFont("Helvetica", "CP1254", iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);
            //iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, iTextSharp.text.Font.NORMAL);
            Paragraph egitim = new Paragraph();
            BaseFont btnegitim = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntegitim = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            egitim.Add(new Chunk(" \n                                                              " + "Personele ait eğitim bilgilerini giriniz.", fntegitim));
            egitim.Add(new Chunk("\n", fntegitim));

            Paragraph prgAuthor6 = new Paragraph();
            prgAuthor6.Add(new Chunk("Başlık 6 : " + label6.Text + "\n", fntAuthor));//sağlık bilgisi

            Paragraph saglik = new Paragraph();
            BaseFont btnsaglik = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntsaglik = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            saglik.Add(new Chunk(" \n                                                              " + "Personele ait saglik bilgilerini giriniz.", fntsaglik));
            saglik.Add(new Chunk("\n", fntsaglik));

            Paragraph prgAuthor7 = new Paragraph();
            prgAuthor7.Add(new Chunk("Başlık 7 : " + label2.Text + "\n", fntAuthor));//iletişim bilgisi

            Paragraph iletisim = new Paragraph();
            BaseFont btniletisim = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntiletisim = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            iletisim.Add(new Chunk(" \n                                                              " + "Personele ait iletişim bilgilerini giriniz.", fntiletisim));
            iletisim.Add(new Chunk("\n", fntiletisim));



            Paragraph prgAuthor8 = new Paragraph();
            prgAuthor8.Add(new Chunk("Başlık 6 : " + "Bilgisayar Bilgisi" + "\n", fntAuthor));

            Paragraph bilgisayar = new Paragraph();
            BaseFont btnbilgisayar = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntbilgisayar = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            bilgisayar.Add(new Chunk(" \n                                                              " + "Personele ait bilgisayar program bilgisi giriniz.", fntbilgisayar));
            bilgisayar.Add(new Chunk("\n", fntbilgisayar));

            Paragraph prgAuthor9 = new Paragraph();
            prgAuthor9.Add(new Chunk("Başlık 7 : " + "Yabancı Dil Bilgisi" + "\n", fntAuthor));

            Paragraph dil = new Paragraph();
            BaseFont btndil = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntdil = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            dil.Add(new Chunk(" \n                                                              " + "Personele ait yabancı dil bilgisi giriniz.", fntdil));
            dil.Add(new Chunk("\n", fntdil));

            Paragraph prgAuthor10 = new Paragraph();
            prgAuthor10.Add(new Chunk("Başlık 8 : " + "Sertifika Bilgisi" + "\n", fntAuthor));

            Paragraph sertifika = new Paragraph();
            BaseFont btnsertifika = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntsertifika = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            sertifika.Add(new Chunk(" \n                                                              " + "Personele ait sertifika bilgisi giriniz.", fntsertifika));
            sertifika.Add(new Chunk("\n", fntsertifika));

            Paragraph prgAuthor11 = new Paragraph();
            prgAuthor11.Add(new Chunk("Başlık 9 : " + "Ağır İş Sertifikası" + "\n", fntAuthor));

            Paragraph sertifikaa = new Paragraph();
            BaseFont btnsertifikaa = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntsertifikaa = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            sertifikaa.Add(new Chunk(" \n                                                              " + "Personele ait varsa ağır iş sertifika bilgisi giriniz.", fntsertifikaa));
            sertifikaa.Add(new Chunk("\n", fntsertifikaa));

            Paragraph prgAuthor12 = new Paragraph();
            prgAuthor12.Add(new Chunk("Başlık 11 : " + label7.Text + "\n", fntAuthor));

            Paragraph cv = new Paragraph();
            BaseFont btncv = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntcv = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            cv.Add(new Chunk(" \n                                                              " + "Personele ait varsa öz geçmiş bilgisi giriniz.", fntcv));
            cv.Add(new Chunk("\n", fntcv));

            Paragraph prgAuthor13 = new Paragraph();
            prgAuthor13.Add(new Chunk("Başlık 12 : " + label9.Text + "\n", fntAuthor));

            Paragraph kkd = new Paragraph();
            BaseFont btnkkd = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntkkd = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            kkd.Add(new Chunk(" \n                                                              " + "Personele ait varsa iş sağlığı ve güvenliği malzeme bilgisi giriniz.", fntkkd));
            kkd.Add(new Chunk("\n", fntkkd));

            Paragraph prgAuthor14 = new Paragraph();
            prgAuthor14.Add(new Chunk("Başlık 13 : " + label72.Text + "\n", fntAuthor));

            Paragraph borc = new Paragraph();
            BaseFont btnborc = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntborc = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            borc.Add(new Chunk(" \n                                                              " + "Personele ait herhangibir borç bilgisi yoktur.", fntborc));
            borc.Add(new Chunk("\n", fntborc));


            Paragraph prgAuthor15 = new Paragraph();
            prgAuthor15.Add(new Chunk("Başlık 14 : " + label8.Text + "\n", fntAuthor));

            Paragraph maddi = new Paragraph();
            BaseFont btnmaddi = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntmaddi = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            maddi.Add(new Chunk(" \n                                                              " + "Personele ait maddi durum bilgisi giriniz.", fntmaddi));
            maddi.Add(new Chunk("\n", fntmaddi));

            Paragraph prgAuthor16 = new Paragraph();
            prgAuthor16.Add(new Chunk("Başlık 15 : " + label55.Text + "\n", fntAuthor));


            Paragraph bakim = new Paragraph();
            BaseFont btnbakim = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntbakim = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            bakim.Add(new Chunk(" \n                                                              " + "Personelin bakımı ile ilgilendiği herhangi bir birey yoktur.", fntbakim));
            bakim.Add(new Chunk("\n", fntbakim));

            Paragraph prgAuthor17 = new Paragraph();
            prgAuthor17.Add(new Chunk("Başlık 16 : " + "Çekirdek Aileye Ait Temel Bilgiler" + "\n", fntAuthor));

            Paragraph yakın1 = new Paragraph();
            BaseFont btnyakın1 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntyakın1 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            yakın1.Add(new Chunk(" \n                                                              " + "Personelin çekirdek ailesine ait personel bilgisi yoktur.", fntyakın1));
            yakın1.Add(new Chunk("\n", fntyakın1));

            Paragraph prgAuthor18 = new Paragraph();
            prgAuthor18.Add(new Chunk("Başlık 17 : " + "Çekirdek Aileye Ait Sağlık Bilgileri" + "\n", fntAuthor));

            Paragraph yakın2 = new Paragraph();
            BaseFont btnyakın2 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntyakın2 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            yakın2.Add(new Chunk(" \n                                                              " + "Personelin çekirdek ailesine ait personel bilgisi yoktur.", fntyakın2));
            yakın2.Add(new Chunk("\n", fntyakın2));

            Paragraph prgAuthor19 = new Paragraph();
            prgAuthor19.Add(new Chunk("Başlık 18 : " + "Çekirdek Aileye Ait Eğitim Bilgileri" + "\n", fntAuthor));

            Paragraph yakın3 = new Paragraph();
            BaseFont btnyakın3 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntyakın3 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            yakın3.Add(new Chunk(" \n                                                              " + "Personelin çekirdek ailesine ait personel bilgisi yoktur.", fntyakın3));
            yakın3.Add(new Chunk("\n", fntyakın3));

            Paragraph prgAuthor20 = new Paragraph();
            prgAuthor20.Add(new Chunk("Başlık 19 : " + "Çekirdek Aileye Ait Çalışan Bilgisi" + "\n", fntAuthor));

            Paragraph yakın4 = new Paragraph();
            BaseFont btnyakın4 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntyakın4 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            yakın4.Add(new Chunk(" \n                                                              " + "Personelin çekirdek ailesine ait personel bilgisi yoktur.", fntyakın4));
            yakın4.Add(new Chunk("\n", fntyakın4));

            Paragraph prgAuthor21 = new Paragraph();
            prgAuthor21.Add(new Chunk("Başlık 20 : " + "Çekirdek Aileye Ait Genel Kültür Bilgisi" + "\n", fntAuthor));

            Paragraph yakın5 = new Paragraph();
            BaseFont btnyakın5 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntyakın5 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            yakın5.Add(new Chunk(" \n                                                              " + "Personelin çekirdek ailesine ait personel bilgisi yoktur.", fntyakın5));
            yakın5.Add(new Chunk("\n", fntyakın5));

            Paragraph prgAuthor22 = new Paragraph();
            prgAuthor22.Add(new Chunk("Başlık 10 : " + "Personelin hobileri" + "\n", fntAuthor));

            Paragraph hobi = new Paragraph();
            BaseFont btnhobi = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fnthobi = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            hobi.Add(new Chunk(" \n                                                              " + "Personelin kayıtlı bir hobisi yoktur.", fnthobi));
            hobi.Add(new Chunk("\n", fnthobi));


            Paragraph cocuk = new Paragraph();
            BaseFont btncocuk = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntcocuk = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            cocuk.Add(new Chunk(" \n                Çocuk Sayısı=" + lbl_cocuk.Text, fntcocuk));
            cocuk.Add(new Chunk("\n", fntcocuk));

            Paragraph cocukyok = new Paragraph();
            BaseFont btncocukyok = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntcocukyok = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            cocukyok.Add(new Chunk(" \n                  " + "Personelin kayıtlı cocuk bilgisi yoktur.", fntcocukyok));
            cocukyok.Add(new Chunk("\n", fntcocukyok));


            Paragraph hobii = new Paragraph();
            BaseFont btnhobii = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fnthobii = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            hobii.Add(new Chunk(" \n                Hobileri=" + lbl_hobileri.Text, fnthobii));
            hobii.Add(new Chunk("\n", fnthobii));

            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////

            Paragraph aylikGider = new Paragraph();
            BaseFont btnaylikGider = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntaylikGider = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            aylikGider.Add(new Chunk(label56.Text + " : " + lbl_gider.Text, fntaylikGider));
            //   aylikGider.Add(new Chunk("\n", fntaylikGider));

            Paragraph sure = new Paragraph();
            BaseFont btnsure = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntsure = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            sure.Add(new Chunk(label57.Text + " : " + lbl_sure.Text, fntsure));
            //   sure.Add(new Chunk("\n", fntsure));

            Paragraph vasita = new Paragraph();
            BaseFont btnvasita = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntvasita = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            vasita.Add(new Chunk(label58.Text, fntvasita));
            //   vasita.Add(new Chunk("\n", fntvasita));


            Paragraph vasita1 = new Paragraph();
            BaseFont btnvasita1 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntvasita1 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            vasita1.Add(new Chunk(label60.Text + " : " + lbl_v1.Text, fntvasita1));
            //     vasita1.Add(new Chunk("\n", fntvasita1));

            Paragraph vasita2 = new Paragraph();
            BaseFont btnvasita2 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntvasita2 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            vasita2.Add(new Chunk(label61.Text + " : " + lbl_v2.Text, fntvasita2));
            /// vasita2.Add(new Chunk("\n", fntvasita2));


            Paragraph vasita3 = new Paragraph();
            BaseFont btnvasita3 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntvasita3 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            vasita3.Add(new Chunk(label62.Text + " : " + lbl_3.Text, fntvasita3));
            //vasita3.Add(new Chunk("\n", fntvasita3));

            Paragraph vasita4 = new Paragraph();
            BaseFont btnvasita4 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntvasita4 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            vasita4.Add(new Chunk(label63.Text + " : " + lbl_4.Text, fntvasita4));
            //   vasita4.Add(new Chunk("\n", fntvasita4));

            Paragraph vasita5 = new Paragraph();
            BaseFont btnvasita5 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntvasita5 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            vasita5.Add(new Chunk(label64.Text + " : " + lbl_5.Text, fntvasita5));
            //   vasita5.Add(new Chunk("\n", fntvasita5));

            Paragraph vasita6 = new Paragraph();
            BaseFont btnvasita6 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntvasita6 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            vasita6.Add(new Chunk(label65.Text + " : " + lbl_v6.Text, fntvasita6));
            //     vasita6.Add(new Chunk("\n", fntvasita6));

            Paragraph alarji = new Paragraph();
            BaseFont btnalarji = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntalarji = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            alarji.Add(new Chunk(label68.Text + " : " + txt_alerji.Text, fntalarji));
            //    alarji.Add(new Chunk("\n", fntalarji));




            Paragraph yemek1 = new Paragraph();
            BaseFont btnyemek1 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntyemek1 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            yemek1.Add(new Chunk(label69.Text + " " + lbl_yemek.Text, fntyemek1));
            // yemek1.Add(new Chunk("\n", fntyemek1));


            Paragraph yemek2 = new Paragraph();
            BaseFont btnyemek2 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntyemek2 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            yemek2.Add(new Chunk(label71.Text + " : " + txt_neden.Text, fntyemek2));
            //    yemek2.Add(new Chunk("\n", fntyemek2));


            Paragraph talep = new Paragraph();
            BaseFont btntalep = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fnttalep = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            talep.Add(new Chunk(label70.Text + " : " + txt_talep.Text, fnttalep));
            //  talep.Add(new Chunk("\n", fnttalep));

            //////////////////////////////////////////////////////////////////////////
            ///////////////
            ///
            //////////////////////////////////////////////////////////////////////////

            Paragraph tcbilgisi = new Paragraph();
            BaseFont btntcbilgisi = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fnttcbilgisi = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            tcbilgisi.Add(new Chunk(label73.Text + " : " + lbl_tc.Text, fnttcbilgisi));

            Paragraph adsoyad = new Paragraph();
            BaseFont btnadsoyad = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntadsoyad = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            adsoyad.Add(new Chunk(label21.Text + " " + label22.Text + " : " + lbl_ad.Text + " " + lbl_soyad.Text, fntadsoyad));

            Paragraph uyruk = new Paragraph();
            BaseFont btnuyruk = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntuyruk = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            uyruk.Add(new Chunk(label23.Text + " : " + lbl_uyruk.Text, fntuyruk));

            Paragraph cinsiyet = new Paragraph();
            BaseFont btncinsiyet = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntcinsiyet = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            cinsiyet.Add(new Chunk(label24.Text + " : " + lbl_cinsiyet.Text, fntcinsiyet));

            Paragraph medeni = new Paragraph();
            BaseFont btnmedeni = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntmedeni = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            medeni.Add(new Chunk(label17.Text + " : " + lbl_medeni_hal.Text, fntmedeni));

            Paragraph dogum = new Paragraph();
            BaseFont btndogum = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntdogum = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            dogum.Add(new Chunk("DOĞUM YERİ/TARİHİ" + " : " + lbl_dogum_yeri.Text + " / " + lbl_dogum_tarihi.Text, fntdogum));

            Paragraph baba = new Paragraph();
            BaseFont btnbaba = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntbaba = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            baba.Add(new Chunk(label13.Text + " : " + lbl_baba_adi.Text, fntbaba));


            Paragraph anne = new Paragraph();
            BaseFont btnanne = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntanne = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            anne.Add(new Chunk(label20.Text + " : " + lbl_ana_adi.Text, fntanne));


            Paragraph kod = new Paragraph();
            BaseFont btnkod = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntkod = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            kod.Add(new Chunk(label14.Text + " : " + lbl_meslek_kodu.Text, fntkod));



            Paragraph gorev = new Paragraph();
            BaseFont btngorev = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntgorev = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            gorev.Add(new Chunk("GÖREV / YERİ" + " : " + lbl_görevi.Text + " / " + lbl_gorev_yeri.Text, fntgorev));

            Paragraph durum = new Paragraph();
            BaseFont btndurum = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntdurum = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            durum.Add(new Chunk("ÇALIŞMA SÜRESİ" + " : " + lbl_ise_giris.Text + " / " + lbl_isten_cikis.Text, fntdurum));

            Paragraph dipnot = new Paragraph();
            BaseFont btndipnot = BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntdipnot = new iTextSharp.text.Font(STF_Helvetica_Turkish, 6, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            dipnot.Add(new Chunk("~~Optimak İnsan Kaynakları Form Sonu" + "      /     " + DateTime.Now.ToString(), fntdipnot));


            //MemoryStream ms = new MemoryStream();
            //picb_resim.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //byte[] resim = ms.GetBuffer();



            iTextSharp.text.Image resim = iTextSharp.text.Image.GetInstance(picb_resim.Image, System.Drawing.Imaging.ImageFormat.Jpeg);

            resim.ScaleAbsolute(90, 90);//pdf deki resmi boyutlandırma.

            ////////////////////////////////////////////////////////////////////
            ///
            ////////////////////////////////////////////////////////////////////


            Paragraph ara = new Paragraph();
            ara.Add(new Chunk("\n", fntAuthor));
            {     /*



                    Paragraph prgAuthor = new Paragraph();
                    //BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    // iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(STF_Helvetica_Turkish, 12, 1, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    prgAuthor.Add(new Chunk("                                                               Başlık 1 : " + label1.Text, fntAuthor));
                    prgAuthor.Add(new Chunk("\n\n", fntAuthor));






                    //deneme
                    {
                        //prgAuthor.Add(new Chunk("\n\n\nTemel Kimlik Bilgileri\n", fntAuthor));
                        prgAuthor.Add(new Chunk(
                            textBox3.Text + textBox3.Text + lbl_tc_no.Text + " : " + mtxt_tc_no.Text + "\n" +
                            textBox3.Text + textBox3.Text + lbl_pdks.Text + " : " + txt_pdks.Text + "\n" +
                            textBox3.Text + textBox3.Text + "ADI SOYADI" + " : " + lbl_ad.Text + " " + lbl_soyad.Text + "\n" +
                            textBox3.Text + textBox3.Text + label23.Text + " : " + lbl_uyruk.Text + "\n" +
                            textBox3.Text + textBox3.Text + label24.Text + " : " + lbl_cinsiyet.Text + "\n" +
                            textBox3.Text + textBox3.Text + label17.Text + " : " + lbl_medeni_hal.Text + "\n" +
                            textBox3.Text + textBox3.Text + label18.Text + " : " + lbl_dogum_tarihi.Text + "\n" +
                            textBox3.Text + textBox3.Text + label19.Text + " : " + lbl_dogum_yeri.Text + "\n" +
                            textBox3.Text + textBox3.Text + label20.Text + " : " + lbl_ana_adi.Text + "\n" +
                            textBox3.Text + textBox3.Text + label13.Text + " : " + lbl_baba_adi.Text + "\n" +
                            textBox3.Text + textBox3.Text + label14.Text + " : " + lbl_meslek_kodu.Text + "\n" +
                            textBox3.Text + textBox3.Text + label15.Text + " : " + lbl_görevi.Text + "\n" +
                            textBox3.Text + textBox3.Text + label16.Text + " : " + lbl_gorev_yeri.Text + "\n" +
                            textBox3.Text + textBox3.Text + lbl_calisma_durumu.Text + " : " + lbl_durum.Text + "\n" +
                            textBox3.Text + textBox3.Text + label11.Text + " : " + lbl_ise_giris.Text + "\n" +
                            textBox3.Text + textBox3.Text + label12.Text + " : " + lbl_isten_cikis.Text + "\n" +
                            "\n\n"
                            , fntAuthor));

                        prgAuthor.Add(new Chunk("                                                               Başlık 2 : " + label10.Text, fntAuthor));
                        prgAuthor.Add(new Chunk("\n\n", fntAuthor));
                        prgAuthor.Add(new Chunk(
                             textBox3.Text + textBox3.Text + label56.Text + " : " + lbl_gider.Text + "\n" +
                             textBox3.Text + textBox3.Text + label57.Text + " : " + lbl_gider.Text + "\n" +
                             textBox3.Text + textBox3.Text + label58.Text + " ; " + "\n" +
                             textBox3.Text + textBox3.Text + label60.Text + " : " + lbl_v1.Text + "\n" +
                             textBox3.Text + textBox3.Text + label60.Text + " : " + lbl_v1.Text + textBox3.Text + textBox3.Text + textBox3.Text + textBox3.Text + label61.Text + " : " + lbl_v2.Text + "\n" +
                             textBox3.Text + textBox3.Text + label62.Text + " : " + lbl_3.Text + textBox3.Text + textBox3.Text + textBox3.Text + textBox3.Text + label61.Text + " : " + lbl_v2.Text + "\n" +
                             textBox3.Text + textBox3.Text + label64.Text + " : " + lbl_5.Text + textBox3.Text + textBox3.Text + textBox3.Text + textBox3.Text + label65.Text + " : " + lbl_v6.Text + "\n" +
                             textBox3.Text + textBox3.Text + label68.Text + " : " + txt_alerji.Text + "\n" +
                             textBox3.Text + textBox3.Text + label69.Text + " : " + lbl_yemek.Text + " ; " +
                             textBox3.Text + textBox3.Text + textBox3.Text + textBox3.Text + label71.Text + "  " + txt_neden.Text + "\n" +
                             textBox3.Text + textBox3.Text + label70.Text + " " + txt_talep.Text +
                                "\n\n"
                            , fntAuthor));



                        prgAuthor.Add(new Chunk("                                                               Başlık 3 : " + label3.Text, fntAuthor));
                        prgAuthor.Add(new Chunk("\n\n", fntAuthor));
                        prgAuthor.Add(new Chunk(
                             textBox3.Text + textBox3.Text + lbl_hobi.Text + " " + lbl_hobileri.Text +
                                "\n\n"
                            , fntAuthor));
                    }
                    e.Graphics.DrawString(label11.Text + " : " + lbl_ise_giris.Text, myFont1, sb1, 630, 100);

                    e.Graphics.DrawString(label23.Text + " : " + lbl_uyruk.Text, myFont1, sb1, 100, 125);
                    e.Graphics.DrawString(label19.Text + " : " + lbl_dogum_yeri.Text, myFont1, sb1, 255, 125);
                    e.Graphics.DrawString(label15.Text + " : " + lbl_görevi.Text, myFont1, sb1, 430, 125);
                    e.Graphics.DrawString(label12.Text + " : " + lbl_isten_cikis.Text, myFont1, sb1, 630, 125);
                    */
            }
            {
                document.Add(resim);
                document.Add(bosluk);

                //document.Add(prgAuthor);
                document.Add(prgAuthor1);//başlık 1

                ///////////////////////////////////////////////////////
                ///
                /////////////////////////////////////////////////////////

                // document.Add(png);

                document.Add(tcbilgisi);
                document.Add(adsoyad);
                document.Add(uyruk);
                document.Add(cinsiyet);
                document.Add(medeni);
                document.Add(dogum);
                document.Add(baba);
                document.Add(anne);
                document.Add(kod);
                document.Add(gorev);
                document.Add(durum);



                document.Add(ara);//araya boşluk tara


                ///////////////////////////////////////////////////////
                ///
                /////////////////////////////////////////////////////////

                document.Add(prgAuthor2);//başlık 2

                //document.Add(png2);
                document.Add(ara);//araya boşluk atar
                                  // document.Add(prgAuthor6);
                if (t2.Rows.Count > 0)//sağlık kısmı için
                {
                    document.Add(ara);
                    document.Add(table2);
                }
                else
                    document.Add(saglik);


                document.Add(ara);//araya boşluk atar


                document.Add(prgAuthor3);//başlık3

                document.Add(ara);
                //document.Add(prgAuthor7);
                if (t3.Rows.Count > 0)//letişim tablosu
                {
                    document.Add(ara);
                    document.Add(table3);
                }
                else
                    document.Add(iletisim);

                document.Add(ara);

                ///////////////////////////////////////////////////////
                ///
                /////////////////////////////////////////////////////////
                document.Add(prgAuthor4);//başlık4
                                         //document.Add(png4);//firma ikanları resmi


                document.Add(ara);

                if (lbl_gider.Text != "" && lbl_gider.Text != "...")
                {
                    document.Add(aylikGider);
                }
                if (lbl_sure.Text != "" && lbl_sure.Text != "...")
                {
                    document.Add(sure);
                }
                if (lbl_v1.Text != "" && lbl_v1.Text != "...")
                {
                    document.Add(vasita);
                }
                if (lbl_v1.Text != "" && lbl_v1.Text != "...")
                {
                    document.Add(vasita1);
                }
                if (lbl_v2.Text != "" && lbl_v2.Text != "...")
                {
                    document.Add(vasita2);
                }
                if (lbl_3.Text != "" && lbl_3.Text != "...")
                {
                    document.Add(vasita3);
                }
                if (lbl_4.Text != "" && lbl_4.Text != "...")
                {
                    document.Add(vasita4);
                }
                if (lbl_5.Text != "" && lbl_5.Text != "...")
                {
                    document.Add(vasita5);
                }
                if (lbl_v6.Text != "" && lbl_v6.Text != "...")
                {
                    document.Add(vasita6);
                }
                if (txt_alerji.Text != "")
                {
                    document.Add(alarji);
                }
                if (lbl_yemek.Text != "" && lbl_yemek.Text != "...")
                {
                    document.Add(yemek1);
                }
                if (txt_neden.Text != "")
                {
                    document.Add(yemek2);
                }
                if (txt_talep.Text != "")
                {
                    document.Add(talep);
                }

                ///////////////////////////////////////////////////////
                ///
                /////////////////////////////////////////////////////////

                document.Add(ara);//araya boşluk atar



                document.Add(prgAuthor5);//başlık5

                if (t1.Rows.Count > 0)
                {
                    document.Add(ara);
                    document.Add(table1);//eğitim kısmı
                }
                else
                    document.Add(egitim);

                document.Add(ara);




                document.Add(prgAuthor8);//başlık6

                if (t4.Rows.Count > 0)
                {
                    document.Add(ara);
                    document.Add(table4);//bilgisayar becerisi
                }
                else
                    document.Add(bilgisayar);

                document.Add(ara);


                document.Add(prgAuthor9);//başlık7
                if (t5.Rows.Count > 0)
                {
                    document.Add(ara);
                    document.Add(table5);//yabancı dil
                }
                else
                    document.Add(dil);

                document.Add(ara);



                document.Add(prgAuthor10);//başlık8
                if (t6.Rows.Count > 0)
                {
                    document.Add(ara);
                    document.Add(table6);//sertifika 
                }
                else
                    document.Add(sertifika);
                document.Add(ara);





                document.Add(prgAuthor11);//başlık9
                if (t7.Rows.Count > 0)
                {
                    document.Add(ara);
                    document.Add(table7);//ağır iş sertifikası
                }
                else
                    document.Add(sertifikaa);

                document.Add(ara);




                document.Add(prgAuthor22);//başlık10
                                          //document.Add(ara);

                if (lbl_hobileri.Text == "...")
                    document.Add(hobi);
                else
                    document.Add(hobii);

                document.Add(ara);



                document.Add(prgAuthor12);//başlık11
                if (t8.Rows.Count > 0)
                {
                    document.Add(ara);
                    document.Add(table8);//öz geçmiş
                }
                else
                    document.Add(cv);

                document.Add(ara);

                document.Add(prgAuthor13);//başlık12

                if (t9.Rows.Count > 0)
                {
                    document.Add(ara);
                    document.Add(table9);//isg-kkd
                }
                else
                    document.Add(kkd);

                document.Add(ara);




                document.Add(prgAuthor14);//başlık13
                if (t10.Rows.Count > 0)
                {
                    document.Add(ara);
                    document.Add(table10);//borç tablosu
                }
                else
                    document.Add(borc);
                document.Add(ara);





                document.Add(prgAuthor15);//başlık14
                if (t11.Rows.Count > 0)
                {
                    document.Add(ara);
                    document.Add(table11);//maddi durum tablosu
                }
                else
                    document.Add(maddi);
                document.Add(ara);





                document.Add(prgAuthor16);//başlık15
                if (t12.Rows.Count > 0)
                {
                    document.Add(ara);
                    document.Add(table12);//bakımı ile ilgili tablo
                }
                else
                    document.Add(bakim);
                document.Add(ara);




                document.Add(prgAuthor17);//başlık16

                if (t13.Rows.Count > 0)
                {
                    {
                        if (lbl_cocuk.Text == "0")
                            document.Add(cocukyok);
                        else
                            document.Add(cocuk);
                        document.Add(ara);
                    }
                    document.Add(table13);//aile temel bilgiler
                }

                else
                    document.Add(yakın1);

                document.Add(ara);




                document.Add(prgAuthor18);//başlık17
                if (t14.Rows.Count > 0)
                {
                    document.Add(ara);
                    document.Add(table14);
                }
                else
                    document.Add(yakın2);//aile sağlık bilgisi

                document.Add(ara);



                document.Add(prgAuthor19);//başlık18

                if (t15.Rows.Count > 0)
                {
                    document.Add(ara);
                    document.Add(table15);//aile eğitim bilgisi
                }
                else
                    document.Add(yakın3);
                document.Add(ara);


                document.Add(prgAuthor20);//başlık19
                if (t16.Rows.Count > 0)
                {
                    document.Add(ara);
                    document.Add(table16);//aile çalışma bilgisi
                }
                else
                    document.Add(yakın4);



                document.Add(ara);
                document.Add(prgAuthor21);//başlık20
                if (t17.Rows.Count > 0)
                {
                    document.Add(ara);

                    document.Add(table17);//aile genel kültür
                }
                else
                    document.Add(yakın5);
                document.Add(ara);
                document.Add(ara);
                document.Add(ara);
                document.Add(ara);
                document.Add(ara);

                document.Add(dipnot);

                //document.Add(table18);

                document.Close();
                writer.Close();
                fs.Close();
            }

            //   string strPdfPath = @"C://Dosyalar/" + mtxt_tc_no.Text + "/" + mtxt_tc_no.Text + "_" + "Tüm_Bilgiler.pdf";

            System.Diagnostics.Process.Start(strPdfPath);

            ////////////////////////Yeni Kod Sonu//////////////////////////
        }
        //son1


        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            //GridView[] gvpdf = new GridView[] {gridView1, gridView2, gridView3, gridView4, gridView5, gridView6, gridView7, gridView8,
            //    gridView9,gridView10,gridView11,gridView12,gridView13,gridView14 };
            //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            //MemoryStream ms = new MemoryStream();
            //PdfWriter.GetInstance(pdfDoc, ms);
            //pdfDoc.Open();

            int x, y;
            int satir_yuksekligi, sayfa_yuksekligi;

            System.Drawing.Printing.PageSettings sayfa_ayari;
            sayfa_ayari = printDocument1.DefaultPageSettings;
            sayfa_yuksekligi = sayfa_ayari.PaperSize.Height - sayfa_ayari.Margins.Top - sayfa_ayari.Margins.Bottom;

            int sayfa_genisligi;

            sayfa_genisligi = sayfa_ayari.PaperSize.Width - sayfa_ayari.Margins.Left - sayfa_ayari.Margins.Right;

            x = sayfa_ayari.Margins.Left + 2;
            y = sayfa_ayari.Margins.Top;

            StringFormat ortala = new StringFormat();
            ortala.Alignment = StringAlignment.Center;

            /*  StringFormat saga_yasla = new StringFormat();
             saga_yasla.Alignment = StringAlignment.Far;*/



            //Yazı fontumu ve çizgi çizmek için fırçamı ve kalem nesnemi oluşturdum
            System.Drawing.Font myFont1 = new System.Drawing.Font("Calibri", 6);
            SolidBrush sbrush1 = new SolidBrush(Color.Black);
            Pen myPen1 = new Pen(Color.Black);



            System.Drawing.Font myFont = new System.Drawing.Font("Calibri", 28);
            SolidBrush sbrush = new SolidBrush(Color.Black);
            Pen myPen = new Pen(Color.Black);

            System.Drawing.Font cizgiFont = new System.Drawing.Font("Calibri", 28, FontStyle.Underline);
            SolidBrush cizgisbrush = new SolidBrush(Color.Black);
            Pen cizgiPen = new Pen(Color.Black);

            System.Drawing.Font ustFont = new System.Drawing.Font("Calibri", 8);
            SolidBrush sbbrush = new SolidBrush(Color.Black);
            Pen ustPen = new Pen(Color.Black);


            System.Drawing.Font tableFont = new System.Drawing.Font("Calibri", 5);
            SolidBrush tablerush = new SolidBrush(Color.Black);
            Pen tablePen = new Pen(Color.Black);

            System.Drawing.Font italikFont = new System.Drawing.Font("Calibri", 8, FontStyle.Underline);
            SolidBrush italiksbrush = new SolidBrush(Color.Black);
            Pen italikPen = new Pen(Color.Black);


            satir_yuksekligi = (int)e.Graphics.MeasureString("x", myFont).Height;

            StringFormat ustStringFormat = new StringFormat();
            ustStringFormat.Alignment = StringAlignment.Far;
            ustStringFormat.LineAlignment = StringAlignment.Center;

            cizgiFont = new System.Drawing.Font("Calibri", 8, FontStyle.Underline);
            SolidBrush sbcizgi = new SolidBrush(Color.Black);

            italikFont = new System.Drawing.Font("Calibri", 8, FontStyle.Italic);
            SolidBrush isbcizgi = new SolidBrush(Color.Black);

            myFont = new System.Drawing.Font("Calibri", 8, FontStyle.Bold);
            SolidBrush sb = new SolidBrush(Color.Black);

            myFont1 = new System.Drawing.Font("Calibri", 6, FontStyle.Regular);
            SolidBrush sb1 = new SolidBrush(Color.Black);

            switch (a)
            {
                //birinci sayfa

                case 1:
                    ////////////////////////Yeni Kod Başlangıç//////////////////////////
                    // string tc = "";
                    // string strPdfPath = @"C:\Dosyalar\ciktiForm.pdf";
                    //string strPdfPath = @"C:\\Dosyalar\\"+mtxt_tc_no.Text+"\\";
                    string dosya_yolu = "C:\\Dosyalar\\" + mtxt_tc_no.Text;
                    if (Directory.Exists(dosya_yolu))
                    {
                        // MessageBox.Show("Dosya bulundu", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        try
                        {
                            Directory.CreateDirectory(@"C://Dosyalar/" + mtxt_tc_no.Text + "/");
                            //  MessageBox.Show("Dosya başarılı bir şekilde oluşturulmuştur.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Exception)
                        {

                            // MessageBox.Show("Dosya oluşturulamadı", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    string strPdfPath = @"C://Dosyalar/" + mtxt_tc_no.Text + "/" + mtxt_tc_no.Text + "_" + "Tüm_Bilgiler.pdf";

                    //string yeniad = mtxt_tc_no.Text + "_" + "bilgiler.pdf"; //Benzersiz isim verme

                    //   "C:\\Dosyalar\\" + mtxt_tc_no.Text;

                    //string strPdfPath = @"C://Dosyalar/" + mtxt_tc_no.Text + "/" + mtxt_tc_no.Text + "_Tüm Bilgileri" + ".pdf";

                    System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
                    //Document document = new Document();

                    Document document = new Document(PageSize.A4, 10f, 10f, 10f, 10f);//???

                    document.SetPageSize(iTextSharp.text.PageSize.A4);

                    PdfWriter writer = PdfWriter.GetInstance(document, fs);//yazıyorrr 
                    document.Open();


                    Bitmap MemoryImage;

                    Panel pnl;
                    pnl = panel_genel_bilgiler;
                    MemoryImage = new Bitmap(pnl.Width, pnl.Height);
                    System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, pnl.Width, pnl.Height);
                    pnl.DrawToBitmap(MemoryImage, new System.Drawing.Rectangle(0, 0, pnl.Width, pnl.Height));

                    iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(MemoryImage, System.Drawing.Imaging.ImageFormat.Png);




                    Bitmap MemoryImage2;

                    Panel pnl2;
                    pnl2 = panel_saglik;
                    MemoryImage2 = new Bitmap(pnl2.Width, pnl2.Height);
                    System.Drawing.Rectangle rect2 = new System.Drawing.Rectangle(0, 0, pnl2.Width, pnl2.Height);
                    pnl2.DrawToBitmap(MemoryImage2, pnl2.ClientRectangle);
                    //pnl2.DrawToBitmap(MemoryImage2, new System.Drawing.Rectangle(0, 0, pnl2.Width, pnl2.Height));

                    iTextSharp.text.Image png2 = iTextSharp.text.Image.GetInstance(MemoryImage2, System.Drawing.Imaging.ImageFormat.Png);


                    Bitmap MemoryImage3;

                    Panel pnl3;
                    pnl3 = panel_iletisim;
                    MemoryImage3 = new Bitmap(pnl3.Width, pnl3.Height);
                    System.Drawing.Rectangle rect3 = new System.Drawing.Rectangle(0, 0, pnl3.Width, pnl3.Height);
                    pnl3.DrawToBitmap(MemoryImage3, new System.Drawing.Rectangle(0, 0, pnl3.Width, pnl3.Height));

                    iTextSharp.text.Image png3 = iTextSharp.text.Image.GetInstance(MemoryImage3, System.Drawing.Imaging.ImageFormat.Png);


                    Bitmap MemoryImage4;

                    Panel pnl4;
                    pnl4 = panel_ulasim;
                    MemoryImage4 = new Bitmap(pnl4.Width, pnl4.Height);
                    System.Drawing.Rectangle rect4 = new System.Drawing.Rectangle(0, 0, pnl4.Width, pnl4.Height);
                    pnl4.DrawToBitmap(MemoryImage4, new System.Drawing.Rectangle(0, 0, pnl4.Width, pnl4.Height));

                    iTextSharp.text.Image png4 = iTextSharp.text.Image.GetInstance(MemoryImage4, System.Drawing.Imaging.ImageFormat.Png);

                    //Bitmap MemoryImage6;

                    //MemoryImage6 = new Bitmap(picb_resim.Width, picb_resim.Height);
                    //System.Drawing.Rectangle rect6 = new System.Drawing.Rectangle(0, 0, picb_resim.Width, picb_resim.Height);
                    //picb_resim.Image.RawFormat(Stream, ImageFormatConverter);
                    //(MemoryImage, new System.Drawing.Rectangle(0, 0, picb_resim.Width, picb_resim.Height));

                    //iTextSharp.text.Image png6 = iTextSharp.text.Image.GetInstance(MemoryImage6, System.Drawing.Imaging.ImageFormat.Png);



                    //Bitmap MemoryImage5;

                    //Panel pnl5;
                    //pnl5 = panel_ulasim;
                    //MemoryImage5 = new Bitmap(pnl5.Width, pnl5.Height);
                    //System.Drawing.Rectangle rect5 = new System.Drawing.Rectangle(0, 0, pnl5.Width, pnl5.Height);
                    //pnl5.DrawToBitmap(MemoryImage5, new System.Drawing.Rectangle(0, 0, pnl5.Width, pnl5.Height));

                    //iTextSharp.text.Image png5 = iTextSharp.text.Image.GetInstance(MemoryImage5, System.Drawing.Imaging.ImageFormat.Png);

                    /*
                    iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(picb_resim.Image, System.Drawing.Imaging.ImageFormat.Jpeg);

                    png.ScaleAbsolute(90, 90);//pdf deki resmi boyutlandırma.*/


                    DataTable t1 = new DataTable();

                    DataTable t2 = new DataTable();

                    DataTable t3 = new DataTable();

                    DataTable t4 = new DataTable();

                    DataTable t5 = new DataTable();

                    DataTable t6 = new DataTable();

                    DataTable t7 = new DataTable();

                    DataTable t8 = new DataTable();

                    DataTable t9 = new DataTable();

                    DataTable t10 = new DataTable();

                    DataTable t11 = new DataTable();

                    DataTable t12 = new DataTable();

                    DataTable t13 = new DataTable();

                    DataTable t14 = new DataTable();

                    DataTable t15 = new DataTable();

                    DataTable t16 = new DataTable();

                    DataTable t17 = new DataTable();

                    //eğitim bilgisi girilmiş mi diye sorgulamak lazım


                    bool kayitkontrolegitim = false;//bir kayıt yaparken daha önceden böyle bir kullanıcı var mı diye kontrolü yapılacak
                                                    //baglantim.baglanti().Open();
                    SqlCommand selectsorgu = new SqlCommand("select * from Kisi_Egitim_Bilgisi where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

                    SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.
                                                                           //ilgili tc no ya ait vb de kayıt vamı diye kontrol edelim.

                    //while (kayitokuma.Read())
                    //{
                    kayitkontrolegitim = true;//ilgili tc noya ait bir kullanıcı var demektir.
                    SqlCommand sorgu1 = new SqlCommand("Listele_Egitim_Bilgisi_Cikti", baglantim.baglanti());
                    sorgu1.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae1 = new SqlDataAdapter(sorgu1);
                    sorgu1.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
                    dae1.Fill(t1);
                    //    break;

                    //}
                    //eğitim bilgisi girilmiş mi diye sorgulamak lazım


                    //bool kayitkontrolesaglik = false;//bir kayıt yaparken daha önceden böyle bir kullanıcı var mı diye kontrolü yapılacak
                    //                                //baglantim.baglanti().Open();
                    //SqlCommand selectsorgu2 = new SqlCommand("select * from Kisi_Saglik_Bilgisi where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

                    //SqlDataReader kayitokuma2 = selectsorgu2.ExecuteReader();//okuduğu sorguları tutuyoruz.
                    //                                                       //ilgili tc no ya ait vb de kayıt vamı diye kontrol edelim.

                    //while (kayitokuma2.Read())
                    //{
                    //kayitkontrolesaglik = true;
                    SqlCommand sorgu2 = new SqlCommand("Listele_Kisi_Saglik_Bilgisi_Cikti", baglantim.baglanti());
                    sorgu2.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae2 = new SqlDataAdapter(sorgu2);
                    sorgu2.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae2.Fill(t2);
                    //}

                    SqlCommand sorgu3 = new SqlCommand("Listeler_Ilestisim_Bilgisi_cikti", baglantim.baglanti());
                    sorgu3.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae3 = new SqlDataAdapter(sorgu3);

                    sorgu3.Parameters.AddWithValue("@tc_bilgisi", mtxt_tc_no.Text);
                    dae3.Fill(t3);

                    SqlCommand sorgu4 = new SqlCommand("Listele_Bilgisayar_Bilgisi_Cikti", baglantim.baglanti());
                    sorgu4.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae4 = new SqlDataAdapter(sorgu4);
                    sorgu4.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae4.Fill(t4);

                    SqlCommand sorgu5 = new SqlCommand("Listele_Yabanci_Dil_Cikti", baglantim.baglanti());
                    sorgu5.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae5 = new SqlDataAdapter(sorgu5);
                    sorgu5.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae5.Fill(t5);


                    SqlCommand sorgu6 = new SqlCommand("Kisi_Sertifika_Bilgileri_Cikti", baglantim.baglanti());
                    sorgu6.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae6 = new SqlDataAdapter(sorgu6);
                    sorgu6.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae6.Fill(t6);



                    SqlCommand sorgu7 = new SqlCommand("Kisi_Sertifika_Agir_is_Cikti", baglantim.baglanti());
                    sorgu7.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae7 = new SqlDataAdapter(sorgu7);
                    sorgu7.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae7.Fill(t7);


                    SqlCommand sorgu8 = new SqlCommand("Listele_Ozgecmis_isyeri_Cikti", baglantim.baglanti());
                    sorgu8.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae8 = new SqlDataAdapter(sorgu8);
                    sorgu8.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae8.Fill(t8);


                    SqlCommand sorgu9 = new SqlCommand("Listele_kkd_Cikti", baglantim.baglanti());
                    sorgu9.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae9 = new SqlDataAdapter(sorgu9);
                    sorgu9.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                    dae9.Fill(t9);


                    SqlCommand sorgu10 = new SqlCommand("Listele_Borc_Bilgisi_Cikti", baglantim.baglanti());
                    sorgu10.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae10 = new SqlDataAdapter(sorgu10);
                    sorgu10.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae10.Fill(t10);


                    SqlCommand sorgu11 = new SqlCommand("Listele_Maddi_Durum_Listele", baglantim.baglanti());
                    sorgu11.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae11 = new SqlDataAdapter(sorgu11);
                    sorgu11.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae11.Fill(t11);


                    SqlCommand sorgu12 = new SqlCommand("Listele_Bakim_Bilgileri_Cikti", baglantim.baglanti());
                    sorgu12.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae12 = new SqlDataAdapter(sorgu12);
                    sorgu12.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae12.Fill(t12);


                    SqlCommand sorgu13 = new SqlCommand("Listele_Yakin_Bilgileri_Cikti", baglantim.baglanti());
                    sorgu13.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae13 = new SqlDataAdapter(sorgu13);
                    sorgu13.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae13.Fill(t13);

                    SqlCommand sorgu14 = new SqlCommand("Listele_Yakin_Saglik_Bilgileri_Cikti", baglantim.baglanti());
                    sorgu14.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae14 = new SqlDataAdapter(sorgu14);
                    sorgu14.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae14.Fill(t14);


                    SqlCommand sorgu15 = new SqlCommand("Listele_Yakin_Egitim_Bilgileri_Cikti", baglantim.baglanti());
                    sorgu15.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae15 = new SqlDataAdapter(sorgu15);
                    sorgu15.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae15.Fill(t15);

                    SqlCommand sorgu16 = new SqlCommand("Listele_Yakin_Calisma_Bilgileri_Cikti", baglantim.baglanti());
                    sorgu16.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae16 = new SqlDataAdapter(sorgu16);
                    sorgu16.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae16.Fill(t16);


                    SqlCommand sorgu17 = new SqlCommand("Listele_Yakin_gyk_Bilgileri_Cikti", baglantim.baglanti());
                    sorgu17.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dae17 = new SqlDataAdapter(sorgu11);
                    sorgu17.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    dae17.Fill(t17);

                    PdfPTable table1 = new PdfPTable(t1.Columns.Count);

                    PdfPTable table2 = new PdfPTable(t2.Columns.Count);

                    PdfPTable table3 = new PdfPTable(t3.Columns.Count);

                    PdfPTable table4 = new PdfPTable(t4.Columns.Count);

                    PdfPTable table5 = new PdfPTable(t5.Columns.Count);

                    PdfPTable table6 = new PdfPTable(t6.Columns.Count);

                    PdfPTable table7 = new PdfPTable(t7.Columns.Count);

                    PdfPTable table8 = new PdfPTable(t8.Columns.Count);

                    PdfPTable table9 = new PdfPTable(t9.Columns.Count);

                    PdfPTable table10 = new PdfPTable(t10.Columns.Count);

                    PdfPTable table11 = new PdfPTable(t11.Columns.Count);

                    PdfPTable table12 = new PdfPTable(t12.Columns.Count);

                    PdfPTable table13 = new PdfPTable(t13.Columns.Count);

                    PdfPTable table14 = new PdfPTable(t14.Columns.Count);

                    PdfPTable table15 = new PdfPTable(t15.Columns.Count);

                    PdfPTable table16 = new PdfPTable(t16.Columns.Count);

                    PdfPTable table17 = new PdfPTable(t17.Columns.Count);


                    //BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                    BaseFont btnColumnHeader = BaseFont.CreateFont(@"C:\Windows\Fonts\Calibri.ttf", "Identity-H", BaseFont.EMBEDDED);
                    //iTextSharp.text.Font fntColumnHeader = new Font(btnColumnHeader, 6, 0, Color.BLACK);
                    iTextSharp.text.Font fntColumnHeader = new iTextSharp.text.Font(btnColumnHeader, 6, 1, iTextSharp.text.BaseColor.BLACK);
                    if (t1.Rows.Count > 0)
                    {
                        //t1 için
                        for (int i = 0; i < t1.Columns.Count; i++)
                        {
                            PdfPCell cell_1 = new PdfPCell();
                            cell_1.AddElement(new Chunk(t1.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table1.AddCell(cell_1);
                        }

                        for (int i = 0; i < t1.Rows.Count; i++)
                        {
                            for (int j = 0; j < t1.Columns.Count; j++)
                            {
                                PdfPCell cell_1_1 = new PdfPCell();
                                cell_1_1.AddElement(new Chunk(t1.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table1.AddCell(cell_1_1);
                            }
                        }

                    }
                    if (t2.Rows.Count > 0)
                    {
                        //t2için
                        for (int i = 0; i < t2.Columns.Count; i++)
                        {
                            PdfPCell cell_2 = new PdfPCell();
                            cell_2.AddElement(new Chunk(t2.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table2.AddCell(cell_2);
                        }

                        for (int i = 0; i < t2.Rows.Count; i++)
                        {
                            for (int j = 0; j < t2.Columns.Count; j++)
                            {
                                PdfPCell cell_2_1 = new PdfPCell();
                                cell_2_1.AddElement(new Chunk(t2.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table2.AddCell(cell_2_1);
                            }
                        }
                    }
                    //t3için
                    if (t3.Rows.Count > 0)
                    {
                        for (int i = 0; i < t3.Columns.Count; i++)
                        {
                            PdfPCell cell_3 = new PdfPCell();
                            cell_3.AddElement(new Chunk(t3.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table3.AddCell(cell_3);
                        }

                        for (int i = 0; i < t3.Rows.Count; i++)
                        {
                            for (int j = 0; j < t3.Columns.Count; j++)
                            {
                                PdfPCell cell_3_1 = new PdfPCell();
                                cell_3_1.AddElement(new Chunk(t3.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table3.AddCell(cell_3_1);
                            }
                        }

                    }
                    if (t4.Rows.Count > 0)
                    {
                        //t4için
                        for (int i = 0; i < t4.Columns.Count; i++)
                        {
                            PdfPCell cell_4 = new PdfPCell();
                            cell_4.AddElement(new Chunk(t4.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table4.AddCell(cell_4);
                        }

                        for (int i = 0; i < t4.Rows.Count; i++)
                        {
                            for (int j = 0; j < t4.Columns.Count; j++)
                            {
                                PdfPCell cell_4_1 = new PdfPCell();
                                cell_4_1.AddElement(new Chunk(t4.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table4.AddCell(cell_4_1);
                            }
                        }
                    }
                    //t5için
                    if (t5.Rows.Count > 0)
                    {
                        for (int i = 0; i < t5.Columns.Count; i++)
                        {
                            PdfPCell cell_5 = new PdfPCell();
                            cell_5.AddElement(new Chunk(t5.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table5.AddCell(cell_5);
                        }

                        for (int i = 0; i < t5.Rows.Count; i++)
                        {
                            for (int j = 0; j < t5.Columns.Count; j++)
                            {
                                PdfPCell cell_5_1 = new PdfPCell();
                                cell_5_1.AddElement(new Chunk(t5.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table5.AddCell(cell_5_1);
                            }
                        }
                    }
                    if (t6.Rows.Count > 0)
                    {
                        //t6için
                        for (int i = 0; i < t6.Columns.Count; i++)
                        {
                            PdfPCell cell_6 = new PdfPCell();
                            cell_6.AddElement(new Chunk(t6.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table6.AddCell(cell_6);
                        }

                        for (int i = 0; i < t6.Rows.Count; i++)
                        {
                            for (int j = 0; j < t6.Columns.Count; j++)
                            {
                                PdfPCell cell_6_1 = new PdfPCell();
                                cell_6_1.AddElement(new Chunk(t6.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table6.AddCell(cell_6_1);
                            }
                        }
                    }
                    if (t7.Rows.Count > 0)
                    {

                        //t7için
                        for (int i = 0; i < t7.Columns.Count; i++)
                        {
                            PdfPCell cell_7 = new PdfPCell();
                            cell_7.AddElement(new Chunk(t7.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table7.AddCell(cell_7);
                        }

                        for (int i = 0; i < t7.Rows.Count; i++)
                        {
                            for (int j = 0; j < t7.Columns.Count; j++)
                            {
                                PdfPCell cell_7_1 = new PdfPCell();
                                cell_7_1.AddElement(new Chunk(t7.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table7.AddCell(cell_7_1);
                            }
                        }
                    }
                    if (t8.Rows.Count > 0)
                    {
                        //t8için
                        for (int i = 0; i < t8.Columns.Count; i++)
                        {
                            PdfPCell cell_8 = new PdfPCell();
                            cell_8.AddElement(new Chunk(t8.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table8.AddCell(cell_8);
                        }

                        for (int i = 0; i < t8.Rows.Count; i++)
                        {
                            for (int j = 0; j < t8.Columns.Count; j++)
                            {
                                PdfPCell cell_8_1 = new PdfPCell();
                                cell_8_1.AddElement(new Chunk(t8.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table8.AddCell(cell_8_1);
                            }
                        }
                    }
                    if (t9.Rows.Count > 0)
                    {
                        //t9 için
                        for (int i = 0; i < t9.Columns.Count; i++)
                        {
                            PdfPCell cell_9 = new PdfPCell();
                            cell_9.AddElement(new Chunk(t9.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table9.AddCell(cell_9);
                        }

                        for (int i = 0; i < t9.Rows.Count; i++)
                        {
                            for (int j = 0; j < t9.Columns.Count; j++)
                            {
                                PdfPCell cell_9_1 = new PdfPCell();
                                cell_9_1.AddElement(new Chunk(t9.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table9.AddCell(cell_9_1);
                            }
                        }
                    }
                    if (t10.Rows.Count > 0)
                    {

                        //t10için
                        for (int i = 0; i < t10.Columns.Count; i++)
                        {
                            PdfPCell cell_10 = new PdfPCell();
                            cell_10.AddElement(new Chunk(t10.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table10.AddCell(cell_10);
                        }

                        for (int i = 0; i < t10.Rows.Count; i++)
                        {
                            for (int j = 0; j < t10.Columns.Count; j++)
                            {
                                PdfPCell cell_10_1 = new PdfPCell();
                                cell_10_1.AddElement(new Chunk(t10.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table10.AddCell(cell_10_1);
                            }
                        }
                    }
                    if (t11.Rows.Count > 0)
                    {
                        //t11için
                        for (int i = 0; i < t11.Columns.Count; i++)
                        {
                            PdfPCell cell_11 = new PdfPCell();
                            cell_11.AddElement(new Chunk(t11.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table11.AddCell(cell_11);
                        }

                        for (int i = 0; i < t11.Rows.Count; i++)
                        {
                            for (int j = 0; j < t11.Columns.Count; j++)
                            {
                                PdfPCell cell_11_1 = new PdfPCell();
                                cell_11_1.AddElement(new Chunk(t11.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table11.AddCell(cell_11_1);
                            }
                        }
                    }
                    if (t12.Rows.Count > 0)
                    {
                        //t12için
                        for (int i = 0; i < t12.Columns.Count; i++)
                        {
                            PdfPCell cell_12 = new PdfPCell();
                            cell_12.AddElement(new Chunk(t12.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table12.AddCell(cell_12);
                        }

                        for (int i = 0; i < t12.Rows.Count; i++)
                        {
                            for (int j = 0; j < t12.Columns.Count; j++)
                            {
                                PdfPCell cell_12_1 = new PdfPCell();
                                cell_12_1.AddElement(new Chunk(t12.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table12.AddCell(cell_12_1);
                            }
                        }
                    }
                    if (t13.Rows.Count > 0)
                    {
                        //t13için
                        for (int i = 0; i < t13.Columns.Count; i++)
                        {
                            PdfPCell cell_13 = new PdfPCell();
                            cell_13.AddElement(new Chunk(t13.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table13.AddCell(cell_13);
                        }

                        for (int i = 0; i < t13.Rows.Count; i++)
                        {
                            for (int j = 0; j < t13.Columns.Count; j++)
                            {
                                PdfPCell cell_13_1 = new PdfPCell();
                                cell_13_1.AddElement(new Chunk(t13.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table13.AddCell(cell_13_1);
                            }
                        }
                    }
                    if (t14.Rows.Count > 0)
                    {
                        //t14için
                        for (int i = 0; i < t14.Columns.Count; i++)
                        {
                            PdfPCell cell_14 = new PdfPCell();
                            cell_14.AddElement(new Chunk(t14.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table14.AddCell(cell_14);
                        }

                        for (int i = 0; i < t14.Rows.Count; i++)
                        {
                            for (int j = 0; j < t14.Columns.Count; j++)
                            {
                                PdfPCell cell_14_1 = new PdfPCell();
                                cell_14_1.AddElement(new Chunk(t14.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table14.AddCell(cell_14_1);
                            }
                        }
                    }
                    if (t15.Rows.Count > 0)
                    {
                        //t15için
                        for (int i = 0; i < t15.Columns.Count; i++)
                        {
                            PdfPCell cell_15 = new PdfPCell();
                            cell_15.AddElement(new Chunk(t15.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table15.AddCell(cell_15);
                        }

                        for (int i = 0; i < t15.Rows.Count; i++)
                        {
                            for (int j = 0; j < t15.Columns.Count; j++)
                            {
                                PdfPCell cell_15_1 = new PdfPCell();
                                cell_15_1.AddElement(new Chunk(t15.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table15.AddCell(cell_15_1);
                            }
                        }
                    }
                    if (t16.Rows.Count > 0)
                    {
                        //t16için
                        for (int i = 0; i < t16.Columns.Count; i++)
                        {
                            PdfPCell cell_16 = new PdfPCell();
                            cell_16.AddElement(new Chunk(t16.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table16.AddCell(cell_16);
                        }

                        for (int i = 0; i < t16.Rows.Count; i++)
                        {
                            for (int j = 0; j < t16.Columns.Count; j++)
                            {
                                PdfPCell cell_16_1 = new PdfPCell();
                                cell_16_1.AddElement(new Chunk(t16.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table16.AddCell(cell_16_1);
                            }
                        }
                    }
                    if (t17.Rows.Count > 0)
                    {
                        //t17için
                        for (int i = 0; i < t17.Columns.Count; i++)
                        {
                            PdfPCell cell_17 = new PdfPCell();
                            cell_17.AddElement(new Chunk(t17.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                            table17.AddCell(cell_17);
                        }

                        for (int i = 0; i < t17.Rows.Count; i++)
                        {
                            for (int j = 0; j < t17.Columns.Count; j++)
                            {
                                PdfPCell cell_17_1 = new PdfPCell();
                                cell_17_1.AddElement(new Chunk(t17.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                                table17.AddCell(cell_17_1);
                            }
                        }
                    }
                    /*
                    //t18için
                    for (int i = 0; i < t18.Columns.Count; i++)
                    {
                        PdfPCell cell_18 = new PdfPCell();
                        cell_18.AddElement(new Chunk(t18.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                        table18.AddCell(cell_18);
                    }

                    for (int i = 0; i < t18.Rows.Count; i++)
                    {
                        for (int j = 0; j < t18.Columns.Count; j++)
                        {
                            PdfPCell cell_18_1 = new PdfPCell();
                            cell_18_1.AddElement(new Chunk(t18.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                            table18.AddCell(cell_18_1);
                        }
                    }
                    */



                    iTextSharp.text.pdf.BaseFont STF_Helvetica_Turkish = iTextSharp.text.pdf.BaseFont.CreateFont("Helvetica", "CP1254", iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, iTextSharp.text.Font.NORMAL);
                    Paragraph bosluk = new Paragraph();
                    //BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    BaseFont btnAuthor = BaseFont.CreateFont(@"C:\Windows\Fonts\Calibri.ttf", "Identity-H", BaseFont.EMBEDDED);
                    iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(STF_Helvetica_Turkish, 12, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    bosluk.Add(new Chunk(" \n                                                              " + "PERSONEL BİLGİ FORMU", fntAuthor));
                    bosluk.Add(new Chunk("\n", fntAuthor));

                    Paragraph prgAuthor1 = new Paragraph();
                    prgAuthor1.Add(new Chunk("Başlık 1 : " + label1.Text, fntAuthor));



                    Paragraph prgAuthor2 = new Paragraph();
                    prgAuthor2.Add(new Chunk("Başlık 2 : " + label6.Text, fntAuthor));



                    Paragraph prgAuthor3 = new Paragraph();
                    prgAuthor3.Add(new Chunk("Başlık 3 : " + label2.Text + "\n", fntAuthor));////iletişim bilgileri

                    Paragraph prgAuthor4 = new Paragraph();
                    prgAuthor4.Add(new Chunk("Başlık 4 : " + label10.Text + "\n", fntAuthor));//firma imkanları bilgisi

                    Paragraph prgAuthor5 = new Paragraph();
                    prgAuthor5.Add(new Chunk("Başlık 5 : " + label4.Text + "\n", fntAuthor));//eğitim bilgisi

                    //iTextSharp.text.pdf.BaseFont STF_Helvetica_Turkish = iTextSharp.text.pdf.BaseFont.CreateFont("Helvetica", "CP1254", iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);
                    //iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, iTextSharp.text.Font.NORMAL);
                    Paragraph egitim = new Paragraph();
                    BaseFont btnegitim = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntegitim = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    egitim.Add(new Chunk(" \n                                                              " + "Personele ait eğitim bilgilerini giriniz.", fntegitim));
                    egitim.Add(new Chunk("\n", fntegitim));

                    Paragraph prgAuthor6 = new Paragraph();
                    prgAuthor6.Add(new Chunk("Başlık 6 : " + label6.Text + "\n", fntAuthor));//sağlık bilgisi

                    Paragraph saglik = new Paragraph();
                    BaseFont btnsaglik = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntsaglik = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    saglik.Add(new Chunk(" \n                                                              " + "Personele ait saglik bilgilerini giriniz.", fntsaglik));
                    saglik.Add(new Chunk("\n", fntsaglik));

                    Paragraph prgAuthor7 = new Paragraph();
                    prgAuthor7.Add(new Chunk("Başlık 7 : " + label2.Text + "\n", fntAuthor));//iletişim bilgisi

                    Paragraph iletisim = new Paragraph();
                    BaseFont btniletisim = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntiletisim = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    iletisim.Add(new Chunk(" \n                                                              " + "Personele ait iletişim bilgilerini giriniz.", fntiletisim));
                    iletisim.Add(new Chunk("\n", fntiletisim));



                    Paragraph prgAuthor8 = new Paragraph();
                    prgAuthor8.Add(new Chunk("Başlık 6 : " + "Bilgisayar Bilgisi" + "\n", fntAuthor));

                    Paragraph bilgisayar = new Paragraph();
                    BaseFont btnbilgisayar = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntbilgisayar = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    bilgisayar.Add(new Chunk(" \n                                                              " + "Personele ait bilgisayar program bilgisi giriniz.", fntbilgisayar));
                    bilgisayar.Add(new Chunk("\n", fntbilgisayar));

                    Paragraph prgAuthor9 = new Paragraph();
                    prgAuthor9.Add(new Chunk("Başlık 7 : " + "Yabancı Dil Bilgisi" + "\n", fntAuthor));

                    Paragraph dil = new Paragraph();
                    BaseFont btndil = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntdil = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    dil.Add(new Chunk(" \n                                                              " + "Personele ait yabancı dil bilgisi giriniz.", fntdil));
                    dil.Add(new Chunk("\n", fntdil));

                    Paragraph prgAuthor10 = new Paragraph();
                    prgAuthor10.Add(new Chunk("Başlık 8 : " + "Sertifika Bilgisi" + "\n", fntAuthor));

                    Paragraph sertifika = new Paragraph();
                    BaseFont btnsertifika = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntsertifika = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    sertifika.Add(new Chunk(" \n                                                              " + "Personele ait sertifika bilgisi giriniz.", fntsertifika));
                    sertifika.Add(new Chunk("\n", fntsertifika));

                    Paragraph prgAuthor11 = new Paragraph();
                    prgAuthor11.Add(new Chunk("Başlık 9 : " + "Ağır İş Sertifikası" + "\n", fntAuthor));

                    Paragraph sertifikaa = new Paragraph();
                    BaseFont btnsertifikaa = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntsertifikaa = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    sertifikaa.Add(new Chunk(" \n                                                              " + "Personele ait varsa ağır iş sertifika bilgisi giriniz.", fntsertifikaa));
                    sertifikaa.Add(new Chunk("\n", fntsertifikaa));

                    Paragraph prgAuthor12 = new Paragraph();
                    prgAuthor12.Add(new Chunk("Başlık 11 : " + label7.Text + "\n", fntAuthor));

                    Paragraph cv = new Paragraph();
                    BaseFont btncv = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntcv = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    cv.Add(new Chunk(" \n                                                              " + "Personele ait varsa öz geçmiş bilgisi giriniz.", fntcv));
                    cv.Add(new Chunk("\n", fntcv));

                    Paragraph prgAuthor13 = new Paragraph();
                    prgAuthor13.Add(new Chunk("Başlık 12 : " + label9.Text + "\n", fntAuthor));

                    Paragraph kkd = new Paragraph();
                    BaseFont btnkkd = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntkkd = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    kkd.Add(new Chunk(" \n                                                              " + "Personele ait varsa iş sağlığı ve güvenliği malzeme bilgisi giriniz.", fntkkd));
                    kkd.Add(new Chunk("\n", fntkkd));

                    Paragraph prgAuthor14 = new Paragraph();
                    prgAuthor14.Add(new Chunk("Başlık 13 : " + label72.Text + "\n", fntAuthor));

                    Paragraph borc = new Paragraph();
                    BaseFont btnborc = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntborc = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    borc.Add(new Chunk(" \n                                                              " + "Personele ait herhangibir borç bilgisi yoktur.", fntborc));
                    borc.Add(new Chunk("\n", fntborc));


                    Paragraph prgAuthor15 = new Paragraph();
                    prgAuthor15.Add(new Chunk("Başlık 14 : " + label8.Text + "\n", fntAuthor));

                    Paragraph maddi = new Paragraph();
                    BaseFont btnmaddi = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntmaddi = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    maddi.Add(new Chunk(" \n                                                              " + "Personele ait maddi durum bilgisi giriniz.", fntmaddi));
                    maddi.Add(new Chunk("\n", fntmaddi));

                    Paragraph prgAuthor16 = new Paragraph();
                    prgAuthor16.Add(new Chunk("Başlık 15 : " + label55.Text + "\n", fntAuthor));


                    Paragraph bakim = new Paragraph();
                    BaseFont btnbakim = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntbakim = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    bakim.Add(new Chunk(" \n                                                              " + "Personelin bakımı ile ilgilendiği herhangi bir birey yoktur.", fntbakim));
                    bakim.Add(new Chunk("\n", fntbakim));

                    Paragraph prgAuthor17 = new Paragraph();
                    prgAuthor17.Add(new Chunk("Başlık 16 : " + "Çekirdek Aileye Ait Temel Bilgiler" + "\n", fntAuthor));

                    Paragraph yakın1 = new Paragraph();
                    BaseFont btnyakın1 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntyakın1 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    yakın1.Add(new Chunk(" \n                                                              " + "Personelin çekirdek ailesine ait personel bilgisi yoktur.", fntyakın1));
                    yakın1.Add(new Chunk("\n", fntyakın1));

                    Paragraph prgAuthor18 = new Paragraph();
                    prgAuthor18.Add(new Chunk("Başlık 17 : " + "Çekirdek Aileye Ait Sağlık Bilgileri" + "\n", fntAuthor));

                    Paragraph yakın2 = new Paragraph();
                    BaseFont btnyakın2 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntyakın2 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    yakın2.Add(new Chunk(" \n                                                              " + "Personelin çekirdek ailesine ait personel bilgisi yoktur.", fntyakın2));
                    yakın2.Add(new Chunk("\n", fntyakın2));

                    Paragraph prgAuthor19 = new Paragraph();
                    prgAuthor19.Add(new Chunk("Başlık 18 : " + "Çekirdek Aileye Ait Eğitim Bilgileri" + "\n", fntAuthor));

                    Paragraph yakın3 = new Paragraph();
                    BaseFont btnyakın3 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntyakın3 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    yakın3.Add(new Chunk(" \n                                                              " + "Personelin çekirdek ailesine ait personel bilgisi yoktur.", fntyakın3));
                    yakın3.Add(new Chunk("\n", fntyakın3));

                    Paragraph prgAuthor20 = new Paragraph();
                    prgAuthor20.Add(new Chunk("Başlık 19 : " + "Çekirdek Aileye Ait Çalışan Bilgisi" + "\n", fntAuthor));

                    Paragraph yakın4 = new Paragraph();
                    BaseFont btnyakın4 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntyakın4 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    yakın4.Add(new Chunk(" \n                                                              " + "Personelin çekirdek ailesine ait personel bilgisi yoktur.", fntyakın4));
                    yakın4.Add(new Chunk("\n", fntyakın4));

                    Paragraph prgAuthor21 = new Paragraph();
                    prgAuthor21.Add(new Chunk("Başlık 20 : " + "Çekirdek Aileye Ait Genel Kültür Bilgisi" + "\n", fntAuthor));

                    Paragraph yakın5 = new Paragraph();
                    BaseFont btnyakın5 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntyakın5 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    yakın5.Add(new Chunk(" \n                                                              " + "Personelin çekirdek ailesine ait personel bilgisi yoktur.", fntyakın5));
                    yakın5.Add(new Chunk("\n", fntyakın5));

                    Paragraph prgAuthor22 = new Paragraph();
                    prgAuthor22.Add(new Chunk("Başlık 10 : " + "Personelin hobileri" + "\n", fntAuthor));

                    Paragraph hobi = new Paragraph();
                    BaseFont btnhobi = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fnthobi = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    hobi.Add(new Chunk(" \n                                                              " + "Personelin kayıtlı bir hobisi yoktur.", fnthobi));
                    hobi.Add(new Chunk("\n", fnthobi));


                    Paragraph cocuk = new Paragraph();
                    BaseFont btncocuk = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntcocuk = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    cocuk.Add(new Chunk(" \n                Çocuk Sayısı=" + lbl_cocuk.Text, fntcocuk));
                    cocuk.Add(new Chunk("\n", fntcocuk));

                    Paragraph cocukyok = new Paragraph();
                    BaseFont btncocukyok = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntcocukyok = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    cocukyok.Add(new Chunk(" \n                  " + "Personelin kayıtlı cocuk bilgisi yoktur.", fntcocukyok));
                    cocukyok.Add(new Chunk("\n", fntcocukyok));


                    Paragraph hobii = new Paragraph();
                    BaseFont btnhobii = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fnthobii = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    hobii.Add(new Chunk(" \n                Hobileri=" + lbl_hobileri.Text, fnthobii));
                    hobii.Add(new Chunk("\n", fnthobii));

                    //////////////////////////////////////////////////////////////////////////////////////////////////////////
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                    /////////////////////////////////////////////////////////////////////////////////////////////////

                    Paragraph aylikGider = new Paragraph();
                    BaseFont btnaylikGider = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntaylikGider = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    aylikGider.Add(new Chunk(label56.Text + " : " + lbl_gider.Text, fntaylikGider));
                    //   aylikGider.Add(new Chunk("\n", fntaylikGider));

                    Paragraph sure = new Paragraph();
                    BaseFont btnsure = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntsure = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    sure.Add(new Chunk(label57.Text + " : " + lbl_sure.Text, fntsure));
                    //   sure.Add(new Chunk("\n", fntsure));

                    Paragraph vasita = new Paragraph();
                    BaseFont btnvasita = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntvasita = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    vasita.Add(new Chunk(label58.Text, fntvasita));
                    //   vasita.Add(new Chunk("\n", fntvasita));


                    Paragraph vasita1 = new Paragraph();
                    BaseFont btnvasita1 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntvasita1 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    vasita1.Add(new Chunk(label60.Text + " : " + lbl_v1.Text, fntvasita1));
                    //     vasita1.Add(new Chunk("\n", fntvasita1));

                    Paragraph vasita2 = new Paragraph();
                    BaseFont btnvasita2 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntvasita2 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    vasita2.Add(new Chunk(label61.Text + " : " + lbl_v2.Text, fntvasita2));
                    /// vasita2.Add(new Chunk("\n", fntvasita2));


                    Paragraph vasita3 = new Paragraph();
                    BaseFont btnvasita3 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntvasita3 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    vasita3.Add(new Chunk(label62.Text + " : " + lbl_3.Text, fntvasita3));
                    //vasita3.Add(new Chunk("\n", fntvasita3));

                    Paragraph vasita4 = new Paragraph();
                    BaseFont btnvasita4 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntvasita4 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    vasita4.Add(new Chunk(label63.Text + " : " + lbl_4.Text, fntvasita4));
                    //   vasita4.Add(new Chunk("\n", fntvasita4));

                    Paragraph vasita5 = new Paragraph();
                    BaseFont btnvasita5 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntvasita5 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    vasita5.Add(new Chunk(label64.Text + " : " + lbl_5.Text, fntvasita5));
                    //   vasita5.Add(new Chunk("\n", fntvasita5));

                    Paragraph vasita6 = new Paragraph();
                    BaseFont btnvasita6 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntvasita6 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    vasita6.Add(new Chunk(label65.Text + " : " + lbl_v6.Text, fntvasita6));
                    //     vasita6.Add(new Chunk("\n", fntvasita6));

                    Paragraph alarji = new Paragraph();
                    BaseFont btnalarji = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntalarji = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    alarji.Add(new Chunk(label68.Text + " : " + txt_alerji.Text, fntalarji));
                    //    alarji.Add(new Chunk("\n", fntalarji));




                    Paragraph yemek1 = new Paragraph();
                    BaseFont btnyemek1 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntyemek1 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    yemek1.Add(new Chunk(label69.Text + " " + lbl_yemek.Text, fntyemek1));
                    // yemek1.Add(new Chunk("\n", fntyemek1));


                    Paragraph yemek2 = new Paragraph();
                    BaseFont btnyemek2 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntyemek2 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    yemek2.Add(new Chunk(label71.Text + " : " + txt_neden.Text, fntyemek2));
                    //    yemek2.Add(new Chunk("\n", fntyemek2));


                    Paragraph talep = new Paragraph();
                    BaseFont btntalep = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fnttalep = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    talep.Add(new Chunk(label70.Text + " : " + txt_talep.Text, fnttalep));
                    //  talep.Add(new Chunk("\n", fnttalep));

                    //////////////////////////////////////////////////////////////////////////
                    ///////////////
                    ///
                    //////////////////////////////////////////////////////////////////////////

                    Paragraph tcbilgisi = new Paragraph();
                    BaseFont btntcbilgisi = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fnttcbilgisi = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    tcbilgisi.Add(new Chunk(label73.Text + " : " + lbl_tc.Text, fnttcbilgisi));

                    Paragraph adsoyad = new Paragraph();
                    BaseFont btnadsoyad = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntadsoyad = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    adsoyad.Add(new Chunk(label21.Text + " " + label22.Text + " : " + lbl_ad.Text + " " + lbl_soyad.Text, fntadsoyad));

                    Paragraph uyruk = new Paragraph();
                    BaseFont btnuyruk = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntuyruk = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    uyruk.Add(new Chunk(label23.Text + " : " + lbl_uyruk.Text, fntuyruk));

                    Paragraph cinsiyet = new Paragraph();
                    BaseFont btncinsiyet = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntcinsiyet = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    cinsiyet.Add(new Chunk(label24.Text + " : " + lbl_cinsiyet.Text, fntcinsiyet));

                    Paragraph medeni = new Paragraph();
                    BaseFont btnmedeni = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntmedeni = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    medeni.Add(new Chunk(label17.Text + " : " + lbl_medeni_hal.Text, fntmedeni));

                    Paragraph dogum = new Paragraph();
                    BaseFont btndogum = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntdogum = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    dogum.Add(new Chunk("DOĞUM YERİ/TARİHİ" + " : " + lbl_dogum_yeri.Text + " / " + lbl_dogum_tarihi.Text, fntdogum));

                    Paragraph baba = new Paragraph();
                    BaseFont btnbaba = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntbaba = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    baba.Add(new Chunk(label13.Text + " : " + lbl_baba_adi.Text, fntbaba));


                    Paragraph anne = new Paragraph();
                    BaseFont btnanne = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntanne = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    anne.Add(new Chunk(label20.Text + " : " + lbl_ana_adi.Text, fntanne));


                    Paragraph kod = new Paragraph();
                    BaseFont btnkod = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntkod = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    kod.Add(new Chunk(label14.Text + " : " + lbl_meslek_kodu.Text, fntkod));



                    Paragraph gorev = new Paragraph();
                    BaseFont btngorev = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntgorev = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    gorev.Add(new Chunk("GÖREV / YERİ" + " : " + lbl_görevi.Text + " / " + lbl_gorev_yeri.Text, fntgorev));

                    Paragraph durum = new Paragraph();
                    BaseFont btndurum = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntdurum = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    durum.Add(new Chunk("ÇALIŞMA SÜRESİ" + " : " + lbl_ise_giris.Text + " / " + lbl_isten_cikis.Text, fntdurum));

                    Paragraph dipnot = new Paragraph();
                    BaseFont btndipnot = BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntdipnot = new iTextSharp.text.Font(STF_Helvetica_Turkish, 6, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    dipnot.Add(new Chunk("~~Optimak İnsan Kaynakları Form Sonu" + "      /     " + DateTime.Now.ToString(), fntdipnot));


                    //MemoryStream ms = new MemoryStream();
                    //picb_resim.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //byte[] resim = ms.GetBuffer();



                    iTextSharp.text.Image resim = iTextSharp.text.Image.GetInstance(picb_resim.Image, System.Drawing.Imaging.ImageFormat.Jpeg);

                    resim.ScaleAbsolute(90, 90);//pdf deki resmi boyutlandırma.

                    ////////////////////////////////////////////////////////////////////
                    ///
                    ////////////////////////////////////////////////////////////////////


                    Paragraph ara = new Paragraph();
                    ara.Add(new Chunk("\n", fntAuthor));
                    {     /*



                    Paragraph prgAuthor = new Paragraph();
                    //BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    // iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(STF_Helvetica_Turkish, 12, 1, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    prgAuthor.Add(new Chunk("                                                               Başlık 1 : " + label1.Text, fntAuthor));
                    prgAuthor.Add(new Chunk("\n\n", fntAuthor));






                    //deneme
                    {
                        //prgAuthor.Add(new Chunk("\n\n\nTemel Kimlik Bilgileri\n", fntAuthor));
                        prgAuthor.Add(new Chunk(
                            textBox3.Text + textBox3.Text + lbl_tc_no.Text + " : " + mtxt_tc_no.Text + "\n" +
                            textBox3.Text + textBox3.Text + lbl_pdks.Text + " : " + txt_pdks.Text + "\n" +
                            textBox3.Text + textBox3.Text + "ADI SOYADI" + " : " + lbl_ad.Text + " " + lbl_soyad.Text + "\n" +
                            textBox3.Text + textBox3.Text + label23.Text + " : " + lbl_uyruk.Text + "\n" +
                            textBox3.Text + textBox3.Text + label24.Text + " : " + lbl_cinsiyet.Text + "\n" +
                            textBox3.Text + textBox3.Text + label17.Text + " : " + lbl_medeni_hal.Text + "\n" +
                            textBox3.Text + textBox3.Text + label18.Text + " : " + lbl_dogum_tarihi.Text + "\n" +
                            textBox3.Text + textBox3.Text + label19.Text + " : " + lbl_dogum_yeri.Text + "\n" +
                            textBox3.Text + textBox3.Text + label20.Text + " : " + lbl_ana_adi.Text + "\n" +
                            textBox3.Text + textBox3.Text + label13.Text + " : " + lbl_baba_adi.Text + "\n" +
                            textBox3.Text + textBox3.Text + label14.Text + " : " + lbl_meslek_kodu.Text + "\n" +
                            textBox3.Text + textBox3.Text + label15.Text + " : " + lbl_görevi.Text + "\n" +
                            textBox3.Text + textBox3.Text + label16.Text + " : " + lbl_gorev_yeri.Text + "\n" +
                            textBox3.Text + textBox3.Text + lbl_calisma_durumu.Text + " : " + lbl_durum.Text + "\n" +
                            textBox3.Text + textBox3.Text + label11.Text + " : " + lbl_ise_giris.Text + "\n" +
                            textBox3.Text + textBox3.Text + label12.Text + " : " + lbl_isten_cikis.Text + "\n" +
                            "\n\n"
                            , fntAuthor));

                        prgAuthor.Add(new Chunk("                                                               Başlık 2 : " + label10.Text, fntAuthor));
                        prgAuthor.Add(new Chunk("\n\n", fntAuthor));
                        prgAuthor.Add(new Chunk(
                             textBox3.Text + textBox3.Text + label56.Text + " : " + lbl_gider.Text + "\n" +
                             textBox3.Text + textBox3.Text + label57.Text + " : " + lbl_gider.Text + "\n" +
                             textBox3.Text + textBox3.Text + label58.Text + " ; " + "\n" +
                             textBox3.Text + textBox3.Text + label60.Text + " : " + lbl_v1.Text + "\n" +
                             textBox3.Text + textBox3.Text + label60.Text + " : " + lbl_v1.Text + textBox3.Text + textBox3.Text + textBox3.Text + textBox3.Text + label61.Text + " : " + lbl_v2.Text + "\n" +
                             textBox3.Text + textBox3.Text + label62.Text + " : " + lbl_3.Text + textBox3.Text + textBox3.Text + textBox3.Text + textBox3.Text + label61.Text + " : " + lbl_v2.Text + "\n" +
                             textBox3.Text + textBox3.Text + label64.Text + " : " + lbl_5.Text + textBox3.Text + textBox3.Text + textBox3.Text + textBox3.Text + label65.Text + " : " + lbl_v6.Text + "\n" +
                             textBox3.Text + textBox3.Text + label68.Text + " : " + txt_alerji.Text + "\n" +
                             textBox3.Text + textBox3.Text + label69.Text + " : " + lbl_yemek.Text + " ; " +
                             textBox3.Text + textBox3.Text + textBox3.Text + textBox3.Text + label71.Text + "  " + txt_neden.Text + "\n" +
                             textBox3.Text + textBox3.Text + label70.Text + " " + txt_talep.Text +
                                "\n\n"
                            , fntAuthor));



                        prgAuthor.Add(new Chunk("                                                               Başlık 3 : " + label3.Text, fntAuthor));
                        prgAuthor.Add(new Chunk("\n\n", fntAuthor));
                        prgAuthor.Add(new Chunk(
                             textBox3.Text + textBox3.Text + lbl_hobi.Text + " " + lbl_hobileri.Text +
                                "\n\n"
                            , fntAuthor));
                    }
                    e.Graphics.DrawString(label11.Text + " : " + lbl_ise_giris.Text, myFont1, sb1, 630, 100);

                    e.Graphics.DrawString(label23.Text + " : " + lbl_uyruk.Text, myFont1, sb1, 100, 125);
                    e.Graphics.DrawString(label19.Text + " : " + lbl_dogum_yeri.Text, myFont1, sb1, 255, 125);
                    e.Graphics.DrawString(label15.Text + " : " + lbl_görevi.Text, myFont1, sb1, 430, 125);
                    e.Graphics.DrawString(label12.Text + " : " + lbl_isten_cikis.Text, myFont1, sb1, 630, 125);
                    */
                    }
                    {
                        document.Add(resim);
                        document.Add(bosluk);

                        //document.Add(prgAuthor);
                        document.Add(prgAuthor1);//başlık 1

                        ///////////////////////////////////////////////////////
                        ///
                        /////////////////////////////////////////////////////////

                        // document.Add(png);

                        document.Add(tcbilgisi);
                        document.Add(adsoyad);
                        document.Add(uyruk);
                        document.Add(cinsiyet);
                        document.Add(medeni);
                        document.Add(dogum);
                        document.Add(baba);
                        document.Add(anne);
                        document.Add(kod);
                        document.Add(gorev);
                        document.Add(durum);



                        document.Add(ara);//araya boşluk tara


                        ///////////////////////////////////////////////////////
                        ///
                        /////////////////////////////////////////////////////////

                        document.Add(prgAuthor2);//başlık 2

                        //document.Add(png2);
                        document.Add(ara);//araya boşluk atar
                                          // document.Add(prgAuthor6);
                        if (t2.Rows.Count > 0)//sağlık kısmı için
                        {
                            document.Add(ara);
                            document.Add(table2);
                        }
                        else
                            document.Add(saglik);


                        document.Add(ara);//araya boşluk atar


                        document.Add(prgAuthor3);//başlık3

                        document.Add(ara);
                        //document.Add(prgAuthor7);
                        if (t3.Rows.Count > 0)//letişim tablosu
                        {
                            document.Add(ara);
                            document.Add(table3);
                        }
                        else
                            document.Add(iletisim);

                        document.Add(ara);

                        ///////////////////////////////////////////////////////
                        ///
                        /////////////////////////////////////////////////////////
                        document.Add(prgAuthor4);//başlık4
                                                 //document.Add(png4);//firma ikanları resmi


                        document.Add(ara);

                        if (lbl_gider.Text != "" && lbl_gider.Text != "...")
                        {
                            document.Add(aylikGider);
                        }
                        if (lbl_sure.Text != "" && lbl_sure.Text != "...")
                        {
                            document.Add(sure);
                        }
                        if (lbl_v1.Text != "" && lbl_v1.Text != "...")
                        {
                            document.Add(vasita);
                        }
                        if (lbl_v1.Text != "" && lbl_v1.Text != "...")
                        {
                            document.Add(vasita1);
                        }
                        if (lbl_v2.Text != "" && lbl_v2.Text != "...")
                        {
                            document.Add(vasita2);
                        }
                        if (lbl_3.Text != "" && lbl_3.Text != "...")
                        {
                            document.Add(vasita3);
                        }
                        if (lbl_4.Text != "" && lbl_4.Text != "...")
                        {
                            document.Add(vasita4);
                        }
                        if (lbl_5.Text != "" && lbl_5.Text != "...")
                        {
                            document.Add(vasita5);
                        }
                        if (lbl_v6.Text != "" && lbl_v6.Text != "...")
                        {
                            document.Add(vasita6);
                        }
                        if (txt_alerji.Text != "")
                        {
                            document.Add(alarji);
                        }
                        if (lbl_yemek.Text != "" && lbl_yemek.Text != "...")
                        {
                            document.Add(yemek1);
                        }
                        if (txt_neden.Text != "")
                        {
                            document.Add(yemek2);
                        }
                        if (txt_talep.Text != "")
                        {
                            document.Add(talep);
                        }

                        ///////////////////////////////////////////////////////
                        ///
                        /////////////////////////////////////////////////////////

                        document.Add(ara);//araya boşluk atar



                        document.Add(prgAuthor5);//başlık5

                        if (t1.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table1);//eğitim kısmı
                        }
                        else
                            document.Add(egitim);

                        document.Add(ara);




                        document.Add(prgAuthor8);//başlık6

                        if (t4.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table4);//bilgisayar becerisi
                        }
                        else
                            document.Add(bilgisayar);

                        document.Add(ara);


                        document.Add(prgAuthor9);//başlık7
                        if (t5.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table5);//yabancı dil
                        }
                        else
                            document.Add(dil);

                        document.Add(ara);



                        document.Add(prgAuthor10);//başlık8
                        if (t6.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table6);//sertifika 
                        }
                        else
                            document.Add(sertifika);
                        document.Add(ara);





                        document.Add(prgAuthor11);//başlık9
                        if (t7.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table7);//ağır iş sertifikası
                        }
                        else
                            document.Add(sertifikaa);

                        document.Add(ara);




                        document.Add(prgAuthor22);//başlık10
                                                  //document.Add(ara);

                        if (lbl_hobileri.Text == "...")
                            document.Add(hobi);
                        else
                            document.Add(hobii);

                        document.Add(ara);



                        document.Add(prgAuthor12);//başlık11
                        if (t8.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table8);//öz geçmiş
                        }
                        else
                            document.Add(cv);

                        document.Add(ara);

                        document.Add(prgAuthor13);//başlık12

                        if (t9.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table9);//isg-kkd
                        }
                        else
                            document.Add(kkd);

                        document.Add(ara);




                        document.Add(prgAuthor14);//başlık13
                        if (t10.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table10);//borç tablosu
                        }
                        else
                            document.Add(borc);
                        document.Add(ara);





                        document.Add(prgAuthor15);//başlık14
                        if (t11.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table11);//maddi durum tablosu
                        }
                        else
                            document.Add(maddi);
                        document.Add(ara);





                        document.Add(prgAuthor16);//başlık15
                        if (t12.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table12);//bakımı ile ilgili tablo
                        }
                        else
                            document.Add(bakim);
                        document.Add(ara);




                        document.Add(prgAuthor17);//başlık16

                        if (t13.Rows.Count > 0)
                        {
                            {
                                if (lbl_cocuk.Text == "0")
                                    document.Add(cocukyok);
                                else
                                    document.Add(cocuk);
                                document.Add(ara);
                            }
                            document.Add(table13);//aile temel bilgiler
                        }

                        else
                            document.Add(yakın1);

                        document.Add(ara);




                        document.Add(prgAuthor18);//başlık17
                        if (t14.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table14);
                        }
                        else
                            document.Add(yakın2);//aile sağlık bilgisi

                        document.Add(ara);



                        document.Add(prgAuthor19);//başlık18

                        if (t15.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table15);//aile eğitim bilgisi
                        }
                        else
                            document.Add(yakın3);
                        document.Add(ara);


                        document.Add(prgAuthor20);//başlık19
                        if (t16.Rows.Count > 0)
                        {
                            document.Add(ara);
                            document.Add(table16);//aile çalışma bilgisi
                        }
                        else
                            document.Add(yakın4);



                        document.Add(ara);
                        document.Add(prgAuthor21);//başlık20
                        if (t17.Rows.Count > 0)
                        {
                            document.Add(ara);

                            document.Add(table17);//aile genel kültür
                        }
                        else
                            document.Add(yakın5);
                        document.Add(ara);
                        document.Add(ara);
                        document.Add(ara);
                        document.Add(ara);
                        document.Add(ara);

                        document.Add(dipnot);

                        //document.Add(table18);

                        document.Close();
                        writer.Close();
                        fs.Close();
                    }

                    //   string strPdfPath = @"C://Dosyalar/" + mtxt_tc_no.Text + "/" + mtxt_tc_no.Text + "_" + "Tüm_Bilgiler.pdf";

                    System.Diagnostics.Process.Start(strPdfPath);

                    ////////////////////////Yeni Kod Sonu//////////////////////////
                    /*
                    //Bu kısımda sipariş formu yazısını ve çizgileri yazdırıyorum
                    e.Graphics.DrawLine(myPen, 100, 50, 750, 50);

                    e.Graphics.DrawString("PERSONEL BİLGİ FORMU", ustFont, sbbrush, (sayfa_genisligi / 2) + 70, 30);

                    e.Graphics.DrawLine(myPen, 100, 320, 750, 320);

                    ustFont = new System.Drawing.Font("Calibri", 12, FontStyle.Bold);

                    e.Graphics.DrawLine(myPen, 100, 348, 750, 348);

                    e.Graphics.DrawString("Temel Kimlik Bilgileri", cizgiFont, sbcizgi, 100, 55);

                    //e.Graphics.DrawString(".............................................", myFont, sb, 70, 170);
                    e.Graphics.DrawString(label21.Text + " : " + lbl_ad.Text, myFont1, sb1, 100, 75);
                    e.Graphics.DrawString(label17.Text + " : " + lbl_medeni_hal.Text, myFont1, sb1, 255, 75);
                    e.Graphics.DrawString(label13.Text + " : " + lbl_baba_adi.Text, myFont1, sb1, 430, 75);
                    e.Graphics.DrawString(lbl_calisma_durumu.Text + " : " + lbl_durum.Text, myFont1, sb1, 630, 75);

                    e.Graphics.DrawString(label22.Text + " : " + lbl_soyad.Text, myFont1, sb1, 100, 100);
                    e.Graphics.DrawString(label18.Text + " : " + lbl_dogum_tarihi.Text, myFont1, sb1, 255, 100);
                    e.Graphics.DrawString(label14.Text + " : " + lbl_meslek_kodu.Text, myFont1, sb1, 430, 100);
                    e.Graphics.DrawString(label11.Text + " : " + lbl_ise_giris.Text, myFont1, sb1, 630, 100);

                    e.Graphics.DrawString(label23.Text + " : " + lbl_uyruk.Text, myFont1, sb1, 100, 125);
                    e.Graphics.DrawString(label19.Text + " : " + lbl_dogum_yeri.Text, myFont1, sb1, 255, 125);
                    e.Graphics.DrawString(label15.Text + " : " + lbl_görevi.Text, myFont1, sb1, 430, 125);
                    e.Graphics.DrawString(label12.Text + " : " + lbl_isten_cikis.Text, myFont1, sb1, 630, 125);



                    e.Graphics.DrawString(label24.Text + " : " + lbl_cinsiyet.Text, myFont1, sb1, 100, 150);
                    e.Graphics.DrawString(label20.Text + " : " + lbl_ana_adi.Text, myFont1, sb1, 255, 150);
                    e.Graphics.DrawString(label16.Text + " : " + lbl_gorev_yeri.Text, myFont1, sb1, 430, 150);

                    e.Graphics.DrawLine(myPen, 100, 170, 750, 170);

                    //iletişim bilgileri
                    e.Graphics.DrawString(label2.Text, cizgiFont, sbcizgi, 100, 175);

                    e.Graphics.DrawString(label25.Text + " : " + lbl_tel_no.Text, myFont, sb, 100, 200);
                    e.Graphics.DrawString(label26.Text + " : " + lbl_cep_no.Text, myFont, sb, 300, 200);
                    e.Graphics.DrawString(label36.Text + " : " + lbl_email.Text, myFont, sb, 500, 200);

                    e.Graphics.DrawString(label30.Text + " : " + lbl_yakin.Text, myFont, sb, 100, 225);
                    e.Graphics.DrawString(label31.Text + " : " + lbl_yakin_tel.Text, myFont, sb, 300, 225);
                    e.Graphics.DrawString(label32.Text + " : " + lbl_adres.Text, myFont, sb, 500, 225);


                    e.Graphics.DrawLine(myPen, 100, 250, 750, 250);


                    //eğitim bilgisi

                    e.Graphics.DrawString(label4.Text, cizgiFont, sbcizgi, 100, 255);
                    e.Graphics.DrawString("EĞİTİM BİLGİLERİ ", cizgiFont, sbcizgi, 100, 280);

                    //for (int i = 0; i < dte.Rows.Count; i++)
                    //{

                    //    e.Graphics.DrawString(i+"-"+dte.Rows[i]["okul_adi"] +  ""+ dte.Rows[i]["ogrenim_düzeyi"] + "," + dte.Rows[i]["bolum"] + "," + dte.Rows[i]["sinif"] + "," + dte.Rows[i]["sehir_id"] + ",(" + dte.Rows[i]["giris_tarihi"] + "-"  + dte.Rows[i]["mezuniyet_tarihi"] + ") , " + dte.Rows[i]["derece"]+ ", "+ dte.Rows[i]["durum_bilgisi"]  , myFont, sb, 100, 305 + (i * 25));
                    //}
                    //e.Graphics.DrawLine(myPen, 100, 625, 750, 625);

                    //sağlık bilgileri
                    e.Graphics.DrawString(label6.Text, cizgiFont, sbcizgi, 100, 650);

                    e.Graphics.DrawString(label28.Text + " : " + lbl_kan.Text, myFont, sb, 100, 675);
                    e.Graphics.DrawString(label33.Text + " : " + lbl_boy.Text + " " + label50.Text, myFont, sb, 300, 675);
                    e.Graphics.DrawString(label34.Text + " : " + lbl_kilo.Text + " " + label54.Text, myFont, sb, 400, 675);
                    e.Graphics.DrawString(label46.Text + " : " + txt_saglik.Text, myFont, sb, 100, 700);


                    e.Graphics.DrawString(label53.Text + " : " + txt_engel.Text, myFont, sb, 100, 725);
                    e.Graphics.DrawString(label59.Text + " : " + txt_ameliyat.Text, myFont, sb, 100, 750);
                    e.Graphics.DrawString(label48.Text + " : " + lbl_sigara.Text + " " + lbl_z_sigara.Text, myFont, sb, 500, 675);
                    e.Graphics.DrawString(label51.Text + " : " + lbl_alkol.Text + " " + lbl_z_alkol.Text, myFont, sb, 600, 675);

                    e.Graphics.DrawLine(myPen, 100, 750, 750, 750);

                    //genel kültür kısmı
                    e.Graphics.DrawString("Hobileri", cizgiFont, sbcizgi, 100, 775);
                    e.Graphics.DrawString(lbl_hobi.Text + " : " + lbl_hobileri.Text, myFont, sb, 100, 800);

                    e.Graphics.DrawString("Yabancı Dil", cizgiFont, sbcizgi, 100, 825);
                    e.Graphics.DrawString("YABANCI DİL   YABANCI DİL DÜZEYİ", cizgiFont, sbcizgi, 100, 850);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        e.Graphics.DrawString(dt.Rows[i]["yabanci_dil"] + " " + dt.Rows[i]["duzeyi"], tableFont, tablerush, 100, 875 + (i * 25));
                    }

                    e.Graphics.DrawString("Bilgisayar Programları", cizgiFont, sbcizgi, 400, 825);
                    e.Graphics.DrawString("PROGRAM ADI   PROGRAM BİLGİ DÜZEYİ", cizgiFont, sbcizgi, 400, 850);

                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {

                        e.Graphics.DrawString(dt2.Rows[i]["program_ad"] + " " + dt2.Rows[i]["duzey"], tableFont, tablerush, 400, 875 + (i * 25));
                    }
                    e.Graphics.DrawString("Sertifikalar", cizgiFont, sbcizgi, 100, 1000);
                    e.Graphics.DrawString("SERTİFİKANIN ADI   SERTİFİKANIN ALINDIĞI KURULUŞ     SERTİFİKA KONUSU    ALIŞ TARİHİ", cizgiFont, sbcizgi, 100, 1025);
                    int h = 1050;
                    int s = 0;
                    for (s = 0; s < dt3.Rows.Count; s++)
                    {

                        e.Graphics.DrawString(dt3.Rows[s]["sertifika_adi"] + " " + dt3.Rows[s]["aldigi_kurum"] + "  " + dt3.Rows[s]["konu"] + " " + dt3.Rows[s]["tarih"], tableFont, tablerush, 100, h + (s * 25));
                    }

                    //resmi çekmek
                    e.Graphics.DrawImage(picb_resim.Image, 3, 3, 95, 95);

                    e.Graphics.DrawString("Sayfa 1/4", italikFont, isbcizgi, 100, 1095);*/
                    break;

                    //ikinci sayfa

                    /* case 2:



                         e.Graphics.DrawString("Ağır İş Sertifikası", cizgiFont, sbcizgi, 100, 125);
                         e.Graphics.DrawString("SERTİFİKANIN ADI    ALIŞ TARİHİ", cizgiFont, sbcizgi, 100, 150);

                         for (int i = 0; i < dt5.Rows.Count; i++)
                         {

                             e.Graphics.DrawString(dt5.Rows[i]["agir_is_sertifika_adi"] + " " + dt5.Rows[i]["alinis_tarihi"], tableFont, tablerush, 100, 175 + (i * 25));
                         }

                         e.Graphics.DrawString("Ağır İş Sertifikası", cizgiFont, sbcizgi, 100, 125);

                         //ulaşımın kısmı
                         e.Graphics.DrawLine(myPen, 100, 250, 750, 250);
                         e.Graphics.DrawString("FİRMA İMKANLARI", cizgiFont, sbcizgi, 100, 275);


                         e.Graphics.DrawString(label56.Text + " : " + lbl_gider.Text, myFont, sb, 100, 300);
                         e.Graphics.DrawString(label57.Text + " : " + lbl_sure.Text, myFont, sb, 100, 325);
                         e.Graphics.DrawString(label58.Text, myFont, sb, 100, 350);
                         e.Graphics.DrawString(label60.Text + " " + lbl_v1.Text, myFont, sb, 100, 375);
                         e.Graphics.DrawString(label61.Text + " " + lbl_v2.Text, myFont, sb, 100, 400);
                         e.Graphics.DrawString(label62.Text + " " + lbl_3.Text, myFont, sb, 100, 425);
                         e.Graphics.DrawString(label63.Text + " " + lbl_4.Text, myFont, sb, 100, 450);
                         e.Graphics.DrawString(label64.Text + " " + lbl_5.Text, myFont, sb, 100, 475);
                         e.Graphics.DrawString(label65.Text + " " + lbl_v6.Text, myFont, sb, 100, 500);

                         e.Graphics.DrawString(label68.Text + " ; ", myFont, sb, 400, 300);
                         e.Graphics.DrawString(txt_alerji.Text, myFont, sb, 400, 325);
                         e.Graphics.DrawString(label69.Text + "  " + lbl_yemek.Text, myFont, sb, 400, 400);
                         e.Graphics.DrawString(label71.Text, myFont, sb, 400, 425);
                         e.Graphics.DrawString(txt_neden.Text, myFont, sb, 400, 450);

                         e.Graphics.DrawString(label70.Text, myFont, sb, 400, 475);
                         e.Graphics.DrawString(txt_talep.Text, myFont, sb, 400, 500);



                         e.Graphics.DrawLine(myPen, 100, 550, 750, 550);

                         //MADDİ DURUM BİLGİLERİ
                         e.Graphics.DrawString("MADDİ DURUM BİLGİLERİ", cizgiFont, sbcizgi, 100, 575);

                         e.Graphics.DrawString(label37.Text + " : " + lbl_maas.Text, myFont, sb, 100, 600);
                         e.Graphics.DrawString(label38.Text + " : " + lbl_destek.Text + " " + lbl_destek_mikari.Text, myFont, sb, 100, 625);
                         e.Graphics.DrawString(label39.Text + " : " + lbl_ev.Text, myFont, sb, 100, 650);
                         e.Graphics.DrawString(label40.Text + " : " + lbl_kira.Text, myFont, sb, 100, 675);
                         e.Graphics.DrawString(label41.Text + " : " + lbl_isinma.Text, myFont, sb, 100, 700);
                         e.Graphics.DrawString(label43.Text + " : " + lbl_arac.Text + " , " + lbl_arac_amac.Text, myFont, sb, 100, 725);
                         e.Graphics.DrawString(label42.Text + " : " + lbl_arazi.Text, myFont, sb, 100, 750);
                         e.Graphics.DrawString(lbl_arazi_amac.Text, myFont, sb, 100, 775);
                         e.Graphics.DrawString(label27.Text + " : " + lbl_gelir_ev.Text + " ; " + lbl_gelir_ev_tutar.Text, myFont, sb, 500, 625);
                         e.Graphics.DrawString(label45.Text + " : " + lbl_iban.Text, myFont, sb, 500, 650);
                         e.Graphics.DrawString(label44.Text + " : " + lbl_icra.Text, myFont, sb, 500, 675);
                         e.Graphics.DrawString(label29.Text + " : " + lbl_icra_konu.Text, myFont, sb, 500, 700);
                         e.Graphics.DrawString(label49.Text + " : " + lbl_borc_miktari.Text, myFont, sb, 500, 725);
                         e.Graphics.DrawString(label52.Text + " : " + lbl_borc_hesap_no.Text, myFont, sb, 500, 750);
                         e.Graphics.DrawString(label35.Text + " : " + date_borc_tarihi.Value.ToShortDateString(), myFont, sb, 500, 775);

                         e.Graphics.DrawString("Sayfa 2/4", italikFont, isbcizgi, 100, 1095);
                         break;

                         */
                    /*case 3:

                        //özgeçmiş bilgilerinin çekilmesi
                        e.Graphics.DrawString("PERSONEL ÖZ GEÇMİŞ BİLGİLERİ", cizgiFont, sbcizgi, 100, 125);



                        e.Graphics.DrawString("İŞ YERİ ADI      TELEFON NUMARASI        GÖREVİ       MAAŞ        YÖNETİCİ ADI         İŞE GİRİŞ TARİHİ      İŞTEN AYRILIŞ TARİHİ        AYRILMA SEBEBİ", cizgiFont, sbcizgi, 100, 150);

                        for (int i = 0; i < dto.Rows.Count; i++)
                        {

                            e.Graphics.DrawString(dto.Rows[i]["isyeri_adi"] + " " + dto.Rows[i]["tel"] + " " + dto.Rows[i]["gorev"] + " " + dto.Rows[i]["maaş"] +
                                " " + dto.Rows[i]["yon_adi"] + " " + dto.Rows[i]["giris_tarihi"] + " " + dto.Rows[i]["cikis_tarihi"] + " " + dto.Rows[i]["sebep"], tableFont, tablerush, 100, 175 + (i * 25));

                        }

                        //kkd çekilmesi
                        e.Graphics.DrawString("PERSONEL KŞİSEL KORUYUCU DONANIM LİSTESİ", cizgiFont, sbcizgi, 100, 275);

                        e.Graphics.DrawString("KKD TÜRÜ         BEDEN       KKD TESLİM TARİHİ        AKSİYON TÜRÜ        AKSİYON TARİHİ", cizgiFont, sbcizgi, 100, 300);

                        for (int i = 0; i < dtk.Rows.Count; i++)
                        {

                            e.Graphics.DrawString(dtk.Rows[i]["kkd_turu"] + " " + dtk.Rows[i]["beden"] + " " + dtk.Rows[i]["kkd_teslim_tarihi"] +
                                " " + dtk.Rows[i]["aksiyon_tutu"] + " " + dtk.Rows[i]["aksiyon_tarihi"], tableFont, tablerush, 100, 350 + (i * 25));

                        }


                        ///aile ve bakım bilgisi
                        e.Graphics.DrawString("AİLE BİLGİLERİ", cizgiFont, sbcizgi, 100, 475);

                        //printDocument1.DefaultPageSettings.Landscape = false;

                        //çocuk sayıısnın çekilmesi
                        e.Graphics.DrawString(label47.Text + " : " + lbl_cocuk.Text, myFont, sb, 100, 500);



                        //aileye ait temel bilgiler
                        e.Graphics.DrawString("YAKINLIK DERECESİ    ADI SOYADI      CİNSİYETİ       DOĞUM YERİ      DOĞUM TARİHİ       YAŞAM BİLGİSİ        ÖLÜM TARİHİ         ÖLÜM SEBEBİ         MEDENİ HALİ         TELEFON NUMARASI", cizgiFont, sbcizgi, 100, 525);

                        for (int i = 0; i < dtyt.Rows.Count; i++)
                        {

                            e.Graphics.DrawString(dtyt.Rows[i]["yakinlik_derecesi"] + " " + dtyt.Rows[i]["yakin_adi_soyadi"] + " "
                                + dtyt.Rows[i]["yakin_cinsiyeti"] + " " + dtyt.Rows[i]["yakin_dogum_yeri"] + " " + dtyt.Rows[i]["yakin_dogum_tarihi"]
                                + " " + dtyt.Rows[i]["yakin_yasam_bilgisi"] + " " + dtyt.Rows[i]["yakin_olum_tarihi"] + " " + dtyt.Rows[i]["yakin_olum_aciklamasi"]
                                + " " + dtyt.Rows[i]["yakin_medeni_hali"] + " " + dtyt.Rows[i]["yakin_tel_no"], tableFont, tablerush, 100, 550 + (i * 25));

                        }


                        //aileye ait sağlık  bilgiler
                        e.Graphics.DrawString("ADI SOYADI         KAN GRUBU      SAĞLIK AÇIKLAMASI       ENGEL AÇIKLAMASI", cizgiFont, sbcizgi, 100, 700);

                        for (int i = 0; i < dtys.Rows.Count; i++)
                        {

                            e.Graphics.DrawString(dtys.Rows[i]["yakin_adi_soyadi"] + " " + dtys.Rows[i]["yakin_kan_grubu"] + " " + dtys.Rows[i]["yakin_saglik_aciklama"] + " " +
                                dtys.Rows[i]["yakin_engel_aciklama"] + " " + dtys.Rows[i]["yakin_çalisma_durumu"], tableFont, tablerush, 100, 725 + (i * 25));

                        }

                        //aileye ait eğitim bilgileri
                        e.Graphics.DrawString("ADI SOYADI      OKUL DURUMU       OKUL ADI        ÖĞRENİM DÜZEYİ      BÖLÜMÜ      SINIF       ŞEHİR      OKUL GİRİŞ TARİHİ      MEZUNİYET DURUMU         MEZUNİYET TARİHİ         MEZUNİYET DERECESİ", cizgiFont, sbcizgi, 100, 925);

                        for (int i = 0; i < dtye.Rows.Count; i++)
                        {

                            e.Graphics.DrawString(dtye.Rows[i]["yakin_adi_soyadi"] + " " + dtye.Rows[i]["yakin_okul"] + " " + dtye.Rows[i]["yakin_okul_adi"] + " " + dtye.Rows[i]["yakin_ogrenim_duzeyi"]
                                + " " + dtye.Rows[i]["yakin_okul_bolumu"] + " " + dtye.Rows[i]["yakin_okul_sinif"] + " " + dtye.Rows[i]["yakin_okul_sehir"]
                                + " " + dtye.Rows[i]["yakin_okul_giris_tarihi"] + " " + dtye.Rows[i]["yakin_okul_durumu"] + " " +
                                dtye.Rows[i]["yakin_okul_mezuniyet_tarihi"] + " " + dtye.Rows[i]["yakin_mezuniyet_derecesi"], tableFont, tablerush, 100, 950 + (i * 25));

                        }



                        e.Graphics.DrawString("Sayfa 3/4", italikFont, isbcizgi, 100, 1095);
                        break;
                    */
                    /* case 4:
                         //aileye ait çalışma bilgiler
                         e.Graphics.DrawString("ADI SOYADI         ÇALIŞMA DURUMU         MESLEK BİLGİSİ       AYLIK GELİR         ÇALIŞMA YERİ", cizgiFont, sbcizgi, 100, 125);

                         for (int i = 0; i < dtyc.Rows.Count; i++)
                         {

                             e.Graphics.DrawString(dtyc.Rows[i]["yakin_adi_soyadi"] + " " + dtyc.Rows[i]["yakin_çalisma_durumu"]
                                 + " " + dtyc.Rows[i]["yakin_meslegi"] + " " + dtyc.Rows[i]["yakin_geliri"] + " " + dtyc.Rows[i]["yakin_calistigi_yer"], tableFont, tablerush, 100, 150 + (i * 25));

                         }



                         //aileye ait genel kültür bilgileri
                         e.Graphics.DrawString("ADI SOYADI      MERASİM TÜRÜ       MERASİM TARİHİ       HOBİLERİ", cizgiFont, sbcizgi, 100, 225);

                         for (int i = 0; i < dtyg.Rows.Count; i++)
                         {

                             e.Graphics.DrawString(dtyg.Rows[i]["yakin_adi_soyadi"] + " " + dtyg.Rows[i]["yakin_merasim_turu"]
                                 + " " + dtyg.Rows[i]["yakin_merasim_tarihi"] + " " + dtyg.Rows[i]["yakin_hobileri"], tableFont, tablerush, 100, 250 + (i * 25));

                         }

                         e.Graphics.DrawString("ADI SOYADI       DOĞUM YERİ          DOĞUM TARİHİ           TELEFON NUMARASI          SAĞLIK AÇIKLAMASI      ENGEL AÇIKLAMASI        GELİRİ      YAKINLIK DERECESİ        HOBİLERİ", cizgiFont, sbcizgi, 100, 350);

                         for (int i = 0; i < dtb.Rows.Count; i++)
                         {

                             e.Graphics.DrawString(dtb.Rows[i]["adi_soyadi"] + " " + dtb.Rows[i]["dogum_yeri"] + "     " + dtb.Rows[i]["dogum_tarihi"] +
                                 " " + dtb.Rows[i]["tel_no"] + "     " + dtb.Rows[i]["saglik_sorunu_aciklama"] + " " + dtb.Rows[i]["engel_aciklama"] +
                                 "     " + dtb.Rows[i]["geliri"] + " " + dtb.Rows[i]["bakim_yakini"] + "     " + dtb.Rows[i]["bakim_hobi"], tableFont, tablerush, 100, 875 + (i * 25));

                         }


                         e.Graphics.DrawLine(myPen, 100, 450, 750, 450);


                        e.Graphics.DrawString("Sayfa 4/4", italikFont, isbcizgi, 100, 1095);
                    */
                    //  break;
                    //satırlar safaya sığmazsa bir sonraki sayfadan devam edilsin



                    //if ((y/satir_yuksekligi)>(sayfa_ayari.PaperSize.Height-sayfa_ayari.Margins.Bottom))
                    //{
                    //    e.HasMorePages = true;

                    //}

            }
            //if (a < 4)
            //{
            //    a++;
            //    e.HasMorePages = true;
            //}
            //else
            //    a = 1;
            throw new NotImplementedException();
        }

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            MessageBox.Show("hello :))");
        }

        /*
       private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
       {

        }
        */
    }
}
