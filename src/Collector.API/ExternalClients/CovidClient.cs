using Collector.Domain.ViewModels;
using Collector.Mappers.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Collector.API.ExternalClients
{
    public class CovidClient
    {
        private readonly HttpClient _httpClient;

        public CovidClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.covid19api.com/");
        }

        public async Task<IEnumerable<CovidHistoryCreateViewModel>> GetUAECovidHistoryAsync() =>
            await _httpClient.GetFromJsonAsync<IEnumerable<CovidHistoryCreateViewModel>>(
                "total/country/united-arab-emirates");


        public async Task<GlobalCovidSummaryViewModel> GetCovidSummaryAsync() =>
            await _httpClient.GetFromJsonAsync<GlobalCovidSummaryViewModel>(
                "summary");
    }
}
