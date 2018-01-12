using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Attributes;

namespace WPF_Demo.DependencyInjection
{
    public class StringValue : IValue
    {
        private string _value;

        public StringValue([Dependency]IValue innerValue)
        {
            this._value = "MyString";
        }
        public object GetValue()
        {
            return _value;
        }
    }
}
