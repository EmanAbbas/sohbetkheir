using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gam3iaWeb;
using Gam3iaWeb.Models;

namespace Gam3iaWeb.Controllers
{
    [Authorize]
    public class CaseStudiesController : Controller
    {
        private Gam3iaEntities db = new Gam3iaEntities();

        // GET: CaseStudies
        public ActionResult Index()
        {
            List<CaseStudy> caseStudylst = db.CaseStudy.Include(c => c.AspNetUsers).ToList();
            List<CaseStudyViewModel> vms = new List<CaseStudyViewModel>();
            foreach (var item in caseStudylst)
            {
                vms.Add((CaseStudyViewModel)item);
            }
            return View(vms);
        }

        public ActionResult test()
        {
            return View("test");
        }

        // GET: CaseStudies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseStudy caseStudy = db.CaseStudy.Find(id);
            CaseStudyViewModel vm = caseStudy;
            if (caseStudy == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // GET: CaseStudies/Create
        public ActionResult Create()
        {
            CaseStudyViewModel vm = new CaseStudyViewModel();
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName");
            ViewBag.Poors = new SelectList(db.Poor, "ID", "PoorName");

            return View(vm);
        }

        // POST: CaseStudies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CaseID,VillageName,ReporterName,ReporterPhone,FamilyClass,PartnerName,PartnerNID,Address,Breadwinner,Job,EducationState,ChildrenNo,ChildrenInEducationNo,TravelledOrMarriedChildrenNo,Telephone1,Telephone2,Target,ReviewerOpinion,VolunteerID,WaterFees,ElectricityFees,InstallmentsFees,DrugsFees,RentFees,OtherFees,MonthlySalary,DailySalary,InsuranceIncome,SocitiesIncome,MaashIncome,OtherIncome,LandsOwned,AnimalsOwned,BirdsOwned,OtherOwned,DevicesOwned,RoomsNo,HouseType,WallsType,RoofType,Floor,HasWaterLine,HasElectLine,HasSarfLine,OtherLines,Comments,PoorID,ReviewerName,ResearchDate,IsDeserved")] CaseStudyViewModel caseStudyvm)
        {

            CaseStudy caseStudy = (CaseStudy)caseStudyvm;
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                db.CaseStudy.Add(caseStudy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", caseStudy.VolunteerID);
            return View((CaseStudyViewModel)caseStudy);
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
            ViewBag.Poors = new SelectList(db.Poor, "ID", "PoorName");
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", caseStudy.VolunteerID);
            return View((CaseStudyViewModel)caseStudy);
        }

        // POST: CaseStudies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CaseID,VillageName,ReporterName,ReporterPhone,FamilyClass,PartnerName,PartnerNID,Address,Breadwinner,Job,EducationState,ChildrenNo,ChildrenInEducationNo,TravelledOrMarriedChildrenNo,Telephone1,Telephone2,Target,ReviewerOpinion,VolunteerID,WaterFees,ElectricityFees,InstallmentsFees,DrugsFees,RentFees,OtherFees,MonthlySalary,DailySalary,InsuranceIncome,SocitiesIncome,MaashIncome,OtherIncome,LandsOwned,AnimalsOwned,BirdsOwned,OtherOwned,DevicesOwned,RoomsNo,HouseType,WallsType,RoofType,Floor,HasWaterLine,HasElectLine,HasSarfLine,OtherLines,Comments,PoorID,ReviewerName,ResearchDate,IsDeserved")] CaseStudyViewModel caseStudyvm)
        {
            CaseStudy caseStudy = (CaseStudy)caseStudyvm;
            if (ModelState.IsValid)
            {
                db.Entry(caseStudy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", caseStudy.VolunteerID);
            return View((CaseStudyViewModel)caseStudy);
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
            return View((CaseStudyViewModel)caseStudy);
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


        public ActionResult CreateNew()
        {
            //ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName");
            //return View();
            Session["caller"] = "CaseStudy";
            return RedirectToAction("Create", "Poors");
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
