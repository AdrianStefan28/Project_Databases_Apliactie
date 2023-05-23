using Microsoft.AspNetCore.Mvc;
using MTAApp.DataAccess.Model;
using MTAApp.Logic;

namespace MTAApp.Controllers
{
    public class ContractsController : Controller
    {
        private readonly ContractService contractService;
        private readonly PaymentReportService paymentReportService;

        public ContractsController(ContractService contrService, PaymentReportService payReportService)
        {
            contractService = contrService;
            paymentReportService = payReportService;
        }

        public ActionResult Index()
        {
            var contracts = contractService.GetContracts();
            return View(contracts);
        }

        public ActionResult Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var contracts = contractService.GetContract(id);
            if(contracts == null)
            {
                return NotFound();
            }

            return View(contracts);
        }
       
        public ActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Type,SupplierName,ContractDuration,Cost,AssociationId")] Contract contract)
        {
            try
            {
                contractService.AddContract(contract);
                var paymentReport = paymentReportService.GetPaymentReportByAssociationId(contract.AssociationId);
                if(paymentReport != null && contract.Cost != null && contract.ContractDuration != null) 
                {
                    paymentReport.ContractsCost += contract.ContractDuration * contract.Cost;
                    paymentReportService.UpdatePaymentReportContractsCost(paymentReport);
                    paymentReportService.UpdatePaymentReportProfit(paymentReport);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(contract);
            }
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = contractService.GetContract(id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Type,SupplierName,ContractDuration,Cost,AssociationId")] Contract contract)
        {
            if(id != contract.Id)
            {
                return NotFound();
            }

            try
            {
                contractService.UpdateContract(contract);
                var paymentReport = paymentReportService.GetPaymentReportByAssociationId(contract.AssociationId);
                if (paymentReport != null && contract.Cost != null && contract.ContractDuration != null)
                {
                    paymentReport.ContractsCost += contract.ContractDuration * contract.Cost;
                    paymentReportService.UpdatePaymentReportContractsCost(paymentReport);
                    paymentReportService.UpdatePaymentReportProfit(paymentReport);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(contract);
            }
            return View(contract);
        }

        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = contractService.GetContract(id);
            if(contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var contract = contractService.GetContract(id);
                contractService.DeleteContract(id);
                var paymentReport = paymentReportService.GetPaymentReportByAssociationId(contract.AssociationId);
                if (paymentReport != null && contract.Cost != null && contract.ContractDuration != null)
                {
                    paymentReport.ContractsCost -= contract.ContractDuration * contract.Cost;
                    paymentReportService.UpdatePaymentReportContractsCost(paymentReport);
                    paymentReportService.UpdatePaymentReportProfit(paymentReport);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
