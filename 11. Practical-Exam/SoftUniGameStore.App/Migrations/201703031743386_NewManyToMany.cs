namespace SoftUniGameStore.App.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class NewManyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "User_Id", "dbo.Users");
            DropIndex("dbo.Games", new[] { "User_Id" });
            CreateTable(
                "dbo.UserGames",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Game_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Game_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Game_Id);
            
            DropColumn("dbo.Games", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "User_Id", c => c.Int());
            DropForeignKey("dbo.UserGames", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.UserGames", "User_Id", "dbo.Users");
            DropIndex("dbo.UserGames", new[] { "Game_Id" });
            DropIndex("dbo.UserGames", new[] { "User_Id" });
            DropTable("dbo.UserGames");
            CreateIndex("dbo.Games", "User_Id");
            AddForeignKey("dbo.Games", "User_Id", "dbo.Users", "Id");
        }
    }
}
