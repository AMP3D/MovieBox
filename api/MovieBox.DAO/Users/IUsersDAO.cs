using MovieBox.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieBox.DAO.Users
{
    public interface IUsersDAO
    {
        public Task<UserModel> AddUserAsync(UserModel userModel);

        public Task<UserModel> GetUserAsync(string userName);

        public Task<IEnumerable<UserModel>> GetUsersAsync();
    }
}