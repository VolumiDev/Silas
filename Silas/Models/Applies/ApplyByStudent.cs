using System.Text.Json.Serialization;

namespace Silas.Models.Applies
{
    public class ApplyByStudent
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("id_course")]
        public long IdCourse { get; set; }

        [JsonPropertyName("offerdate")]
        public DateTimeOffset OfferDate { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("id_company")]
        public long IdCompany { get; set; }

        [JsonPropertyName("id_user")]
        public long IdUser { get; set; }

        [JsonPropertyName("id_offer")]
        public long IdOffer { get; set; }

        [JsonPropertyName("presentation")]
        public string Presentation { get; set; }

        [JsonPropertyName("status")]
        public long Status { get; set; }

        [JsonPropertyName("applydate")]
        public DateTimeOffset ApplyDate { get; set; }
    }
}
