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
using WCF_Demo.Contracts;
using WCF_Demo.Proxies;

namespace WCF_Demo.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CheckAstronautClient _proxy;
        public CheckAstronautClient Proxy {
            get
            {
                if (_proxy == null || _proxy.State != System.ServiceModel.CommunicationState.Opened)
                {
                    _proxy = new CheckAstronautClient();
                    _proxy.Open();
                }
                return _proxy;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Preliminary_Click(object sender, RoutedEventArgs e)
        {
            var validData = FormIsValid();
            (sender as Button).Background = validData ? Brushes.LightGray : Brushes.Red;
            if (validData)
            {
                var data = ParseForm();
                var proxy = new CheckAstronautClient();
                var passed = proxy.DoPreliminaryCheckup(data);
                PreliminaryResult.Text = passed.ToString();
                proxy.Close();
            }
        }

        private void Final_Click(object sender, RoutedEventArgs e)
        {
            var validData = FormIsValid();
            (sender as Button).Background = validData ? Brushes.LightGray : Brushes.Red;
            if (validData)
            {
                var data = ParseForm();
                var proxy = new CheckAstronautClient();
                var passed = proxy.DoFinalCheckup(data);
                FinalResult.Text = passed.ToString();
                proxy.Close();
            }
        }

        private void SendNames_Click(object sender, RoutedEventArgs evt)
        {
            Proxy.SetNames(AllNamesBox.Text.Split(' '));
        }

        private void GetNames_Click(object sender, RoutedEventArgs evt)
        {
            RetrievedNames.Text = string.Join(" ", Proxy.GetNames());
        }

        private void Exception_Click(object sender, RoutedEventArgs evt)
        {
            Proxy.ThrowException();
        }

        private FlightRosterData ParseForm()
        {
            return new FlightRosterData
            {
                CaptainName = CaptainName.Text,
                SecondInCommandName = SecondName.Text,
                NavigatorName = NavigatorName.Text,
                EngineerName = EngineerName.Text
            };
        }

        private bool FormIsValid()
        {
            return 
                !string.IsNullOrWhiteSpace(CaptainName.Text) &&
                !string.IsNullOrWhiteSpace(SecondName.Text) &&
                !string.IsNullOrWhiteSpace(NavigatorName.Text) &&
                !string.IsNullOrWhiteSpace(EngineerName.Text);
        }
    }
}
