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
    }
}
