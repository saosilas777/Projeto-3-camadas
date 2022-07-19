using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class DbSilas : Migration
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
                    Telefone2 = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
