using LuckyMinerWCFService.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
    /// Interaction logic for WcfLight.xaml
    /// </summary>
    public partial class WcfLight : Window
    {
        public WcfLight()
        {
            InitializeComponent();
            LightServiceCallback callback = new LightServiceCallback(new Button[] { Button1, Button2, Button3 }, SynchronizationContext.Current);
            LightProxy proxy = new LightProxy(new System.ServiceModel.InstanceContext(callback));
            Task.Run(() =>
           {
              MessageBox.Show(proxy.EnableButtons());
           });
        }
    }
}
