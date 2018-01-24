using LuckyMinerWCFService.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LuckyMinerWCFService
{
    /// <summary>
    /// Interaction logic for ClientAccount.xaml
    /// </summary>
    public partial class ClientAccount : Window
    {
        BankProxy bankproxy = new BankProxy();
        string name = "Dirk";
        public ClientAccount()
        {
            bankproxy.CreateNewAccount(name);
            bankproxy.Deposit(name, 100);
        }

        public int getBalance()
        {
           return bankproxy.GetBalance(name);
        }

        public void updateBalanceLabel()
        {
            balanceLabel.Content =  bankproxy.GetBalance(name);
        }

        private void updatebalance_Click(object sender, RoutedEventArgs e)
        {
            balanceLabel.Content = getBalance();
        }

        private void deposit100_Click(object sender, RoutedEventArgs e)
        {
            bankproxy.Deposit(name, 100);
            updateBalanceLabel();
        }

        private void writeToJan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bankproxy.WriteToAccount(name, "Jan", 100);
            }
            catch
            {
                bankproxy = new BankProxy();
            }
                 updateBalanceLabel();
        }

        private void AddJan_Click(object sender, RoutedEventArgs e)
        {
            bankproxy.CreateNewAccount("Jan");
        }

        private void UpdateJanBalance_Click(object sender, RoutedEventArgs e)
        {
            JanBalanceLabel.Content = bankproxy.GetBalance("Jan");
        }
    }
}
