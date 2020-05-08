using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoOTECWeb.Data.Migrations
{
    public partial class InitialMigrationV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false),
                    Lugar = table.Column<string>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    NumeroEstudiantes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreCompleto = table.Column<string>(nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    AnosExperiencia = table.Column<double>(nullable: false),
                    NumeroTelefono = table.Column<string>(nullable: true),
                    Especialidad = table.Column<string>(nullable: true),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relators_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreCompleto = table.Column<string>(maxLength: 25, nullable: false),
                    Apellido = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    PDE = table.Column<double>(nullable: false),
                    NombreImagen = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    RelatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Relators_RelatorId",
                        column: x => x.RelatorId,
                        principalTable: "Relators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_RelatorId",
                table: "Estudiantes",
                column: "RelatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Relators_CursoId",
                table: "Relators",
                column: "CursoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Relators");

            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
