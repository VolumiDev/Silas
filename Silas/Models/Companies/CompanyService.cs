using Silas.Models.Offers;
﻿using Silas.Models.Applies;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Silas.ViewModels;

namespace Silas.Models.Companies
{
    public class CompanyService
    {
        private readonly HttpClient _httpClient;

        public CompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //AÑADE UNA COMAÑIA A LA BBDD
        public async Task<bool> CreateCompanyAsync(Company company)
        {
            var json = JsonSerializer.Serialize(company);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("http://volumidev.duckdns.org/silasapp/api/endpoint/createCompanyDetails.php", content);
                response.EnsureSuccessStatusCode();
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }

        //RECOGE UNA COMAÑIA DE LA DE BBDD POR SU ID
        public async Task<Company> GetCompanyByIdAsync(int idUser)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://volumidev.duckdns.org/silasapp/api/endpoint/getCompanyById.php?id_user={idUser}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var company = JsonSerializer.Deserialize<Company>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return company;
                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }


        //ACTUALIZA LOS DATOS DE LA COPAÑIA EN LA BBDD
        public async Task<bool> UpdateCompanyAsync(Company company)
        {
            //COMO HEMOS SERIALIZADO PARA UN JSON EN "Company" DEBEMOS CONSTRUIR UN OBJETO CON LOS DATOS Q ESPERA AHORA EL PHP
            var jsonObj = new
            {
                id_user = company.IdUser,
                adress = company.Adress,
                telephone = company.Telephone,
                contact = company.Contact,
                mobile = company.Mobile,
                status = company.Status
            };

            var json = JsonSerializer.Serialize(jsonObj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("http://volumidev.duckdns.org/silasapp/api/endpoint/updateCompanyDetails.php", content);
                response.EnsureSuccessStatusCode();
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }



        //DESACTIVA UNA COMPAÑIA EN LA BBDD
        public async Task<bool> DeactivateCompanyAsync(int idUser)
        {
            var json = JsonSerializer.Serialize(new { id_user = idUser });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("http://volumidev.duckdns.org/silasapp/api/endpoint/desactivateCompany.php", content);
                response.EnsureSuccessStatusCode();
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }


        //RECOGE TODAS LAS COPAÑIAS DE LA BBDD
        public async Task<List<Company>> ListAllCompaniesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://volumidev.duckdns.org/silasapp/api/endpoint/listCompanies.php");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var companies = JsonSerializer.Deserialize<List<Company>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return companies ?? new List<Company>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error in ListAllCompaniesAsync: {ex.Message}");
                return new List<Company>();
            }
        }




        //RECOGE LOS APLIQUES UNA COMPAÑIA
        public async Task<List<ApplyByCompany>> ListAplliesByCompanyId(int id_company)
        {
            var response = await _httpClient.GetAsync($"http://volumidev.duckdns.org/silasapp/api/endpoint/getApliesByCompanyId.php?id_company={id_company}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<AppliesResponseByCompany>(json);
                var applies = data.Applies;
                return applies;
            }
            else
            {
                return [];

            }
        }

        //TODAS LAS COMPAÑIAS CON SUS OFERTAS
        public async Task<List<Company>> ListAllCompaniesWithOffersAsync()
        {
            try
            {

                var response = await _httpClient.GetAsync("http://volumidev.duckdns.org/silasapp/api/endpoint/getAllCompaniesWithOffers.php");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var companies = JsonSerializer.Deserialize<List<Company>>(json);
                Console.WriteLine($"Companies: {companies}");
                return companies ?? new List<Company>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en ListAllCompaniesWithOffersAsync: {ex.Message}");
                return new List<Company>();
            }
        }

        //TODAS LAS COMPAÑÍAS CON TODAS SUS OFERTAS CON TODOS SUS APLIQUES:
        public async Task<CompanyDetailsViewModel> GetCompanyDetailsAndOffersAndHisAppliesAsync(int id_company)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://volumidev.duckdns.org/silasapp/api/endpoint/getCompanyDetailsAndOffersAndHisApplies.php?id_company={id_company}");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                // Como la consulta PHP devuelve un conjunto de filas (con datos repetidos de la empresa, uno por cada oferta),
                // se deserializa en una lista de diccionarios (LE PASO LAS OPCIONES TAMBIÉN COMO SEGUNDO PARAMETRO AL DESERIALIZAR)
                var data = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (data == null || data.Count == 0)
                    return null;

                var firstRow = data[0];
                var company = new Company
                {
                    IdUser = Convert.ToInt32(firstRow["company_id"]),
                    Adress = firstRow["company_address"].ToString(),
                    Telephone = firstRow["company_telephone"].ToString(),
                    Contact = firstRow["company_contact"].ToString(),
                    Mobile = firstRow["company_mobile"].ToString(),
                    Status = Convert.ToInt32(firstRow["company_status"])
                };

                var offers = new List<Offer>();
                foreach (var row in data)
                {
                    if (row["offer_id"] == null || string.IsNullOrEmpty(row["offer_id"].ToString()))
                        continue;

                    var offer = new Offer
                    {
                        id = Convert.ToInt32(row["offer_id"]),
                        title = row["offer_title"].ToString(),
                        description = row["offer_description"].ToString(),
                        requiriments = row["offer_requiriments"].ToString(),
                        date = DateTime.Parse(row["offer_date"].ToString()),
                        location = row["offer_location"].ToString(),
                        id_company = Convert.ToInt32(row["company_id"]),
                        id_course = Convert.ToInt32(row["offer_course_id"]),
                        course_name = row.ContainsKey("course_name") ? row["course_name"].ToString() : "",
                        course_acronim = row.ContainsKey("course_acronim") ? row["course_acronim"].ToString() : ""
                    };
                    offers.Add(offer);
                }

                return new CompanyDetailsViewModel
                {
                    Company = company,
                    Offers = offers
                };
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en GetCompanyDetailsAndOffersAndHisAppliesAsync: {ex.Message}");
                return null;
            }
        }



    }
}
