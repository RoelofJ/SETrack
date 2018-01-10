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

namespace CustomControl_Demo
{
    /// <summary>
    /// Interaction logic for NumericControl.xaml
    /// </summary>
    public partial class NumericControl : UserControl
    {
        public NumericControl()
        {
            InitializeComponent();
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NumericValue.Text, out int value))
            {
                NumericValue.Text = (value + 1).ToString();
            }
            else
            {
                NumericValue.Text = "0";
            }
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NumericValue.Text, out int value))
            {
                NumericValue.Text = (value - 1).ToString();
            }
            else
            {
                NumericValue.Text = "0";
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (!KeyIsNumeric(e.Key))
            {
                e.Handled = true;
            }
        }

        private bool KeyIsNumeric(Key key)
        {
            return
                (key >= Key.D0 && key <= Key.D9) ||
                (key >= Key.NumPad0 && key <= Key.NumPad9);
        }
    }
}
