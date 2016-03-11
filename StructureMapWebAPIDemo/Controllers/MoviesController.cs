using StructureMapWebAPIDemo.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetByID(int id)
        {
            var movie = _movieRepo.GetByID(id);
            if(movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }
    }
}
