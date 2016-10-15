namespace NWHarvest.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddress : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Listing", "listing_farmer", "dbo.Grower");
            DropIndex("dbo.Listing", new[] { "listing_farmer" });
            AddColumn("dbo.Grower", "address1", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.Grower", "address2", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.Grower", "address3", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.Grower", "address4", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.Grower", "city", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.Grower", "state", c => c.String(maxLength: 2, unicode: false));
            AddColumn("dbo.Grower", "zip", c => c.String(maxLength: 9, unicode: false));
            AddColumn("dbo.Listing", "Farmer_id", c => c.Int());
            AddColumn("dbo.FoodBank", "address1", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.FoodBank", "address2", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.FoodBank", "address3", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.FoodBank", "address4", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.FoodBank", "city", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.FoodBank", "state", c => c.String(maxLength: 2, unicode: false));
            AddColumn("dbo.FoodBank", "zip", c => c.String(maxLength: 9, unicode: false));
            AddColumn("dbo.PickupLocation", "name", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.PickupLocation", "latitude", c => c.Decimal(precision: 9, scale: 6));
            AddColumn("dbo.PickupLocation", "longitude", c => c.Decimal(precision: 9, scale: 6));
            AddColumn("dbo.PickupLocation", "address1", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.PickupLocation", "address2", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.PickupLocation", "address3", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.PickupLocation", "address4", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.PickupLocation", "city", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.PickupLocation", "state", c => c.String(maxLength: 2, unicode: false));
            AddColumn("dbo.PickupLocation", "zip", c => c.String(maxLength: 9, unicode: false));
            AddColumn("dbo.PickupLocation", "comments", c => c.String(unicode: false));
            CreateIndex("dbo.PickupLocation", "growerId");
            CreateIndex("dbo.Listing", "Farmer_id");
            AddForeignKey("dbo.PickupLocation", "growerId", "dbo.Grower", "id");
            AddForeignKey("dbo.Listing", "Farmer_id", "dbo.Grower", "id");
            DropColumn("dbo.FoodBank", "latlong");
            DropColumn("dbo.PickupLocation", "description");
            DropColumn("dbo.PickupLocation", "latlong");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PickupLocation", "latlong", c => c.Decimal(precision: 9, scale: 6));
            AddColumn("dbo.PickupLocation", "description", c => c.String(unicode: false));
            AddColumn("dbo.FoodBank", "latlong", c => c.Decimal(precision: 9, scale: 6));
            DropForeignKey("dbo.Listing", "Farmer_id", "dbo.Grower");
            DropForeignKey("dbo.PickupLocation", "growerId", "dbo.Grower");
            DropIndex("dbo.Listing", new[] { "Farmer_id" });
            DropIndex("dbo.PickupLocation", new[] { "growerId" });
            DropColumn("dbo.PickupLocation", "comments");
            DropColumn("dbo.PickupLocation", "zip");
            DropColumn("dbo.PickupLocation", "state");
            DropColumn("dbo.PickupLocation", "city");
            DropColumn("dbo.PickupLocation", "address4");
            DropColumn("dbo.PickupLocation", "address3");
            DropColumn("dbo.PickupLocation", "address2");
            DropColumn("dbo.PickupLocation", "address1");
            DropColumn("dbo.PickupLocation", "longitude");
            DropColumn("dbo.PickupLocation", "latitude");
            DropColumn("dbo.PickupLocation", "name");
            DropColumn("dbo.FoodBank", "zip");
            DropColumn("dbo.FoodBank", "state");
            DropColumn("dbo.FoodBank", "city");
            DropColumn("dbo.FoodBank", "address4");
            DropColumn("dbo.FoodBank", "address3");
            DropColumn("dbo.FoodBank", "address2");
            DropColumn("dbo.FoodBank", "address1");
            DropColumn("dbo.Listing", "Farmer_id");
            DropColumn("dbo.Grower", "zip");
            DropColumn("dbo.Grower", "state");
            DropColumn("dbo.Grower", "city");
            DropColumn("dbo.Grower", "address4");
            DropColumn("dbo.Grower", "address3");
            DropColumn("dbo.Grower", "address2");
            DropColumn("dbo.Grower", "address1");
            CreateIndex("dbo.Listing", "listing_farmer");
            AddForeignKey("dbo.Listing", "listing_farmer", "dbo.Grower", "id");
        }
    }
}
