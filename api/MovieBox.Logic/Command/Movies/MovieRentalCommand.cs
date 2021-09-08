using MediatR;

namespace MovieBox.Logic.Command.Movies
{
    public record RentMovieCommand(int Id, string UserName) : IRequest;

    public record ReturnMovieRentalCommand(int Id, string UserName) : IRequest;
}