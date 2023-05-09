using Microsoft.AspNetCore.Mvc;
using MTAApp.DataAccess.Model;
using MTAApp.Logic;

namespace MTAApp.Controllers
{
    public class PollsController : Controller
    {
        private readonly PollService pollService;

        public PollsController(PollService polService)
        {
            pollService = polService;
        }

        public ActionResult Index()
        {
            var polls = pollService.GetPolls();
            return View(polls);
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var polls = pollService.GetPoll(id);
            if (polls == null)
            {
                return NotFound();
            }

            return View(polls);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Subject,Context,UserId")] Poll poll)
        {
            try
            {
                pollService.AddPoll(poll);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(poll);
            }
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poll = pollService.GetPoll(id);
            if (poll == null)
            {
                return NotFound();
            }

            return View(poll);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Subject,Context,UserId")] Poll poll)
        {
            if (id != poll.Id)
            {
                return NotFound();
            }

            try
            {
                pollService.UpdatePoll(poll);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(poll);
            }
            return View(poll);
        }

        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poll = pollService.GetPoll(id);
            if (poll == null)
            {
                return NotFound();
            }

            return View(poll);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                pollService.DeletePoll(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}

