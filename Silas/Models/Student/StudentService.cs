using Silas.Models.Applies;
using Silas.Models.Offers;
using Silas.ViewModels;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Silas.Models.Student
{
    public class StudentService
    {
        private readonly HttpClient _HttpClient;

        public StudentService(HttpClient httpClient) {
            _HttpClient = httpClient;
        }

        public StudentService() { }


        //RECOGEMOS LOS APLIQUE POR ID DE ESTUDIANTE
        public async Task<AppliesResponseByStudents> ListAplliesByStudentId(int id)
        {
            try
            {
                var response = await _HttpClient.GetAsync($"http://volumidev.duckdns.org/silasapp/api/endpoint/getAppliesByUserId.php?id_user={id}");
                if (response.IsSuccessStatusCode)
                {
                    //AQUI ME ESTA DANDO UN PROBLEMA PARA PARSEAR EL JSON PORQUE ME ESTA DEVOLVIENDO UN OBJETO EN LUGAR UNA LISTA
                    var json = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<AppliesResponseByStudents>(json);
                    return data;
                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }


        //NOS TRAEMOS LAS OFERTAA PARA UN ALUMNO
        public async Task<OffersResponseToStudentProfile> GetOffersToStudent(int id)
        {
            try
            {
                var response = await _HttpClient.GetAsync($"http://volumidev.duckdns.org/silasapp/api/endpoint/getOffersByIdUserUserCourse.php?id_user={id}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<OffersResponseToStudentProfile>(json);
                    return data;
                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var response = await _HttpClient.GetAsync($"http://volumidev.duckdns.org/silasapp/api/endpoint/getStudentById.php{id}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var student = JsonSerializer.Deserialize<Student>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return student;
        }


        public async Task<List<Student>> GetAllStudentsAsync()
        {
            try
            {
                //LISTSTUDENTS ES UN PHP QUE TODAVIA NO EXISTE
                var response = await _HttpClient.GetAsync("http://volumidev.duckdns.org/silasapp/api/endpoint/listStudents.php");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var students = JsonSerializer.Deserialize<List<Student>>(json);
                return students ?? new List<Student>();

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en GetAllStudentsAsync: {ex.Message}");
                return new List<Student>();
            }
        }

        public async Task<bool> AddStudentApply(StudentOfferAplicationViewModel req)
        {
            var json = JsonSerializer.Serialize(req);
            Console.WriteLine(json);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _HttpClient.PostAsync("http://volumidev.duckdns.org/silasapp/api/endpoint/addStudenApply.php", content);
                response.EnsureSuccessStatusCode();
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;

            }
        }


        public async Task<AppliesResponseToStudentProfile> GetAppliesToStudentProfileAsync(int id)
        {
            try
            {
                var response = await _HttpClient.GetAsync($"http://volumidev.duckdns.org/silasapp/api/endpoint/getAppliesToStudentProfile.php?id_user={id}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<AppliesResponseToStudentProfile>(json);
                    return data;
                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                return null;

            }

        }

    }
}
