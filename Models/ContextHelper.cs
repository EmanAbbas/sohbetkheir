namespace Gam3iaWeb
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Data.Entity.Infrastructure;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;

    public partial class Gam3iaEntities : DbContext
    {
        
        /// <summary>
        /// CheckLoanCompleteion
        /// </summary>
        /// <param name="loanInstallment"></param>
        /// <returns></returns>
        public bool CheckLoanCompleteion(LoanInstallment loanInstallment)
        {
            Gam3iaEntities db = new Gam3iaEntities();
            List<LoanInstallment> prev_installments = (from i in db.LoanInstallment where i.Loan.PoorID == loanInstallment.PoorID select i).ToList();
            if (prev_installments.Count > 0)
            {
                int prev_installments_sum = prev_installments.Sum(p => p.Amount.Value);

                int loan_value = loanInstallment.LoanValue;
                if (prev_installments_sum >= loan_value)
                {
                    return true;
                }
                
            }
            return false;
           }
        public bool MarkLoanAsCompleted(LoanInstallment loanInstallment)
        {
            Gam3iaEntities db = new Gam3iaEntities();

            try { 
                    Loan current = (from l in db.Loan where l.ID == loanInstallment.LoanID select l).FirstOrDefault();
                    current.HasCompleted = true;
                    db.SaveChanges();
                return true;
                }
            catch
            {
                return false;
            }
            
        }
        public DateTime? GetNextInstallmentDate(int loanid)
        {
            List <LoanInstallment> payments = (from i in this.LoanInstallment where i.LoanID == loanid select i).ToList();
            if (payments != null&& payments.Count>0)
            {
                var last_payment = payments.Last();
                if (last_payment != null)
                {
                    DateTime pay_date = last_payment.DueDate.Value;
                    DateTime next_pay_date = pay_date.AddMonths(1);
                    return next_pay_date;

                }
                else
                    return null;
            }
            else
                return null;

        }


    }
}