using MediatR;
using MovieBox.Common.Models;
using MovieBox.DAO.Movies;
using MovieBox.Logic.Command.Movies;
using MovieBox.Validation.Movies;
using System.Threading;
using System.Threading.Tasks;

namespace MovieBox.Logic.Handler.Movies
{
    public class AddMovieHandler : IRequestHandler<AddMovieCommand, MovieModel>
    {
        private readonly IMoviesDAO _moviesDAO;
        private readonly IMoviesValidator _moviesValidator;

        public AddMovieHandler(IMoviesDAO moviesDAO, IMoviesValidator moviesValidator)
        {
            _moviesDAO = moviesDAO;
            _moviesValidator = moviesValidator;
        }

        public async Task<MovieModel> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            await _moviesValidator.ValidateAndThrowAsync(request.Model);

            return await _moviesDAO.AddMovieAsync(request.Model);
        }
    }
}