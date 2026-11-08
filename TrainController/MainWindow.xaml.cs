using System.ComponentModel;
using System.Text;
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

namespace TrainController
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainVM modelMain = new MainVM();






        public MainWindow()
        {
            InitializeComponent();
            modelMain.PropertyChanged += ModelMain_PropertyChanged ;
            
        }



        private void ModelMain_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(modelMain.ShowLayer))
            {
                MessageBox.Show("Showlayer " + modelMain.ShowLayer.ToString());
            }
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ShowLayer_Click(object sender, RoutedEventArgs e)
        {  
            modelMain.ShowLayer = this.ItemRaster.IsChecked ;
        }
    }
}