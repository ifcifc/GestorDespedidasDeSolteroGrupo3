using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.SQLUtils;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using static Dapper.SqlMapper;

namespace GestorEventos.Servicios.Servicios
{
    public class Service<T> : IService<T> where T : Entidad, new()
    {
        public Service()
        {
            //Para evitar el problema de las comas en los numeros
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        }

        public virtual IEnumerable<T>? GetAll()
        {
            using (var db = SQLConnect.New())
            {
                return db.Query<T>(new T().SQL_GetAll());
            }
        }

        public virtual IEnumerable<T>? GetAllByID(int idEntity)
        {
            using (var db = SQLConnect.New())
            {
                return db.Query<T>(string.Format(new T().SQL_GetAllByID(), idEntity));
            }
        }

        public virtual T? GetByID(int idEntity)
        {
            using (var db = SQLConnect.New())
            {
                return db.QueryFirst<T>(string.Format(new T().SQL_GetByID(), idEntity));
            }
        }


        public virtual bool Add(T entity)
        {
            using (var db = SQLConnect.New().Transaction())
            {
                return db.ExecuteWithCheck(new T().SQL_Add(), entity);
            }       
        }

        public virtual bool Modify(int idEntity, T entity)
        {
            using (var db = SQLConnect.New().Transaction())
            {
                return db.ExecuteWithCheck(string.Format(new T().SQL_Modify(), idEntity), entity);
            }
        }

        public virtual bool Delete(int idEntity)
        {
            Console.WriteLine(">" + idEntity);

            using (var db = SQLConnect.New().Transaction())
            {
                return db.ExecuteWithCheck(string.Format(new T().SQL_Delete(), idEntity));
            }
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

        public virtual int AddGetID(T entity)
        {
            
            using (var db = SQLConnect.New().Transaction())
            {
                return db.ExecuteScalar<int>(string.Format(new T().SQL_Add_GET_ID(),
                    (SQLConnect.CONNECTION_TYPE == ConnectionTypes.MSSQL) ?
                        "CAST(SCOPE_IDENTITY() AS int)" : "LAST_INSERT_ID()")
                    , entity); ;
            }
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
