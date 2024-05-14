using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheaterTown.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersMovie_AspNetUsers_UserId",
                table: "UsersMovie");

            migrationBuilder.DropIndex(
                name: "IX_UsersMovie_UserId",
                table: "UsersMovie");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UsersMovie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UsersMovie",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UsersMovie_UserId",
                table: "UsersMovie",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersMovie_AspNetUsers_UserId",
                table: "UsersMovie",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
