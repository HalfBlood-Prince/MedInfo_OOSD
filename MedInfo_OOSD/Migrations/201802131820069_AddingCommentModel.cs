namespace MedInfo_OOSD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCommentModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecordId = c.Guid(nullable: false),
                        PostComment = c.String(nullable: false, maxLength: 255),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "ApplicationUserId" });
            DropTable("dbo.Comments");
        }
    }
}
