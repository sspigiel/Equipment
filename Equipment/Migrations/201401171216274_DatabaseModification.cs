namespace Equipment.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseModification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Start", c => c.DateTime(nullable: false));
            AddColumn("dbo.Devices", "Finish", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Devices", "DeviceSerialNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Devices", "DeviceUser", c => c.String(maxLength: 14));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Devices", "DeviceUser", c => c.String(nullable: false, maxLength: 14));
            AlterColumn("dbo.Devices", "DeviceSerialNumber", c => c.String());
            DropColumn("dbo.Devices", "Finish");
            DropColumn("dbo.Devices", "Start");
        }
    }
}
