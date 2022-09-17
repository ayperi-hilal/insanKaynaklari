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
using System.Windows.Forms.DataVisualization.Charting;

namespace InsanKaynaklariBilgiSistem
{
    public partial class perfomansDurumu : Form
    {
        public perfomansDurumu()
        {
            InitializeComponent();

        }

        sqlBaglantisi baglantim = new sqlBaglantisi();

        private void perfomansDurumu_Load(object sender, EventArgs e)
        {
            cbx_calisan_grubu.Items.Add("Grup Seçiniz...");
            cbx_calisan_grubu.Items.Add("YENİ PERSONEL");
            cbx_calisan_grubu.Items.Add("TECRÜBELİ PERSONEL");

            cbx_calisan_grubu.SelectedIndex = 0;

            txt_harf1.Enabled = false;
            txt_harf2.Enabled = false;
            txt_harf3.Enabled = false;
            txt_harf4.Enabled = false;
            txt_harf5.Enabled = false;
            txt_harf6.Enabled = false;
            txt_harf7.Enabled = false;
            txt_harf8.Enabled = false;
            txt_harf9.Enabled = false;
            txt_harf10.Enabled = false;
            txt_harf11.Enabled = false;
            txt_harf12.Enabled = false;


            DateTime zaman = DateTime.Now;
            int yil = int.Parse(zaman.ToString("yyyy"));
            int ay = int.Parse(zaman.ToString("MM"));
            int gun = int.Parse(zaman.ToString("dd"));


            for (int i = 2020; i <= yil; i++)
            {
                cb_yil_1.Items.Add(i);
                cb_yil_2.Items.Add(i);
                cb_yil_3.Items.Add(i);
                cb_yil_4.Items.Add(i);
                cb_yil_5.Items.Add(i);
                cb_yil_6.Items.Add(i);
                cb_yil_7.Items.Add(i);
                cb_yil_8.Items.Add(i);
                cb_yil_9.Items.Add(i);
                cb_yil_10.Items.Add(i);
                cb_yil_11.Items.Add(i);
                cb_yil_12.Items.Add(i);
                cb_yil_sec.Items.Add(i);
            }

            mtxt_tc_no.Mask = "00000000000";//kullnıcı 11 haneli tc numarası girebilecek.

            //cb_1.Items.Add("1");
            //cb_1.Items.Add("2");
            //cb_1.Items.Add("3");
            //cb_1.Items.Add("4");
            //cb_1.Items.Add("5");
            //cb_1.Items.Add("6");
            //cb_1.Items.Add("7");
            //cb_1.Items.Add("8");
            //cb_1.Items.Add("9");
            //cb_1.Items.Add("10");
            //cb_1.Items.Add("11");
            //cb_1.Items.Add("12");

            //cb_2.Items.Add("1");
            //cb_2.Items.Add("2");
            //cb_2.Items.Add("3");
            //cb_2.Items.Add("4");
            //cb_2.Items.Add("5");
            //cb_2.Items.Add("6");
            //cb_2.Items.Add("7");
            //cb_2.Items.Add("8");
            //cb_2.Items.Add("9");
            //cb_2.Items.Add("10");
            //cb_2.Items.Add("11");
            //cb_2.Items.Add("12");


            for (int i = 1; i <= 12; i++)
            {
                cb_1.Items.Add(i);
                cb_2.Items.Add(i);
                cb_3.Items.Add(i);
                cb_4.Items.Add(i);
                cb_5.Items.Add(i);
                cb_6.Items.Add(i);
                cb_7.Items.Add(i);
                cb_8.Items.Add(i);
                cb_9.Items.Add(i);
                cb_10.Items.Add(i);
                cb_11.Items.Add(i);
                cb_12.Items.Add(i);

            }

        }

        private void cbx_calisan_grubu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_sayi1_TextChanged(object sender, EventArgs e)
        {
            if (cbx_calisan_grubu.Text == "TECRÜBELİ PERSONEL")
            {
                if (txt_sayi1.Text.Length > 0)
                {


                    int sayi1 = Convert.ToInt32(txt_sayi1.Text);
                    if (0 <= sayi1 && sayi1 < 36)
                    {
                        txt_harf1.Text = "E";
                        lbl_1.Text = "BAŞARISIZ";
                    }
                    else if (36 <= sayi1 && sayi1 < 60)
                    {
                        txt_harf1.Text = "D";
                        lbl_1.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                    }
                    else if (60 <= sayi1 && sayi1 < 80)
                    {
                        txt_harf1.Text = "C";
                        lbl_1.Text = "NORMAL";
                    }
                    else if (80 <= sayi1 && sayi1 < 90)
                    {
                        txt_harf1.Text = "B";
                        lbl_1.Text = "İYİ";
                    }

                    else if (90 <= sayi1 && sayi1 <= 100)
                    {
                        txt_harf1.Text = "A";
                        lbl_1.Text = "ÇOK İYİ";
                    }
                    else if (sayi1 < 0 || sayi1 > 100)
                    {
                        txt_harf1.Text = "";
                        lbl_1.Text = "";
                        txt_sayi1.ForeColor = Color.Red;

                    }

                }
                else
                {
                    txt_harf1.Text = "";
                    lbl_1.Text = "";
                }
            }
            else if (cbx_calisan_grubu.Text == "YENİ PERSONEL")

            {
                if (txt_sayi1.Text.Length > 0)
                {

                    int sayi1 = Convert.ToInt32(txt_sayi1.Text);
                    if (0 <= sayi1 && sayi1 < 13)
                    {
                        txt_harf1.Text = "E";
                        lbl_1.Text = "BAŞARISIZ";
                    }
                    else if (13 <= sayi1 && sayi1 < 22)
                    {
                        txt_harf1.Text = "D";
                        lbl_1.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                    }
                    else if (22 <= sayi1 && sayi1 < 29)
                    {
                        txt_harf1.Text = "C";
                        lbl_1.Text = "NORMAL";
                    }
                    else if (29 <= sayi1 && sayi1 < 33)
                    {
                        txt_harf1.Text = "B";
                        lbl_1.Text = "İYİ";
                    }

                    else if (33 <= sayi1 && sayi1 <= 35)
                    {
                        txt_harf1.Text = "A";
                        lbl_1.Text = "ÇOK İYİ";
                    }
                    else if (sayi1 < 0 || sayi1 > 35)
                    {
                        txt_harf1.Text = "";
                        lbl_1.Text = "";
                        txt_sayi1.ForeColor = Color.Red;

                    }
                }
                else
                {
                    txt_harf1.Text = "";
                    lbl_1.Text = "";
                }
            }
            else
            {
                MessageBox.Show("ÇALIŞANIN GRUBUNU SEÇİNİZ.");
            }

        }

        private void txt_sayi2_TextChanged(object sender, EventArgs e)
        {
            if (cbx_calisan_grubu.Text == "TECRÜBELİ PERSONEL")
            {
                if (txt_sayi2.Text.Length > 0)
                {


                    int sayi2 = Convert.ToInt32(txt_sayi2.Text);
                    if (0 <= sayi2 && sayi2 < 36)
                    {
                        txt_harf2.Text = "E";
                        lbl_2.Text = "BAŞARISIZ";
                    }
                    else if (36 <= sayi2 && sayi2 < 60)
                    {
                        txt_harf2.Text = "D";
                        lbl_2.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                    }
                    else if (60 <= sayi2 && sayi2 < 80)
                    {
                        txt_harf2.Text = "C";
                        lbl_2.Text = "NORMAL";
                    }
                    else if (80 <= sayi2 && sayi2 < 90)
                    {
                        txt_harf2.Text = "B";
                        lbl_2.Text = "İYİ";
                    }

                    else if (90 <= sayi2 && sayi2 <= 100)
                    {
                        txt_harf2.Text = "A";
                        lbl_2.Text = "ÇOK İYİ";
                    }
                    else if (sayi2 < 0 || sayi2 > 100)
                    {
                        txt_harf2.Text = "";
                        lbl_2.Text = "";
                        txt_sayi2.ForeColor = Color.Red;

                    }

                }
                else
                {
                    txt_harf2.Text = "";
                    lbl_2.Text = "";
                }
            }
            else if (cbx_calisan_grubu.Text == "YENİ PERSONEL")

            {
                if (txt_sayi2.Text.Length > 0)
                {

                    int sayi2 = Convert.ToInt32(txt_sayi2.Text);
                    if (0 <= sayi2 && sayi2 < 13)
                    {
                        txt_harf2.Text = "E";
                        lbl_2.Text = "BAŞARISIZ";
                    }
                    else if (13 <= sayi2 && sayi2 < 22)
                    {
                        txt_harf2.Text = "D";
                        lbl_2.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                    }
                    else if (22 <= sayi2 && sayi2 < 29)
                    {
                        txt_harf2.Text = "C";
                        lbl_2.Text = "NORMAL";
                    }
                    else if (29 <= sayi2 && sayi2 < 33)
                    {
                        txt_harf2.Text = "B";
                        lbl_2.Text = "İYİ";
                    }

                    else if (33 <= sayi2 && sayi2 <= 35)
                    {
                        txt_harf2.Text = "A";
                        lbl_2.Text = "ÇOK İYİ";
                    }
                    else if (sayi2 < 0 || sayi2 > 35)
                    {
                        txt_harf2.Text = "";
                        lbl_2.Text = "";
                        txt_sayi2.ForeColor = Color.Red;

                    }
                }
                else
                {
                    txt_harf2.Text = "";
                    lbl_2.Text = "";
                }
            }
            else
            {
                MessageBox.Show("ÇALIŞANIN GRUBUNU SEÇİNİZ.");
            }

        }

        private void txt_sayi3_TextChanged(object sender, EventArgs e)
        {
            if (cbx_calisan_grubu.Text == "TECRÜBELİ PERSONEL")
            {
                if (txt_sayi3.Text.Length > 0)
                {


                    int sayi3 = Convert.ToInt32(txt_sayi3.Text);
                    if (0 <= sayi3 && sayi3 < 36)
                    {
                        txt_harf3.Text = "E";
                        lbl_3.Text = "BAŞARISIZ";
                    }
                    else if (36 <= sayi3 && sayi3 < 60)
                    {
                        txt_harf3.Text = "D";
                        lbl_3.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                    }
                    else if (60 <= sayi3 && sayi3 < 80)
                    {
                        txt_harf3.Text = "C";
                        lbl_3.Text = "NORMAL";
                    }
                    else if (80 <= sayi3 && sayi3 < 90)
                    {
                        txt_harf3.Text = "B";
                        lbl_3.Text = "İYİ";
                    }

                    else if (90 <= sayi3 && sayi3 <= 100)
                    {
                        txt_harf3.Text = "A";
                        lbl_3.Text = "ÇOK İYİ";
                    }
                    else if (sayi3 < 0 || sayi3 > 100)
                    {
                        txt_harf3.Text = "";
                        lbl_3.Text = "";
                        txt_sayi3.ForeColor = Color.Red;

                    }

                }
                else
                {
                    txt_harf3.Text = "";
                    lbl_3.Text = "";
                }
            }
            else if (cbx_calisan_grubu.Text == "YENİ PERSONEL")

            {
                if (txt_sayi3.Text.Length > 0)
                {

                    int sayi3 = Convert.ToInt32(txt_sayi3.Text);
                    if (0 <= sayi3 && sayi3 < 13)
                    {
                        txt_harf3.Text = "E";
                        lbl_3.Text = "BAŞARISIZ";
                    }
                    else if (13 <= sayi3 && sayi3 < 22)
                    {
                        txt_harf3.Text = "D";
                        lbl_3.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                    }
                    else if (22 <= sayi3 && sayi3 < 29)
                    {
                        txt_harf3.Text = "C";
                        lbl_3.Text = "NORMAL";
                    }
                    else if (29 <= sayi3 && sayi3 < 33)
                    {
                        txt_harf3.Text = "B";
                        lbl_3.Text = "İYİ";
                    }

                    else if (33 <= sayi3 && sayi3 <= 35)
                    {
                        txt_harf3.Text = "A";
                        lbl_3.Text = "ÇOK İYİ";
                    }
                    else if (sayi3 < 0 || sayi3 > 35)
                    {
                        txt_harf3.Text = "";
                        lbl_3.Text = "";
                        txt_sayi3.ForeColor = Color.Red;

                    }
                }
                else
                {
                    txt_harf3.Text = "";
                    lbl_3.Text = "";
                }
            }
            else
            {
                MessageBox.Show("ÇALIŞANIN GRUBUNU SEÇİNİZ.");
            }
        }

        private void txt_sayi4_TextChanged(object sender, EventArgs e)
        {
            if (cbx_calisan_grubu.Text == "TECRÜBELİ PERSONEL")
            {
                if (txt_sayi4.Text.Length > 0)
                {


                    int sayi4 = Convert.ToInt32(txt_sayi4.Text);
                    if (0 <= sayi4 && sayi4 < 36)
                    {
                        txt_harf4.Text = "E";
                        lbl_4.Text = "BAŞARISIZ";
                    }
                    else if (36 <= sayi4 && sayi4 < 60)
                    {
                        txt_harf4.Text = "D";
                        lbl_4.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                    }
                    else if (60 <= sayi4 && sayi4 < 80)
                    {
                        txt_harf4.Text = "C";
                        lbl_4.Text = "NORMAL";
                    }
                    else if (80 <= sayi4 && sayi4 < 90)
                    {
                        txt_harf4.Text = "B";
                        lbl_4.Text = "İYİ";
                    }

                    else if (90 <= sayi4 && sayi4 <= 100)
                    {
                        txt_harf4.Text = "A";
                        lbl_4.Text = "ÇOK İYİ";
                    }
                    else if (sayi4 < 0 || sayi4 > 100)
                    {
                        txt_harf4.Text = "";
                        lbl_4.Text = "";
                        txt_sayi4.ForeColor = Color.Red;

                    }

                }
                else
                {
                    txt_harf4.Text = "";
                    lbl_4.Text = "";
                }
            }
            else if (cbx_calisan_grubu.Text == "YENİ PERSONEL")

            {
                if (txt_sayi4.Text.Length > 0)
                {

                    int sayi4 = Convert.ToInt32(txt_sayi4.Text);
                    if (0 <= sayi4 && sayi4 < 13)
                    {
                        txt_harf4.Text = "E";
                        lbl_4.Text = "BAŞARISIZ";
                    }
                    else if (13 <= sayi4 && sayi4 < 22)
                    {
                        txt_harf4.Text = "D";
                        lbl_4.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                    }
                    else if (22 <= sayi4 && sayi4 < 29)
                    {
                        txt_harf4.Text = "C";
                        lbl_4.Text = "NORMAL";
                    }
                    else if (29 <= sayi4 && sayi4 < 33)
                    {
                        txt_harf4.Text = "B";
                        lbl_4.Text = "İYİ";
                    }

                    else if (33 <= sayi4 && sayi4 <= 35)
                    {
                        txt_harf4.Text = "A";
                        lbl_4.Text = "ÇOK İYİ";
                    }
                    else if (sayi4 < 0 || sayi4 > 35)
                    {
                        txt_harf4.Text = "";
                        lbl_4.Text = "";
                        txt_sayi4.ForeColor = Color.Red;

                    }
                }
                else
                {
                    txt_harf4.Text = "";
                    lbl_4.Text = "";
                }
            }
            else
            {
                MessageBox.Show("ÇALIŞANIN GRUBUNU SEÇİNİZ.");
            }
        }

