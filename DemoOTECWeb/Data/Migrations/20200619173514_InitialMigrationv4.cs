using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoOTECWeb.Data.Migrations
{
    public partial class InitialMigrationv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Valor",
                table: "Cursos",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Cursos");
        }
    }
}
