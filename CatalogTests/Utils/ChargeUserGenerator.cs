using CatalogTests.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CatalogTests.Utils
{
    internal class ChargeUserGenerator
    {
        public CreateNewUserRequest GenerateNewUserRequest()
        {
            return new CreateNewUserRequest();
        }
      
        public CreateNewUserRequest GenerateNewUserRequest(string firstName, string lastName)
        {
            return new CreateNewUserRequest()
            {
                FirstName = firstName,
                LastName = lastName,
            };
        }
    }
}
