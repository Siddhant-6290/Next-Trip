using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TMS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TourPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourPackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TourPackageId = table.Column<int>(type: "int", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConfirmedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_TourPackages_TourPackageId",
                        column: x => x.TourPackageId,
                        principalTable: "TourPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TourPackages",
                columns: new[] { "Id", "Description", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "3 Days/2 Nights Goa Tour", 5000m, "Goa Beach Trip" },
                    { 2, "5 Days Trekking in Himalayas", 12000m, "Himalaya Trek" },
                    { 3, "4 Days Houseboat Tour", 8000m, "Kerala Backwaters" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "admin@test.com", "Admin", "admin123", "Admin" },
                    { 2, "john@test.com", "John Doe", "john123", "Customer" },
                    { 3, "jane@test.com", "Jane Smith", "jane123", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "AmountPaid", "BookingDate", "ConfirmedOn", "Seats", "TourPackageId", "UserId" },
                values: new object[,]
                {
                    { 1, 10000m, new DateTime(2025, 9, 20, 16, 17, 57, 159, DateTimeKind.Local).AddTicks(3979), new DateTime(2025, 9, 10, 16, 17, 57, 159, DateTimeKind.Local).AddTicks(4019), 2, 1, 2 },
                    { 2, 8000m, new DateTime(2025, 9, 15, 16, 17, 57, 159, DateTimeKind.Local).AddTicks(4029), new DateTime(2025, 9, 10, 16, 17, 57, 159, DateTimeKind.Local).AddTicks(4030), 1, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TourPackageId",
                table: "Bookings",
                column: "TourPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "TourPackages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
