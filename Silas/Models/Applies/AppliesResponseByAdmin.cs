
using System.Text.Json.Serialization;

namespace Silas.Models.Applies
{
   
    public class AppliesResponseByAdmin
    {
        [JsonPropertyName("status")]
        public long Status { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("applies")]
        public List<ApplyByAdmin> Applies { get; set; }
    }
}
