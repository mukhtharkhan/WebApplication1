using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class carImage_Collection2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarImages_Cars_CarsCarCarId",
                table: "CarImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Cars_CarsCarCarId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_CarsCarCarId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_CarImages_CarsCarCarId",
                table: "CarImages");

            migrationBuilder.DropColumn(
                name: "CarsCarCarId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "CarsCarCarId",
                table: "CarImages");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CarId",
                table: "Rentals",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarImages_CarId",
                table: "CarImages",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarImages_Cars_CarId",
                table: "CarImages",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Cars_CarId",
                table: "Rentals",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarImages_Cars_CarId",
                table: "CarImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Cars_CarId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_CarId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_CarImages_CarId",
                table: "CarImages");

            migrationBuilder.AddColumn<int>(
                name: "CarsCarCarId",
                table: "Rentals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarsCarCarId",
                table: "CarImages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CarsCarCarId",
                table: "Rentals",
                column: "CarsCarCarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarImages_CarsCarCarId",
                table: "CarImages",
                column: "CarsCarCarId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarImages_Cars_CarsCarCarId",
                table: "CarImages",
                column: "CarsCarCarId",
                principalTable: "Cars",
                principalColumn: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Cars_CarsCarCarId",
                table: "Rentals",
                column: "CarsCarCarId",
                principalTable: "Cars",
                principalColumn: "CarId");
        }
    }
}
