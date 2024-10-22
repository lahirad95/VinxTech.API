using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VinxTech.API.Migrations
{
    /// <inheritdoc />
    public partial class AddImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 14, 3, 30, 42, 190, DateTimeKind.Utc).AddTicks(4409), new DateTime(2024, 10, 14, 3, 30, 42, 190, DateTimeKind.Utc).AddTicks(4412) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 14, 3, 30, 42, 190, DateTimeKind.Utc).AddTicks(4415), new DateTime(2024, 10, 14, 3, 30, 42, 190, DateTimeKind.Utc).AddTicks(4416) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 14, 3, 30, 42, 190, DateTimeKind.Utc).AddTicks(4418), new DateTime(2024, 10, 14, 3, 30, 42, 190, DateTimeKind.Utc).AddTicks(4418) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 14, 3, 30, 42, 190, DateTimeKind.Utc).AddTicks(4420), new DateTime(2024, 10, 14, 3, 30, 42, 190, DateTimeKind.Utc).AddTicks(4420) });
        }
    }
}
