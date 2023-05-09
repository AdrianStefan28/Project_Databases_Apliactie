using Microsoft.AspNetCore.Mvc;
using MTAApp.DataAccess.Model;
using MTAApp.Logic;
using System.Diagnostics.Contracts;

namespace MTAApp.Controllers
{
    public class PaymentReportsController : Controller
    {
        private readonly PaymentReportService paymentReportService;

        public PaymentReportsController(PaymentReportService prService)
        {
            paymentReportService = prService;
        }

        public ActionResult Index()
        {
            var paymentReports = paymentReportService.GetPaymentReports();
            return View(paymentReports);
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var paymentReports = paymentReportService.GetPaymentReport(id);
            if (paymentReports == null)
            {
                return NotFound();
            }

            return View(paymentReports);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,EmployeesSalary,ContractsCost,RepairingFund,AppsPayCurrentMonth,AppsPayTotalDebt,OtherPays,Expense,Income,Profit,AssociationId")] PaymentReport paymentReport)
        {
            try
            {
                paymentReportService.AddPaymentReport(paymentReport);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(paymentReport);
            }
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentReport = paymentReportService.GetPaymentReport(id);
            if (paymentReport == null)
            {
                return NotFound();
            }

            return View(paymentReport);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,EmployeesSalary,ContractsCost,RepairingFund,AppsPayCurrentMonth,AppsPayTotalDebt,OtherPays,Expense,Income,Profit,AssociationId")] PaymentReport paymentReport)
        {
            if (id != paymentReport.Id)
            {
                return NotFound();
            }

            try
            {
                paymentReportService.UpdatePaymentReport(paymentReport);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(paymentReport);
            }
            return View(paymentReport);
        }

        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentReport = paymentReportService.GetPaymentReport(id);
            if (paymentReport == null)
            {
                return NotFound();
            }

            return View(paymentReport);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                paymentReportService.DeletePaymentReport(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
