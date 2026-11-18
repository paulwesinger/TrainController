using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TrainController.MenuItems
{
    public class TreeViewUIItem:TreeViewItem
    {
        public string Textelement { get; set; } 
        public UIElement Visualelement { get; set; }
        public TreeViewUIItem() 
        {
            Textelement = "NOName";
            Visualelement = new UIElement();
        }

        public TreeViewUIItem(string text, UIElement element)
        {
            Textelement = text;
            Visualelement = element;
        }
    }
}
