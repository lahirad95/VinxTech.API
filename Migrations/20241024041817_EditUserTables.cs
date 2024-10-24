using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VinxTech.API.Migrations
{
    /// <inheritdoc />
    public partial class EditUserTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "IdExpiryDate",
                table: "Employees",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 24, 4, 18, 17, 67, DateTimeKind.Utc).AddTicks(2563), new DateTime(2024, 10, 24, 4, 18, 17, 67, DateTimeKind.Utc).AddTicks(2566) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 24, 4, 18, 17, 67, DateTimeKind.Utc).AddTicks(2569), new DateTime(2024, 10, 24, 4, 18, 17, 67, DateTimeKind.Utc).AddTicks(2570) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 24, 4, 18, 17, 67, DateTimeKind.Utc).AddTicks(2573), new DateTime(2024, 10, 24, 4, 18, 17, 67, DateTimeKind.Utc).AddTicks(2573) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 24, 4, 18, 17, 67, DateTimeKind.Utc).AddTicks(2576), new DateTime(2024, 10, 24, 4, 18, 17, 67, DateTimeKind.Utc).AddTicks(2576) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2024, 10, 24, 4, 18, 17, 67, DateTimeKind.Utc).AddTicks(2578), "Responsible for handling the Branch.", "Branch Manager", new DateTime(2024, 10, 24, 4, 18, 17, 67, DateTimeKind.Utc).AddTicks(2579) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IdExpiryDate",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
    }
}
