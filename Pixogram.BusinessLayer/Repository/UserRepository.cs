using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Pixogram.DataLayer;
using Pixogram.Entities;

namespace Pixogram.BusinessLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public UserRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;

        }

        public async Task<User> RegisterAsync(User user)
        {
            try
            {
                var connection = await _dbConnectionFactory.CreateConnectionAsync();
                //_dbConnectionFactory.SetupAsync();
                await connection.ExecuteAsync("Insert into User (Id, FirstName, LastName,UserName,Email,Password, ConfirmPassword,ProfilePicture) VALUES (@id, @firstName, @lastName,@userName,@email,@password, @confirmPassword,@profilePicture)", new { id=user.Id,firstName=user.FirstName,lastName=user.LastName, userName=user.UserName, email=user.Email, password=user.Password, confirmPassword=user.ConfirmPassword, profilePicture=user.ProfilePicture});
                return user;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

       

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            try
            {
                var connection = await _dbConnectionFactory.CreateConnectionAsync();
                return await connection.QueryAsync<User>("select * from User");
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public Task<User> LoginAsync(string UserName, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<User> ResetPassword(string Password)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetProfile(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProfile(User User)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProfile(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddContent(List<Content> content, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Content>> OrganizeImage(int UserId, List<Content> Content)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Content>> OrganizeVideo(int UserId, List<Content> Content)
        {
            throw new NotImplementedException();
        }

        public Content GetContent(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateContent(int UserId, Content Content)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddComment(Feedback Feedback)
        {
            throw new NotImplementedException();
        }

        public Task<bool> FollowUser(int UserId, int SenderId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Follow>> FollowList(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HideMedia(string picturePath, bool Visibility, string VideoPath)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ILog>> ActivityLog(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Content>> GetContentByUserId(int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
