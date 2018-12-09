using ArtiLib.Entites;
using ArtiLib.Services;
using ArtiLib.Utils;
using System.Web.Mvc;

namespace ArtiLib.Site.Controllers
{
    public class StatutRendezVousController : Controller
    {
        private StatutRendezVousService statutRendezVousService;

        public StatutRendezVousController()
        {
            statutRendezVousService = Singleton<StatutRendezVousService>.Instance;
        }

        // GET: StatutRendezVous
        public ActionResult Index()
        {
            return View(statutRendezVousService.GetAll());
        }

        // GET: StatutRendezVous/Details/5
        public ActionResult Details(int id)
        {
            return View(statutRendezVousService.GetById(id));
        }

        // GET: StatutRendezVous/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatutRendezVous/Create
        [HttpPost]
        public ActionResult Create(StatutRendezVous statutRendezVous)
        {
            try
            {
                // TODO: Add insert logic here
                statutRendezVousService.Add(statutRendezVous);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StatutRendezVous/Edit/5
        public ActionResult Edit(int id)
        {
            return View(statutRendezVousService.GetById(id));
        }

        // POST: StatutRendezVous/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StatutRendezVous statutRendezVous)
        {
            try
            {
                // TODO: Add update logic here
                statutRendezVousService.Edit(statutRendezVous);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StatutRendezVous/Delete/5
        public ActionResult Delete(int id)
        {
            return View(statutRendezVousService.GetById(id));
        }

        // POST: StatutRendezVous/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, StatutRendezVous statutRendezVous)
        {
            try
            {
                // TODO: Add delete logic here
                statutRendezVousService.RemoveById(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}