using Microsoft.EntityFrameworkCore.Migrations;

namespace prematix.Web.Migrations
{
    public partial class Modifycc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Telefono",
                table: "Pediatras",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Pediatras",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Cedula",
                table: "Pediatras",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Pediatras",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Pediatras",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "Pediatras",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
