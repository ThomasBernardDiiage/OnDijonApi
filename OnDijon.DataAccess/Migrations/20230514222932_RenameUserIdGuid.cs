using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnDijon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenameUserIdGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "User",
                newName: "Guid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "User",
                newName: "UserId");
        }
    }
}
