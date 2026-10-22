using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RhProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoPerfilDeUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "Id", "Ativo", "DataCadastro", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Possui acesso completo ao sistema, podendo gerenciar cooperados, usuários, bases, funções, documentos, férias, financeiro, relatórios e configurações.", "Administrador" },
                    { 2, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Responsável pela gestão dos cooperados vinculados às bases sob sua responsabilidade, podendo consultar informações, acompanhar documentos, plantões e solicitações conforme suas permissões.", "Coordenador" },
                    { 3, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Possui acesso às próprias informações cadastrais, documentos, plantões, saldo de férias, solicitações e treinamentos disponibilizados pelo sistema.", "Cooperado" },
                    { 4, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perfil com permissões configuráveis individualmente, permitindo liberar ou restringir funcionalidades e módulos conforme a necessidade administrativa.", "Personalizado" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Perfil");
        }
    }
}
