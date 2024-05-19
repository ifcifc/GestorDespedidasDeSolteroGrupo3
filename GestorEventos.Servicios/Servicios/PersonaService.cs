using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.SQLUtils;

namespace GestorEventos.Servicios.Servicios
{
    public class PersonaService : Service<Persona>
	{
		public PersonaService()
		{
		}

		override public IEnumerable<Persona>? GetAll()
		{
            return SQLExecute
                    .New()
                    .Query<Persona>(SQLExecute.TPERSONA_GET_ALL);
		}

        override public Persona? GetByID(int idPersona)
		{
            return SQLExecute
                    .New()
                    .QueryFirst<Persona>(SQLExecute.TPERSONA_GET_BY_ID, idPersona);
        }

        override public bool Add(Persona persona)
        {
            return SQLExecute
                    .New()
                    .Transaction(true)
                    .Execute(SQLExecute.TPERSONA_INSERT, 
                            persona.IdLocalidad, 
                            persona.Nombre, 
                            persona.Apellido,
                            persona.Telefono,
                            persona.Email, 
                            persona.DireccionCalle, 
                            persona.DireccionNumero, 
                            persona.DireccionPiso, 
                            persona.DireccionDepartamento);
        }

        override public bool Delete(int IdPersona)
        {
            return SQLExecute
                    .New()
                    .Transaction(true)
                    .Execute(SQLExecute.TPERSONA_DELETE, IdPersona);
        }


        override public bool Modify(int idPersona, Persona persona)
        {
            return SQLExecute
                    .New()
                    .Transaction(true)
                    .Execute(SQLExecute.TPERSONA_MODIFY,
                            idPersona,
                            persona.IdLocalidad,
                            persona.Nombre,
                            persona.Apellido,
                            persona.Telefono,
                            persona.Email,
                            persona.DireccionCalle,
                            persona.DireccionNumero,
                            persona.DireccionPiso,
                            persona.DireccionDepartamento);
        }

    }
}
