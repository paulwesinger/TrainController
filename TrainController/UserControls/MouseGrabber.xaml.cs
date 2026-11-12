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
using TrainController.Models;

namespace TrainController.UserControls
{
    /// <summary>
    /// Interaktionslogik für MouseGrabber.xaml
    /// </summary>
    public partial class MouseGrabber : UserControl    
    {
        //public static readonly DependencyProperty UserControlsVMProperty = DependencyProperty.Register("UserControlsVM",
        //    typeof(UserControlsModel), typeof(MouseGrabber), new PropertyMetadata(null));

        MainWinModel? model;

        public MainWinModel? Model
        {
            get => model;
            set => model = value;
        }

        public UserControl ChildCtl
        {
            get => childctl;                          
            set
            {  
                if (value == null) return;
                childctl = value;
            }            
        }
        private UserControl childctl;
 

        public Canvas? MyCanvas
        {
            get => _canvas;
            set => _canvas = value;
        }
        private Canvas? _canvas = null;
        // -------------------------
        // Wird gebraucht für die Linke obere Ecke des parent
        public double LocationX;
        public double LocationY;

        private Point GrabPoint;

        
        public MouseGrabber(MainWinModel? vmodel)
        {
            InitializeComponent();
            MyCanvas = new Canvas();
            model = vmodel;
            LocationX = 0;
            LocationY = 0;
            childctl = new UserControl();
        }

        public MouseGrabber(UIElement child)
        {
            InitializeComponent();
        }

        public MouseGrabber(UIElement child,MainWinModel vmodel)
        {
            
            InitializeComponent();

            model= vmodel;
            // exception werfen 
            //if (model == null)
            //    this.model = new UserControlsModel();
            //else
            //    this.model = vm;

            Type t = child.GetType();
            if (t == typeof(SchieneGerade))
                ChildCtl =  child as SchieneGerade;

            
            //var item = child  as SchieneGerade;
            ////ChildCtl = t;
           
          
        }

        private void GrabRight_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) {                
                GrabPoint = new Point(e.GetPosition(this).X,e.GetPosition(this).Y); 
                

            }
        }

        private void GrabRight_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point p = new Point(e.GetPosition(this).X, e.GetPosition(this).Y);
                double deltaX = p.X - GrabPoint.X;           

                this.Width += deltaX;
                //GrabPoint.X += deltaX;

                if (model != null)
                   model.ControlsModel.CntrlWidth = this.Width;

                ChildCtl.Width += deltaX;
                GrabPoint.X += deltaX;
                
            }
        }

        private void GrabRight_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GrabPoint = new Point(e.GetPosition(this).X,e.GetPosition(this).Y);
            this.Visibility = Visibility.Hidden;
            Model.ControlsModel.Editing = false;
            //Viewmodel.Editing = false;
        }
    }
}
