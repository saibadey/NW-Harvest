using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NWHarvest.Web.Models
{
    public class ListingsRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<Listing> GetAllAvailable()
        {
            return (from b in db.Listings
                        where b.available == true
                        select b).ToList();
        }
        public IEnumerable<Listing> GetAvailableByGrower(int growerId)
        {
            return (from b in db.Listings
                    where b.available == true & b.Grower.Id == growerId
                    select b).ToList();
        }

        public IEnumerable<Listing> GetAllUnavailableExpired(int daysSinceCreation)
        {
            var oldestAcceptableDate = DateTime.Now.AddDays(-daysSinceCreation);
            var currentDate = DateTime.Now;
            return (from b in db.Listings
                    where((b.available == false 
                    || b.expire_date < currentDate)
                    & b.expire_date > oldestAcceptableDate)
                    select b).ToList();
        }

        public IEnumerable<Listing> GetUnavailableExpired(int growerId, int daysSinceCreation)
        {
            var oldestAcceptableDate = DateTime.Now.AddDays(-daysSinceCreation);
            var currentDate = DateTime.Now;
            return (from b in db.Listings
                    where ((b.available == false
                    || b.expire_date < currentDate)
                    & b.expire_date > oldestAcceptableDate
                    & b.Grower.Id == growerId)
                    select b).ToList();
        }

        public IEnumerable<Listing> GetClaimedByFoodBank(int foodBankId, int daysSinceCreation)
        {
            var oldestAcceptableDate = DateTime.Now.AddDays(-daysSinceCreation);    
            return (from b in db.Listings
                    where (b.available == false
                    & b.expire_date > oldestAcceptableDate
                    & b.FoodBank.Id == foodBankId)
                    select b).ToList();
        }
    }
}