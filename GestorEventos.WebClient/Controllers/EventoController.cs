using GestorEventos.Compartido.Controller;
using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Entidades.Models;
using GestorEventos.Servicios.Servicios;
using GestorEventos.Servicios.SQLUtils;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace GestorEventos.WebClient.Controllers
{
    public class EventoController : WebController<EventoModel>
    {
        IService<EstadoEvento> estadoEventoService;
        IService<TipoEvento> tipoEventoService;
        IService<Servicio> sevicioService;
        IService<EventoServicio> eventoServicio;
        EventoService eventoService;
        IService<Persona> personaService;
        public EventoController(
                        IService<EventoModel> eventoModelService, 
                        IService<TipoEvento> tipoEventoService, 
                        IService<EstadoEvento> estadoEventoService, 
                        IService<Servicio> sevicioService, 
                        IService<EventoServicio> eventoServicio,
                        IService<Persona> personaService,
                        IService<Evento> eventoService) : base(eventoModelService)
        {
            this.tipoEventoService = tipoEventoService;
            this.estadoEventoService = estadoEventoService;
            this.sevicioService = sevicioService;
            this.eventoServicio = eventoServicio;
            this.eventoService = (EventoService)eventoService;
            this.personaService = personaService;


        }

        public override ActionResult Edit(int id)
        {
            int IdUsuario = int.Parse(HttpContext.User.Claims.First(x => x.Type == "UsuarioId").Value);
            //ViewBag.Usuarios = usuarioService.GetAll();
            ViewBag.TiposEventos = tipoEventoService.GetAll();
            ViewBag.Personas = personaService.GetAllByID(IdUsuario);
            ViewBag.Servicios = sevicioService.GetAll();
            ViewBag.ServiciosSelect = sevicioService?
                .GetAllByID(id)?
                .Select(item => item.IdServicio).ToList();

            return base.Edit(id);
        }

        public override ActionResult Edit(int id, IFormCollection collection)
        {
            this.EditServicesOfEvent(id, collection["Servicio"]);

            return base.Edit(id, collection);
        }


        public override ActionResult Index()
        {
            int idUsuario = int.Parse(
                    HttpContext.User.Claims.First(x => x.Type == "UsuarioId").Value);
            return View(this.Service.GetAllByID(idUsuario));
        }

        public override ActionResult Details(int id)
        {
            int idEvento = id;
            ViewBag.ListaServicios = this.sevicioService.GetAllByID(idEvento);
            decimal total = 0;
            foreach (Servicio s in ViewBag.ListaServicios) {
                total += s.PrecioServicio;
            }
            ViewBag.ServicioTotal = total.ToString("F2");


            return base.Details(idEvento);
        }

        public override ActionResult Create()
        {
            ViewBag.TiposEventos = tipoEventoService.GetAll();
            ViewBag.Servicios = sevicioService.GetAll();


            return base.Create();
        }

        public override ActionResult Create(IFormCollection collection)
        {
            EventoModel eventoModel = this.Service.FromFormCollection(collection);
            eventoModel.IdEstadoEvento = 1;
            eventoModel.IdPersonaAgasajada = (int)TempData["IdPersonaAgasajada"];
            eventoModel.IdUsuario = int.Parse(
                    HttpContext.User.Claims.First(x => x.Type == "UsuarioId").Value);
            
            TempData["IdPersonaAgasajada"] = null;

            int id = eventoService.AddGetID(eventoModel);

            foreach (var idServicio in (collection["Servicio"]))
            {
                this.eventoServicio.Add(new EventoServicio()
                {
                    IdEvento = id,
                    IdServicio = int.Parse(idServicio)
                });
            }

            return RedirectToAction(nameof(Index)); ;
        }
        public override ActionResult Delete(int id)
        {
            int idPersona = id;
            return base.Delete(idPersona);
        }
        public void EditServicesOfEvent(int idEvent, string[] servicesList)
        {
            StringBuilder query = new StringBuilder()
                .Append("UPDATE EventosServicios SET Borrado=1 WHERE IdEvento=")
                .Append(idEvent)
                .Append(";\n");

            using (var db = SQLConnect.New().Transaction())
            {
                db.Execute(query.ToString());
            }

            foreach (var idServicio in servicesList)
            {
                this.eventoServicio.Add(new EventoServicio()
                {
                    IdEvento = idEvent,
                    IdServicio = int.Parse(idServicio)
                });
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult EventoAction(IFormCollection collection)
        {
            int IdEvento = int.Parse(collection["IdEvento"]);


            switch (collection["actionType"])
            {
                case "Delete": return RedirectToAction("Delete", "Evento", new { id = IdEvento });
                case "Edit": return RedirectToAction("Edit", "Evento", new { id = IdEvento });
                case "Details": return RedirectToAction("Details", "Evento", new { id = IdEvento });
                case "Evento": return RedirectToAction("Index", "Reserva");
            }

            return RedirectToAction(nameof(Index));
        }

        protected override bool ValidateAction(int idEntity)
        {
            int IdUsuario = int.Parse(
                    HttpContext.User.Claims.First(x => x.Type == "UsuarioId").Value);
            return this.eventoService.EventoDeUsuario(idEntity, IdUsuario);
        }

    }
}
