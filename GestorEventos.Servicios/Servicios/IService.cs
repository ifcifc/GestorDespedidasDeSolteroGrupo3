using GestorEventos.Servicios.Entidades;
using Microsoft.AspNetCore.Http;

namespace GestorEventos.Servicios.Servicios
{
    public interface IService<T> where T : Entidad, new()
    {
        public IEnumerable<T>? GetAll();

        public T? GetByID(int idEntity);
        public IEnumerable<T>? GetAllByID(int idEntity);
        public bool Add(T entity);

        public bool Modify(int idEntity, T entity);

        public bool Delete(int idEntity);

        public T FromFormCollection(IFormCollection collection);
    }
}
