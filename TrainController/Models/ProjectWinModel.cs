using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace TrainController.Models
{
    public class ProjectWinModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public double Spacing { get; set; } = 20.0;

        public bool ShowRaster
        {
            get => _showRaster;
            set
            {
                if (_showRaster == value) return;
                _showRaster = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShowRaster)));
            }
        }   
        private bool _showRaster = true;

        public bool EditMode
        {
            get => _editMode;
            set
            {
                if (value == _editMode) return;
                _editMode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EditMode)));
            }
        }
        private bool _editMode = false;

        public DrawingBrush CreateDotGridBrush(double spacing, double dotRadius, Brush dotBrush)
        {
            Spacing = spacing;
            EllipseGeometry dotGeometry = new EllipseGeometry(new Point(spacing / 2, spacing / 2), dotRadius, dotRadius);

            GeometryDrawing geometryDrawing = new GeometryDrawing(dotBrush, null, dotGeometry);

            GeometryDrawing backgroundDrawing = new GeometryDrawing(Brushes.Transparent, null, new RectangleGeometry(new Rect(0, 0, spacing, spacing)));

            DrawingGroup drawingGroup = new DrawingGroup();
            drawingGroup.Children.Add(backgroundDrawing);
            drawingGroup.Children.Add(geometryDrawing);

            DrawingBrush brush = new DrawingBrush(drawingGroup)
            {
                TileMode = TileMode.Tile,
                Viewport = new Rect(0, 0, spacing, spacing),
                ViewportUnits = BrushMappingMode.Absolute
            };

            return brush;
        }

        public ProjectWinModel()
        {

        }

    }
}
