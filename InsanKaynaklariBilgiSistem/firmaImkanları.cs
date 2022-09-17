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
    public partial class firmaImkanları : Form
    {
        public firmaImkanları()
        {
            InitializeComponent();
        }
        sqlBaglantisi baglantim = new sqlBaglantisi();
        string yemekdurumu = "";
        private void firmaImkanları_Load(object sender, EventArgs e)
        {
            mtxt_tc_no.Mask = "00000000000";//kullnıcı 11 haneli tc numarası girebilecek.
            txt_vasita2.Visible = false;
            btn_v2.Visible = false;
            txt_vasita3.Visible = false;
            btn_v3.Visible = false;
            txt_vasita4.Visible = false;
            btn_v4.Visible = false;
            txt_vasita5.Visible = false;
            btn_v5.Visible = false;
            txt_vasita6.Visible = false;
            btn_v6.Visible = false;

            rdb_evet.Checked = true;

            txt_beklenti.CharacterCasing = CharacterCasing.Upper;
            txt_alerji.CharacterCasing = CharacterCasing.Upper;
            txt_vasita1.CharacterCasing = CharacterCasing.Upper;
            txt_vasita2.CharacterCasing = CharacterCasing.Upper;
            txt_vasita3.CharacterCasing = CharacterCasing.Upper;
            txt_vasita4.CharacterCasing = CharacterCasing.Upper;
            txt_vasita5.CharacterCasing = CharacterCasing.Upper;
            txt_vasita6.CharacterCasing = CharacterCasing.Upper;
            txt_yemek.CharacterCasing = CharacterCasing.Upper;

            //form yüklenir yüklenmez gritview listelensin
            listele_Kisi_firmaImkanlari();
        }


        public void listele_Kisi_firmaImkanlari()
        {
            SqlCommand sorgu = new SqlCommand("Listele_Kisi_firmaImkanlari", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;


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

                SqlCommand selectsorgu2 = new SqlCommand("select *from Kisi_iletisim_Bilgileri where tc_bilgisi='" + mtxt_tc_no.Text + "'", baglantim.baglanti());
                SqlDataReader kayitokuma2 = selectsorgu2.ExecuteReader();

                while (kayitokuma2.Read())
                {
                    txt_adres.Text = kayitokuma2.GetValue(14).ToString();

                    break;
                }

                SqlCommand selectsorgu5 = new SqlCommand("select *from Kisi_maddi_durum where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());
                SqlDataReader kayitokuma5 = selectsorgu5.ExecuteReader();

                while (kayitokuma5.Read())
                {
                    
                    if (kayitokuma5.GetValue(4).ToString() == "Yol"&& kayitokuma5.GetValue(3).ToString() == "Destek")
                    {
                        txt_destek_yol.Visible = true;
                       
                        txt_destek_yol.Text = kayitokuma5.GetValue(7).ToString();
                    }
                    else
                    {
                        txt_destek_yol.Visible = false;
                      
                    }

                    if (kayitokuma5.GetValue(4).ToString() == "Gıda"&& kayitokuma5.GetValue(3).ToString() == "Destek")
                    {
                        txt_destek_gıda.Visible = true;
                       
                        txt_destek_yol.Text = kayitokuma5.GetValue(7).ToString();
                    }
                    else
                    {
                        txt_destek_gıda.Visible = false;
                     
                    }


                    break;
                }







            }
        }

        private void ekrani_temizle()
        {
            mtxt_tc_no.Clear();
            txt_pdks.Clear();
            label3.Text = string.Empty;
            label5.Text= string.Empty;
            txt_adres.Text= string.Empty;
            txt_destek_yol.Text=string.Empty;
            txt_ulasim_ucreti.Text= string.Empty;
            time_zaman.Reset();
            txt_vasita1.Text = string.Empty;
            txt_vasita2.Text = string.Empty;
            txt_vasita3.Text = string.Empty;
            txt_vasita4.Text = string.Empty;
            txt_vasita5.Text = string.Empty;
            txt_vasita6.Text = string.Empty;
            txt_alerji.Text = string.Empty;
            txt_destek_gıda.Text = string.Empty;
            rdb_evet.Checked = true;
            rdb_hayir.Checked = false;
            txt_yemek.Text = string.Empty;
            txt_beklenti.Text = string.Empty;
            btn_v2.Visible = false;
            btn_v3.Visible = false;
            btn_v4.Visible = false;
            btn_v5.Visible = false;
            btn_v6.Visible = false;
            txt_vasita2.Visible = false;
            txt_vasita3.Visible = false;
            txt_vasita4.Visible = false;
            txt_vasita5.Visible = false;
            txt_vasita6.Visible = false;
            time_zaman.EditValue = "00:00:00";


        }

        private void btn_v1_Click(object sender, EventArgs e)
        {
            txt_vasita2.Visible = true;
            btn_v2.Visible = true;
        }

        private void btn_v2_Click(object sender, EventArgs e)
        {
            txt_vasita3.Visible = true;
            btn_v3.Visible = true;
        }

        private void btn_v3_Click(object sender, EventArgs e)
        {
            txt_vasita4.Visible = true;
            btn_v4.Visible = true;

        }

        private void btn_v4_Click(object sender, EventArgs e)
        {
            txt_vasita5.Visible = true;
            btn_v5.Visible = true;
        }

        private void btn_v5_Click(object sender, EventArgs e)
        {
            txt_vasita6.Visible = true;
            btn_v6.Visible = true;
        }

        //formu temzile

        private void btn_formu_temizle_Click(object sender, EventArgs e)
        {
            ekrani_temizle();
        }

        //ara butonu
        bool kayit_arama_durumu = false;//kayıdın olup olmadığını değerlendirecektir.
        private void btn_ara_Click(object sender, EventArgs e)
        {
            //tck yazılarak veri tablosundaki veri araştırılır
            
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
                    btn_kaydet.Enabled = true;

                    break;
                }

                SqlCommand selectsorgu_3 = new SqlCommand("select *from Kisi_firmaImkanlari where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());
                SqlDataReader kayitokuma_3 = selectsorgu_3.ExecuteReader();

                while(kayitokuma_3.Read())
                {
                    txt_ulasim_ucreti.Text = kayitokuma_3.GetValue(2).ToString();
                    //time_zaman.Value = kayitokuma.GetDateTime(7);//doğum tarihi
                    time_zaman.EditValue = kayitokuma_3.GetTimeSpan(3).ToString();
                    txt_vasita1.Text = kayitokuma_3.GetString(4).ToString();
                    txt_vasita2.Text = kayitokuma_3.GetString(5).ToString();
                    txt_vasita3.Text = kayitokuma_3.GetString(6).ToString();
                    txt_vasita4.Text = kayitokuma_3.GetString(7).ToString();
                    txt_vasita5.Text = kayitokuma_3.GetString(8).ToString();
                    txt_vasita6.Text = kayitokuma_3.GetString(9).ToString();
                    txt_alerji.Text = kayitokuma_3.GetString(10).ToString();
                    if (kayitokuma_3.GetString(11).ToString() == "EVET")
                        rdb_evet.Checked = true;
                    else
                        rdb_hayir.Checked = true;
                    txt_yemek.Text= kayitokuma_3.GetString(12).ToString();
                    txt_beklenti.Text= kayitokuma_3.GetString(13).ToString();

                }

                //adres bilgisinin çekilmesi
                SqlCommand selectsorgu_4 = new SqlCommand("select *from Kisi_Adres_Bilgileri where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());
                SqlDataReader kayitokuma_4 = selectsorgu_4.ExecuteReader();

                while (kayitokuma_4.Read())
                {
                    
                        txt_adres.Text = kayitokuma_4.GetValue(4).ToString() + "" +
                                kayitokuma_4.GetValue(5).ToString() + "" + kayitokuma_4.GetValue(6).ToString() + "" + kayitokuma_4.GetValue(7).ToString()
                                + "" + kayitokuma_4.GetValue(8).ToString() + "" + kayitokuma_4.GetValue(9).ToString() + "" + kayitokuma_4.GetValue(3).ToString()
                                + "" + kayitokuma_4.GetValue(2).ToString();

                }

                //DESTEK MİKTARLARINI ÇEKELİM
                SqlCommand selectsorgu_5 = new SqlCommand("select *from Kisi_maddi_durum where kisi_tc='" + mtxt_tc_no.Text + "'and durum='"+ "Yol" + "'", baglantim.baglanti());
                SqlDataReader kayitokuma_5 = selectsorgu_5.ExecuteReader();

                while (kayitokuma_5.Read())
                {
                    txt_destek_yol.Text = kayitokuma_5.GetValue(7).ToString();
                
                }

                SqlCommand selectsorgu_6 = new SqlCommand("select *from Kisi_maddi_durum where kisi_tc='" + mtxt_tc_no.Text + "'and durum='" + "Gıda" + "'", baglantim.baglanti());
                SqlDataReader kayitokuma_6 = selectsorgu_6.ExecuteReader();

                while (kayitokuma_6.Read())
                {
                    txt_destek_gıda.Text = kayitokuma_6.GetValue(7).ToString();
                    
                }


               



                //eğer kayıt okuma durumu gerçekleşmemiş ise kayıt bulunamadı ise
                if (kayit_arama_durumu == false)
                {
                    MessageBox.Show("Arama kaydı bulunamadı", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btn_guncelle.Enabled = false;
                    btn_sil.Enabled = false;
                    btn_kaydet.Enabled = false;
                }
            }
            else
            {
                //girilen tc no 11karakter değilse
                MessageBox.Show("Lütfen 11 haneli tc giriniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //kaydet butonu

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            bool kayitkontrol = false;//bir kayıt yaparken daha önceden böyle bir kullanıcı var mı diye kontrolü yapılacak
         
            SqlCommand selectsorgu = new SqlCommand("select * from Kisi_firmaImkanlari where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.
            //ilgili tc no ya ait vb de kayıt vamı diye kontrol edelim.

            while (kayitokuma.Read())
            {
                kayitkontrol = true;//ilgili tc noya ait bir kullanıcı var demektir.
                break;

            }


            if (kayitkontrol == false)//kayıt  yok ise kayıt yapılma işlemi  gerçekleştirilmelidir. fakat önce verilerin doğru girildiğinden emin olunmalıdır.
            {

                //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

                if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;

                if(rdb_hayir.Checked==true)
                {
                    yemekdurumu = rdb_hayir.Text;
                    if (txt_yemek.Text.Length < 0)
                        label16.ForeColor = Color.Red;
                    else
                        label16.ForeColor = Color.Black;
                }
                else
                {
                    yemekdurumu = rdb_evet.Text;
                    label16.ForeColor = Color.Black;
                }

                if (mtxt_tc_no.Text.Length == 11 )
                {

                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_Firma_Imkanlari", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;
                        eklekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@ulasim_ucreti", txt_ulasim_ucreti.Text);
                        eklekomutu.Parameters.AddWithValue("@ulasim_süresi", time_zaman.EditValue);
                        eklekomutu.Parameters.AddWithValue("@vasita1", txt_vasita1.Text);
                        eklekomutu.Parameters.AddWithValue("@vasita2", txt_vasita2.Text);
                        eklekomutu.Parameters.AddWithValue("@vasita3", txt_vasita3.Text);
                        eklekomutu.Parameters.AddWithValue("@vasita4", txt_vasita4.Text);
                        eklekomutu.Parameters.AddWithValue("@vasita5", txt_vasita5.Text);
                        eklekomutu.Parameters.AddWithValue("@vasita6", txt_vasita6.Text);
                        eklekomutu.Parameters.AddWithValue("@alerji", txt_alerji.Text);
                        eklekomutu.Parameters.AddWithValue("@yemekBilgisi", yemekdurumu);
                        eklekomutu.Parameters.AddWithValue("@yemekNedeni", txt_yemek.Text);
                        eklekomutu.Parameters.AddWithValue("@talepler", txt_beklenti.Text);

                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        
                        MessageBox.Show("Kişinin firma imkanları bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    finally
                    {

                    }

                }
                else//herhangi bir hata ile karşılaşılır ise 
                {
                    MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçirniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

            else
            {
                MessageBox.Show("Kişiye ait bilgiler mevcuttur.Tekrar kayıt gerçekleştiremezsiniz", "Optimak İnsan Kaynakları",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11)
            {
                bool kayit_arama_durumu = false;
                //baglantim.baglanti().Open();
                SqlCommand secmeSorgusu = new SqlCommand("Select *from Kisi_firmaImkanlari where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                while (kayitokuma.Read())
                {

                    //kayıt okuma gerçekleşti ise
                    kayit_arama_durumu = true;
                    SqlCommand silsorgusu = new SqlCommand("delete from Kisi_firmaImkanlari where TC='" + mtxt_tc_no.Text + "'", baglantim.baglanti());
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
                MessageBox.Show("tc kimlik no 11 haneli girilmelidir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            


                //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

                if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;

                if (rdb_hayir.Checked == true)
                {
                    yemekdurumu = rdb_hayir.Text;
                    if (txt_yemek.Text.Length < 0)
                        label16.ForeColor = Color.Red;
                    else
                        label16.ForeColor = Color.Black;
                }
                else
                {
                    yemekdurumu = rdb_evet.Text;
                    label16.ForeColor = Color.Black;
                }

                if (mtxt_tc_no.Text.Length == 11)
                {

                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_Firma_Imkanlari", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;
                        guncellekomutu.Parameters.AddWithValue("@TC", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@ulasim_ucreti", txt_ulasim_ucreti.Text);
                        guncellekomutu.Parameters.AddWithValue("@ulasim_süresi", time_zaman.EditValue);
                        guncellekomutu.Parameters.AddWithValue("@vasita1", txt_vasita1.Text);
                        guncellekomutu.Parameters.AddWithValue("@vasita2", txt_vasita2.Text);
                        guncellekomutu.Parameters.AddWithValue("@vasita3", txt_vasita3.Text);
                        guncellekomutu.Parameters.AddWithValue("@vasita4", txt_vasita4.Text);
                        guncellekomutu.Parameters.AddWithValue("@vasita5", txt_vasita5.Text);
                        guncellekomutu.Parameters.AddWithValue("@vasita6", txt_vasita6.Text);
                        guncellekomutu.Parameters.AddWithValue("@alerji", txt_alerji.Text);
                        guncellekomutu.Parameters.AddWithValue("@yemekBilgisi", yemekdurumu);
                        guncellekomutu.Parameters.AddWithValue("@yemekNedeni", txt_yemek.Text);
                        guncellekomutu.Parameters.AddWithValue("@talepler", txt_beklenti.Text);

                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir


                        MessageBox.Show("Kişinin firma imkanları bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    finally
                    {

                    }

                }
                else//herhangi bir hata ile karşılaşılır ise 
                {
                    MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçirniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            
        }

        private void mtxt_tc_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_ulasim_ucreti_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
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
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
            

        }

        private void rdb_evet_CheckedChanged(object sender, EventArgs e)
        {
            txt_yemek.Visible = false;
            label16.Visible = false;
        }

        private void rdb_hayir_CheckedChanged(object sender, EventArgs e)
        {
            txt_yemek.Visible = true;
            label16.Visible = true;
        }
    }
}
