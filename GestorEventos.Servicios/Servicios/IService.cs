using GestorEventos.Servicios.Entidades;
using Microsoft.AspNetCore.Http;

namespace GestorEventos.Servicios.Servicios
{
    //Interfaz para definir los metodos basicos de los Servicios
    public interface IService<T> where T : Entidad, new()
    {
        //Obtiene todos las Entidades
        public IEnumerable<T>? GetAll();
        //Obtiene una entidad segun su ID
        public T? GetByID(int idEntity);
        //Obtiene una lista de entidades segun un id
        public IEnumerable<T>? GetAllByID(int idEntity);
        //Añade la entidad a la base de datos
        public bool Add(T entity);
        //Añade la entidad a la base de datos y retorna el Id insertado
        public int AddGetID(T entity);
        //Modifica la entidad
        public bool Modify(int idEntity, T entity);
        //Borrado logico de la entidad
        public bool Delete(int idEntity);
        //Convierte IFormCollection en una Entidad<T>
        public T FromFormCollection(IFormCollection collection);
    }
}
