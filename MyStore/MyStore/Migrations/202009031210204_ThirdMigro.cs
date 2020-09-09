namespace MyStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigro : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Roles", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "Name", c => c.String());
        }
    }
}
