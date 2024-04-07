using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Edu_Station.Controllers
{
    public class DirecaoController : Controller
    {
        // GET: DirecaoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DirecaoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DirecaoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DirecaoController/Create
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

        // GET: DirecaoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DirecaoController/Edit/5
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

        // GET: DirecaoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DirecaoController/Delete/5
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
