using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NWHarvest.Web.Models
{
    public class FullListing
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public Listing Listing { get; set; }
        public PickupLocation PickupLocation { get; set; }

        public FullListing(Listing listing)
        {
            this.Listing = listing;
            this.PickupLocation = this.GetPickupLocation();
        }

        private PickupLocation GetPickupLocation()
        {
            return (from b in this.db.PickupLocations
                    where b.id == this.Listing.PickupLocation.id
                    select b).FirstOrDefault();
        }
    }
}