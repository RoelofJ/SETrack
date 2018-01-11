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

namespace PerformanceTestProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random random;
        private StackPanel tempStack;
        private int _nrOfStacks;
        private bool flipFlop;

        public int nrOfStacks
        {
            get { return _nrOfStacks; }
            set { _nrOfStacks = value; tempStack = AddToStack(tempStack);  }
        }

        public MainWindow()
        {   
            random = new Random();
            InitializeComponent();
            tempStack = HierGaatHetGebeuren;
        }
        
        private StackPanel AddToStack(StackPanel addTo)
        {
            var n = new StackPanel();
            n.Orientation = flipFlop ? Orientation.Horizontal : Orientation.Vertical;
            n.Margin = new Thickness(4);
            var ColorBytes = new byte[3];
            random.NextBytes(ColorBytes);
            n.Background = new SolidColorBrush(Color.FromRgb(ColorBytes[0], ColorBytes[1], ColorBytes[2]));
            var l = new Label();
            l.Content = String.Format("#{0}",ByteArrayToString(ColorBytes));
            n.Children.Add(l);
            addTo.Children.Add(n);
            flipFlop = !flipFlop;
            return n;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            nrOfStacks++;
            nrOfStackPanels.Text = string.Format("{0}",nrOfStacks);
        }
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}
