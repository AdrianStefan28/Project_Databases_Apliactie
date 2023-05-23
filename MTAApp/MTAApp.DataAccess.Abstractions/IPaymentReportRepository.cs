using MTAApp.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAApp.DataAccess.Abstractions
{
    public interface IPaymentReportRepository : IBaseRepository<PaymentReport>
    {
        PaymentReport? GetPaymentReportByProfit(double profit);
        PaymentReport? GetPaymentReportByAssociationId(int id);
        PaymentReport? UpdatePaymentReportEmployeesSalary(PaymentReport paymentReport);
        PaymentReport? UpdatePaymentReportContractsCost(PaymentReport paymentReport);
        
        PaymentReport? UpdatePaymentReportAppsTotalPayDebt(PaymentReport paymentReport);
       
        PaymentReport? UpdatePaymentReportAppsCurrentMonth(PaymentReport paymentReport);
        
        PaymentReport? UpdatePaymentReportOtherPays(PaymentReport paymentReport);
        PaymentReport? UpdatePaymentReportProfit(PaymentReport paymentReport);
    }
}
