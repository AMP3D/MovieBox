using Dapper;
using Microsoft.Extensions.Options;
using MovieBox.Common.Exceptions;
using MovieBox.Common.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MovieBox.DAO.Users
{
    public class UsersDAO : BaseDAO, IUsersDAO
    {
        public UsersDAO(IOptions<ConnectionStrings> connectionStrings) : base(connectionStrings)
        {
        }

        public async Task<UserModel> AddUserAsync(UserModel userModel)
        {
            var query = "SELECT 1 FROM User WHERE UserName = @UserName";

            var parameters = new DynamicParameters();
            parameters.Add("UserName", userModel.UserName, DbType.String);

            using var connection = CreateConnection();
            var exists = await connection.QueryFirstOrDefaultAsync(query, parameters);
            if (exists)
            {
                throw new UserExistsException($"There is already a user with user name {userModel.UserName}.");
            }

            query = "INSERT INTO User (UserName, Password) VALUES (@UserName, @Password)";
            parameters.Add("Password", userModel.Password, DbType.String);

            // Ordinarily we'd call a sproc here which would insert into UserRole and UserPayment tables

            await connection.ExecuteAsync(query, parameters);

            return userModel;
        }

        public async Task<UserModel> GetUserAsync(string userName)
        {
            var query = $"SELECT * FROM User WHERE UserName = @UserName";

            var parameters = new DynamicParameters();
            parameters.Add("UserName", userName, DbType.String);

            using var connection = CreateConnection();
            var result = await connection.QueryFirstOrDefaultAsync<UserModel>(query, parameters);

            // Mocking this to save time. In the real world I would have a UserRole table to query from
            result.Roles = new List<string>() { "Admin" };

            return result;
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            var query = $"SELECT * FROM User";

            using var connection = CreateConnection();
            var result = await connection.QueryAsync<UserModel>(query);

            foreach (var user in result)
            {
                // Mocking this to save time. In the real world I would have a UserRole table to query from
                user.Roles = new List<string>() { "Admin" };
            }

            return result;
        }
    }
}