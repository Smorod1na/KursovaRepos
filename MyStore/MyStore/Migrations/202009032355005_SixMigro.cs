namespace MyStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SixMigro : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "Category");
            AlterColumn("dbo.News", "ManagerId", c => c.String());
            AlterColumn("dbo.News", "Pfoto", c => c.String(nullable: false));
            AlterColumn("dbo.News", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.News", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.News", "Description", c => c.String());
            AlterColumn("dbo.News", "Name", c => c.String());
            AlterColumn("dbo.News", "Pfoto", c => c.String());
            AlterColumn("dbo.News", "ManagerId", c => c.Int(nullable: false));
            RenameTable(name: "dbo.Category", newName: "Categories");
        }
    }
}
