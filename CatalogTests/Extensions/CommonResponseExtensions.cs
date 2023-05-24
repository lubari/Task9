using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace CatalogTests.Models.Responses.Base
{
    public static class CommonResponseExtensions
    {
        public static async Task<CommonResponse<T>> ToCommonResponse<T>(this HttpResponseMessage message)
        {
            string responseBody = await message.Content.ReadAsStringAsync();

            var commonResponse = new CommonResponse<T>
            {
                Status = message.StatusCode,
                Content = responseBody
            };

            try
            {
                commonResponse.Body = JsonConvert.DeserializeObject<T>(responseBody);
            }
            catch (JsonReaderException exception)
            {
            }

            return commonResponse;
        }
    }
}
