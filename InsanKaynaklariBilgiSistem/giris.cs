using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//veri tabanı ile bağlantı kurulacağı için System.dataçoledb  kütüphanesi eklenmesi gerekir.
//using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

namespace InsanKaynaklariBilgiSistem
{
    public partial class giris : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public giris()
        {
            InitializeComponent();
            Init_Data();

        }
        //veri tabanı yolu ve provider nesnesinin tanımlanması gerekmektedir.
        // OleDbConnection baglantim = new OleDbConnection ();
        sqlBaglantisi baglantim = new sqlBaglantisi();
        
        

        //bu noktada yerel ve formlar arası kullanıacak olan değişkenler tanımlanacaktır.
        //formlar arası veri aktarımında kullanılacaklar değişkenler ;

        public static string tcno, adi, soyadi, yetki;
        bool durum = false;

        

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (hak!=0)//kullanıcının girme hakkı var ise 
            {
                //kullanıcının giriş hakkı var ise giriş yaptığında veri tabanı ile bağlantı kurulup sorgu oluşturulur.
               // baglantim.baglanti().Open();
               SqlCommand eklemesorgusu = new SqlCommand("select*from hesap_olustur", baglantim.baglanti());//veri tabanındaki tüm kayıtları getirdik.
                //veri tabanından veri okumammız gerekmektedir.
                SqlDataReader kayitokuma = eklemesorgusu.ExecuteReader();//getirilen tüm kayıtlar kayit okumaya aktarıldı.

                while(kayitokuma.Read())
                {
                   // if (radioButton1.Checked==true)
                    {
                        if (kayitokuma["kullanici_Adi"].ToString() == textBox1.Text && kayitokuma ["parola"].ToString()==textBox2.Text )
                        // if (kayitokuma["kullaniciadi"].ToString() == textBox1.Text && kayitokuma["parola"].ToString() == textBox2.Text && kayitokuma["yetki"].ToString() == "Yönetici")
                            {
                            //beni hatırla 
                            /*if(checkBox1.Checked==true)
                            {
                                StreamWriter writer = new StreamWriter("setting.txt");
                                writer.Write(kayitokuma("kullaniciadi"));
                            }*/
                            //başırılı bir girişişlemi yapıldı se burası çalışır.
                            durum = true;

                            tcno = kayitokuma.GetValue(1).ToString();//kayıt okuma belleğe aktarılmıştı bir üst tarafta.while döngüsü ile şartlar sağlandığında giriş yapılmıştı 
                                                                     //şimdi giriş yapılan ilgili kullanıcının acseste tcnosu ilk sutunda olduğu için ve veri sisteminde 0 dan başladığı için getvalue(0) oldu.
                            aktifKullanici.tcno = tcno;//clasdaki tc ye buradaki tc yi atadık.
                            MessageBox.Show("TC", aktifKullanici.tcno);
                          
                            adi = kayitokuma.GetValue(2).ToString();
                            soyadi = kayitokuma.GetValue(3).ToString();
                            yetki = kayitokuma.GetValue(4).ToString();
                            



                            this.Hide();//kullanıcı başarılı bir şekilde giriş yapabildiği için bu form gizlenip form 2 ye geçiş yapılacaktır.
                            ekran frm4 = new ekran();
                            frm4.Show();
                            kullaniciHesap frm8 = new kullaniciHesap();
                            if (textBox1.Text=="Admin")
                            {
                                //   kullaniciHesap frm8=new kullaniciHesap()
                                frm8.Enabled = false;
                            }
                            break;
                        }
                    }

                   /* if (radioButton2.Checked == true)
                    {
                        if (kayitokuma["kullaniciadi"].ToString() == textBox1.Text && kayitokuma["parola"].ToString() == textBox2.Text && kayitokuma["yetki"].ToString() == "Kullanici")
                        {
                            //başırılı bir girişişlemi yapıldı se burası çalışır.
                            durum = true;

                            tcno = kayitokuma.GetValue(0).ToString();//kayıt okuma belleğe aktarılmıştı bir üst tarafta.while döngüsü ile şartlar sağlandığında giriş yapılmıştı 
                            //şimdi giriş yapılan ilgili kullanıcının acseste tcnosu ilk sutunda olduğu için ve veri sisteminde 0 dan başladığı için getvalue(0) oldu.
                            adi = kayitokuma.GetValue(1).ToString();
                            soyadi = kayitokuma.GetValue(2).ToString();
                            yetki = kayitokuma.GetValue(3).ToString();
                            this.Hide();//kullanıcı başarılı bir şekilde giriş yapabildiği için bu form gizlenip form 2 ye geçiş yapılacaktır.
                            Form3 frm3 = new Form3();
                            frm3.Show();
                            break;
                        }
                    }*/
                }
                if (durum == false)
                    hak--;
               
            }
            

            label5.Text = Convert.ToString(hak);
            if(hak==0)
            {
                button1.Enabled = false;
                MessageBox.Show("Giriş hakkınız kalmadı", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }


        //burada tanımlanan değişkenler acses deki değişkenler ile aynı olmak zorunda değil ileride eşleştirlecektir.

        //yerel yani yalnızca bu formda geçerli olacak değişkenleri tanımlayalım.
        //durum kullanıcının varlığını kontol ederken her kullanıcı için 3 hak veriyor.
        int hak = 3; 
        //kullanıcı sorgulama için  bool durum kullanılıyacak.
        private void Form1_Load(object sender, EventArgs e)
        {
           
            this.Text = "Kullanıcı Girişi ";
            this.AcceptButton = button1;//enter tuşuna basıldığında giriş diye tepki versin.
            this.CancelButton = button2;//esc tuşuna basıldığında çıkış diye tepki versin.
            label5.Text = Convert.ToString(hak);
           /// radioButton1.Checked = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;//(x) harici diğer üst tuşları pasif etmek için kullanılır.
        }


        private void save_Data()//beni hatırla işaretli ise şifre ve kullanıcı adı hafızaya alınacaktır
        {
            if (checkBox1.Checked)
            {
                Properties.Settings.Default.UserName = textBox1.Text;
                Properties.Settings.Default.Password = textBox2.Text;
                Properties.Settings.Default.Remember = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.UserName = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Remember = false;
                Properties.Settings.Default.Save();
            }
        }

        private void Init_Data()
        {
            if(Properties.Settings.Default.UserName!=string.Empty)
            {
                if (Properties.Settings.Default.Remember == true)
                {
                    textBox1.Text = Properties.Settings.Default.UserName;
                    textBox2.Text = Properties.Settings.Default.Password;
                    checkBox1.Checked = true;
                }
                else
                {
                    textBox1.Text = Properties.Settings.Default.UserName;
                }
            }
        }
    }
}
