using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VinxTech.API.Migrations
{
    /// <inheritdoc />
    public partial class AddServicesTable4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeeServices_EmployeeId",
                table: "EmployeeServices");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeServices_ServiceID",
                table: "EmployeeServices");

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

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeServices_EmployeeId_ServiceID",
                table: "EmployeeServices",
                columns: new[] { "EmployeeId", "ServiceID" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeeServices_EmployeeId_ServiceID",
                table: "EmployeeServices");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 18, 54, 42, 468, DateTimeKind.Utc).AddTicks(4073), new DateTime(2024, 10, 9, 18, 54, 42, 468, DateTimeKind.Utc).AddTicks(4075) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 18, 54, 42, 468, DateTimeKind.Utc).AddTicks(4077), new DateTime(2024, 10, 9, 18, 54, 42, 468, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 9, 18, 54, 42, 468, DateTimeKind.Utc).AddTicks(4079), new DateTime(2024, 10, 9, 18, 54, 42, 468, DateTimeKind.Utc).AddTicks(4080) });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeServices_EmployeeId",
                table: "EmployeeServices",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeServices_ServiceID",
                table: "EmployeeServices",
                column: "ServiceID",
                unique: true);
        }
    }
}
