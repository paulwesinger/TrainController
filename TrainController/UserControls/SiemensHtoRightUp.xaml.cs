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

namespace TrainController.UserControls
{
    /// <summary>
    /// Interaktionslogik für SiemensHtoRightUp.xaml
    /// </summary>
    public partial class SiemensHtoRightUp : UserControl
    {
        public SiemensHtoRightUp()
        {
            InitializeComponent();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //if (isediting) return;

                DataObject data = new DataObject();
                data.SetData(DataFormats.StringFormat, SiemensHtoRightup);
                data.SetData("Width", SiemensHtoRightup.Width);
                data.SetData("Object", this); // Setzen Sie das UserControl selbst als Datenobjekt
                                              //   data.SetData("Vm", model); //Model auf datalist setzen

                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
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
