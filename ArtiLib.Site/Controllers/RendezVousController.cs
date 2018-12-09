using ArtiLib.Entites;
using ArtiLib.Services;
using ArtiLib.Utils;
using System.Web.Mvc;

namespace ArtiLib.Site.Controllers
{
    public class RendezVousController : Controller
    {
        private RendezVousService rendezVousService;

        public RendezVousController()
        {
            rendezVousService = Singleton<RendezVousService>.Instance;
        }

        // GET: RendezVous
        public ActionResult Index()
        {
            return View(rendezVousService.GetAllMapping());
        }

        // GET: RendezVous/Details/5
        public ActionResult Details(int id)
        {
            return View(rendezVousService.GetById(id));
        }

        // GET: RendezVous/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RendezVous/Create
        [HttpPost]
        public ActionResult Create(RendezVous rendezVous)
        {
            try
            {
                // TODO: Add insert logic here
                rendezVousService.Add(rendezVous);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RendezVous/Edit/5
        public ActionResult Edit(int id)
        {
            return View(rendezVousService.GetById(id));
        }

        // POST: RendezVous/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RendezVous rendezVous)
        {
            try
            {
                // TODO: Add update logic here
                rendezVousService.Edit(rendezVous);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RendezVous/Delete/5
        public ActionResult Delete(int id)
        {
            return View(rendezVousService.GetById(id));
        }

        // POST: RendezVous/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RendezVous rendezVous)
        {
            try
            {
                // TODO: Add delete logic here
                rendezVousService.RemoveById(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}