using CatalogTests.Enum;

namespace CatalogTests.Models.Responses
{
    public class GetProductInfoResponse
    {
        public string Article { get; set; }
        public string Name { get; set; }
        public string Manufactor { get; set; }
        public ProductStatus Status { get; set; }
        public decimal Price { get; set; }
    }
}
