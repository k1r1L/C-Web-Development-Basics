namespace ForumMVC.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30),
                        Content = c.String(nullable: false, maxLength: 500),
                        PostedOn = c.DateTime(nullable: false),
                        Author_Id = c.Int(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        ImageUrl = c.String(),
                        PostedOn = c.DateTime(nullable: false),
                        Author_Id = c.Int(),
                        Topic_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .ForeignKey("dbo.Topics", t => t.Topic_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Topic_Id);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logins", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Replies", "Topic_Id", "dbo.Topics");
            DropForeignKey("dbo.Replies", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.Topics", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Topics", "Author_Id", "dbo.Users");
            DropIndex("dbo.Logins", new[] { "User_Id" });
            DropIndex("dbo.Replies", new[] { "Topic_Id" });
            DropIndex("dbo.Replies", new[] { "Author_Id" });
            DropIndex("dbo.Topics", new[] { "Category_Id" });
            DropIndex("dbo.Topics", new[] { "Author_Id" });
            DropTable("dbo.Logins");
            DropTable("dbo.Replies");
            DropTable("dbo.Users");
            DropTable("dbo.Topics");
            DropTable("dbo.Categories");
        }
    }
}
