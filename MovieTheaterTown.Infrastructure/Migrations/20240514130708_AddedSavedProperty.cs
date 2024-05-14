using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheaterTown.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedSavedProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Saved",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Saved",
                table: "Movies");
        }
    }
}
