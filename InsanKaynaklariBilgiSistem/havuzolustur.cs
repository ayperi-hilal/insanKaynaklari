using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using AForge.Video;
using AForge.Video.DirectShow;
using Image = System.Drawing.Image;

namespace InsanKaynaklariBilgiSistem
{
    public partial class havuzolustur : Form
    {
        public havuzolustur()
        {
            InitializeComponent();
        }
        sqlBaglantisi baglantim = new sqlBaglantisi();

        private int flag;

        private void CheckFlag()
        {
            if (flag == 1)
            {
                lnk_lbl_1.MouseClick += Lnk_lbl_1_MouseClick;

            }
        }

        private void Lnk_lbl_1_MouseClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private FilterInfoCollection webcam;

        private VideoCaptureDevice cam;


        private void havuzolustur_Load(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Personele ait resmi seçiniz";
            openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo videocapturedevice in webcam)
            {
                comboBox1.Items.Add(videocapturedevice.Name);
            }
            comboBox1.SelectedIndex = 0;

            btn_kamerayıkapat.Visible = false;

            txt_baslik.CharacterCasing = CharacterCasing.Upper;
            txt_cvdosya.CharacterCasing = CharacterCasing.Upper;
            txt_kariyerhedefi.CharacterCasing = CharacterCasing.Upper;
            txt_pozisyon.CharacterCasing = CharacterCasing.Upper;
            txt_ad.CharacterCasing = CharacterCasing.Upper;
            txt_soyadı.CharacterCasing = CharacterCasing.Upper;
            txt_dogum.CharacterCasing = CharacterCasing.Upper;
            txt_uyruk.CharacterCasing = CharacterCasing.Upper;
            txt_adres.CharacterCasing = CharacterCasing.Upper;
            txt_ehliyet.CharacterCasing = CharacterCasing.Upper;
            txt_saglik.CharacterCasing = CharacterCasing.Upper;
            txt_e_okul1.CharacterCasing = CharacterCasing.Upper;
            txt_e_okul2.CharacterCasing = CharacterCasing.Upper;
            txt_e_okul3.CharacterCasing = CharacterCasing.Upper;
            txt_e_bolum1.CharacterCasing = CharacterCasing.Upper;
            txt_e_bolum2.CharacterCasing = CharacterCasing.Upper;
            txt_e_bolum3.CharacterCasing = CharacterCasing.Upper;
            txt_yer1.CharacterCasing = CharacterCasing.Upper;
            txt_yer2.CharacterCasing = CharacterCasing.Upper;
            txt_yer3.CharacterCasing = CharacterCasing.Upper;
            txt_gorev1.CharacterCasing = CharacterCasing.Upper;
            txt_gorev2.CharacterCasing = CharacterCasing.Upper;
            txt_gorev3.CharacterCasing = CharacterCasing.Upper;
            txt_neden1.CharacterCasing = CharacterCasing.Upper;
            txt_neden2.CharacterCasing = CharacterCasing.Upper;
            txt_neden3.CharacterCasing = CharacterCasing.Upper;
            txt_ref1.CharacterCasing = CharacterCasing.Upper;
            txt_ref2.CharacterCasing = CharacterCasing.Upper;
            txt_ref3.CharacterCasing = CharacterCasing.Upper;
            txt_program1.CharacterCasing = CharacterCasing.Upper;
            txt_program2.CharacterCasing = CharacterCasing.Upper;
            txt_program3.CharacterCasing = CharacterCasing.Upper;

            txt_sertifika1.CharacterCasing = CharacterCasing.Upper;
            txt_sertifika2.CharacterCasing = CharacterCasing.Upper;
            txt_sertifika3.CharacterCasing = CharacterCasing.Upper;
            txt_sertifikaa1.CharacterCasing = CharacterCasing.Upper;
            txt_sertifikaa2.CharacterCasing = CharacterCasing.Upper;
            txt_sertifikaa3.CharacterCasing = CharacterCasing.Upper;
            txt_sertifika_kurum1.CharacterCasing = CharacterCasing.Upper;
            txt_sertifika_kurum2.CharacterCasing = CharacterCasing.Upper;
            txt_sertifika_kurum3.CharacterCasing = CharacterCasing.Upper;

            txt_tc_no.MaxLength = 11;
            txt_tel_no.MaxLength = 11;
            txt_iletisim1.MaxLength = 11;
            txt_iletisim2.MaxLength = 11;
            txt_iletisim3.MaxLength = 11;
            txt_yer1.MaxLength = 20;
            txt_yer2.MaxLength = 20;
            txt_yer3.MaxLength = 20;
            txt_gorev1.MaxLength = 15;
            txt_gorev2.MaxLength = 15;
            txt_gorev3.MaxLength = 15;
            txt_neden1.MaxLength = 15;
            txt_neden2.MaxLength = 15;
            txt_neden3.MaxLength = 15;
            txt_ref1.MaxLength = 15;
            txt_ref2.MaxLength = 15;
            txt_ref3.MaxLength = 15;
            txt_sertifika1.MaxLength = 20;
            txt_sertifika2.MaxLength = 20;
            txt_sertifika3.MaxLength = 20;
            txt_sertifikaa1.MaxLength = 15;
            txt_sertifikaa2.MaxLength = 15;
            txt_sertifikaa3.MaxLength = 15;
            txt_sertifika_kurum1.MaxLength = 20;
            txt_sertifika_kurum2.MaxLength = 20;
            txt_sertifika_kurum3.MaxLength = 20;
            txt_program1.MaxLength = 30;
            txt_program2.MaxLength = 30;
            txt_program3.MaxLength = 30;
            txt_e_okul1.MaxLength = 30;
            txt_e_okul2.MaxLength = 30;
            txt_e_okul3.MaxLength = 30;
            txt_e_bolum1.MaxLength = 25;
            txt_e_bolum2.MaxLength = 25;
            txt_e_bolum3.MaxLength = 25;

            cbx_calisma_sekli.Items.Add("Seçiniz...");
            cbx_calisma_sekli.Items.Add("Proje Bazlı");
            cbx_calisma_sekli.Items.Add("Tam Zamanlı");
            cbx_calisma_sekli.Items.Add("Yarı Zamanlı");
            cbx_calisma_sekli.Items.Add("Dönemsel");
            cbx_calisma_sekli.Items.Add("Uzaktan");
            cbx_calisma_sekli.Items.Add("Stajyer");

            cbx_cinsiyet.Items.Add("Seçiniz...");
            cbx_cinsiyet.Items.Add("Kadın");
            cbx_cinsiyet.Items.Add("Erkek");

            cbx_medeni_hal.Items.Add("Seçiniz...");
            cbx_medeni_hal.Items.Add("Evli");
            cbx_medeni_hal.Items.Add("Bekar");
            cbx_medeni_hal.Items.Add("Boşanmış");

            cbx_kan.Items.Add("Seçiniz...");
            cbx_kan.Items.Add("0(+)");
            cbx_kan.Items.Add("0(-)");
            cbx_kan.Items.Add("A(+)");
            cbx_kan.Items.Add("A(-)");
            cbx_kan.Items.Add("B(+)");
            cbx_kan.Items.Add("B(-)");
            cbx_kan.Items.Add("AB(+)");
            cbx_kan.Items.Add("AB(-)");
            cbx_kan.Items.Add("Bilinmiyor");

            cbx_askerlik.Items.Add("Seçiniz...");
            cbx_askerlik.Items.Add("Yaptı");
            cbx_askerlik.Items.Add("Yapmadı");
            cbx_askerlik.Items.Add("Muaf");

            cbx_e_seviye1.Items.Add("Seçiniz...");
            cbx_e_seviye1.Items.Add("Ana Okulu");
            cbx_e_seviye1.Items.Add("İlkokul");
            cbx_e_seviye1.Items.Add("Ortaokul");
            cbx_e_seviye1.Items.Add("Lise");
            cbx_e_seviye1.Items.Add("Üniversite");
            cbx_e_seviye1.Items.Add("Yüksek Lisans");
            cbx_e_seviye1.Items.Add("Doktora");

            cbx_e_seviye2.Items.Add("Seçiniz...");
            cbx_e_seviye2.Items.Add("Ana Okulu");
            cbx_e_seviye2.Items.Add("İlkokul");
            cbx_e_seviye2.Items.Add("Ortaokul");
            cbx_e_seviye2.Items.Add("Lise");
            cbx_e_seviye2.Items.Add("Üniversite");
            cbx_e_seviye2.Items.Add("Yüksek Lisans");
            cbx_e_seviye2.Items.Add("Doktora");

            cbx_e_seviye3.Items.Add("Seçiniz...");
            cbx_e_seviye3.Items.Add("Ana Okulu");
            cbx_e_seviye3.Items.Add("İlkokul");
            cbx_e_seviye3.Items.Add("Ortaokul");
            cbx_e_seviye3.Items.Add("Lise");
            cbx_e_seviye3.Items.Add("Üniversite");
            cbx_e_seviye3.Items.Add("Yüksek Lisans");
            cbx_e_seviye3.Items.Add("Doktora");

            cbx_e_durum1.Items.Add("Hazırlık");
            cbx_e_durum1.Items.Add("1");
            cbx_e_durum1.Items.Add("2");
            cbx_e_durum1.Items.Add("3");
            cbx_e_durum1.Items.Add("4");
            cbx_e_durum1.Items.Add("5");
            cbx_e_durum1.Items.Add("6");
            cbx_e_durum1.Items.Add("Mezun");
            cbx_e_durum1.Items.Add("Terk");

            cbx_e_durum2.Items.Add("Hazırlık");
            cbx_e_durum2.Items.Add("1");
            cbx_e_durum2.Items.Add("2");
            cbx_e_durum2.Items.Add("3");
            cbx_e_durum2.Items.Add("4");
            cbx_e_durum2.Items.Add("5");
            cbx_e_durum2.Items.Add("6");
            cbx_e_durum2.Items.Add("Mezun");
            cbx_e_durum2.Items.Add("Terk");

            cbx_e_durum3.Items.Add("Hazırlık");
            cbx_e_durum3.Items.Add("1");
            cbx_e_durum3.Items.Add("2");
            cbx_e_durum3.Items.Add("3");
            cbx_e_durum3.Items.Add("4");
            cbx_e_durum3.Items.Add("5");
            cbx_e_durum3.Items.Add("6");
            cbx_e_durum3.Items.Add("Mezun");
            cbx_e_durum3.Items.Add("Terk");

            cbx_dil1.Items.Add("İngilizce");
            cbx_dil1.Items.Add("Almanca");
            cbx_dil1.Items.Add("Fransızca");
            cbx_dil1.Items.Add("Arapça");

            cbx_dil_sev1.Items.Add("İyi");
            cbx_dil_sev1.Items.Add("Orta");
            cbx_dil_sev1.Items.Add("Çok iyi");

            cbx_dil2.Items.Add("İngilizce");
            cbx_dil2.Items.Add("Almanca");
            cbx_dil2.Items.Add("Fransızca");
            cbx_dil2.Items.Add("Arapça");

            cbx_dil_sev2.Items.Add("İyi");
            cbx_dil_sev2.Items.Add("Orta");
            cbx_dil_sev2.Items.Add("Çok iyi");

            cbx_dil3.Items.Add("İngilizce");
            cbx_dil3.Items.Add("Almanca");
            cbx_dil3.Items.Add("Fransızca");
            cbx_dil3.Items.Add("Arapça");

            cbx_dil_sev3.Items.Add("İyi");
            cbx_dil_sev3.Items.Add("Orta");
            cbx_dil_sev3.Items.Add("Çok iyi");

            cbx_bil_sev1.Items.Add("İyi");
            cbx_bil_sev1.Items.Add("Orta");
            cbx_bil_sev1.Items.Add("Çok iyi");

            cbx_bil_sev2.Items.Add("İyi");
            cbx_bil_sev2.Items.Add("Orta");
            cbx_bil_sev2.Items.Add("Çok iyi");

            cbx_bil_sev3.Items.Add("İyi");
            cbx_bil_sev3.Items.Add("Orta");
            cbx_bil_sev3.Items.Add("Çok iyi");


            resim.Image = null;

            havuzKayit ff = new havuzKayit();


            txt_id.Text = havuz.havuz_id;
            // resim.Image = ff.resim.Length;//??
            txt_baslik.Text = havuz.baslik;
            lnk_lbl_1.Text = havuz.cvLinki;

            cbx_calisma_sekli.Text = havuz.calismaSekli;
            txt_tc_no.Text = havuz.kisi_tc;
            txt_ad.Text = havuz.adi; //ff.adi = null
            txt_soyadı.Text = havuz.soyadi;
            date_dogum.Text = havuz.dogumTarihi;
            txt_dogum.Text = havuz.dogumYeri;
            txt_uyruk.Text = havuz.uyruk;
            cbx_askerlik.Text = havuz.askerlik;
            date_askerlik.Text = havuz.askerlikTarihi;
            txt_adres.Text = havuz.adres;

            if (havuz.engelDurumu == cx_engel_var.Text)
                cx_engel_var.Checked = true;
            else
                cx_engel_yok.Checked = true;

            if (havuz.seyehat == cx_sey_e.Text)
                cx_sey_e.Checked = true;
            else
                cx_sey_h.Checked = true;
            if (havuz.cocukDurumu == cx_cocuk_var.Text)
                cx_cocuk_var.Checked = true;
            else
                cx_cocuk_yok.Checked = true;

            // numeric_cocuk_sayisi.Value= havuz.cocukSayisi;//?
            if (havuz.sektörTecrübesi == cx_sektor_var.Text)
                cx_sektor_var.Checked = true;
            else
                cx_sektor_yok.Checked = true;

            date_kayit.Text = havuz.kayitTarihi;
            txt_kariyerhedefi.Text = havuz.kariyerHedefi;
            txt_pozisyon.Text = havuz.pozisyonTercihi;
            cbx_cinsiyet.Text = havuz.cinsiyet;
            cbx_medeni_hal.Text = havuz.medeniHal;
            cbx_kan.Text = havuz.kan;
            txt_email.Text = havuz.eposta;
            txt_tel_no.Text = havuz.tel;
            if (havuz.sabikakaydı == cx_sabika_var.Text)
                cx_sabika_var.Checked = true;
            else
                cx_sabika_yok.Checked = true;

            txt_ehliyet.Text = havuz.sürücübelgesi;
            txt_saglik.Text = havuz.saglikSorunu;
            if (havuz.sigara == cx_sigara_evet.Text)
                cx_sigara_evet.Checked = true;
            else
                cx_sigara_hayır.Checked = true;

            if (havuz.alkol == cx_alkol_evet.Text)
                cx_alkol_evet.Checked = true;
            else
                cx_alkol_hayır.Checked = true;

            txt_ucret_beklentisi.Text = havuz.ücretBeklentisi;
            cbx_e_seviye1.Text = havuz.egitimSeviye1;
            cbx_e_durum1.Text = havuz.egitimDurum1;
            txt_e_okul1.Text = havuz.egitimOkul1;
            txt_e_bolum1.Text = havuz.egitimBolum1;
            date_mezuniyet1.Text = havuz.mezuniyet1;
            txt_not1.Text = havuz.notDurumu1;
            cbx_e_seviye2.Text = havuz.egitimSeviye2;
            cbx_e_durum2.Text = havuz.egitimDurum2;
            txt_e_okul2.Text = havuz.egitimOkul2;
            txt_e_bolum2.Text = havuz.egitimBolum2;
            date_mezuniyet2.Text = havuz.mezuniyet2;
            txt_not2.Text = havuz.notDurumu2;
            cbx_e_seviye3.Text = havuz.egitimSeviye3;
            cbx_e_durum3.Text = havuz.egitimDurum3;
            txt_e_okul3.Text = havuz.egitimOkul3;
            txt_e_bolum3.Text = havuz.egitimBolum3;
            date_mezuniyet3.Text = havuz.mezuniyet3;
            txt_not3.Text = havuz.notDurumu3;
            txt_yer1.Text = havuz.calistigiyer1;
            txt_yer2.Text = havuz.calistigiyer2;
            txt_yer3.Text = havuz.calistigiyer3;
            txt_gorev1.Text = havuz.gorev1;
            txt_gorev2.Text = havuz.gorev2;
            txt_gorev3.Text = havuz.gorev3;
            date_giris_1.Text = havuz.cGirisTarihi1;
            date_giris_2.Text = havuz.cGirisTarihi2;
            date_giris_3.Text = havuz.cGirisTarihi3;
            date_cikis_1.Text = havuz.cCikisTarihi1;
            date_cikis_2.Text = havuz.cCikisTarihi2;
            date_cikis_3.Text = havuz.cCikisTarihi3;
            txt_neden1.Text = havuz.cNeden1;
            txt_neden2.Text = havuz.cNeden2;
            txt_neden3.Text = havuz.cNeden3;
            txt_ref1.Text = havuz.cref1;
            txt_ref2.Text = havuz.cref2;
            txt_ref3.Text = havuz.cref3;
            txt_iletisim1.Text = havuz.ciletisim1;
            txt_iletisim2.Text = havuz.ciletisim2;
            txt_iletisim3.Text = havuz.ciletisim3;
            cbx_dil1.Text = havuz.dil1;
            cbx_dil2.Text = havuz.dil2;
            cbx_dil3.Text = havuz.dil3;
            cbx_dil_sev1.Text = havuz.dilseviye1;
            cbx_dil_sev2.Text = havuz.dilseviye2;
            cbx_dil_sev3.Text = havuz.dilseviye3;
            txt_program1.Text = havuz.program1;
            txt_program2.Text = havuz.program2;
            txt_program3.Text = havuz.program3;
            cbx_bil_sev1.Text = havuz.programseviye1;
            cbx_bil_sev2.Text = havuz.programseviye2;
            cbx_bil_sev3.Text = havuz.programseviye3;
            txt_sertifika1.Text = havuz.sertifika1;
            txt_sertifika2.Text = havuz.sertifika2;
            txt_sertifika3.Text = havuz.sertifika3;
            txt_sertifikaa1.Text = havuz.sertifikaa1;
            txt_sertifikaa2.Text = havuz.sertifikaa2;
            txt_sertifikaa3.Text = havuz.sertifikaa3;
            txt_sertifika_kurum1.Text = havuz.sertifikakurum1;
            txt_sertifika_kurum2.Text = havuz.sertifikakurum2;
            txt_sertifika_kurum3.Text = havuz.sertifikakurum3;
            date_sertifika1.Text = havuz.sertifikatarih1;
            date_sertifika2.Text = havuz.sertifikatarih2;
            date_sertifika3.Text = havuz.sertifikatarih3;


        }

        private void ekrani_temizle()
        {
            resim.Image = null;

            txt_baslik.Text = string.Empty;
            //  txt_cvdosya.Text = string.Empty;
            lnk_lbl_1.Text = string.Empty;
            txt_tc_no.Text = string.Empty;
            txt_ad.Text = string.Empty;
            txt_soyadı.Text = string.Empty;
            txt_dogum.Text = string.Empty;
            txt_uyruk.Text = string.Empty;
            txt_adres.Text = string.Empty;
            txt_kariyerhedefi.Text = string.Empty;
            txt_pozisyon.Text = string.Empty;
            txt_email.Text = string.Empty;
            txt_tel_no.Text = string.Empty;
            txt_saglik.Text = string.Empty;
            txt_ehliyet.Text = string.Empty;
            txt_ucret_beklentisi.Text = string.Empty;

            txt_sertifika1.Text = string.Empty;
            txt_sertifika2.Text = string.Empty;
            txt_sertifika3.Text = string.Empty;
            txt_sertifikaa1.Text = string.Empty;
            txt_sertifikaa2.Text = string.Empty;
            txt_sertifikaa3.Text = string.Empty;
            txt_sertifika_kurum1.Text = string.Empty;
            txt_sertifika_kurum2.Text = string.Empty;
            txt_sertifika_kurum3.Text = string.Empty;

            txt_program1.Text = string.Empty;
            txt_program2.Text = string.Empty;
            txt_program3.Text = string.Empty;

            txt_yer1.Text = string.Empty;
            txt_yer2.Text = string.Empty;
            txt_yer3.Text = string.Empty;
            txt_gorev1.Text = string.Empty;
            txt_gorev2.Text = string.Empty;
            txt_gorev3.Text = string.Empty;

            txt_neden1.Text = string.Empty;
            txt_neden2.Text = string.Empty;
            txt_neden3.Text = string.Empty;
            txt_ref1.Text = string.Empty;
            txt_ref2.Text = string.Empty;
            txt_ref3.Text = string.Empty;
            txt_iletisim1.Text = string.Empty;
            txt_iletisim2.Text = string.Empty;
            txt_iletisim3.Text = string.Empty;
            txt_e_okul1.Text = string.Empty;
            txt_e_okul2.Text = string.Empty;
            txt_e_okul3.Text = string.Empty;
            txt_e_bolum1.Text = string.Empty;
            txt_e_bolum2.Text = string.Empty;
            txt_e_bolum3.Text = string.Empty;
            txt_not1.Text = string.Empty;
            txt_not2.Text = string.Empty;
            txt_not3.Text = string.Empty;

            cx_engel_var.Checked = false;
            cx_engel_yok.Checked = false;
            cx_sey_e.Checked = false;
            cx_sey_h.Checked = false;
            cx_cocuk_var.Checked = false;
            cx_cocuk_yok.Checked = false;
            cx_sektor_var.Checked = false;
            cx_sektor_yok.Checked = false;
            cx_sabika_var.Checked = false;
            cx_sabika_yok.Checked = false;
            cx_sigara_evet.Checked = false;
            cx_sigara_hayır.Checked = false;
            cx_alkol_evet.Checked = false;
            cx_alkol_hayır.Checked = false;

            cbx_calisma_sekli.Text = "Seçiniz...";
            cbx_askerlik.Text = "Seçiniz...";
            cbx_cinsiyet.Text = "Seçiniz...";
            cbx_medeni_hal.Text = "Seçiniz...";
            cbx_kan.Text = "Seçiniz...";
            cbx_bil_sev1.Text = "Seçiniz...";
            cbx_bil_sev2.Text = "Seçiniz...";
            cbx_bil_sev3.Text = "Seçiniz...";
            cbx_dil1.Text = "Seçiniz...";
            cbx_dil2.Text = "Seçiniz...";
            cbx_dil3.Text = "Seçiniz...";
            cbx_e_seviye1.Text = "Seçiniz...";
            cbx_e_seviye2.Text = "Seçiniz...";
            cbx_e_seviye3.Text = "Seçiniz...";
            cbx_e_durum1.Text = "Seçiniz...";
            cbx_e_durum2.Text = "Seçiniz...";
            cbx_e_durum3.Text = "Seçiniz...";

            numeric_cocuk_sayisi.Value = 0;

            date_dogum.ResetText();
            date_askerlik.ResetText();
            date_kayit.ResetText();
            date_sertifika1.ResetText();
            date_sertifika2.ResetText();
            date_sertifika3.ResetText();
            date_giris_1.ResetText();
            date_giris_2.ResetText();
            date_giris_3.ResetText();
            date_cikis_1.ResetText();
            date_cikis_2.ResetText();
            date_cikis_3.ResetText();
            date_mezuniyet1.ResetText();
            date_mezuniyet2.ResetText();
            date_mezuniyet3.ResetText();

        }

