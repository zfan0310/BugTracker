using BugTrack.DTO;
using BugTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.IBLL
{ 
    public interface IProjectManager
    {
        Task _CreateProjectUser(Guid userId, Guid projectId);
        Task CreateProject(string name,Guid userId);
        Task<List<DTO.ProjectDto>> GetProjectByEmail(string email);
        Task<List<Projects>> GetAllProjectByUserId(Guid userId);
        Task RemoveProjectById(Guid ProjectId);
        Task RemoveProjectByEmail(Guid UserEmail);
        Task EditProject(Guid ProjectId, string newName);
    }
}
