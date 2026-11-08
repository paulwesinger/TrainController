using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrainController.Dialogs;
using TrainController.Models;

namespace TrainController.ProjectWindow
{
    /// <summary>
    /// Interaktionslogik für ProjectEditor.xaml
    /// </summary>
    public partial class ProjectEditor : UserControl
    {
        public ProjectWinVM modelProject = new ProjectWinVM();        

        Canvas canvas;
        public ProjectEditor()
        { 
            DataContext= modelProject;
            InitializeComponent();
            canvas = mycanvas;
           
        }

        public void DrawRaster(bool drawraster)
        {
            if (drawraster)
                canvas.Background = modelProject.CreateDotGridBrush(20.0, 2, Brushes.Gray);
            else
                canvas.Background = Brushes.Transparent;
        }
    }
}