        string resimAdresi;

        private void btn_gozat_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) //resim seçme işlemi başarılı bir şekilde gerçekleştirildi mi onu kontrol edelim
            {


                resim.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);

                textBox2.Text = openFileDialog1.FileName.ToString();
                resimAdresi = openFileDialog1.FileName.ToString();

                Bitmap bmp = new Bitmap(resim.Image, 100, 100);
                resim.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public void resim_goruntule()
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT resim FROM tbl_havuz WHERE kisi_tc = '" + txt_tc_no.Text + "'", baglantim.baglanti()));

                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count == 1)
                {
                    Byte[] data = new Byte[0];
                    data = (Byte[])(dataSet.Tables[0].Rows[0]["resim"]);        // tablodaki coloum ismi
                    MemoryStream mem = new MemoryStream(data);
                    resim.Image = Image.FromStream(mem);

                    MessageBox.Show("Okuma Başarılı");
                }
                else
                {
                    resim.Image = null;
                    MessageBox.Show("Resim Yok!");
                }

            }
            catch (Exception se)
            {

                // MessageBox.Show("Resim görüntüleme noktasında bir hata ile karşılaşıldı. Lütfen yönetici ile iletişime geçiniz.");
                MessageBox.Show(se.Message);
            }
            finally
            {

            }
        }

        bool kayitarama = false;
        private void txt_tc_no_TextChanged(object sender, EventArgs e)
        {
            //tc kimlik no giriş kısmı için kısıtlamalar yazılacaktır.
            //yukarıda 11 den fazla giremeyeceğini belirtmştirk. bu ksımda da 11d den az giremeyeceğini belirttik.
            if (txt_tc_no.Text.Length < 11)
                dxErrorProvider1.SetError(txt_tc_no, "TC KİMLİK NO 11 KARAKTER OLMALIDIR.");
            else
                dxErrorProvider1.ClearErrors();
            if (txt_tc_no.Text.Length == 11)
            {
                SqlCommand selectsorgu = new SqlCommand("havuz_arama", baglantim.baglanti());
                selectsorgu.CommandType = CommandType.StoredProcedure;

                selectsorgu.Parameters.AddWithValue("@kisi_tc", txt_tc_no.Text);


                SqlDataReader kayitokuma = selectsorgu.ExecuteReader();

                //kayıtokumanın içerisne attığımız değişkenin while döngüsü ile tüm veri tabanında arayalım.
                while (kayitokuma.Read())
                {   //kayıt var ise buradan true dönecek.


                    SqlCommand selectsorguiki = new SqlCommand("select *from tbl_havuz where kisi_tc='" + txt_tc_no.Text + "'", baglantim.baglanti());
                    SqlDataReader kayitokumaiki = selectsorguiki.ExecuteReader();

                    kayitarama = true;
                    //label3.Text = kayitokuma.GetValue(2).ToString();//ilgili tck ait değerin veritabanındaki tck getirilecek. veri tabanı 0,1,2,.. diye gider.
                    //label5.Text = kayitokuma.GetValue(3).ToString();//ad
                    txt_baslik.Text = kayitokuma.GetValue(2).ToString();
                    txt_cvdosya.Text = kayitokuma.GetValue(3).ToString();

                    cbx_calisma_sekli.Text = kayitokuma.GetValue(4).ToString();
                    txt_tc_no.Text = kayitokuma.GetValue(5).ToString();
                    txt_ad.Text = kayitokuma.GetValue(6).ToString();
                    txt_soyadı.Text = kayitokuma.GetValue(7).ToString();
                    date_dogum.Value = kayitokuma.GetDateTime(8);
                    txt_dogum.Text = kayitokuma.GetValue(9).ToString();
                    txt_uyruk.Text = kayitokuma.GetValue(10).ToString();
                    cbx_askerlik.Text = kayitokuma.GetValue(11).ToString();
                    date_askerlik.Value = kayitokuma.GetDateTime(12);
                    txt_adres.Text = kayitokuma.GetValue(13).ToString();

                    if (kayitokuma.GetValue(3).ToString() != "")
                    {
                        string yeniad = txt_tc_no.Text + "_" + txt_ad.Text + "_" + txt_soyadı.Text + ".pdf"; //Benzersiz isim verme

                        DosyaYolu = @"C://Dosyalar//Havuz//" + yeniad;

                        lnk_lbl_1.Text = kayitokuma.GetValue(3).ToString();
                        if (flag == 1)
                        {
                            System.Diagnostics.Process.Start(DosyaYolu);
                        }

                    }
                    lnk_lbl_1.Text = kayitokuma.GetValue(3).ToString();

                    if (kayitokuma.GetValue(14).ToString() == cx_engel_var.Text)
                    {
                        cx_engel_var.Checked = true;
                        cx_engel_yok.Checked = false;
                    }
                    else
                    {
                        cx_engel_yok.Checked = true;
                        cx_engel_var.Checked = false;
                    }

                    if (kayitokuma.GetValue(15).ToString() == cx_sey_e.Text)
                    {
                        cx_sey_e.Checked = true;
                        cx_sey_h.Checked = false;
                    }
                    else
                    {
                        cx_sey_e.Checked = false;
                        cx_sey_h.Checked = true;
                    }
                    if (kayitokuma.GetValue(16).ToString() == cx_cocuk_var.Text)
                    {
                        cx_cocuk_var.Checked = true;
                        cx_cocuk_yok.Checked = false;
                    }
                    else
                    {
                        cx_cocuk_var.Checked = false;
                        cx_cocuk_yok.Checked = true;
                    }

                    numeric_cocuk_sayisi.Value = kayitokuma.GetInt32(17);

                    if (kayitokuma.GetValue(18).ToString() == cx_sektor_var.Text)
                    {
                        cx_sektor_var.Checked = true;
                        cx_sektor_yok.Checked = false;
                    }
                    else
                    {
                        cx_sektor_var.Checked = false;
                        cx_sektor_yok.Checked = true;
                    }
                    date_kayit.Value = kayitokuma.GetDateTime(19);
                    txt_kariyerhedefi.Text = kayitokuma.GetValue(20).ToString();
                    txt_pozisyon.Text = kayitokuma.GetValue(21).ToString();
                    cbx_cinsiyet.Text = kayitokuma.GetValue(22).ToString();
                    cbx_medeni_hal.Text = kayitokuma.GetValue(23).ToString();
                    cbx_kan.Text = kayitokuma.GetValue(24).ToString();
                    txt_email.Text = kayitokuma.GetValue(25).ToString();
                    txt_tel_no.Text = kayitokuma.GetValue(26).ToString();

                    if (kayitokuma.GetValue(27).ToString() == cx_sabika_var.Text)
                    {
                        cx_sabika_var.Checked = true;
                        cx_sabika_yok.Checked = false;
                    }
                    else
                    {
                        cx_sabika_var.Checked = false;
                        cx_sabika_yok.Checked = true;
                    }

                    txt_ehliyet.Text = kayitokuma.GetValue(28).ToString();
                    txt_saglik.Text = kayitokuma.GetValue(29).ToString();

                    if (kayitokuma.GetValue(30).ToString() == cx_sigara_evet.Text)
                    {
                        cx_sigara_evet.Checked = true;
                        cx_sigara_hayır.Checked = false;
                    }
                    else
                    {
                        cx_sigara_evet.Checked = false;
                        cx_sigara_hayır.Checked = true;
                    }

                    if (kayitokuma.GetValue(31).ToString() == cx_alkol_evet.Text)
                    {
                        cx_alkol_evet.Checked = true;
                        cx_alkol_hayır.Checked = false;
                    }
                    else
                    {
                        cx_alkol_evet.Checked = false;
                        cx_alkol_hayır.Checked = true;
                    }

                    txt_ucret_beklentisi.Text = kayitokuma.GetValue(32).ToString();
                    cbx_e_seviye1.Text = kayitokuma.GetValue(33).ToString();
                    cbx_e_seviye2.Text = kayitokuma.GetValue(39).ToString();
                    cbx_e_seviye3.Text = kayitokuma.GetValue(45).ToString();
                    cbx_e_durum1.Text = kayitokuma.GetValue(34).ToString();
                    cbx_e_durum2.Text = kayitokuma.GetValue(40).ToString();
                    cbx_e_durum3.Text = kayitokuma.GetValue(46).ToString();
                    txt_e_okul1.Text = kayitokuma.GetValue(35).ToString();
                    txt_e_okul2.Text = kayitokuma.GetValue(41).ToString();
                    txt_e_okul3.Text = kayitokuma.GetValue(47).ToString();
                    txt_e_bolum1.Text = kayitokuma.GetValue(36).ToString();
                    txt_e_bolum2.Text = kayitokuma.GetValue(42).ToString();
                    txt_e_bolum3.Text = kayitokuma.GetValue(48).ToString();
                    date_mezuniyet1.Value = kayitokuma.GetDateTime(37);
                    date_mezuniyet2.Value = kayitokuma.GetDateTime(43);
                    date_mezuniyet3.Value = kayitokuma.GetDateTime(49);
                    txt_not1.Text = kayitokuma.GetValue(38).ToString();
                    txt_not2.Text = kayitokuma.GetValue(44).ToString();
                    txt_not3.Text = kayitokuma.GetValue(50).ToString();
                    txt_yer1.Text = kayitokuma.GetValue(51).ToString();
                    txt_yer2.Text = kayitokuma.GetValue(52).ToString();
                    txt_yer3.Text = kayitokuma.GetValue(53).ToString();
                    txt_gorev1.Text = kayitokuma.GetValue(54).ToString();
                    txt_gorev2.Text = kayitokuma.GetValue(55).ToString();
                    txt_gorev3.Text = kayitokuma.GetValue(56).ToString();
                    date_giris_1.Value = kayitokuma.GetDateTime(57);
                    date_giris_2.Value = kayitokuma.GetDateTime(58);
                    date_giris_3.Value = kayitokuma.GetDateTime(59);
                    date_cikis_1.Value = kayitokuma.GetDateTime(60);
                    date_cikis_2.Value = kayitokuma.GetDateTime(61);
                    date_cikis_3.Value = kayitokuma.GetDateTime(62);
                    txt_neden1.Text = kayitokuma.GetValue(63).ToString();
                    txt_neden2.Text = kayitokuma.GetValue(64).ToString();
                    txt_neden3.Text = kayitokuma.GetValue(65).ToString();
                    txt_ref1.Text = kayitokuma.GetValue(66).ToString();
                    txt_ref2.Text = kayitokuma.GetValue(67).ToString();
                    txt_ref3.Text = kayitokuma.GetValue(68).ToString();
                    txt_iletisim1.Text = kayitokuma.GetValue(69).ToString();
                    txt_iletisim2.Text = kayitokuma.GetValue(70).ToString();
                    txt_iletisim3.Text = kayitokuma.GetValue(71).ToString();
                    cbx_dil1.Text = kayitokuma.GetValue(72).ToString();
                    cbx_dil2.Text = kayitokuma.GetValue(73).ToString();
                    cbx_dil3.Text = kayitokuma.GetValue(74).ToString();
                    cbx_dil_sev1.Text = kayitokuma.GetValue(75).ToString();
                    cbx_dil_sev2.Text = kayitokuma.GetValue(76).ToString();
                    cbx_dil_sev3.Text = kayitokuma.GetValue(77).ToString();
                    txt_program1.Text = kayitokuma.GetValue(78).ToString();
                    txt_program2.Text = kayitokuma.GetValue(79).ToString();
                    txt_program3.Text = kayitokuma.GetValue(80).ToString();
                    cbx_bil_sev1.Text = kayitokuma.GetValue(81).ToString();
                    cbx_bil_sev2.Text = kayitokuma.GetValue(82).ToString();
                    cbx_bil_sev3.Text = kayitokuma.GetValue(83).ToString();
                    txt_sertifika1.Text = kayitokuma.GetValue(84).ToString();
                    txt_sertifika2.Text = kayitokuma.GetValue(85).ToString();
                    txt_sertifika3.Text = kayitokuma.GetValue(86).ToString();
                    txt_sertifikaa1.Text = kayitokuma.GetValue(87).ToString();
                    txt_sertifikaa2.Text = kayitokuma.GetValue(88).ToString();
                    txt_sertifikaa3.Text = kayitokuma.GetValue(89).ToString();
                    txt_sertifika_kurum1.Text = kayitokuma.GetValue(90).ToString();
                    txt_sertifika_kurum2.Text = kayitokuma.GetValue(91).ToString();
                    txt_sertifika_kurum3.Text = kayitokuma.GetValue(92).ToString();
                    date_sertifika1.Value = kayitokuma.GetDateTime(93);
                    date_sertifika2.Value = kayitokuma.GetDateTime(94);
                    date_sertifika3.Value = kayitokuma.GetDateTime(95);

                    resim_goruntule();
                    break;
                }
            }

        }

        string engelDurumu, seyehatDurumu, cocukDurumu, sektorTecrube, sabikaKaydi, sigaraDurumu, alkolDurumu;

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from tbl_havuz where kisi_tc='" + txt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.
            if (kayitarama == true)
            {
                MessageBox.Show("Personel kaydı mevcuttur");


            }
            else
            {

                //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.
                if (cx_engel_yok.Checked == true)
                {
                    cx_engel_var.Checked = false;
                    cx_engel_yok.Checked = true;
                    engelDurumu = cx_engel_yok.Text;
                }
                else
                {
                    cx_engel_var.Checked = true;
                    cx_engel_yok.Checked = false;
                    engelDurumu = cx_engel_var.Text;
                }

                if (cx_sey_e.Checked == true)
                {
                    cx_sey_h.Checked = false;
                    seyehatDurumu = cx_sey_e.Text;
                }
                else
                {
                    cx_sey_h.Checked = true;
                    cx_sey_e.Checked = false;
                    seyehatDurumu = cx_sey_h.Text;
                }

                if (cx_cocuk_var.Checked == true)
                {
                    cx_cocuk_yok.Checked = false;
                    cocukDurumu = cx_cocuk_var.Text;
                }
                else
                {
                    cx_cocuk_yok.Checked = true;
                    cx_cocuk_var.Checked = false;
                    cocukDurumu = cx_cocuk_yok.Text;
                }

                if (cx_sektor_var.Checked == true)
                {
                    cx_sektor_yok.Checked = false;
                    sektorTecrube = cx_sektor_var.Text;
                }
                else
                {
                    cx_sektor_yok.Checked = true;
                    cx_sektor_var.Checked = false;
                    sektorTecrube = cx_sektor_yok.Text;
                }

                if (cx_sabika_var.Checked == true)
                {
                    cx_sabika_yok.Checked = false;
                    sabikaKaydi = cx_sabika_var.Text;
                }
                else
                {
                    cx_sabika_yok.Checked = true;
                    cx_sabika_var.Checked = false;
                    sabikaKaydi = cx_sabika_yok.Text;
                }

                if (cx_sigara_evet.Checked == true)
                {
                    cx_sigara_hayır.Checked = false;
                    sigaraDurumu = cx_sigara_evet.Text;
                }
                else
                {
                    cx_sigara_hayır.Checked = true;
                    cx_sigara_evet.Checked = false;
                    sigaraDurumu = cx_sigara_hayır.Text;
                }

                if (cx_alkol_evet.Checked == true)
                {
                    cx_alkol_hayır.Checked = false;
                    alkolDurumu = cx_alkol_evet.Text;
                }
                else
                {
                    cx_alkol_hayır.Checked = true;
                    cx_alkol_evet.Checked = false;
                    alkolDurumu = cx_alkol_hayır.Text;
                }

                if (txt_baslik.Text == "")
                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;

                if (txt_cvdosya.Text == "")
                    label2.ForeColor = Color.Red;
                else
                    label2.ForeColor = Color.Black;

                if (cbx_calisma_sekli.Text == "Seçiniz...")
                    label3.ForeColor = Color.Red;
                else
                    label3.ForeColor = Color.Black;

                if (txt_tc_no.Text.Length < 11 || txt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                    label4.ForeColor = Color.Red;
                else
                    label4.ForeColor = Color.Black;


                if (txt_ad.Text == "" && txt_ad.Text.Length < 2)
                    label5.ForeColor = Color.Red;
                else
                    label5.ForeColor = Color.Black;

                if (txt_soyadı.Text == "" && txt_soyadı.Text.Length < 2)
                    label6.ForeColor = Color.Red;
                else
                    label6.ForeColor = Color.Black;


                if (txt_dogum.Text == "" && txt_dogum.Text.Length < 2)
                    label8.ForeColor = Color.Red;
                else
                    label8.ForeColor = Color.Black;


                if (txt_uyruk.Text == "" && txt_uyruk.Text.Length < 2)
                    label13.ForeColor = Color.Red;
                else
                    label13.ForeColor = Color.Black;

                if (cbx_askerlik.Text == "" || cbx_askerlik.Text == "Seçiniz...")
                    label9.ForeColor = Color.Red;
                else
                    label9.ForeColor = Color.Black;

                if (cbx_askerlik.Text == "Muaf")
                    date_askerlik.Visible = false;
                else
                    date_askerlik.Visible = true;


                if (txt_adres.Text == "" && txt_adres.Text.Length < 2)
                    label11.ForeColor = Color.Red;
                else
                    label11.ForeColor = Color.Black;

                if (txt_saglik.Text == "" && txt_saglik.Text.Length < 2)
                    label15.ForeColor = Color.Red;
                else
                    label15.ForeColor = Color.Black;


                if (txt_tel_no.Text == "" && txt_tel_no.Text.Length != 11)
                    label26.ForeColor = Color.Red;
                else
                    label26.ForeColor = Color.Black;


                if (txt_email.Text == "")
                    label25.ForeColor = Color.Red;
                else
                    label25.ForeColor = Color.Black;


                if (cbx_kan.Text == "" || cbx_kan.Text == "Seçiniz...")
                    label24.ForeColor = Color.Red;
                else
                    label24.ForeColor = Color.Black;


                if (cbx_medeni_hal.Text == "" || cbx_medeni_hal.Text == "Seçiniz...")
                    label22.ForeColor = Color.Red;
                else
                    label22.ForeColor = Color.Black;

                if (cbx_cinsiyet.Text == "" || cbx_cinsiyet.Text == "Seçiniz...")
                    label21.ForeColor = Color.Red;
                else
                    label21.ForeColor = Color.Black;

                if (txt_pozisyon.Text == "")
                    label20.ForeColor = Color.Red;
                else
                    label20.ForeColor = Color.Black;

                if (txt_kariyerhedefi.Text == "")
                    label19.ForeColor = Color.Red;
                else
                    label19.ForeColor = Color.Black;


                if (cbx_e_seviye1.Text != "Seçiniz...")
                {
                    if (cbx_e_durum1.Text == "Seçiniz...")
                        label61.ForeColor = Color.Red;
                    else
                        label61.ForeColor = Color.Black;
                    if (txt_e_okul1.Text == "")
                        label55.ForeColor = Color.Red;
                    else
                        label55.ForeColor = Color.Black;
                    if (txt_e_bolum1.Text == "")
                        label54.ForeColor = Color.Red;
                    else
                        label54.ForeColor = Color.Black;
                    if (txt_not1.Text == "")
                        label52.ForeColor = Color.Red;
                    else
                        label52.ForeColor = Color.Black;
                }
                if (cbx_e_durum1.Text != "Seçiniz...")
                {
                    if (cbx_e_seviye1.Text == "Seçiniz...")
                        label61.ForeColor = Color.Red;
                    else
                        label61.ForeColor = Color.Black;
                    if (txt_e_okul1.Text == "")
                        label55.ForeColor = Color.Red;
                    else
                        label55.ForeColor = Color.Black;
                    if (txt_e_bolum1.Text == "")
                        label54.ForeColor = Color.Red;
                    else
                        label54.ForeColor = Color.Black;
                    if (txt_not1.Text == "")
                        label52.ForeColor = Color.Red;
                    else
                        label52.ForeColor = Color.Black;
                }
                if (txt_e_okul1.Text != "" || txt_e_okul1.Text.Length > 2)
                {
                    if (cbx_e_seviye1.Text == "Seçiniz...")
                        label61.ForeColor = Color.Red;
                    else
                        label61.ForeColor = Color.Black;
                    if (cbx_e_durum1.Text == "Seçiniz...")
                        label55.ForeColor = Color.Red;
                    else
                        label55.ForeColor = Color.Black;
                    if (txt_e_bolum1.Text == "")
                        label54.ForeColor = Color.Red;
                    else
                        label54.ForeColor = Color.Black;
                    if (txt_not1.Text == "")
                        label52.ForeColor = Color.Red;
                    else
                        label52.ForeColor = Color.Black;
                }
                if (txt_e_bolum1.Text != "" || txt_e_bolum1.Text.Length > 2)
                {
                    if (cbx_e_seviye1.Text == "Seçiniz...")
                        label61.ForeColor = Color.Red;
                    else
                        label61.ForeColor = Color.Black;
                    if (cbx_e_durum1.Text == "Seçiniz...")
                        label55.ForeColor = Color.Red;
                    else
                        label55.ForeColor = Color.Black;
                    if (txt_e_okul1.Text == "")
                        label54.ForeColor = Color.Red;
                    else
                        label54.ForeColor = Color.Black;
                    if (txt_not1.Text == "")
                        label52.ForeColor = Color.Red;
                    else
                        label52.ForeColor = Color.Black;
                }
                if (txt_not1.Text != "")
                {
                    if (cbx_e_seviye1.Text == "Seçiniz...")
                        label61.ForeColor = Color.Red;
                    else
                        label61.ForeColor = Color.Black;
                    if (cbx_e_durum1.Text == "Seçiniz...")
                        label55.ForeColor = Color.Red;
                    else
                        label55.ForeColor = Color.Black;
                    if (txt_e_okul1.Text == "")
                        label54.ForeColor = Color.Red;
                    else
                        label54.ForeColor = Color.Black;
                    if (txt_e_bolum1.Text == "")
                        label52.ForeColor = Color.Red;
                    else
                        label52.ForeColor = Color.Black;
                }

                if (cbx_e_seviye2.Text != "Seçiniz...")
                {
                    if (cbx_e_durum2.Text == "Seçiniz...")
                        label61.ForeColor = Color.Red;
                    else
                        label61.ForeColor = Color.Black;
                    if (txt_e_okul2.Text == "")
                        label55.ForeColor = Color.Red;
                    else
                        label55.ForeColor = Color.Black;
                    if (txt_e_bolum2.Text == "")
                        label54.ForeColor = Color.Red;
                    else
                        label54.ForeColor = Color.Black;
                    if (txt_not2.Text == "")
                        label52.ForeColor = Color.Red;
                    else
                        label52.ForeColor = Color.Black;
                }
                if (cbx_e_durum2.Text != "Seçiniz...")
                {
                    if (cbx_e_seviye2.Text == "Seçiniz...")
                        label61.ForeColor = Color.Red;
                    else
                        label61.ForeColor = Color.Black;
                    if (txt_e_okul2.Text == "")
                        label55.ForeColor = Color.Red;
                    else
                        label55.ForeColor = Color.Black;
                    if (txt_e_bolum2.Text == "")
                        label54.ForeColor = Color.Red;
                    else
                        label54.ForeColor = Color.Black;
                    if (txt_not2.Text == "")
                        label52.ForeColor = Color.Red;
                    else
                        label52.ForeColor = Color.Black;
                }
                if (txt_e_okul2.Text != "" || txt_e_okul2.Text.Length > 2)
                {
                    if (cbx_e_seviye2.Text == "Seçiniz...")
                        label61.ForeColor = Color.Red;
                    else
                        label61.ForeColor = Color.Black;
                    if (cbx_e_durum2.Text == "Seçiniz...")
                        label55.ForeColor = Color.Red;
                    else
                        label55.ForeColor = Color.Black;
                    if (txt_e_bolum2.Text == "")
                        label54.ForeColor = Color.Red;
                    else
                        label54.ForeColor = Color.Black;
                    if (txt_not2.Text == "")
                        label52.ForeColor = Color.Red;
                    else
                        label52.ForeColor = Color.Black;
                }
                if (txt_e_bolum2.Text != "" || txt_e_bolum2.Text.Length > 2)
                {
                    if (cbx_e_seviye2.Text == "Seçiniz...")
                        label61.ForeColor = Color.Red;
                    else
                        label61.ForeColor = Color.Black;
                    if (cbx_e_durum2.Text == "Seçiniz...")
                        label55.ForeColor = Color.Red;
                    else
                        label55.ForeColor = Color.Black;
                    if (txt_e_okul2.Text == "")
                        label54.ForeColor = Color.Red;
                    else
                        label54.ForeColor = Color.Black;
                    if (txt_not2.Text == "")
                        label52.ForeColor = Color.Red;
                    else
                        label52.ForeColor = Color.Black;
                }
                if (txt_not2.Text != "")
                {
                    if (cbx_e_seviye2.Text == "Seçiniz...")
                        label61.ForeColor = Color.Red;
                    else
                        label61.ForeColor = Color.Black;
                    if (cbx_e_durum2.Text == "Seçiniz...")
                        label55.ForeColor = Color.Red;
                    else
                        label55.ForeColor = Color.Black;
                    if (txt_e_okul2.Text == "")
                        label54.ForeColor = Color.Red;
                    else
                        label54.ForeColor = Color.Black;
                    if (txt_e_bolum2.Text == "")
                        label52.ForeColor = Color.Red;
                    else
                        label52.ForeColor = Color.Black;
                }

                if (cbx_e_seviye3.Text != "Seçiniz...")
                {
                    if (cbx_e_durum3.Text == "Seçiniz...")
                        label61.ForeColor = Color.Red;
                    else
                        label61.ForeColor = Color.Black;
                    if (txt_e_okul3.Text == "")
                        label55.ForeColor = Color.Red;
                    else
                        label55.ForeColor = Color.Black;
                    if (txt_e_bolum3.Text == "")
                        label54.ForeColor = Color.Red;
                    else
                        label54.ForeColor = Color.Black;
                    if (txt_not3.Text == "")
                        label52.ForeColor = Color.Red;
                    else
                        label52.ForeColor = Color.Black;
                }
                if (cbx_e_durum3.Text != "Seçiniz...")
                {
                    if (cbx_e_seviye3.Text == "Seçiniz...")
                        label61.ForeColor = Color.Red;
                    else
                        label61.ForeColor = Color.Black;
                    if (txt_e_okul3.Text == "")
                        label55.ForeColor = Color.Red;
                    else
                        label55.ForeColor = Color.Black;
                    if (txt_e_bolum3.Text == "")
                        label54.ForeColor = Color.Red;
                    else
                        label54.ForeColor = Color.Black;
                    if (txt_not3.Text == "")
                        label52.ForeColor = Color.Red;
                    else
                        label52.ForeColor = Color.Black;
                }
                if (txt_e_okul3.Text != "" || txt_e_okul3.Text.Length > 2)
                {
                    if (cbx_e_seviye3.Text == "Seçiniz...")
                        label61.ForeColor = Color.Red;
                    else
                        label61.ForeColor = Color.Black;
                    if (cbx_e_durum3.Text == "Seçiniz...")
                        label55.ForeColor = Color.Red;
                    else
                        label55.ForeColor = Color.Black;
                    if (txt_e_bolum3.Text == "")
                        label54.ForeColor = Color.Red;
                    else
                        label54.ForeColor = Color.Black;
                    if (txt_not3.Text == "")
                        label52.ForeColor = Color.Red;
                    else
                        label52.ForeColor = Color.Black;
                }
                if (txt_e_bolum3.Text != "" || txt_e_bolum3.Text.Length > 2)
                {
                    if (cbx_e_seviye3.Text == "Seçiniz...")
                        label61.ForeColor = Color.Red;
                    else
                        label61.ForeColor = Color.Black;
                    if (cbx_e_durum3.Text == "Seçiniz...")
                        label55.ForeColor = Color.Red;
                    else
                        label55.ForeColor = Color.Black;
                    if (txt_e_okul3.Text == "")
                        label54.ForeColor = Color.Red;
                    else
                        label54.ForeColor = Color.Black;
                    if (txt_not3.Text == "")
                        label52.ForeColor = Color.Red;
                    else
                        label52.ForeColor = Color.Black;
                }
                if (txt_not3.Text != "")
                {
                    if (cbx_e_seviye3.Text == "Seçiniz...")
                        label61.ForeColor = Color.Red;
                    else
                        label61.ForeColor = Color.Black;
                    if (cbx_e_durum3.Text == "Seçiniz...")
                        label55.ForeColor = Color.Red;
                    else
                        label55.ForeColor = Color.Black;
                    if (txt_e_okul3.Text == "")
                        label54.ForeColor = Color.Red;
                    else
                        label54.ForeColor = Color.Black;
                    if (txt_e_bolum3.Text == "")
                        label52.ForeColor = Color.Red;
                    else
                        label52.ForeColor = Color.Black;
                }


                if (txt_yer1.Text != "" && txt_yer1.Text.Length >= 2)
                {
                    if (txt_gorev1.Text == "" && txt_gorev1.Text.Length < 2)
                        label85.ForeColor = Color.Red;
                    else
                        label85.ForeColor = Color.Black;

                    if (txt_neden1.Text == "" && txt_neden1.Text.Length < 2)
                        label82.ForeColor = Color.Red;
                    else
                        label82.ForeColor = Color.Black;
                }
                if (txt_gorev1.Text != "" && txt_gorev1.Text.Length >= 2)
                {
                    if (txt_yer1.Text == "" && txt_yer1.Text.Length < 2)
                        label86.ForeColor = Color.Red;
                    else
                        label86.ForeColor = Color.Black;
                    if (txt_neden1.Text == "" && txt_neden1.Text.Length < 2)
                        label82.ForeColor = Color.Red;
                    else
                        label82.ForeColor = Color.Black;
                }
                if (txt_neden1.Text != "" && txt_neden1.Text.Length >= 2)
                {
                    if (txt_yer1.Text == "" && txt_yer1.Text.Length < 2)
                        label86.ForeColor = Color.Red;
                    else
                        label86.ForeColor = Color.Black;

                    if (txt_gorev1.Text == "" && txt_gorev1.Text.Length < 2)
                        label85.ForeColor = Color.Red;
                    else
                        label85.ForeColor = Color.Black;
                }
                if (txt_ref1.Text != "" && txt_ref1.Text.Length > 2)
                {
                    if (txt_yer1.Text == "" && txt_yer1.Text.Length < 2)
                        label86.ForeColor = Color.Red;
                    else
                        label86.ForeColor = Color.Black;

                    if (txt_gorev1.Text == "" && txt_gorev1.Text.Length < 2)
                        label85.ForeColor = Color.Red;
                    else
                        label85.ForeColor = Color.Black;
                    if (txt_neden1.Text == "" && txt_neden1.Text.Length < 2)
                        label82.ForeColor = Color.Red;
                    else
                        label82.ForeColor = Color.Black;

                }
                if (txt_iletisim1.Text != "" && txt_iletisim1.Text.Length == 11)
                {
                    if (txt_yer1.Text == "" && txt_yer1.Text.Length < 2)
                        label86.ForeColor = Color.Red;
                    else
                        label86.ForeColor = Color.Black;

                    if (txt_gorev1.Text == "" && txt_gorev1.Text.Length < 2)
                        label85.ForeColor = Color.Red;
                    else
                        label85.ForeColor = Color.Black;
                    if (txt_neden1.Text == "" && txt_neden1.Text.Length < 2)
                        label82.ForeColor = Color.Red;
                    else
                        label82.ForeColor = Color.Black;
                    if (txt_ref1.Text == "" && txt_ref1.Text.Length < 2)
                        label81.ForeColor = Color.Red;
                    else
                        label81.ForeColor = Color.Black;
                }

                if (txt_yer2.Text != "" && txt_yer2.Text.Length >= 2)
                {
                    if (txt_gorev2.Text == "" && txt_gorev2.Text.Length < 2)
                        label85.ForeColor = Color.Red;
                    else
                        label85.ForeColor = Color.Black;

                    if (txt_neden2.Text == "" && txt_neden2.Text.Length < 2)
                        label82.ForeColor = Color.Red;
                    else
                        label82.ForeColor = Color.Black;
                }
                if (txt_gorev2.Text != "" && txt_gorev2.Text.Length >= 2)
                {
                    if (txt_yer2.Text == "" && txt_yer2.Text.Length < 2)
                        label86.ForeColor = Color.Red;
                    else
                        label86.ForeColor = Color.Black;
                    if (txt_neden2.Text == "" && txt_neden2.Text.Length < 2)
                        label82.ForeColor = Color.Red;
                    else
                        label82.ForeColor = Color.Black;
                }
                if (txt_neden2.Text != "" && txt_neden2.Text.Length >= 2)
                {
                    if (txt_yer2.Text == "" && txt_yer2.Text.Length < 2)
                        label86.ForeColor = Color.Red;
                    else
                        label86.ForeColor = Color.Black;

                    if (txt_gorev2.Text == "" && txt_gorev2.Text.Length < 2)
                        label85.ForeColor = Color.Red;
                    else
                        label85.ForeColor = Color.Black;
                }
                if (txt_ref2.Text != "" && txt_ref2.Text.Length > 2)
                {
                    if (txt_yer2.Text == "" && txt_yer2.Text.Length < 2)
                        label86.ForeColor = Color.Red;
                    else
                        label86.ForeColor = Color.Black;

                    if (txt_gorev2.Text == "" && txt_gorev2.Text.Length < 2)
                        label85.ForeColor = Color.Red;
                    else
                        label85.ForeColor = Color.Black;
                    if (txt_neden2.Text == "" && txt_neden2.Text.Length < 2)
                        label82.ForeColor = Color.Red;
                    else
                        label82.ForeColor = Color.Black;

                }
                if (txt_iletisim2.Text != "" && txt_iletisim2.Text.Length == 11)
                {
                    if (txt_yer2.Text == "" && txt_yer2.Text.Length < 2)
                        label86.ForeColor = Color.Red;
                    else
                        label86.ForeColor = Color.Black;

                    if (txt_gorev2.Text == "" && txt_gorev2.Text.Length < 2)
                        label85.ForeColor = Color.Red;
                    else
                        label85.ForeColor = Color.Black;
                    if (txt_neden2.Text == "" && txt_neden2.Text.Length < 2)
                        label82.ForeColor = Color.Red;
                    else
                        label82.ForeColor = Color.Black;
                    if (txt_ref2.Text == "" && txt_ref2.Text.Length < 2)
                        label81.ForeColor = Color.Red;
                    else
                        label81.ForeColor = Color.Black;
                }


                if (txt_yer3.Text != "" && txt_yer3.Text.Length >= 2)
                {
                    if (txt_gorev3.Text == "" && txt_gorev3.Text.Length < 2)
                        label85.ForeColor = Color.Red;
                    else
                        label85.ForeColor = Color.Black;

                    if (txt_neden3.Text == "" && txt_neden3.Text.Length < 2)
                        label82.ForeColor = Color.Red;
                    else
                        label82.ForeColor = Color.Black;
                }
                if (txt_gorev3.Text != "" && txt_gorev3.Text.Length >= 2)
                {
                    if (txt_yer3.Text == "" && txt_yer3.Text.Length < 2)
                        label86.ForeColor = Color.Red;
                    else
                        label86.ForeColor = Color.Black;
                    if (txt_neden3.Text == "" && txt_neden3.Text.Length < 2)
                        label82.ForeColor = Color.Red;
                    else
                        label82.ForeColor = Color.Black;
                }
                if (txt_neden3.Text != "" && txt_neden3.Text.Length >= 2)
                {
                    if (txt_yer3.Text == "" && txt_yer3.Text.Length < 2)
                        label86.ForeColor = Color.Red;
                    else
                        label86.ForeColor = Color.Black;

                    if (txt_gorev3.Text == "" && txt_gorev3.Text.Length < 2)
                        label85.ForeColor = Color.Red;
                    else
                        label85.ForeColor = Color.Black;
                }
                if (txt_ref3.Text != "" && txt_ref3.Text.Length > 2)
                {
                    if (txt_yer3.Text == "" && txt_yer3.Text.Length < 2)
                        label86.ForeColor = Color.Red;
                    else
                        label86.ForeColor = Color.Black;

                    if (txt_gorev3.Text == "" && txt_gorev3.Text.Length < 2)
                        label85.ForeColor = Color.Red;
                    else
                        label85.ForeColor = Color.Black;
                    if (txt_neden3.Text == "" && txt_neden3.Text.Length < 2)
                        label82.ForeColor = Color.Red;
                    else
                        label82.ForeColor = Color.Black;

                }
                if (txt_iletisim3.Text != "" && txt_iletisim3.Text.Length == 11)
                {
                    if (txt_yer3.Text == "" && txt_yer3.Text.Length < 2)
                        label86.ForeColor = Color.Red;
                    else
                        label86.ForeColor = Color.Black;

                    if (txt_gorev3.Text == "" && txt_gorev3.Text.Length < 2)
                        label85.ForeColor = Color.Red;
                    else
                        label85.ForeColor = Color.Black;
                    if (txt_neden3.Text == "" && txt_neden3.Text.Length < 2)
                        label82.ForeColor = Color.Red;
                    else
                        label82.ForeColor = Color.Black;
                    if (txt_ref3.Text == "" && txt_ref3.Text.Length < 2)
                        label81.ForeColor = Color.Red;
                    else
                        label81.ForeColor = Color.Black;
                }


                if (cbx_dil_sev1.Text != "Seçiniz...")
                {
                    if (cbx_dil1.Text == "Seçiniz...")
                        label91.ForeColor = Color.Red;
                    else
                        label91.ForeColor = Color.Black;
                }
                else//dil seçmiş ise
                {
                    if (cbx_dil_sev1.Text == "Seçiniz...")
                        label90.ForeColor = Color.Red;
                    else
                        label90.ForeColor = Color.Black;
                }
                if (cbx_dil_sev2.Text != "Seçiniz...")
                {
                    if (cbx_dil2.Text == "Seçiniz...")
                        label91.ForeColor = Color.Red;
                    else
                        label91.ForeColor = Color.Black;
                }
                else//dil seçmiş ise
                {
                    if (cbx_dil_sev2.Text == "Seçiniz...")
                        label90.ForeColor = Color.Red;
                    else
                        label90.ForeColor = Color.Black;
                }
                if (cbx_dil_sev3.Text != "Seçiniz...")
                {
                    if (cbx_dil3.Text == "Seçiniz...")
                        label91.ForeColor = Color.Red;
                    else
                        label91.ForeColor = Color.Black;
                }
                else//dil seçmiş ise
                {
                    if (cbx_dil_sev3.Text == "Seçiniz...")
                        label90.ForeColor = Color.Red;
                    else
                        label90.ForeColor = Color.Black;
                }

                if (txt_program1.Text != "" && txt_program1.Text.Length >= 2)
                {
                    if (cbx_bil_sev1.Text == "Seçiniz...")
                        label95.ForeColor = Color.Red;
                    else
                        label95.ForeColor = Color.Black;
                }
                else
                {
                    if (cbx_bil_sev1.Text != "Seçiniz...")
                        label96.ForeColor = Color.Red;
                    else
                        label96.ForeColor = Color.Black;
                }

                if (txt_program2.Text != "" && txt_program2.Text.Length >= 2)
                {
                    if (cbx_bil_sev2.Text == "Seçiniz...")
                        label95.ForeColor = Color.Red;
                    else
                        label95.ForeColor = Color.Black;
                }
                else
                {
                    if (cbx_bil_sev2.Text != "Seçiniz...")
                        label96.ForeColor = Color.Red;
                    else
                        label96.ForeColor = Color.Black;
                }

                if (txt_program3.Text != "" && txt_program3.Text.Length >= 2)
                {
                    if (cbx_bil_sev3.Text == "Seçiniz...")
                        label95.ForeColor = Color.Red;
                    else
                        label95.ForeColor = Color.Black;
                }
                else
                {
                    if (cbx_bil_sev3.Text != "Seçiniz...")
                        label96.ForeColor = Color.Red;
                    else
                        label96.ForeColor = Color.Black;
                }


                if (txt_sertifika1.Text != "" && txt_sertifika1.Text.Length >= 2)
                {
                    if (txt_sertifikaa1.Text != "" && txt_sertifikaa1.Text.Length >= 2)

                        label102.ForeColor = Color.Black;
                    else
                        label102.ForeColor = Color.Red;
                    if (txt_sertifika_kurum1.Text != "" && txt_sertifika_kurum1.Text.Length >= 2)
                        label101.ForeColor = Color.Black;

                    else
                        label101.ForeColor = Color.Red;
                }

                if (txt_sertifikaa1.Text != "" && txt_sertifikaa1.Text.Length >= 2)
                {
                    if (txt_sertifika1.Text != "" && txt_sertifika1.Text.Length >= 2)

                        label103.ForeColor = Color.Black;
                    else
                        label103.ForeColor = Color.Red;
                    if (txt_sertifika_kurum1.Text != "" && txt_sertifika_kurum1.Text.Length >= 2)
                        label101.ForeColor = Color.Black;

                    else
                        label101.ForeColor = Color.Red;
                }
                if (txt_sertifika_kurum1.Text != "" && txt_sertifika_kurum1.Text.Length >= 2)
                {
                    if (txt_sertifika1.Text != "" && txt_sertifika1.Text.Length >= 2)

                        label103.ForeColor = Color.Black;
                    else
                        label103.ForeColor = Color.Red;
                    if (txt_sertifikaa1.Text != "" && txt_sertifikaa1.Text.Length >= 2)
                        label102.ForeColor = Color.Black;

                    else
                        label102.ForeColor = Color.Red;
                }

                if (txt_baslik.Text != "" && cbx_calisma_sekli.Text != "" && txt_tc_no.Text.Length == 11 && txt_ad.Text.Length >= 2 &&
                   txt_soyadı.Text.Length >= 2 && txt_dogum.Text.Length >= 2 && txt_adres.Text.Length >= 2
                    && txt_uyruk.Text != "" && cbx_askerlik.Text != "Seçiniz..." && txt_saglik.Text.Length >= 2 &&
                    txt_kariyerhedefi.Text != "" && txt_pozisyon.Text != "" && cbx_cinsiyet.Text != "Seçiniz..." && txt_tel_no.Text.Length == 11 &&
                    cbx_medeni_hal.Text != "Seçiniz..." && cbx_kan.Text != "Seçiniz..." && txt_ucret_beklentisi.Text != "")
                {

                    FileStream fsResim = new FileStream(resimAdresi, FileMode.Open, FileAccess.Read);

                    BinaryReader brResim = new BinaryReader(fsResim);

                    byte[] resim = brResim.ReadBytes((int)fsResim.Length);

                    brResim.Close();
                    fsResim.Close();

                    //SqlCommand eklekomutu = new SqlCommand("Kaydet_havuz", baglantim.baglanti());
                    //eklekomutu.CommandType = CommandType.StoredProcedure;
                    SqlCommand eklekomutu = new SqlCommand("insert into tbl_havuz(resim, baslik, cvLinki, calismaSekli, kisi_tc, adi, soyadi, dogumTarihi, dogumYeri, uyruk, askerlik, askerlikTarihi, adres, engelDurumu, seyehat, cocukDurumu, cocukSayisi, sektörTecrübesi, kayitTarihi, kariyerHedefi, pozisyonTercihi, cinsiyet, medeniHal, kan, eposta, tel, sabikakaydı, sürücübelgesi, saglikSorunu, sigara, alkol, ücretBeklentisi, egitimSeviye1, egitimDurum1, egitimOkul1, egitimBolum1, mezuniyet1, notDurumu1, egitimSeviye2, egitimDurum2, egitimOkul2, egitimBolum2, mezuniyet2, notDurumu2, egitimSeviye3, egitimDurum3, egitimOkul3, egitimBolum3, mezuniyet3, notDurumu3, calistigiyer1, calistigiyer2, calistigiyer3, gorev1, gorev2, gorev3, cGirisTarihi1, cGirisTarihi2, cGirisTarihi3, cCikisTarihi1, cCikisTarihi2, cCikisTarihi3, cNeden1, cNeden2, cNeden3, cref1, cref2, cref3, ciletisim1, ciletisim2, ciletisim3, dil1, dil2, dil3, dilseviye1, dilseviye2, dilseviye3, program1, program2, program3, programseviye1, programseviye2, programseviye3, sertifika1, sertifika2, sertifika3, sertifikaa1, sertifikaa2, sertifikaa3, sertifikakurum1, sertifikakurum2, sertifikakurum3, sertifikatarih1, sertifikatarih2, sertifikatarih3) values (@resim, @baslik, @cvLinki, @calismaSekli, @kisi_tc, @adi, @soyadi, @dogumTarihi, @dogumYeri, @uyruk, @askerlik, @askerlikTarihi, @adres, @engelDurumu, @seyehat, @cocukDurumu, @cocukSayisi, @sektörTecrübesi, @kayitTarihi, @kariyerHedefi, @pozisyonTercihi, @cinsiyet, @medeniHal, @kan, @eposta, @tel, @sabikakaydı, @sürücübelgesi, @saglikSorunu, @sigara, @alkol, @ücretBeklentisi, @egitimSeviye1, @egitimDurum1, @egitimOkul1, @egitimBolum1, @mezuniyet1, @notDurumu1, @egitimSeviye2, @egitimDurum2, @egitimOkul2, @egitimBolum2, @mezuniyet2, @notDurumu2, @egitimSeviye3, @egitimDurum3, @egitimOkul3, @egitimBolum3, @mezuniyet3, @notDurumu3, @calistigiyer1, @calistigiyer2, @calistigiyer3, @gorev1, @gorev2, @gorev3, @cGirisTarihi1, @cGirisTarihi2, @cGirisTarihi3, @cCikisTarihi1, @cCikisTarihi2, @cCikisTarihi3, @cNeden1, @cNeden2, @cNeden3, @cref1, @cref2, @cref3, @ciletisim1, @ciletisim2, @ciletisim3, @dil1, @dil2, @dil3, @dilseviye1, @dilseviye2, @dilseviye3, @program1, @program2, @program3, @programseviye1, @programseviye2, @programseviye3, @sertifika1, @sertifika2, @sertifika3, @sertifikaa1, @sertifikaa2, @sertifikaa3, @sertifikakurum1, @sertifikakurum2, @sertifikakurum3, @sertifikatarih1, @sertifikatarih2, @sertifikatarih3)", baglantim.baglanti());

                    //eklekomutu.Parameters.Add("@TC", SqlDbType.NVarChar, 11).Value = tc_no.Text;

                    //cmdResimKaydet.Parameters.Add("@resim", SqlDbType.Image, resim.Length).Value = resim;

                    eklekomutu.Parameters.Add("@resim", SqlDbType.Image, resim.Length).Value = resim;
                    eklekomutu.Parameters.Add("@baslik", SqlDbType.NVarChar, 50).Value = txt_baslik.Text;
                    eklekomutu.Parameters.Add("@cvLinki", SqlDbType.NVarChar, 50).Value = lnk_lbl_1.Text;
                    eklekomutu.Parameters.Add("@calismaSekli", SqlDbType.NVarChar, 50).Value = cbx_calisma_sekli.Text;
                    eklekomutu.Parameters.Add("@kisi_tc", SqlDbType.NVarChar, 11).Value = txt_tc_no.Text;
                    eklekomutu.Parameters.Add("@adi", SqlDbType.NVarChar, 100).Value = txt_ad.Text;
                    eklekomutu.Parameters.Add("@soyadi", SqlDbType.NVarChar, 100).Value = txt_soyadı.Text;
                    eklekomutu.Parameters.Add("@dogumTarihi", SqlDbType.Date).Value = date_dogum.Value;
                    eklekomutu.Parameters.Add("@dogumYeri", SqlDbType.NVarChar, 100).Value = txt_dogum.Text;
                    eklekomutu.Parameters.Add("@uyruk", SqlDbType.NVarChar, 50).Value = txt_uyruk.Text;
                    eklekomutu.Parameters.Add("@askerlik", SqlDbType.NVarChar, 50).Value = cbx_askerlik.Text;
                    eklekomutu.Parameters.Add("@askerlikTarihi", SqlDbType.Date).Value = date_askerlik.Value;
                    eklekomutu.Parameters.Add("@adres", SqlDbType.NVarChar, 500).Value = txt_adres.Text;
                    eklekomutu.Parameters.Add("@engelDurumu", SqlDbType.NVarChar, 50).Value = engelDurumu;
                    eklekomutu.Parameters.Add("@seyehat", SqlDbType.NVarChar, 50).Value = seyehatDurumu;
                    eklekomutu.Parameters.Add("@cocukDurumu", SqlDbType.NVarChar, 50).Value = cocukDurumu;
                    eklekomutu.Parameters.Add("@cocukSayisi", SqlDbType.Int).Value = numeric_cocuk_sayisi.Value;
                    eklekomutu.Parameters.Add("@sektörTecrübesi", SqlDbType.NVarChar, 50).Value = sektorTecrube;
                    eklekomutu.Parameters.Add("@kayitTarihi", SqlDbType.Date).Value = date_kayit.Value;
                    eklekomutu.Parameters.Add("@kariyerHedefi", SqlDbType.NVarChar, 100).Value = txt_kariyerhedefi.Text;
                    eklekomutu.Parameters.Add("@pozisyonTercihi", SqlDbType.NVarChar, 500).Value = txt_pozisyon.Text;
                    eklekomutu.Parameters.Add("@cinsiyet", SqlDbType.NVarChar, 50).Value = cbx_cinsiyet.Text;
                    eklekomutu.Parameters.Add("@medeniHal", SqlDbType.NVarChar, 50).Value = cbx_medeni_hal.Text;
                    eklekomutu.Parameters.Add("@kan", SqlDbType.NVarChar, 50).Value = cbx_kan.Text;
                    eklekomutu.Parameters.Add("@eposta", SqlDbType.NVarChar, 500).Value = txt_email.Text;
                    eklekomutu.Parameters.Add("@tel", SqlDbType.NVarChar, 50).Value = txt_tel_no.Text;
                    eklekomutu.Parameters.Add("@sabikakaydı", SqlDbType.NVarChar, 50).Value = sabikaKaydi;
                    eklekomutu.Parameters.Add("@sürücübelgesi", SqlDbType.NVarChar, 50).Value = txt_ehliyet.Text;
                    eklekomutu.Parameters.Add("@saglikSorunu", SqlDbType.NVarChar, 500).Value = txt_saglik.Text;
                    eklekomutu.Parameters.Add("@sigara", SqlDbType.NVarChar, 50).Value = sigaraDurumu;
                    eklekomutu.Parameters.Add("@alkol", SqlDbType.NVarChar, 50).Value = alkolDurumu;
                    eklekomutu.Parameters.Add("@ücretBeklentisi", SqlDbType.Float).Value = txt_ucret_beklentisi.Text;
                    eklekomutu.Parameters.Add("@egitimSeviye1", SqlDbType.NVarChar, 50).Value = cbx_e_seviye1.Text;
                    eklekomutu.Parameters.Add("@egitimDurum1", SqlDbType.NVarChar, 50).Value = cbx_e_durum1.Text;
                    eklekomutu.Parameters.Add("@egitimOkul1", SqlDbType.NVarChar, 100).Value = txt_e_okul1.Text;
                    eklekomutu.Parameters.Add("@egitimBolum1", SqlDbType.NVarChar, 500).Value = txt_e_bolum1.Text;
                    eklekomutu.Parameters.Add("@mezuniyet1", SqlDbType.Date).Value = date_mezuniyet1.Text;
                    eklekomutu.Parameters.Add("@notDurumu1", SqlDbType.NVarChar, 50).Value = txt_not1.Text;
                    eklekomutu.Parameters.Add("@egitimSeviye2", SqlDbType.NVarChar, 50).Value = cbx_e_seviye2.Text;
                    eklekomutu.Parameters.Add("@egitimDurum2", SqlDbType.NVarChar, 50).Value = cbx_e_durum2.Text;
                    eklekomutu.Parameters.Add("@egitimOkul2", SqlDbType.NVarChar, 100).Value = txt_e_okul2.Text;
                    eklekomutu.Parameters.Add("@egitimBolum2", SqlDbType.NVarChar, 500).Value = txt_e_bolum2.Text;
                    eklekomutu.Parameters.Add("@mezuniyet2", SqlDbType.Date).Value = date_mezuniyet2.Value;
                    eklekomutu.Parameters.Add("@notDurumu2", SqlDbType.NVarChar, 50).Value = txt_not2.Text;
                    eklekomutu.Parameters.Add("@egitimSeviye3", SqlDbType.NVarChar, 50).Value = cbx_e_seviye3.Text;
                    eklekomutu.Parameters.Add("@egitimDurum3", SqlDbType.NVarChar, 50).Value = cbx_e_durum3.Text;
                    eklekomutu.Parameters.Add("@egitimOkul3", SqlDbType.NVarChar, 100).Value = txt_e_okul3.Text;
                    eklekomutu.Parameters.Add("@egitimBolum3", SqlDbType.NVarChar, 500).Value = txt_e_bolum3.Text;
                    eklekomutu.Parameters.Add("@mezuniyet3", SqlDbType.Date).Value = date_mezuniyet3.Text;
                    eklekomutu.Parameters.Add("@notDurumu3", SqlDbType.NVarChar, 50).Value = txt_not3.Text;
                    eklekomutu.Parameters.Add("@calistigiyer1", SqlDbType.NVarChar, 100).Value = txt_yer1.Text;
                    eklekomutu.Parameters.Add("@calistigiyer2", SqlDbType.NVarChar, 100).Value = txt_yer2.Text;
                    eklekomutu.Parameters.Add("@calistigiyer3", SqlDbType.NVarChar, 100).Value = txt_yer3.Text;
                    eklekomutu.Parameters.Add("@gorev1", SqlDbType.NVarChar, 100).Value = txt_gorev1.Text;
                    eklekomutu.Parameters.Add("@gorev2", SqlDbType.NVarChar, 100).Value = txt_gorev2.Text;
                    eklekomutu.Parameters.Add("@gorev3", SqlDbType.NVarChar, 100).Value = txt_gorev3.Text;
                    eklekomutu.Parameters.Add("@cGirisTarihi1", SqlDbType.Date).Value = date_giris_1.Value;
                    eklekomutu.Parameters.Add("@cGirisTarihi2", SqlDbType.Date).Value = date_giris_2.Value;
                    eklekomutu.Parameters.Add("@cGirisTarihi3", SqlDbType.Date).Value = date_giris_3.Value;
                    eklekomutu.Parameters.Add("@cCikisTarihi1", SqlDbType.Date).Value = date_cikis_1.Value;
                    eklekomutu.Parameters.Add("@cCikisTarihi2", SqlDbType.Date).Value = date_cikis_2.Value;
                    eklekomutu.Parameters.Add("@cCikisTarihi3", SqlDbType.Date).Value = date_cikis_3.Value;
                    eklekomutu.Parameters.Add("@cNeden1", SqlDbType.NVarChar, 100).Value = txt_neden1.Text;
                    eklekomutu.Parameters.Add("@cNeden2", SqlDbType.NVarChar, 100).Value = txt_neden2.Text;
                    eklekomutu.Parameters.Add("@cNeden3", SqlDbType.NVarChar, 100).Value = txt_neden3.Text;
                    eklekomutu.Parameters.Add("@cref1", SqlDbType.NVarChar, 100).Value = txt_ref1.Text;
                    eklekomutu.Parameters.Add("@cref2", SqlDbType.NVarChar, 100).Value = txt_ref2.Text;
                    eklekomutu.Parameters.Add("@cref3", SqlDbType.NVarChar, 100).Value = txt_ref3.Text;
                    eklekomutu.Parameters.Add("@ciletisim1", SqlDbType.NVarChar, 100).Value = txt_iletisim1.Text;
                    eklekomutu.Parameters.Add("@ciletisim2", SqlDbType.NVarChar, 100).Value = txt_iletisim2.Text;
                    eklekomutu.Parameters.Add("@ciletisim3", SqlDbType.NVarChar, 100).Value = txt_iletisim3.Text;
                    eklekomutu.Parameters.Add("@dil1", SqlDbType.NVarChar, 50).Value = cbx_dil1.Text;
                    eklekomutu.Parameters.Add("@dil2", SqlDbType.NVarChar, 50).Value = cbx_dil2.Text;
                    eklekomutu.Parameters.Add("@dil3", SqlDbType.NVarChar, 50).Value = cbx_dil3.Text;
                    eklekomutu.Parameters.Add("@dilseviye1", SqlDbType.NVarChar, 50).Value = cbx_dil_sev1.Text;
                    eklekomutu.Parameters.Add("@dilseviye2", SqlDbType.NVarChar, 50).Value = cbx_dil_sev2.Text;
                    eklekomutu.Parameters.Add("@dilseviye3", SqlDbType.NVarChar, 50).Value = cbx_dil_sev3.Text;
                    eklekomutu.Parameters.Add("@program1", SqlDbType.NVarChar, 100).Value = txt_program1.Text;
                    eklekomutu.Parameters.Add("@program2", SqlDbType.NVarChar, 100).Value = txt_program2.Text;
                    eklekomutu.Parameters.Add("@program3", SqlDbType.NVarChar, 100).Value = txt_program3.Text;
                    eklekomutu.Parameters.Add("@programseviye1", SqlDbType.NVarChar, 50).Value = cbx_bil_sev1.Text;
                    eklekomutu.Parameters.Add("@programseviye2", SqlDbType.NVarChar, 50).Value = cbx_bil_sev2.Text;
                    eklekomutu.Parameters.Add("@programseviye3", SqlDbType.NVarChar, 50).Value = cbx_bil_sev3.Text;
                    eklekomutu.Parameters.Add("@sertifika1", SqlDbType.NVarChar, 100).Value = txt_sertifika1.Text;
                    eklekomutu.Parameters.Add("@sertifika2", SqlDbType.NVarChar, 100).Value = txt_sertifika2.Text;
                    eklekomutu.Parameters.Add("@sertifika3", SqlDbType.NVarChar, 100).Value = txt_sertifika3.Text;
                    eklekomutu.Parameters.Add("@sertifikaa1", SqlDbType.NVarChar, 100).Value = txt_sertifikaa1.Text;
                    eklekomutu.Parameters.Add("@sertifikaa2", SqlDbType.NVarChar, 100).Value = txt_sertifikaa2.Text;
                    eklekomutu.Parameters.Add("@sertifikaa3", SqlDbType.NVarChar, 100).Value = txt_sertifikaa3.Text;
                    eklekomutu.Parameters.Add("@sertifikakurum1", SqlDbType.NVarChar, 100).Value = txt_sertifika_kurum1.Text;
                    eklekomutu.Parameters.Add("@sertifikakurum2", SqlDbType.NVarChar, 100).Value = txt_sertifika_kurum2.Text;
                    eklekomutu.Parameters.Add("@sertifikakurum3", SqlDbType.NVarChar, 100).Value = txt_sertifika_kurum3.Text;
                    eklekomutu.Parameters.Add("@sertifikatarih1", SqlDbType.Date).Value = date_sertifika1.Value;
                    eklekomutu.Parameters.Add("@sertifikatarih2", SqlDbType.Date).Value = date_sertifika2.Value;
                    eklekomutu.Parameters.Add("@sertifikatarih3", SqlDbType.Date).Value = date_sertifika3.Value;
                    try
                    {
                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        MessageBox.Show("Kişi havuza başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                    }
                    catch (Exception hatamjs)
                    {

                        MessageBox.Show(hatamjs.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçirniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from tbl_havuz where kisi_tc='" + txt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.
            if (cx_engel_yok.Checked == true)
            {
                cx_engel_var.Checked = false;
                cx_engel_yok.Checked = true;
                engelDurumu = cx_engel_yok.Text;
            }
            else
            {
                cx_engel_var.Checked = true;
                cx_engel_yok.Checked = false;
                engelDurumu = cx_engel_var.Text;
            }

            if (cx_sey_e.Checked == true)
            {
                cx_sey_h.Checked = false;
                seyehatDurumu = cx_sey_e.Text;
            }
            else
            {
                cx_sey_h.Checked = true;
                cx_sey_e.Checked = false;
                seyehatDurumu = cx_sey_h.Text;
            }

            if (cx_cocuk_var.Checked == true)
            {
                cx_cocuk_yok.Checked = false;
                cocukDurumu = cx_cocuk_var.Text;
            }
            else
            {
                cx_cocuk_yok.Checked = true;
                cx_cocuk_var.Checked = false;
                cocukDurumu = cx_cocuk_yok.Text;
            }

            if (cx_sektor_var.Checked == true)
            {
                cx_sektor_yok.Checked = false;
                sektorTecrube = cx_sektor_var.Text;
            }
            else
            {
                cx_sektor_yok.Checked = true;
                cx_sektor_var.Checked = false;
                sektorTecrube = cx_sektor_yok.Text;
            }

            if (cx_sabika_var.Checked == true)
            {
                cx_sabika_yok.Checked = false;
                sabikaKaydi = cx_sabika_var.Text;
            }
            else
            {
                cx_sabika_yok.Checked = true;
                cx_sabika_var.Checked = false;
                sabikaKaydi = cx_sabika_yok.Text;
            }

            if (cx_sigara_evet.Checked == true)
            {
                cx_sigara_hayır.Checked = false;
                sigaraDurumu = cx_sigara_evet.Text;
            }
            else
            {
                cx_sigara_hayır.Checked = true;
                cx_sigara_evet.Checked = false;
                sigaraDurumu = cx_sigara_hayır.Text;
            }

            if (cx_alkol_evet.Checked == true)
            {
                cx_alkol_hayır.Checked = false;
                alkolDurumu = cx_alkol_evet.Text;
            }
            else
            {
                cx_alkol_hayır.Checked = true;
                cx_alkol_evet.Checked = false;
                alkolDurumu = cx_alkol_hayır.Text;
            }

            if (txt_baslik.Text == "")
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (txt_cvdosya.Text == "")
                label2.ForeColor = Color.Red;
            else
                label2.ForeColor = Color.Black;

            if (cbx_calisma_sekli.Text == "Seçiniz...")
                label3.ForeColor = Color.Red;
            else
                label3.ForeColor = Color.Black;

            if (txt_tc_no.Text.Length < 11 || txt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label4.ForeColor = Color.Red;
            else
                label4.ForeColor = Color.Black;

            if (cbx_askerlik.Text == "Muaf")
                date_askerlik.Visible = false;
            else
                date_askerlik.Visible = true;

            if (txt_ad.Text == "" && txt_ad.Text.Length < 2)
                label5.ForeColor = Color.Red;
            else
                label5.ForeColor = Color.Black;

            if (txt_soyadı.Text == "" && txt_soyadı.Text.Length < 2)
                label6.ForeColor = Color.Red;
            else
                label6.ForeColor = Color.Black;


            if (txt_dogum.Text == "" && txt_dogum.Text.Length < 2)
                label8.ForeColor = Color.Red;
            else
                label8.ForeColor = Color.Black;


            if (txt_uyruk.Text == "" && txt_uyruk.Text.Length < 2)
                label13.ForeColor = Color.Red;
            else
                label13.ForeColor = Color.Black;

            if (cbx_askerlik.Text == "" || cbx_askerlik.Text == "Seçiniz...")
                label9.ForeColor = Color.Red;
            else
                label9.ForeColor = Color.Black;



            if (txt_adres.Text == "" && txt_adres.Text.Length < 2)
                label11.ForeColor = Color.Red;
            else
                label11.ForeColor = Color.Red;

            if (txt_saglik.Text == "" && txt_saglik.Text.Length < 2)
                label15.ForeColor = Color.Red;
            else
                label15.ForeColor = Color.Black;


            if (txt_tel_no.Text == "" && txt_tel_no.Text.Length != 11)
                label26.ForeColor = Color.Red;
            else
                label26.ForeColor = Color.Black;


            if (txt_email.Text == "")
                label25.ForeColor = Color.Red;
            else
                label25.ForeColor = Color.Black;


            if (cbx_kan.Text == "" || cbx_kan.Text == "Seçiniz...")
                label24.ForeColor = Color.Red;
            else
                label24.ForeColor = Color.Black;


            if (cbx_medeni_hal.Text == "" || cbx_medeni_hal.Text == "Seçiniz...")
                label22.ForeColor = Color.Red;
            else
                label22.ForeColor = Color.Black;

            if (cbx_cinsiyet.Text == "" || cbx_cinsiyet.Text == "Seçiniz...")
                label21.ForeColor = Color.Red;
            else
                label21.ForeColor = Color.Black;

            if (txt_pozisyon.Text == "")
                label20.ForeColor = Color.Red;
            else
                label20.ForeColor = Color.Black;

            if (txt_kariyerhedefi.Text == "")
                label19.ForeColor = Color.Red;
            else
                label19.ForeColor = Color.Black;


            if (cbx_e_seviye1.Text != "Seçiniz...")
            {
                if (cbx_e_durum1.Text == "Seçiniz...")
                    label61.ForeColor = Color.Red;
                else
                    label61.ForeColor = Color.Black;
                if (txt_e_okul1.Text == "")
                    label55.ForeColor = Color.Red;
                else
                    label55.ForeColor = Color.Black;
                if (txt_e_bolum1.Text == "")
                    label54.ForeColor = Color.Red;
                else
                    label54.ForeColor = Color.Black;
                if (txt_not1.Text == "")
                    label52.ForeColor = Color.Red;
                else
                    label52.ForeColor = Color.Black;
            }
            if (cbx_e_durum1.Text != "Seçiniz...")
            {
                if (cbx_e_seviye1.Text == "Seçiniz...")
                    label61.ForeColor = Color.Red;
                else
                    label61.ForeColor = Color.Black;
                if (txt_e_okul1.Text == "")
                    label55.ForeColor = Color.Red;
                else
                    label55.ForeColor = Color.Black;
                if (txt_e_bolum1.Text == "")
                    label54.ForeColor = Color.Red;
                else
                    label54.ForeColor = Color.Black;
                if (txt_not1.Text == "")
                    label52.ForeColor = Color.Red;
                else
                    label52.ForeColor = Color.Black;
            }
            if (txt_e_okul1.Text != "" || txt_e_okul1.Text.Length > 2)
            {
                if (cbx_e_seviye1.Text == "Seçiniz...")
                    label61.ForeColor = Color.Red;
                else
                    label61.ForeColor = Color.Black;
                if (cbx_e_durum1.Text == "Seçiniz...")
                    label55.ForeColor = Color.Red;
                else
                    label55.ForeColor = Color.Black;
                if (txt_e_bolum1.Text == "")
                    label54.ForeColor = Color.Red;
                else
                    label54.ForeColor = Color.Black;
                if (txt_not1.Text == "")
                    label52.ForeColor = Color.Red;
                else
                    label52.ForeColor = Color.Black;
            }
            if (txt_e_bolum1.Text != "" || txt_e_bolum1.Text.Length > 2)
            {
                if (cbx_e_seviye1.Text == "Seçiniz...")
                    label61.ForeColor = Color.Red;
                else
                    label61.ForeColor = Color.Black;
                if (cbx_e_durum1.Text == "Seçiniz...")
                    label55.ForeColor = Color.Red;
                else
                    label55.ForeColor = Color.Black;
                if (txt_e_okul1.Text == "")
                    label54.ForeColor = Color.Red;
                else
                    label54.ForeColor = Color.Black;
                if (txt_not1.Text == "")
                    label52.ForeColor = Color.Red;
                else
                    label52.ForeColor = Color.Black;
            }
            if (txt_not1.Text != "")
            {
                if (cbx_e_seviye1.Text == "Seçiniz...")
                    label61.ForeColor = Color.Red;
                else
                    label61.ForeColor = Color.Black;
                if (cbx_e_durum1.Text == "Seçiniz...")
                    label55.ForeColor = Color.Red;
                else
                    label55.ForeColor = Color.Black;
                if (txt_e_okul1.Text == "")
                    label54.ForeColor = Color.Red;
                else
                    label54.ForeColor = Color.Black;
                if (txt_e_bolum1.Text == "")
                    label52.ForeColor = Color.Red;
                else
                    label52.ForeColor = Color.Black;
            }

            if (cbx_e_seviye2.Text != "Seçiniz...")
            {
                if (cbx_e_durum2.Text == "Seçiniz...")
                    label61.ForeColor = Color.Red;
                else
                    label61.ForeColor = Color.Black;
                if (txt_e_okul2.Text == "")
                    label55.ForeColor = Color.Red;
                else
                    label55.ForeColor = Color.Black;
                if (txt_e_bolum2.Text == "")
                    label54.ForeColor = Color.Red;
                else
                    label54.ForeColor = Color.Black;
                if (txt_not2.Text == "")
                    label52.ForeColor = Color.Red;
                else
                    label52.ForeColor = Color.Black;
            }
            if (cbx_e_durum2.Text != "Seçiniz...")
            {
                if (cbx_e_seviye2.Text == "Seçiniz...")
                    label61.ForeColor = Color.Red;
                else
                    label61.ForeColor = Color.Black;
                if (txt_e_okul2.Text == "")
                    label55.ForeColor = Color.Red;
                else
                    label55.ForeColor = Color.Black;
                if (txt_e_bolum2.Text == "")
                    label54.ForeColor = Color.Red;
                else
                    label54.ForeColor = Color.Black;
                if (txt_not2.Text == "")
                    label52.ForeColor = Color.Red;
                else
                    label52.ForeColor = Color.Black;
            }
            if (txt_e_okul2.Text != "" || txt_e_okul2.Text.Length > 2)
            {
                if (cbx_e_seviye2.Text == "Seçiniz...")
                    label61.ForeColor = Color.Red;
                else
                    label61.ForeColor = Color.Black;
                if (cbx_e_durum2.Text == "Seçiniz...")
                    label55.ForeColor = Color.Red;
                else
                    label55.ForeColor = Color.Black;
                if (txt_e_bolum2.Text == "")
                    label54.ForeColor = Color.Red;
                else
                    label54.ForeColor = Color.Black;
                if (txt_not2.Text == "")
                    label52.ForeColor = Color.Red;
                else
                    label52.ForeColor = Color.Black;
            }
            if (txt_e_bolum2.Text != "" || txt_e_bolum2.Text.Length > 2)
            {
                if (cbx_e_seviye2.Text == "Seçiniz...")
                    label61.ForeColor = Color.Red;
                else
                    label61.ForeColor = Color.Black;
                if (cbx_e_durum2.Text == "Seçiniz...")
                    label55.ForeColor = Color.Red;
                else
                    label55.ForeColor = Color.Black;
                if (txt_e_okul2.Text == "")
                    label54.ForeColor = Color.Red;
                else
                    label54.ForeColor = Color.Black;
                if (txt_not2.Text == "")
                    label52.ForeColor = Color.Red;
                else
                    label52.ForeColor = Color.Black;
            }
            if (txt_not2.Text != "")
            {
                if (cbx_e_seviye2.Text == "Seçiniz...")
                    label61.ForeColor = Color.Red;
                else
                    label61.ForeColor = Color.Black;
                if (cbx_e_durum2.Text == "Seçiniz...")
                    label55.ForeColor = Color.Red;
                else
                    label55.ForeColor = Color.Black;
                if (txt_e_okul2.Text == "")
                    label54.ForeColor = Color.Red;
                else
                    label54.ForeColor = Color.Black;
                if (txt_e_bolum2.Text == "")
                    label52.ForeColor = Color.Red;
                else
                    label52.ForeColor = Color.Black;
            }

            if (cbx_e_seviye3.Text != "Seçiniz...")
            {
                if (cbx_e_durum3.Text == "Seçiniz...")
                    label61.ForeColor = Color.Red;
                else
                    label61.ForeColor = Color.Black;
                if (txt_e_okul3.Text == "")
                    label55.ForeColor = Color.Red;
                else
                    label55.ForeColor = Color.Black;
                if (txt_e_bolum3.Text == "")
                    label54.ForeColor = Color.Red;
                else
                    label54.ForeColor = Color.Black;
                if (txt_not3.Text == "")
                    label52.ForeColor = Color.Red;
                else
                    label52.ForeColor = Color.Black;
            }
            if (cbx_e_durum3.Text != "Seçiniz...")
            {
                if (cbx_e_seviye3.Text == "Seçiniz...")
                    label61.ForeColor = Color.Red;
                else
                    label61.ForeColor = Color.Black;
                if (txt_e_okul3.Text == "")
                    label55.ForeColor = Color.Red;
                else
                    label55.ForeColor = Color.Black;
                if (txt_e_bolum3.Text == "")
                    label54.ForeColor = Color.Red;
                else
                    label54.ForeColor = Color.Black;
                if (txt_not3.Text == "")
                    label52.ForeColor = Color.Red;
                else
                    label52.ForeColor = Color.Black;
            }
            if (txt_e_okul3.Text != "" || txt_e_okul3.Text.Length > 2)
            {
                if (cbx_e_seviye3.Text == "Seçiniz...")
                    label61.ForeColor = Color.Red;
                else
                    label61.ForeColor = Color.Black;
                if (cbx_e_durum3.Text == "Seçiniz...")
                    label55.ForeColor = Color.Red;
                else
                    label55.ForeColor = Color.Black;
                if (txt_e_bolum3.Text == "")
                    label54.ForeColor = Color.Red;
                else
                    label54.ForeColor = Color.Black;
                if (txt_not3.Text == "")
                    label52.ForeColor = Color.Red;
                else
                    label52.ForeColor = Color.Black;
            }
            if (txt_e_bolum3.Text != "" || txt_e_bolum3.Text.Length > 2)
            {
                if (cbx_e_seviye3.Text == "Seçiniz...")
                    label61.ForeColor = Color.Red;
                else
                    label61.ForeColor = Color.Black;
                if (cbx_e_durum3.Text == "Seçiniz...")
                    label55.ForeColor = Color.Red;
                else
                    label55.ForeColor = Color.Black;
                if (txt_e_okul3.Text == "")
                    label54.ForeColor = Color.Red;
                else
                    label54.ForeColor = Color.Black;
                if (txt_not3.Text == "")
                    label52.ForeColor = Color.Red;
                else
                    label52.ForeColor = Color.Black;
            }
            if (txt_not3.Text != "")
            {
                if (cbx_e_seviye3.Text == "Seçiniz...")
                    label61.ForeColor = Color.Red;
                else
                    label61.ForeColor = Color.Black;
                if (cbx_e_durum3.Text == "Seçiniz...")
                    label55.ForeColor = Color.Red;
                else
                    label55.ForeColor = Color.Black;
                if (txt_e_okul3.Text == "")
                    label54.ForeColor = Color.Red;
                else
                    label54.ForeColor = Color.Black;
                if (txt_e_bolum3.Text == "")
                    label52.ForeColor = Color.Red;
                else
                    label52.ForeColor = Color.Black;
            }


            if (txt_yer1.Text != "" && txt_yer1.Text.Length >= 2)
            {
                if (txt_gorev1.Text == "" && txt_gorev1.Text.Length < 2)
                    label85.ForeColor = Color.Red;
                else
                    label85.ForeColor = Color.Black;

                if (txt_neden1.Text == "" && txt_neden1.Text.Length < 2)
                    label82.ForeColor = Color.Red;
                else
                    label82.ForeColor = Color.Black;
            }
            if (txt_gorev1.Text != "" && txt_gorev1.Text.Length >= 2)
            {
                if (txt_yer1.Text == "" && txt_yer1.Text.Length < 2)
                    label86.ForeColor = Color.Red;
                else
                    label86.ForeColor = Color.Black;
                if (txt_neden1.Text == "" && txt_neden1.Text.Length < 2)
                    label82.ForeColor = Color.Red;
                else
                    label82.ForeColor = Color.Black;
            }
            if (txt_neden1.Text != "" && txt_neden1.Text.Length >= 2)
            {
                if (txt_yer1.Text == "" && txt_yer1.Text.Length < 2)
                    label86.ForeColor = Color.Red;
                else
                    label86.ForeColor = Color.Black;

                if (txt_gorev1.Text == "" && txt_gorev1.Text.Length < 2)
                    label85.ForeColor = Color.Red;
                else
                    label85.ForeColor = Color.Black;
            }
            if (txt_ref1.Text != "" && txt_ref1.Text.Length > 2)
            {
                if (txt_yer1.Text == "" && txt_yer1.Text.Length < 2)
                    label86.ForeColor = Color.Red;
                else
                    label86.ForeColor = Color.Black;

                if (txt_gorev1.Text == "" && txt_gorev1.Text.Length < 2)
                    label85.ForeColor = Color.Red;
                else
                    label85.ForeColor = Color.Black;
                if (txt_neden1.Text == "" && txt_neden1.Text.Length < 2)
                    label82.ForeColor = Color.Red;
                else
                    label82.ForeColor = Color.Black;

            }
            if (txt_iletisim1.Text != "" && txt_iletisim1.Text.Length == 11)
            {
                if (txt_yer1.Text == "" && txt_yer1.Text.Length < 2)
                    label86.ForeColor = Color.Red;
                else
                    label86.ForeColor = Color.Black;

                if (txt_gorev1.Text == "" && txt_gorev1.Text.Length < 2)
                    label85.ForeColor = Color.Red;
                else
                    label85.ForeColor = Color.Black;
                if (txt_neden1.Text == "" && txt_neden1.Text.Length < 2)
                    label82.ForeColor = Color.Red;
                else
                    label82.ForeColor = Color.Black;
                if (txt_ref1.Text == "" && txt_ref1.Text.Length < 2)
                    label81.ForeColor = Color.Red;
                else
                    label81.ForeColor = Color.Black;
            }

            if (txt_yer2.Text != "" && txt_yer2.Text.Length >= 2)
            {
                if (txt_gorev2.Text == "" && txt_gorev2.Text.Length < 2)
                    label85.ForeColor = Color.Red;
                else
                    label85.ForeColor = Color.Black;

                if (txt_neden2.Text == "" && txt_neden2.Text.Length < 2)
                    label82.ForeColor = Color.Red;
                else
                    label82.ForeColor = Color.Black;
            }
            if (txt_gorev2.Text != "" && txt_gorev2.Text.Length >= 2)
            {
                if (txt_yer2.Text == "" && txt_yer2.Text.Length < 2)
                    label86.ForeColor = Color.Red;
                else
                    label86.ForeColor = Color.Black;
                if (txt_neden2.Text == "" && txt_neden2.Text.Length < 2)
                    label82.ForeColor = Color.Red;
                else
                    label82.ForeColor = Color.Black;
            }
            if (txt_neden2.Text != "" && txt_neden2.Text.Length >= 2)
            {
                if (txt_yer2.Text == "" && txt_yer2.Text.Length < 2)
                    label86.ForeColor = Color.Red;
                else
                    label86.ForeColor = Color.Black;

                if (txt_gorev2.Text == "" && txt_gorev2.Text.Length < 2)
                    label85.ForeColor = Color.Red;
                else
                    label85.ForeColor = Color.Black;
            }
            if (txt_ref2.Text != "" && txt_ref2.Text.Length > 2)
            {
                if (txt_yer2.Text == "" && txt_yer2.Text.Length < 2)
                    label86.ForeColor = Color.Red;
                else
                    label86.ForeColor = Color.Black;

                if (txt_gorev2.Text == "" && txt_gorev2.Text.Length < 2)
                    label85.ForeColor = Color.Red;
                else
                    label85.ForeColor = Color.Black;
                if (txt_neden2.Text == "" && txt_neden2.Text.Length < 2)
                    label82.ForeColor = Color.Red;
                else
                    label82.ForeColor = Color.Black;

            }
            if (txt_iletisim2.Text != "" && txt_iletisim2.Text.Length == 11)
            {
                if (txt_yer2.Text == "" && txt_yer2.Text.Length < 2)
                    label86.ForeColor = Color.Red;
                else
                    label86.ForeColor = Color.Black;

                if (txt_gorev2.Text == "" && txt_gorev2.Text.Length < 2)
                    label85.ForeColor = Color.Red;
                else
                    label85.ForeColor = Color.Black;
                if (txt_neden2.Text == "" && txt_neden2.Text.Length < 2)
                    label82.ForeColor = Color.Red;
                else
                    label82.ForeColor = Color.Black;
                if (txt_ref2.Text == "" && txt_ref2.Text.Length < 2)
                    label81.ForeColor = Color.Red;
                else
                    label81.ForeColor = Color.Black;
            }


            if (txt_yer3.Text != "" && txt_yer3.Text.Length >= 2)
            {
                if (txt_gorev3.Text == "" && txt_gorev3.Text.Length < 2)
                    label85.ForeColor = Color.Red;
                else
                    label85.ForeColor = Color.Black;

                if (txt_neden3.Text == "" && txt_neden3.Text.Length < 2)
                    label82.ForeColor = Color.Red;
                else
                    label82.ForeColor = Color.Black;
            }
            if (txt_gorev3.Text != "" && txt_gorev3.Text.Length >= 2)
            {
                if (txt_yer3.Text == "" && txt_yer3.Text.Length < 2)
                    label86.ForeColor = Color.Red;
                else
                    label86.ForeColor = Color.Black;
                if (txt_neden3.Text == "" && txt_neden3.Text.Length < 2)
                    label82.ForeColor = Color.Red;
                else
                    label82.ForeColor = Color.Black;
            }
            if (txt_neden3.Text != "" && txt_neden3.Text.Length >= 2)
            {
                if (txt_yer3.Text == "" && txt_yer3.Text.Length < 2)
                    label86.ForeColor = Color.Red;
                else
                    label86.ForeColor = Color.Black;

                if (txt_gorev3.Text == "" && txt_gorev3.Text.Length < 2)
                    label85.ForeColor = Color.Red;
                else
                    label85.ForeColor = Color.Black;
            }
            if (txt_ref3.Text != "" && txt_ref3.Text.Length > 2)
            {
                if (txt_yer3.Text == "" && txt_yer3.Text.Length < 2)
                    label86.ForeColor = Color.Red;
                else
                    label86.ForeColor = Color.Black;

                if (txt_gorev3.Text == "" && txt_gorev3.Text.Length < 2)
                    label85.ForeColor = Color.Red;
                else
                    label85.ForeColor = Color.Black;
                if (txt_neden3.Text == "" && txt_neden3.Text.Length < 2)
                    label82.ForeColor = Color.Red;
                else
                    label82.ForeColor = Color.Black;

            }
            if (txt_iletisim3.Text != "" && txt_iletisim3.Text.Length == 11)
            {
                if (txt_yer3.Text == "" && txt_yer3.Text.Length < 2)
                    label86.ForeColor = Color.Red;
                else
                    label86.ForeColor = Color.Black;

                if (txt_gorev3.Text == "" && txt_gorev3.Text.Length < 2)
                    label85.ForeColor = Color.Red;
                else
                    label85.ForeColor = Color.Black;
                if (txt_neden3.Text == "" && txt_neden3.Text.Length < 2)
                    label82.ForeColor = Color.Red;
                else
                    label82.ForeColor = Color.Black;
                if (txt_ref3.Text == "" && txt_ref3.Text.Length < 2)
                    label81.ForeColor = Color.Red;
                else
                    label81.ForeColor = Color.Black;
            }


            if (cbx_dil_sev1.Text != "Seçiniz...")
            {
                if (cbx_dil1.Text == "Seçiniz...")
                    label91.ForeColor = Color.Red;
                else
                    label91.ForeColor = Color.Black;
            }
            else//dil seçmiş ise
            {
                if (cbx_dil_sev1.Text == "Seçiniz...")
                    label90.ForeColor = Color.Red;
                else
                    label90.ForeColor = Color.Black;
            }
            if (cbx_dil_sev2.Text != "Seçiniz...")
            {
                if (cbx_dil2.Text == "Seçiniz...")
                    label91.ForeColor = Color.Red;
                else
                    label91.ForeColor = Color.Black;
            }
            else//dil seçmiş ise
            {
                if (cbx_dil_sev2.Text == "Seçiniz...")
                    label90.ForeColor = Color.Red;
                else
                    label90.ForeColor = Color.Black;
            }
            if (cbx_dil_sev3.Text != "Seçiniz...")
            {
                if (cbx_dil3.Text == "Seçiniz...")
                    label91.ForeColor = Color.Red;
                else
                    label91.ForeColor = Color.Black;
            }
            else//dil seçmiş ise
            {
                if (cbx_dil_sev3.Text == "Seçiniz...")
                    label90.ForeColor = Color.Red;
                else
                    label90.ForeColor = Color.Black;
            }

            if (txt_program1.Text != "" && txt_program1.Text.Length >= 2)
            {
                if (cbx_bil_sev1.Text == "Seçiniz...")
                    label95.ForeColor = Color.Red;
                else
                    label95.ForeColor = Color.Black;
            }
            else
            {
                if (cbx_bil_sev1.Text != "Seçiniz...")
                    label96.ForeColor = Color.Red;
                else
                    label96.ForeColor = Color.Black;
            }

            if (txt_program2.Text != "" && txt_program2.Text.Length >= 2)
            {
                if (cbx_bil_sev2.Text == "Seçiniz...")
                    label95.ForeColor = Color.Red;
                else
                    label95.ForeColor = Color.Black;
            }
            else
            {
                if (cbx_bil_sev2.Text != "Seçiniz...")
                    label96.ForeColor = Color.Red;
                else
                    label96.ForeColor = Color.Black;
            }

            if (txt_program3.Text != "" && txt_program3.Text.Length >= 2)
            {
                if (cbx_bil_sev3.Text == "Seçiniz...")
                    label95.ForeColor = Color.Red;
                else
                    label95.ForeColor = Color.Black;
            }
            else
            {
                if (cbx_bil_sev3.Text != "Seçiniz...")
                    label96.ForeColor = Color.Red;
                else
                    label96.ForeColor = Color.Black;
            }


            if (txt_sertifika1.Text != "" && txt_sertifika1.Text.Length >= 2)
            {
                if (txt_sertifikaa1.Text != "" && txt_sertifikaa1.Text.Length >= 2)

                    label102.ForeColor = Color.Black;
                else
                    label102.ForeColor = Color.Red;
                if (txt_sertifika_kurum1.Text != "" && txt_sertifika_kurum1.Text.Length >= 2)
                    label101.ForeColor = Color.Black;

                else
                    label101.ForeColor = Color.Red;
            }

            if (txt_sertifikaa1.Text != "" && txt_sertifikaa1.Text.Length >= 2)
            {
                if (txt_sertifika1.Text != "" && txt_sertifika1.Text.Length >= 2)

                    label103.ForeColor = Color.Black;
                else
                    label103.ForeColor = Color.Red;
                if (txt_sertifika_kurum1.Text != "" && txt_sertifika_kurum1.Text.Length >= 2)
                    label101.ForeColor = Color.Black;

                else
                    label101.ForeColor = Color.Red;
            }
            if (txt_sertifika_kurum1.Text != "" && txt_sertifika_kurum1.Text.Length >= 2)
            {
                if (txt_sertifika1.Text != "" && txt_sertifika1.Text.Length >= 2)

                    label103.ForeColor = Color.Black;
                else
                    label103.ForeColor = Color.Red;
                if (txt_sertifikaa1.Text != "" && txt_sertifikaa1.Text.Length >= 2)
                    label102.ForeColor = Color.Black;

                else
                    label102.ForeColor = Color.Red;
            }

            if (txt_baslik.Text != "" && cbx_calisma_sekli.Text != "" && txt_tc_no.Text.Length == 11 && txt_ad.Text.Length >= 2 &&
               txt_soyadı.Text.Length >= 2 && txt_dogum.Text.Length >= 2 && txt_adres.Text.Length >= 2 &&
                txt_dogum.Text.Length >= 2 && txt_uyruk.Text != "" && cbx_askerlik.Text != "Seçiniz..." && txt_saglik.Text.Length >= 2 &&
                txt_kariyerhedefi.Text != "" && txt_pozisyon.Text != "" && cbx_cinsiyet.Text != "Seçiniz..." && txt_tel_no.Text.Length == 11 &&
                cbx_medeni_hal.Text != "Seçiniz..." && cbx_kan.Text != "Seçiniz..." && resim.Image != null)
            {
                try
                {

                    FileStream fsResim = new FileStream(resimAdresi, FileMode.Open, FileAccess.Read);

                    BinaryReader brResim = new BinaryReader(fsResim);

                    byte[] resim = brResim.ReadBytes((int)fsResim.Length);

                    brResim.Close();
                    fsResim.Close();




                    SqlCommand guncellekomutu = new SqlCommand("update tbl_havuz set  resim = @resim,baslik = @baslik,cvLinki = @cvLinki,calismaSekli = @calismaSekli, kisi_tc = @kisi_tc, adi = @adi,soyadi = @soyadi,dogumTarihi = @dogumTarihi, dogumYeri = @dogumYeri,uyruk = @uyruk, askerlik = @askerlik,askerlikTarihi = @askerlikTarihi, adres = @adres,engelDurumu = @engelDurumu, seyehat = @seyehat,cocukDurumu = @cocukDurumu, cocukSayisi = @cocukSayisi,sektörTecrübesi = @sektörTecrübesi,kayitTarihi = @kayitTarihi,kariyerHedefi = @kariyerHedefi,pozisyonTercihi = @pozisyonTercihi,cinsiyet = @cinsiyet,medeniHal = @medeniHal,kan = @kan,eposta = @eposta,tel = @tel,sabikakaydı = @sabikakaydı,sürücübelgesi = @sürücübelgesi,saglikSorunu = @saglikSorunu,sigara = @sigara,alkol = @alkol, ücretBeklentisi = @ücretBeklentisi,egitimSeviye1 = @egitimSeviye1, egitimDurum1 = @egitimDurum1,egitimOkul1 = @egitimOkul1,egitimBolum1 = @egitimBolum1,mezuniyet1 = @mezuniyet1,notDurumu1 = @notDurumu1,egitimSeviye2 = @egitimSeviye2,egitimDurum2 = @egitimDurum2,egitimOkul2 = @egitimOkul2,egitimBolum2 = @egitimBolum2,mezuniyet2 = @mezuniyet2,notDurumu2 = @notDurumu2,egitimSeviye3 = @egitimSeviye3,egitimDurum3 = @egitimDurum3,egitimOkul3 = @egitimOkul3,egitimBolum3 = @egitimBolum3,mezuniyet3 = @mezuniyet3,notDurumu3 = @notDurumu3,calistigiyer1 = @calistigiyer1,calistigiyer2 = @calistigiyer2,calistigiyer3 = @calistigiyer3,gorev1 = @gorev1, gorev2 = @gorev2,gorev3 = @gorev3,cGirisTarihi1 = @cGirisTarihi1,cGirisTarihi2 = @cGirisTarihi2," +
                        "cGirisTarihi3 = @cGirisTarihi3,cCikisTarihi1 = @cCikisTarihi1,cCikisTarihi2 = @cCikisTarihi2,cCikisTarihi3 = @cCikisTarihi3,cNeden1 = @cNeden1,cNeden2 = @cNeden2,cNeden3 = @cNeden3,cref1 = @cref1,cref2 = @cref2,cref3 = @cref3,ciletisim1 = @ciletisim1,ciletisim2 = @ciletisim2,ciletisim3 = @ciletisim3,dil1 = @dil1,dil2 = @dil2,dil3 = @dil3,dilseviye1 = @dilseviye1,dilseviye2 = @dilseviye2,dilseviye3 = @dilseviye3,program1 = @program1,program2 = @program2,program3 = @program3,programseviye1 = @programseviye1,programseviye2 = @programseviye2,programseviye3 = @programseviye3,sertifika1 = @sertifika1,sertifika2 = @sertifika2,sertifika3 = @sertifika3,sertifikaa1 = @sertifikaa1,sertifikaa2 = @sertifikaa2,sertifikaa3 = @sertifikaa3,sertifikakurum1 = @sertifikakurum1,sertifikakurum2 = @sertifikakurum2,sertifikakurum3 = @sertifikakurum3,sertifikatarih1 = @sertifikatarih1,sertifikatarih2 = @sertifikatarih2,sertifikatarih3 = @sertifikatarih3 where kisi_tc = @kisi_tc", baglantim.baglanti());



                    guncellekomutu.Parameters.Add("@baslik", SqlDbType.NVarChar, 50).Value = txt_baslik.Text;
                    guncellekomutu.Parameters.Add("@cvLinki", SqlDbType.NVarChar, 50).Value = lnk_lbl_1.Text;
                    guncellekomutu.Parameters.Add("@calismaSekli", SqlDbType.NVarChar, 50).Value = cbx_calisma_sekli.Text;
                    guncellekomutu.Parameters.Add("@kisi_tc", SqlDbType.NVarChar, 11).Value = txt_tc_no.Text;
                    guncellekomutu.Parameters.Add("@adi", SqlDbType.NVarChar, 100).Value = txt_ad.Text;
                    guncellekomutu.Parameters.Add("@soyadi", SqlDbType.NVarChar, 100).Value = txt_soyadı.Text;
                    guncellekomutu.Parameters.Add("@dogumTarihi", SqlDbType.Date).Value = date_dogum.Value;
                    guncellekomutu.Parameters.Add("@dogumYeri", SqlDbType.NVarChar, 100).Value = txt_dogum.Text;
                    guncellekomutu.Parameters.Add("@uyruk", SqlDbType.NVarChar, 50).Value = txt_uyruk.Text;
                    guncellekomutu.Parameters.Add("@askerlik", SqlDbType.NVarChar, 50).Value = cbx_askerlik.Text;
                    guncellekomutu.Parameters.Add("@askerlikTarihi", SqlDbType.Date).Value = date_askerlik.Value;
                    guncellekomutu.Parameters.Add("@adres", SqlDbType.NVarChar, 500).Value = txt_adres.Text;
                    guncellekomutu.Parameters.Add("@engelDurumu", SqlDbType.NVarChar, 50).Value = engelDurumu;
                    guncellekomutu.Parameters.Add("@seyehat", SqlDbType.NVarChar, 50).Value = seyehatDurumu;
                    guncellekomutu.Parameters.Add("@cocukDurumu", SqlDbType.NVarChar, 50).Value = cocukDurumu;
                    guncellekomutu.Parameters.Add("@cocukSayisi", SqlDbType.Int).Value = numeric_cocuk_sayisi.Value;
                    guncellekomutu.Parameters.Add("@sektörTecrübesi", SqlDbType.NVarChar, 50).Value = sektorTecrube;
                    guncellekomutu.Parameters.Add("@kayitTarihi", SqlDbType.Date).Value = date_kayit.Value;
                    guncellekomutu.Parameters.Add("@kariyerHedefi", SqlDbType.NVarChar, 100).Value = txt_kariyerhedefi.Text;
                    guncellekomutu.Parameters.Add("@pozisyonTercihi", SqlDbType.NVarChar, 500).Value = txt_pozisyon.Text;
                    guncellekomutu.Parameters.Add("@cinsiyet", SqlDbType.NVarChar, 50).Value = cbx_cinsiyet.Text;
                    guncellekomutu.Parameters.Add("@medeniHal", SqlDbType.NVarChar, 50).Value = cbx_medeni_hal.Text;
                    guncellekomutu.Parameters.Add("@kan", SqlDbType.NVarChar, 50).Value = cbx_kan.Text;
                    guncellekomutu.Parameters.Add("@eposta", SqlDbType.NVarChar, 500).Value = txt_email.Text;
                    guncellekomutu.Parameters.Add("@tel", SqlDbType.NVarChar, 50).Value = txt_tel_no.Text;
                    guncellekomutu.Parameters.Add("@sabikakaydı", SqlDbType.NVarChar, 50).Value = sabikaKaydi;
                    guncellekomutu.Parameters.Add("@sürücübelgesi", SqlDbType.NVarChar, 50).Value = txt_ehliyet.Text;
                    guncellekomutu.Parameters.Add("@saglikSorunu", SqlDbType.NVarChar, 500).Value = txt_saglik.Text;
                    guncellekomutu.Parameters.Add("@sigara", SqlDbType.NVarChar, 50).Value = sigaraDurumu;
                    guncellekomutu.Parameters.Add("@alkol", SqlDbType.NVarChar, 50).Value = alkolDurumu;
                    guncellekomutu.Parameters.Add("@ücretBeklentisi", SqlDbType.Float).Value = txt_ucret_beklentisi.Text;
                    guncellekomutu.Parameters.Add("@egitimSeviye1", SqlDbType.NVarChar, 50).Value = cbx_e_seviye1.Text;
                    guncellekomutu.Parameters.Add("@egitimDurum1", SqlDbType.NVarChar, 50).Value = cbx_e_durum1.Text;
                    guncellekomutu.Parameters.Add("@egitimOkul1", SqlDbType.NVarChar, 100).Value = txt_e_okul1.Text;
                    guncellekomutu.Parameters.Add("@egitimBolum1", SqlDbType.NVarChar, 500).Value = txt_e_bolum1.Text;
                    guncellekomutu.Parameters.Add("@mezuniyet1", SqlDbType.Date).Value = date_mezuniyet1.Text;
                    guncellekomutu.Parameters.Add("@notDurumu1", SqlDbType.NVarChar, 50).Value = txt_not1.Text;
                    guncellekomutu.Parameters.Add("@egitimSeviye2", SqlDbType.NVarChar, 50).Value = cbx_e_seviye2.Text;
                    guncellekomutu.Parameters.Add("@egitimDurum2", SqlDbType.NVarChar, 50).Value = cbx_e_durum2.Text;
                    guncellekomutu.Parameters.Add("@egitimOkul2", SqlDbType.NVarChar, 100).Value = txt_e_okul2.Text;
                    guncellekomutu.Parameters.Add("@egitimBolum2", SqlDbType.NVarChar, 500).Value = txt_e_bolum2.Text;
                    guncellekomutu.Parameters.Add("@mezuniyet2", SqlDbType.Date).Value = date_mezuniyet2.Value;
                    guncellekomutu.Parameters.Add("@notDurumu2", SqlDbType.NVarChar, 50).Value = txt_not2.Text;
                    guncellekomutu.Parameters.Add("@egitimSeviye3", SqlDbType.NVarChar, 50).Value = cbx_e_seviye3.Text;
                    guncellekomutu.Parameters.Add("@egitimDurum3", SqlDbType.NVarChar, 50).Value = cbx_e_durum3.Text;
                    guncellekomutu.Parameters.Add("@egitimOkul3", SqlDbType.NVarChar, 100).Value = txt_e_okul3.Text;
                    guncellekomutu.Parameters.Add("@egitimBolum3", SqlDbType.NVarChar, 500).Value = txt_e_bolum3.Text;
                    guncellekomutu.Parameters.Add("@mezuniyet3", SqlDbType.Date).Value = date_mezuniyet3.Text;
                    guncellekomutu.Parameters.Add("@notDurumu3", SqlDbType.NVarChar, 50).Value = txt_not3.Text;
                    guncellekomutu.Parameters.Add("@calistigiyer1", SqlDbType.NVarChar, 100).Value = txt_yer1.Text;
                    guncellekomutu.Parameters.Add("@calistigiyer2", SqlDbType.NVarChar, 100).Value = txt_yer2.Text;
                    guncellekomutu.Parameters.Add("@calistigiyer3", SqlDbType.NVarChar, 100).Value = txt_yer3.Text;
                    guncellekomutu.Parameters.Add("@gorev1", SqlDbType.NVarChar, 100).Value = txt_gorev1.Text;
                    guncellekomutu.Parameters.Add("@gorev2", SqlDbType.NVarChar, 100).Value = txt_gorev2.Text;
                    guncellekomutu.Parameters.Add("@gorev3", SqlDbType.NVarChar, 100).Value = txt_gorev3.Text;
                    guncellekomutu.Parameters.Add("@cGirisTarihi1", SqlDbType.Date).Value = date_giris_1.Value;
                    guncellekomutu.Parameters.Add("@cGirisTarihi2", SqlDbType.Date).Value = date_giris_2.Value;
                    guncellekomutu.Parameters.Add("@cGirisTarihi3", SqlDbType.Date).Value = date_giris_3.Value;
                    guncellekomutu.Parameters.Add("@cCikisTarihi1", SqlDbType.Date).Value = date_cikis_1.Value;
                    guncellekomutu.Parameters.Add("@cCikisTarihi2", SqlDbType.Date).Value = date_cikis_2.Value;
                    guncellekomutu.Parameters.Add("@cCikisTarihi3", SqlDbType.Date).Value = date_cikis_3.Value;
                    guncellekomutu.Parameters.Add("@cNeden1", SqlDbType.NVarChar, 100).Value = txt_neden1.Text;
                    guncellekomutu.Parameters.Add("@cNeden2", SqlDbType.NVarChar, 100).Value = txt_neden2.Text;
                    guncellekomutu.Parameters.Add("@cNeden3", SqlDbType.NVarChar, 100).Value = txt_neden3.Text;
                    guncellekomutu.Parameters.Add("@cref1", SqlDbType.NVarChar, 100).Value = txt_ref1.Text;
                    guncellekomutu.Parameters.Add("@cref2", SqlDbType.NVarChar, 100).Value = txt_ref2.Text;
                    guncellekomutu.Parameters.Add("@cref3", SqlDbType.NVarChar, 100).Value = txt_ref3.Text;
                    guncellekomutu.Parameters.Add("@ciletisim1", SqlDbType.NVarChar, 100).Value = txt_iletisim1.Text;
                    guncellekomutu.Parameters.Add("@ciletisim2", SqlDbType.NVarChar, 100).Value = txt_iletisim2.Text;
                    guncellekomutu.Parameters.Add("@ciletisim3", SqlDbType.NVarChar, 100).Value = txt_iletisim3.Text;
                    guncellekomutu.Parameters.Add("@dil1", SqlDbType.NVarChar, 50).Value = cbx_dil1.Text;
                    guncellekomutu.Parameters.Add("@dil2", SqlDbType.NVarChar, 50).Value = cbx_dil2.Text;
                    guncellekomutu.Parameters.Add("@dil3", SqlDbType.NVarChar, 50).Value = cbx_dil3.Text;
                    guncellekomutu.Parameters.Add("@dilseviye1", SqlDbType.NVarChar, 50).Value = cbx_dil_sev1.Text;
                    guncellekomutu.Parameters.Add("@dilseviye2", SqlDbType.NVarChar, 50).Value = cbx_dil_sev2.Text;
                    guncellekomutu.Parameters.Add("@dilseviye3", SqlDbType.NVarChar, 50).Value = cbx_dil_sev3.Text;
                    guncellekomutu.Parameters.Add("@program1", SqlDbType.NVarChar, 100).Value = txt_program1.Text;
                    guncellekomutu.Parameters.Add("@program2", SqlDbType.NVarChar, 100).Value = txt_program2.Text;
                    guncellekomutu.Parameters.Add("@program3", SqlDbType.NVarChar, 100).Value = txt_program3.Text;
                    guncellekomutu.Parameters.Add("@programseviye1", SqlDbType.NVarChar, 50).Value = cbx_bil_sev1.Text;
                    guncellekomutu.Parameters.Add("@programseviye2", SqlDbType.NVarChar, 50).Value = cbx_bil_sev2.Text;
                    guncellekomutu.Parameters.Add("@programseviye3", SqlDbType.NVarChar, 50).Value = cbx_bil_sev3.Text;
                    guncellekomutu.Parameters.Add("@sertifika1", SqlDbType.NVarChar, 100).Value = txt_sertifika1.Text;
                    guncellekomutu.Parameters.Add("@sertifika2", SqlDbType.NVarChar, 100).Value = txt_sertifika2.Text;
                    guncellekomutu.Parameters.Add("@sertifika3", SqlDbType.NVarChar, 100).Value = txt_sertifika3.Text;
                    guncellekomutu.Parameters.Add("@sertifikaa1", SqlDbType.NVarChar, 100).Value = txt_sertifikaa1.Text;
                    guncellekomutu.Parameters.Add("@sertifikaa2", SqlDbType.NVarChar, 100).Value = txt_sertifikaa2.Text;
                    guncellekomutu.Parameters.Add("@sertifikaa3", SqlDbType.NVarChar, 100).Value = txt_sertifikaa3.Text;
                    guncellekomutu.Parameters.Add("@sertifikakurum1", SqlDbType.NVarChar, 100).Value = txt_sertifika_kurum1.Text;
                    guncellekomutu.Parameters.Add("@sertifikakurum2", SqlDbType.NVarChar, 100).Value = txt_sertifika_kurum2.Text;
                    guncellekomutu.Parameters.Add("@sertifikakurum3", SqlDbType.NVarChar, 100).Value = txt_sertifika_kurum3.Text;
                    guncellekomutu.Parameters.Add("@sertifikatarih1", SqlDbType.Date).Value = date_sertifika1.Value;
                    guncellekomutu.Parameters.Add("@sertifikatarih2", SqlDbType.Date).Value = date_sertifika2.Value;
                    guncellekomutu.Parameters.Add("@sertifikatarih3", SqlDbType.Date).Value = date_sertifika3.Value;




                    // guncellekomutu.Parameters.Add("@resim", SqlDbType.Image, resim.Length).Value = resim;

                    guncellekomutu.Parameters.Add("@resim", SqlDbType.Image, resim.Length).Value = resim;

                    //SqlCommand guncellekomutu = new SqlCommand("Guncelle_havuz", baglantim.baglanti());
                    //guncellekomutu.CommandType = CommandType.StoredProcedure;

                    //guncellekomutu.Parameters.AddWithValue("@resim", pbx_resim.Image);
                    //guncellekomutu.Parameters.AddWithValue("@baslik", txt_baslik.Text);
                    //guncellekomutu.Parameters.AddWithValue("@cvLinki", txt_cvdosya.Text);
                    //guncellekomutu.Parameters.AddWithValue("@calismaSekli", cbx_calisma_sekli.Text);
                    //guncellekomutu.Parameters.AddWithValue("@kisi_tc", txt_tc_no.Text);
                    //guncellekomutu.Parameters.AddWithValue("@adi", txt_ad.Text);
                    //guncellekomutu.Parameters.AddWithValue("@soyadi", txt_soyadı.Text);
                    //guncellekomutu.Parameters.AddWithValue("@dogumTarihi", date_dogum.Value);
                    //guncellekomutu.Parameters.AddWithValue("@dogumYeri", txt_dogum.Text);
                    //guncellekomutu.Parameters.AddWithValue("@uyruk", txt_uyruk.Text);
                    //guncellekomutu.Parameters.AddWithValue("@askerlik", cbx_askerlik.Text);
                    //guncellekomutu.Parameters.AddWithValue("@askerlikTarihi", date_askerlik.Value);
                    //guncellekomutu.Parameters.AddWithValue("@adres", txt_adres.Text);
                    //guncellekomutu.Parameters.AddWithValue("@engelDurumu", engelDurumu);
                    //guncellekomutu.Parameters.AddWithValue("@seyehat", seyehatDurumu);
                    //guncellekomutu.Parameters.AddWithValue("@cocukDurumu", cocukDurumu);
                    //guncellekomutu.Parameters.AddWithValue("@cocukSayisi", numeric_cocuk_sayisi.Value);
                    //guncellekomutu.Parameters.AddWithValue("@sektörTecrübesi", sektorTecrube);
                    //guncellekomutu.Parameters.AddWithValue("@kayitTarihi", date_kayit.Value);
                    //guncellekomutu.Parameters.AddWithValue("@kariyerHedefi", txt_kariyerhedefi.Text);
                    //guncellekomutu.Parameters.AddWithValue("@pozisyonTercihi", txt_pozisyon.Text);
                    //guncellekomutu.Parameters.AddWithValue("@cinsiyet", cbx_cinsiyet.Text);
                    //guncellekomutu.Parameters.AddWithValue("@medeniHal", cbx_medeni_hal.Text);
                    //guncellekomutu.Parameters.AddWithValue("@kan", cbx_kan.Text);
                    //guncellekomutu.Parameters.AddWithValue("@eposta", txt_email.Text);
                    //guncellekomutu.Parameters.AddWithValue("@tel", txt_tel_no.Text);
                    //guncellekomutu.Parameters.AddWithValue("@sabikakaydı", sabikaKaydi);
                    //guncellekomutu.Parameters.AddWithValue("@sürücübelgesi", txt_ehliyet.Text);
                    //guncellekomutu.Parameters.AddWithValue("@saglikSorunu", txt_saglik.Text);
                    //guncellekomutu.Parameters.AddWithValue("@sigara", sigaraDurumu);
                    //guncellekomutu.Parameters.AddWithValue("@alkol", alkolDurumu);
                    //guncellekomutu.Parameters.AddWithValue("@ücretBeklentisi", txt_ucret_beklentisi.Text);
                    //guncellekomutu.Parameters.AddWithValue("@egitimSeviye1", cbx_e_seviye1.Text);
                    //guncellekomutu.Parameters.AddWithValue("@egitimDurum1", cbx_e_durum1.Text);
                    //guncellekomutu.Parameters.AddWithValue("@egitimOkul1", txt_e_okul1.Text);
                    //guncellekomutu.Parameters.AddWithValue("@egitimBolum1", txt_e_bolum1.Text);
                    //guncellekomutu.Parameters.AddWithValue("@mezuniyet1", date_mezuniyet1.Text);
                    //guncellekomutu.Parameters.AddWithValue("@notDurumu1", txt_not1.Text);
                    //guncellekomutu.Parameters.AddWithValue("@egitimSeviye2", cbx_e_seviye2.Text);
                    //guncellekomutu.Parameters.AddWithValue("@egitimDurum2", cbx_e_durum2.Text);
                    //guncellekomutu.Parameters.AddWithValue("@egitimOkul2", txt_e_okul2.Text);
                    //guncellekomutu.Parameters.AddWithValue("@egitimBolum2", txt_e_bolum2.Text);
                    //guncellekomutu.Parameters.AddWithValue("@mezuniyet2", date_mezuniyet2.Value);
                    //guncellekomutu.Parameters.AddWithValue("@notDurumu2", txt_not2.Text);
                    //guncellekomutu.Parameters.AddWithValue("@egitimSeviye3", cbx_e_seviye3.Text);
                    //guncellekomutu.Parameters.AddWithValue("@egitimDurum3", cbx_e_durum3.Text);
                    //guncellekomutu.Parameters.AddWithValue("@egitimOkul3", txt_e_okul3.Text);
                    //guncellekomutu.Parameters.AddWithValue("@egitimBolum3", txt_e_bolum3.Text);
                    //guncellekomutu.Parameters.AddWithValue("@mezuniyet3", date_mezuniyet3.Text);
                    //guncellekomutu.Parameters.AddWithValue("@notDurumu3", txt_not3.Text);
                    //guncellekomutu.Parameters.AddWithValue("@calistigiyer1", txt_yer1.Text);
                    //guncellekomutu.Parameters.AddWithValue("@calistigiyer2", txt_yer2.Text);
                    //guncellekomutu.Parameters.AddWithValue("@calistigiyer3", txt_yer3.Text);
                    //guncellekomutu.Parameters.AddWithValue("@gorev1", txt_gorev1.Text);
                    //guncellekomutu.Parameters.AddWithValue("@gorev2", txt_gorev2.Text);
                    //guncellekomutu.Parameters.AddWithValue("@gorev3", txt_gorev3.Text);
                    //guncellekomutu.Parameters.AddWithValue("@cGirisTarihi1", date_giris_1.Value);
                    //guncellekomutu.Parameters.AddWithValue("@cGirisTarihi2", date_giris_2.Value);
                    //guncellekomutu.Parameters.AddWithValue("@cGirisTarihi3", date_giris_3.Value);
                    //guncellekomutu.Parameters.AddWithValue("@cCikisTarihi1", date_cikis_1.Value);
                    //guncellekomutu.Parameters.AddWithValue("@cCikisTarihi2", date_cikis_2.Value);
                    //guncellekomutu.Parameters.AddWithValue("@cCikisTarihi3", date_cikis_3.Value);
                    //guncellekomutu.Parameters.AddWithValue("@cNeden1", txt_neden1.Text);
                    //guncellekomutu.Parameters.AddWithValue("@cNeden2", txt_neden2.Text);
                    //guncellekomutu.Parameters.AddWithValue("@cNeden3", txt_neden3.Text);
                    //guncellekomutu.Parameters.AddWithValue("@cref1", txt_ref1.Text);
                    //guncellekomutu.Parameters.AddWithValue("@cref2", txt_ref2.Text);
                    //guncellekomutu.Parameters.AddWithValue("@cref3", txt_ref3.Text);
                    //guncellekomutu.Parameters.AddWithValue("@ciletisim1", txt_iletisim1.Text);
                    //guncellekomutu.Parameters.AddWithValue("@ciletisim2", txt_iletisim2.Text);
                    //guncellekomutu.Parameters.AddWithValue("@ciletisim3", txt_iletisim3.Text);
                    //guncellekomutu.Parameters.AddWithValue("@dil1", cbx_dil1.Text);
                    //guncellekomutu.Parameters.AddWithValue("@dil2", cbx_dil2.Text);
                    //guncellekomutu.Parameters.AddWithValue("@dil3", cbx_dil3.Text);
                    //guncellekomutu.Parameters.AddWithValue("@dilseviye1", cbx_dil_sev1.Text);
                    //guncellekomutu.Parameters.AddWithValue("@dilseviye2", cbx_dil_sev2.Text);
                    //guncellekomutu.Parameters.AddWithValue("@dilseviye3", cbx_dil_sev3.Text);
                    //guncellekomutu.Parameters.AddWithValue("@program1", txt_program1.Text);
                    //guncellekomutu.Parameters.AddWithValue("@program2", txt_program2.Text);
                    //guncellekomutu.Parameters.AddWithValue("@program3", txt_program3.Text);
                    //guncellekomutu.Parameters.AddWithValue("@programseviye1", cbx_bil_sev1.Text);
                    //guncellekomutu.Parameters.AddWithValue("@programseviye2", cbx_bil_sev2.Text);
                    //guncellekomutu.Parameters.AddWithValue("@programseviye3", cbx_bil_sev3.Text);
                    //guncellekomutu.Parameters.AddWithValue("@sertifika1", txt_sertifika1.Text);
                    //guncellekomutu.Parameters.AddWithValue("@sertifika2", txt_sertifika2.Text);
                    //guncellekomutu.Parameters.AddWithValue("@sertifika3", txt_sertifika3.Text);
                    //guncellekomutu.Parameters.AddWithValue("@sertifikaa1", txt_sertifikaa1.Text);
                    //guncellekomutu.Parameters.AddWithValue("@sertifikaa2", txt_sertifikaa2.Text);
                    //guncellekomutu.Parameters.AddWithValue("@sertifikaa3", txt_sertifikaa3.Text);
                    //guncellekomutu.Parameters.AddWithValue("@sertifikakurum1", txt_sertifika_kurum1.Text);
                    //guncellekomutu.Parameters.AddWithValue("@sertifikakurum2", txt_sertifika_kurum2.Text);
                    //guncellekomutu.Parameters.AddWithValue("@sertifikakurum3", txt_sertifika_kurum3.Text);
                    //guncellekomutu.Parameters.AddWithValue("@sertifikatarih1", date_sertifika1.Value);
                    //guncellekomutu.Parameters.AddWithValue("@sertifikatarih2", date_sertifika2.Value);
                    //guncellekomutu.Parameters.AddWithValue("@sertifikatarih3", date_sertifika3.Value);

                    guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    MessageBox.Show("Kişi havuza başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
                catch (Exception hatamjs)
                {

                    SqlCommand guncellekomutu = new SqlCommand("update tbl_havuz set  baslik = @baslik,cvLinki = @cvLinki,calismaSekli = @calismaSekli, kisi_tc = @kisi_tc, adi = @adi,soyadi = @soyadi,dogumTarihi = @dogumTarihi, dogumYeri = @dogumYeri,uyruk = @uyruk, askerlik = @askerlik,askerlikTarihi = @askerlikTarihi, adres = @adres,engelDurumu = @engelDurumu, seyehat = @seyehat,cocukDurumu = @cocukDurumu, cocukSayisi = @cocukSayisi,sektörTecrübesi = @sektörTecrübesi,kayitTarihi = @kayitTarihi,kariyerHedefi = @kariyerHedefi,pozisyonTercihi = @pozisyonTercihi,cinsiyet = @cinsiyet,medeniHal = @medeniHal,kan = @kan,eposta = @eposta,tel = @tel,sabikakaydı = @sabikakaydı,sürücübelgesi = @sürücübelgesi,saglikSorunu = @saglikSorunu,sigara = @sigara,alkol = @alkol, ücretBeklentisi = @ücretBeklentisi,egitimSeviye1 = @egitimSeviye1, egitimDurum1 = @egitimDurum1,egitimOkul1 = @egitimOkul1,egitimBolum1 = @egitimBolum1,mezuniyet1 = @mezuniyet1,notDurumu1 = @notDurumu1,egitimSeviye2 = @egitimSeviye2,egitimDurum2 = @egitimDurum2,egitimOkul2 = @egitimOkul2,egitimBolum2 = @egitimBolum2,mezuniyet2 = @mezuniyet2,notDurumu2 = @notDurumu2,egitimSeviye3 = @egitimSeviye3,egitimDurum3 = @egitimDurum3,egitimOkul3 = @egitimOkul3,egitimBolum3 = @egitimBolum3,mezuniyet3 = @mezuniyet3,notDurumu3 = @notDurumu3,calistigiyer1 = @calistigiyer1,calistigiyer2 = @calistigiyer2,calistigiyer3 = @calistigiyer3,gorev1 = @gorev1, gorev2 = @gorev2,gorev3 = @gorev3,cGirisTarihi1 = @cGirisTarihi1,cGirisTarihi2 = @cGirisTarihi2," +
                       "cGirisTarihi3 = @cGirisTarihi3,cCikisTarihi1 = @cCikisTarihi1,cCikisTarihi2 = @cCikisTarihi2,cCikisTarihi3 = @cCikisTarihi3,cNeden1 = @cNeden1,cNeden2 = @cNeden2,cNeden3 = @cNeden3,cref1 = @cref1,cref2 = @cref2,cref3 = @cref3,ciletisim1 = @ciletisim1,ciletisim2 = @ciletisim2,ciletisim3 = @ciletisim3,dil1 = @dil1,dil2 = @dil2,dil3 = @dil3,dilseviye1 = @dilseviye1,dilseviye2 = @dilseviye2,dilseviye3 = @dilseviye3,program1 = @program1,program2 = @program2,program3 = @program3,programseviye1 = @programseviye1,programseviye2 = @programseviye2,programseviye3 = @programseviye3,sertifika1 = @sertifika1,sertifika2 = @sertifika2,sertifika3 = @sertifika3,sertifikaa1 = @sertifikaa1,sertifikaa2 = @sertifikaa2,sertifikaa3 = @sertifikaa3,sertifikakurum1 = @sertifikakurum1,sertifikakurum2 = @sertifikakurum2,sertifikakurum3 = @sertifikakurum3,sertifikatarih1 = @sertifikatarih1,sertifikatarih2 = @sertifikatarih2,sertifikatarih3 = @sertifikatarih3 where kisi_tc = @kisi_tc", baglantim.baglanti());



                    guncellekomutu.Parameters.Add("@baslik", SqlDbType.NVarChar, 50).Value = txt_baslik.Text;
                    guncellekomutu.Parameters.Add("@cvLinki", SqlDbType.NVarChar, 50).Value = lnk_lbl_1.Text;
                    guncellekomutu.Parameters.Add("@calismaSekli", SqlDbType.NVarChar, 50).Value = cbx_calisma_sekli.Text;
                    guncellekomutu.Parameters.Add("@kisi_tc", SqlDbType.NVarChar, 11).Value = txt_tc_no.Text;
                    guncellekomutu.Parameters.Add("@adi", SqlDbType.NVarChar, 100).Value = txt_ad.Text;
                    guncellekomutu.Parameters.Add("@soyadi", SqlDbType.NVarChar, 100).Value = txt_soyadı.Text;
                    guncellekomutu.Parameters.Add("@dogumTarihi", SqlDbType.Date).Value = date_dogum.Value;
                    guncellekomutu.Parameters.Add("@dogumYeri", SqlDbType.NVarChar, 100).Value = txt_dogum.Text;
                    guncellekomutu.Parameters.Add("@uyruk", SqlDbType.NVarChar, 50).Value = txt_uyruk.Text;
                    guncellekomutu.Parameters.Add("@askerlik", SqlDbType.NVarChar, 50).Value = cbx_askerlik.Text;
                    guncellekomutu.Parameters.Add("@askerlikTarihi", SqlDbType.Date).Value = date_askerlik.Value;
                    guncellekomutu.Parameters.Add("@adres", SqlDbType.NVarChar, 500).Value = txt_adres.Text;
                    guncellekomutu.Parameters.Add("@engelDurumu", SqlDbType.NVarChar, 50).Value = engelDurumu;
                    guncellekomutu.Parameters.Add("@seyehat", SqlDbType.NVarChar, 50).Value = seyehatDurumu;
                    guncellekomutu.Parameters.Add("@cocukDurumu", SqlDbType.NVarChar, 50).Value = cocukDurumu;
                    guncellekomutu.Parameters.Add("@cocukSayisi", SqlDbType.Int).Value = numeric_cocuk_sayisi.Value;
                    guncellekomutu.Parameters.Add("@sektörTecrübesi", SqlDbType.NVarChar, 50).Value = sektorTecrube;
                    guncellekomutu.Parameters.Add("@kayitTarihi", SqlDbType.Date).Value = date_kayit.Value;
                    guncellekomutu.Parameters.Add("@kariyerHedefi", SqlDbType.NVarChar, 100).Value = txt_kariyerhedefi.Text;
                    guncellekomutu.Parameters.Add("@pozisyonTercihi", SqlDbType.NVarChar, 500).Value = txt_pozisyon.Text;
                    guncellekomutu.Parameters.Add("@cinsiyet", SqlDbType.NVarChar, 50).Value = cbx_cinsiyet.Text;
                    guncellekomutu.Parameters.Add("@medeniHal", SqlDbType.NVarChar, 50).Value = cbx_medeni_hal.Text;
                    guncellekomutu.Parameters.Add("@kan", SqlDbType.NVarChar, 50).Value = cbx_kan.Text;
                    guncellekomutu.Parameters.Add("@eposta", SqlDbType.NVarChar, 500).Value = txt_email.Text;
                    guncellekomutu.Parameters.Add("@tel", SqlDbType.NVarChar, 50).Value = txt_tel_no.Text;
                    guncellekomutu.Parameters.Add("@sabikakaydı", SqlDbType.NVarChar, 50).Value = sabikaKaydi;
                    guncellekomutu.Parameters.Add("@sürücübelgesi", SqlDbType.NVarChar, 50).Value = txt_ehliyet.Text;
                    guncellekomutu.Parameters.Add("@saglikSorunu", SqlDbType.NVarChar, 500).Value = txt_saglik.Text;
                    guncellekomutu.Parameters.Add("@sigara", SqlDbType.NVarChar, 50).Value = sigaraDurumu;
                    guncellekomutu.Parameters.Add("@alkol", SqlDbType.NVarChar, 50).Value = alkolDurumu;
                    guncellekomutu.Parameters.Add("@ücretBeklentisi", SqlDbType.Float).Value = txt_ucret_beklentisi.Text;
                    guncellekomutu.Parameters.Add("@egitimSeviye1", SqlDbType.NVarChar, 50).Value = cbx_e_seviye1.Text;
                    guncellekomutu.Parameters.Add("@egitimDurum1", SqlDbType.NVarChar, 50).Value = cbx_e_durum1.Text;
                    guncellekomutu.Parameters.Add("@egitimOkul1", SqlDbType.NVarChar, 100).Value = txt_e_okul1.Text;
                    guncellekomutu.Parameters.Add("@egitimBolum1", SqlDbType.NVarChar, 500).Value = txt_e_bolum1.Text;
                    guncellekomutu.Parameters.Add("@mezuniyet1", SqlDbType.Date).Value = date_mezuniyet1.Text;
                    guncellekomutu.Parameters.Add("@notDurumu1", SqlDbType.NVarChar, 50).Value = txt_not1.Text;
                    guncellekomutu.Parameters.Add("@egitimSeviye2", SqlDbType.NVarChar, 50).Value = cbx_e_seviye2.Text;
                    guncellekomutu.Parameters.Add("@egitimDurum2", SqlDbType.NVarChar, 50).Value = cbx_e_durum2.Text;
                    guncellekomutu.Parameters.Add("@egitimOkul2", SqlDbType.NVarChar, 100).Value = txt_e_okul2.Text;
                    guncellekomutu.Parameters.Add("@egitimBolum2", SqlDbType.NVarChar, 500).Value = txt_e_bolum2.Text;
                    guncellekomutu.Parameters.Add("@mezuniyet2", SqlDbType.Date).Value = date_mezuniyet2.Value;
                    guncellekomutu.Parameters.Add("@notDurumu2", SqlDbType.NVarChar, 50).Value = txt_not2.Text;
                    guncellekomutu.Parameters.Add("@egitimSeviye3", SqlDbType.NVarChar, 50).Value = cbx_e_seviye3.Text;
                    guncellekomutu.Parameters.Add("@egitimDurum3", SqlDbType.NVarChar, 50).Value = cbx_e_durum3.Text;
                    guncellekomutu.Parameters.Add("@egitimOkul3", SqlDbType.NVarChar, 100).Value = txt_e_okul3.Text;
                    guncellekomutu.Parameters.Add("@egitimBolum3", SqlDbType.NVarChar, 500).Value = txt_e_bolum3.Text;
                    guncellekomutu.Parameters.Add("@mezuniyet3", SqlDbType.Date).Value = date_mezuniyet3.Text;
                    guncellekomutu.Parameters.Add("@notDurumu3", SqlDbType.NVarChar, 50).Value = txt_not3.Text;
                    guncellekomutu.Parameters.Add("@calistigiyer1", SqlDbType.NVarChar, 100).Value = txt_yer1.Text;
                    guncellekomutu.Parameters.Add("@calistigiyer2", SqlDbType.NVarChar, 100).Value = txt_yer2.Text;
                    guncellekomutu.Parameters.Add("@calistigiyer3", SqlDbType.NVarChar, 100).Value = txt_yer3.Text;
                    guncellekomutu.Parameters.Add("@gorev1", SqlDbType.NVarChar, 100).Value = txt_gorev1.Text;
                    guncellekomutu.Parameters.Add("@gorev2", SqlDbType.NVarChar, 100).Value = txt_gorev2.Text;
                    guncellekomutu.Parameters.Add("@gorev3", SqlDbType.NVarChar, 100).Value = txt_gorev3.Text;
                    guncellekomutu.Parameters.Add("@cGirisTarihi1", SqlDbType.Date).Value = date_giris_1.Value;
                    guncellekomutu.Parameters.Add("@cGirisTarihi2", SqlDbType.Date).Value = date_giris_2.Value;
                    guncellekomutu.Parameters.Add("@cGirisTarihi3", SqlDbType.Date).Value = date_giris_3.Value;
                    guncellekomutu.Parameters.Add("@cCikisTarihi1", SqlDbType.Date).Value = date_cikis_1.Value;
                    guncellekomutu.Parameters.Add("@cCikisTarihi2", SqlDbType.Date).Value = date_cikis_2.Value;
                    guncellekomutu.Parameters.Add("@cCikisTarihi3", SqlDbType.Date).Value = date_cikis_3.Value;
                    guncellekomutu.Parameters.Add("@cNeden1", SqlDbType.NVarChar, 100).Value = txt_neden1.Text;
                    guncellekomutu.Parameters.Add("@cNeden2", SqlDbType.NVarChar, 100).Value = txt_neden2.Text;
                    guncellekomutu.Parameters.Add("@cNeden3", SqlDbType.NVarChar, 100).Value = txt_neden3.Text;
                    guncellekomutu.Parameters.Add("@cref1", SqlDbType.NVarChar, 100).Value = txt_ref1.Text;
                    guncellekomutu.Parameters.Add("@cref2", SqlDbType.NVarChar, 100).Value = txt_ref2.Text;
                    guncellekomutu.Parameters.Add("@cref3", SqlDbType.NVarChar, 100).Value = txt_ref3.Text;
                    guncellekomutu.Parameters.Add("@ciletisim1", SqlDbType.NVarChar, 100).Value = txt_iletisim1.Text;
                    guncellekomutu.Parameters.Add("@ciletisim2", SqlDbType.NVarChar, 100).Value = txt_iletisim2.Text;
                    guncellekomutu.Parameters.Add("@ciletisim3", SqlDbType.NVarChar, 100).Value = txt_iletisim3.Text;
                    guncellekomutu.Parameters.Add("@dil1", SqlDbType.NVarChar, 50).Value = cbx_dil1.Text;
                    guncellekomutu.Parameters.Add("@dil2", SqlDbType.NVarChar, 50).Value = cbx_dil2.Text;
                    guncellekomutu.Parameters.Add("@dil3", SqlDbType.NVarChar, 50).Value = cbx_dil3.Text;
                    guncellekomutu.Parameters.Add("@dilseviye1", SqlDbType.NVarChar, 50).Value = cbx_dil_sev1.Text;
                    guncellekomutu.Parameters.Add("@dilseviye2", SqlDbType.NVarChar, 50).Value = cbx_dil_sev2.Text;
                    guncellekomutu.Parameters.Add("@dilseviye3", SqlDbType.NVarChar, 50).Value = cbx_dil_sev3.Text;
                    guncellekomutu.Parameters.Add("@program1", SqlDbType.NVarChar, 100).Value = txt_program1.Text;
                    guncellekomutu.Parameters.Add("@program2", SqlDbType.NVarChar, 100).Value = txt_program2.Text;
                    guncellekomutu.Parameters.Add("@program3", SqlDbType.NVarChar, 100).Value = txt_program3.Text;
                    guncellekomutu.Parameters.Add("@programseviye1", SqlDbType.NVarChar, 50).Value = cbx_bil_sev1.Text;
                    guncellekomutu.Parameters.Add("@programseviye2", SqlDbType.NVarChar, 50).Value = cbx_bil_sev2.Text;
                    guncellekomutu.Parameters.Add("@programseviye3", SqlDbType.NVarChar, 50).Value = cbx_bil_sev3.Text;
                    guncellekomutu.Parameters.Add("@sertifika1", SqlDbType.NVarChar, 100).Value = txt_sertifika1.Text;
                    guncellekomutu.Parameters.Add("@sertifika2", SqlDbType.NVarChar, 100).Value = txt_sertifika2.Text;
                    guncellekomutu.Parameters.Add("@sertifika3", SqlDbType.NVarChar, 100).Value = txt_sertifika3.Text;
                    guncellekomutu.Parameters.Add("@sertifikaa1", SqlDbType.NVarChar, 100).Value = txt_sertifikaa1.Text;
                    guncellekomutu.Parameters.Add("@sertifikaa2", SqlDbType.NVarChar, 100).Value = txt_sertifikaa2.Text;
                    guncellekomutu.Parameters.Add("@sertifikaa3", SqlDbType.NVarChar, 100).Value = txt_sertifikaa3.Text;
                    guncellekomutu.Parameters.Add("@sertifikakurum1", SqlDbType.NVarChar, 100).Value = txt_sertifika_kurum1.Text;
                    guncellekomutu.Parameters.Add("@sertifikakurum2", SqlDbType.NVarChar, 100).Value = txt_sertifika_kurum2.Text;
                    guncellekomutu.Parameters.Add("@sertifikakurum3", SqlDbType.NVarChar, 100).Value = txt_sertifika_kurum3.Text;
                    guncellekomutu.Parameters.Add("@sertifikatarih1", SqlDbType.Date).Value = date_sertifika1.Value;
                    guncellekomutu.Parameters.Add("@sertifikatarih2", SqlDbType.Date).Value = date_sertifika2.Value;
                    guncellekomutu.Parameters.Add("@sertifikatarih3", SqlDbType.Date).Value = date_sertifika3.Value;


                    guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    MessageBox.Show("Kişi havuza başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                    ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                }
            }
            else
            {
                MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçirniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (txt_tc_no.Text.Length == 11)
            {
                bool kayit_arama_durumu = false;
                //baglantim.baglanti().Open();
                SqlCommand secmeSorgusu = new SqlCommand("Select *from tbl_havuz where kisi_tc='" + txt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                while (kayitokuma.Read())
                {

                    //kayıt okuma gerçekleşti ise
                    kayit_arama_durumu = true;
                    SqlCommand silsorgusu = new SqlCommand("delete from tbl_havuz where kisi_tc='" + txt_tc_no.Text + "'", baglantim.baglanti());
                    //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                    silsorgusu.ExecuteNonQuery();

                    MessageBox.Show("Kullanıcı kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //baglantim.baglanti().Close();

                    ekrani_temizle();
                    break;
                }
                //girilen tck ya göre bir kayıt bulunmaz ise
                if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                {
                    MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                //baglantim.baglanti().Close();
                ekrani_temizle();


            }
            else
            {
                MessageBox.Show("TC kimlik no 11 haneli girilmelidir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            ekrani_temizle();
        }

        private void btn_cikti_Click(object sender, EventArgs e)
        {
            printDocument1.Print();

        }

        private void cx_engel_var_CheckedChanged(object sender, EventArgs e)
        {
            if (cx_engel_var.Checked == true)
            {
                cx_engel_yok.Checked = false;
            }
        }

        private void cx_engel_yok_CheckedChanged(object sender, EventArgs e)
        {
            if (cx_engel_yok.Checked == true)
            {
                cx_engel_var.Checked = false;
            }
        }

        private void cx_sey_e_CheckedChanged(object sender, EventArgs e)
        {
            if (cx_sey_e.Checked == true)
            {
                cx_sey_h.Checked = false;
            }
        }

        private void cx_sey_h_CheckedChanged(object sender, EventArgs e)
        {
            if (cx_sey_h.Checked == true)
            {
                cx_sey_e.Checked = false;
            }
        }

        private void cx_cocuk_var_CheckedChanged(object sender, EventArgs e)
        {
            if (cx_cocuk_var.Checked == true)
            {
                cx_cocuk_yok.Checked = false;
            }
        }

        private void cx_cocuk_yok_CheckedChanged(object sender, EventArgs e)
        {
            if (cx_cocuk_yok.Checked == true)
            {
                cx_cocuk_var.Checked = false;
            }
        }

        private void cx_sektor_var_CheckedChanged(object sender, EventArgs e)
        {
            if (cx_sektor_var.Checked == true)
            {
                cx_sektor_yok.Checked = false;
            }
        }

        private void cx_sektor_yok_CheckedChanged(object sender, EventArgs e)
        {
            if (cx_sektor_yok.Checked == true)
            {
                cx_sektor_var.Checked = false;
            }
        }

        PrintDocument YaziciCiktisi = new PrintDocument();

        int a = 1;

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
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
                case 1:
                    //  System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
                    //Document document = new Document();

                    Document document = new Document(PageSize.A4, 10f, 10f, 10f, 10f);//???

                    document.SetPageSize(iTextSharp.text.PageSize.A4);

                    // PdfWriter writer = PdfWriter.GetInstance(document, fs);//yazıyorrr 
                    document.Open();

                    e.Graphics.DrawLine(myPen, 100, 50, 750, 50);

                    e.Graphics.DrawString("HAVUZ PERSONEL BİLGİ FORMU", ustFont, sbbrush, (sayfa_genisligi / 2) + 50, 30);

                    ustFont = new System.Drawing.Font("Calibri", 12, FontStyle.Bold);

                    e.Graphics.DrawImage(resim.Image, 10, 10, 100, 100);

                    //e.Graphics.DrawString(".............................................", myFont, sb, 70, 170);
                    e.Graphics.DrawString(label1.Text + " : " + txt_baslik.Text, myFont1, sb1, 100, 125);
                    e.Graphics.DrawString(label2.Text + " : " + txt_cvdosya.Text, myFont1, sb1, 100, 150);
                    e.Graphics.DrawString(label3.Text + " : " + cbx_calisma_sekli.Text, myFont1, sb1, 100, 175);
                    e.Graphics.DrawString(label4.Text + " : " + txt_tc_no.Text, myFont1, sb1, 100, 200);

                    e.Graphics.DrawString(label5.Text + " : " + txt_ad.Text, myFont1, sb1, 100, 225);
                    e.Graphics.DrawString(label6.Text + " : " + txt_soyadı.Text, myFont1, sb1, 100, 250);
                    e.Graphics.DrawString(label7.Text + " : " + date_dogum.Text, myFont1, sb1, 100, 275);
                    e.Graphics.DrawString(label8.Text + " : " + txt_dogum.Text, myFont1, sb1, 100, 300);

                    e.Graphics.DrawString(label13.Text + " : " + txt_uyruk.Text, myFont1, sb1, 100, 325);
                    e.Graphics.DrawString(label9.Text + " : " + cbx_askerlik.Text + " " + date_askerlik.Text, myFont1, sb1, 100, 350);
                    e.Graphics.DrawString(label11.Text + " : " + txt_adres.Text, myFont1, sb1, 100, 375);
                    e.Graphics.DrawString(txt_adres.Text, myFont1, sb1, 100, 400);
                    e.Graphics.DrawString(label12.Text + " : " + engelDurumu, myFont1, sb1, 100, 425);

                    e.Graphics.DrawString(label16.Text + " : " + seyehatDurumu, myFont1, sb1, 100, 450);
                    e.Graphics.DrawString(label14.Text + " : " + cocukDurumu, myFont1, sb1, 400, 75);
                    e.Graphics.DrawString(label29.Text + " : " + numeric_cocuk_sayisi.Value, myFont1, sb1, 400, 100);
                    e.Graphics.DrawString(label17.Text + " : " + sektorTecrube, myFont1, sb1, 400, 125);
                    e.Graphics.DrawString(label18.Text + " : " + date_kayit.Text, myFont1, sb1, 400, 150);
                    e.Graphics.DrawString(label19.Text + " : " + txt_kariyerhedefi.Text, myFont1, sb1, 400, 175);
                    e.Graphics.DrawString(label20.Text + " : " + txt_pozisyon.Text, myFont1, sb1, 400, 200);
                    e.Graphics.DrawString(label21.Text + " : " + cbx_cinsiyet.Text, myFont1, sb1, 400, 225);

                    e.Graphics.DrawString(label22.Text + " : " + cbx_medeni_hal.Text, myFont1, sb1, 400, 250);
                    e.Graphics.DrawString(label24.Text + " : " + cbx_kan.Text, myFont1, sb1, 400, 275);
                    e.Graphics.DrawString(label25.Text + " : " + txt_email.Text, myFont1, sb1, 400, 300);
                    e.Graphics.DrawString(label26.Text + " : " + txt_tel_no.Text, myFont1, sb1, 400, 325);
                    e.Graphics.DrawString(label27.Text + " : " + sabikaKaydi, myFont1, sb1, 400, 350);
                    e.Graphics.DrawString(label28.Text + " : " + txt_ehliyet.Text, myFont1, sb1, 400, 375);
                    e.Graphics.DrawString(label15.Text + " : " + txt_saglik.Text, myFont1, sb1, 400, 400);
                    e.Graphics.DrawString(label30.Text + " : " + sigaraDurumu, myFont1, sb1, 400, 425);

                    e.Graphics.DrawString(label31.Text + " : " + alkolDurumu, myFont1, sb1, 400, 450);
                    e.Graphics.DrawString(label32.Text + " : " + txt_ucret_beklentisi.Text, myFont1, sb1, 400, 475);

                    e.Graphics.DrawString("EĞİTİM BİLGİLERİ", cizgiFont, sbcizgi, 100, 500);


                    e.Graphics.DrawString(label62.Text, myFont1, sb1, 100, 525);//EĞİTİM SEVİYESİ
                    e.Graphics.DrawString(cbx_e_seviye1.Text, myFont1, sb1, 100, 550);
                    e.Graphics.DrawString(cbx_e_seviye2.Text, myFont1, sb1, 100, 575);
                    e.Graphics.DrawString(cbx_e_seviye3.Text, myFont1, sb1, 100, 600);

                    e.Graphics.DrawString(label61.Text, myFont1, sb1, 175, 525);//DURUM
                    e.Graphics.DrawString(cbx_e_durum1.Text, myFont1, sb1, 175, 550);
                    e.Graphics.DrawString(cbx_e_durum2.Text, myFont1, sb1, 175, 575);
                    e.Graphics.DrawString(cbx_e_durum3.Text, myFont1, sb1, 175, 600);

                    e.Graphics.DrawString(label55.Text, myFont1, sb1, 225, 525);//OKUL ADI
                    e.Graphics.DrawString(txt_e_okul1.Text, myFont1, sb1, 225, 550);
                    e.Graphics.DrawString(txt_e_okul2.Text, myFont1, sb1, 225, 575);
                    e.Graphics.DrawString(txt_e_okul3.Text, myFont1, sb1, 225, 600);

                    e.Graphics.DrawString(label54.Text, myFont1, sb1, 425, 525);//BÖLÜM
                    e.Graphics.DrawString(txt_e_bolum1.Text, myFont1, sb1, 425, 550);
                    e.Graphics.DrawString(txt_e_bolum2.Text, myFont1, sb1, 425, 575);
                    e.Graphics.DrawString(txt_e_bolum3.Text, myFont1, sb1, 425, 600);

                    e.Graphics.DrawString(label53.Text, myFont1, sb1, 575, 525);//MEZUNİYET TARİHİ
                    e.Graphics.DrawString(date_mezuniyet1.Text, myFont1, sb1, 575, 550);
                    e.Graphics.DrawString(date_mezuniyet2.Text, myFont1, sb1, 575, 575);
                    e.Graphics.DrawString(date_mezuniyet3.Text, myFont1, sb1, 575, 600);

                    e.Graphics.DrawString(label52.Text, myFont1, sb1, 700, 525);//NOT DURUMU
                    e.Graphics.DrawString(txt_not1.Text, myFont1, sb1, 700, 550);
                    e.Graphics.DrawString(txt_not2.Text, myFont1, sb1, 700, 575);
                    e.Graphics.DrawString(txt_not3.Text, myFont1, sb1, 700, 600);


                    e.Graphics.DrawString("İŞ DENEYİMİ", cizgiFont, sbcizgi, 100, 625);


                    e.Graphics.DrawString(label86.Text, myFont1, sb1, 100, 650);//EĞİTİM SEVİYESİ
                    e.Graphics.DrawString(txt_yer1.Text, myFont1, sb1, 100, 675);
                    e.Graphics.DrawString(txt_yer2.Text, myFont1, sb1, 100, 700);
                    e.Graphics.DrawString(txt_yer3.Text, myFont1, sb1, 100, 725);

                    e.Graphics.DrawString(label85.Text, myFont1, sb1, 225, 650);//DURUM
                    e.Graphics.DrawString(txt_gorev1.Text, myFont1, sb1, 225, 675);
                    e.Graphics.DrawString(txt_gorev2.Text, myFont1, sb1, 225, 700);
                    e.Graphics.DrawString(txt_gorev3.Text, myFont1, sb1, 225, 725);

                    e.Graphics.DrawString(label84.Text, myFont1, sb1, 300, 650);//OKUL ADI
                    e.Graphics.DrawString(date_giris_1.Text, myFont1, sb1, 300, 675);
                    e.Graphics.DrawString(date_giris_2.Text, myFont1, sb1, 300, 700);
                    e.Graphics.DrawString(date_giris_3.Text, myFont1, sb1, 300, 725);

                    e.Graphics.DrawString(label83.Text, myFont1, sb1, 400, 650);//BÖLÜM
                    e.Graphics.DrawString(date_cikis_1.Text, myFont1, sb1, 400, 675);
                    e.Graphics.DrawString(date_cikis_2.Text, myFont1, sb1, 400, 700);
                    e.Graphics.DrawString(date_cikis_3.Text, myFont1, sb1, 400, 725);

                    e.Graphics.DrawString(label82.Text, myFont1, sb1, 500, 650);//MEZUNİYET TARİHİ
                    e.Graphics.DrawString(txt_neden1.Text, myFont1, sb1, 500, 675);
                    e.Graphics.DrawString(txt_neden2.Text, myFont1, sb1, 500, 700);
                    e.Graphics.DrawString(txt_neden3.Text, myFont1, sb1, 500, 725);

                    e.Graphics.DrawString(label81.Text, myFont1, sb1, 600, 650);//NOT DURUMU
                    e.Graphics.DrawString(txt_ref1.Text, myFont1, sb1, 600, 675);
                    e.Graphics.DrawString(txt_ref2.Text, myFont1, sb1, 600, 700);
                    e.Graphics.DrawString(txt_ref3.Text, myFont1, sb1, 600, 725);

                    e.Graphics.DrawString(label80.Text, myFont1, sb1, 700, 650);//NOT DURUMU
                    e.Graphics.DrawString(txt_iletisim1.Text, myFont1, sb1, 700, 675);
                    e.Graphics.DrawString(txt_iletisim2.Text, myFont1, sb1, 700, 700);
                    e.Graphics.DrawString(txt_iletisim3.Text, myFont1, sb1, 700, 725);

                    e.Graphics.DrawString("YABANCI DİL", cizgiFont, sbcizgi, 100, 750);


                    e.Graphics.DrawString(label91.Text, myFont1, sb1, 100, 775);//EĞİTİM SEVİYESİ
                    e.Graphics.DrawString(cbx_dil1.Text, myFont1, sb1, 100, 800);
                    e.Graphics.DrawString(cbx_dil2.Text, myFont1, sb1, 100, 825);
                    e.Graphics.DrawString(cbx_dil3.Text, myFont1, sb1, 100, 850);

                    e.Graphics.DrawString(label90.Text, myFont1, sb1, 225, 775);//DURUM
                    e.Graphics.DrawString(cbx_dil_sev1.Text, myFont1, sb1, 225, 800);
                    e.Graphics.DrawString(cbx_dil_sev2.Text, myFont1, sb1, 225, 825);
                    e.Graphics.DrawString(cbx_dil_sev3.Text, myFont1, sb1, 225, 850);

                    e.Graphics.DrawString("BİLGİSAYAR BİLGİLERİ", cizgiFont, sbcizgi, 400, 750);


                    e.Graphics.DrawString(label96.Text, myFont1, sb1, 400, 775);//EĞİTİM SEVİYESİ
                    e.Graphics.DrawString(txt_program1.Text, myFont1, sb1, 400, 800);
                    e.Graphics.DrawString(txt_program2.Text, myFont1, sb1, 400, 825);
                    e.Graphics.DrawString(txt_program3.Text, myFont1, sb1, 400, 850);

                    e.Graphics.DrawString(label95.Text, myFont1, sb1, 575, 775);//DURUM
                    e.Graphics.DrawString(cbx_bil_sev1.Text, myFont1, sb1, 575, 800);
                    e.Graphics.DrawString(cbx_bil_sev2.Text, myFont1, sb1, 575, 825);
                    e.Graphics.DrawString(cbx_bil_sev3.Text, myFont1, sb1, 575, 850);


                    e.Graphics.DrawString("SERTİFİKA BİLGİLERİ", cizgiFont, sbcizgi, 100, 875);


                    e.Graphics.DrawString(label103.Text, myFont1, sb1, 100, 900);//SERTİFİKA ADI
                    e.Graphics.DrawString(txt_sertifika1.Text, myFont1, sb1, 100, 925);
                    e.Graphics.DrawString(txt_sertifika2.Text, myFont1, sb1, 100, 950);
                    e.Graphics.DrawString(txt_sertifika3.Text, myFont1, sb1, 100, 975);

                    e.Graphics.DrawString(label102.Text, myFont1, sb1, 250, 900);//AÇIKLAMA
                    e.Graphics.DrawString(txt_sertifikaa1.Text, myFont1, sb1, 250, 925);
                    e.Graphics.DrawString(txt_sertifikaa1.Text, myFont1, sb1, 250, 950);
                    e.Graphics.DrawString(txt_sertifikaa1.Text, myFont1, sb1, 250, 975);

                    e.Graphics.DrawString(label101.Text, myFont1, sb1, 400, 900);//ALDIĞI KURUM
                    e.Graphics.DrawString(txt_sertifika_kurum1.Text, myFont1, sb1, 400, 925);
                    e.Graphics.DrawString(txt_sertifika_kurum2.Text, myFont1, sb1, 400, 950);
                    e.Graphics.DrawString(txt_sertifika_kurum3.Text, myFont1, sb1, 400, 975);

                    e.Graphics.DrawString(label100.Text, myFont1, sb1, 550, 900);//TARİH
                    e.Graphics.DrawString(date_sertifika1.Text, myFont1, sb1, 550, 925);
                    e.Graphics.DrawString(date_sertifika2.Text, myFont1, sb1, 550, 950);
                    e.Graphics.DrawString(date_sertifika3.Text, myFont1, sb1, 550, 975);


                    e.Graphics.DrawString("İş Başvurusu Ön Bilgilendirme Formudur. Optimak STU İnsan Kaynakları", cizgiFont, sbcizgi, 100, 1125);





                    break;
            }


        }
        string DosyaYolu;

        private void btn_cvekle_Click(object sender, EventArgs e)
        {
            if (txt_tc_no.Text.Length == 11)
            {
                aktifKullanici.kisi = txt_tc_no.Text;
                string dosya_yolu = "C:\\Dosyalar\\Havuz";
                if (Directory.Exists(dosya_yolu))
                {
                    MessageBox.Show("Dosya bulundu", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //evrakEkleme evrak = new evrakEkleme();
                    //evrak.ShowDialog();
                }
                else
                {

                    try
                    {
                        Directory.CreateDirectory(@"C://Dosyalar//Havuz/" + "/");
                        MessageBox.Show("Dosya başarılı bir şekilde oluşturulmuştur.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //evrakEkleme evrak = new evrakEkleme();
                        //evrak.ShowDialog();

                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Dosya oluşturulamadı", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (btn_cvekle.Tag != null)
                {
                    if (!String.IsNullOrWhiteSpace(btn_cvekle.Tag.ToString()))
                    {
                        System.Diagnostics.Process.Start(btn_cvekle.Tag.ToString());
                        return;
                    }
                }

                OpenFileDialog dosya = new OpenFileDialog();
                dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";

                if (dosya.ShowDialog() == DialogResult.OK)
                {
                    dosyaYolu = dosya.FileName;

                    dosyaAdi = Path.GetFileName(dosyaYolu); //Dosya adını alma
                    string kaynak = dosyaYolu;
                    string hedef = (@"C://Dosyalar//Havuz//");
                    // MessageBox.Show(hedef);
                    string yeniad = txt_tc_no.Text + "_" + txt_ad.Text + "_" + txt_soyadı.Text + ".pdf"; //Benzersiz isim verme

                    DosyaYolu = @"C://Dosyalar//Havuz//" + yeniad;
                    File.Copy(kaynak, hedef + yeniad, true);
                    //btn_kimlik.Tag = hedef + yeniad;
                    //btn_kimlik.ForeColor = Color.Red;
                    lnk_lbl_1.Tag = hedef + yeniad;
                    lnk_lbl_1.Text = "CV Göster";
                    lnk_lbl_1.ForeColor = Color.Red;

                }
            }
            else
            {
                MessageBox.Show("11 haneli TC kimlik numarasını eksiksiz bir şekilde giriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        string dosyaYolu;
        string dosyaAdi;



        private void havuzolustur_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cam != null)
            {
                if (cam.IsRunning)
                {
                    cam.Stop();
                }
            }
        }

        private void btn_kamera_ac_Click(object sender, EventArgs e)
        {
            cam = new VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(Cam_NewFrame);



            cam.Start();

            btn_kamerayıkapat.Visible = true;
            btn_kamera_ac.Visible = false;
        }

        private void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            pbx_cekilen_resim.Image = bit;
        }

        private void btn_resim_cek_Click(object sender, EventArgs e)
        {
            resim.Image = pbx_cekilen_resim.Image;
            Bitmap bmpkucuk = new Bitmap(pbx_cekilen_resim.Image);
        }

        private void btn_resim_kaydet_Click(object sender, EventArgs e)
        {
            SaveFileDialog swf = new SaveFileDialog();
            swf.Filter = "(*.jpg)|*.jpg";
            DialogResult dialog = swf.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                resim.Image.Save(swf.FileName);
            }

            if (cam.IsRunning)
            {
                cam.Stop();
            }
        }

        private void btn_kamerayıkapat_Click(object sender, EventArgs e)
        {
            if (cam.IsRunning)
            {
                cam.Stop();
            }

            btn_kamera_ac.Visible = true;
            btn_kamerayıkapat.Visible = false;
        }


        //string belge = "myb2";

        private void cx_sabika_var_CheckedChanged(object sender, EventArgs e)
        {
            if (cx_sabika_var.Checked == true)
            {
                cx_sabika_yok.Checked = false;
            }
        }
        //CVLERDE TC N YAZMADIĞI İÇİN ZAMAN TC BENZERİ BİR NUMARA ÜRETMEMİZ GEREKMEKTEDİR. RESMİ BİR BAĞLAYICILIĞI YOKTUR.

        string uretilen;

        int[] rakamlar = new int[11];

        public void tcUret()
        {
            uretilen = "";
            txt_tc_uret.Text = "";
           // MessageBox.Show(uretilen);
            Random ran = new Random();

            for (int i = 0; i < 9; i++)
            {
                rakamlar[i] = ran.Next(0, 9);
            }

            if (rakamlar[0] == 0)
            {
                rakamlar[0] = ran.Next(0, 9);
            }
            else
            {
                int onuncuhane = ((rakamlar[0] + rakamlar[2] + rakamlar[4] + rakamlar[6] + rakamlar[8]) * 7) - (rakamlar[1] + rakamlar[3] + rakamlar[5] + rakamlar[7]);
                int ondanbolum = onuncuhane % 10;
                rakamlar[9] = ondanbolum;
                int onbirincihane = rakamlar[0] + rakamlar[1] + rakamlar[2] + rakamlar[3] + rakamlar[4] + rakamlar[5] + rakamlar[6] + rakamlar[7] + rakamlar[8] + rakamlar[9];
                int modu = onbirincihane % 10;

                rakamlar[10] = modu;
            }
            foreach (int a in rakamlar)
            {
                //listBox1.Items.Add(a);
                txt_tc_uret.Text += a.ToString();

            }
            uretilen = txt_tc_uret.Text;
       
            MessageBox.Show(uretilen);
        }
        bool uretim = false;
        private void btn_no_uret_Click(object sender, EventArgs e)
        {


            tcUret();

            SqlCommand selectsorguuret = new SqlCommand("select *from tbl_havuz where kisi_tc='" + txt_tc_uret.Text + "'", baglantim.baglanti());
            SqlDataReader kayitokumauret = selectsorguuret.ExecuteReader();
            while (kayitokumauret.Read())
            {
                uretim = true;
                tcUret();
            }
            if (uretim == true)
            {
                txt_tc_no.Text = uretilen;//?
                tcUret();
            }
            else
            {
               
                txt_tc_no.Text = uretilen;
            }
        }

        private void cx_sabika_yok_CheckedChanged(object sender, EventArgs e)
        {
            if (cx_sabika_yok.Checked == true)
            {
                cx_sabika_var.Checked = false;
            }
        }

        private void cx_sigara_evet_CheckedChanged(object sender, EventArgs e)
        {
            if (cx_sigara_evet.Checked == true)
            {
                cx_sigara_hayır.Checked = false;
            }
        }

        private void cx_sigara_hayır_CheckedChanged(object sender, EventArgs e)
        {
            if (cx_sigara_hayır.Checked == true)
            {
                cx_sigara_evet.Checked = false;
            }
        }

        private void cx_alkol_evet_CheckedChanged(object sender, EventArgs e)
        {
            if (cx_alkol_evet.Checked == true)
            {
                cx_alkol_hayır.Checked = false;
            }
        }

        private void cx_alkol_hayır_CheckedChanged(object sender, EventArgs e)
        {
            if (cx_alkol_hayır.Checked == true)
            {
                cx_alkol_evet.Checked = false;
            }
        }

        private void lnk_lbl_1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string yeniad = txt_tc_no.Text + "_" + txt_ad.Text + "_" + txt_soyadı.Text + ".pdf"; //Benzersiz isim verme

            DosyaYolu = @"C://Dosyalar//Havuz//" + yeniad;

            System.Diagnostics.Process.Start(DosyaYolu);
        }

    }
}
