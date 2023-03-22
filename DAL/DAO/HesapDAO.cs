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
    }
}
