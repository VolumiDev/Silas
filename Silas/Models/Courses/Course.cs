using System.Text.Json.Serialization;

namespace Silas.Models.Courses
{
    public class Course
    {
        [JsonPropertyName("id")]  // ✅ Matches JSON field
        public int Id { get; set; }

        [JsonPropertyName("name")]  // ✅ Matches JSON field
        public string Name { get; set; }

        [JsonPropertyName("acronim")]  // ✅ Matches JSON field
        public string Acronim { get; set; }

    }
}
