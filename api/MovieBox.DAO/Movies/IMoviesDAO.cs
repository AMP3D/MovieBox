using MovieBox.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieBox.DAO.Movies
{
    public interface IMoviesDAO
    {
        public Task<MovieModel> AddMovieAsync(MovieModel movieModel);

        public Task<IEnumerable<MovieModel>> GetAllMoviesAsync();

        public Task<MovieModel> GetMovieByIdAsync(int id);

        public Task<IEnumerable<MovieModel>> GetMoviesByTitleAsync(string title);

        public Task<MovieModel> UpdateMovieAsync(MovieModel model);
    }
}