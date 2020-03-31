using Moq;
using Pixogram.BusinessLayer.Interfaces;
using Pixogram.BusinessLayer.Repository;
using Pixogram.BusinessLayer.Services;
using Pixogram.Entities;
using Pixogram.Tests.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pixogram.Tests
{
   public class ExceptionTests
    {
        private IUserServices _services;

        public readonly Mock<IUserRepository> service = new Mock<IUserRepository>();
        public ExceptionTests()
        {
            _services = new UserServices(service.Object);
        }
        Random random = new Random();
        [Fact]
        public async Task ExceptionTestForUserNotFound()
        {

            //Arrange
            var user = new User()
            {
                Id = random.Next(35, 300000),
                FirstName = "Rose",
                LastName = "mary",
                UserName = "Rose",
                Email = "abc@gmail.com",
                Password = "1234",
                ConfirmPassword = "1234",
            };
            Assert.ThrowsAsync<UserNotFoundException>(async () => await _services.GetUserById(user.Id));
        }
    }
}
