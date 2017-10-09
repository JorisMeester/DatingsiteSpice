namespace DatingsiteSpice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Profiles", name: "ImageID_ID", newName: "Image_ID");
            RenameColumn(table: "dbo.Profiles", name: "InterestsID_ID", newName: "Interests_ID");
            RenameIndex(table: "dbo.Profiles", name: "IX_ImageID_ID", newName: "IX_Image_ID");
            RenameIndex(table: "dbo.Profiles", name: "IX_InterestsID_ID", newName: "IX_Interests_ID");
            AlterColumn("dbo.Pictures", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pictures", "Image", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Profiles", name: "IX_Interests_ID", newName: "IX_InterestsID_ID");
            RenameIndex(table: "dbo.Profiles", name: "IX_Image_ID", newName: "IX_ImageID_ID");
            RenameColumn(table: "dbo.Profiles", name: "Interests_ID", newName: "InterestsID_ID");
            RenameColumn(table: "dbo.Profiles", name: "Image_ID", newName: "ImageID_ID");
        }
    }
}
