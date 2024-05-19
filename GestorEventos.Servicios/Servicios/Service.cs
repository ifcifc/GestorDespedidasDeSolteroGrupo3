using GestorEventos.Servicios.Entidades;

namespace GestorEventos.Servicios.Servicios
{
    public abstract class Service<T> where T : Entidad 
    {
        public Service() {
            //Para evitar el problema de las comas en los numeros
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        }

        public abstract IEnumerable<T>? GetAll();
        public abstract T? GetByID(int ID);

        public abstract bool Add(T entidad);

        public abstract bool Delete(int ID);

        public abstract bool Modify(int ID, T entidad);

    }
}
