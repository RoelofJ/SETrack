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

namespace WPF_Demo.Async
{
    /// <summary>
    /// Interaction logic for Controls.xaml
    /// </summary>
    public partial class Async : Window
    {
        public Async()
        {
            InitializeComponent();
            ComputeStuffAsync();
        }

        private async void ComputeStuffAsync()
        {
            while (true)
            {
                var sum = 0.0;
                await Task.Run(() => 
                {
                    for (int i = 0; i < 200000000; i++)
                    {
                        sum += Math.Sqrt(i);
                        //Runtime error: cannot access property from this thread
                        //Message.Text = "Sum is: " + sum;
                    }
                });
                Message.Text = "Sum is: " + sum;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button clicked");
        }
    }
}
