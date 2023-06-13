using Newtonsoft.Json;

namespace CatalogTests.Models.Requests
{
    public class CreateChargeRequest
    {
        [JsonProperty("userId")]
        public int UserId;

        [JsonProperty("amount")]
        public decimal Amount;
    }
}
