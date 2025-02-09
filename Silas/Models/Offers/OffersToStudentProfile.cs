using System.Text.Json.Serialization;

namespace Silas.Models.Offers
{
    public class OffersToStudentProfile
    {
        [JsonPropertyName("offers_id")]
        public long OffersId { get; set; }

        [JsonPropertyName("offers_title")]
        public string OffersTitle { get; set; }

        [JsonPropertyName("offers_description")]
        public string OffersDescription { get; set; }

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

        [JsonPropertyName("students_courses_id_course")]
        public long StudentsCoursesIdCourse { get; set; }

        [JsonPropertyName("students_courses_id_student")]
        public long StudentsCoursesIdStudent { get; set; }

        [JsonPropertyName("companies_id_user")]
        public long CompaniesIdUser { get; set; }

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
        public long CompaniesStatus { get; set; }
    }
}
