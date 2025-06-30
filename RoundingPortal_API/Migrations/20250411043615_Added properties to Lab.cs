using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoundingPortal_API.Migrations
{
    /// <inheritdoc />
    public partial class AddedpropertiestoLab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastRoundedDate",
                table: "Labs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PreviousRounderId",
                table: "Labs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Labs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Labs_PreviousRounderId",
                table: "Labs",
                column: "PreviousRounderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Labs_Users_PreviousRounderId",
                table: "Labs",
                column: "PreviousRounderId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labs_Users_PreviousRounderId",
                table: "Labs");

            migrationBuilder.DropIndex(
                name: "IX_Labs_PreviousRounderId",
                table: "Labs");

            migrationBuilder.DropColumn(
                name: "LastRoundedDate",
                table: "Labs");

            migrationBuilder.DropColumn(
                name: "PreviousRounderId",
                table: "Labs");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Labs");
        }
    }
}
