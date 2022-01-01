using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsanKaynaklariBilgiSistem
{
    public partial class evrakEkleme : Form
    {
        public evrakEkleme()
        {
            InitializeComponent();
        }

        string kimlik_dosyaYolu;
        string kimlik_dosyaAdi;
        string belge="myb2";


        private void evrakEkleme_Load(object sender, EventArgs e)
        {

            //personel için yüklenen tüm evraklar görünebiliyor.

            listBox1.Items.Clear();
            string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
            DirectoryInfo di = new DirectoryInfo(hedef);
            FileInfo[] rgFiles = di.GetFiles();
            foreach(FileInfo fi in rgFiles)
            {
                listBox1.Items.Add(fi.Name);
            }









            lbl_kisi.Text = aktifKullanici.kisi;
           // MessageBox.Show(lbl_kisi.Text);
            MessageBox.Show(aktifKullanici.kisi  + " TC nolu personelin evraklarını yüklüyorsunuz...");

            // For döngüsü ile kişinin dosyalarını listeleme
            if (Directory.Exists(@"C://Dosyalar//" + aktifKullanici.kisi + "/"))
            {
                

              //  MessageBox.Show("Test- dosya listesi okey");
                string[] dosyalar = Directory.GetFiles(@"C://Dosyalar//" + aktifKullanici.kisi + "/");
                //MessageBox.Show(dosyalar.Length.ToString()  + " dosyalar dosya sayısı");
                for (int i = 0; i < dosyalar.Length; i++)
                {
                    //MessageBox.Show(dosyalar[i]);

                    // Contains: içinde var mı diye kontrol. True false dönderir
                    if (dosyalar[i].Contains("Kimlik"))
                    {
                        btn_kimlik.Tag = dosyalar[i];
                        btn_kimlik.ForeColor = Color.Red;
                    }
                  else  if (dosyalar[i].Contains("Akciğer Grafiği"))
                    {
                        btn_akciger.Tag = dosyalar[i];
                        btn_akciger.ForeColor = Color.Red;
                    }
                    else if (dosyalar[i].Contains("Tetanoz Aşısı"))
                    {
                        btn_tetanoz.Tag = dosyalar[i];
                        btn_tetanoz.ForeColor = Color.Red;
                    }
                    else if (dosyalar[i].Contains("Kan Tahlili"))
                    {
                        btn_kan.Tag = dosyalar[i];
                        btn_kan.ForeColor = Color.Red;
                    }
                    else if (dosyalar[i].Contains("Muayene"))
                    {
                        btn_muayene.Tag = dosyalar[i];
                        btn_muayene.ForeColor = Color.Red;
                    }
                    if (dosyalar[i].Contains("ODYOGRAM"))
                    {
                        btn_odyogram.Tag = dosyalar[i];
                        btn_odyogram.ForeColor = Color.Red;
                    }
                    if (dosyalar[i].Contains("Hepatit"))
                    {
                        btn_hepaitit.Tag = dosyalar[i];
                        btn_hepaitit.ForeColor = Color.Red;
                    }
                    if (dosyalar[i].Contains("Diploma"))
                    {
                        btn_diploma.Tag = dosyalar[i];
                        btn_diploma.ForeColor = Color.Red;
                    }
                    if (dosyalar[i].Contains("İkametgah"))
                    {
                        btn_ikametgah.Tag = dosyalar[i];
                        btn_ikametgah.ForeColor = Color.Red;
                    }
                    if (dosyalar[i].Contains("Sabıka"))
                    {
                        btn_sabika.Tag = dosyalar[i];
                        btn_sabika.ForeColor = Color.Red;
                    }
                    if (dosyalar[i].Contains("SGK Bildiriri"))
                    {
                        btn_sgk.Tag = dosyalar[i];
                        btn_sgk.ForeColor = Color.Red;
                    }
                    if (dosyalar[i].Contains("İSG"))
                    {
                        btn_isg.Tag = dosyalar[i];
                        btn_isg.ForeColor = Color.Red;
                    }
                    if (dosyalar[i].Contains("Belgesi-1"))
                    {
                        btn_myb.Tag = dosyalar[i];
                        btn_myb.ForeColor = Color.Red;
                    }
                    if (dosyalar[i].Contains("Belgesi-2"))
                    {
                        btn_myb2.Tag = dosyalar[i];
                        btn_myb2.ForeColor = Color.Red;
                    }
                    if (dosyalar[i].Contains("Dil Bilgisi"))
                    {
                        btn_dil.Tag = dosyalar[i];
                        btn_dil.ForeColor = Color.Red;
                    }

                }

            }
            /*else
            {
                MessageBox.Show("bomboş geçti");
            }*/

        }

        private void btn_kimlik_Click(object sender, EventArgs e)
        {
            if (btn_kimlik.Tag != null)
            {
                if (!String.IsNullOrWhiteSpace(btn_kimlik.Tag.ToString()))
                {
                    System.Diagnostics.Process.Start(btn_kimlik.Tag.ToString());
                    return;
                }
            }
              
                OpenFileDialog dosya = new OpenFileDialog();
                dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";

                if (dosya.ShowDialog() == DialogResult.OK)
                {
                   kimlik_dosyaYolu = dosya.FileName;

                    kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
                    string kaynak = kimlik_dosyaYolu;
                    string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
                    MessageBox.Show(hedef);
                    string yeniad = lbl_kisi.Text + "_" + btn_kimlik.Text + ".pdf"; //Benzersiz isim verme

                    string DosyaYolu = @"C://Dosyalar//" + aktifKullanici.kisi + "/" + yeniad;
                    File.Copy(kaynak, hedef + yeniad, true);
                    btn_kimlik.Tag = hedef + yeniad;
                    btn_kimlik.ForeColor = Color.Red;
                }
            
        }

        private void btn_akciger_Click(object sender, EventArgs e)
        {
            if (btn_akciger.Tag != null)
            {
                if (!String.IsNullOrWhiteSpace(btn_akciger.Tag.ToString()))
                {
                    System.Diagnostics.Process.Start(btn_akciger.Tag.ToString());
                    return;
                }
            }

            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";

            if (dosya.ShowDialog() == DialogResult.OK)
            {
                kimlik_dosyaYolu = dosya.FileName;


                kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
                string kaynak = kimlik_dosyaYolu;
                string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
                MessageBox.Show(hedef);
                string yeniad = lbl_kisi.Text + "_" + btn_akciger.Text + ".pdf"; //Benzersiz isim verme

                string DosyaYolu = @"C://Dosyalar//" + aktifKullanici.kisi + "/" + yeniad;

                File.Copy(kaynak, hedef + yeniad, true);
                btn_kimlik.Tag = hedef + yeniad;
                btn_kimlik.ForeColor = Color.Red;
            }
            
            
        }

        
        private void btn_tetanoz_Click(object sender, EventArgs e)
        {
            if (btn_akciger.Tag != null)
            {
                if (!String.IsNullOrWhiteSpace(btn_akciger.Tag.ToString()))
                {
                    System.Diagnostics.Process.Start(btn_akciger.Tag.ToString());
                    return;
                }
            }

            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";

            if (dosya.ShowDialog() == DialogResult.OK)
            {
                kimlik_dosyaYolu = dosya.FileName;


                kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
                string kaynak = kimlik_dosyaYolu;
                string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
                MessageBox.Show(hedef);
                string yeniad = lbl_kisi.Text + "_" + btn_tetanoz.Text + ".pdf"; //Benzersiz isim verme
                string DosyaYolu = @"C://Dosyalar//" + aktifKullanici.kisi + "/" + yeniad;

                File.Copy(kaynak, hedef + yeniad, true);
                btn_kimlik.Tag = hedef + yeniad;
                btn_kimlik.ForeColor = Color.Red;
            }
            
            
        }

        private void btn_kan_Click(object sender, EventArgs e)
        {

            if (btn_kan.Tag != null)
            {
                if (!String.IsNullOrWhiteSpace(btn_kan.Tag.ToString()))
                {
                    System.Diagnostics.Process.Start(btn_kan.Tag.ToString());
                    return;
                }
            }


            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";

            if (dosya.ShowDialog() == DialogResult.OK)
            {

                kimlik_dosyaYolu = dosya.FileName;


                kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
                string kaynak = kimlik_dosyaYolu;
                string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
                MessageBox.Show(hedef);
                string yeniad = lbl_kisi.Text + "_" + btn_kan.Text + ".pdf"; //Benzersiz isim verme

                string DosyaYolu = @"C://Dosyalar//" + aktifKullanici.kisi + "/" + yeniad;

                File.Copy(kaynak, hedef + yeniad, true);
                btn_kimlik.Tag = hedef + yeniad;
                btn_kimlik.ForeColor = Color.Red;


            }
        }

        private void btn_muayene_Click(object sender, EventArgs e)
        {
            if (btn_muayene.Tag != null)
            {
                if (!String.IsNullOrWhiteSpace(btn_muayene.Tag.ToString()))
                {
                    System.Diagnostics.Process.Start(btn_muayene.Tag.ToString());
                    return;
                }
            }

            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";

            if (dosya.ShowDialog() == DialogResult.OK)
            {

                kimlik_dosyaYolu = dosya.FileName;


                kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
                string kaynak = kimlik_dosyaYolu;
                string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
                MessageBox.Show(hedef);
                string yeniad = lbl_kisi.Text + "_" + btn_muayene.Text + ".pdf"; //Benzersiz isim verme

                string DosyaYolu = @"C://Dosyalar//" + aktifKullanici.kisi + "/" + yeniad;
                File.Copy(kaynak, hedef + yeniad, true);
                btn_kimlik.Tag = hedef + yeniad;
                btn_kimlik.ForeColor = Color.Red;


            }
        }
        private void btn_odyogram_Click(object sender, EventArgs e)
        {
            if (btn_odyogram.Tag != null)
            {
                if (!String.IsNullOrWhiteSpace(btn_odyogram.Tag.ToString()))
                {
                    System.Diagnostics.Process.Start(btn_odyogram.Tag.ToString());
                    return;
                }
            }


            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";
            if (dosya.ShowDialog() == DialogResult.OK)
            {
                kimlik_dosyaYolu = dosya.FileName;


                kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
                string kaynak = kimlik_dosyaYolu;
                string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
                MessageBox.Show(hedef);

                string yeniad = lbl_kisi.Text + "_" + btn_odyogram.Text + ".pdf"; //Benzersiz isim verme
                string DosyaYolu = @"C://Dosyalar//" + aktifKullanici.kisi + "/" + yeniad;
                File.Copy(kaynak, hedef + yeniad, true);
                btn_kimlik.Tag = hedef + yeniad;
                btn_kimlik.ForeColor = Color.Red;

            }
        }
        private void btn_hepaitit_Click(object sender, EventArgs e)
        {
            if (btn_hepaitit.Tag != null)
            {
                if (!String.IsNullOrWhiteSpace(btn_hepaitit.Tag.ToString()))
                {
                    System.Diagnostics.Process.Start(btn_hepaitit.Tag.ToString());
                    return;
                }
            }

            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";
            if (dosya.ShowDialog() == DialogResult.OK)
            {

                kimlik_dosyaYolu = dosya.FileName;


                kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
                string kaynak = kimlik_dosyaYolu;
                string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
                MessageBox.Show(hedef);
                string yeniad = lbl_kisi.Text + "_" + btn_hepaitit.Text + ".pdf"; //Benzersiz isim verme
                string DosyaYolu = @"C://Dosyalar//" + aktifKullanici.kisi + "/" + yeniad;
                File.Copy(kaynak, hedef + yeniad, true);
                btn_kimlik.Tag = hedef + yeniad;
                btn_kimlik.ForeColor = Color.Red;


            }
        }
        private void btn_diploma_Click(object sender, EventArgs e)
        {
            if (btn_diploma.Tag != null)
            {
                if (!String.IsNullOrWhiteSpace(btn_diploma.Tag.ToString()))
                {
                    System.Diagnostics.Process.Start(btn_diploma.Tag.ToString());
                    return;
                }
            }


            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";

            if (dosya.ShowDialog() == DialogResult.OK)
            {

                kimlik_dosyaYolu = dosya.FileName;


                kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
                string kaynak = kimlik_dosyaYolu;
                string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
                MessageBox.Show(hedef);
                string yeniad = lbl_kisi.Text + "_" + btn_diploma.Text + ".pdf"; //Benzersiz isim verme
                string DosyaYolu = @"C://Dosyalar//" + aktifKullanici.kisi + "/" + yeniad;
                File.Copy(kaynak, hedef + yeniad, true);
                btn_kimlik.Tag = hedef + yeniad;
                btn_kimlik.ForeColor = Color.Red;


            }

        }

        private void btn_ikametgah_Click(object sender, EventArgs e)
        {
            if (btn_ikametgah.Tag != null)
            {
                if (!String.IsNullOrWhiteSpace(btn_ikametgah.Tag.ToString()))
                {
                    System.Diagnostics.Process.Start(btn_ikametgah.Tag.ToString());
                    return;
                }
            }

            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";

            if (dosya.ShowDialog() == DialogResult.OK)
            {

                kimlik_dosyaYolu = dosya.FileName;


                kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
                string kaynak = kimlik_dosyaYolu;
                string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
                MessageBox.Show(hedef);
                string yeniad = lbl_kisi.Text + "_" + btn_ikametgah.Text + ".pdf"; //Benzersiz isim verme
                string DosyaYolu = @"C://Dosyalar//" + aktifKullanici.kisi + "/" + yeniad;
                File.Copy(kaynak, hedef + yeniad, true);
                btn_kimlik.Tag = hedef + yeniad;
                btn_kimlik.ForeColor = Color.Red;

            }          
        }

        private void btn_sabika_Click(object sender, EventArgs e)
        {
            if (btn_sabika.Tag != null)
            {
                if (!String.IsNullOrWhiteSpace(btn_sabika.Tag.ToString()))
                {
                    System.Diagnostics.Process.Start(btn_sabika.Tag.ToString());
                    return;
                }
            }

            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";

            if (dosya.ShowDialog() == DialogResult.OK)
            {

                kimlik_dosyaYolu = dosya.FileName;


                kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
                string kaynak = kimlik_dosyaYolu;
                string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
                MessageBox.Show(hedef);
                string yeniad = lbl_kisi.Text + "_" + btn_sabika.Text + ".pdf"; //Benzersiz isim verme
                string DosyaYolu = @"C://Dosyalar//" + aktifKullanici.kisi + "/" + yeniad;
                File.Copy(kaynak, hedef + yeniad, true);
                btn_kimlik.Tag = hedef + yeniad;
                btn_kimlik.ForeColor = Color.Red;
            }
        }

        private void btn_sgk_Click(object sender, EventArgs e)
        {
            if (btn_sgk.Tag != null)
            {
                if (!String.IsNullOrWhiteSpace(btn_sgk.Tag.ToString()))
                {
                    System.Diagnostics.Process.Start(btn_sgk.Tag.ToString());
                    return;
                }
            }

            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";

            if (dosya.ShowDialog() == DialogResult.OK)
            {

                kimlik_dosyaYolu = dosya.FileName;


                kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
                string kaynak = kimlik_dosyaYolu;
                string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
                MessageBox.Show(hedef);
                string yeniad = lbl_kisi.Text + "_" + btn_sgk.Text + ".pdf"; //Benzersiz isim verme
                string DosyaYolu = @"C://Dosyalar//" + aktifKullanici.kisi + "/" + yeniad;
                File.Copy(kaynak, hedef + yeniad, true);
                btn_kimlik.Tag = hedef + yeniad;
                btn_kimlik.ForeColor = Color.Red;


            }
        }

        private void btn_isg_Click(object sender, EventArgs e)
        {
            if (btn_isg.Tag != null)
            {
                if (!String.IsNullOrWhiteSpace(btn_isg.Tag.ToString()))
                {
                    System.Diagnostics.Process.Start(btn_isg.Tag.ToString());
                    return;
                }
            }
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";

            if (dosya.ShowDialog() == DialogResult.OK)
            {
                kimlik_dosyaYolu = dosya.FileName;


                kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
                string kaynak = kimlik_dosyaYolu;
                string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
                MessageBox.Show(hedef);
                string yeniad = lbl_kisi.Text + "_" + btn_isg.Text + ".pdf"; //Benzersiz isim verme
                string DosyaYolu = @"C://Dosyalar//" + aktifKullanici.kisi + "/" + yeniad;
                File.Copy(kaynak, hedef + yeniad, true);
                btn_kimlik.Tag = hedef + yeniad;
                btn_kimlik.ForeColor = Color.Red;

            }
        }

        private void btn_myb_Click(object sender, EventArgs e)
        {
            if (btn_myb.Tag != null)
            {
                if (!String.IsNullOrWhiteSpace(btn_myb.Tag.ToString()))
                {
                    System.Diagnostics.Process.Start(btn_myb.Tag.ToString());
                    return;
                }
            }
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";

            if (dosya.ShowDialog() == DialogResult.OK)
            {
                kimlik_dosyaYolu = dosya.FileName;


                kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
                string kaynak = kimlik_dosyaYolu;
                string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
                MessageBox.Show(hedef);
                string yeniad = lbl_kisi.Text + "_" + btn_myb.Text + ".pdf"; //Benzersiz isim verme
                string DosyaYolu = @"C://Dosyalar//" + aktifKullanici.kisi + "/" + yeniad;
                File.Copy(kaynak, hedef + yeniad, true);
                btn_kimlik.Tag = hedef + yeniad;
                btn_kimlik.ForeColor = Color.Red;

            }
        }

        private void btn_myb2_Click(object sender, EventArgs e)
        {
            if (btn_myb2.Tag != null)
            {
                if (!String.IsNullOrWhiteSpace(btn_myb2.Tag.ToString()))
                {
                    System.Diagnostics.Process.Start(btn_myb2.Tag.ToString());
                    return;
                }
            }
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";

            if (dosya.ShowDialog() == DialogResult.OK)
            {
                kimlik_dosyaYolu = dosya.FileName;


                kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
                string kaynak = kimlik_dosyaYolu;
                string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
                MessageBox.Show(hedef);
                string yeniad = lbl_kisi.Text + "_" +btn_myb2.Text+ ".pdf"; //Benzersiz isim verme
                string DosyaYolu = @"C://Dosyalar//" + aktifKullanici.kisi + "/" + yeniad;
                File.Copy(kaynak, hedef + yeniad, true);
                btn_kimlik.Tag = hedef + yeniad;
                btn_kimlik.ForeColor = Color.Red;


            }                              
        }

        private void btn_dil_Click(object sender, EventArgs e)
        {
            if (btn_dil.Tag != null)
            {
                if (!String.IsNullOrWhiteSpace(btn_dil.Tag.ToString()))
                {
                    System.Diagnostics.Process.Start(btn_dil.Tag.ToString());
                    return;
                }
            }
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";

            if (dosya.ShowDialog() == DialogResult.OK)
            {

                kimlik_dosyaYolu = dosya.FileName;


                kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
                string kaynak = kimlik_dosyaYolu;
                string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
                MessageBox.Show(hedef);
                string yeniad = lbl_kisi.Text + "_" + btn_dil.Text + ".pdf"; //Benzersiz isim verme
                string DosyaYolu = @"C://Dosyalar//" + aktifKullanici.kisi + "/" + yeniad;
                File.Copy(kaynak, hedef + yeniad, true);
                btn_kimlik.Tag = hedef + yeniad;
                btn_kimlik.ForeColor = Color.Red;

            }
        }
        
        private void simpleButton2_Click(object sender, EventArgs e)
        {


            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";

            //bu kısımda dosyaları yenidenadlandırmadan atacağımız için varlıkkontolü yapmamız gerekmektedir.
            

            if (dosya.ShowDialog() == DialogResult.OK)
            {

                kimlik_dosyaYolu = dosya.FileName;


                kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
                string kaynak = kimlik_dosyaYolu;
                string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
                MessageBox.Show(hedef);
               // string yeniad = lbl_kisi.Text + "_" + btn_dil.Text + ".pdf"; //Benzersiz isim verme
                string DosyaYolu = @"C://Dosyalar//" + aktifKullanici.kisi + "/" ;
                string dosyaAdi = hedef + kimlik_dosyaAdi;
                if (System.IO.File.Exists(dosyaAdi))
                {
                    DialogResult result= MessageBox.Show("Dosya bulundu.Değiştirmek istiyor musunuz ?","Optimak İnsan Kaynakaları",MessageBoxButtons.YesNo,MessageBoxIcon.Error);
                     if(result==DialogResult.Yes)
                     { 
                        MessageBox.Show("dosya oluşturuluyor.");
                        
                        File.Copy(kaynak, hedef + kimlik_dosyaAdi,true);
                        btn_kimlik.Tag = hedef;
                        btn_kimlik.ForeColor = Color.Red;
                     }
                    else
                    {
                        MessageBox.Show("dosya oluşturulmadı.");
                    }
                }
                else
                {
                    MessageBox.Show("dosya oluşturuluyor.");
                    File.Copy(kaynak, hedef + kimlik_dosyaAdi);
                    btn_kimlik.Tag = hedef;
                    btn_kimlik.ForeColor = Color.Red;
                }
                
               


            }
        }
        private void btn_tamamlandi_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /*
        private void btn_kimlik_DoubleClick(object sender, EventArgs e)
        {
                string yeniad = lbl_kisi.Text + "_" + btn_kimlik.Text + ".pdf"; //Benzersiz isim verme
                string DosyaYolu = @"C://Dosyalar//" + aktifKullanici.kisi + "/" + yeniad;
                if (System.IO.File.Exists(DosyaYolu))
                {
                    MessageBox.Show("dosya bulundu.");
                }
                else
                {
                    MessageBox.Show("dosya oluşturuluyor.");
                    File.Copy(kaynak, hedef + yeniad);
                }
            }

        }

        */

        

        private void popup_btn_EvrakKaldir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // evrak kaldırma popup kodu buraya gelecek
            if (this.ActiveControl != null)
            {
                if (!String.IsNullOrWhiteSpace(this.ActiveControl.Tag.ToString()))
                {
                    if (File.Exists(this.ActiveControl.Tag.ToString()))
                    {
                        File.Delete(this.ActiveControl.Tag.ToString());
                    }
                    this.ActiveControl.Tag = "";
                    this.ActiveControl.ForeColor = Color.Black;
                }
                
            }
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = listBox1.GetItemText(listBox1.SelectedItem);
            //System.Diagnostics.Process.Start(btn_dil.Tag.ToString());
            //System.Diagnostics.Process.Start(listBox1.SelectedItem.ToString());
            MessageBox.Show(select);
            //FileStream fileStream = new FileStream(@"C://Dosyalar//" + aktifKullanici.kisi + "/"+select, FileMode.Open);
            //string yol = @"C://Dosyalar//" + aktifKullanici.kisi + "/" + select;
            

           // System.Diagnostics.Process.Start(listBox1.SelectedItem.ToString());


            try
            {
                // string yol = @"C://Dosyalar//" + aktifKullanici.kisi + "/" + select;
                string dir = @"C://Dosyalar//" + aktifKullanici.kisi + "/";
               // MessageBox.Show(dir);
                string file = listBox1.SelectedItem.ToString();
                string DosyaYolu = @"C://Dosyalar//" + aktifKullanici.kisi + "/" + listBox1.SelectedItem.ToString();

               // MessageBox.Show(DosyaYolu);
                //MessageBox.Show(file) ;

                System.Diagnostics.Process.Start(DosyaYolu);


            }
            catch
            {

                MessageBox.Show("Dosya Göstermede Hata Oluştu...");
            }

        }
    }
}

