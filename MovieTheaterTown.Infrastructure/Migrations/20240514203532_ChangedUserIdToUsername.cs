using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheaterTown.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedUserIdToUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersMovie",
                table: "UsersMovie");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "UsersMovie",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersMovie",
                table: "UsersMovie",
                columns: new[] { "UserName", "MovieId" });

            migrationBuilder.CreateIndex(
                name: "IX_UsersMovie_UserId",
                table: "UsersMovie",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersMovie",
                table: "UsersMovie");

            migrationBuilder.DropIndex(
                name: "IX_UsersMovie_UserId",
                table: "UsersMovie");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "UsersMovie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersMovie",
                table: "UsersMovie",
                columns: new[] { "UserId", "MovieId" });
        }
    }
}
