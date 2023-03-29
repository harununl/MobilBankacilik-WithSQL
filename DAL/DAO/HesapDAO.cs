﻿using System;
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

       

        public static void BakiyeGuncelleEksi(HesapBilgileri hesap)
        {
			try
			{
				HesapBilgileri hsp = db.HesapBilgileri.First(x=>x.HesapNO == hesap.HesapNO);
				hsp.Bakiye -= hesap.Bakiye;
				db.SubmitChanges();

			}
			catch (Exception)
			{

				throw;
			}
        }

       

        public static void ArtiGuncelle(HesapBilgileri hesap)
        {
			try
			{

                HesapBilgileri hsp = db.HesapBilgileri.First(x => x.HesapNO == hesap.HesapNO);
                hsp.ArtiPara -= hesap.ArtiPara;
                db.SubmitChanges();

            }
			catch (Exception ex)
			{

				throw ex;
			}
        }

        public static void ArtiGuncelleArti(HesapBilgileri hesap)
        {
            try
            {

                HesapBilgileri hsp = db.HesapBilgileri.First(x => x.HesapNO == hesap.HesapNO);
                hsp.ArtiPara += hesap.ArtiPara;
                db.SubmitChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void KrediCek(HesapBilgileri hesap)
        {

            try
            {

                HesapBilgileri hsp = db.HesapBilgileri.First(x => x.HesapNO == hesap.HesapNO);
               hsp.KrediBorc -= hesap.KrediBorc;
                db.SubmitChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void KrediOde(HesapBilgileri hesap)
        {
            try
            {

                HesapBilgileri hsp = db.HesapBilgileri.First(x => x.HesapNO == hesap.HesapNO);
                hsp.KrediBorc += hesap.KrediBorc;
                db.SubmitChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
