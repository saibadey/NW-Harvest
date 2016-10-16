using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace NWHarvest.Web.Models
{
    public class ListingViewModel
    {
        ListingsRepository repo = new ListingsRepository();

        public IEnumerable<SelectListItem> PickupLocations
        {

            get
            {
                if (this.Grower != null)
                {
                    IEnumerable<PickupLocation> allLocs = repo.GetAllPickupLocations(this.Grower.Id);
                    IEnumerable<SelectListItem> listItems = allLocs.Select(pl => new SelectListItem() { Value = pl.id.ToString(), Text = pl.name });
                    return listItems;
                }

                return new List<SelectListItem>();
            }
        }
        public int id { get; set; }
        [DataType(DataType.Text)]
        public string SavedLocationId { get; set; }

        [DisplayName("Product")]
        public string product { get; set; }

        [DisplayName("Quantity Available")]
        public decimal? qtyOffered { get; set; }

        [DisplayName("Quantity Claimed")]
        public decimal? qtyClaimed { get; set; }

        [DisplayName("Unit of Measure")]
        [StringLength(100)]
        public string qtyLabel { get; set; }

        [Column(TypeName = "date")]
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

        [DisplayName("Grower")]
        public virtual Grower Grower { get; set; }

        [DisplayName("FoodBank")]
        public virtual FoodBank FoodBank { get; set; }

        [DisplayName("Pickup Location")]
        public virtual PickupLocation PickupLocation
        {
            get
            {
                if (String.IsNullOrWhiteSpace(this.SavedLocationId) == false)
                {
                    IEnumerable<PickupLocation> allLocs = repo.GetAllPickupLocations(this.Grower.Id);
                    return allLocs.Where(l => l.id == int.Parse(this.SavedLocationId)).FirstOrDefault();
                }

                return new PickupLocation();
            }
            set
            {
                if (value != null)
                {
                    this.SavedLocationId = value.id.ToString();
                }
                else
                {
                    this.SavedLocationId = null;
                }
            }
        }
    }
}