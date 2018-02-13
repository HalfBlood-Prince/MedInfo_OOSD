namespace MedInfo_OOSD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingHospitalModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        HospitalAddress = c.String(),
                        SpecialityId = c.Short(nullable: false),
                        DoesHaveEmergencyWard = c.Boolean(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Specialities", t => t.SpecialityId, cascadeDelete: true)
                .Index(t => t.SpecialityId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hospitals", "SpecialityId", "dbo.Specialities");
            DropForeignKey("dbo.Hospitals", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Hospitals", new[] { "ApplicationUserId" });
            DropIndex("dbo.Hospitals", new[] { "SpecialityId" });
            DropTable("dbo.Hospitals");
        }
    }
}
