using MediatR;

namespace MovieBox.Logic.Command.Movies
{
    public record PlayMovieCommand(int Id, string UserName) : IRequest<int>;
}