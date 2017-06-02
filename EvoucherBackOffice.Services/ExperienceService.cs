using EvoucherBackOffice.Services.DTObjects.Voucher;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EvoucherBackOffice.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly string _baseUrl;
        private readonly HttpClient _httpClient;
        private readonly string _authString;
        public ExperienceService(string baseUrl)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl.TrimEnd('/');
            _authString = Properties.Settings.Default.AuthToken;
        }

        public async Task<List<ExperienceDTO>> GetExperiences()
        {
            var uri = $"{_baseUrl}/products";
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _authString);
            var content = await _httpClient.GetStringAsync(uri).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<ExperienceDTO>>(content);
        }
    }
}
