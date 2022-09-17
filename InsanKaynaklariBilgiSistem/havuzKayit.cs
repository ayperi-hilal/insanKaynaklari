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
    public partial class havuzKayit : Form
    {
        public havuzKayit()
        {
            InitializeComponent();
        }

        sqlBaglantisi baglantim = new sqlBaglantisi();

        private void btn_ara_Click(object sender, EventArgs e)
        {

        }

        havuzolustur frm1;
        //ekran frm2;
        private void btn_ekle_Click(object sender, EventArgs e)
        {

            havuzolustur frm1 = new havuzolustur();
            frm1.ShowDialog();

            //if (frm1 == null || frm1.IsDisposed)
            //{
            //    frm1 = new havuzolustur();
            //    frm1.MdiParent = new ekran();
            //    frm1.Show();
            //}
            //else
            //{
            //    frm1.Show();
            //}

        }

        public void listele()
        {
            SqlCommand sorgu = new SqlCommand("tum_havuz", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sorgu);

            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;


            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
        }

        public void tum_listele()
        {
            SqlCommand sorgu2 = new SqlCommand("select * from tbl_havuz", baglantim.baglanti());
            //sorgu2.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter dak = new SqlDataAdapter(sorgu2);
            DataTable dtk = new DataTable();
            dak.Fill(dtk);
            gridControl2.DataSource = dtk;

            gridView2.Columns["id"].Visible = false;

            gridView2.Columns["kisi_tc"].Caption = "TC NO";
            gridView2.Columns["adi"].Caption = "ADI";
            gridView2.Columns["soyadi"].Caption = "SOYADI";
            gridView2.Columns["resim"].Visible = false;
            gridView2.Columns["baslik"].Visible = false;
            gridView2.Columns["cvLinki"].Visible = false;
            gridView2.Columns["calismaSekli"].Caption = "ÇALIŞMA TERCİHİ";
            gridView2.Columns["dogumTarihi"].Caption = "DOĞUM TARİHİ";
            gridView2.Columns["dogumYeri"].Caption = "DOĞUM YERİ";
            gridView2.Columns["uyruk"].Caption = "UYRUK";
            gridView2.Columns["askerlik"].Caption = "ASKERLİK";
            gridView2.Columns["askerlikTarihi"].Caption = "ASKERLİK TARİHİ";
            gridView2.Columns["adres"].Caption = "ADRES";
            gridView2.Columns["engelDurumu"].Caption = "ENGEL DURUMU";
            gridView2.Columns["seyehat"].Caption = "SEYEHAT DURUMU";
            gridView2.Columns["cocukDurumu"].Caption = "ÇOCUK DURUMU";
            gridView2.Columns["cocukSayisi"].Caption = "ÇOCUK SAYISI";
            gridView2.Columns["cocukSayisi"].Caption = "ÇOCUK SAYISI";
            gridView2.Columns["sektörTecrübesi"].Caption = "SEKTÖR TECRÜBESİ";
            gridView2.Columns["kayitTarihi"].Caption = "BAŞVURU TARİHİ";
            gridView2.Columns["kariyerHedefi"].Caption = "KARİYER HEDEFİ";
            gridView2.Columns["pozisyonTercihi"].Caption = "POZİSYON TERCİHİ";
            gridView2.Columns["cinsiyet"].Caption = "CİNSİYET";
            gridView2.Columns["medeniHal"].Caption = "MEDENİ HALİ";
            gridView2.Columns["kan"].Caption = "KAN GUBU";
            gridView2.Columns["eposta"].Caption = "EMAİL";
            gridView2.Columns["tel"].Caption = "İLETİŞİM";
            gridView2.Columns["sabikakaydı"].Caption = "SABIKA KAYDI";
            gridView2.Columns["sürücübelgesi"].Caption = "SÜRÜCÜ BELGESİ";
            gridView2.Columns["saglikSorunu"].Caption = "SAĞLIK SORUNU";
            gridView2.Columns["sigara"].Caption = "SİGARA KULLANIMI";
            gridView2.Columns["alkol"].Caption = "ALKOL KULLANIMI";
            gridView2.Columns["ücretBeklentisi"].Caption = "ÜCRET BEKLENTİSİ";
            gridView2.Columns["egitimSeviye1"].Caption = "1-EĞİTİM SEVİYESİ";
            gridView2.Columns["egitimDurum1"].Caption = "1-DURUM";
            gridView2.Columns["egitimOkul1"].Caption = "1-OKUL ADI";
            gridView2.Columns["egitimBolum1"].Caption = "1-BÖLÜM";
            gridView2.Columns["mezuniyet1"].Caption = "1-MEZUNİYET";
            gridView2.Columns["notDurumu1"].Caption = "1-NOT ORTALAMASI";
            gridView2.Columns["egitimSeviye2"].Caption = "2-EĞİTİM SEVİYESİ";
            gridView2.Columns["egitimDurum2"].Caption = "2-DURUM";
            gridView2.Columns["egitimOkul2"].Caption = "2-OKUL ADI";
            gridView2.Columns["egitimBolum2"].Caption = "2-BÖLÜM";
            gridView2.Columns["mezuniyet2"].Caption = "2-MEZUNİYET";
            gridView2.Columns["notDurumu2"].Caption = "2-NOT ORTALAMASI";
            gridView2.Columns["egitimSeviye3"].Caption = "3-EĞİTİM SEVİYESİ";
            gridView2.Columns["egitimDurum3"].Caption = "3-DURUM";
            gridView2.Columns["egitimOkul3"].Caption = "3-OKUL ADI";
            gridView2.Columns["egitimBolum3"].Caption = "3-BÖLÜM";
            gridView2.Columns["mezuniyet3"].Caption = "3-MEZUNİYET";
            gridView2.Columns["notDurumu3"].Caption = "3-NOT ORTALAMASI";

            gridView2.Columns["calistigiyer1"].Caption = "1-ÇALIŞTIĞI YER";
            gridView2.Columns["gorev1"].Caption = "1-GÖREVİ";
            gridView2.Columns["cGirisTarihi1"].Caption = "1-GİRİŞ TARİHİ";
            gridView2.Columns["cCikisTarihi1"].Caption = "1-ÇIKIŞ TARİHİ";
            gridView2.Columns["cNeden1"].Caption = "1-AYRILMA NEDENİ";
            gridView2.Columns["cref1"].Caption = "1-REFERANS";
            gridView2.Columns["ciletisim1"].Caption = "1-İLETİŞİM";

            gridView2.Columns["calistigiyer2"].Caption = "2-ÇALIŞTIĞI YER";
            gridView2.Columns["gorev2"].Caption = "2-GÖREVİ";
            gridView2.Columns["cGirisTarihi2"].Caption = "2-GİRİŞ TARİHİ";
            gridView2.Columns["cCikisTarihi2"].Caption = "2-ÇIKIŞ TARİHİ";
            gridView2.Columns["cNeden2"].Caption = "2-AYRILMA NEDENİ";
            gridView2.Columns["cref2"].Caption = "2-REFERANS";
            gridView2.Columns["ciletisim2"].Caption = "2-İLETİŞİM";

            gridView2.Columns["calistigiyer3"].Caption = "3-ÇALIŞTIĞI YER";
            gridView2.Columns["gorev3"].Caption = "3-GÖREVİ";
            gridView2.Columns["cGirisTarihi3"].Caption = "3-GİRİŞ TARİHİ";
            gridView2.Columns["cCikisTarihi1"].Caption = "3-ÇIKIŞ TARİHİ";
            gridView2.Columns["cNeden3"].Caption = "3-AYRILMA NEDENİ";
            gridView2.Columns["cref3"].Caption = "3-REFERANS";
            gridView2.Columns["ciletisim3"].Caption = "3-İLETİŞİM";

            gridView2.Columns["dil1"].Caption = "1-YABANCI DİL";
            gridView2.Columns["dilseviye1"].Caption = "1-SEVİYE";

            gridView2.Columns["dil2"].Caption = "2-YABANCI DİL";
            gridView2.Columns["dilseviye2"].Caption = "2-SEVİYE";

            gridView2.Columns["dil3"].Caption = "3-YABANCI DİL";
            gridView2.Columns["dilseviye3"].Caption = "3-SEVİYE";


            gridView2.Columns["program1"].Caption = "1-PROGRAM";
            gridView2.Columns["programseviye1"].Caption = "1-PROGRAM SEVİYESİ";

            gridView2.Columns["program2"].Caption = "2-PROGRAM";
            gridView2.Columns["programseviye2"].Caption = "2-PROGRAM SEVİYESİ";

            gridView2.Columns["program3"].Caption = "3-PROGRAM";
            gridView2.Columns["programseviye3"].Caption = "3-PROGRAM SEVİYESİ";


            gridView2.Columns["sertifika1"].Caption = "1-SERTİFİKA BİLGİSİ";
            gridView2.Columns["sertifikaa1"].Caption = "1-SERTİFİKA KONUSU";
            gridView2.Columns["sertifikakurum1"].Caption = "1-SERTİFİKA ALINDIĞI KURUM";
            gridView2.Columns["sertifikatarih1"].Caption = "1-TARİH";

            gridView2.Columns["sertifika2"].Caption = "2-SERTİFİKA BİLGİSİ";
            gridView2.Columns["sertifikaa2"].Caption = "2-SERTİFİKA KONUSU";
            gridView2.Columns["sertifikakurum2"].Caption = "2-SERTİFİKA ALINDIĞI KURUM";
            gridView2.Columns["sertifikatarih2"].Caption = "2-TARİH";

            gridView2.Columns["sertifika3"].Caption = "3-SERTİFİKA BİLGİSİ";
            gridView2.Columns["sertifikaa3"].Caption = "3-SERTİFİKA KONUSU";
            gridView2.Columns["sertifikakurum3"].Caption = "3-SERTİFİKA ALINDIĞI KURUM";
            gridView2.Columns["sertifikatarih3"].Caption = "3-TARİH";

            gridView2.OptionsBehavior.Editable = false;
            gridView2.OptionsView.ShowAutoFilterRow = true;
        }


        private void havuzKayit_Load(object sender, EventArgs e)
        {
            listele();
            tum_listele();
        }
        havuzolustur havuzolustur_f = new havuzolustur();

        //public string havuz_id, resim, baslik, cvLinki, calismaSekli, kisi_tc, adi, soyadi, dogumTarihi, dogumYeri, uyruk, askerlik, askerlikTarihi,
        //    adres, engelDurumu, seyehat, cocukDurumu, cocukSayisi, sektörTecrübesi, kayitTarihi, kariyerHedefi, pozisyonTercihi, cinsiyet, medeniHal,
        //    kan, eposta, tel, sabikakaydı, sürücübelgesi, saglikSorunu, sigara, alkol, ücretBeklentisi, egitimSeviye1, egitimDurum1, egitimOkul1, egitimBolum1,
        //    mezuniyet1, notDurumu1, egitimSeviye2, egitimDurum2, egitimOkul2, egitimBolum2, mezuniyet2, notDurumu2, egitimSeviye3, egitimDurum3, egitimOkul3, egitimBolum3,
        //    mezuniyet3, notDurumu3, calistigiyer1, calistigiyer2, calistigiyer3, gorev1, gorev2, gorev3, cGirisTarihi1, cGirisTarihi2, cGirisTarihi3,
        //    cCikisTarihi1, cCikisTarihi2, cCikisTarihi3, cNeden1, cNeden2, cNeden3, cref1, cref2, cref3, ciletisim1, ciletisim2, ciletisim3, dil1, dil2, dil3,
        //    dilseviye1, dilseviye2, dilseviye3, program1, program2, program3, programseviye1, programseviye2, programseviye3, sertifika1, sertifika2, sertifika3, sertifikaa1,
        //    sertifikaa2, sertifikaa3, sertifikakurum1, sertifikakurum2, sertifikakurum3, sertifikatarih1, sertifikatarih2, sertifikatarih3;




        private void btn_aktar_Click(object sender, EventArgs e)
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
                            gridControl1.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            gridControl1.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            gridControl1.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            gridControl1.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            gridControl1.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            gridControl1.ExportToMht(exportFilePath);
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
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }







        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            SqlCommand sorgu2 = new SqlCommand("select * from tbl_havuz", baglantim.baglanti());
            //sorgu2.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter dak = new SqlDataAdapter(sorgu2);
            DataTable dtk = new DataTable();
            dak.Fill(dtk);
            gridControl2.DataSource = dtk;

            SqlCommand selectsorgu = new SqlCommand("select * from tbl_havuz where kisi_tc = @kisitc", baglantim.baglanti());
            //selectsorgu.CommandType = CommandType.StoredProcedure;

            selectsorgu.Parameters.AddWithValue("@kisitc", gridView1.GetFocusedRowCellValue("TC NO").ToString());


            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();

            while (kayitokuma.Read())
            {
                MessageBox.Show(kayitokuma.GetValue(0).ToString() + "\n" +
                    kayitokuma.GetValue(1).ToString() + "\n" +
                    kayitokuma.GetValue(2).ToString() + "\n" +
                    kayitokuma.GetValue(3).ToString() + "\n" +
                    kayitokuma.GetValue(4).ToString() + "\n" +
                    kayitokuma.GetValue(5).ToString() + "\n");


                havuz.havuz_id = kayitokuma.GetValue(0).ToString();
                havuz.baslik = kayitokuma.GetValue(2).ToString();
                // havuz.cvLinki = kayitokuma.GetValue(3).ToString();
                havuz.calismaSekli = kayitokuma.GetValue(4).ToString();
                havuz.kisi_tc = kayitokuma.GetValue(5).ToString();
                havuz.adi = kayitokuma.GetValue(6).ToString();
                havuz.soyadi = kayitokuma.GetValue(7).ToString();
                havuz.dogumTarihi = kayitokuma.GetValue(8).ToString();
                havuz.dogumYeri = kayitokuma.GetValue(9).ToString();
                havuz.uyruk = kayitokuma.GetValue(10).ToString();
                havuz.askerlik = kayitokuma.GetValue(11).ToString();
                havuz.askerlikTarihi = kayitokuma.GetValue(12).ToString();
                havuz.adres = kayitokuma.GetValue(13).ToString();
                havuz.engelDurumu = kayitokuma.GetValue(14).ToString();
                havuz.seyehat = kayitokuma.GetValue(15).ToString();
                havuz.cocukDurumu = kayitokuma.GetValue(16).ToString();
                havuz.cocukSayisi = kayitokuma.GetValue(17).ToString();
                havuz.sektörTecrübesi = kayitokuma.GetValue(18).ToString();
                havuz.kayitTarihi = kayitokuma.GetValue(19).ToString();
                havuz.kariyerHedefi = kayitokuma.GetValue(20).ToString();
                havuz.pozisyonTercihi = kayitokuma.GetValue(21).ToString();
                havuz.cinsiyet = kayitokuma.GetValue(22).ToString();
                havuz.medeniHal = kayitokuma.GetValue(23).ToString();
                havuz.kan = kayitokuma.GetValue(24).ToString();
                havuz.eposta = kayitokuma.GetValue(25).ToString();
                havuz.tel = kayitokuma.GetValue(26).ToString();
                havuz.sabikakaydı = kayitokuma.GetValue(27).ToString();
                havuz.sürücübelgesi = kayitokuma.GetValue(28).ToString();
                havuz.saglikSorunu = kayitokuma.GetValue(29).ToString();
                havuz.sigara = kayitokuma.GetValue(30).ToString();
                havuz.alkol = kayitokuma.GetValue(31).ToString();
                havuz.ücretBeklentisi = kayitokuma.GetValue(32).ToString();
                havuz.egitimSeviye1 = kayitokuma.GetValue(33).ToString();
                havuz.egitimDurum1 = kayitokuma.GetValue(34).ToString();
                havuz.egitimOkul1 = kayitokuma.GetValue(35).ToString();
                havuz.egitimBolum1 = kayitokuma.GetValue(36).ToString();
                havuz.mezuniyet1 = kayitokuma.GetValue(37).ToString();
                havuz.notDurumu1 = kayitokuma.GetValue(38).ToString();
                havuz.egitimSeviye2 = kayitokuma.GetValue(39).ToString();
                havuz.egitimDurum2 = kayitokuma.GetValue(40).ToString();
                havuz.egitimOkul2 = kayitokuma.GetValue(41).ToString();
                havuz.egitimBolum2 = kayitokuma.GetValue(42).ToString();
                havuz.mezuniyet2 = kayitokuma.GetValue(43).ToString();
                havuz.notDurumu2 = kayitokuma.GetValue(44).ToString();
                havuz.egitimSeviye3 = kayitokuma.GetValue(45).ToString();
                havuz.egitimDurum3 = kayitokuma.GetValue(46).ToString();
                havuz.egitimOkul3 = kayitokuma.GetValue(47).ToString();
                havuz.egitimBolum3 = kayitokuma.GetValue(48).ToString();
                havuz.mezuniyet3 = kayitokuma.GetValue(49).ToString();
                havuz.notDurumu3 = kayitokuma.GetValue(50).ToString();
                havuz.calistigiyer1 = kayitokuma.GetValue(51).ToString();
                havuz.calistigiyer2 = kayitokuma.GetValue(52).ToString();
                havuz.calistigiyer3 = kayitokuma.GetValue(53).ToString();
                havuz.gorev1 = kayitokuma.GetValue(54).ToString();
                havuz.gorev2 = kayitokuma.GetValue(55).ToString();
                havuz.gorev3 = kayitokuma.GetValue(56).ToString();
                havuz.cGirisTarihi1 = kayitokuma.GetValue(57).ToString();
                havuz.cGirisTarihi2 = kayitokuma.GetValue(58).ToString();
                havuz.cGirisTarihi3 = kayitokuma.GetValue(59).ToString();
                havuz.cCikisTarihi1 = kayitokuma.GetValue(60).ToString();
                havuz.cCikisTarihi2 = kayitokuma.GetValue(61).ToString();
                havuz.cCikisTarihi3 = kayitokuma.GetValue(62).ToString();

                havuz.cNeden1 = kayitokuma.GetValue(63).ToString();
                havuz.cNeden2 = kayitokuma.GetValue(64).ToString();
                havuz.cNeden3 = kayitokuma.GetValue(65).ToString();
                havuz.cref1 = kayitokuma.GetValue(66).ToString();
                havuz.cref2 = kayitokuma.GetValue(67).ToString();
                havuz.cref3 = kayitokuma.GetValue(68).ToString();
                havuz.ciletisim1 = kayitokuma.GetValue(69).ToString();
                havuz.ciletisim2 = kayitokuma.GetValue(70).ToString();
                havuz.ciletisim3 = kayitokuma.GetValue(71).ToString();
                havuz.dil1 = kayitokuma.GetValue(72).ToString();
                havuz.dil2 = kayitokuma.GetValue(73).ToString();
                havuz.dil3 = kayitokuma.GetValue(74).ToString();
                havuz.dilseviye1 = kayitokuma.GetValue(75).ToString();
                havuz.dilseviye2 = kayitokuma.GetValue(76).ToString();
                havuz.dilseviye3 = kayitokuma.GetValue(77).ToString();
                havuz.program1 = kayitokuma.GetValue(78).ToString();
                havuz.program2 = kayitokuma.GetValue(79).ToString();
                havuz.program3 = kayitokuma.GetValue(80).ToString();
                havuz.programseviye1 = kayitokuma.GetValue(81).ToString();
                havuz.programseviye2 = kayitokuma.GetValue(82).ToString();
                havuz.programseviye3 = kayitokuma.GetValue(83).ToString();
                havuz.sertifika1 = kayitokuma.GetValue(84).ToString();
                havuz.sertifika2 = kayitokuma.GetValue(85).ToString();
                havuz.sertifika3 = kayitokuma.GetValue(86).ToString();
                havuz.sertifikaa1 = kayitokuma.GetValue(87).ToString();
                havuz.sertifikaa2 = kayitokuma.GetValue(88).ToString();
                havuz.sertifikaa3 = kayitokuma.GetValue(89).ToString();
                havuz.sertifikakurum1 = kayitokuma.GetValue(90).ToString();
                havuz.sertifikakurum2 = kayitokuma.GetValue(91).ToString();
                havuz.sertifikakurum3 = kayitokuma.GetValue(92).ToString();
                havuz.sertifikatarih1 = kayitokuma.GetValue(93).ToString();
                havuz.sertifikatarih2 = kayitokuma.GetValue(94).ToString();
                havuz.sertifikatarih3 = kayitokuma.GetValue(95).ToString();

                break;
            }


            // yakin_id = gridView3.GetFocusedRowCellValue("id").ToString();
            //havuz_id = gridView1.GetFocusedRowCellValue("id").ToString();
            /// resim = gridView1.GetFocusedRowCellValue("resim").ToString();
            havuzolustur havuzolustur_t = new havuzolustur();
            havuzolustur_t.Show();
            //this.Close();


        }

        private void btn_yenile_Click(object sender, EventArgs e)
        {
            listele();
        }
    }
}
