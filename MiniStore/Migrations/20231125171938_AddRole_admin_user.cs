using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniStore.Migrations
{
    /// <inheritdoc />
    public partial class AddRole_admin_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 25, 19, 19, 37, 763, DateTimeKind.Local).AddTicks(7175),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 25, 11, 32, 12, 55, DateTimeKind.Local).AddTicks(8879));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9abeba0a-d65d-4f31-b6a0-39d5fee94ecd", "9e6e48db-c10a-4349-bd7a-8015e5895704", "User", "user" },
                    { "a1463c00-1271-4dbc-ae07-2a31f390cdb6", "1d25167e-6517-41ee-8a75-f88e8519da27", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9abeba0a-d65d-4f31-b6a0-39d5fee94ecd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1463c00-1271-4dbc-ae07-2a31f390cdb6");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 25, 11, 32, 12, 55, DateTimeKind.Local).AddTicks(8879),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 25, 19, 19, 37, 763, DateTimeKind.Local).AddTicks(7175));
        }
    }
}
