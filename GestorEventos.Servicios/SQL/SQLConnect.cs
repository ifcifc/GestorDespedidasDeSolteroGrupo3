using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace GestorEventos.Servicios.SQL
{
    public class SQLConnect
    {
        private static readonly string ConnectionString = "Server=(localdb)\\programacion;Database=gestor;User Id=admin;Password=1234";

        public static bool Execute(string sql, object? param = null)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    db.Open();
                    return db.Execute(sql, param) == 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(sql);
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public static IEnumerable<T>? Query<T>(string sql)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    db.Open();
                    return db.Query<T>(sql);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(sql);
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static T? QueryFirst<T>(string sql)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    db.Open();
                    return db.QueryFirst<T>(sql);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(sql);
                Console.WriteLine(ex.ToString());
                return default(T);
            }
        }
    }
}
