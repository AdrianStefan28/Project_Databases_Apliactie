using Microsoft.AspNetCore.Mvc;
using MTAApp.DataAccess.Model;
using MTAApp.Logic;
using System.Diagnostics.Contracts;

namespace MTAApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeService employeeService;

        public EmployeesController(EmployeeService emplService)
        {
            employeeService = emplService;
        }

        public ActionResult Index()
        {
            var employees = employeeService.GetEmployees();
            return View(employees);
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employees= employeeService.GetEmployee(id);
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,FirstName,LastName,Type,CNP,Age,ContractDuration,Salary,AssociationId")] Employee employee)
        {
            try
            {
                employeeService.AddEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(employee);
            }
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = employeeService.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,FirstName,LastName,Type,CNP,Age,ContractDuration,Salary,AssociationId")] Employee employee)

        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            try
            {
                employeeService.UpdateEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(employee);
            }
            return View(employee);
        }

        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = employeeService.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                employeeService.DeleteEmployee(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
