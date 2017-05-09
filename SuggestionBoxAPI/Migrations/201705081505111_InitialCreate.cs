namespace SuggestionBoxAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Suggestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.Int(nullable: false),
                        UserName = c.String(),
                        Email = c.String(),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        IdTypeSuggestion = c.Int(nullable: false),
                        TypeOfSuggestion_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeSuggestions", t => t.TypeOfSuggestion_Id)
                .Index(t => t.TypeOfSuggestion_Id);
            
            CreateTable(
                "dbo.TypeSuggestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Caption = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Suggestions", "TypeOfSuggestion_Id", "dbo.TypeSuggestions");
            DropIndex("dbo.Suggestions", new[] { "TypeOfSuggestion_Id" });
            DropTable("dbo.TypeSuggestions");
            DropTable("dbo.Suggestions");
        }
    }
}
