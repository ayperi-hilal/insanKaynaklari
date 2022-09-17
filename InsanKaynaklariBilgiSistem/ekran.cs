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

        kullaniciHesap frmx;
        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (label2.Text == "ADMİN ADMİN")
            {
                barButtonItem29.Enabled = true;
                frmx.Visible = true;
                frmx.Enabled = true;
                if (frmx == null || frmx.IsDisposed)
                {
                    frmx = new kullaniciHesap();
                    frmx.MdiParent = this;
                    frmx.Show();
                }
                else
                {
                    xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frmx];
                }
            }
            //if (label2.Text == "ADMİN ADMİN")
            //{
            //    barButtonItem29.Enabled = true;
            //    frm1.Visible = true;
            //    frm1.Enabled = true;
            //}
            else
            {
                barButtonItem29.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
               barButtonItem29.Enabled = false;
                frmx.Visible = false;
                frmx.Enabled = false;
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

            maddiDurum frm11;

        private void barButtonItem34_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm11 == null || frm11.IsDisposed)
            { 
                 frm11 = new maddiDurum();

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

        kkdBilgisi frm14;
        private void barButtonItem40_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm14==null||frm14.IsDisposed)
            {
                frm14 = new kkdBilgisi();
                frm14.MdiParent = this;
                frm14.Show();
            }
            else
            {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm14];
            }
        }

        
        ciktiForm frm15;
        private void barButtonItem41_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm15 == null || frm15.IsDisposed)
            {
                frm15 = new ciktiForm();
                frm15.MdiParent = this;
                frm15.Show();
            }
            else
            {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm15];
            }
        }

        borcDurumu frm16;
        private void barButtonItem42_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm16 == null || frm16.IsDisposed)
            {
                frm16 = new borcDurumu();
                frm16.MdiParent = this;
                frm16.Show();
            }
            else
            {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm16];
            }
        }

        performans frm17;
        private void barButtonItem43_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm17 == null || frm17.IsDisposed)
            {
                frm17 = new performans();
                frm17.MdiParent = this;
                frm17.Show();
            }
            else
            {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm17];
            }
        }

        havuzolustur frm18;
        private void barButtonItem44_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm18 == null || frm18.IsDisposed)
            {
                frm18 = new havuzolustur();
                frm18.MdiParent = this;
                frm18.Show();
            }
            else
            {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm18];
            }
        }
        havuzKayit frm19;
        private void barButtonItem45_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm19 == null || frm19.IsDisposed)
            {
                frm19 = new havuzKayit();
                frm19.MdiParent = this;
                frm19.Show();
            }
            else
            {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm19];
            }
        }

        departmanOlustur frm20;
        private void barButtonItem47_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm20 == null || frm20.IsDisposed)
            {
                frm20 = new departmanOlustur();
                frm20.MdiParent = this;
                frm20.Show();
            }
            else
            {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm20];
            }
        }

        gorevOlustur frm21;
        private void barButtonItem48_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm21 == null || frm21.IsDisposed)
            {
                frm21 = new gorevOlustur();
                frm21.MdiParent = this;
                frm21.Show();
            }
            else
            {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm21];
            }
        }

        meslekKodu frm22;
        private void barButtonItem49_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm22 == null || frm22.IsDisposed)
            {
                frm22 = new meslekKodu();
                frm22.MdiParent = this;
                frm22.Show();
            }
            else
            {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm22];
            }
        }
        firmaImkanları frm23;
        private void barButtonItem50_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm23 == null || frm23.IsDisposed)
            {
                frm23 = new firmaImkanları();
                frm23.MdiParent = this;
                frm23.Show();
            }
            else
            {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm23];
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

            frmx = new kullaniciHesap();
            if (label2.Text != "ADMİN ADMİN")
            {
                barButtonItem29.Enabled = false;
                frmx.Visible = false;
                frmx.Enabled = false;
                ribbonPage2.Visible = false;
            }
            else
            {
                barButtonItem29.Enabled = false;
                // frm1.Visible = false;
                //frm1.Enabled = false;
                ribbonPage2.Visible = false;
            }
            //alertControl1.Show(this, "ekran ", "Aşağıdaki kod örneği, Windows Forms ile kullanım için tasarlanmıştır ve PaintEventArgs e olay işleyicisinin bir parametresi olan gerektirir Paint . Kod aşağıdaki eylemi gerçekleştirir:Bir iç işaretçi türü değişkeni oluşturur hdc ve bunu, formun grafik nesnesinin cihaz bağlamı için tanıtıcı olarak ayarlar.Kullanarak yeni bir grafik nesnesi oluşturur hdc.Yeni grafik nesnesiyle(ekranda) bir dikdörtgen çizer.Kullanarak yeni grafik nesnesini serbest bırakır hdc.");

            //alertControl1.Show(this, "Bildirim_Dogum_Günü_Bugün", "vvvv");

            SqlCommand cmd = new SqlCommand("Bildirim_Dogum_Günü_Bugün", baglantim.baglanti());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader data_Reader = cmd.ExecuteReader();
            while (data_Reader.Read())
            {
                alertControl1.Show(this, "\n", data_Reader[0].ToString() + " \nDogum Günü Bugün\n" + data_Reader[1].ToString());
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            SqlCommand cmd_1 = new SqlCommand("Bildirim_Dogum_Günü_Yaklasan", baglantim.baglanti());
            cmd_1.CommandType = CommandType.StoredProcedure;

            SqlDataReader data_Reader_1 = cmd_1.ExecuteReader();
            while (data_Reader_1.Read())
            {
                alertControl1.Show(this, "Yaklaşan Doğum Günleri\n", data_Reader_1[1].ToString() + " \n Bu hafta içinde \n" + data_Reader_1[2].ToString());
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
           

            SqlCommand cmd_2 = new SqlCommand("Bildirim_Kisi_Planli_Merasim_Bugün", baglantim.baglanti());
            cmd_2.CommandType = CommandType.StoredProcedure;

            SqlDataReader data_Reader_2 = cmd_2.ExecuteReader();
            while (data_Reader_2.Read())
            {
                alertControl1.Show(this, "MERASİMLERDE BUGÜN", data_Reader_2[1].ToString() + " " + data_Reader_2[2].ToString());
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            SqlCommand cmd_3 = new SqlCommand("Bildirim_Kisi_Planli_Merasim_Yaklasan", baglantim.baglanti());
            cmd_3.CommandType = CommandType.StoredProcedure;

            SqlDataReader data_Reader_3 = cmd_3.ExecuteReader();
            while (data_Reader_3.Read())
            {
                alertControl1.Show(this, "YAKLAŞAN MERASİMLER", data_Reader_3[1].ToString() + " " + data_Reader_3[2].ToString());
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            SqlCommand cmd_4 = new SqlCommand("Borc_Odeme_Bugün", baglantim.baglanti());
            cmd_4.CommandType = CommandType.StoredProcedure;

            SqlDataReader data_Reader_4 = cmd_4.ExecuteReader();
            while (data_Reader_4.Read())
            {
                alertControl1.Show(this, "BORÇ ÖDEMESİNDE BUGÜN", data_Reader_4[1].ToString() + " " + data_Reader_4[2].ToString());
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            SqlCommand cmd_5 = new SqlCommand("Borc_Odeme_Buhafta", baglantim.baglanti());
            cmd_5.CommandType = CommandType.StoredProcedure;

            SqlDataReader data_Reader_5 = cmd_5.ExecuteReader();
            while (data_Reader_5.Read())
            {
                alertControl1.Show(this, "BU HAFTA BORÇ ÖDEMESİ", data_Reader_5[1].ToString() + " " + data_Reader_5[2].ToString());
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            SqlCommand cmd_6 = new SqlCommand("Borc_Odeme_Buay", baglantim.baglanti());
            cmd_6.CommandType = CommandType.StoredProcedure;

            SqlDataReader data_Reader_6 = cmd_6.ExecuteReader();
            while (data_Reader_6.Read())
            {
                alertControl1.Show(this, "BU AY BORÇ ÖDEMESİ", data_Reader_6[1].ToString() + " " + data_Reader_6[2].ToString());
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            SqlCommand cmd_7 = new SqlCommand("Borcu_Geciken", baglantim.baglanti());
            cmd_7.CommandType = CommandType.StoredProcedure;

            SqlDataReader data_Reader_7 = cmd_7.ExecuteReader();
            while (data_Reader_7.Read())
            {
                alertControl1.Show(this, "BORCU GECİKEN", data_Reader_7[1].ToString() + " " + data_Reader_7[2].ToString());
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            SqlCommand cmd_8 = new SqlCommand("Bildirim_agir_Sertifika_Bitisi_Bugün", baglantim.baglanti());
            cmd_8.CommandType = CommandType.StoredProcedure;

            SqlDataReader data_Reader_8 = cmd_8.ExecuteReader();
            while (data_Reader_8.Read())
            {
                alertControl1.Show(this, "AĞIR İŞ SERTİFİKASININ SÜRESİ DOLDU", data_Reader_8[1].ToString() + " " + data_Reader_8[2].ToString());
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



            SqlCommand cmd_9 = new SqlCommand("Bildirim_agir_Sertifika_Bitisi_Buhafta", baglantim.baglanti());
            cmd_9.CommandType = CommandType.StoredProcedure;

            SqlDataReader data_Reader_9 = cmd_9.ExecuteReader();
            while (data_Reader_9.Read())
            {
                alertControl1.Show(this, "AĞIR İŞ SERTİFİKASININ SÜRESİ BU HAFTA DOLACAK", data_Reader_9[1].ToString() + " " + data_Reader_9[2].ToString());
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




            SqlCommand cmd_10 = new SqlCommand("Bildirim_agir_Sertifika_Bitisi_Buay", baglantim.baglanti());
            cmd_10.CommandType = CommandType.StoredProcedure;

            SqlDataReader data_Reader_10 = cmd_10.ExecuteReader();
            while (data_Reader_10.Read())
            {
                alertControl1.Show(this, "AĞIR İŞ SERTİFİKASININ SÜRESİ BU AY DOLACAK", data_Reader_10[1].ToString() + " " + data_Reader_10[2].ToString());
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



            SqlCommand cmd_11 = new SqlCommand("Bildirim_agir_Sertifika_Bitisi_Gecti", baglantim.baglanti());
            cmd_11.CommandType = CommandType.StoredProcedure;

            SqlDataReader data_Reader_11 = cmd_11.ExecuteReader();
            while (data_Reader_11.Read())
            {
                alertControl1.Show(this, "AĞIR İŞ SERTİFİKASININ SÜRESİ DOLDU.", data_Reader_11[1].ToString() + " " + data_Reader_11[2].ToString());
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            SqlCommand cmd_12 = new SqlCommand("Bildirim_Sertifika_Bitisi_Bugün", baglantim.baglanti());
            cmd_12.CommandType = CommandType.StoredProcedure;

            SqlDataReader data_Reader_12 = cmd_12.ExecuteReader();
            while (data_Reader_12.Read())
            {
                alertControl1.Show(this, "SERTİFİKANIN SÜRESİ DOLDU", data_Reader_12[1].ToString() + " " + data_Reader_12[2].ToString());
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            SqlCommand cmd_13 = new SqlCommand("Bildirim_Sertifika_Bitisi_Buhafta", baglantim.baglanti());
            cmd_13.CommandType = CommandType.StoredProcedure;

            SqlDataReader data_Reader_13 = cmd_13.ExecuteReader();
            while (data_Reader_13.Read())
            {
                alertControl1.Show(this, "SERTİFİKASININ SÜRESİ BU HAFTA DOLACAK", data_Reader_13[1].ToString() + " " + data_Reader_13[2].ToString());
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            SqlCommand cmd_14 = new SqlCommand("Bildirim_Sertifika_Bitisi_Buay", baglantim.baglanti());
            cmd_14.CommandType = CommandType.StoredProcedure;

            SqlDataReader data_Reader_14 = cmd_14.ExecuteReader();
            while (data_Reader_14.Read())
            {
                alertControl1.Show(this, "SERTİFİKASININ SÜRESİ BU AY DOLACAK", data_Reader_14[1].ToString() + " " + data_Reader_14[2].ToString());
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
           
            SqlCommand cmd_15 = new SqlCommand("Bildirim_Sertifika_Bitisi_Gecti", baglantim.baglanti());
            cmd_15.CommandType = CommandType.StoredProcedure;

            SqlDataReader data_Reader_15 = cmd_15.ExecuteReader();
            while (data_Reader_15.Read())
            {
                alertControl1.Show(this, "SERTİFİKASININ SÜRESİ DOLDU.", data_Reader_15[1].ToString() + " " + data_Reader_15[2].ToString());
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            SqlCommand cmd_16 = new SqlCommand("Aile_Merasim_Bugün", baglantim.baglanti());
            cmd_16.CommandType = CommandType.StoredProcedure;

            SqlDataReader data_Reader_16 = cmd_16.ExecuteReader();
            while (data_Reader_16.Read())
            {
                alertControl1.Show(this, "MERASİMİ BUGÜN.", data_Reader_16[1].ToString() + " " + data_Reader_16[2].ToString());
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            SqlCommand cmd_17 = new SqlCommand("Aile_Merasim_Buhafta", baglantim.baglanti());
            cmd_17.CommandType = CommandType.StoredProcedure;

            SqlDataReader data_Reader_17 = cmd_17.ExecuteReader();
            while (data_Reader_17.Read())
            {
                alertControl1.Show(this, "MERASİMİ BU HAFTA.", data_Reader_17[1].ToString() + " " + data_Reader_17[2].ToString());
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //DateTime bugunTarihi = DateTime.Now;
            //DateTime sinavTarihi = new DateTime(2021, 3, 2);

            ////"6.02.1990 17:23:43" 

            //TimeSpan ts = sinavTarihi - bugunTarihi;
            //MessageBox.Show(
            //"Sınav Tarihi : " + b.ToShortDateString()
            //+ "\n" +
            //  "Kalan Gün : " + ts.Days.ToString());

            //MessageBox.Show("(baslangicTarihi - bitisTarihi).TotalDays",(sinavTarihi - bugunTarihi).TotalDays.ToString());


            //planlanan merasimler
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

        private void alertControl1_BeforeFormShow(object sender, DevExpress.XtraBars.Alerter.AlertFormEventArgs e)
        {
            e.AlertForm.OpacityLevel = 1;
        }

        
    }
}
