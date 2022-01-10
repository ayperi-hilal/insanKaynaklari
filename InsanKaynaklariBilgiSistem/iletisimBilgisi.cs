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
    public partial class iletisimBilgisi : Form
    {
        public iletisimBilgisi()
        {
            InitializeComponent();
        }
        sqlBaglantisi baglantim = new sqlBaglantisi();

        //ara butonu
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


                //SqlCommand selectsorgu2 = new SqlCommand("select *from Kisi_iletisim_Bilgileri where tc_bilgisi='" + mtxt_tc_no.Text + "'", baglantim.baglanti());
                //SqlDataReader kayitokuma2 = selectsorgu2.ExecuteReader();


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

                    btn_kaydet.Enabled = true;
                    btn_sil.Enabled = true;
                    btn_guncelle.Enabled = true;

                    break;
                  }

                SqlCommand selectsorgu2 = new SqlCommand("select *from Kisi_iletisim_Bilgileri where tc_bilgisi='" + mtxt_tc_no.Text + "'", baglantim.baglanti());
                SqlDataReader kayitokuma2 = selectsorgu2.ExecuteReader();

                while (kayitokuma2.Read()) {
                     mtxt_tel_no.Text = kayitokuma2.GetValue(2).ToString();
                    mtxt_cep_no.Text = kayitokuma2.GetValue(3).ToString();
                    txt_email.Text = kayitokuma2.GetValue(4).ToString();
                    txt_yakini.Text = kayitokuma2.GetValue(5).ToString();
                    mtxt_yakini_no.Text = kayitokuma2.GetValue(6).ToString();

                    cb_il.Text = kayitokuma2.GetValue(7).ToString();
                    cb_ilçe.Text = kayitokuma2.GetValue(8).ToString();
                    txt_mahalle.Text = kayitokuma2.GetValue(9).ToString();
                    txt_sokak.Text = kayitokuma2.GetValue(10).ToString();
                    mtxt_apartman.Text = kayitokuma2.GetValue(11).ToString();
                    mtxt_blok.Text = kayitokuma2.GetValue(12).ToString();
                    txt_kapi.Text = kayitokuma2.GetValue(13).ToString();
                    txt_adres.Text = kayitokuma2.GetValue(14).ToString();

                    
                    btn_kaydet.Enabled = true;
                    btn_sil.Enabled = true;
                    btn_guncelle.Enabled = true;
                    break;

                }


                  //eğer kayıt okuma durumu gerçekleşmemiş ise kayıt bulunamadı ise
                  if (kayit_arama_durumu == false)
                  {
                      MessageBox.Show("Arama kayıtı bulunamadı.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    btn_kaydet.Enabled = false;
                    btn_sil.Enabled = false;
                    btn_guncelle.Enabled = false;
                  }
                 

              }
              else
              {
                  //girilen tc no 11karakter değilse
                  MessageBox.Show("Lütfen 11 haneli tc giriniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btn_kaydet.Enabled = false;
                btn_sil.Enabled = false;
                btn_guncelle.Enabled = false;

            }

          }
         

        private void iletisimBilgisi_Load(object sender, EventArgs e)
        {
            mtxt_tc_no.Mask = "00000000000";//kullnıcı 11 haneli tc numarası girebilecek.
            mtxt_tel_no.Mask = "0000000000";//telefon no
            mtxt_cep_no.Mask = "0000000000";//cep no
            txt_email.CharacterCasing = CharacterCasing.Lower;//email
            mtxt_yakini_no.Mask = "0000000000";//yakının numarsı
            mtxt_apartman.Mask = ">LL?????????????????????????????";//apartman adı
            mtxt_blok.Mask = ">LL????????????????????";//blok adı

            cb_il.Text = string.Empty;
            cb_ilçe.Text = string.Empty;
            txt_adres.Text = string.Empty;

            txt_mahalle.CharacterCasing = CharacterCasing.Upper;
            txt_sokak.CharacterCasing = CharacterCasing.Upper;
            txt_kapi.CharacterCasing = CharacterCasing.Upper;
            txt_yakini.CharacterCasing = CharacterCasing.Upper;
            txt_adres.Enabled = false;
            /* *    *   *** *   *   *** *   *   **      **  *   *   *       *   **  */
            SqlCommand cmd = new SqlCommand("Select * from iller ORDER BY sehiradi ASC", baglantim.baglanti());

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            cb_il.ValueMember = "id";

            cb_il.DisplayMember = "sehiradi";

            cb_il.DataSource = dt;
            //* *    *   *** *   *   *** *   *   **      **  *   *   *       *   **  */
        }

        private void ekrani_temizle()
        {
            mtxt_tc_no.Clear();
            mtxt_tel_no.Clear();
            mtxt_cep_no.Clear();
            mtxt_yakini_no.Clear();
            mtxt_apartman.Clear();
            mtxt_blok.Clear();


            label3.Text = string.Empty;
            label5.Text = string.Empty;
            label16.Text = string.Empty;

            cb_il.Text = string.Empty;
            cb_ilçe.Text = string.Empty;
            txt_mahalle.Text = string.Empty;
            txt_sokak.Text = string.Empty;

            txt_adres.Text = string.Empty;
            txt_email.Text = string.Empty;
            txt_kapi.Text = string.Empty;
            txt_yakini.Text = string.Empty;

            txt_pdks.Text = string.Empty;

            lbl_tc_no.ForeColor = Color.Black;
            lbl_tel_no.ForeColor = Color.Black;
            lbl_cep_no.ForeColor = Color.Black;
            lbl_email.ForeColor = Color.Black;
            lbl_yakin.ForeColor = Color.Black;
            lbl_yakin_no.ForeColor = Color.Black;
            lbl_il.ForeColor = Color.Black;
            lbl_ilçe.ForeColor = Color.Black;
            lbl_mahalle.ForeColor = Color.Black;
            lbl_sokak.ForeColor = Color.Black;
            lbl_kapi_no.ForeColor = Color.Black;
        }


        //tc karakter sayısı kontrolü

        private void mtxt_tc_no_TextChanged(object sender, EventArgs e)
        {   //tc kimlik no giriş kısmı için kısıtlamalar yazılacaktır.
             //yukarıda 11 den fazla giremeyeceğini belirtmştirk. bu ksımda da 11d den az giremeyeceğini belirttik.
             if (mtxt_tc_no.Text.Length < 11)
                 dxErrorProvider1.SetError(mtxt_tc_no, "TC KİMLİK NO 11 KARAKTER OLMALIDIR.");
             else
                 dxErrorProvider1.ClearErrors();

         }

        
        //kaydet
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            bool kayitkontrol = false;//bir kayıt yaparken daha önceden böyle bir kullanıcı var mı diye kontrolü yapılacak
            //baglantim.baglanti().Open();
            SqlCommand selectsorgu = new SqlCommand("select * from Kisi_iletisim_Bilgileri where tc_bilgisi='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.
            //ilgili tc no ya ait vb de kayıt vamı diye kontrol edelim.

            while (kayitokuma.Read())
            {
                kayitkontrol = true;//ilgili tc noya ait bir kullanıcı var demektir.
                break;

            }
            //baglantim.baglanti().Close();

            if (kayitkontrol == false)//kayıt  yok ise kayıt yapılma işlemi  gerçekleştirilmelidir. fakat önce verilerin doğru girildiğinden emin olunmalıdır.
            {
                //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

                if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                    lbl_tc_no.ForeColor = Color.Red;
                else
                    lbl_tc_no.ForeColor = Color.Black;

                //kullanıcıcep numarası girmeli
                if (mtxt_cep_no.Text == "" || mtxt_cep_no.Text.Length < 10)
                    lbl_cep_no.ForeColor = Color.Red;
                else
                    lbl_cep_no.ForeColor = Color.Black;


                //yakını bilgisi olmalı
                if (txt_yakini.Text == "")
                    lbl_yakin.ForeColor = Color.Red;
                else
                    lbl_yakin.ForeColor = Color.Black;

                //yakınına ait iletişim bilgisi olmalı
                if (mtxt_yakini_no.Text == "" && mtxt_yakini_no.Text.Length < 10)
                    lbl_yakin_no.ForeColor = Color.Red;
                else
                    lbl_yakin_no.ForeColor = Color.Black;

                if (cb_il.Text == "")//il seçilmeli
                    lbl_il.ForeColor = Color.Red;
                else
                    lbl_il.ForeColor = Color.Black;


                if (cb_ilçe.Text == "")//ilçe seçilmeli
                    lbl_ilçe.ForeColor = Color.Red;
                else
                    lbl_ilçe.ForeColor = Color.Black;

                if (txt_mahalle.Text == "")//mahalle seçilmelidr.
                    lbl_mahalle.ForeColor = Color.Red;
                else
                    lbl_mahalle.ForeColor = Color.Black;

                if (txt_sokak.Text == "")//sokak seçilmelidir.
                    lbl_sokak.ForeColor = Color.Red;
                else
                    lbl_sokak.ForeColor = Color.Black;

                if (txt_kapi.Text == "")
                    lbl_kapi_no.ForeColor = Color.Red;
                else
                    lbl_kapi_no.ForeColor = Color.Black;




                if (mtxt_tc_no.Text.Length == 11 && mtxt_cep_no.Text != "" && txt_yakini.Text != "" &&
                    mtxt_yakini_no.Text != "" && mtxt_yakini_no.Text.Length == 10 && cb_il.Text != "" && cb_ilçe.Text != ""
                    && txt_mahalle.Text != "" && txt_sokak.Text != "" && txt_kapi.Text != "")
                {
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_iletisim_Bilgileri", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@tc_bilgisi", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@ev_tel", mtxt_tel_no.Text);
                        eklekomutu.Parameters.AddWithValue("@cep_tel", mtxt_cep_no.Text);
                        eklekomutu.Parameters.AddWithValue("@email", txt_email.Text);
                        eklekomutu.Parameters.AddWithValue("@yakini_Adi_Soyadi", txt_yakini.Text);
                        eklekomutu.Parameters.AddWithValue("@yakini_Tel_no", mtxt_yakini_no.Text);
                        eklekomutu.Parameters.AddWithValue("@il", cb_il.Text);
                        eklekomutu.Parameters.AddWithValue("@ilce", cb_ilçe.Text);
                        eklekomutu.Parameters.AddWithValue("@mahalle", txt_mahalle.Text);
                        eklekomutu.Parameters.AddWithValue("@sokak", txt_sokak.Text);
                        eklekomutu.Parameters.AddWithValue("@apartman_adi", mtxt_apartman.Text);
                        eklekomutu.Parameters.AddWithValue("@blok", mtxt_blok.Text);
                        eklekomutu.Parameters.AddWithValue("@kapi_no", txt_kapi.Text);
                        eklekomutu.Parameters.AddWithValue("@adres", txt_adres.Text);


                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir
                       
                        //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                        MessageBox.Show("Kişinin iletişim bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

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


        }

        //güncelleme
        private void btn_guncelle_Click(object sender, EventArgs e)
        {

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                lbl_tc_no.ForeColor = Color.Red;
            else
                lbl_tc_no.ForeColor = Color.Black;

            //kullanıcıcep numarası girmeli
            if (mtxt_cep_no.Text == "" || mtxt_cep_no.Text.Length < 10)
                lbl_cep_no.ForeColor = Color.Red;
            else
                lbl_cep_no.ForeColor = Color.Black;


            //yakını bilgisi olmalı
            if (txt_yakini.Text == "")
                lbl_yakin.ForeColor = Color.Red;
            else
                lbl_yakin.ForeColor = Color.Black;

            //yakınına ait iletişim bilgisi olmalı
            if (mtxt_yakini_no.Text == "" && mtxt_yakini_no.Text.Length < 10)
                lbl_yakin_no.ForeColor = Color.Red;
            else
                lbl_yakin_no.ForeColor = Color.Black;

            if (cb_il.Text == "")//il seçilmeli
                lbl_il.ForeColor = Color.Red;
            else
                lbl_il.ForeColor = Color.Black;


            if (cb_ilçe.Text == "")//ilçe seçilmeli
                lbl_ilçe.ForeColor = Color.Red;
            else
                lbl_ilçe.ForeColor = Color.Black;

            if (txt_mahalle.Text == "")//mahalle seçilmelidr.
                lbl_mahalle.ForeColor = Color.Red;
            else
                lbl_mahalle.ForeColor = Color.Black;

            if (txt_sokak.Text == "")//sokak seçilmelidir.
                lbl_sokak.ForeColor = Color.Red;
            else
                lbl_sokak.ForeColor = Color.Black;

            if (txt_kapi.Text == "")
                lbl_kapi_no.ForeColor = Color.Red;
            else
                lbl_kapi_no.ForeColor = Color.Black;




            if (mtxt_tc_no.Text.Length == 11 && mtxt_cep_no.Text != "" && txt_yakini.Text != "" &&
                mtxt_yakini_no.Text != "" && mtxt_yakini_no.Text.Length == 10 && cb_il.Text != "" && cb_ilçe.Text != ""
                && txt_mahalle.Text != "" && txt_sokak.Text != "" && txt_kapi.Text != "")
            {
                try
                {
                    SqlCommand guncellekomutu = new SqlCommand("Guncelle_iletisim_Bilgileri", baglantim.baglanti());
                    guncellekomutu.CommandType = CommandType.StoredProcedure;

                    guncellekomutu.Parameters.AddWithValue("@tc_bilgisi", mtxt_tc_no.Text);
                    guncellekomutu.Parameters.AddWithValue("@ev_tel", mtxt_tel_no.Text);
                    guncellekomutu.Parameters.AddWithValue("@cep_tel", mtxt_cep_no.Text);
                    guncellekomutu.Parameters.AddWithValue("@email", txt_email.Text);
                    guncellekomutu.Parameters.AddWithValue("@yakini_Adi_Soyadi", txt_yakini.Text);
                    guncellekomutu.Parameters.AddWithValue("@yakini_Tel_no", mtxt_yakini_no.Text);
                    guncellekomutu.Parameters.AddWithValue("@il", cb_il.Text);
                    guncellekomutu.Parameters.AddWithValue("@ilce", cb_ilçe.Text);
                    guncellekomutu.Parameters.AddWithValue("@mahalle", txt_mahalle.Text);
                    guncellekomutu.Parameters.AddWithValue("@sokak", txt_sokak.Text);
                    guncellekomutu.Parameters.AddWithValue("@apartman_adi", mtxt_apartman.Text);
                    guncellekomutu.Parameters.AddWithValue("@blok", mtxt_blok.Text);
                    guncellekomutu.Parameters.AddWithValue("@kapi_no", txt_kapi.Text);
                    guncellekomutu.Parameters.AddWithValue("@adres", txt_adres.Text);


                    guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir
                  
                    //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                    MessageBox.Show("Kişinin iletişim bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

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

        //sil butonu
        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11)
            {
                bool kayit_arama_durumu = false;
                //baglantim.baglanti().Open();
                SqlCommand secmeSorgusu = new SqlCommand("Select *from Kisi_iletisim_Bilgileri where tc_bilgisi='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                while (kayitokuma.Read())
                {

                    //kayıt okuma gerçekleşti ise
                    kayit_arama_durumu = true;
                    SqlCommand silsorgusu = new SqlCommand("delete from Kisi_iletisim_Bilgileri where tc_bilgisi='" + mtxt_tc_no.Text + "'", baglantim.baglanti());
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
        //formu temizle
        private void btn_temizle_Click(object sender, EventArgs e)
        {
            ekrani_temizle();
        }

        private void cb_il_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            //cb_il 'e çift tıklayınca bu özellik geliyor
            string sehir_id_bilgisi = cb_il.SelectedValue.ToString();

            SqlCommand cmd = new SqlCommand("Select * from ilceler where sehirid = @sehir_id", baglantim.baglanti());

            cmd.Parameters.AddWithValue("@sehir_id", sehir_id_bilgisi);

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            cb_ilçe.ValueMember = "id";

            cb_ilçe.DisplayMember = "ilceadi";

            cb_ilçe.DataSource = dt;
            txt_adres.Text = cb_il.Text + " " + cb_ilçe.Text + " " + txt_mahalle.Text + " " + txt_sokak.Text + " "
                + mtxt_apartman.Text + " " + mtxt_blok.Text + " " + txt_kapi.Text;
            //cb_il 'e çift tıklayınca bu özellik geliyor
        }

        private void cb_ilçe_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_adres.Text = cb_il.Text + " " + cb_ilçe.Text + " " + txt_mahalle.Text + " " + txt_sokak.Text + " "
                + mtxt_apartman.Text + " " + mtxt_blok.Text + " " + txt_kapi.Text;
        }

        private void txt_mahalle_TextChanged(object sender, EventArgs e)
        {
            txt_adres.Text = cb_il.Text + " " + cb_ilçe.Text + " " + txt_mahalle.Text + " " + txt_sokak.Text + " "
                + mtxt_apartman.Text + " " + mtxt_blok.Text + " " + txt_kapi.Text;
        }

        private void txt_sokak_TextChanged(object sender, EventArgs e)
        {
            txt_adres.Text = cb_il.Text + " " + cb_ilçe.Text + " " + txt_mahalle.Text + " " + txt_sokak.Text + " "
                + mtxt_apartman.Text + " " + mtxt_blok.Text + " " + txt_kapi.Text;
        }

        private void mtxt_apartman_TextChanged(object sender, EventArgs e)
        {
            txt_adres.Text = cb_il.Text + " " + cb_ilçe.Text + " " + txt_mahalle.Text + " " + txt_sokak.Text + " "
                + mtxt_apartman.Text + " " + mtxt_blok.Text + " " + txt_kapi.Text;
        }

        private void mtxt_blok_TextChanged(object sender, EventArgs e)
        {
            txt_adres.Text = cb_il.Text + " " + cb_ilçe.Text + " " + txt_mahalle.Text + " " + txt_sokak.Text + " "
                + mtxt_apartman.Text + " " + mtxt_blok.Text + " " + txt_kapi.Text;
        }

        private void txt_kapi_TextChanged(object sender, EventArgs e)
        {
            txt_adres.Text = cb_il.Text + " " + cb_ilçe.Text + " " + txt_mahalle.Text + " " + txt_sokak.Text + " "
                + mtxt_apartman.Text + " " + mtxt_blok.Text + " " + txt_kapi.Text;
        }
    }
        
}

