using System.Collections.Generic;

namespace MovieBox.Common.Models
{
    public class UserModel
    {
        public IEnumerable<string> Roles { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }
    }
}