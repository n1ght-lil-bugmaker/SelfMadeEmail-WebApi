namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Emails", "Source_Id", "dbo.Users");
            DropForeignKey("dbo.Emails", "Target_Id", "dbo.Users");
            DropIndex("dbo.Emails", new[] { "Source_Id" });
            DropIndex("dbo.Emails", new[] { "Target_Id" });
            AddColumn("dbo.Emails", "Source", c => c.String());
            AddColumn("dbo.Emails", "Target", c => c.String());
            AddColumn("dbo.Emails", "Theme", c => c.String());
            DropColumn("dbo.Emails", "Source_Id");
            DropColumn("dbo.Emails", "Target_Id");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        EmailAdress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Emails", "Target_Id", c => c.Int());
            AddColumn("dbo.Emails", "Source_Id", c => c.Int());
            DropColumn("dbo.Emails", "Theme");
            DropColumn("dbo.Emails", "Target");
            DropColumn("dbo.Emails", "Source");
            CreateIndex("dbo.Emails", "Target_Id");
            CreateIndex("dbo.Emails", "Source_Id");
            AddForeignKey("dbo.Emails", "Target_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Emails", "Source_Id", "dbo.Users", "Id");
        }
    }
}
