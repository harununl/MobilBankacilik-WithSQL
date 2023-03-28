using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using DAL.DAO;


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
            if (MessageBox.Show("Emin misiniz?", "Uyari", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();

            }

        }

        private void btnYatir_Click(object sender, RoutedEventArgs e)
        {
            double miktariniz;
            double bakiyeniz;
            double credit = 1000;
            double borc;

            double.TryParse(txtYatir.Text, out miktariniz);
            double.TryParse(txtBakiye.Text, out bakiyeniz);
            double.TryParse(txtKredi.Text, out borc);
            HesapBilgileri hesap = new HesapBilgileri();
            hesap.HesapNO = Convert.ToInt32(txtHesap.Text.ToString());
            hesap.Bakiye = Convert.ToInt32(txtYatir.Text.ToString());
            hesap.ArtiPara = Convert.ToInt32(txtArti.Text);
            Atm islem = new Atm(bakiyeniz, miktariniz, credit, borc);
            
            if (Convert.ToInt32(txtBakiye.Text) == 0)
            {

                List<HesapBilgileri> list = HesapBLL.HesapGetir(Convert.ToInt32(txtHesap.Text));
                if(list.Count > 0)
                {
                    if (MessageBox.Show("Islemi Onayliyor Musunuz?", "UYARI!!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        double total = islem.paraYatir();

                        txtBakiye.Text = total.ToString();
                        MessageBox.Show("Hesabiniza " + txtYatir.Text + " Tutarinda Para Yatirilmistir.", "Uyari");
                    }
                    txtYatir.Clear();

                    HesapBLL.BakiyeGuncelle(hesap);
                }
                else
                {
                    if (MessageBox.Show("Islemi Onayliyor Musunuz?", "UYARI!!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        double total = islem.paraYatir();

                        txtBakiye.Text = total.ToString();
                        MessageBox.Show("Hesabiniza " + txtYatir.Text + " Tutarinda Para Yatirilmistir.", "Uyari");
                    }
                    txtYatir.Clear();

                    HesapBLL.BakiyeEkle(hesap);
                }
              
                


            }
            else if (Convert.ToInt32(txtBakiye.Text) > 0)
            {
                if (MessageBox.Show("Islemi Onayliyor Musunuz?", "UYARI!!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    double total = islem.paraYatir();

                    txtBakiye.Text = total.ToString();
                    MessageBox.Show("Hesabiniza " + txtYatir.Text + " Tutarinda Para Yatirilmistir.", "Uyari");
                }
                txtYatir.Clear();

              

                HesapBLL.BakiyeGuncelle(hesap);
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


            

            
            txtArti.Text = creditBalance.ToString();
            int counter = 0;
            counter++;
            if (counter > 0)
            {
                btnSorgula.IsEnabled = false;
            }

           
          

           

            string connectionString = "Data Source=MONSTERT5\\SQLEXPRESS;Initial Catalog=mobilBankacilik;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlConnection connectionNew = new SqlConnection(connectionString);




            // SqlCommand nesnesi oluşturma
            SqlCommand command = new SqlCommand("SELECT Bakiye FROM HesapBilgileri WHERE HesapNO = @hesapNo",connection);
            SqlCommand commandNew = new SqlCommand("SELECT ArtiPara FROM HesapBilgileri WHERE HesapNO = @hesapNo", connectionNew);


            // @hesapNo parametresine değer atama
            command.Parameters.AddWithValue("@hesapNo", txtHesap.Text);
            commandNew.Parameters.AddWithValue("@hesapNo", txtHesap.Text);

            // Sorguyu çalıştırma ve sonucu alıp TextBox'a yazdırma
            connection.Open();
            connectionNew.Open();
            

            object result = command.ExecuteScalar();
            if (result != null)
            {
                txtBakiye.Text = result.ToString();
               
            }

            object resultNew = commandNew.ExecuteScalar();
            if (resultNew != null)
            {
                txtArti.Text = resultNew.ToString();

            }

            connection.Close();



           

        }

        private void btnCek_Click(object sender, RoutedEventArgs e)
        {

            double miktariniz;
            double bakiyeniz;
            double ekstra;
            double borc;

            double.TryParse(txtYatir.Text, out miktariniz);
            double.TryParse(txtBakiye.Text, out bakiyeniz);

            double.TryParse(txtArti.Text, out ekstra);
            double.TryParse(txtKredi.Text, out borc);

            HesapBilgileri hesap = new HesapBilgileri();

            hesap.HesapNO = Convert.ToInt32(txtHesap.Text);
            hesap.Bakiye = Convert.ToInt32(txtYatir.Text);
            hesap.ArtiPara = Convert.ToInt32(txtYatir.Text);


            Atm islem = new Atm(bakiyeniz, miktariniz, ekstra, borc);
            double total;
            double creditBalance;

            if (bakiyeniz == 0 || bakiyeniz < 0)
            {
                if (txtYatir.Text != "")
                {
                    MessageBox.Show("Hesabinizda bakiye bulunmamaktadir");
                    if (MessageBox.Show("Arti bakiyenizden kullanmak ister misiniz?", "UYARI!!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        creditBalance = islem.artiPara();

                        if (miktariniz > ekstra)
                        {
                            MessageBox.Show("Arti para limitiniz yetersiz yalnizca " + txtArti.Text + " kadar kullanabílirsiniz", "Uyari!!");
                            txtYatir.Clear();
                        }
                        else
                        {

                            txtArti.Text = creditBalance.ToString();
                            HesapBLL.ArtiGuncelle(hesap);
                            MessageBox.Show("Arti bakiye kullandiniz");
                        }



                    }
                    txtYatir.Clear();
                }
                else
                {
                    MessageBox.Show("Lutfen Cekilecek Miktari Giriniz.");
                }
            }
            else
            {

                if (txtYatir.Text != "")
                {
                    List<HesapBilgileri> list = HesapBLL.HesapGetir(Convert.ToInt32(txtHesap.Text));
                    if (list.Count > 0)
                    {
                        if (MessageBox.Show("Para Cekme Islemini Onayliyor Musunuz?", "Uyari", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            total = islem.paraCek();
                            if (total >= 0)
                            {
                                txtBakiye.Text = total.ToString();
                                MessageBox.Show("Hesabinizdan " + txtYatir.Text + " Tutarinda Para Cekilmistir", "Uyari");
                                txtYatir.Clear();
                                HesapBLL.BakiyeGuncelleEksi(hesap);

                            }
                            else
                            {
                                MessageBox.Show("Bakiyeniz yeterli degil");



                                if (MessageBox.Show("Arti bakiyenizden kullanmak ister misiniz?", "UYARI!!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                {
                                    creditBalance = islem.artiPara();

                                    if (miktariniz > ekstra)
                                    {
                                        MessageBox.Show("Arti para limitiniz yetersiz yalnizca " + txtArti.Text + " kadar kullanabílirsiniz", "Uyari!!");
                                        txtYatir.Clear();
                                    }
                                    else
                                    {

                                        txtArti.Text = creditBalance.ToString();
                                        
                                        HesapBLL.ArtiGuncelle(hesap);
                                        MessageBox.Show("Arti bakiye kullandiniz");
                                    }


                                }



                                txtYatir.Clear();
                            }

                        }
                        else
                        {
                            txtYatir.Clear();
                        }

                    }
                }   
                 
                else
                {
                    MessageBox.Show("Lutfen Cekilecek Miktari Giriniz.");
                }


            }

        }

        private void btnOde_Click(object sender, RoutedEventArgs e)
        {
            HesapBilgileri hesap = new HesapBilgileri();
            double miktariniz;
            double bakiyeniz;
            double ekstra;
            double newEkstra;
            double borc;
            double.TryParse(txtYatir.Text, out miktariniz);
            double.TryParse(txtBakiye.Text, out bakiyeniz);
            double.TryParse(txtArti.Text, out ekstra);
            double.TryParse(txtKredi.Text, out borc);
            hesap.ArtiPara = Convert.ToInt32(txtYatir.Text);
            hesap.HesapNO = Convert.ToInt32(txtHesap.Text);


            Atm islem = new Atm(bakiyeniz, miktariniz, ekstra, borc); ;


            newEkstra = 1000 - ekstra;
            double kredi;

            if (MessageBox.Show(txtYatir.Text + " Tutarinda Odeme Yapilacaktir Onayliyor Musunuz? ", "UYARI!!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                List<HesapBilgileri> list = HesapBLL.HesapGetir(Convert.ToInt32(txtHesap.Text));
                if (list.Count>0)
                {
                    if (ekstra != 1000)
                    {
                        double total = islem.borcOde();
                       
                        if (total > 1000)
                        {
                            MessageBox.Show("en fazla " + newEkstra + " tutarinda odeme yapabilirsiniz");
                        }
                        else
                        {
                            txtArti.Text = total.ToString();
                            HesapBLL.ArtiGuncelleArti(hesap);
                            MessageBox.Show(txtYatir.Text + " tutarinda borc odemesi yapilmistir.", "Uyari!!");
                        }
                       

                    }
                    else if (borc < 0)
                    {
                        kredi = islem.krediOde();
                        txtKredi.Text = kredi.ToString();

                    }
                    else
                    {
                        MessageBox.Show("Borcunuz bulunmamaktadir", "Uyari!!");
                    }
                }
               
            }



            txtYatir.Clear();


        }
    }
}
