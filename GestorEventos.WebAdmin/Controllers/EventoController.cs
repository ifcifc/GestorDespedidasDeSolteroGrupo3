using GestorEventos.Compartido.Controller;
using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Entidades.Models;
using GestorEventos.Servicios.Servicios;
using GestorEventos.Servicios.SQLUtils;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace GestorEventos.WebAdmin.Controllers
{
    public class EventoController : WebController<EventoModel>
    {
        IService<Usuario> usuarioService;
        IService<EstadoEvento> estadoEventoService;
        IService<TipoEvento> tipoEventoService;
        IService<Persona> personaService;
        IService<Servicio> sevicioService;
        IService<EventoServicio> eventoServicio;
        IService<Evento> eventoService;
        public EventoController(
                        IService<EventoModel> eventoModelService, 
                        IService<Usuario> usuarioService, 
                        IService<TipoEvento> tipoEventoService, 
                        IService<Persona> personaService, 
                        IService<EstadoEvento> estadoEventoService, 
                        IService<Servicio> sevicioService, 
                        IService<EventoServicio> eventoServicio, 
                        IService<Evento> eventoService) : base(eventoModelService)
        {
            this.usuarioService = usuarioService;
            this.tipoEventoService = tipoEventoService;
            this.estadoEventoService = estadoEventoService;
            this.personaService = personaService;
            this.sevicioService = sevicioService;
            this.eventoServicio = eventoServicio;
            this.eventoService = eventoService;
        }

        public override ActionResult Details(int id)
        {
            ViewBag.ListaServicios = this.sevicioService.GetAllByID(id);
            decimal total = 0;
            foreach (Servicio s in ViewBag.ListaServicios) {
                total += s.PrecioServicio;
            }
            ViewBag.ServicioTotal = total.ToString("F2");


            return base.Details(id);
        }


        public override ActionResult Edit(int id)
        {
            ViewBag.Usuarios = usuarioService.GetAll();
            ViewBag.TiposEventos = tipoEventoService.GetAll();
            ViewBag.Personas = personaService.GetAll();
            ViewBag.Servicios = sevicioService.GetAll();
            ViewBag.ServiciosSelect =  sevicioService?
                .GetAllByID(id)?
                .Select(item => item.IdServicio).ToList();


            return base.Edit(id);
        }

        public override ActionResult Edit(int id, IFormCollection collection)
        {

            this.EditServicesOfEvent(id, collection["Servicio"]);

            return base.Edit(id, collection);
        }

        public override ActionResult Create()
        {
            ViewBag.Usuarios = usuarioService.GetAll();
            ViewBag.TiposEventos = tipoEventoService.GetAll();
            ViewBag.Personas = personaService.GetAll();
            ViewBag.Servicios = sevicioService.GetAll();



            return base.Create();
        }

        public override ActionResult Create(IFormCollection collection)
        {
            int id = eventoService.AddGetID(this.Service.FromFormCollection(collection));

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

        public void EditServicesOfEvent(int idEvent, string[] servicesList)
        {
            StringBuilder query = new StringBuilder()
                .Append("UPDATE EventosServicios SET Borrado=1 WHERE IdEvento=")
                .Append(idEvent)
                .Append(";\n");

            Console.WriteLine(query.ToString());
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
    }
}
