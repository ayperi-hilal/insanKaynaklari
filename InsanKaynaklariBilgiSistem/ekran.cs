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
    public partial class ekran : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public ekran()
        {
            InitializeComponent();
        }
        string tc = "";
        sqlBaglantisi baglantim = new sqlBaglantisi();

        public void resim_goruntule()
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT resim FROM Kisi WHERE TC = '" + tc + "'", baglantim.baglanti()));

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


        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
           kullaniciHesap frm1 = new kullaniciHesap();

            frm1.MdiParent = this;
            frm1.Show();

        }

        
        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                genelBilgiler frm2 = new genelBilgiler();
            
                frm2.MdiParent = this;
                frm2.Show();

        }
        
        private void iletişim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            iletisimBilgisi frm3 = new iletisimBilgisi();
                      
            frm3.MdiParent = this;
            frm3.Show();

        }
        
        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            saglik frm4 = new saglik();

            frm4.MdiParent = this;
            frm4.Show();

        }

        
        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ozGecmis frm5 = new ozGecmis();

            frm5.MdiParent = this;
            frm5.Show();

        }

       
        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            egitim frm6 = new egitim();

            frm6.MdiParent = this;
            frm6.Show();
        }

        
        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            genelKultur frm7 = new genelKultur();

            frm7.MdiParent = this;
            frm7.Show();

        }
        
        
        private void barButtonItem35_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            aileBilgisi frm8 = new aileBilgisi();

            frm8.MdiParent = this;
            frm8.Show();

        }

        private void b_btn_rapor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            raporlama frm9 = new raporlama();
            
            frm9.MdiParent = this;
            frm9.Show();

        }

        private void barButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bildirimler frm10 = new bildirimler();

            frm10.MdiParent = this;
            frm10.Show();

        }

        private void barButtonItem34_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            maddiBilgi frm11 = new maddiBilgi();

            frm11.MdiParent = this;
            frm11.Show();

           // Form active11 = this.ActiveMdiChild;
            //MessageBox.Show("---", active11.Name.ToString());
        }
        
        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            izinIslemleri frm12 = new izinIslemleri();

            frm12.MdiParent = this;
            frm12.Show();

        }


        private void Form4_Load(object sender, EventArgs e)
        {
            resim_goruntule();

            pictureBox1.Height = 90;
            pictureBox1.Width = 90;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
           
            //kullanıcı sekmesi ile ilgili ayarlaır yapalım.

            label2.ForeColor = Color.DarkRed;
            label2.Text = giris.adi + " " + giris.soyadi;

            //tarih ve saat bildgisi
            label4.Text = DateTime.Now.ToString();

        }

       

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Programdan Çıkmak İstediğinizden Emin Misiniz?", "Çıkış Mesajı!", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                //Evet tıklandığında Yapılacak İşlemler
                Environment.Exit(0); // Evet tıklandığında uygulama kapanacak

            }
            else if (x == DialogResult.No)
            {
                // Hayır tıklandığında yapılacak işlemler
                MessageBox.Show("Program Kapatılamadı.");
            }
            
        }
       
        


    }
}
