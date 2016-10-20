using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NWHarvest.Web.Models;

namespace NWHarvest.Web.Controllers
{
    [Authorize]
    public class PickupLocationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PickupLocations
        public ActionResult Index()
        {
            var registeredUserService = new RegisteredUserService();
            var user = registeredUserService.GetRegisteredUser(this.User);
            ViewBag.userRole = user.Role;


            var pickupLocations = db.PickupLocations.Include(p => p.Grower);
            return View(pickupLocations.ToList());
        }

        // GET: PickupLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickupLocation pickupLocation = db.PickupLocations.Find(id);
            if (pickupLocation == null)
            {
                return HttpNotFound();
            }
            return View(pickupLocation);
        }

        // GET: PickupLocations/Create
        public ActionResult Create()
        {
            ViewBag.growerId = new SelectList(db.Growers, "id", "name");
            return View();
        }

        // POST: PickupLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,growerId,address1,address2,address3,address4,city,state,zip,comments")] PickupLocation pickupLocation)
        {
            if (ModelState.IsValid)
            {
                db.PickupLocations.Add(pickupLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.growerId = new SelectList(db.Growers, "id", "name", pickupLocation.Grower.Id);
            return View(pickupLocation);
        }

        // GET: PickupLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickupLocation pickupLocation = db.PickupLocations.Find(id);
            if (pickupLocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.growerId = new SelectList(db.Growers, "id", "name", pickupLocation.Grower.Id);
            return View(pickupLocation);
        }

        // POST: PickupLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,growerId,address1,address2,address3,address4,city,state,zip,comments")] PickupLocation pickupLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pickupLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.growerId = new SelectList(db.Growers, "id", "name", pickupLocation.Grower.Id);
            return View(pickupLocation);
        }

        // GET: PickupLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickupLocation pickupLocation = db.PickupLocations.Find(id);
            if (pickupLocation == null)
            {
                return HttpNotFound();
            }
            return View(pickupLocation);
        }

        // POST: PickupLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PickupLocation pickupLocation = db.PickupLocations.Find(id);
            db.PickupLocations.Remove(pickupLocation);
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
