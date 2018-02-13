namespace MedInfo_OOSD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCommentDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommentDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "CommentDateTime");
        }
    }
}
