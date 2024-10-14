using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VinxTech.API.Migrations
{
    /// <inheritdoc />
    public partial class _5th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "EmployeeId",
                table: "EmployeeServices",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "IdNumber",
                table: "Employees",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 20, 24, 55, 621, DateTimeKind.Utc).AddTicks(6399), new DateTime(2024, 10, 9, 20, 24, 55, 621, DateTimeKind.Utc).AddTicks(6401) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 20, 24, 55, 621, DateTimeKind.Utc).AddTicks(6405), new DateTime(2024, 10, 9, 20, 24, 55, 621, DateTimeKind.Utc).AddTicks(6405) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 20, 24, 55, 621, DateTimeKind.Utc).AddTicks(6407), new DateTime(2024, 10, 9, 20, 24, 55, 621, DateTimeKind.Utc).AddTicks(6408) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "EmployeeServices",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "IdNumber",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

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
    }
}
