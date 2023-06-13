using CatalogTests.Clients;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogTests
{
    internal class UserTests
    {
        private readonly UserServiceClient _userServiceClient = new UserServiceClient();

        [Test]
        public async Task CreateValidUserID_GetUserStatus_ResponseIsCorrect()
        {
            //Precondition
            //Action
            var requesponse = _userServiceClient.GetUserStatus("1234");
            //Assert
            Assert.True(requesponse.);
        }
    }
}
