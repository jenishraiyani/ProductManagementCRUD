namespace ProductManagmentCRUD.Migrations
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
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Description = c.String(),
                        IsActive = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsInStock = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrdersId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrdersId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(maxLength: 20),
                        LastName = c.String(maxLength: 20),
                        MobilePhone = c.String(),
                        Email = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.CustomerAddressses",
                c => new
                    {
                        CustomerAddressId = c.Int(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        PostalCode = c.Int(nullable: false),
                        State = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.CustomerAddressId)
                .ForeignKey("dbo.Customers", t => t.CustomerAddressId)
                .Index(t => t.CustomerAddressId);
            
            CreateTable(
                "dbo.OrderDetails1",
                c => new
                    {
                        OrderDetailsId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailsId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrdersId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrdersId, t.ProductId })
                .ForeignKey("dbo.Orders", t => t.OrdersId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrdersId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails1", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails1", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrdersId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerAddressses", "CustomerAddressId", "dbo.Customers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrdersId" });
            DropIndex("dbo.OrderDetails1", new[] { "OrderId" });
            DropIndex("dbo.OrderDetails1", new[] { "ProductId" });
            DropIndex("dbo.CustomerAddressses", new[] { "CustomerAddressId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.OrderDetails");
            DropTable("dbo.OrderDetails1");
            DropTable("dbo.CustomerAddressses");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
