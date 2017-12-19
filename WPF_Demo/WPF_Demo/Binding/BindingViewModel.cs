using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_Demo.Binding
{
    public class BindingViewModel : INotifyPropertyChanged
    {
        private int _sliderValue;

        public int SliderValue
        {
            get { return _sliderValue; }
            set { _sliderValue = value; OnPropertyChanged(nameof(SliderValue)); }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        private int _clickCount;

        public int ClickCount
        {
            get
            {
                return _clickCount;
            }
            set
            {
                _clickCount = value;
                #region
                OnPropertyChanged(nameof(ClickCount));
                OnPropertyChanged(nameof(ButtonText));
                #endregion
            }
        }

        public string ButtonStartText { get; set; }
        public string ButtonText
        {
            get
            {
                return ButtonStartText + ClickCount;
            }
        }

        private ObservableCollection<string> _listItems;

        public ObservableCollection<string> MyListItems
        {
            get { return _listItems; }
            set { _listItems = value; }
        }


        private ICommand _bindingCommand;

        public ICommand BindingCommand
        {
            get { return _bindingCommand; }
            set { _bindingCommand = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public BindingViewModel()
        {
            this.ButtonStartText = "Clicks: ";
            this.BindingCommand = new BindingCommand(CommandFunction);
            this.MyListItems = new ObservableCollection<string> {
                "One",
                "Two",
                "Three"
            };
        }

        private void CommandFunction()
        {
            this.ClickCount++;
        }

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
