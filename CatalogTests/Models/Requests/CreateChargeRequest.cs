using Newtonsoft.Json;

namespace CatalogTests.Models.Requests
{
    internal class CreateChargeRequest
    {
        [JsonProperty("userId")]
        public string UserId;

        [JsonProperty("amount")]
        public string Amount;
    }
}
