using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VinxTech.API.Migrations
{
    /// <inheritdoc />
    public partial class _4th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 20, 20, 52, 294, DateTimeKind.Utc).AddTicks(1080), new DateTime(2024, 10, 9, 20, 20, 52, 294, DateTimeKind.Utc).AddTicks(1084) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 20, 20, 52, 294, DateTimeKind.Utc).AddTicks(1087), new DateTime(2024, 10, 9, 20, 20, 52, 294, DateTimeKind.Utc).AddTicks(1087) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 20, 20, 52, 294, DateTimeKind.Utc).AddTicks(1089), new DateTime(2024, 10, 9, 20, 20, 52, 294, DateTimeKind.Utc).AddTicks(1090) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 19, 1, 54, 931, DateTimeKind.Utc).AddTicks(1969), new DateTime(2024, 10, 9, 19, 1, 54, 931, DateTimeKind.Utc).AddTicks(1970) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 19, 1, 54, 931, DateTimeKind.Utc).AddTicks(1972), new DateTime(2024, 10, 9, 19, 1, 54, 931, DateTimeKind.Utc).AddTicks(1972) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 19, 1, 54, 931, DateTimeKind.Utc).AddTicks(1974), new DateTime(2024, 10, 9, 19, 1, 54, 931, DateTimeKind.Utc).AddTicks(1974) });
        }
    }
}
