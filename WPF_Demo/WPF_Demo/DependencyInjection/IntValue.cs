using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Demo.DependencyInjection
{
    public class IntValue : IValue
    {
        private int _value;

        public IntValue()
        {
            this._value = 15;
        }
        public object GetValue()
        {
            return _value;
        }
    }
}
