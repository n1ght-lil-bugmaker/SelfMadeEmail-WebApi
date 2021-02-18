namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersAdded : DbMigration
    {
        public override void Up()
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
            
            AddColumn("dbo.Emails", "Source_Id", c => c.Int());
            AddColumn("dbo.Emails", "Target_Id", c => c.Int());
            CreateIndex("dbo.Emails", "Source_Id");
            CreateIndex("dbo.Emails", "Target_Id");
            AddForeignKey("dbo.Emails", "Source_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Emails", "Target_Id", "dbo.Users", "Id");
            DropColumn("dbo.Emails", "Source");
            DropColumn("dbo.Emails", "Target");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Emails", "Target", c => c.String());
            AddColumn("dbo.Emails", "Source", c => c.String());
            DropForeignKey("dbo.Emails", "Target_Id", "dbo.Users");
            DropForeignKey("dbo.Emails", "Source_Id", "dbo.Users");
            DropIndex("dbo.Emails", new[] { "Target_Id" });
            DropIndex("dbo.Emails", new[] { "Source_Id" });
            DropColumn("dbo.Emails", "Target_Id");
            DropColumn("dbo.Emails", "Source_Id");
            DropTable("dbo.Users");
        }
    }
}
