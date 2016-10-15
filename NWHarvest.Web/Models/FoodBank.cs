namespace NWHarvest.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FoodBank")]
    public partial class FoodBank
    {
        public int id { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(11)]
        public string phone { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        public decimal? latlong { get; set; }
    }
}
