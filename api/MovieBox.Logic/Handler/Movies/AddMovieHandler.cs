using MediatR;
using MovieBox.Common.Models;
using MovieBox.DAO.Movies;
using MovieBox.Logic.Command.Movies;
using System.Threading;
using System.Threading.Tasks;

namespace MovieBox.Logic.Handler.Movies
{
    public class AddMovieHandler : IRequestHandler<AddMovieCommand, MovieModel>
    {
        private readonly IMoviesDAO _moviesDAO;

        public AddMovieHandler(IMoviesDAO moviesDAO)
        {
            _moviesDAO = moviesDAO;
        }

        public async Task<MovieModel> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            return await _moviesDAO.AddMovieAsync(request.Model);
        }
    }
}