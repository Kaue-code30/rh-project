using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RhProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoCooperadoEFuncao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cooperados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FuncaoId = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cooperados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cooperados_Funcao_FuncaoId",
                        column: x => x.FuncaoId,
                        principalTable: "Funcao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Funcao",
                columns: new[] { "Id", "Ativo", "DataCadastro", "Descricao" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medico" },
                    { 2, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enfermeiro" },
                    { 3, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "TecnicoEnfermagem" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cooperados_FuncaoId",
                table: "Cooperados",
                column: "FuncaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cooperados");

            migrationBuilder.DropTable(
                name: "Funcao");
        }
    }
}
