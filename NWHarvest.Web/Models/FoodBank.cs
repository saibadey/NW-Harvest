using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NWHarvest.Web.Models
{

    [Table("FoodBank")]
    public partial class FoodBank
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [StringLength(11)]
        public string phone { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        [Required]
        [StringLength(200)]
        public string address1 { get; set; }

        [StringLength(200)]
        public string address2 { get; set; }

        [StringLength(200)]
        public string address3 { get; set; }

        [StringLength(200)]
        public string address4 { get; set; }

        [Required]
        [StringLength(100)]
        public string city { get; set; }

        [Required]
        [StringLength(2)]
        public string state { get; set; }

        [Required]
        [StringLength(9)]
        public string zip { get; set; }

        [Required]
        public string NotificationPreference { get; set; }
    }
}
