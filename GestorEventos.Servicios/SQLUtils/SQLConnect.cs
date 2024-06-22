using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

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
            Console.WriteLine("Transacciones desactivadas");
            //this.UseTransactions = true;
            return this;
        }
        private string MakeTransaction(string sql) {
            if (this.UseTransactions) return 
                    ((CONNECTION_TYPE == ConnectionTypes.MYSQL)? "START":"BEGIN") +
                    " TRANSACTION;\n" + sql + ";\nCOMMIT;";
            return sql;
        }
        //Ejecuta un SQL
        //args -> Es la entidad
        public SQLConnect Execute(string sql, object? args = null)
        {
            try
            {
                this.DBConn.Execute(MakeTransaction(sql), args);//Ejecuta el sql
            }
            catch (Exception ex)
            {
                throw new Exception("SQL ERROR:\n\t" + sql.Replace(";", ";\n\t") + "\n", ex);
            }
            return this;
        }

        public T? ExecuteScalar<T>(string sql, object? args = null) {
            
            try
            {
                return this.DBConn.ExecuteScalar<T>(MakeTransaction(sql), args);//Ejecuta el sql
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
                return this.ExecuteWithResult(MakeTransaction(sql), args) == 1;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());

                return false;
            }
        }

        //Ejecuta un sql y devuelve un valor
        public int ExecuteWithResult(string sql, object? args = null)
        {
            try
            {
                int ret = this.DBConn.Execute(MakeTransaction(sql), args);
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
            
            try
            {
                IEnumerable<T> query = this.DBConn.Query<T>(MakeTransaction(sql), args);
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
            
            try
            {
                T? query = this.DBConn.QueryFirstOrDefault<T>(MakeTransaction(sql), args);
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

        public static void SetConfig(string sqlConnection, string dbServer){
            //"SQLConnectionString": "Server=(localdb)\\programacion;Database=gestioneventos;User Id=admin;Password=1234",
            SQLConnect.DEFAULT_CONNECTION_STRING = string.Format(sqlConnection, "AVNS_1UuQ-8eNZQZr_HdHYuc");
            SQLConnect.CONNECTION_TYPE = ConnectionTypes.Parse<ConnectionTypes>(dbServer);
        }
    }


    public enum ConnectionTypes { 
        MSSQL,//SQL SERVER
        MYSQL
    }

}
