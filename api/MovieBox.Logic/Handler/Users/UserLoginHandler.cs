using MediatR;
using Microsoft.IdentityModel.Tokens;
using MovieBox.Common.Exceptions;
using MovieBox.DAO.Users;
using MovieBox.Logic.Command.Users;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieBox.Logic.Handler.Users
{
    public class UserLoginHandler : IRequestHandler<UserLoginCommand, string>
    {
        private readonly IUsersDAO _usersDAO;

        public UserLoginHandler(IUsersDAO usersDAO)
        {
            _usersDAO = usersDAO;
        }

        public async Task<string> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _usersDAO.GetUserAsync(request.UserName);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            if (user.Password != request.Password)
            {
                throw new UserLoginInvalidException();
            }

            var key = Encoding.ASCII.GetBytes(request.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            foreach (var role in user.Roles)
            {
                descriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            var token = tokenHandler.CreateToken(descriptor);
            var accessToken = tokenHandler.WriteToken(token);

            return accessToken;
        }
    }
}