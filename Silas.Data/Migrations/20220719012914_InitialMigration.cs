using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    UltimaCompra = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    Telefone2 = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logger",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Server = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, maxLength: 2147483647, nullable: false),
                    ApplicationName = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    ApplicationVersion = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    Ambient = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    Exception = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    InnerException = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    Stack = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    Line = table.Column<int>(type: "int", nullable: false),
                    CallerMemberName = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    ApplicationOwner = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    Password = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    Scope = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    Role = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Logger");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
