using Dapper;
using Microsoft.Extensions.Options;
using MovieBox.Common.Exceptions;
using MovieBox.Common.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MovieBox.DAO.Movies
{
    public class MoviesDAO : BaseDAO, IMoviesDAO
    {
        public MoviesDAO(IOptions<ConnectionStrings> connectionStrings) : base(connectionStrings)
        { }

        public async Task<MovieModel> AddMovieAsync(MovieModel movieModel)
        {
            var movie = await UpsertMovie(movieModel);

            return movie;
        }

        public async Task<IEnumerable<MovieModel>> GetAllMoviesAsync()
        {
            var query = $"SELECT * FROM Movie";

            var result = await GetMoviesAsync(query);

            return result;
        }

        public async Task<MovieModel> GetMovieByIdAsync(int id)
        {
            var query = $"SELECT * FROM Movie WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);

            using var connection = CreateConnection();
            var result = await connection.QueryFirstOrDefaultAsync<MovieModel>(query, parameters);

            return result;
        }

        public async Task<IEnumerable<MovieModel>> GetMoviesByTitleAsync(string title)
        {
            var query = $"SELECT * FROM Movie WHERE Title = @Title";

            var parameters = new DynamicParameters();
            parameters.Add("Title", title, DbType.Int32);

            var result = await GetMoviesAsync(query, parameters);

            return result;
        }

        public async Task<MovieModel> UpdateMovieAsync(MovieModel movieModel)
        {
            var result = await UpsertMovie(movieModel, true);

            return result;
        }

        private async Task<IEnumerable<MovieModel>> GetMoviesAsync(string query, DynamicParameters parameters = null)
        {
            using var connection = CreateConnection();
            var result = await connection.QueryAsync<MovieModel>(query, parameters);

            return result;
        }

        private async Task<MovieModel> UpsertMovie(MovieModel movieModel, bool isUpdate = false)
        {
            var query = "SELECT 1 FROM Movie WHERE Title = @Title AND YearReleased = @YearReleased";

            var parameters = new DynamicParameters();
            parameters.Add("Title", movieModel.Title, DbType.String);
            parameters.Add("YearReleased", movieModel.YearReleased, DbType.Int32);

            using var connection = CreateConnection();
            var exists = await connection.QueryFirstOrDefaultAsync(query, parameters);
            if (exists && !isUpdate)
            {
                throw new MovieExistsException($"There is already a title called {movieModel.Title} released in the year {movieModel.YearReleased}");
            }

            var insertQuery = "INSERT INTO Movie (ImageUrl, IsAvailable, PurchasePrice, Rating, RentalPrice, Summary, Title, YearReleased) VALUES (@ImageUrl, @IsAvailable, @PurchasePrice, @Rating, @RentalPrice, @Summary, @Title, @YearReleased)";
            var updateQuery = "UPDATE Movie SET Id = @Id, ImageUrl = @ImageUrl, IsAvailable = @IsAvailable, PurchasePrice = @PurchasePrice, Rating = @Rating, RentalPrice = @RentalPrice, Summary = @Summary, Title = @Title, YearReleased = @YearReleased";

            query = isUpdate ? updateQuery : insertQuery;

            parameters.Add("Id", movieModel.Id, DbType.String);
            parameters.Add("ImageUrl", movieModel.ImageUrl, DbType.String);
            parameters.Add("IsAvailable", movieModel.IsAvailable, DbType.Boolean);
            parameters.Add("PurchasePrice", movieModel.PurchasePrice, DbType.Decimal);
            parameters.Add("Rating", movieModel.Rating, DbType.String);
            parameters.Add("RentalPrice", movieModel.RentalPrice, DbType.Decimal);
            parameters.Add("Summary", movieModel.Summary, DbType.String);

            await connection.ExecuteAsync(query, parameters);

            return movieModel;
        }
    }
}