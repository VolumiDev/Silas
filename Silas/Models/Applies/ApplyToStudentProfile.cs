using System.Text.Json.Serialization;

namespace Silas.Models.Applies
{
    public class ApplyToStudentProfile
    {
        [JsonPropertyName("offers_id")]
        public long OffersId { get; set; }

        [JsonPropertyName("offers_title")]
        public string OffersTitle { get; set; }

        [JsonPropertyName("offers_description")]
        public string OffersDescription { get; set; }

        [JsonPropertyName("companies_name")]
        public string CompaniesName { get; set; }

        [JsonPropertyName("offers_id_course")]
        public long OffersIdCourse { get; set; }

        [JsonPropertyName("offers_date")]
        public DateTime OffersDate { get; set; }

        [JsonPropertyName("offers_location")]
        public string OffersLocation { get; set; }

        [JsonPropertyName("offers_id_company")]
        public long OffersIdCompany { get; set; }

        [JsonPropertyName("students_offers_id_user")]
        public long StudentsOffersIdUser { get; set; }

        [JsonPropertyName("students_offers_id_offer")]
        public long StudentsOffersIdOffer { get; set; }

        [JsonPropertyName("students_offers_presentation")]
        public string StudentsOffersPresentation { get; set; }

        [JsonPropertyName("students_offers_status")]
        public long StudentsOffersStatus { get; set; }

        [JsonPropertyName("students_offers_date")]
        public DateTime StudentsOffersDate { get; set; }

        [JsonPropertyName("students_nie")]
        public string StudentsNie { get; set; }

        [JsonPropertyName("students_name")]
        public string StudentsName { get; set; }

        [JsonPropertyName("students_surname")]
        public string StudentsSurname { get; set; }

        [JsonPropertyName("students_gendre")]
        public string StudentsGendre { get; set; }

        [JsonPropertyName("students_birthdate")]
        public DateTime StudentsBirthdate { get; set; }

        [JsonPropertyName("students_phone")]
        public string StudentsPhone { get; set; }

        [JsonPropertyName("students_emer_phone")]
        public string StudentsEmerPhone { get; set; }

        [JsonPropertyName("students_nationality")]
        public string StudentsNationality { get; set; }

        [JsonPropertyName("students_car")]
        public long StudentsCar { get; set; }

        [JsonPropertyName("students_address")]
        public string StudentsAddress { get; set; }

        [JsonPropertyName("students_year")]
        public long StudentsYear { get; set; }

        [JsonPropertyName("students_register_date")]
        public DateTime StudentsRegisterDate { get; set; }

        [JsonPropertyName("students_cv")]
        public long StudentsCv { get; set; }
    }
}
