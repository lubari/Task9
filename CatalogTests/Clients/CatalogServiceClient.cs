using CatalogTests.Models.Responses;
using CatalogTests.Models.Responses.Base;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogTests.Clients
{
    public class CatalogServiceClient
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly string _baseUrl = "https://catalogservice-uat.azurewebsites.net";

        public async Task<CommonResponse<object>> CreateProduct(CreateProductRequest request)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{_baseUrl}/Catalog/CreateProduct"),
                Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = await _client.SendAsync(httpRequestMessage);

            return await response.ToCommonResponse<object>();
        }

        public async Task<CommonResponse<GetProductInfoResponse>> GetProductInfo(string article)
        {
            var getProductInfoRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_baseUrl}/Catalog/GetProductInfo?article={article}")
            };

            HttpResponseMessage response = await _client.SendAsync(getProductInfoRequest);

            return await response.ToCommonResponse<GetProductInfoResponse>();
        }
    }
}
