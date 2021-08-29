using System;

namespace MovieBox.Common.Models
{
    public class UserMovieModel
    {
        public bool? CanReturn { get; set; }

        public DateTime? DateExpires { get; set; }

        public DateTime? DatePurchased { get; set; }

        public DateTime? DateStarted { get; set; }

        public int? Id { get; set; }

        public bool? IsRental { get; set; }

        public int? MovieId { get; set; }

        public int? UserId { get; set; }
    }
}