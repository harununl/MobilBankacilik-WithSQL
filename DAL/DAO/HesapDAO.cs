using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class HesapDAO : MusteriDataContext
    {
        public static void BakiyeEkle(HesapBilgileri hesap)
        {
			try
			{
				db.HesapBilgileri.InsertOnSubmit(hesap);
				db.SubmitChanges();

			   

			}
			catch (Exception ex)
			{

				throw ex;
			}
        }

    

        public static List<HesapBilgileri> HesapGetir(int v)
        {
            return db.HesapBilgileri.Where(x=>x.HesapNO == v).ToList();
        }

        public static void BakiyeGuncelle(HesapBilgileri hesap)
        {
			try
			{
				HesapBilgileri hsp = db.HesapBilgileri.First(x => x.HesapNO == hesap.HesapNO);
				hsp.Bakiye+= hesap.Bakiye;
				db.SubmitChanges();
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }

        public static List<HesapBilgileri> BakiyeSorgula(int v)
        {
           return db.HesapBilgileri.Where(x=>x.HesapNO==v).ToList();	
        }
    }
}
