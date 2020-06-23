using BugTrack.DAL;
using BugTrack.DTO;
using BugTrack.IBLL;
using BugTrack.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserManager : IUserManager
    {
        public async Task ChangePassword(string email, string oldPassword, string newPassword)
        {
            using (BugTrack.IDAL.IUserService userService = new BugTrack.DAL.UserService())
            {
                if (await userService.GetAll().AnyAsync(m => m.Email == email && m.Password == oldPassword))
                {
                    var user = await userService.GetAll().FirstOrDefaultAsync(m => m.Email == email);
                    user.Password = newPassword;
                    await userService.Eidt(user);
                }
            }
        }

        public async Task ChangeUserInfo(string email, string password, string phoneNum)
        {
            using (BugTrack.IDAL.IUserService userService = new BugTrack.DAL.UserService())
            {
                var user = await userService.GetAll().FirstAsync(m => m.Email == email);
                user.Password = password;
                user.PhoneNumber = phoneNum;
                await userService.Eidt(user);
            }
        }

        public async Task GetBackPassword(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<UserInfoDto> GetUserByEmail(string email)
        {
            using (BugTrack.IDAL.IUserService userService = new BugTrack.DAL.UserService())
            {
                if (await userService.GetAll().AnyAsync(m => m.Email == email))
                {
                    return await userService.GetAll().Where(m => m.Email == email).Select(m =>
                        new BugTrack.DTO.UserInfoDto()
                        {
                            Id = m.Id,
                            Email = m.Email,
                            PhoneNumber = m.PhoneNumber,
                        }).FirstAsync();
                }
                else
                {
                    throw new Exception("Didn't Existing...");
                }
            }
        }

        // public async Task<bool> Login(string email, string password, Guid userId)
        public bool Login(string email, string password,string name, out Guid userId)
        {
            using (BugTrack.IDAL.IUserService userService = new BugTrack.DAL.UserService())
            {
                var user = userService.GetAll().FirstOrDefaultAsync(m => m.Email == email 
                && m.Password ==password&&m.UserName==name);
                user.Wait();
                var data = user.Result;
                if (data == null)
                {
                    userId = new Guid();
                    return false;
                }
                else 
                {
                    userId = data.Id;
                    return true;
                 }
            }
            //using (BugTrack.IDAL.IUserService userService = new BugTrack.DAL.UserService())
            //{
            //    return await userService.GetAll().
            //        AnyAsync(m => m.Email == email && m.Password == password);
        }

        public async Task Register(string email, string password,string name)
        {
            using (BugTrack.IDAL.IUserService userService = new BugTrack.DAL.UserService())
            {
                await userService.Create(new Users()
                {
                    Email = email,
                    Password = password,
                    UserName=name
                });
            }
        }
    }
}
