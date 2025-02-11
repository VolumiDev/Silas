using System.Text.Json;

namespace Silas.Models.Courses
{
    public class CourseService
    {
        private readonly HttpClient _httpClient;

        public CourseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<Course>> GetCoursesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://volumidev.duckdns.org/silasapp/api/endpoint/getCoursesInfo.php");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var courses = JsonSerializer.Deserialize<List<Course>>(json);
                return courses ?? new List<Course>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<Course>();
            }
        }
    }
}
