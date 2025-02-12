using System.Text.Json.Serialization;

namespace Silas.Models.Student
{
    public class Student
    {
        [JsonPropertyName("id_user")]
        public long IdUser { get; set; }

        [JsonPropertyName("nie")]
        public string Nie { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [JsonPropertyName("gendre")]
        public string Gendre { get; set; }

        [JsonPropertyName("birthdate")]
        public DateTime Birthdate { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("emer_phone")]
        public string EmerPhone { get; set; }

        [JsonPropertyName("nationality")]
        public string Nationality { get; set; }

        [JsonPropertyName("car")]
        public long Car { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("year")]
        public long? Year { get; set; }

        [JsonPropertyName("register_date")]
        public DateTime RegisterDate { get; set; }

        [JsonPropertyName("cv")]
        public long? Cv { get; set; }
    }
}
