using MediatR;

namespace MovieBox.Logic.Command.Users
{
    public record UserLoginCommand(string UserName, string Password, string Secret) : IRequest<string>;
}