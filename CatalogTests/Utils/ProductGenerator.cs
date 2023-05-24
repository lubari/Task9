using System;

namespace CatalogTests.Utils
{
    public class ProductGenerator
    {
        public CreateProductRequest GenerateCreateProductRequest()
        {
            return GenerateCreateProductRequest("LL5" + Guid.NewGuid().ToString().ToUpper().Replace("-", ""));
        }

        public CreateProductRequest GenerateCreateProductRequest(string article)
        {
            return GenerateCreateProductRequest(article, "Legion5" + Guid.NewGuid().ToString(), "Lenovo" + Guid.NewGuid().ToString());
        }

        public CreateProductRequest GenerateCreateProductRequest(string article, string name, string manufactor)
        {
            return new CreateProductRequest()
            {
                Article = article,
                Name = name,
                Manufactor = manufactor,
            };
        }

        public string GenerateArticle() => "LL5" + Guid.NewGuid().ToString().ToUpper().Replace("-", "");
    }
}
