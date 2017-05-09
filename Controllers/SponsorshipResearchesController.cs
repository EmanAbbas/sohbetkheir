using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gam3iaWeb;

namespace Gam3iaWeb.Controllers
{
    [Authorize]
    public class SponsorshipResearchesController : Controller
    {
        private Gam3iaEntities db = new Gam3iaEntities();

        // GET: SponsorshipResearches
        public ActionResult Index()
        {
            var sponsorshipResearch = db.SponsorshipResearch.Include(s => s.Poor).Include(s => s.AspNetUsers);
            return View(sponsorshipResearch.ToList());
        }

        // GET: SponsorshipResearches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SponsorshipResearch sponsorshipResearch = db.SponsorshipResearch.Find(id);
            if (sponsorshipResearch == null)
            {
                return HttpNotFound();
            }
            return View(sponsorshipResearch);
        }

        // GET: SponsorshipResearches/Create
        public ActionResult Create()
        {
            ViewBag.PoorID = new SelectList(db.Poor.Include("Sponsorship").Where(p => p.Sponsorship.Count > 0), "ID", "PoorName");
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName");
            return View();
        }

        // POST: SponsorshipResearches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ResearcherName,ResearchDate,ResearchResponse,ResearchResults,SponsorshipStartDate,Comments,VolunteerID,PoorID")] SponsorshipResearch sponsorshipResearch)
        {
            if (ModelState.IsValid)
            {
                db.SponsorshipResearch.Add(sponsorshipResearch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PoorID = new SelectList(db.Poor.Include("Sponsorship").Where(p => p.Sponsorship.Count > 0), "ID", "PoorName");
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", sponsorshipResearch.VolunteerID);
            return View(sponsorshipResearch);
        }

        // GET: SponsorshipResearches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SponsorshipResearch sponsorshipResearch = db.SponsorshipResearch.Find(id);
            if (sponsorshipResearch == null)
            {
                return HttpNotFound();
            }
            ViewBag.PoorID = new SelectList(db.Poor.Include("Sponsorship").Where(p => p.Sponsorship.Count > 0), "ID", "PoorName");
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", sponsorshipResearch.VolunteerID);
            return View(sponsorshipResearch);
        }

        // POST: SponsorshipResearches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ResearcherName,ResearchDate,ResearchResponse,ResearchResults,SponsorshipStartDate,Comments,VolunteerID,PoorID")] SponsorshipResearch sponsorshipResearch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sponsorshipResearch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PoorID = new SelectList(db.Poor.Include("Sponsorship").Where(p => p.Sponsorship.Count > 0), "ID", "PoorName");
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", sponsorshipResearch.VolunteerID);
            return View(sponsorshipResearch);
        }

        // GET: SponsorshipResearches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SponsorshipResearch sponsorshipResearch = db.SponsorshipResearch.Find(id);
            if (sponsorshipResearch == null)
            {
                return HttpNotFound();
            }
            return View(sponsorshipResearch);
        }

        // POST: SponsorshipResearches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SponsorshipResearch sponsorshipResearch = db.SponsorshipResearch.Find(id);
            db.SponsorshipResearch.Remove(sponsorshipResearch);
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
