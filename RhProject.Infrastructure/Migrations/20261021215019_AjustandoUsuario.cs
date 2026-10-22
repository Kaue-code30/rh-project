using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RhProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjustandoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Cooperados_CooperadoId",
                table: "Usuario");

            migrationBuilder.AlterColumn<int>(
                name: "CooperadoId",
                table: "Usuario",
                type: "int",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 1000);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Cooperados_CooperadoId",
                table: "Usuario",
                column: "CooperadoId",
                principalTable: "Cooperados",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Cooperados_CooperadoId",
                table: "Usuario");

            migrationBuilder.AlterColumn<int>(
                name: "CooperadoId",
                table: "Usuario",
                type: "int",
                maxLength: 1000,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Cooperados_CooperadoId",
                table: "Usuario",
                column: "CooperadoId",
                principalTable: "Cooperados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
