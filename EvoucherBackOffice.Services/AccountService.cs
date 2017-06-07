using EvoucherBackOffice.Services.DTObjects.Account;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace EvoucherBackOffice.Services
{
    public class AccountService : IAccountService
    {
        private readonly string _baseUrl;
        private readonly HttpClient _httpClient;
        private readonly string _authString;
        public AccountService(string baseUrl)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl.TrimEnd('/');
            _authString = Properties.Settings.Default.AuthToken;
        }

        public async Task<string> Login(LoginDTO login)
        {
            var content = JsonConvert.SerializeObject(login);
            string uri = $"{_baseUrl}/ExpectingEndPoint/";
            var res = await _httpClient.PostAsync(uri, new StringContent(content, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            var textData = await res.Content.ReadAsStringAsync();
            if (res.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<string>(textData);
            }
            var errorMessage = ParseErrorResponse(textData);
            throw new Exception(errorMessage);
        }

        public async Task<bool> RequestPasswordReset(ForgotPasswordDTO forgotPassword)
        {
            var content = JsonConvert.SerializeObject(forgotPassword);
            string uri = $"{_baseUrl}/ExpectingEndPoint/";
            var res = await _httpClient.PostAsync(uri, new StringContent(content, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            var textData = await res.Content.ReadAsStringAsync();
            if (res.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<bool>(textData);
            }
            var errorMessage = ParseErrorResponse(textData);
            throw new Exception(errorMessage);
        }

        public async Task<bool> ResetPassword(ResetPasswordDTO resetPassword)
        {
            var content = JsonConvert.SerializeObject(resetPassword);
            string uri = $"{_baseUrl}/ExpectingEndPoint/";
            var res = await _httpClient.PostAsync(uri, new StringContent(content, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            var textData = await res.Content.ReadAsStringAsync();
            if (res.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<bool>(textData);
            }
            var errorMessage = ParseErrorResponse(textData);
            throw new Exception(errorMessage);
        }
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
