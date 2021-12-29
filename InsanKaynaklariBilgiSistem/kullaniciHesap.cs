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
    public partial class kullaniciHesap : Form
    {
        public kullaniciHesap()
        {
            InitializeComponent();
        }
        //veri tabanı doaya yoluve provider nesnesinin belirlenmesi
        sqlBaglantisi baglantim = new sqlBaglantisi();

        //OleDbConnection baglantim = new OleDbConnection(dbclass.con);
        //OleDbConnection baglantim = new OleDbConnection("Provider = Microsoft.Ace.OleDb.12.0; Data Source = personel.accdb");

        //birden fazla yerde aynı kod blokları kullanıcağı için metodlar tanımlanıp kullanılacaktır.
        private void kullanicileri_goster()
        {
            //bu metod veri tabanındaki kullanıcıları yeni kullanıcı ekleme güncelleme silmede peronel listesini datagritview de görmeyi sağlayacak.
            try
            {
                
                SqlDataAdapter kullanicileri_listele = new SqlDataAdapter
                   //select tcno As[TC KİMLİK NO] DATAGRİTVİEW DE nasıl gözükmesini istiyoruz değişkenlerin yapar.
                   ("select  tc_no AS[TC KİMLİK NO],ad AS[ADI],soyad AS[SOYADI],yetki AS[YETKİ],kullanici_Adi AS[KULLANICI ADI]," +
                    "parola AS[PAROLA] from hesap_olustur Order By ad ASC", baglantim.baglanti());//neyi nasıl neye göresıralayacağımızı yazdık

                DataSet dshafiza = new DataSet();
                kullanicileri_listele.Fill(dshafiza);
                dataGridView2.DataSource = dshafiza.Tables[0];
               
            }
            catch (Exception hatamsj)
            {//try kısmındaki sorguda herhangi bir hata oluştuğunda hata verilecek olan mesaj bu kısımda belirtilmektedir.
                MessageBox.Show(hatamsj.Message, "Optimak insan Kaynakları Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // throw;
            }
        }


        private void kullaniciHesap_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Height = 100;
            pictureBox1.Width = 100;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;


            textBox1.MaxLength = 11;//maksimum karakter sayısı
            textBox4.MaxLength = 8;//kullanıcı adını ilerleyen süreçlerde tc ye aşitleyebilirim
            toolTip1.SetToolTip(this.textBox1, "TC KİMLİK NO 11  KARAKTER OLMALI!"); //VERİ TÜRÜN BELİRLER VE UYARI VERİR.
            radioButton1.Checked = true;

            //textbaxların kontrollerini yapalım
           /* textBox2.CharacterCasing = CharacterCasing.Upper;//küçük harf dahi yazılsa metni büyük harfe çeviri.
            textBox3.CharacterCasing = CharacterCasing.Upper;//küçük harf dahi yazılsa metni büyük harfe çeviri.*/
            textBox5.MaxLength = 10;
            textBox6.MaxLength = 10;

            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            kullanicileri_goster();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
                //tc kimlik no giriş kısmı için kısıtlamalar yazılacaktır.
                //yukarıda 11 den fazla giremeyeceğini belirtmştirk. bu ksımda da 11d den az giremeyeceğini belirttik.
                if (textBox1.Text.Length < 11)
                    dxErrorProvider1.SetError(textBox1, "TC KİMLİK NO 11 KARAKTER OLMALIDIR.");
                else
                    dxErrorProvider1.ClearErrors();
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //işlem esnaında her bir karakterde bu durum çalışmaktadır. sayı ve silme dışında herhangi birşey yapmasını engelleyeceğiz.
            if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || ((int)e.KeyChar == 8))//asc karaktere çevirdil 48e eşit ve veya büyükse veya backspace tuşu kullnılır.

                e.Handled = false;//bu tuşlara basılırsa izin vereceğil
            else
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //yalnızca harf girilebilecek boşluk ve backspace tuşu kullnılabilecek
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

       private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //yalnızca harf girilebilecek boşluk ve backspace tuşu kullnılabilecek
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length != 8)
                //uzunluk 8 karakter değlse. çünkü 8 karakter istemiştik
                dxErrorProvider1.SetError(textBox4, "Kullanıcı adı 8 karakter olmalıdır.");
            else
                dxErrorProvider1.ClearErrors();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //kullanıcı adında özel karaktere izin vermek istemiyoruz.
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsDigit(e.KeyChar) == true)
                //eğer harfse char.IsLetter(e.KeyChar)==true
                e.Handled = false;
            else
                e.Handled = true;
        }

                        
        int parola_skoru = 0;

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //parola için istenilen koşulları bu kısımda beliteceğiz.
            //0 ile 100 arası bir skor oluşturacağız.

            string parola_seviyesi = "";//pazorlanı n zayıf güçlü ve çok güclü olduğunu tutacak değişkendir.

            //paolada küçük harf büyük harf sayı ve sembol kullanılsıistiyoruz bunun için değişkenler tanımlayacağız.

            int kucukharfskoru = 0, buyukharfskoru = 0, sayiskoru = 0, ozelkarakterskoru = 0;
            string sifre = textBox5.Text;

            //Regex kütüphanesini güvenli parola oluşturma işlemlerinde kullanıyoruz.
            //ingilizce karakterli baz alır bu nedenle şifre de türkçe karakterleri ingilizce karakterlere çevirmek gerekir.
            string duzeltilmis_sifre = "";
            duzeltilmis_sifre = sifre;
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('İ', 'I'); //yer değiştir anlamına gelir.böylece girilen türkçede olup ingilizcede olayan ları değiştiriyoru.
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ı', 'i');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ç', 'C');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ç', 'c');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ş', 'S');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ş', 's');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ğ', 'G');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ğ', 'g');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ü', 'U');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ü', 'u');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ö', 'O');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ö', 'o');
            //tüm türkçe karakterleri ingilizce karakterler ile er değiştirdik.


            if (sifre != duzeltilmis_sifre)
            {
                //şifre oluşturulurken tükçe karakter kullnılmış demekteir
                sifre = duzeltilmis_sifre;
                textBox5.Text = sifre;
                //bu kıısmdaki karakter dğeişimi kullanıcıya gösterilmş ve kullanıcıya uyarı verilmiştir.
                MessageBox.Show("paroladaki türkçe karakter ingilizce karakterlere dönüştürülmüştür");
                //BU KISIMDA KIRMIZI ÜNLEM KULLANABİLİRİZ TC KİMLİK NODA KULLANDIĞIMIZ GİBİ

            }
                //----------------------------------------------------------------------------------------------------------------------------------------------------------------
                //BİR KÜÇÜK HARF 10 PUAN İKİ VE ÜZERİ 20 PUAN OLACAKTIR.
                int az_karakter_sayisi = sifre.Length - Regex.Replace(sifre, "[a-z]", "").Length;
                //küçük harf sayısını bulduk
                 //küçük harf karakter sayısı=şifrenin uzunluğu-küçük harf olmayan halinin karakter sayısı
                                                                                                 //bu kısmda şifrede küçük harf var ise boş değer atıyoruz bir nevi siliyoruz


                kucukharfskoru = Math.Min(2, az_karakter_sayisi) * 10;//yani eğer az_karakter_sayısı ikiden küçükse yani bir ise o değeri 10 ile çarpıyurz.
                                                                      //eğer ki az_karakter_sayısı 2 den büyük ise bu sefer de 2 yi 10 ile çarpıyırz.

                //----------------------------------------------------------------------------------------------------------------------------------------------------------------

                //kullanılan büük harfler içinde skor bulma işlemi yapalım
                //BİR büyük HARF 10 PUAN İKİ VE ÜZERİ 20 PUAN OLACAKTIR.
                int AZ_karakter_sayisi = sifre.Length - Regex.Replace(sifre, "[A-Z]", "").Length;//BÜYÜK harf sayısını bulduk
                                                                                                 //küçük harf karakter sayısı=şifrenin uzunluğu-küçük harf olmayan halinin karakter sayısı
                                                                                                 //bu kısmda şifrede küçük harf var ise boş değer atıyoruz bir nevi siliyoruz


                buyukharfskoru = Math.Min(2, AZ_karakter_sayisi) * 10;//yani eğer az_karakter_sayısı ikiden küçükse yani bir ise o değeri 10 ile çarpıyurz.
                                                                      //eğer ki az_karakter_sayısı 2 den büyük ise bu sefer de 2 yi 10 ile çarpıyırz.

                //----------------------------------------------------------------------------------------------------------------------------------------------------------------


                //kullanılan büük harfler içinde skor bulma işlemi yapalım
                //BİR RAKAM 10 PUAN İKİ VE ÜZERİ 20 PUAN OLACAKTIR.
                int rakam_sayisi = sifre.Length - Regex.Replace(sifre, "[0-9]", "").Length;//rakam sayısını bulduk
                                                                                           //küçük harf karakter sayısı=şifrenin uzunluğu-küçük harf olmayan halinin karakter sayısı
                                                                                           //bu kısmda şifrede küçük harf var ise boş değer atıyoruz bir nevi siliyoruz


                sayiskoru = Math.Min(2, rakam_sayisi) * 10;//yani eğer az_karakter_sayısı ikiden küçükse yani bir ise o değeri 10 ile çarpıyurz.
                                                           //eğer ki az_karakter_sayısı 2 den büyük ise bu sefer de 2 yi 10 ile çarpıyırz.
                                                           //----------------------------------------------------------------------------------------------------------------------------------------------------------------

                //kullanılan büük harfler içinde skor bulma işlemi yapalım
                //BİR sembol 10 PUAN İKİ VE ÜZERİ 20 PUAN OLACAKTIR.
                int sembol_sayisi = sifre.Length - az_karakter_sayisi - AZ_karakter_sayisi - rakam_sayisi;//sembol sayısını bulduk

                ozelkarakterskoru = Math.Min(2, sembol_sayisi) * 10;//yani eğer az_karakter_sayısı ikiden küçükse yani bir ise o değeri 10 ile çarpıyurz.
                                                                    //eğer ki az_karakter_sayısı 2 den büyük ise bu sefer de 2 yi 10 ile çarpıyırz.


                parola_skoru = kucukharfskoru + buyukharfskoru + ozelkarakterskoru + sayiskoru;

                //80/100 olan güvenli şifre olacaktır.

                if (sifre.Length == 9)
                    parola_skoru += 10;
                else if (sifre.Length == 10)
                    parola_skoru += 20;

                //kullanıcını şifre oluşturuken 1 küçük 1 büyük 1 sayı ve 1 sembol girmsini isteyelim.uayaralım.

                if (kucukharfskoru == 0 || buyukharfskoru == 0 || ozelkarakterskoru == 0 || sayiskoru == 0)
                    label22.Text = "Büyük harf küçük harf küçük harf ve sembol mutlaka kullanmalısın.";

                //bu ksıımda adım adım kullanılan karakterlr için yeil tikli uyarı verelim.(yapılacak)
                //hata düzltildiğinde ilgili alanın temizlenmesi için
                if (kucukharfskoru != 0 && buyukharfskoru != 0 && sayiskoru != 0 && ozelkarakterskoru != 0)
                    //yani tüm alanlardan veri gibisi yapıldı ise
                    label22.Text = "";


                //parola puanı ile seviye ilişkilendirlecek. güclü çok güçlü gibi;
                if (parola_skoru < 70)
                    parola_seviyesi = "kabul edilemez";
                else if (parola_skoru == 70 || parola_skoru == 80)
                    parola_seviyesi = "güçlü";
                else if (parola_skoru == 90 || parola_skoru == 100)
                    parola_seviyesi = "çok güçlü";
                label18.Text = "%" + Convert.ToString(parola_skoru);
                label19.Text = parola_seviyesi;
                progressBar1.Value = parola_skoru;//progres barı daha önce 100 parçaya bölmüştük.



                //parola ile parola tekrarının birbirine uyması gerekmektedir.


            

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //parola ile parola tekrarının birbirine uyması gerekmektedir.
            if (textBox6.Text != textBox5.Text)
                dxErrorProvider1.SetError(textBox6, "Parola tekrarı eşleşmiyor");
            else
                dxErrorProvider1.ClearErrors();
        }

        //metoto yazaılım.
        //bu metot çağrıldığı yerde formdaki tüm textbaxların içerisin temizleyecektir.
        private void ekrani_temizle()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            txt_pdks.Text = string.Empty;
            pictureBox1.Image = null;

            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
            txt_pdks.Text = string.Empty;
        }

        public void resim_goruntule()
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT resim FROM Kisi WHERE TC = '" + textBox1.Text + "'", baglantim.baglanti()));

                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count == 1)
                {
                    Byte[] data = new Byte[0];
                    data = (Byte[])(dataSet.Tables[0].Rows[0]["resim"]);        // tablodaki coloum ismi
                    MemoryStream mem = new MemoryStream(data);
                    pictureBox1.Image = Image.FromStream(mem);

                    MessageBox.Show("Okuma Başarılı");
                }
                else
                {
                    pictureBox1.Image = null;
                    MessageBox.Show("Resim Yok!");
                }

            }
            catch (Exception se)
            {

                MessageBox.Show(se.Message);
            }
            finally
            {

            }

        }
        //simpleButton1=kaydet butonu
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //yetki belirleyelim.yeni kayıtın yetkisi kullanıcı mı yoksa kullanıcı mı bunu belirlemek için kullanılan değişkendir.
            string yetki = "";
            bool kayitkontrol = false;//bir kayıt yaparken daha önceden böyle bir kullanıcı var mı diye kontrolü yapılacak

            //veri tabanı bağlantısını açaçlım . bağlantıyı daha önce tanımlamıştık.
          
            SqlCommand selectsorgu = new SqlCommand("select * from hesap_olustur where tc_no='" + textBox1.Text + "'", baglantim.baglanti());

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
                 
                if (textBox1.Text.Length < 11 || textBox1.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;
                //bu ksıma bir tc algoritması gelecektir.

              /*  //ad kontrolü
                if (textBox2.Text.Length < 2 || textBox2.Text == "")//isim 2 den küçük olmamalıdr(en kısa isim "su"). veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                    label2.ForeColor = Color.Red;
                else
                    label2.ForeColor = Color.Black;


                //soyad kontrolü
                if (textBox3.Text.Length < 2 || textBox3.Text == "")//soyad 2 den küçük olmamalıdr(en kısa isim "su"). veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                    label3.ForeColor = Color.Red;
                else
                    label3.ForeColor = Color.Black;*/

                //kullanıcı adı kontrolü //bu kımsı direk tc numara ile aynı yapabiliriz de 
                if (textBox4.Text.Length != 8 || textBox4.Text == "")//isim 2 den küçük olmamalıdr(en kısa isim "su"). veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                    label5.ForeColor = Color.Red;
                else
                    label5.ForeColor = Color.Black;


                //parola veri kontrolü
                if (textBox5.Text == "" || parola_skoru < 70)//parola boş veya 70 ın altında ise uyarı verilecektir
                    label6.ForeColor = Color.Red;
                else
                    label6.ForeColor = Color.Black;


                //parola tekrar veri kontrolü
                if (textBox6.Text != textBox5.Text || textBox6.Text == "")//parola ile tekrarı uymaz ise veya boş ise
                    label7.ForeColor = Color.Red;
                else
                    label7.ForeColor = Color.Black;



                //verilerde herhangş bir hata olup olmadığını konrol edelim.
                //herhangi bir hata ile karşılaşılmaz ise
               /* if (textBox1.Text.Length == 11 && textBox1.Text != "" && textBox2.Text != "" && textBox2.Text.Length > 1 && textBox3.Text.Length > 1 && textBox3.Text != ""
                    && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox5.Text == textBox6.Text && parola_skoru >= 70)//eğer bu şartlar sağlanır ise*/
                if (textBox1.Text.Length == 11 && textBox1.Text != ""&& textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox5.Text == textBox6.Text && parola_skoru >= 70)//eğer bu şartlar sağlanır ise
                 {
               
                    if (radioButton1.Checked == true)//yönetici
                        yetki = "Yönetici";
                    else if (radioButton2.Checked == true)//kullanıcı yetkisine sahip ise
                        yetki = "Kullanıcı";
                    //tüm koşullar oluştuğunda kayıt işlemini yapalım
                    try
                    {
                      
                        SqlCommand eklekomutu = new SqlCommand("insert into hesap_olustur values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + yetki + "','" + textBox4.Text + "','" + textBox5.Text + "','" + "" + "')", baglantim.baglanti());

                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir
                        
                        //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                        MessageBox.Show("yeni kullanıcı veri tabanına başarılı bir şekilde kayıt edilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi


                    }
                    catch (Exception hatamjs)
                    {//kayıt esnasında herhangi bir hata ile karşılaşıldığında


                        MessageBox.Show(hatamjs.Message);
                        baglantim.baglanti().Close();
                    }
                }
                    else//herhangi bir hata ile karşılaşılır ise örneğin paola uyuşmaz ise vb.
                {
                    MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçirniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else
            {
                //aynı tc ye ait bir kayıt var ise
                MessageBox.Show("Girilen tc kimlik numarasına ait bir kayıt mevcuttur.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            kullanicileri_goster();

        }

            //simpleButton5 =ara butonu
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            pictureBox1.Image = null;

            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
            //tck yazılarak veri tablosundaki veri araştırılır
            bool kayit_arama_durumu = false;//kayıdın olup olmadığını değerlendirecektir.
            bool hesap_arama_durumu = false;
            if (textBox1.Text.Length == 11 || txt_pdks.Text != "")
            {//tck 11 hane olarak yazıldı ise arama yapılabilecek aksi taktirde arama yapmaya gek yok zaten.

                SqlCommand selectsorgu = new SqlCommand("kisi_arama", baglantim.baglanti());
                selectsorgu.CommandType = CommandType.StoredProcedure;

                selectsorgu.Parameters.AddWithValue("@TC", textBox1.Text);
                selectsorgu.Parameters.AddWithValue("@pdks", txt_pdks.Text); 


                SqlDataReader kayitokuma = selectsorgu.ExecuteReader();

                //kayıtokumanın içerisne attığımız değişkenin while döngüsü ile tüm veri tabanında arayalım.
                  while (kayitokuma.Read())
                    {
                        //kayıt var ise buradan true dönecek.
                        kayit_arama_durumu = true;

                        if (textBox1.Text != "")
                            txt_pdks.Text = kayitokuma.GetValue(19).ToString();
                        else if (txt_pdks.Text != "")
                            textBox1.Text = kayitokuma.GetValue(1).ToString();
                        else if (textBox1.Text != "" && txt_pdks.Text != "")
                        {
                            SqlCommand selectsorguiki = new SqlCommand("select *from Kisi where TC='" + textBox1.Text + "'", baglantim.baglanti());
                            SqlDataReader kayitokumaiki = selectsorguiki.ExecuteReader();


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


                        textBox2.Text = kayitokuma.GetValue(2).ToString();  //ad  ilgili tck ait değerin veritabanındaki tck getirilecek. veri tabanı 0,1,2,.. diye gider.
                        textBox3.Text = kayitokuma.GetValue(3).ToString(); //soyad




                        break;
                    }
                    if (kayit_arama_durumu == true)
                    {
                        resim_goruntule();
                        SqlCommand select_2_sorgu = new SqlCommand("select * from hesap_olustur where tc_no='" + textBox1.Text + "'", baglantim.baglanti());
                        SqlDataReader kayitokuma_2 = select_2_sorgu.ExecuteReader();
                        while (kayitokuma_2.Read())
                        {
                            hesap_arama_durumu = true;
                            if (kayitokuma_2.GetValue(4).ToString() == "Yönetici")
                                radioButton1.Checked = true;
                            else
                                radioButton2.Checked = true;

                            textBox5.Text = kayitokuma_2.GetValue(6).ToString();
                            textBox4.Text = kayitokuma_2.GetValue(5).ToString(); //kullanici adi

                            textBox6.Text = kayitokuma_2.GetValue(6).ToString();
                        }
                        if (hesap_arama_durumu == false)
                        {
                            MessageBox.Show("Kullanıcı mevcut fakat hesap kayıtı bulunamadı", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        
                    }
                   

                //eğer kayıt okuma durumu gerçekleşmemiş ise kayıt bulunamadı ise
                else if (kayit_arama_durumu == false)
               {
                    MessageBox.Show("Arama kayıtı bulunamadı", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

               }
                

            }
            else
            {
                //girilen tc no 11karakter değilse
                MessageBox.Show("Lütfen 11 haneli tc giriniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ekrani_temizle();
            }
           

        }


        //buraya kadar kayıt ve  arama işlemi yaptık. şimdi de aradığımız değeri güncelleyelim
        //güncelleme işlemi =simpleButton2


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //yetki belirleyelim.yeni kayıtın yetkisi kullanıcı mı yoksa kullanıcı mı bunu belirlemek için kullanılan değişkendir.
            string yetki = "";

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (textBox1.Text.Length < 11 || textBox1.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;
            //bu ksıma bir tc algoritması gelecektir.
            /*
            //ad kontrolü
            if (textBox2.Text.Length < 2 || textBox2.Text == "")//isim 2 den küçük olmamalıdr(en kısa isim "su"). veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label2.ForeColor = Color.Red;
            else
                label2.ForeColor = Color.Black;

                        //soyad kontrolü
                        if (textBox3.Text.Length < 2 || textBox3.Text == "")//soyad 2 den küçük olmamalıdr(en kısa isim "su"). veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                            label3.ForeColor = Color.Red;
                        else
                            label3.ForeColor = Color.Black;
                        */
            //kullanıcı adı kontrolü //bu kımsı direk tc numara ile aynı yapabiliriz de 
            if (textBox4.Text.Length != 8 || textBox4.Text == "")//isim 2 den küçük olmamalıdr(en kısa isim "su"). veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label5.ForeColor = Color.Red;
            else
                label5.ForeColor = Color.Black;

            //parola veri kontrolü
            if (textBox5.Text == "" || parola_skoru < 70)//parola boş veya 70 ın altında ise uyarı verilecektir
                label6.ForeColor = Color.Red;
            else
                label6.ForeColor = Color.Black;

            //parola tekrar veri kontrolü
            if (textBox6.Text != textBox5.Text || textBox6.Text == "")//parola ile tekrarı uymaz ise veya boş ise
                label7.ForeColor = Color.Red;
            else
                label5.ForeColor = Color.Black;

            //parola veri kontrolü
            if (textBox5.Text == "" || parola_skoru < 70)//parola boş veya 70 ın altında ise uyarı verilecektir
                label6.ForeColor = Color.Red;
            else
                label6.ForeColor = Color.Black;

            //parola tekrar veri kontrolü
            if (textBox6.Text != textBox5.Text || textBox6.Text == "")//parola ile tekrarı uymaz ise veya boş ise
                label7.ForeColor = Color.Red;
            else
                label7.ForeColor = Color.Black;
            //verilerde herhangş bir hata olup olmadığını konrol edelim.
            //herhangi bir hata ile karşılaşılmaz ise
            /*if (textBox1.Text.Length == 11 && textBox1.Text != "" && textBox2.Text != "" && textBox2.Text.Length > 1 && textBox3.Text.Length > 1 && textBox3.Text != ""
                && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox5.Text == textBox6.Text && parola_skoru >= 70)//eğer bu şartlar sağlanır ise*/
            if (textBox1.Text.Length == 11 && textBox1.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox5.Text == textBox6.Text && parola_skoru >= 70)//eğer bu şartlar sağlanır ise
            {
                if (radioButton1.Checked == true)//yönetici
                    yetki = "Yönetici";
                else if (radioButton2.Checked == true)//kullanıcı yetkisine sahip ise
                    yetki = "Kullanıcı";
                //tüm koşullar oluştuğunda kayıt işlemini yapalım
                try
                {
                    //önce veri tabanına bağlanalım.
                    // //baglantim.baglanti().Open();
                    SqlCommand guncellekomutu = new SqlCommand("update hesap_olustur set ad='" + textBox2.Text + "',soyad='" + textBox3.Text + "',yetki='" + yetki + "',kullanici_Adi='" + textBox4.Text + "',parola='" + textBox5.Text + "' where tc_no='" + textBox1.Text + "'", baglantim.baglanti());

                    guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir
                    //baglantim.baglanti().Close();
                    //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                    MessageBox.Show("kullanıcı verileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                    kullanicileri_goster();//güncellemeden sonra datagritwiev den kullanıcılar listelenir

        
        

        
    }
                catch (Exception hatamjs)
                {//kayıt esnasında herhangi bir hata ile karşılaşıldığında
                    MessageBox.Show(hatamjs.Message, "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //   //baglantim.baglanti().Close();
                }
            }
            else//herhangi bir hata ile karşılaşılır ise örneğin paola uyuşmaz ise vb.
            {
                MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçirniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        //buraya kadar kayıt ve  arama işlemi yaptık. şimdi de KAYIT SİLME İŞLEMİ YAPALIM=simpleButton3
        private void simpleButton3_Click(object sender, EventArgs e)

            {
            if (textBox1.Text.Length == 11)
            {
                bool kayit_arama_durumu = false;
                ////baglantim.baglanti().Open();
                SqlCommand secmeSorgusu = new SqlCommand("Select *from Kisi where TC='" + textBox1.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                while (kayitokuma.Read())
                {

                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from hesap_olustur where tc_no='" + textBox1.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak yani değişikliğin acseste oluşması sağlanacak
                        silsorgusu.ExecuteNonQuery();
                        MessageBox.Show("kullanıcı kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //baglantim.baglanti().Close();
                        kullanicileri_goster();//daha önce tanımlanan metot çağrılıyor. datagritview güncelleniyor.
                        ekrani_temizle();
                        break;
                }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır...", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    // //baglantim.baglanti().Close();
                    ekrani_temizle();
            }
                else
                {

                    MessageBox.Show("TC kimlik no 11 haneli girilmelidir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        //buraya kadar kayıt ve  arama işlemi yaptık. şimdi de formu temizle işlemi=simpleButton4
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            ekrani_temizle();
        }


    }

}
