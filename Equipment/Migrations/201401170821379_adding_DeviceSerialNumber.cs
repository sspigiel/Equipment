namespace Equipment.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    
    public partial class adding_DeviceSerialNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "DeviceSerialNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "DeviceSerialNumber");
        }
    }
}
