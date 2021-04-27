using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("INSERT INTO [dbo].[Homeworld] (Name) VALUES('Tatooine')");
            migrationBuilder
                 .Sql("INSERT INTO [dbo].[Homeworld] (Name) VALUES('Hoth')");

            migrationBuilder
                .Sql("INSERT INTO [dbo].[Specie] (Name) VALUES('Human')");
            migrationBuilder
                 .Sql("INSERT INTO [dbo].[Specie] (Name) VALUES('Robot')");

            migrationBuilder
                .Sql("INSERT INTO [dbo].[User] ([Name],[Height],[HomeworldId],[Gender],[SpecieId],[Created],[Edited]) VALUES('Luke Skywalker', 172, (SELECT Id FROM Homeworld WHERE Name = 'Tatooine'), 'M', (SELECT Id FROM Specie WHERE Name = 'Human'), GETDATE(), GETDATE())");
            migrationBuilder
               .Sql("INSERT INTO [dbo].[User] ([Name],[Height],[HomeworldId],[Gender],[SpecieId],[Created],[Edited]) VALUES('C-3PO', 52, (SELECT Id FROM Homeworld WHERE Name = 'Tatooine'), 'F', (SELECT Id FROM Specie WHERE Name = 'Robot'), GETDATE(), GETDATE())");
            migrationBuilder
               .Sql("INSERT INTO [dbo].[User] ([Name],[Height],[HomeworldId],[Gender],[SpecieId],[Created],[Edited]) VALUES('Test3', 100, (SELECT Id FROM Homeworld WHERE Name = 'Hoth'), 'M', (SELECT Id FROM Specie WHERE Name = 'Human'), GETDATE(), GETDATE())");
            migrationBuilder
               .Sql("INSERT INTO [dbo].[User] ([Name],[Height],[HomeworldId],[Gender],[SpecieId],[Created],[Edited]) VALUES('Test4', 172, (SELECT Id FROM Homeworld WHERE Name = 'Hoth'), 'F', (SELECT Id FROM Specie WHERE Name = 'Robot'), GETDATE(), GETDATE())");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
