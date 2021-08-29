using MovieBox.Common.Models;
using Newtonsoft.Json;

namespace MovieBox.Models
{
    public class MovieViewModel : MovieModel
    {
        [JsonProperty("id")]
        public override int? Id { get; set; }
    }
}