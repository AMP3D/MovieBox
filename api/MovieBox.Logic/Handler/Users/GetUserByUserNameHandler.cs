using MediatR;
using MovieBox.Common.Models;
using MovieBox.DAO.Users;
using MovieBox.Logic.Query.Users;
using System.Threading;
using System.Threading.Tasks;

namespace MovieBox.Logic.Handler.Users
{
    public class GetUserByUserNameHandler : IRequestHandler<GetUserByUserNameQuery, UserModel>
    {
        private readonly IUsersDAO _usersDAO;

        public GetUserByUserNameHandler(IUsersDAO usersDAO)
        {
            _usersDAO = usersDAO;
        }

        public async Task<UserModel> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            return await _usersDAO.GetUserAsync(request.UserName);
        }
    }
}