        private void txt_sayi5_TextChanged(object sender, EventArgs e)
        {
            if (cbx_calisan_grubu.Text == "TECRÜBELİ PERSONEL")
            {
                if (txt_sayi5.Text.Length > 0)
                {


                    int sayi5 = Convert.ToInt32(txt_sayi5.Text);
                    if (0 <= sayi5 && sayi5 < 36)
                    {
                        txt_harf5.Text = "E";
                        lbl_5.Text = "BAŞARISIZ";
                    }
                    else if (36 <= sayi5 && sayi5 < 60)
                    {
                        txt_harf5.Text = "D";
                        lbl_5.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                    }
                    else if (60 <= sayi5 && sayi5 < 80)
                    {
                        txt_harf5.Text = "C";
                        lbl_5.Text = "NORMAL";
                    }
                    else if (80 <= sayi5 && sayi5 < 90)
                    {
                        txt_harf5.Text = "B";
                        lbl_5.Text = "İYİ";
                    }

                    else if (90 <= sayi5 && sayi5 <= 100)
                    {
                        txt_harf5.Text = "A";
                        lbl_5.Text = "ÇOK İYİ";
                    }
                    else if (sayi5 < 0 || sayi5 > 100)
                    {
                        txt_harf5.Text = "";
                        lbl_5.Text = "";
                        txt_sayi5.ForeColor = Color.Red;

                    }

                }
                else
                {
                    txt_harf5.Text = "";
                    lbl_5.Text = "";
                }
            }
            else if (cbx_calisan_grubu.Text == "YENİ PERSONEL")

            {
                if (txt_sayi5.Text.Length > 0)
                {

                    int sayi5 = Convert.ToInt32(txt_sayi5.Text);
                    if (0 <= sayi5 && sayi5 < 13)
                    {
                        txt_harf5.Text = "E";
                        lbl_5.Text = "BAŞARISIZ";
                    }
                    else if (13 <= sayi5 && sayi5 < 22)
                    {
                        txt_harf5.Text = "D";
                        lbl_5.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                    }
                    else if (22 <= sayi5 && sayi5 < 29)
                    {
                        txt_harf5.Text = "C";
                        lbl_5.Text = "NORMAL";
                    }
                    else if (29 <= sayi5 && sayi5 < 33)
                    {
                        txt_harf5.Text = "B";
                        lbl_5.Text = "İYİ";
                    }

                    else if (33 <= sayi5 && sayi5 <= 35)
                    {
                        txt_harf5.Text = "A";
                        lbl_5.Text = "ÇOK İYİ";
                    }
                    else if (sayi5 < 0 || sayi5 > 35)
                    {
                        txt_harf5.Text = "";
                        lbl_5.Text = "";
                        txt_sayi5.ForeColor = Color.Red;

                    }
                }
                else
                {
                    txt_harf5.Text = "";
                    lbl_5.Text = "";
                }
            }
            else
            {
                MessageBox.Show("ÇALIŞANIN GRUBUNU SEÇİNİZ.");
            }
        }

        private void txt_sayi6_TextChanged(object sender, EventArgs e)
        {
            if (cbx_calisan_grubu.Text == "TECRÜBELİ PERSONEL")
            {
                if (txt_sayi6.Text.Length > 0)
                {


                    int sayi6 = Convert.ToInt32(txt_sayi6.Text);
                    if (0 <= sayi6 && sayi6 < 36)
                    {
                        txt_harf6.Text = "E";
                        lbl_6.Text = "BAŞARISIZ";
                    }
                    else if (36 <= sayi6 && sayi6 < 60)
                    {
                        txt_harf6.Text = "D";
                        lbl_6.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                    }
                    else if (60 <= sayi6 && sayi6 < 80)
                    {
                        txt_harf6.Text = "C";
                        lbl_6.Text = "NORMAL";
                    }
                    else if (80 <= sayi6 && sayi6 < 90)
                    {
                        txt_harf6.Text = "B";
                        lbl_6.Text = "İYİ";
                    }

                    else if (90 <= sayi6 && sayi6 <= 100)
                    {
                        txt_harf6.Text = "A";
                        lbl_6.Text = "ÇOK İYİ";
                    }
                    else if (sayi6 < 0 || sayi6 > 100)
                    {
                        txt_harf6.Text = "";
                        lbl_6.Text = "";
                        txt_sayi6.ForeColor = Color.Red;

                    }

                }
                else
                {
                    txt_harf6.Text = "";
                    lbl_6.Text = "";
                }
            }
            else if (cbx_calisan_grubu.Text == "YENİ PERSONEL")

            {
                if (txt_sayi6.Text.Length > 0)
                {

                    int sayi6 = Convert.ToInt32(txt_sayi6.Text);
                    if (0 <= sayi6 && sayi6 < 13)
                    {
                        txt_harf6.Text = "E";
                        lbl_6.Text = "BAŞARISIZ";
                    }
                    else if (13 <= sayi6 && sayi6 < 22)
                    {
                        txt_harf6.Text = "D";
                        lbl_6.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                    }
                    else if (22 <= sayi6 && sayi6 < 29)
                    {
                        txt_harf6.Text = "C";
                        lbl_6.Text = "NORMAL";
                    }
                    else if (29 <= sayi6 && sayi6 < 33)
                    {
                        txt_harf6.Text = "B";
                        lbl_6.Text = "İYİ";
                    }

                    else if (33 <= sayi6 && sayi6 <= 35)
                    {
                        txt_harf6.Text = "A";
                        lbl_6.Text = "ÇOK İYİ";
                    }
                    else if (sayi6 < 0 || sayi6 > 35)
                    {
                        txt_harf6.Text = "";
                        lbl_6.Text = "";
                        txt_sayi6.ForeColor = Color.Red;

                    }
                }
                else
                {
                    txt_harf6.Text = "";
                    lbl_6.Text = "";
                }
            }
            else
            {
                MessageBox.Show("ÇALIŞANIN GRUBUNU SEÇİNİZ.");
            }
        }

        private void txt_sayi7_TextChanged(object sender, EventArgs e)
        {
            if (cbx_calisan_grubu.Text == "TECRÜBELİ PERSONEL")
            {
                if (txt_sayi7.Text.Length > 0)
                {


                    int sayi7 = Convert.ToInt32(txt_sayi7.Text);
                    if (0 <= sayi7 && sayi7 < 36)
                    {
                        txt_harf7.Text = "E";
                        lbl_7.Text = "BAŞARISIZ";
                    }
                    else if (36 <= sayi7 && sayi7 < 60)
                    {
                        txt_harf7.Text = "D";
                        lbl_7.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                    }
                    else if (60 <= sayi7 && sayi7 < 80)
                    {
                        txt_harf7.Text = "C";
                        lbl_7.Text = "NORMAL";
                    }
                    else if (80 <= sayi7 && sayi7 < 90)
                    {
                        txt_harf7.Text = "B";
                        lbl_7.Text = "İYİ";
                    }

                    else if (90 <= sayi7 && sayi7 <= 100)
                    {
                        txt_harf7.Text = "A";
                        lbl_7.Text = "ÇOK İYİ";
                    }
                    else if (sayi7 < 0 || sayi7 > 100)
                    {
                        txt_harf7.Text = "";
                        lbl_7.Text = "";
                        txt_sayi7.ForeColor = Color.Red;

                    }

                }
                else
                {
                    txt_harf7.Text = "";
                    lbl_7.Text = "";
                }
            }
            else if (cbx_calisan_grubu.Text == "YENİ PERSONEL")

            {
                if (txt_sayi7.Text.Length > 0)
                {

                    int sayi7 = Convert.ToInt32(txt_sayi7.Text);
                    if (0 <= sayi7 && sayi7 < 13)
                    {
                        txt_harf7.Text = "E";
                        lbl_7.Text = "BAŞARISIZ";
                    }
                    else if (13 <= sayi7 && sayi7 < 22)
                    {
                        txt_harf7.Text = "D";
                        lbl_7.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                    }
                    else if (22 <= sayi7 && sayi7 < 29)
                    {
                        txt_harf7.Text = "C";
                        lbl_7.Text = "NORMAL";
                    }
                    else if (29 <= sayi7 && sayi7 < 33)
                    {
                        txt_harf7.Text = "B";
                        lbl_7.Text = "İYİ";
                    }

                    else if (33 <= sayi7 && sayi7 <= 35)
                    {
                        txt_harf7.Text = "A";
                        lbl_7.Text = "ÇOK İYİ";
                    }
                    else if (sayi7 < 0 || sayi7 > 35)
                    {
                        txt_harf7.Text = "";
                        lbl_7.Text = "";
                        txt_sayi7.ForeColor = Color.Red;

                    }
                }
                else
                {
                    txt_harf7.Text = "";
                    lbl_7.Text = "";
                }
            }
            else
            {
                MessageBox.Show("ÇALIŞANIN GRUBUNU SEÇİNİZ.");
            }
        }

        private void txt_sayi8_TextChanged(object sender, EventArgs e)
        {
            if (cbx_calisan_grubu.Text == "TECRÜBELİ PERSONEL")
            {
                if (txt_sayi8.Text.Length > 0)
                {


                    int sayi8 = Convert.ToInt32(txt_sayi8.Text);
                    if (0 <= sayi8 && sayi8 < 36)
                    {
                        txt_harf8.Text = "E";
                        lbl_8.Text = "BAŞARISIZ";
                    }
                    else if (36 <= sayi8 && sayi8 < 60)
                    {
                        txt_harf8.Text = "D";
                        lbl_8.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                    }
                    else if (60 <= sayi8 && sayi8 < 80)
                    {
                        txt_harf8.Text = "C";
                        lbl_8.Text = "NORMAL";
                    }
                    else if (80 <= sayi8 && sayi8 < 90)
                    {
                        txt_harf8.Text = "B";
                        lbl_8.Text = "İYİ";
                    }

                    else if (90 <= sayi8 && sayi8 <= 100)
                    {
                        txt_harf8.Text = "A";
                        lbl_8.Text = "ÇOK İYİ";
                    }
                    else if (sayi8 < 0 || sayi8 > 100)
                    {
                        txt_harf8.Text = "";
                        lbl_8.Text = "";
                        txt_sayi8.ForeColor = Color.Red;

                    }

                }
                else
                {
                    txt_harf8.Text = "";
                    lbl_8.Text = "";
                }
            }
            else if (cbx_calisan_grubu.Text == "YENİ PERSONEL")

            {
                if (txt_sayi8.Text.Length > 0)
                {

                    int sayi8 = Convert.ToInt32(txt_sayi8.Text);
                    if (0 <= sayi8 && sayi8 < 13)
                    {
                        txt_harf8.Text = "E";
                        lbl_8.Text = "BAŞARISIZ";
                    }
                    else if (13 <= sayi8 && sayi8 < 22)
                    {
                        txt_harf8.Text = "D";
                        lbl_8.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                    }
                    else if (22 <= sayi8 && sayi8 < 29)
                    {
                        txt_harf8.Text = "C";
                        lbl_8.Text = "NORMAL";
                    }
                    else if (29 <= sayi8 && sayi8 < 33)
                    {
                        txt_harf8.Text = "B";
                        lbl_8.Text = "İYİ";
                    }

                    else if (33 <= sayi8 && sayi8 <= 35)
                    {
                        txt_harf2.Text = "A";
                        lbl_2.Text = "ÇOK İYİ";
                    }
                    else if (sayi8 < 0 || sayi8 > 35)
                    {
                        txt_harf8.Text = "";
                        lbl_8.Text = "";
                        txt_sayi8.ForeColor = Color.Red;

                    }
                }
                else
                {
                    txt_harf8.Text = "";
                    lbl_8.Text = "";
                }
            }
            else
            {
                MessageBox.Show("ÇALIŞANIN GRUBUNU SEÇİNİZ.");
            }
        }

        private void txt_sayi9_TextChanged(object sender, EventArgs e)
        {
            if (cbx_calisan_grubu.Text == "TECRÜBELİ PERSONEL")
            {
                if (txt_sayi9.Text.Length > 0)
                {


                    int sayi9 = Convert.ToInt32(txt_sayi9.Text);
                    if (0 <= sayi9 && sayi9 < 36)
                    {
                        txt_harf9.Text = "E";
                        lbl_9.Text = "BAŞARISIZ";
                    }
                    else if (36 <= sayi9 && sayi9 < 60)
                    {
                        txt_harf9.Text = "D";
                        lbl_9.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                    }
                    else if (60 <= sayi9 && sayi9 < 80)
                    {
                        txt_harf9.Text = "C";
                        lbl_9.Text = "NORMAL";
                    }
                    else if (80 <= sayi9 && sayi9 < 90)
                    {
                        txt_harf9.Text = "B";
                        lbl_9.Text = "İYİ";
                    }

                    else if (90 <= sayi9 && sayi9 <= 100)
                    {
                        txt_harf9.Text = "A";
                        lbl_9.Text = "ÇOK İYİ";
                    }
                    else if (sayi9 < 0 || sayi9 > 100)
                    {
                        txt_harf9.Text = "";
                        lbl_9.Text = "";
                        txt_sayi9.ForeColor = Color.Red;

                    }

                }
                else
                {
                    txt_harf9.Text = "";
                    lbl_9.Text = "";
                }
            }
            else if (cbx_calisan_grubu.Text == "YENİ PERSONEL")

            {
                if (txt_sayi9.Text.Length > 0)
                {

                    int sayi9 = Convert.ToInt32(txt_sayi9.Text);
                    if (0 <= sayi9 && sayi9 < 13)
                    {
                        txt_harf9.Text = "E";
                        lbl_9.Text = "BAŞARISIZ";
                    }
                    else if (13 <= sayi9 && sayi9 < 22)
                    {
                        txt_harf9.Text = "D";
                        lbl_9.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                    }
                    else if (22 <= sayi9 && sayi9 < 29)
                    {
                        txt_harf9.Text = "C";
                        lbl_9.Text = "NORMAL";
                    }
                    else if (29 <= sayi9 && sayi9 < 33)
                    {
                        txt_harf9.Text = "B";
                        lbl_9.Text = "İYİ";
                    }

                    else if (33 <= sayi9 && sayi9 <= 35)
                    {
                        txt_harf9.Text = "A";
                        lbl_9.Text = "ÇOK İYİ";
                    }
                    else if (sayi9 < 0 || sayi9 > 35)
                    {
                        txt_harf9.Text = "";
                        lbl_9.Text = "";
                        txt_sayi9.ForeColor = Color.Red;

                    }
                }
                else
                {
                    txt_harf9.Text = "";
                    lbl_9.Text = "";
                }
            }
            else
            {
                MessageBox.Show("ÇALIŞANIN GRUBUNU SEÇİNİZ.");
            }
        }

