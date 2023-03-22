using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BLLL;
using DAL;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for FrmIslem.xaml
    /// </summary>
    public partial class FrmIslem : Window
    {
        public FrmIslem()
        {
            InitializeComponent();
        }
        public class Atm
        {

            public double bakiye { get; set; }
            public double miktar { get; set; }
            public double credit { get; set; }
            public double borc { get; set; }



            public Atm(double bakiye, double miktar, double credit, double borc)
            {
                this.bakiye = bakiye;
                this.miktar = miktar;
                this.credit = credit;
                this.borc = borc;

            }

            public double paraYatir()
            {
                bakiye += miktar;


                return bakiye;
            }

            public double paraCek()
            {
                bakiye -= miktar;

                return bakiye;
            }

            public double sorgula()
            {
                return bakiye;
            }

            public double artiPara()
            {

                credit -= miktar;


                return credit;

            }

            public double borcOde()
            {
                credit += miktar;


                return credit;
            }

            public double krediCek()
            {
                borc -= miktar;



                return borc;
            }
            public double krediOde()
            {
                borc += miktar;

                return borc;
            }




        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnYatir_Click(object sender, RoutedEventArgs e)
        {

            HesapBilgileri hesap = new HesapBilgileri();
          
            if (Convert.ToInt32(txtBakiye.Text) == 0)
            {
                hesap.Bakiye = Convert.ToInt32(txtYatir.Text.ToString());
                MessageBox.Show("Para Yatirdiniz.");
                txtYatir.Clear();

                HesapBLL.BakiyeEkle(hesap);
                


            }

        }

        private void btnSorgula_Click(object sender, RoutedEventArgs e)
        {
            double bakiyeniz;
            double miktariniz;

            double credit = 1000;

            double total;
            double creditBalance;
            double borc;



            double.TryParse(txtBakiye.Text, out bakiyeniz);
            double.TryParse(txtYatir.Text, out miktariniz);
            double.TryParse(txtKredi.Text, out borc);
            Atm islem = new Atm(bakiyeniz, miktariniz, credit, borc);



            total = islem.sorgula();
            creditBalance = islem.artiPara();




            txtBakiye.Text = total.ToString();
            txtArti.Text = creditBalance.ToString();
            int counter = 0;
            counter++;
            if (counter > 0)
            {
                btnSorgula.IsEnabled = false;
            }
        }
    }
}
