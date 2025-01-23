using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOrganization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "production_date",
                table: "computers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 9, 13, 42, 16, 208, DateTimeKind.Local).AddTicks(6850),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2024, 11, 20, 11, 54, 7, 940, DateTimeKind.Local).AddTicks(1760));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "production_date",
                table: "computers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 20, 11, 54, 7, 940, DateTimeKind.Local).AddTicks(1760),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2025, 1, 9, 13, 42, 16, 208, DateTimeKind.Local).AddTicks(6850));
        }
    }
}
