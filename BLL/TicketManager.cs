using BugTrack.DAL;
using BugTrack.DTO;
using BugTrack.IBLL;
using BugTrack.IDAL;
using BugTrack.Models;
using BugTrack.Models.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TicketManager : ITicketManager
    {
        public async Task CreateTicket(string title, string description, 
            Guid typeId,Guid projectId,Guid priorityId,Guid statusId,
            Guid ownerUserId,Guid assignedToUserId, Guid userId)
        {
            using(var ticketSvc=new TicketService())
            {
                var ticket = new Tickets()
                {
                    Title = title,
                    Description=description,
                    TicketTypeId=typeId,
                    TicketPriorityId=priorityId,
                    TicketStatusId=statusId,
                    OwnerUserId=ownerUserId,
                    AssignedToUserId=assignedToUserId
                };
                await ticketSvc.Create(ticket);

                Guid ticketId = ticket.Id;
                using(var notificationSvc=new TicketNotificationService())
                {
                    await notificationSvc.Create(new TicketNotifications()
                    {
                        TicketId=ticketId,
                        UserId=userId,
                    });
                }
                //TicketNotification achieve
            }
        }

        public async Task CreateTicketAttachment(string filePath, string description, 
            Guid ticketId, Guid userId)
        {
            using (var ticketAttachment = new TicketAttachmentService()) 
            {
                await ticketAttachment.Create(new TicketAttachments()
                {
                    FilePath=filePath,
                    Description=description,
                    UserId=userId,
                    TicketId=ticketId,
                });
            }
        }

        public async Task CreateTicketComment(string comment, Guid ticketId, Guid userId)
        {
            using(var ticketCommentSvc=new TicketCommentService())
            {
                await ticketCommentSvc.Create(new TicketComments()
                {
                    Comment=comment,
                    TicketId=ticketId,
                    UserId=userId,
                });
            }
        }

        public async Task CreateTicketHistory(string property, string oldValue,
            string newValue, Guid ticketId, Guid UserId)
        {
            using(var ticketHistorySvc=new TicketHistoryService())
            {
                await ticketHistorySvc.Create(new TicketHistories()
                {
                    Property=property,
                    OldValue=oldValue,
                    NewValue=newValue,
                    TicketId=ticketId,
                    UserId=UserId,
                });
            }
        }

        public async Task CreateTicketPriority(string name)
        {
            using(var ticketPrioritySvc=new TicketPriorityService())
            {
                await ticketPrioritySvc.Create(new TicketPriorities()
                {
                    Name = name,
                });
            }
        }

        public async Task CreateTicketStatus(string name)
        {
            using(var ticketStatusSvc=new TicketStatusService())
            {
                await ticketStatusSvc.Create(new TicketStatuses()
                {
                    Name=name,
                });
            }
        }
       
        public async Task CreateTicketType(string name)
        {
            using(var typeSvc=new TicketTypeService())
            {
                await typeSvc.Create(new TicketTypes()
                {
                    Name=name,
                });
            }
        }

        public async Task EditTicket(Guid TicketId, string title, string description,
            Guid typeId, Guid priorityId, Guid statusId)
        {
            using(var ticketSvc=new TicketService())
            {

               // await ticketSvc.Eidt();
            }
        }

        /* public async Task EditTicketType(string name)
         {
             throw new NotImplementedException();
         }*/

        public async Task<List<TicketDto>> GetAllTicketByType(Guid ticketTypeId)
        {
            using (ITicketService TicketSvc = new TicketService())
            {
                return await TicketSvc.GetAll().Where(t => t.TicketTypeId == ticketTypeId)
                    .Select(s=>new TicketDto()
                    {
                        Id = s.Id,
                        Title = s.Title,
                        Description = s.Description,
                        Created = s.Created,
                        Updated = s.Updated,
                        ProjectId = s.ProjectId,
                        ticketTypeId = s.TicketTypeId,
                        TicketPriorityId = s.TicketPriorityId,
                        TicketStatusId = s.TicketStatusId,
                        OwnerUserId = s.OwnerUserId,
                        AssignedToUserId = s.AssignedToUserId
                    }).ToListAsync();
            }
        }

        public async Task<List<TicketDto>> GetAllTicketByUserId(Guid userId)
        {
            using (ITicketService TicketSvc = new TicketService())
            {
                return await TicketSvc.GetAll().Where(t => t.TicketNotifications
                    .Any( n => n.UserId == userId)).Select(s=>new TicketDto() 
                    { 
                      Id=s.Id,
                      Title=s.Title,
                      Description=s.Description,
                      Created=s.Created,
                      Updated=s.Updated,
                      ProjectId=s.ProjectId,
                      ticketTypeId=s.TicketTypeId,
                      TicketPriorityId=s.TicketPriorityId,
                      TicketStatusId=s.TicketStatusId,
                      OwnerUserId=s.OwnerUserId,
                      AssignedToUserId=s.AssignedToUserId
                    }).ToListAsync();
            }
        }

        public async Task<List<TicketTypeDto>> GetAllTicketType()
        {
            using (ITicketTypeService x = new TicketTypeService())
            {
                return await x.GetAll().Select(t=>new TicketTypeDto() {
                Id=t.Id,
                Name=t.Name,
                }).ToListAsync();
            }
        }

        public async Task<TicketDto> GetTicketById(Guid id)
        {
            using (ITicketService TicketSvc = new TicketService())
            {
                return await TicketSvc.GetAll().Where(t => t.Id == id)
                    .Select(s => new TicketDto()
                    {
                        Id = s.Id,
                        Title = s.Title,
                        Description = s.Description,
                        Created = s.Created,
                        Updated = s.Updated,
                        ProjectId = s.ProjectId,
                        ticketTypeId = s.TicketTypeId,
                        TicketPriorityId = s.TicketPriorityId,
                        TicketStatusId = s.TicketStatusId,
                        OwnerUserId = s.OwnerUserId,
                        AssignedToUserId = s.AssignedToUserId
                    }).FirstOrDefaultAsync();
            }
        }

        public async Task RemoveTicketById(Guid TicketId)
        {
            throw new NotImplementedException();
        }
    }
}
