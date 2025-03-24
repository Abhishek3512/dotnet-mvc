using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DovetailSol.Migrations
{
    /// <inheritdoc />
    public partial class AddCityColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "EMP",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "EMP");
        }
    }
}
