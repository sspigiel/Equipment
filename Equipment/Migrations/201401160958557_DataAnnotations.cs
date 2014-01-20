namespace Equipment.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE [dbo].[Devices] SET DeviceManufacturer = 'Null' WHERE DeviceManufacturer IS NULL");
            AlterColumn("dbo.Devices", "DeviceManufacturer", c => c.String(nullable: false,defaultValue:"Null"));
            AlterColumn("dbo.Devices", "DeviceName", c => c.String(nullable: false, defaultValue: "Null"));
            AlterColumn("dbo.Devices", "DeviceSerialNumber", c => c.String(nullable: false, defaultValue: "Null"));
            AlterColumn("dbo.Devices", "DeviceUser", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Devices", "DeviceUser", c => c.String());
            AlterColumn("dbo.Devices", "DeviceSerialNumber", c => c.String());
            AlterColumn("dbo.Devices", "DeviceName", c => c.String());
            AlterColumn("dbo.Devices", "DeviceManufacturer", c => c.String());
        }
    }
}
