using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RhProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TornandoUsuarioPerfilComIdUsuarioUnico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsuarioPerfil_UsuarioId",
                table: "UsuarioPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPerfil_UsuarioId",
                table: "UsuarioPerfil",
                column: "UsuarioId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsuarioPerfil_UsuarioId",
                table: "UsuarioPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPerfil_UsuarioId",
                table: "UsuarioPerfil",
                column: "UsuarioId");
        }
    }
}
