using Pixogram.BusinessLayer.Interfaces;
using Pixogram.BusinessLayer.Repository;
using Pixogram.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pixogram.BusinessLayer.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
    

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> RegisterAsync(User user)
        {
            try
            {
                var users = await _userRepository.RegisterAsync(user);
                return users;
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
                var user = await _userRepository.GetAllUserAsync();
                return user;
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
