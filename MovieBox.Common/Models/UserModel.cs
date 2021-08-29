using System.Collections.Generic;

namespace MovieBox.Common.Models
{
    public class UserModel
    {
        public IEnumerable<UserMovieModel> MoviesLibrary { get; set; } = new List<UserMovieModel>();

        public IEnumerable<string> Roles { get; set; } = new List<string>();

        public IEnumerable<PaymentModel> Payments { get; set; } = new List<PaymentModel>();

        public string Password { get; set; }

        public int? UserId { get; set; }

        public string UserName { get; set; }
    }
}