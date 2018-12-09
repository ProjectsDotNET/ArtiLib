using ArtiLib.Entites;
using ArtiLib.Services;
using ArtiLib.Utils;
using System.Web.Mvc;

namespace ArtiLib.Site.Controllers
{
    public class PrestationController : Controller
    {
        private PrestationService prestationService;

        public PrestationController()
        {
            prestationService = Singleton<PrestationService>.Instance;
        }

        // GET: Prestation
        public ActionResult Index()
        {
            return View(prestationService.GetAll());
        }

        // GET: Prestation/Details/5
        public ActionResult Details(int id)
        {
            return View(prestationService.GetById(id));
        }

        // GET: Prestation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prestation/Create
        [HttpPost]
        public ActionResult Create(Prestation prestation)
        {
            try
            {
                // TODO: Add insert logic here
                prestationService.Add(prestation);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Prestation/Edit/5
        public ActionResult Edit(int id)
        {
            return View(prestationService.GetById(id));
        }

        // POST: Prestation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Prestation prestation)
        {
            try
            {
                // TODO: Add update logic here
                prestationService.Edit(prestation);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Prestation/Delete/5
        public ActionResult Delete(int id)
        {
            return View(prestationService.GetById(id));
        }

        // POST: Prestation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Prestation prestation)
        {
            try
            {
                // TODO: Add delete logic here
                prestationService.RemoveById(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}