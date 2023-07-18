using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnDijon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ShelterForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ShelterHistory_ShelterId",
                table: "ShelterHistory",
                column: "ShelterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShelterHistory_Shelter_ShelterId",
                table: "ShelterHistory",
                column: "ShelterId",
                principalTable: "Shelter",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShelterHistory_Shelter_ShelterId",
                table: "ShelterHistory");

            migrationBuilder.DropIndex(
                name: "IX_ShelterHistory_ShelterId",
                table: "ShelterHistory");
        }
    }
}
