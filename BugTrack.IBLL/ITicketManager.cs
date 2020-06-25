using BugTrack.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.IBLL
{
    public interface ITicketManager
    {
        Task CreateTicket(string title, string description,
             Guid ownerUserId, Guid typeId,
             Guid priorityId, Guid statusId, Guid projectId);///////////////
        Task CreateTicketType(string name);
        Task <List<TicketTypeDto>> GetAllTicketType();
        Task CreateTicketStatus(string name);
        Task CreateTicketPriority(string name);
        Task CreateTicketAttachment(string filePath, string description, Guid ticketId, Guid userId);
        Task CreateTicketComment(string comment, Guid ticketId, Guid userId);
        //Task CreateTicketNotification()
        Task CreateTicketHistory(string property, string oldValue, string newValue, Guid ticketId, Guid UserId);

        //Task EditTicketType(string name); 
        Task <DTO.TicketDto> GetTicketById(Guid id);
        Task<List<DTO.TicketDto>> GetAllTicketByUserId(Guid userId);
        Task<List<DTO.TicketDto>> GetAllTicketByType(Guid ticketTypeId);
        Task RemoveTicketById(Guid TicketId);
        Task<List<TicketPriorityDto>> GetAllPriority();
        Task<List<TicketDto>> GetAllTicket();
        Task<List<TicketStatusDto>> GetAllTicketStatus();
        Task EditTicket(Guid TicketId, string title,string description,Guid typeId,Guid priorityId,Guid statusId);
    }
}
