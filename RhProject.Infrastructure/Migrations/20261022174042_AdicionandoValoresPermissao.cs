using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RhProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoValoresPermissao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Modulo",
                table: "Permissao",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Permissao",
                columns: new[] { "Id", "Ativo", "Codigo", "DataCadastro", "Descricao", "Modulo" },
                values: new object[,]
                {
                    { 1, true, "CooperadoVisualizar", new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visualizar cooperados", "Cooperados" },
                    { 2, true, "CooperadoCriar", new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cadastrar cooperados", "Cooperados" },
                    { 3, true, "CooperadoEditar", new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Editar cooperados", "Cooperados" },
                    { 4, true, "CooperadoExcluir", new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Excluir cooperados", "Cooperados" },
                    { 5, true, "FinanceiroVisualizar", new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visualizar financeiro", "Financeiro" },
                    { 6, true, "FinanceiroGerenciar", new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gerenciar financeiro", "Financeiro" },
                    { 7, true, "FeriasVisualizar", new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visualizar férias", "Ferias" },
                    { 8, true, "FeriasAprovar", new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aprovar férias", "Ferias" },
                    { 9, true, "RelatoriosVisualizar", new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visualizar relatórios", "Relatorios" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissao_Codigo",
                table: "Permissao",
                column: "Codigo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Permissao_Codigo",
                table: "Permissao");

            migrationBuilder.DeleteData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.AlterColumn<string>(
                name: "Modulo",
                table: "Permissao",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
