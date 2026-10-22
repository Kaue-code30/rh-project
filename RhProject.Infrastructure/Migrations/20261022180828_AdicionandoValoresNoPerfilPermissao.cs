using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RhProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoValoresNoPerfilPermissao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PerfilPermissao_PerfilId",
                table: "PerfilPermissao");

            migrationBuilder.InsertData(
                table: "PerfilPermissao",
                columns: new[] { "Id", "Ativo", "DataCadastro", "PerfilId", "PermissaoId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 4, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 5, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5 },
                    { 6, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 6 },
                    { 7, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 7 },
                    { 8, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8 },
                    { 9, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9 },
                    { 10, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 11, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 12, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 13, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 7 },
                    { 14, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerfilPermissao_PerfilId_PermissaoId",
                table: "PerfilPermissao",
                columns: new[] { "PerfilId", "PermissaoId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PerfilPermissao_PerfilId_PermissaoId",
                table: "PerfilPermissao");

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "PerfilPermissao",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.CreateIndex(
                name: "IX_PerfilPermissao_PerfilId",
                table: "PerfilPermissao",
                column: "PerfilId");
        }
    }
}
