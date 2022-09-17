﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraCharts;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text;
using System.Windows.Forms.DataVisualization.Charting;

namespace InsanKaynaklariBilgiSistem
{
    public partial class durumGrafiği : Form
    {
        public durumGrafiği()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // Fill a SqlDataSource asynchronously
            sqlDataSource1.FillAsync();
            // This line of code is generated by Data Source Configuration Wizard
            // Fill a SqlDataSource asynchronously
            sqlDataSource1.FillAsync();
            // This line of code is generated by Data Source Configuration Wizard
            // Fill a SqlDataSource asynchronously
            sqlDataSource1.FillAsync();
        }
        sqlBaglantisi baglantim = new sqlBaglantisi();


        public void listele_gorevYeri()
        {
            SqlCommand sorgu2 = new SqlCommand("Gorev_Yeri", baglantim.baglanti());
            sorgu2.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da2 = new SqlDataAdapter(sorgu2);

            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            gridControl1.DataSource = dt2;

            gridView1.Columns["gorev_Yeri"].Caption = "GÖREV YERİ";
            gridView1.Columns["sayi"].Caption = "ADET";


        }




        public void listele_gorev_Yeri()
        {
            SqlCommand ss = new SqlCommand("gorev_gorev_yeri", baglantim.baglanti());
            ss.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dd = new SqlDataAdapter(ss);

            DataTable dtt = new DataTable();
            dd.Fill(dtt);

            gridControl2.DataSource = dtt;

            gridView2.Columns["gorev_Yeri"].Caption = "GÖREV YERİ";
            gridView2.Columns["gorevi"].Caption = "GÖREVİ";
            gridView2.Columns["sayi"].Caption = "ADET";


        }




        public void sayilar()
        {
            SqlCommand cinsiyet = new SqlCommand("sayilar", baglantim.baglanti());
            cinsiyet.CommandType = CommandType.StoredProcedure;

            SqlDataReader tr = cinsiyet.ExecuteReader();

            while (tr.Read())
            {
                //txt_kadin.Text = tr[0].ToString();

                if (tr[0].ToString() == "Bay")
                {
                    //txt_erkek.Text = tr[1].ToString();

                }
                else
                {
                    //   txt_kadin.Text = tr[1].ToString();

                }

                //txt_erkek.Text = tr[1].ToString();
            }
        }

        private void durumGrafiği_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true;
            this.HorizontalScroll.Enabled = true;
            this.HorizontalScroll.Visible = true;
            this.VerticalScroll.Enabled = true;
            this.VerticalScroll.Visible = true;

