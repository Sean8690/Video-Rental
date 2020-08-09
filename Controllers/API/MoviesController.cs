using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoRental.Models;
using AutoMapper;
using VideoRental.Dtos;
using System.Data.Entity;

namespace VideoRental.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetMovies(string query = null)
        {
            var movieQuery = _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.NumberAvailable > 0);

            if (!string.IsNullOrWhiteSpace(query))
            {
                movieQuery = movieQuery.Where(m => m.Name.Contains(query));
            }

            var movieDto = movieQuery
                .ToList()
                .Select(Mapper.Map<Movies, MovieDto>);

            return Ok(movieDto);
        }


        //Get/api/movies/id
        public IHttpActionResult GetMovies(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movies, MovieDto>(movie));
        }

        //Post/api/movie
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageAllMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        { 
            if(!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, "Couldn't add new movie");
            }

            var movie = Mapper.Map<MovieDto, Movies>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //Post/api/movie
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageAllMovies)]
        public IHttpActionResult UpadteMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var movieInDB = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDB == null)
            {
                return NotFound();
            }

            Mapper.Map(movieDto, movieInDB);

            _context.SaveChanges();

            return Ok();
        }

        //Get/api/movies/id
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageAllMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDB = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDB == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movieInDB);
            _context.SaveChanges();

            return Ok();
        }
    }
}
