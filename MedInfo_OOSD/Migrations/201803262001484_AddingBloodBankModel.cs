namespace MedInfo_OOSD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingBloodBankModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BloodBanks",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Email = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 255),
                        AvailableDays = c.String(nullable: false, maxLength: 255),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        IsApproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BloodBanks", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.BloodBanks", new[] { "ApplicationUserId" });
            DropTable("dbo.BloodBanks");
        }
    }
}
