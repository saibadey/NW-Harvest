namespace NWHarvest.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Listing")]
    public partial class Listing
    {
        public int id { get; set; }
        
        [DisplayName("Product")]
        public string product { get; set; }

        [DisplayName("Quantity Available")]
        public decimal? qtyOffered { get; set; }

        [DisplayName("Quantity Claimed")]
        public decimal? qtyClaimed { get; set; }

        [DisplayName("Quantity Label")]
        [StringLength(100)]
        public string qtyLabel { get; set; }

        [Column(TypeName ="date")]
        [DisplayName("Harvested Date")]
        public DateTime? harvested_date { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Expiration Date")]
        public DateTime? expire_date { get; set; }

        [DisplayName("Cost")]
        public decimal? cost { get; set; }

        [DisplayName("Is Available")]
        public bool? available { get; set; }

        [DisplayName("Schedule Pickup")]
        public string comments { get; set; }

        [DisplayName("Location")]
        public string location { get; set; }

        [DisplayName("Grower")]
        public virtual Grower Grower { get; set; }

        [DisplayName("FoodBank")]
        public virtual FoodBank FoodBank { get; set; }

        [DisplayName("Pickup Location")]
        public virtual PickupLocation PickupLocation { get; set; }
    }
}
