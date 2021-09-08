using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieBox.Logic.Command.Movies;

namespace MovieBox.Controllers
{
    [ApiController]
    [Route("api/moviesondemand")]
    public class MoviesOnDemandController : ControllerBase
    {
        private readonly ILogger<MoviesOnDemandController> _logger;
        private readonly IMediator _mediator;
        private readonly string _userName;

        public MoviesOnDemandController(IHttpContextAccessor httpContextAccessor, ILogger<MoviesOnDemandController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
            _userName = httpContextAccessor.HttpContext.User.Identity.Name;
        }

        /// <summary>
        /// Play movie On-Demand
        /// </summary>
        /// <param name="id">Movie ID</param>
        /// <returns>OK if movie can be played</returns>
        [HttpPost]
        [Route("play/movie/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PlayMovieAsync(int id)
        {
            await _mediator.Send(new PlayMovieCommand(id, _userName));

            return Ok(id);
        }
    }
}