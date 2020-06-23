namespace BugTrack.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class i : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Created = c.DateTime(nullable: false),
                        Users_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.ProjectUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProjectId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.ProjectId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(nullable: false),
                        EmailConfirmed = c.String(),
                        Password = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.String(),
                        LockendDateUtc = c.DateTime(nullable: false),
                        LockoutEnable = c.Boolean(nullable: false),
                        UserName = c.String(maxLength: 50),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        ProjectId = c.Guid(nullable: false),
                        TicketTypeId = c.Guid(nullable: false),
                        TicketPriorityId = c.Guid(nullable: false),
                        TicketStatusId = c.Guid(nullable: false),
                        OwnerUserId = c.Guid(nullable: false),
                        AssignedToUserId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Users_Id = c.Guid(),
                        Users_Id1 = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AssignedToUserId)
                .ForeignKey("dbo.Users", t => t.OwnerUserId)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .ForeignKey("dbo.TicketPriorities", t => t.TicketPriorityId)
                .ForeignKey("dbo.TicketStatuses", t => t.TicketStatusId)
                .ForeignKey("dbo.TicketTypes", t => t.TicketTypeId)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .ForeignKey("dbo.Users", t => t.Users_Id1)
                .Index(t => t.ProjectId)
                .Index(t => t.TicketTypeId)
                .Index(t => t.TicketPriorityId)
                .Index(t => t.TicketStatusId)
                .Index(t => t.OwnerUserId)
                .Index(t => t.AssignedToUserId)
                .Index(t => t.Users_Id)
                .Index(t => t.Users_Id1);
            
            CreateTable(
                "dbo.TicketAttachments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TicketId = c.Guid(nullable: false),
                        FilePath = c.String(),
                        Description = c.String(maxLength: 200),
                        UserId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickets", t => t.TicketId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.TicketId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TicketComments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Comment = c.String(nullable: false),
                        TicketId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickets", t => t.TicketId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.TicketId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TicketHistories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Property = c.String(),
                        OldValue = c.String(),
                        NewValue = c.String(),
                        Changed = c.DateTime(nullable: false),
                        TicketId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickets", t => t.TicketId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.TicketId);
            
            CreateTable(
                "dbo.TicketNotifications",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TicketId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickets", t => t.TicketId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.TicketId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TicketPriorities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TicketStatuses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TicketTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLongins",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(maxLength: 50),
                        UserId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Users_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.RolesUsers",
                c => new
                    {
                        Roles_Id = c.Guid(nullable: false),
                        Users_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Roles_Id, t.Users_Id })
                .ForeignKey("dbo.Roles", t => t.Roles_Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.Roles_Id)
                .Index(t => t.Users_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectUsers", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserLongins", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.RolesUsers", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.RolesUsers", "Roles_Id", "dbo.Roles");
            DropForeignKey("dbo.Projects", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.Tickets", "Users_Id1", "dbo.Users");
            DropForeignKey("dbo.Tickets", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.Tickets", "TicketTypeId", "dbo.TicketTypes");
            DropForeignKey("dbo.Tickets", "TicketStatusId", "dbo.TicketStatuses");
            DropForeignKey("dbo.Tickets", "TicketPriorityId", "dbo.TicketPriorities");
            DropForeignKey("dbo.TicketNotifications", "UserId", "dbo.Users");
            DropForeignKey("dbo.TicketNotifications", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketHistories", "UserId", "dbo.Users");
            DropForeignKey("dbo.TicketHistories", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketComments", "UserId", "dbo.Users");
            DropForeignKey("dbo.TicketComments", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketAttachments", "UserId", "dbo.Users");
            DropForeignKey("dbo.TicketAttachments", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Tickets", "OwnerUserId", "dbo.Users");
            DropForeignKey("dbo.Tickets", "AssignedToUserId", "dbo.Users");
            DropForeignKey("dbo.ProjectUsers", "ProjectId", "dbo.Projects");
            DropIndex("dbo.RolesUsers", new[] { "Users_Id" });
            DropIndex("dbo.RolesUsers", new[] { "Roles_Id" });
            DropIndex("dbo.UserLongins", new[] { "Users_Id" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.TicketNotifications", new[] { "UserId" });
            DropIndex("dbo.TicketNotifications", new[] { "TicketId" });
            DropIndex("dbo.TicketHistories", new[] { "TicketId" });
            DropIndex("dbo.TicketHistories", new[] { "UserId" });
            DropIndex("dbo.TicketComments", new[] { "UserId" });
            DropIndex("dbo.TicketComments", new[] { "TicketId" });
            DropIndex("dbo.TicketAttachments", new[] { "UserId" });
            DropIndex("dbo.TicketAttachments", new[] { "TicketId" });
            DropIndex("dbo.Tickets", new[] { "Users_Id1" });
            DropIndex("dbo.Tickets", new[] { "Users_Id" });
            DropIndex("dbo.Tickets", new[] { "AssignedToUserId" });
            DropIndex("dbo.Tickets", new[] { "OwnerUserId" });
            DropIndex("dbo.Tickets", new[] { "TicketStatusId" });
            DropIndex("dbo.Tickets", new[] { "TicketPriorityId" });
            DropIndex("dbo.Tickets", new[] { "TicketTypeId" });
            DropIndex("dbo.Tickets", new[] { "ProjectId" });
            DropIndex("dbo.ProjectUsers", new[] { "UserId" });
            DropIndex("dbo.ProjectUsers", new[] { "ProjectId" });
            DropIndex("dbo.Projects", new[] { "Users_Id" });
            DropTable("dbo.RolesUsers");
            DropTable("dbo.UserLongins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Roles");
            DropTable("dbo.TicketTypes");
            DropTable("dbo.TicketStatuses");
            DropTable("dbo.TicketPriorities");
            DropTable("dbo.TicketNotifications");
            DropTable("dbo.TicketHistories");
            DropTable("dbo.TicketComments");
            DropTable("dbo.TicketAttachments");
            DropTable("dbo.Tickets");
            DropTable("dbo.Users");
            DropTable("dbo.ProjectUsers");
            DropTable("dbo.Projects");
        }
    }
}
