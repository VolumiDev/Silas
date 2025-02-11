using System.Text.Json.Serialization;

namespace Silas.Models
{
    public class Company
    {
        [JsonPropertyName("company_id")]
        public int IdUser { get; set; }

        [JsonPropertyName("company_name")]
        public string Name { get; set; }

        [JsonPropertyName("company_address")]
        public string Adress { get; set; }

        [JsonPropertyName("company_telephone")]
        public string Telephone { get; set; }

        [JsonPropertyName("company_contact")]
        public string Contact { get; set; }

        [JsonPropertyName("company_mobile")]
        public string Mobile { get; set; }

        [JsonPropertyName("company_status")]
        public int Status { get; set; }
    }
}
