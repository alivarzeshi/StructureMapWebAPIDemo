using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructureMapWebAPIDemo.Lib.DataModels
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int RunningTimeMinutes { get; set; }
        public string Director { get; set; }

    }
}
