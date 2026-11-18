using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TrainController.MenuItems;
using TrainController.Models;
using TrainController.UserControls;


namespace TrainController.ProjectWindow
{
    /// <summary>
    /// Interaktionslogik für ProjectEditor.xaml
    /// </summary>
    public partial class ProjectEditor : UserControl
    {
        public MainWinModel Model;
        private UserControl? currentControl = null;

     //   public MouseGrabber? mousegrabber = null;

        public Canvas canvas; 

        public int CountTracks
        {
            get => countTracks;
            set => countTracks = value; 
        }
        private int countTracks = 0;

        private bool _snapToGrid = true;

        
        public ProjectEditor(MainWinModel model)
        { 
            Model = model;
            DataContext= Model.ProjecModel;
            InitializeComponent(); 
            
            canvas = mycanvas;           
        }



        public void DrawRaster(bool drawraster)
        {
            if (drawraster)
                canvas.Background = Model.ProjecModel.CreateDotGridBrush(Model.ProjecModel.SpacingX, Model.ProjecModel.SpacingY , 2, Brushes.DarkGray);
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


                // Erstellen Sie eine neue Instanz des UserControls
                UserControl? newControl = null;

                if (droppedControl is SchieneGerade)
                {
                    newControl = new SchieneGerade(Model, mycanvas);
                    ((SchieneGerade)newControl).GrabberVisibility = Visibility.Visible;
                    //newControl.RenderTransformOrigin = new Point(0,0);
                    //newControl.RenderTransform = new RotateTransform(45);



                }
                else
                if (droppedControl is SiemensGeradeH)
                {
                    newControl = new SiemensGeradeH();
                }
                else
                if (droppedControl is SiemensHtoRightUp)
                {
                    newControl = new SiemensHtoRightUp();
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
                    Point dropPosition = e.GetPosition(this.mycanvas);

                    if (_snapToGrid)
                    {
                        dropPosition.X = Math.Round(dropPosition.X / Model.ProjecModel.SpacingX) * Model.ProjecModel.SpacingX;
                        dropPosition.Y = Math.Round(dropPosition.Y / Model.ProjecModel.SpacingY) * Model.ProjecModel.SpacingY;
                    }
                    Canvas.SetLeft(newControl, dropPosition.X);
                    Canvas.SetTop(newControl, dropPosition.Y);
                    Canvas.SetRight(newControl, dropPosition.X + 40);
                    Canvas.SetBottom(newControl, 20);

                    // Fügen Sie das neue Control zum Canvas hinzu                   

                    // erstmal den mousegrabber für eine horizontale gerade testen => später für vertikale und bögen adaptieren
                    // jedes schienen element kriegt seinen eigenen grabber:

                    //mousegrabber = new MouseGrabber(newControl, Model);

                    ////((SchieneGerade)newControl).Mousegrabber = mousegrabber;
                    //mousegrabber.ChildCtl = ((SchieneGerade)newControl); 


                    //  Canvas.SetLeft(mousegrabber, dropPosition.X);
                    //  Canvas.SetTop(mousegrabber, dropPosition.Y+5);

                    ////  mousegrabber.Height = 20;
                    //  Canvas.SetBottom(mousegrabber, 20);

                    //(SchieneGerade)newControl.                   
                    //newControl.Width = 100;

                    canvas.Children.Add(newControl);
                    //                  canvas.Children.Add(mousegrabber);

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
                    //Model.ProjecModel.EditMode = true;
                   // item.Model?.ControlsModel.Editing = true;
                   // item.Width = 100;
                    //item.Child.Width = 100;
                                 
                }
            }
        }

        private void mycanvas_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)

        {

            MenuObjects item1 = new MenuObjects() {TextElement = "Element 1", ControlElement = new SchieneGerade() };

            Model.ProjecModel.Menuobjects.Add(item1);
            this.lvMenu.ItemsSource = Model.ProjecModel.Menuobjects;

            //TreeviewMenuItems item1 = new TreeviewMenuItems("Header 1", new SchieneGerade(),"Gerade");
            //TreeviewMenuItems item2 = new TreeviewMenuItems("Header 2", new SchieneGerade(), "Bogen");


            //TreeviewMenuItems item1_1 = new TreeviewMenuItems("Header 1_1", new SchieneGerade(), "Gerade1_1");  
            //item1.Childs.Add(item1_1);

            //Model.ProjecModel.RootNode.Childs.Add(item1);
            //Model.ProjecModel.RootNode.Childs.Add(item2);



            //this.trvTracks.Items.Add(rootitem);

            //Model.ProjecModel.RootNode.Header = "Tracks";//  Childs.Add(new SchieneGerade());
            //Model.ProjecModel.RootNode.Childs.Add(new SchieneGerade());
            //Model.ProjecModel.RootNode.Childs.Add(new SiemensGeradeH());

           // this.trvTracks.Items.Add(Model.ProjecModel.RootNode);
        }
    }
}
