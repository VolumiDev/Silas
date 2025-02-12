using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Silas.Models.Offers;
using Silas.ViewModels;

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
                var response = await _httpClient.GetAsync($"http://volumidev.duckdns.org/silasapp/api/endpoint/listOffersByCompanyId.php?id_company={companyId}");
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

        public async Task<List<Offer>> GetCustomOffersForThisStudentAsync(int userId)
        {
            try
            {
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

        public async Task<List<Offer>> GetLatestOffersForAdminAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://volumidev.duckdns.org/silasapp/api/endpoint/list10LatestOffers.php");
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

        public async Task<Offer> GetOfferDetailsAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://volumidev.duckdns.org/silasapp/api/endpoint/getOfferDetails.php?id={id}");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var offer = JsonSerializer.Deserialize<Offer>(json);
                return offer;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        //CREACION DE LA OFERTA NUEVA, UTILIZANDO EL ENDPOINT "createNewOffer.php"  
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

        public async Task<bool> UpdateOfferAsync(Offer offer)
        {
            try
            {
                var json = JsonSerializer.Serialize(offer);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("http://volumidev.duckdns.org/silasapp/api/endpoint/updateOffer.php", content);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteOfferAsync(int id)
        {
            try
            {
                var json = JsonSerializer.Serialize(new { id = id });
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("http://volumidev.duckdns.org/silasapp/api/endpoint/deleteOffer.php", content);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public async Task<List<OfferApplicationViewModel>> GetOfferApplicationsAsync(int offerId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://volumidev.duckdns.org/silasapp/api/endpoint/getOfferApplications.php?id_offer={offerId}");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var applications = JsonSerializer.Deserialize<List<OfferApplicationViewModel>>(json);
                return applications ?? new List<OfferApplicationViewModel>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<OfferApplicationViewModel>();
            }
        }
    }
}
