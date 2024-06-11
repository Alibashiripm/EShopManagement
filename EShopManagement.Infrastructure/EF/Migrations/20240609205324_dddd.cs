using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShopManagement.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class dddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PremiumId",
                table: "UserPremiums");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PremiumId",
                table: "UserPremiums",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
