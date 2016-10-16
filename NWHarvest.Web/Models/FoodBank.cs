using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity.Spatial;

namespace NWHarvest.Web.Models
{

    [Table("FoodBank")]
    public partial class FoodBank
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(11)]
        public string phone { get; set; }

        [StringLength(100)]
        public string email { get; set; }

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

        public string NoficationPreference { get; set; }

    }
}
