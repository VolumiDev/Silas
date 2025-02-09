using System.Text.Json.Serialization;

namespace Silas.Models.Offers
{
    public class OffersResponseToStudentProfile
    {
        [JsonPropertyName("status")]
        public long Status { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("offers")]
        public List<OffersToStudentProfile> Offers { get; set; }
    }
}
