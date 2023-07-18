using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnDijon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ShelterForeignKeyRestrict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShelterHistory_Shelter_ShelterId",
                table: "ShelterHistory");

            migrationBuilder.AddForeignKey(
                name: "FK_ShelterHistory_Shelter_ShelterId",
                table: "ShelterHistory",
                column: "ShelterId",
                principalTable: "Shelter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShelterHistory_Shelter_ShelterId",
                table: "ShelterHistory");

            migrationBuilder.AddForeignKey(
                name: "FK_ShelterHistory_Shelter_ShelterId",
                table: "ShelterHistory",
                column: "ShelterId",
                principalTable: "Shelter",
                principalColumn: "Id");
        }
    }
}
