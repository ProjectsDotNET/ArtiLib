using ArtiLib.Entites;
using ArtiLib.Services;
using ArtiLib.Utils;
using System.Web.Mvc;

namespace ArtiLib.Site.Controllers
{
    public class PrestationArtisanController : Controller
    {
        private PrestationArtisanService prestationArtisanService;

        public PrestationArtisanController()
        {
            prestationArtisanService = Singleton<PrestationArtisanService>.Instance;
        }

        // GET: PrestationArtisan
        public ActionResult Index()
        {
            return View(prestationArtisanService.GetAllMapping());
        }

        // GET: PrestationArtisan/Details/5
        public ActionResult Details(int id)
        {
            return View(prestationArtisanService.GetById(id));
        }

        // GET: PrestationArtisan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrestationArtisan/Create
        [HttpPost]
        public ActionResult Create(PrestationArtisan prestationArtisan)
        {
            try
            {
                // TODO: Add insert logic here
                prestationArtisanService.Add(prestationArtisan);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PrestationArtisan/Edit/5
        public ActionResult Edit(int id)
        {
            return View(prestationArtisanService.GetById(id));
        }

        // POST: PrestationArtisan/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PrestationArtisan prestationArtisan)
        {
            try
            {
                // TODO: Add update logic here
                prestationArtisanService.Edit(prestationArtisan);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PrestationArtisan/Delete/5
        public ActionResult Delete(int id)
        {
            return View(prestationArtisanService.GetById(id));
        }

        // POST: PrestationArtisan/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PrestationArtisan prestationArtisan)
        {
            try
            {
                // TODO: Add delete logic here
                prestationArtisanService.RemoveById(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}