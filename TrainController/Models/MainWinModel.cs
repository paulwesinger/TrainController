using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TrainController.Models
{
    public class MainWinModel : DependencyObject,INotifyPropertyChanged
    {
        public static readonly DependencyProperty ShowLayerProperty = DependencyProperty.Register(
            nameof(ShowLayer), typeof(bool), typeof(MainWinModel), new PropertyMetadata());


        /// <summary>
        /// DependecyProperties
        /// </summary>
        public static readonly DependencyProperty UserControlsModelProperty = DependencyProperty.Register("ControlModel",
            typeof(UserControlsModel), typeof(MainWinModel), new PropertyMetadata());

        public static readonly DependencyProperty ProjectModelProperty = DependencyProperty.Register("ProjectModel",
                        typeof(ProjectWinModel),typeof(MainWinModel), new PropertyMetadata());


        public UserControlsModel ControlsModel 
        {
            get { return (UserControlsModel)GetValue(UserControlsModelProperty); }
            set { SetValue(UserControlsModelProperty, value); } 
        }

        public ProjectWinModel ProjecModel
        {
            get { return (ProjectWinModel)GetValue(ProjectModelProperty); }
            set { SetValue(ProjectModelProperty, value); }
        }
        // -----------------------------------------------------------------------------------


        public int RasterSize { 
            get => _rasterSize;
            set
            {
                if (value < 4) // Minimum raster size is 16
                {
                    throw new ArgumentOutOfRangeException(nameof(RasterSize), "Raster size must be greater than 4.");
                }
                else
                {
                    _rasterSize = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RasterSize)));
                }
            } 
        }
        private int _rasterSize = 64;

        public bool ShowLayer
        {
            get => (bool)GetValue(ShowLayerProperty);
            set
            {
                SetValue(ShowLayerProperty, value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShowLayer)));
            }
        }
        private bool _showLayer = true;


        public bool NewProjectStarted
        {
            get => _newProjectStarted;
            set
            {
                if (_newProjectStarted == value) return;
                _newProjectStarted = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NewProjectStarted)));
            }
        }
        bool _newProjectStarted = false;

        public bool EnableControls
        {
            get => _EnableControls;
            set
            {
                if (_EnableControls == value) return;
                _EnableControls = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EnableControls)));

            }
        }
        private bool _EnableControls = false;

        public event PropertyChangedEventHandler? PropertyChanged;       

        public void DrawGrid()
        {
            // Logic to draw the grid based on RasterSize

        }


        public MainWinModel()
        {
            
        }


    }
}
