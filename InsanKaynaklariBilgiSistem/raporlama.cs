using DevExpress.DataAccess.Native.Web;
using DevExpress.Utils.OAuth.Provider;
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
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using System.IO;

namespace InsanKaynaklariBilgiSistem
{
    public partial class raporlama : Form
    {
        public raporlama()
        {
            InitializeComponent();
        }
        sqlBaglantisi baglantim = new sqlBaglantisi();

        

        public void listele_Tum_Personeller()
        {
            SqlCommand sorgu = new SqlCommand("Listele_Tum_Personeller", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(sorgu);


            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
      
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;


  
        }

        public void arge_Personelleri()
        {
            SqlCommand sorgu = new SqlCommand("Listele_Arge_Personelleri", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(sorgu);


            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
       
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
        }
        public void personel_Listesi()
        {
            SqlCommand sorgu = new SqlCommand("Listele_Personeller", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(sorgu);


            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
        }
        public void ayrılanların_Listesi()
        {
            SqlCommand sorgu = new SqlCommand("Listele_Ayrılan_Personeller", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(sorgu);


            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
        }

        public void saglik_gizle()
        {
            gridView1.Columns["PERSONELİN KAN GRUBU"].Visible = false;
            gridView1.Columns["PERSONELİN SAĞLIK BİLGİSİ"].Visible = false;
            gridView1.Columns["PERSONELİN BOYU"].Visible = false;
            gridView1.Columns["PERSONELİN KİLOSU"].Visible = false;
            gridView1.Columns["PERSONELİN ENGEL BİLGİSİ"].Visible = false;
            gridView1.Columns["PERSONELİN AMELİYAT BİLGİSİ"].Visible = false;
            gridView1.Columns["PEROSNELİN SİGARA BAŞLANGICI"].Visible = false;
            gridView1.Columns["PERSONELİN SİGARA MİKTARI"].Visible = false;
            gridView1.Columns["PERSONELİN ALKOL BİLGİSİ"].Visible = false;
            gridView1.Columns["PEROSNELİN ALKOL BAŞLANGICI"].Visible = false;
            gridView1.Columns["PERSONELİN ALKOL MİKTARI"].Visible = false;
            
        }

        public void aile_gizle()
        {
            gridView1.Columns["YAKINLIK DERECESİ"].Visible = false;
            gridView1.Columns["YAKINI ADI SOYADI"].Visible = false;
            gridView1.Columns["YAKINI CİNSİYET"].Visible = false;
            gridView1.Columns["YAKINI DOĞUM YERİ"].Visible = false;
            gridView1.Columns["YAKINI DOĞUM TARİHİ"].Visible = false;
            gridView1.Columns["SAĞ / ÖLÜ"].Visible = false;
            gridView1.Columns["YAKINI ÖLÜM NEDENİ"].Visible = false;
            gridView1.Columns["YAKINI MEDENİ HALİ"].Visible = false;
            gridView1.Columns["YAKINI KAN GRUBU"].Visible = false;
            gridView1.Columns["YAKINI TEL NO"].Visible = false;
            gridView1.Columns["YAKINI SAĞLIK AÇIKLAMASI"].Visible = false;
            gridView1.Columns["YAKINI ENGEL AÇIKLAMASI"].Visible = false;
            gridView1.Columns["YAKINI ÇALIŞMA DURUMU"].Visible = false;
            gridView1.Columns["YAKINI MESLEĞİ"].Visible = false;
            gridView1.Columns["YAKINI GELİRİ"].Visible = false;
            gridView1.Columns["YAKINI ÇALIŞTIĞI YER"].Visible = false;
            gridView1.Columns["YAKINI OKUL ADI"].Visible = false;
            gridView1.Columns["YAKINI ÖĞRENİM DÜZEYİ"].Visible = false;
            gridView1.Columns["YAKINI OKUL BÖLÜMÜ"].Visible = false;
            gridView1.Columns["YAKINI SINIFI"].Visible = false;
            gridView1.Columns["YAKINI OKUDUĞU ŞEHİR"].Visible = false;
            gridView1.Columns["YAKINI OKULA GİRİŞ TARİHİ"].Visible = false;
            gridView1.Columns["YAKINI EĞİTİM DURUMU"].Visible = false;
            gridView1.Columns["YAKINI MEZUNİYET TARİHİ"].Visible = false;
            gridView1.Columns["YAKINI MEZUNİYET DERECESİ"].Visible = false;
            gridView1.Columns["YAKINI MERASİM TÜRÜ"].Visible = false;
            gridView1.Columns["YAKINI MERASİM TARİHİ"].Visible = false;
            gridView1.Columns["YAKINI HOBİLERİ"].Visible = false;

            gridView1.Columns["BAKIMI İLE İLGİLENDİĞİ KİŞİ"].Visible = false;
            gridView1.Columns["BAKIMI İLE İLGİLENDİĞİ KİŞİNİN DOĞUM YERİ"].Visible = false;
            gridView1.Columns["BAKIMI İLE İLGİLENDİĞİ KİŞİNİN DOĞUM TARİHİ"].Visible = false;
            gridView1.Columns["BAKIMI İLE İLGİLENDİĞİ KİŞİNİN TELEFON NUMARASI"].Visible = false;
            gridView1.Columns["BAKIMI İLE İLGİLENDİĞİ KİŞİNİN SAĞLIK DURUMU"].Visible = false;
            gridView1.Columns["BAKIMI İLE İLGİLENDİĞİ KİŞİNİN SAĞLIK AÇIKLAMASI"].Visible = false;
            gridView1.Columns["BAKIMI İLE İLGİLENDİĞİ KİŞİNİN ENGEL DURUMU"].Visible = false;
            gridView1.Columns["BAKIMI İLE İLGİLENDİĞİ KİŞİNİN ENGEL DURUMU AÇIKLAMASI"].Visible = false;
            gridView1.Columns["BAKIMI İLE İLGİLENDİĞİ KİŞİNİN GELİRİ"].Visible = false;
            gridView1.Columns["BAKIMI İLE İLGİLENDİĞİ KİŞİNİN HOBİSİ"].Visible = false;
            gridView1.Columns["BAKIMI İLE İLGİLENDİĞİ KİŞİNİN YAKINLIĞI"].Visible = false;
            

        }

        public void iletisim_bilgisi_gizle()
        {
            gridView1.Columns["PERSONELİN EV TELEFONU"].Visible = false;
            gridView1.Columns["PERSONELİN CEP TELEFONU"].Visible = false;
            gridView1.Columns["PERSONELİN EMAİL ADRESİ"].Visible = false;
            gridView1.Columns["ACİL DURUMLARDA ULAŞILACAK KİŞİ"].Visible = false;
            gridView1.Columns["ACİL DURUMLARDA ULAŞILACAK KİŞİNİN İLETİŞİM BİLGİSİ"].Visible = false;
            gridView1.Columns["PERSONELİN ADRESİ"].Visible = false;
            
        }
        public void egitim_gizle()
        {
            gridView1.Columns["PERSONELİN OKUL ADI"].Visible = false;
            gridView1.Columns["PERSONELİN ÖĞRENİM DÜZEYİ"].Visible = false;
            gridView1.Columns["PERSONELİN OKUDUĞU BÖLÜM"].Visible = false;
            gridView1.Columns["PERSONELİN OKUDUĞU SINIF"].Visible = false;
            gridView1.Columns["PERSONELİN OKUDUĞU ŞEHİR"].Visible = false;
            gridView1.Columns["PERSONELİN OKULA GİRİŞ TARİHİ"].Visible = false;
            gridView1.Columns["PERSONELİN EĞİTİM DURUMU"].Visible = false;
            gridView1.Columns["PERSONELİN OKULA MEZUNİYET TARİHİ"].Visible = false;
            gridView1.Columns["PERSONELİN MEZUNİYET DERECESİ"].Visible = false;
          
        }

        public void hobi_gizle()
        {
            gridView1.Columns["PERSONELİN HOBİLERİ"].Visible = false;
        }


        public void ozgecmis_gizle()
        {
            
            gridView1.Columns["ÖNCEKİ İŞYERİ ADI"].Visible = false;
            gridView1.Columns["ÖNCEKİ İŞYERİ İLETİŞİM"].Visible = false;
            gridView1.Columns["ÖNCEKİ İŞYERİNDEKİ GÖREVİ"].Visible = false;
            gridView1.Columns["ÖNCEKİ İŞYERİNDEKİ MAAŞI"].Visible = false;
            gridView1.Columns["ÖNCEKİ İŞYERİNDEKİ YETKİLİ"].Visible = false;
            gridView1.Columns["ÖNCEKİ İŞYERİNE GİRİŞ TARİHİ"].Visible = false;
            gridView1.Columns["ÖNCEKİ İŞYERİNE ÇIKIŞ TARİHİ"].Visible = false;
            gridView1.Columns["ÖNCEKİ İŞYERİNDEN ÇIKIŞ SEBEBİ"].Visible = false;
            
        }
        public void maddi_gizle()
        {
            gridView1.Columns["PERSONELİN MAAŞI"].Visible = false;
            gridView1.Columns["PERSONELİN ALDIĞI DESTEK TÜRÜ"].Visible = false;
            gridView1.Columns["PERSONELİN ALDIĞI DESTEK MİKTARI"].Visible = false;
            gridView1.Columns["PERSONELİN HESAP NO"].Visible = false;
            gridView1.Columns["PERSONELİN EV DURUMU"].Visible = false;
            gridView1.Columns["PERSONELİN KİRA MİKTARI"].Visible = false;
            gridView1.Columns["ISINMA TÜRÜ"].Visible = false;
            gridView1.Columns["KİRA ÜCRETİ GELİRİ"].Visible = false;
            gridView1.Columns["ARAÇ KULLANIM AMACI"].Visible = false;
            gridView1.Columns["ARAZİ KULLANIM AMACI"].Visible = false;
            gridView1.Columns["İCRA/BORÇ KONUSU"].Visible = false;
            gridView1.Columns["BORÇ MİKTARI"].Visible = false;
            gridView1.Columns["İCRA/BORÇ HESAP NO"].Visible = false;
        }

       
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

        

        private void btn_listele_Click(object sender, EventArgs e)
        {
            if(btn_tum_personeller.Checked==true)
            {
                listele_Tum_Personeller();
                if(btn_saglik.Checked!=true)
                { 
                    saglik_gizle(); 
                }
                if (btn_aile.Checked != true)
                {
                    aile_gizle();
                }
                if(btn_iletisim.Checked!=true)
                {
                    iletisim_bilgisi_gizle();
                }
                if(btn_egitim.Checked!=true)
                {
                    egitim_gizle();
                }
                if(btn_hobi.Checked!=true)
                {
                    hobi_gizle();
                }
                if(btn_ozgecmis.Checked!=true)
                {
                    ozgecmis_gizle();
                }
                if(btn_maddi.Checked!=true)
                {
                    maddi_gizle();
                }
                

            }
            if(btn_arge.Checked==true)
            {
                arge_Personelleri();
                if (btn_saglik.Checked != true)
                {
                    saglik_gizle();
                }
                if (btn_aile.Checked != true)
                {
                    aile_gizle();
                }
                if (btn_iletisim.Checked != true)
                {
                    iletisim_bilgisi_gizle();
                }
                if (btn_egitim.Checked != true)
                {
                    egitim_gizle();
                }
                if (btn_hobi.Checked != true)
                {
                    hobi_gizle();
                }
                if (btn_ozgecmis.Checked != true)
                {
                    ozgecmis_gizle();
                }
                if (btn_maddi.Checked != true)
                {
                    maddi_gizle();
                }
            }
            if (btn_personel.Checked == true)
            {
               personel_Listesi();
                if (btn_saglik.Checked != true)
                {
                    saglik_gizle();
                }
                if (btn_aile.Checked != true)
                {
                    aile_gizle();
                }
                if (btn_iletisim.Checked != true)
                {
                    iletisim_bilgisi_gizle();
                }
                if (btn_egitim.Checked != true)
                {
                    egitim_gizle();
                }
                if (btn_hobi.Checked != true)
                {
                    hobi_gizle();
                }
                if (btn_ozgecmis.Checked != true)
                {
                    ozgecmis_gizle();
                }
                if (btn_maddi.Checked != true)
                {
                    maddi_gizle();
                }


            }
            if (btn_cikanlar.Checked == true)
            {
                ayrılanların_Listesi();
                if (btn_saglik.Checked != true)
                {
                    saglik_gizle();
                }
                if (btn_aile.Checked != true)
                {
                    aile_gizle();
                }
                if (btn_iletisim.Checked != true)
                {
                    iletisim_bilgisi_gizle();
                }
                if (btn_egitim.Checked != true)
                {
                    egitim_gizle();
                }
                if (btn_hobi.Checked != true)
                {
                    hobi_gizle();
                }
                if (btn_ozgecmis.Checked != true)
                {
                    ozgecmis_gizle();
                }
                if (btn_maddi.Checked != true)
                {
                    maddi_gizle();
                }
            }
        }

       private void raporlama_Load(object sender, EventArgs e)
        {
            // for (int i = 0; i < gridView1.Columns.Count; i++) 
            //gridView2.Columns[i].BestFit();
            // gridView1.Columns[1].Width=80;
            // gridView1.Columns[2].GetBestWidth();
           // gridView1.Columns[1].BestFit();
            //gridView1.Columns[2].BestFit();
            //gridView1.Columns[3].BestFit();

        }
    }
}
