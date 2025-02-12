using System.Text.Json.Serialization;

namespace Silas.Models.Offers
{
    public class OffersToStudentProfile
    {
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonPropertyName("offers_id")]
        public int OffersId { get; set; }

        [JsonPropertyName("offers_title")]
        public string OffersTitle { get; set; }

        [JsonPropertyName("offers_description")]
        public string OffersDescription { get; set; }

        [JsonPropertyName("offers_id_course")]
        public int OffersIdCourse { get; set; }

        [JsonPropertyName("offers_date")]
        public DateTime OffersDate { get; set; }

        [JsonPropertyName("offers_location")]
        public string OffersLocation { get; set; }

        [JsonPropertyName("offers_id_company")]
        public int OffersIdCompany { get; set; }

        [JsonPropertyName("companies_name")]
        public string CompaniesName { get; set; }

        [JsonPropertyName("companies_adress")]
        public string CompaniesAdress { get; set; }

        [JsonPropertyName("companies_telephone")]
        public string CompaniesTelephone { get; set; }

        [JsonPropertyName("companies_contact")]
        public string CompaniesContact { get; set; }

        [JsonPropertyName("companies_mobile")]
        public string CompaniesMobile { get; set; }

        [JsonPropertyName("companies_status")]
        public int CompaniesStatus { get; set; }
    }
}
