namespace ForumMVC.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Topics", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Replies", "Topic_Id", "dbo.Topics");
            DropIndex("dbo.Topics", new[] { "Category_Id" });
            DropIndex("dbo.Replies", new[] { "Topic_Id" });
            RenameColumn(table: "dbo.Topics", name: "Category_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.Replies", name: "Topic_Id", newName: "TopicId");
            AlterColumn("dbo.Topics", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Replies", "TopicId", c => c.Int(nullable: false));
            CreateIndex("dbo.Topics", "CategoryId");
            CreateIndex("dbo.Replies", "TopicId");
            AddForeignKey("dbo.Topics", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Replies", "TopicId", "dbo.Topics", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replies", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Topics", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Replies", new[] { "TopicId" });
            DropIndex("dbo.Topics", new[] { "CategoryId" });
            AlterColumn("dbo.Replies", "TopicId", c => c.Int());
            AlterColumn("dbo.Topics", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Replies", name: "TopicId", newName: "Topic_Id");
            RenameColumn(table: "dbo.Topics", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Replies", "Topic_Id");
            CreateIndex("dbo.Topics", "Category_Id");
            AddForeignKey("dbo.Replies", "Topic_Id", "dbo.Topics", "Id");
            AddForeignKey("dbo.Topics", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
