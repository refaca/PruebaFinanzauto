using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaFinanzauto.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarEstudiante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Celphone",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Celphone",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Estudiantes");
        }
    }
}
