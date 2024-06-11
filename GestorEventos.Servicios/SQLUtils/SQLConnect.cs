using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestorEventos.Servicios.SQLUtils
{
    public class SQLConnect : IDisposable
    {

        public static string DEFAULT_CONNECTION_STRING = "";

        //Para indicar el tipo de servidor a conectarse
        public static ConnectionTypes CONNECTION_TYPE = ConnectionTypes.MSSQL;

        private string ConnectionString;
        private IDbConnection?  DBConn;//Para almacenar manejar la coneccion con la DB
        private bool UseTransactions;

        //Crea una instancia de SQLConnect usando DEFAULT_CONNECTION_STRING
        public static SQLConnect New() {
            return new SQLConnect(DEFAULT_CONNECTION_STRING);
        }

        //Crea una instancia de SQLConnect
        public static SQLConnect New(string connectionString)
        {
            return new SQLConnect(connectionString);
        }

        public SQLConnect(string connectionString) { 
            this.ConnectionString = connectionString;

            //Crea la un objeto IDbConnection con el ConnectionString
            this.DBConn = (CONNECTION_TYPE == ConnectionTypes.MSSQL) ? 
                new SqlConnection(this.ConnectionString) : 
                new MySqlConnection(this.ConnectionString);
            
            
                


            try//Para comprobar si hay errores
            {
                this.DBConn.Open();//Conecta con la base de datos
            }
            catch (Exception ex)//Si se produce un error esto se executara
            {
                throw new Exception("SQL ERROR: Connection DB.\n", ex);//Muestra un mensaje de que tipo de error es y muestra la informacion mas detallada
            }
            
        }

        ~SQLConnect() {//Destructor se ejecuta al eliminar la instancia
            this.Dispose();
        }

        //Inicia una transaccion
        public SQLConnect Transaction() {
            this.UseTransactions = true;
            return this;
        }

        //Ejecuta un SQL
        //args -> Es la entidad
        public SQLConnect Execute(string sql, object? args = null)
        {
            if (this.UseTransactions) sql = "START TRANSACTION;\n" + sql + ";\n COMMIT;";
            try
            {
                this.DBConn.Execute(sql, args);//Ejecuta el sql
            }
            catch (Exception ex)
            {
                throw new Exception("SQL ERROR:\n\t" + sql.Replace(";", ";\n\t") + "\n", ex);
            }
            return this;
        }

        public T? ExecuteScalar<T>(string sql, object? args = null) {
            if (this.UseTransactions) sql = "START TRANSACTION;\n" + sql + ";\n COMMIT;";
            try
            {
                return this.DBConn.ExecuteScalar<T>(sql, args);//Ejecuta el sql
            }
            catch (Exception ex)
            {
                throw new Exception("SQL ERROR:\n\t" + sql.Replace(";", ";\n\t") + "\n", ex);
            }
        }


        //Ejecuta un sql, si no se producen errores devuelve true
        public bool ExecuteWithCheck(string sql, object? args = null) 
        {
            try
            {
                return this.ExecuteWithResult(sql, args) == 1;
            }
            catch (Exception) 
            {
                return false;
            }
        }

        //Ejecuta un sql y devuelve un valor
        public int ExecuteWithResult(string sql, object? args = null)
        {
            if (this.UseTransactions) sql = "START TRANSACTION;\n" + sql + ";\nCOMMIT;";
            try
            {
                Console.WriteLine(sql);
                int ret = this.DBConn.Execute(sql, args);
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("SQL ERROR: " + sql.Replace(";", ";\n") + "\n", ex);
            }
        }

        //Ejecuta una Query
        public IEnumerable<T>? Query<T>(string sql, object? args = null)
        {
            if (this.UseTransactions) sql = "START TRANSACTION;\n" + sql + ";\n COMMIT;";
            try
            {
                IEnumerable<T> query = this.DBConn.Query<T>(sql, args);
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception("SQL ERROR: " + sql.Replace(";", ";\n") + "\n", ex);
            }
        }

        //Ejecuta una Query y devuelve un unico elemento
        public T? QueryFirst<T>(string sql, object? args = null)
        {
            if (this.UseTransactions) sql = "START TRANSACTION;\n" + sql + ";\n COMMIT;";
            try
            {
                T? query = this.DBConn.QueryFirstOrDefault<T>(sql, args);
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception("SQL ERROR: " + sql.Replace(";", ";\n") + "\n", ex);
            }
        }

        //Se llama al finalizar
        public void Dispose() {
            this.DBConn?.Close();//Si se establecio una coneccion con la DB se cierra.
            this.DBConn?.Dispose();
        }
    }


    public enum ConnectionTypes { 
        MSSQL,//SQL SERVER
        MYSQL
    }

}
