namespace BugTrack.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RolesUsers", "Roles_Id", "dbo.Roles");
            DropForeignKey("dbo.RolesUsers", "Users_Id", "dbo.Users");
            DropIndex("dbo.RolesUsers", new[] { "Roles_Id" });
            DropIndex("dbo.RolesUsers", new[] { "Users_Id" });
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        RolesId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RolesId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RolesId);
            
            DropTable("dbo.RolesUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RolesUsers",
                c => new
                    {
                        Roles_Id = c.Guid(nullable: false),
                        Users_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Roles_Id, t.Users_Id });
            
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RolesId", "dbo.Roles");
            DropIndex("dbo.UserRoles", new[] { "RolesId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropTable("dbo.UserRoles");
            CreateIndex("dbo.RolesUsers", "Users_Id");
            CreateIndex("dbo.RolesUsers", "Roles_Id");
            AddForeignKey("dbo.RolesUsers", "Users_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.RolesUsers", "Roles_Id", "dbo.Roles", "Id");
        }
    }
}
