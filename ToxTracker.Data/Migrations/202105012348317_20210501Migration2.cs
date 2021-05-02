namespace ToxTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210501Migration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Standard", "CatNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Standard", "CatNumber", c => c.String(nullable: false));
        }
    }
}
