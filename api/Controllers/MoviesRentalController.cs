using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MovieBox.Controllers
{
    [ApiController]
    [Route("api/moviesrental")]
    public class MoviesRentalController : ControllerBase
    {
        private readonly ILogger<MoviesRentalController> _logger;
        private readonly string _userName;

        public MoviesRentalController(IHttpContextAccessor httpContextAccessor, ILogger<MoviesRentalController> logger)
        {
            _logger = logger;
            _userName = httpContextAccessor.HttpContext.User.Identity.Name;
        }

        /// <summary>
        /// Rent a movie by movie ID
        /// </summary>
        /// <param name="id">Movie ID</param>
        /// <returns>OK if movie is successfully rented</returns>
        [HttpPost]
        [Route("movie/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RentMovieAsync(int id)
        {
            // TODO: Pass username and id
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return a movie rental by movie ID
        /// </summary>
        /// <param name="id">Movie ID</param>
        /// <returns>No Content if movie return is successful</returns>
        [HttpDelete]
        [Route("movie/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ReturnMovieAsync(int id)
        {
            // TODO: Pass username and id
            throw new NotImplementedException();
        }
    }
}