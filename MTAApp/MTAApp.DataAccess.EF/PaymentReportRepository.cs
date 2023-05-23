using Microsoft.EntityFrameworkCore;
using MTAApp.DataAccess.Abstractions;
using MTAApp.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAApp.DataAccess.EF
{
    public class PaymentReportRepository : BaseRepository<PaymentReport>, IPaymentReportRepository
    {
        public PaymentReportRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public PaymentReport GetPaymentReportByProfit(double profit)
        {
            return dbContext.Set<PaymentReport>().Where(p => p.Profit >= profit)
                                            .FirstOrDefault();
        }

        public PaymentReport GetPaymentReportByAssociationId(int id)
        {
            return dbContext.Set<PaymentReport>().Where(p => p.AssociationId == id).FirstOrDefault();
        }

        public PaymentReport UpdatePaymentReportEmployeesSalary(PaymentReport paymentReport)
        {
            paymentReport.Expense += paymentReport.EmployeesSalary;
            var item = dbContext.Set<PaymentReport>().Update(paymentReport);
            dbContext.SaveChanges();
            return item.Entity;

        }
        public PaymentReport UpdatePaymentReportContractsCost(PaymentReport paymentReport)
        {
            paymentReport.Expense += paymentReport.ContractsCost;
            var item = dbContext.Set<PaymentReport>().Update(paymentReport);
            dbContext.SaveChanges();
            return item.Entity;

        }
        public PaymentReport UpdatePaymentReportAppsTotalPayDebt(PaymentReport paymentReport)
        {
            paymentReport.Income += paymentReport.AppsTotalPayDebt;
            var item = dbContext.Set<PaymentReport>().Update(paymentReport);
            dbContext.SaveChanges();
            return item.Entity;

        }
        public PaymentReport UpdatePaymentReportAppsCurrentMonth(PaymentReport paymentReport)
        {
            paymentReport.Income += paymentReport.AppsPayCurrentMonth;
            var item = dbContext.Set<PaymentReport>().Update(paymentReport);
            dbContext.SaveChanges();
            return item.Entity;

        }
        public PaymentReport UpdatePaymentReportOtherPays(PaymentReport paymentReport)
        {
            paymentReport.Income += paymentReport.OtherPays;
            var item = dbContext.Set<PaymentReport>().Update(paymentReport);
            dbContext.SaveChanges();
            return item.Entity;

        }
        public PaymentReport UpdatePaymentReportProfit(PaymentReport paymentReport)
        {
            paymentReport.Profit = paymentReport.Income - paymentReport.Expense;
            var item = dbContext.Set<PaymentReport>().Update(paymentReport);
            dbContext.SaveChanges();
            return item.Entity;

        }
    }
}
