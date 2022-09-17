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
    public partial class maddiBilgi : Form
    {
        public maddiBilgi()
        {
            InitializeComponent();
        }

        public void tum_maddi_bilgileri()
        {
            SqlCommand sorgu = new SqlCommand("tum_maddi_bilgileri", baglantim.baglanti());
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
            SqlCommand sorgu = new SqlCommand("Listele_Maddi_Durum_Bilgisi", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sorgu);
            sorgu.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;
            //gridView1.Columns["pdks"].Visible = false;

            gridView1.Columns["kisi_tc"].Caption = "TC NO";
            gridView1.Columns["maas"].Caption = "MAAŞ";
            gridView1.Columns["aldigi_destek_turu"].Caption = "ALDIĞI DESTEK TÜRÜ";
            gridView1.Columns["aldigi_destek_miktari"].Caption = "DESTEK MİKTARI";
            gridView1.Columns["hesap_numarasi"].Caption = "HESAP NUMARASI";
            gridView1.Columns["ev_durumu"].Caption = "EV DURUMU";
            gridView1.Columns["kira_ucreti"].Caption = "KİRA ÜCRETİ";
            gridView1.Columns["isinma_sistemi_turu"].Caption = "ISINMA SİSTEMİ";
            gridView1.Columns["kirada_ev_var_mi"].Caption = "KİRA GELİRİ OLAN EV";
            gridView1.Columns["kiradaki_evlerin_kira_ucreti"].Caption = "KİRA GELİRİ";
            gridView1.Columns["arac_durumu"].Caption = "ARAÇ DURUMU";
            gridView1.Columns["arac_kullanim_amaci"].Caption = "ARACIN KULLANIM AMACI";
            gridView1.Columns["sahip_olunan_arazi_var_mi"].Caption = "ARAZİ DURUMU";
            gridView1.Columns["sahip_olunan_arazi_kullanim_amaci"].Caption = "ARAZİ KULLANIM AMACI";
            //gridView1.Columns["icra_durumu"].Caption = "İCRA/BORÇ DURUMU";
            //gridView1.Columns["icra_konusu"].Caption = "İCRA/BORÇ NEDENİ ";
            //gridView1.Columns["icra_kesinti_miktari"].Caption = "İCRA/BORÇ MİKTARI";
            //gridView1.Columns["icra_hesap_no"].Caption = "İCRA/BORÇ HESAP NO";
            //gridView1.Columns["borc_Tarihi"].Caption = "ÖDEME TARİHİ";
            


        }
       
        //veri tabanı doaya yoluve provider nesnesinin belirlenmesi
        sqlBaglantisi baglantim = new sqlBaglantisi();
        string ev_durumu, arac_durumu, isinma_türü, kirada_evi,icra_durumu;
        string arazi_durumu = "Arazisi yok";
        private void maddiBilgi_Load(object sender, EventArgs e)
        {
            radioButton_evSahibi.Checked = true;
            radioButton_dogalgaz.Checked = true;
            radioButton_kirada_yok.Checked = true;
            radioButton_araci_yok.Checked = true;
            radioButton_arazi_yok.Checked = true;
            //radioButton_icra_yok.Checked = true;

            

            mtxt_tc_no.Mask = "00000000000";//kullnıcı 11 haneli tc numarası girebilecek.
            mtxt_ıban.Mask = "00000000000000000000000000";//hesap numarası
            txt_kira_miktari.MaxLength = 6;
           
          //  mtxt_icra_iban.Mask = "00000000000000000000000000";//hesap numarası


            tum_maddi_bilgileri();

          //  date_borc_tarihi.Visible = false;

        }
       //?
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);//sadece sayı girişi yapılabilsin

        }
        //?
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);//sadece sayı girişi yapılabilsin
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


                    label3.Text = kayitokuma.GetValue(2).ToString();//ilgili tck ait değerin veritabanındaki tck getirilecek. veri tabanı 0,1,2,.. diye gider.
                    label5.Text = kayitokuma.GetValue(3).ToString();//ad

                    break;
                }
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            mtxt_tc_no.Text = gridView1.GetFocusedRowCellValue("kisi_tc").ToString();
            txt_maas.Text = gridView1.GetFocusedRowCellValue("maas").ToString();
            cb_destek_turu.Text = gridView1.GetFocusedRowCellValue("aldigi_destek_turu").ToString();
            txt_destek_miktari.Text = gridView1.GetFocusedRowCellValue("aldigi_destek_miktari").ToString();
            mtxt_ıban.Text = gridView1.GetFocusedRowCellValue("hesap_numarasi").ToString();
            ev_durumu = gridView1.GetFocusedRowCellValue("ev_durumu").ToString();
            if (ev_durumu == "Kira")
            {
                radioButton_kira.Checked = true;
            }
            else
                radioButton_evSahibi.Checked = true;
            txt_kira_miktari.Text = gridView1.GetFocusedRowCellValue("kira_ucreti").ToString();
            isinma_türü = gridView1.GetFocusedRowCellValue("isinma_sistemi_turu").ToString();
            if (isinma_türü == "SOBA")
            {
                radioButton_soba.Checked = true;
            }
            else if (isinma_türü == "DOĞALGAZ")
            {
                radioButton_dogalgaz.Checked = true;
            }
            else if (isinma_türü == "ELEKTRİK")
            {
                radioButton_elektrik.Checked = true;
            }
            else
            {
               
                txt_isinma_aciklamasi.Text = isinma_türü;
            }
            kirada_evi = gridView1.GetFocusedRowCellValue("kirada_ev_var_mi").ToString();
            txt_kira_geliri_toplami.Text = gridView1.GetFocusedRowCellValue("kiradaki_evlerin_kira_ucreti").ToString();
            arac_durumu = gridView1.GetFocusedRowCellValue("arac_durumu").ToString();
            txt_arac_kullanim_amaci.Text = gridView1.GetFocusedRowCellValue("arac_kullanim_amaci").ToString();
            arazi_durumu = gridView1.GetFocusedRowCellValue("sahip_olunan_arazi_var_mi").ToString();
            txt_arazi_kullanim_amaci.Text = gridView1.GetFocusedRowCellValue("sahip_olunan_arazi_kullanim_amaci").ToString();
            //icra_durumu = gridView1.GetFocusedRowCellValue("icra_durumu").ToString();
            //txt_icra_konusu.Text = gridView1.GetFocusedRowCellValue("icra_konusu").ToString();
            //txt_icra_miktari.Text = gridView1.GetFocusedRowCellValue("icra_kesinti_miktari").ToString();
            //mtxt_icra_iban.Text = gridView1.GetFocusedRowCellValue("icra_hesap_no").ToString();
            //date_borc_tarihi.Text = gridView1.GetFocusedRowCellValue("borc_Tarihi").ToString();
            txt_id.Text = gridView1.GetFocusedRowCellValue("id").ToString();

            btn_guncelle.Enabled = true;
            btn_sil.Enabled = true;
            simpleButton6.Enabled = true;

        }

        

        //?
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);//sadece sayı girişi yapılabilsin
        }

        

        private void ekrani_temizle()
        {
            mtxt_tc_no.Clear();
            mtxt_ıban.Clear();
            //mtxt_icra_iban.Clear();

            label3.Text = string.Empty;
            label5.Text = string.Empty;

            cb_destek_turu.Text = string.Empty;

            txt_id.Text = string.Empty;
            txt_pdks.Text = string.Empty;
            txt_isinma_aciklamasi.Text = string.Empty;
            txt_arac_kullanim_amaci.Text = string.Empty;
            txt_arazi_kullanim_amaci.Text = string.Empty;
            //txt_icra_konusu.Text = string.Empty;
            txt_maas.Text = string.Empty;
            txt_destek_miktari.Text = string.Empty;
            txt_kira_miktari.Text = string.Empty;
            txt_kira_geliri_toplami.Text = string.Empty;
            //txt_icra_miktari.Text = string.Empty;
            //date_borc_tarihi.ResetText();
        }

        //private void radioButton_icra_var_CheckedChanged(object sender, EventArgs e)
        //{
        //    date_borc_tarihi.Visible = true;
        //    txt_icra_konusu.Enabled = true;
        //    txt_icra_miktari.Enabled = true;
        //    mtxt_icra_iban.Enabled = true;
        //}

        //private void radioButton_icra_yok_CheckedChanged(object sender, EventArgs e)
        //{
        //    date_borc_tarihi.Visible = false;
        //    txt_icra_konusu.Enabled = false;
        //    txt_icra_miktari.Enabled = false;
        //    mtxt_icra_iban.Enabled = false;
        //}


        //formu temizle
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            ekrani_temizle();
        }

        private void radioButton_kirada_yok_CheckedChanged(object sender, EventArgs e)
        {
            txt_kira_geliri_toplami.Enabled = false;
        }

        private void radioButton_kirada_var_CheckedChanged(object sender, EventArgs e)
        {
            txt_kira_geliri_toplami.Enabled = true;
        }

        private void radioButton_kira_CheckedChanged(object sender, EventArgs e)
        {
            txt_kira_miktari.Enabled = true;
        }

        private void radioButton_evSahibi_CheckedChanged(object sender, EventArgs e)
        {
            txt_kira_miktari.Enabled = false;
        }

        private void cb_destek_turu_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_destek_miktari.Enabled = true;
        }

        private void radioButton_diger_CheckedChanged(object sender, EventArgs e)
        {
            txt_isinma_aciklamasi.Enabled = true;
        }

        private void radioButton_araci_yok_CheckedChanged(object sender, EventArgs e)
        {
            txt_arac_kullanim_amaci.Enabled = false;
        }

        private void radioButton_araci_var_CheckedChanged(object sender, EventArgs e)
        {
            txt_arac_kullanim_amaci.Enabled = true;
        }

        private void radioButton_arazi_yok_CheckedChanged(object sender, EventArgs e)
        {
            txt_arazi_kullanim_amaci.Enabled = false;
        }

        private void radioButton_arazi_var_CheckedChanged(object sender, EventArgs e)
        {
            txt_arazi_kullanim_amaci.Enabled = true;
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
      



        //ARA BUTONU
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            //tck yazılarak veri tablosundaki veri araştırılır
            bool kayit_arama_durumu = false;//kayıdın olup olmadığını değerlendirecektir.
            if (mtxt_tc_no.Text.Length == 11 || txt_pdks.Text != "")
            {
                //tck 11 hane olarak yazıldı ise arama yapılabilecek aksi taktirde arama yapmaya gek yok zaten.
                //şimdi veri tabanı bağlantısı açılmalıdır.

                SqlCommand selectsorgu = new SqlCommand("kisi_arama", baglantim.baglanti());
                selectsorgu.CommandType = CommandType.StoredProcedure;

                selectsorgu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                selectsorgu.Parameters.AddWithValue("@pdks", txt_pdks.Text);

                SqlDataReader kayitokuma = selectsorgu.ExecuteReader();
                //kayıtokumanın içerisne attığımız değişkenin while döngüsü ile tüm veri tabanında arayalım.
                while (kayitokuma.Read())
                {
                    //kayıt var ise buradan true dönecek.
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


                    btn_guncelle.Enabled = true;
                    btn_sil.Enabled = true;
                    simpleButton6.Enabled = true;

                    break;
                }
                //eğer kayıt okuma durumu gerçekleşmemiş ise kayıt bulunamadı ise
                if (kayit_arama_durumu == false)
                {
                    MessageBox.Show("Arama kaydı bulunamadı", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btn_guncelle.Enabled = false;
                    btn_sil.Enabled = false;
                    simpleButton6.Enabled = false;
                }
                else
                {
                    listele();
                }
               

            }
            else
            {
                //girilen tc no 11karakter değilse
                MessageBox.Show("Lütfen 11 haneli tc giriniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //forma ekle
        private void simpleButton6_Click(object sender, EventArgs e)
        {

            //yetki belirleyelim.yeni kayıtın yetkisi kullanıcı mı yoksa kullanıcı mı bunu belirlemek için kullanılan değişkendir.


            //veri tabanı bağlantısını açaçlım . bağlantıyı daha önce tanımlamıştık.


            //ilgili tc no ya ait vb de kayıt vamı diye kontrol edelim.


            //bu kısım için veri tabanında ad soyad için bir arama yapılması gerektedir.

            //  bool kayitkontrol = false;//bir kayıt yaparken daha önceden böyle bir kullanıcı var mı diye kontrolü yapılacak


            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                lbl_tc.ForeColor = Color.Red;
            else
                lbl_tc.ForeColor = Color.Black;

            bool kayitkontrol = false;//bir kayıt yaparken daha önceden böyle bir kullanıcı var mı diye kontrolü yapılacak

            SqlCommand selectsorgu = new SqlCommand("select * from Kisi_maddi_durum_Bilgileri where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            while (kayitokuma.Read())
            {
                kayitkontrol = true;//ilgili tc noya ait bir kullanıcı var demektir.
                break;

            }
            if (kayitkontrol == false)
            { //ilgili tc no ya ait vb de kayıt vamı diye kontrol edelim.

                //önce girilen alanlar için uygun koşullar koyalım.



                if (txt_maas.Text == "")//maaş bilgisi girilsin

                    lbl_maasi.ForeColor = Color.Red;
                else
                    lbl_maasi.ForeColor = Color.Black;

                //hesap numarası mutlaka olmalıdır.
                if (mtxt_ıban.Text == "")
                    lbl_iban.ForeColor = Color.Red;
                else
                    lbl_iban.ForeColor = Color.Black;

                //destek türü seçili ise destek miktarı da girilmelidir.
                if (cb_destek_turu.Text != "")
                {
                    txt_destek_miktari.Enabled = true;
                    if (txt_destek_miktari.Text == "")
                        lbl_destek_miktari.ForeColor = Color.Red;
                    else
                        lbl_destek_miktari.ForeColor = Color.Black;
                }
                else
                {
                    txt_destek_miktari.Enabled = false;
                    lbl_destek_miktari.ForeColor = Color.Black;
                }

                //ev durumu
                if (radioButton_kira.Checked == true)//kira ise kira miktarı girilmelidir.
                {
                    txt_kira_miktari.Enabled = true;
                    if (txt_kira_miktari.Text == "")
                        lbl_kira_ucreti.ForeColor = Color.Red;
                    else
                    {
                        ev_durumu = "Kira";
                        lbl_kira_ucreti.ForeColor = Color.Black;
                    }
                }
                else
                {
                    ev_durumu = "Kendisine ait";
                    lbl_kira_ucreti.ForeColor = Color.Black;
                    txt_kira_miktari.Enabled = false;
                }

                //ısınma sistemi herhangi biri değil ise kendi belirtmellidir.
                if (radioButton_soba.Checked == false && radioButton_dogalgaz.Checked == false && radioButton_elektrik.Checked == false)
                {
                    txt_isinma_aciklamasi.Enabled = true;
                    txt_isinma_aciklamasi.Enabled = true;
                    if (txt_isinma_aciklamasi.Text == "")
                        lbl_isinma_sistemi.ForeColor = Color.Red;
                    else
                    {
                        lbl_isinma_sistemi.ForeColor = Color.Black;
                        isinma_türü = txt_isinma_aciklamasi.Text;
                    }


                }
                else
                {
                    lbl_isinma_sistemi.ForeColor = Color.Black;
                    txt_isinma_aciklamasi.Enabled = true;
                    //isinma_türü = txt_isinma_aciklamasi.Text;
                    
                        if (radioButton_soba.Checked == true)
                            isinma_türü = radioButton_soba.Text;
                        else if (radioButton_dogalgaz.Checked == true)
                            isinma_türü = radioButton_dogalgaz.Text;
                        else if (radioButton_elektrik.Checked == true)
                            isinma_türü = radioButton_elektrik.Text;
                                           
                         else
                    
                               isinma_türü = txt_isinma_aciklamasi.Text;
                    

                }

                //kirada evi var ise miktar girsin
                if (radioButton_kirada_var.Checked == true)
                {
                    txt_kira_geliri_toplami.Enabled = true;
                    if (txt_kira_geliri_toplami.Text == "")
                        lbl_kira_geliri.ForeColor = Color.Red;
                    else
                    {
                        kirada_evi = "Kirada evi vardır.";
                        lbl_kira_geliri.ForeColor = Color.Black;
                    }
                }
                else
                {
                    lbl_kira_geliri.ForeColor = Color.Black;
                    txt_kira_geliri_toplami.Enabled = false;
                    kirada_evi = "Kirada evi yoktur.";
                }
                //arabası var ise
                if (radioButton_araci_var.Checked == true)
                {
                    txt_arac_kullanim_amaci.Enabled = true;
                    if (txt_arac_kullanim_amaci.Text == "")
                        lbl_arac_kullanim_amaci.ForeColor = Color.Red;
                    else
                    {
                        arac_durumu = "Aracı var";
                        lbl_arac_kullanim_amaci.ForeColor = Color.Black;
                    }
                }
                else
                {
                    lbl_arac_kullanim_amaci.ForeColor = Color.Black;
                    txt_arac_kullanim_amaci.Enabled = false;
                    arac_durumu = "Aracı yok";
                }

                //arazi durumu
                if (radioButton_arazi_var.Checked == true)
                {
                    txt_arazi_kullanim_amaci.Enabled = true;
                    if (txt_arazi_kullanim_amaci.Text == "")
                        lbl_arazi_amaci.ForeColor = Color.Red;
                    else
                    {
                        arazi_durumu = "Arazisi var";
                        lbl_arazi_amaci.ForeColor = Color.Black;
                    }
                }
                else
                {
                    lbl_arazi_amaci.ForeColor = Color.Black;
                    txt_arazi_kullanim_amaci.Enabled = false;
                    arazi_durumu = "Arazisi yok";
                }


                ////icra durumu söz konusu ise
                //if (radioButton_icra_var.Checked == true)
                //{
                //    txt_icra_konusu.Enabled = true;
                //    txt_icra_miktari.Enabled = true;
                //    mtxt_icra_iban.Enabled = true;
                //    date_borc_tarihi.Enabled = true;
                //    icra_durumu = "İcrası var.";

                //    if (txt_icra_konusu.Text == "")
                //        lbl_icra_konusu.ForeColor = Color.Red;
                //    else
                //        lbl_icra_konusu.ForeColor = Color.Black;
                //    if (txt_icra_miktari.Text == "")
                //        lbl_icra_kesinti_miktari.ForeColor = Color.Red;
                //    else
                //        lbl_icra_kesinti_miktari.ForeColor = Color.Black;
                //    if (mtxt_icra_iban.Text == "")
                //        lbl_icra_iban.ForeColor = Color.Red;
                //    else
                //        lbl_icra_iban.ForeColor = Color.Black;

                //}
                //else
                //{
                //    icra_durumu = "İcrası yok.";
                //    lbl_icra_konusu.ForeColor = Color.Black;
                //    lbl_icra_kesinti_miktari.ForeColor = Color.Black;
                //    lbl_icra_iban.ForeColor = Color.Black;
                //    txt_icra_konusu.Enabled = false;
                //    txt_icra_miktari.Enabled = false;
                //    mtxt_icra_iban.Enabled = false;
                //    date_borc_tarihi.Enabled = false;
                //}

                //kayıt işlemine başlayalım.
                if (mtxt_tc_no.Text.Length == 11)
                {
                    //nu kısımda sadece maaş zorunlu bir veridir. 

                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_Kisi_Maddi_Durum", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@maas", txt_maas.Text);
                        eklekomutu.Parameters.AddWithValue("@aldigi_destek_turu", cb_destek_turu.Text);
                        eklekomutu.Parameters.AddWithValue("@aldigi_destek_miktari", txt_destek_miktari.Text);
                        eklekomutu.Parameters.AddWithValue("@hesap_numarasi", mtxt_ıban.Text);
                        eklekomutu.Parameters.AddWithValue("@ev_durumu", ev_durumu);
                        eklekomutu.Parameters.AddWithValue("@kira_ucreti", txt_kira_miktari.Text);
                        eklekomutu.Parameters.AddWithValue("@isinma_sistemi_turu", isinma_türü);
                        eklekomutu.Parameters.AddWithValue("@kirada_ev_var_mi", kirada_evi);
                        eklekomutu.Parameters.AddWithValue("@kiradaki_evlerin_kira_ucreti", txt_kira_geliri_toplami.Text);
                        eklekomutu.Parameters.AddWithValue("@arac_durumu", arac_durumu);
                        eklekomutu.Parameters.AddWithValue("@arac_kullanim_amaci", txt_arac_kullanim_amaci.Text);
                        eklekomutu.Parameters.AddWithValue("@sahip_olunan_arazi_var_mi", arazi_durumu);
                        eklekomutu.Parameters.AddWithValue("@sahip_olunan_arazi_kullanim_amaci", txt_arazi_kullanim_amaci.Text);
                        //eklekomutu.Parameters.AddWithValue("@icra_durumu", icra_durumu);
                        //eklekomutu.Parameters.AddWithValue("@icra_konusu", txt_icra_konusu.Text);
                        //eklekomutu.Parameters.AddWithValue("@icra_kesinti_miktari", txt_icra_miktari.Text);
                        //eklekomutu.Parameters.AddWithValue("@icra_hesap_no", mtxt_icra_iban.Text);
                        //eklekomutu.Parameters.AddWithValue("@borc_Tarihi", date_borc_tarihi.Value);


                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                        listele();
                        MessageBox.Show("Kişinin maddi durum bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }

                }

                else
                {
                    MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçirniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                //aynı tc ye ait bir kayıt var ise
                MessageBox.Show("Girilen tc kimlik numarasına ait bir kayıt mevcuttur.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        
            
            listele();

        }

        

        private void btn_guncelle_Click(object sender, EventArgs e)
        {  
            SqlCommand selectsorgu = new SqlCommand("select * from Kisi_maddi_durum_Bilgileri where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //ilgili tc no ya ait vb de kayıt vamı diye kontrol edelim.

            //önce girilen alanlar için uygun koşullar koyalım.

            if (txt_maas.Text == "")//maaş bilgisi girilsin

                lbl_maasi.ForeColor = Color.Red;
            else
                lbl_maasi.ForeColor = Color.Black;

            //hesap numarası mutlaka olmalıdır.
            if (mtxt_ıban.Text == "")
                lbl_iban.ForeColor = Color.Red;
            else
                lbl_iban.ForeColor = Color.Black;

            //destek türü seçili ise destek miktarı da girilmelidir.
            if (cb_destek_turu.Text != "")
            {
                txt_destek_miktari.Enabled = true;
                if (txt_destek_miktari.Text == "")
                    lbl_destek_miktari.ForeColor = Color.Red;
                else
                    lbl_destek_miktari.ForeColor = Color.Black;
            }
            else
            {
                txt_destek_miktari.Enabled = false;
                lbl_destek_miktari.ForeColor = Color.Black;
            }

            //ev durumu
            if (radioButton_kira.Checked == true)//kira ise kira miktarı girilmelidir.
            {
                txt_kira_miktari.Enabled = true;
                if (txt_kira_miktari.Text == "")
                    lbl_kira_ucreti.ForeColor = Color.Red;
                else
                {
                    ev_durumu = "Kira";
                    lbl_kira_ucreti.ForeColor = Color.Black;
                }
            }
            else
            {
                ev_durumu = "Kendisine ait";
                lbl_kira_ucreti.ForeColor = Color.Black;
                txt_kira_miktari.Enabled = false;
            }

            //ısınma sistemi herhangi biri değil ise kendi belirtmellidir.
            if (radioButton_soba.Checked == false && radioButton_dogalgaz.Checked == false && radioButton_elektrik.Checked == false)
            {
                radioButton_diger.Checked = true;
                txt_isinma_aciklamasi.Enabled = true;
                if (txt_isinma_aciklamasi.Text == "")
                    lbl_isinma_sistemi.ForeColor = Color.Red;
                else
                {
                    lbl_isinma_sistemi.ForeColor = Color.Black;
                    isinma_türü = txt_isinma_aciklamasi.Text;
                }


            }
            else
            {
                lbl_isinma_sistemi.ForeColor = Color.Black;
                txt_isinma_aciklamasi.Enabled = true;
                if (radioButton_soba.Checked == true)
                    isinma_türü = radioButton_soba.Text;
                else if (radioButton_dogalgaz.Checked == true)
                    isinma_türü = radioButton_dogalgaz.Text;
                else if (radioButton_elektrik.Checked == true)
                    isinma_türü = radioButton_elektrik.Text;
                else
                    isinma_türü= txt_isinma_aciklamasi.Text;
            }

            //kirada evi var ise miktar girsin
            if (radioButton_kirada_var.Checked == true)
            {
                txt_kira_geliri_toplami.Enabled = true;
                if (txt_kira_geliri_toplami.Text == "")
                    lbl_kira_geliri.ForeColor = Color.Red;
                else
                {
                    kirada_evi = "Kirada evi vardır.";
                    lbl_kira_geliri.ForeColor = Color.Black;
                }
            }
            else
            {
                lbl_kira_geliri.ForeColor = Color.Black;
                txt_kira_geliri_toplami.Enabled = false;
                kirada_evi = "Kirada evi yoktur.";
            }
            //arabası var ise
            if (radioButton_araci_var.Checked == true)
            {
                arac_durumu = "Aracı var";
                txt_arac_kullanim_amaci.Enabled = true;
                if (txt_arac_kullanim_amaci.Text == "")
                    lbl_arac_kullanim_amaci.ForeColor = Color.Red;
                else
                {
                   
                    lbl_arac_kullanim_amaci.ForeColor = Color.Black;
                }
            }
            else
            {
                lbl_arac_kullanim_amaci.ForeColor = Color.Black;
                txt_arac_kullanim_amaci.Enabled = false;
                arac_durumu = "Aracı yok";
            }

            //arazi durumu
            if (radioButton_arazi_var.Checked == true)
            {
                arazi_durumu = "Arazisi var";
                txt_arazi_kullanim_amaci.Enabled = true;

                if (txt_arazi_kullanim_amaci.Text == "")
                    lbl_arazi_amaci.ForeColor = Color.Red;
                else
                {
                    
                    lbl_arazi_amaci.ForeColor = Color.Black;
                }
            }
            else
            {
                lbl_arazi_amaci.ForeColor = Color.Black;
                txt_arazi_kullanim_amaci.Enabled = false;
                arazi_durumu = "Arazisi yok";
            }


            ////icra durumu söz konusu ise
            //if (radioButton_icra_var.Checked == true)
            //{
            //    icra_durumu = "İcrası var.";
            //    txt_icra_konusu.Enabled = true;
            //    txt_icra_miktari.Enabled = true;
            //    mtxt_icra_iban.Enabled = true;
            //    date_borc_tarihi.Enabled = true;

            //    if (txt_icra_konusu.Text == "")
            //        lbl_icra_konusu.ForeColor = Color.Red;
            //    else
            //        lbl_icra_konusu.ForeColor = Color.Black;
            //    if (txt_icra_miktari.Text == "")
            //        lbl_icra_kesinti_miktari.ForeColor = Color.Red;
            //    else
            //        lbl_icra_kesinti_miktari.ForeColor = Color.Black;
            //    if (mtxt_icra_iban.Text == "")
            //        lbl_icra_iban.ForeColor = Color.Red;
            //    else
            //        lbl_icra_iban.ForeColor = Color.Black;
            //}
            //else
            //{
            //    icra_durumu = "İcrası yok.";
            //    lbl_icra_konusu.ForeColor = Color.Black;
            //    lbl_icra_kesinti_miktari.ForeColor = Color.Black;
            //    lbl_icra_iban.ForeColor = Color.Black;
            //    txt_icra_konusu.Enabled = false;
            //    txt_icra_miktari.Enabled = false;
            //    mtxt_icra_iban.Enabled = false;
            //    date_borc_tarihi.Enabled = false;

            //}

            //kayıt işlemine başlayalım.
            if (mtxt_tc_no.Text.Length == 11)
            {
                //nu kısımda sadece maaş zorunlu bir veridir. 
                if (txt_maas.Text != "" && mtxt_ıban.Text != "")
                {
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_Kisi_Maddi_Durum", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@maas", txt_maas.Text);
                        guncellekomutu.Parameters.AddWithValue("@aldigi_destek_turu", cb_destek_turu.Text);
                        guncellekomutu.Parameters.AddWithValue("@aldigi_destek_miktari", txt_destek_miktari.Text);
                        guncellekomutu.Parameters.AddWithValue("@hesap_numarasi", mtxt_ıban.Text);
                        guncellekomutu.Parameters.AddWithValue("@ev_durumu", ev_durumu);
                        guncellekomutu.Parameters.AddWithValue("@kira_ucreti", txt_kira_miktari.Text);
                        guncellekomutu.Parameters.AddWithValue("@isinma_sistemi_turu", isinma_türü);
                        guncellekomutu.Parameters.AddWithValue("@kirada_ev_var_mi", kirada_evi);
                        guncellekomutu.Parameters.AddWithValue("@kiradaki_evlerin_kira_ucreti", txt_kira_geliri_toplami.Text);
                        guncellekomutu.Parameters.AddWithValue("@arac_durumu", arac_durumu);
                        guncellekomutu.Parameters.AddWithValue("@arac_kullanim_amaci", txt_arac_kullanim_amaci.Text);
                        guncellekomutu.Parameters.AddWithValue("@sahip_olunan_arazi_var_mi", arazi_durumu);
                        guncellekomutu.Parameters.AddWithValue("@sahip_olunan_arazi_kullanim_amaci", txt_arazi_kullanim_amaci.Text);
                        //guncellekomutu.Parameters.AddWithValue("@icra_durumu", icra_durumu);
                        //guncellekomutu.Parameters.AddWithValue("@icra_konusu", txt_icra_konusu.Text);
                        //guncellekomutu.Parameters.AddWithValue("@icra_kesinti_miktari", txt_icra_miktari.Text);
                        //guncellekomutu.Parameters.AddWithValue("@icra_hesap_no", mtxt_icra_iban.Text);
                        //guncellekomutu.Parameters.AddWithValue("borc_Tarihi", date_borc_tarihi.Value);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id.Text);

                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                        listele();
                        MessageBox.Show("Kişinin maddi durum bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                       // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }

            }
            else
            {
                MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçirniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            //listele();
        }
        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11)
            {
                bool kayit_arama_durumu = false;
      
                SqlCommand secmeSorgusu = new SqlCommand("Select *from Kisi_maddi_durum_Bilgileri where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                while (kayitokuma.Read())
                {
                    if (txt_id.Text != "")
                    {
                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from Kisi_maddi_durum_Bilgileri where kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_id.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();

                        MessageBox.Show("Kullanıcı kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //baglantim.baglanti().Close();
                        ekrani_temizle();

                    }
                    else
                    {
                        MessageBox.Show("Silinmesini istediğiniz kaydı seçiniz.");
                    }
                    
                    listele();
                    break;
                }
                //girilen tck ya göre bir kayıt bulunmaz ise
                /*if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                {
                    MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                }*/
                //baglantim.baglanti().Close();
                ekrani_temizle();


            }
            else
            {
                MessageBox.Show("Lütfen 11 haneli TC veya geçerli bir pdks giriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
