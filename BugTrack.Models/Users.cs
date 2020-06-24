using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.Models
{
    public class Users : BaseEntity
    {
        public Users()
        {
            this.OwnerTickets = new HashSet<Tickets>();
            this.UserClaims = new HashSet<UserClaims>();
            this.UserLongins = new HashSet<UserLongins>();
            this.UserRoles = new HashSet<UserRoles>();
            this.ProjectUsers = new HashSet<ProjectUsers>();
            this.AssignedTickets = new HashSet<Tickets>();
            this.TicketNotifications = new HashSet<TicketNotifications>();
            this.TicketHistories = new HashSet<TicketHistories>();
            this.TicketComments = new HashSet<TicketComments>();
            this.TicketAttachments = new HashSet<TicketAttachments>();
            this.LockoutEnable = false;
        }

        [Required]
        public string Email { get; set; }
        public string EmailConfirmed { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 6)]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberConfirmed { get; set; }
        public Nullable< DateTime> LockendDateUtc { get; set; }
        public bool LockoutEnable { get; set; } = false;
        [MaxLength(50)]
        public string UserName { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
        public virtual ICollection<UserClaims> UserClaims { get; set; }
        public virtual ICollection<UserLongins> UserLongins { get; set; }
        public virtual ICollection<ProjectUsers> ProjectUsers { get; set; }
        public virtual ICollection<Tickets> OwnerTickets { get; set; }
        public virtual ICollection<Tickets> AssignedTickets { get; set; }
        public virtual ICollection<TicketNotifications> TicketNotifications { get; set; }
        public virtual ICollection<TicketHistories> TicketHistories { get; set; }
        public virtual ICollection<TicketComments> TicketComments { get; set; }
        public virtual ICollection<TicketAttachments> TicketAttachments { get; set; }
    }
}
