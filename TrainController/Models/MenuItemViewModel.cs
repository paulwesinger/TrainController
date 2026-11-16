using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainController.Models
{
    class MenuItemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        public MenuItemViewModel() 
        { 

        }
        public string Title 
        { 
            get => title;
            set
            {
                title = value;
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("Title"));
            } 
        }
        private string title = string.Empty;





    }
}
