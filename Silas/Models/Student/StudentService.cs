using Silas.Models.Applies;
using Silas.Models.Offers;
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
        public async Task<OffersResponseToStudentProfile> GetOffersToStodent(int id)
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
            var response = await _HttpClient.GetAsync($"http://localhost/endpoint/getStudentByUserID.php?id_student={id}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            Console.WriteLine("JSON recibido: " + json);
            var student = JsonSerializer.Deserialize<Student>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return student;
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            var json = JsonSerializer.Serialize(student);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            // Suponiendo que el endpoint para actualizar es updateStudent.php
            var response = await _HttpClient.PostAsync("http://localhost/endpoint/updateStudentProfile.php", content);
            return response.IsSuccessStatusCode;
        }



        /*public async Task<Student> GetStudentByIdAsync(int id)
        {
            var response = await _HttpClient.GetAsync($"http://volumidev.duckdns.org/silasapp/api/endpoint/getStudentDetails.php?id_student={id}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var student = JsonSerializer.Deserialize<Student>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return student;
        }*/ //Juanan: no he encontrado en ningun lado el php de esto, al igual que la carpeta Student abajo. Supongo que se creo para el admin o algo.

    }
}
