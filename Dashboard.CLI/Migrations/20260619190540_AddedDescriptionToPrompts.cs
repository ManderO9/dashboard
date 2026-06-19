using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboard.CLI.Migrations
{
    /// <inheritdoc />
    public partial class AddedDescriptionToPrompts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Prompt",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Prompt");
        }
    }
}
