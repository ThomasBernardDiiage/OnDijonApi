using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnDijon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Shelter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_MeanOfLocomotion_MeanOfLocomotionId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ReasonForTravel_ReasonForTravelId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_MeanOfLocomotionId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ReasonForTravelId",
                table: "User");

            migrationBuilder.CreateTable(
                name: "Shelter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    MaxCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelter", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shelter");

            migrationBuilder.CreateIndex(
                name: "IX_User_MeanOfLocomotionId",
                table: "User",
                column: "MeanOfLocomotionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ReasonForTravelId",
                table: "User",
                column: "ReasonForTravelId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_MeanOfLocomotion_MeanOfLocomotionId",
                table: "User",
                column: "MeanOfLocomotionId",
                principalTable: "MeanOfLocomotion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ReasonForTravel_ReasonForTravelId",
                table: "User",
                column: "ReasonForTravelId",
                principalTable: "ReasonForTravel",
                principalColumn: "Id");
        }
    }
}
