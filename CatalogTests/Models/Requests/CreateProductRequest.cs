using Newtonsoft.Json;

namespace CatalogTests
{
    public class CreateProductRequest
    {
        [JsonProperty("article")]
        public string Article;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("manufactor")]
        public string Manufactor;
    }
}