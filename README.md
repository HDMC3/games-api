# Games Api

Web API sencilla para consultar información general sobre algunos videojuegos. Está desarrollada con .Net 6 (utilizando la plantilla minimal), y los datos están almacenados en una base de datos Postgresql.

# Tecnologías usadas

### Frameworks y librerías

- [.NET 8](https://docs.microsoft.com/es-mx/dotnet/fundamentals/)

### Bases de datos

- [Postgresql](https://www.postgresql.org/)

# Recursos
## **Url pública base**
`https://games-api-r4qr.onrender.com`

## **Games**
#### Endpoints
- `/games`
- `/games?id`
- `/games?limit`
- `/games?name`
- `/games/developer/{developerId}?limit`
- `/games/engine/{engineId}?limit`
- `/games/platform/{platformId}?limit`
- `/games/genre/{genreId}?limit`
#### **Game**
| Nombre | Tipo |
|--------|------|
| id | `int` |
| name | `string` |
| publisher | `string` |
| web | `string` \| `null` |
| developer | `GameDeveloper` |
| engine | `GameEngine` |
| genres | `string[]` |
| soundtracks | `GameSoundtrack[]` |
| reviews | `GameReview[]` |
| releases | `GameRelease[]` |
#### **GameDeveloper**, **GameEngine**
| Nombre | Tipo |
|--------|------|
| name | `string` |
| url | `string` |
#### **GameSoundtrack**
| Nombre | Tipo |
|--------|------|
| web | `string` |
| url | `string` |
#### **GameRelease**
| Nombre | Tipo |
|--------|------|
| platform | `string` |
| date | `string` |
#### **GameReview**
| Nombre | Tipo |
|--------|------|
| reviewer | `string` |
| score | `float` |


## **Developers**
#### Endpoints
- `/developers`
- `/developers?id`
- `/developers?limit`
#### **Developer**
| Nombre | Tipo |
|--------|------|
| id | `int` |
| name | `string` |
| web | `string` \| `null` |
| games | `DeveloperGame[]` |
#### **DeveloperGame**
| Nombre | Tipo |
|--------|------|
| name | `string` |
| publisher | `string` |
| url | `string` |


## **Soundtracks**
#### Endpoints
- `/soundtracks`
- `/soundtracks?id`
- `/soundtracks?limit`
#### **Soundtrack**
| Nombre | Tipo |
|--------|------|
| id | `int` |
| name | `string` |
| composer | `string` |
| web | `string` \| `null` |
| game | `SoundtrackGame` |
#### **SoundtrackGame**
| Nombre | Tipo |
|--------|------|
| name | `string` |
| developer | `string` |
| url | `string` |


## **Engines**
#### Endpoints
- `/engines`
- `/engines?id`
- `/engines?limit`
#### **Engine**
| Nombre | Tipo |
|--------|------|
| id | `int` |
| name | `string` |
| languages | `string[]` |
| web | `string` \| `null` |
| games | `EngineGame[]` |
#### **EngineGame**
| Nombre | Tipo |
|--------|------|
| name | `string` |
| developer | `string` |
| url | `string` |


# Getting started

\- Clonar y restaurar los paquetes:
1. `git clone https://github.com/HDMC3/games-api.git`
2. `cd games-api`
3. `dotnet restore`

\- Restaurar las herramientas:

4. `dotnet tool restore`

\- Agregar y aplicar una migración para la creación de la base de datos.

> Para este paso se debe establecer una variable de entorno con el nombre "PG_CON_STR", y como valor una cadena de conexion válida para Postgresql. 

5. `dotnet ef migrations add Initial -p Persistence/ -s Api/`
6. `dotnet ef database update -p Persistence/ -s Api/`

\- Ejecutar el script "db_data.sql" sobre la base de datos creada ([pgAdmin](https://www.pgadmin.org/download/) o [DBeaver](https://dbeaver.io/) son buenas opciones), y ejecuta el proyecto:

7. `dotnet run`