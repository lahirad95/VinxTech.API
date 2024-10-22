using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VinxTech.API.Migrations
{
    /// <inheritdoc />
    public partial class AddGenderNationality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 20, 19, 13, 21, 23, DateTimeKind.Utc).AddTicks(4526), new DateTime(2024, 10, 20, 19, 13, 21, 23, DateTimeKind.Utc).AddTicks(4529) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 20, 19, 13, 21, 23, DateTimeKind.Utc).AddTicks(4535), new DateTime(2024, 10, 20, 19, 13, 21, 23, DateTimeKind.Utc).AddTicks(4536) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 20, 19, 13, 21, 23, DateTimeKind.Utc).AddTicks(4538), new DateTime(2024, 10, 20, 19, 13, 21, 23, DateTimeKind.Utc).AddTicks(4539) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 20, 19, 13, 21, 23, DateTimeKind.Utc).AddTicks(4541), new DateTime(2024, 10, 20, 19, 13, 21, 23, DateTimeKind.Utc).AddTicks(4542) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 17, 3, 59, 44, 252, DateTimeKind.Utc).AddTicks(6979), new DateTime(2024, 10, 17, 3, 59, 44, 252, DateTimeKind.Utc).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 17, 3, 59, 44, 252, DateTimeKind.Utc).AddTicks(6984), new DateTime(2024, 10, 17, 3, 59, 44, 252, DateTimeKind.Utc).AddTicks(6984) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 17, 3, 59, 44, 252, DateTimeKind.Utc).AddTicks(6986), new DateTime(2024, 10, 17, 3, 59, 44, 252, DateTimeKind.Utc).AddTicks(6987) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 17, 3, 59, 44, 252, DateTimeKind.Utc).AddTicks(6989), new DateTime(2024, 10, 17, 3, 59, 44, 252, DateTimeKind.Utc).AddTicks(6989) });
        }
    }
}
