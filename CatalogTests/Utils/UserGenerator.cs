using CatalogTests.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogTests.Utils
{
    internal class UserGenerator
    {
        public CreateProductRequest GenerateCreateProductRequest()
        {
            return GenerateCreateProductRequest("LL5" + Guid.NewGuid().ToString().ToUpper().Replace("-", ""));
        }

        public CreateProductRequest GenerateCreateProductRequest(string article)
        {
            return GenerateCreateProductRequest(article);
        }

        public CreateUserInfoRequest GenerateCreateProductRequest(string firstName, string lastName)
        {
            return new CreateUserInfoRequest()
            {
                FirstName = firstName,
                LastName = lastName,
            };
        }

        public string GenerateArticle() => "LL5" + Guid.NewGuid().ToString().ToUpper().Replace("-", "");
    
    }
}
