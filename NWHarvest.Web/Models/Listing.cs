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
        
        [Required]
        [DisplayName("Product")]
        public string product { get; set; }

        [Required]
        [DisplayName("Quantity Available")]
        public decimal? qtyOffered { get; set; }

        [DisplayName("Quantity Claimed")]
        public decimal? qtyClaimed { get; set; }

        [Required]
        [DisplayName("Unit of Measure")]
        [StringLength(100)]
        public string qtyLabel { get; set; }

        [Column(TypeName ="date")]
        [DisplayName("Harvested Date")]
        public DateTime? harvested_date { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [DisplayName("Expiration Date")]
        public DateTime? expire_date { get; set; }

        [Required]
        [DisplayName("Cost/Unit")]
        public decimal? cost { get; set; }

        [DisplayName("Is Available")]
        public bool? available { get; set; }

        [DisplayName("Notes")]
        public string comments { get; set; }


        [DisplayName("Grower")]
        public virtual Grower Grower { get; set; }

        [DisplayName("FoodBank")]
        public virtual FoodBank FoodBank { get; set; }

        [DisplayName("Pickup Location")]
        public virtual PickupLocation PickupLocation { get; set; }
    }
}
