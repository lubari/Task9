using CatalogTests.Models.Requests;
using CatalogTests.Models.Responses;
using CatalogTests.Models.Responses.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogTests.Clients
{
    public class WalletServiceClient
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly string _baseUrl = "https://catalogservice-uat.azurewebsites.net";

        public async Task<CommonResponse<object>> Charge(CreateChargeRequest request)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{_baseUrl}/Balance/Charge"),
                Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = await _client.SendAsync(httpRequestMessage);

            return await response.ToCommonResponse<object>();
        }

        public async Task<CommonResponse<GetBalanceInfoResponse>> GetBalance(string userId)
        {
            var getProductInfoRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_baseUrl}/Balance/GetBalance?userId={userId}")
            };

            HttpResponseMessage response = await _client.SendAsync(getProductInfoRequest);

            return await response.ToCommonResponse<GetBalanceInfoResponse>();
        }
    }
}
