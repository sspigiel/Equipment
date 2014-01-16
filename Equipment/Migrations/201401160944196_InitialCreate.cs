namespace Equipment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        DeviceId = c.Int(nullable: false, identity: true),
                        DeviceManufacturer = c.String(),
                        DeviceName = c.String(),
                        DeviceSerialNumber = c.String(),
                        DeviceUser = c.String(),
                    })
                .PrimaryKey(t => t.DeviceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Devices");
        }
    }
}
