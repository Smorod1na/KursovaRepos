namespace MyStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourMigRo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "ManagerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "ManagerId");
        }
    }
}
