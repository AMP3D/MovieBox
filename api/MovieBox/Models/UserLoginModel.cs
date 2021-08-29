using Newtonsoft.Json;

namespace MovieBox.Models
{
    public class UserLoginModel
    {
        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }
    }
}