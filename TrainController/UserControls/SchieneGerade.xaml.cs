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
using TrainController.Models;

namespace TrainController.UserControls
{
    /// <summary>
    /// Interaktionslogik für SchieneGerade.xaml
    /// </summary>
    public partial class SchieneGerade : UserControl
    {
        private UserControlsVM usrctlmodel = new UserControlsVM();

        public UserControlsVM CtlModel 
        {
            get => usrctlmodel; 
            set => usrctlmodel = value;
        }



        public string CtlrName()
        {
            return this.Name;
        }
        public SchieneGerade()
        {   
            InitializeComponent();
           
        }

        public SchieneGerade(SchieneGerade c)
        {
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
                data.SetData("Vm", usrctlmodel); //Model auf datalist setzen

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
