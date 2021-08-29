using System;

namespace MovieBox.Common.Models
{
    public class PaymentModel
    {
        public DateTime? CardExpirationDate { get; set; }

        public double? CardNumber { get; set; }

        public int? Id { get; set; }

        public bool? IsDefault { get; set; }

        public bool? IsValid { get; set; }

        public int? SecurityCode { get; set; }
    }
}