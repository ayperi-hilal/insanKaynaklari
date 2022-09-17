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
    public partial class saglik : Form
    {
        public saglik()
        {
            InitializeComponent();
        }
        //veri tabanı doaya yoluve provider nesnesinin belirlenmesi
        sqlBaglantisi baglantim = new sqlBaglantisi();

        string saglik_durumu, engel_durumu, ameliyat_durumu, sigara_durumu, alkol_durumu;

        public void tum_saglik_bilgileri()
        {
            SqlCommand sorgu = new SqlCommand("tum_saglik_bilgileri", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sorgu);

            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;


            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
        }

        private void saglik_Load(object sender, EventArgs e)
        {
            mtxt_tc_no.Mask = "00000000000";//kullnıcı 11 haneli tc numarası girebilecek.
            
            cm_sigara.Items.Add("Gün");
            cm_sigara.Items.Add("Ay");
            cm_sigara.Items.Add("Yıl");

            cm_alkol.Items.Add("Gün");
            cm_alkol.Items.Add("Ay");
            cm_alkol.Items.Add("Yıl");

            //kan grubu
            
            cm_kangrubu.Items.Add("0(+)");
            cm_kangrubu.Items.Add("0(-)");
            cm_kangrubu.Items.Add("A(+)");
            cm_kangrubu.Items.Add("A(-)");
            cm_kangrubu.Items.Add("B(+)");
            cm_kangrubu.Items.Add("B(-)");
            cm_kangrubu.Items.Add("AB(+)");
            cm_kangrubu.Items.Add("AB(-)");
            cm_kangrubu.Items.Add("Bilinmiyor");

            tum_saglik_bilgileri();

        }

        private void ekrani_temizle()
        {
            mtxt_tc_no.Clear();
            mtxt_boy.Clear();
            mtxt_kilo.Clear();
            mtxt_sigara.Clear();
            mtxt_alkol.Clear();

            cm_sigara.Text = string.Empty;
            cm_alkol.Text=string.Empty;
            cm_kangrubu.Text = string.Empty;

            saglik_switch.Reset();
            engel_switch.Reset();
            ameliyat_switch.Reset();
            sigara_switch.Reset();
            alkol_switch.Reset();

            alkol_switch.IsOn = false;
            sigara_switch.IsOn = false;
            ameliyat_switch.IsOn = false;
            engel_switch.IsOn = false;
            saglik_switch.IsOn = false;

            txt_saglik.Text = string.Empty;
            txt_engel.Text = string.Empty;
            txt_ameliyat.Text = string.Empty;
            txt_pdks.Text = string.Empty;

            label3.Text = string.Empty;
            label5.Text = string.Empty;
            label6.Text = string.Empty;

        }


        private void mtxt_tc_no_TextChanged(object sender, EventArgs e)
        {
            //tc kimlik no giriş kısmı için kısıtlamalar yazılacaktır.
            //yukarıda 11 den fazla giremeyeceğini belirtmştirk. bu ksımda da 11d den az giremeyeceğini belirttik.
            if (mtxt_tc_no.Text.Length < 11)
                dxErrorProvider1.SetError(mtxt_tc_no, "TC KİMLİK NO 11 KARAKTER OLMALIDIR.");
            else
                dxErrorProvider1.ClearErrors();
        }

        //sağlık sorunu
        private void saglik_switch_Toggled(object sender, EventArgs e)
        {
            if (saglik_switch.IsOn == true)
            {
                txt_saglik.Enabled = true;
                saglik_durumu = saglik_switch.Properties.OnText;
            }
            else
            {
                txt_saglik.Enabled = false;
                saglik_durumu = saglik_switch.Properties.OffText;
            }
        }

        //engel durumu
        
        private void engel_switch_Toggled(object sender, EventArgs e)
        {
            if (engel_switch.IsOn == true)
            {
                txt_engel.Enabled = true;
                engel_durumu = engel_switch.Properties.OnText;
            }
            else
            {
                txt_engel.Enabled = false;
                engel_durumu = engel_switch.Properties.OffText;
            }
        }

        //ameliyat için
        private void ameliyat_switch_Toggled(object sender, EventArgs e)
        {
            if (ameliyat_switch.IsOn == true)
            {
                txt_ameliyat.Enabled = true;
                ameliyat_durumu = ameliyat_switch.Properties.OnText;
            }
            else
            {
                txt_ameliyat.Enabled = false;
                ameliyat_durumu = ameliyat_switch.Properties.OffText;
            }
        }
       
        //sigara
        private void sigara_switch_Toggled(object sender, EventArgs e)
        {
            if (sigara_switch.IsOn == true)
            {
                mtxt_sigara.Enabled = true;
                cm_sigara.Enabled = true;
                sigara_durumu = sigara_switch.Properties.OnText;
            }
            else
            {
                mtxt_sigara.Enabled = false;
                cm_sigara.Enabled = false;
                sigara_durumu = sigara_switch.Properties.OffText;
            }
        }
         //alkol
        private void alkol_switch_Toggled(object sender, EventArgs e)
        {
            if (alkol_switch.IsOn == true)
            {
                mtxt_alkol.Enabled = true;
                cm_alkol.Enabled = true;
                alkol_durumu = alkol_switch.Properties.OnText;
            }
            else
            {
                mtxt_alkol.Enabled = false;
                cm_alkol.Enabled = false;
                alkol_durumu = alkol_switch.Properties.OffText;
            }
        }

        

        //ARA BUTONU
        private void btn_ara_Click(object sender, EventArgs e)
        {
            //tck yazılarak veri tablosundaki veri araştırılır
            bool kayit_arama_durumu = false;//kayıdın olup olmadığını değerlendirecektir.
            if (mtxt_tc_no.Text.Length == 11 || txt_pdks.Text != "")
            {
                //tck 11 hane olarak yazıldı ise arama yapılabilecek aksi taktirde arama yapmaya gek yok zaten.

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
                            btn_kaydet.Enabled = true;
                            btn_sil.Enabled = true;
                            btn_guncelle.Enabled = true;

                        }
                    }

                    label3.Text = kayitokuma.GetValue(2).ToString();//ilgili tck ait değerin veritabanındaki tck getirilecek. veri tabanı 0,1,2,.. diye gider.
                    label5.Text = kayitokuma.GetValue(3).ToString();
                    label6.Text = kayitokuma.GetValue(12).ToString();

                    btn_kaydet.Enabled = true;
                    btn_sil.Enabled = true;
                    btn_guncelle.Enabled = true;
                    break;
                }
                //eğer kayıt okuma durumu gerçekleşmemiş ise kayıt bulunamadı ise
                if (kayit_arama_durumu == false)
                {
                    MessageBox.Show("Arama kaydı bulunamadı", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btn_kaydet.Enabled = false;
                    btn_sil.Enabled = false;
                    btn_guncelle.Enabled = false;
                }
                else
                {
                    btn_kaydet.Enabled = true;
                    btn_sil.Enabled = true;
                    btn_guncelle.Enabled = true;

                    SqlCommand selectsorgu2 = new SqlCommand("Listele_Saglik_Bilgisi", baglantim.baglanti());
                    selectsorgu2.CommandType = CommandType.StoredProcedure;

                    selectsorgu2.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    SqlDataReader kayitokuma2 = selectsorgu2.ExecuteReader();


                    while (kayitokuma2.Read())
                    {
                        cm_kangrubu.Text = kayitokuma2.GetValue(2).ToString();

                        string switch_saglik = kayitokuma2.GetValue(3).ToString();
                        if (switch_saglik == "Sağlık problemi mevcuttur.")
                        {
                            saglik_switch.IsOn = true;
                        }
                        else
                        {
                            saglik_switch.IsOn = false;
                        }
                        txt_saglik.Text = kayitokuma2.GetValue(4).ToString();
                        mtxt_boy.Text = kayitokuma2.GetValue(5).ToString();
                        mtxt_kilo.Text = kayitokuma2.GetValue(6).ToString();


                        btn_kaydet.Enabled = true;
                        btn_sil.Enabled = true;
                        btn_guncelle.Enabled = true;


                        string switch_engel = kayitokuma2.GetValue(7).ToString();
                        if (switch_engel == "Engel durumu mevcuttur.")
                        {
                            engel_switch.IsOn = true;
                        }
                        else
                        {
                            engel_switch.IsOn = false;
                        }
                        txt_engel.Text = kayitokuma2.GetValue(8).ToString();

                        string switch_ameliyat = kayitokuma2.GetValue(9).ToString();
                        if (switch_ameliyat == "Ameliyat ile ilgili bir durumu mevcuttur.")
                        {
                            ameliyat_switch.IsOn = true;
                        }
                        else
                        {
                            ameliyat_switch.IsOn = false;
                        }
                        txt_ameliyat.Text = kayitokuma2.GetValue(10).ToString();

                        string switch_sigara = kayitokuma2.GetValue(11).ToString();
                        if (switch_sigara == "Sigara içmektedir.")
                        {
                            sigara_switch.IsOn = true;
                        }
                        else
                        {
                            sigara_switch.IsOn = false;
                        }
                        mtxt_sigara.Text = kayitokuma2.GetValue(12).ToString();
                        cm_sigara.Text = kayitokuma2.GetValue(13).ToString();

                        string switch_alkol = kayitokuma2.GetValue(14).ToString();
                        if (switch_alkol == "Alkol kullanmaktadır")
                        {
                            alkol_switch.IsOn = true;
                        }
                        else
                        {
                            alkol_switch.IsOn = false;
                        }
                        mtxt_alkol.Text = kayitokuma2.GetValue(15).ToString();
                        cm_alkol.Text = kayitokuma2.GetValue(16).ToString();

                        break;

                    }
                }

            }
            else
            {
                //girilen tc no 11karakter değilse
                MessageBox.Show("Lütfen 11 haneli tc giriniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_evrakYukleme_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11)
            {
                string dosya_yolu = "C:\\Dosyalar\\" + mtxt_tc_no.Text;
                if (Directory.Exists(dosya_yolu))
                {
                    aktifKullanici.kisi = mtxt_tc_no.Text;

                    MessageBox.Show("Dosya bulundu", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    evrakEkleme evrak = new evrakEkleme();
                    evrak.ShowDialog();
                }
                else
                {

                    try
                    {
                        if (mtxt_tc_no.Text == "")
                        {
                            MessageBox.Show("TC  giriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            aktifKullanici.kisi = mtxt_tc_no.Text;

                            Directory.CreateDirectory("C:\\Dosyalar\\" + mtxt_tc_no.Text);
                            MessageBox.Show("Dosya başarılı bir şekilde oluşturulmuştur.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            evrakEkleme evrak = new evrakEkleme();
                            evrak.ShowDialog();
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Dosya oluşturulamadı", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                MessageBox.Show("Lütfen 11 haneli TC kimlik numarasını eksiksiz bir şekilde giriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
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



        //kaydet butonu
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            bool kayitkontrol = false;//bir kayıt yaparken daha önceden böyle bir kullanıcı var mı diye kontrolü yapılacak
      
            SqlCommand selectsorgu = new SqlCommand("select * from Kisi_Saglik_Bilgisi where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.
            //ilgili tc no ya ait vb de kayıt vamı diye kontrol edelim.

            while (kayitokuma.Read())
            {
                kayitkontrol = true;//ilgili tc noya ait bir kullanıcı var demektir.
                MessageBox.Show("Personele ait bir veri vardır. İsterseniz güncelleyebilirsiniz.");
                break;

            }
            

            if (kayitkontrol == false)//kayıt  yok ise kayıt yapılma işlemi  gerçekleştirilmelidir. fakat önce verilerin doğru girildiğinden emin olunmalıdır.
            {
                //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

                if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                    lbl_tc_no.ForeColor = Color.Red;
                else
                    lbl_tc_no.ForeColor = Color.Black;

                //kullnıcı kan grubu için seçim yapmalıdır.
                if (cm_kangrubu.Text == string.Empty)
                    lbl_kan_grubu.ForeColor = Color.Red;
                else
                    lbl_kan_grubu.ForeColor = Color.Black;

                //sağlık açıklaması yazılmalıdır.
                if (saglik_switch.IsOn == true)
                {
                    if (txt_saglik.Text == "")
                        lbl_saglik_aciklama.ForeColor = Color.Red;
                    saglik_durumu = "Sağlık problemi mevcuttur.";
                }

                else
                {
                    lbl_saglik_aciklama.ForeColor = Color.Black;
                    saglik_durumu = "Sağlık problemi yoktur.";
                }

                    //boy
                if (mtxt_boy.Text == "")
                {
                    lbl_boy.ForeColor = Color.Red;

                }
                else
                {
                    int boy = int.Parse(mtxt_boy.Text);

                    if (boy <= 0)
                    {
                        lbl_boy.ForeColor = Color.Red;

                    }
                    else
                    {

                        lbl_boy.ForeColor = Color.Black;
                    }
                }



                //kilo

                if (mtxt_kilo.Text == "")
                {
                    lbl_kilo.ForeColor = Color.Red;

                }
                else
                {
                    int kilo = int.Parse(mtxt_kilo.Text);

                    if (kilo <= 0)
                    {
                        lbl_kilo.ForeColor = Color.Red;

                    }
                    else
                    {

                        lbl_kilo.ForeColor = Color.Black;
                    }
                }

                //engel durmuiçin açıklama yazılmalıdır               
                if (engel_switch.IsOn == true)
                {
                    if (txt_engel.Text == "")
                    lbl_engel_aciklamasi.ForeColor = Color.Red;
                    engel_durumu = "Engel durumu mevcuttur.";
                }

                else
                {
                    lbl_engel_aciklamasi.ForeColor = Color.Black;
                    engel_durumu = "Engel durumu yoktur.";
                }

                //ameliyat durmu için açıklama yazılmalıdır               
                if (ameliyat_switch.IsOn == true)
                {
                    if (txt_ameliyat.Text == "")
                        lbl_ameliyat_aciklamasi.ForeColor = Color.Red;
                   ameliyat_durumu = "Ameliyat ile ilgili bir durumu mevcuttur.";
                }

                else
                {
                    lbl_ameliyat_aciklamasi.ForeColor = Color.Black;
                    ameliyat_durumu = "Ameliyat ile ilgili bir durumu yoktur.";
                }

                //sigara içim bilgileri
                if (sigara_switch.IsOn == true)
                {
                    if (mtxt_sigara.Text == "" && cm_sigara.Text == string.Empty)
                    {
                        lbl_sigara.ForeColor = Color.Red;
                    }
                    sigara_durumu = "Sigara içmektedir.";
                }

                else
                {
                    sigara_durumu = "Sigara içmemektedir.";
                    lbl_sigara.ForeColor = Color.Black;
                }

                //alkol içim bilgileri
                if (alkol_switch.IsOn == true)
                {
                    if (mtxt_alkol.Text == "" && cm_alkol.Text == string.Empty)
                    {
                        lbl_alkol.ForeColor = Color.Red;
                        
                    }
                    alkol_durumu = "Alkol kullanmaktadır";

                }

                else
                {
                    lbl_alkol.ForeColor = Color.Black;
                    alkol_durumu = "Alkol kullanmamaktadır";
                }

                if (mtxt_tc_no.Text.Length==11 && cm_kangrubu.Text != string.Empty && mtxt_boy.Text.Length>0 && mtxt_kilo.Text.Length>0)
                {
                    try
                    {
                        //önce veri tabanına bağlanalım.
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_Saglik_Bilgisi", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@kan_grubu", cm_kangrubu.Text);
                        eklekomutu.Parameters.AddWithValue("@saglik_sorunu", saglik_durumu);
                        eklekomutu.Parameters.AddWithValue("@saglik_sorunu_aciklama", txt_saglik.Text);
                        eklekomutu.Parameters.AddWithValue("@boy", mtxt_boy.Text);
                        eklekomutu.Parameters.AddWithValue("@kilo", mtxt_kilo.Text);
                        eklekomutu.Parameters.AddWithValue("@engel_durumu", engel_durumu);
                        eklekomutu.Parameters.AddWithValue("@engel_aciklama", txt_engel.Text);
                        eklekomutu.Parameters.AddWithValue("@ameliyat", ameliyat_durumu);
                        eklekomutu.Parameters.AddWithValue("@ameliyat_aciklama", txt_ameliyat.Text);
                        eklekomutu.Parameters.AddWithValue("@sigara", sigara_durumu);
                        eklekomutu.Parameters.AddWithValue("@sigara_baslangic_gün", mtxt_sigara.Text);
                        eklekomutu.Parameters.AddWithValue("@sigara_baslangic_miktar", cm_sigara.Text);
                        eklekomutu.Parameters.AddWithValue("@alkol", alkol_durumu);
                        eklekomutu.Parameters.AddWithValue("@alkol_baslangic_gün", mtxt_alkol.Text);
                        eklekomutu.Parameters.AddWithValue("@alkol_baslangic_miktar", cm_alkol.Text);


                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir
                       
                        //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                        MessageBox.Show("Kişinin sağlık bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);
                       

                    }
                }
                else//herhangi bir hata ile karşılaşılır ise 
                {
                    MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçiriniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {   //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

                if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                    lbl_tc_no.ForeColor = Color.Red;
                else
                    lbl_tc_no.ForeColor = Color.Black;

                //kullnıcı kan grubu için seçim yapmalıdır.
                if (cm_kangrubu.Text == string.Empty)
                    lbl_kan_grubu.ForeColor = Color.Red;
                else
                    lbl_kan_grubu.ForeColor = Color.Black;

                //sağlık açıklaması yazılmalıdır.
                if (saglik_switch.IsOn == true)
                {
                    if (txt_saglik.Text == "")
                        lbl_saglik_aciklama.ForeColor = Color.Red;
                    saglik_durumu = "Sağlık problemi mevcuttur.";
                }

                else
            {
                lbl_saglik_aciklama.ForeColor = Color.Black;
                saglik_durumu = "Sağlık problemi yoktur.";
            }

            //boy
            if (mtxt_boy.Text == "")
                {
                    lbl_boy.ForeColor = Color.Red;

                }
                else
                {
                    int boy = int.Parse(mtxt_boy.Text);

                    if (boy <= 0)
                    {
                        lbl_boy.ForeColor = Color.Red;

                    }
                    else
                    {

                        lbl_boy.ForeColor = Color.Black;
                    }
                }



                //kilo

                if (mtxt_kilo.Text == "")
                {
                    lbl_kilo.ForeColor = Color.Red;

                }
                else
                {
                    int kilo = int.Parse(mtxt_kilo.Text);

                    if (kilo <= 0)
                    {
                        lbl_kilo.ForeColor = Color.Red;

                    }
                    else
                    {

                        lbl_kilo.ForeColor = Color.Black;
                    }
                }

                //engel durmuiçin açıklama yazılmalıdır               
                if (engel_switch.IsOn == true)
                {
                    if (txt_engel.Text == "")
                        lbl_engel_aciklamasi.ForeColor = Color.Red;
                    engel_durumu = "Engel durumu mevcuttur.";
                }

                else
            {
                lbl_engel_aciklamasi.ForeColor = Color.Black;
                engel_durumu = "Engel durumu yoktur.";
            }

            //ameliyat durmu için açıklama yazılmalıdır               
            if (ameliyat_switch.IsOn == true)
                {
                    if (txt_ameliyat.Text == "")
                        lbl_ameliyat_aciklamasi.ForeColor = Color.Red;
                    ameliyat_durumu = "Ameliyat ile ilgili bir durumu mevcuttur.";
                }

                else
            {
                lbl_ameliyat_aciklamasi.ForeColor = Color.Black;
                ameliyat_durumu = "Ameliyat ile ilgili bir durumu yoktur.";
            }

            //sigara içim bilgileri
            if (sigara_switch.IsOn == true)
                {
                    if (mtxt_sigara.Text == "" && cm_sigara.Text == string.Empty)
                    {
                        lbl_sigara.ForeColor = Color.Red;
                    }
                    sigara_durumu = "Sigara içmektedir.";
                }

                else
            {
                sigara_durumu = "Sigara içmemektedir.";
                lbl_sigara.ForeColor = Color.Black;
            }

            //alkol içim bilgileri
            if (alkol_switch.IsOn == true)
                {
                    if (mtxt_alkol.Text == "" && cm_alkol.Text == string.Empty)
                    {
                        lbl_alkol.ForeColor = Color.Red;

                    }
                    alkol_durumu = "Alkol kullanmaktadır";

                }

                else
            {
                lbl_alkol.ForeColor = Color.Black;
                alkol_durumu = "Alkol kullanmamaktadır";
            }

            if (mtxt_tc_no.Text.Length == 11 && cm_kangrubu.Text != string.Empty && mtxt_boy.Text.Length > 0 && mtxt_kilo.Text.Length > 0)
                {
                    try
                    {
                    //önce veri tabanına bağlanalım.

                    SqlCommand guncellekomutu = new SqlCommand("Guncelle_Saglik_Bilgisi", baglantim.baglanti());
                    guncellekomutu.CommandType = CommandType.StoredProcedure;

                    guncellekomutu.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                    guncellekomutu.Parameters.AddWithValue("@kan_grubu", cm_kangrubu.Text);
                    guncellekomutu.Parameters.AddWithValue("@saglik_sorunu", saglik_durumu);
                    guncellekomutu.Parameters.AddWithValue("@saglik_sorunu_aciklama", txt_saglik.Text);
                    guncellekomutu.Parameters.AddWithValue("@boy", mtxt_boy.Text);
                    guncellekomutu.Parameters.AddWithValue("@kilo", mtxt_kilo.Text);
                    guncellekomutu.Parameters.AddWithValue("@engel_durumu", engel_durumu);
                    guncellekomutu.Parameters.AddWithValue("@engel_aciklama", txt_engel.Text);
                    guncellekomutu.Parameters.AddWithValue("@ameliyat", ameliyat_durumu);
                    guncellekomutu.Parameters.AddWithValue("@ameliyat_aciklama", txt_ameliyat.Text);
                    guncellekomutu.Parameters.AddWithValue("@sigara", sigara_durumu);
                    guncellekomutu.Parameters.AddWithValue("@sigara_baslangic_gün", mtxt_sigara.Text);
                    guncellekomutu.Parameters.AddWithValue("@sigara_baslangic_miktar", cm_sigara.Text);
                    guncellekomutu.Parameters.AddWithValue("@alkol", alkol_durumu);
                    guncellekomutu.Parameters.AddWithValue("@alkol_baslangic_gün", mtxt_alkol.Text);
                    guncellekomutu.Parameters.AddWithValue("@alkol_baslangic_miktar", cm_alkol.Text);

                    guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir
                        baglantim.baglanti().Close();
                        //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                        MessageBox.Show("Kişinin sağlık bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

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
     
                SqlCommand secmeSorgusu = new SqlCommand("Select *from Kisi_Saglik_Bilgisi where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                while (kayitokuma.Read())
                {

                    //kayıt okuma gerçekleşti ise
                    kayit_arama_durumu = true;
                    SqlCommand silsorgusu = new SqlCommand("delete from Kisi_Saglik_Bilgisi where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());
                    //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                    silsorgusu.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  
                    ekrani_temizle();
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

        private void btn_formu_temizle_Click(object sender, EventArgs e)
        {
            ekrani_temizle();
        }

        
    }
}
