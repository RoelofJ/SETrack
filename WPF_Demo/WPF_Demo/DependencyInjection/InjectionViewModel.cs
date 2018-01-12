using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Attributes;

namespace WPF_Demo.DependencyInjection
{
    public class InjectionViewModel
    {
        private IValue _value;
        public string Value { get { return _value.GetValue().ToString(); } }

        public IValue StringValue { get; set; }

        //("Integer")
        public InjectionViewModel([Dependency("String")] IValue val)
        {
            this._value = val;
        }
    }
}
