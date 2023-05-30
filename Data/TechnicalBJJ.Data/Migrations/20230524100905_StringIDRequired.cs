using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicalBJJ.Data.Migrations
{
    /// <inheritdoc />
    public partial class StringIDRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Techniques_StartingPositions_StartingPositionId",
                table: "Techniques");

            migrationBuilder.AlterColumn<string>(
                name: "StartingPositionId",
                table: "Techniques",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Techniques_StartingPositions_StartingPositionId",
                table: "Techniques",
                column: "StartingPositionId",
                principalTable: "StartingPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Techniques_StartingPositions_StartingPositionId",
                table: "Techniques");

            migrationBuilder.AlterColumn<string>(
                name: "StartingPositionId",
                table: "Techniques",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Techniques_StartingPositions_StartingPositionId",
                table: "Techniques",
                column: "StartingPositionId",
                principalTable: "StartingPositions",
                principalColumn: "Id");
        }
    }
}
