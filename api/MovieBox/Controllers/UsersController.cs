using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieBox.Common.Models;
using MovieBox.Logic.Command.Users;
using MovieBox.Models;

namespace MovieBox.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly AppSettingsModel _appSettings;
        private readonly ILogger<UsersController> _logger;
        private readonly IMediator _mediator;

        public UsersController(IOptions<AppSettingsModel> appSettings, ILogger<UsersController> logger, IMediator mediator)
        {
            _appSettings = appSettings.Value;
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginModel userLoginModel)
        {
            var accessToken = await _mediator.Send(new UserLoginCommand(userLoginModel.UserName, userLoginModel.Password, _appSettings.Secret));

            return Ok(accessToken);
        }
    }
}