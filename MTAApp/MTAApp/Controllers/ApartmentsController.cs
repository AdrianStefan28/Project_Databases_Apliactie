using Microsoft.AspNetCore.Mvc;
using MTAApp.DataAccess.Model;
using MTAApp.Logic;

namespace MTAApp.Controllers
{
    public class ApartmentsController : Controller
    {
      
        private readonly ApartmentService apartmentService;

        public ApartmentsController(ApartmentService aprService)
        {
            apartmentService = aprService;
        }

        public ActionResult Index()
        {
            var apartments = apartmentService.GetApartments();
            return View(apartments);
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var apartments = apartmentService.GetApartment(id);
            if (apartments == null)
            {
                return NotFound();
            }

            return View(apartments);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,ApNumber, TenantName, NoPeople, NoRooms, ColdWater, HotWater, ExtraPayments, CurrentMonthPayment, TotalPaymentDebt, UserId")] Apartment apartment)
        {
            try
            {
                apartmentService.AddApartment(apartment);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(apartment);
            }
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = apartmentService.GetApartment(id);
            if (apartment == null)
            {
                return NotFound();
            }

            return View(apartment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,ApNumber, TenantName, NoPeople, NoRooms, ColdWater, HotWater, ExtraPayments, CurrentMonthPayment, TotalPaymentDebt, UserId")] Apartment apartment)
        {
            if (id != apartment.Id)
            {
                return NotFound();
            }

            try
            {
                apartmentService.UpdateApartment(apartment);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(apartment);
            }
            return View(apartment);
        }

        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = apartmentService.GetApartment(id);
            if (apartment == null)
            {
                return NotFound();
            }

            return View(apartment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                apartmentService.DeleteApartment(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}

