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
    public class LoanInstallmentsController : Controller
    {
        private Gam3iaEntities db = new Gam3iaEntities();

        // GET: LoanInstallments
        public ActionResult Index()
        {
            var loanInstallment = db.LoanInstallment.Include(l => l.Loan).Include(l => l.Poor);
            return View(loanInstallment.ToList());
        }

        // GET: LoanInstallments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanInstallment loanInstallment = db.LoanInstallment.Find(id);
            if (loanInstallment == null)
            {
                return HttpNotFound();
            }
            return View(loanInstallment);
        }

        // GET: LoanInstallments/Create
        public ActionResult Create()
        {
            List<Loan> loans = (from l in db.Loan where l.HasCompleted != true select l).ToList();
            ViewBag.LoanID = new SelectList(loans, "ID", "LoanCode");
            ViewBag.PoorID = new SelectList(db.Poor.Include("Loan").Where(p=>p.Loan.Count>0), "ID", "PoorName");
            return View();
        }

        // POST: LoanInstallments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DueDate,Amount,LoanID,Comments,PoorID")] LoanInstallment loanInstallment)
        {
            if (ModelState.IsValid)
            {
                db.LoanInstallment.Add(loanInstallment);
                db.SaveChanges();
                
                    if (db.CheckLoanCompleteion(loanInstallment))
                    {
                        db.MarkLoanAsCompleted(loanInstallment);

                    }

                    
                return RedirectToAction("Index");
            }

            ViewBag.LoanID = new SelectList(db.Loan, "ID", "LoanCode", loanInstallment.LoanID);
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorNID", loanInstallment.PoorID);
            return View(loanInstallment);
        }

        // GET: LoanInstallments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanInstallment loanInstallment = db.LoanInstallment.Find(id);
            if (loanInstallment == null)
            {
                return HttpNotFound();
            }
            List<Loan> loans = (from l in db.Loan where l.HasCompleted != true select l).ToList();
            ViewBag.LoanID = new SelectList(loans, "ID", "LoanCode", loanInstallment.LoanID);
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorName", loanInstallment.PoorID);
            return View(loanInstallment);
        }

        // POST: LoanInstallments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DueDate,Amount,LoanID,Comments,PoorID")] LoanInstallment loanInstallment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loanInstallment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoanID = new SelectList(db.Loan, "ID", "LoanCode", loanInstallment.LoanID);
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorNID", loanInstallment.PoorID);
            return View(loanInstallment);
        }

        // GET: LoanInstallments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanInstallment loanInstallment = db.LoanInstallment.Find(id);
            if (loanInstallment == null)
            {
                return HttpNotFound();
            }
            return View(loanInstallment);
        }

        // POST: LoanInstallments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoanInstallment loanInstallment = db.LoanInstallment.Find(id);
            db.LoanInstallment.Remove(loanInstallment);
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
