namespace CRUD_APPLICATION.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCategoryListTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryLists",
                c => new
                    {
                        Productid = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.Productid, t.CategoryId })
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Productid, cascadeDelete: true)
                .Index(t => t.Productid)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryLists", "Productid", "dbo.Products");
            DropForeignKey("dbo.CategoryLists", "CategoryId", "dbo.Categories");
            DropIndex("dbo.CategoryLists", new[] { "CategoryId" });
            DropIndex("dbo.CategoryLists", new[] { "Productid" });
            DropTable("dbo.CategoryLists");
        }
    }
}
