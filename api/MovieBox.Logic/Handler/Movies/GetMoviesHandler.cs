using MediatR;
using MovieBox.Common.Models;
using MovieBox.DAO.Movies;
using MovieBox.Logic.Query.Movies;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MovieBox.Logic.Handler.Movie
{
    public class GetMoviesHandler : IRequestHandler<GetMoviesQuery, IEnumerable<MovieModel>>
    {
        private readonly IMoviesDAO _moviesDAO;

        public GetMoviesHandler(IMoviesDAO moviesDAO)
        {
            _moviesDAO = moviesDAO;
        }

        public async Task<IEnumerable<MovieModel>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            return await _moviesDAO.GetAllMoviesAsync();
        }
    }
}