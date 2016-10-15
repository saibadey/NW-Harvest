namespace NWHarvest.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PickupLocation")]
    public partial class PickupLocation
    {
        public int id { get; set; }

        public string description { get; set; }

        public decimal? latlong { get; set; }

        public int? growerId { get; set; }
    }
}
