using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.DAO
{
    public class KullaniciDAO : MusteriDataContext
    {
        public static void KullaniciEkle(KullaniciBilgileri kullanici)
        {

            try
            {
                db.KullaniciBilgileri.InsertOnSubmit(kullanici);
               
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        
        }

        public static List<KullaniciBilgileri> KullaniciGetir(int v)
        {
            return db.KullaniciBilgileri.Where(x => x.HesapNO == v).ToList();
        }
    }
}
