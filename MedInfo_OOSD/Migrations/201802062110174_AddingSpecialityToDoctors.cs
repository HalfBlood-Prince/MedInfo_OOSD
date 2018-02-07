namespace MedInfo_OOSD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingSpecialityToDoctors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Specialities",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Doctors", "SpecialityId", c => c.Short(nullable: false));
            CreateIndex("dbo.Doctors", "SpecialityId");
            AddForeignKey("dbo.Doctors", "SpecialityId", "dbo.Specialities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "SpecialityId", "dbo.Specialities");
            DropIndex("dbo.Doctors", new[] { "SpecialityId" });
            DropColumn("dbo.Doctors", "SpecialityId");
            DropTable("dbo.Specialities");
        }
    }
}
