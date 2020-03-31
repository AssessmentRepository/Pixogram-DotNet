using Moq;
using Pixogram.BusinessLayer.Interfaces;
using Pixogram.BusinessLayer.Repository;
using Pixogram.BusinessLayer.Services;
using Pixogram.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace Pixogram.Tests
{
  public  class BoundaryTests
    {
        private IUserServices _services;

        public readonly Mock<IUserRepository> service = new Mock<IUserRepository>();
        public BoundaryTests()
        {
            _services = new UserServices(service.Object);
        }

        Random random = new Random();

        [Fact]
        public void BoundaryTestForPassword()
        {
            var user = new User()
            {
                Id = random.Next(35, 300000),
                FirstName = "Rose",
                LastName = "mary",
                UserName = "Rose",
                Email = "abc@gmail.com",
                Password = "123456789",
                ConfirmPassword = "123456789",
            };
            var MinLenghthRequired = 8;

            //Action
            var actualLenghth = user.Password.Length;

            //Assert
            Assert.Equal(MinLenghthRequired, actualLenghth);

        }

        [Fact]
        public void BoundaryTestForContent()
        {
            Content user = new Content { Caption = "welcome...." };

            var MaxLenghthRequired = 500;

            //Action
            var actualLenghth = user.Caption.Length;

            //Assert
            Assert.Equal(MaxLenghthRequired, actualLenghth);
        }
        [Fact]
        public void Boundary_Testfor_ValidEmail()
        {
            //Action
            var user = new User()
            {
                Id = random.Next(35, 300000),
                FirstName = "Rose",
                LastName = "mary",
                UserName = "Rose",
                Email = "abc@gmail.com",
                Password = "123456789",
                ConfirmPassword = "123456789",
            };
            bool isEmail = Regex.IsMatch(user.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            //Assert
            Assert.True(isEmail);
        }


    }
}
