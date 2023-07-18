using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnDijon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeanOfLocomotion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeanOfLocomotion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReasonForTravel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonForTravel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeanOfLocomotionId = table.Column<int>(type: "int", nullable: true),
                    ReasonForTravelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_MeanOfLocomotion_MeanOfLocomotionId",
                        column: x => x.MeanOfLocomotionId,
                        principalTable: "MeanOfLocomotion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_ReasonForTravel_ReasonForTravelId",
                        column: x => x.ReasonForTravelId,
                        principalTable: "ReasonForTravel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_MeanOfLocomotionId",
                table: "User",
                column: "MeanOfLocomotionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ReasonForTravelId",
                table: "User",
                column: "ReasonForTravelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "MeanOfLocomotion");

            migrationBuilder.DropTable(
                name: "ReasonForTravel");
        }
    }
}
