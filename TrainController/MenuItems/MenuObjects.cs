using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TrainController.MenuItems
{
    public class MenuObjects
    {
        public string TextElement { get; set; } 
        public UIElement ControlElement { get; set; }
        public MenuObjects() 
        {
            TextElement = "NOName";
            ControlElement = new UIElement();
        }

        public MenuObjects(string text, UIElement element)
        {
            TextElement = text;
            ControlElement = element;
        }
    }
}
