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
    [Authorize]
    public class DonationsController : Controller
    {
        private Gam3iaEntities db = new Gam3iaEntities();

        // GET: Donations
        public ActionResult Index()
        {
            var donation = db.Donation.Include(d => d.AspNetUsers).Include(d => d.Donator);
            return View(donation.ToList());
        }

        // GET: Donations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donation.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // GET: Donations/Create
        public ActionResult Create()
        {
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName");
            ViewBag.DonatorID = new SelectList(db.Donator, "ID", "DonatorName");
            return View();
        }

        // POST: Donations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DonationValue,Date,DonatorID")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                donation.VolunteerID= User.Identity.GetUserId();
                db.Donation.Add(donation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ModelState.Values.SelectMany(v => v.Errors);
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", donation.VolunteerID);
            ViewBag.DonatorID = new SelectList(db.Donator, "ID", "DonatorName", donation.DonatorID);
            return View(donation);
        }
        public ActionResult CreateNew()
        {

            Session["caller"] = "Donations";
            return RedirectToAction("Create", "Donators");
        }
        
        // GET: Donations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donation.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", donation.VolunteerID);
            ViewBag.DonatorID = new SelectList(db.Donator, "ID", "DonatorName", donation.DonatorID);
            return View(donation);
        }

        // POST: Donations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DonationValue,Date,DonatorID")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", donation.VolunteerID);
            ViewBag.DonatorID = new SelectList(db.Donator, "ID", "DonatorName", donation.DonatorID);
            return View(donation);
        }

        // GET: Donations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donation.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // POST: Donations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donation donation = db.Donation.Find(id);
            db.Donation.Remove(donation);
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
