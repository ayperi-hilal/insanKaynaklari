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
    public partial class departmanOlustur : Form
    {
        public departmanOlustur()
        {
            InitializeComponent();
        }
        sqlBaglantisi baglantim = new sqlBaglantisi();

        private void departmanOlustur_Load(object sender, EventArgs e)
        {

            HorizontalScroll.Enabled = true;
            HorizontalScroll.Visible = true;

            txt_departmanAciklamasi.CharacterCasing = CharacterCasing.Upper;
            txt_departmanAdi.CharacterCasing = CharacterCasing.Upper;
            listele();
        }
        public void listele()
        {

            SqlCommand sorgu = new SqlCommand("ListeleDepartman", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(sorgu);

            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;


        }
        public void ekrani_temizle()
        {
            txt_departmanAdi.Text = "";
            txt_departmanAciklamasi.Text = "";
            txt_id.Text = "";
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {

            if (txt_departmanAdi.Text == "")
            {
                labelControl1.ForeColor = Color.Red;
            }
            else
                labelControl1.ForeColor = Color.Black;

            if (txt_departmanAciklamasi.Text == "")
                labelControl2.ForeColor = Color.Red;
            else
                labelControl2.ForeColor = Color.Black;
            if (txt_departmanAciklamasi.Text != "" && txt_departmanAdi.Text != "")
            {
                try
                {
                    SqlCommand eklekomutu = new SqlCommand("Kaydet_Departman", baglantim.baglanti());
                    eklekomutu.CommandType = CommandType.StoredProcedure;

                    eklekomutu.Parameters.AddWithValue("@deparmanAdi", txt_departmanAdi.Text);
                    eklekomutu.Parameters.AddWithValue("@departmanAciklamasi", txt_departmanAciklamasi.Text);

                    eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    MessageBox.Show("Departman başarılı bir şekilde eklenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                    ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                }
                catch (Exception hatamjs)
                {
                    //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                    MessageBox.Show("Kayıt esnasında beklenmeyen bir hata ile karşılaşılmıştır");
                    // MessageBox.Show(hatamjs.Message);

                }
            }
            else//herhangi bir hata ile karşılaşılır ise 
            {
                MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçirniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            listele();

        }

        private void btn_formuTemizle_Click(object sender, EventArgs e)
        {
            ekrani_temizle();
        }

        bool kayit = false;

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            kayit = true;

            txt_departmanAciklamasi.Text = gridView1.GetFocusedRowCellValue("BİRİM AÇIKLAMASI").ToString();
            txt_departmanAdi.Text = gridView1.GetFocusedRowCellValue("BİRİM").ToString();
            txt_id.Text = gridView1.GetFocusedRowCellValue("id").ToString();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            if (kayit == true)
            {
                if (txt_departmanAdi.Text == "")
                {
                    labelControl1.ForeColor = Color.Red;
                }
                else
                    labelControl1.ForeColor = Color.Black;

                if (txt_departmanAciklamasi.Text == "")
                    labelControl2.ForeColor = Color.Red;
                else
                    labelControl2.ForeColor = Color.Black;
                if (txt_departmanAciklamasi.Text != "" && txt_departmanAdi.Text != "")
                {
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_Departman", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@deparmanAdi", txt_departmanAdi.Text);
                        guncellekomutu.Parameters.AddWithValue("@departmanAciklamasi", txt_departmanAciklamasi.Text);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id.Text);

                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                        MessageBox.Show("Departman başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                        ekrani_temizle();//kayıt işlemi yapıldıktan sonra form temizlendi

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show("Güncelleme esnasında beklenmeyen bir hata ile karşılaşılmıştır");
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                else//herhangi bir hata ile karşılaşılır ise 
                {
                    MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçirniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                listele();
            }
            else
            {
                MessageBox.Show("Önce tablodan güncelleme yapmak istediğiniz birimi seçniz.");
                ekrani_temizle();
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (kayit == true)

            {
                bool kayit_arama_durumu = false;

                SqlCommand secmeSorgusu = new SqlCommand("Select *from deparman where deparmanAdi='" + txt_departmanAdi.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                while (kayitokuma.Read())
                {

                    //kayıt okuma gerçekleşti ise
                    kayit_arama_durumu = true;
                    SqlCommand silsorgusu = new SqlCommand("delete from deparman where deparmanAdi='" + txt_departmanAdi.Text + "'and id='" + txt_id.Text + "'", baglantim.baglanti());
                    //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                    silsorgusu.ExecuteNonQuery();
                    MessageBox.Show("Departman başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                    ekrani_temizle();
                    listele();
                    break;
                }
                //girilen tck ya göre bir kayıt bulunmaz ise
                if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                {
                    MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ekrani_temizle();
                }

                ekrani_temizle();


            }
            else
            {
                MessageBox.Show("Lütfen önce tablodan silmek istediğiniz departmanı seçiniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
