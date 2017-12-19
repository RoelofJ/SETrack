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
        private Action _actualAction;
        public BindingCommand(Action action)
        {
            this._actualAction = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this._actualAction();
        }
    }
}
