using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f8fca1c2-9e6f-42ea-aa7f-50ae7dcc5a06", "64fb6a85-8bae-49c9-889f-a78ffa97dead" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8fca1c2-9e6f-42ea-aa7f-50ae7dcc5a06");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64fb6a85-8bae-49c9-889f-a78ffa97dead");

            migrationBuilder.AlterColumn<DateTime>(
                name: "production_date",
                table: "computers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 23, 12, 40, 5, 902, DateTimeKind.Local).AddTicks(660),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2025, 1, 9, 15, 5, 5, 305, DateTimeKind.Local).AddTicks(9320));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c9b65e22-9c49-4c0c-8946-39efd1ae561b", "c9b65e22-9c49-4c0c-8946-39efd1ae561b", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "adadf1b3-3c5e-46ea-9f24-73725735cb05", 0, "6a8377d8-3f7a-4a3b-86eb-36941d5bbd9a", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM@WSEI.EDU.PL", "AQAAAAIAAYagAAAAEMFFbTAOs5GqTNsIai6k3CBzCHsxvDY9W9p9Ml0bjtNBdTy8mAGZoyEKM0lG1dQ4jQ==", null, false, "911269af-4024-4c3f-9832-dd0e230f0771", false, "adam@wsei.edu.pl" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c9b65e22-9c49-4c0c-8946-39efd1ae561b", "adadf1b3-3c5e-46ea-9f24-73725735cb05" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c9b65e22-9c49-4c0c-8946-39efd1ae561b", "adadf1b3-3c5e-46ea-9f24-73725735cb05" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9b65e22-9c49-4c0c-8946-39efd1ae561b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adadf1b3-3c5e-46ea-9f24-73725735cb05");

            migrationBuilder.AlterColumn<DateTime>(
                name: "production_date",
                table: "computers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 9, 15, 5, 5, 305, DateTimeKind.Local).AddTicks(9320),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2025, 1, 23, 12, 40, 5, 902, DateTimeKind.Local).AddTicks(660));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f8fca1c2-9e6f-42ea-aa7f-50ae7dcc5a06", "f8fca1c2-9e6f-42ea-aa7f-50ae7dcc5a06", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "64fb6a85-8bae-49c9-889f-a78ffa97dead", 0, "9abd3978-343e-46ae-b840-5d372213cd18", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADMIN", "AQAAAAIAAYagAAAAEN+p5wsRZ4NtwZqvZBUPtfzLEnWxxbhGjrN7qZ5YQHlJVeKbhVZ9AfQWfr8R+j7grA==", null, false, "a54af87e-3ddd-4be4-af02-03919de87f23", false, "adam" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f8fca1c2-9e6f-42ea-aa7f-50ae7dcc5a06", "64fb6a85-8bae-49c9-889f-a78ffa97dead" });
        }
    }
}
