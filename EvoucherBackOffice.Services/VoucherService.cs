using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace EvoucherBackOffice.Services
{
    public class VoucherService : IVoucherService
    {
        private readonly string _baseUrl;
        private readonly HttpClient _httpClient;
        private readonly string _authString;
        //public VoucherService(string baseUrl)
        //{
        //    _httpClient = new HttpClient();
        //    _baseUrl = baseUrl.TrimEnd('/');
        //    _authString = Properties.Settings.Default.AuthToken;
        //}
        //public async Task<List<ExperienceDTO>> GetCategories()
        //{
        //    var uri = $"{_baseUrl}/products";
        //    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _authString);
        //    var content = await _httpClient.GetStringAsync(uri).ConfigureAwait(false);
        //    return JsonConvert.DeserializeObject<List<ExperienceDTO>>(content);
        //}
        //public async Task PostOrder(OrderDTO order)
        //{
        //    var content = JsonConvert.SerializeObject(order);
        //    string uri = $"{_baseUrl}/ExpectingEndPoint/";
        //    var res = await _httpClient.PostAsync(uri, new StringContent(content, Encoding.UTF8, "application/json")).ConfigureAwait(false);
        //    var textData = await res.Content.ReadAsStringAsync();
        //    if (!res.IsSuccessStatusCode)
        //    {
        //        var errorMessage = ParseErrorResponse(textData);
        //        throw new Exception(errorMessage);
        //    }
        //}
        private static string ParseErrorResponse(string response)
        {
            var error = JsonConvert.DeserializeObject<HttpError>(response);
            if (!String.IsNullOrEmpty(error.ExceptionMessage))
            {
                throw new Exception(error.ExceptionMessage + " " + error.StackTrace);
            }
            string errorMessage = "";
            foreach (var err in error)
            {
                errorMessage += err.Key + ": " + err.Value + "\n";
            }
            return errorMessage;
        }
    }
}
