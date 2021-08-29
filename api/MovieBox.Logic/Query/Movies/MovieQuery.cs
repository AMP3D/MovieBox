using MediatR;
using MovieBox.Common.Models;
using System.Collections.Generic;

namespace MovieBox.Logic.Query.Movies
{
    public record GetMoviesQuery() : IRequest<IEnumerable<MovieModel>>;

    public record GetMoviesByCategoryQuery(int CategoryId) : IRequest<IEnumerable<MovieModel>>;

    public record GetMoviesByGenreQuery(int GenreId) : IRequest<IEnumerable<MovieModel>>;

    public record GetMovieByIdQuery(int Id) : IRequest<IEnumerable<MovieModel>>;

    public record GetMovieByTitleQuery(string Title) : IRequest<IEnumerable<MovieModel>>;
}