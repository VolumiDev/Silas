using Silas.Models.Applies;
using System.Net.Http;
using System.Text.Json;

namespace Silas.Models.Admin
{
    public class AdminService
    {
        private readonly HttpClient _httpClient;

        public AdminService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public AdminService() { }

        //RECOGEMOS TODOS LOS APLIQUE DE LOS ESTUDIANTES PARA DARSELOS AL ADMIN
        public async Task<AppliesResponseByAdmin> GetAppliesToAdmin()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://volumidev.duckdns.org/silasapp/api/endpoint/getAppliesToAdmin.php");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<AppliesResponseByAdmin>(json);
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
