using MediatR;
using MovieBox.Common.Models;

namespace MovieBox.Logic.Command.Movies
{
    public record AddMovieCommand(MovieModel Model) : IRequest<MovieModel>;
}