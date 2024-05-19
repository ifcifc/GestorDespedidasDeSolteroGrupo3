using Dapper;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestorEventos.Servicios.SQLUtils
{
    public class SQLExecute
    {
        public static readonly string TSERVICIOS_GET_ALL =   "SELECT * FROM servicios WHERE IsDelete=0;";
        public static readonly string TSERVICIOS_GET_BY_ID = "SELECT * FROM servicios WHERE IsDelete=0 AND IdServicio={0};";
        public static readonly string TSERVICIOS_INSERT =    "INSERT INTO servicios ([Descripcion], [PrecioServicio], [isDelete]) VALUES ('{0}', {1}, 0);";
        public static readonly string TSERVICIOS_DELETE =    "UPDATE servicios SET IsDelete=1 WHERE IdServicio={0};";
        public static readonly string TSERVICIOS_MODIFY =    "UPDATE servicios SET Descripcion='{1}', PrecioServicio={2}  WHERE IdServicio={0};";


        public static readonly string TPROVINCIAS_GET_ALL =   "SELECT * FROM Provincias WHERE IsDelete=0;";
        public static readonly string TPROVINCIAS_GET_BY_ID = "SELECT * FROM Provincias WHERE IsDelete=0 AND IdProvincia={0};";
        public static readonly string TPROVINCIAS_INSERT =    "INSERT INTO Provincias ([Nombre]) VALUES ('{0}');";
        public static readonly string TPROVINCIAS_DELETE =    "UPDATE Provincias SET IsDelete=1 WHERE IdProvincia={0};";
        public static readonly string TPROVINCIAS_MODIFY =    "UPDATE Provincias SET Nombre='{1}' WHERE IdProvincia={0};";


        public static readonly string TLOCALIDADES_GET_ALL =    "SELECT * FROM Localidades WHERE IsDelete=0;";
        public static readonly string TLOCALIDADES_GET_BY_ID =  "SELECT * FROM Localidades WHERE IsDelete=0 AND IdLocalidad={0};";
        public static readonly string TLOCALIDADES_INSERT =     "INSERT INTO Localidades ([IdProvincia], [Nombre], [CodigoArea]) VALUES ({0}, '{1}', {2});";
        public static readonly string TLOCALIDADES_DELETE =     "UPDATE Localidades SET IsDelete=1 WHERE IdLocalidad={0};";
        public static readonly string TLOCALIDADES_MODIFY =     "UPDATE Localidades SET IdProvincia={1}, Nombre='{2}', CodigoArea={3} WHERE IdLocalidad={0};";


        public static readonly string TTIPOEVENTO_GET_ALL =     "SELECT * FROM TipoEventos WHERE IsDelete=0;";
        public static readonly string TTIPOEVENTO_GET_BY_ID =   "SELECT * FROM TipoEventos WHERE IsDelete=0 AND IdTipoEvento={0};";
        public static readonly string TTIPOEVENTO_INSERT =      "INSERT INTO TipoEventos ([Descripcion]) VALUES ('{0}');";
        public static readonly string TTIPOEVENTO_DELETE =      "UPDATE TipoEventos SET IsDelete=1 WHERE IdTipoEvento={0};";
        public static readonly string TTIPOEVENTO_MODIFY =      "UPDATE TipoEventos SET Descripcion='{1}' WHERE IdTipoEvento={0};";


        public static readonly string TEVENTO_GET_ALL =     "SELECT * FROM Eventos WHERE IsDelete=0;";
        public static readonly string TEVENTO_GET_BY_ID =   "SELECT * FROM Eventos WHERE IsDelete=0 AND IdEvento={0};";
        public static readonly string TEVENTO_INSERT =      "INSERT INTO Eventos ([IdTipoEvento], [IdPersonaAgasajada], [IdPersonaContacto], [NombreEvento], [FechaEvento], [CantidadPersonas]) VALUES ({0},{1},{2},'{3}','{4}',{5});";
        public static readonly string TEVENTO_MODIFY =      "UPDATE Eventos SET IdTipoEvento={1}, IdPersonaAgasajada={2}, IdPersonaContacto={3}, NombreEvento='{4}', FechaEvento='{5}', CantidadPersonas={6}  WHERE IdEvento={0}";
        public static readonly string TEVENTO_DELETE =      "UPDATE Eventos SET IsDelete=1 WHERE IdEvento={0};";

        public static readonly string TPERSONA_GET_ALL = "SELECT * FROM Personas WHERE IsDelete=0;";
        public static readonly string TPERSONA_GET_BY_ID = "SELECT * FROM Personas WHERE IsDelete=0 AND IdPersona={0};";
        public static readonly string TPERSONA_INSERT = "INSERT INTO Personas ([IdLocalidad], [Nombre], [Apellido], [Telefono], [Email], [DireccionCalle], [DireccionNumero], [DireccionPiso], [DireccionDepartamento]) VALUES ({0},'{1}','{2}','{3}','{4}','{5}',{6},{7},'{8}');";
        public static readonly string TPERSONA_DELETE = "UPDATE Personas SET IsDelete=1 WHERE IdPersona={0};";
        public static readonly string TPERSONA_MODIFY = "UPDATE Personas SET [IdLocalidad]={1}, [Nombre]='{2}', [Apellido]='{3}', [Telefono]='{4}', [Email]='{5}', [DireccionCalle]='{6}', [DireccionNumero]={7}, [DireccionPiso]={8}, [DireccionDepartamento]='{9}'  WHERE IdPersona={0};";


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

        private string FormatSQL(string sql, params object?[] args) 
        {
            return ((this.HasTransaction) ? "BEGIN TRANSACTION\n" : "")
                          + ((this.HasTransaction && this.HasTryTransaction) ? "BEGIN TRY\n" : "")
                          + string.Format(sql, args) + "\n"
                          + ((this.HasTransaction) ? "COMMIT\n" : "")
                          + ((this.HasTransaction && this.HasTryTransaction) ? "END TRY\nBEGIN CATCH\n ROLLBACK\nEND CATCH\n" : "");
        }

        public bool Execute(string sql) {
            try
            {
                using (IDbConnection db = new SqlConnection(this.ConnectionString))
                {
                    db.Open();
                    return db.Execute(sql) == 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(sql);
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool Execute(string sql, params object?[] args) {
            return this.Execute(this.FormatSQL(sql, args));
        }

        public IEnumerable<T>? Query<T>(string sql)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(this.ConnectionString))
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

        public IEnumerable<T>? Query<T>(string sql, params object?[] args) {
            return this.Query<T>(this.FormatSQL(sql, args));
        }

        public T? QueryFirst<T>(string sql)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(this.ConnectionString))
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
        public T? QueryFirst<T>(string sql, params object?[] args)
        {
            return this.QueryFirst<T>(this.FormatSQL(sql, args));
        }



    }
}
