using LuckyMinerWCFService.Contracts;
using LuckyMinerWCFService.Proxy;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LuckyMinerWCFService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LuckyMinerProxy proxy = new LuckyMinerProxy();
      
        public MainWindow()
        {
            InitializeComponent();
            ClientAccount client = new ClientAccount();
            client.Show();
            WcfLight wcfLight = new WcfLight();
            wcfLight.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           CoinContract coin =  proxy.GetLucky();
            if(coin == null)
            {
                MessageBox.Show("Unlucky!!!!!!!!!!!");
            }
            else
            {
                StringBuilder result = new StringBuilder(coin.hash.Length * 2);

                for (int i = 0; i < coin.hash.Length; i++)
                    result.Append(coin.hash[i].ToString(false ? "X2" : "x2"));

                MessageBox.Show("YOU LUCKY: " + result.ToString());
            }
        }
    }
}
