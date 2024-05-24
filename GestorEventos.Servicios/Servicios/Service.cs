using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.SQLUtils;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace GestorEventos.Servicios.Servicios
{

    public class Service<T> : IService<T> where T : Entidad, new()
    {
        public virtual string SQL_GetAll => "";
        public virtual string SQL_GetByID => "";
        public virtual string SQL_Add => "";
        public virtual string SQL_Delete => "";
        public virtual string SQL_Modify => "";

        public Service() {
            //Para evitar el problema de las comas en los numeros
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        }

        public virtual IEnumerable<T>? GetAll()
        {
            return SQLExecute
                    .New()
                    .Query<T>(SQL_GetAll);
        }

        public virtual T? GetByID(int idEntity)
        {
            return SQLExecute
                    .New()
                    .QueryFirst<T>(string.Format(SQL_GetByID, idEntity));
        }


        public virtual bool Add(T entity)
        {
            return SQLExecute
                    .New()
                    .Transaction(true)
                    .Execute(SQL_Add, entity);
        }

        public virtual bool Modify(int idEntity, T entity)
        {
            return SQLExecute
                    .New()
                    .Transaction(true)
                    .Execute(string.Format(SQL_Modify, idEntity), entity);
        }

        public virtual bool Delete(int idEntity)
        {
            return SQLExecute
                    .New()
                    .Transaction(true)
                    .Execute(string.Format(SQL_Delete, idEntity));

        }

        public T FromFormCollection(IFormCollection collection)// where X : new()
        {
            T entidad = new T();
            Type type = entidad.GetType();

            foreach (var item in collection)
            {
                PropertyInfo? propertyInfo = type.GetProperty(item.Key);
                if (propertyInfo == null) continue;
                propertyInfo.SetValue(
                        entidad,
                        ParseValue(item.Value, propertyInfo.PropertyType));
            }

            return entidad;
        }

        private static Object? ParseValue(String value, Type type)
        {

            if (type == typeof(int)) return int.Parse(value);
            if (type == typeof(long)) return long.Parse(value);
            if (type == typeof(bool)) return bool.Parse(value);
            if (type == typeof(float)) return float.Parse(value);
            if (type == typeof(double)) return double.Parse(value);
            if (type == typeof(decimal)) return decimal.Parse(value);
            if (type == typeof(DateTime)) return DateTime.Parse(value);

            if (type != typeof(string)) Console.WriteLine("Tipo de dato desconocido: " + type.Name);

            return value;
        }

    }
}
