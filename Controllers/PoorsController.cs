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
    public class PoorsController : Controller
    {
        private Gam3iaEntities db = new Gam3iaEntities();

        // GET: Poors
        public ActionResult Index(string searchby,string search)
        {
            List<Poor> ps = db.Poor.ToList();
            if (searchby == "PoorName")
            {
                ps=db.Poor.Where(x => x.PoorName.Contains( search )).ToList();
            }
            if (searchby == "PoorNID")
            {
                ps=db.Poor.Where(x => x.PoorNID.Equals(search)).ToList();
            }
            
            List<PoorViewModel> poorsvm = new List<PoorViewModel>();
           
            foreach (Poor item in ps)
            {
                poorsvm.Add((PoorViewModel)item);

            }
            return View(poorsvm);
        }
        // GET: GetCaseStudies/1
        public ActionResult GetCaseStudies(int? poorid)
        {

            if (poorid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Poor po = (from p in db.Poor where p.ID == poorid select p).FirstOrDefault();

                List<CaseStudyViewModel> cslst = new List<CaseStudyViewModel>();

                var case_studies = (from i in db.CaseStudy where i.PoorID == poorid select i).ToList();
                if (case_studies.Count == 0)
                    ViewBag.RelatedCaseStudyMsg = "لا  توجد أبحاث حاله متعلقه بهذا العنصر..";
                else
                {
                    foreach (var item in case_studies)
                    {
                        cslst.Add((CaseStudyViewModel)item);
                    }
                }


                return View(cslst);
            }
        }

        public ActionResult GetPoorHistory(int? poorid)
        {

            if (poorid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Poor po = (from p in db.Poor where p.ID == poorid select p).FirstOrDefault();


                List<Loan> lolst = (from i in db.Loan where i.PoorID == poorid select i).ToList();
                if (lolst.Count == 0)
                    ViewBag.RelatedLoanMsg = "لا  توجد قروض متعلقه بهذا العنصر..";
                else
                {
                    ViewBag.LoanList = lolst;
                }
                List<StudentAid> sdonationlst = (from i in db.StudentAid where i.PoorID == poorid select i).ToList();
                if (sdonationlst.Count == 0)
                    ViewBag.RelatedStudentAidMsg = "لا  توجد مساعدات طالب متعلقه بهذا العنصر..";
                else
                {
                    ViewBag.StudentAidList = sdonationlst;
                }
                List<PhysicalDonation> donationlst = (from i in db.PhysicalDonation where i.PoorID == poorid select i).ToList();
                if (donationlst.Count == 0)
                    ViewBag.RelatedPhysicalDonationMsg = "لا  توجد تبرعات عينيه مستلمه متعلقه بهذا العنصر..";
                else
                {
                    ViewBag.PhysicalDonationList = donationlst;
                }


                return View();
            }
        }

        // GET: Poors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poor poor = db.Poor.Find(id);
            if (poor == null)
            {
                return HttpNotFound();
            }
           
            return View((PoorViewModel)poor);
        }

        // GET: Poors/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.City, "ID", "CityName");

            return View();

        }

        // POST: Poors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PoorNID,PoorName,RegisterDate,CityID")] PoorViewModel poorvm)
        {
            Poor poor = (Poor)poorvm;
            if (ModelState.IsValid)
            {
                
                db.Poor.Add(poor);
                db.SaveChanges();
                if (Session["caller"] != null)
                {
                    if (Session["caller"].ToString() == "CaseStudy")
                    {
                        Session["caller"] = "";
                        return RedirectToAction("Create", "CaseStudies");

                    }
                    if (Session["caller"].ToString() == "Loan")
                    {
                        Session["caller"] = "";
                        return RedirectToAction("Create", "Loans");

                    }
                    if (Session["caller"].ToString() == "StudentAid")
                    {
                        Session["caller"] = "";
                        return RedirectToAction("Create", "StudentAids");

                    }
                    if (Session["caller"].ToString() == "GeneralAid")
                    {
                        Session["caller"] = "";
                        return RedirectToAction("Create", "GeneralAids");

                    }
                }
                else
                    return RedirectToAction("Index");


            }

            return View((PoorViewModel)poor);
        }

        // GET: Poors/Edit/5
        public ActionResult Edit(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poor poor = db.Poor.Find(id);
            if (poor == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.City, "ID", "CityName",poor.CityID);

            return View((PoorViewModel)poor);
        }

        // POST: Poors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PoorNID,PoorName,CityID")] PoorViewModel poorvm)
        {
            Poor poor = (Poor)poorvm;
            if (ModelState.IsValid)
            {
                db.Entry(poor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View((PoorViewModel)poor);
        }

        // GET: Poors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poor poor = db.Poor.Find(id);
            if (poor == null)
            {
                return HttpNotFound();
            }
            return View((PoorViewModel)poor);
        }

        // POST: Poors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Poor poor = db.Poor.Find(id);
            db.Poor.Remove(poor);
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
