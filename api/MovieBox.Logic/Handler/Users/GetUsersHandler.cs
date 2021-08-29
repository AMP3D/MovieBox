using MediatR;
using MovieBox.Common.Models;
using MovieBox.DAO.Users;
using MovieBox.Logic.Query.Users;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MovieBox.Logic.Handler.Users
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserModel>>
    {
        private readonly IUsersDAO _usersDAO;

        public GetUsersHandler(IUsersDAO usersDAO)
        {
            _usersDAO = usersDAO;
        }

        public async Task<IEnumerable<UserModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _usersDAO.GetUsersAsync();
        }
    }
}