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

    public class ListingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private const int DAY_LIMIT_FOR_GROWERS = 31;
        private const int DAY_LIMIT_FOR_FOOD_BANKS = 31;
        private const int DAY_LIMIT_FOR_ADMINISTRATORS = 180;

        // GET: Listings
        public ActionResult Index()
        {
            var registeredUserService = new RegisteredUserService();
            var user = registeredUserService.GetRegisteredUser(this.User);

            var repo = new ListingsRepository();
            var viewLists = new ViewLists();
            viewLists.registeredUser = user;

            if (user.Role == "admin")
            {
                viewLists.TopList = repo.GetAllAvailable();
                viewLists.BottomList = repo.GetAllUnavailableExpired(DAY_LIMIT_FOR_ADMINISTRATORS);
            }

            else if (user.Role == "grower")
            {
                viewLists.TopList = repo.GetAvailableByGrower(user.GrowerId);
                viewLists.BottomList = repo.GetUnavailableExpired(user.GrowerId, DAY_LIMIT_FOR_GROWERS);
            }

            else if (user.Role == "foodBank")
            {
                viewLists.TopList = repo.GetAllAvailable();
                viewLists.BottomList = repo.GetClaimedByFoodBank(user.FoodBankId, DAY_LIMIT_FOR_FOOD_BANKS);
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
            ViewBag.grower = new SelectList(db.Growers, "id", "name");
            ViewBag.growerName = "the grower";
            return View();
        }

        // POST: Listings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,product,qtyOffered,qtyClaimed,qtyLabel,expire_date,cost,available,comments")] Listing listing)
        {
            var service = new RegisteredUserService();
            var user = service.GetRegisteredUser(this.User);

            var grower = (from b in db.Growers
                            where b.Id == user.GrowerId
                            select b).FirstOrDefault();

            listing.Grower = grower;

            if (ModelState.IsValid)
            {
                db.Listings.Add(listing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            //ViewBag.grower = new SelectList(db.Growers, "id", "name", listing.Grower.Id);
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
            ViewBag.grower = new SelectList(db.Growers, "id", "name", listing.Grower.Id);
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
            //ViewBag.grower = new SelectList(db.Growers, "id", "name", listing.Grower.Id);
            return View(listing);
        }


        // POST: Listings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,product,qtyOffered,qtyClaimed,qtyLabel,expire_date,cost,available,comments")] Listing listing)
        {


            if (ModelState.IsValid)
            {
                db.Entry(listing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.grower = new SelectList(db.Growers, "id", "name", listing.Grower.Id);
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

                var service = new RegisteredUserService();
                var user = service.GetRegisteredUser(this.User);

                var foodBank = (from b in db.FoodBanks
                                where b.Id == user.FoodBankId
                                select b).FirstOrDefault();

                listing.FoodBank = foodBank;

                listing.comments = theComments;
                listing.available = false;

                db.Entry(listing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Grower = new SelectList(db.Growers, "id", "name", listing.Grower.Id);
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
