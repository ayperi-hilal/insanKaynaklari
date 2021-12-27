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
    public partial class ozGecmis : Form
    {
        public ozGecmis()
        {
            InitializeComponent();
        }
        //veri tabanı doaya yoluve provider nesnesinin belirlenmesi
        sqlBaglantisi baglantim = new sqlBaglantisi();

        public void listele()
        {
            SqlCommand sorgu = new SqlCommand("Listele_Ozgecmis_isyeri", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(sorgu);
            sorgu.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);

            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;

            gridView1.Columns["kisi_tc"].Caption = "TC NO";
            gridView1.Columns["isyeri_adi"].Caption = "ÇALIŞILAN İŞ YERİ";
            gridView1.Columns["tel"].Caption = "TELEFON NO";
            gridView1.Columns["gorev"].Caption = "GÖREV";
            gridView1.Columns["maaş"].Caption = "MAAŞ";
            gridView1.Columns["yon_adi"].Caption = "YÖNETİCİ ADI SOYADI";
            gridView1.Columns["giris_tarihi"].Caption = "GİRİŞ TARİHİ";
            gridView1.Columns["cikis_tarihi"].Caption = "ÇIKIŞ TARİHİ";
            gridView1.Columns["sebep"].Caption = "İŞTEN AYRILMA SEBEBİ";
           



        }
        private void ozGecmis_Load(object sender, EventArgs e)
        {
            mtxt_tc_no.Mask = "00000000000";//kullnıcı 11 haneli tc numarası girebilecek.
            m_txt_isad.Text.ToUpper();
            mtxt_istel.Mask = "0000000000";//cep no
            mtxt_gorev.Mask = "LL????????????????????";//görevi
            mtxt_maas.Mask = "00009";//toplam gelir
            mtxt_yon.Mask = "LL????????????????????????????????????????";//önceki yöneticinin ad soy adı


            DateTime zaman = DateTime.Now;
            int yil = int.Parse(zaman.ToString("yyyy"));
            int ay = int.Parse(zaman.ToString("MM"));
            int gun = int.Parse(zaman.ToString("dd"));

            //giriş tarihi
            date_cikis.MinDate = new DateTime(1900, 1, 1);
            date_cikis.MaxDate = new DateTime(yil, ay, gun);

            //çıkış tarihi
            date_giris.MinDate = new DateTime(1900, 1, 1);
            date_giris.MaxDate = new DateTime(yil, ay, gun);

            cb_sebep.Items.Add("Ücret");
            cb_sebep.Items.Add("Okul");
            cb_sebep.Items.Add("Firma");
            cb_sebep.Items.Add("Görev");
            cb_sebep.Items.Add("Evlilik");
            cb_sebep.Items.Add("Taşınma");
            cb_sebep.Items.Add("Firma Lokasyonu");
        }
        private void ekrani_temizle()
        {

            mtxt_tc_no.Clear();
            m_txt_isad.Clear();
            mtxt_istel.Clear();
            mtxt_gorev.Clear();
            mtxt_maas.Clear();
            mtxt_yon.Clear();

            txt_pdks.Text = string.Empty;

            date_cikis.ResetText();
            date_giris.ResetText();

            cb_sebep.Text = string.Empty;

            label3.Text = string.Empty;
            label5.Text = string.Empty;

            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
            label8.ForeColor = Color.Black;
            label9.ForeColor = Color.Black;
            label10.ForeColor = Color.Black;
            label11.ForeColor = Color.Black;
            label12.ForeColor = Color.Black;
            label13.ForeColor = Color.Black;

        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            //tc kimlik no giriş kısmı için kısıtlamalar yazılacaktır.
            //yukarıda 11 den fazla giremeyeceğini belirtmştirk. bu ksımda da 11d den az giremeyeceğini belirttik.
            if (mtxt_tc_no.Text.Length < 11)
                dxErrorProvider1.SetError(mtxt_tc_no, "TC KİMLİK NO 11 KARAKTER OLMALIDIR.");
            else
                dxErrorProvider1.ClearErrors();
        }
        //ARA BUTONU
        private void simpleButton5_Click(object sender, EventArgs e)
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

                        }
                    }

                    label3.Text = kayitokuma.GetValue(2).ToString();//ilgili tck ait değerin veritabanındaki tck getirilecek. veri tabanı 0,1,2,.. diye gider.
                    label5.Text = kayitokuma.GetValue(3).ToString();

                    break;
                }
                //eğer kayıt okuma durumu gerçekleşmemiş ise kayıt bulunamadı ise
                if (kayit_arama_durumu == false)
                {
                    MessageBox.Show("Arama kayıtı bulunamadı", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                label1.ForeColor = Color.Black;

            }
            else
            {
                //girilen tc no 11karakter değilse
                MessageBox.Show("Lütfen 11 haneli tc giriniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            listele();
        }


        //forma ekle için veri tabanına ekliyoruz
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            
           
           // baglantim.baglanti().Open();
            SqlCommand selectsorgu = new SqlCommand("select * from Kisi_ozgecmis_isyeri where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.
      
                //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

                if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;

                //eğer iş yerinin adına herhangi bir veri girilirse diğerlerine de yazılmak zorunda olsun.
                if (m_txt_isad.Text != "" && m_txt_isad.Text.Length > 2)
                {
                   
                    if (mtxt_gorev.Text == "")
                        label8.ForeColor = Color.Red;
                    else
                        label8.ForeColor = Color.Black;

                    if (mtxt_maas.Text == "")
                        label9.ForeColor = Color.Red;
                    else
                        label9.ForeColor = Color.Black;

                    if (mtxt_yon.Text == "")
                        label10.ForeColor = Color.Red;
                    else
                        label10.ForeColor = Color.Black;

                    if (cb_sebep.Text == string.Empty)
                        label12.ForeColor = Color.Red;
                    else
                        label12.ForeColor = Color.Black;


                }
                else
                {
                    mtxt_istel.Enabled = false;
                    mtxt_gorev.Enabled = false;
                    mtxt_maas.Enabled = false;
                    mtxt_yon.Enabled = false;
                    date_cikis.Enabled = false;
                    date_giris.Enabled = false;
                    cb_sebep.Enabled = false;
                }


                if (mtxt_tc_no.Text.Length == 11 && m_txt_isad.Text.Length > 2)
                {
                    if ( mtxt_gorev.Text != string.Empty && mtxt_yon.Text != string.Empty && cb_sebep.Text != string.Empty)
                    {
                        try
                        {
                        //önce veri tabanına bağlanalım.

                        SqlCommand eklekomutu = new SqlCommand("Kaydet_Kisi_Ozgecmis", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@isyeri_adi", m_txt_isad.Text);
                        eklekomutu.Parameters.AddWithValue("@tel", mtxt_istel.Text);
                        eklekomutu.Parameters.AddWithValue("@gorev", mtxt_gorev.Text);
                        eklekomutu.Parameters.AddWithValue("@maaş", mtxt_maas.Text);
                        eklekomutu.Parameters.AddWithValue("@yon_adi", mtxt_yon.Text);
                        eklekomutu.Parameters.AddWithValue("@giris_tarihi", date_giris.Value);
                        eklekomutu.Parameters.AddWithValue("@cikis_tarihi", date_cikis.Value);
                        eklekomutu.Parameters.AddWithValue("@sebep", cb_sebep.Text);




                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir
                                                       
                                                         //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu,
                        listele();
                            MessageBox.Show("Kişinin özgeçmişine bilgiler başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

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
                else//herhangi bir hata ile karşılaşılır ise 
                {
                    MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçirniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            listele();
        }


        
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            ekrani_temizle();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
           
            m_txt_isad.Text = gridView1.GetFocusedRowCellValue("isyeri_adi").ToString();
            mtxt_istel.Text = gridView1.GetFocusedRowCellValue("tel").ToString();
            mtxt_gorev.Text = gridView1.GetFocusedRowCellValue("gorev").ToString();
            mtxt_maas.Text = gridView1.GetFocusedRowCellValue("maaş").ToString();
            mtxt_yon.Text = gridView1.GetFocusedRowCellValue("yon_adi").ToString();
            date_giris.Text = gridView1.GetFocusedRowCellValue("giris_tarihi").ToString();
            date_cikis.Text = gridView1.GetFocusedRowCellValue("cikis_tarihi").ToString();
            cb_sebep.Text = gridView1.GetFocusedRowCellValue("sebep").ToString();
            txt_id.Text = gridView1.GetFocusedRowCellValue("id").ToString();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
           
            SqlCommand selectsorgu = new SqlCommand("select * from Kisi_ozgecmis_isyeri where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            //eğer iş yerinin adına herhangi bir veri girilirse diğerlerine de yazılmak zorunda olsun.
            if (m_txt_isad.Text != "" && m_txt_isad.Text.Length > 2)
            {

                if (mtxt_gorev.Text == "")
                    label8.ForeColor = Color.Red;
                else
                    label8.ForeColor = Color.Black;

                if (mtxt_maas.Text == "")
                    label9.ForeColor = Color.Red;
                else
                    label9.ForeColor = Color.Black;

                if (mtxt_yon.Text == "")
                    label10.ForeColor = Color.Red;
                else
                    label10.ForeColor = Color.Black;

                if (cb_sebep.Text == string.Empty)
                    label12.ForeColor = Color.Red;
                else
                    label12.ForeColor = Color.Black;


            }
            else
            {
                mtxt_istel.Enabled = false;
                mtxt_gorev.Enabled = false;
                mtxt_maas.Enabled = false;
                mtxt_yon.Enabled = false;
                date_cikis.Enabled = false;
                date_giris.Enabled = false;
                cb_sebep.Enabled = false;
            }


            if (mtxt_tc_no.Text.Length == 11 && m_txt_isad.Text.Length > 2)
            {
                if (mtxt_gorev.Text != string.Empty && mtxt_maas.Text != string.Empty
                    && mtxt_yon.Text != string.Empty && cb_sebep.Text != string.Empty)
                {
                    try
                    {
                        //önce veri tabanına bağlanalım.

                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_Kisi_Ozgecmis", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@isyeri_adi", m_txt_isad.Text);
                        guncellekomutu.Parameters.AddWithValue("@tel", mtxt_istel.Text);
                        guncellekomutu.Parameters.AddWithValue("@gorev", mtxt_gorev.Text);
                        guncellekomutu.Parameters.AddWithValue("@maas", mtxt_maas.Text);
                        guncellekomutu.Parameters.AddWithValue("@yon_adi", mtxt_yon.Text);
                        guncellekomutu.Parameters.AddWithValue("@giris_tarihi", date_giris.Value);
                        guncellekomutu.Parameters.AddWithValue("@cikis_tarihi", date_cikis.Value);
                        guncellekomutu.Parameters.AddWithValue("@sebep", cb_sebep.Text);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id.Text);

                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir
                                                     
                                                     //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu,
                        listele();
                        MessageBox.Show("Kişinin özgeçmişine bilgiler başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

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
            else//herhangi bir hata ile karşılaşılır ise 
            {
                MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçirniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            listele();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11)

            {
                bool kayit_arama_durumu = false;
              
                SqlCommand secmeSorgusu = new SqlCommand("Select *from Kisi_ozgecmis_isyeri where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                while (kayitokuma.Read())
                {

                    //kayıt okuma gerçekleşti ise
                    kayit_arama_durumu = true;
                    SqlCommand silsorgusu = new SqlCommand("delete from Kisi_ozgecmis_isyeri where kisi_tc='" + mtxt_tc_no.Text +"'and id='"+txt_id.Text+ "'", baglantim.baglanti());
                    //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                    silsorgusu.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                   

                    ekrani_temizle();
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

        private void m_txt_isad_TextChanged(object sender, EventArgs e)
        {

            if (m_txt_isad.Text.Length > 2)
            {
                mtxt_istel.Enabled = true;
                mtxt_gorev.Enabled = true;
                mtxt_maas.Enabled = true;
                mtxt_yon.Enabled = true;
                date_giris.Enabled = true;
                date_cikis.Enabled = true;
                cb_sebep.Enabled = true;
            }
        }
    }
}
