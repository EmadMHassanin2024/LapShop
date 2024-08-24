using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LapShop.Migrations
{
    /// <inheritdoc />
    public partial class ColumSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastPanner2",
                table: "TbSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastPanner2",
                table: "TbSettings");
        }
    }
}
