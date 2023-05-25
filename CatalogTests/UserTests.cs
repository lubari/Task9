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

        // RegisterUser
        [Test]
        public async Task RegisterUser_EmptyFields_ReturnsError()
        {
            // Arrange
            string firstName = "";
            string lastName = "";

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () =>
            {
                await _userServiceClient.RegisterNewUser(firstName, lastName);
            });
        }

        [Test]
        public async Task RegisterUser_FieldsEqualToNull_ReturnsError()
        {
            // Arrange
            string firstName = null;
            string lastName = null;

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () =>
            {
                await _userServiceClient.RegisterNewUser(firstName, lastName);
            });
        }

        [Test]
        public async Task RegisterUser_DigitsInFields_ReturnsNewUserId()
        {
            // Arrange
            string firstName = "John123";
            string lastName = "Doe456";

            // Act
            int newUserId = await _userServiceClient.RegisterNewUser(firstName, lastName);

            // Assert
            Assert.Greater(newUserId, 0);
        }

        // ... Implement additional test cases for RegisterUser based on the provided requirements

        // GetUserStatus
        [Test]
        public async Task GetUserStatus_NotExistingUser_ReturnsFalse()
        {
            // Arrange
            int nonExistingUserId = 999; // Replace with a non-existing user ID in UserService

            // Act
            bool userStatus = await _userServiceClient.GetUserStatus(nonExistingUserId);

            // Assert
            Assert.IsFalse(userStatus);
        }

        // ... Implement additional test cases for GetUserStatus based on the provided requirements

        // SetUserStatus
        [Test]
        public async Task SetUserStatus_NotExistingUser_ThrowsException()
        {
            // Arrange
            int nonExistingUserId = 999; // Replace with a non-existing user ID in UserService
            bool newStatus = true;

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () =>
            {
                await _userServiceClient.SetUserStatus(nonExistingUserId, newStatus);
            });
        }

        // ... Implement additional test cases for SetUserStatus based on the provided requirements

        // DeleteUser
       
    }
}
