using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManagementApplication.Migrations
{
    /// <inheritdoc />
    public partial class Add_Many_To_Many2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garages_Cars_CarId",
                table: "Garages");

            migrationBuilder.DropIndex(
                name: "IX_Garages_CarId",
                table: "Garages");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Garages");

            migrationBuilder.CreateTable(
                name: "CarGarage",
                columns: table => new
                {
                    CarsId = table.Column<long>(type: "bigint", nullable: false),
                    GaragesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarGarage", x => new { x.CarsId, x.GaragesId });
                    table.ForeignKey(
                        name: "FK_CarGarage_Cars_CarsId",
                        column: x => x.CarsId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarGarage_Garages_GaragesId",
                        column: x => x.GaragesId,
                        principalTable: "Garages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarGarage_GaragesId",
                table: "CarGarage",
                column: "GaragesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarGarage");

            migrationBuilder.AddColumn<long>(
                name: "CarId",
                table: "Garages",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Garages_CarId",
                table: "Garages",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Garages_Cars_CarId",
                table: "Garages",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");
        }
    }
}
