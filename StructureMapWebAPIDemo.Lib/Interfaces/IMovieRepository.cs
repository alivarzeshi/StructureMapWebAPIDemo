using StructureMapWebAPIDemo.Lib.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructureMapWebAPIDemo.Lib.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies();
    }
}
