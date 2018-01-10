using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Demo.Controls
{
    public class ControlsViewModel : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Employee> employees;

        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set { employees = value; }
        }

        public ControlsViewModel()
        {
            this.employees = new ObservableCollection<Employee>
            {
                new Employee("Developer"){ Name = "Roelof", HasPermanentContract = true, Department = Department.CSD },
                new Employee("Account Manager"){ Name = "Jasper", HasPermanentContract = true, Department = Department.Sales },
                new Employee("Stagiair"){ Name = "Thomas", HasPermanentContract = false, Department = Department.BTech},
                new Employee("Recruiter"){ Name = "Hester", HasPermanentContract = true, Department = Department.Recruitment}
            };
        }
    }
}
