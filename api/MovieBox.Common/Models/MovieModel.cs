using Newtonsoft.Json;

namespace MovieBox.Common.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class MovieModel
    {
        [JsonProperty("categoryId")]
        public int? CategoryId { get; set; }

        [JsonProperty("genreId")]
        public int? GenreId { get; set; }

        public virtual int? Id { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("isAvailable")]
        public bool? IsAvailable { get; set; }

        [JsonProperty("purchasePrice")]
        public decimal? PurchasePrice { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("rentalPrice")]
        public decimal? RentalPrice { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("yearReleased")]
        public int? YearReleased { get; set; }
    }
}