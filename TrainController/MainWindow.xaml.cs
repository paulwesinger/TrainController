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
using TrainController.Dialogs;
using TrainController.ProjectWindow;

namespace TrainController
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainVM modelMain = new MainVM();
        public ProjectWindow.ProjectWindow? projectWindow = null;
        public ProjectEditor? projectEditor = null;





        public MainWindow()
        {
            InitializeComponent();
            modelMain.PropertyChanged += ModelMain_PropertyChanged ;   
            this.DataContext = modelMain;
        }



        private void ModelMain_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(modelMain.EnableControls))
            {
                if (modelMain.NewProjectStarted)
                {
                    this.ItemRaster.IsEnabled = true;
                }
                else
                {
                    this.ItemRaster.IsEnabled = false;
                }               

                modelMain.DrawGrid();
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

            if (projectEditor != null)
            {
                Models.ProjectWinVM vm = projectEditor.DataContext as ProjectWinVM;

                projectEditor.DrawRaster(modelMain.ShowLayer);
            }
            


        }

        private void NewProject_Click(object sender, RoutedEventArgs e)
        {
            DlgNewProject dlgNewProject = new DlgNewProject();
            dlgNewProject.Owner = this;
            dlgNewProject.ShowDialog();

            if (dlgNewProject.DialogResult == true)
            {
                modelMain.NewProjectStarted = true;
                modelMain.EnableControls = true;                


                projectEditor = new ProjectEditor();
                projectEditor.DrawRaster(true);
                usercontrl.Content = projectEditor;
            }
            else
            {
                modelMain.EnableControls = false;
            }
        }
    }
}