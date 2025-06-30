using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoundingPortal_API.Migrations
{
    /// <inheritdoc />
    public partial class AddedmorepropertiesforIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReportedDate",
                table: "Issues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ReporterId",
                table: "Issues",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Issues_ReporterId",
                table: "Issues",
                column: "ReporterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Rounders_ReporterId",
                table: "Issues",
                column: "ReporterId",
                principalTable: "Rounders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Rounders_ReporterId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_ReporterId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "ReportedDate",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "ReporterId",
                table: "Issues");
        }
    }
}
