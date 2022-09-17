using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsanKaynaklariBilgiSistem
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new genelKultur());
            //Application.Run(new giris());
            Application.Run(new ekran());
            //Application.Run(new ciktiForm());
            //Application.Run(new performans());
            //Application.Run(new havuzKayit());
            //Application.Run(new havuzolustur());
            //Application.Run(new havuzolustur());
            //Application.Run(new performans());
            //Application.Run(new maddiDurum());
            //Application.Run(new aileBilgisi());

            //Application.Run(new egitim());
            //Application.Run(new performans());
            //Application.Run(new borcDurumu());
            //Application.Run(new kullaniciHesap());
            //Application.Run(new giris());
            //Application.Run(new durumGrafiği());
            //Application.Run(new departmanOlustur());
            //Application.Run(new gorevOlustur());      
            //Application.Run(new kkdBilgisi());
            //Application.Run(new bildirimler());


        }
    }
}
