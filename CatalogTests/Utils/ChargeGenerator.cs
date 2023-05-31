using CatalogTests.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CatalogTests.Utils
{
    public class ChargeGenerator
    {   
        public CreateChargeRequest GenerateChargeRequest()
        {
            return new CreateChargeRequest();
        }

        public CreateChargeRequest GenerateChargeRequest(int userId, double amount)
        {
            return new CreateChargeRequest()
            {
                UserId = userId,
                Amount = amount,
            };
        }

        public CreateChargeRequest GenerateChargeRequestWithData()
        {
            return GenerateChargeRequest(3, 1234.0);
        }

    }
}
