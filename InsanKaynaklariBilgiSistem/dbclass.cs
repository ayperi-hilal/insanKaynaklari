using System;
using System.Collections.Generic;
//using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace InsanKaynaklariBilgiSistem
{
    class sqlBaglantisi
    {
        //public static string conn="Provider = Microsoft.Ace.OleDb.12.0; Data Source = personel.accdb";

       // public static string conn="Data Source = 192.168.1.203; Network Library = DBMSSOCN; Initial Catalog = personel; User ID = cogurcu; Password = deneme;";
        
        public SqlConnection baglanti()
        {
           SqlConnection baglan = new SqlConnection("Data Source = 192.168.1.203; Network Library = DBMSSOCN; Initial Catalog = personel; User ID = cogurcu; Password = deneme;");

            baglan.Open();
            return baglan;
        }

        

        /*public SqlConnection hesapolusturma()
        {
            SqlConnection hesapolustur = new SqlConnection("Data Source = 192.168.1.203; Network Library = DBMSSOCN; Initial Catalog = personel; User ID = cogurcu; Password = deneme;");

            hesapolustur.Open();
            return hesapolustur;
        }*/

    }
   
}
