namespace Equipment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class annotationUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Devices", "DeviceUser", c => c.String(maxLength: 14));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Devices", "DeviceUser", c => c.String(maxLength: 10));
        }
    }
}
