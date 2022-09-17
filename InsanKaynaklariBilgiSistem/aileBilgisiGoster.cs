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
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Configuration;

namespace InsanKaynaklariBilgiSistem
{
    public partial class aileBilgisiGoster : Form
    {
        public aileBilgisiGoster()
        {
            InitializeComponent();
        }

        sqlBaglantisi baglantim = new sqlBaglantisi();

        public void listele_yakin_bilgileri()
        {
            SqlCommand sorgu = new SqlCommand("Listele_Yakin_Bilgileri", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sorgu);
            sorgu.Parameters.AddWithValue("@kisi_tc_no", aktifKullanici.kisi);
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
            sorgu2.Parameters.AddWithValue("@kisi_tc_no", aktifKullanici.kisi);
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
        private void aileBilgisiGoster_Load(object sender, EventArgs e)
        {
            listele_bakim();
            listele_yakin_bilgileri();
            lbl_kisi.Text = aktifKullanici.kisi;

        }
        aileBilgisi aileBilgisi_f = new aileBilgisi();

        public string yakin_id, yakin_yakinlik_derecesi, yakin_adi_soyadi, yakin_cinsiyeti, yakin_dogum_yeri, yakin_dogum_tarihi, yakin_yasam_bilgisi, yakin_olum_tarihi
            , yakin_olum_aciklamasi, yakin_medeni_hali, yakin_kan_grubu, yakin_tel_no, yakin_saglik_sorunu, yakin_saglik_aciklama, yakin_engel_durumu, yakin_engel_aciklama
            , yakin_çalisma_durumu, yakin_meslegi, yakin_geliri, yakin_calistigi_yer, yakin_okul_adi, yakin_ogrenim_duzeyi, yakin_okul_bolumu, yakin_okul_sinif, yakin_okul_sehir
            , yakin_okul_giris_tarihi, yakin_okul_durumu, yakin_okul_mezuniyet_tarihi, yakin_mezuniyet_derecesi, yakin_merasim_turu, yakin_merasim_tarihi, yakin_hobileri;




        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();

        public void listele1()
        {
            SqlCommand bakimSorgusu = new SqlCommand("select * from Kisi_Bakmakla_Yukumlu", baglantim.baglanti());
            // sorgu_Kisi.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da2 = new SqlDataAdapter(bakimSorgusu);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
            gridView2.Columns["id"].Visible = false;

            gridView2.Columns["TC"].Caption = "TC NO";
            gridView2.Columns["ad"].Caption = "ADI";


        }
        private void btn_rapor_Click(object sender, EventArgs e)
        {
            DataSet dataset = new DataSet();
            dataset.Tables.Add(dt1);
            dataset.Tables.Add(dt2);

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;
                    

                    Excel.Application excel = new Excel.Application();
                    var workbook = (Excel._Workbook)(excel.Workbooks.Add(Missing.Value));

                    for (var i = 0; i < dataset.Tables.Count; i++)
                    {
                        if (workbook.Sheets.Count < i + 1)
                        {
                            workbook.Sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        }
                        var currentSheet = (Excel._Worksheet)workbook.Sheets[1];
                        for (var y = 0; y < dataset.Tables[i].Columns.Count; y++)
                        {
                            currentSheet.Cells[1, y + 1] = dataset.Tables[i].Columns[y].ColumnName;
                            //for (var x = 0; x < dataset.Tables[i].Columns[y].ColumnName.Count(); x++) //sütun
                            //{
                            //currentSheet.Cells[y + 2, x + 1] = dataset.Tables[i].Columns[y];


                            //}
                        }
                        for (var y = 0; y < dataset.Tables[i].Rows.Count; y++)
                        {
                            for (var x = 0; x < dataset.Tables[i].Rows[y].ItemArray.Count(); x++) //sütun
                            {
                                //MessageBox.Show("....", dataset.Tables[i].Rows[y].ItemArray.Count().ToString());

                                currentSheet.Cells[y + 2, x + 1] = dataset.Tables[i].Rows[y].ItemArray[x];
                            }
                        }
                    }
                    // string outfile = @"C:\Dosyalar\Aile.xlsx";
                    //string outfile;

                    SaveFileDialog save = new SaveFileDialog();

                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        StreamWriter Kayit = new StreamWriter(save.FileName);

                        //}

                        //if (File.Exists(exportFilePath))
                        //{


                        try
                        {
                            workbook.Sheets[1].Name = "Bakım";
                            workbook.Sheets[2].Name = "Yakın";


                            workbook.SaveAs(Kayit, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);


                            workbook.Close();
                            excel.Quit();
                          //  System.Diagnostics.Process.Start(@"C:\Dosyalar\Aile.xlsx");
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


                    /*  switch (fileExtenstion)
                      {
                          case ".xls":
                              gridControl3.ExportToXls(exportFilePath);
                              break;
                          case ".xlsx":
                              gridControl3.ExportToXlsx(exportFilePath);
                              break;
                          case ".rtf":
                              gridControl3.ExportToRtf(exportFilePath);
                              break;
                          case ".pdf":
                              gridControl3.ExportToPdf(exportFilePath);
                              break;
                          case ".html":
                              gridControl3.ExportToHtml(exportFilePath);
                              break;
                          case ".mht":
                              gridControl3.ExportToMht(exportFilePath);
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
                      }*/
                }
            }
        }

        private void btn_kaydi_aktar_Click(object sender, EventArgs e)
        { }

