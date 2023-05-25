using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CatalogTests.Clients
{
    internal class UserServiceClient
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly string _baseUrl = "https://userservice-uat.azurewebsites.net";

        public async Task<int> RegisterNewUser(string firstName, string lastName)
        {
            var requestBody = new { firstName, lastName };
            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"{_baseUrl}/Register/RegisterNewUser", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<int>(responseContent);

            return result;
        }

        public async Task<bool> GetUserStatus(int userId)
        {
            var response = await _client.GetAsync($"{_baseUrl}/UserManagement/GetUserStatus?userId={userId}");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("Specified argument was out of the range of valid values. (Parameter 'cannot find user with this id')");
            }
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(responseContent);

            return result;
        }

        public async Task SetUserStatus(int userId, bool newStatus)
        {
            var setUserStatusRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"{_baseUrl}/UserManagement/SetUserStatus?userId={userId}&newStatus={newStatus}")
            };

            HttpResponseMessage response = await _client.SendAsync(setUserStatusRequest);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new Exception("Specified argument was out of the range of valid values. (Parameter 'cannot find user with this id')");
                }
                else
                {
                    throw new Exception("An error occurred while setting the user status.");
                }
            }
        }
    }
}
