using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_Demo.Binding
{
    public class BindingCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private BindingViewModel _viewmodel;
        public BindingCommand(BindingViewModel vm)
        {
            this._viewmodel = vm;
        }
        public bool CanExecute(object parameter)
        {
            return this._viewmodel.SliderValue > 50;
        }

        public void Execute(object parameter)
        {
            this._viewmodel.ClickCount++;
        }
    }
}