        private void gridControl3_DoubleClick(object sender, EventArgs e)
        {
            yakin_id = gridView3.GetFocusedRowCellValue("id").ToString();

            yakin_yakinlik_derecesi = gridView3.GetFocusedRowCellValue("yakinlik_derecesi").ToString();

            yakin_adi_soyadi = gridView3.GetFocusedRowCellValue("yakin_adi_soyadi").ToString();
            yakin_cinsiyeti = gridView3.GetFocusedRowCellValue("yakin_cinsiyeti").ToString();

            yakin_dogum_yeri = gridView3.GetFocusedRowCellValue("yakin_dogum_yeri").ToString();
            yakin_dogum_tarihi = gridView3.GetFocusedRowCellValue("yakin_dogum_tarihi").ToString();

            yakin_yasam_bilgisi = gridView3.GetFocusedRowCellValue("yakin_yasam_bilgisi").ToString();

            yakin_olum_tarihi = gridView3.GetFocusedRowCellValue("yakin_olum_tarihi").ToString();
            yakin_olum_aciklamasi = gridView3.GetFocusedRowCellValue("yakin_olum_aciklamasi").ToString();
            yakin_medeni_hali = gridView3.GetFocusedRowCellValue("yakin_medeni_hali").ToString();
            yakin_kan_grubu = gridView3.GetFocusedRowCellValue("yakin_kan_grubu").ToString();
            yakin_tel_no = gridView3.GetFocusedRowCellValue("yakin_tel_no").ToString();

            yakin_saglik_sorunu = gridView3.GetFocusedRowCellValue("yakin_saglik_sorunu").ToString();

            yakin_saglik_aciklama = gridView3.GetFocusedRowCellValue("yakin_saglik_aciklama").ToString();
            yakin_engel_durumu = gridView3.GetFocusedRowCellValue("yakin_engel_durumu").ToString();

            yakin_engel_aciklama = gridView3.GetFocusedRowCellValue("yakin_engel_aciklama").ToString();

            yakin_çalisma_durumu = gridView3.GetFocusedRowCellValue("yakin_çalisma_durumu").ToString();

            yakin_meslegi = gridView3.GetFocusedRowCellValue("yakin_meslegi").ToString();
            yakin_geliri = gridView3.GetFocusedRowCellValue("yakin_geliri").ToString();
            yakin_calistigi_yer = gridView3.GetFocusedRowCellValue("yakin_calistigi_yer").ToString();
            yakin_okul_adi = gridView3.GetFocusedRowCellValue("yakin_okul_adi").ToString();
            yakin_ogrenim_duzeyi = gridView3.GetFocusedRowCellValue("yakin_ogrenim_duzeyi").ToString();
            yakin_okul_bolumu = gridView3.GetFocusedRowCellValue("yakin_okul_bolumu").ToString();
            yakin_okul_sinif = gridView3.GetFocusedRowCellValue("yakin_okul_sinif").ToString();
            yakin_okul_sehir = gridView3.GetFocusedRowCellValue("yakin_okul_sehir").ToString();
            yakin_okul_giris_tarihi = gridView3.GetFocusedRowCellValue("yakin_okul_giris_tarihi").ToString();
            yakin_okul_durumu = gridView3.GetFocusedRowCellValue("yakin_okul_durumu").ToString();

            yakin_okul_mezuniyet_tarihi = gridView3.GetFocusedRowCellValue("yakin_okul_mezuniyet_tarihi").ToString();
            yakin_mezuniyet_derecesi = gridView3.GetFocusedRowCellValue("yakin_mezuniyet_derecesi").ToString();
            yakin_merasim_turu = gridView3.GetFocusedRowCellValue("yakin_merasim_turu").ToString();
            yakin_merasim_tarihi = gridView3.GetFocusedRowCellValue("yakin_merasim_tarihi").ToString();

            yakin_hobileri = gridView3.GetFocusedRowCellValue("yakin_hobileri").ToString();
            this.Close();


        }

        public string bakim_yakini, adi_soyadi, dogum_yeri, dogum_tarihi, tel_no, saglik_sorunu, saglik_sorunu_aciklama, engel_durumu,
            engel_aciklama, geliri, bakim_hobi, bakim_id;

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            bakim_yakini = gridView2.GetFocusedRowCellValue("bakim_yakini").ToString();
            adi_soyadi = gridView2.GetFocusedRowCellValue("adi_soyadi").ToString();
            dogum_yeri = gridView2.GetFocusedRowCellValue("dogum_yeri").ToString();
            dogum_tarihi = gridView2.GetFocusedRowCellValue("dogum_tarihi").ToString();
            tel_no = gridView2.GetFocusedRowCellValue("tel_no").ToString();
            saglik_sorunu = gridView2.GetFocusedRowCellValue("saglik_sorunu").ToString();
            saglik_sorunu_aciklama = gridView2.GetFocusedRowCellValue("saglik_sorunu_aciklama").ToString();
            engel_durumu = gridView2.GetFocusedRowCellValue("engel_durumu").ToString();
            engel_aciklama = gridView2.GetFocusedRowCellValue("engel_aciklama").ToString();
            geliri = gridView2.GetFocusedRowCellValue("geliri").ToString();

            bakim_hobi = gridView2.GetFocusedRowCellValue("bakim_hobi").ToString();

            bakim_id = gridView2.GetFocusedRowCellValue("id").ToString();

            this.Close();

        }
    }
}
