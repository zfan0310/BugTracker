using BugTrack.DAL;
using BugTrack.DTO;
using BugTrack.IBLL;
using BugTrack.IDAL;
using BugTrack.Models;
using System;
using System.Collections.Generic;
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

        public Task<List<ProjectDto>> GetAllProjectByUserId(Guid userId)
        {
            throw new NotImplementedException();
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
    }
}
