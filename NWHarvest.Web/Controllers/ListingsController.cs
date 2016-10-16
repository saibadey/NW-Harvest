using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NWHarvest.Web.Models;

namespace NWHarvest.Web.Controllers
{
    using System.Collections.Generic;
    
    public class ViewLists
    {
        public RegisteredUser registeredUser { get; set; } 
        public IEnumerable<Listing> TopList { get; set; }
        public IEnumerable<Listing> BottomList { get; set; }
    }

    public class RegisteredUser
    {
        public int GrowerId { get; set; }
        public int FoodBankId { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
    }

    public class ListingsController : Controller
    {
        private const int DAY_LIMIT_FOR_GROWERS = 31;
        private const int DAY_LIMIT_FOR_FOOD_BANKS = 31;
        private const int DAY_LIMIT_FOR_ADMINISTRATORS = 180;

        private NWHarvestEntities db = new NWHarvestEntities();

        // GET: Listings
        public ActionResult Index()
        {
            var dummyUser = new RegisteredUser();

            dummyUser.FoodBankId = 1;
            dummyUser.GrowerId = 2;
            dummyUser.Role = "grower";

            if (dummyUser.Role == "admin")
            {
                dummyUser.UserName = "Mr./Mrs. admin";
            }

            if (dummyUser.Role == "grower")
            {
                dummyUser.UserName = "Mr./Mrs. Grower" + dummyUser.GrowerId;
            }

            if (dummyUser.Role == "foodBank")
            {
                dummyUser.UserName = "Mr./Mrs. Food Bank" + dummyUser.FoodBankId;
            }

            var repo = new ListingsRepository();
            var viewLists = new ViewLists();
            viewLists.registeredUser = dummyUser;

            if (dummyUser.Role == "admin")
            {
                viewLists.TopList = repo.GetAllAvailable();
                viewLists.BottomList = repo.GetAllUnavailableExpired(DAY_LIMIT_FOR_ADMINISTRATORS);
            }

            else if (dummyUser.Role == "grower")
            {
                viewLists.TopList = repo.GetAvailableByGrower(dummyUser.GrowerId);
                viewLists.BottomList = repo.GetUnavailableExpired(dummyUser.GrowerId, DAY_LIMIT_FOR_GROWERS);
            }

            else if (dummyUser.Role == "foodBank")
            {
                viewLists.TopList = repo.GetAllAvailable();
                viewLists.BottomList = repo.GetClaimedByFoodBank(dummyUser.FoodBankId, DAY_LIMIT_FOR_FOOD_BANKS);
            }

            return View(viewLists);
        }

        // GET: Listings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        // GET: Listings/Create
        public ActionResult Create()
        {
            ViewBag.listing_farmer = new SelectList(db.Growers, "id", "name");
            return View();
        }

        // POST: Listings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,listing_farmer,product,qtyOffered,qtyClaimed,qtyLabel,expire_date,cost,available,comments")] Listing listing)
        {
            if (ModelState.IsValid)
            {
                db.Listings.Add(listing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.listing_farmer = new SelectList(db.Growers, "id", "name", listing.Grower.id);
            return View(listing);
        }

        // GET: Listings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            ViewBag.listing_farmer = new SelectList(db.Growers, "id", "name", listing.Grower.id);
            return View(listing);
        }

        // GET: Listings/Claim/5
        public ActionResult Claim(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            ViewBag.listing_farmer = new SelectList(db.Growers, "id", "name", listing.Grower.id);
            return View(listing);
        }


        // POST: Listings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,listing_farmer,product,qtyOffered,qtyClaimed,qtyLabel,expire_date,cost,available,comments")] Listing listing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.listing_farmer = new SelectList(db.Growers, "id", "name", listing.Grower.id);
            return View(listing);
        }

        // POST: Listings/Claim/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Claim([Bind(Include = "id,comments")] Listing listing)
        {
            if (ModelState.IsValid)
            {
                var theComments = listing.comments;
                listing = db.Listings.FirstOrDefault(p => p.id == listing.id);

                listing.comments = theComments;
                listing.available = false;

                db.Entry(listing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.listing_farmer = new SelectList(db.Growers, "id", "name", listing.Grower.id);
            return View(listing);
        }

        // GET: Listings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        // POST: Listings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Listing listing = db.Listings.Find(id);
            db.Listings.Remove(listing);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
