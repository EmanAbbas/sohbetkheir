using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

using Gam3iaWeb;

namespace Gam3iaWeb.Controllers
{
    public class PhysicalDonationsController : Controller
    {
        private Gam3iaEntities db = new Gam3iaEntities();

        // GET: PhysicalDonations
        public ActionResult Index()
        {
            var physicalDonation = db.PhysicalDonation.Include(p => p.AspNetUsers).Include(p => p.Donator).Include(p => p.Poor);
            return View(physicalDonation.ToList());
        }

        // GET: PhysicalDonations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhysicalDonation physicalDonation = db.PhysicalDonation.Find(id);
            if (physicalDonation == null)
            {
                return HttpNotFound();
            }
            return View(physicalDonation);
        }

        // GET: PhysicalDonations/Create
        public ActionResult Create()
        {
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName");
            ViewBag.DonatorID = new SelectList(db.Donator, "ID", "DonatorName");
            List<Poor> plist = db.Poor.ToList();
            plist.Insert(0, new Poor() { ID = 0, PoorName = "غير محدد" });
            ViewBag.PoorID = new SelectList(plist, "ID", "PoorName");
            return View();
        }

        // POST: PhysicalDonations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // GET: PhysicalDonations/CreateNew
        public ActionResult CreateNew()
        {
            Session["caller"] = "PDonations";
            return RedirectToAction("Create", "Donators");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DonationType,DeviceName,DeviceState,CanBeFixed,FixFees,ReceiveDate,IsSelled,IsDelivered,SellPrice,SellDate,DonatorID,PoorID")] PhysicalDonation physicalDonation)
        {
            if (physicalDonation.PoorID == 0)
                physicalDonation.PoorID = null;
            if (ModelState.IsValid)
            {
                physicalDonation.VolunteerID = User.Identity.GetUserId();
                db.PhysicalDonation.Add(physicalDonation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", physicalDonation.VolunteerID);
            ViewBag.DonatorID = new SelectList(db.Donator, "ID", "DonatorName", physicalDonation.DonatorID);
            List<Poor> plist = db.Poor.ToList();
            plist.Insert(0, new Poor() { ID = 0, PoorName = "غير محدد" });
            

            ViewBag.PoorID = new SelectList(plist, "ID", "PoorName", physicalDonation.PoorID);
            return View(physicalDonation);
        }

        // GET: PhysicalDonations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhysicalDonation physicalDonation = db.PhysicalDonation.Find(id);
            if (physicalDonation == null)
            {
                return HttpNotFound();
            }
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", physicalDonation.VolunteerID);
            ViewBag.DonatorID = new SelectList(db.Donator, "ID", "DonatorName", physicalDonation.DonatorID);
            List<Poor> plist = db.Poor.ToList();
            plist.Insert(0, new Poor() { ID = 0, PoorName = "غير محدد" });
            ViewBag.PoorID = new SelectList(plist, "ID", "PoorName", physicalDonation.PoorID);
            
            return View(physicalDonation);
        }

        // POST: PhysicalDonations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DonationType,DeviceName,DeviceState,CanBeFixed,FixFees,ReceiveDate,IsSelled,IsDelivered,SellPrice,SellDate,DonatorID,PoorID")] PhysicalDonation physicalDonation)
        {
            if (physicalDonation.PoorID == 0)
                physicalDonation.PoorID = null;
            if (ModelState.IsValid)
            {
                db.Entry(physicalDonation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", physicalDonation.VolunteerID);
            ViewBag.DonatorID = new SelectList(db.Donator, "ID", "DonatorName", physicalDonation.DonatorID);
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorName", physicalDonation.PoorID);
            return View(physicalDonation);
        }

        // GET: PhysicalDonations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhysicalDonation physicalDonation = db.PhysicalDonation.Find(id);
            if (physicalDonation == null)
            {
                return HttpNotFound();
            }
            return View(physicalDonation);
        }

        // POST: PhysicalDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhysicalDonation physicalDonation = db.PhysicalDonation.Find(id);
            db.PhysicalDonation.Remove(physicalDonation);
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
