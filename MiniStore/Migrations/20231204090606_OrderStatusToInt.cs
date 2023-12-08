using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniStore.Migrations
{
    /// <inheritdoc />
    public partial class OrderStatusToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "0f910f42-7938-4431-a0ba-2a9692f78b2b");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "612d9ed5-8539-4ed9-83e7-801aa1fc3e7d");

            migrationBuilder.AlterColumn<int>(
                name: "OrderStatus",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 4, 11, 6, 5, 837, DateTimeKind.Local).AddTicks(9888),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 1, 15, 45, 11, 386, DateTimeKind.Local).AddTicks(1147));

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { "587ca7ee-2db6-4594-ad55-930d628c4728", "af73b531-11b0-4bac-9493-f66879aedd03", "User", "user" },
            //        { "6e2bd2d8-df26-4c3a-b6ba-16577294152e", "9a2c512e-acc5-49d9-8473-3bd7c944c6f4", "Admin", "admin" }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "587ca7ee-2db6-4594-ad55-930d628c4728");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "6e2bd2d8-df26-4c3a-b6ba-16577294152e");

            migrationBuilder.AlterColumn<bool>(
                name: "OrderStatus",
                table: "Orders",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 1, 15, 45, 11, 386, DateTimeKind.Local).AddTicks(1147),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 4, 11, 6, 5, 837, DateTimeKind.Local).AddTicks(9888));

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { "0f910f42-7938-4431-a0ba-2a9692f78b2b", "bd81c551-481c-44e6-9710-5ba61d2a29b7", "User", "user" },
            //        { "612d9ed5-8539-4ed9-83e7-801aa1fc3e7d", "20163829-af02-4c87-b4b5-f05f25b4780e", "Admin", "admin" }
            //    });
        }
    }
}
