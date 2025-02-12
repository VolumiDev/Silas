using System.Text.Json.Serialization;

namespace Silas.ViewModels
{
    public class StudentOfferAplicationViewModel
    {
        //[JsonPropertyName("id_user")]
        public int Id { get; set; }
        //[JsonPropertyName("id_offer")]
        public int IdOffer { get; set; }
        //[JsonPropertyName("presentation")]
        public string Presentation { get; set; }
    }
}
