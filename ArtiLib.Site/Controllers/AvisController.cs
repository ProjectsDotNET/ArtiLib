using ArtiLib.Entites;
using ArtiLib.Services;
using ArtiLib.Utils;
using System.Web.Mvc;

namespace ArtiLib.Site.Controllers
{
    public class AvisController : Controller
    {
        private AvisService avisService;

        public AvisController()
        {
            avisService = Singleton<AvisService>.Instance;
        }

        // GET: Avis
        public ActionResult Index()
        {
            return View(avisService.GetAllMapping());
        }

        // GET: Avis/Details/5
        public ActionResult Details(int id)
        {
            return View(avisService.GetById(id));
        }

        // GET: Avis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Avis/Create
        [HttpPost]
        public ActionResult Create(Avis avis)
        {
            try
            {
                // TODO: Add insert logic here
                avisService.Add(avis);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Avis/Edit/5
        public ActionResult Edit(int id)
        {
            return View(avisService.GetById(id));
        }

        // POST: Avis/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Avis avis)
        {
            try
            {
                // TODO: Add update logic here
                avisService.Edit(avis);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Avis/Delete/5
        public ActionResult Delete(int id)
        {
            return View(avisService.GetById(id));
        }

        // POST: Avis/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Avis avis)
        {
            try
            {
                // TODO: Add delete logic here
                avisService.RemoveById(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}