namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sprintv30 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Slug", c => c.String());
            AlterColumn("dbo.Courses", "Slug", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Slug", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Slug", c => c.String(nullable: false));
        }
    }
}
