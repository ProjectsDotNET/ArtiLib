using ArtiLib.Entites;
using ArtiLib.Services;
using ArtiLib.Utils;
using System.Web.Mvc;

namespace ArtiLib.Site.Controllers
{
    public class DisponibiliteArtisanController : Controller
    {
        private DisponibiliteArtisanService disponibiliteArtisanService;

        public DisponibiliteArtisanController()
        {
            disponibiliteArtisanService = Singleton<DisponibiliteArtisanService>.Instance;
        }

        // GET: DisponibiliteArtisan
        public ActionResult Index()
        {
            return View(disponibiliteArtisanService.GetAllMapping());
        }

        // GET: DisponibiliteArtisan/Details/5
        public ActionResult Details(int id)
        {
            return View(disponibiliteArtisanService.GetById(id));
        }

        // GET: DisponibiliteArtisan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DisponibiliteArtisan/Create
        [HttpPost]
        public ActionResult Create(DisponibiliteArtisan disponibiliteArtisan)
        {
            try
            {
                // TODO: Add insert logic here
                disponibiliteArtisanService.Add(disponibiliteArtisan);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DisponibiliteArtisan/Edit/5
        public ActionResult Edit(int id)
        {
            return View(disponibiliteArtisanService.GetById(id));
        }

        // POST: DisponibiliteArtisan/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DisponibiliteArtisan disponibiliteArtisan)
        {
            try
            {
                // TODO: Add update logic here
                disponibiliteArtisanService.Edit(disponibiliteArtisan);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DisponibiliteArtisan/Delete/5
        public ActionResult Delete(int id)
        {
            return View(disponibiliteArtisanService.GetById(id));
        }

        // POST: DisponibiliteArtisan/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DisponibiliteArtisan disponibiliteArtisan)
        {
            try
            {
                // TODO: Add delete logic here
                disponibiliteArtisanService.RemoveById(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}