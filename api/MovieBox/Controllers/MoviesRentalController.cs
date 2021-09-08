using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieBox.Logic.Command.Movies;

namespace MovieBox.Controllers
{
    [ApiController]
    [Route("api/moviesrental")]
    public class MoviesRentalController : ControllerBase
    {
        private readonly ILogger<MoviesRentalController> _logger;
        private readonly IMediator _mediator;
        private readonly string _userName;

        public MoviesRentalController(IHttpContextAccessor httpContextAccessor, ILogger<MoviesRentalController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
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
            await _mediator.Send(new RentMovieCommand(id, _userName));

            return Ok(id);
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
            await _mediator.Send(new ReturnMovieRentalCommand(id, _userName));

            return NoContent();
        }
    }
}