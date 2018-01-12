using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using WPF_Demo.DependencyInjection;

namespace WPF_Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IUnityContainer container = new UnityContainer();
            RegisterTypes(container);
            
            InjectionView window = container.Resolve<InjectionView>();
            window.Show();
        }

        private void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IValue, IntValue>();
            container.RegisterType<IValue, IntValue>("Integer");
            container.RegisterType<IValue, StringValue>("String");
            
        }
    }
}
