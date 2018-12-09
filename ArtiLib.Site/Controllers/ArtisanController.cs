using ArtiLib.Entites;
using ArtiLib.Services;
using ArtiLib.Utils;
using System.Web.Mvc;

namespace ArtiLib.Site.Controllers
{
    public class ArtisanController : Controller
    {
        private ArtisanService artisanService;

        public ArtisanController()
        {
            artisanService = Singleton<ArtisanService>.Instance;
        }

        // GET: Artisan
        public ActionResult Index()
        {
            return View(artisanService.GetAll());
        }

        // GET: Artisan/Details/5
        public ActionResult Details(int id)
        {
            return View(artisanService.GetById(id));
        }

        // GET: Artisan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artisan/Create
        [HttpPost]
        public ActionResult Create(Artisan artisan)
        {
            try
            {
                // TODO: Add insert logic here
                artisanService.Add(artisan);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Artisan/Edit/5
        public ActionResult Edit(int id)
        {
            return View(artisanService.GetById(id));
        }

        // POST: Artisan/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Artisan artisan)
        {
            try
            {
                // TODO: Add update logic here
                artisanService.Edit(artisan);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Artisan/Delete/5
        public ActionResult Delete(int id)
        {
            return View(artisanService.GetById(id));
        }

        // POST: Artisan/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Artisan artisan)
        {
            try
            {
                // TODO: Add delete logic here
                artisanService.RemoveById(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}