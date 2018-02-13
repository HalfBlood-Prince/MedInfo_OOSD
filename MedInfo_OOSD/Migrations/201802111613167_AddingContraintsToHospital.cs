namespace MedInfo_OOSD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingContraintsToHospital : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Hospitals", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Hospitals", "SpecialityId", "dbo.Specialities");
            DropIndex("dbo.Hospitals", new[] { "ApplicationUserId" });
            DropPrimaryKey("dbo.Hospitals");
            AlterColumn("dbo.Hospitals", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Hospitals", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Hospitals", "Email", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Hospitals", "HospitalAddress", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Hospitals", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Hospitals", "Id");
            CreateIndex("dbo.Hospitals", "ApplicationUserId");
            AddForeignKey("dbo.Hospitals", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Hospitals", "SpecialityId", "dbo.Specialities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hospitals", "SpecialityId", "dbo.Specialities");
            DropForeignKey("dbo.Hospitals", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Hospitals", new[] { "ApplicationUserId" });
            DropPrimaryKey("dbo.Hospitals");
            AlterColumn("dbo.Hospitals", "ApplicationUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Hospitals", "HospitalAddress", c => c.String());
            AlterColumn("dbo.Hospitals", "Email", c => c.String());
            AlterColumn("dbo.Hospitals", "Name", c => c.String());
            AlterColumn("dbo.Hospitals", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Hospitals", "Id");
            CreateIndex("dbo.Hospitals", "ApplicationUserId");
            AddForeignKey("dbo.Hospitals", "SpecialityId", "dbo.Specialities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Hospitals", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
