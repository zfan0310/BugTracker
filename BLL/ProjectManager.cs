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
    public class ProjectManager : IProjectManager
    {
        public async Task CreateProject(string name,Guid userId)
        {
            using (var projectService = new ProjectService())
            {
                var project = new Projects()
                { 
                    Name = name,
                };
                await projectService.Create(project);
                await _CreateProjectUser(userId, project.Id);
               
            }
        }

        public async Task _CreateProjectUser(Guid userId, Guid projectId)
        {
           using(var projectUSvc=new ProjectUsersService())
            {
                await projectUSvc.Create(new ProjectUsers()
                {
                    UserId=userId,
                    ProjectId=projectId,
                });
            }
        }

        public Task EditProject(Guid ProjectId, string newName) 
        {
            throw new NotImplementedException();
        }

        public async Task<List<Projects>> GetAllProjectByUserId(Guid userId)
        {
            Context db = new Context();
            var projects = db.Projects;
            //find user role if is admin
            IUserManager userSvc = new UserManager();
            string userRole= await userSvc.GetUserRole(userId);

            if (userRole == "Admin" || userRole == "Submitter")
            {
                return projects.ToList();
            }
            else
            {
                return projects.Where(
                    pj => pj.Id == pj.ProjectUsers.Where(pu=>pu.UserId==userId)
                    .FirstOrDefault().ProjectId).ToList();
            }
            /*using(IProjectService projectSvc=new ProjectService())
            {
                ITicketService ticketSvc = new TicketService();
                if (userRole == "Admin"|| userRole == "Submitter")
                {
                    return await projectSvc.GetAll().Select(p => new ProjectDto()
                    {
                        Id = p.Id,
                        Name = p.Name,
                    }).ToListAsync();
                }
                else
                {
                    using(IProjectUsersService projectUserSvc=new ProjectUsersService())
                    {
                        List<ProjectDto> ProjectList = new List<ProjectDto>();

                        foreach (var pu in  projectUserSvc.GetAll())
                        {
                            foreach (var p in projectSvc.GetAll())
                            {
                                if (pu.UserId == userId)
                                {
                                    var x = pu.ProjectId;
                                    if (p.Id == x)
                                    {
                                        ProjectList.Add(new ProjectDto()
                                        {
                                            Id = p.Id,
                                            Name = p.Name,
                                        });
                                    }
                                }
                            }

                        }
                        return ProjectList;
                    }
                }
                
            }*/
        }

        public Task<List<ProjectDto>> GetProjectByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProjectByEmail(Guid UserEmail)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProjectById(Guid ProjectId)
        {
            throw new NotImplementedException();
        }

       /* public Task<List<ProjectDto>> GetAllProject()
        {
            
        }*/
    }
}
