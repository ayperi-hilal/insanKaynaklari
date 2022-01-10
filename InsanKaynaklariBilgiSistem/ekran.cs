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
        string tc = giris.tcno;
        sqlBaglantisi baglantim = new sqlBaglantisi();

        public void resim_goruntule()
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT resim FROM Kisi WHERE TC = '" + aktifKullanici.tcno + "'", baglantim.baglanti()));

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

        kullaniciHesap frm1;
        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(frm1==null||frm1.IsDisposed)
            {
                frm1 = new kullaniciHesap();
                frm1.MdiParent = this;
                frm1.Show();
            }
            else
            {
             xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm1];
            }



            if (label2.Text == "ADMİN ADMİN")
            {
                barButtonItem29.Enabled = true;
                frm1.Visible = true;
                frm1.Enabled = true;
            }
            else
            {
                barButtonItem29.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
               barButtonItem29.Enabled = false;
                frm1.Visible = false;
                frm1.Enabled = false;
                MessageBox.Show("Bu kısım ile ilgili yetkiniz bulunmamaktadır");
            }

        }

        genelBilgiler frm2;
        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (frm2 == null || frm2.IsDisposed)
            {
                frm2 = new genelBilgiler();
                frm2.MdiParent = this;
                frm2.Show();
            }
            else
            {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm2];

            }

        }
        
        iletisimBilgisi frm3;
        private void iletişim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm3 == null || frm3.IsDisposed)
            {
                frm3 = new iletisimBilgisi();
                      
            frm3.MdiParent = this;
            frm3.Show();
             }
            else
            {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm3];

            }

}
        
        saglik frm4;
        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm4 == null || frm4.IsDisposed)
            { 
                frm4 = new saglik();

            frm4.MdiParent = this;
            frm4.Show();
            }
            else
            {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm4];

            }

        }

        ozGecmis frm5;
        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm5 == null || frm5.IsDisposed)
            {
                frm5 = new ozGecmis();

                frm5.MdiParent = this;
                frm5.Show();
            }
            else
            {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm5];

            }
        }

       egitim frm6;

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        if (frm6 == null || frm6.IsDisposed)
        { 
            frm6 = new egitim();

             frm6.MdiParent = this;
             frm6.Show();
        }
            else
        {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm6];

            }
        }

         genelKultur frm7;

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm7 == null || frm7.IsDisposed)
            {
                frm7 = new genelKultur();

                frm7.MdiParent = this;
                frm7.Show();

            }
            else
            {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm7];

            }
        }

            aileBilgisi frm8;

        private void barButtonItem35_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm8 == null || frm8.IsDisposed)
            { 
                 frm8 = new aileBilgisi();

                frm8.MdiParent = this;
                frm8.Show();

             }
             else
             {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm8];

            }

        }

            raporlama frm9;

        private void b_btn_rapor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm9 == null || frm9.IsDisposed)
            { 
                frm9 = new raporlama();
            
                frm9.MdiParent = this;
                frm9.Show();
            }
            else
            {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm9];

            }

        }
            bildirimler frm10;

        private void barButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             if (frm10 == null || frm10.IsDisposed)
             { 
                     frm10 = new bildirimler();

                    frm10.MdiParent = this;
                    frm10.Show();
             }
            else
            {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm10];

            }

        }

            maddiBilgi frm11;

        private void barButtonItem34_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm11 == null || frm11.IsDisposed)
            { 
                 frm11 = new maddiBilgi();

                frm11.MdiParent = this;
                frm11.Show();
            }
            else
            {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm11];

            }

           // Form active11 = this.ActiveMdiChild;
            //MessageBox.Show("---", active11.Name.ToString());
        }

        izinIslemleri frm12;
        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm12 == null || frm12.IsDisposed)
            { 
                frm12 = new izinIslemleri();

                    frm12.MdiParent = this;
                    frm12.Show();
             }
            else
            {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm12];

            }

        }

        durumGrafiği frm13;
        private void barButtonItem38_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm13 == null || frm13.IsDisposed)
            {
                frm13 = new durumGrafiği();

                frm13.MdiParent = this;
                frm13.Show();
            }
            else
            {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm13];

            }
        }

        kkd frm14;
        private void barButtonItem40_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm14==null||frm14.IsDisposed)
            {
                frm14 = new kkd();
                frm14.MdiParent = this;
                frm14.Show();
            }
            else
            {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm14];
            }
        }

        //   kullaniciHesap frm14 = new kullaniciHesap();
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
