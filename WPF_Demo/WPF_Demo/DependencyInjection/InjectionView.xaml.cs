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
using Unity.Attributes;

namespace WPF_Demo.DependencyInjection
{
    /// <summary>
    /// Interaction logic for InjectionView.xaml
    /// </summary>
    public partial class InjectionView : Window
    {
        [Dependency]
        public InjectionViewModel ViewModel
        {
            set { DataContext = value; }
        }

        public InjectionView(IValue value)
        {
            
            this.DataContext = new InjectionViewModel(value);
            InitializeComponent();
        }
    }
}
