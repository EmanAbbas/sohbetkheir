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
    public class SponsorsController : Controller
    {
        private Gam3iaEntities db = new Gam3iaEntities();

        // GET: Sponsors
        public ActionResult Index()
        {
            return View(db.Sponsor.ToList());
        }

        // GET: Sponsors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sponsor sponsor = db.Sponsor.Find(id);
            if (sponsor == null)
            {
                return HttpNotFound();
            }
            return View(sponsor);
        }

        // GET: Sponsors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sponsors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SponsorName,SponsorPhone,SponsorAddress,Email,Notes,Job,SponsorNID")] Sponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                sponsor.JoinedAt = DateTime.Now;
                db.Sponsor.Add(sponsor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sponsor);
        }

        // GET: Sponsors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sponsor sponsor = db.Sponsor.Find(id);
            if (sponsor == null)
            {
                return HttpNotFound();
            }
            return View(sponsor);
        }

        // POST: Sponsors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SponsorName,SponsorPhone,SponsorAddress,Email,Notes,Job,SponsorNID,JoinedAt")] Sponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sponsor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sponsor);
        }

        // GET: Sponsors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sponsor sponsor = db.Sponsor.Find(id);
            if (sponsor == null)
            {
                return HttpNotFound();
            }
            return View(sponsor);
        }

        // POST: Sponsors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sponsor sponsor = db.Sponsor.Find(id);
            db.Sponsor.Remove(sponsor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetSponsorInstallments(int? sid)
        {

            if (sid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
               

               
                var sponsor_installments = (from i in db.SponsorshipInstallment where i.SponsorID == sid select i).ToList();
                if (sponsor_installments.Count == 0)
                    ViewBag.NextInstallmentDateMsg = "لا توجد أقساط دفعها الكفيل  حتي الآن..";

                return View(sponsor_installments.ToList());
            }
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
