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
using TrainController.Interfaces;
using TrainController.Models;
using TrainController.UserControls;

namespace TrainController.ProjectWindow
{
    /// <summary>
    /// Interaktionslogik für ProjectEditor.xaml
    /// </summary>
    public partial class ProjectEditor : UserControl
    {
        public ProjectWinVM modelProject = new ProjectWinVM();

        private UserControl? currentControl = null;

        public MouseGrabber? mousegrabber = null;

        public Canvas canvas;

        


        public int CountTracks
        {
            get => countTracks;
            set => countTracks = value; 
        }
        private int countTracks = 0;

        private bool _snapToGrid = true;

        
        public ProjectEditor()
        { 
            DataContext= modelProject;
            InitializeComponent();
            canvas = mycanvas;           
        }



        public void DrawRaster(bool drawraster)
        {
            if (drawraster)
                canvas.Background = modelProject.CreateDotGridBrush(modelProject.Spacing , 2, Brushes.Gray);
            else
                canvas.Background = Brushes.Transparent;
        }

        //protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        //{
        //    base.OnPreviewMouseLeftButtonDown(e);

        //    Point p = e.GetPosition(mycanvas);

        //    if (p.X < 0)
        //    {
        //        // Drag and Drop
        //    }
        //    else
        //    {
        //        // Select the child in the ui-tree to transform it
        //        Type t = e.GetType();
                
        //        if (e.GetType() == typeof(SchieneGerade))
        //        {
        //            SchieneGerade selectedControl = (SchieneGerade)e.Source;
        //            // Do something with the selected control
        //        }
        //    }
        //}

        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);
            if (e.Data.GetDataPresent(DataFormats.StringFormat) && e.Data.GetDataPresent("Width") && e.Data.GetDataPresent("Object"))
            {
               // string fillColorString = (string)e.Data.GetData(DataFormats.StringFormat);
                //double width = (double)e.Data.GetData("Width");
                UserControl droppedControl = (UserControl)e.Data.GetData("Object");

                if (droppedControl == null) return;

                UserControlsVM model; //= e.Data.GetData("Vm") as SchieneGerade;
                // Erstellen Sie eine neue Instanz des UserControls
                UserControl? newControl = null;
                model = new UserControlsVM();

                if (droppedControl is SchieneGerade)
                {
                    newControl = new SchieneGerade(model);                    
                }
                //else if (droppedControl is SchieneKurve)
                //{
                //    newControl = new SchieneKurve();
                //    ((SchieneKurve)newControl).Schiene_Kurve.Fill = (Brush)new BrushConverter().ConvertFromString(fillColorString);
                //    ((SchieneKurve)newControl).Schiene_Kurve.Width = width;
                //}


                if (newControl != null)
                {
                    // Setzen Sie die Position des neuen Controls auf die Drop-Position
                    Point dropPosition = e.GetPosition(canvas);  

                    if (_snapToGrid)
                    {
                        dropPosition.X = Math.Round(dropPosition.X / modelProject.Spacing) * modelProject.Spacing;
                        dropPosition.Y = Math.Round(dropPosition.Y / modelProject.Spacing) * modelProject.Spacing;
                    }                  
                    Canvas.SetLeft(newControl, dropPosition.X);
                    Canvas.SetTop(newControl, dropPosition.Y);

                    // Fügen Sie das neue Control zum Canvas hinzu                   

                    // erstmal den mousegrabber für eine horizontale gerade testen => später für vertikale und bögen adaptieren
                    // jedes schienen element kriegt seinen eigenen grabber:
                                        
                    mousegrabber = new MouseGrabber(newControl, model);

                    ((SchieneGerade)newControl).Mousegrabber = mousegrabber;

                    Canvas.SetLeft(mousegrabber, dropPosition.X);
                    Canvas.SetTop(mousegrabber, dropPosition.Y+5);

                  //  mousegrabber.Height = 20;
                    Canvas.SetBottom(mousegrabber, 20);

                    //(SchieneGerade)newControl.
                    canvas.Children.Add(newControl);
                    canvas.Children.Add(mousegrabber);

                    CountTracks++;
                }
            }
        }

        private void mycanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           

        }

        private void mycanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mycanvas.Children.Count == 0)
                return;

            //var firstChild = mycanvas.Children[0];
            var ctl = mycanvas.Children.OfType<SchieneGerade>().ToList();
            foreach (var item in ctl)
            {
                if (item.IsMouseOver)
                {
                    // Flag für Bearbeitung eines UI Elements setzensetzen
                    // ToDo: UIElement mit Punkten zum transformieren versehen
                    modelProject.EditMode = true;
                    item.ViewModel.Editing = true;
                    item.Width = 100;
                    item.Mousegrabber.Width = 100;
                                 
                }
            }
        }
    }
}
