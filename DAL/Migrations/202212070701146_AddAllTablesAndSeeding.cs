namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAllTablesAndSeeding : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        admin_id = c.Int(nullable: false, identity: true),
                        admin_name = c.String(nullable: false, maxLength: 100),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                        contact = c.String(nullable: false),
                        token = c.String(),
                    })
                .PrimaryKey(t => t.admin_id);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        cart_id = c.Int(nullable: false, identity: true),
                        customer_id = c.Int(nullable: false),
                        item_id = c.Int(nullable: false),
                        total_price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.cart_id)
                .ForeignKey("dbo.Customers", t => t.customer_id, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.item_id, cascadeDelete: true)
                .Index(t => t.customer_id)
                .Index(t => t.item_id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        customer_id = c.Int(nullable: false, identity: true),
                        customer_name = c.String(nullable: false, maxLength: 100),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                        contact = c.String(nullable: false),
                        location = c.String(nullable: false),
                        token = c.String(),
                    })
                .PrimaryKey(t => t.customer_id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        order_id = c.Int(nullable: false, identity: true),
                        customer_id = c.Int(nullable: false),
                        item_id = c.Int(nullable: false),
                        total_price = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                        delivered_by = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.order_id)
                .ForeignKey("dbo.Couriers", t => t.delivered_by, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.customer_id, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.item_id, cascadeDelete: true)
                .Index(t => t.customer_id)
                .Index(t => t.item_id)
                .Index(t => t.delivered_by);
            
            CreateTable(
                "dbo.Couriers",
                c => new
                    {
                        courier_id = c.Int(nullable: false, identity: true),
                        courier_name = c.String(nullable: false, maxLength: 100),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                        contact = c.String(nullable: false),
                        location = c.String(nullable: false),
                        income = c.Int(nullable: false),
                        token = c.String(),
                    })
                .PrimaryKey(t => t.courier_id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        item_id = c.Int(nullable: false, identity: true),
                        item_name = c.String(nullable: false),
                        stock = c.Int(nullable: false),
                        unit_price = c.Int(nullable: false),
                        man_date = c.DateTime(nullable: false),
                        exp_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.item_id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        sales_id = c.Int(nullable: false, identity: true),
                        expense = c.Int(nullable: false),
                        revenue = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.sales_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "item_id", "dbo.Items");
            DropForeignKey("dbo.Carts", "customer_id", "dbo.Customers");
            DropForeignKey("dbo.Orders", "item_id", "dbo.Items");
            DropForeignKey("dbo.Orders", "customer_id", "dbo.Customers");
            DropForeignKey("dbo.Orders", "delivered_by", "dbo.Couriers");
            DropIndex("dbo.Orders", new[] { "delivered_by" });
            DropIndex("dbo.Orders", new[] { "item_id" });
            DropIndex("dbo.Orders", new[] { "customer_id" });
            DropIndex("dbo.Carts", new[] { "item_id" });
            DropIndex("dbo.Carts", new[] { "customer_id" });
            DropTable("dbo.Sales");
            DropTable("dbo.Items");
            DropTable("dbo.Couriers");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Carts");
            DropTable("dbo.Admins");
        }
    }
}
