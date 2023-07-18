﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnDijon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddressUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Address");
        }
    }
}
