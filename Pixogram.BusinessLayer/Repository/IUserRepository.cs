using Pixogram.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pixogram.BusinessLayer.Repository
{
  public interface IUserRepository
    {
        Task<User> RegisterAsync(User user);
        Task<User> LoginAsync(string UserName, string Password);
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> ResetPassword(string Password);
        Task<User> GetProfile(int Id);
        Task<bool> UpdateProfile(User User);
        Task<bool> DeleteProfile(int Id);
        Task<bool> AddContent(List<Content> content, int UserID);
        Task<IEnumerable<Content>> OrganizeImage(int UserId, List<Content> Content);
        Task<IEnumerable<Content>> OrganizeVideo(int UserId, List<Content> Content);
        Content GetContent(int Id);
        Task<bool> UpdateContent(int UserId, Content Content);
        Task<bool> AddComment(Feedback Feedback);
        Task<bool> FollowUser(int UserId, int SenderId);
        Task<IEnumerable<Follow>> FollowList(int UserId);
        Task<bool> HideMedia(string picturePath, bool Visibility, string VideoPath);
        Task<IEnumerable<ILog>> ActivityLog(int UserId);
        Task<User> GetUserById(int UserId);
        Task<IEnumerable<Content>> GetContentByUserId(int UserId);
    }
}
