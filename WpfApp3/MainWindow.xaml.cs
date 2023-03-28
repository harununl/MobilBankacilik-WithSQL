using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLLL;
using DAL;
using DAL.DAO;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCıkıs_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Emin misiniz?", "Uyari",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();

            }
            
           
        }
      
        private void btnOlustur_Click(object sender, RoutedEventArgs e)
        {
           
            KullaniciBilgileri kullanici = new KullaniciBilgileri();

            kullanici.HesapNO = Convert.ToInt32(txtNo.Text.ToString());
           
            kullanici.MusteriAd = txtAd.Text;
            kullanici.MusteriSoyad = txtSoyad.Text;
            kullanici.MusteriYas = Convert.ToInt32(txtYas.Text.ToString());
     
            if(kullanici.MusteriYas < 18) 
            {
                MessageBox.Show("Yasiniz 18den buyuk olmali");
            }
            else if(kullanici.HesapNO.ToString().Length != 6)
            {
                MessageBox.Show("Hesap No 6 haneli olmalidir.");
            }
            else
            {
                List<KullaniciBilgileri> list = KullaniciBLL.KullaniciGetir(Convert.ToInt32(txtNo.Text));
                if (list.Count > 0)
                {
                    MessageBox.Show("Zaten Kayitlisiniz.");
                    txtAd.Clear();
                    txtSoyad.Clear();
                    txtYas.Clear();
                    txtNo.Clear();
                }
                else
                {
                    MessageBox.Show("Basariyla Musteri Oldunuz.");
                    txtAd.Clear();
                    txtSoyad.Clear();
                    txtYas.Clear();
                    txtNo.Clear();
                    MessageBox.Show("Hesap numaraniz ile giris yapabilirsiniz.");


                    KullaniciBLL.KullaniciEkle(kullanici);
                }



              
                
               

            }





           
       

        }

        private void btnIslem_Click(object sender, RoutedEventArgs e)
        {
         
            double txtIlk;
            double txtYeni;
            string temp = "";
          
        
           
          
            if (txtHesap.Text.Trim() == "")
            {
                MessageBox.Show("Hesap No Bos Gecilemez.");
            }
            else
            {
                List<KullaniciBilgileri> list = KullaniciBLL.KullaniciGetir(Convert.ToInt32(txtHesap.Text));
                if(list.Count <= 0 ) 
                {
                    MessageBox.Show("Hesap No Yanlis.");
                }
                else
                {
                    FrmIslem islem = new FrmIslem();
                    double.TryParse(txtHesap.Text, out txtIlk);
                    double.TryParse(islem.txtHesap.Text, out txtYeni);

                    temp = txtHesap.Text;
                   
                    islem.txtHesap.Text = temp;

                   

                  
                    MessageBox.Show("Basariyla Giris Yaptiniz.");
                  
                    
                    this.Hide();
                    islem.ShowDialog();
                    
                    this.Visibility = Visibility.Visible;
                }
            }
         

        }
    }
}
