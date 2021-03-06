﻿using EvoucherBackOffice.Services.DTObjects.Voucher;
using Newtonsoft.Json;
using System;
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
        public VoucherService(string baseUrl)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl.TrimEnd('/');
            _authString = Properties.Settings.Default.AuthToken;
        }

        public async Task<VoucherDetailDTO> GetVoucher(string token)
        {
            var uri = $"{_baseUrl}/vouchers/{token}";
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _authString);
            var content = await _httpClient.GetStringAsync(uri).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<VoucherDetailDTO>(content);
        }
        public async Task<VoucherDetailDTO> RedeemVoucher(string token)
        {
            string uri = $"{_baseUrl}/vouchers/{token}/redeem";
            var res = await _httpClient.PostAsync(uri, new StringContent("", Encoding.UTF8, "application/json")).ConfigureAwait(false);
            var textData = await res.Content.ReadAsStringAsync();
            if (res.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<VoucherDetailDTO>(textData);
            }
            var errorMessage = ParseErrorResponse(textData);
            throw new Exception(errorMessage);
        }

        public async Task<VoucherDetailDTO> CreateVoucher(CreateVoucherDTO createVoucher)
        {
            var content = JsonConvert.SerializeObject(createVoucher);
            string uri = $"{_baseUrl}/vouchers";
            var res = await _httpClient.PostAsync(uri, new StringContent(content, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            var textData = await res.Content.ReadAsStringAsync();
            if (res.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<VoucherDetailDTO>(textData);
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
