namespace SuggestionBoxAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Suggestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        UserName = c.String(),
                        Email = c.String(),
                        Description = c.String(unicode: false, storeType: "text"),
                        CreationDate = c.DateTime(nullable: false, storeType: "date"),
                        StateId = c.Int(nullable: false),
                        TypeSuggestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SuggestionStates", t => t.StateId, cascadeDelete: true)
                .ForeignKey("dbo.TypeSuggestions", t => t.TypeSuggestionId, cascadeDelete: true)
                .Index(t => t.StateId)
                .Index(t => t.TypeSuggestionId);
            
            CreateTable(
                "dbo.SuggestionStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeSuggestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Caption = c.String(),
                        ImageUri = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Suggestions", "TypeSuggestionId", "dbo.TypeSuggestions");
            DropForeignKey("dbo.Suggestions", "StateId", "dbo.SuggestionStates");
            DropIndex("dbo.Suggestions", new[] { "TypeSuggestionId" });
            DropIndex("dbo.Suggestions", new[] { "StateId" });
            DropTable("dbo.TypeSuggestions");
            DropTable("dbo.SuggestionStates");
            DropTable("dbo.Suggestions");
        }
    }
}
