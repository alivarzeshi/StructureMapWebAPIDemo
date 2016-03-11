using StructureMapWebAPIDemo.Lib.DataModels;
using StructureMapWebAPIDemo.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructureMapWebAPIDemo.Lib.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        public List<Movie> GetAllMovies()
        {
            return new List<Movie>()
            {
                new Movie()
                {
                    ID = 1,
                    Title = "The Incredibles",
                    ReleaseDate = new DateTime(2004, 11, 5),
                    RunningTimeMinutes = 116,
                    Director = "Brad Bird"
                },
                new Movie()
                {
                    ID = 2,
                    Title = "Wreck-It Ralph",
                    ReleaseDate = new DateTime(2012, 11, 2),
                    RunningTimeMinutes = 120,
                    Director = "Rich Moore"
                },
                new Movie()
                {
                    ID = 3,
                    Title = "Inside Out",
                    ReleaseDate = new DateTime(2015, 6, 19),
                    RunningTimeMinutes = 102,
                    Director = "Pete Doctor & Ronnie Del Carmen"
                }
            };
        }

        public Movie GetByID(int id)
        {
            var allMovies = GetAllMovies();
            if (allMovies.Where(x => x.ID == id).Any())
            {
                return allMovies.First(x => x.ID == id);
            }
            else return null;
        }
    }
}
