using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainController.Models
{
    public class ModelMain : INotifyPropertyChanged
    {
        public int RasterSize { 
            get => _rasterSize;
            set
            {
                if (value < 16) // Minimum raster size is 16
                {
                    throw new ArgumentOutOfRangeException(nameof(RasterSize), "Raster size must be greater than 0.");
                }
                else
                {
                    _rasterSize = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RasterSize)));
                }
            } 
        }
        private int _rasterSize = 64;


        public event PropertyChangedEventHandler? PropertyChanged;

        public void DrawGrid()
        {
            // Logic to draw the grid based on RasterSize

        }

        public ModelMain()
        {
            // Constructor logic here
        }


    }
}
