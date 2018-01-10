using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Demo.Controls
{
    public class Employee : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _title;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title
        {
            get { return _title; }
        }

        private bool _hasPermanentContract;

        public bool HasPermanentContract
        {
            get { return _hasPermanentContract; }
            set { _hasPermanentContract = value; }
        }

        private Department _department;

        public Department Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public Employee()
        {

        }

        public Employee(string title)
        {
            this._title = title;
        }
    }

    public enum Department
    {
        FS,
        CSD,
        Testing,
        BTech,
        Sales,
        Recruitment
    }
}
