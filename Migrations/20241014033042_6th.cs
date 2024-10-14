using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VinxTech.API.Migrations
{
    /// <inheritdoc />
    public partial class _6th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Breanch",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "IdExpiryDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IdNumber",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { 4, new DateTime(2024, 10, 14, 3, 30, 42, 190, DateTimeKind.Utc).AddTicks(4420), "Responsible for handling transactions and managing customer payments.", "Cashier", new DateTime(2024, 10, 14, 3, 30, 42, 190, DateTimeKind.Utc).AddTicks(4420) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Breanch",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdExpiryDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "Users");

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
    }
}
