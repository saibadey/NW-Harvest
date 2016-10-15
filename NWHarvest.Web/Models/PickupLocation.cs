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

        [StringLength(50)]
        public string name { get; set; }

        public int? growerId { get; set; }

        public decimal? latitude { get; set; }

        public decimal? longitude { get; set; }

        [StringLength(200)]
        public string address1 { get; set; }

        [StringLength(200)]
        public string address2 { get; set; }

        [StringLength(200)]
        public string address3 { get; set; }

        [StringLength(200)]
        public string address4 { get; set; }

        [StringLength(100)]
        public string city { get; set; }

        [StringLength(2)]
        public string state { get; set; }

        [StringLength(9)]
        public string zip { get; set; }

        public string comments { get; set; }

        public virtual Grower Grower { get; set; }
    }
}
