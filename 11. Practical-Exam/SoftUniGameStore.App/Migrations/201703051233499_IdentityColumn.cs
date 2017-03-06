namespace SoftUniGameStore.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserGames", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Sessions", "UserId", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "Id");
            AddForeignKey("dbo.UserGames", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sessions", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessions", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserGames", "User_Id", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Users", "Id");
            AddForeignKey("dbo.Sessions", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserGames", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
