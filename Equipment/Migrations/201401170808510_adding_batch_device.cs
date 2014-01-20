namespace Equipment.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    
    public partial class adding_batch_device : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Batch", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "Batch");
        }
    }
}
