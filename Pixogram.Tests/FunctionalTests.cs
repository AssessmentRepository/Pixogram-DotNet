using Moq;
using Pixogram.BusinessLayer.Interfaces;
using Pixogram.BusinessLayer.Repository;
using Pixogram.BusinessLayer.Services;
using Pixogram.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pixogram.Tests
{
   public class FunctionalTests
    {
        private IUserServices _services;

        public readonly Mock<IUserRepository> service = new Mock<IUserRepository>();
        public FunctionalTests()
        {
            _services = new UserServices(service.Object);
        }

        Random random = new Random();

        [Fact]
        public async Task TestFor_ValidUserRegistrationAsync()
        {
            Random random = new Random();

            var user = new User()
            {
                Id = random.Next(35, 300000),
                FirstName="Rose",
                LastName="mary",
                UserName = "Rose",
                Email = "abc@gmail.com",
                Password = "1234",
                ConfirmPassword = "1234",
            };

            service.Setup(repos => repos.RegisterAsync(user)).ReturnsAsync(user);
            var registeredUser = await _services.RegisterAsync(user);
            Assert.Equal(user, registeredUser);
        }


        [Fact]
        public async Task Testfor_ValidSignin()
        {

            Random random = new Random();

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
            service.Setup(repos => repos.LoginAsync(user.UserName, user.Password)).ReturnsAsync(user);
            var register = await _services.LoginAsync(user.UserName, user.Password);

            Assert.Equal(user, register); 
        }

        [Fact]
        public async Task Testfor_AllUser()
        {
            //Action
            service.Setup(repos => repos.GetAllUserAsync());
            var register = await _services.GetAllUserAsync();
            //Assertion
            Assert.NotNull(register);
        }
        [Fact]
        public async Task Testfor_GetUser()
        {
            //Action
            Random random = new Random();

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

            service.Setup(repos => repos.GetUserById(user.Id)).ReturnsAsync(user);
            var register = await _services.GetUserById (user.Id);
            //Assertion
            Assert.Equal(user, register);
        }


        //Content

        [Fact]
        public async Task TestForValidAddContent()
        {
            //Arrange
            List<Content> contentlist = new List<Content>();
            Content contentOne = new Content() {Id=random.Next(15,10000),Image="rose.png", Video="Rose" };
            Content contentTwo = new Content() { Id = random.Next(15, 10000), Image = "Jasmine.png", Video = "Jasmine" };
            contentlist.Add(contentOne);
            contentlist.Add(contentTwo);
            User user = new User { Id = 11, FirstName = "John", LastName = "HS", UserName = "John", Email = "John@gmail.com", Password = "1234567890", ProfilePicture = "https://unsplash.com/photos/p7mo8-CG5Gs" };
           
            //Action
            var isAdded = await _services.AddContent(contentlist, user.Id);

            //Assert
            Assert.True(isAdded);

        }

        [Fact]
        public async Task TestValidOrganiceImageAsync()
        {
            //Arrange
            List<Content> contentlist = new List<Content>();
            Content contentOne = new Content() { Id = random.Next(15, 10000), Image = "rose.png", Video = "Rose" };
            Content contentTwo = new Content() { Id = random.Next(15, 10000), Image = "Jasmine.png", Video = "Jasmine" };
            User user = new User { Id = 11, FirstName = "John", LastName = "HS", UserName = "John", Email = "John@gmail.com", Password = "1234567890", ProfilePicture = "https://unsplash.com/photos/p7mo8-CG5Gs" };


            //Action
            service.Setup(repos => repos.OrganizeImage(user.Id, contentlist)).ReturnsAsync(contentlist);
            var Organised =await _services.OrganizeImage(user.Id, contentlist);
            var isOrganised = await _services.GetContentByUserId(user.Id);

            //Assert
            Assert.Equal(Organised, contentlist);
            Assert.Equal(isOrganised, Organised);

        }

        [Fact]
        public async Task TestForValidOrganiceVideoAsync()
        {
            //Arrange
            List<Content> contentlist = new List<Content>();
            Content contentOne = new Content() { Id = random.Next(15, 10000), Image = "rose.png", Video = "Rose" };
            Content contentTwo = new Content() { Id = random.Next(15, 10000), Image = "Jasmine.png", Video = "Jasmine" };
            User user = new User { Id = 11, FirstName = "John", LastName = "HS", UserName = "John", Email = "John@gmail.com", Password = "1234567890", ProfilePicture = "https://unsplash.com/photos/p7mo8-CG5Gs" };


            //Action
            service.Setup(repos => repos.OrganizeVideo(user.Id, contentlist)).ReturnsAsync(contentlist);
            var Organised = await _services.OrganizeVideo(user.Id, contentlist);
            var isOrganised =await _services.GetContentByUserId(user.Id);

            //Assert
            Assert.Equal(Organised, contentlist);
            Assert.Equal(isOrganised, Organised);

        }
        [Fact]
        public async Task TestForValidUpdateContentAsync()
        {
            //Arrange
            Content content = new Content { Id = random.Next(20,100), Image = "https://unsplash.com/photos/p7mo8-CG5Gs", Video = "https://unsplash.com/photos/p7mo8-CG5Gs", Caption = "Images", Description = "Flowers", Visibility = true, UserId = 11 };
            User user = new User { Id = 11, FirstName = "John", LastName = "HS", UserName = "John", Email = "John@gmail.com", Password = "1234567890", ProfilePicture = "https://unsplash.com/photos/p7mo8-CG5Gs" };

            //Action
            var isContetUpadated = await _services.UpdateContent(user.Id, content);

            //Assert
            Assert.True(isContetUpadated);


        }
        [Fact]
        public async Task TestForValidAddCommentAsync()
        {
            //Arrange
            Feedback feedback = new Feedback() { Id = random.Next(10, 1000), UserId= random.Next(10, 1000), SenderUserId=random.Next(10, 1000), Comment="NoComment", Like=true };

            //Action

            var isAdded = await _services.AddComment(feedback);

            //Assert
            Assert.True(isAdded);
        }

        [Fact]
        public async Task TestForValidFollowUserAsync()
        {
            //Arrange
            User user = new User { Id = 11, FirstName = "John", LastName = "HS", UserName = "John", Email = "John@gmail.com", Password = "1234567890", ProfilePicture = "https://unsplash.com/photos/p7mo8-CG5Gs" };

            //Action
           // service.Setup(repos => repos.OrganizeVideo(user.Id, contentlist)).ReturnsAsync(contentlist);
            var isFollowed = await _services.FollowUser(user.Id, 2);

            //Assert
            Assert.True(isFollowed);

        }

        [Fact]
        public async Task TestForValidHideMediaAsync()
        {
            //Arrange
            Content content = new Content { Image = "https://unsplash.com/photos/p7mo8-CG5Gs", Visibility = true, Video = "https://unsplash.com/photos/p7mo8-CG5Gs" };

            //Action
            var isHided = await _services.HideMedia(content.Image, content.Visibility, content.Video);

            //Assert
            Assert.True(isHided);

        }
    }
}
