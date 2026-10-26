using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RhProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Base",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Permissao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Modulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissao", x => x.Id);
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
                    BaseId = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cooperados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cooperados_Base_BaseId",
                        column: x => x.BaseId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cooperados_Funcao_FuncaoId",
                        column: x => x.FuncaoId,
                        principalTable: "Funcao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PerfilPermissao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerfilId = table.Column<int>(type: "int", nullable: false),
                    PermissaoId = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilPermissao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerfilPermissao_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PerfilPermissao_Permissao_PermissaoId",
                        column: x => x.PermissaoId,
                        principalTable: "Permissao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SenhaHash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CooperadoId = table.Column<int>(type: "int", maxLength: 1000, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Cooperados_CooperadoId",
                        column: x => x.CooperadoId,
                        principalTable: "Cooperados",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsuarioBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    BaseId = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioBase_Base_BaseId",
                        column: x => x.BaseId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioBase_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioPerfil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    PerfilId = table.Column<int>(type: "int", nullable: false),
                    BaseId = table.Column<int>(type: "int", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPerfil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioPerfil_Base_BaseId",
                        column: x => x.BaseId,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioPerfil_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioPerfil_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
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
                    { 9, true, "RelatoriosVisualizar", new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visualizar relatórios", "Relatorios" },
                    { 10, true, "BaseVisualizar", new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visualizar bases", "Base" },
                    { 11, true, "BaseCriar", new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cadastrar bases", "Base" },
                    { 12, true, "BaseEditar", new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Editar bases", "Base" },
                    { 13, true, "BaseExcluir", new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Excluir bases", "Base" }
                });

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
                    { 14, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8 },
                    { 15, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 9 },
                    { 16, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10 },
                    { 17, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 11 },
                    { 18, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 12 },
                    { 19, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 13 },
                    { 20, true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cooperados_BaseId",
                table: "Cooperados",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Cooperados_FuncaoId",
                table: "Cooperados",
                column: "FuncaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilPermissao_PerfilId_PermissaoId",
                table: "PerfilPermissao",
                columns: new[] { "PerfilId", "PermissaoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PerfilPermissao_PermissaoId",
                table: "PerfilPermissao",
                column: "PermissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissao_Codigo",
                table: "Permissao",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CooperadoId",
                table: "Usuario",
                column: "CooperadoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioBase_BaseId",
                table: "UsuarioBase",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioBase_UsuarioId_BaseId",
                table: "UsuarioBase",
                columns: new[] { "UsuarioId", "BaseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPerfil_BaseId",
                table: "UsuarioPerfil",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPerfil_PerfilId",
                table: "UsuarioPerfil",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPerfil_UsuarioId",
                table: "UsuarioPerfil",
                column: "UsuarioId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerfilPermissao");

            migrationBuilder.DropTable(
                name: "UsuarioBase");

            migrationBuilder.DropTable(
                name: "UsuarioPerfil");

            migrationBuilder.DropTable(
                name: "Permissao");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Cooperados");

            migrationBuilder.DropTable(
                name: "Base");

            migrationBuilder.DropTable(
                name: "Funcao");
        }
    }
}
