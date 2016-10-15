namespace NWHarvest.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPickupLocation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PickupLocation",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        description = c.String(unicode: false),
                        latlong = c.Decimal(precision: 9, scale: 6),
                        growerId = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PickupLocation");
        }
    }
}
