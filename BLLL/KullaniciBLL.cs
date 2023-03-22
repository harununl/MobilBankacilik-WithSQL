using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO;


namespace BLLL
{
    public class KullaniciBLL
    {
        public static void KullaniciEkle(KullaniciBilgileri kullanici)
        {
            KullaniciDAO.KullaniciEkle(kullanici);
        }

        public static List<KullaniciBilgileri> KullaniciGetir(int v)
        {
            return KullaniciDAO.KullaniciGetir(v);
        }
    }
}
