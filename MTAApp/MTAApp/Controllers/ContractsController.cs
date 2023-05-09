using Microsoft.AspNetCore.Mvc;
using MTAApp.DataAccess.Model;
using MTAApp.Logic;

namespace MTAApp.Controllers
{
    public class ContractsController : Controller
    {
        private readonly ContractService contractService;

        public ContractsController(ContractService contrService)
        {
            contractService = contrService;
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
                contractService.DeleteContract(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
