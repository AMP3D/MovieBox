using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MovieBox.Controllers
{
    [ApiController]
    [Route("api/moviesondemand")]
    public class MoviesOnDemandController : ControllerBase
    {
        private readonly ILogger<MoviesOnDemandController> _logger;
        private readonly string _userName;

        public MoviesOnDemandController(IHttpContextAccessor httpContextAccessor, ILogger<MoviesOnDemandController> logger)
        {
            _logger = logger;
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
            // TODO: Pass username and id
            throw new NotImplementedException();
        }
    }
}