using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Edu_Station.Migrations
{
    /// <inheritdoc />
    public partial class Inicital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diretores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diretores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Docentes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ano = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdDocente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Docentes_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "Docentes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Disciplinas_Docentes_IdDocente",
                        column: x => x.IdDocente,
                        principalTable: "Docentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTurma = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NomeCompleto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Docentes_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "Docentes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Alunos_Turmas_IdTurma",
                        column: x => x.IdTurma,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocenteTurma",
                columns: table => new
                {
                    DocentesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TurmasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocenteTurma", x => new { x.DocentesId, x.TurmasId });
                    table.ForeignKey(
                        name: "FK_DocenteTurma_Docentes_DocentesId",
                        column: x => x.DocentesId,
                        principalTable: "Docentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocenteTurma_Turmas_TurmasId",
                        column: x => x.TurmasId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoDisciplina",
                columns: table => new
                {
                    AlunosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscipinasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoDisciplina", x => new { x.AlunosId, x.DiscipinasId });
                    table.ForeignKey(
                        name: "FK_AlunoDisciplina_Alunos_AlunosId",
                        column: x => x.AlunosId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoDisciplina_Disciplinas_DiscipinasId",
                        column: x => x.DiscipinasId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Docentes",
                columns: new[] { "Id", "CPF", "DataNascimento", "Email", "NomeCompleto", "Perfil", "Senha", "Telefone" },
                values: new object[,]
                {
                    { new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fb7"), "03223652566", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jose@email.com", "José da Silva Santos", 2, "123", "86995522588" },
                    { new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fb8"), "12345678910", new DateTime(1975, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "maria@email.com", "Maria Oliveira", 2, "456", "86998877441" },
                    { new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fb9"), "98765432100", new DateTime(1990, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "joao@email.com", "João Pereira", 2, "789", "869977336699" },
                    { new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fba"), "55544433322", new DateTime(1985, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ana@email.com", "Ana Souza", 2, "abc", "869911223344" },
                    { new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fbb"), "11223344556", new DateTime(1978, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "pedro@email.com", "Pedro Santos", 2, "def", "869922334455" },
                    { new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fbc"), "99887766554", new DateTime(1982, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "mariana@email.com", "Mariana Costa", 2, "ghi", "869933445566" },
                    { new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fbd"), "77665544332", new DateTime(1970, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "carlos@email.com", "Carlos Oliveira", 2, "jkl", "869944556677" },
                    { new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fbe"), "33445566778", new DateTime(1995, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "aline@email.com", "Aline Pereira", 2, "mno", "869955667788" },
                    { new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fbf"), "22334455667", new DateTime(1987, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "marcos@email.com", "Marcos Silva", 2, "pqr", "869966778899" },
                    { new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fc0"), "77889900123", new DateTime(1983, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "laura@email.com", "Laura Santos", 2, "stu", "869977889900" }
                });

            migrationBuilder.InsertData(
                table: "Turmas",
                columns: new[] { "Id", "Ano", "DataCriacao", "Nome" },
                values: new object[] { new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"), "2024", new DateTime(2024, 4, 11, 10, 28, 40, 3, DateTimeKind.Local).AddTicks(4288), "1A" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "CPF", "DataNascimento", "DocenteId", "Email", "IdTurma", "NomeCompleto", "Perfil", "Senha", "Telefone" },
                values: new object[,]
                {
                    { new Guid("314eb2b5-20ef-4ba4-853c-0b5acfaa45dc"), "56789012345", new DateTime(2004, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "carlosoliveira@mail.com", new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"), "Carlos Oliveira", 3, "123", "11998877665" },
                    { new Guid("54b13b24-bc53-4826-9f9e-b5b75bca12c0"), "67890123456", new DateTime(2003, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "julianalima@mail.com", new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"), "Juliana Lima", 3, "123", "85998877665" },
                    { new Guid("6d1cb8d4-4c70-44e8-8e58-b1c378c5271b"), "45678901234", new DateTime(2005, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "marianacosta@mail.com", new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"), "Mariana Costa", 3, "123", "31997766554" },
                    { new Guid("98bc7d6e-5a1f-4c7c-bddb-93733fb6d4d1"), "01234567890", new DateTime(2003, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mariasilva@mail.com", new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"), "Maria Silva", 3, "123", "85997766554" },
                    { new Guid("a2d6d6b8-6eb6-40a2-978d-ae48fd5f7f6d"), "78901234567", new DateTime(2005, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "lucasferreira@mail.com", new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"), "Lucas Ferreira", 3, "123", "81998877665" },
                    { new Guid("a2e1b68e-f2d8-4e33-9cbf-9fe5125aeff7"), "12345678901", new DateTime(2004, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "joaooliveira@mail.com", new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"), "João Oliveira", 3, "123", "81998877665" },
                    { new Guid("ec1f4354-865e-47a1-8c6f-31f69360b97d"), "34567890123", new DateTime(2004, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "pedrosantos@mail.com", new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"), "Pedro Santos", 3, "123", "21998877665" },
                    { new Guid("f12bc8d1-4e2b-4b5d-af42-b858bb362cf9"), "09876543210", new DateTime(2005, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "fernandolima@mail.com", new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"), "Fernando Lima", 3, "123", "86996655443" },
                    { new Guid("f12bc8d1-4e2b-4b7d-af42-b858bb362cf9"), "09876543210", new DateTime(2005, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "fernandolima@mail.com", new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"), "Fernando Lima", 3, "123", "86996655443" },
                    { new Guid("fb9c8a3b-4dc7-4981-b38f-9a50031e5b84"), "23456789012", new DateTime(2003, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "anasouza@mail.com", new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"), "Ana Souza", 3, "123", "11997766554" }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "DataCriacao", "DocenteId", "IdDocente", "Nome" },
                values: new object[,]
                {
                    { new Guid("c8188f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"), new DateTime(2024, 4, 11, 10, 28, 40, 2, DateTimeKind.Local).AddTicks(340), null, new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fb7"), "Português" },
                    { new Guid("c8188f6e-ffb6-4d1f-9ad5-3f4bb5838fb8"), new DateTime(2024, 4, 11, 10, 28, 40, 2, DateTimeKind.Local).AddTicks(352), null, new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fb8"), "Matemática" },
                    { new Guid("c8188f6e-ffb6-4d1f-9ad5-3f4bb5838fb9"), new DateTime(2024, 4, 11, 10, 28, 40, 2, DateTimeKind.Local).AddTicks(354), null, new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fb9"), "História" },
                    { new Guid("c8188f6e-ffb6-4d1f-9ad5-3f4bb5838fba"), new DateTime(2024, 4, 11, 10, 28, 40, 2, DateTimeKind.Local).AddTicks(356), null, new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fba"), "Geografia" },
                    { new Guid("c8188f6e-ffb6-4d1f-9ad5-3f4bb5838fbb"), new DateTime(2024, 4, 11, 10, 28, 40, 2, DateTimeKind.Local).AddTicks(359), null, new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fbb"), "Ciências" },
                    { new Guid("c8188f6e-ffb6-4d1f-9ad5-3f4bb5838fbc"), new DateTime(2024, 4, 11, 10, 28, 40, 2, DateTimeKind.Local).AddTicks(361), null, new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fbc"), "Inglês" },
                    { new Guid("c8188f6e-ffb6-4d1f-9ad5-3f4bb5838fbd"), new DateTime(2024, 4, 11, 10, 28, 40, 2, DateTimeKind.Local).AddTicks(363), null, new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fbd"), "Educação Física" },
                    { new Guid("c8188f6e-ffb6-4d1f-9ad5-3f4bb5838fbe"), new DateTime(2024, 4, 11, 10, 28, 40, 2, DateTimeKind.Local).AddTicks(366), null, new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fbe"), "Artes" },
                    { new Guid("c8188f6e-ffb6-4d1f-9ad5-3f4bb5838fbf"), new DateTime(2024, 4, 11, 10, 28, 40, 2, DateTimeKind.Local).AddTicks(368), null, new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fbf"), "Química" },
                    { new Guid("c8188f6e-ffb6-4d1f-9ad5-3f4bb5838fc0"), new DateTime(2024, 4, 11, 10, 28, 40, 2, DateTimeKind.Local).AddTicks(370), null, new Guid("c8788f1e-ffb6-4d1f-9ad5-3f4bb5838fc0"), "Física" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDisciplina_DiscipinasId",
                table: "AlunoDisciplina",
                column: "DiscipinasId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_DocenteId",
                table: "Alunos",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_IdTurma",
                table: "Alunos",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_DocenteId",
                table: "Disciplinas",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_IdDocente",
                table: "Disciplinas",
                column: "IdDocente");

            migrationBuilder.CreateIndex(
                name: "IX_DocenteTurma_TurmasId",
                table: "DocenteTurma",
                column: "TurmasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoDisciplina");

            migrationBuilder.DropTable(
                name: "Diretores");

            migrationBuilder.DropTable(
                name: "DocenteTurma");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Docentes");
        }
    }
}
