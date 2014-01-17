namespace Equipment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseModification3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Devices", "Start");
            DropColumn("dbo.Devices", "Finish");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Devices", "Finish", c => c.DateTime(nullable: false));
            AddColumn("dbo.Devices", "Start", c => c.DateTime(nullable: false));
        }
    }
}
