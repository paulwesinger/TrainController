using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TrainController.Models;

namespace TrainController.Interfaces
{
    public interface IBaseControl
    {
        public string CtlName { get; set; }
        public UserControlsVM ViewModel { get; set; }      

    }
}