        private void txt_sayi10_TextChanged(object sender, EventArgs e)
        {
            if (cbx_calisan_grubu.Text == "TECRÜBELİ PERSONEL")
            {
                if (txt_sayi10.Text.Length > 0)
                {


                    int sayi10 = Convert.ToInt32(txt_sayi2.Text);
                    if (0 <= sayi10 && sayi10 < 36)
                    {
                        txt_harf10.Text = "E";
                        lbl_10.Text = "BAŞARISIZ";
                    }
                    else if (36 <= sayi10 && sayi10 < 60)
                    {
                        txt_harf10.Text = "D";
                        lbl_10.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                    }
                    else if (60 <= sayi10 && sayi10 < 80)
                    {
                        txt_harf10.Text = "C";
                        lbl_10.Text = "NORMAL";
                    }
                    else if (80 <= sayi10 && sayi10 < 90)
                    {
                        txt_harf10.Text = "B";
                        lbl_10.Text = "İYİ";
                    }

                    else if (90 <= sayi10 && sayi10 <= 100)
                    {
                        txt_harf10.Text = "A";
                        lbl_10.Text = "ÇOK İYİ";
                    }
                    else if (sayi10 < 0 || sayi10 > 100)
                    {
                        txt_harf10.Text = "";
                        lbl_10.Text = "";
                        txt_sayi10.ForeColor = Color.Red;

                    }

                }
                else
                {
                    txt_harf10.Text = "";
                    lbl_10.Text = "";
                }
            }
            else if (cbx_calisan_grubu.Text == "YENİ PERSONEL")

            {
                if (txt_sayi10.Text.Length > 0)
                {

                    int sayi10 = Convert.ToInt32(txt_sayi10.Text);
                    if (0 <= sayi10 && sayi10 < 13)
                    {
                        txt_harf10.Text = "E";
                        lbl_10.Text = "BAŞARISIZ";
                    }
                    else if (13 <= sayi10 && sayi10 < 22)
                    {
                        txt_harf10.Text = "D";
                        lbl_10.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                    }
                    else if (22 <= sayi10 && sayi10 < 29)
                    {
                        txt_harf10.Text = "C";
                        lbl_10.Text = "NORMAL";
                    }
                    else if (29 <= sayi10 && sayi10 < 33)
                    {
                        txt_harf10.Text = "B";
                        lbl_10.Text = "İYİ";
                    }

                    else if (33 <= sayi10 && sayi10 <= 35)
                    {
                        txt_harf10.Text = "A";
                        lbl_10.Text = "ÇOK İYİ";
                    }
                    else if (sayi10 < 0 || sayi10 > 35)
                    {
                        txt_harf10.Text = "";
                        lbl_10.Text = "";
                        txt_sayi10.ForeColor = Color.Red;

                    }
                }
                else
                {
                    txt_harf10.Text = "";
                    lbl_10.Text = "";
                }
            }
            else
            {
                MessageBox.Show("ÇALIŞANIN GRUBUNU SEÇİNİZ.");
            }
        }

        private void txt_sayi11_TextChanged(object sender, EventArgs e)
        {
            if (cbx_calisan_grubu.Text == "TECRÜBELİ PERSONEL")
            {
                if (txt_sayi11.Text.Length > 0)
                {


                    int sayi11 = Convert.ToInt32(txt_sayi11.Text);
                    if (0 <= sayi11 && sayi11 < 36)
                    {
                        txt_harf11.Text = "E";
                        lbl_11.Text = "BAŞARISIZ";
                    }
                    else if (36 <= sayi11 && sayi11 < 60)
                    {
                        txt_harf11.Text = "D";
                        lbl_11.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                    }
                    else if (60 <= sayi11 && sayi11 < 80)
                    {
                        txt_harf11.Text = "C";
                        lbl_11.Text = "NORMAL";
                    }
                    else if (80 <= sayi11 && sayi11 < 90)
                    {
                        txt_harf11.Text = "B";
                        lbl_11.Text = "İYİ";
                    }

                    else if (90 <= sayi11 && sayi11 <= 100)
                    {
                        txt_harf11.Text = "A";
                        lbl_11.Text = "ÇOK İYİ";
                    }
                    else if (sayi11 < 0 || sayi11 > 100)
                    {
                        txt_harf11.Text = "";
                        lbl_11.Text = "";
                        txt_sayi11.ForeColor = Color.Red;

                    }

                }
                else
                {
                    txt_harf11.Text = "";
                    lbl_11.Text = "";
                }
            }
            else if (cbx_calisan_grubu.Text == "YENİ PERSONEL")

            {
                if (txt_sayi11.Text.Length > 0)
                {

                    int sayi11 = Convert.ToInt32(txt_sayi2.Text);
                    if (0 <= sayi11 && sayi11 < 13)
                    {
                        txt_harf11.Text = "E";
                        lbl_11.Text = "BAŞARISIZ";
                    }
                    else if (13 <= sayi11 && sayi11 < 22)
                    {
                        txt_harf11.Text = "D";
                        lbl_11.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                    }
                    else if (22 <= sayi11 && sayi11 < 29)
                    {
                        txt_harf11.Text = "C";
                        lbl_11.Text = "NORMAL";
                    }
                    else if (29 <= sayi11 && sayi11 < 33)
                    {
                        txt_harf11.Text = "B";
                        lbl_11.Text = "İYİ";
                    }

                    else if (33 <= sayi11 && sayi11 <= 35)
                    {
                        txt_harf11.Text = "A";
                        lbl_11.Text = "ÇOK İYİ";
                    }
                    else if (sayi11 < 0 || sayi11 > 35)
                    {
                        txt_harf11.Text = "";
                        lbl_11.Text = "";
                        txt_sayi11.ForeColor = Color.Red;

                    }
                }
                else
                {
                    txt_harf11.Text = "";
                    lbl_11.Text = "";
                }
            }
            else
            {
                MessageBox.Show("ÇALIŞANIN GRUBUNU SEÇİNİZ.");
            }
        }

