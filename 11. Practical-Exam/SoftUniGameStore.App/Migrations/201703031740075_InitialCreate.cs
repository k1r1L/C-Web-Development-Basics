namespace SoftUniGameStore.App.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Trailer = c.String(),
                        ImageThumbnail = c.String(),
                        Size = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        FullName = c.String(),
                        Email = c.String(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GameCarts",
                c => new
                    {
                        Game_Id = c.Int(nullable: false),
                        Cart_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Game_Id, t.Cart_Id })
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .ForeignKey("dbo.Carts", t => t.Cart_Id, cascadeDelete: true)
                .Index(t => t.Game_Id)
                .Index(t => t.Cart_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Games", "User_Id", "dbo.Users");
            DropForeignKey("dbo.GameCarts", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.GameCarts", "Game_Id", "dbo.Games");
            DropIndex("dbo.GameCarts", new[] { "Cart_Id" });
            DropIndex("dbo.GameCarts", new[] { "Game_Id" });
            DropIndex("dbo.Sessions", new[] { "UserId" });
            DropIndex("dbo.Games", new[] { "User_Id" });
            DropTable("dbo.GameCarts");
            DropTable("dbo.Users");
            DropTable("dbo.Sessions");
            DropTable("dbo.Games");
            DropTable("dbo.Carts");
        }
    }
}
