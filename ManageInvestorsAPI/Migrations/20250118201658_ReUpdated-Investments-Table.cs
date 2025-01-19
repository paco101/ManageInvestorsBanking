using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageInvestors.Migrations
{
    /// <inheritdoc />
    public partial class ReUpdatedInvestmentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investments_Funds_FundId",
                table: "Investments");

            migrationBuilder.DropForeignKey(
                name: "FK_Investments_Investors_InvestorId",
                table: "Investments");

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_Funds_FundId",
                table: "Investments",
                column: "FundId",
                principalTable: "Funds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_Investors_InvestorId",
                table: "Investments",
                column: "InvestorId",
                principalTable: "Investors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investments_Funds_FundId",
                table: "Investments");

            migrationBuilder.DropForeignKey(
                name: "FK_Investments_Investors_InvestorId",
                table: "Investments");

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_Funds_FundId",
                table: "Investments",
                column: "FundId",
                principalTable: "Funds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_Investors_InvestorId",
                table: "Investments",
                column: "InvestorId",
                principalTable: "Investors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
