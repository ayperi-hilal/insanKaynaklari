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
    public partial class borcDurumu : Form
    {
        public borcDurumu()
        {
            InitializeComponent();
        }

        sqlBaglantisi baglantim = new sqlBaglantisi();

        public void listele_tumu()
        {
            SqlCommand sorgu = new SqlCommand("Listele_Tum_borc", baglantim.baglanti());
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
            SqlCommand sorgu = new SqlCommand("Listele_Borc_Bilgisi", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sorgu);
            sorgu.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;


            gridView1.Columns["kisi_tc"].Caption = "TC NO";
            gridView1.Columns["borcBaslangicTarihi"].Caption = "BORÇ EDİNİM TARİHİ";
            gridView1.Columns["borcNedeni"].Caption = "BORÇ NEDENİ";
            gridView1.Columns["borcKaynagi"].Caption = "BORÇ KAYNAĞI";
            gridView1.Columns["borcMiktari"].Caption = "MİKTARI";
            gridView1.Columns["durum"].Caption = "DURUM";
            gridView1.Columns["borcOdemeTarihi"].Caption = "ÖDEME TARİHİ";
            gridView1.Columns["ödendigiTarih"].Caption = "ÖDENDİĞİ TARİH";

        }

        private void borcDurumu_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.Columns.Count; i++) gridView1.Columns[i].BestFit();

            panel1.Visible = false;

            mtxt_tc_no.Mask = "00000000000";//kullnıcı 11 haneli tc numarası girebilecek.
            txt_borc_miktari.MaxLength = 8;
            txt_nedeni.CharacterCasing = CharacterCasing.Upper;
            txt_alınan_yer.CharacterCasing = CharacterCasing.Upper;
            txt_borc_miktari.CharacterCasing = CharacterCasing.Upper;
         
            DateTime zaman = DateTime.Now;
            int yil = int.Parse(zaman.ToString("yyyy"));
            int ay = int.Parse(zaman.ToString("MM"));
            int gun = int.Parse(zaman.ToString("dd"));

            //okulagiriş tarihi
            date_borc_tarihi.MinDate = new DateTime(1900, 1, 1);
            date_borc_tarihi.MaxDate = new DateTime(yil, ay, gun + 1);

            date_ödeme_tarihi.MinDate = new DateTime(yil, ay, gun + 1);
            date_kapatilan.MaxDate= new DateTime(yil, ay, gun + 1);

            listele_tumu();
        }

        private void ekrani_temizle()
        {
            mtxt_tc_no.Clear();
            txt_nedeni.Text = string.Empty;
            txt_alınan_yer.Text = string.Empty;
            txt_borc_miktari.Text = string.Empty;
            txt_pdks.Text = string.Empty;

            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
            label9.ForeColor = Color.Black;
            label12.ForeColor = Color.Black;
            label13.ForeColor = Color.Black;
            label14.ForeColor = Color.Black;

            label3.Text = string.Empty;
            label5.Text = string.Empty;



            date_borc_tarihi.ResetText();
            date_ödeme_tarihi.ResetText();

            panel1.Visible = false;

            toggleSwitch1.Reset();
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

        string borc_durumu = "YOK";
        //borç için
        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch1.IsOn == true)
            {
                panel1.Visible = true;
                date_kapatilan.Enabled = true;
                date_ödeme_tarihi.Enabled = false;
                borc_durumu = "YOK";
            }
            else
            {
                panel1.Visible = false;
                date_kapatilan.Enabled = false;
                date_ödeme_tarihi.Enabled = true;
                borc_durumu = "VAR";
            }
        }

        //ARA
        private void simpleButton5_Click(object sender, EventArgs e)
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

                    label3.Text = kayitokuma.GetValue(2).ToString();//ilgili tck ait değerin veritabanındaki tck getirilecek. veri tabanı 0,1,2,.. diye gider.
                    label5.Text = kayitokuma.GetValue(3).ToString();


                    btn_sil.Enabled = true;
                    btn_guncelle.Enabled = true;
                    btn_formaEkle.Enabled = true;

                    break;
                }
                //eğer kayıt okuma durumu gerçekleşmemiş ise kayıt bulunamadı ise
                if (kayit_arama_durumu == false)
                {
                    MessageBox.Show("Kayıt bulunamadı", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btn_sil.Enabled = false;
                    btn_guncelle.Enabled = false;
                    btn_formaEkle.Enabled = false;
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

        private void btn_formaEkle_Click(object sender, EventArgs e)
        {
            // baglantim.baglanti().Open();
            SqlCommand selectsorgu = new SqlCommand("select * from Kisi_Borc_Durumu where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            //eğer okul adına herhangi bir veri girilirse diğerlerine de yazılmak zorunda olsun.
            if (txt_nedeni.Text != "" && txt_nedeni.Text.Length > 2)
            {
                if (txt_alınan_yer.Text == string.Empty)
                    label7.ForeColor = Color.Red;
                else
                    label7.ForeColor = Color.Black;

                if (txt_borc_miktari.Text == "")
                    label14.ForeColor = Color.Red;
                else
                    label14.ForeColor = Color.Black;
                                
            }
           
            if (mtxt_tc_no.Text.Length == 11 && txt_nedeni.Text.Length > 2)
            {
                try
                {
                      SqlCommand eklekomutu = new SqlCommand("Kaydet_Borc_Bilgisi", baglantim.baglanti());
                      eklekomutu.CommandType = CommandType.StoredProcedure;
                      eklekomutu.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                      eklekomutu.Parameters.AddWithValue("@borcBaslangicTarihi", date_borc_tarihi.Value);
                      eklekomutu.Parameters.AddWithValue("@borcNedeni", txt_nedeni.Text);
                      eklekomutu.Parameters.AddWithValue("@borcKaynagi", txt_alınan_yer.Text);
                      eklekomutu.Parameters.AddWithValue("@borcMiktari", txt_borc_miktari.Text);
                      eklekomutu.Parameters.AddWithValue("@durum", borc_durumu);
                      eklekomutu.Parameters.AddWithValue("@borcOdemeTarihi", date_ödeme_tarihi.Value);
                      eklekomutu.Parameters.AddWithValue("@ödendigiTarih", date_kapatilan.Value);
                            
                      eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                      listele();
                        MessageBox.Show("Kişinin borç bilgisi başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                            // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                }
                catch (Exception hatamjs)
                {
                   //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                   MessageBox.Show(hatamjs.Message);
                }
                   
                 
            }
            else//herhangi bir hata ile karşılaşılır ise 
            {
                MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçirniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_formuTemizle_Click(object sender, EventArgs e)
        {
            ekrani_temizle();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            mtxt_tc_no.Text = gridView1.GetFocusedRowCellValue("kisi_tc").ToString();
            date_borc_tarihi.Value = Convert.ToDateTime(gridView1.GetFocusedRowCellValue("borcBaslangicTarihi"));
            txt_nedeni.Text = gridView1.GetFocusedRowCellValue("borcNedeni").ToString();
            txt_alınan_yer.Text = gridView1.GetFocusedRowCellValue("borcKaynagi").ToString();
            txt_borc_miktari.Text = gridView1.GetFocusedRowCellValue("borcMiktari").ToString();
            borc_durumu = gridView1.GetFocusedRowCellValue("durum").ToString();

            if (borc_durumu == "VAR")
            {
                toggleSwitch1.IsOn = false;
            }
            else
            {
                toggleSwitch1.IsOn = true;
            }
            date_ödeme_tarihi.Text = gridView1.GetFocusedRowCellValue("borcOdemeTarihi").ToString();
            date_kapatilan.Text = gridView1.GetFocusedRowCellValue("ödendigiTarih").ToString();

            //date_ödeme_tarihi.Value = Convert.ToDateTime(gridView1.GetFocusedRowCellValue("borcOdemeTarihi"));
            //date_kapatilan.Value = Convert.ToDateTime(gridView1.GetFocusedRowCellValue("ödendigiTarih"));
            txt_id.Text = gridView1.GetFocusedRowCellValue("id").ToString();

            btn_sil.Enabled = true;
            btn_guncelle.Enabled = true;
            btn_formaEkle.Enabled = true;
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            // baglantim.baglanti().Open();
            SqlCommand selectsorgu = new SqlCommand("select * from Kisi_Borc_Durumu where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.
                        

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            //eğer okul adına herhangi bir veri girilirse diğerlerine de yazılmak zorunda olsun.
            if (txt_nedeni.Text != "" && txt_nedeni.Text.Length > 2)
            {
                if (txt_alınan_yer.Text == string.Empty)
                    label7.ForeColor = Color.Red;
                else
                    label7.ForeColor = Color.Black;

                if (txt_borc_miktari.Text == "")
                    label14.ForeColor = Color.Red;
                else
                    label14.ForeColor = Color.Black;

            }

            if (mtxt_tc_no.Text.Length == 11)
            {
                try
                {
                    SqlCommand guncellekomutu = new SqlCommand("[Guncelle_Borc_Bilgisi]", baglantim.baglanti());
                    guncellekomutu.CommandType = CommandType.StoredProcedure;
                    guncellekomutu.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    guncellekomutu.Parameters.AddWithValue("@borcBaslangicTarihi", date_borc_tarihi.Value);
                    guncellekomutu.Parameters.AddWithValue("@borcNedeni", txt_nedeni.Text);
                    guncellekomutu.Parameters.AddWithValue("@borcKaynagi", txt_alınan_yer.Text);
                    guncellekomutu.Parameters.AddWithValue("@borcMiktari", txt_borc_miktari.Text);
                    guncellekomutu.Parameters.AddWithValue("@durum", borc_durumu);
                    guncellekomutu.Parameters.AddWithValue("@borcOdemeTarihi", date_ödeme_tarihi.Value);
                    guncellekomutu.Parameters.AddWithValue("@ödendigiTarih", date_kapatilan.Value);
                    guncellekomutu.Parameters.AddWithValue("@id", txt_id.Text);

                    guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    listele();
                    MessageBox.Show("Kişinin borç bilgisi başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                    // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                }
                catch (Exception hatamjs)
                {
                    //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                    MessageBox.Show(hatamjs.Message);
                }


            }
            else//herhangi bir hata ile karşılaşılır ise 
            {
                MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçirniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11)

            {
                bool kayit_arama_durumu = false;

                SqlCommand secmeSorgusu = new SqlCommand("Select *from Kisi_Borc_Durumu where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                while (kayitokuma.Read())
                {

                    //kayıt okuma gerçekleşti ise
                    kayit_arama_durumu = true;
                    SqlCommand silsorgusu = new SqlCommand("delete from Kisi_Borc_Durumu where kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_id.Text + "'", baglantim.baglanti());
                    //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                    silsorgusu.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcının borç kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                    //ekrani_temizle();
                    listele();
                    break;
                }
                //girilen tck ya göre bir kayıt bulunmaz ise
                if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                {
                    MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                ekrani_temizle();


            }
            else
            {
                MessageBox.Show("TC kimlik no 11 haneli girilmelidir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
