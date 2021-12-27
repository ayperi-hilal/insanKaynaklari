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
        private void evrakEkleme_Load(object sender, EventArgs e)
        {
            lbl_kisi.Text = aktifKullanici.kisi;
            MessageBox.Show(lbl_kisi.Text);
        }

        private void btn_kimlik_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";
            dosya.ShowDialog();
            kimlik_dosyaYolu = dosya.FileName;

            
                kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
                string kaynak = kimlik_dosyaYolu;
                string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
                MessageBox.Show(hedef);
                string yeniad = lbl_kisi.Text + "_" + btn_kimlik.Text + ".pdf"; //Benzersiz isim verme
            l_lbl_kimlik.Text = yeniad;
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

        private void btn_akciger_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";
            dosya.ShowDialog();
            kimlik_dosyaYolu = dosya.FileName;


            kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
            string kaynak = kimlik_dosyaYolu;
            string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
            MessageBox.Show(hedef);
            string yeniad = lbl_kisi.Text + "_" + btn_akciger.Text + ".pdf"; //Benzersiz isim verme
            l_lbl_akciger.Text = yeniad;
            if (System.IO.File.Exists(yeniad))
            {
                MessageBox.Show("dosya bulundu.");
            }
            else
            {
                MessageBox.Show("dosya oluşturuluyor.");
                File.Copy(kaynak, hedef + yeniad);
            }

        }

        private void btn_tetanoz_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";
            dosya.ShowDialog();
            kimlik_dosyaYolu = dosya.FileName;


            kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
            string kaynak = kimlik_dosyaYolu;
            string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
            MessageBox.Show(hedef);
            string yeniad = lbl_kisi.Text + "_" + btn_tetanoz.Text + ".pdf"; //Benzersiz isim verme
            l_lbl_tetanoz.Text = yeniad;
            if (System.IO.File.Exists(yeniad))
            {
                MessageBox.Show("dosya bulundu.");
            }
            else
            {
                MessageBox.Show("dosya oluşturuluyor.");
                File.Copy(kaynak, hedef + yeniad);
            }
        }

        private void btn_kan_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";
            dosya.ShowDialog();
            kimlik_dosyaYolu = dosya.FileName;


            kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
            string kaynak = kimlik_dosyaYolu;
            string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
            MessageBox.Show(hedef);
            string yeniad = lbl_kisi.Text + "_" + btn_kan.Text + ".pdf"; //Benzersiz isim verme
            l_lbl_kan.Text = yeniad;
            if (System.IO.File.Exists(yeniad))
            {
                MessageBox.Show("dosya bulundu.");
            }
            else
            {
                MessageBox.Show("dosya oluşturuluyor.");
                File.Copy(kaynak, hedef + yeniad);
            }
        }

        private void btn_muayene_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";
            dosya.ShowDialog();
            kimlik_dosyaYolu = dosya.FileName;


            kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
            string kaynak = kimlik_dosyaYolu;
            string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
            MessageBox.Show(hedef);
            string yeniad = lbl_kisi.Text + "_" + btn_muayene.Text + ".pdf"; //Benzersiz isim verme
            l_lbl_muayene.Text = yeniad;
            if (System.IO.File.Exists(yeniad))
            {
                MessageBox.Show("dosya bulundu.");
            }
            else
            {
                MessageBox.Show("dosya oluşturuluyor.");
                File.Copy(kaynak, hedef + yeniad);
            }
        }

        private void btn_odyogram_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";
            dosya.ShowDialog();
            kimlik_dosyaYolu = dosya.FileName;


            kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
            string kaynak = kimlik_dosyaYolu;
            string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
            MessageBox.Show(hedef);
            string yeniad = lbl_kisi.Text + "_" + btn_odyogram.Text + ".pdf"; //Benzersiz isim verme
            l_lbl_odyo.Text = yeniad;
            if (System.IO.File.Exists(yeniad))
            {
                MessageBox.Show("dosya bulundu.");
            }
            else
            {
                MessageBox.Show("dosya oluşturuluyor.");
                File.Copy(kaynak, hedef + yeniad);
            }
        }

        private void btn_hepaitit_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";
            dosya.ShowDialog();
            kimlik_dosyaYolu = dosya.FileName;


            kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
            string kaynak = kimlik_dosyaYolu;
            string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
            MessageBox.Show(hedef);
            string yeniad = lbl_kisi.Text + "_" + btn_hepaitit.Text + ".pdf"; //Benzersiz isim verme
            l_lbl_hepatit.Text = yeniad;
            if (System.IO.File.Exists(yeniad))
            {
                MessageBox.Show("dosya bulundu.");
            }
            else
            {
                MessageBox.Show("dosya oluşturuluyor.");
                File.Copy(kaynak, hedef + yeniad);
            }
        }

        private void btn_diploma_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";
            dosya.ShowDialog();
            kimlik_dosyaYolu = dosya.FileName;


            kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
            string kaynak = kimlik_dosyaYolu;
            string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
            MessageBox.Show(hedef);
            string yeniad = lbl_kisi.Text + "_" + btn_diploma.Text + ".pdf"; //Benzersiz isim verme
            l_lbl_diploma.Text = yeniad;
            if (System.IO.File.Exists(yeniad))
            {
                MessageBox.Show("dosya bulundu.");
            }
            else
            {
                MessageBox.Show("dosya oluşturuluyor.");
                File.Copy(kaynak, hedef + yeniad);
            }
        }

        private void btn_ikametgah_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";
            dosya.ShowDialog();
            kimlik_dosyaYolu = dosya.FileName;


            kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
            string kaynak = kimlik_dosyaYolu;
            string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
            MessageBox.Show(hedef);
            string yeniad = lbl_kisi.Text + "_" + btn_ikametgah.Text + ".pdf"; //Benzersiz isim verme
            l_lbl_ikametgah.Text = yeniad;
            if (System.IO.File.Exists(yeniad))
            {
                MessageBox.Show("dosya bulundu.");
            }
            else
            {
                MessageBox.Show("dosya oluşturuluyor.");
                File.Copy(kaynak, hedef + yeniad);
            }
        }

        private void btn_sabika_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";
            dosya.ShowDialog();
            kimlik_dosyaYolu = dosya.FileName;


            kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
            string kaynak = kimlik_dosyaYolu;
            string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
            MessageBox.Show(hedef);
            string yeniad = lbl_kisi.Text + "_" + btn_sabika.Text + ".pdf"; //Benzersiz isim verme
            l_lbl_sabika.Text = yeniad;
            if (System.IO.File.Exists(yeniad))
            {
                MessageBox.Show("dosya bulundu.");
            }
            else
            {
                MessageBox.Show("dosya oluşturuluyor.");
                File.Copy(kaynak, hedef + yeniad);
            }
        }

        private void btn_sgk_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";
            dosya.ShowDialog();
            kimlik_dosyaYolu = dosya.FileName;


            kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
            string kaynak = kimlik_dosyaYolu;
            string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
            MessageBox.Show(hedef);
            string yeniad = lbl_kisi.Text + "_" + btn_sgk.Text + ".pdf"; //Benzersiz isim verme
            l_lbl_sgk.Text = yeniad;
            if (System.IO.File.Exists(yeniad))
            {
                MessageBox.Show("dosya bulundu.");
            }
            else
            {
                MessageBox.Show("dosya oluşturuluyor.");
                File.Copy(kaynak, hedef + yeniad);
            }
        }

        private void btn_isg_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";
            dosya.ShowDialog();
            kimlik_dosyaYolu = dosya.FileName;


            kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
            string kaynak = kimlik_dosyaYolu;
            string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
            MessageBox.Show(hedef);
            string yeniad = lbl_kisi.Text + "_" + btn_isg.Text + ".pdf"; //Benzersiz isim verme
            l_lbl_isg.Text = yeniad;
            if (System.IO.File.Exists(yeniad))
            {
                MessageBox.Show("dosya bulundu.");
            }
            else
            {
                MessageBox.Show("dosya oluşturuluyor.");
                File.Copy(kaynak, hedef + yeniad);
            }
        }

        private void btn_myb_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";
            dosya.ShowDialog();
            kimlik_dosyaYolu = dosya.FileName;


            kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
            string kaynak = kimlik_dosyaYolu;
            string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
            MessageBox.Show(hedef);
            string yeniad = lbl_kisi.Text + "_" + btn_myb.Text + ".pdf"; //Benzersiz isim verme
            l_lbl_myb1.Text = yeniad;
            if (System.IO.File.Exists(yeniad))
            {
                MessageBox.Show("dosya bulundu.");
            }
            else
            {
                MessageBox.Show("dosya oluşturuluyor.");
                File.Copy(kaynak, hedef + yeniad);
            }
        }

        private void btn_myb2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";
            dosya.ShowDialog();
            kimlik_dosyaYolu = dosya.FileName;


            kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
            string kaynak = kimlik_dosyaYolu;
            string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
            MessageBox.Show(hedef);
            string yeniad = lbl_kisi.Text + "_" + btn_myb2.Text + ".pdf"; //Benzersiz isim verme
            l_lbl_myb2.Text = yeniad;
            if (System.IO.File.Exists(yeniad))
            {
                MessageBox.Show("dosya bulundu.");
            }
            else
            {
                MessageBox.Show("dosya oluşturuluyor.");
                File.Copy(kaynak, hedef + yeniad);
            }
        }

        private void btn_dil_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "PDF Dosyaları(*.pdf)|*.pdf|Tüm Dosyalar|*.*";
            dosya.ShowDialog();
            kimlik_dosyaYolu = dosya.FileName;


            kimlik_dosyaAdi = Path.GetFileName(kimlik_dosyaYolu); //Dosya adını alma
            string kaynak = kimlik_dosyaYolu;
            string hedef = (@"C://Dosyalar//" + aktifKullanici.kisi + "/");
            MessageBox.Show(hedef);
            string yeniad = lbl_kisi.Text + "_" + btn_dil.Text + ".pdf"; //Benzersiz isim verme
            l_lbl_dil.Text = yeniad;
            if (System.IO.File.Exists(yeniad))
            {
                MessageBox.Show("dosya bulundu.");
            }
            else
            {
                MessageBox.Show("dosya oluşturuluyor.");
                File.Copy(kaynak, hedef + yeniad);
            }
        }

        private void btn_tamamlandi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}

