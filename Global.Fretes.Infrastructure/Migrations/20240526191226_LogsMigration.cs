using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Global.Fretes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LogsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Host = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Ip = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Path = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Erro = table.Column<string>(type: "character varying(2500)", maxLength: 2500, nullable: true),
                    StatusCode = table.Column<int>(type: "integer", nullable: false),
                    LogLevel = table.Column<int>(type: "integer", nullable: false),
                    Numero = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CriadoEm = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");
        }
    }
}
