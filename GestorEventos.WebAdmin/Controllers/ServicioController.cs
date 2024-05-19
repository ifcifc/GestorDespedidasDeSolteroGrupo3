using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GestorEventos.WebAdmin.Controllers
{
    public class ServicioController : Controller
    {
        // GET: ServicioController
        public ActionResult Index()
        {
            ServicioService ss = new ServicioService();
            
            return View(ss.GetAll());
        }

        // GET: ServicioController/Details/5
        public ActionResult Details(int id)
        {
            ServicioService ss = new ServicioService();
            return View(ss.GetByID(id));
        }

        // GET: ServicioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                ServicioService ss = new ServicioService();

                Servicio servicio = new Servicio();
                servicio.Descripcion = collection["Descripcion"].ToString();
                servicio.PrecioServicio = decimal.Parse(collection["PrecioServicio"].ToString());
                ss.Add(servicio);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServicioController/Edit/5
        public ActionResult Edit(int id)
        {
            ServicioService ss = new ServicioService();
            return View(ss.GetByID(id));
        }

        // POST: ServicioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                ServicioService ss = new ServicioService();
                
                Servicio servicio = new Servicio();
                servicio.Descripcion = collection["Descripcion"].ToString();
                servicio.PrecioServicio = decimal.Parse(collection["PrecioServicio"].ToString());

                ss.Modify(
                    id,
                    servicio);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServicioController/Delete/5
        public ActionResult Delete(int id)
        {

            ServicioService ss = new ServicioService();
            return View(ss.GetByID(id));
        }

        // POST: ServicioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                ServicioService ss = new ServicioService();
                ss.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
