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
    public partial class maddiDurum : Form
    {
        public maddiDurum()
        {
            InitializeComponent();
        }
        public void tum_maddi_bilgileri()
        {
            SqlCommand sorgu = new SqlCommand("tum_maddi_durum", baglantim.baglanti());
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
            SqlCommand sorgu = new SqlCommand("Listele_Maddi_Durum", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sorgu);
            sorgu.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;
            //gridView1.Columns["pdks"].Visible = false;

            gridView1.Columns["kisi_tc"].Visible = false;
            gridView1.Columns["hesap_numarasi"].Caption = "HESAP NUMARASI";
            gridView1.Columns["tur"].Caption = "TÜR";
            gridView1.Columns["durum"].Caption = "DURUM";
            gridView1.Columns["giderUcreti"].Caption = "GİDER ÜCRETİ";
            gridView1.Columns["ozellik"].Caption = "ÖZELLİK";
            gridView1.Columns["gelirUcreti"].Caption = "GELİR ÜCRETİ";
            gridView1.Columns["kullanimAmaci"].Caption = "KULLANIM AMACI";


        }
        sqlBaglantisi baglantim = new sqlBaglantisi();

        private void maddiDurum_Load(object sender, EventArgs e)
        {
            mtxt_tc_no.Mask = "00000000000";//kullnıcı 11 haneli tc numarası girebilecek.

            txt_ozellik.CharacterCasing = CharacterCasing.Upper;
            txt_kullanım_amaci.CharacterCasing = CharacterCasing.Upper;

            if (toggleSwitch1.IsOn == false)
            {
                txt_ıban.Visible = false;
                label4.Visible = false;
            }

            else
            {
                txt_ıban.Visible = true;
                label4.Visible = true;

            }


            //öğrenim düzeyi
            cbx_tur.Items.Add("Maaş");
            cbx_tur.Items.Add("Ev");
            cbx_tur.Items.Add("Araba");
            cbx_tur.Items.Add("Arazi");
            cbx_tur.Items.Add("Destek");
            cbx_tur.Items.Add("Diğer");


            //öğrenim düzeyi
            cbx_durum.Items.Add("Maaş");
            cbx_durum.Items.Add("Kendina Ait");
            cbx_durum.Items.Add("Kira");
            cbx_durum.Items.Add("Geliri Olan");
            cbx_durum.Items.Add("Yol");
            cbx_durum.Items.Add("Gıda");
            cbx_durum.Items.Add("Diğer");

            tum_maddi_bilgileri();

            label4.Visible = false;
            txt_ıban.Visible = false;


        }

        private void txt_maas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);//sadece sayı girişi yapılabilsin

        }

        private void txt_gider_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);//sadece sayı girişi yapılabilsin

        }

        private void txt_geliri_KeyPress(object sender, KeyPressEventArgs e)
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
            //mtxt_tc_no.Text = gridView1.GetFocusedRowCellValue("kisi_tc").ToString();
            //txt_maas.Text = gridView1.GetFocusedRowCellValue("maas").ToString();
            //mtxt_ıban.Text = gridView1.GetFocusedRowCellValue("hesap_numarasi").ToString();
            cbx_tur.Text = gridView1.GetFocusedRowCellValue("tur").ToString();
            cbx_durum.Text = gridView1.GetFocusedRowCellValue("durum").ToString();
            txt_gider.Text = gridView1.GetFocusedRowCellValue("giderUcreti").ToString();
            txt_ozellik.Text = gridView1.GetFocusedRowCellValue("ozellik").ToString();
            txt_geliri.Text = gridView1.GetFocusedRowCellValue("gelirUcreti").ToString();
            txt_kullanım_amaci.Text = gridView1.GetFocusedRowCellValue("kullanimAmaci").ToString();
            txt_ıban.Text = gridView1.GetFocusedRowCellValue("hesap_numarasi").ToString();
            if(gridView1.GetFocusedRowCellValue("hesap_numarasi").ToString()!="")
            {
                txt_ıban.Visible = true;
                label4.Visible = true;
                toggleSwitch1.IsOn = true;
            }
            else
            {
                txt_ıban.Visible = false;
                label4.Visible = false;
                toggleSwitch1.IsOn = false;
            }
            txt_id.Text = gridView1.GetFocusedRowCellValue("id").ToString();

            btn_guncelle.Enabled = true;
            btn_sil.Enabled = true;
            simpleButton6.Enabled = true;

        }


        private void ekrani_temizle()
        {
            mtxt_tc_no.Clear();

            label3.Text = string.Empty;
            label5.Text = string.Empty;

            cbx_tur.Text = string.Empty;
            cbx_durum.Text = string.Empty;

            txt_id.Text = string.Empty;
            txt_pdks.Text = string.Empty;

            txt_gider.Text = string.Empty;
            txt_ozellik.Text = string.Empty;
            txt_geliri.Text = string.Empty;
            txt_ıban.Text = string.Empty;
            txt_kullanım_amaci.Text = string.Empty;

            label4.Visible = false;
            txt_ıban.Visible = false;

            lbl_borc.Text = "...";

            gridView1.Columns.Clear();
            toggleSwitch1.IsOn = false;
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11)
            {
                bool kayit_arama_durumu = false;

                SqlCommand secmeSorgusu = new SqlCommand("Select *from Kisi_maddi_durum where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                while (kayitokuma.Read())
                {
                    if (txt_id.Text != "")
                    {
                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from Kisi_maddi_durum where kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_id.Text + "'", baglantim.baglanti());
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

                ekrani_temizle();


            }
            else
            {
                MessageBox.Show("Lütfen 11 haneli TC veya geçerli bir pdks giriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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




                //SqlCommand selectsorgu7 = new SqlCommand("toplam_borc", baglantim.baglanti());
                SqlCommand selectsorgu7 = new SqlCommand("XXX", baglantim.baglanti());
                selectsorgu7.CommandType = CommandType.StoredProcedure;

                selectsorgu7.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);


                SqlDataReader kayitokuma7 = selectsorgu7.ExecuteReader();

                while (kayitokuma7.Read())
                {
                    lbl_borc.Text = kayitokuma7.GetValue(1).ToString();

                    break;
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
            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                lbl_tc.ForeColor = Color.Red;
            else
                lbl_tc.ForeColor = Color.Black;

            bool kayitkontrol = false;//bir kayıt yaparken daha önceden böyle bir kullanıcı var mı diye kontrolü yapılacak

            SqlCommand selectsorgu = new SqlCommand("select * from Kisi_maddi_durum where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            if (toggleSwitch1.IsOn == false)
            {
                txt_ıban.Visible = false;
                label4.Visible = false;
            }

            else
            {
                txt_ıban.Visible = true;
                label4.Visible = true;

            }

            //kayıt işlemine başlayalım.
            if (mtxt_tc_no.Text.Length == 11)
            {

                try
                {
                    SqlCommand eklekomutu = new SqlCommand("Kaydet_Kisi_Maddi_Durum_Bilgileri", baglantim.baglanti());
                    eklekomutu.CommandType = CommandType.StoredProcedure;

                    eklekomutu.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    eklekomutu.Parameters.AddWithValue("@hesap_numarasi", txt_ıban.Text);
                    eklekomutu.Parameters.AddWithValue("@tur", cbx_tur.Text);
                    eklekomutu.Parameters.AddWithValue("@durum", cbx_durum.Text);
                    eklekomutu.Parameters.AddWithValue("@giderUcreti", txt_gider.Text);
                    eklekomutu.Parameters.AddWithValue("@ozellik", txt_ozellik.Text);
                    eklekomutu.Parameters.AddWithValue("@gelirUcreti", txt_geliri.Text);
                    eklekomutu.Parameters.AddWithValue("@kullanimAmaci", txt_kullanım_amaci.Text);


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


            listele();

        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                lbl_tc.ForeColor = Color.Red;
            else
                lbl_tc.ForeColor = Color.Black;

            bool kayitkontrol = false;//bir kayıt yaparken daha önceden böyle bir kullanıcı var mı diye kontrolü yapılacak

            SqlCommand selectsorgu = new SqlCommand("select * from Kisi_maddi_durum where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.


            if (toggleSwitch1.IsOn == false)
            {
                txt_ıban.Visible = false;
                label4.Visible = false;
            }

            else
            {
                txt_ıban.Visible = true;
                label4.Visible = true;

            }


            //kayıt işlemine başlayalım.
            if (mtxt_tc_no.Text.Length == 11)
            {

                try
                {
                    SqlCommand guncellekomutu = new SqlCommand("Guncelle_Kisi_Maddi_Durum_Bilgileri", baglantim.baglanti());
                    guncellekomutu.CommandType = CommandType.StoredProcedure;

                    guncellekomutu.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    guncellekomutu.Parameters.AddWithValue("@hesap_numarasi", txt_ıban.Text);
                    guncellekomutu.Parameters.AddWithValue("@tur", cbx_tur.Text);
                    guncellekomutu.Parameters.AddWithValue("@durum", cbx_durum.Text);
                    guncellekomutu.Parameters.AddWithValue("@giderUcreti", txt_gider.Text);
                    guncellekomutu.Parameters.AddWithValue("@ozellik", txt_ozellik.Text);
                    guncellekomutu.Parameters.AddWithValue("@gelirUcreti", txt_geliri.Text);
                    guncellekomutu.Parameters.AddWithValue("@kullanimAmaci", txt_kullanım_amaci.Text);
                    guncellekomutu.Parameters.AddWithValue("@id", txt_id.Text);

                    guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                    listele();
                    MessageBox.Show("Kişinin maddi durum bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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


            listele();

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            ekrani_temizle();
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


        private void toggleSwitch1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch1.IsOn == false)
            {
                txt_ıban.Visible = false;
                label4.Visible = false;
            }

            else
            {
                txt_ıban.Visible = true;
                label4.Visible = true;

            }
        }
    }
}
