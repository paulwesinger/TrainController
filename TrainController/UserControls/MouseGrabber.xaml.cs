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
        UserControlsVM? viewmodel;

        public UserControlsVM? Viewmodel
        {
            get 
            { 
                return viewmodel; 
            }
            set
            {
                viewmodel = value;
            }
        }

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

        
        public MouseGrabber()
        {
            InitializeComponent();
            MyCanvas = new Canvas();
            Viewmodel = new UserControlsVM();
            LocationX = 0;
            LocationY = 0;
        }

        public MouseGrabber(UserControl parent, UserControlsVM? vm)
        {
            
            InitializeComponent();
            if (vm == null)
                this.Viewmodel = new UserControlsVM();
            else
                this.Viewmodel = vm;

            this.Width = parent.Width;
            this.Height = parent.Height;

            var item = parent as SchieneGerade;
            
           
            this.LocationX = Canvas.GetLeft(parent);
            this.LocationY = Canvas.GetTop(parent);
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

                if (viewmodel != null)
                    this.viewmodel.CntrlWidth = this.Width;
            }
        }

        private void GrabRight_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GrabPoint = new Point(e.GetPosition(this).X,e.GetPosition(this).Y);
        }
    }
}
