namespace BugTrack.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
     
    public class Context : DbContext
    {
        public Context(): base("conn")
        {
            Database.SetInitializer<Context>(null);
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserLongins> UserLongins { get; set; }
        public DbSet<UserClaims> UserClaims { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<TicketStatuses> TicketStatuses { get; set; }
        public DbSet<TicketTypes> TicketTypes { get; set; }
        public DbSet<TicketPriorities> TicketPriorities { get; set; }
        public DbSet<TicketComments> TicketComments { get; set; }
        public DbSet<TicketAttachments> TicketAttachments { get; set; }
        public DbSet<TicketHistories> TicketHistories { get; set; }
        public DbSet<TicketNotifications> ticketNotifications { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<ProjectUsers> ProjectUsers { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}