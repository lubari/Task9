using CatalogTests.Clients;
using CatalogTests.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CatalogTests
{
    internal class WalletTest
    {
        private readonly WalletServiceClient _walletServiceClient = new WalletServiceClient();
        private readonly ChargeGenerator _chargeGenerator = new ChargeGenerator();

        [Test]
        public async Task InvalidUserInfo_CreateUser_StatusCodeIsCreated()
        {
            // Precondition
            var request = _chargeGenerator.GenerateChargeRequest();
            // Action
            var response = await _walletServiceClient.Charge(request);
            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.Status);
        }

        [Test]
        public async Task ValidUserInfo_CreateUser_StatusCodeIsCreated()
        {
            // Precondition
            var request = _chargeGenerator.GenerateChargeRequestWithData();
            // Action
            var response = await _walletServiceClient.Charge(request);
            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.Status);
        }
    }
}
