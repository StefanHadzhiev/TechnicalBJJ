using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicalBJJ.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Steps",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Steps",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "StartingPositions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StartingPositions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Images",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Images",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Steps_IsDeleted",
                table: "Steps",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StartingPositions_IsDeleted",
                table: "StartingPositions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Images_IsDeleted",
                table: "Images",
                column: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Steps_IsDeleted",
                table: "Steps");

            migrationBuilder.DropIndex(
                name: "IX_StartingPositions_IsDeleted",
                table: "StartingPositions");

            migrationBuilder.DropIndex(
                name: "IX_Images_IsDeleted",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "StartingPositions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StartingPositions");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Images");
        }
    }
}
