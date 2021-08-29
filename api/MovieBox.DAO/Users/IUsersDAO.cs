using MovieBox.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieBox.DAO.Users
{
    public interface IUsersDAO
    {
        public Task<UserModel> AddUser(UserModel userModel);

        public Task<UserModel> GetUser(string userName);

        public Task<IEnumerable<UserModel>> GetUsers();
    }
}