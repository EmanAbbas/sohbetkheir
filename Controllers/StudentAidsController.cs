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
    public class StudentAidsController : Controller
    {
        private Gam3iaEntities db = new Gam3iaEntities();

        // GET: StudentAids
        public ActionResult Index()
        {
            var studentAid = db.StudentAid.Include(s => s.AspNetUsers).Include(s => s.Poor);
            return View(studentAid.ToList());
        }

        // GET: StudentAids/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAid studentAid = db.StudentAid.Find(id);
            if (studentAid == null)
            {
                return HttpNotFound();
            }
            return View(studentAid);
        }

        // GET: StudentAids/Create
        public ActionResult Create()
        {
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName");
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorName");
            StudentAid aid = new StudentAid();
            return View(aid);
        }

        // POST: StudentAids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudyYear,SchoolName,RequiredFeesValue,RequiredFeesType,OtherFeesValue,OtherFeesType,VolunteerID,PoorID,StudentName, SchoolAddress,Notes")] StudentAid studentAid)
        {
            studentAid.VolunteerID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.StudentAid.Add(studentAid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", studentAid.VolunteerID);
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorName", studentAid.PoorID);
            return View(studentAid);
        }
        // GET: StudentAids/CreateNew
        public ActionResult CreateNew()
        {

            Session["caller"] = "StudentAid";
            return RedirectToAction("Create", "Poors");
        }
        // POST: StudentAids/CreateNew
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNew([Bind(Include = "ID,StudyYear,SchoolName,RequiredFeesValue,RequiredFeesType,OtherFeesValue,OtherFeesType,VolunteerID,PoorID,,StudentName, SchoolAddress,Notes")] StudentAid studentAid)
        {
            studentAid.VolunteerID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.StudentAid.Add(studentAid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", studentAid.VolunteerID);
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorName", studentAid.PoorID);
            return View(studentAid);
        }
        // GET: StudentAids/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAid studentAid = db.StudentAid.Find(id);
            if (studentAid == null)
            {
                return HttpNotFound();
            }
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", studentAid.VolunteerID);
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorName", studentAid.PoorID);
            return View(studentAid);
        }

        // POST: StudentAids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudyYear,SchoolName,RequiredFeesValue,RequiredFeesType,OtherFeesValue,OtherFeesType,VolunteerID,PoorID,,StudentName, SchoolAddress,Notes")] StudentAid studentAid)
        {
            studentAid.VolunteerID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.Entry(studentAid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", studentAid.VolunteerID);
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorName", studentAid.PoorID);
            return View(studentAid);
        }

        // GET: StudentAids/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAid studentAid = db.StudentAid.Find(id);
            if (studentAid == null)
            {
                return HttpNotFound();
            }
            return View(studentAid);
        }

        // POST: StudentAids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentAid studentAid = db.StudentAid.Find(id);
            db.StudentAid.Remove(studentAid);
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
