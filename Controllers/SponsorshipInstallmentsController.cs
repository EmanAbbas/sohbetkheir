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
    public class SponsorshipInstallmentsController : Controller
    {
        private Gam3iaEntities db = new Gam3iaEntities();

        // GET: SponsorshipInstallments
        public ActionResult Index()
        {
            var sponsorshipInstallment = db.SponsorshipInstallment.Include(s => s.Sponsorship);
            return View(sponsorshipInstallment.ToList());
        }

        // GET: SponsorshipInstallments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SponsorshipInstallment sponsorshipInstallment = db.SponsorshipInstallment.Find(id);
            if (sponsorshipInstallment == null)
            {
                return HttpNotFound();
            }
            return View(sponsorshipInstallment);
        }

        // GET: SponsorshipInstallments/Create
        public ActionResult Create()
        {
            List<Sponsorship> dlist = db.Sponsorship.ToList();
            dlist.Insert(0, new Sponsorship() { ID = 0, SposorshipCode = "لم تحدد بعد" });
            ViewBag.SposorshipID = new SelectList(dlist, "ID", "SposorshipCode");
            ViewBag.SponsorsID = new SelectList(db.Sponsor, "ID", "SponsorName");
            return View();
        }

        // POST: SponsorshipInstallments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DueDate,Amount,IsCalledB,CallerName,CallDate,IsDeliveredB,DeliveryDate,SposorshipID,JanuaryNN,FebruaryNN,MarchNN,AprilNN,MayNN,JuneNN,JulyNN,AugustNN,SeptemberNN,OctoberNN,NovemberNN,DecemberNN,Year,SponsorID")] SponsorshipInstallment sponsorshipInstallment)
        {
            if (sponsorshipInstallment.SposorshipID == 0)
                sponsorshipInstallment.SposorshipID = null;
            if (ModelState.IsValid)
            {
                db.SponsorshipInstallment.Add(sponsorshipInstallment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SponsorsID = new SelectList(db.Sponsor, "ID", "SponsorName", sponsorshipInstallment.SponsorID);
            ViewBag.SposorshipID = new SelectList(db.Sponsorship, "ID", "SposorshipCode", sponsorshipInstallment.SposorshipID);
            return View(sponsorshipInstallment);
        }

        // GET: SponsorshipInstallments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SponsorshipInstallment sponsorshipInstallment = db.SponsorshipInstallment.Find(id);
            if (sponsorshipInstallment == null)
            {
                return HttpNotFound();
            }
            List<Sponsorship> dlist = db.Sponsorship.ToList();
            dlist.Insert(0, new Sponsorship() { ID = 0, SposorshipCode = "لم تحدد بعد" });
            ViewBag.SposorshipID = new SelectList(dlist, "ID", "SposorshipCode", sponsorshipInstallment.SposorshipID);
            ViewBag.SponsorsID = new SelectList(db.Sponsor, "ID", "SponsorName",sponsorshipInstallment.SponsorID);
            return View(sponsorshipInstallment);
        }

        // POST: SponsorshipInstallments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DueDate,Amount,IsCalledB,CallerName,CallDate,IsDeliveredB,DeliveryDate,SposorshipID,JanuaryNN,FebruaryNN,MarchNN,AprilNN,MayNN,JuneNN,JulyNN,AugustNN,SeptemberNN,OctoberNN,NovemberNN,DecemberNN,Year,SponsorID")] SponsorshipInstallment sponsorshipInstallment)
        {
            if (sponsorshipInstallment.SposorshipID == 0)
                sponsorshipInstallment.SposorshipID = null;
            if (ModelState.IsValid)
            {
                db.Entry(sponsorshipInstallment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SposorshipID = new SelectList(db.Sponsorship, "ID", "SposorshipCode", sponsorshipInstallment.SposorshipID);
            ViewBag.SponsorsID = new SelectList(db.Sponsor, "ID", "SponsorName", sponsorshipInstallment.SponsorID);

            return View(sponsorshipInstallment);
        }

        // GET: SponsorshipInstallments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SponsorshipInstallment sponsorshipInstallment = db.SponsorshipInstallment.Find(id);
            if (sponsorshipInstallment == null)
            {
                return HttpNotFound();
            }
            return View(sponsorshipInstallment);
        }

        // POST: SponsorshipInstallments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SponsorshipInstallment sponsorshipInstallment = db.SponsorshipInstallment.Find(id);
            db.SponsorshipInstallment.Remove(sponsorshipInstallment);
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
