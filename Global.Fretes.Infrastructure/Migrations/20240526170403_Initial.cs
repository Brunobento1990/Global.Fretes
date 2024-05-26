using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Global.Fretes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transportadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Senha = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    Numero = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CriadoEm = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()"),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    Telefone = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    Foto = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfiguracoesContasTransportador",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmailVerificado = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CodigoEmailVerificado = table.Column<Guid>(type: "uuid", nullable: false),
                    DataExpiracaoCodigoEmail = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TransportadorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Numero = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CriadoEm = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracoesContasTransportador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfiguracoesContasTransportador_Transportadores_Transporta~",
                        column: x => x.TransportadorId,
                        principalTable: "Transportadores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConfiguracoesFretesTransportador",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RegiaoDeAtendimento = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    PrecoPorKm = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    TransportadorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Numero = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CriadoEm = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracoesFretesTransportador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfiguracoesFretesTransportador_Transportadores_Transporta~",
                        column: x => x.TransportadorId,
                        principalTable: "Transportadores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TipoVeiculo = table.Column<int>(type: "integer", nullable: false),
                    PesoMaximo = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    TransportadorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Foto = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Numero = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CriadoEm = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculos_Transportadores_TransportadorId",
                        column: x => x.TransportadorId,
                        principalTable: "Transportadores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracoesContasTransportador_CodigoEmailVerificado",
                table: "ConfiguracoesContasTransportador",
                column: "CodigoEmailVerificado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracoesContasTransportador_TransportadorId",
                table: "ConfiguracoesContasTransportador",
                column: "TransportadorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracoesFretesTransportador_RegiaoDeAtendimento",
                table: "ConfiguracoesFretesTransportador",
                column: "RegiaoDeAtendimento");

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracoesFretesTransportador_TransportadorId",
                table: "ConfiguracoesFretesTransportador",
                column: "TransportadorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transportadores_Cpf",
                table: "Transportadores",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transportadores_Email",
                table: "Transportadores",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transportadores_Telefone",
                table: "Transportadores",
                column: "Telefone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_TipoVeiculo",
                table: "Veiculos",
                column: "TipoVeiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_TransportadorId",
                table: "Veiculos",
                column: "TransportadorId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfiguracoesContasTransportador");

            migrationBuilder.DropTable(
                name: "ConfiguracoesFretesTransportador");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Transportadores");
        }
    }
}
