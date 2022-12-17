namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTableTokenTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        user_id = c.Int(nullable: false, identity: true),
                        user_name = c.String(),
                        password = c.String(),
                        role = c.String(),
                    })
                .PrimaryKey(t => t.user_id);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        token_id = c.Int(nullable: false, identity: true),
                        user_id = c.Int(nullable: false),
                        token_key = c.String(),
                        created = c.DateTime(nullable: false),
                        expired = c.DateTime(),
                    })
                .PrimaryKey(t => t.token_id)
                .ForeignKey("dbo.Users", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id);
            
            AddColumn("dbo.Admins", "user_id", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "user_id", c => c.Int(nullable: false));
            AddColumn("dbo.Couriers", "user_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Admins", "user_id");
            CreateIndex("dbo.Couriers", "user_id");
            CreateIndex("dbo.Customers", "user_id");
            AddForeignKey("dbo.Customers", "user_id", "dbo.Users", "user_id", cascadeDelete: false);
            AddForeignKey("dbo.Couriers", "user_id", "dbo.Users", "user_id", cascadeDelete: false);
            AddForeignKey("dbo.Admins", "user_id", "dbo.Users", "user_id", cascadeDelete: false);
            DropColumn("dbo.Admins", "token");
            DropColumn("dbo.Customers", "token");
            DropColumn("dbo.Couriers", "token");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Couriers", "token", c => c.String());
            AddColumn("dbo.Customers", "token", c => c.String());
            AddColumn("dbo.Admins", "token", c => c.String());
            DropForeignKey("dbo.Admins", "user_id", "dbo.Users");
            DropForeignKey("dbo.Tokens", "user_id", "dbo.Users");
            DropForeignKey("dbo.Couriers", "user_id", "dbo.Users");
            DropForeignKey("dbo.Customers", "user_id", "dbo.Users");
            DropIndex("dbo.Tokens", new[] { "user_id" });
            DropIndex("dbo.Customers", new[] { "user_id" });
            DropIndex("dbo.Couriers", new[] { "user_id" });
            DropIndex("dbo.Admins", new[] { "user_id" });
            DropColumn("dbo.Couriers", "user_id");
            DropColumn("dbo.Customers", "user_id");
            DropColumn("dbo.Admins", "user_id");
            DropTable("dbo.Tokens");
            DropTable("dbo.Users");
        }
    }
}
