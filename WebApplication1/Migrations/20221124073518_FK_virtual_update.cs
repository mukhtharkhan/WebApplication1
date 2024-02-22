using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class FK_virtual_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_Rentals_CustId",
                table: "Rentals",
                column: "CustId");

            migrationBuilder.CreateIndex(
                name: "IX_CarImages_CarsCarCarId",
                table: "CarImages",
                column: "CarsCarCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_RentalId",
                table: "Bills",
                column: "RentalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Rentals_RentalId",
                table: "Bills",
                column: "RentalId",
                principalTable: "Rentals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Customer_CustId",
                table: "Rentals",
                column: "CustId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Rentals_RentalId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_CarImages_Cars_CarsCarCarId",
                table: "CarImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Cars_CarsCarCarId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Customer_CustId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_CarsCarCarId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_CustId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_CarImages_CarsCarCarId",
                table: "CarImages");

            migrationBuilder.DropIndex(
                name: "IX_Bills_RentalId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "CarsCarCarId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "CarsCarCarId",
                table: "CarImages");
        }
    }
}
