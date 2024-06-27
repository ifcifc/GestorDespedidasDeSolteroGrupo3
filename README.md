# **Gestor de eventos “Solteros en Fuga” (Grupo 3)**
**Integrantes:**
 - Castellanos, Ignacio ( **ifcifc** )
 - Goñi, Jacqueline ( **jacquelineeee** )
 - Herr, Santiago ( **san-102** )
 - Ristaño, Ana ( **anitierri** )
 - Romano, Eliana ( **ColliePaciente** )

## **Iniciar el sistema**
El sistema ya está listo para iniciar, los datos ya se encuentran en el “appsettings.json”.
El “appsettings.json” contiene los siguientes valores:

 - **SQLConnectionString** Contiene la ConnectionString a la base de datos
 - **DBServer** Qué indica si se va a conectar a Mysql o SQL Server, en esté valor se puede introducir “MSSQL” para SQL Server o “MYSQL” para
   MySQL.
 -  **EnableTransactions** Habilita o deshabilita las Transacciones en el proyecto, es de tipo booleana, se puso debido a qué Dapper por
   alguna razón empezó a lanzar excepciones con el cambio de servidor de
   freesqldatabase a aiven.

El proyecto está actualmente configurado para conectarse a la base de datos MySQL de aiven creada para el proyecto, debido a qué github no permitía subir la contraseña está se encuentra dentro del código de SQLConnect.

Al igual qué el proyecto base esté utiliza Dapper y SQLConnect se encarga de la conexión a la base de dato y así cómo crear una instancia de SqlConnection para SQL Server o un MySqlConnection para MySQL.

El proyecto es compatible con MySQL y con SQL Server. los comandos SQL usados en el proyecto son compatibles con estas dos bases de datos, y los archivos qué están en el proyecto “MysqlDB.sql” y “SQLServerDB.sql” contienen los datos para crear las bases de datos.

## **APIs**
Proyecto utilizan dos APIs para qué el cliente pueda obtener información del servidor, estas APIs se encuentran dentro del proyecto GestorEventos.Api y son cargadas junto a los proyectos WebClient y WebAdmin
 - La Api “ **api/Evento{date}** ” devuelve un valor booleano verdadero
   si existe ya un evento “Aceptado” en una fecha.
 - La Api “ **api/Localidad{int}** ” retorna una lista de ciudades de una provincia.
 
Ambas APIs son accedidas por el cliente a través de JavaScript y JQuery en el momento de
cargar los datos de una persona( _en el momento qué se cambia la provincia seleccionada_ ) o
en el momento de crear una reserva de evento ( _Cuando se elige la fecha para el evento_ ).

## **Proyecto WebAdmin**
Está construido en su mayoría con MVC, con algunos retoques utilizando css, js y html.
Tiene dos apartados principales

 - **Gestionar reservas:** Donde aparecen todas las reservas ordenadas según su estado y donde se puede observar los detalles de la misma y cambiar su estado(Aprobar, Rechazar, ...).
 - **Administrar entidades:** Un menú desde donde se puede crear, eliminar y modificar casi cualquier entidad.

## **Proyecto WebClient**
En esté proyecto la “Página principal”, “FAQ” y “Reservar un evento” están construidas en su totalidad con HTML, CSS y JS.
Mientras qué los Apartados “Mis Personas” y “Mis Eventos” así cómo las vistas de Crear, Editar, Eliminar y Detalles utiliza MVC modificado con HTML, CSS y JS.

Para acceder a “Reservar un evento”, “Mis Personas” y “Mis Eventos” es obligatorio haber
iniciado sesión primero.

## **Estructura de la Solución**:

 - **GestorEventos.Api** Esté proyecto contiene las Apis qué usan los demás proyectos.
 - **GestorEventos.Comun** Es una Biblioteca de Clases qué contiene las clases en común qué utilizan los demás proyectos.
 - **GestorEventos.Servicios** Contiene los servicios y entidades del proyecto, también contiene la clase SQLConnect qué gestiona las llamadas a la base de datos. Los servicios se encuentran declarados en la clase “**ServicesScopes**” de **GestorEventos.Comun**.
 - **GestorEventos.WebAdmin** Proyecto para administrar las entidades.
 - **GestorEventos.WebClient** Proyecto para el cliente.
 - **GestorEventos.Test** Proyecto para realizar pruebas.
