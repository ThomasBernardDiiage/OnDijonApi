using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnDijon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Address",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_User_MeanOfLocomotionId",
                table: "User",
                column: "MeanOfLocomotionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ReasonForTravelId",
                table: "User",
                column: "ReasonForTravelId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                table: "Address",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_User_UserId",
                table: "Address",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_MeanOfLocomotion_MeanOfLocomotionId",
                table: "User",
                column: "MeanOfLocomotionId",
                principalTable: "MeanOfLocomotion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_MeanOfLocomotion_ReasonForTravelId",
                table: "User",
                column: "ReasonForTravelId",
                principalTable: "MeanOfLocomotion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_User_UserId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_User_MeanOfLocomotion_MeanOfLocomotionId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_MeanOfLocomotion_ReasonForTravelId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_MeanOfLocomotionId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ReasonForTravelId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Address_UserId",
                table: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
