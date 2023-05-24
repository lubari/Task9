using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using CatalogTests.Models.Responses.Base;
using CatalogTests.Models.Responses;

namespace CatalogTests.Clients
{
    internal class UserClient
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly string _baseUrl = "https://catalogservice-uat.azurewebsites.net";

        public async Task<CommonResponse<GetUserInfoResponse>> GetUserInfo(string userID)
        {
            var getUserInfoRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_baseUrl}/UserManagement/GetUserStatus?userId={userID}")
            };

            HttpResponseMessage response = await _client.SendAsync(getUserInfoRequest);

            return await response.ToCommonResponse<GetUserInfoResponse>();
        }
    }
}
