using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Migrations
{
    /// <inheritdoc />
    public partial class ImageAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "TourPackages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookingDate", "ConfirmedOn" },
                values: new object[] { new DateTime(2025, 9, 20, 20, 23, 16, 457, DateTimeKind.Local).AddTicks(2922), new DateTime(2025, 9, 10, 20, 23, 16, 457, DateTimeKind.Local).AddTicks(2960) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookingDate", "ConfirmedOn" },
                values: new object[] { new DateTime(2025, 9, 15, 20, 23, 16, 457, DateTimeKind.Local).AddTicks(2967), new DateTime(2025, 9, 10, 20, 23, 16, 457, DateTimeKind.Local).AddTicks(2968) });

            migrationBuilder.UpdateData(
                table: "TourPackages",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/goa.jpg");

            migrationBuilder.UpdateData(
                table: "TourPackages",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/himalaya.jpg");

            migrationBuilder.UpdateData(
                table: "TourPackages",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/images/kerala.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "TourPackages");

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookingDate", "ConfirmedOn" },
                values: new object[] { new DateTime(2025, 9, 20, 16, 17, 57, 159, DateTimeKind.Local).AddTicks(3979), new DateTime(2025, 9, 10, 16, 17, 57, 159, DateTimeKind.Local).AddTicks(4019) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookingDate", "ConfirmedOn" },
                values: new object[] { new DateTime(2025, 9, 15, 16, 17, 57, 159, DateTimeKind.Local).AddTicks(4029), new DateTime(2025, 9, 10, 16, 17, 57, 159, DateTimeKind.Local).AddTicks(4030) });
        }
    }
}
