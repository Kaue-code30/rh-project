using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RhProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoBaseIdNoCooperado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BaseId",
                table: "Cooperados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cooperados_BaseId",
                table: "Cooperados",
                column: "BaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cooperados_Base_BaseId",
                table: "Cooperados",
                column: "BaseId",
                principalTable: "Base",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cooperados_Base_BaseId",
                table: "Cooperados");

            migrationBuilder.DropIndex(
                name: "IX_Cooperados_BaseId",
                table: "Cooperados");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "Cooperados");
        }
    }
}
