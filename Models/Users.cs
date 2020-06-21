using ADKZ_BugTrack.fonts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADKZ_BugTrack.Models
{
    public class Users
    {
        public Users()
        {
            this.OwnerTickets = new HashSet<Tickets>();
            this.UserClaims = new HashSet<UserClaims>();
            this.UserLongins = new HashSet<UserLongins>();
            this.Roles = new HashSet<Roles>();
            this.Projects = new HashSet<Projects>();
            this.AssignedTickets = new HashSet<Tickets>();
            this.TicketNotifications = new HashSet<TicketNotifications>();
            this.TicketHistories = new HashSet<TicketHistories>();
            this.TicketComments = new HashSet<TicketComments>();
            this.TicketAttachments = new HashSet<TicketAttachments>();
            this.LockoutEnable = false;
        }
        [Key]
        public Guid Id { get; set; } = new Guid();
        [Required]
        public string Email { get; set; }
        [Required]
        public string EmailConfirmed { get; set; }
        [Required]
        [StringLength(maximumLength:50,MinimumLength =6)]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string PhoneNumberConfirmed { get; set; }
        public DateTime LockendDateUtc { get; set; }
        public bool LockoutEnable { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        public virtual ICollection<Roles> Roles { get; set; }
        public virtual ICollection<UserClaims> UserClaims { get; set; }
        public virtual ICollection<UserLongins> UserLongins { get; set; }
        public virtual ICollection<Projects> Projects { get; set; }
        public virtual ICollection<Tickets> OwnerTickets { get; set; }
        public virtual ICollection<Tickets> AssignedTickets { get; set; }
        public virtual ICollection<TicketNotifications> TicketNotifications { get; set; }
        public virtual ICollection<TicketHistories> TicketHistories { get; set; }
        public virtual ICollection<TicketComments> TicketComments { get; set; }
        public virtual ICollection<TicketAttachments> TicketAttachments { get; set; }
    }
}