
The StarWars+ (or StarWarsPlus) API solution is organized by the following directories and projects:

	- Core:
		- DTO (Data Transfer Objects)
		- Entities
		- Services (Services Interfaces & Implementations)

	- Infrastructure:
		- DAL (Data Access Layer, contains Database Context, Entities <-> Model Mapper, Entity Framework Migrations & Model)
		- Repositories (Repositories Interfaces & Implementations)

	- StarWarsPlus (API Startup project, contains the Controllers, DTO <-> Entities Mapper and application configuration files)

The technologies used are:

	- .Net Core 3.1
	- Entity Framework Core 5.0.5
	- Sql Server ((LocalDb)\MSSQLLocalDB)
	- Automapper
	- Swagger UI
	- IIS Express

A first data load (seed) has been prepared, to facilitate API testing, through Entity Framework migrations. By default, the creation of the database and the execution of migrations are carried out automatically when the application is loaded. If necessary, you can update the database from the Nuget Package Manager console with the following command:

	dotnet ef --startup-project StarWarsPlus\StarWarsPlus.csproj database update

Through the previous migration, the following values are allowed:

	- Homeworlds: "Tatooine" and "Hoth"
	- Species: "Human" and "Robot"
	- Genres: "male" and "female".

In case of entering a value outside the previous domain, a BadRequest (400) status will be returned.

Pending tasks (TODOs):

  - Add Tests
  - Add logging
  - Extend error control and show more information to the user
  - Restrict users with duplicate values

