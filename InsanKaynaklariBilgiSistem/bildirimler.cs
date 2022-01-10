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
    public partial class bildirimler : Form
    {
        public bildirimler()
        {
            InitializeComponent();
        }
        sqlBaglantisi baglantim = new sqlBaglantisi();
        DataSet daset = new DataSet();

        private void bildirimler_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.Columns.Count; i++) gridView1.Columns[i].BestFit();

        }
        public void formu_temizle()
        {
            gridView1.Columns.Clear();
        }
        public void dogumGünüListeler()
        {
            /*SqlDataAdapter adtr = new SqlDataAdapter("select ad+' '+soyad as 'PERSONEL ADI', dogum_Tarihi AS 'DOĞUM TARİHİ' from Kisi where day(dogum_Tarihi)= '" + DateTime.Now.ToString("dd") + "'and month(dogum_Tarihi)='" + DateTime.Now.ToString("MM") + "'", baglantim.baglanti());
            adtr.Fill(daset, "Kisi");
            gridControl1.DataSource = daset.Tables["Kisi"];*/

            SqlCommand sorgu = new SqlCommand("dogumGunleri", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(sorgu);


            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;

            gridView1.BestFitColumns();


        }

        public void merasimTarihleriListeler()
        {
            SqlDataAdapter adtr = new SqlDataAdapter("select  kisi_tc  AS 'TC NO' ,planli_merasim_adi AS 'MERASİMİN TÜRÜ',planli_merasim_tarihi AS 'MERASİM TARİHİ' from Kisi_planli_merasim where day(planli_merasim_tarihi)= '" + DateTime.Now.ToString("dd")+"'and month(planli_merasim_tarihi)='"+DateTime.Now.ToString("MM")+"'", baglantim.baglanti());
            adtr.Fill(daset, "Kisi_planli_merasim");
            gridControl1.DataSource = daset.Tables["Kisi_planli_merasim"];


            gridView1.BestFitColumns();

        }
        public void borçTarihleriListeler()
        {
            SqlCommand sorgu = new SqlCommand("borc_tarihi", baglantim.baglanti());
            sorgu.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(sorgu);


            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;


            gridView1.BestFitColumns();

        }
        /*
    {
        SqlDataAdapter adtr = new SqlDataAdapter("select " +
            "Kisi_maddi_durum_Bilgileri.kisi_tc AS 'TC NO'," +
            "Kisi.ad +Kisi.soyad AS 'PEROSNEL' ," +
            "Kisi_maddi_durum_Bilgileri.maas AS 'MAAŞ'," +
            "Kisi_maddi_durum_Bilgileri.aldigi_destek_turu AS 'ALDIĞI DESTEK TÜRÜ'," +
            "Kisi_maddi_durum_Bilgileri.aldigi_destek_miktari AS 'DESTEK MİKTARI'," +
            "Kisi_maddi_durum_Bilgileri.ev_durumu AS 'EV BİLGİSİ'," +
            "Kisi_maddi_durum_Bilgileri.kira_ucreti AS 'KİRA ÜCRETİ'," +
            "Kisi_maddi_durum_Bilgileri.isinma_sistemi_turu AS 'EVİN ISINMA SİSTEMİ'," +
            "kirada_ev_var_mi AS 'KİRA GELİRİ OLAN EV'," +
            "kiradaki_evlerin_kira_ucreti AS 'KİRA GELİRİ'," +
            "arac_durumu AS 'ARAÇ DURUMU'," +
            "Kisi_maddi_durum_Bilgileri.arac_kullanim_amaci AS 'ARAÇ KULLANIM AMACI'," +
            "Kisi_maddi_durum_Bilgileri.sahip_olunan_arazi_var_mi AS 'ARAZİ DURUMU'," +
            "Kisi_maddi_durum_Bilgileri.sahip_olunan_arazi_kullanim_amaci AS 'ARAZİ KULLANIM AMACI'," +
            "Kisi_maddi_durum_Bilgileri.icra_durumu AS 'İCRA DURUMU'," +
            "Kisi_maddi_durum_Bilgileri.icra_konusu AS 'İCRA KONUSU',Kisi_maddi_durum_Bilgileri.icra_kesinti_miktari AS 'KESNTİ MİKTARI',Kisi_maddi_durum_Bilgileri.icra_hesap_no AS 'İCRA HESAP NO',Kisi_maddi_durum_Bilgileri.borc_Tarihi AS 'ÖDEME TARİHİ' from Kisi_maddi_durum_Bilgileri INNER Join Kisi on Kisi.TC=Kisi_maddi_durum_Bilgileri.kisi_tc where day(borc_Tarihi)= '" + DateTime.Now.ToString("dd") + "'and month(borc_Tarihi)='"+DateTime.Now.ToString("MM"), baglantim.baglanti());





        adtr.Fill(daset, "Kisi_maddi_durum_Bilgileri INNER Join Kisi");
        gridControl1.DataSource = daset.Tables["Kisi_maddi_durum_Bilgileri"];

    }*/
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            formu_temizle();
            if (comboBox1.SelectedIndex == 0)//eğer doğum gnlerini görme ister ise
            {
                dogumGünüListeler();

            }
            else if (comboBox1.SelectedIndex == 1)//merasim tarihleri seçilir ise
            {
                merasimTarihleriListeler();
            }
            else if (comboBox1.SelectedIndex ==2 )//borc durmu geçti ise
            {
                borçTarihleriListeler();
            }


        }
    }
}
