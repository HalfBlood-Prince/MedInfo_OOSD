namespace MedInfo_OOSD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUserIdToDoctors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Doctors", "ApplicationUserId");
            AddForeignKey("dbo.Doctors", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Doctors", new[] { "ApplicationUserId" });
            DropColumn("dbo.Doctors", "ApplicationUserId");
        }
    }
}