            SqlCommand cinsiyet = new SqlCommand("SELECT cinsiyet,COUNT(*) as 'sayi' FROM Kisi GROUP BY cinsiyet", baglantim.baglanti());
            SqlDataReader dr = cinsiyet.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0].ToString() == "Bay")
                {
                    tablo_cinsiyet.Series["Erkek"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
                }
                else if (dr[0].ToString() == "Bayan")
                {

                    tablo_cinsiyet.Series["Kadın"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
                }

                else
                {

                    tablo_cinsiyet.Series["admin"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
                }



            }
            sayilar();

            //////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////
            SqlCommand gorev_Yeri = new SqlCommand("Gorev_Yeri", baglantim.baglanti());

            gorev_Yeri.CommandType = CommandType.StoredProcedure;

            SqlDataReader gy = gorev_Yeri.ExecuteReader();
            while (gy.Read())
            {
                tablo_gorevYeri.Series["yer"].Points.AddPoint(Convert.ToString(gy[0]), int.Parse(gy[1].ToString()));
            }

            listele_gorevYeri();

            ////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////

            SqlCommand gorev = new SqlCommand("gorevi", baglantim.baglanti());

            gorev.CommandType = CommandType.StoredProcedure;

            SqlDataReader g = gorev.ExecuteReader();

            while (g.Read())
            {

                tablo_pasta.Series["pasta"].Points.AddPoint(Convert.ToString(g[0]), int.Parse(g[1].ToString()));

            }



            ///////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////

            SqlCommand gorev_gorev = new SqlCommand("gorev_gorev_yeri", baglantim.baglanti());

            gorev_gorev.CommandType = CommandType.StoredProcedure;

            SqlDataReader hh = gorev_gorev.ExecuteReader();
            /* 
             while (hh.Read())
              {

                 // tablo_gorev_gorev_yeri.Series["gorev_gorev"].Points.AddPoint(Convert.ToString(hh[0]), int.Parse(hh[2].ToString()));
                  // tablo_gorev_gorev_yeri.Series["dagılım"].Points.AddPoint(Convert.ToString(gg[0]), int.Parse(gg[1].ToString()));
                 // tablo_gorev_gorev_yeri.Series["gorev_gorev"].Points.AddPoint(Convert.ToString(hh[0]), int.Parse(hh[2].ToString()));
                //  tablo_gorev_gorev_yeri.Series["gorev_gorev"].Points.AddPoint(Convert.ToString(hh[1]), int.Parse(hh[2].ToString()));
              }
            */

            /*
                        while (hh.Read())
                        {
                           //chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(hh[0]),int.Parse(hh[2].ToString()));
                           // chartControl1.Series["Series 2"].Points.AddPoint(Convert.ToString(hh[1]), int.Parse(hh[2].ToString()));

                            /*chart1.Series["s2"].Points.AddXY(Convert.ToString(hh[1]), int.Parse(hh[2].ToString()));
                        /*
                            chartControl1.Series["s1"].Points.AddPoint("day 2", "25");
                            chartControl1.Series["s2"].Points.AddPoint("day 2", "75");

                            chartControl1.Series["s1"].Points.AddPoint("day 3", "40");
                            chartControl1.Series["s2"].Points.AddPoint("day 3", "60");

                            chartControl1.Series["s1"].Points.AddPoint("day 4", "70");
                            chartControl1.Series["s2"].Points.AddPoint("day 4", "30");

                        }
                    */
            //  SwitchRowColumn();



            listele_gorev_Yeri();




        }


        public void sade_print()
        {
            string strPdfPath = @"C:\Dosyalar\durumAnaliz.pdf";

            System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);

            Document document = new Document(PageSize.A4, 10f, 10f, 10f, 10f);//???

            document.SetPageSize(iTextSharp.text.PageSize.A4);

            PdfWriter writer = PdfWriter.GetInstance(document, fs);//yazıyorrr 

            document.Open();



            Bitmap MemoryImage;

            Panel pnl;
            pnl = panel1;
            MemoryImage = new Bitmap(pnl.Width, pnl.Height);
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, pnl.Width, pnl.Height);
            pnl.DrawToBitmap(MemoryImage, new System.Drawing.Rectangle(0, 0, pnl.Width, pnl.Height));

            iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(MemoryImage, System.Drawing.Imaging.ImageFormat.Png);


            //Bitmap MemoryImage2;

            //Panel pnl2;
            //pnl2 = panel2;
            //MemoryImage2 = new Bitmap(pnl2.Width, pnl2.Height);
            //System.Drawing.Rectangle rect2 = new System.Drawing.Rectangle(0, 0, pnl2.Width, pnl2.Height);
            //pnl2.DrawToBitmap(MemoryImage2, pnl2.ClientRectangle);
            ////pnl2.DrawToBitmap(MemoryImage2, new System.Drawing.Rectangle(0, 0, pnl2.Width, pnl2.Height));

            //iTextSharp.text.Image png2 = iTextSharp.text.Image.GetInstance(MemoryImage2, System.Drawing.Imaging.ImageFormat.Png);


            Bitmap MemoryImage3;

            Panel pnl3;
            pnl3 = panel3;
            MemoryImage3 = new Bitmap(pnl3.Width, pnl3.Height);
            System.Drawing.Rectangle rect3 = new System.Drawing.Rectangle(0, 0, pnl3.Width, pnl3.Height);
            pnl3.DrawToBitmap(MemoryImage3, new System.Drawing.Rectangle(0, 0, pnl3.Width, pnl3.Height));

            iTextSharp.text.Image png3 = iTextSharp.text.Image.GetInstance(MemoryImage3, System.Drawing.Imaging.ImageFormat.Png);




            SqlCommand hh = new SqlCommand("gorev_gorev_yeri", baglantim.baglanti());
            hh.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sh = new SqlDataAdapter(hh);

            DataTable t1 = new DataTable();
            sh.Fill(t1);

            gridControl2.DataSource = t1;

            gridView2.Columns["gorev_Yeri"].Caption = "GÖREV YERİ";
            gridView2.Columns["gorevi"].Caption = "GÖREVİ";
            gridView2.Columns["sayi"].Caption = "ADET";



            PdfPTable table1 = new PdfPTable(t1.Columns.Count);


            //BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            BaseFont btnColumnHeader = BaseFont.CreateFont(@"C:\Windows\Fonts\Calibri.ttf", "Identity-H", BaseFont.EMBEDDED);
            //iTextSharp.text.Font fntColumnHeader = new Font(btnColumnHeader, 6, 0, Color.BLACK);
            iTextSharp.text.Font fntColumnHeader = new iTextSharp.text.Font(btnColumnHeader, 6, 1, iTextSharp.text.BaseColor.BLACK);
            if (t1.Rows.Count > 0)
            {
                //t1 için
                for (int i = 0; i < t1.Columns.Count; i++)
                {
                    PdfPCell cell_1 = new PdfPCell();
                    cell_1.AddElement(new Chunk(t1.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                    table1.AddCell(cell_1);
                }

                for (int i = 0; i < t1.Rows.Count; i++)
                {
                    for (int j = 0; j < t1.Columns.Count; j++)
                    {
                        PdfPCell cell_1_1 = new PdfPCell();
                        cell_1_1.AddElement(new Chunk(t1.Rows[i][j].ToString().ToUpper(), fntColumnHeader));
                        table1.AddCell(cell_1_1);
                    }
                }

            }







            iTextSharp.text.pdf.BaseFont STF_Helvetica_Turkish = iTextSharp.text.pdf.BaseFont.CreateFont("Helvetica", "CP1254", iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, iTextSharp.text.Font.NORMAL);
            Paragraph başlık = new Paragraph();
            BaseFont btnAuthor1 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntAuthor1 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 12, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
            başlık.Add(new Chunk(" \n                                                              " + "PERSONEL DURUM GRAFİKLERİ", fntAuthor1));
            başlık.Add(new Chunk("\n", fntAuthor1));


            Paragraph bosluk = new Paragraph();
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(STF_Helvetica_Turkish, 12, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2

            bosluk.Add(new Chunk("\n", fntAuthor));

            Paragraph prgAuthor1 = new Paragraph();
            prgAuthor1.Add(new Chunk("Başlık 1 : " + lbl_cinsiyet.Text, fntAuthor));


            //Paragraph prgAuthor2 = new Paragraph();
            //prgAuthor2.Add(new Chunk("Başlık 2 : " + label1.Text, fntAuthor));


            Paragraph prgAuthor3 = new Paragraph();
            prgAuthor3.Add(new Chunk("Başlık 2 : " + label3.Text, fntAuthor));


            Paragraph prgAuthor4 = new Paragraph();
            prgAuthor4.Add(new Chunk("Başlık 3 : " + label2.Text, fntAuthor));



            Paragraph simplePara = new Paragraph();

            MemoryStream stream = new MemoryStream();

            //tablo_cinsiyet.ExportToPdf(strPdfPath2);
            //tablo_gorevYeri.ExportToPdf(strPdfPath2);
            //tablo_pasta.ExportToPdf(strPdfPath2);

            // iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(stream.GetBuffer());
            //chartImage.ScalePercent(75);
            //document.Add(simplePara);
            //document.Add(chartImage);

            document.Add(başlık);
            document.Add(bosluk);
            //document.Add(prgAuthor);
            document.Add(prgAuthor1);
            document.Add(png);
            document.Add(bosluk);

            //document.Add(prgAuthor2);
            //document.Add(bosluk);
            //document.Add(png2);



            document.Add(prgAuthor3);
            document.Add(bosluk);
            //document.Add(prgAuthor);

            document.Add(png3);

            document.Add(bosluk);

            document.Add(prgAuthor4);
            document.Add(bosluk);

            if (t1.Rows.Count > 0)//sağlık kısmı için
            {
                document.Add(bosluk);
                document.Add(table1);
            }
            else
                document.Add(bosluk);






            document.Close();
            writer.Close();
            fs.Close();

            System.Diagnostics.Process.Start(strPdfPath);
        }





        private void btn_rapor_Click(object sender, EventArgs e)
        {
            sade_print();
        }

        int a = 1;

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            /*

            switch (a)
            {

                case 1:
                    ////////////////////////Yeni Kod Başlangıç//////////////////////////

                    //string strPdfPath = @"C:\Dosyalar\durumAnaliz.pdf";
                   

                    //System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);

                    //Document document = new Document(PageSize.A4, 10f, 10f, 10f, 10f);//???

                    //document.SetPageSize(iTextSharp.text.PageSize.A4);

                    //PdfWriter writer = PdfWriter.GetInstance(document, fs);//yazıyorrr 

                    //document.Open();



                    //Bitmap MemoryImage;

                    //Panel pnl;
                    //pnl = panel1;
                    //MemoryImage = new Bitmap(pnl.Width, pnl.Height);
                    //System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, pnl.Width, pnl.Height);
                    //pnl.DrawToBitmap(MemoryImage, new System.Drawing.Rectangle(0, 0, pnl.Width, pnl.Height));

                    //iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(MemoryImage, System.Drawing.Imaging.ImageFormat.Png);


                    //Bitmap MemoryImage2;

                    //Panel pnl2;
                    //pnl2 = panel2;
                    //MemoryImage2 = new Bitmap(pnl2.Width, pnl2.Height);
                    //System.Drawing.Rectangle rect2 = new System.Drawing.Rectangle(0, 0, pnl2.Width, pnl2.Height);
                    //pnl2.DrawToBitmap(MemoryImage2, pnl2.ClientRectangle);
                    ////pnl2.DrawToBitmap(MemoryImage2, new System.Drawing.Rectangle(0, 0, pnl2.Width, pnl2.Height));

                    //iTextSharp.text.Image png2 = iTextSharp.text.Image.GetInstance(MemoryImage2, System.Drawing.Imaging.ImageFormat.Png);


                    //Bitmap MemoryImage3;

                    //Panel pnl3;
                    //pnl3 = panel3;
                    //MemoryImage3 = new Bitmap(pnl3.Width, pnl3.Height);
                    //System.Drawing.Rectangle rect3 = new System.Drawing.Rectangle(0, 0, pnl3.Width, pnl3.Height);
                    //pnl3.DrawToBitmap(MemoryImage3, new System.Drawing.Rectangle(0, 0, pnl3.Width, pnl3.Height));

                    //iTextSharp.text.Image png3 = iTextSharp.text.Image.GetInstance(MemoryImage3, System.Drawing.Imaging.ImageFormat.Png);






                    //iTextSharp.text.pdf.BaseFont STF_Helvetica_Turkish = iTextSharp.text.pdf.BaseFont.CreateFont("Helvetica", "CP1254", iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);
                    //iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(STF_Helvetica_Turkish, 8, iTextSharp.text.Font.NORMAL);
                    //Paragraph bosluk = new Paragraph();
                    //BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    //iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(STF_Helvetica_Turkish, 12, 0, iTextSharp.text.BaseColor.BLACK); //1 or 0 yada 2 yazı sitili --> eğik:2
                    //bosluk.Add(new Chunk(" \n                                                              " + "PERSONEL DURUM GRAFİKLERİ", fntAuthor));
                    //bosluk.Add(new Chunk("\n", fntAuthor));

                    //Paragraph prgAuthor1 = new Paragraph();
                    //prgAuthor1.Add(new Chunk("Başlık 1 : " + lbl_cinsiyet.Text, fntAuthor));


                    //Paragraph prgAuthor2 = new Paragraph();
                    //prgAuthor2.Add(new Chunk("Başlık 2 : " + label1.Text, fntAuthor));


                    //Paragraph prgAuthor3 = new Paragraph();
                    //prgAuthor3.Add(new Chunk("Başlık 3 : " + label3.Text, fntAuthor));

                    //Paragraph simplePara = new Paragraph();

                    //MemoryStream stream = new MemoryStream();

                    ////tablo_cinsiyet.ExportToPdf(strPdfPath2);
                    ////tablo_gorevYeri.ExportToPdf(strPdfPath2);
                    ////tablo_pasta.ExportToPdf(strPdfPath2);

                    //// iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(stream.GetBuffer());
                    ////chartImage.ScalePercent(75);
                    ////document.Add(simplePara);
                    ////document.Add(chartImage);


                    //document.Add(bosluk);
                    ////document.Add(prgAuthor);
                    //document.Add(prgAuthor1);
                    //document.Add(png);
                    //document.Add(bosluk);

                    //document.Add(prgAuthor2);
                    //document.Add(bosluk);
                    //document.Add(png2);

                    //document.Add(prgAuthor2);
                    //document.Add(bosluk);
                    ////document.Add(prgAuthor);
                    //document.Add(prgAuthor3);
                    //document.Add(png3);

                    //document.Add(bosluk);
                    //document.Add(prgAuthor1);

                    //document.Close();
                    //writer.Close();
                    //fs.Close();

                    //System.Diagnostics.Process.Start(strPdfPath);

                    break;
            }
            */




        }
        /* public void SwitchRowColumn()
{
string seriesDataMember = chartControl1.SeriesDataMember;
chartControl1.SeriesDataMember = chartControl1.SeriesTemplate.ArgumentDataMember;
chartControl1.SeriesTemplate.ArgumentDataMember = seriesDataMember;

string seriesDataMember2 = chartControl1.SeriesDataMember;
chartControl1.SeriesDataMember = chartControl1.SeriesTemplate.ArgumentDataMember;
chartControl1.SeriesTemplate.ArgumentDataMember = seriesDataMember2;
}*/
    }
}
