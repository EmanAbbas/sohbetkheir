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
    public class GeneralAidsController : Controller
    {
        private Gam3iaEntities db = new Gam3iaEntities();
        
        // GET: GeneralAids
        public ActionResult Index( int serviceid=0)
        {
            List<Service> services = db.Service.ToList();
            services.Insert(0, new Service() { ServiceID = 0, ServiceName = "الكل" });
            ViewBag.ServicesList = new SelectList(services, "ServiceID", "ServiceName",serviceid);
           
            List<GeneralAid> generalAid = new List<GeneralAid>();
            if (serviceid == 0)
            {
                 generalAid = db.GeneralAid.Include(g => g.AspNetUsers).Include(g => g.Poor).Include(g => g.Service).ToList();
                //ViewBag.SelectedOption = serviceid;
            }
            else
            {
                 generalAid = db.GeneralAid.Where(g=>g.ServiceID==serviceid).Include(g => g.AspNetUsers).Include(g => g.Poor).Include(g => g.Service).ToList();

            }
            return View(generalAid);
        }

        // GET: GeneralAids/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralAid generalAid = db.GeneralAid.Find(id);
            if (generalAid == null)
            {
                return HttpNotFound();
            }
            return View(generalAid);
        }

        // GET: GeneralAids/Create
        public ActionResult Create()
        {
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName");
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorName");
            ViewBag.ServiceID = new SelectList(db.Service, "ServiceID", "ServiceName");
            return View();
        }

        // POST: GeneralAids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Comment,Tag,PoorID,ServiceID,ReceiveDate,Value")] GeneralAid generalAid)
        {

            generalAid.VolunteerID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.GeneralAid.Add(generalAid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", generalAid.VolunteerID);
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorName", generalAid.PoorID);
            ViewBag.ServiceID = new SelectList(db.Service, "ServiceID", "ServiceName", generalAid.ServiceID);
            return View(generalAid);
        }

        public ActionResult CreateNew()
        {

            Session["caller"] = "GeneralAid";
            return RedirectToAction("Create", "Poors");
        }
        // GET: GeneralAids/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralAid generalAid = db.GeneralAid.Find(id);
            if (generalAid == null)
            {
                return HttpNotFound();
            }
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", generalAid.VolunteerID);
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorName", generalAid.PoorID);
            ViewBag.ServiceID = new SelectList(db.Service, "ServiceID", "ServiceName", generalAid.ServiceID);
            return View(generalAid);
        }

        // POST: GeneralAids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Comment,PoorID,ServiceID,ReceiveDate,Value")] GeneralAid generalAid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(generalAid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", generalAid.VolunteerID);
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorName", generalAid.PoorID);
            ViewBag.ServiceID = new SelectList(db.Service, "ServiceID", "ServiceName", generalAid.ServiceID);
            return View(generalAid);
        }

        // GET: GeneralAids/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralAid generalAid = db.GeneralAid.Find(id);
            if (generalAid == null)
            {
                return HttpNotFound();
            }
            return View(generalAid);
        }

        // POST: GeneralAids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GeneralAid generalAid = db.GeneralAid.Find(id);
            db.GeneralAid.Remove(generalAid);
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
