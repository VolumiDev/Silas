using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Silas.Models.Offers
{
    public class OfferService
    {
        private readonly HttpClient _httpClient;

        public OfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Offer>> GetOffersByCompanyIdAsync(int companyId)
        {
            try
            {
                var company = companyId;

                var response = await _httpClient.GetAsync($"http://volumidev.duckdns.org/silasapp/api/endpoint/listOffersByCompanyId.php?id_company={companyId}");

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var jsonOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                var offers = JsonSerializer.Deserialize<List<Offer>>(json, jsonOptions);
                return offers ?? new List<Offer>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<Offer>();
            }
        }

        public async Task<List<Offer>> GetCustomOffersForThisStudentAsync(int userId)
        {
            try
            {
                //LAS 5 ÚLTIMAS
                var response = await _httpClient.GetAsync($"http://volumidev.duckdns.org/silasapp/api/endpoint/list5LatestOffers.php?id_student={userId}");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var offers = JsonSerializer.Deserialize<List<Offer>>(json);
                return offers ?? new List<Offer>();
            }

            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<Offer>();
            }
        }

        //PARA ADMIN
        public async Task<List<Offer>> GetLatestOffersForAdminAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://volumidev.duckdns.org/silasapp/api/endpoint/list10LatestOffers.php");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var offers = JsonSerializer.Deserialize<List<Offer>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return offers ?? new List<Offer>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<Offer>();
            }
        }
        //DETALLES DE UNA OFERTA EN CONCRETO, LA VISTA -> OfferDetails.cshtml
        public async Task<Offer> GetOfferDetailsAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://volumidev.duckdns.org/silasapp/api/endpoint/getOfferDetails.php?id={id}");
                response.EnsureSuccessStatusCode();


                var json = await response.Content.ReadAsStringAsync();
                var offer = JsonSerializer.Deserialize<Offer>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return offer;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> CreateOfferAsync(OfferInsert offer)


        {
            var json = JsonSerializer.Serialize(offer);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            try
            {
                var response = await _httpClient.PostAsync("http://volumidev.duckdns.org/silasapp/api/endpoint/createNewOffer.php", content);
                response.EnsureSuccessStatusCode();
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }


    }

}

