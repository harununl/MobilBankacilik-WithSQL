using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO;

namespace BLLL
{
    public class HesapBLL
    {
        public static void ArtiGuncelle(HesapBilgileri hesap)
        {
            HesapDAO.ArtiGuncelle(hesap);
        }

        public static void ArtiGuncelleArti(HesapBilgileri hesap)
        {
            HesapDAO.ArtiGuncelleArti(hesap);
        }

        public static void BakiyeEkle(HesapBilgileri hesap)
        {
            HesapDAO.BakiyeEkle(hesap);
           
        }

        public static void BakiyeGuncelle(HesapBilgileri hesap)
        {
            HesapDAO.BakiyeGuncelle(hesap);
        }

        public static void BakiyeGuncelleEksi(HesapBilgileri hesap)
        {
            HesapDAO.BakiyeGuncelleEksi(hesap);
        }

      

        public static List<HesapBilgileri> HesapGetir(HesapBilgileri hesap)
        {
            throw new NotImplementedException();
        }

        public static List<HesapBilgileri> HesapGetir(int v)
        {
            return HesapDAO.HesapGetir(v);
        }
    }
}
