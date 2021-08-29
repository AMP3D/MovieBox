using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using System;

namespace MovieBox.DAO
{
    public class BaseDAO
    {
        private readonly ConnectionStrings _connectionStrings;

        protected SqliteConnection CreateConnection() => new SqliteConnection(_connectionStrings.MoviesDB);

        public BaseDAO(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
        }
    }
}