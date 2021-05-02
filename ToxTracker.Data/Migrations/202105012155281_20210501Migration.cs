namespace ToxTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210501Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Standard", "RecDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Standard", "RecDate");
        }
    }
}
