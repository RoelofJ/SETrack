using LuckyMinerWCFService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

namespace LuckyMinerWCFService.Host
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceHost host = new ServiceHost(typeof(LuckyMinerService));
        ServiceHost bankHost = new ServiceHost(typeof(BankService));
        ServiceHost lightHost = new ServiceHost(typeof(LightService));
        public MainWindow()
        {
            InitializeComponent();
           
            host.Open();
            label1.Content = " Connected to Lucky Miner Service \n ";
            bankHost.Open();
            label1.Content += "Connected to Bank service.\n";
            lightHost.Open();
            label1.Content += "Connected to Light service.";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bankHost.Close();
            host.Close();
            lightHost.Close();
            label1.Content += "Disconnected";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bankHost.Close();
            lightHost.Close();
            host.Close();
        }
    }
}
