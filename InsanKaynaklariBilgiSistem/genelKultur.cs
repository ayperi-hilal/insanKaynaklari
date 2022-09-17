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

using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InsanKaynaklariBilgiSistem
{
    public partial class genelKultur : Form
    {
        public genelKultur()
        {
            InitializeComponent();
        }
        sqlBaglantisi baglantim = new sqlBaglantisi();
        DataTable dtl = new DataTable();
        DataTable dth = new DataTable();
        DataTable dtb = new DataTable();
        DataTable dts = new DataTable();
        DataTable dtas = new DataTable();
        DataTable dtm = new DataTable();

        private void tum_yabanci_dil()
        {

            SqlCommand sorgu = new SqlCommand("tum_yabanci_dil", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sorgu);
            
            //DataTable dt = new DataTable();
            da.Fill(dtl);
            dataGridView1.DataSource = dtl;
            
        }
        private void tum_merasim()
        {

            SqlCommand sorgu = new SqlCommand("tum_Kisi_planli_merasim", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sorgu);

            //DataTable dt = new DataTable();
            da.Fill(dtm);
            dataGridView1.DataSource = dtm;

        }
        private void tum_hobi()
        {

            SqlCommand sorgu = new SqlCommand("tum_hobi", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sorgu);

            //DataTable dt = new DataTable();
            da.Fill(dth);
            dataGridView1.DataSource = dth;

        }
        private void tum_bilgisayar()
        {

            SqlCommand sorgu = new SqlCommand("tum_bilgisayar", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sorgu);

            //DataTable dt = new DataTable();
            da.Fill(dtb);
            dataGridView1.DataSource = dtb;

        }
        private void tum_sertifika()
        {

            SqlCommand sorgu = new SqlCommand("tum_sertifika", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sorgu);

            //DataTable dt = new DataTable();
            da.Fill(dts);
            dataGridView1.DataSource = dts;

        }
        private void tum_agir_sertifika()
        {

            SqlCommand sorgu = new SqlCommand("tum_agir_sertifika", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sorgu);

            //DataTable dt = new DataTable();
            da.Fill(dtas);
            dataGridView1.DataSource = dtas;

        }
      
        public void listele_yabanci_dil()//2
        {
            SqlCommand sorgu = new SqlCommand("Listele_Yabanci_Dil", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sorgu);
            sorgu.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl2.DataSource = dt;
            gridView2.Columns["id"].Visible = false;
            gridView2.Columns["pdks"].Visible = false;

            gridView2.Columns["kisi_tc"].Caption = "TC NO";
            gridView2.Columns["yabanci_dil"].Caption = "YABANCI DİL";
            gridView2.Columns["duzeyi"].Caption = "DÜZEY";
           

        }


        public void listele_merasim()//9
        {
            SqlCommand sorgu = new SqlCommand("Listele_merasim", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sorgu);
            sorgu.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl9.DataSource = dt;

            gridView9.Columns["id"].Visible = false;
            gridView9.Columns["pdks"].Visible = false;

            gridView9.Columns["kisi_tc"].Caption = "TC NO";
            gridView9.Columns["planli_merasim_adi"].Caption = "MERASİM";
            gridView9.Columns["planli_merasim_tarihi"].Caption = "TARİHİ";



        }



        public void listele_bilgisayar_bilgisi()//3
        {
            SqlCommand sorgu2 = new SqlCommand("Listele_Bilgisayar_Bilgisi", baglantim.baglanti());
            sorgu2.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da2 = new SqlDataAdapter(sorgu2);
            sorgu2.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            gridControl3.DataSource = dt2;
            gridView3.Columns["id"].Visible = false;
            gridView3.Columns["pdks"].Visible = false;

            gridView3.Columns["kisi_tc"].Caption = "TC NO";
            gridView3.Columns["program_ad"].Caption = "PROGRAM ADI";
            gridView3.Columns["duzey"].Caption = "DÜZEY";
            

        }
        public void listele_sertifika()//4
        {
            SqlCommand sorgu3 = new SqlCommand("Listele_Sertifika", baglantim.baglanti());
            sorgu3.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da3 = new SqlDataAdapter(sorgu3);
            sorgu3.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            gridControl4.DataSource = dt3;
            gridView4.Columns["id"].Visible = false;
         

            gridView4.Columns["kisi_tc"].Caption = "TC NO";
            gridView4.Columns["sertifika_adi"].Caption = "SERTİFİKA ADI";
            gridView4.Columns["aldigi_kurum"].Caption = "SERTİFİKANIN ALINDIĞI KURUM";
            gridView4.Columns["konu"].Caption = "SERTİFİKA KONUSU";
            gridView4.Columns["tarih"].Caption = "ALINIŞ TARİHİ";
            gridView4.Columns["bitis_tarihi"].Caption = "GEÇERLİLİK TARİHİ";
        }
        public void listele_hobi()//1
        {
            SqlCommand sorgu4 = new SqlCommand("Listele_Kisi_Hobi", baglantim.baglanti());
            sorgu4.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da4 = new SqlDataAdapter(sorgu4);
            sorgu4.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            gridControl1.DataSource = dt4;
            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["pdks"].Visible = false;

            gridView1.Columns["kisi_tc"].Caption = "TC NO";
            gridView1.Columns["kisi_hobileri"].Caption = "HOBİLER";

        }

        public void listele_sertifika_agir_is() //5
        {
            SqlCommand sorgu5 = new SqlCommand("Listele_Kisi_Sertifika_Agir_is", baglantim.baglanti());
            sorgu5.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da5 = new SqlDataAdapter(sorgu5);
            sorgu5.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);
            gridControl5.DataSource = dt5;
            gridView5.Columns["id"].Visible = false;
            

            gridView5.Columns["kisi_tc"].Caption = "TC NO";
            gridView5.Columns["agir_is_sertifika_adi"].Caption = "SERTİFİKA ADI";
            gridView5.Columns["alinis_tarihi"].Caption = "ALINIŞ TARİHİ";
            gridView5.Columns["bitis_tarihi"].Caption = "GEÇERLİLİK TARİHİ";
        }


        private void genelKultur_Load(object sender, EventArgs e)
        {  
            mtxt_tc_no.Mask = "00000000000";//kullnıcı 11 haneli tc numarası girebilecek.

            txt_agir.CharacterCasing = CharacterCasing.Upper;
            txt_pc.CharacterCasing = CharacterCasing.Upper;
            txt_sertf_ad.CharacterCasing = CharacterCasing.Upper;
            txt_sertf_konu.CharacterCasing = CharacterCasing.Upper;
            txt_sertf_kurum.CharacterCasing = CharacterCasing.Upper;
            txt_merasim.CharacterCasing = CharacterCasing.Upper;


            cb_pc_duzey.Items.Add("İyi");
            cb_pc_duzey.Items.Add("Orta");
            cb_pc_duzey.Items.Add("Çok iyi");

            cb_dil.Items.Add("İngilizce");
            cb_dil.Items.Add("Almanca");
            cb_dil.Items.Add("Fransızca");
            cb_dil.Items.Add("Arapça");

            cb_dil_duzey.Items.Add("İyi");
            cb_dil_duzey.Items.Add("Orta");
            cb_dil_duzey.Items.Add("Çok iyi");

            DateTime zaman = DateTime.Now;
            int yil = int.Parse(zaman.ToString("yyyy"));
            int ay = int.Parse(zaman.ToString("MM"));
            int gun = int.Parse(zaman.ToString("dd"));

            //sertifikanın alınış tarihi
            date_sertf_tarih.MinDate = new DateTime(1900, 1, 1);
            date_sertf_tarih.MaxDate = new DateTime(yil, ay, gun+1);

            //sertifikanın alınış tarihi
            date_sertf_agir.MinDate = new DateTime(1900, 1, 1);
            date_sertf_agir.MaxDate = new DateTime(yil, ay, gun+1);

            //Sertifikalrın geçerlilik tarihi
            date_bitis_tarih.MinDate = new DateTime(1900, 1, 1);
            date_sertf_agir_bitis.MinDate = new DateTime(1900, 1, 1);

            //merasim tarihi
            date_merasim.MinDate = new DateTime(yil, ay, gun);


            tum_agir_sertifika();
            tum_bilgisayar();
            tum_hobi();
            tum_sertifika();
            tum_yabanci_dil();
            tum_merasim();
        }
        private void ekrani_temizle()
        {
            txt_hobi_id.Text = string.Empty;
            txt_dil_id.Text = string.Empty;
            txt_bilgisayar_id.Text = string.Empty;
            txt_sertifika_id.Text = string.Empty;
            txt_agirsertifika_id.Text = string.Empty;
            txt_merasim_id.Text = string.Empty;

            mtxt_tc_no.Clear();
            txt_agir.Text = string.Empty;
            txt_pc.Text = string.Empty;
            txt_sertf_ad.Text = string.Empty;
            txt_sertf_konu.Text = string.Empty;
            txt_sertf_kurum.Text = string.Empty;
            txt_pdks.Text = string.Empty;
            txt_merasim.Text = string.Empty;

            label3.Text = string.Empty;
            label5.Text = string.Empty;

            chb_hobi.ClearSelected();

            for (int i = 0; i < chb_hobi.Items.Count; i++)
            {
                chb_hobi.SetItemChecked(i, false);
            }

            lbl_hobiler.Text = "";

            cb_pc_duzey.Text = string.Empty;
            cb_dil.Text = string.Empty;
            cb_dil_duzey.Text = string.Empty;

            date_sertf_tarih.ResetText();
            date_sertf_agir.ResetText();
            date_bitis_tarih.ResetText();
            date_merasim.ResetText();

            lbl_agir_tarih.ForeColor = Color.Black;
            lbl_ad.ForeColor = Color.Black;
            lbl_agir.ForeColor = Color.Black;
            lbl_dil.ForeColor = Color.Black;
            lbl_dil_duzey.ForeColor = Color.Black;
            lbl_hobi.ForeColor = Color.Black;
            lbl_pc.ForeColor = Color.Black;
            lbl_pc_duzey.ForeColor = Color.Black;
            lbl_sertf_ad.ForeColor = Color.Black;
            lbl_sertf_konu.ForeColor = Color.Black;
            lbl_sertf_kurum.ForeColor = Color.Black;
            lbl_sertf_tarih.ForeColor = Color.Black;
            lbl_soyad.ForeColor = Color.Black;
            lbl_tc.ForeColor = Color.Black;

        }

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

        string hobiler = "";

        public object CheckedListBox1 { get; private set; }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chb_hobi.CheckOnClick = true;
            if (chb_hobi.CheckedItems.Count > 0)
            {
                lbl_hobiler.Text = "";
                hobiler = "";
                foreach (string title in chb_hobi.CheckedItems)
                {
                    lbl_hobiler.Text += " " + title + ", ";
                    hobiler += " " + title + ", ";



                }
            }
            else
            {
                hobiler = "";
                lbl_hobiler.Text = "";
            }

        }


        //arama işlemi
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
                    MessageBox.Show("Arama kayıtı bulunamadı", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btn_guncelle.Enabled = false;
                    btn_sil.Enabled = false;
                    simpleButton6.Enabled = false;
                }
                else
                {
                    listele_bilgisayar_bilgisi();
                    listele_hobi();
                    listele_sertifika();
                    listele_sertifika_agir_is();
                    listele_yabanci_dil();
                    listele_merasim();

                    btn_guncelle.Enabled = true;
                    btn_sil.Enabled = true;
                    simpleButton6.Enabled = true;
                }
            }
            else
            {
                //girilen tc no 11karakter değilse
                MessageBox.Show("Lütfen 11 haneli tc giriniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ekrani_temizle();

                btn_guncelle.Enabled = false;
                btn_sil.Enabled = false;
                simpleButton6.Enabled = false;
            }




            /*

            foreach (CheckBox hobi in chb_hobi.Items)
            {
                string nvarchar; = Select * from Kisi_Hobi where tc= @tcno. 
                hobi.Checked = abc.IndexOf(hobi.Text) >= 0 ? true : false;
            }

            */
        }

        bool ho = false;
        bool yd = false; 
        bool bil = false;
        bool ser = false; 
        bool aser = false;
        bool mer = false;
        //forma ekleme
        private void simpleButton6_Click(object sender, EventArgs e)
        {

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                lbl_tc.ForeColor = Color.Red;
            else
                lbl_tc.ForeColor = Color.Black;


            //bu formda mutlaka seçim yapması gereken herhangi bir durum yoktur ama eğer ki herhangi bir giriş yapılacaksa
            //if yapısı ile tüm bölümler kontrol edilmelidir.

            //yabancı dili yoksa düzeyde giremesin
            if (cb_dil.Text != string.Empty)/*(1)*/
                cb_dil_duzey.Enabled = false;
            else
            {
                if (cb_dil.Text == string.Empty)
                    lbl_dil_duzey.ForeColor = Color.Red;
                else
                    lbl_dil_duzey.ForeColor = Color.Black;
            }


            //pc program için
            if (txt_pc.Text == "")
                cb_pc_duzey.Enabled = false;
            else
            {
                if (txt_pc.Text == "")
                    lbl_pc_duzey.ForeColor = Color.Red;
                else
                    lbl_pc_duzey.ForeColor = Color.Black;
            }


            //aldığı sertifikalar
            if (txt_sertf_ad.Text == "")
            {
                txt_sertf_kurum.Enabled = false;
                txt_sertf_konu.Enabled = false;
                date_sertf_tarih.Enabled = false;
            }
            else
            {
                if (txt_sertf_kurum.Text == "")
                    lbl_sertf_kurum.ForeColor = Color.Red;
                else
                    lbl_sertf_kurum.ForeColor = Color.Black;

                if (txt_sertf_konu.Text == "")
                    lbl_sertf_konu.ForeColor = Color.Red;
                else
                    lbl_sertf_konu.ForeColor = Color.Black;
                date_sertf_tarih.Enabled = true;


            }


            //ağır ve tehlikeli iş sertifikası
            if (txt_agir.Text == "")
                date_sertf_agir.Enabled = false;
            else
                date_sertf_agir.Enabled = true;


            //merasim bilgilerinin kontrol edilmesi
            if (txt_merasim.Text == "")
                date_merasim.Enabled = false;
            else
                date_merasim.Enabled = true;



            //şimdiye kadar alanların zorunlulukları belirlendi sıra geldi forma ekleme işlemine

            if (mtxt_tc_no.Text.Length == 11)
            {
                //hobi kısmı
                if (chb_hobi.CheckedItems.Count > 0) //eğer hobi kısmından seçimler yapılır ise
                {
                    try
                    {
                        SqlCommand eklekomutuhobi = new SqlCommand("Kaydet_Kisi_Hobi", baglantim.baglanti());
                        eklekomutuhobi.CommandType = CommandType.StoredProcedure;

                        eklekomutuhobi.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
                        eklekomutuhobi.Parameters.AddWithValue("@kisi_hobileri", hobiler);

                        eklekomutuhobi.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir
                        ho = true;
                        //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                      //  MessageBox.Show("Kişinin hobileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                else//herhangi bir hata ile karşılaşılır ise 
                {
                    //MessageBox.Show("Hobi kısmı ile ilgili beklenmedik bir hata oluştu.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


                //yabancı dil
                if (cb_dil.Text != string.Empty && cb_dil_duzey.Text != string.Empty) //eğer dil kısmı uygun yazılmışsa kaydetsin
                {
                    try
                    {
                        SqlCommand eklekomutudil = new SqlCommand("Kaydet_Kisi_Dil_Bilgisi", baglantim.baglanti());
                        eklekomutudil.CommandType = CommandType.StoredProcedure;

                        eklekomutudil.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
                        eklekomutudil.Parameters.AddWithValue("@yabanci_dil", cb_dil.Text);
                        eklekomutudil.Parameters.AddWithValue("@duzeyi", cb_dil_duzey.Text);

                        yd = true;
                        eklekomutudil.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                       // MessageBox.Show("Kişinin yabancı dil bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }


                //program ile ilgil bilgler
                if (txt_pc.Text != string.Empty && cb_pc_duzey.Text != string.Empty)
                {

                    try
                    {
                        SqlCommand eklekomutuBilgisayar = new SqlCommand("Kaydet_Kisi_Bilgisayar_Program_Bilgileri", baglantim.baglanti());
                        eklekomutuBilgisayar.CommandType = CommandType.StoredProcedure;

                        eklekomutuBilgisayar.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
                        eklekomutuBilgisayar.Parameters.AddWithValue("@program_ad", txt_pc.Text);
                        eklekomutuBilgisayar.Parameters.AddWithValue("@duzey", cb_pc_duzey.Text);
                        bil = true;
                        eklekomutuBilgisayar.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir
                        baglantim.baglanti().Close();
                        //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                       // MessageBox.Show("Kişinin bilgisayar bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                else//herhangi bir hata ile karşılaşılır ise 
                {
                    // MessageBox.Show("Bilgisayar programı kısmındaki rengi kırmızı olan alanları yeniden gözden geçiriniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                //sertifika ile ilgil bilgler
                if (txt_sertf_ad.Text != string.Empty && txt_sertf_kurum.Text != string.Empty && txt_sertf_konu.Text != string.Empty)
                {

                    try
                    {
                        SqlCommand eklekomutusertifika = new SqlCommand("Kaydet_Kisi_Sertifika_Bilgileri", baglantim.baglanti());
                        eklekomutusertifika.CommandType = CommandType.StoredProcedure;

                        eklekomutusertifika.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
                        eklekomutusertifika.Parameters.AddWithValue("@sertifika_adi", txt_sertf_ad.Text);
                        eklekomutusertifika.Parameters.AddWithValue("@aldigi_kurum", txt_sertf_kurum.Text);
                        eklekomutusertifika.Parameters.AddWithValue("@konu", txt_sertf_konu.Text);
                        eklekomutusertifika.Parameters.AddWithValue("@tarih", date_sertf_tarih.Value);
                        eklekomutusertifika.Parameters.AddWithValue("@bitis_tarihi", date_bitis_tarih.Value);
                        ser = true;

                        eklekomutusertifika.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                       // MessageBox.Show("Kişinin sertifika bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }


                //ağır ve tehlikeli iş sertifika ile ilgil bilgler
                if (txt_agir.Text != string.Empty)
                {

                    try
                    {
                        SqlCommand eklekomutuagir = new SqlCommand("Kaydet_Kisi_Sertifika_Agir_is", baglantim.baglanti());
                        eklekomutuagir.CommandType = CommandType.StoredProcedure;

                        eklekomutuagir.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
                        eklekomutuagir.Parameters.AddWithValue("@agir_is_sertifika_adi", txt_agir.Text);
                        eklekomutuagir.Parameters.AddWithValue("@alinis_tarihi", date_sertf_agir.Value);
                        eklekomutuagir.Parameters.AddWithValue("@bitis_tarihi", date_sertf_agir_bitis.Value);

                        aser = true;
                        eklekomutuagir.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                       // MessageBox.Show("Kişinin sertifika bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }


                //mersaim tarihleri

                //ağır ve tehlikeli iş sertifika ile ilgil bilgler
                if (txt_merasim.Text != string.Empty)
                {
                    try
                    {
                        SqlCommand eklekomutumerasim = new SqlCommand("Kaydet_Kisi_Merasim", baglantim.baglanti());
                        eklekomutumerasim.CommandType = CommandType.StoredProcedure;

                        eklekomutumerasim.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                        eklekomutumerasim.Parameters.AddWithValue("@planli_merasim_adi", txt_merasim.Text);
                        eklekomutumerasim.Parameters.AddWithValue("@planli_merasim_tarihi", date_merasim.Value);
                        mer = true;
                        eklekomutumerasim.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                      //  MessageBox.Show("Kişinin merasim bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
               
                if (ho==true|| bil == true || ser == true || aser == true || mer == true)
                {
                    MessageBox.Show("Kişinin bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    // ekrani_
                }
            }
            else
            {
                MessageBox.Show("Lütfen 11 haneli TC no veya geçerli bir pdks giriniz.");
            }
            listele_bilgisayar_bilgisi();
            listele_hobi();
            listele_sertifika();
            listele_sertifika_agir_is();
            listele_yabanci_dil();
            listele_merasim();
            ekrani_temizle();
        }

        //ekrandaki formu temizlemek için
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            ekrani_temizle();
        }

        private void btn_evrak_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11)
            {
                aktifKullanici.kisi = mtxt_tc_no.Text;
                string dosya_yolu = "C:\\Dosyalar\\" + mtxt_tc_no.Text;
                if (Directory.Exists(dosya_yolu))
                {
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


                            Directory.CreateDirectory(@"C://Dosyalar/" + mtxt_tc_no.Text + "/");
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
                MessageBox.Show("11 haneli TC kimlik numarasını eksiksiz bir şekilde giriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cb_dil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_dil.Text != string.Empty)
                cb_dil_duzey.Enabled = true;
            else
            {
                cb_dil_duzey.Enabled = false;
            }
        }

        private void txt_pc_TextChanged(object sender, EventArgs e)
        {
            if (txt_pc.Text == "")
            {
                cb_pc_duzey.Enabled = false;
            }
            else
            {
                cb_pc_duzey.Enabled = true;

            }
        }

        private void txt_sertf_ad_TextChanged(object sender, EventArgs e)
        {
            if (txt_sertf_ad.Text == "")
            {
                txt_sertf_kurum.Enabled = false;
                txt_sertf_konu.Enabled = false;
                date_sertf_tarih.Enabled = false;

                //lbl_sertf_tarih.Visible = false;
                date_sertf_tarih.Visible = false;
            }
            else
            {
                txt_sertf_kurum.Enabled = true;
                txt_sertf_konu.Enabled = true;
                date_sertf_tarih.Enabled = true;

                lbl_sertf_tarih.Visible = true;
                date_sertf_tarih.Visible = true;

            }
        }

        private void txt_merasim_TextChanged(object sender, EventArgs e)
        {
            if (txt_merasim.Text == "")
            {               
                date_merasim.Enabled = false;
                date_merasim.Visible = false;
            }
            else
            {
                date_merasim.Enabled = true;
                date_merasim.Visible = true;

            }
        }

        private void txt_agir_TextChanged(object sender, EventArgs e)
        {
            if (txt_agir.Text == "")
            {
                date_sertf_agir.Enabled = false;
                //lbl_agir_tarih.Visible= false;
                date_sertf_agir.Visible = false;
            }
            else
            {
                date_sertf_agir.Enabled = true;

                lbl_agir_tarih.Visible = true;
                date_sertf_agir.Visible = true;

            }
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            // kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                lbl_tc.ForeColor = Color.Red;
            else
                lbl_tc.ForeColor = Color.Black;


            //bu formda mutlaka seçim yapması gereken herhangi bir durum yoktur ama eğer ki herhangi bir giriş yapılacaksa
            //if yapısı ile tüm bölümler kontrol edilmelidir.

            //yabancı dili yoksa düzeyde giremesin
            if (cb_dil.Text != string.Empty)/*1*/
                cb_dil_duzey.Enabled = false;
            else
            {
                if (cb_dil.Text == string.Empty)
                    lbl_dil_duzey.ForeColor = Color.Red;
                else
                    lbl_dil_duzey.ForeColor = Color.Black;
            }


            //pc program için
            if (txt_pc.Text == "")
                cb_pc_duzey.Enabled = false;
            else
            {
                if (txt_pc.Text == "")
                    lbl_pc_duzey.ForeColor = Color.Red;
                else
                    lbl_pc_duzey.ForeColor = Color.Black;
            }


            //aldığı sertifikalar
            if (txt_sertf_ad.Text == "")
            {
                txt_sertf_kurum.Enabled = false;
                txt_sertf_konu.Enabled = false;
                date_sertf_tarih.Enabled = false;
            }
            else
            {
                if (txt_sertf_kurum.Text == "")
                    lbl_sertf_kurum.ForeColor = Color.Red;
                else
                    lbl_sertf_kurum.ForeColor = Color.Black;

                if (txt_sertf_konu.Text == "")
                    lbl_sertf_konu.ForeColor = Color.Red;
                else
                    lbl_sertf_konu.ForeColor = Color.Black;
                date_sertf_tarih.Enabled = true;


            }


            //ağır ve tehlikeli iş sertifikası
            if (txt_agir.Text == "")
                date_sertf_agir.Enabled = false;
            else
                date_sertf_agir.Enabled = true;


            //şimdiye kadar alanların zorunlulukları belirlendi sıra geldi forma ekleme işlemine

            if (mtxt_tc_no.Text.Length == 11)
            {
                //hobi kısmı
                if (chb_hobi.CheckedItems.Count > 0) //eğer hobi kısmından seçimler yapılır ise
                {
                    try
                    {
                        SqlCommand guncellekomutuhobi = new SqlCommand("Guncelle_Kisi_Hobi", baglantim.baglanti());
                        guncellekomutuhobi.CommandType = CommandType.StoredProcedure;

                        guncellekomutuhobi.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
                        guncellekomutuhobi.Parameters.AddWithValue("@kisi_hobileri", hobiler);
                        guncellekomutuhobi.Parameters.AddWithValue("@id", txt_hobi_id.Text);

                        guncellekomutuhobi.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                        MessageBox.Show("Kişinin hobileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }



                //yabancı dil
                if (cb_dil.Text != string.Empty && cb_dil_duzey.Text != string.Empty) //eğer dil kısmı uygun yazılmışsa kaydetsin
                {
                    try
                    {

                        SqlCommand guncellekomutudil = new SqlCommand("Guncelle_Kisi_Dil_Bilgisi", baglantim.baglanti());
                        guncellekomutudil.CommandType = CommandType.StoredProcedure;

                        guncellekomutudil.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
                        guncellekomutudil.Parameters.AddWithValue("@yabanci_dil", cb_dil.Text);
                        guncellekomutudil.Parameters.AddWithValue("@duzeyi", cb_dil_duzey.Text);
                        guncellekomutudil.Parameters.AddWithValue("@id", txt_dil_id.Text);

                        guncellekomutudil.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                        MessageBox.Show("Kişinin dil bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }


                //program ile ilgil bilgler
                if (txt_pc.Text != string.Empty && cb_pc_duzey.Text != string.Empty)
                {

                    try
                    {

                        SqlCommand guncellekomutuBilgisayar = new SqlCommand("Guncelle_Kisi_Bilgisayar_Program_Bilgileri", baglantim.baglanti());
                        guncellekomutuBilgisayar.CommandType = CommandType.StoredProcedure;

                        guncellekomutuBilgisayar.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
                        guncellekomutuBilgisayar.Parameters.AddWithValue("@program_ad", txt_pc.Text);
                        guncellekomutuBilgisayar.Parameters.AddWithValue("@duzey", cb_pc_duzey.Text);
                        guncellekomutuBilgisayar.Parameters.AddWithValue("@id", txt_bilgisayar_id.Text);

                        guncellekomutuBilgisayar.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                        MessageBox.Show("Kişinin bilgisayar bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }


                //sertifika ile ilgil bilgler
                if (txt_sertf_ad.Text != string.Empty && txt_sertf_kurum.Text != string.Empty && txt_sertf_konu.Text != string.Empty)
                {

                    try
                    {

                        SqlCommand guncellekomutusertifika = new SqlCommand("Guncelle_Kisi_Sertifika_Bilgileri", baglantim.baglanti());
                        guncellekomutusertifika.CommandType = CommandType.StoredProcedure;

                        guncellekomutusertifika.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
                        guncellekomutusertifika.Parameters.AddWithValue("@sertifika_adi", txt_sertf_ad.Text);
                        guncellekomutusertifika.Parameters.AddWithValue("@aldigi_kurum", txt_sertf_kurum.Text);
                        guncellekomutusertifika.Parameters.AddWithValue("@konu", txt_sertf_konu.Text);
                        guncellekomutusertifika.Parameters.AddWithValue("@tarih", date_sertf_tarih.Value);
                        guncellekomutusertifika.Parameters.AddWithValue("@bitis_tarihi", date_bitis_tarih.Value);
                        guncellekomutusertifika.Parameters.AddWithValue("@id", txt_sertifika_id.Text);

                        guncellekomutusertifika.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                        MessageBox.Show("Kişinin sertifika bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }


                //ağır ve tehlikeli iş sertifika ile ilgil bilgler
                if (txt_agir.Text != string.Empty)
                {

                    try
                    {
                        SqlCommand guncellekomutuagir = new SqlCommand("Guncelle_Kisi_Sertifika_Agir_is", baglantim.baglanti());
                        guncellekomutuagir.CommandType = CommandType.StoredProcedure;

                        guncellekomutuagir.Parameters.AddWithValue("@kisi_tc_no", mtxt_tc_no.Text);
                        guncellekomutuagir.Parameters.AddWithValue("@agir_is_sertifika_adi", txt_agir.Text);
                        guncellekomutuagir.Parameters.AddWithValue("@alinis_tarihi", date_sertf_agir.Value);
                        guncellekomutuagir.Parameters.AddWithValue("@bitis_tarihi", date_sertf_agir_bitis.Value);
                        guncellekomutuagir.Parameters.AddWithValue("@id", txt_agirsertifika_id.Text);

                        guncellekomutuagir.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                        MessageBox.Show("Kişinin sertifika bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }

                if (txt_merasim.Text != string.Empty)
                {
                    try
                    {
                        SqlCommand guncellekomutumerasim = new SqlCommand("Guncelle_Kisi_Merasim", baglantim.baglanti());
                        guncellekomutumerasim.CommandType = CommandType.StoredProcedure;

                        guncellekomutumerasim.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);
                        guncellekomutumerasim.Parameters.AddWithValue("@planli_merasim_adi", txt_merasim.Text);
                        guncellekomutumerasim.Parameters.AddWithValue("@planli_merasim_tarihi", date_merasim.Value);
                        guncellekomutumerasim.Parameters.AddWithValue("@id", txt_merasim_id.Text);
                        guncellekomutumerasim.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        //böylece kayıt ekleme işlemi gerçekleştirlmiş oldu
                        MessageBox.Show("Kişinin merasim bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        // ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }

            }
            listele_bilgisayar_bilgisi();
            listele_hobi();
            listele_sertifika();
            listele_sertifika_agir_is();
            listele_yabanci_dil();
            listele_merasim();
            ekrani_temizle();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11)
            {
                //hobilerin silinmesi
                if (txt_hobi_id.Text != "")
                {
                    bool kisi_hobi_arama_yakin = false;
                    SqlCommand kisiHobisecmeSorgusu = new SqlCommand("Select *from Kisi_Hobi where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokumahobi = kisiHobisecmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokumahobi.Read())
                    {

                        //kayıt okuma gerçekleşti ise
                        kisi_hobi_arama_yakin = true;
                        SqlCommand hobiSilsorgusu = new SqlCommand("delete from Kisi_Hobi where kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_hobi_id.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        hobiSilsorgusu.ExecuteNonQuery();
                        // MessageBox.Show("Kullanıcının igili hobi bilgileri başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                        //ekrani_temizle();
                        listele_hobi();
                        break;
                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    /*  if (kisi_hobi_arama_yakin == false)//while döngüsü çalışmamş demektir.
                      {
                          MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                      }*/

                    // ekrani_temizle();


                    //yabancı dilinmesi
                }

                if (txt_dil_id.Text != "")
                {
                    bool kayit_arama_yabanci_dil = false;
                    SqlCommand secmeSorgusuyabancidil = new SqlCommand("Select *from Kisi_Dil_Bilgisi where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokumayabancidil = secmeSorgusuyabancidil.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokumayabancidil.Read())
                    {
                        //kayıt okuma gerçekleşti ise
                        kayit_arama_yabanci_dil = true;
                        SqlCommand yabanciDilSilsorgusu = new SqlCommand("delete from Kisi_Dil_Bilgisi where kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_dil_id.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        yabanciDilSilsorgusu.ExecuteNonQuery();
                        //MessageBox.Show("ilgili kayıt başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                        // ekrani_temizle();
                        listele_yabanci_dil();
                        break;
                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    /*if (kayit_arama_yabanci_dil == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }*/

                    // ekrani_temizle();
                }

                //bilgisayar bilgisi
                if (txt_bilgisayar_id.Text != "")
                {
                    bool kayit_arama_bilgisayar_bilgisi = false;
                    SqlCommand secmeSorgusubilgisayarbilgisi = new SqlCommand("Select *from Kisi_Bilgisayar_Program_Bilgileri where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokumabilgisayarbilgisi = secmeSorgusubilgisayarbilgisi.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokumabilgisayarbilgisi.Read())
                    {

                        //kayıt okuma gerçekleşti ise
                        kayit_arama_bilgisayar_bilgisi = true;
                        SqlCommand bilgisayarBilgisiSilsorgusu = new SqlCommand("delete from Kisi_Bilgisayar_Program_Bilgileri where kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_bilgisayar_id.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        bilgisayarBilgisiSilsorgusu.ExecuteNonQuery();
                        // MessageBox.Show("ilgili kayıt başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                        // ekrani_temizle();
                        listele_bilgisayar_bilgisi();
                        break;
                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    /*  if (kayit_arama_bilgisayar_bilgisi == false)//while döngüsü çalışmamş demektir.
                      {
                          MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                      }

                      ekrani_temizle();*/


                }


                //sertifika

                if (txt_sertifika_id.Text != "")
                {
                    bool kayit_arama_sertifika = false;
                    SqlCommand secmeSorgusuSertifika = new SqlCommand("Select *from Kisi_Sertifika_Bilgileri where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokumasertifika = secmeSorgusuSertifika.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokumasertifika.Read())
                    {

                        //kayıt okuma gerçekleşti ise
                        kayit_arama_sertifika = true;
                        SqlCommand sertifikaSilsorgusu = new SqlCommand("delete from Kisi_Sertifika_Bilgileri where kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_sertifika_id.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        sertifikaSilsorgusu.ExecuteNonQuery();
                        // MessageBox.Show("ilgili kayıt başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                        //  ekrani_temizle();
                        listele_sertifika();
                        break;
                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    /* if (kayit_arama_sertifika == false)//while döngüsü çalışmamş demektir.
                     {
                         MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                     }

                     ekrani_temizle();
                    */
                }
                // ağır sertifika
                if (txt_agirsertifika_id.Text != "")
                {
                    bool kayit_arama_agir = false;
                    SqlCommand secmeSorgusuagir = new SqlCommand("Select *from Kisi_Sertifika_Agir_is where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokumaagir = secmeSorgusuagir.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokumaagir.Read())
                    {

                        //kayıt okuma gerçekleşti ise
                        kayit_arama_agir = true;
                        SqlCommand agirSilsorgusu = new SqlCommand("delete from Kisi_Sertifika_Agir_is where kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_agirsertifika_id.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        agirSilsorgusu.ExecuteNonQuery();
                        //MessageBox.Show("Seçmiş olduğunuz tüm kayıtlar başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                        // ekrani_temizle();
                        listele_sertifika_agir_is();
                        break;
                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    /* if (kayit_arama_agir == false)//while döngüsü çalışmamş demektir.
                     {
                         MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                     }
                    */
                }

                if (txt_merasim_id.Text != "")
                {
                    bool kayit_arama_merasim = false;
                    SqlCommand secmeSorgusumerasim = new SqlCommand("Select *from Kisi_planli_merasim where kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokumamerasim = secmeSorgusumerasim.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokumamerasim.Read())
                    {

                        //kayıt okuma gerçekleşti ise
                        kayit_arama_merasim = true;
                        SqlCommand agirmerasimsorgusu = new SqlCommand("delete from Kisi_planli_merasim where kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_merasim_id.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        agirmerasimsorgusu.ExecuteNonQuery();
                        //MessageBox.Show("Seçmiş olduğunuz tüm kayıtlar başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                        // ekrani_temizle();
                        listele_merasim();
                        break;
                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    /* if (kayit_arama_agir == false)//while döngüsü çalışmamş demektir.
                     {
                         MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                     }
                    */
                }


                if (txt_sertifika_id.Text != "" || txt_agirsertifika_id.Text != "" || txt_dil_id.Text != "" || txt_bilgisayar_id.Text != "" || txt_hobi_id.Text != ""||txt_merasim_id.Text!="")
                {
                    MessageBox.Show("Seçmiş olduğunuz tüm kayıtlar başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                ekrani_temizle();
               
            }
            else
            {
                MessageBox.Show("tc kimlik no 11 haneli girilmelidir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            txt_hobi_id.Text = gridView1.GetFocusedRowCellValue("id").ToString();
            mtxt_tc_no.Text = gridView1.GetFocusedRowCellValue("kisi_tc").ToString();
            string hobilerrs = gridView1.GetFocusedRowCellValue("kisi_hobileri").ToString();
            lbl_hobiler.Text = hobilerrs;
            for (int count = 0; count < chb_hobi.Items.Count; count++)
            {
                if (hobilerrs.Contains(chb_hobi.Items[count].ToString()))
                {
                    chb_hobi.SetItemChecked(count, true);
                }
                else
                {
                    chb_hobi.SetItemChecked(count, false);
                }
            }

            btn_guncelle.Enabled = true;
            btn_sil.Enabled = true;
            simpleButton6.Enabled = true;
        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            txt_dil_id.Text = gridView2.GetFocusedRowCellValue("id").ToString();
            mtxt_tc_no.Text = gridView2.GetFocusedRowCellValue("kisi_tc").ToString();
            cb_dil.Text = gridView2.GetFocusedRowCellValue("yabanci_dil").ToString();
            cb_dil_duzey.Text = gridView2.GetFocusedRowCellValue("duzeyi").ToString();

            btn_guncelle.Enabled = true;
            btn_sil.Enabled = true;
            simpleButton6.Enabled = true;
        }

        private void gridControl3_DoubleClick(object sender, EventArgs e)
        {
            mtxt_tc_no.Text = gridView3.GetFocusedRowCellValue("kisi_tc").ToString();
            txt_bilgisayar_id.Text = gridView3.GetFocusedRowCellValue("id").ToString();
            txt_pc.Text = gridView3.GetFocusedRowCellValue("program_ad").ToString();
            cb_pc_duzey.Text = gridView3.GetFocusedRowCellValue("duzey").ToString();

            btn_guncelle.Enabled = true;
            btn_sil.Enabled = true;
            simpleButton6.Enabled = true;

        }

        private void gridControl4_DoubleClick(object sender, EventArgs e)
        {
            mtxt_tc_no.Text = gridView4.GetFocusedRowCellValue("kisi_tc").ToString();
            txt_sertifika_id.Text = gridView4.GetFocusedRowCellValue("id").ToString();
            txt_sertf_ad.Text = gridView4.GetFocusedRowCellValue("sertifika_adi").ToString();
            txt_sertf_kurum.Text = gridView4.GetFocusedRowCellValue("aldigi_kurum").ToString();
            txt_sertf_konu.Text = gridView4.GetFocusedRowCellValue("konu").ToString();
            date_sertf_tarih.Text = gridView4.GetFocusedRowCellValue("tarih").ToString();

            btn_guncelle.Enabled = true;
            btn_sil.Enabled = true;
            simpleButton6.Enabled = true;
        }

        private void gridControl5_DoubleClick(object sender, EventArgs e)
        {
            mtxt_tc_no.Text = gridView5.GetFocusedRowCellValue("kisi_tc").ToString();
            txt_agirsertifika_id.Text = gridView5.GetFocusedRowCellValue("id").ToString();
            txt_agir.Text = gridView5.GetFocusedRowCellValue("agir_is_sertifika_adi").ToString();
            date_sertf_agir.Text = gridView5.GetFocusedRowCellValue("alinis_tarihi").ToString();

            btn_guncelle.Enabled = true;
            btn_sil.Enabled = true;
            simpleButton6.Enabled = true;
        }

        private void gridControl9_DoubleClick(object sender, EventArgs e)
        {
            mtxt_tc_no.Text = gridView9.GetFocusedRowCellValue("kisi_tc").ToString();
            txt_merasim_id.Text = gridView9.GetFocusedRowCellValue("id").ToString();
            txt_merasim.Text = gridView9.GetFocusedRowCellValue("planli_merasim_adi").ToString();
            date_merasim.Text = gridView9.GetFocusedRowCellValue("planli_merasim_tarihi").ToString();

            btn_guncelle.Enabled = true;
            btn_sil.Enabled = true;
            simpleButton6.Enabled = true;
        }
        public void Excel_Disa_Aktar()
        {
            

        }
                           
        private void btn_rapor_Click(object sender, EventArgs e)
        {
            DataSet dataset = new DataSet();
            dataset.Tables.Add(dtl);
            dataset.Tables.Add(dth);
            dataset.Tables.Add(dtb);
            dataset.Tables.Add(dts);
            dataset.Tables.Add(dtas);
            dataset.Tables.Add(dtm);

            Excel.Application excel = new Excel.Application();
            var workbook = (Excel._Workbook)(excel.Workbooks.Add(Missing.Value));

            for (var i = 0; i < dataset.Tables.Count; i++)
            {
                if (workbook.Sheets.Count < i + 2)
                {
                    workbook.Sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }

                var currentSheet = (Excel._Worksheet)workbook.Sheets[1]; 

                //MessageBox.Show("?FullName?", workbook.FullName.ToString()); //Kitap__

                //MessageBox.Show("?Name?", currentSheet.Name.ToString()); //__Sayfa

                for (var y = 0; y < dataset.Tables[i].Columns.Count; y++)
                {
                    currentSheet.Cells[1, y + 1] = dataset.Tables[i].Columns[y].ColumnName;
                    //for (var x = 0; x < dataset.Tables[i].Columns[y].ColumnName.Count(); x++) //sütun
                    //{
                    //currentSheet.Cells[y + 2, x + 1] = dataset.Tables[i].Columns[y];


                    //}
                }
                for (var y = 0; y < dataset.Tables[i].Rows.Count; y++)
                {
                    for (var x = 0; x < dataset.Tables[i].Rows[y].ItemArray.Count(); x++) //sütun
                    {
                        //MessageBox.Show("....", dataset.Tables[i].Rows[y].ItemArray.Count().ToString());

                        currentSheet.Cells[y + 2, x + 1] = dataset.Tables[i].Rows[y].ItemArray[x];
                    }
                }
            }
            string outfile = @"C:\Dosyalar\GenelKultur.xlsx";

           
            workbook.Sheets[1].Name = "Merasim";
            workbook.Sheets[2].Name = "AgırİsSertifika";
            workbook.Sheets[3].Name = "Sertifika";
            workbook.Sheets[4].Name = "Bilgisayar";
            workbook.Sheets[5].Name = "Hobi";
            workbook.Sheets[6].Name = "Dil";

            workbook.SaveAs(outfile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);


            workbook.Close();
            excel.Quit();
            System.Diagnostics.Process.Start(@"C:\Dosyalar\GenelKultur.xlsx");


        }

        
    }
}