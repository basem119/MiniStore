using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniStore.Migrations
{
    /// <inheritdoc />
    public partial class Add_productPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9abeba0a-d65d-4f31-b6a0-39d5fee94ecd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1463c00-1271-4dbc-ae07-2a31f390cdb6");

            migrationBuilder.AddColumn<byte[]>(
                name: "productPhoto",
                table: "Products",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 1, 15, 45, 11, 386, DateTimeKind.Local).AddTicks(1147),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 25, 19, 19, 37, 763, DateTimeKind.Local).AddTicks(7175));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f910f42-7938-4431-a0ba-2a9692f78b2b", "bd81c551-481c-44e6-9710-5ba61d2a29b7", "User", "user" },
                    { "612d9ed5-8539-4ed9-83e7-801aa1fc3e7d", "20163829-af02-4c87-b4b5-f05f25b4780e", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f910f42-7938-4431-a0ba-2a9692f78b2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "612d9ed5-8539-4ed9-83e7-801aa1fc3e7d");

            migrationBuilder.DropColumn(
                name: "productPhoto",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 25, 19, 19, 37, 763, DateTimeKind.Local).AddTicks(7175),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 1, 15, 45, 11, 386, DateTimeKind.Local).AddTicks(1147));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9abeba0a-d65d-4f31-b6a0-39d5fee94ecd", "9e6e48db-c10a-4349-bd7a-8015e5895704", "User", "user" },
                    { "a1463c00-1271-4dbc-ae07-2a31f390cdb6", "1d25167e-6517-41ee-8a75-f88e8519da27", "Admin", "admin" }
                });
        }
    }
}
