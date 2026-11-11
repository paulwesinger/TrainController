using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TrainController.UserControls;

namespace TrainController.Models
{
    public class UserControlsVM : INotifyPropertyChanged
    { 

        public event PropertyChangedEventHandler? PropertyChanged;
        public bool Editing
        {
            get => _editing;
            set
            {
                if (_editing != value) return;
                _editing = value;
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(Editing)));
            }
        }
        private bool _editing = true;


        public double CntrlWidth
        {
            get => _cntrlwidth;
            set
            {
                if (value ==  _cntrlwidth) return;
                _cntrlwidth = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CntrlWidth)));
            }
        }
        private double _cntrlwidth = 32;

        //public static implicit operator UserControlsVM?(SchieneGerade? v)
        //{
        //    if (v == null) return null;

        //    return v.ViewModel;
        //}
    }
}
