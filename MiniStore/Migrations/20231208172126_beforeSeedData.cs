using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniStore.Migrations
{
    /// <inheritdoc />
    public partial class beforeSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.AlterColumn<byte[]>(
                name: "productPhoto",
                table: "Products",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 8, 19, 21, 26, 394, DateTimeKind.Local).AddTicks(5336),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 5, 17, 5, 25, 319, DateTimeKind.Local).AddTicks(540));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "productPhoto",
                table: "Products",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 5, 17, 5, 25, 319, DateTimeKind.Local).AddTicks(540),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 8, 19, 21, 26, 394, DateTimeKind.Local).AddTicks(5336));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2771dc5c-e2d9-4c17-8246-8878569189aa", "4a9f143d-068f-4595-bd5d-ac1ec7fa2b4d", "Admin", "admin" },
                    { "3d44c93b-efac-4758-a0f2-e4b2ecd219b3", "ce85e82c-c323-4cb2-ac9d-dcb98ca0e950", "User", "user" }
                });
        }
    }
}
