using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace boutaburger.Migrations.MenuItemDb
{
    /// <inheritdoc />
    public partial class AddPicsColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pics",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pics",
                table: "MenuItems");
        }
    }
}
