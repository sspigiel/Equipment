namespace Equipment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeviceDictionaries",
                c => new
                    {
                        DeviceDictionaryId = c.Int(nullable: false, identity: true),
                        DeviceManufacturer = c.String(nullable: false),
                        DeviceName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DeviceDictionaryId);
            
            AddColumn("dbo.Devices", "DeviceDictionaryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Devices", "DeviceUser", c => c.String(nullable: false, maxLength: 14));
            CreateIndex("dbo.Devices", "DeviceDictionaryId");
            AddForeignKey("dbo.Devices", "DeviceDictionaryId", "dbo.DeviceDictionaries", "DeviceDictionaryId", cascadeDelete: true);
            DropColumn("dbo.Devices", "DeviceManufacturer");
            DropColumn("dbo.Devices", "DeviceName");
            DropColumn("dbo.Devices", "DeviceSerialNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Devices", "DeviceSerialNumber", c => c.String(nullable: false));
            AddColumn("dbo.Devices", "DeviceName", c => c.String(nullable: false));
            AddColumn("dbo.Devices", "DeviceManufacturer", c => c.String(nullable: false));
            DropForeignKey("dbo.Devices", "DeviceDictionaryId", "dbo.DeviceDictionaries");
            DropIndex("dbo.Devices", new[] { "DeviceDictionaryId" });
            AlterColumn("dbo.Devices", "DeviceUser", c => c.String(maxLength: 14));
            DropColumn("dbo.Devices", "DeviceDictionaryId");
            DropTable("dbo.DeviceDictionaries");
        }
    }
}
