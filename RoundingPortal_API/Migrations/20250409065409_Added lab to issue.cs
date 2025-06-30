using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoundingPortal_API.Migrations
{
    /// <inheritdoc />
    public partial class Addedlabtoissue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LabId",
                table: "Issues",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Issues_LabId",
                table: "Issues",
                column: "LabId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Labs_LabId",
                table: "Issues",
                column: "LabId",
                principalTable: "Labs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Labs_LabId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_LabId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "LabId",
                table: "Issues");
        }
    }
}
