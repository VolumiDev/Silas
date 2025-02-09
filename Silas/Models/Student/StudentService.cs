using Silas.Models.Applies;
using Silas.Models.Offers;
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

    }
}
