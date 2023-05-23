using MTAApp.DataAccess.Abstractions;
using MTAApp.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAApp.Logic
{
    public class PaymentReportService
    {
        private readonly IPaymentReportRepository paymentReportRepository;
        public PaymentReportService(IPaymentReportRepository paymentReportRepository)
        {
            this.paymentReportRepository = paymentReportRepository;
        }

        public IEnumerable<PaymentReport> GetPaymentReports()
        {
            return paymentReportRepository.GetAll();
        }

        public PaymentReport GetPaymentReport(int id)
        {
            return paymentReportRepository.Get(id);
        }

        public PaymentReport AddPaymentReport(PaymentReport paymentReport)
        {
            return paymentReportRepository.Add(paymentReport);
        }

        public PaymentReport UpdatePaymentReport(PaymentReport paymentReport)
        {
            return paymentReportRepository.Update(paymentReport);
        }

        public void DeletePaymentReport(int id)
        {
            paymentReportRepository.Remove(id);
        }

        public double CalculateProfit(PaymentReport paymentReport)
        {
            return (double)(paymentReport.Income - paymentReport.Expense);

        }

        public PaymentReport GetPaymentReportByProfit(double profit)
        {
            return paymentReportRepository.GetPaymentReportByProfit(profit);
        }

        public PaymentReport GetPaymentReportByAssociationId(int id)
        {
            return paymentReportRepository.GetPaymentReportByAssociationId(id);
        }

        public PaymentReport UpdatePaymentReportEmployeesSalary(PaymentReport paymentReport)
        {
            return paymentReportRepository.UpdatePaymentReportEmployeesSalary(paymentReport);
        }
        public PaymentReport UpdatePaymentReportContractsCost(PaymentReport paymentReport)
        {
            return paymentReportRepository.UpdatePaymentReportContractsCost(paymentReport);
        }
        public PaymentReport UpdatePaymentReportAppsTotalPayDebt(PaymentReport paymentReport)
        {
            return paymentReportRepository.UpdatePaymentReportAppsTotalPayDebt(paymentReport);
        }
        public PaymentReport UpdatePaymentReportAppsCurrentMonth(PaymentReport paymentReport)
        {
            return paymentReportRepository.UpdatePaymentReportAppsCurrentMonth(paymentReport);
        }
        public PaymentReport UpdatePaymentReportOtherPays(PaymentReport paymentReport)
        {
            return paymentReportRepository.UpdatePaymentReportOtherPays(paymentReport);
        }
        public PaymentReport UpdatePaymentReportProfit(PaymentReport paymentReport)
        {
            return paymentReportRepository.UpdatePaymentReportProfit(paymentReport);
        }

    }
}
