using BugTrack.BAL;
using BugTrack.DAL;
using BugTrack.DTO;
using BugTrack.IBLL;
using BugTrack.IDAL;
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

        public async Task CreateRole(string name)
        {
            using(IRoleService roleSvc=new RoleService())
            {
                await roleSvc.Create(new Roles()
                {
                    Name=name,
                });
            }
        }

        public async Task CreateUserRoles(Guid userId, Guid roleId)
        {
           using(IUserRoleService userRoleSvc=new UserRoleService())
            {
                await userRoleSvc.Create(new UserRoles()
                {
                    UserId=userId,
                    RolesId=roleId,
                });
            }
        }

        public async Task<List<RoleDto>> GetAllRoles()
        {
            using(IRoleService roleSvc=new RoleService())
            {
                return await roleSvc.GetAll().Select(r=>new RoleDto() 
                {
                    Id=r.Id,
                    Name=r.Name
                }).ToListAsync();
            }
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            using(IUserService userSvc = new UserService())
            {
                return await userSvc.GetAll().Select(u=>new UserDto() 
                {
                    Id=u.Id,
                    UserName=u.UserName,
                }).ToListAsync();
            }

           
        }

        public async Task GetBackPassword(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            using (BugTrack.IDAL.IUserService userService = new BugTrack.DAL.UserService())
            {
                if (await userService.GetAll().AnyAsync(m => m.Email == email))
                {
                    return await userService.GetAll().Where(m => m.Email == email).Select(m =>
                        new BugTrack.DTO.UserDto()
                        {
                            Id = m.Id,
                            Email = m.Email,
                            UserName=m.UserName
                        }).FirstAsync();
                }
                else
                {
                    throw new Exception("Didn't Existing...");
                }
            }
        }

        public async Task<string>GetUserRole(Guid userId)
        {
            IUserRoleService userRoleSvc = new UserRoleService();
            var userRole = await userRoleSvc.GetAll().Where(r => r.UserId == userId).FirstOrDefaultAsync();
            IRoleService roleSvc = new RoleService();

            if(await roleSvc.GetAll().Where(r => r.Id == userRole.RolesId).Select(y => y.Name)
            .FirstOrDefaultAsync()!=string.Empty)
            {
                string x = await roleSvc.GetAll().Where(r => r.Id == userRole.RolesId).Select(y => y.Name)
            .FirstOrDefaultAsync();
                return x;
            }
            else
            {
                throw new Exception("Your Don't Have Any Role");
            }
                
        }

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
