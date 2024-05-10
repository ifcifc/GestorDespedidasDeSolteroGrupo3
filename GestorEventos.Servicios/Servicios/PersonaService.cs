using GestorEventos.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
	public class PersonaService
	{
		//IENumerable para esstablecer que es una Lista de Entidades
		public IEnumerable<Persona> Personas{ get; set; }


		//constructor
		public PersonaService()
		{
            this.Personas = new List<Persona>
			{
				new Persona{ IdPersona = 1, Nombre = "Esteban", Apellido = "Gomez", Email = "estebangomez@yopmail.com", Telefono = "1111111", DireccionCalle="Calle_1", DireccionNumero=463, DireccionDepartamento="", DireccionPiso=0, IdLocalidad=1},
				new Persona{ IdPersona = 2, Nombre = "Jose", Apellido = "Peñaloza", Email = "Josepenaloza@yopmail.com", Telefono = "22222222", DireccionCalle="Calle_2", DireccionNumero=753, DireccionDepartamento="B", DireccionPiso=2, IdLocalidad=2},
				new Persona{ IdPersona = 3, Nombre = "Juana", Apellido = "Manzo",  Email = "juanamanzo@yopmail.com", Telefono = "3333333", DireccionCalle="Calle_3", DireccionNumero=1146, DireccionDepartamento="S", DireccionPiso=9, IdLocalidad=3},

			};
		}

		public IEnumerable<Persona> GetPersonas()
		{
			return Personas.Where(e => !e.isDelete); ;
		}

		public Persona? GetPersonaPorId(int IdPersona)
		{
			try
			{
				Persona persona = this.Personas.Where(x => x.IdPersona == IdPersona).First();
				return persona; 
			}
			catch (Exception ex)
			{
				return null;
			}

		}

        public bool Agregar(Persona persona)
        {
            try
            {
                List<Persona> lista = this.Personas.ToList();
                lista.Add(persona);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool Eliminar(int IdPersona)
        {
            try
            {
                var e = this.Personas.FirstOrDefault(x => x.IdPersona == IdPersona);
                e.isDelete = true;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool Modificar(int idPersona, Persona persona)
        {

            var e = this.Personas.FirstOrDefault(x => x.IdPersona == idPersona);
            if (e == null) return false;

            e.IdLocalidad = persona.IdLocalidad;
            e.DireccionPiso = persona.DireccionPiso;
            e.DireccionCalle = persona.DireccionCalle;
            e.DireccionNumero = persona.DireccionNumero;
            e.DireccionPiso = persona.DireccionPiso;
            e.Nombre = persona.Nombre;
            e.Apellido = persona.Apellido;
            e.Telefono = persona.Telefono;
            e.Email = persona.Email;

            return true;
        }

    }
}
