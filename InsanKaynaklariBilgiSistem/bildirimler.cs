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
            
        }
        public void dogumGünüListeler()
        {
            SqlDataAdapter adtr = new SqlDataAdapter("select ad+' '+soyad as 'PERSONEL ADI', dogum_Tarihi AS 'DOĞUM TARİHİ' from Kisi where day(dogum_Tarihi)= '" + DateTime.Now.ToString("dd")+ "'and month(dogum_Tarihi)='" + DateTime.Now.ToString("MM")+"'", baglantim.baglanti());
            adtr.Fill(daset, "Kisi");
            gridControl1.DataSource = daset.Tables["Kisi"];
           

        }
        public void merasimTarihleriListeler()
        {
            SqlDataAdapter adtr = new SqlDataAdapter("select  kisi_tc  AS 'TC NO' ,planli_merasim_adi AS 'MERASİMİN TÜRÜ',planli_merasim_tarihi AS 'MERASİM TARİHİ' from Kisi_planli_merasim where day(planli_merasim_tarihi)= '" + DateTime.Now.ToString("dd")+"'and month(planli_merasim_tarihi)='"+DateTime.Now.ToString("MM")+"'", baglantim.baglanti());
            adtr.Fill(daset, "Kisi_planli_merasim");
            gridControl1.DataSource = daset.Tables["Kisi_planli_merasim"];
            
        }
        public void borçTarihleriListeler()
        {
            SqlDataAdapter adtr = new SqlDataAdapter("select kisi_tc AS 'TC NO', maas AS 'MAAŞ',aldigi_destek_turu AS 'ALDIĞI DESTEK TÜRÜ',aldigi_destek_miktari AS 'DESTEK MİKTARI'" +
                " ev_durumu AS 'EV BİLGİSİ',kira_ucreti AS 'KİRA ÜCRETİ',isinma_sistemi_turu AS 'EVİN ISINMA SİSTEMİ'," +
                " kirada_ev_var_mi AS 'KİRA GELİRİ OLAN EV',kiradaki_evlerin_kira_ucreti AS 'KİRA GELİRİ',arac_durumu AS" +
                "'ARAÇ DURUMU',arac_kullanim_amaci AS 'ARAÇ KULLANIM AMACI',sahip_olunan_arazi_var_mi AS 'ARAZİ DURUMU'," +
                "sahip_olunan_arazi_kullanim_amaci AS 'ARAZİ KULLANIM AMACI',icra_durumu AS 'İCRA DURUMU',icra_konusu AS" +
                "'İCRA KONUSU',icra_kesinti_miktari AS 'KESNTİ MİKTARI',icra_hesap_no AS 'İCRA HESAP NO',borc_Tarihi AS 'ÖDEME TARİHİ' from Kisi_maddi_durum_Bilgileri where day(borc_Tarihi)= '" + DateTime.Now.ToString("dd") + "'and month(borc_Tarihi)='"+DateTime.Now.ToString("mm"), baglantim.baglanti());
            adtr.Fill(daset, "Kisi_maddi_durum_Bilgileri");
            gridControl1.DataSource = daset.Tables["Kisi_maddi_durum_Bilgileri"];
           
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==0)//eğer doğum gnlerini görme ister ise
            {
                dogumGünüListeler();
               
            }
            else if(comboBox1.SelectedIndex==1)//merasim tarihleri seçilir ise
            {
                merasimTarihleriListeler();
            }
            else if (comboBox1.SelectedIndex == 3)//borc durmu geçti ise
            {
                borçTarihleriListeler();
            }

        }
    }
}
