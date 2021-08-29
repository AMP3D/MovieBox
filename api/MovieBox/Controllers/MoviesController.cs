using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieBox.Common.Exceptions;
using MovieBox.Common.Models;
using MediatR;
using MovieBox.Logic.Query.Movies;

namespace MovieBox.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IMediator _mediator;

        public MoviesController(ILogger<MoviesController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Add a movie
        /// </summary>
        /// <param name="movieModel">Movie item to add</param>
        /// <returns>Created if movie is successfully added</returns>
        [HttpPost]
        [Route("movie")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddMovieAsync([FromBody] MovieModel movieModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieve a movie by its ID
        /// </summary>
        /// <param name="id">Movie ID</param>
        /// <returns>A movie</returns>
        [HttpGet]
        [Route("movie/{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(MovieModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMovieByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetMovieByIdQuery(id));

            return Ok(result);
        }

        /// <summary>
        /// Retrieve a movie by its title
        /// </summary>
        /// <param name="title">Movie title</param>
        /// <returns>A movie</returns>
        [HttpGet]
        [Route("movie/titles/{title}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(MovieModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMovieByTitleAsync(string title)
        {
            var result = await _mediator.Send(new GetMovieByTitleQuery(title));

            return Ok(result);
        }

        /// <summary>
        /// Get all movies
        /// </summary>
        /// <returns>List of all movies</returns>
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<MovieModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMoviesAsync()
        {
            var result = await _mediator.Send(new GetMoviesQuery());

            return Ok(result);
        }

        /// <summary>
        /// Retrieve a movie by category ID
        /// </summary>
        /// <param name="id">Movie category ID</param>
        /// <returns>A movie</returns>
        [HttpGet]
        [Route("category/{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(MovieModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMoviesByCategoryAsync(int id)
        {
            var result = await _mediator.Send(new GetMoviesByCategoryQuery(id));

            return Ok(result);
        }

        /// <summary>
        /// Retrieve a movie by genre ID
        /// </summary>
        /// <param name="id">Movie genre ID</param>
        /// <returns>A movie</returns>
        [HttpGet]
        [Route("genre/{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(MovieModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMoviesByGenreAsync(int id)
        {
            var result = await _mediator.Send(new GetMoviesByGenreQuery(id));

            return Ok(result);
        }

        /// <summary>
        /// Update data on a movie
        /// </summary>
        /// <param name="patchDoc">Data to update</param>
        /// <returns>No Content if movie is successfully updated</returns>
        [HttpPatch]
        [Route("")]
        [Authorize("Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateMovie([FromBody] JsonPatchDocument<MovieModel> patchDoc)
        {
            MovieModel movie = null;

            try
            {
                movie = await Task.FromResult(new MovieModel());

                patchDoc.ApplyTo(movie, ModelState);
            }
            catch (Exception ex)
            {
                if (ex is MovieNotFoundException)
                {
                    _logger.LogError(ex, ex.Message);

                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }
    }
}