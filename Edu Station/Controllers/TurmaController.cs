using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edu_Station.Controllers
{
    public class TurmaController : Controller
    {
        // GET: TurmaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TurmaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TurmaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TurmaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TurmaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TurmaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TurmaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TurmaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
