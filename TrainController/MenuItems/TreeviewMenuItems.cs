using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TrainController.Interfaces;

namespace TrainController.MenuItems
{
    public class TreeviewMenuItems
    {
        public TreeviewMenuItems()
        {
            Header= string.Empty;
            IconPath = string.Empty;
        }
        public TreeviewMenuItems(string header, ObservableCollection<UIElement> childs)
        {
            Header = header;
            IconPath = string.Empty;
            Childs = childs;
        }

        public string Header { get; set; } = "Default";
        public string IconPath { get; set; }

        public ObservableCollection<UIElement> Childs { get; set; } = new();
    }
}
