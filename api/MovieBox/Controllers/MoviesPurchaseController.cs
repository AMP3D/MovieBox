using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieBox.Logic.Command.Movies;

namespace MovieBox.Controllers
{
    [ApiController]
    [Route("api/moviespurchase")]
    public class MoviesPurchaseController : ControllerBase
    {
        private readonly ILogger<MoviesPurchaseController> _logger;
        private readonly IMediator _mediator;
        private readonly string _userName;

        public MoviesPurchaseController(IHttpContextAccessor httpContextAccessor, ILogger<MoviesPurchaseController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
            _userName = httpContextAccessor.HttpContext.User.Identity.Name;
        }

        /// <summary>
        /// Purchase a movie by movie ID
        /// </summary>
        /// <param name="id">Movie ID</param>
        /// <returns>OK if movie is successfully purchased</returns>
        [HttpPost]
        [Route("movie/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PurchaseMovieAsync(int id)
        {
            await _mediator.Send(new PurchaseMovieCommand(id, _userName));

            return Ok(id);
        }

        /// <summary>
        /// Return a movie by movie ID
        /// </summary>
        /// <param name="id">Movie ID</param>
        /// <returns>No Content if movie return is successful</returns>
        [HttpDelete]
        [Route("movie/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ReturnMovieAsync(int id)
        {
            await _mediator.Send(new ReturnMoviePurchaseCommand(id, _userName));

            return NoContent();
        }
    }
}