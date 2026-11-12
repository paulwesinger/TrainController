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
using System.Runtime.CompilerServices;

namespace TrainController
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static readonly DependencyProperty MainWindowViewModelProperty = 
            DependencyProperty.Register("MainWindowViewModel", typeof(MainWinModel), typeof(MainWindow), new PropertyMetadata(null));

        public  MainWinModel MainWindowViewModel
        {
            get { return (MainWinModel)GetValue(MainWindowViewModelProperty); }
            set { SetValue(MainWindowViewModelProperty, value);}
        }

        public MainWinModel ModelMain;

        public ProjectWindow.ProjectWindow? projectWindow = null;
        public ProjectEditor? projectEditor = null;

        public MainWindow()
        {
            InitializeComponent();           

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ModelMain = new MainWinModel();
            ModelMain.PropertyChanged += ModelMain_PropertyChanged;

            ModelMain.ControlsModel = new UserControlsModel();
            ModelMain.ProjecModel = new ProjectWinModel();

            this.DataContext = ModelMain;
        }



        private void ModelMain_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ModelMain.EnableControls))
            {
                if (ModelMain.NewProjectStarted)
                {
                    this.ItemRaster.IsEnabled = true;
                }
                else
                {
                    this.ItemRaster.IsEnabled = false;
                }               

                ModelMain.DrawGrid();
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
            ModelMain.ShowLayer = this.ItemRaster.IsChecked ;

            if (projectEditor != null)
            {
                Models.ProjectWinModel vm = projectEditor.DataContext as ProjectWinModel;

                projectEditor.DrawRaster(ModelMain.ShowLayer);
            }
            


        }

        private void NewProject_Click(object sender, RoutedEventArgs e)
        {
            DlgNewProject dlgNewProject = new DlgNewProject();
            dlgNewProject.Owner = this;
            dlgNewProject.ShowDialog();

            if (dlgNewProject.DialogResult == true)
            {
                ModelMain.NewProjectStarted = true;
                ModelMain.EnableControls = true;                


                projectEditor = new ProjectEditor(ModelMain);
                projectEditor.DrawRaster(true);
                usercontrl.Content = projectEditor;
            }
            else
            {
                ModelMain.EnableControls = false;
            }
        }


    }
}