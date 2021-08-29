using MediatR;
using MovieBox.Common.Models;
using System.Collections.Generic;

namespace MovieBox.Logic.Query.Users
{
    public record GetUsersQuery() : IRequest<IEnumerable<UserModel>>;

    public record GetUserByUserNameQuery(string UserName) : IRequest<UserModel>;
}