namespace NWHarvest.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameFarmerGrower : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Farmer", newName: "Grower");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Grower", newName: "Farmer");
        }
    }
}
