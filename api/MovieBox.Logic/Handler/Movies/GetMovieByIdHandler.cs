using MediatR;
using MovieBox.Common.Models;
using MovieBox.DAO.Movies;
using MovieBox.Logic.Query.Movies;
using System.Threading;
using System.Threading.Tasks;

namespace MovieBox.Logic.Handler.Movie
{
    public class GetMovieByIdHandler : IRequestHandler<GetMovieByIdQuery, MovieModel>
    {
        private readonly IMoviesDAO _moviesDAO;

        public GetMovieByIdHandler(IMoviesDAO moviesDAO)
        {
            _moviesDAO = moviesDAO;
        }

        public async Task<MovieModel> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            return await _moviesDAO.GetMovieByIdAsync(request.Id);
        }
    }
}