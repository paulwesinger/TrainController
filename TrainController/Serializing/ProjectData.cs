using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TrainController.Serializing
{
    /// <summary>
    /// Klasse zum serialisieren des Projekts im json format
    /// </summary>   
    
    class ProjectData
    {
        ProjectData() 
        {
            ProjectName = string.Empty;
            LayoutPattern = 0;
        }

        public string ProjectName { get; set;}
        /// <summary>
        /// LAyoutPAttern: enum für den Look → DarkPattern, BluePattern,...usw
        /// </summary>
        public int LayoutPattern { get; set; }

        //public IEnumerable
        // weiters folgt noch
        }
}
