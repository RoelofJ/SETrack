using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_Demo.Async
{
    public class AsyncViewModel
    {
        private ICommand _clickCommand;

        public ICommand ClickCommand
        {
            get { return _clickCommand; }
            set { _clickCommand = value; }
        }
    }
}
