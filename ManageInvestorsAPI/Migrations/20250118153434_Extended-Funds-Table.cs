using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageInvestors.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedFundsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ISIN",
                table: "Funds",
                type: "varchar(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProviderName",
                table: "Funds",
                type: "varchar(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Funds",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISIN",
                table: "Funds");

            migrationBuilder.DropColumn(
                name: "ProviderName",
                table: "Funds");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Funds");
        }
    }
}
