using MediatR;
using MovieBox.Common.Models;
using MovieBox.DAO.Movies;
using MovieBox.Logic.Query.Movies;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MovieBox.Logic.Handler.Movie
{
    public class GetMoviesByTitleHandler : IRequestHandler<GetMoviesByTitleQuery, IEnumerable<MovieModel>>
    {
        private readonly IMoviesDAO _moviesDAO;

        public GetMoviesByTitleHandler(IMoviesDAO moviesDAO)
        {
            _moviesDAO = moviesDAO;
        }

        public async Task<IEnumerable<MovieModel>> Handle(GetMoviesByTitleQuery request, CancellationToken cancellationToken)
        {
            return await _moviesDAO.GetMoviesByTitleAsync(request.Title);
        }
    }
}