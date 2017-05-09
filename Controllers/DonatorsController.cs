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
    public class DonatorsController : Controller
    {
        private Gam3iaEntities db = new Gam3iaEntities();

        // GET: Donators
        public ActionResult Index()
        {
            return View(db.Donator.ToList());
        }

        // GET: Donators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donator donator = db.Donator.Find(id);
            if (donator == null)
            {
                return HttpNotFound();
            }
            return View(donator);
        }

        // GET: Donators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DonatorName,DonatorPhone,DonatorAddress,DonatorNID,Job,Notes,Tag,Email")] Donator donator)
        {
            if (ModelState.IsValid)
            {
                donator.JoinedAt = DateTime.Now;
                db.Donator.Add(donator);
                db.SaveChanges();
                if (Session["caller"] != null)
                {
                    if (Session["caller"].ToString() == "Donations")
                    {
                        Session["caller"] = "";
                        return RedirectToAction("Create", "Donations");

                    }
                    if (Session["caller"].ToString() == "PDonations")
                    {
                        Session["caller"] = "";
                        return RedirectToAction("Create", "PhysicalDonations");

                    }
                }
                return RedirectToAction("Index");
            }

            return View(donator);
        }

        // GET: Donators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donator donator = db.Donator.Find(id);
            if (donator == null)
            {
                return HttpNotFound();
            }
            return View(donator);
        }

        // POST: Donators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DonatorName,DonatorPhone,DonatorAddress,DonatorNID,Job,Notes,Tag,Email")] Donator donator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donator);
        }

        // GET: Donators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donator donator = db.Donator.Find(id);
            if (donator == null)
            {
                return HttpNotFound();
            }
            return View(donator);
        }

        // POST: Donators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donator donator = db.Donator.Find(id);
            db.Donator.Remove(donator);
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
