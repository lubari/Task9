using CatalogTests.Clients;
using CatalogTests.Utils;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

namespace CatalogTests
{
    internal class WalletTest
    {
        private readonly WalletServiceClient _walletServiceClient = new WalletServiceClient();
        private readonly ChargeGenerator _chargeGenerator = new ChargeGenerator();

        [Test]
        public async Task InvalidUserInfo_Charge_StatusCodeIsCreated()
        {
            // Precondition
            var chargeRequest = _chargeGenerator.GenerateChargeRequest();
            // Action
            var response = await _walletServiceClient.Charge(chargeRequest);
            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.Status);
        }

        [Test]
        public async Task ValidUserInfo_ChargeUser_StatusCodeIsCreated()
        {
            // Precondition
            var request = _chargeGenerator.GenerateChargeRequestWithData();
            // Action
            var response = await _walletServiceClient.Charge(request);
            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.Status);
        }

        [Test]
        public async Task NewUser_GetBalance_StatusCodeISCreated()
        {
            // Precondition

            // Action
            var response = await _walletServiceClient.GetBalance("123");
            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.Status);
        }



    }
}
