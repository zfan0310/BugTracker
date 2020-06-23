using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.IBLL
{
    public interface IUserManager
    {
        Task Register(string email, string password,string name);
        bool Login(string email, string password,string name,out Guid userId);
        Task ChangePassword(string email, string oldPassword, string newPassword);
        Task ChangeUserInfo(string email, string password, string phoneNum);
        Task GetBackPassword(string email);
        Task<DTO.UserInfoDto> GetUserByEmail(string email);
    }
}
 