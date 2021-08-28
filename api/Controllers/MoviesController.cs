using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MovieBox.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(ILogger<MoviesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetMoviesAsync()
        {
            _logger.LogInformation("Getting all movies...");

            var result = await Task.FromResult(new List<dynamic>() 
            { 
                new { Foo = "bar" } 
            });

            return Ok(result);
        }
    }
}
