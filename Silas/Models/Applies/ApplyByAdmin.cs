using System.Text.Json.Serialization;

namespace Silas.Models.Applies
{
    public class ApplyByAdmin
    {

        [JsonPropertyName("student_id_user")]
        public long StudentIdUser { get; set; }

        [JsonPropertyName("student_nie")]
        public string StudentNie { get; set; }

        [JsonPropertyName("student_name")]
        public string StudentName { get; set; }

        [JsonPropertyName("student_surname")]
        public string StudentSurname { get; set; }

        [JsonPropertyName("student_gendre")]
        public string StudentGendre { get; set; }

        [JsonPropertyName("student_birthdate")]
        public DateTime StudentBirthdate { get; set; }

        [JsonPropertyName("student_phone")]
        
        public string StudentPhone { get; set; }

        [JsonPropertyName("student_emer_phone")]
        
        public string StudentEmerPhone { get; set; }

        [JsonPropertyName("student_nationality")]
        public string StudentNationality { get; set; }

        [JsonPropertyName("student_car")]
        public long StudentCar { get; set; }

        [JsonPropertyName("student_address")]
        public string StudentAddress { get; set; }

        [JsonPropertyName("student_year")]
        public long? StudentYear { get; set; }

        [JsonPropertyName("student_register_date")]
        public DateTime? StudentRegisterDate { get; set; }

        [JsonPropertyName("student_cv")]
        public long? StudentCv { get; set; }

        [JsonPropertyName("students_offers_id_offer")]
        public long StudentsOffersIdOffer { get; set; }

        [JsonPropertyName("students_offers_presentation")]
        public string StudentsOffersPresentation { get; set; }

        [JsonPropertyName("students_offers_status")]
        public long StudentsOffersStatus { get; set; }

        [JsonPropertyName("students_offers_date")]
        public DateTime StudentsOffersDate { get; set; }

        [JsonPropertyName("offer_id")]
        public long OfferId { get; set; }

        [JsonPropertyName("offer_title")]
        public string OfferTitle { get; set; }

        [JsonPropertyName("offer_description")]
        public string OfferDescription { get; set; }

        [JsonPropertyName("offer_id_course")]
        public long OfferIdCourse { get; set; }

        [JsonPropertyName("offer_date")]
        public DateTime OfferDate { get; set; }

        [JsonPropertyName("offer_location")]
        public string OfferLocation { get; set; }

        [JsonPropertyName("offer_id_company")]
        public long OfferIdCompany { get; set; }

        [JsonPropertyName("company_id_user")]
        public long CompanyIdUser { get; set; }

        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; }

        [JsonPropertyName("company_adress")]
        public string CompanyAdress { get; set; }

        [JsonPropertyName("company_telephone")]
        
        public string CompanyTelephone { get; set; }

        [JsonPropertyName("company_contact")]
        public string CompanyContact { get; set; }

        [JsonPropertyName("company_mobile")]
        
        public string CompanyMobile { get; set; }

        [JsonPropertyName("company_status")]
        public long CompanyStatus { get; set; }

    }
}
