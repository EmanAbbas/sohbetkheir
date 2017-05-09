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
    public class CaseStudiesController2 : Controller
    {
        private Gam3iaEntities db = new Gam3iaEntities();

        // GET: CaseStudies
        public ActionResult Index()
        {
            var caseStudy = db.CaseStudy.Include(c => c.AspNetUsers).Include(c => c.Poor);
            return View(caseStudy.ToList());
        }

        // GET: CaseStudies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseStudy caseStudy = db.CaseStudy.Find(id);
            if (caseStudy == null)
            {
                return HttpNotFound();
            }
            return View(caseStudy);
        }

        // GET: CaseStudies/Create
        public ActionResult Create()
        {
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorNID");
            return View();
        }

        // POST: CaseStudies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CaseID,VillageName,ReporterName,ReporterPhone,FamilyClass,PartnerName,PartnerNID,Address,Breadwinner,Job,EducationState,ChildrenNo,ChildrenInEducationNo,TravelledOrMarriedChildrenNo,Telephone1,Telephone2,Target,ReviewerOpinion,VolunteerID,WaterFees,ElectricityFees,InstallmentsFees,DrugsFees,RentFees,OtherFees,MonthlySalary,DailySalary,InsuranceIncome,SocitiesIncome,MaashIncome,OtherIncome,LandsOwned,AnimalsOwned,BirdsOwned,OtherOwned,DevicesOwned,RoomsNo,HouseType,WallsType,RoofType,Floor,HasWaterLine,HasElectLine,HasSarfLine,OtherLines,Comments,PoorID")] CaseStudy caseStudy)
        {
            if (ModelState.IsValid)
            {
                db.CaseStudy.Add(caseStudy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "Email", caseStudy.VolunteerID);
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorNID", caseStudy.PoorID);
            return View(caseStudy);
        }

        // GET: CaseStudies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseStudy caseStudy = db.CaseStudy.Find(id);
            if (caseStudy == null)
            {
                return HttpNotFound();
            }
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "Email", caseStudy.VolunteerID);
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorNID", caseStudy.PoorID);
            return View(caseStudy);
        }

        // POST: CaseStudies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CaseID,VillageName,ReporterName,ReporterPhone,FamilyClass,PartnerName,PartnerNID,Address,Breadwinner,Job,EducationState,ChildrenNo,ChildrenInEducationNo,TravelledOrMarriedChildrenNo,Telephone1,Telephone2,Target,ReviewerOpinion,VolunteerID,WaterFees,ElectricityFees,InstallmentsFees,DrugsFees,RentFees,OtherFees,MonthlySalary,DailySalary,InsuranceIncome,SocitiesIncome,MaashIncome,OtherIncome,LandsOwned,AnimalsOwned,BirdsOwned,OtherOwned,DevicesOwned,RoomsNo,HouseType,WallsType,RoofType,Floor,HasWaterLine,HasElectLine,HasSarfLine,OtherLines,Comments,PoorID")] CaseStudy caseStudy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caseStudy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "Email", caseStudy.VolunteerID);
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorNID", caseStudy.PoorID);
            return View(caseStudy);
        }

        // GET: CaseStudies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseStudy caseStudy = db.CaseStudy.Find(id);
            if (caseStudy == null)
            {
                return HttpNotFound();
            }
            return View(caseStudy);
        }

        // POST: CaseStudies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CaseStudy caseStudy = db.CaseStudy.Find(id);
            db.CaseStudy.Remove(caseStudy);
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
