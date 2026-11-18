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
            Header= "Leerer Header";       
            
            Elementlabel= "Leerer Label";

            uiElement = new UIElement();

            Childs = new ObservableCollection<TreeviewMenuItems>();
        }
        public TreeviewMenuItems(string header,UIElement elem,string label)
        {
            Header = header;

            Childs = new ObservableCollection<TreeviewMenuItems>();
            uiElement = elem == null ? new UIElement() : elem;
            Elementlabel = label;

        }

        public string Header { get; set; } 
        public string Elementlabel { get; set; }
        public UIElement uiElement {  get; set; }
      

        public ObservableCollection<TreeviewMenuItems> Childs { get; set; }
    }
}
