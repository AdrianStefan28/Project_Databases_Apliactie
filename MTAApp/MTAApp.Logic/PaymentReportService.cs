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
    }
}
