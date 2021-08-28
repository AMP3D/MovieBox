using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MovieBox.Controllers
{
    [ApiController]
    [Route("api/moviespurchase")]
    public class MoviesPurchaseController : ControllerBase
    {
        private readonly ILogger<MoviesPurchaseController> _logger;
        private readonly string _userName;

        public MoviesPurchaseController(IHttpContextAccessor httpContextAccessor, ILogger<MoviesPurchaseController> logger)
        {
            _logger = logger;
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
            // TODO: Pass username and id
            throw new NotImplementedException();
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
            // TODO: Pass username and id
            throw new NotImplementedException();
        }
    }
}