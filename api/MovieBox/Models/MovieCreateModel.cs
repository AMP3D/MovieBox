using MovieBox.Common.Models;
using System.Text.Json.Serialization;

namespace MovieBox.Models
{
    public class MovieCreateModel : MovieModel
    {
        [JsonIgnore]
        public override int? Id { get; set; }
    }
}