using Dapper;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestorEventos.Servicios.SQLUtils
{
    public class SQLConnect : IDisposable
    {

        public static string DEFAULT_CONNECTION_STRING = "";

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
            this.DBConn = new SqlConnection(this.ConnectionString);//Crea la un objeto IDbConnection con el ConnectionString
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

        private IDbTransaction? BeginTransaction() 
        {
            try
            {
                return this.UseTransactions ? this.DBConn.BeginTransaction() : null;
            }
            catch (Exception ex){
                throw new Exception("SQL ERROR: Connection DB.\n", ex);
            }
        }

        //Ejecuta un SQL
        //args -> Es la entidad
        public SQLConnect Execute(string sql, object? args = null)
        {
            var DBTran = this.BeginTransaction();
            try
            {
                this.DBConn.Execute(sql, args, DBTran);//Ejecuta el sql
                DBTran?.Commit();
            }
            catch (Exception ex)
            {
                DBTran?.Rollback();
                ////Se revierte las operaciones y se cierra la transaccion
                throw new Exception("SQL ERROR:\n\t" + sql.Replace(";", ";\n\t") + "\n", ex);
            }
            return this;
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
            var DBTran = this.BeginTransaction();
            try
            {
                int ret = this.DBConn.Execute(sql, args, DBTran);
                DBTran?.Commit();
                return ret;
            }
            catch (Exception ex)
            {
                DBTran?.Rollback();
                throw new Exception("SQL ERROR: " + sql.Replace(";", ";\n") + "\n", ex);
            }
        }

        //Ejecuta una Query
        public IEnumerable<T>? Query<T>(string sql, object? args = null)
        {
            var DBTran = this.BeginTransaction();
            try
            {
                IEnumerable<T> query = this.DBConn.Query<T>(sql, args, DBTran);
                DBTran?.Commit();
                return query;
            }
            catch (Exception ex)
            {
                DBTran?.Rollback();
                throw new Exception("SQL ERROR: " + sql.Replace(";", ";\n") + "\n", ex);
            }
        }

        //Ejecuta una Query y devuelve un unico elemento
        public T? QueryFirst<T>(string sql, object? args = null)
        {
            var DBTran = this.BeginTransaction();
            try
            {
                T? query = this.DBConn.QueryFirstOrDefault<T>(sql, args, DBTran);
                DBTran?.Commit();
                return query;
            }
            catch (Exception ex)
            {
                DBTran?.Rollback();
                throw new Exception("SQL ERROR: " + sql.Replace(";", ";\n") + "\n", ex);
            }
        }

        //Se llama al finalizar
        public void Dispose() {
            this.DBConn?.Close();//Si se establecio una coneccion con la DB se cierra.
            this.DBConn?.Dispose();
        }
    }
}
