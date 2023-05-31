using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CatalogTests.Models.Requests;
using CatalogTests.Models.Responses.Base;
using CatalogTests.Models.Responses;

namespace CatalogTests.Clients
{
    public class UserServiceClient
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly string _baseUrl = "https://userservice-uat.azurewebsites.net";

        public async Task<CommonResponse<object>> RegisterNewUser(CreateNewUserRequest request)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{_baseUrl}/Register/RegisterNewUser"),
                Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = await _client.SendAsync(httpRequestMessage);

            return await response.ToCommonResponse<object>();
        }

        public async Task<CommonResponse<GetUserStatusResponse>> GetUserStatus(string userId)
        {
            var getUserInfoRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_baseUrl}/UserManagement/GetUserStatus?userId={userId}")
            };

            HttpResponseMessage response = await _client.SendAsync(getUserInfoRequest);

            return await response.ToCommonResponse<GetUserStatusResponse>();
        }

        public async Task<CommonResponse<object>> SetUserStatus(string userId, bool status)
        {
            var getUserInfoRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{_baseUrl}/UserManagement/SetUserStatus?userId={userId}&newStatus={status}")
            };

            HttpResponseMessage response = await _client.SendAsync(getUserInfoRequest);

            return await response.ToCommonResponse<object>();
        }

        public async Task<CommonResponse<object>> DeleteUser(string userId)
        {
            var getUserInfoRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{_baseUrl}/Register/DeleteUser?userId={userId}")
            };

            HttpResponseMessage response = await _client.SendAsync(getUserInfoRequest);

            return await response.ToCommonResponse<object>();
        }
    }
}
