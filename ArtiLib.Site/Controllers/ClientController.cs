using ArtiLib.Entites;
using ArtiLib.Services;
using ArtiLib.Utils;
using System.Web.Mvc;

namespace ArtiLib.Site.Controllers
{
    public class ClientController : Controller
    {
        private ClientService clientService;

        public ClientController()
        {
            clientService = Singleton<ClientService>.Instance;
        }

        // GET: Client
        public ActionResult Index()
        {
            return View(clientService.GetAll());
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            return View(clientService.GetById(id));
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(Client client)
        {
            try
            {
                // TODO: Add insert logic here
                clientService.Add(client);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            return View(clientService.GetById(id));
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Client client)
        {
            try
            {
                // TODO: Add update logic here
                clientService.Edit(client);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            return View(clientService.GetById(id));
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Client client)
        {
            try
            {
                // TODO: Add delete logic here
                clientService.RemoveById(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}