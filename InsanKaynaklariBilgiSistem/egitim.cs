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
    public partial class egitim : Form
    {
        public egitim()
        {
            InitializeComponent();
        }

        sqlBaglantisi baglantim = new sqlBaglantisi();

        public void listele()
        {
            SqlCommand sorgu = new SqlCommand("Listele_Egitim_Bilgisi", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sorgu);
            sorgu.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;


            gridView1.Columns["kisi_tc"].Caption = "TC NO";
            gridView1.Columns["okul_adi"].Caption = "OKULUN ADI";
            gridView1.Columns["ogrenim_düzeyi"].Caption = "ÖĞRENİM DÜZEYİ";
            gridView1.Columns["bolum"].Caption = "BÖLÜM";
            gridView1.Columns["sinif"].Caption = "SINIF";
            gridView1.Columns["sehir_id"].Caption = "ŞEHİR";
            gridView1.Columns["giris_tarihi"].Caption = "GİRİŞ TARİHİ";
            gridView1.Columns["durum_bilgisi"].Caption = "EĞİTİM DURUMU";
            gridView1.Columns["mezuniyet_tarihi"].Caption = "MEZUNİYET TARİHİ";
            gridView1.Columns["derece"].Caption = "MEZUNİYET DERECESİ";
            

        }
        private void egitim_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;

            mtxt_tc_no.Mask = "00000000000";//kullnıcı 11 haneli tc numarası girebilecek.

            txt_okuladi.CharacterCasing = CharacterCasing.Upper;
            txt_bolum.CharacterCasing = CharacterCasing.Upper;
            txt_sehir.CharacterCasing = CharacterCasing.Upper;
            txt_derece.CharacterCasing = CharacterCasing.Upper;
          

            //öğrenim düzeyi
            cb_duzey.Items.Add("Ana Okulu");
            cb_duzey.Items.Add("İlkokul");
            cb_duzey.Items.Add("Ortaokul");
            cb_duzey.Items.Add("Lise");
            cb_duzey.Items.Add("Üniversite");
            cb_duzey.Items.Add("Yüksek Lisans");
            cb_duzey.Items.Add("Doktora");


            //sınıf bilgisi
            cb_sinif.Items.Add("Hazırlık");
            cb_sinif.Items.Add("1");
            cb_sinif.Items.Add("2");
            cb_sinif.Items.Add("3");
            cb_sinif.Items.Add("4");
            cb_sinif.Items.Add("5");
            cb_sinif.Items.Add("6");
            cb_sinif.Items.Add("Mezun");
            

            DateTime zaman = DateTime.Now;
            int yil = int.Parse(zaman.ToString("yyyy"));
            int ay = int.Parse(zaman.ToString("MM"));
            int gun = int.Parse(zaman.ToString("dd"));

            //okulagiriş tarihi
            date_giris.MinDate = new DateTime(1900, 1, 1);
            date_giris.MaxDate = new DateTime(yil, ay, gun+1);

            //mezuniyet tarihi
            date_mezun.MinDate = new DateTime(1900, 1, 1);
            

        }

        private void ekrani_temizle()
        {
            mtxt_tc_no.Clear();
            txt_okuladi.Text = string.Empty;
            txt_bolum.Text = string.Empty;
            txt_sehir.Text = string.Empty;
            txt_derece.Text = string.Empty;
            txt_pdks.Text = string.Empty;

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
            label14.ForeColor = Color.Black;

            label3.Text = string.Empty;
            label5.Text = string.Empty;

            cb_duzey.Text = string.Empty;
            cb_sinif.Text = string.Empty;

            date_giris.ResetText();
            date_mezun.ResetText();

            toggleSwitch1.Reset();
        }

        //tc karakter kontrolü
        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
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

        string mezuniyet_durumu= "Okuyor";
        //mezuniyet için
        private void toggleSwitch3_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch1.IsOn == true)
            {
               date_mezun.Enabled = true;
                mezuniyet_durumu = "Okuyor";
            }
            else
            {
                date_mezun.Enabled = false;
                mezuniyet_durumu = "Mezun";
            }
        }
      
        //ara butonu
        private void simpleButton5_Click(object sender, EventArgs e)
        {//tck yazılarak veri tablosundaki veri araştırılır
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
                   
                    break;
                }
                //eğer kayıt okuma durumu gerçekleşmemiş ise kayıt bulunamadı ise
                if (kayit_arama_durumu == false)
                {
                    MessageBox.Show("Kayıt bulunamadı", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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

        //forma ekle butonu 
        private void simpleButton6_Click(object sender, EventArgs e)
        {

           // baglantim.baglanti().Open();
            SqlCommand selectsorgu = new SqlCommand("select * from Kisi_Egitim_Bilgisi where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            //eğer okul adına herhangi bir veri girilirse diğerlerine de yazılmak zorunda olsun.
            if (txt_okuladi.Text != "" && txt_okuladi.Text.Length > 2)
            {
                if (cb_duzey.Text == string.Empty)
                    label13.ForeColor = Color.Red;
                else
                    label13.ForeColor = Color.Black;

                if (txt_bolum.Text == "")
                    label7.ForeColor = Color.Red;
                else
                    label7.ForeColor = Color.Black;


                if (cb_sinif.Text == string.Empty)
                    label14.ForeColor = Color.Red;
                else
                    label14.ForeColor = Color.Black;

                if (txt_sehir.Text == "")
                    label8.ForeColor = Color.Red;
                else
                    label8.ForeColor = Color.Black;



                if (toggleSwitch1.IsOn == true)
                { 
                    label10.ForeColor = Color.Red;
                    label11.ForeColor = Color.Red; 
                }
                else
                {
                    label10.ForeColor = Color.Black;
                    label11.ForeColor = Color.Black;
                }

            }
            else
            {
                txt_bolum.Enabled = false;
                txt_sehir.Enabled = false;
                txt_derece.Enabled = false;
                date_giris.Enabled = false;
                date_mezun.Enabled = false;
                cb_duzey.Enabled = false;
                cb_sinif.Enabled = false;
            }


            if (mtxt_tc_no.Text.Length == 11 && txt_okuladi.Text.Length > 2)
            {
                if (cb_duzey.Text == "Lise" || cb_duzey.Text == "Üniversite" || cb_duzey.Text == "Doktora" || cb_duzey.Text == "Yüksek Lisans")
                {

                    if (cb_duzey.Text != string.Empty && txt_bolum.Text != string.Empty && cb_sinif.Text != string.Empty)
                    {
                        try
                        {
                            SqlCommand eklekomutu = new SqlCommand("Kaydet_Egitim_Bilgisi", baglantim.baglanti());
                            eklekomutu.CommandType = CommandType.StoredProcedure;
                            eklekomutu.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                            eklekomutu.Parameters.AddWithValue("@okul_adi", txt_okuladi.Text);
                            eklekomutu.Parameters.AddWithValue("@ogrenim_düzeyi", cb_duzey.Text);
                            eklekomutu.Parameters.AddWithValue("@bolum", txt_bolum.Text);
                            eklekomutu.Parameters.AddWithValue("@sinif", cb_sinif.Text);
                            eklekomutu.Parameters.AddWithValue("@sehir_id", txt_sehir.Text);
                            eklekomutu.Parameters.AddWithValue("@giris_tarihi", date_giris.Value);
                            eklekomutu.Parameters.AddWithValue("@durum_bilgisi", mezuniyet_durumu);
                            eklekomutu.Parameters.AddWithValue("@mezuniyet_tarihi", date_mezun.Value);
                            eklekomutu.Parameters.AddWithValue("@derece", txt_derece.Text);


                            eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                            listele();
                            MessageBox.Show("Kişinin eğitim bilgisi başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                            // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

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
                    if (cb_duzey.Text != string.Empty )
                    {
                        try
                        {
                            SqlCommand eklekomutu = new SqlCommand("Kaydet_Egitim_Bilgisi", baglantim.baglanti());
                            eklekomutu.CommandType = CommandType.StoredProcedure;
                            eklekomutu.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                            eklekomutu.Parameters.AddWithValue("@okul_adi", txt_okuladi.Text);
                            eklekomutu.Parameters.AddWithValue("@ogrenim_düzeyi", cb_duzey.Text);
                            eklekomutu.Parameters.AddWithValue("@bolum", txt_bolum.Text);
                            eklekomutu.Parameters.AddWithValue("@sinif", cb_sinif.Text);
                            eklekomutu.Parameters.AddWithValue("@sehir_id", txt_sehir.Text);
                            eklekomutu.Parameters.AddWithValue("@giris_tarihi", date_giris.Value);
                            eklekomutu.Parameters.AddWithValue("@durum_bilgisi", mezuniyet_durumu);
                            eklekomutu.Parameters.AddWithValue("@mezuniyet_tarihi", date_mezun.Value);
                            eklekomutu.Parameters.AddWithValue("@derece", txt_derece.Text);


                            eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                            listele();
                            MessageBox.Show("Kişinin eğitim bilgisi başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                            // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                        }
                        catch (Exception hatamjs)
                        {
                            //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                            MessageBox.Show(hatamjs.Message);


                        }
                    }

                    
                }
            }
            else//herhangi bir hata ile karşılaşılır ise 
            {
                MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçirniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        //formu temizle
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            ekrani_temizle();
        }

        //ekranda kayıtların görünmesi
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            mtxt_tc_no.Text = gridView1.GetFocusedRowCellValue("kisi_tc").ToString();
            txt_okuladi.Text = gridView1.GetFocusedRowCellValue("okul_adi").ToString();
            cb_duzey.Text = gridView1.GetFocusedRowCellValue("ogrenim_düzeyi").ToString();
            txt_bolum.Text = gridView1.GetFocusedRowCellValue("bolum").ToString();
            cb_sinif.Text = gridView1.GetFocusedRowCellValue("sinif").ToString();
            txt_sehir.Text = gridView1.GetFocusedRowCellValue("sehir_id").ToString();
            date_giris.Value = Convert.ToDateTime(gridView1.GetFocusedRowCellValue("giris_tarihi"));
            mezuniyet_durumu = gridView1.GetFocusedRowCellValue("durum_bilgisi").ToString();

            if (mezuniyet_durumu == "Mezun")
            {
                toggleSwitch1.IsOn = true;
            }
            else
            {
                toggleSwitch1.IsOn = false;
            }
            date_mezun.Text = gridView1.GetFocusedRowCellValue("mezuniyet_tarihi").ToString();
            txt_derece.Text = gridView1.GetFocusedRowCellValue("derece").ToString();
            txt_id.Text = gridView1.GetFocusedRowCellValue("id").ToString();

        }

        //güncelleme işlemi
        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            // baglantim.baglanti().Open();
            SqlCommand selectsorgu = new SqlCommand("select * from Kisi_Egitim_Bilgisi where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            //eğer okul adına herhangi bir veri girilirse diğerlerine de yazılmak zorunda olsun.
            if (txt_okuladi.Text != "" && txt_okuladi.Text.Length > 2)
            {
                if (cb_duzey.Text == string.Empty)
                    label13.ForeColor = Color.Red;
                else
                    label13.ForeColor = Color.Black;

                if (txt_bolum.Text == "")
                    label7.ForeColor = Color.Red;
                else
                    label7.ForeColor = Color.Black;


                if (cb_sinif.Text == string.Empty)
                    label14.ForeColor = Color.Red;
                else
                    label14.ForeColor = Color.Black;

                if (txt_sehir.Text == "")
                    label8.ForeColor = Color.Red;
                else
                    label8.ForeColor = Color.Black;



                if (toggleSwitch1.IsOn == true)
                {
                    label10.ForeColor = Color.Red;
                    label11.ForeColor = Color.Red;
                }
                else
                {
                    label10.ForeColor = Color.Black;
                    label11.ForeColor = Color.Black;
                }

            }
            else
            {
                txt_bolum.Enabled = false;
                txt_sehir.Enabled = false;
                txt_derece.Enabled = false;
                date_giris.Enabled = false;
                date_mezun.Enabled = false;
                cb_duzey.Enabled = false;
                cb_sinif.Enabled = false;
            }


            if (mtxt_tc_no.Text.Length == 11 && txt_okuladi.Text.Length > 2)
            {
                if (cb_duzey.Text == "Lise" || cb_duzey.Text == "Üniversite" || cb_duzey.Text == "Doktora" || cb_duzey.Text == "Yüksek Lisans")
                {
                    if (cb_duzey.Text != string.Empty && txt_bolum.Text != string.Empty && cb_sinif.Text != string.Empty)
                    {
                        try
                        {
                            SqlCommand guncellekomutu = new SqlCommand("Guncelle_Egitim_Bilgisi", baglantim.baglanti());
                            guncellekomutu.CommandType = CommandType.StoredProcedure;

                            guncellekomutu.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                            guncellekomutu.Parameters.AddWithValue("@okul_adi", txt_okuladi.Text);
                            guncellekomutu.Parameters.AddWithValue("@ogrenim_düzeyi", cb_duzey.Text);
                            guncellekomutu.Parameters.AddWithValue("@bolum", txt_bolum.Text);
                            guncellekomutu.Parameters.AddWithValue("@sinif", cb_sinif.Text);
                            guncellekomutu.Parameters.AddWithValue("@sehir_id", txt_sehir.Text);
                            guncellekomutu.Parameters.AddWithValue("@giris_tarihi", date_giris.Value);
                            guncellekomutu.Parameters.AddWithValue("@durum_bilgisi", mezuniyet_durumu);
                            guncellekomutu.Parameters.AddWithValue("@mezuniyet_tarihi", date_mezun.Value);
                            guncellekomutu.Parameters.AddWithValue("@derece", txt_derece.Text);
                            guncellekomutu.Parameters.AddWithValue("@id", txt_id.Text);



                            guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir
                                                             // baglantim.baglanti().Close();
                                                             //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                            listele();
                            MessageBox.Show("Kişinin eğitim bilgisi başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                            // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

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
                    if (cb_duzey.Text != string.Empty)
                    {
                        try
                        {
                            SqlCommand guncellekomutu = new SqlCommand("Guncelle_Egitim_Bilgisi", baglantim.baglanti());
                            guncellekomutu.CommandType = CommandType.StoredProcedure;

                            guncellekomutu.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                            guncellekomutu.Parameters.AddWithValue("@okul_adi", txt_okuladi.Text);
                            guncellekomutu.Parameters.AddWithValue("@ogrenim_düzeyi", cb_duzey.Text);
                            guncellekomutu.Parameters.AddWithValue("@bolum", txt_bolum.Text);
                            guncellekomutu.Parameters.AddWithValue("@sinif", cb_sinif.Text);
                            guncellekomutu.Parameters.AddWithValue("@sehir_id", txt_sehir.Text);
                            guncellekomutu.Parameters.AddWithValue("@giris_tarihi", date_giris.Value);
                            guncellekomutu.Parameters.AddWithValue("@durum_bilgisi", mezuniyet_durumu);
                            guncellekomutu.Parameters.AddWithValue("@mezuniyet_tarihi", date_mezun.Value);
                            guncellekomutu.Parameters.AddWithValue("@derece", txt_derece.Text);
                            guncellekomutu.Parameters.AddWithValue("@id", txt_id.Text);



                            guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir
                                                             // baglantim.baglanti().Close();
                                                             //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                            listele();
                            MessageBox.Show("Kişinin eğitim bilgisi başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                            // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                        }
                        catch (Exception hatamjs)
                        {
                            //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                            MessageBox.Show(hatamjs.Message);


                        }
                    }
                }
            }
            else//herhangi bir hata ile karşılaşılır ise 
            {
                MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçirniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

       
        //ilgili kaydın silinme işlemi
        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11)

            {
                bool kayit_arama_durumu = false;

                SqlCommand secmeSorgusu = new SqlCommand("Select *from Kisi_Egitim_Bilgisi where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                while (kayitokuma.Read())
                {

                    //kayıt okuma gerçekleşti ise
                    kayit_arama_durumu = true;
                    SqlCommand silsorgusu = new SqlCommand("delete from Kisi_Egitim_Bilgisi where kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_id.Text + "'", baglantim.baglanti());
                    //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                    silsorgusu.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  

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

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch1.IsOn == true) //MEZUN
            {
                date_mezun.Enabled = true;
                mezuniyet_durumu = "Mezun";
                panel1.Visible = true;
            }
            else
            {
                date_mezun.Enabled = false;
                mezuniyet_durumu = "okuyor";
                panel1.Visible = false;
            }
        }

        private void txt_okuladi_TextChanged(object sender, EventArgs e)
        {
            if (txt_okuladi.Text.Length > 2)
            {
                txt_bolum.Enabled = true;
                txt_sehir.Enabled = true;
                txt_derece.Enabled = true;
                date_giris.Enabled = true;
                date_mezun.Enabled = true;
                cb_duzey.Enabled = true;
                cb_sinif.Enabled = true;
            }
        }
    }
}
