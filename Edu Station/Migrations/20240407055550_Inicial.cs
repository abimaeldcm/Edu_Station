using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Edu_Station.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Docentes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docentes", x => x.Id);
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
                    DocenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Docentes_DocenteId",
                        column: x => x.DocenteId,
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
                table: "Turmas",
                columns: new[] { "Id", "Ano", "DataCriacao", "Nome" },
                values: new object[] { new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"), "2024", new DateTime(2024, 4, 7, 2, 55, 49, 873, DateTimeKind.Local).AddTicks(5686), "1A" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "CPF", "DataNascimento", "DocenteId", "Email", "IdTurma", "NomeCompleto", "Telefone" },
                values: new object[,]
                {
                    { new Guid("94d7934e-3462-4b97-91c7-6a7d16d456ad"), "01234567890", new DateTime(2003, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "carlasantos@mail.com", new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"), "Carla Santos", "86995544333" },
                    { new Guid("963c7e5d-2f0e-45ec-8d4e-1216f62627d7"), "98765432109", new DateTime(1998, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "joaosilva@mail.com", new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"), "João da Silva", "86997654321" },
                    { new Guid("a3c750e3-3d79-4d3e-923e-2fcd52794c0c"), "45678912345", new DateTime(2001, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "anasouza@mail.com", new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"), "Ana Souza", "86999887766" },
                    { new Guid("bd923fe1-3e73-4dda-ae5c-c27588ab08db"), "06445225447", new DateTime(1999, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "josearimateia@mail.com", new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"), "José de Arimateia", "86995258775" },
                    { new Guid("e3f72cbf-35ed-4f7e-8476-72ba3c3cc5e3"), "12345678901", new DateTime(2000, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mariasilva@mail.com", new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"), "Maria da Silva", "86991234567" },
                    { new Guid("e5b01b44-32b8-4c5d-8090-23c2d0a0c6cb"), "98765432198", new DateTime(2002, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "pedrooliveira@mail.com", new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"), "Pedro Oliveira", "86994433221" },
                    { new Guid("f12bc8d1-4e2b-4b7d-af42-b858bb362cf9"), "09876543210", new DateTime(2005, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "fernandolima@mail.com", new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"), "Fernando Lima", "86996655443" },
                    { new Guid("fb03391d-6223-4a4c-87f6-ec131dbbd99d"), "10293847560", new DateTime(2004, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "marianaoliveira@mail.com", new Guid("c8788f6e-ffb6-4d1f-9ad5-3f4bb5838fb7"), "Mariana Oliveira", "86993322111" }
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
                name: "DocenteTurma");

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
