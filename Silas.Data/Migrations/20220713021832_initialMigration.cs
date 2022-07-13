using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logger");
        }
    }
}
