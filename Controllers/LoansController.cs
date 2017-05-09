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
    public class LoansController : Controller
    {
        private Gam3iaEntities db = new Gam3iaEntities();

        // GET: Loans
        public ActionResult Index()
        {
            var loans = db.Loan.Where(l=>l.HasCompleted!=true).Where(l=>l.HasJudged!=true).Include(l => l.AspNetUsers).Include(l => l.Poor);
            List<Loan> current_loans = new List<Loan>();
            foreach (Loan lo in loans.ToList())
            {
                bool? is_monthly = lo.IsMonthlyPayment;
                if (is_monthly != null && is_monthly == true)
                {
                    DateTime? next_pay_date = db.GetNextInstallmentDate(lo.ID);
                    if (next_pay_date == null || next_pay_date > DateTime.Now)
                        current_loans.Add(lo);


                }
            }
            return View(current_loans);
           
        }
        public ActionResult Completed()
        {
            var loan = db.Loan.Where(l => l.HasCompleted == true).Include(l => l.AspNetUsers).Include(l => l.Poor);
            return View(loan.ToList());
        }
        public ActionResult Judged()
        {
            var loan = db.Loan.Where(l => l.HasJudged == true).Include(l => l.AspNetUsers).Include(l => l.Poor);
            return View(loan.ToList());
        }
        public ActionResult Late()
        {
            var loans = db.Loan.Where(l => l.HasCompleted != true).Where(l => l.HasJudged != true).Include(l => l.AspNetUsers).Include(l => l.Poor);
            List<Loan> late_loans = new List<Loan>();
            foreach (Loan lo in loans.ToList())
            {
                bool? is_monthly = lo.IsMonthlyPayment;
                if (is_monthly != null && is_monthly == true)
                {
                    DateTime? next_pay_date = db.GetNextInstallmentDate(lo.ID);
                    if (next_pay_date != null && next_pay_date < DateTime.Now)
                        late_loans.Add(lo);
                   

                }
            }
            return View(late_loans);
        }
        // GET: LoanInstallments/1
        public ActionResult GetInstallments(int? loanid)
        {

            if (loanid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Loan lo = (from l in db.Loan where l.ID == loanid select l).FirstOrDefault();

                bool? is_monthly = lo.IsMonthlyPayment;
                if (is_monthly != null && is_monthly == true)
                {
                    DateTime? next_pay_date = db.GetNextInstallmentDate(loanid.Value);
                    if (next_pay_date != null)
                        ViewBag.NextInstallmentDateMsg = "موعد دفع القسط القادم :" + next_pay_date.Value.ToShortDateString();
                    else
                        ViewBag.NextInstallmentDateMsg = " ";

                }
                else
                {
                    ViewBag.NextInstallmentDateMsg = "لم يتم تحديد طريقة دفع الأقساط";
                }
                var loan_installments = (from i in db.LoanInstallment where i.LoanID == loanid select i).ToList();
                if (loan_installments.Count == 0)
                    ViewBag.NextInstallmentDateMsg = "لا توجد أقساط مدفوعه حتي الآن..";
                
                    return View(loan_installments.ToList());
            }
        }
        // GET: Loans/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.Loan.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // GET: Loans/Create
        public ActionResult Create()
        {
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName");
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorName");
            Loan l = new Loan();
            return View(l);
        }

        // POST: Loans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID, Address,Telephone1,Telephone2,Telephone3,Telephone4,WorkType,WorkAddress,WorkPhone,LoanValue,LoanReason,RequestDate,RequiredPapersSatisfied,HasSalaryStatement,MonthlyIncome,ReceiveDate,IsMonthlyPayment,GuarantorName,GuarantorAddress,GuarantorPhone1,GuarantorPhone2,GuarantorWorkType,GuarantorWorkAddress,GuarantorWorkPhone,GuarantorNID,GuarantorHasSalaryStatement,VolunteerID,PoorID,Notes")] Loan loan)
        {
            var errors=ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                db.Loan.Add(loan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", loan.VolunteerID);
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorName", loan.PoorID);
            return View(loan);
        }

        // GET: Loans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.Loan.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", loan.VolunteerID);
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorName", loan.PoorID);
            return View(loan);
        }

        // POST: Loans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, Address,Telephone1,Telephone2,Telephone3,Telephone4,WorkType,WorkAddress,WorkPhone,NID,LoanValue,LoanReason,RequestDate,RequiredPapersSatisfied,HasJudged,HasCompleted,HasSalaryStatement,MonthlyIncome,ReceiveDate,IsMonthlyPayment,PaymentBehavior,IrregularPaymentReason,GuarantorName,GuarantorAddress,GuarantorPhone1,GuarantorPhone2,GuarantorWorkType,GuarantorWorkAddress,GuarantorWorkPhone,GuarantorNID,GuarantorHasSalaryStatement,VolunteerID,PoorID,Notes")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", loan.VolunteerID);
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorName", loan.PoorID);
            return View(loan);
        }

        // GET: Loans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.Loan.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // POST: Loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loan loan = db.Loan.Find(id);
            db.Loan.Remove(loan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CreateNew()
        {
           
            Session["caller"] = "Loan";
            return RedirectToAction("Create", "Poors");
        }

        // POST: Loans/CreateNew
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNew([Bind(Include = "ID, Address,Telephone1,Telephone2,Telephone3,Telephone4,WorkType,WorkAddress,WorkPhone,LoanValue,LoanReason,RequestDate,RequiredPapersSatisfied,HasSalaryStatement,MonthlyIncome,ReceiveDate,IsMonthlyPayment,GuarantorName,GuarantorAddress,GuarantorPhone1,GuarantorPhone2,GuarantorWorkType,GuarantorWorkAddress,GuarantorWorkPhone,GuarantorNID,GuarantorHasSalaryStatement,VolunteerID,PoorID")] Loan loan)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                db.Loan.Add(loan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", loan.VolunteerID);
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorName", loan.PoorID);
            return View(loan);
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
