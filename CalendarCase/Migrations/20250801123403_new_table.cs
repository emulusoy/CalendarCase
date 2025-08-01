using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalendarCase.Migrations
{
    /// <inheritdoc />
    public partial class new_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Categories_CategoryId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_CategoryId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "IsAllDay",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Events",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAllDay",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Events",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Categories_CategoryId",
                table: "Events",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
