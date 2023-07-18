using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnDijon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeys2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_MeanOfLocomotion_ReasonForTravelId",
                table: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ReasonForTravel_ReasonForTravelId",
                table: "User",
                column: "ReasonForTravelId",
                principalTable: "ReasonForTravel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_ReasonForTravel_ReasonForTravelId",
                table: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_User_MeanOfLocomotion_ReasonForTravelId",
                table: "User",
                column: "ReasonForTravelId",
                principalTable: "MeanOfLocomotion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
