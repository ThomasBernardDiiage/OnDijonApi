using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnDijon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeys3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ShelterReporting",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ShelterReporting_UserId",
                table: "ShelterReporting",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShelterReporting_User_UserId",
                table: "ShelterReporting",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShelterReporting_User_UserId",
                table: "ShelterReporting");

            migrationBuilder.DropIndex(
                name: "IX_ShelterReporting_UserId",
                table: "ShelterReporting");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShelterReporting",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
