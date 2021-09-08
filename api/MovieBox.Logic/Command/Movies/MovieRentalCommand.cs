using MediatR;

namespace MovieBox.Logic.Command.Movies
{
    public record RentMovieCommand(int Id, string UserName) : IRequest<int>;

    public record ReturnMovieRentalCommand(int Id, string UserName) : IRequest<int>;
}