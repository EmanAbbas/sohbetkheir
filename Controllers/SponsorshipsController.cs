using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.AspNet.Identity;

using System.Web.Mvc;
using Gam3iaWeb;
using Gam3iaWeb.Models;

namespace Gam3iaWeb.Controllers
{
    [Authorize]
    public class SponsorshipsController : Controller
    {
        private Gam3iaEntities db = new Gam3iaEntities();

        // GET: Sponsorships
        public ActionResult Index()
        {
            var sponsorship = db.Sponsorship.Include(s => s.Sponsor).Include(s => s.Poor).Include(s => s.AspNetUsers).Where(s => s.RequestCase == (int)RequestStatusEnum.انتظار_كفالة);

            //var sponsorship = db.Sponsorship.Include(s => s.Sponsor).Include(s => s.Poor).Include(s => s.AspNetUsers);
            return View(sponsorship.ToList());
        }

        // GET: Sponsorships/Research
        public ActionResult Research()
        {
            var sponsorship = db.Sponsorship.Include(s => s.Sponsor).Include(s => s.Poor).Include(s => s.AspNetUsers).Where(s=>s.RequestCase== (int)RequestStatusEnum.إعادة_بحث);
            return View(sponsorship.ToList());
        }
        //Sponsored
        public ActionResult Sponsored()
        {
            var sponsorship = db.Sponsorship.Include(s => s.Sponsor).Include(s => s.Poor).Include(s => s.AspNetUsers).Where(s => s.RequestCase == (int)RequestStatusEnum.تم_كفلها_بانتظام_من_الجمعيه);
            return View(sponsorship.ToList());
        }
        //Rejected
        public ActionResult Rejected()
        {
            List<Sponsorship> sponsorship = (from s in db.Sponsorship.Include(s => s.Sponsor).Include(s => s.Poor).Include(s => s.AspNetUsers)
                                             where (s.IsStopped.Value == true ||
                                              s.RequestCase == (int)RequestStatusEnum.تم_رفض_الطلب
                                              )
                                             select s).ToList();
            return View(sponsorship);
        }

        public ActionResult Stopped()
        {
            var sponsorship = db.Sponsorship.Include(s => s.Sponsor).Include(s => s.Poor).Include(s => s.AspNetUsers).Where(s => s.RequestCase == (int)RequestStatusEnum.تم_إخراج_الحاله_من_الكفالة);
            return View(sponsorship.ToList());
        }

        public ActionResult GetSposorshipInstallments(int? sid)
        {

            if (sid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Sponsorship lo = (from s in db.Sponsorship where s.ID == sid select s).FirstOrDefault();

                //bool? is_monthly = lo.IsMonthlyPayment;
                //if (is_monthly != null && is_monthly == true)
                //{
                //    DateTime? next_pay_date = db.GetNextInstallmentDate(sid.Value);
                //    if (next_pay_date != null)
                //        ViewBag.NextInstallmentDateMsg = "موعد دفع القسط القادم :" + next_pay_date.Value.ToShortDateString();
                //    else
                //        ViewBag.NextInstallmentDateMsg = " ";

                //}
                //else
                //{
                //    ViewBag.NextInstallmentDateMsg = "لم يتم تحديد طريقة دفع الأقساط";
                //}
                var spons_installments = (from i in db.SponsorshipInstallment where i.SposorshipID == sid select i).ToList();
                if (spons_installments.Count == 0)
                    ViewBag.NextInstallmentDateMsg = "لا توجد أقساط مدفوعه حتي الآن..";

                return View(spons_installments.ToList());
            }
        }

        // GET: Sponsorships/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sponsorship sponsorship = db.Sponsorship.Find(id);
            if (sponsorship == null)
            {
                return HttpNotFound();
            }
            return View(sponsorship);
        }

        // GET: Sponsorships/Create
        public ActionResult Create()
        {
            List<Sponsor> dlist = db.Sponsor.ToList();
            dlist.Insert(0, new Sponsor() { ID = 0, SponsorName = "لم يحدد بعد" });
            ViewBag.SponsorID = new SelectList(dlist, "ID", "SponsorName");
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorName");
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName");
            Sponsorship s = new Sponsorship();
            return View(s);
        }

        // POST: Sponsorships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RequestCase,RequestReceiver,RequestFollowHolder,RequestDate,Amount,PaymentMethodType,WaseetName,WaseetPhone,SposorChanged,OldSponsorName,NewSponsorName,ReasonOfChange,IsStopped,StopDate,StopReason,RefuseReason,IsRefused,PoorID,SponsorID,Income,IncomeSource")] Sponsorship sponsorship)
        {
            if (sponsorship.SponsorID == 0)
                sponsorship.SponsorID = null;
            if (ModelState.IsValid)
            {
                sponsorship.VolunteerID= User.Identity.GetUserId();
                db.Sponsorship.Add(sponsorship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SponsorID = new SelectList(db.Sponsor, "ID", "SponsorName", sponsorship.SponsorID);
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorName", sponsorship.PoorID);
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", sponsorship.VolunteerID);
            return View(sponsorship);
        }

        // GET: Sponsorships/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sponsorship sponsorship = db.Sponsorship.Find(id);
            if (sponsorship == null)
            {
                return HttpNotFound();
            }
            List<Sponsor> dlist = db.Sponsor.ToList();
            dlist.Insert(0, new Sponsor() { ID = 0, SponsorName = "لم يحدد بعد" });
            ViewBag.SponsorID = new SelectList(dlist, "ID", "SponsorName", sponsorship.SponsorID);
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorName", sponsorship.PoorID);
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", sponsorship.VolunteerID);
            return View(sponsorship);
        }

        // POST: Sponsorships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RequestCase,RequestReceiver,RequestFollowHolder,RequestDate,Amount,PaymentMethodType,WaseetName,WaseetPhone,SposorChanged,OldSponsorName,NewSponsorName,ReasonOfChange,IsStopped,StopDate,StopReason,RefuseReason,IsRefused,PoorID,SponsorID,Income,IncomeSource")] Sponsorship sponsorship)
        {
            if (sponsorship.SponsorID == 0)
                sponsorship.SponsorID = null;
            if (ModelState.IsValid)
            {
                sponsorship.VolunteerID = User.Identity.GetUserId();

                db.Entry(sponsorship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SponsorID = new SelectList(db.Sponsor, "ID", "SponsorName", sponsorship.SponsorID);
            ViewBag.PoorID = new SelectList(db.Poor, "ID", "PoorName", sponsorship.PoorID);
            ViewBag.VolunteerID = new SelectList(db.AspNetUsers, "Id", "UserName", sponsorship.VolunteerID);
            return View(sponsorship);
        }

        // GET: Sponsorships/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sponsorship sponsorship = db.Sponsorship.Find(id);
            if (sponsorship == null)
            {
                return HttpNotFound();
            }
            return View(sponsorship);
        }

        // POST: Sponsorships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sponsorship sponsorship = db.Sponsorship.Find(id);
            db.Sponsorship.Remove(sponsorship);
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
