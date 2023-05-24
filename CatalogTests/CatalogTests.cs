using CatalogTests.Clients;
using CatalogTests.Enum;
using CatalogTests.Utils;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

namespace CatalogTests
{
    public class CatalogTests
    {
        private readonly CatalogServiceClient _catalogServiceClient = new CatalogServiceClient();
        private readonly ProductGenerator _productGenerator = new ProductGenerator();

        [Test]
        public async Task ValidProductInfo_CreateProduct_StatusCodeIsCreated()
        {
            // Precondition
            var request = _productGenerator.GenerateCreateProductRequest();
            // Action
            var response = await _catalogServiceClient.CreateProduct(request);
            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.Status);
        }

        [Test]
        public async Task CreateValidProduct_CreateProductWithSameArticle_StatusCodeIsConflict()
        {
            // Precondition 

            var request1 = _productGenerator.GenerateCreateProductRequest();

            await _catalogServiceClient.CreateProduct(request1);

            // Action

            var request2 = _productGenerator.GenerateCreateProductRequest(request1.Article);

            var response = await _catalogServiceClient.CreateProduct(request2);

            // Assert

            Assert.AreEqual(HttpStatusCode.Conflict, response.Status);
        }

        [Test]
        public async Task CreateValidProduct_GetProductInfo_ResponseIsCorrect()
        {
            // Precondition 

            var createProductRequest = _productGenerator.GenerateCreateProductRequest();

            await _catalogServiceClient.CreateProduct(createProductRequest);

            // Action

            var getProductInfoResponse = await _catalogServiceClient.GetProductInfo(createProductRequest.Article);

            // Assert

            Assert.Multiple(() =>
            {
                Assert.AreEqual(createProductRequest.Article, getProductInfoResponse.Body.Article);
                Assert.AreEqual(createProductRequest.Name, getProductInfoResponse.Body.Name);
                Assert.AreEqual(createProductRequest.Manufactor, getProductInfoResponse.Body.Manufactor);
                Assert.AreEqual(0, getProductInfoResponse.Body.Price);
                Assert.AreEqual(ProductStatus.NotActive, getProductInfoResponse.Body.Status);
            });
        }

        [Test]
        public async Task NoProduct_GetProduct_StatusIsNotFound()
        {
            // Precondition

            var article = _productGenerator.GenerateArticle();

            // Action 

            var response = await _catalogServiceClient.GetProductInfo(article);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.NotFound, response.Status);
                Assert.AreEqual("Sequence contains no elements", response.Content);
            });
        }
    }
}