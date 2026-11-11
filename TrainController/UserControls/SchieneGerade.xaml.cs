using System;
using System.Collections.Generic;
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
    public partial class SchieneGerade : UserControl//,IBaseControl
    {
        private UserControlsVM viewmodel = new UserControlsVM();

        //public MouseGrabber Mousegrabber
        //{
        //    get => mouseGrabber; 
        //    set => mouseGrabber = value;
        //}

        private MouseGrabber mouseGrabber;
        public UserControlsVM ViewModel
        { 
            get => viewmodel;
            set => viewmodel = value; 
        }
        public string CtlName 
        {            
            get => this.Name;
            set => this.Name = value; 
        }     

        public SchieneGerade()
        {   
            InitializeComponent();
            viewmodel = new UserControlsVM();
            mouseGrabber = new MouseGrabber(this,viewmodel);
           
        }
        public SchieneGerade(UserControlsVM model)
        {

            InitializeComponent();
            viewmodel = model;
            mouseGrabber = new MouseGrabber(this,model);          
        }

        public SchieneGerade(SchieneGerade c)
        {
            InitializeComponent(); 
            viewmodel = new UserControlsVM();
            mouseGrabber = new MouseGrabber(this, viewmodel);
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
                data.SetData("Vm", viewmodel); //Model auf datalist setzen

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
    }
}
