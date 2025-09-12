using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingStatusRefund : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "RefundAmount",
                table: "Bookings",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookingDate", "ConfirmedOn", "RefundAmount", "Status" },
                values: new object[] { new DateTime(2025, 9, 21, 10, 14, 15, 687, DateTimeKind.Local).AddTicks(2317), new DateTime(2025, 9, 11, 10, 14, 15, 687, DateTimeKind.Local).AddTicks(2339), null, 0 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookingDate", "ConfirmedOn", "RefundAmount", "Status" },
                values: new object[] { new DateTime(2025, 9, 16, 10, 14, 15, 687, DateTimeKind.Local).AddTicks(2344), new DateTime(2025, 9, 11, 10, 14, 15, 687, DateTimeKind.Local).AddTicks(2345), null, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefundAmount",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bookings");

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
        }
    }
}
