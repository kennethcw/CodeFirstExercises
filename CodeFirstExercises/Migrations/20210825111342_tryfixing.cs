using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstExercises.Migrations
{
    public partial class tryfixing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Lastbilar");

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "Lastbilar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lastbilar_ManufacturerId",
                table: "Lastbilar",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lastbilar_Manufacturers_ManufacturerId",
                table: "Lastbilar",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lastbilar_Manufacturers_ManufacturerId",
                table: "Lastbilar");

            migrationBuilder.DropIndex(
                name: "IX_Lastbilar_ManufacturerId",
                table: "Lastbilar");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "Lastbilar");

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Lastbilar",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
