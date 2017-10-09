namespace DatingsiteSpice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Madeitbetter : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Profiels", newName: "Profiles");
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Image = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Interests = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Profiles", "ImageID_ID", c => c.Int());
            AddColumn("dbo.Profiles", "InterestsID_ID", c => c.Int());
            CreateIndex("dbo.Profiles", "ImageID_ID");
            CreateIndex("dbo.Profiles", "InterestsID_ID");
            AddForeignKey("dbo.Profiles", "ImageID_ID", "dbo.Pictures", "ID");
            AddForeignKey("dbo.Profiles", "InterestsID_ID", "dbo.Interests", "ID");
            DropColumn("dbo.Profiles", "Interests");
            DropColumn("dbo.Profiles", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "Image", c => c.String());
            AddColumn("dbo.Profiles", "Interests", c => c.String());
            DropForeignKey("dbo.Profiles", "InterestsID_ID", "dbo.Interests");
            DropForeignKey("dbo.Profiles", "ImageID_ID", "dbo.Pictures");
            DropIndex("dbo.Profiles", new[] { "InterestsID_ID" });
            DropIndex("dbo.Profiles", new[] { "ImageID_ID" });
            DropColumn("dbo.Profiles", "InterestsID_ID");
            DropColumn("dbo.Profiles", "ImageID_ID");
            DropTable("dbo.Interests");
            DropTable("dbo.Pictures");
            RenameTable(name: "dbo.Profiles", newName: "Profiels");
        }
    }
}
