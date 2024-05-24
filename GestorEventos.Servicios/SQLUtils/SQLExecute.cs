using Dapper;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestorEventos.Servicios.SQLUtils
{
    public class SQLExecute
    {

        public static string DEFAULT_CONNECTION_STRING = "";

        private string ConnectionString;
        private bool HasTransaction, HasTryTransaction;
        public static SQLExecute New() {
            return new SQLExecute(DEFAULT_CONNECTION_STRING);
        }

        public static SQLExecute New(string connectionString)
        {
            return new SQLExecute(connectionString);
        }

        public SQLExecute(string connectionString) { 
            this.ConnectionString = connectionString;
            this.HasTransaction = false;
            this.HasTryTransaction = false;
        }


        public SQLExecute Transaction() {
            return this.Transaction(false);
        }

        public SQLExecute Transaction(bool tryTransaction)
        {
            this.HasTransaction = true;
            this.HasTryTransaction = tryTransaction;
            return this;
        }

        private string FormatSQL(string sql) //, params object?[] args) 
        {
            return ((this.HasTransaction) ? "BEGIN TRANSACTION\n" : "")
                          + ((this.HasTransaction && this.HasTryTransaction) ? "BEGIN TRY\n" : "")
                          //+ string.Format(sql, args) + "\n"
                          + sql + "\n"
                          + ((this.HasTransaction) ? "COMMIT\n" : "")
                          + ((this.HasTransaction && this.HasTryTransaction) ? "END TRY\nBEGIN CATCH\n ROLLBACK\nEND CATCH\n" : "");
        }


        public bool Execute(string sql, object? args = null) {
            try
            {
                using (IDbConnection db = new SqlConnection(this.ConnectionString))
                {
                    db.Open();
                    return db.Execute(this.FormatSQL(sql), args) == 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(sql);
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public IEnumerable<T>? Query<T>(string sql, object? args = null)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(this.ConnectionString))
                {
                    db.Open();
                    return db.Query<T>(this.FormatSQL(sql), args);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(sql);
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public T? QueryFirst<T>(string sql, object? args = null)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(this.ConnectionString))
                {
                    db.Open();
                    return db.QueryFirst<T>(this.FormatSQL(sql), args);
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
