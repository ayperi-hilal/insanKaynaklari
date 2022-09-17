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
using AForge.Video;
using AForge.Video.DirectShow;


namespace InsanKaynaklariBilgiSistem
{
    public partial class genelBilgiler : Form
    {
        public genelBilgiler()
        {
            InitializeComponent();
        }

        string resimAdresi;

        string cinsiyet = "";
        string oncekisoyadi = "";
        string calismaDurumu = "Çalışıyor.";
        DateTime? cikisTarihi = null;
        //veri tabanı doaya yoluve provider nesnesinin belirlenmesi
        sqlBaglantisi baglantim = new sqlBaglantisi();

        //RESİM YÜKLEME       
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK) //resim seçme işlemi başarılı bir şekilde gerçekleştirildi mi onu kontrol edelim
            {
                resim.Image = System.Drawing.Image.FromFile(openFileDialog2.FileName);

                textBox3.Text = openFileDialog2.FileName.ToString();
                resimAdresi = openFileDialog2.FileName.ToString();
            }
        }

        private FilterInfoCollection webcam;
        private VideoCaptureDevice cam;

        public void resim_goruntule()
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT resim FROM Kisi WHERE TC = '" + tc_no.Text + "'", baglantim.baglanti()));

                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count == 1)
                {
                    Byte[] data = new Byte[0];
                    data = (Byte[])(dataSet.Tables[0].Rows[0]["resim"]);        // tablodaki coloum ismi
                    MemoryStream mem = new MemoryStream(data);
                    resim.Image = Image.FromStream(mem);

                    MessageBox.Show("Okuma Başarılı");
                }
                else
                {
                    resim.Image = null;
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

        public void listele_Kisi()
        {
            SqlCommand sorgu_Kisi = new SqlCommand("select * from Kisi", baglantim.baglanti());
            // sorgu_Kisi.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter dak = new SqlDataAdapter(sorgu_Kisi);
            DataTable dtk = new DataTable();
            dak.Fill(dtk);
            gridControl1.DataSource = dtk;
            gridView1.Columns["id"].Visible = false;

            gridView1.Columns["TC"].Caption = "TC NO";
            gridView1.Columns["ad"].Caption = "ADI";
            gridView1.Columns["soyad"].Caption = "SOYADI";
            gridView1.Columns["uyruk"].Caption = "UYRUK";
            gridView1.Columns["cinsiyet"].Caption = "CİNSİYET";
            gridView1.Columns["medeni_hal"].Caption = "MEDENİ HAL";
            gridView1.Columns["dogum_Tarihi"].Caption = "DOĞUM TARİHİ";
            gridView1.Columns["dogum_Yeri"].Caption = "DOĞUM YERİ";
            gridView1.Columns["onceki_soyadi"].Caption = "ÖNCEKİ SOYADI";
            gridView1.Columns["ana_Adi_Soyadi"].Caption = "ANNE ADI";

            gridView1.Columns["baba_Adi_Soyadi"].Caption = "BABA ADI";
            gridView1.Columns["meslekID"].Caption = "MESLEK KODU";
            gridView1.Columns["gorevi"].Caption = "GÖREVİ";
            gridView1.Columns["gorev_Yeri"].Caption = "GÖREV YERİ";
            gridView1.Columns["giris_Tarihi"].Caption = "İŞE GİRİŞ TARİHİ";
            gridView1.Columns["Aktif"].Caption = "DURUMU";
            gridView1.Columns["resim"].Visible = false;
            gridView1.Columns["cikis_Tarihi"].Caption = "İŞTEN ÇIKIŞ TARİHİ";
            gridView1.Columns["pdks"].Caption = "PDKS";



            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;


        }

        private void genelBilgiler_Load(object sender, EventArgs e)
        {
            openFileDialog2.Title = "Personele ait resmi seçiniz";

            openFileDialog2.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            cikis_tarihi.Visible = false;

            resim.SizeMode = PictureBoxSizeMode.StretchImage;
            resim.Height = 100;
            resim.Width = 100;
            resim.BorderStyle = BorderStyle.Fixed3D;


            tc_no.Mask = "00000000000";//kullnıcı 11 haneli tc numarası girebilecek.



            txt_uyruk.CharacterCasing = CharacterCasing.Upper;
            txt_ad.CharacterCasing = CharacterCasing.Upper;
            txt_soyad.CharacterCasing = CharacterCasing.Upper;
            txt_anneadi.CharacterCasing = CharacterCasing.Upper;
            txt_baba_adi.CharacterCasing = CharacterCasing.Upper;
            txt_dogumyeri.CharacterCasing = CharacterCasing.Upper;
            txt_o_soyadi.CharacterCasing = CharacterCasing.Upper;


            //medeni hal kısmı
            medeni_hal.Items.Add("Bekar");
            medeni_hal.Items.Add("Evli");
            medeni_hal.Items.Add("Boşanmış");


            //cb_gorevi.CharacterCasing = CharacterCasing.Upper;
            //cb_gorev_yeri.CharacterCasing = CharacterCasing.Upper;

            ////meslek kodu
            //SqlCommand cmd0 = new SqlCommand("select * from meslekKodu", baglantim.baglanti());
            //SqlDataReader dr0 = cmd0.ExecuteReader();
            //while (dr0.Read())
            //{
            //    comboBox2.Items.Add(dr0[1].ToString() + "-" + dr0[2].ToString());
            //}


            //meslek kodu
            SqlCommand cmd = new SqlCommand("select * from meslek_kodlari", baglantim.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox_meslek_kodu.Items.Add(dr[1].ToString() + "-" + dr[2].ToString());
            }

            //görevi sekmesi
            SqlCommand cmdgorevi = new SqlCommand("select * from gorev", baglantim.baglanti());
            SqlDataReader drgorevi = cmdgorevi.ExecuteReader();
            while (drgorevi.Read())
            {
                cb_gorevi.Items.Add(drgorevi[1].ToString());
            }



            //göreviyeri sekmesi
            SqlCommand cmdgorevyeri = new SqlCommand("select * from deparman", baglantim.baglanti());
            SqlDataReader drgorevyeri = cmdgorevyeri.ExecuteReader();
            while (drgorevyeri.Read())
            {
                cb_gorev_yeri.Items.Add(drgorevyeri[1].ToString());
            }




            DateTime zaman = DateTime.Now;
            int yil = int.Parse(zaman.ToString("yyyy"));
            int ay = int.Parse(zaman.ToString("MM"));
            int gun = int.Parse(zaman.ToString("dd"));

            //doğum tarihi
            dogum_tarihi.MinDate = new DateTime(1900, 1, 1);
            dogum_tarihi.MaxDate = new DateTime(yil - 18, ay, gun);//18 yaşından küçükler çalışamaz!!!

            //işe giriş tarihi
            giris_tarihi.MinDate = new DateTime(1900, 1, 1);
            giris_tarihi.MaxDate = new DateTime(yil, 12, 31);

            //işten çıkış tarihi
            cikis_tarihi.MinDate = new DateTime(1900, 1, 1);
            cikis_tarihi.MaxDate = new DateTime(yil, ay, gun);

            listele_Kisi();

            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo videocapturedevice in webcam)
            {
                comboBox1.Items.Add(videocapturedevice.Name);
            }
            comboBox1.SelectedIndex = 0;

        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            comboBox_meslek_kodu.Items.Clear();
            cb_gorevi.Items.Clear();
            cb_gorev_yeri.Items.Clear();

            //meslek kodu
            SqlCommand cmd = new SqlCommand("select * from meslek_kodlari", baglantim.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox_meslek_kodu.Items.Add(dr[1].ToString() + "-" + dr[2].ToString());
            }

            //görevi sekmesi
            SqlCommand cmdgorevi = new SqlCommand("select * from gorev", baglantim.baglanti());
            SqlDataReader drgorevi = cmdgorevi.ExecuteReader();
            while (drgorevi.Read())
            {
                cb_gorevi.Items.Add(drgorevi[1].ToString());
            }



            //göreviyeri sekmesi
            SqlCommand cmdgorevyeri = new SqlCommand("select * from deparman", baglantim.baglanti());
            SqlDataReader drgorevyeri = cmdgorevyeri.ExecuteReader();
            while (drgorevyeri.Read())
            {
                cb_gorev_yeri.Items.Add(drgorevyeri[1].ToString());
            }

        }

        private void ekrani_temizle()
        {
            resim.Image = null;
            pictureBox1.Image = null;

            tc_no.Clear();


            medeni_hal.Text = string.Empty;
            cb_gorevi.Text = string.Empty;
            cb_gorev_yeri.Text = string.Empty;
            comboBox_meslek_kodu.Text = string.Empty;
            txt_pdks.Text = string.Empty;
            txt_uyruk.Text = string.Empty;
            txt_ad.Text = string.Empty;
            txt_soyad.Text = string.Empty;
            txt_dogumyeri.Text = string.Empty;
            txt_anneadi.Text = string.Empty;
            txt_baba_adi.Text = string.Empty;
            txt_o_soyadi.Text = string.Empty;


            dogum_tarihi.ResetText();
            giris_tarihi.ResetText();
            cikis_tarihi.ResetText();

            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
            label8.ForeColor = Color.Black;
            label9.ForeColor = Color.Black;
            label10.ForeColor = Color.Black;
            label11.ForeColor = Color.Black;
            label12.ForeColor = Color.Black;
            label13.ForeColor = Color.Black;
            label14.ForeColor = Color.Black;
            label15.ForeColor = Color.Black;
            label21.ForeColor = Color.Black;
            label23.ForeColor = Color.Black;



            toggleSwitch1.Reset();



        }
        //tc karakter kontrolü
        private void tc_no_TextChanged(object sender, EventArgs e)
        {
            //tc kimlik no giriş kısmı için kısıtlamalar yazılacaktır.
            //yukarıda 11 den fazla giremeyeceğini belirtmştirk. bu ksımda da 11d den az giremeyeceğini belirttik.
            if (tc_no.Text.Length < 11)
                dxErrorProvider1.SetError(tc_no, "TC KİMLİK NO 11 KARAKTER OLMALIDIR.");
            else
                dxErrorProvider1.ClearErrors();

            bool kayit_arama_durumu = false;

            if (tc_no.Text.Length == 11)
            {

                SqlCommand selectsorgu = new SqlCommand("kisi_arama", baglantim.baglanti());
                selectsorgu.CommandType = CommandType.StoredProcedure;

                selectsorgu.Parameters.AddWithValue("@TC", tc_no.Text);
                selectsorgu.Parameters.AddWithValue("@pdks", "");


                SqlDataReader kayitokuma = selectsorgu.ExecuteReader();
                //kayıtokumanın içerisne attığımız değişkenin while döngüsü ile tüm veri tabanında arayalım.
                while (kayitokuma.Read())
                {
                    //kayıt var ise buradan true dönecek.
                    kayit_arama_durumu = true;

                    if (tc_no.Text != "")
                        txt_pdks.Text = kayitokuma.GetValue(19).ToString();
                    else if (txt_pdks.Text != "")
                        tc_no.Text = kayitokuma.GetValue(1).ToString();
                    else if (tc_no.Text != "" && txt_pdks.Text != "")
                    {
                        SqlCommand selectsorguiki = new SqlCommand("select *from Kisi where TC='" + tc_no.Text + "'", baglantim.baglanti());
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


                    txt_uyruk.Text = kayitokuma.GetValue(4).ToString();//uyruk
                                                                       //cinsiyet verisini çekelim.
                    if (kayitokuma.GetValue(5).ToString() == "Bayan")
                    {
                        radioButton_bayan.Checked = true;
                        radioButton_bay.Checked = false;
                    }
                    else if (kayitokuma.GetValue(5).ToString() == "Bay")
                    {
                        radioButton_bay.Checked = true;
                        radioButton_bayan.Checked = false;
                    }

                    medeni_hal.Text = kayitokuma.GetValue(6).ToString();//medeni hal
                    txt_ad.Text = kayitokuma.GetValue(2).ToString();//ad
                    txt_soyad.Text = kayitokuma.GetValue(3).ToString();//soyad
                    txt_uyruk.Text = kayitokuma.GetValue(4).ToString();//meslek kodu

                    if (kayitokuma.GetDateTime(7) > dogum_tarihi.MaxDate)
                    { MessageBox.Show("Tarih kaydı alınırken hata oluştu.Doğum tarihini güncelleyiniz.Başarısız olunuz ise yöneticiye başvurunuz"); }
                    else
                    {
                        dogum_tarihi.Value = kayitokuma.GetDateTime(7);//doğum tarihi
                    }
                    txt_dogumyeri.Text = kayitokuma.GetValue(8).ToString();//doğum yeri
                    txt_anneadi.Text = kayitokuma.GetValue(10).ToString();//anne adı
                    txt_baba_adi.Text = kayitokuma.GetValue(11).ToString();//baba adı
                    txt_o_soyadi.Text = kayitokuma.GetValue(9).ToString();//önceki soy adı
                    comboBox_meslek_kodu.Text = kayitokuma.GetValue(12).ToString();//meslek kodu
                    cb_gorevi.Text = kayitokuma.GetValue(13).ToString();//görevi
                    cb_gorev_yeri.Text = kayitokuma.GetValue(14).ToString();//görev yeri
                    giris_tarihi.Value = kayitokuma.GetDateTime(15);//giriş tarihi
                                                                    //iş durumu
                    if (kayitokuma.GetValue(16).ToString() == "Çalışıyor.")
                        toggleSwitch1.IsOn = false;
                    else
                        toggleSwitch1.IsOn = true;

                    if (kayitokuma.GetValue(16).ToString() == "Çalışıyor.")
                    {
                        // cikis_tarihi.Value = DateTime.MinValue;
                        cikis_tarihi.Enabled = false;
                    }
                    else
                        cikis_tarihi.Value = kayitokuma.GetDateTime(18);//işten çıkış tarihi


                    //resmi çekelim
                    resim_goruntule();

                    break;
                }
                //eğer kayıt okuma durumu gerçekleşmemiş ise kayıt bulunamadı ise
                if (kayit_arama_durumu == false)
                {
                    MessageBox.Show("Arama kayıtı bulunamadı", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                    medeni_hal.Text = string.Empty;
                    cb_gorevi.Text = string.Empty;
                    cb_gorev_yeri.Text = string.Empty;
                    comboBox_meslek_kodu.Text = string.Empty;
                    txt_pdks.Text = string.Empty;
                    txt_uyruk.Text = string.Empty;
                    txt_ad.Text = string.Empty;
                    txt_soyad.Text = string.Empty;
                    txt_dogumyeri.Text = string.Empty;
                    txt_anneadi.Text = string.Empty;
                    txt_baba_adi.Text = string.Empty;
                    txt_o_soyadi.Text = string.Empty;


                    dogum_tarihi.ResetText();
                    giris_tarihi.ResetText();
                    cikis_tarihi.ResetText();

                    label1.ForeColor = Color.Black;
                    label2.ForeColor = Color.Black;
                    label3.ForeColor = Color.Black;
                    label4.ForeColor = Color.Black;
                    label5.ForeColor = Color.Black;
                    label6.ForeColor = Color.Black;
                    label7.ForeColor = Color.Black;
                    label8.ForeColor = Color.Black;
                    label9.ForeColor = Color.Black;
                    label10.ForeColor = Color.Black;
                    label11.ForeColor = Color.Black;
                    label12.ForeColor = Color.Black;
                    label13.ForeColor = Color.Black;
                    label14.ForeColor = Color.Black;
                    label15.ForeColor = Color.Black;
                    label21.ForeColor = Color.Black;
                    label23.ForeColor = Color.Black;



                    toggleSwitch1.Reset();
                }
                //baglantim.baglanti().Close();
            }


        }

        //kaydet butonu
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            bool kayitkontrol = false;//bir kayıt yaparken daha önceden böyle bir kullanıcı var mı diye kontrolü yapılacak
            //baglantim.baglanti().Open();
            SqlCommand selectsorgu = new SqlCommand("select * from Kisi where TC='" + tc_no.Text + "'", baglantim.baglanti());

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

                if (tc_no.Text.Length < 11 || tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;

                //uyruk bilgisi girilmelidir.
                if (txt_uyruk.Text == "")
                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;

                //cinsiyet

                if (radioButton_bay.Checked == true)
                    cinsiyet = "Bay";
                else if (radioButton_bayan.Checked == true)
                    cinsiyet = "Bayan";



                //medeni hal seçilmelidir.
                if (medeni_hal.Text == "")
                    label2.ForeColor = Color.Red;
                else
                    label2.ForeColor = Color.Black;

                //ad girilmeli
                if (txt_ad.Text == "" && txt_ad.Text.Length < 2)
                    label11.ForeColor = Color.Red;
                else
                    label11.ForeColor = Color.Black;


                //soyad girilmeli
                if (txt_soyad.Text == "" && txt_soyad.Text.Length < 2)
                    label12.ForeColor = Color.Red;
                else
                    label12.ForeColor = Color.Black;

                //doğu yeri girilmeli
                if (txt_dogumyeri.Text == "")
                    label23.ForeColor = Color.Red;
                else
                    label23.ForeColor = Color.Black;

                //anne adı 
                if (txt_anneadi.Text == "")
                    label3.ForeColor = Color.Red;
                else
                    label3.ForeColor = Color.Black;

                // baba adı
                if (txt_baba_adi.Text == "")
                    label4.ForeColor = Color.Red;
                else
                    label4.ForeColor = Color.Black;

                //önceki soy adı
                if (txt_o_soyadi.Text != "")
                    oncekisoyadi = txt_o_soyadi.Text;
                else
                    oncekisoyadi = "";
                //meslek kodu
                if (comboBox_meslek_kodu.Text == "")
                    label15.ForeColor = Color.Red;
                else
                    label15.ForeColor = Color.Black;

                //görevi
                if (cb_gorevi.Text == "")
                    label6.ForeColor = Color.Red;
                else
                    label6.ForeColor = Color.Black;

                //görev yeri
                if (cb_gorev_yeri.Text == "")
                    label9.ForeColor = Color.Red;
                else
                    label9.ForeColor = Color.Black;



                //çalıma durmu  açıklama yazılmalıdır               
                if (toggleSwitch1.IsOn == false)
                {

                    calismaDurumu = "Çalışıyor.";
                    cikis_tarihi.Enabled = false;


                }

                else
                {
                    calismaDurumu = "İşten Ayrıldı.";
                    cikis_tarihi.Enabled = true;
                    cikisTarihi = cikis_tarihi.Value;

                }

                if (tc_no.Text.Length == 11 && txt_uyruk.Text != "" && medeni_hal.Text != "" && txt_ad.Text != "" && txt_soyad.Text != ""
                    && txt_dogumyeri.Text != "" && txt_anneadi.Text != "" && txt_baba_adi.Text != "" && txt_o_soyadi.Text != "" && comboBox_meslek_kodu.Text != "" &&
                    cb_gorevi.Text != "" && cb_gorev_yeri.Text != "" && resim.Image != null)
                {



                    FileStream fsResim = new FileStream(resimAdresi, FileMode.Open, FileAccess.Read);

                    BinaryReader brResim = new BinaryReader(fsResim);

                    byte[] resim = brResim.ReadBytes((int)fsResim.Length);

                    brResim.Close();
                    fsResim.Close();


                    SqlCommand cmdResimKaydet = new SqlCommand("insert into Kisi(TC,ad,soyad,uyruk,cinsiyet,medeni_hal,dogum_Tarihi,dogum_Yeri,onceki_soyadi,ana_Adi_Soyadi,baba_Adi_Soyadi,meslekID,gorevi,gorev_Yeri,giris_Tarihi,Aktif,resim,cikis_Tarihi,pdks) values (@TC,@ad,@soyad,@uyruk,@cinsiyet,@medeni_hal,@dogum_Tarihi,@dogum_Yeri,@onceki_soyadi,@ana_Adi_Soyadi,@baba_Adi_Soyadi,@meslekID,@gorevi,@gorev_Yeri,@giris_Tarihi,@Aktif,@resim,@cikis_Tarihi,@pdks)", baglantim.baglanti());
                    cmdResimKaydet.Parameters.Add("@TC", SqlDbType.NVarChar, 11).Value = tc_no.Text;
                    cmdResimKaydet.Parameters.Add("@ad", SqlDbType.NVarChar, 50).Value = txt_ad.Text;
                    cmdResimKaydet.Parameters.Add("@soyad", SqlDbType.NVarChar, 50).Value = txt_soyad.Text;
                    cmdResimKaydet.Parameters.Add("@uyruk", SqlDbType.NVarChar, 50).Value = txt_uyruk.Text;
                    cmdResimKaydet.Parameters.Add("@cinsiyet", SqlDbType.NVarChar, 5).Value = cinsiyet;
                    cmdResimKaydet.Parameters.Add("@medeni_hal", SqlDbType.NVarChar, 50).Value = medeni_hal.Text;

                    cmdResimKaydet.Parameters.Add("@dogum_Tarihi", SqlDbType.DateTime).Value = dogum_tarihi.Value;
                    cmdResimKaydet.Parameters.Add("@dogum_Yeri", SqlDbType.NVarChar, 50).Value = txt_dogumyeri.Text;
                    cmdResimKaydet.Parameters.Add("@onceki_soyadi", SqlDbType.NVarChar, 50).Value = txt_o_soyadi.Text;
                    cmdResimKaydet.Parameters.Add("@ana_Adi_Soyadi", SqlDbType.NVarChar, 50).Value = txt_anneadi.Text;
                    cmdResimKaydet.Parameters.Add("@baba_Adi_Soyadi", SqlDbType.NVarChar, 50).Value = txt_baba_adi.Text;
                    cmdResimKaydet.Parameters.Add("@meslekID", SqlDbType.NVarChar, 50).Value = comboBox_meslek_kodu.Text;
                    cmdResimKaydet.Parameters.Add("@gorevi", SqlDbType.NVarChar, 50).Value = cb_gorevi.Text;
                    cmdResimKaydet.Parameters.Add("@gorev_Yeri", SqlDbType.NVarChar, 50).Value = cb_gorev_yeri.Text;

                    cmdResimKaydet.Parameters.Add("@giris_Tarihi", SqlDbType.DateTime).Value = giris_tarihi.Value;
                    cmdResimKaydet.Parameters.Add("@Aktif", SqlDbType.NVarChar, 50).Value = calismaDurumu;

                    cmdResimKaydet.Parameters.Add("@resim", SqlDbType.Image, resim.Length).Value = resim;

                    if (calismaDurumu == "İşten Ayrıldı.")
                    { cmdResimKaydet.Parameters.Add("@cikis_Tarihi", SqlDbType.DateTime).Value = cikis_tarihi.Value; }
                    else
                    { cmdResimKaydet.Parameters.Add("@cikis_Tarihi", SqlDbType.DateTime).Value = DBNull.Value; }

                    cmdResimKaydet.Parameters.Add("@pdks", SqlDbType.NVarChar, 50).Value = txt_pdks.Text;

                    try
                    {
                        cmdResimKaydet.ExecuteNonQuery();
                        MessageBox.Show(textBox3.Text + " Tabloya Basarili Bir Sekilde Kaydedildi.");

                        MessageBox.Show("Kişinin Temel Bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi
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
                MessageBox.Show("Bu TC kimlik numarasına ait bir kullanıcı mevcuttur.");
            }
        }

        //ara  kısmı
        private void btn_ara_Click(object sender, EventArgs e)
        {
            // tck yazılarak veri tablosundaki veri araştırılır
            bool kayit_arama_durumu = false;//kayıdın olup olmadığını değerlendirecektir.
            if (tc_no.Text.Length == 11 || txt_pdks.Text != "")
            {  //tck 11 hane olarak yazıldı ise arama yapılabilecek aksi taktirde arama yapmaya gerek yok zaten.
                SqlCommand selectsorgu = new SqlCommand("kisi_arama", baglantim.baglanti());
                selectsorgu.CommandType = CommandType.StoredProcedure;

                selectsorgu.Parameters.AddWithValue("@TC", tc_no.Text);
                selectsorgu.Parameters.AddWithValue("@pdks", txt_pdks.Text);


                SqlDataReader kayitokuma = selectsorgu.ExecuteReader();
                //kayıtokumanın içerisne attığımız değişkenin while döngüsü ile tüm veri tabanında arayalım.
                while (kayitokuma.Read())
                {
                    //kayıt var ise buradan true dönecek.
                    kayit_arama_durumu = true;

                    if (tc_no.Text != "")
                        txt_pdks.Text = kayitokuma.GetValue(19).ToString();
                    else if (txt_pdks.Text != "")
                        tc_no.Text = kayitokuma.GetValue(1).ToString();
                    else if (tc_no.Text != "" && txt_pdks.Text != "")
                    {
                        SqlCommand selectsorguiki = new SqlCommand("select *from Kisi where TC='" + tc_no.Text + "'", baglantim.baglanti());
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


                    txt_uyruk.Text = kayitokuma.GetValue(4).ToString();//uyruk
                    
                    if (kayitokuma.GetValue(5).ToString() == "Bayan")
                    {
                        radioButton_bayan.Checked = true;
                        radioButton_bay.Checked = false;
                    }
                    else if (kayitokuma.GetValue(5).ToString() == "Bay")
                    {
                        radioButton_bay.Checked = true;
                        radioButton_bayan.Checked = false;
                    }
                    medeni_hal.Text = kayitokuma.GetValue(6).ToString();//medeni hal
                    txt_ad.Text = kayitokuma.GetValue(2).ToString();//ad
                    txt_soyad.Text = kayitokuma.GetValue(3).ToString();//soyad
                    txt_uyruk.Text = kayitokuma.GetValue(4).ToString();//meslek kodu

                    if (kayitokuma.GetDateTime(7) > dogum_tarihi.MaxDate)
                    { MessageBox.Show("Tarih kaydı alınırken hata oluştu.Doğum tarihini güncelleyiniz.Başarısız olunuz ise yöneticiye başvurunuz"); }
                    else
                    {
                        dogum_tarihi.Value = kayitokuma.GetDateTime(7);//doğum tarihi
                    }
                    txt_dogumyeri.Text = kayitokuma.GetValue(8).ToString();//doğum yeri
                    txt_anneadi.Text = kayitokuma.GetValue(10).ToString();//anne adı
                    txt_baba_adi.Text = kayitokuma.GetValue(11).ToString();//baba adı
                    txt_o_soyadi.Text = kayitokuma.GetValue(9).ToString();//önceki soy adı
                    comboBox_meslek_kodu.Text = kayitokuma.GetValue(12).ToString();//meslek kodu
                    cb_gorevi.Text = kayitokuma.GetValue(13).ToString();//görevi
                    cb_gorev_yeri.Text = kayitokuma.GetValue(14).ToString();//görev yeri
                    giris_tarihi.Value = kayitokuma.GetDateTime(15);//giriş tarihi
                    //iş durumu
                    if (kayitokuma.GetValue(16).ToString() == "Çalışıyor.")
                        toggleSwitch1.IsOn = false;
                    else
                        toggleSwitch1.IsOn = true;

                    if (kayitokuma.GetValue(16).ToString() == "Çalışıyor.")
                    {
                        // cikis_tarihi.Value = DateTime.MinValue;
                        cikis_tarihi.Enabled = false;
                    }
                    else
                        cikis_tarihi.Value = kayitokuma.GetDateTime(18);//işten çıkış tarihi


                    //resmi çekelim
                    resim_goruntule();

                    break;
                }
                //eğer kayıt okuma durumu gerçekleşmemiş ise kayıt bulunamadı ise
                if (kayit_arama_durumu == false)
                {
                    MessageBox.Show("Arama kayıtı bulunamadı", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ekrani_temizle();
                }
                //baglantim.baglanti().Close();
            }
            else
            {
                //girilen tc no 11karakter değilse
                MessageBox.Show("Lütfen 11 haneli tc giriniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ekrani_temizle();
            }
        }

        //güncelle butonu
        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (tc_no.Text.Length < 11 || tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            //uyruk bilgisi girilmelidir.
            if (txt_uyruk.Text == "")
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            //cinsiyet

            if (radioButton_bay.Checked == true)
                cinsiyet = "Bay";
            else if (radioButton_bayan.Checked == true)
                cinsiyet = "Bayan";

            //medeni hal seçilmelidir.
            if (medeni_hal.Text == "")
                label2.ForeColor = Color.Red;
            else
                label2.ForeColor = Color.Black;

            //ad girilmeli
            if (txt_ad.Text == "" && txt_ad.Text.Length < 2)
                label11.ForeColor = Color.Red;
            else
                label11.ForeColor = Color.Black;


            //soyad girilmeli
            if (txt_soyad.Text == "" && txt_soyad.Text.Length < 2)
                label12.ForeColor = Color.Red;
            else
                label12.ForeColor = Color.Black;

            //doğu yeri girilmeli
            if (txt_dogumyeri.Text == "")
                label23.ForeColor = Color.Red;
            else
                label23.ForeColor = Color.Black;

            //anne adı 
            if (txt_anneadi.Text == "")
                label3.ForeColor = Color.Red;
            else
                label3.ForeColor = Color.Black;

            // baba adı
            if (txt_baba_adi.Text == "")
                label4.ForeColor = Color.Red;
            else
                label4.ForeColor = Color.Black;

            //önceki soy adı
            if (txt_o_soyadi.Text != "")
                oncekisoyadi = txt_o_soyadi.Text;
            else
                oncekisoyadi = "";
            //meslek kodu
            if (comboBox_meslek_kodu.Text == "")
                label15.ForeColor = Color.Red;
            else
                label15.ForeColor = Color.Black;

            //görevi
            if (cb_gorevi.Text == "")
                label6.ForeColor = Color.Red;
            else
                label6.ForeColor = Color.Black;

            //görev yeri
            if (cb_gorev_yeri.Text == "")
                label9.ForeColor = Color.Red;
            else
                label9.ForeColor = Color.Black;



            //çalıma durmu  açıklama yazılmalıdır               
            if (toggleSwitch1.IsOn == false)
            {

                calismaDurumu = "Çalışıyor.";
                cikis_tarihi.Enabled = false;


            }

            else
            {
                calismaDurumu = "İşten Ayrıldı.";
                cikis_tarihi.Enabled = true;
                cikis_tarihi.Visible = true;
                cikisTarihi = cikis_tarihi.Value;

            }


            if (tc_no.Text.Length == 11 && txt_uyruk.Text != "" && medeni_hal.Text != "" && txt_ad.Text != "" && txt_soyad.Text != ""
                    && txt_dogumyeri.Text != "" && txt_anneadi.Text != "" && txt_baba_adi.Text != "" && txt_o_soyadi.Text != "" && comboBox_meslek_kodu.Text != "" &&
                    cb_gorevi.Text != "" && cb_gorev_yeri.Text != "" && resim.Image != null)
            {


                try
                {
                    FileStream fsResim = new FileStream(resimAdresi, FileMode.Open, FileAccess.Read);

                    BinaryReader brResim = new BinaryReader(fsResim);

                    byte[] resim = brResim.ReadBytes((int)fsResim.Length);

                    brResim.Close();
                    fsResim.Close();

                    SqlCommand guncellekomutu = new SqlCommand("update Kisi set TC=@TC,pdks=@pdks, ad=@ad, soyad=@soyad, uyruk=@uyruk, cinsiyet=@cinsiyet, medeni_hal=@medeni_hal, dogum_Tarihi=@dogum_Tarihi, dogum_Yeri=@dogum_Yeri, onceki_soyadi=@onceki_soyadi, ana_Adi_Soyadi=@ana_Adi_Soyadi, baba_Adi_Soyadi=@baba_Adi_Soyadi, meslekID=@meslekID, gorevi=@gorevi, gorev_Yeri=@gorev_Yeri, giris_Tarihi=@giris_Tarihi, Aktif=@Aktif, resim=@resim, cikis_Tarihi= @cikis_Tarihi where TC=@TC", baglantim.baglanti());


                    guncellekomutu.Parameters.Add("@TC", SqlDbType.NVarChar, 11).Value = tc_no.Text;
                    guncellekomutu.Parameters.Add("@pdks", SqlDbType.NVarChar, 50).Value = txt_pdks.Text;
                    guncellekomutu.Parameters.Add("@ad", SqlDbType.NVarChar, 50).Value = txt_ad.Text;
                    guncellekomutu.Parameters.Add("@soyad", SqlDbType.NVarChar, 50).Value = txt_soyad.Text;
                    guncellekomutu.Parameters.Add("@uyruk", SqlDbType.NVarChar, 50).Value = txt_uyruk.Text;
                    guncellekomutu.Parameters.Add("@cinsiyet", SqlDbType.NVarChar, 5).Value = cinsiyet;
                    guncellekomutu.Parameters.Add("@medeni_hal", SqlDbType.NVarChar, 50).Value = medeni_hal.Text;

                    guncellekomutu.Parameters.Add("@dogum_Tarihi", SqlDbType.DateTime).Value = dogum_tarihi.Value;
                    guncellekomutu.Parameters.Add("@dogum_Yeri", SqlDbType.NVarChar, 50).Value = txt_dogumyeri.Text;
                    guncellekomutu.Parameters.Add("@onceki_soyadi", SqlDbType.NVarChar, 50).Value = txt_o_soyadi.Text;
                    guncellekomutu.Parameters.Add("@ana_Adi_Soyadi", SqlDbType.NVarChar, 50).Value = txt_anneadi.Text;
                    guncellekomutu.Parameters.Add("@baba_Adi_Soyadi", SqlDbType.NVarChar, 50).Value = txt_baba_adi.Text;
                    guncellekomutu.Parameters.Add("@meslekID", SqlDbType.NVarChar, 50).Value = comboBox_meslek_kodu.Text;
                    guncellekomutu.Parameters.Add("@gorevi", SqlDbType.NVarChar, 50).Value = cb_gorevi.Text;
                    guncellekomutu.Parameters.Add("@gorev_Yeri", SqlDbType.NVarChar, 50).Value = cb_gorev_yeri.Text;

                    guncellekomutu.Parameters.Add("@giris_Tarihi", SqlDbType.DateTime).Value = giris_tarihi.Value;
                    guncellekomutu.Parameters.Add("@Aktif", SqlDbType.NVarChar, 50).Value = calismaDurumu;

                    guncellekomutu.Parameters.Add("@resim", SqlDbType.Image, resim.Length).Value = resim;
                    if (calismaDurumu == "İşten Ayrıldı.")
                    { guncellekomutu.Parameters.Add("@cikis_Tarihi", SqlDbType.DateTime).Value = cikis_tarihi.Value; }
                    else
                    { guncellekomutu.Parameters.Add("@cikis_Tarihi", SqlDbType.DateTime).Value = DBNull.Value; }




                    //SqlCommand guncellekomutu = new SqlCommand("update  Kisi set ad='" + maskedTextBox_ad.Text + "',soyad='" + maskedTextBox_soyad.Text + "',uyruk='"
                    //    + uyruk.Text + "',cinsiyet='" + cinsiyet + "',medeni_hal='" + medeni_hal.Text + "',dogum_Tarihi='" + dogum_tarihi.Value + "',dogum_Yeri='" + maskedTextBox_dogum_yeri.Text +
                    //    "',onceki_soyadi='" + maskedTextBox_o_soyadi.Text + "',ana_Adi_Soyadi='" + maskedTextBox_anneadi.Text + "',baba_Adi_Soyadi='" + maskedTextBox_baba_adi.Text +
                    //    "',meslekID='" + comboBox_meslek_kodu.Text + "',gorevi='" + comboBox_gorevi.Text + "',gorev_Yeri='" + comboBox_gorev_yeri.Text + "',giris_Tarihi='" + giris_tarihi.Value +
                    //    "',Aktif='" + calismaDurumu + "',resim='" + "',cikis_Tarihi='" + cikis_tarihi.Value + "' where TC='" + tc_no.Text + "'", baglantim.baglanti());


                    guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir
                                                     //baglantim.baglanti().Close();
                                                     //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                    MessageBox.Show("Kişinin Temel Bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                    ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                }
                catch
                {
                    SqlCommand guncellekomutu = new SqlCommand("update Kisi set TC=@TC,pdks=@pdks, ad=@ad, soyad=@soyad, uyruk=@uyruk, cinsiyet=@cinsiyet, medeni_hal=@medeni_hal, dogum_Tarihi=@dogum_Tarihi, dogum_Yeri=@dogum_Yeri, onceki_soyadi=@onceki_soyadi, ana_Adi_Soyadi=@ana_Adi_Soyadi, baba_Adi_Soyadi=@baba_Adi_Soyadi, meslekID=@meslekID, gorevi=@gorevi, gorev_Yeri=@gorev_Yeri, giris_Tarihi=@giris_Tarihi, Aktif=@Aktif, cikis_Tarihi= @cikis_Tarihi where TC=@TC", baglantim.baglanti());

                    guncellekomutu.Parameters.Add("@pdks", SqlDbType.NVarChar, 50).Value = txt_pdks.Text;
                    guncellekomutu.Parameters.Add("@TC", SqlDbType.NVarChar, 11).Value = tc_no.Text;
                    guncellekomutu.Parameters.Add("@ad", SqlDbType.NVarChar, 50).Value = txt_ad.Text;
                    guncellekomutu.Parameters.Add("@soyad", SqlDbType.NVarChar, 50).Value = txt_soyad.Text;
                    guncellekomutu.Parameters.Add("@uyruk", SqlDbType.NVarChar, 50).Value = txt_uyruk.Text;
                    guncellekomutu.Parameters.Add("@cinsiyet", SqlDbType.NVarChar, 5).Value = cinsiyet;
                    guncellekomutu.Parameters.Add("@medeni_hal", SqlDbType.NVarChar, 50).Value = medeni_hal.Text;

                    guncellekomutu.Parameters.Add("@dogum_Tarihi", SqlDbType.DateTime).Value = dogum_tarihi.Value;
                    guncellekomutu.Parameters.Add("@dogum_Yeri", SqlDbType.NVarChar, 50).Value = txt_dogumyeri.Text;
                    guncellekomutu.Parameters.Add("@onceki_soyadi", SqlDbType.NVarChar, 50).Value = txt_o_soyadi.Text;
                    guncellekomutu.Parameters.Add("@ana_Adi_Soyadi", SqlDbType.NVarChar, 50).Value = txt_anneadi.Text;
                    guncellekomutu.Parameters.Add("@baba_Adi_Soyadi", SqlDbType.NVarChar, 50).Value = txt_baba_adi.Text;
                    guncellekomutu.Parameters.Add("@meslekID", SqlDbType.NVarChar, 50).Value = comboBox_meslek_kodu.Text;
                    guncellekomutu.Parameters.Add("@gorevi", SqlDbType.NVarChar, 50).Value = cb_gorevi.Text;
                    guncellekomutu.Parameters.Add("@gorev_Yeri", SqlDbType.NVarChar, 50).Value = cb_gorev_yeri.Text;

                    guncellekomutu.Parameters.Add("@giris_Tarihi", SqlDbType.DateTime).Value = giris_tarihi.Value;
                    guncellekomutu.Parameters.Add("@Aktif", SqlDbType.NVarChar, 50).Value = calismaDurumu;



                    if (calismaDurumu == "İşten Ayrıldı.")
                    { guncellekomutu.Parameters.Add("@cikis_Tarihi", SqlDbType.DateTime).Value = cikis_tarihi.Value; }
                    else
                    { guncellekomutu.Parameters.Add("@cikis_Tarihi", SqlDbType.DateTime).Value = DBNull.Value; }


                    guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir
                                                     //baglantim.baglanti().Close();
                                                     //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                    MessageBox.Show("Kişinin Temel Bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                    ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

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

        //formu temizle
        private void btn_formu_temizle_Click(object sender, EventArgs e)
        {
            ekrani_temizle();
        }

        //sil butonu
        private void btn_sil_Click(object sender, EventArgs e)
        {

            if (tc_no.Text.Length == 11)

            {
                bool kayit_arama_durumu = false;
                baglantim.baglanti().Open();
                SqlCommand secmeSorgusu = new SqlCommand("Select *from Kisi where tcno='" + tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                while (kayitokuma.Read())
                {

                    //kayıt okuma gerçekleşti ise
                    kayit_arama_durumu = true;
                    SqlCommand silsorgusu = new SqlCommand("delete *from Kisi where tcno='" + tc_no.Text + "'", baglantim.baglanti());
                    //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                    silsorgusu.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    baglantim.baglanti().Close();

                    ekrani_temizle();
                    break;
                }
                //girilen tck ya göre bir kayıt bulunmaz ise
                if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                {
                    MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                baglantim.baglanti().Close();
                ekrani_temizle();


            }
            else
            {
                MessageBox.Show("tc kimlik no 11 haneli girilmelidir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void tc_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch1.IsOn == true)
            {
                cikis_tarihi.Visible = true;
                cikis_tarihi.Enabled = true;
            }
            else
            {
                cikis_tarihi.Visible = false;
                cikis_tarihi.Enabled = false;
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

        private void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bit;
        }


        private void genelBilgiler_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cam != null)
            {
                if (cam.IsRunning)
                {
                    cam.Stop();
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {//Kamerayı Aç
            cam = new VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            cam.Start();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {//Resim Çek
            resim.Image = pictureBox1.Image;
            Bitmap bmpkucuk = new Bitmap(pictureBox1.Image);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {//Farklı            Kaydet
            SaveFileDialog swf = new SaveFileDialog();
            swf.Filter = "(*.jpg)|*.jpg";
            DialogResult dialog = swf.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                resim.Image.Save(swf.FileName);
            }

            if (cam.IsRunning)
            {
                cam.Stop();
            }
        }


    }
}