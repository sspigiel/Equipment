namespace Equipment.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    
    public partial class Adding_DataTimes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Start", c => c.DateTime());
            AddColumn("dbo.Devices", "End", c => c.DateTime());
            AlterColumn("dbo.Devices", "Batch", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Devices", "Batch", c => c.String());
            DropColumn("dbo.Devices", "End");
            DropColumn("dbo.Devices", "Start");
        }
    }
}
