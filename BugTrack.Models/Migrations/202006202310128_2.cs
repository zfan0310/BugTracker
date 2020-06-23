namespace BugTrack.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "IsRemoved", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProjectUsers", "IsRemoved", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "IsRemoved", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tickets", "IsRemoved", c => c.Boolean(nullable: false));
            AddColumn("dbo.TicketAttachments", "IsRemoved", c => c.Boolean(nullable: false));
            AddColumn("dbo.TicketComments", "IsRemoved", c => c.Boolean(nullable: false));
            AddColumn("dbo.TicketHistories", "IsRemoved", c => c.Boolean(nullable: false));
            AddColumn("dbo.TicketNotifications", "IsRemoved", c => c.Boolean(nullable: false));
            AddColumn("dbo.TicketPriorities", "IsRemoved", c => c.Boolean(nullable: false));
            AddColumn("dbo.TicketStatuses", "IsRemoved", c => c.Boolean(nullable: false));
            AddColumn("dbo.TicketTypes", "IsRemoved", c => c.Boolean(nullable: false));
            AddColumn("dbo.Roles", "IsRemoved", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserClaims", "IsRemoved", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserLongins", "IsRemoved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserLongins", "IsRemoved");
            DropColumn("dbo.UserClaims", "IsRemoved");
            DropColumn("dbo.Roles", "IsRemoved");
            DropColumn("dbo.TicketTypes", "IsRemoved");
            DropColumn("dbo.TicketStatuses", "IsRemoved");
            DropColumn("dbo.TicketPriorities", "IsRemoved");
            DropColumn("dbo.TicketNotifications", "IsRemoved");
            DropColumn("dbo.TicketHistories", "IsRemoved");
            DropColumn("dbo.TicketComments", "IsRemoved");
            DropColumn("dbo.TicketAttachments", "IsRemoved");
            DropColumn("dbo.Tickets", "IsRemoved");
            DropColumn("dbo.Users", "IsRemoved");
            DropColumn("dbo.ProjectUsers", "IsRemoved");
            DropColumn("dbo.Projects", "IsRemoved");
        }
    }
}
