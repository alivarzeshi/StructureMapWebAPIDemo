using StructureMapWebAPIDemo.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StructureMapWebAPIDemo.Controllers
{
    [RoutePrefix("movies")]
    public class MoviesController : ApiController
    {
        private IMovieRepository _movieRepo;

        public MoviesController(IMovieRepository movieRepo)
        {
            _movieRepo = movieRepo;
        }

        [HttpGet]
        [Route("all")]
        public IHttpActionResult All()
        {
            return Ok(_movieRepo.GetAllMovies());
        }
    }
}