        private void txt_sayi12_TextChanged(object sender, EventArgs e)
        {
            if (cbx_calisan_grubu.Text == "TECRÜBELİ PERSONEL")
            {
                if (txt_sayi12.Text.Length > 0)
                {


                    int sayi12 = Convert.ToInt32(txt_sayi12.Text);
                    if (0 <= sayi12 && sayi12 < 36)
                    {
                        txt_harf12.Text = "E";
                        lbl_12.Text = "BAŞARISIZ";
                    }
                    else if (36 <= sayi12 && sayi12 < 60)
                    {
                        txt_harf12.Text = "D";
                        lbl_12.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                    }
                    else if (60 <= sayi12 && sayi12 < 80)
                    {
                        txt_harf12.Text = "C";
                        lbl_12.Text = "NORMAL";
                    }
                    else if (80 <= sayi12 && sayi12 < 90)
                    {
                        txt_harf12.Text = "B";
                        lbl_12.Text = "İYİ";
                    }

                    else if (90 <= sayi12 && sayi12 <= 100)
                    {
                        txt_harf12.Text = "A";
                        lbl_12.Text = "ÇOK İYİ";
                    }
                    else if (sayi12 < 0 || sayi12 > 100)
                    {
                        txt_harf12.Text = "";
                        lbl_12.Text = "";
                        txt_sayi12.ForeColor = Color.Red;

                    }

                }
                else
                {
                    txt_harf12.Text = "";
                    lbl_12.Text = "";
                }
            }
            else if (cbx_calisan_grubu.Text == "YENİ PERSONEL")

            {
                if (txt_sayi12.Text.Length > 0)
                {

                    int sayi12 = Convert.ToInt32(txt_sayi12.Text);
                    if (0 <= sayi12 && sayi12 < 13)
                    {
                        txt_harf12.Text = "E";
                        lbl_12.Text = "BAŞARISIZ";
                    }
                    else if (13 <= sayi12 && sayi12 < 22)
                    {
                        txt_harf12.Text = "D";
                        lbl_12.Text = "YETERSİZ(EĞİTİLEBİLİR)";
                    }
                    else if (22 <= sayi12 && sayi12 < 29)
                    {
                        txt_harf12.Text = "C";
                        lbl_12.Text = "NORMAL";
                    }
                    else if (29 <= sayi12 && sayi12 < 33)
                    {
                        txt_harf12.Text = "B";
                        lbl_12.Text = "İYİ";
                    }

                    else if (33 <= sayi12 && sayi12 <= 35)
                    {
                        txt_harf12.Text = "A";
                        lbl_12.Text = "ÇOK İYİ";
                    }
                    else if (sayi12 < 0 || sayi12 > 35)
                    {
                        txt_harf12.Text = "";
                        lbl_12.Text = "";
                        txt_sayi12.ForeColor = Color.Red;

                    }
                }
                else
                {
                    txt_harf12.Text = "";
                    lbl_12.Text = "";
                }
            }
            else
            {
                MessageBox.Show("ÇALIŞANIN GRUBUNU SEÇİNİZ.");
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_sayi1_Leave(object sender, EventArgs e)
        {
            if (cbx_calisan_grubu.Text == "TECRÜBELİ PERSONEL")
            {
                try
                {
                    if (Convert.ToInt32(txt_sayi1.Text) < 0 || Convert.ToInt32(txt_sayi1.Text) > 101)
                    {
                        MessageBox.Show("Değer 0-100 arasında olmalı");
                        txt_sayi1.Text = "";
                        txt_sayi1.Focus();
                    }

                }
                catch
                {
                    MessageBox.Show("Sayısal bir değer girin");
                    txt_sayi1.Text = "";


                }

            }

            else if (cbx_calisan_grubu.Text == "YENİ PERSONEL")
            {
                try
                {
                    if (Convert.ToInt32(txt_sayi1.Text) < 0 || Convert.ToInt32(txt_sayi1.Text) > 36)
                    {
                        MessageBox.Show("Değer 0-35 arasında olmalı");
                        txt_sayi1.Text = "";
                        txt_sayi1.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Sayısal bir değer girin");
                    txt_sayi1.Text = "";

                }
            }

        }

        private void txt_sayi2_Leave(object sender, EventArgs e)
        {
            if (cbx_calisan_grubu.Text == "TECRÜBELİ PERSONEL")
            {
                try
                {
                    if (Convert.ToInt32(txt_sayi2.Text) < 0 || Convert.ToInt32(txt_sayi2.Text) > 101)
                    {
                        MessageBox.Show("Değer 0-100 arasında olmalı");
                        txt_sayi2.Text = "";
                        txt_sayi2.Focus();
                    }

                }
                catch
                {
                    MessageBox.Show("Sayısal bir değer girin");
                    txt_sayi2.Text = "";


                }

            }

            else if (cbx_calisan_grubu.Text == "YENİ PERSONEL")
            {
                try
                {
                    if (Convert.ToInt32(txt_sayi2.Text) < 0 || Convert.ToInt32(txt_sayi2.Text) > 36)
                    {
                        MessageBox.Show("Değer 0-35 arasında olmalı");
                        txt_sayi2.Text = "";
                        txt_sayi2.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Sayısal bir değer girin");
                    txt_sayi2.Text = "";

                }
            }
        }

        private void txt_sayi3_Leave(object sender, EventArgs e)
        {
            if (cbx_calisan_grubu.Text == "TECRÜBELİ PERSONEL")
            {
                try
                {
                    if (Convert.ToInt32(txt_sayi3.Text) < 0 || Convert.ToInt32(txt_sayi3.Text) > 101)
                    {
                        MessageBox.Show("Değer 0-100 arasında olmalı");
                        txt_sayi3.Text = "";
                        txt_sayi3.Focus();
                    }

                }
                catch
                {
                    MessageBox.Show("Sayısal bir değer girin");
                    txt_sayi3.Text = "";


                }

            }

            else if (cbx_calisan_grubu.Text == "YENİ PERSONEL")
            {
                try
                {
                    if (Convert.ToInt32(txt_sayi3.Text) < 0 || Convert.ToInt32(txt_sayi3.Text) > 36)
                    {
                        MessageBox.Show("Değer 0-35 arasında olmalı");
                        txt_sayi3.Text = "";
                        txt_sayi3.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Sayısal bir değer girin");
                    txt_sayi3.Text = "";

                }
            }
        }

        private void txt_sayi4_Leave(object sender, EventArgs e)
        {
            if (cbx_calisan_grubu.Text == "TECRÜBELİ PERSONEL")
            {
                try
                {
                    if (Convert.ToInt32(txt_sayi4.Text) < 0 || Convert.ToInt32(txt_sayi4.Text) > 101)
                    {
                        MessageBox.Show("Değer 0-100 arasında olmalı");
                        txt_sayi4.Text = "";
                        txt_sayi4.Focus();
                    }

                }
                catch
                {
                    MessageBox.Show("Sayısal bir değer girin");
                    txt_sayi4.Text = "";


                }

            }

            else if (cbx_calisan_grubu.Text == "YENİ PERSONEL")
            {
                try
                {
                    if (Convert.ToInt32(txt_sayi4.Text) < 0 || Convert.ToInt32(txt_sayi4.Text) > 36)
                    {
                        MessageBox.Show("Değer 0-35 arasında olmalı");
                        txt_sayi4.Text = "";
                        txt_sayi4.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Sayısal bir değer girin");
                    txt_sayi4.Text = "";

                }
            }
        }

        private void txt_sayi5_Leave(object sender, EventArgs e)
        {
            if (cbx_calisan_grubu.Text == "TECRÜBELİ PERSONEL")
            {
                try
                {
                    if (Convert.ToInt32(txt_sayi5.Text) < 0 || Convert.ToInt32(txt_sayi5.Text) > 101)
                    {
                        MessageBox.Show("Değer 0-100 arasında olmalı");
                        txt_sayi5.Text = "";
                        txt_sayi5.Focus();
                    }

                }
                catch
                {
                    MessageBox.Show("Sayısal bir değer girin");
                    txt_sayi5.Text = "";


                }

            }

            else if (cbx_calisan_grubu.Text == "YENİ PERSONEL")
            {
                try
                {
                    if (Convert.ToInt32(txt_sayi5.Text) < 0 || Convert.ToInt32(txt_sayi5.Text) > 36)
                    {
                        MessageBox.Show("Değer 0-35 arasında olmalı");
                        txt_sayi5.Text = "";
                        txt_sayi5.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Sayısal bir değer girin");
                    txt_sayi5.Text = "";

                }
            }
        }

        private void txt_sayi6_Leave(object sender, EventArgs e)
        {
            if (cbx_calisan_grubu.Text == "TECRÜBELİ PERSONEL")
            {
                try
                {
                    if (Convert.ToInt32(txt_sayi6.Text) < 0 || Convert.ToInt32(txt_sayi6.Text) > 101)
                    {
                        MessageBox.Show("Değer 0-100 arasında olmalı");
                        txt_sayi6.Text = "";
                        txt_sayi6.Focus();
                    }

                }
                catch
                {
                    MessageBox.Show("Sayısal bir değer girin");
                    txt_sayi6.Text = "";


                }

            }

            else if (cbx_calisan_grubu.Text == "YENİ PERSONEL")
            {
                try
                {
                    if (Convert.ToInt32(txt_sayi6.Text) < 0 || Convert.ToInt32(txt_sayi6.Text) > 36)
                    {
                        MessageBox.Show("Değer 0-35 arasında olmalı");
                        txt_sayi6.Text = "";
                        txt_sayi6.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Sayısal bir değer girin");
                    txt_sayi6.Text = "";

                }
            }
        }

        private void txt_sayi7_Leave(object sender, EventArgs e)
        {
            if (cbx_calisan_grubu.Text == "TECRÜBELİ PERSONEL")
            {
                try
                {
                    if (Convert.ToInt32(txt_sayi7.Text) < 0 || Convert.ToInt32(txt_sayi7.Text) > 101)
                    {
                        MessageBox.Show("Değer 0-100 arasında olmalı");
                        txt_sayi7.Text = "";
                        txt_sayi7.Focus();
                    }

                }
                catch
                {
                    MessageBox.Show("Sayısal bir değer girin");
                    txt_sayi7.Text = "";


                }

            }

            else if (cbx_calisan_grubu.Text == "YENİ PERSONEL")
            {
                try
                {
                    if (Convert.ToInt32(txt_sayi7.Text) < 0 || Convert.ToInt32(txt_sayi7.Text) > 36)
                    {
                        MessageBox.Show("Değer 0-35 arasında olmalı");
                        txt_sayi7.Text = "";
                        txt_sayi7.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Sayısal bir değer girin");
                    txt_sayi7.Text = "";

                }
            }
        }

        private void txt_sayi8_Leave(object sender, EventArgs e)
        {
            if (cbx_calisan_grubu.Text == "TECRÜBELİ PERSONEL")
            {
                try
                {
                    if (Convert.ToInt32(txt_sayi8.Text) < 0 || Convert.ToInt32(txt_sayi8.Text) > 101)
                    {
                        MessageBox.Show("Değer 0-100 arasında olmalı");
                        txt_sayi8.Text = "";
                        txt_sayi8.Focus();
                    }

                }
                catch
                {
                    MessageBox.Show("Sayısal bir değer girin");
                    txt_sayi8.Text = "";


                }

            }

            else if (cbx_calisan_grubu.Text == "YENİ PERSONEL")
            {
                try
                {
                    if (Convert.ToInt32(txt_sayi8.Text) < 0 || Convert.ToInt32(txt_sayi8.Text) > 36)
                    {
                        MessageBox.Show("Değer 0-35 arasında olmalı");
                        txt_sayi8.Text = "";
                        txt_sayi8.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Sayısal bir değer girin");
                    txt_sayi8.Text = "";

                }
            }
        }

        private void txt_sayi9_Leave(object sender, EventArgs e)
        {
            if (cbx_calisan_grubu.Text == "TECRÜBELİ PERSONEL")
            {
                try
                {
                    if (Convert.ToInt32(txt_sayi9.Text) < 0 || Convert.ToInt32(txt_sayi9.Text) > 101)
                    {
                        MessageBox.Show("Değer 0-100 arasında olmalı");
                        txt_sayi9.Text = "";
                        txt_sayi9.Focus();
                    }

                }
                catch
                {
                    MessageBox.Show("Sayısal bir değer girin");
                    txt_sayi9.Text = "";


                }

            }

            else if (cbx_calisan_grubu.Text == "YENİ PERSONEL")
            {
                try
                {
                    if (Convert.ToInt32(txt_sayi9.Text) < 0 || Convert.ToInt32(txt_sayi9.Text) > 36)
                    {
                        MessageBox.Show("Değer 0-35 arasında olmalı");
                        txt_sayi9.Text = "";
                        txt_sayi9.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Sayısal bir değer girin");
                    txt_sayi9.Text = "";

                }
            }
        }

        private void txt_sayi10_Leave(object sender, EventArgs e)
        {
            if (cbx_calisan_grubu.Text == "TECRÜBELİ PERSONEL")
            {
                try
                {
                    if (Convert.ToInt32(txt_sayi10.Text) < 0 || Convert.ToInt32(txt_sayi10.Text) > 101)
                    {
                        MessageBox.Show("Değer 0-100 arasında olmalı");
                        txt_sayi10.Text = "";
                        txt_sayi10.Focus();
                    }

                }
                catch
                {
                    MessageBox.Show("Sayısal bir değer girin");
                    txt_sayi10.Text = "";


                }

            }

            else if (cbx_calisan_grubu.Text == "YENİ PERSONEL")
            {
                try
                {
                    if (Convert.ToInt32(txt_sayi10.Text) < 0 || Convert.ToInt32(txt_sayi10.Text) > 36)
                    {
                        MessageBox.Show("Değer 0-35 arasında olmalı");
                        txt_sayi10.Text = "";
                        txt_sayi10.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Sayısal bir değer girin");
                    txt_sayi10.Text = "";

                }
            }
        }

        private void txt_sayi11_Leave(object sender, EventArgs e)
        {
            if (cbx_calisan_grubu.Text == "TECRÜBELİ PERSONEL")
            {
                try
                {
                    if (Convert.ToInt32(txt_sayi11.Text) < 0 || Convert.ToInt32(txt_sayi11.Text) > 101)
                    {
                        MessageBox.Show("Değer 0-100 arasında olmalı");
                        txt_sayi11.Text = "";
                        txt_sayi11.Focus();
                    }

                }
                catch
                {
                    MessageBox.Show("Sayısal bir değer girin");
                    txt_sayi11.Text = "";


                }

            }

            else if (cbx_calisan_grubu.Text == "YENİ PERSONEL")
            {
                try
                {
                    if (Convert.ToInt32(txt_sayi11.Text) < 0 || Convert.ToInt32(txt_sayi11.Text) > 36)
                    {
                        MessageBox.Show("Değer 0-35 arasında olmalı");
                        txt_sayi11.Text = "";
                        txt_sayi11.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Sayısal bir değer girin");
                    txt_sayi11.Text = "";

                }
            }
        }

        private void txt_sayi12_Leave(object sender, EventArgs e)
        {
            if (cbx_calisan_grubu.Text == "TECRÜBELİ PERSONEL")
            {
                try
                {
                    if (Convert.ToInt32(txt_sayi12.Text) < 0 || Convert.ToInt32(txt_sayi12.Text) > 101)
                    {
                        MessageBox.Show("Değer 0-100 arasında olmalı");
                        txt_sayi12.Text = "";
                        txt_sayi12.Focus();
                    }

                }
                catch
                {
                    MessageBox.Show("Sayısal bir değer girin");
                    txt_sayi12.Text = "";


                }

            }

            else if (cbx_calisan_grubu.Text == "YENİ PERSONEL")
            {
                try
                {
                    if (Convert.ToInt32(txt_sayi12.Text) < 0 || Convert.ToInt32(txt_sayi12.Text) > 36)
                    {
                        MessageBox.Show("Değer 0-35 arasında olmalı");
                        txt_sayi12.Text = "";
                        txt_sayi12.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Sayısal bir değer girin");
                    txt_sayi12.Text = "";

                }
            }
        }

        private void ekrani_temizle()
        {
            mtxt_tc_no.Clear();
            txt_pdks.Text = string.Empty;

            cb_yil_1.Text = string.Empty;
            cb_yil_2.Text = string.Empty;
            cb_yil_3.Text = string.Empty;
            cb_yil_4.Text = string.Empty;
            cb_yil_5.Text = string.Empty;
            cb_yil_6.Text = string.Empty;
            cb_yil_7.Text = string.Empty;
            cb_yil_8.Text = string.Empty;
            cb_yil_9.Text = string.Empty;
            cb_yil_10.Text = string.Empty;
            cb_yil_11.Text = string.Empty;
            cb_yil_12.Text = string.Empty;

            cb_1.Text = string.Empty;
            cb_2.Text = string.Empty;
            cb_3.Text = string.Empty;
            cb_4.Text = string.Empty;
            cb_5.Text = string.Empty;
            cb_6.Text = string.Empty;
            cb_7.Text = string.Empty;
            cb_8.Text = string.Empty;
            cb_9.Text = string.Empty;
            cb_10.Text = string.Empty;
            cb_11.Text = string.Empty;
            cb_12.Text = string.Empty;

            txt_sayi1.Text = string.Empty;
            txt_sayi2.Text = string.Empty;
            txt_sayi3.Text = string.Empty;
            txt_sayi4.Text = string.Empty;
            txt_sayi5.Text = string.Empty;
            txt_sayi6.Text = string.Empty;
            txt_sayi7.Text = string.Empty;
            txt_sayi8.Text = string.Empty;
            txt_sayi9.Text = string.Empty;
            txt_sayi10.Text = string.Empty;
            txt_sayi11.Text = string.Empty;
            txt_sayi12.Text = string.Empty;

            txt_harf1.Text = string.Empty;
            txt_harf2.Text = string.Empty;
            txt_harf3.Text = string.Empty;
            txt_harf4.Text = string.Empty;
            txt_harf5.Text = string.Empty;
            txt_harf6.Text = string.Empty;
            txt_harf7.Text = string.Empty;
            txt_harf8.Text = string.Empty;
            txt_harf9.Text = string.Empty;
            txt_harf10.Text = string.Empty;
            txt_harf11.Text = string.Empty;
            txt_harf12.Text = string.Empty;

            txt_id_1.Text = string.Empty;
            txt_id_2.Text = string.Empty;
            txt_id_3.Text = string.Empty;
            txt_id_4.Text = string.Empty;
            txt_id_5.Text = string.Empty;
            txt_id_6.Text = string.Empty;
            txt_id_7.Text = string.Empty;
            txt_id_8.Text = string.Empty;
            txt_id_9.Text = string.Empty;
            txt_id_10.Text = string.Empty;
            txt_id_11.Text = string.Empty;
            txt_id_12.Text = string.Empty;

            lbl_1.Text = "...";
            lbl_2.Text = "...";
            lbl_3.Text = "...";
            lbl_4.Text = "...";
            lbl_5.Text = "...";
            lbl_6.Text = "...";
            lbl_7.Text = "...";
            lbl_8.Text = "...";
            lbl_9.Text = "...";
            lbl_10.Text = "...";
            lbl_11.Text = "...";
            lbl_12.Text = "...";
            lbl_ortalama.Text = "...";

            label3.Text = "...";
            label5.Text = "...";
            lbl_gorevyeri.Text = "...";
            lbl_gorevii.Text = "...";

            //foreach (var series in chartControl1.Series)
            //{
            //    series.Equals = "";
            //}
            chartControl1.Series.Clear();

            cbx_calisan_grubu.SelectedIndex = 0;
            gridView1.Columns.Clear();
        }

        bool kayit_arama_durumu = false;

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

                    btn_sil_11.Enabled = true;
                    btn_guncelle.Enabled = true;
                    btn_forma_ekle.Enabled = true;

                    //listele();
                    break;
                }
                //eğer kayıt okuma durumu gerçekleşmemiş ise kayıt bulunamadı ise
                if (kayit_arama_durumu == false)
                {
                    MessageBox.Show("Kayıt bulunamadı", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btn_sil_11.Enabled = false;
                    btn_guncelle.Enabled = false;
                    btn_forma_ekle.Enabled = false;
                }

            }
            else
            {
                //girilen tc no 11karakter değilse
                MessageBox.Show("Lütfen 11 haneli TC NO giriniz", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ekrani_temizle();
            }


        }

        private void txt_sayi1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_sayi2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_sayi3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_sayi4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_sayi5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_sayi6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_sayi7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_sayi8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_sayi9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_sayi10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_sayi11_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_sayi12_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void mtxt_tc_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void mtxt_tc_no_TextChanged(object sender, EventArgs e)
        {
            //tc kimlik no giriş kısmı için kısıtlamalar yazılacaktır.
            //yukarıda 11 den fazla giremeyeceğini belirtmştirk. bu ksımda da 11d den az giremeyeceğini belirttik.
            if (mtxt_tc_no.Text.Length < 11)
                dxErrorProvider1.SetError(mtxt_tc_no, "TC KİMLİK NO 11 KARAKTER OLMALIDIR.");
            else
                dxErrorProvider1.ClearErrors();



        }

        private void btn_formu_temizle_Click(object sender, EventArgs e)
        {
            ekrani_temizle();
        }

        private void btn_ekle_1_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (cb_yil_1.Text == "" || cb_1.Text == "" || txt_sayi1.Text == "")
            {
                lbl_donem.ForeColor = Color.Red;
                lbl_yıl.ForeColor = Color.Red;
                lbl_puan.ForeColor = Color.Red;
                lbl_aciklama.ForeColor = Color.Red;
                lbl_not.ForeColor = Color.Red;

            }
            else
            {
                lbl_donem.ForeColor = Color.Black;
                lbl_yıl.ForeColor = Color.Black;
                lbl_puan.ForeColor = Color.Black;
                lbl_aciklama.ForeColor = Color.Black;
                lbl_not.ForeColor = Color.Black;
            }



            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_sayi1.Text != "" && cb_yil_1.Text != "" && cb_1.Text != "")
                {

                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_KisiYillikPerformans", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@persormansDonemi", cb_1.Text);
                        eklekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi1.Text);
                        eklekomutu.Parameters.AddWithValue("@harfNotu", txt_harf1.Text);
                        eklekomutu.Parameters.AddWithValue("@yil", cb_yil_1.Text);
                        eklekomutu.Parameters.AddWithValue("@aciklama", lbl_1.Text);
                        eklekomutu.Parameters.AddWithValue("@calismaGrubu", cbx_calisan_grubu.Text);

                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin performans bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                    ekrani_temizle();
                    // listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamamıştır. Lütfen kontrol ediniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarasını gözden geçiriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

            }

        }

        private void btn_ekle_2_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (cb_yil_2.Text == "" || cb_2.Text == "" || txt_sayi2.Text == "")
            {
                lbl_donem.ForeColor = Color.Red;
                lbl_yıl.ForeColor = Color.Red;
                lbl_puan.ForeColor = Color.Red;
                lbl_aciklama.ForeColor = Color.Red;
                lbl_not.ForeColor = Color.Red;

            }
            else
            {
                lbl_donem.ForeColor = Color.Black;
                lbl_yıl.ForeColor = Color.Black;
                lbl_puan.ForeColor = Color.Black;
                lbl_aciklama.ForeColor = Color.Black;
                lbl_not.ForeColor = Color.Black;
            }



            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_sayi2.Text != "" && cb_yil_2.Text != "" && cb_2.Text != "")
                {

                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_KisiYillikPerformans", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@persormansDonemi", cb_2.Text);
                        eklekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi2.Text);
                        eklekomutu.Parameters.AddWithValue("@harfNotu", txt_harf2.Text);
                        eklekomutu.Parameters.AddWithValue("@yil", cb_yil_2.Text);
                        eklekomutu.Parameters.AddWithValue("@aciklama", lbl_2.Text);
                        eklekomutu.Parameters.AddWithValue("@calismaGrubu", cbx_calisan_grubu.Text);

                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin performans bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                    ekrani_temizle();
                    // listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamamıştır. Lütfen kontrol ediniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarasını gözden geçiriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

            }
        }

        private void btn_ekle_3_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (cb_yil_3.Text == "" || cb_3.Text == "" || txt_sayi3.Text == "")
            {
                lbl_donem.ForeColor = Color.Red;
                lbl_yıl.ForeColor = Color.Red;
                lbl_puan.ForeColor = Color.Red;
                lbl_aciklama.ForeColor = Color.Red;
                lbl_not.ForeColor = Color.Red;

            }
            else
            {
                lbl_donem.ForeColor = Color.Black;
                lbl_yıl.ForeColor = Color.Black;
                lbl_puan.ForeColor = Color.Black;
                lbl_aciklama.ForeColor = Color.Black;
                lbl_not.ForeColor = Color.Black;
            }



            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_sayi3.Text != "" && cb_yil_3.Text != "" && cb_3.Text != "")
                {

                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_KisiYillikPerformans", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@persormansDonemi", cb_3.Text);
                        eklekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi3.Text);
                        eklekomutu.Parameters.AddWithValue("@harfNotu", txt_harf3.Text);
                        eklekomutu.Parameters.AddWithValue("@yil", cb_yil_3.Text);
                        eklekomutu.Parameters.AddWithValue("@aciklama", lbl_3.Text);
                        eklekomutu.Parameters.AddWithValue("@calismaGrubu", cbx_calisan_grubu.Text);

                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin performans bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                    ekrani_temizle();
                    // listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamamıştır. Lütfen kontrol ediniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarasını gözden geçiriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

            }
        }

        private void btn_ekle_4_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (cb_yil_4.Text == "" || cb_4.Text == "" || txt_sayi4.Text == "")
            {
                lbl_donem.ForeColor = Color.Red;
                lbl_yıl.ForeColor = Color.Red;
                lbl_puan.ForeColor = Color.Red;
                lbl_aciklama.ForeColor = Color.Red;
                lbl_not.ForeColor = Color.Red;

            }
            else
            {
                lbl_donem.ForeColor = Color.Black;
                lbl_yıl.ForeColor = Color.Black;
                lbl_puan.ForeColor = Color.Black;
                lbl_aciklama.ForeColor = Color.Black;
                lbl_not.ForeColor = Color.Black;
            }



            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_sayi4.Text != "" && cb_yil_4.Text != "" && cb_4.Text != "")
                {

                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_KisiYillikPerformans", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@persormansDonemi", cb_4.Text);
                        eklekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi4.Text);
                        eklekomutu.Parameters.AddWithValue("@harfNotu", txt_harf4.Text);
                        eklekomutu.Parameters.AddWithValue("@yil", cb_yil_4.Text);
                        eklekomutu.Parameters.AddWithValue("@aciklama", lbl_4.Text);
                        eklekomutu.Parameters.AddWithValue("@calismaGrubu", cbx_calisan_grubu.Text);

                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin performans bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                    ekrani_temizle();
                    // listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamamıştır. Lütfen kontrol ediniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarasını gözden geçiriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

            }
        }

        private void btn_ekle_5_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (cb_yil_5.Text == "" || cb_5.Text == "" || txt_sayi5.Text == "")
            {
                lbl_donem.ForeColor = Color.Red;
                lbl_yıl.ForeColor = Color.Red;
                lbl_puan.ForeColor = Color.Red;
                lbl_aciklama.ForeColor = Color.Red;
                lbl_not.ForeColor = Color.Red;

            }
            else
            {
                lbl_donem.ForeColor = Color.Black;
                lbl_yıl.ForeColor = Color.Black;
                lbl_puan.ForeColor = Color.Black;
                lbl_aciklama.ForeColor = Color.Black;
                lbl_not.ForeColor = Color.Black;
            }



            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_sayi5.Text != "" && cb_yil_5.Text != "" && cb_5.Text != "")
                {

                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_KisiYillikPerformans", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@persormansDonemi", cb_5.Text);
                        eklekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi5.Text);
                        eklekomutu.Parameters.AddWithValue("@harfNotu", txt_harf5.Text);
                        eklekomutu.Parameters.AddWithValue("@yil", cb_yil_5.Text);
                        eklekomutu.Parameters.AddWithValue("@aciklama", lbl_5.Text);
                        eklekomutu.Parameters.AddWithValue("@calismaGrubu", cbx_calisan_grubu.Text);

                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin performans bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                    ekrani_temizle();
                    // listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamamıştır. Lütfen kontrol ediniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarasını gözden geçiriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

            }
        }

        private void btn_ekle_6_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (cb_yil_6.Text == "" || cb_6.Text == "" || txt_sayi6.Text == "")
            {
                lbl_donem.ForeColor = Color.Red;
                lbl_yıl.ForeColor = Color.Red;
                lbl_puan.ForeColor = Color.Red;
                lbl_aciklama.ForeColor = Color.Red;
                lbl_not.ForeColor = Color.Red;

            }
            else
            {
                lbl_donem.ForeColor = Color.Black;
                lbl_yıl.ForeColor = Color.Black;
                lbl_puan.ForeColor = Color.Black;
                lbl_aciklama.ForeColor = Color.Black;
                lbl_not.ForeColor = Color.Black;
            }



            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_sayi6.Text != "" && cb_yil_6.Text != "" && cb_6.Text != "")
                {

                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_KisiYillikPerformans", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@persormansDonemi", cb_6.Text);
                        eklekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi6.Text);
                        eklekomutu.Parameters.AddWithValue("@harfNotu", txt_harf6.Text);
                        eklekomutu.Parameters.AddWithValue("@yil", cb_yil_6.Text);
                        eklekomutu.Parameters.AddWithValue("@aciklama", lbl_6.Text);
                        eklekomutu.Parameters.AddWithValue("@calismaGrubu", cbx_calisan_grubu.Text);

                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin performans bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                    ekrani_temizle();
                    // listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamamıştır. Lütfen kontrol ediniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarasını gözden geçiriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

            }
        }

        private void btn_ekle_7_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (cb_yil_7.Text == "" || cb_7.Text == "" || txt_sayi7.Text == "")
            {
                lbl_donem.ForeColor = Color.Red;
                lbl_yıl.ForeColor = Color.Red;
                lbl_puan.ForeColor = Color.Red;
                lbl_aciklama.ForeColor = Color.Red;
                lbl_not.ForeColor = Color.Red;

            }
            else
            {
                lbl_donem.ForeColor = Color.Black;
                lbl_yıl.ForeColor = Color.Black;
                lbl_puan.ForeColor = Color.Black;
                lbl_aciklama.ForeColor = Color.Black;
                lbl_not.ForeColor = Color.Black;
            }



            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_sayi7.Text != "" && cb_yil_7.Text != "" && cb_7.Text != "")
                {

                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_KisiYillikPerformans", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@persormansDonemi", cb_7.Text);
                        eklekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi7.Text);
                        eklekomutu.Parameters.AddWithValue("@harfNotu", txt_harf7.Text);
                        eklekomutu.Parameters.AddWithValue("@yil", cb_yil_7.Text);
                        eklekomutu.Parameters.AddWithValue("@aciklama", lbl_7.Text);
                        eklekomutu.Parameters.AddWithValue("@calismaGrubu", cbx_calisan_grubu.Text);

                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin performans bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                    ekrani_temizle();
                    // listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamamıştır. Lütfen kontrol ediniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarasını gözden geçiriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

            }
        }

        private void btn_ekle_8_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (cb_yil_8.Text == "" || cb_8.Text == "" || txt_sayi8.Text == "")
            {
                lbl_donem.ForeColor = Color.Red;
                lbl_yıl.ForeColor = Color.Red;
                lbl_puan.ForeColor = Color.Red;
                lbl_aciklama.ForeColor = Color.Red;
                lbl_not.ForeColor = Color.Red;

            }
            else
            {
                lbl_donem.ForeColor = Color.Black;
                lbl_yıl.ForeColor = Color.Black;
                lbl_puan.ForeColor = Color.Black;
                lbl_aciklama.ForeColor = Color.Black;
                lbl_not.ForeColor = Color.Black;
            }



            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_sayi8.Text != "" && cb_yil_8.Text != "" && cb_8.Text != "")
                {

                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_KisiYillikPerformans", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@persormansDonemi", cb_8.Text);
                        eklekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi8.Text);
                        eklekomutu.Parameters.AddWithValue("@harfNotu", txt_harf8.Text);
                        eklekomutu.Parameters.AddWithValue("@yil", cb_yil_8.Text);
                        eklekomutu.Parameters.AddWithValue("@aciklama", lbl_8.Text);
                        eklekomutu.Parameters.AddWithValue("@calismaGrubu", cbx_calisan_grubu.Text);

                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin performans bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                    ekrani_temizle();
                    // listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamamıştır. Lütfen kontrol ediniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarasını gözden geçiriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

            }
        }

        private void btn_ekle_9_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (cb_yil_9.Text == "" || cb_9.Text == "" || txt_sayi9.Text == "")
            {
                lbl_donem.ForeColor = Color.Red;
                lbl_yıl.ForeColor = Color.Red;
                lbl_puan.ForeColor = Color.Red;
                lbl_aciklama.ForeColor = Color.Red;
                lbl_not.ForeColor = Color.Red;

            }
            else
            {
                lbl_donem.ForeColor = Color.Black;
                lbl_yıl.ForeColor = Color.Black;
                lbl_puan.ForeColor = Color.Black;
                lbl_aciklama.ForeColor = Color.Black;
                lbl_not.ForeColor = Color.Black;
            }



            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_sayi9.Text != "" && cb_yil_9.Text != "" && cb_9.Text != "")
                {

                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_KisiYillikPerformans", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@persormansDonemi", cb_9.Text);
                        eklekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi9.Text);
                        eklekomutu.Parameters.AddWithValue("@harfNotu", txt_harf9.Text);
                        eklekomutu.Parameters.AddWithValue("@yil", cb_yil_9.Text);
                        eklekomutu.Parameters.AddWithValue("@aciklama", lbl_9.Text);
                        eklekomutu.Parameters.AddWithValue("@calismaGrubu", cbx_calisan_grubu.Text);

                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin performans bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                    ekrani_temizle();
                    // listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamamıştır. Lütfen kontrol ediniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarasını gözden geçiriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

            }
        }

        private void btn_ekle_10_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (cb_yil_10.Text == "" || cb_10.Text == "" || txt_sayi10.Text == "")
            {
                lbl_donem.ForeColor = Color.Red;
                lbl_yıl.ForeColor = Color.Red;
                lbl_puan.ForeColor = Color.Red;
                lbl_aciklama.ForeColor = Color.Red;
                lbl_not.ForeColor = Color.Red;

            }
            else
            {
                lbl_donem.ForeColor = Color.Black;
                lbl_yıl.ForeColor = Color.Black;
                lbl_puan.ForeColor = Color.Black;
                lbl_aciklama.ForeColor = Color.Black;
                lbl_not.ForeColor = Color.Black;
            }



            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_sayi10.Text != "" && cb_yil_10.Text != "" && cb_10.Text != "")
                {

                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_KisiYillikPerformans", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@persormansDonemi", cb_10.Text);
                        eklekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi10.Text);
                        eklekomutu.Parameters.AddWithValue("@harfNotu", txt_harf10.Text);
                        eklekomutu.Parameters.AddWithValue("@yil", cb_yil_10.Text);
                        eklekomutu.Parameters.AddWithValue("@aciklama", lbl_10.Text);
                        eklekomutu.Parameters.AddWithValue("@calismaGrubu", cbx_calisan_grubu.Text);

                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin performans bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                    ekrani_temizle();
                    // listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamamıştır. Lütfen kontrol ediniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarasını gözden geçiriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

            }
        }

        private void btn_ekle_11_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (cb_yil_11.Text == "" || cb_11.Text == "" || txt_sayi11.Text == "")
            {
                lbl_donem.ForeColor = Color.Red;
                lbl_yıl.ForeColor = Color.Red;
                lbl_puan.ForeColor = Color.Red;
                lbl_aciklama.ForeColor = Color.Red;
                lbl_not.ForeColor = Color.Red;

            }
            else
            {
                lbl_donem.ForeColor = Color.Black;
                lbl_yıl.ForeColor = Color.Black;
                lbl_puan.ForeColor = Color.Black;
                lbl_aciklama.ForeColor = Color.Black;
                lbl_not.ForeColor = Color.Black;
            }



            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_sayi11.Text != "" && cb_yil_11.Text != "" && cb_11.Text != "")
                {

                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_KisiYillikPerformans", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@persormansDonemi", cb_11.Text);
                        eklekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi11.Text);
                        eklekomutu.Parameters.AddWithValue("@harfNotu", txt_harf11.Text);
                        eklekomutu.Parameters.AddWithValue("@yil", cb_yil_11.Text);
                        eklekomutu.Parameters.AddWithValue("@aciklama", lbl_11.Text);
                        eklekomutu.Parameters.AddWithValue("@calismaGrubu", cbx_calisan_grubu.Text);

                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin performans bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                    ekrani_temizle();
                    // listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamamıştır. Lütfen kontrol ediniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarasını gözden geçiriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

            }
        }

        private void btn_ekle_12_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (cb_yil_12.Text == "" || cb_12.Text == "" || txt_sayi12.Text == "")
            {
                lbl_donem.ForeColor = Color.Red;
                lbl_yıl.ForeColor = Color.Red;
                lbl_puan.ForeColor = Color.Red;
                lbl_aciklama.ForeColor = Color.Red;
                lbl_not.ForeColor = Color.Red;

            }
            else
            {
                lbl_donem.ForeColor = Color.Black;
                lbl_yıl.ForeColor = Color.Black;
                lbl_puan.ForeColor = Color.Black;
                lbl_aciklama.ForeColor = Color.Black;
                lbl_not.ForeColor = Color.Black;
            }



            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_sayi12.Text != "" && cb_yil_12.Text != "" && cb_12.Text != "")
                {

                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand eklekomutu = new SqlCommand("Kaydet_KisiYillikPerformans", baglantim.baglanti());
                        eklekomutu.CommandType = CommandType.StoredProcedure;

                        eklekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                        eklekomutu.Parameters.AddWithValue("@persormansDonemi", cb_12.Text);
                        eklekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi12.Text);
                        eklekomutu.Parameters.AddWithValue("@harfNotu", txt_harf12.Text);
                        eklekomutu.Parameters.AddWithValue("@yil", cb_yil_12.Text);
                        eklekomutu.Parameters.AddWithValue("@aciklama", lbl_12.Text);
                        eklekomutu.Parameters.AddWithValue("@calismaGrubu", cbx_calisan_grubu.Text);

                        eklekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin performans bilgileri başarılı bir şekilde kaydedilmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                    ekrani_temizle();
                    // listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamamıştır. Lütfen kontrol ediniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarasını gözden geçiriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

            }
        }

        DataTable dtp = new DataTable();

        public void listele()
        {
            // gridControl1.DataSource = null;
            //gridView1.Columns.Clear();

            SqlCommand sorgu = new SqlCommand("tum_kisiYillikPerformans", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sorgu);
            sorgu.Parameters.AddWithValue("@kisi_tc", mtxt_tc_no.Text);

            sorgu.Parameters.AddWithValue("@yil", cb_yil_sec.Text);

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
                    lbl_ortalama.Text = kayitokuma2.GetValue(1).ToString();
                }
                else
                { MessageBox.Show("Test"); }

                break;
            }


        }



        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            //birinci satır için ilgili değerlerin forma aktarılması
            if (gridView1.GetFocusedRowCellValue("DÖNEM").ToString() == "1")
            {
                cb_1.Text = gridView1.GetFocusedRowCellValue("DÖNEM").ToString();
                lbl_1.Text = gridView1.GetFocusedRowCellValue("AÇIKLAMA").ToString();
                txt_sayi1.Text = gridView1.GetFocusedRowCellValue("SAYI").ToString();
                cbx_calisan_grubu.Text = gridView1.GetFocusedRowCellValue("ÇALIŞAN GRUBU").ToString();
                txt_id_1.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                lbl_1.Text = gridView1.GetFocusedRowCellValue("AÇIKLAMA").ToString();
                txt_harf1.Text = gridView1.GetFocusedRowCellValue("HARF NOTU").ToString();
                cb_yil_1.Text = gridView1.GetFocusedRowCellValue("YIL").ToString();
            }


            //2. satır için ilgili değerlerin forma aktarılması
            if (gridView1.GetFocusedRowCellValue("DÖNEM").ToString() == "2")
            {
                cb_2.Text = gridView1.GetFocusedRowCellValue("DÖNEM").ToString();
                lbl_2.Text = gridView1.GetFocusedRowCellValue("AÇIKLAMA").ToString();
                txt_sayi2.Text = gridView1.GetFocusedRowCellValue("SAYI").ToString();
                cbx_calisan_grubu.Text = gridView1.GetFocusedRowCellValue("ÇALIŞAN GRUBU").ToString();
                txt_id_2.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                lbl_2.Text = gridView1.GetFocusedRowCellValue("AÇIKLAMA").ToString();
                txt_harf2.Text = gridView1.GetFocusedRowCellValue("HARF NOTU").ToString();
                cb_yil_2.Text = gridView1.GetFocusedRowCellValue("YIL").ToString();
            }


            //3. satır için ilgili değerlerin forma aktarılması
            if (gridView1.GetFocusedRowCellValue("DÖNEM").ToString() == "3")
            {
                cb_3.Text = gridView1.GetFocusedRowCellValue("DÖNEM").ToString();
                lbl_3.Text = gridView1.GetFocusedRowCellValue("AÇIKLAMA").ToString();
                txt_sayi3.Text = gridView1.GetFocusedRowCellValue("SAYI").ToString();
                cbx_calisan_grubu.Text = gridView1.GetFocusedRowCellValue("ÇALIŞAN GRUBU").ToString();
                txt_id_3.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                lbl_3.Text = gridView1.GetFocusedRowCellValue("AÇIKLAMA").ToString();
                txt_harf3.Text = gridView1.GetFocusedRowCellValue("HARF NOTU").ToString();
                cb_yil_3.Text = gridView1.GetFocusedRowCellValue("YIL").ToString();
            }


            //4. satır için ilgili değerlerin forma aktarılması
            if (gridView1.GetFocusedRowCellValue("DÖNEM").ToString() == "4")
            {
                cb_4.Text = gridView1.GetFocusedRowCellValue("DÖNEM").ToString();
                lbl_4.Text = gridView1.GetFocusedRowCellValue("AÇIKLAMA").ToString();
                txt_sayi4.Text = gridView1.GetFocusedRowCellValue("SAYI").ToString();
                cbx_calisan_grubu.Text = gridView1.GetFocusedRowCellValue("ÇALIŞAN GRUBU").ToString();
                txt_id_4.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                lbl_4.Text = gridView1.GetFocusedRowCellValue("AÇIKLAMA").ToString();
                txt_harf4.Text = gridView1.GetFocusedRowCellValue("HARF NOTU").ToString();
                cb_yil_4.Text = gridView1.GetFocusedRowCellValue("YIL").ToString();
            }



            //5. satır için ilgili değerlerin forma aktarılması
            if (gridView1.GetFocusedRowCellValue("DÖNEM").ToString() == "5")
            {
                cb_5.Text = gridView1.GetFocusedRowCellValue("DÖNEM").ToString();
                lbl_5.Text = gridView1.GetFocusedRowCellValue("AÇIKLAMA").ToString();
                txt_sayi5.Text = gridView1.GetFocusedRowCellValue("SAYI").ToString();
                cbx_calisan_grubu.Text = gridView1.GetFocusedRowCellValue("ÇALIŞAN GRUBU").ToString();
                txt_id_5.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                lbl_5.Text = gridView1.GetFocusedRowCellValue("AÇIKLAMA").ToString();
                txt_harf5.Text = gridView1.GetFocusedRowCellValue("HARF NOTU").ToString();
                cb_yil_5.Text = gridView1.GetFocusedRowCellValue("YIL").ToString();
            }



            //6. satır için ilgili değerlerin forma aktarılması
            if (gridView1.GetFocusedRowCellValue("DÖNEM").ToString() == "6")
            {
                cb_6.Text = gridView1.GetFocusedRowCellValue("DÖNEM").ToString();
                lbl_6.Text = gridView1.GetFocusedRowCellValue("AÇIKLAMA").ToString();
                txt_sayi6.Text = gridView1.GetFocusedRowCellValue("SAYI").ToString();
                cbx_calisan_grubu.Text = gridView1.GetFocusedRowCellValue("ÇALIŞAN GRUBU").ToString();
                txt_id_6.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                lbl_6.Text = gridView1.GetFocusedRowCellValue("AÇIKLAMA").ToString();
                txt_harf6.Text = gridView1.GetFocusedRowCellValue("HARF NOTU").ToString();
                cb_yil_6.Text = gridView1.GetFocusedRowCellValue("YIL").ToString();
            }


            //7. satır için ilgili değerlerin forma aktarılması
            if (gridView1.GetFocusedRowCellValue("DÖNEM").ToString() == "7")
            {
                cb_7.Text = gridView1.GetFocusedRowCellValue("DÖNEM").ToString();
                lbl_7.Text = gridView1.GetFocusedRowCellValue("AÇIKLAMA").ToString();
                txt_sayi7.Text = gridView1.GetFocusedRowCellValue("SAYI").ToString();
                cbx_calisan_grubu.Text = gridView1.GetFocusedRowCellValue("ÇALIŞAN GRUBU").ToString();
                txt_id_7.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                lbl_7.Text = gridView1.GetFocusedRowCellValue("AÇIKLAMA").ToString();
                txt_harf7.Text = gridView1.GetFocusedRowCellValue("HARF NOTU").ToString();
                cb_yil_7.Text = gridView1.GetFocusedRowCellValue("YIL").ToString();
            }



            //8. satır için ilgili değerlerin forma aktarılması
            if (gridView1.GetFocusedRowCellValue("DÖNEM").ToString() == "8")
            {
                cb_8.Text = gridView1.GetFocusedRowCellValue("DÖNEM").ToString();
                lbl_8.Text = gridView1.GetFocusedRowCellValue("AÇIKLAMA").ToString();
                txt_sayi8.Text = gridView1.GetFocusedRowCellValue("SAYI").ToString();
                cbx_calisan_grubu.Text = gridView1.GetFocusedRowCellValue("ÇALIŞAN GRUBU").ToString();
                txt_id_8.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                lbl_8.Text = gridView1.GetFocusedRowCellValue("AÇIKLAMA").ToString();
                txt_harf8.Text = gridView1.GetFocusedRowCellValue("HARF NOTU").ToString();
                cb_yil_8.Text = gridView1.GetFocusedRowCellValue("YIL").ToString();
            }



            //9. satır için ilgili değerlerin forma aktarılması
            if (gridView1.GetFocusedRowCellValue("DÖNEM").ToString() == "9")
            {
                cb_9.Text = gridView1.GetFocusedRowCellValue("DÖNEM").ToString();
                lbl_9.Text = gridView1.GetFocusedRowCellValue("AÇIKLAMA").ToString();
                txt_sayi9.Text = gridView1.GetFocusedRowCellValue("SAYI").ToString();
                cbx_calisan_grubu.Text = gridView1.GetFocusedRowCellValue("ÇALIŞAN GRUBU").ToString();
                txt_id_9.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                lbl_9.Text = gridView1.GetFocusedRowCellValue("AÇIKLAMA").ToString();
                txt_harf9.Text = gridView1.GetFocusedRowCellValue("HARF NOTU").ToString();
                cb_yil_9.Text = gridView1.GetFocusedRowCellValue("YIL").ToString();
            }



            //10. satır için ilgili değerlerin forma aktarılması
            if (gridView1.GetFocusedRowCellValue("DÖNEM").ToString() == "10")
            {
                cb_10.Text = gridView1.GetFocusedRowCellValue("DÖNEM").ToString();
                lbl_10.Text = gridView1.GetFocusedRowCellValue("AÇIKLAMA").ToString();
                txt_sayi10.Text = gridView1.GetFocusedRowCellValue("SAYI").ToString();
                cbx_calisan_grubu.Text = gridView1.GetFocusedRowCellValue("ÇALIŞAN GRUBU").ToString();
                txt_id_10.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                lbl_10.Text = gridView1.GetFocusedRowCellValue("AÇIKLAMA").ToString();
                txt_harf10.Text = gridView1.GetFocusedRowCellValue("HARF NOTU").ToString();
                cb_yil_10.Text = gridView1.GetFocusedRowCellValue("YIL").ToString();
            }


            //11. satır için ilgili değerlerin forma aktarılması
            if (gridView1.GetFocusedRowCellValue("DÖNEM").ToString() == "11")
            {
                cb_11.Text = gridView1.GetFocusedRowCellValue("DÖNEM").ToString();
                lbl_11.Text = gridView1.GetFocusedRowCellValue("AÇIKLAMA").ToString();
                txt_sayi11.Text = gridView1.GetFocusedRowCellValue("SAYI").ToString();
                cbx_calisan_grubu.Text = gridView1.GetFocusedRowCellValue("ÇALIŞAN GRUBU").ToString();
                txt_id_11.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                lbl_11.Text = gridView1.GetFocusedRowCellValue("AÇIKLAMA").ToString();
                txt_harf11.Text = gridView1.GetFocusedRowCellValue("HARF NOTU").ToString();
                cb_yil_11.Text = gridView1.GetFocusedRowCellValue("YIL").ToString();
            }


            //12. satır için ilgili değerlerin forma aktarılması
            if (gridView1.GetFocusedRowCellValue("DÖNEM").ToString() == "12")
            {
                cb_12.Text = gridView1.GetFocusedRowCellValue("DÖNEM").ToString();
                lbl_12.Text = gridView1.GetFocusedRowCellValue("AÇIKLAMA").ToString();
                txt_sayi12.Text = gridView1.GetFocusedRowCellValue("SAYI").ToString();
                cbx_calisan_grubu.Text = gridView1.GetFocusedRowCellValue("ÇALIŞAN GRUBU").ToString();
                txt_id_12.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                lbl_12.Text = gridView1.GetFocusedRowCellValue("AÇIKLAMA").ToString();
                txt_harf12.Text = gridView1.GetFocusedRowCellValue("HARF NOTU").ToString();
                cb_yil_12.Text = gridView1.GetFocusedRowCellValue("YIL").ToString();
            }

        }




        private void btn_guncelle_1_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (cb_yil_1.Text == "" || cb_1.Text == "" || txt_sayi1.Text == "")
            {
                lbl_donem.ForeColor = Color.Red;
                lbl_yıl.ForeColor = Color.Red;
                lbl_puan.ForeColor = Color.Red;
                lbl_aciklama.ForeColor = Color.Red;
                lbl_not.ForeColor = Color.Red;

            }
            else
            {
                lbl_donem.ForeColor = Color.Black;
                lbl_yıl.ForeColor = Color.Black;
                lbl_puan.ForeColor = Color.Black;
                lbl_aciklama.ForeColor = Color.Black;
                lbl_not.ForeColor = Color.Black;
            }



            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_sayi1.Text != "" && cb_yil_1.Text != "" && cb_1.Text != "")
                {

                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_KisiYillikPerformans", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@persormansDonemi", cb_1.Text);
                        guncellekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi1.Text);
                        guncellekomutu.Parameters.AddWithValue("@harfNotu", txt_harf1.Text);
                        guncellekomutu.Parameters.AddWithValue("@yil", cb_yil_1.Text);
                        guncellekomutu.Parameters.AddWithValue("@aciklama", lbl_1.Text);
                        guncellekomutu.Parameters.AddWithValue("@calismaGrubu", cbx_calisan_grubu.Text);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_1.Text);
                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin performans bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                                                                                                                                                                                        // ekrani_temizle();
                                                                                                                                                                                        // listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamamıştır. Lütfen kontrol ediniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarasını gözden geçiriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

            }
        }

        private void btn_guncelle_2_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (cb_yil_2.Text == "" || cb_2.Text == "" || txt_sayi2.Text == "")
            {
                lbl_donem.ForeColor = Color.Red;
                lbl_yıl.ForeColor = Color.Red;
                lbl_puan.ForeColor = Color.Red;
                lbl_aciklama.ForeColor = Color.Red;
                lbl_not.ForeColor = Color.Red;

            }
            else
            {
                lbl_donem.ForeColor = Color.Black;
                lbl_yıl.ForeColor = Color.Black;
                lbl_puan.ForeColor = Color.Black;
                lbl_aciklama.ForeColor = Color.Black;
                lbl_not.ForeColor = Color.Black;
            }



            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_sayi2.Text != "" && cb_yil_2.Text != "" && cb_2.Text != "")
                {

                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_KisiYillikPerformans", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@persormansDonemi", cb_2.Text);
                        guncellekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi2.Text);
                        guncellekomutu.Parameters.AddWithValue("@harfNotu", txt_harf2.Text);
                        guncellekomutu.Parameters.AddWithValue("@yil", cb_yil_2.Text);
                        guncellekomutu.Parameters.AddWithValue("@aciklama", lbl_2.Text);
                        guncellekomutu.Parameters.AddWithValue("@calismaGrubu", cbx_calisan_grubu.Text);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_2.Text);
                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin performans bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                    //ekrani_temizle();
                    // listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamamıştır. Lütfen kontrol ediniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarasını gözden geçiriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

            }
        }

        private void btn_guncelle_3_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (cb_yil_3.Text == "" || cb_3.Text == "" || txt_sayi3.Text == "")
            {
                lbl_donem.ForeColor = Color.Red;
                lbl_yıl.ForeColor = Color.Red;
                lbl_puan.ForeColor = Color.Red;
                lbl_aciklama.ForeColor = Color.Red;
                lbl_not.ForeColor = Color.Red;

            }
            else
            {
                lbl_donem.ForeColor = Color.Black;
                lbl_yıl.ForeColor = Color.Black;
                lbl_puan.ForeColor = Color.Black;
                lbl_aciklama.ForeColor = Color.Black;
                lbl_not.ForeColor = Color.Black;
            }



            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_sayi3.Text != "" && cb_yil_3.Text != "" && cb_3.Text != "")
                {

                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_KisiYillikPerformans", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@persormansDonemi", cb_3.Text);
                        guncellekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi3.Text);
                        guncellekomutu.Parameters.AddWithValue("@harfNotu", txt_harf3.Text);
                        guncellekomutu.Parameters.AddWithValue("@yil", cb_yil_3.Text);
                        guncellekomutu.Parameters.AddWithValue("@aciklama", lbl_3.Text);
                        guncellekomutu.Parameters.AddWithValue("@calismaGrubu", cbx_calisan_grubu.Text);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_3.Text);
                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin performans bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                                                                                                                                                                                        //  ekrani_temizle();
                                                                                                                                                                                        // listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamamıştır. Lütfen kontrol ediniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarasını gözden geçiriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

            }
        }

        private void btn_guncelle_4_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (cb_yil_4.Text == "" || cb_4.Text == "" || txt_sayi4.Text == "")
            {
                lbl_donem.ForeColor = Color.Red;
                lbl_yıl.ForeColor = Color.Red;
                lbl_puan.ForeColor = Color.Red;
                lbl_aciklama.ForeColor = Color.Red;
                lbl_not.ForeColor = Color.Red;

            }
            else
            {
                lbl_donem.ForeColor = Color.Black;
                lbl_yıl.ForeColor = Color.Black;
                lbl_puan.ForeColor = Color.Black;
                lbl_aciklama.ForeColor = Color.Black;
                lbl_not.ForeColor = Color.Black;
            }



            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_sayi4.Text != "" && cb_yil_4.Text != "" && cb_4.Text != "")
                {

                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_KisiYillikPerformans", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@persormansDonemi", cb_4.Text);
                        guncellekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi4.Text);
                        guncellekomutu.Parameters.AddWithValue("@harfNotu", txt_harf4.Text);
                        guncellekomutu.Parameters.AddWithValue("@yil", cb_yil_4.Text);
                        guncellekomutu.Parameters.AddWithValue("@aciklama", lbl_4.Text);
                        guncellekomutu.Parameters.AddWithValue("@calismaGrubu", cbx_calisan_grubu.Text);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_4.Text);
                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin performans bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                                                                                                                                                                                        // ekrani_temizle();
                                                                                                                                                                                        // listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamamıştır. Lütfen kontrol ediniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarasını gözden geçiriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

            }
        }

        private void btn_guncelle_5_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (cb_yil_5.Text == "" || cb_5.Text == "" || txt_sayi5.Text == "")
            {
                lbl_donem.ForeColor = Color.Red;
                lbl_yıl.ForeColor = Color.Red;
                lbl_puan.ForeColor = Color.Red;
                lbl_aciklama.ForeColor = Color.Red;
                lbl_not.ForeColor = Color.Red;

            }
            else
            {
                lbl_donem.ForeColor = Color.Black;
                lbl_yıl.ForeColor = Color.Black;
                lbl_puan.ForeColor = Color.Black;
                lbl_aciklama.ForeColor = Color.Black;
                lbl_not.ForeColor = Color.Black;
            }



            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_sayi5.Text != "" && cb_yil_5.Text != "" && cb_5.Text != "")
                {

                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_KisiYillikPerformans", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@persormansDonemi", cb_5.Text);
                        guncellekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi5.Text);
                        guncellekomutu.Parameters.AddWithValue("@harfNotu", txt_harf5.Text);
                        guncellekomutu.Parameters.AddWithValue("@yil", cb_yil_5.Text);
                        guncellekomutu.Parameters.AddWithValue("@aciklama", lbl_5.Text);
                        guncellekomutu.Parameters.AddWithValue("@calismaGrubu", cbx_calisan_grubu.Text);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_5.Text);
                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin performans bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                                                                                                                                                                                        //  ekrani_temizle();
                                                                                                                                                                                        // listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamamıştır. Lütfen kontrol ediniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarasını gözden geçiriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

            }
        }

        private void btn_guncelle_6_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (cb_yil_6.Text == "" || cb_6.Text == "" || txt_sayi6.Text == "")
            {
                lbl_donem.ForeColor = Color.Red;
                lbl_yıl.ForeColor = Color.Red;
                lbl_puan.ForeColor = Color.Red;
                lbl_aciklama.ForeColor = Color.Red;
                lbl_not.ForeColor = Color.Red;

            }
            else
            {
                lbl_donem.ForeColor = Color.Black;
                lbl_yıl.ForeColor = Color.Black;
                lbl_puan.ForeColor = Color.Black;
                lbl_aciklama.ForeColor = Color.Black;
                lbl_not.ForeColor = Color.Black;
            }



            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_sayi6.Text != "" && cb_yil_6.Text != "" && cb_6.Text != "")
                {

                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_KisiYillikPerformans", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@persormansDonemi", cb_6.Text);
                        guncellekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi6.Text);
                        guncellekomutu.Parameters.AddWithValue("@harfNotu", txt_harf6.Text);
                        guncellekomutu.Parameters.AddWithValue("@yil", cb_yil_6.Text);
                        guncellekomutu.Parameters.AddWithValue("@aciklama", lbl_6.Text);
                        guncellekomutu.Parameters.AddWithValue("@calismaGrubu", cbx_calisan_grubu.Text);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_6.Text);
                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin performans bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                                                                                                                                                                                        //  ekrani_temizle();
                                                                                                                                                                                        // listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamamıştır. Lütfen kontrol ediniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarasını gözden geçiriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

            }
        }

        private void btn_guncelle_7_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (cb_yil_7.Text == "" || cb_7.Text == "" || txt_sayi7.Text == "")
            {
                lbl_donem.ForeColor = Color.Red;
                lbl_yıl.ForeColor = Color.Red;
                lbl_puan.ForeColor = Color.Red;
                lbl_aciklama.ForeColor = Color.Red;
                lbl_not.ForeColor = Color.Red;

            }
            else
            {
                lbl_donem.ForeColor = Color.Black;
                lbl_yıl.ForeColor = Color.Black;
                lbl_puan.ForeColor = Color.Black;
                lbl_aciklama.ForeColor = Color.Black;
                lbl_not.ForeColor = Color.Black;
            }



            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_sayi7.Text != "" && cb_yil_7.Text != "" && cb_7.Text != "")
                {

                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_KisiYillikPerformans", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@persormansDonemi", cb_7.Text);
                        guncellekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi7.Text);
                        guncellekomutu.Parameters.AddWithValue("@harfNotu", txt_harf7.Text);
                        guncellekomutu.Parameters.AddWithValue("@yil", cb_yil_7.Text);
                        guncellekomutu.Parameters.AddWithValue("@aciklama", lbl_7.Text);
                        guncellekomutu.Parameters.AddWithValue("@calismaGrubu", cbx_calisan_grubu.Text);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_7.Text);
                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin performans bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                                                                                                                                                                                        //   ekrani_temizle();
                                                                                                                                                                                        // listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamamıştır. Lütfen kontrol ediniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarasını gözden geçiriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

            }
        }

        private void btn_guncelle_8_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (cb_yil_8.Text == "" || cb_8.Text == "" || txt_sayi8.Text == "")
            {
                lbl_donem.ForeColor = Color.Red;
                lbl_yıl.ForeColor = Color.Red;
                lbl_puan.ForeColor = Color.Red;
                lbl_aciklama.ForeColor = Color.Red;
                lbl_not.ForeColor = Color.Red;

            }
            else
            {
                lbl_donem.ForeColor = Color.Black;
                lbl_yıl.ForeColor = Color.Black;
                lbl_puan.ForeColor = Color.Black;
                lbl_aciklama.ForeColor = Color.Black;
                lbl_not.ForeColor = Color.Black;
            }



            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_sayi8.Text != "" && cb_yil_8.Text != "" && cb_8.Text != "")
                {

                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_KisiYillikPerformans", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@persormansDonemi", cb_8.Text);
                        guncellekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi8.Text);
                        guncellekomutu.Parameters.AddWithValue("@harfNotu", txt_harf8.Text);
                        guncellekomutu.Parameters.AddWithValue("@yil", cb_yil_8.Text);
                        guncellekomutu.Parameters.AddWithValue("@aciklama", lbl_8.Text);
                        guncellekomutu.Parameters.AddWithValue("@calismaGrubu", cbx_calisan_grubu.Text);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_8.Text);
                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin performans bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                                                                                                                                                                                        //  ekrani_temizle();
                                                                                                                                                                                        // listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamamıştır. Lütfen kontrol ediniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarasını gözden geçiriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

            }
        }

        private void btn_guncelle_9_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (cb_yil_9.Text == "" || cb_9.Text == "" || txt_sayi9.Text == "")
            {
                lbl_donem.ForeColor = Color.Red;
                lbl_yıl.ForeColor = Color.Red;
                lbl_puan.ForeColor = Color.Red;
                lbl_aciklama.ForeColor = Color.Red;
                lbl_not.ForeColor = Color.Red;

            }
            else
            {
                lbl_donem.ForeColor = Color.Black;
                lbl_yıl.ForeColor = Color.Black;
                lbl_puan.ForeColor = Color.Black;
                lbl_aciklama.ForeColor = Color.Black;
                lbl_not.ForeColor = Color.Black;
            }



            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_sayi9.Text != "" && cb_yil_9.Text != "" && cb_9.Text != "")
                {

                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_KisiYillikPerformans", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@persormansDonemi", cb_9.Text);
                        guncellekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi9.Text);
                        guncellekomutu.Parameters.AddWithValue("@harfNotu", txt_harf9.Text);
                        guncellekomutu.Parameters.AddWithValue("@yil", cb_yil_9.Text);
                        guncellekomutu.Parameters.AddWithValue("@aciklama", lbl_9.Text);
                        guncellekomutu.Parameters.AddWithValue("@calismaGrubu", cbx_calisan_grubu.Text);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_9.Text);
                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin performans bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                                                                                                                                                                                        // ekrani_temizle();
                                                                                                                                                                                        // listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamamıştır. Lütfen kontrol ediniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarasını gözden geçiriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

            }
        }

        private void btn_guncelle_10_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (cb_yil_10.Text == "" || cb_10.Text == "" || txt_sayi10.Text == "")
            {
                lbl_donem.ForeColor = Color.Red;
                lbl_yıl.ForeColor = Color.Red;
                lbl_puan.ForeColor = Color.Red;
                lbl_aciklama.ForeColor = Color.Red;
                lbl_not.ForeColor = Color.Red;

            }
            else
            {
                lbl_donem.ForeColor = Color.Black;
                lbl_yıl.ForeColor = Color.Black;
                lbl_puan.ForeColor = Color.Black;
                lbl_aciklama.ForeColor = Color.Black;
                lbl_not.ForeColor = Color.Black;
            }



            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_sayi10.Text != "" && cb_yil_10.Text != "" && cb_10.Text != "")
                {

                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_KisiYillikPerformans", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@persormansDonemi", cb_10.Text);
                        guncellekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi10.Text);
                        guncellekomutu.Parameters.AddWithValue("@harfNotu", txt_harf10.Text);
                        guncellekomutu.Parameters.AddWithValue("@yil", cb_yil_10.Text);
                        guncellekomutu.Parameters.AddWithValue("@aciklama", lbl_10.Text);
                        guncellekomutu.Parameters.AddWithValue("@calismaGrubu", cbx_calisan_grubu.Text);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_10.Text);
                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin performans bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                                                                                                                                                                                        // ekrani_temizle();
                                                                                                                                                                                        // listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamamıştır. Lütfen kontrol ediniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarasını gözden geçiriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

            }
        }

        private void btn_guncelle_11_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (cb_yil_1.Text == "" || cb_1.Text == "" || txt_sayi1.Text == "")
            {
                lbl_donem.ForeColor = Color.Red;
                lbl_yıl.ForeColor = Color.Red;
                lbl_puan.ForeColor = Color.Red;
                lbl_aciklama.ForeColor = Color.Red;
                lbl_not.ForeColor = Color.Red;

            }
            else
            {
                lbl_donem.ForeColor = Color.Black;
                lbl_yıl.ForeColor = Color.Black;
                lbl_puan.ForeColor = Color.Black;
                lbl_aciklama.ForeColor = Color.Black;
                lbl_not.ForeColor = Color.Black;
            }



            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_sayi11.Text != "" && cb_yil_11.Text != "" && cb_11.Text != "")
                {

                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_KisiYillikPerformans", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@persormansDonemi", cb_11.Text);
                        guncellekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi11.Text);
                        guncellekomutu.Parameters.AddWithValue("@harfNotu", txt_harf11.Text);
                        guncellekomutu.Parameters.AddWithValue("@yil", cb_yil_11.Text);
                        guncellekomutu.Parameters.AddWithValue("@aciklama", lbl_11.Text);
                        guncellekomutu.Parameters.AddWithValue("@calismaGrubu", cbx_calisan_grubu.Text);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_11.Text);
                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin performans bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                                                                                                                                                                                        //   ekrani_temizle();
                                                                                                                                                                                        // listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamamıştır. Lütfen kontrol ediniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarasını gözden geçiriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

            }
        }

        private void btn_guncelle_12_Click(object sender, EventArgs e)
        {
            SqlCommand selectsorgu = new SqlCommand("select * from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());

            SqlDataReader kayitokuma = selectsorgu.ExecuteReader();//okuduğu sorguları tutuyoruz.

            //kullnıcı bir tc kimlik no girecektir fakat girdiği numara gerçekten tc numarası mı onun kontrolü yapılmalıdr.

            if (mtxt_tc_no.Text.Length < 11 || mtxt_tc_no.Text == "")//tc kimlik numarsaı 11 den küçük olmamalıdr. veya boş olmalaıdr. eğer olur ise tc kimlik no yazısı kırmızı olacaktır.
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (cb_yil_12.Text == "" || cb_12.Text == "" || txt_sayi12.Text == "")
            {
                lbl_donem.ForeColor = Color.Red;
                lbl_yıl.ForeColor = Color.Red;
                lbl_puan.ForeColor = Color.Red;
                lbl_aciklama.ForeColor = Color.Red;
                lbl_not.ForeColor = Color.Red;

            }
            else
            {
                lbl_donem.ForeColor = Color.Black;
                lbl_yıl.ForeColor = Color.Black;
                lbl_puan.ForeColor = Color.Black;
                lbl_aciklama.ForeColor = Color.Black;
                lbl_not.ForeColor = Color.Black;
            }



            if (mtxt_tc_no.Text.Length == 11)
            {
                bool ekle = false;
                if (txt_sayi12.Text != "" && cb_yil_12.Text != "" && cb_12.Text != "")
                {

                    ekle = true;
                    btn_forma_ekle.Enabled = true;
                    try
                    {
                        SqlCommand guncellekomutu = new SqlCommand("Guncelle_KisiYillikPerformans", baglantim.baglanti());
                        guncellekomutu.CommandType = CommandType.StoredProcedure;

                        guncellekomutu.Parameters.AddWithValue("@Kisi_tc", mtxt_tc_no.Text);
                        guncellekomutu.Parameters.AddWithValue("@persormansDonemi", cb_12.Text);
                        guncellekomutu.Parameters.AddWithValue("@sayisalKarsilik", txt_sayi12.Text);
                        guncellekomutu.Parameters.AddWithValue("@harfNotu", txt_harf12.Text);
                        guncellekomutu.Parameters.AddWithValue("@yil", cb_yil_12.Text);
                        guncellekomutu.Parameters.AddWithValue("@aciklama", lbl_12.Text);
                        guncellekomutu.Parameters.AddWithValue("@calismaGrubu", cbx_calisan_grubu.Text);
                        guncellekomutu.Parameters.AddWithValue("@id", txt_id_12.Text);
                        guncellekomutu.ExecuteNonQuery();//sorgu sonuçları bağlantı tablosuna eklenir

                    }
                    catch (Exception hatamjs)
                    {
                        //kayıt esnasında herhangi bir hata ile karşılaşıldığında
                        MessageBox.Show(hatamjs.Message);


                    }
                }
                if (ekle == true)
                {

                    MessageBox.Show("Kişinin performans bilgileri başarılı bir şekilde güncellenmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.
                                                                                                                                                                                        //  ekrani_temizle();
                                                                                                                                                                                        // listele();
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamamıştır. Lütfen kontrol ediniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

                }
            }
            else
            {
                MessageBox.Show("TC kimlik numarasını gözden geçiriniz.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//ilk tırnak içi mesaj içeriği ikinci tırnak içi mesaj kutusunun başlığıdır.

            }
        }

        private void btn_sil_1_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11)

            {
                bool sil = false;
                if (cb_1.Text != "" && txt_sayi1.Text != "" && txt_harf1.Text != "")
                {
                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {



                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_id_1.Text + "'and yil='" + cb_yil_1.Text + "'and persormansDonemi='" + cb_1.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        //     MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        sil = true;
                        //ekrani_temizle();

                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

                if (sil == true)
                {
                    MessageBox.Show("Kullanıcının ilgili  performans bilgisi başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                // ekrani_temizle();


            }
            else
            {
                MessageBox.Show("TC kimlik no 11 haneli girilmelidir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sil_2_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11)

            {
                bool sil = false;
                if (cb_2.Text != "" && txt_sayi2.Text != "" && txt_harf2.Text != "")
                {
                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {



                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_id_2.Text + "'and yil='" + cb_yil_2.Text + "'and persormansDonemi='" + cb_2.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        //     MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        sil = true;
                        //ekrani_temizle();

                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

                if (sil == true)
                {
                    MessageBox.Show("Kullanıcının ilgili  performans bilgisi başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                // ekrani_temizle();


            }
            else
            {
                MessageBox.Show("TC kimlik no 11 haneli girilmelidir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sil_3_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11)

            {
                bool sil = false;
                if (cb_3.Text != "" && txt_sayi3.Text != "" && txt_harf3.Text != "")
                {
                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {



                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_id_3.Text + "'and yil='" + cb_yil_3.Text + "'and persormansDonemi='" + cb_3.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        //     MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        sil = true;
                        //ekrani_temizle();

                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

                if (sil == true)
                {
                    MessageBox.Show("Kullanıcının ilgili  performans bilgisi başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //    ekrani_temizle();


            }
            else
            {
                MessageBox.Show("TC kimlik no 11 haneli girilmelidir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sil_4_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11)

            {
                bool sil = false;
                if (cb_4.Text != "" && txt_sayi4.Text != "" && txt_harf4.Text != "")
                {
                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {



                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_id_4.Text + "'and yil='" + cb_yil_4.Text + "'and persormansDonemi='" + cb_4.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        //     MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        sil = true;
                        //ekrani_temizle();

                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

                if (sil == true)
                {
                    MessageBox.Show("Kullanıcının ilgili  performans bilgisi başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                // ekrani_temizle();


            }
            else
            {
                MessageBox.Show("TC kimlik no 11 haneli girilmelidir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sil_5_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11)

            {
                bool sil = false;
                if (cb_5.Text != "" && txt_sayi5.Text != "" && txt_harf5.Text != "")
                {
                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {



                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_id_5.Text + "'and yil='" + cb_yil_5.Text + "'and persormansDonemi='" + cb_5.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        //     MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        sil = true;
                        //ekrani_temizle();

                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

                if (sil == true)
                {
                    MessageBox.Show("Kullanıcının ilgili  performans bilgisi başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                // ekrani_temizle();


            }
            else
            {
                MessageBox.Show("TC kimlik no 11 haneli girilmelidir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sil_6_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11)

            {
                bool sil = false;
                if (cb_6.Text != "" && txt_sayi6.Text != "" && txt_harf6.Text != "")
                {
                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {



                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_id_6.Text + "'and yil='" + cb_yil_6.Text + "'and persormansDonemi='" + cb_6.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        //     MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        sil = true;
                        //ekrani_temizle();

                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

                if (sil == true)
                {
                    MessageBox.Show("Kullanıcının ilgili  performans bilgisi başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                // ekrani_temizle();


            }
            else
            {
                MessageBox.Show("TC kimlik no 11 haneli girilmelidir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sil_7_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11)

            {
                bool sil = false;
                if (cb_7.Text != "" && txt_sayi7.Text != "" && txt_harf7.Text != "")
                {
                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {



                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_id_7.Text + "'and yil='" + cb_yil_7.Text + "'and persormansDonemi='" + cb_7.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        //     MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        sil = true;
                        //ekrani_temizle();

                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

                if (sil == true)
                {
                    MessageBox.Show("Kullanıcının ilgili  performans bilgisi başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //  ekrani_temizle();


            }
            else
            {
                MessageBox.Show("TC kimlik no 11 haneli girilmelidir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sil_8_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11)

            {
                bool sil = false;
                if (cb_8.Text != "" && txt_sayi8.Text != "" && txt_harf8.Text != "")
                {
                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {



                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_id_8.Text + "'and yil='" + cb_yil_8.Text + "'and persormansDonemi='" + cb_8.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        //     MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        sil = true;
                        //ekrani_temizle();

                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

                if (sil == true)
                {
                    MessageBox.Show("Kullanıcının ilgili  performans bilgisi başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //  ekrani_temizle();


            }
            else
            {
                MessageBox.Show("TC kimlik no 11 haneli girilmelidir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sil_9_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11)

            {
                bool sil = false;
                if (cb_9.Text != "" && txt_sayi9.Text != "" && txt_harf9.Text != "")
                {
                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {



                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_id_9.Text + "'and yil='" + cb_yil_9.Text + "'and persormansDonemi='" + cb_9.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        //     MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        sil = true;
                        //ekrani_temizle();

                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

                if (sil == true)
                {
                    MessageBox.Show("Kullanıcının ilgili  performans bilgisi başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                // ekrani_temizle();


            }
            else
            {
                MessageBox.Show("TC kimlik no 11 haneli girilmelidir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sil_10_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11)

            {
                bool sil = false;
                if (cb_10.Text != "" && txt_sayi10.Text != "" && txt_harf10.Text != "")
                {
                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {



                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_id_10.Text + "'and yil='" + cb_yil_10.Text + "'and persormansDonemi='" + cb_10.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        //     MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        sil = true;
                        //ekrani_temizle();

                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

                if (sil == true)
                {
                    MessageBox.Show("Kullanıcının ilgili  performans bilgisi başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                // ekrani_temizle();


            }
            else
            {
                MessageBox.Show("TC kimlik no 11 haneli girilmelidir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sil_11_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11)

            {
                bool sil = false;
                if (cb_11.Text != "" && txt_sayi11.Text != "" && txt_harf11.Text != "")
                {
                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {



                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_id_11.Text + "'and yil='" + cb_yil_11.Text + "'and persormansDonemi='" + cb_11.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        //     MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        sil = true;
                        //ekrani_temizle();

                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

                if (sil == true)
                {
                    MessageBox.Show("Kullanıcının ilgili  performans bilgisi başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //  ekrani_temizle();


            }
            else
            {
                MessageBox.Show("TC kimlik no 11 haneli girilmelidir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sil_12_Click(object sender, EventArgs e)
        {
            if (mtxt_tc_no.Text.Length == 11)

            {
                bool sil = false;
                if (cb_12.Text != "" && txt_sayi12.Text != "" && txt_harf12.Text != "")
                {
                    bool kayit_arama_durumu = false;

                    SqlCommand secmeSorgusu = new SqlCommand("Select *from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'", baglantim.baglanti());//ilgili tck verisine ait veriler seçiliyor.henüz silme yok. varmı yok mu ona bakıyoruz.
                    SqlDataReader kayitokuma = secmeSorgusu.ExecuteReader();//veri okuyucu tanımlanıyor. sorgu sonucalrı secmesorgusuna eşitledik.
                    while (kayitokuma.Read())
                    {



                        //kayıt okuma gerçekleşti ise
                        kayit_arama_durumu = true;
                        SqlCommand silsorgusu = new SqlCommand("delete from KisiYillikPerformans where Kisi_tc='" + mtxt_tc_no.Text + "'and id='" + txt_id_12.Text + "'and yil='" + cb_yil_12.Text + "'and persormansDonemi='" + cb_12.Text + "'", baglantim.baglanti());
                        //şimdi sorgunun sonucunun gerçekleştirilmesi sağlanacak 
                        silsorgusu.ExecuteNonQuery();
                        //     MessageBox.Show("Kullanıcının eğitim kaydı başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        sil = true;
                        //ekrani_temizle();

                        break;

                    }
                    //girilen tck ya göre bir kayıt bulunmaz ise
                    if (kayit_arama_durumu == false)//while döngüsü çalışmamş demektir.
                    {
                        MessageBox.Show("Böyle bir kayıt bulunamamıştır", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

                if (sil == true)
                {
                    MessageBox.Show("Kullanıcının ilgili  performans bilgisi başarılı bir şekilde silinmiştir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                // ekrani_temizle();


            }
            else
            {
                MessageBox.Show("TC kimlik no 11 haneli girilmelidir.", "Optimak İnsan Kaynakları", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            //try
            //{

            //    //for (int i = 0; i < dtp.Rows.Count; i++)

            //    //{
            //    //    this.chart1.Series["ser1"].Points.AddXY(dtp.Rows[i][5].ToString(), Convert.ToInt32(dtp.Rows[i][6]));
            //    //}

            //    for (int i = 0; i < dtp.Rows.Count; i++)

            //    {
            //        this.chartControl1.Series["Series 2"].Points.AddPoint(dtp.Rows[i][7].ToString(), Convert.ToInt32(dtp.Rows[i][5]));

            //        this.chartControl1.Series["Series 1"].Points.AddPoint(dtp.Rows[i][5].ToString(), Convert.ToInt32(dtp.Rows[i][6]));//sayı dönem  //çalışıyor 
            //                                                                                                                          //this.chartControl1.Series["Series 2"].Points.AddPoint(dtp.Rows[i][5].ToString(), Convert.ToInt32(dtp.Rows[i][6]));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Bir şeyler ters gitti...");
            //}
            
        }

        private void gridView1_FilterPopupExcelData(object sender, DevExpress.XtraGrid.Views.Grid.FilterPopupExcelDataEventArgs e)
        {
            //MessageBox.Show("gridView1_FilterPopupExcelData");
        }

        private void gridView1_FilterPopupExcelCustomizeTemplate(object sender, DevExpress.XtraGrid.Views.Grid.FilterPopupExcelCustomizeTemplateEventArgs e)
        {
            //MessageBox.Show("gridView1_FilterPopupExcelCustomizeTemplate");
        }

        private void gridView1_FilterEditorCreated(object sender, DevExpress.XtraGrid.Views.Base.FilterControlEventArgs e)
        {
            MessageBox.Show("gridView1_FilterEditorCreated");
            this.chartControl1.DataSource = dtp; // :((


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
        
        }
    }
}
