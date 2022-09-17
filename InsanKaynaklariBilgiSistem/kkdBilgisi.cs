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
    public partial class kkdBilgisi : Form
    {
        public kkdBilgisi()
        {
            InitializeComponent();
        }
        sqlBaglantisi baglantim = new sqlBaglantisi();

        private void kkdBilgisi_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.Columns.Count; i++) gridView1.Columns[i].BestFit();
            mtxt_tc_no.Mask = "00000000000";//kullnıcı 11 haneli tc numarası girebilecek.

            txt_kkd_turu.CharacterCasing = CharacterCasing.Upper;
            txt_beden_buyukluk.CharacterCasing = CharacterCasing.Upper;
            tum_kkd_bilgileri();

            //aksiyon türleri
            cb_aksiyon.Items.Add("Kullanımda");
            cb_aksiyon.Items.Add("İşten Ayrılma");
            cb_aksiyon.Items.Add("Değişim");
            cb_aksiyon.Items.Add("Kırılma");
            cb_aksiyon.Items.Add("Görevden Ayrılma");
            cb_aksiyon.Items.Add("Kaybolma");
            cb_aksiyon.Items.Add("Yenileme");
            cb_aksiyon.SelectedItem = "Kullanımda";

            txt_beden_buyukluk.MaxLength = 5;

            DateTime zaman = DateTime.Now;
            int yil = int.Parse(zaman.ToString("yyyy"));
            int ay = int.Parse(zaman.ToString("MM"));
            int gun = int.Parse(zaman.ToString("dd"));

            //teslim tarihleri
            date_teslim_tarihi.MinDate = new DateTime(1900, 1, 1);
            date_teslim_tarihi.MaxDate = new DateTime(yil, ay, gun + 1);

            date_aksiyon_tarihi.MinDate = new DateTime(1900, 1, 1);
            date_aksiyon_tarihi.MaxDate = new DateTime(yil, ay, gun + 1);


            //aksiyon tahilerinin görünmesi
            lbl_aksiyon_tarihi.Visible = false;
            date_aksiyon_tarihi.Visible = false;

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

            txt_id.Text = string.Empty;
            txt_kkd_turu.Text = string.Empty;
            txt_beden_buyukluk.Text = string.Empty;

            cb_aksiyon.Text = string.Empty;

            date_teslim_tarihi.ResetText();
            date_aksiyon_tarihi.ResetText();

            lbl_aksiyon_tarihi.Visible = false;
            date_aksiyon_tarihi.Visible = false;
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

        private void cb_aksiyon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_aksiyon.Text == "Kullanımda")
            {
                date_aksiyon_tarihi.Visible = false;
                lbl_aksiyon_tarihi.Visible = false;
            }
            else
            {
                date_aksiyon_tarihi.Visible = true;
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
            mtxt_tc_no.Text = gridView1.GetFocusedRowCellValue("TC").ToString();
            txt_id.Text = gridView1.GetFocusedRowCellValue("id").ToString();
            txt_kkd_turu.Text = gridView1.GetFocusedRowCellValue("kkd_turu").ToString();
            txt_beden_buyukluk.Text = gridView1.GetFocusedRowCellValue("beden").ToString();
            date_teslim_tarihi.Text = gridView1.GetFocusedRowCellValue("kkd_teslim_tarihi").ToString();
            cb_aksiyon.Text = gridView1.GetFocusedRowCellValue("aksiyon_tutu").ToString();
            date_aksiyon_tarihi.Text = gridView1.GetFocusedRowCellValue("aksiyon_tarihi").ToString();

            btn_guncelle.Enabled = true;
            btn_sil.Enabled = true;
            btn_forma_ekle.Enabled = true;
        }

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


            //eğer aksiyon türüseçilir ise tarih zoruluolarak girilsin
            if (cb_aksiyon.Text != "Kullanımda" && cb_aksiyon.Text != "")
            {
                date_aksiyon_tarihi.Enabled = true;
                date_aksiyon_tarihi.Visible = true;
            }
            else
            {
                date_aksiyon_tarihi.Enabled = false;
                date_aksiyon_tarihi.Visible = false;
            }

            if (mtxt_tc_no.Text.Length == 11 && txt_kkd_turu.Text != "" && txt_beden_buyukluk.Text != "")
            {
                bool ekle = false;
                btn_forma_ekle.Enabled = true;
                try
                {
                    SqlCommand eklekomutu = new SqlCommand("Kaydet_kkd", baglantim.baglanti());
                    eklekomutu.CommandType = CommandType.StoredProcedure;

                    eklekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                    eklekomutu.Parameters.AddWithValue("@kkd_turu", txt_kkd_turu.Text);
                    eklekomutu.Parameters.AddWithValue("@beden", txt_beden_buyukluk.Text);
                    eklekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_teslim_tarihi.Value);
                    eklekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_aksiyon.Text);
                    eklekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_aksiyon_tarihi.Value);

                    ekle = true;

                    eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    listele();

                    MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                    ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                }
                catch (Exception hatamjs)
                {
                    //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                    MessageBox.Show("Kayıt esnasında hata ile karşılaşılmıştır.");
                }
            }

        }

        private void btn_formu_temizle_Click(object sender, EventArgs e)
        {
            ekrani_temizle();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            // baglantim.baglanti().Open();
            SqlCommand selectsorgu = new SqlCommand("select * from kkd where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                lbl_tc_no.ForeColor = Color.Red;
            else
                lbl_tc_no.ForeColor = Color.Black;


            //eğer aksiyon türüseçilir ise tarih zoruluolarak girilsin
            if (cb_aksiyon.Text != "Kullanımda" && cb_aksiyon.Text != "")
            {
                date_aksiyon_tarihi.Enabled = true;
                date_aksiyon_tarihi.Visible = true;
            }
            else
            {
                date_aksiyon_tarihi.Enabled = false;
                date_aksiyon_tarihi.Visible = false;
            }

            if (mtxt_tc_no.Text.Length == 11 && txt_kkd_turu.Text != "" && txt_beden_buyukluk.Text != "")
            {
                bool guncelle = false;
                btn_guncelle.Enabled = true;
                try
                {
                    SqlCommand guncellekomutu = new SqlCommand("Guncelle_kkd", baglantim.baglanti());
                    guncellekomutu.CommandType = CommandType.StoredProcedure;

                    guncellekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                    guncellekomutu.Parameters.AddWithValue("@kkd_turu", txt_kkd_turu.Text);
                    guncellekomutu.Parameters.AddWithValue("@beden", txt_beden_buyukluk.Text);
                    guncellekomutu.Parameters.AddWithValue("@kkd_teslim_tarihi", date_teslim_tarihi.Value);
                    guncellekomutu.Parameters.AddWithValue("@aksiyon_tutu", cb_aksiyon.Text);
                    guncellekomutu.Parameters.AddWithValue("@aksiyon_tarihi", date_aksiyon_tarihi.Value);
                    guncellekomutu.Parameters.AddWithValue("@id", txt_id.Text);

                    guncelle = true;

                    guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    listele();

                    MessageBox.Show("Kişinin kkd bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                    ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                }
                catch (Exception hatamjs)
                {
                    //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                    MessageBox.Show("Güncelleme esnasında hata ile karşılaşılmıştır.");
                }
            }

        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11)
            {
                bool sil = false;

                if (txt_kkd_turu.Text != "" && txt_id.Text != "")
                {
                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from kkd where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {
                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from kkd where TC='" + mtxt_tc_no.Text + "'and id='" + txt_id.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                       
                        sil = true;
                        //ekrani_temizle();
                        listele();
                        break;

                    }
                    if (sil == true)
                    {
                        MessageBox.Show("Kullanıcının KKD kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void cb_aksiyon_TextChanged(object sender, EventArgs e)
        {
            if (cb_aksiyon.Text == "Kullanımda")
                date_aksiyon_tarihi.Visible = false;
            else
            {
                date_aksiyon_tarihi.Enabled = true;
                date_aksiyon_tarihi.Visible = true;
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
