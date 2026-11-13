using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using TrainController.Interfaces;
using TrainController.Models;

namespace TrainController.UserControls
{
    /// <summary>
    /// Interaktionslogik für SchieneGerade.xaml
    /// </summary>
    public partial class SchieneGerade : UserControl,IBaseControl,INotifyPropertyChanged
    {
        private MainWinModel? model;

        public MainWinModel? Model
        {
            get { return model; }
            set { model = value; }
        }

        public string CtlName 
        {
            get => ctlname; 
            set => ctlname = value; 
        }
        string ctlname = string.Empty;       


        public double CtlWidh 
        { 
            get => ctlwidth;
            set => ctlwidth = value;
        }
        double ctlwidth = 50;
        public Visibility GrabberVisibility 
        { 
            get => grabbervisibility; 
            set
            {
                grabbervisibility = value;
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(GrabberVisibility)));
            }  
        }
        Visibility grabbervisibility = Visibility.Hidden;

        public event PropertyChangedEventHandler? PropertyChanged;


        //public MouseGrabber Mousegrabber
        //{
        //    get => mouseGrabber; 
        //    set => mouseGrabber = value;
        //}      


        public SchieneGerade()
        {   
            InitializeComponent();
            DataContext = this;
           
        }
        public SchieneGerade(MainWinModel mod)
        {

            InitializeComponent();
            DataContext = this;
            model = mod;            
        }

        public SchieneGerade(SchieneGerade c)
        {
            InitializeComponent();   
            DataContext = this;
            this.Width = c.Width;
            this.Height = c.Height;           
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {


                DataObject data = new DataObject();
                data.SetData(DataFormats.StringFormat, SchieneGerade_Horizontal);
                data.SetData("Width", SchieneGerade_Horizontal.Width);
                data.SetData("Object", this); // Setzen Sie das UserControl selbst als Datenobjekt
             //   data.SetData("Vm", model); //Model auf datalist setzen

                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy|DragDropEffects.Move);
            }
        }

        protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
            base.OnGiveFeedback(e);
            if (e.Effects.HasFlag(DragDropEffects.Copy))
            {
                Mouse.SetCursor(Cursors.Cross);
            }
            else if (e.Effects.HasFlag(DragDropEffects.Move))
            {
                Mouse.SetCursor(Cursors.Cross);
            }
            else
            {
                Mouse.SetCursor(Cursors.No);
            }
            e.Handled = true;
        }

        private void Rectangle_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
