using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsanKaynaklariBilgiSistem
{
    public partial class performansDurum : Form
    {
        public performansDurum()
        {
            InitializeComponent();
        }

        sqlBaglantisi baglantim = new sqlBaglantisi();

        bool kayit_arama_durumu = false;

        DataTable dtp = new DataTable();


        public void listele()
        {
            // gridControl1.DataSource = null;
            //gridView1.Columns.Clear();
            DataTable dnull = new DataTable();

            

            SqlCommand sorgu = new SqlCommand("tum_kisiYillikPerformans", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sorgu);
            sorgu.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);

            sorgu.Parameters.AddWithValue("@yil", cb_yil_sec.Text);

            gridControl1.DataSource = null;

            //DataTable dt = new DataTable();
            da.Fill(dtp);
            gridControl1.DataSource = dtp;
            // gridView1.Columns["ID"].Visible = false;
            //gridView1.Columns["pdks"].Visible = false;


            SqlCommand selectsorgu2 = new SqlCommand("ORTALAMA", baglantim.baglanti());
            selectsorgu2.CommandType = CommandType.StoredProcedure;

            selectsorgu2.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
            selectsorgu2.Parameters.AddWithValue("@yil", cb_yil_sec.Text);

            SqlDataReader kayitokuma2 = selectsorgu2.ExecuteReader();

            while (kayitokuma2.Read())

            {
                // MessageBox.Show(kayitokuma2.GetValue(0).ToString() + "---" + kayitokuma2.GetValue(1).ToString());
                if (kayitokuma2.GetValue(0).ToString() == mtxt_tc_no.Text)
                {
                    //lbl_ortalama.Text = kayitokuma2.GetValue(1).ToString();
                }
                else
                { MessageBox.Show("Test"); }

                break;
            }


        }

        private void btn_ara_Click(object sender, EventArgs e)
        {

            //kayıdın olup olmadığını değerlendirecektir.
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
                    lbl_gorevyeri.Text = kayitokuma.GetValue(14).ToString();
                    lbl_gorevii.Text = kayitokuma.GetValue(13).ToString();

                    //btn_sil_11.Enabled = true;
                    //btn_guncelle.Enabled = true;
                    //btn_forma_ekle.Enabled = true;

                    //
                    //
                    //();
                    break;
                }
                //eğer kayıt okuma durumu gerçekleşmemiş ise kayıt bulunamadı ise
                if (kayit_arama_durumu == false)
                {
                    MessageBox.Show("Kayıt bulunamadı", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //btn_sil_11.Enabled = false;
                    //btn_guncelle.Enabled = false;
                    //btn_forma_ekle.Enabled = false;
                }

            }
            else
            {
                //girilen tc no 11karakter değilse
                MessageBox.Show("Lütfen 11 haneli TC NO giriniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ekrani_temizle();
            }



        }

        private void btn_listele_Click(object sender, EventArgs e)
        {

            if (mtxt_tc_no.Text == "")
            {
                MessageBox.Show("Lütfen önce arama işlemi yapınız.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                if (cb_yil_sec.Text == "")
                {
                    MessageBox.Show("Sol taraftan yıl bilgisini seçiniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (mtxt_tc_no.Text != "" && txt_pdks.Text != "" && label3.Text != "" && label5.Text != "")
                {
                    listele();
                    try
                    {
                        for (int i = 0; i < dtp.Rows.Count; i++)
                        {
                            //Series sutunlar = this.chart1.Series.Add(dtp.Rows[i].ItemArray.ToString());
                            //sutunlar.Points.Add(dtp.Columns[i].DataType.Name);
                            //this.chartControl1.Series["Series 2"].Points.AddPoint(dtp.Rows[i][7].ToString(), Convert.ToInt32(dtp.Rows[i][5]));
                            this.chartControl1.DataSource = dtp;
                            this.chartControl1.Series["Series 1"].Points.AddPoint(dtp.Rows[i][5].ToString(), Convert.ToInt32(dtp.Rows[i][6]));


                            //çalışan
                        }

                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }
                else
                {
                    MessageBox.Show("Birşeyler ters  gitti.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // bool kayit_arama_durumu = false;
            }



        }

        private void performansDurum_Load(object sender, EventArgs e)
        {

        }
    }
}
