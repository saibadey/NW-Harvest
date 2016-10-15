namespace NWHarvest.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Listing")]
    public partial class Listing
    {
        public int id { get; set; }

        public int listing_farmer { get; set; }

        public string product { get; set; }

        public decimal? qtyOffered { get; set; }

        public decimal? qtyClaimed { get; set; }

        [StringLength(100)]
        public string qtyLabel { get; set; }

        [Column(TypeName = "date")]
        public DateTime? expire_date { get; set; }

        public decimal? cost { get; set; }

        public bool? available { get; set; }

        public string comments { get; set; }

        public virtual Farmer Farmer { get; set; }
    }
}
