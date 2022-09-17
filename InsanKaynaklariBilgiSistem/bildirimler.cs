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
    public partial class bildirimler : Form
    {
        public bildirimler()
        {
            InitializeComponent();
        }
        sqlBaglantisi baglantim = new sqlBaglantisi();
        DataSet daset = new DataSet();

        private void bildirimler_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.Columns.Count; i++) gridView1.Columns[i].BestFit();

        }
        public void formu_temizle()
        {
            gridView1.Columns.Clear();
        }
        public void yaklasandogumGünüListeler()
        {
            /*SqlDataAdapter adtr = new SqlDataAdapter("select ad+' '+soyad as 'PERSONEL ADI', dogum_Tarihi AS 'DOĞUM TARİHİ' from Kisi where day(dogum_Tarihi)= '" + DateTime.Now.ToString("dd") + "'and month(dogum_Tarihi)='" + DateTime.Now.ToString("MM") + "'", baglantim.baglanti());
            adtr.Fill(daset, "Kisi");
            gridControl1.DataSource = daset.Tables["Kisi"];*/

            SqlCommand sorgu1 = new SqlCommand("Bildirim_Dogum_Günü_Yaklasan", baglantim.baglanti());
            sorgu1.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da1 = new SqlDataAdapter(sorgu1);

            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            gridControl1.DataSource = dt1;
            gridView1.Columns["BİR HAFTA SONRAKİ YAŞI"].Visible = false;

            gridView1.Columns["GEÇEN HAFTAKİ YAŞI"].Visible = false;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;

            gridView1.BestFitColumns();
        }
        public void bugundogumGünüListeler()
        {
            /*SqlDataAdapter adtr = new SqlDataAdapter("select ad+' '+soyad as 'PERSONEL ADI', dogum_Tarihi AS 'DOĞUM TARİHİ' from Kisi where day(dogum_Tarihi)= '" + DateTime.Now.ToString("dd") + "'and month(dogum_Tarihi)='" + DateTime.Now.ToString("MM") + "'", baglantim.baglanti());
            adtr.Fill(daset, "Kisi");
            gridControl1.DataSource = daset.Tables["Kisi"];*/

            SqlCommand sorgu2 = new SqlCommand("Bildirim_Dogum_Günü_Bugün", baglantim.baglanti());
            sorgu2.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da2 = new SqlDataAdapter(sorgu2);

            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;

            gridView1.BestFitColumns();
        }
        public void bugunmerasimTarihleriListeler()
        {
            SqlCommand sorgu3 = new SqlCommand("Bildirim_Kisi_Planli_Merasim_Bugün", baglantim.baglanti());
            sorgu3.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da3 = new SqlDataAdapter(sorgu3);

            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            gridControl1.DataSource = dt3;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;

            gridView1.BestFitColumns();

        }
        public void yakinmerasimTarihleriListeler()
        {
            SqlCommand sorgu4 = new SqlCommand("Bildirim_Kisi_Planli_Merasim_Yaklasan", baglantim.baglanti());
            sorgu4.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da4 = new SqlDataAdapter(sorgu4);

            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            gridControl1.DataSource = dt4;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;

            gridView1.BestFitColumns();
        }
        public void bugunborçTarihleriListeler()
        {
            SqlCommand sorgu5 = new SqlCommand("Borc_Odeme_Bugün", baglantim.baglanti());
            sorgu5.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da5 = new SqlDataAdapter(sorgu5);

            DataTable dt5 = new DataTable();
            da5.Fill(dt5);
            gridControl1.DataSource = dt5;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;

            gridView1.BestFitColumns();

        }
        public void buhaftaborçTarihleriListeler()
        {
            SqlCommand sorgu6 = new SqlCommand("Borc_Odeme_Buhafta", baglantim.baglanti());
            sorgu6.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da6 = new SqlDataAdapter(sorgu6);

            DataTable dt6 = new DataTable();
            da6.Fill(dt6);
            gridControl1.DataSource = dt6;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;

            gridView1.BestFitColumns();

        }
        public void buayborçTarihleriListeler()
        {
            SqlCommand sorgu7 = new SqlCommand("Borc_Odeme_Buay", baglantim.baglanti());
            sorgu7.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da7 = new SqlDataAdapter(sorgu7);

            DataTable dt7 = new DataTable();
            da7.Fill(dt7);
            gridControl1.DataSource = dt7;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;

            gridView1.BestFitColumns();

        }
        public void gecikenborçTarihleriListeler()
        {
            SqlCommand sorgu8 = new SqlCommand("Borcu_Geciken", baglantim.baglanti());
            sorgu8.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da8 = new SqlDataAdapter(sorgu8);

            DataTable dt8 = new DataTable();
            da8.Fill(dt8);
            gridControl1.DataSource = dt8;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;

            gridView1.BestFitColumns();

        }
        public void asertifikadolduTarihleriListeler()
        {
            SqlCommand sorgu9 = new SqlCommand("Bildirim_agir_Sertifika_Bitisi_Bugün", baglantim.baglanti());
            sorgu9.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da9 = new SqlDataAdapter(sorgu9);

            DataTable dt9 = new DataTable();
            da9.Fill(dt9);
            gridControl1.DataSource = dt9;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;

            gridView1.BestFitColumns();

        }
        public void asertifikabuhaftadolcakTarihleriListeler()
        {
            SqlCommand sorgu10 = new SqlCommand("Bildirim_agir_Sertifika_Bitisi_Buhafta", baglantim.baglanti());
            sorgu10.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da10 = new SqlDataAdapter(sorgu10);

            DataTable dt10 = new DataTable();
            da10.Fill(dt10);
            gridControl1.DataSource = dt10;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;

            gridView1.BestFitColumns();

        }
        public void asertifikabuaydolcakTarihleriListeler()
        {
            SqlCommand sorgu11 = new SqlCommand("Bildirim_agir_Sertifika_Bitisi_Buay", baglantim.baglanti());
            sorgu11.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da11 = new SqlDataAdapter(sorgu11);

            DataTable dt11 = new DataTable();
            da11.Fill(dt11);
            gridControl1.DataSource = dt11;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;

            gridView1.BestFitColumns();

        }
        public void asertifikagectiTarihleriListeler()
        {
            SqlCommand sorgu12 = new SqlCommand("Bildirim_agir_Sertifika_Bitisi_Gecti", baglantim.baglanti());
            sorgu12.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da12 = new SqlDataAdapter(sorgu12);

            DataTable dt12 = new DataTable();
            da12.Fill(dt12);
            gridControl1.DataSource = dt12;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;

            gridView1.BestFitColumns();

        }
        public void sertifikabuhaftabitisTarihleriListeler()
        {
            SqlCommand sorgu13 = new SqlCommand("Bildirim_Sertifika_Bitisi_Buhafta", baglantim.baglanti());
            sorgu13.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da13 = new SqlDataAdapter(sorgu13);

            DataTable dt13 = new DataTable();
            da13.Fill(dt13);
            gridControl1.DataSource = dt13;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;

            gridView1.BestFitColumns();

        }
        public void sertifikabuaybitisTarihleriListeler()
        {
            SqlCommand sorgu14 = new SqlCommand("Bildirim_Sertifika_Bitisi_Buay", baglantim.baglanti());
            sorgu14.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da14 = new SqlDataAdapter(sorgu14);


            DataTable dt14 = new DataTable();
            da14.Fill(dt14);
            gridControl1.DataSource = dt14;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;


            gridView1.BestFitColumns();

        }
        public void sertifikabittiTarihleriListeler()
        {
            SqlCommand sorgu15 = new SqlCommand("Bildirim_Sertifika_Bitisi_Gecti", baglantim.baglanti());
            sorgu15.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da15 = new SqlDataAdapter(sorgu15);


            DataTable dt15 = new DataTable();
            da15.Fill(dt15);
            gridControl1.DataSource = dt15;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;


            gridView1.BestFitColumns();

        }
        public void bugunMerasimVarListeler()
        {
            SqlCommand sorgu16 = new SqlCommand("Aile_Merasim_Bugün", baglantim.baglanti());
            sorgu16.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da16 = new SqlDataAdapter(sorgu16);


            DataTable dt16 = new DataTable();
            da16.Fill(dt16);
            gridControl1.DataSource = dt16;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;


            gridView1.BestFitColumns();

        }
        public void buhaftaMerasimVarListeler()
        {
            SqlCommand sorgu17 = new SqlCommand("Aile_Merasim_Buhafta", baglantim.baglanti());
            sorgu17.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da17 = new SqlDataAdapter(sorgu17);

            DataTable dt17 = new DataTable();
            da17.Fill(dt17);
            gridControl1.DataSource = dt17;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;

            gridView1.BestFitColumns();
        }

        //public void sertifikalarigoster()
        //{
        //    SqlCommand sorguS = new SqlCommand("sertifikalarigoster", baglantim.baglanti());
        //    sorguS.CommandType = CommandType.StoredProcedure;

        //    SqlDataAdapter daS = new SqlDataAdapter(sorguS);


        //    DataTable dtS = new DataTable();
        //    daS.Fill(dtS);
        //    gridControl1.DataSource = dtS;

        //    gridView1.OptionsBehavior.Editable = false;
        //    gridView1.OptionsView.ShowAutoFilterRow = true;

        //    gridView1.BestFitColumns();
        //}

        //public void agirsertifikalarigoster()
        //{
        //    SqlCommand sorguS = new SqlCommand("agirsertifikalarigoster", baglantim.baglanti());
        //    sorguS.CommandType = CommandType.StoredProcedure;

        //    SqlDataAdapter daS = new SqlDataAdapter(sorguS);


        //    DataTable dtS = new DataTable();
        //    daS.Fill(dtS);
        //    gridControl1.DataSource = dtS;

        //    gridView1.OptionsBehavior.Editable = false;
        //    gridView1.OptionsView.ShowAutoFilterRow = true;

        //    gridView1.BestFitColumns();
        //}

        /*
    {
        SqlDataAdapter adtr = new SqlDataAdapter("select " +
            "Kisi_maddi_durum_Bilgileri.kisi_tc AS 'TC NO'," +
            "Kisi.ad +Kisi.soyad AS 'PEROSNEL' ," +
            "Kisi_maddi_durum_Bilgileri.maas AS 'MAAŞ'," +
            "Kisi_maddi_durum_Bilgileri.aldigi_destek_turu AS 'ALDIĞI DESTEK TÜRÜ'," +
            "Kisi_maddi_durum_Bilgileri.aldigi_destek_miktari AS 'DESTEK MİKTARI'," +
            "Kisi_maddi_durum_Bilgileri.ev_durumu AS 'EV BİLGİSİ'," +
            "Kisi_maddi_durum_Bilgileri.kira_ucreti AS 'KİRA ÜCRETİ'," +
            "Kisi_maddi_durum_Bilgileri.isinma_sistemi_turu AS 'EVİN ISINMA SİSTEMİ'," +
            "kirada_ev_var_mi AS 'KİRA GELİRİ OLAN EV'," +
            "kiradaki_evlerin_kira_ucreti AS 'KİRA GELİRİ'," +
            "arac_durumu AS 'ARAÇ DURUMU'," +
            "Kisi_maddi_durum_Bilgileri.arac_kullanim_amaci AS 'ARAÇ KULLANIM AMACI'," +
            "Kisi_maddi_durum_Bilgileri.sahip_olunan_arazi_var_mi AS 'ARAZİ DURUMU'," +
            "Kisi_maddi_durum_Bilgileri.sahip_olunan_arazi_kullanim_amaci AS 'ARAZİ KULLANIM AMACI'," +
            "Kisi_maddi_durum_Bilgileri.icra_durumu AS 'İCRA DURUMU'," +
            "Kisi_maddi_durum_Bilgileri.icra_konusu AS 'İCRA KONUSU',Kisi_maddi_durum_Bilgileri.icra_kesinti_miktari AS 'KESNTİ MİKTARI',Kisi_maddi_durum_Bilgileri.icra_hesap_no AS 'İCRA HESAP NO',Kisi_maddi_durum_Bilgileri.borc_Tarihi AS 'ÖDEME TARİHİ' from Kisi_maddi_durum_Bilgileri INNER Join Kisi on Kisi.TC=Kisi_maddi_durum_Bilgileri.kisi_tc where day(borc_Tarihi)= '" + DateTime.Now.ToString("dd") + "'and month(borc_Tarihi)='"+DateTime.Now.ToString("MM"), baglantim.baglanti());





        adtr.Fill(daset, "Kisi_maddi_durum_Bilgileri INNER Join Kisi");
        gridControl1.DataSource = daset.Tables["Kisi_maddi_durum_Bilgileri"];

    }*/
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            formu_temizle();
            if (comboBox1.SelectedIndex == 0)//eğer doğum gnlerini görme ister ise
            {
                yaklasandogumGünüListeler();

            }
            else if (comboBox1.SelectedIndex == 1)//merasim tarihleri seçilir ise
            {
                bugundogumGünüListeler();
            }
            else if (comboBox1.SelectedIndex == 2)//borc durmu geçti ise
            {
                bugunmerasimTarihleriListeler();
            }
            else if (comboBox1.SelectedIndex == 3)//merasim tarihleri seçilir ise
            {
                yakinmerasimTarihleriListeler();
            }
            else if (comboBox1.SelectedIndex == 4)//merasim tarihleri seçilir ise
            {
                bugunborçTarihleriListeler();
            }
            else if (comboBox1.SelectedIndex == 5)//merasim tarihleri seçilir ise
            {
                buhaftaborçTarihleriListeler();
            }
            else if (comboBox1.SelectedIndex == 6)//borc durmu geçti ise
            {
                buayborçTarihleriListeler();
            }
            else if (comboBox1.SelectedIndex == 7)//merasim tarihleri seçilir ise
            {
                gecikenborçTarihleriListeler();
            }
            else if (comboBox1.SelectedIndex == 8)//merasim tarihleri seçilir ise
            {
                asertifikadolduTarihleriListeler();
            }
            else if (comboBox1.SelectedIndex == 9)//merasim tarihleri seçilir ise
            {
                asertifikabuhaftadolcakTarihleriListeler();
            }
            else if (comboBox1.SelectedIndex == 10)//merasim tarihleri seçilir ise
            {
                asertifikabuaydolcakTarihleriListeler();
            }
            else if (comboBox1.SelectedIndex == 11)//merasim tarihleri seçilir ise
            {
                asertifikagectiTarihleriListeler();
            }
            else if (comboBox1.SelectedIndex == 12)//merasim tarihleri seçilir ise
            {
                sertifikabuhaftabitisTarihleriListeler();
            }
            else if (comboBox1.SelectedIndex == 13)//merasim tarihleri seçilir ise
            {
                sertifikabuaybitisTarihleriListeler();
            }
            else if (comboBox1.SelectedIndex == 14)//merasim tarihleri seçilir ise
            {
                sertifikabittiTarihleriListeler();
            }
            else if (comboBox1.SelectedIndex == 15)//merasim tarihleri seçilir ise
            {
                bugunMerasimVarListeler();
            }
            else if (comboBox1.SelectedIndex == 16)//merasim tarihleri seçilir ise
            {
                buhaftaMerasimVarListeler();
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
